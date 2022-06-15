using System;
using UnityEngine;
using System.Collections.Generic;

public class CriAtomEx
{
	public struct CueInfo
	{
		public int id; // 0x0
		// public CriAtomEx.CueType type; // 0x4
		public readonly string name; // 0x8
		public readonly string userData; // 0xC
		public long length; // 0x10
		public ushort[] categories; // 0x18
		public short numLimits; // 0x1C
		public ushort numBlocks; // 0x1E
		public ushort numTracks; // 0x20
		public ushort numRelatedWaveForms; // 0x22
		public byte priority; // 0x24
		public byte headerVisibility; // 0x25
		public byte ignore_player_parameter; // 0x26
		public byte probability; // 0x27
		// public CriAtomEx.PanType panType; // 0x28
		// public CriAtomEx.CuePos3dInfo pos3dInfo; // 0x2C
		// public CriAtomEx.GameVariableInfo gameVariableInfo; // 0x64

		// RVA: 0x81C4A4 Offset: 0x81C4A4 VA: 0x81C4A4
		//public void .ctor(byte[] data, int startIndex) { }
	}

	[Serializable]
	public struct Randomize3dConfig
	{
		public const int NumOfCalcParams = 3;
		[SerializeField]
		private bool followsOriginalSource; // 0x0
		[SerializeField]
		private CriAtomEx.Randomize3dCalcType calculationType; // 0x4
		[SerializeField]
		private float[] calculationParameters; // 0x8

		// public bool FollowsOriginalSource { get; } // 0x81C634
		// public CriAtomEx.Randomize3dCalcType CalculationType { get; } // 0x81C63C
		// public float CalculationParameter1 { get; } // 0x81C644
		// public float CalculationParameter2 { get; } // 0x81C64C
		// public float CalculationParameter3 { get; } // 0x81C654

		// // RVA: 0x81C65C Offset: 0x81C65C VA: 0x81C65C
		// internal void .ctor(byte[] data, int startIndex) { }

		// // RVA: 0x81C664 Offset: 0x81C664 VA: 0x81C664
		public Randomize3dConfig(bool followsOriginalSource, CriAtomEx.Randomize3dCalcType calculationType, float param1 = 0, float param2 = 0, float param3 = 0)
		{
			this.followsOriginalSource = followsOriginalSource;
			this.calculationType = calculationType;
			calculationParameters = new float[3];
			calculationParameters[0] = param1;
			calculationParameters[1] = param2;
			calculationParameters[2] = param3;
		}

		// // RVA: 0x81C690 Offset: 0x81C690 VA: 0x81C690
		public Randomize3dConfig(int dummy) : this()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x81C698 Offset: 0x81C698 VA: 0x81C698
		// public void ClearCalcParams(float initVal = 0) { }

		// // RVA: 0x81C6A0 Offset: 0x81C6A0 VA: 0x81C6A0
		// public bool GetParamByType(CriAtomEx.Randomize3dParamType paramType, ref float paramVal) { }

		// // RVA: 0x81C6A8 Offset: 0x81C6A8 VA: 0x81C6A8
		// public bool SetParamByType(CriAtomEx.Randomize3dParamType paramType, float paramVal) { }
	}

	public enum Randomize3dCalcType
	{
		None = -1,
		Rectangle = 0,
		Cuboid = 1,
		Circle = 2,
		Cylinder = 3,
		Sphere = 4,
		List = 6,
	}

	public enum SoundRendererType
	{
		Default = 0,
		Native = 1,
		Asr = 2,
		Hw1 = 1,
		Hw2 = 9,
	}

	public enum Randomize3dParamType
	{
		None = 0,
		Width = 1,
		Depth = 2,
		Height = 3,
		Radius = 4,
	}

