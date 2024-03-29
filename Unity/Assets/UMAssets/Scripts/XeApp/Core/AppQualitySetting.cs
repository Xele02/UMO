using UnityEngine;
using XeApp.Game;

namespace XeApp.Core
{
	public class AppQualitySetting
	{
		public enum DeviceSpec
		{
			Low = 0,
			Middle = 1,
			High = 2,
			Default = 3,
		}

		private const int ANDROID_LOWSPEC_MEMSIZE = 1400;
		private static string[] recommendedAndroidDevice_High = new string[1] { "htc Nexus 9" }; // 0x0
		private static string[] recommendedAndroidDevice_Middle = new string[3] { "Sony SO-03G", "Sony SOV31", "Sony 402SO" }; // 0x4
		public static AppQualitySetting.DeviceSpec spec = DeviceSpec.Low; // 0x8

		// // RVA: 0xE0D960 Offset: 0xE0D960 VA: 0xE0D960
		public static void Modify()
		{
			spec = GetDeviceSpec();
			int qualLevel = 1;
			if(spec != AppQualitySetting.DeviceSpec.High)
			{
				qualLevel = 0;
				if(spec != AppQualitySetting.DeviceSpec.Middle)
				{
					if(spec != AppQualitySetting.DeviceSpec.Low)
						spec = AppQualitySetting.DeviceSpec.Low;
				}
			}
			QualitySettings.SetQualityLevel(qualLevel);
		}

		// [ConditionalAttribute] // RVA: 0x747BAC Offset: 0x747BAC VA: 0x747BAC
		// // RVA: 0xE0DD40 Offset: 0xE0DD40 VA: 0xE0DD40
		// private static void RepostQulityLevel(int index) { }

		// // RVA: 0xE0DAC8 Offset: 0xE0DAC8 VA: 0xE0DAC8
		public static DeviceSpec GetDeviceSpec()
		{
#if UNITY_ANDROID
			TodoLogger.Log(TodoLogger.AppQualitySetting, "AppQualitySetting.GetDeviceSpec");
#endif
			return DeviceSpec.High;
		}

		// // RVA: 0xE0E27C Offset: 0xE0E27C VA: 0xE0E27C
		// private static int GetModelNumber(string name, string filter) { }

		// // RVA: 0xE0DE08 Offset: 0xE0DE08 VA: 0xE0DE08
		// private static AppQualitySetting.DeviceSpec ClassifyAndroidDeviceModel(string name) { }

		// // RVA: 0xE0DFC8 Offset: 0xE0DFC8 VA: 0xE0DFC8
		// private static AppQualitySetting.DeviceSpec ClassifyAdereno(string name) { }

		// // RVA: 0xE0E14C Offset: 0xE0E14C VA: 0xE0E14C
		// private static AppQualitySetting.DeviceSpec ClassifyMali(string name) { }

		// // RVA: 0xE0E3F8 Offset: 0xE0E3F8 VA: 0xE0E3F8
		public static int GetScreenSizeType()
		{
			SystemInfo.deviceModel.Contains("htc Nexus 9");
			return 0;
		}

		// // RVA: 0xE0E47C Offset: 0xE0E47C VA: 0xE0E47C
		// public static int GetInGameScreenSizeType() { }

		// // RVA: 0xE0E4FC Offset: 0xE0E4FC VA: 0xE0E4FC
		public static DeviceSpec GetDeviceSpecFromMaster(string deviceModel)
		{
#if UNITY_ANDROID
			TodoLogger.Log(0, "GetDeviceSpecFromMaster");
			return DeviceSpec.High;
#else
			return DeviceSpec.High;
#endif
		}

		// // RVA: 0xE0E6C8 Offset: 0xE0E6C8 VA: 0xE0E6C8
		public static int Get3DModeFromMaster(DeviceSpec spec)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.GAGDEIMGBBG((int)spec);
		}

		// // RVA: 0xE0E7AC Offset: 0xE0E7AC VA: 0xE0E7AC
		public static void InitDefault3dMode()
		{
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GEPLOFLHAOL_NeedInitRenderQuality == 0)
				return;
			DeviceSpec spec = GetDeviceSpecFromMaster(null);
			int mode = Get3DModeFromMaster(spec);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DDHCLNFPNGK_RenderQuality = mode;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MHHPDGJLJGE_OptionsSLive.DDHCLNFPNGK_RenderQuality = mode;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.GEPLOFLHAOL_NeedInitRenderQuality = 0;
			Debug.Log(JpStringLiterals.StringLiteral_13316 + mode.ToString());
		}
	}
}
