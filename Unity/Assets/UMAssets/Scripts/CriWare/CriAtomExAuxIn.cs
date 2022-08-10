using System;

namespace CriWare
{
	public class CriAtomExAuxIn : CriDisposable
	{
		public struct Config
		{
			public int maxChannels;
			public int maxSamplingRate;
			public CriAtomEx.SoundRendererType soundRendererType;
		}


		// private const string errorInvalidHandle = "[CRIWARE] Invalid native handle of CriAtomExAuxIn.";
		// private IntPtr handle; // 0x18
		// private CriAudioReadStream inputReadStream; // 0x1C

		// // RVA: 0x2897BF0 Offset: 0x2897BF0 VA: 0x2897BF0
		public CriAtomExAuxIn(Nullable<CriAtomExAuxIn.Config> config)
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2898174 Offset: 0x2898174 VA: 0x2898174 Slot: 5
		public override void Dispose()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28985A8 Offset: 0x28985A8 VA: 0x28985A8
		public void Start()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x28986BC Offset: 0x28986BC VA: 0x28986BC
		// public void Stop() { }

		// // RVA: 0x28987D0 Offset: 0x28987D0 VA: 0x28987D0
		// public void SetFormat(int numChannels, int samplingRate) { }

		// // RVA: 0x28988FC Offset: 0x28988FC VA: 0x28988FC
		// public void GetFormat(out int numChannels, out int samplingRate) { }

		// // RVA: 0x2898A2C Offset: 0x2898A2C VA: 0x2898A2C
		// public void SetVolume(float volume) { }

		// // RVA: 0x2898B54 Offset: 0x2898B54 VA: 0x2898B54
		// public void SetFrequencyRatio(float frequencyRatio) { }

		// // RVA: 0x2898C48 Offset: 0x2898C48 VA: 0x2898C48
		// public void SetBusSendLevel(string busName, float level) { }

		// // RVA: 0x2898D60 Offset: 0x2898D60 VA: 0x2898D60
		// public void SetInputReadStream(CriAudioReadStream stream) { }

		// // RVA: 0x2898058 Offset: 0x2898058 VA: 0x2898058
		// private static extern IntPtr criAtomAuxIn_Create(in CriAtomExAuxIn.Config config, IntPtr work, int work_size) { }

		// // RVA: 0x2898258 Offset: 0x2898258 VA: 0x2898258
		// private static extern void criAtomAuxIn_Destroy(IntPtr aux_in) { }

		// // RVA: 0x28985B0 Offset: 0x28985B0 VA: 0x28985B0
		// private static extern void criAtomAuxIn_Start(IntPtr aux_in) { }

		// // RVA: 0x28986C8 Offset: 0x28986C8 VA: 0x28986C8
		// private static extern void criAtomAuxIn_Stop(IntPtr aux_in) { }

		// // RVA: 0x2898A38 Offset: 0x2898A38 VA: 0x2898A38
		// private static extern void criAtomAuxIn_SetVolume(IntPtr aux_in, float volume) { }

		// // RVA: 0x2898B60 Offset: 0x2898B60 VA: 0x2898B60
		// private static extern void criAtomAuxIn_SetFrequencyRatio(IntPtr aux_in, float ratio) { }

		// // RVA: 0x2898C50 Offset: 0x2898C50 VA: 0x2898C50
		// private static extern void criAtomAuxIn_SetBusSendLevelByName(IntPtr aux_in, string bus_name, float level) { }

		// // RVA: 0x28987D8 Offset: 0x28987D8 VA: 0x28987D8
		// private static extern void criAtomAuxIn_SetFormat(IntPtr aux_in, int num_channels, int sampling_rate) { }

		// // RVA: 0x2898908 Offset: 0x2898908 VA: 0x2898908
		// private static extern void criAtomAuxIn_GetFormat(IntPtr aux_in, out int num_channels, out int sampling_rate) { }

		// // RVA: 0x2898DC0 Offset: 0x2898DC0 VA: 0x2898DC0
		// private static extern void criAtomAuxIn_SetInputReadStream(IntPtr aux_in, IntPtr stream_cbfunc, IntPtr stream_ptr) { }
	}
}