using System;
using UnityEngine;
using XeApp.Game.Common;

public static class TodoLogger
{
	public static int _NonVisible = 99999999;

	// Can ignore
	public static int CriWareErrorHandler = _NonVisible;
	public static int CriFsPlugin = _NonVisible;
	public static int CriAtomPlugin = _NonVisible;
	public static int CriManaPlugin = _NonVisible;
	public static int CriWareDecrypter = _NonVisible;
	public static int CriWareInitializer = _NonVisible;
	public static int CriAtomExLib = _NonVisible;
	public static int AppQualitySetting = _NonVisible;
	public static int SecureLibAPI = _NonVisible;
	public static int FCMTokenReceiver = _NonVisible;
	public static int CriAtomExLatencyEstimator = _NonVisible;
	public static int CriFsWebInstaller = _NonVisible;
	public static int Adjust = _NonVisible;
	public static int AppInfo = _NonVisible;
	public static int CriFsLoader = _NonVisible;
	public static int SakashoSystem = _NonVisible;
	public static int Playgames = _NonVisible;
	public static int Crashlytics = _NonVisible;
	public static int StorageSupport = _NonVisible;
	public static int ManaAd = _NonVisible;
	public static int AndroidNotification = _NonVisible;
	public static int CriAtomExPlayer = _NonVisible;
	public static int HashCheck = _NonVisible;
	public static int Java = _NonVisible;
	public static int WebRequest = _NonVisible;
	public static int OptimizedSave = _NonVisible;
	public static int UMOSkip = _NonVisible;

	// Need to implement at some point
	public static int _Todo = 99999999;
	public static int CriAtomVolumes = _Todo;
	public static int ToCheck = _Todo;
	public static int Errors = _Todo;
	public static int DbIntegrityCheck = _Todo;
	public static int Xedec = _Todo;
	public static int Event = _Todo;
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

	public static void LogError(int priority, string str)
	{
		if(priority < RuntimeSettings.CurrentSettings.MinLogError)
		{
			UnityEngine.Debug.LogError(str);
		}
	}

	public static void LogWarning(int priority, string str)
	{
		if (priority < RuntimeSettings.CurrentSettings.MinLogWarning)
		{
			UnityEngine.Debug.LogWarning(str);
		}
	}

	public static void Log(int priority, string str)
	{
		if (priority < RuntimeSettings.CurrentSettings.MinLogInfo)
		{
			UnityEngine.Debug.Log(str);
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
