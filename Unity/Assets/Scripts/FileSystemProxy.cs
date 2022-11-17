using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp.Game;

static class FileSystemProxy
{
	private static Dictionary<string, string> serverFileList;

	private static bool isInitialized = false;

	static public bool IsInitialized { get { return isInitialized; } }

	static public string ConvertURL(string url)
	{
		if (url.Contains("!s00000000z!"))
		{
			int idx = url.IndexOf("/android/");
			string fileName = url.Substring(idx);
			fileName = fileName.Replace("!s00000000z!", "");
			if(serverFileList.ContainsKey(fileName))
			{
				url = url.Substring(0, idx) + serverFileList[fileName];
			}
			else
			{
				return "";
			}
		}

		if (RuntimeSettings.CurrentSettings == null || string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.DataWebServerURL))
		{
			if (!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.DataDirectory))
			{
				url = url.Replace("[SERVER_DATA_PATH]", "file://" + Path.GetFullPath(RuntimeSettings.CurrentSettings.DataDirectory));
			}
			return url;
		}
		string serverPath = RuntimeSettings.CurrentSettings.DataWebServerURL;
		if (serverPath.EndsWith("/"))
			serverPath = serverPath.Substring(0, serverPath.Length - 1);
		return url.Replace("[SERVER_DATA_PATH]", serverPath);
	}

	static public string ConvertPath(string path)
	{
		path = path.Replace("\\", "/");
		if (File.Exists(path))
			return path;
		if (RuntimeSettings.CurrentSettings == null)
			return path;
		if (path.Contains(UnityEngine.Application.persistentDataPath + "/data") && !string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.DataDirectory))
		{
			string dataDir = RuntimeSettings.CurrentSettings.DataDirectory;
			if (!Path.IsPathRooted(dataDir))
				dataDir = Path.GetFullPath(dataDir);
			if (Directory.Exists(dataDir))
			{
				string new_path = path.Replace(UnityEngine.Application.persistentDataPath + "/data", dataDir);
				if (File.Exists(new_path)) // Search normal name
					return new_path;
				if (File.Exists(new_path + ".decrypted")) // Search normal name + ".decrypted"
					return new_path + ".decrypted";
				string baseName = new_path.Replace(dataDir, "");
				if (serverFileList.ContainsKey(baseName))
				{
					new_path = dataDir + serverFileList[baseName];
					if (File.Exists(new_path)) // Search server format name (with hash)
						return new_path;
					if (File.Exists(new_path + ".decrypted")) // Search server format name (with hash) decrypted
						return new_path + ".decrypted";
				}
			}
		}
		return path;
	}

	public static bool FileExists(string path)
	{
		return File.Exists(ConvertPath(path));
	}

	public static void TryInstallFile(string path, Action<string> onDone)
	{
		string existingPath = ConvertPath(path);
		if (File.Exists(existingPath))
		{
			if (onDone != null)
				onDone(existingPath);
			return;
		}
		if (RuntimeSettings.CurrentSettings != null)
		{
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.DataWebServerURL))
			{
				GameManager.Instance.StartCoroutine(TryInstallFileCoroutine(path, onDone));
				return;
			}
		}
		if (onDone != null)
			onDone(path);
	}

	public static IEnumerator InitServerFileList()
	{
		if (serverFileList == null)
		{
			serverFileList = new Dictionary<string, string>();
			string fileList = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(UnityEngine.Application.dataPath + "/../../Data/RequestGetFiles.json"));
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(fileList);
			EDOHBJAPLPF_JsonData fileL = jsonData["files"];
			for (int i = 0; i < fileL.HNBFOAJIIAL_Count; i++)
			{
				if((i % 1000) == 0)
				{
					UnityEngine.Debug.Log("Done file list "+i+"/"+fileL.HNBFOAJIIAL_Count);
					yield return null;
				}
				string fileName = (string)fileL[i]["file"];
				string localName = GCGNICILKLD_AssetFileInfo.NOCCMAKNLLD.Replace(fileName, "");
				//UnityEngine.Debug.Log("Added file " + localName + " to remote name " + fileName);
				serverFileList.Add(localName, fileName);
			}
			isInitialized = true;
		}
	}

	static IEnumerator TryInstallFileCoroutine(string path, Action<string> onDone)
	{
		yield return InitServerFileList();
		path = path.Replace("\\", "/");
		string relativePath = path;
		int pos = path.IndexOf("/android/");
		if (pos >= 0)
			relativePath = path.Substring(pos);
		UnityEngine.Debug.Log("Try install relative path : " + relativePath);
		if (serverFileList.ContainsKey(relativePath))
		{
			string startPath = RuntimeSettings.CurrentSettings.DataWebServerURL;
			if(serverFileList[relativePath].StartsWith("/") && startPath.EndsWith("/"))
				startPath = startPath.Substring(0, startPath.Length - 1);
			string url = startPath + serverFileList[relativePath];
			UnityEngine.Debug.Log("Try dld from server at " + url);
			WWW dldData = new WWW(url);
			while (!dldData.isDone)
				yield return null;
			if (string.IsNullOrEmpty(dldData.error))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				File.WriteAllBytes(path, dldData.bytes);
			}
			else
			{
				UnityEngine.Debug.LogError("Dld Error : "+dldData.error);
			}
		}
		if (onDone != null)
			onDone(path);
	}

#if UNITY_EDITOR
	[UnityEditor.MenuItem("UMO/TestLoadBundle")]
	static void TestLoadBundle()
	{
		if (GameManager.Instance)
		{
			foreach (var k in serverFileList)
			{
				string path = ConvertPath(UnityEngine.Application.persistentDataPath + "/data" + k.Value);
				UnityEngine.Debug.LogError(path);
				break;
			}
		}
	}
#endif
}
