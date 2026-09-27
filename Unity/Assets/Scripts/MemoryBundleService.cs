using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

public class MemoryBundleService : MonoBehaviour
{
    private static MemoryBundleService _instance;
    public static MemoryBundleService Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("MemoryBundleService_Core");
                _instance = go.AddComponent<MemoryBundleService>();
                DontDestroyOnLoad(go);
                _instance.InitializeService();
            }
            return _instance;
        }
    }

    private Process _pythonProcess;
    private Stream _toPython;
    private Stream _fromPython;
    private bool _isReady = false;
    private bool _isProcessing = false;
    private bool _isRestarting = false;
    private bool _canNotStart = false;

    private void InitializeService()
    {
        _isReady = false;
        _isRestarting = false;
        _canNotStart = false;

        string exeName = "patch_service/patch_service.exe";
        #if UNITY_STANDALONE_LINUX
        exeName = "patch_service/patch_service";
        #endif

        string exePath = Path.Combine(Application.streamingAssetsPath, exeName);

        if (!File.Exists(exePath))
        {
            UnityEngine.Debug.LogError($"[BundleService] Converter not found at : {exePath}");
            _canNotStart = true;
            return;
        }

        #if UNITY_STANDALONE_LINUX && !UNITY_EDITOR
        try { Process.Start("chmod", $"+x \"{exePath}\""); } catch {}
        #endif

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = exePath,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        _pythonProcess = new Process { StartInfo = startInfo };
        _pythonProcess.EnableRaisingEvents = true; 
        _pythonProcess.Exited += OnProcessCrashed;  
        _pythonProcess.ErrorDataReceived += OnPythonErrorReceived;
        
        try
        {
            _pythonProcess.Start();
            _pythonProcess.BeginErrorReadLine();
            _toPython = _pythonProcess.StandardInput.BaseStream;
            _fromPython = _pythonProcess.StandardOutput.BaseStream;
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"[BundleService] Can't start the process : {e.Message}");
            _canNotStart = true;
        }
    }

    private void OnPythonErrorReceived(object sender, DataReceivedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.Data)) return;

        if (e.Data == "READY")
        {
            _isReady = true;
            TodoLogger.Log(TodoLogger.BundlePatch, "[BundleService] Python service started in background and ready!");
        }
        else if (e.Data.StartsWith("ERROR:"))
        {
            UnityEngine.Debug.LogError($"[BundleService] {e.Data}");
            _isProcessing = false; 
        }
    }

    private void OnProcessCrashed(object sender, EventArgs e)
    {
        if (_isRestarting) return; 
        _isRestarting = true;
        _isReady = false;
        _isProcessing = false;

        UnityEngine.Debug.LogWarning("[BundleService] Process unexpected close, Restart...");

        try { _toPython?.Close(); } catch {}
        try { _fromPython?.Close(); } catch {}
        try { _pythonProcess?.Dispose(); } catch {}

        InitializeService();
    }

    public void ConvertBundle(byte[] androidBytes, Action<byte[]> onComplete)
    {
        StartCoroutine(ConvertRoutine(androidBytes, onComplete));
    }

    private IEnumerator ConvertRoutine(byte[] originalBytes, Action<byte[]> callback)
    {
        while (!_isReady || _isProcessing)
        {
            yield return null;
            if(_canNotStart)
            {
                callback?.Invoke(null);
                yield break;
            }
        }
        _isProcessing = true;

        bool hasError = false;
        byte[] patchedBytes = null;

        // 1. WRITE : Send the size (4 bytes) then the file
        byte[] sizeHeader = BitConverter.GetBytes(originalBytes.Length);
        var writeHeaderTask = _toPython.WriteAsync(sizeHeader, 0, sizeHeader.Length);
        while (!writeHeaderTask.IsCompleted)
        {
            if (!_isReady) { hasError = true; break; }
            yield return null;
        }

        if (!hasError)
        {
            var writeDataTask = _toPython.WriteAsync(originalBytes, 0, originalBytes.Length);
            while (!writeDataTask.IsCompleted)
            {
                if (!_isReady) { hasError = true; break; }
                yield return null;
            }
        }

        if (!hasError)
        {
            try { _toPython.Flush(); } 
            catch { hasError = true; }
        }

        // 2. READ : Get the response size (4 bytes)
        byte[] responseSizeBuffer = new byte[4];
        int headerBytesRead = 0;
        
        while (!hasError && headerBytesRead < 4)
        {
            var readHeaderTask = _fromPython.ReadAsync(responseSizeBuffer, headerBytesRead, 4 - headerBytesRead);
            while (!readHeaderTask.IsCompleted)
            {
                if (!_isReady) { hasError = true; break; }
                yield return null;
            }
            if (hasError) break;

            int readResult = 0;
            try { readResult = readHeaderTask.Result; } catch { hasError = true; }
            
            if (readResult <= 0) { hasError = true; break; }
            headerBytesRead += readResult;
        }

        // 3. READ : Get the bundle result
        if (!hasError)
        {
            int responseSize = BitConverter.ToInt32(responseSizeBuffer, 0);
            patchedBytes = new byte[responseSize];
            int totalBytesRead = 0;

            while (totalBytesRead < responseSize)
            {
                var readDataTask = _fromPython.ReadAsync(patchedBytes, totalBytesRead, responseSize - totalBytesRead);
                while (!readDataTask.IsCompleted)
                {
                    if (!_isReady) { hasError = true; break; }
                    yield return null;
                }
                if (hasError) break;

                int readResult = 0;
                try { readResult = readDataTask.Result; } catch { hasError = true; }

                if (readResult <= 0) { hasError = true; break; }
                totalBytesRead += readResult;
            }
        }

        _isProcessing = false; 

        // 4. Send the result back to the caller script
        if (!hasError && patchedBytes != null && patchedBytes.Length > 0)
        {
            callback?.Invoke(patchedBytes);
        }
        else
        {
            UnityEngine.Debug.LogError("[BundleService] Error during the conversion.");
            callback?.Invoke(null);
        }
    }

    private void OnDestroy()
    {
        if (_pythonProcess != null)
        {
            _pythonProcess.Exited -= OnProcessCrashed;
            try
            {
                _toPython?.Close();
                if (!_pythonProcess.HasExited)
                {
                    _pythonProcess.Kill();
                }
                _pythonProcess.Dispose();
            }
            catch {}
        }
    }
}

/*
public void OnReceiveBundle(byte[] rawAndroidBytes)
{
    // Appel instantané via le service persistant
    MemoryBundleService.Instance.ConvertBundle(rawAndroidBytes, (AssetBundle pcReadyBundle) => 
    {
        if (pcReadyBundle != null)
        {
            GameObject model = pcReadyBundle.LoadAsset<GameObject>("MonPersonnage");
            Instantiate(model);
        }
    });
}
*/