using UnityEngine;

namespace XeApp.Core
{
	public class ClipboardSupport
	{
		//// RVA: 0x1D6B478 Offset: 0x1D6B478 VA: 0x1D6B478
		public static void CopyText(string text)
		{
			CopyTextInternal(text);
		}

		//// RVA: 0x1D6B47C Offset: 0x1D6B47C VA: 0x1D6B47C
		private static void CopyTextInternal(string text)
		{
#if UNITY_ANDROID
			TodoLogger.LogError(TodoLogger.Android, "CopyText");
#else
			GUIUtility.systemCopyBuffer = text;
#endif
		}

		//// RVA: 0x1D6B670 Offset: 0x1D6B670 VA: 0x1D6B670
		public static void SendSharedIntent(string text)
		{
			GUIUtility.systemCopyBuffer = text;
		}

		//// RVA: 0x1D6B674 Offset: 0x1D6B674 VA: 0x1D6B674
		//private static void SendSharedIntentInternal(string text) { }
	}
}
