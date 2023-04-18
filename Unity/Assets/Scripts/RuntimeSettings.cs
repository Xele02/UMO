
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
		if (!string.IsNullOrEmpty(DataWebServerURL))
			return true;
		if (!string.IsNullOrEmpty(DataDirectory))
		{
			if (Directory.Exists(DataDirectory))
			{
				if (Directory.Exists(Path.Combine(DataDirectory, "android")) && Directory.Exists(Path.Combine(DataDirectory, "db")))
					return true;
			}
		}
		string path = Path.GetFullPath("../Tools/Data");
		if (Directory.Exists(path))
		{
			if (Directory.Exists(Path.Combine(path, "android")) && Directory.Exists(Path.Combine(path, "db")))
			{
#if UNITY_EDITOR
				if (EditorUtility.DisplayDialog("Game data found", "Game data found in directory " + path + ", use it ?", "Yes", "No"))
#endif
				{
					DataDirectory = path;
					return true;
				}
				return false;
			}
		}
		path = Path.GetFullPath("../Data");
		if (Directory.Exists(path))
		{
			if (Directory.Exists(Path.Combine(path, "android")) && Directory.Exists(Path.Combine(path, "db")))
			{
#if UNITY_EDITOR
				if (EditorUtility.DisplayDialog("Game data found", "Game data found in directory " + path + ", use it ?", "Yes", "No"))
#endif
				{
					DataDirectory = path;
					return true;
				}
				return false;
			}
		}
		return false;
	}

	[Header("Profile")]
	public bool ForceDivaUnlock = true;
	public bool ForceCostumeUnlock = true;
	public bool ForceSongUnlock = true;
	public bool ForceCardsUnlock = true;
	public bool ForceValkyrieUnlock = true;
	public bool ForceSimulationOpen = true;
	public bool ForceTutoSkip = true;
	public bool ForceAllStoryMusicUnlock = true;
	public int ForcePlayerLevel = 90;
	public bool IsInvincibleCheat = true;

	[Header("Live")]
	public bool ForceLiveValkyrieMode = true;
	public bool ForceLiveDivaMode = false;
	public bool ForceLiveAwakenDivaMode = true;

	public bool AddBigScore = false;

	public KeyCode Lane1Touch = KeyCode.S;
	public KeyCode Lane2Touch = KeyCode.D;
	public KeyCode Lane3Touch = KeyCode.F;
	public KeyCode Lane4Touch = KeyCode.H;
	public KeyCode Lane5Touch = KeyCode.J;
	public KeyCode Lane6Touch = KeyCode.K;
	public KeyCode ActiveSkillTouch = KeyCode.Space;

	[Header("S-Live")]
	public bool ForceCutin = true;
	public bool DisableNoteSound = false;
	public bool DisableWatermark = false;

	[Header("Local directory where the android directory with asset bundle is. Accept crypted and decrypted bundle.")]
	public string DataDirectory;
	[Header("Web url where the game server is running (answering game request). Leave empty to run with offline simulated webserver.")]
	[HideInInspector]
	public string WebServerURL;
	[Header("Web url where the android directory with asset bundle is. If left empty, DataDirectory should be set and with all the datas.")]
	public string DataWebServerURL;

	public bool SLiveViewerRequest { get; set; }
	public bool SLiveViewer { get; set; }

	[Header("Debug")]

	public int MinLog = -9999;
}
