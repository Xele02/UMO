using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections;

public class MemoryBundlePatcher
{
    // Entry point to call
    static public void ConvertBundleInMemory(byte[] androidBundleBytes, Action<byte[]> onComplete)
    {
        #if UNITY_STANDALONE_LINUX
        try {
            string exePath = Path.Combine(Application.streamingAssetsPath, "patch_stream/patch_stream");
            System.Diagnostics.Process.Start("chmod", $"+x \"{exePath}\"");
        } catch { /* ... */ }
#endif
        N.a.StartCoroutineWatched(StreamPatchRoutine(androidBundleBytes, onComplete));
    }

    static private IEnumerator StreamPatchRoutine(byte[] originalBytes, Action<byte[]> callback)
    {
        // Define path to the python executable
#if UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
        string exePath = Path.Combine(Application.streamingAssetsPath, "patch_stream/patch_stream"); 
#else
        string exePath = Path.Combine(Application.streamingAssetsPath, "patch_stream/patch_stream.exe"); 
#endif

        if (!File.Exists(exePath))
        {
            UnityEngine.Debug.LogError($"[Patcher] Converter not found at : {exePath}");
            callback?.Invoke(originalBytes);
            yield break;
        }

        // Config process to redirect input/output
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = exePath;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardInput = true;  // Send our data
        startInfo.RedirectStandardOutput = true; // Receive the bundle data
        startInfo.RedirectStandardError = true;  // Read errors

        TodoLogger.Log(TodoLogger.BundlePatch, $"[Patcher] Start patch");
        Process process = null;
        try
        {
            process = Process.Start(startInfo);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"[Patcher] Can't start the process : {e.Message}");
            callback?.Invoke(originalBytes);
            yield break;
        }

        // 1. WRITE : Async send the bundle to the converter
        var inputStream = process.StandardInput.BaseStream;
        var writeTask = inputStream.WriteAsync(originalBytes, 0, originalBytes.Length);
        
        while (!writeTask.IsCompleted) yield return null;
        inputStream.Flush();
        process.StandardInput.Close();

        UnityEngine.Debug.Log($"[Patcher] Write done");

        // 2. READ : Get the result
        byte[] patchedBytes = null;
        using (MemoryStream outputMs = new MemoryStream())
        {
            var outputStream = process.StandardOutput.BaseStream;
            byte[] buffer = new byte[4096];
            int bytesRead;

            TodoLogger.Log(TodoLogger.BundlePatch, $"[Patcher] Start wait result");

            // Read the stream from the python script
            while (true)
            {
                var readTask = outputStream.ReadAsync(buffer, 0, buffer.Length);
                while (!readTask.IsCompleted) yield return null;
                
                bytesRead = readTask.Result;
                if (bytesRead <= 0) break; // Fin du flux binaire
                
                outputMs.Write(buffer, 0, bytesRead);
            }
            patchedBytes = outputMs.ToArray();

            TodoLogger.Log(TodoLogger.BundlePatch, $"[Patcher] End wait result");
        }

        // 3. Check errors
        if (process.HasExited && process.ExitCode != 0)
        {
            string errorLog = process.StandardError.ReadToEnd();
            UnityEngine.Debug.LogError($"[Patcher] Python script returned an error :\n{errorLog}");
            callback?.Invoke(originalBytes);
            process.Dispose();
            yield break;
        }

        process.Dispose();

        callback?.Invoke(patchedBytes);
    }
}
