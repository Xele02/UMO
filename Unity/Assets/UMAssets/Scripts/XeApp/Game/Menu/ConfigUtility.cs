
using mcrs;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ConfigUtility
	{
		//// RVA: 0x1B64AF4 Offset: 0x1B64AF4 VA: 0x1B64AF4
		public static void PlaySeSlider()
		{
			SoundManager.Instance.sePlayerBoot.Stop();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0x1B64B94 Offset: 0x1B64B94 VA: 0x1B64B94
		public static void PlaySeButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0x1B64BEC Offset: 0x1B64BEC VA: 0x1B64BEC
		public static void PlaySeToggleButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x1B64C44 Offset: 0x1B64C44 VA: 0x1B64C44
		public static void VolumeDefaultPopup(Action<bool> callback)
		{
			TodoLogger.LogNotImplemented("VolumeDefaultPopup");
			if (callback != null)
				callback(true);
		}

		//// RVA: 0x1B64F58 Offset: 0x1B64F58 VA: 0x1B64F58
		public static void TimingDefaultPopup(Action<bool> callback)
		{
			TodoLogger.LogNotImplemented("TimingDefaultPopup");
			if (callback != null)
				callback(true);
		}

		//// RVA: 0x1B6526C Offset: 0x1B6526C VA: 0x1B6526C
		public static void NotesSpeedDefaultPopup(Action<bool> callback)
		{
			TodoLogger.LogNotImplemented("NotesSpeedDefaultPopup");
			if (callback != null)
				callback(true);
		}

		//// RVA: 0x1B65580 Offset: 0x1B65580 VA: 0x1B65580
		public static void DimmerDefaultPopup(Action<bool> callback)
		{
			TodoLogger.LogNotImplemented("DimmerDefaultPopup");
			if (callback != null)
				callback(true);
		}

		//// RVA: 0x1B60B24 Offset: 0x1B60B24 VA: 0x1B60B24
		public static void PopupShowVideoQuality(Action<bool> callback)
		{
			TodoLogger.LogNotImplemented("PopupShowVideoQuality");
			if (callback != null)
				callback(true);
		}

		//// RVA: 0x1B60E30 Offset: 0x1B60E30 VA: 0x1B60E30
		public static void PopupShowVideoDelete(Action callback)
		{
			TodoLogger.LogNotImplemented("PopupShowVideoDelete");
			if (callback != null)
				callback();
		}
	}
}
