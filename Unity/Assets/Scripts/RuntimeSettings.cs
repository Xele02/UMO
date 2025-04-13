
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;

[CreateAssetMenu(fileName = "RuntimeSettings", menuName = "ScriptableObjects/RuntimeSettings", order = 1)]
class RuntimeSettings : ScriptableObject
{
#if UNITY_EDITOR
	[MenuItem("UMO/Options", priority=2)]
	static void ShowOption()
	{
		PopUpAssetInspector.Create(CurrentSettings);
	}
#endif

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
				
				UMO_PlayerPrefs.CheckLoad();
				m_currentSettings.CanSkipUnplayedSongs = UMO_PlayerPrefs.GetInt("CanSkipSongs", 1) == 1;
				m_currentSettings.DisableMaxVopFastCompletionLimit = UMO_PlayerPrefs.GetInt("DisableMaxVopFastCompletionLimit", 0) == 1;
				m_currentSettings.DisableHeadRotation = UMO_PlayerPrefs.GetInt("DisableHeadRotation", 0) == 1;
				m_currentSettings.IsInvincibleCheat = UMO_PlayerPrefs.GetInt("InvincibleMode", 0) == 1;
				m_currentSettings.ForcePerfectNote = UMO_PlayerPrefs.GetInt("ForcePerfect", 0) == 1;
				m_currentSettings.DisableNoteSound = UMO_PlayerPrefs.GetInt("DisableNoteSound", 1) == 1;
				m_currentSettings.DisableWatermark = UMO_PlayerPrefs.GetInt("DisableWatermark", 1) == 1;
				m_currentSettings.MinigameAutoPlay = UMO_PlayerPrefs.GetInt("MinigameAutoPlay", 0) == 1;
				m_currentSettings.DisplayIdInName = UMO_PlayerPrefs.GetInt("DisplayIdInName", 0) == 1;
				m_currentSettings.EnableInfoLog = UMO_PlayerPrefs.GetInt("EnableInfoLog", 0) == 1;
				m_currentSettings.EnableErrorLog = UMO_PlayerPrefs.GetInt("EnableErrorLog", 0) == 1;
				m_currentSettings.DisableCrywareLowLatency = UMO_PlayerPrefs.GetInt("DisableCrywareLowLatency", 0) == 1;
				m_currentSettings.UseTouchScreen = UMO_PlayerPrefs.GetInt("UseTouchScreen", 0) == 1;
				m_currentSettings.RemoveShopLimit = UMO_PlayerPrefs.GetInt("RemoveShopLimit", 0) == 1;
				m_currentSettings.RemoveCrystalLimit = UMO_PlayerPrefs.GetInt("RemoveCrystalLimit", 0) == 1;
				m_currentSettings.DumpStringUsed = UMO_PlayerPrefs.GetInt("DumpStringUsed", 0) == 1;
				m_currentSettings.ShowStringUsed = UMO_PlayerPrefs.GetInt("ShowStringUsed", 0) == 1;
				m_currentSettings.UseTmpLocalizationFiles = UMO_PlayerPrefs.GetInt("UseTmpLocalizationFiles", 0) == 1;
				m_currentSettings.Language = UMO_PlayerPrefs.GetString("Language", "");
				m_currentSettings.WorkerThreadPriorityNormal = UMO_PlayerPrefs.GetInt("WorkerThreadPriorityNormal", 0) == 1;
				m_currentSettings.WorkerThreadUseCoroutine = UMO_PlayerPrefs.GetInt("WorkerThreadUseCoroutine", 0) == 1;
				m_currentSettings.EnableMusicSecondDisplay = UMO_PlayerPrefs.GetInt("EnableMusicSecondDisplay", 1) == 1;
				m_currentSettings.EnableMusicThirdDisplay = UMO_PlayerPrefs.GetInt("EnableMusicThirdDisplay", 1) == 1;
				m_currentSettings.MusicFirstDisplayType = UMO_PlayerPrefs.GetInt("MusicFirstDisplayType", 2);
				m_currentSettings.MusicSecondDisplayType = UMO_PlayerPrefs.GetInt("MusicSecondDisplayType", 1);
				m_currentSettings.MusicThirdDisplayType = UMO_PlayerPrefs.GetInt("MusicThirdDisplayType", 0);
				m_currentSettings.UseChineseFont = UMO_PlayerPrefs.GetInt("UseChineseFont", 1) == 1;
				m_currentSettings.EnableARDebugInfo = UMO_PlayerPrefs.GetInt("EnableARDebugInfo", 0) == 1;

#if (UNITY_ANDROID && !UNITY_EDITOR) || DEBUG_ANDROID_FILESYSTEM
				m_currentSettings.DataDirectory = Application.persistentDataPath + "/data/";
#endif
			}
			return m_currentSettings;
		}
	}

	public void Save()
	{
        UMO_PlayerPrefs.SetInt("CanSkipSongs", m_currentSettings.CanSkipUnplayedSongs ? 1 : 0);
        UMO_PlayerPrefs.SetInt("InvincibleMode", m_currentSettings.IsInvincibleCheat ? 1 : 0);
        UMO_PlayerPrefs.SetInt("ForcePerfect", m_currentSettings.ForcePerfectNote ? 1 : 0);
        UMO_PlayerPrefs.SetInt("DisableNoteSound", m_currentSettings.DisableNoteSound ? 1 : 0);
        UMO_PlayerPrefs.SetInt("DisableWatermark", m_currentSettings.DisableWatermark ? 1 : 0);
        UMO_PlayerPrefs.SetInt("MinigameAutoPlay", m_currentSettings.MinigameAutoPlay ? 1 : 0);
        UMO_PlayerPrefs.SetInt("DisplayIdInName", m_currentSettings.DisplayIdInName ? 1 : 0);
        UMO_PlayerPrefs.SetInt("EnableInfoLog", m_currentSettings.EnableInfoLog ? 1 : 0);
        UMO_PlayerPrefs.SetInt("EnableErrorLog", m_currentSettings.EnableErrorLog ? 1 : 0);
        UMO_PlayerPrefs.SetInt("DisableCrywareLowLatency", m_currentSettings.DisableCrywareLowLatency ? 1 : 0);
		UMO_PlayerPrefs.SetInt("UseTouchScreen", m_currentSettings.UseTouchScreen ? 1 : 0);
		UMO_PlayerPrefs.SetInt("RemoveShopLimit", m_currentSettings.RemoveShopLimit ? 1 : 0);
		UMO_PlayerPrefs.SetInt("RemoveCrystalLimit", m_currentSettings.RemoveCrystalLimit ? 1 : 0);
		UMO_PlayerPrefs.SetInt("DumpStringUsed", m_currentSettings.DumpStringUsed ? 1 : 0);
		UMO_PlayerPrefs.SetInt("ShowStringUsed", m_currentSettings.ShowStringUsed ? 1 : 0);
		UMO_PlayerPrefs.SetInt("UseTmpLocalizationFiles", m_currentSettings.UseTmpLocalizationFiles ? 1 : 0);
		UMO_PlayerPrefs.SetString("Language", m_currentSettings.Language);
		UMO_PlayerPrefs.SetInt("WorkerThreadPriorityNormal", m_currentSettings.WorkerThreadPriorityNormal ? 1 : 0);
		UMO_PlayerPrefs.SetInt("WorkerThreadUseCoroutine", m_currentSettings.WorkerThreadUseCoroutine ? 1 : 0);
		UMO_PlayerPrefs.SetInt("DisableMaxVopFastCompletionLimit", m_currentSettings.DisableMaxVopFastCompletionLimit ? 1 : 0);
		UMO_PlayerPrefs.SetInt("DisableHeadRotation", m_currentSettings.DisableHeadRotation ? 1 : 0);
		UMO_PlayerPrefs.SetInt("EnableMusicSecondDisplay", m_currentSettings.EnableMusicSecondDisplay ? 1 : 0);
		UMO_PlayerPrefs.SetInt("EnableMusicThirdDisplay", m_currentSettings.EnableMusicThirdDisplay ? 1 : 0);
		UMO_PlayerPrefs.SetInt("MusicFirstDisplayType", m_currentSettings.MusicFirstDisplayType);
		UMO_PlayerPrefs.SetInt("MusicSecondDisplayType", m_currentSettings.MusicSecondDisplayType);
		UMO_PlayerPrefs.SetInt("MusicThirdDisplayType", m_currentSettings.MusicThirdDisplayType);
		UMO_PlayerPrefs.SetInt("UseChineseFont", m_currentSettings.UseChineseFont ? 1 : 0);
		UMO_PlayerPrefs.SetInt("EnableARDebugInfo", m_currentSettings.EnableARDebugInfo ? 1 : 0);
		UMO_PlayerPrefs.Save();
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

	//public bool ForceDivaUnlock = true;
	//public bool ForceCostumeUnlock = true;
	//public bool ForceSongUnlock = true;
	//public bool ForceCardsUnlock = true;
	//public bool ForceValkyrieUnlock = true;
	//public bool ForceSimulationOpen = true;
	//public bool ForceAllStoryMusicUnlock = true;
	//public int ForcePlayerLevel = 90;
	public bool CanSkipUnplayedSongs { get; set; }
	public bool DisableCrywareLowLatency { get; set; }
	public bool RemoveHomeBgDateLimit = false;
	public bool DisableMaxVopFastCompletionLimit{ get; set; }
	public bool DisableHeadRotation{ get; set; }

	public bool IsInvincibleCheat { get; set; }
	public bool ForcePerfectNote { get; set; }

	public bool EnableMusicSecondDisplay { get; set; }
	public bool EnableMusicThirdDisplay { get; set; }
	public int MusicFirstDisplayType { get; set; }
	public int MusicSecondDisplayType { get; set; }
	public int MusicThirdDisplayType { get; set; }

	[Header("Live")]
	public bool ForceLiveValkyrieMode = false;
	public bool ForceLiveDivaMode = false;
	public bool ForceLiveAwakenDivaMode = false;

	//public bool AddBigScore = false;

	public KeyCode Lane1Touch = KeyCode.S;
	public KeyCode Lane2Touch = KeyCode.D;
	public KeyCode Lane3Touch = KeyCode.F;
	public KeyCode Lane4Touch = KeyCode.H;
	public KeyCode Lane5Touch = KeyCode.J;
	public KeyCode Lane6Touch = KeyCode.K;
	public KeyCode ActiveSkillTouch = KeyCode.Space;

	//public bool ForceCutin = true;
	public bool DisableNoteSound { get; set; }
	public bool DisableWatermark { get; set; }
	[Header("S-Live")]
	public bool DisableMovies = false;

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

	public int MinLogError = 1;
	public int MinLogWarning = 1;
	public int MinLogInfo = 1;
	public bool EnableProfileSaveCheck = false;
	public bool EnableLocalSaveCheck = false;
	public bool EnableDebugStopCoroutine = false;
	public bool EnableDebugSkills = false;
	public bool MinigameAutoPlay { get; set; }
	public bool DisplayIdInName { get; set; }
	public bool EnableInfoLog { get; set; }
	public bool EnableErrorLog { get; set; }
	public bool UseTouchScreen { get; set; }
	public bool RemoveShopLimit { get; set; }
	public bool RemoveCrystalLimit { get; set; }
	public bool DumpStringUsed { get; set; }
	public bool ShowStringUsed { get; set; }

	public bool UseTmpLocalizationFiles { get; set; }
	public string Language { get; set; }
	public bool UseChineseFont { get; set; }
	public bool WorkerThreadPriorityNormal { get; set; }
	public bool WorkerThreadUseCoroutine { get; set; }
	public bool EnableARDebugInfo { get; set; }

	public bool UnlimitedEvent { get; set; } = true;

	public SmartFormatter SmartFormatter
	{
		get => m_SmartFormat;
		set => m_SmartFormat = value;
	}
	SmartFormatter m_SmartFormat = Smart.CreateDefaultSmartFormat();

	public string GetMusicName(int idx, string str_translated, string str_kanji, string str_rom)
	{
		string[] strs = {str_kanji, str_rom, str_translated};
		switch(idx)
		{
			case 1:
				return EnableMusicSecondDisplay ? strs[MusicSecondDisplayType] : "";
			case 2:
				return EnableMusicThirdDisplay ? strs[MusicThirdDisplayType] : "";
		}
		return strs[MusicFirstDisplayType];
	}
}

#if UNITY_EDITOR
public class PopUpAssetInspector : EditorWindow
{
	private Object asset;
	private Editor assetEditor;

	public static PopUpAssetInspector Create(Object asset)
	{
		var window = GetWindow<PopUpAssetInspector>(typeof(PopUpAssetInspector));
		window.asset = asset;
		window.assetEditor = Editor.CreateEditor(asset);
		return window;
	}

	Vector2 scrollPos = Vector2.zero;

	private void OnGUI()
	{
		GUI.enabled = false;
		asset = EditorGUILayout.ObjectField("Asset", asset, asset.GetType(), false);
		GUI.enabled = true;

		EditorGUILayout.BeginVertical(EditorStyles.helpBox);
		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		assetEditor.OnInspectorGUI();
		EditorGUILayout.EndScrollView();
		EditorGUILayout.EndVertical();
	}
}
#endif
