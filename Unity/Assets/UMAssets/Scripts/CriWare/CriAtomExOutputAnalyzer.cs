using System;

public class CriAtomExOutputAnalyzer : CriDisposable
{
	public struct Config
	{
		public bool enableLevelmeter;
		public bool enableSpectrumAnalyzer;
		public bool enablePcmCapture;
		public bool enablePcmCaptureCallback;
		public int numSpectrumAnalyzerBands;
		public int numCapturedPcmSamples;
	}


	// public const int MaximumSpectrumBands = 512;
	// protected IntPtr handle; // 0x18
	// protected CriAtomExPlayer player; // 0x1C
	// protected string busName; // 0x20
	// protected int numBands; // 0x24
	// protected int numCapturedPcmSamples; // 0x28
	// protected CriAtomExOutputAnalyzer.PcmCaptureCallback userPcmCaptureCallback; // 0x2C
	// protected float[] dataL; // 0x30
	// protected float[] dataR; // 0x34
	// protected const int pcmCapturerNumMaxData = 512;
	// protected static IntPtr InternalCallbackFunctionPointer = IntPtr.Zero; // 0x0
	// protected static CriAtomExOutputAnalyzer.InternalPcmCaptureCallback DelegateObject; // 0x4
	// protected static float[] DataL; // 0x8
	// protected static float[] DataR; // 0xC
	// protected static CriAtomExOutputAnalyzer.PcmCaptureCallback UserPcmCaptureCallback = null; // 0x10

	// public IntPtr nativeHandle { get; }

	// // RVA: 0x289F268 Offset: 0x289F268 VA: 0x289F268
	// public IntPtr get_nativeHandle() { }

	// // RVA: 0x289F270 Offset: 0x289F270 VA: 0x289F270
	public CriAtomExOutputAnalyzer(CriAtomExOutputAnalyzer.Config config)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x289F490 Offset: 0x289F490 VA: 0x289F490 Slot: 5
	public override void Dispose()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x289F498 Offset: 0x289F498 VA: 0x289F498
	// protected void Dispose(bool disposing) { }

	// // RVA: 0x289F8B8 Offset: 0x289F8B8 VA: 0x289F8B8
	// public bool AttachExPlayer(CriAtomExPlayer player) { }

	// // RVA: 0x289F5C4 Offset: 0x289F5C4 VA: 0x289F5C4
	// public void DetachExPlayer() { }

	// // RVA: 0x289FC28 Offset: 0x289FC28 VA: 0x289FC28
	// public bool AttachDspBus(string busName) { }

	// // RVA: 0x289F720 Offset: 0x289F720 VA: 0x289F720
	// public void DetachDspBus() { }

	// // RVA: 0x289FF20 Offset: 0x289FF20 VA: 0x289FF20
	// public float GetRms(int channel) { }

	// // RVA: 0x28A0108 Offset: 0x28A0108 VA: 0x28A0108
	// public void GetSpectrumLevels(ref float[] levels) { }

	// // RVA: 0x28A033C Offset: 0x28A033C VA: 0x28A033C
	// public void GetPcmData(ref float[] data, int ch) { }

	// // RVA: 0x28A058C Offset: 0x28A058C VA: 0x28A058C
	// public void SetPcmCaptureCallback(CriAtomExOutputAnalyzer.PcmCaptureCallback callback) { }

	// // RVA: 0x28A0594 Offset: 0x28A0594 VA: 0x28A0594
	// public void ExecutePcmCaptureCallback() { }

	// [ObsoleteAttribute] // RVA: 0x635E5C Offset: 0x635E5C VA: 0x635E5C
	// // RVA: 0x28A08D4 Offset: 0x28A08D4 VA: 0x28A08D4
	// public void ExecutePcmCaptureCallback(CriAtomExOutputAnalyzer.PcmCaptureCallback callback) { }

	// // RVA: 0x28A08DC Offset: 0x28A08DC VA: 0x28A08DC
	protected CriAtomExOutputAnalyzer()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x28A0980 Offset: 0x28A0980 VA: 0x28A0980 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x289F33C Offset: 0x289F33C VA: 0x289F33C
	// protected void InitializeWithConfig(CriAtomExOutputAnalyzer.Config config) { }

	// [MonoPInvokeCallbackAttribute] // RVA: 0x635E90 Offset: 0x635E90 VA: 0x635E90
	// // RVA: 0x289EFEC Offset: 0x289EFEC VA: 0x289EFEC
	// private static void Callback(IntPtr ptrL, IntPtr ptrR, int numChannels, int numData) { }

	// // RVA: 0x28A09E8 Offset: 0x28A09E8 VA: 0x28A09E8
	// protected static extern IntPtr criAtomExOutputAnalyzer_Create(in CriAtomExOutputAnalyzer.Config config) { }

	// // RVA: 0x289F7D8 Offset: 0x289F7D8 VA: 0x289F7D8
	// protected static extern void criAtomExOutputAnalyzer_Destroy(IntPtr analyzer) { }

	// // RVA: 0x289FA18 Offset: 0x289FA18 VA: 0x289FA18
	// protected static extern void criAtomExOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player) { }

	// // RVA: 0x289FB38 Offset: 0x289FB38 VA: 0x289FB38
	// protected static extern void criAtomExOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player) { }

	// // RVA: 0x289FD00 Offset: 0x289FD00 VA: 0x289FD00
	// protected static extern void criAtomExOutputAnalyzer_AttachDspBusByName(IntPtr analyzer, string busName) { }

	// // RVA: 0x289FE10 Offset: 0x289FE10 VA: 0x289FE10
	// protected static extern void criAtomExOutputAnalyzer_DetachDspBusByName(IntPtr analyzer, string busName) { }

	// // RVA: 0x28A0020 Offset: 0x28A0020 VA: 0x28A0020
	// protected static extern float criAtomExOutputAnalyzer_GetRms(IntPtr analyzer, int channel) { }

	// // RVA: 0x28A0250 Offset: 0x28A0250 VA: 0x28A0250
	// protected static extern IntPtr criAtomExOutputAnalyzer_GetSpectrumLevels(IntPtr analyzer) { }

	// // RVA: 0x28A04A0 Offset: 0x28A04A0 VA: 0x28A04A0
	// protected static extern IntPtr criAtomExOutputAnalyzer_GetPcmData(IntPtr analyzer, int ch) { }

	// // RVA: 0x28A07D0 Offset: 0x28A07D0 VA: 0x28A07D0
	// protected static extern void criAtomExOutputAnalyzer_ExecuteQueuedPcmCapturerCallbacks(IntPtr analyzer, IntPtr callback) { }
}
