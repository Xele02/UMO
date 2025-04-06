using System;
using UnityEngine;
using XeApp.Game.Common;

public static class TodoLogger
{
	public static int _NonVisible = 99999999;

#if UNITY_ANDROID
	public static int _OnlyAndroid = 0;
#else
	public static int _OnlyAndroid = _NonVisible;
#endif

	// Can ignore
	public static int CriWareErrorHandler = _OnlyAndroid;
	public static int CriFsPlugin = _OnlyAndroid;
	public static int CriAtomPlugin = _OnlyAndroid;
	public static int CriManaPlugin = _OnlyAndroid;
	public static int CriWareDecrypter = _OnlyAndroid;
	public static int CriWareInitializer = _OnlyAndroid;
	public static int CriAtomExLib = _OnlyAndroid;
	public static int CriAtom = _OnlyAndroid;
	public static int AppQualitySetting = _NonVisible;
	public static int SecureLibAPI = _NonVisible;
	public static int FCMTokenReceiver = _NonVisible;
	public static int CriAtomExLatencyEstimator = _OnlyAndroid;
	public static int CriFsWebInstaller = _OnlyAndroid;
	public static int Adjust = _NonVisible;
	public static int AppInfo = _NonVisible;
	public static int CriFsLoader = _OnlyAndroid;
	public static int SakashoSystem = _NonVisible;
	public static int Playgames = _NonVisible;
	public static int Crashlytics = _NonVisible;
	public static int StorageSupport = _OnlyAndroid;
	public static int ManaAd = _NonVisible;
	public static int AndroidNotification = _NonVisible;
	public static int CriAtomExPlayer = _OnlyAndroid;
	public static int HashCheck = _OnlyAndroid;
	public static int Java = _NonVisible;
	public static int WebRequest = _NonVisible;
	public static int OptimizedSave = _NonVisible;
	public static int UMOSkip = _NonVisible;

	// Need to implement at some point
	public static int _Todo = 99999999;
	public static int CriAtomVolumes = _OnlyAndroid;
	public static int ToCheck = _Todo;
	public static int Errors = _Todo;
	public static int DbIntegrityCheck = _Todo;
	public static int Xedec = _Todo;
	public static int SaveLoad = _Todo;

	public static int _Debug = 1;
	public static int UI = _Debug;
	public static int Popup = _Debug;
	public static int Database = _Debug;
	public static int Shader = _Debug;
	public static int Filesystem = _Debug;
	public static int Movie = _Debug;
	public static int Init = _Debug;
	public static int Job = _Debug;
	public static int AssetBundle = _Debug;
	public static int Menu = _Debug;
	public static int Game = _Debug;
	public static int Base = _Debug;
	public static int Coroutine = _Debug;
	public static int Layout = _Debug;
	public static int Event_Unknwown_2 = _Debug;
	public static int EventPresentCampaign_9 = _Debug;
	public static int EventSp_7 = _Debug;
	public static int EventRaid_11_13 = _Debug;
	public static int EventBoxGacha_8 = _Debug;
	public static int EventGoDiva_14 = _Debug;
	public static int EventBattle_3 = _Debug;
	public static int EventScore_4 = _Debug;
	public static int EventQuest_6 = _Debug; // == EventMission?
	public static int EventCollection_1 = _Debug;
	public static int EventMission_6 = _Debug;
	public static int RequestFail = _Debug;
	public static int CBT = _Debug;
	public static int MonthlyPass = _Debug;
	public static int DbJson = _Debug;
	public static int Android = _Debug;
	public static int Toast = _Debug;
	public static int AR = _Debug;
	public static int CampaignRoulette = _Debug;
	public static int DecoVisit = _Debug;
	public static int SakashoServer = _Debug;
	public static int OldMusicSelect = _Debug;
	public static int OldEpisodeFilter = _Debug;
	public static int DebugTextRenderer = _Debug;

	public static void LogError(int priority, string str)
	{
		if(priority < RuntimeSettings.CurrentSettings.MinLogError || (RuntimeSettings.CurrentSettings.EnableErrorLog && priority < 999))
		{
			UnityEngine.Debug.LogError("TODO "+str);
		}
	}

	public static void LogWarning(int priority, string str)
	{
		if (priority < RuntimeSettings.CurrentSettings.MinLogWarning || (RuntimeSettings.CurrentSettings.EnableErrorLog && priority < 999))
		{
			UnityEngine.Debug.LogWarning("TODO "+str);
		}
	}

	public static void Log(int priority, string str)
	{
		if (priority < RuntimeSettings.CurrentSettings.MinLogInfo || (RuntimeSettings.CurrentSettings.EnableErrorLog && priority < 999))
		{
			UnityEngine.Debug.Log("TODO "+str);
		}
	}

	public static PopupWindowControl LogNotImplemented(string str, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> callbackEnd = null)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = "Not Implemented";
		s.Text = "Not implemented\n"+str;
		s.WindowSize = SizeType.Large;
		s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
		UnityEngine.Debug.LogError("Not Implemented " + str);
		return PopupWindowManager.Show(s, callbackEnd, null, null, null);
	}
}
