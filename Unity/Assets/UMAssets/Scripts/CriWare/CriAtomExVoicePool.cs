public class CriAtomExVoicePool : CriDisposable
{
	// public const int StandardMemoryAsrVoicePoolId = 0;
	// public const int StandardStreamingAsrVoicePoolId = 1;
	// public const int StandardMemoryNsrVoicePoolId = 2;
	// public const int StandardStreamingNsrVoicePoolId = 3;
	// protected IntPtr _handle; // 0x18
	// protected uint _identifier; // 0x1C
	// protected int _numVoices; // 0x20
	// protected int _maxChannels; // 0x24
	// protected int _maxSamplingRate; // 0x28

	// public IntPtr nativeHandle { get; }
	// public uint identifier { get; }
	// public int numVoices { get; }
	// public int maxChannels { get; }
	// public int maxSamplingRate { get; }

	// // RVA: 0x28ADB04 Offset: 0x28ADB04 VA: 0x28ADB04
	// public static CriAtomExVoicePool.UsedVoicesInfo GetNumUsedVoices(CriAtomExVoicePool.VoicePoolId voicePoolId) { }

	// // RVA: 0x28ADC5C Offset: 0x28ADC5C VA: 0x28ADC5C
	// public IntPtr get_nativeHandle() { }

	// // RVA: 0x28ADC64 Offset: 0x28ADC64 VA: 0x28ADC64
	// public uint get_identifier() { }

	// // RVA: 0x28ADC6C Offset: 0x28ADC6C VA: 0x28ADC6C
	// public int get_numVoices() { }

	// // RVA: 0x28ADC74 Offset: 0x28ADC74 VA: 0x28ADC74
	// public int get_maxChannels() { }

	// // RVA: 0x28ADC7C Offset: 0x28ADC7C VA: 0x28ADC7C
	// public int get_maxSamplingRate() { }

	// // RVA: 0x28ADC84 Offset: 0x28ADC84 VA: 0x28ADC84 Slot: 5
	public override void Dispose()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x28ADE7C Offset: 0x28ADE7C VA: 0x28ADE7C
	// public CriAtomExVoicePool.UsedVoicesInfo GetNumUsedVoices() { }

	// // RVA: 0x28AE01C Offset: 0x28AE01C VA: 0x28AE01C
	// public void AttachDspTimeStretch() { }

	// // RVA: 0x28AE1C0 Offset: 0x28AE1C0 VA: 0x28AE1C0
	// public void AttachDspPitchShifter(CriAtomExVoicePool.PitchShifterMode mode = 0, int windosSize = 1024, int overlapTimes = 4) { }

	// // RVA: 0x28AE37C Offset: 0x28AE37C VA: 0x28AE37C
	// public void DetachDsp() { }

	// // RVA: 0x28AE4C8 Offset: 0x28AE4C8 VA: 0x28AE4C8 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x28ADB48 Offset: 0x28ADB48 VA: 0x28ADB48
	// private static extern void CRIWARE1E2249AB(int voice_pool_id, out int num_used_voices, out int num_pool_voices) { }

	// // RVA: 0x28ADF28 Offset: 0x28ADF28 VA: 0x28ADF28
	// private static extern void criAtomExVoicePool_GetNumUsedVoices(IntPtr pool, out int num_used_voices, out int num_pool_voices) { }

	// // RVA: 0x28ADD68 Offset: 0x28ADD68 VA: 0x28ADD68
	// public static extern void criAtomExVoicePool_Free(IntPtr pool) { }

	// // RVA: 0x28AE0C0 Offset: 0x28AE0C0 VA: 0x28AE0C0
	// private static extern void criAtomExVoicePool_AttachDspTimeStretch(IntPtr pool, ref CriAtomExVoicePool.ExTimeStretchConfig config, IntPtr work, int work_size) { }

	// // RVA: 0x28AE278 Offset: 0x28AE278 VA: 0x28AE278
	// private static extern void criAtomExVoicePool_AttachDspPitchShifter(IntPtr pool, ref CriAtomExVoicePool.ExPitchShifterConfig config, IntPtr work, int work_size) { }

	// // RVA: 0x28AE3E8 Offset: 0x28AE3E8 VA: 0x28AE3E8
	// private static extern void criAtomExVoicePool_DetachDsp(IntPtr pool) { }

	// // RVA: 0x28AB98C Offset: 0x28AB98C VA: 0x28AB98C
	// protected void .ctor() { }
}
