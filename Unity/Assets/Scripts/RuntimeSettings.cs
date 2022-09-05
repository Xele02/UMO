
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeSettings", menuName = "ScriptableObjects/RuntimeSettings", order = 1)]
class RuntimeSettings : ScriptableObject
{
	private static RuntimeSettings m_currentSettings;
	public static RuntimeSettings CurrentSettings
	{
		get
		{
			if (m_currentSettings == null)
			{
				m_currentSettings = Resources.Load<RuntimeSettings>("EditorRuntimeSettings");
				if (m_currentSettings == null)
					m_currentSettings = new RuntimeSettings();
			}
			return m_currentSettings;
		}
	}

	public bool IsPathValid()
	{
		if(!string.IsNullOrEmpty(DataWebServerURL))
			return true;
		if(!string.IsNullOrEmpty(DataDirectory))
		{
			if(Directory.Exists(DataDirectory))
			{
				if(Directory.Exists(Path.Combine(DataDirectory, "android")) && Directory.Exists(Path.Combine(DataDirectory, "db")))
					return true;
			}
		}
		string path = Path.GetFullPath("../Tools/Data");
		if(Directory.Exists(path))
		{
			if(Directory.Exists(Path.Combine(path, "android")) && Directory.Exists(Path.Combine(path, "db")))
			{
				if(EditorUtility.DisplayDialog("Game data found", "Game data found in directory "+path+", use it ?", "Yes", "No"))
				{
					DataDirectory = path;
					return true;
				}
				return false;
			}
		}
		path = Path.GetFullPath("../Data");
		if(Directory.Exists(path))
		{
			if(Directory.Exists(Path.Combine(path, "android")) && Directory.Exists(Path.Combine(path, "db")))
			{
				if(EditorUtility.DisplayDialog("Game data found", "Game data found in directory "+path+", use it ?", "Yes", "No"))
				{
					DataDirectory = path;
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public bool ForceDivaUnlock = true;
	public bool ForceCostumeUnlock = true;
	public bool ForceSongUnlock = true;
	public bool ForceSimulationOpen = true;
	[Header("Local directory where the android directory with asset bundle is. Accept crypted and decrypted bundle.")]
	public string DataDirectory;
	[Header("Web url where the game server is running (answering game request). Leave empty to run with offline simulated webserver.")]
	[HideInInspector]
	public string WebServerURL;
	[Header("Web url where the android directory with asset bundle is. If left empty, DataDirectory should be set and with all the datas.")]
	public string DataWebServerURL;
}
