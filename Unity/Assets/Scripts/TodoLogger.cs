using UnityEngine;
using XeApp.Game.Common;

public static class TodoLogger
{
	public static int NonVisible = 99999999;
	public static int CriWareErrorHandler = NonVisible;
	public static int CriFsPlugin = NonVisible;
	public static int CriAtomPlugin = NonVisible;
	public static int CriManaPlugin = NonVisible;
	public static int CriWareDecrypter = NonVisible;
	public static int CriAtomExLib = NonVisible;
	public static int AppQualitySetting = NonVisible;
	public static int SecureLibAPI = NonVisible;
	public static int FCMTokenReceiver = NonVisible;
	public static int CriAtomExLatencyEstimator = NonVisible;
	public static int CriFsWebInstaller = NonVisible;
	public static int Adjust = NonVisible;

	public static void Log(int priority, string str)
	{
		if(priority < RuntimeSettings.CurrentSettings.MinLog)
		{
			UnityEngine.Debug.LogError(str);
		}
	}
	public static void LogNotImplemented(string str)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = "Not Implemented";
		s.Text = "Not implemented\n"+str;
		s.WindowSize = SizeType.Large;
		s.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } };
		UnityEngine.Debug.LogError("Not Implemented " + str);
		PopupWindowManager.Show(s, null, null, null, null);
	}
}