	public const uint InvalidAisacControlId = 65535;
	public static readonly Dictionary<CriAtomEx.Randomize3dCalcType, CriAtomEx.Randomize3dParamType[]> randomize3dParamTable = new Dictionary<CriAtomEx.Randomize3dCalcType, CriAtomEx.Randomize3dParamType[]>
																							{
																								{Randomize3dCalcType.None, new CriAtomEx.Randomize3dParamType[3]},
																								{Randomize3dCalcType.Rectangle, new CriAtomEx.Randomize3dParamType[3]},
																								{Randomize3dCalcType.Cuboid, new CriAtomEx.Randomize3dParamType[3] {CriAtomEx.Randomize3dParamType.Width, CriAtomEx.Randomize3dParamType.Depth, CriAtomEx.Randomize3dParamType.Height}},
																								{Randomize3dCalcType.Circle, new CriAtomEx.Randomize3dParamType[3]},
																								{Randomize3dCalcType.Cylinder, new CriAtomEx.Randomize3dParamType[3]},
																								{Randomize3dCalcType.Sphere, new CriAtomEx.Randomize3dParamType[3]},
																								{Randomize3dCalcType.List, new CriAtomEx.Randomize3dParamType[3]}
																							}; // 0x0
	public static CriAtomEx.SoundRendererType androidDefaultSoundRendererType = SoundRendererType.Default; // 0x4

	// // RVA: 0x28801D4 Offset: 0x28801D4 VA: 0x28801D4
	// public static void SetSpeakerAngle(CriAtomEx.SpeakerAngles6ch speakerAngle) { }

	// // RVA: 0x2880344 Offset: 0x2880344 VA: 0x2880344
	// public static void SetSpeakerAngle(CriAtomEx.SpeakerAngles8ch speakerAngle) { }

	// // RVA: 0x28804C4 Offset: 0x28804C4 VA: 0x28804C4
	// public static void SetVirtualSpeakerAngle(CriAtomEx.SpeakerAngles6ch speakerAngle) { }

	// // RVA: 0x2880634 Offset: 0x2880634 VA: 0x2880634
	// public static void SetVirtualSpeakerAngle(CriAtomEx.SpeakerAngles8ch speakerAngle) { }

	// // RVA: 0x28807B4 Offset: 0x28807B4 VA: 0x28807B4
	// public static void ControlVirtualSpeakerSetting(bool sw) { }

	// // RVA: 0x2880920 Offset: 0x2880920 VA: 0x2880920
	// public static void add_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

	// // RVA: 0x28809A0 Offset: 0x28809A0 VA: 0x28809A0
	// public static void remove_OnCueLinkCallback(CriAtomEx.CueLinkCbFunc value) { }

	// // RVA: 0x287D1AC Offset: 0x287D1AC VA: 0x287D1AC
	public static void RegisterAcf(CriFsBinder binder, string acfPath)
	{
		UnityEngine.Debug.LogWarning("TODO RegisterAcf");
	}

	// // RVA: 0x2880B7C Offset: 0x2880B7C VA: 0x2880B7C
	// public static void RegisterAcf(IntPtr acfData, int dataSize) { }

	// [ObsoleteAttribute] // RVA: 0x635B38 Offset: 0x635B38 VA: 0x635B38
	// // RVA: 0x2880CFC Offset: 0x2880CFC VA: 0x2880CFC
	// public static void RegisterAcf(byte[] acfData) { }

	// // RVA: 0x287D134 Offset: 0x287D134 VA: 0x287D134
	// public static void UnregisterAcf() { }

	// // RVA: 0x2880F94 Offset: 0x2880F94 VA: 0x2880F94
	// public static string GetAppliedDspBusSnapshotName() { }

	// // RVA: 0x287B1A0 Offset: 0x287B1A0 VA: 0x287B1A0
	// public static void AttachDspBusSetting(string settingName) { }

	// // RVA: 0x287B228 Offset: 0x287B228 VA: 0x287B228
	// public static void DetachDspBusSetting() { }

	// // RVA: 0x2881328 Offset: 0x2881328 VA: 0x2881328
	// public static void ApplyDspBusSnapshot(string snapshot_name, int time_ms) { }

	// // RVA: 0x28814B4 Offset: 0x28814B4 VA: 0x28814B4
	// public static int GetNumGameVariables() { }

	// // RVA: 0x2881608 Offset: 0x2881608 VA: 0x2881608
	// public static bool GetGameVariableInfo(ushort index, out CriAtomEx.GameVariableInfo info) { }

	// // RVA: 0x2881AF8 Offset: 0x2881AF8 VA: 0x2881AF8
	// public static float GetGameVariable(uint game_variable_id) { }

