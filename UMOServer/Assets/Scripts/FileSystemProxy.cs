using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

static class FileSystemProxy
{
	private static Dictionary<string, string> serverFileList;

	private static bool isInitialized = false;

	static public bool IsInitialized { get { return isInitialized; } }

	static public string ConvertPath(string path)
	{
		path = path.Replace("\\", "/");
		if (File.Exists(path))
			return path;
		if (path.Contains(UnityEngine.Application.persistentDataPath + "/data") && !string.IsNullOrEmpty(UMOFileServer.filePath))
		{
			string dataDir = UMOFileServer.filePath;
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

	public static IEnumerator InitServerFileList(TextAsset json)
	{
		if (serverFileList == null)
		{
			serverFileList = new Dictionary<string, string>();

			string fileList = json.text;
			fileList = fileList.Replace("[[DATE]]", "0");
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(fileList);
			EDOHBJAPLPF_JsonData fileL = jsonData["files"];
			Regex NOCCMAKNLLD = new Regex("!s[0-9a-fA-F]+z!"); // 0x0
			for (int i = 0; i < fileL.HNBFOAJIIAL_Count; i++)
			{
				if((i % 1000) == 0)
				{
					yield return null;
				}
				string fileName = (string)fileL[i]["file"];
				string localName = NOCCMAKNLLD.Replace(fileName, "");
				//UnityEngine.Debug.Log("Added file " + localName + " to remote name " + fileName);
				serverFileList.Add(localName, fileName);
			}
			isInitialized = true;
		}
	}

}
