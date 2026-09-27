using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections;

public class MemoryBundlePatcher
{
    // Point d'entrée de votre Coroutine appelée de n'importe où
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
        // Définir le chemin vers l'exécutable autonome Python
#if UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
        string exePath = Path.Combine(Application.streamingAssetsPath, "patch_stream/patch_stream"); 
#else
        string exePath = Path.Combine(Application.streamingAssetsPath, "patch_stream/patch_stream.exe"); 
#endif
        // Note pour Linux standalone : assurez-vous d'utiliser le nom du binaire Linux sans extension et d'accorder les droits chmod +x

        if (!File.Exists(exePath))
        {
            UnityEngine.Debug.LogError($"[Patcher] Convertisseur introuvable à l'adresse : {exePath}");
            callback?.Invoke(originalBytes);
            yield break;
        }

        // Configurer le processus pour rediriger les flux standard d'octets bruts
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = exePath;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardInput = true;  // Permet d'envoyer nos bytes
        startInfo.RedirectStandardOutput = true; // Permet de recevoir le bundle patché
        startInfo.RedirectStandardError = true;  // Permet de lire les erreurs Python éventuelles

        UnityEngine.Debug.Log($"[Patcher] Start patch");
        Process process = null;
        try
        {
            process = Process.Start(startInfo);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError($"[Patcher] Impossible de démarrer le processus : {e.Message}");
            callback?.Invoke(originalBytes);
            yield break;
        }

        // 1. ÉCRITURE : Pousser le buffer mémoire de l'AssetBundle dans le canal d'entrée de Python
        // On effectue cela de manière asynchrone pour ne pas bloquer le thread principal d'Unity
        var inputStream = process.StandardInput.BaseStream;
        var writeTask = inputStream.WriteAsync(originalBytes, 0, originalBytes.Length);
        
        while (!writeTask.IsCompleted) yield return null;
        inputStream.Flush();
        process.StandardInput.Close(); // Signale à Python qu'on a fini d'envoyer les données

        UnityEngine.Debug.Log($"[Patcher] Write done");

        // 2. LECTURE : Récupérer le flux binaire de sortie généré par UnityPy
        byte[] patchedBytes = null;
        using (MemoryStream outputMs = new MemoryStream())
        {
            var outputStream = process.StandardOutput.BaseStream;
            byte[] buffer = new byte[4096];
            int bytesRead;

            UnityEngine.Debug.Log($"[Patcher] Start wait result");

            // Lire le flux binaire continu envoyé par le processus Python
            while (true)
            {
                var readTask = outputStream.ReadAsync(buffer, 0, buffer.Length);
                while (!readTask.IsCompleted) yield return null;
                
                bytesRead = readTask.Result;
                if (bytesRead <= 0) break; // Fin du flux binaire
                
                outputMs.Write(buffer, 0, bytesRead);
            }
            patchedBytes = outputMs.ToArray();

            UnityEngine.Debug.Log($"[Patcher] End wait result");
        }

        // 3. Traitement des erreurs de script
        if (process.HasExited && process.ExitCode != 0)
        {
            string errorLog = process.StandardError.ReadToEnd();
            UnityEngine.Debug.LogError($"[Patcher] Le script Python a renvoyé une erreur :\n{errorLog}");
            callback?.Invoke(originalBytes);
            process.Dispose();
            yield break;
        }

        process.Dispose();

        callback?.Invoke(patchedBytes);
    }
}