	// // RVA: 0x2881C58 Offset: 0x2881C58 VA: 0x2881C58
	// public static float GetGameVariable(string game_variable_name) { }

	// // RVA: 0x2881DDC Offset: 0x2881DDC VA: 0x2881DDC
	// public static void SetGameVariable(uint game_variable_id, float game_variable_value) { }

	// // RVA: 0x2881F50 Offset: 0x2881F50 VA: 0x2881F50
	// public static void SetGameVariable(string game_variable_name, float game_variable_value) { }

	// // RVA: 0x28820DC Offset: 0x28820DC VA: 0x28820DC
	public static void SetRandomSeed(uint seed)
	{
		UnityEngine.Debug.LogWarning("TODO SetRandomSeed");
	}

	// // RVA: 0x2882274 Offset: 0x2882274 VA: 0x2882274
	// public static void ResetPerformanceMonitor() { }

	// // RVA: 0x28823C8 Offset: 0x28823C8 VA: 0x28823C8
	// public static void GetPerformanceInfo(out CriAtomEx.PerformanceInfo info) { }

	// // RVA: 0x2882524 Offset: 0x2882524 VA: 0x2882524
	// public static void SetGlobalLabelToSelectorByIndex(ushort selector_index, ushort label_index) { }

	// // RVA: 0x28826A8 Offset: 0x28826A8 VA: 0x28826A8
	// public static void SetGlobalLabelToSelectorByName(string selector_name, string label_name) { }

	// // RVA: 0x2882858 Offset: 0x2882858 VA: 0x2882858
	// public static void Lock() { }

	// // RVA: 0x28829C4 Offset: 0x28829C4 VA: 0x28829C4
	// public static void Unlock() { }

	// // RVA: 0x2882B38 Offset: 0x2882B38 VA: 0x2882B38
	// public static void SetOutputAudioDevice_PC(string deviceId) { }

	// // RVA: 0x2882B3C Offset: 0x2882B3C VA: 0x2882B3C
	// public static bool LoadAudioDeviceList_PC() { }

	// // RVA: 0x2882B44 Offset: 0x2882B44 VA: 0x2882B44
	// public static int GetNumAudioDevices_PC() { }

	// // RVA: 0x2882B4C Offset: 0x2882B4C VA: 0x2882B4C
	// public static string GetAudioDeviceName_PC(int index) { }

	// // RVA: 0x2882B54 Offset: 0x2882B54 VA: 0x2882B54
	// public static void SetOutputAudioDevice_PC(int index) { }

	// // RVA: 0x2882B58 Offset: 0x2882B58 VA: 0x2882B58
	// public static void SetOutputVolume_VITA(float volume) { }

	// // RVA: 0x2882B5C Offset: 0x2882B5C VA: 0x2882B5C
	// public static bool IsBgmPortAcquired_VITA() { }

	// // RVA: 0x2882B64 Offset: 0x2882B64 VA: 0x2882B64
	// public static bool IsSoundStopped_IOS() { }

	// // RVA: 0x2882B6C Offset: 0x2882B6C VA: 0x2882B6C
	// public static void EnableAudioSessionRestoration_IOS(bool flag) { }

	// // RVA: 0x2880A20 Offset: 0x2880A20 VA: 0x2880A20
	// private static extern bool criAtomEx_RegisterAcfFile(IntPtr binder, string path, IntPtr work, int workSize) { }

	// // RVA: 0x2880C18 Offset: 0x2880C18 VA: 0x2880C18
	// private static extern void criAtomEx_RegisterAcfData(IntPtr acfData, int acfDataSize, IntPtr work, int workSize) { }

	// // RVA: 0x2880DA0 Offset: 0x2880DA0 VA: 0x2880DA0
	// private static extern void criAtomEx_RegisterAcfData(byte[] acfData, int acfDataSize, IntPtr work, int workSize) { }

	// // RVA: 0x2880E90 Offset: 0x2880E90 VA: 0x2880E90
	// private static extern void criAtomEx_UnregisterAcf() { }

	// // RVA: 0x2881140 Offset: 0x2881140 VA: 0x2881140
	// private static extern void criAtomEx_AttachDspBusSetting(string settingName, IntPtr work, int workSize) { }

	// // RVA: 0x2881250 Offset: 0x2881250 VA: 0x2881250
	// private static extern void criAtomEx_DetachDspBusSetting() { }

