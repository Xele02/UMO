using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp.Game;

static class FileSystemProxy
{
	private static RuntimeSettings m_currentSettings;
	private static Dictionary<string, string> serverFileList;

	static RuntimeSettings CurrentSettings {
		get
		{
			if(m_currentSettings == null)
			{
				m_currentSettings = Resources.Load<RuntimeSettings>("EditorRuntimeSettings");
			}
			return m_currentSettings;
		}
	}

	static public string ConvertURL(string url)
	{
		//InitServerFileList();
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

		if (CurrentSettings == null || string.IsNullOrEmpty(CurrentSettings.DataWebServerURL))
			return url;
		string serverPath = CurrentSettings.DataWebServerURL;
		if (serverPath.EndsWith("/"))
			serverPath = serverPath.Substring(0, serverPath.Length - 1);
		return url.Replace("https://assets-sakasho.cdn-dena.com/1246/20220502151005", serverPath);
	}

	static public string ConvertPath(string path)
	{
		path = path.Replace("\\", "/");
		if (File.Exists(path))
			return path;
		if (CurrentSettings == null)
			return path;
		//InitServerFileList();
		if (path.Contains(UnityEngine.Application.persistentDataPath + "/data") && Directory.Exists(CurrentSettings.DataDirectory))
		{
			path = path.Replace(UnityEngine.Application.persistentDataPath + "/data", CurrentSettings.DataDirectory);
			if (File.Exists(path))
				return path;
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
		if (CurrentSettings != null)
		{
			if(!string.IsNullOrEmpty(CurrentSettings.DataWebServerURL))
			{
				GameManager.Instance.StartCoroutine(TryInstallFileCoroutine(path, onDone));
				return;
			}
		}
		if (onDone != null)
			onDone(path);
	}

	static bool serverListInitializing = false;

	public static IEnumerator InitServerFileList()
	{
		while(serverListInitializing)
			yield return null;

		if (serverFileList == null)
		{
			serverListInitializing = true;
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
			serverListInitializing = false;
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
			string startPath = CurrentSettings.DataWebServerURL;
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
}
