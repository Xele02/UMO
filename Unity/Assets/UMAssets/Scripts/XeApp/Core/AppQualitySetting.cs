namespace XeApp.Core
{
	public class AppQualitySetting
	{
		private const int ANDROID_LOWSPEC_MEMSIZE = 1400;
		private static string[] recommendedAndroidDevice_High; // 0x0
		private static string[] recommendedAndroidDevice_Middle; // 0x4
		// public static AppQualitySetting.DeviceSpec spec; // 0x8

		// // RVA: 0xE0D960 Offset: 0xE0D960 VA: 0xE0D960
		// public static void Modify() { }

		// [ConditionalAttribute] // RVA: 0x747BAC Offset: 0x747BAC VA: 0x747BAC
		// // RVA: 0xE0DD40 Offset: 0xE0DD40 VA: 0xE0DD40
		// private static void RepostQulityLevel(int index) { }

		// // RVA: 0xE0DAC8 Offset: 0xE0DAC8 VA: 0xE0DAC8
		// public static AppQualitySetting.DeviceSpec GetDeviceSpec() { }

		// // RVA: 0xE0E27C Offset: 0xE0E27C VA: 0xE0E27C
		// private static int GetModelNumber(string name, string filter) { }

		// // RVA: 0xE0DE08 Offset: 0xE0DE08 VA: 0xE0DE08
		// private static AppQualitySetting.DeviceSpec ClassifyAndroidDeviceModel(string name) { }

		// // RVA: 0xE0DFC8 Offset: 0xE0DFC8 VA: 0xE0DFC8
		// private static AppQualitySetting.DeviceSpec ClassifyAdereno(string name) { }

		// // RVA: 0xE0E14C Offset: 0xE0E14C VA: 0xE0E14C
		// private static AppQualitySetting.DeviceSpec ClassifyMali(string name) { }

		// // RVA: 0xE0E3F8 Offset: 0xE0E3F8 VA: 0xE0E3F8
		// public static int GetScreenSizeType() { }

		// // RVA: 0xE0E47C Offset: 0xE0E47C VA: 0xE0E47C
		// public static int GetInGameScreenSizeType() { }

		// // RVA: 0xE0E4FC Offset: 0xE0E4FC VA: 0xE0E4FC
		// public static AppQualitySetting.DeviceSpec GetDeviceSpecFromMaster(string deviceModel) { }

		// // RVA: 0xE0E6C8 Offset: 0xE0E6C8 VA: 0xE0E6C8
		// public static int Get3DModeFromMaster(AppQualitySetting.DeviceSpec spec) { }

		// // RVA: 0xE0E7AC Offset: 0xE0E7AC VA: 0xE0E7AC
		public static void InitDefault3dMode()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE0EB38 Offset: 0xE0EB38 VA: 0xE0EB38
		// public void .ctor() { }

		// // RVA: 0xE0EB40 Offset: 0xE0EB40 VA: 0xE0EB40
		// private static void .cctor() { }
	}
}