	// // RVA: 0x28813B0 Offset: 0x28813B0 VA: 0x28813B0
	// private static extern void criAtomEx_ApplyDspBusSnapshot(string snapshot_name, int time_ms) { }

	// // RVA: 0x2881060 Offset: 0x2881060 VA: 0x2881060
	// private static extern IntPtr criAtomEx_GetAppliedDspBusSnapshotName() { }

	// // RVA: 0x2881530 Offset: 0x2881530 VA: 0x2881530
	// private static extern int criAtomEx_GetNumGameVariables() { }

	// // RVA: 0x2881840 Offset: 0x2881840 VA: 0x2881840
	// private static extern bool criAtomEx_GetGameVariableInfo(ushort index, IntPtr game_variable_info) { }

	// // RVA: 0x2881B78 Offset: 0x2881B78 VA: 0x2881B78
	// private static extern float criAtomEx_GetGameVariableById(uint game_variable_id) { }

	// // RVA: 0x2881CD8 Offset: 0x2881CD8 VA: 0x2881CD8
	// private static extern float criAtomEx_GetGameVariableByName(string game_variable_name) { }

	// // RVA: 0x2881E68 Offset: 0x2881E68 VA: 0x2881E68
	// private static extern void criAtomEx_SetGameVariableById(uint game_variable_id, float game_variable_value) { }

	// // RVA: 0x2881FD8 Offset: 0x2881FD8 VA: 0x2881FD8
	// private static extern void criAtomEx_SetGameVariableByName(string game_variable_name, float game_variable_value) { }

	// // RVA: 0x2882160 Offset: 0x2882160 VA: 0x2882160
	// private static extern void criAtomEx_SetRandomSeed(uint seed) { }

	// // RVA: 0x28828D0 Offset: 0x28828D0 VA: 0x28828D0
	// private static extern void criAtomEx_Lock() { }

	// // RVA: 0x2882A40 Offset: 0x2882A40 VA: 0x2882A40
	// private static extern void criAtomEx_Unlock() { }

	// // RVA: 0x28822F0 Offset: 0x28822F0 VA: 0x28822F0
	// private static extern void criAtom_ResetPerformanceMonitor() { }

	// // RVA: 0x2882448 Offset: 0x2882448 VA: 0x2882448
	// private static extern void criAtom_GetPerformanceInfo(out CriAtomEx.PerformanceInfo info) { }

	// // RVA: 0x28825B0 Offset: 0x28825B0 VA: 0x28825B0
	// private static extern void criAtomExAcf_SetGlobalLabelToSelectorByIndex(ushort selector_index, ushort label_index) { }

	// // RVA: 0x2882730 Offset: 0x2882730 VA: 0x2882730
	// private static extern void criAtomExAcf_SetGlobalLabelToSelectorByName(string selector_name, string label_name) { }

	// // RVA: 0x2880270 Offset: 0x2880270 VA: 0x2880270
	// private static extern void criAtomEx_SetSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles6ch angle_array) { }

	// // RVA: 0x28803F0 Offset: 0x28803F0 VA: 0x28803F0
	// private static extern void criAtomEx_SetSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles8ch angle_array) { }

	// // RVA: 0x2880560 Offset: 0x2880560 VA: 0x2880560
	// private static extern void criAtomEx_SetVirtualSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles6ch angle_array) { }

	// // RVA: 0x28806E0 Offset: 0x28806E0 VA: 0x28806E0
	// private static extern void criAtomEx_SetVirtualSpeakerAngleArray(CriAtomEx.SpeakerSystem speaker_system, ref CriAtomEx.SpeakerAngles8ch angle_array) { }

	// // RVA: 0x2880838 Offset: 0x2880838 VA: 0x2880838
	// private static extern void criAtomEx_ControlVirtualSpeakerSetting(bool sw) { }

	// // RVA: 0x2882B70 Offset: 0x2882B70 VA: 0x2882B70
	// public static extern void criAtom_EnableSlLatencyCheck_ANDROID(bool sw) { }

	// // RVA: 0x2882C58 Offset: 0x2882C58 VA: 0x2882C58
	// public static extern int criAtom_GetSlBufferConsumptionLatency_ANDROID() { }
}
