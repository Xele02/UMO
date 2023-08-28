using System;
using UnityEngine;

namespace CriWare
{
	public class CriAtomExOutputAnalyzer : CriDisposable
	{
		public struct Config
		{
			public bool enableLevelmeter; // 0x0
			public bool enableSpectrumAnalyzer; // 0x1
			public bool enablePcmCapture; // 0x2
			public bool enablePcmCaptureCallback; // 0x3
			public int numSpectrumAnalyzerBands; // 0x4
			public int numCapturedPcmSamples; // 0x8
		}


		public const int MaximumSpectrumBands = 512;
		protected IntPtr handle = IntPtr.Zero; // 0x18
		protected CriAtomExPlayer player; // 0x1C
		protected string busName; // 0x20
		protected int numBands = 0; // 0x24
		protected int numCapturedPcmSamples = 4096; // 0x28
		//protected CriAtomExOutputAnalyzer.PcmCaptureCallback userPcmCaptureCallback; // 0x2C
		protected float[] dataL; // 0x30
		protected float[] dataR; // 0x34
		protected const int pcmCapturerNumMaxData = 512;
		protected static IntPtr InternalCallbackFunctionPointer = IntPtr.Zero; // 0x0
		//protected static CriAtomExOutputAnalyzer.InternalPcmCaptureCallback DelegateObject; // 0x4
		protected static float[] DataL; // 0x8
		protected static float[] DataR; // 0xC
		//protected static CriAtomExOutputAnalyzer.PcmCaptureCallback UserPcmCaptureCallback = null; // 0x10

		// public IntPtr nativeHandle { get; }

		// // RVA: 0x289F268 Offset: 0x289F268 VA: 0x289F268
		// public IntPtr get_nativeHandle() { }

		// // RVA: 0x289F270 Offset: 0x289F270 VA: 0x289F270
		public CriAtomExOutputAnalyzer(Config config)
		{
			InitializeWithConfig(config);
			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		}

		// // RVA: 0x289F490 Offset: 0x289F490 VA: 0x289F490 Slot: 5
		public override void Dispose()
		{
			Dispose(true);
		}

		// // RVA: 0x289F498 Offset: 0x289F498 VA: 0x289F498
		protected void Dispose(bool disposing)
		{
			CriDisposableObjectManager.Unregister(this);
			if(handle != IntPtr.Zero)
			{
				DetachExPlayer();
				DetachDspBus();
				criAtomExOutputAnalyzer_Destroy(handle);
				handle = IntPtr.Zero;
			}
			if (!disposing)
				return;
			GC.SuppressFinalize(this);
		}

		// // RVA: 0x289F8B8 Offset: 0x289F8B8 VA: 0x289F8B8
		public bool AttachExPlayer(CriAtomExPlayer player)
		{
			if(player != null && player.isAvailable)
			{
				if(handle != IntPtr.Zero)
				{
					DetachExPlayer();
					DetachDspBus();
					if(player.GetStatus() == CriAtomExPlayer.Status.Stop)
					{
						criAtomExOutputAnalyzer_AttachExPlayer(handle, player.nativeHandle);
						this.player = player;
						return true;
					}
				}
			}
			return false;
		}

		// // RVA: 0x289F5C4 Offset: 0x289F5C4 VA: 0x289F5C4
		public void DetachExPlayer()
		{
			if(player != null && player.isAvailable)
			{
				if (handle == IntPtr.Zero)
					return;
				if(player.GetStatus() != CriAtomExPlayer.Status.Stop)
				{
					Debug.LogWarning("[CRIWARE] Warning: CriAtomExPlayer is forced to stop for detaching CriAtomExOutputAnalyzer.");
					player.StopWithoutReleaseTime();
				}
				criAtomExOutputAnalyzer_DetachExPlayer(handle, player.nativeHandle);
			}
		}

		// // RVA: 0x289FC28 Offset: 0x289FC28 VA: 0x289FC28
		// public bool AttachDspBus(string busName) { }

		// // RVA: 0x289F720 Offset: 0x289F720 VA: 0x289F720
		public void DetachDspBus()
		{
			if(busName != null)
			{
				if (handle == IntPtr.Zero)
					return;
				criAtomExOutputAnalyzer_DetachDspBusByName(handle, busName);
				busName = null;
			}
		}

		// // RVA: 0x289FF20 Offset: 0x289FF20 VA: 0x289FF20
		public float GetRms(int channel)
		{
			if ((player != null || busName != null) && handle != IntPtr.Zero)
			{
				if (player != null && player.GetStatus() != CriAtomExPlayer.Status.Playing)
				{
					if (player.GetStatus() != CriAtomExPlayer.Status.Prep)
						return 0;
				}
#if UNITY_ANDROID
				return CriAtomExOutputAnalyzer.criAtomExOutputAnalyzer_GetRms(handle, channel);
#else
				int numSample = player.source.unityAudioSource.clip.frequency / 30;
				float[] sample = new float[numSample];

				player.source.unityAudioSource.GetOutputData(sample, channel);
				float sum = 0;
				for(int i = 0; i < numSample; i++)
				{
					sum += sample[i] * sample[i];
				}
				float res = Mathf.Sqrt(sum / numSample);
				return res;
#endif
			}
			return 0;
		}

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
			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		}

		// // RVA: 0x28A0980 Offset: 0x28A0980 VA: 0x28A0980 Slot: 1
		~CriAtomExOutputAnalyzer()
		{
			Dispose(false);
		}

		// // RVA: 0x289F33C Offset: 0x289F33C VA: 0x289F33C
		protected void InitializeWithConfig(Config config)
		{
			handle = criAtomExOutputAnalyzer_Create(config);
			if(handle != IntPtr.Zero)
			{
				numBands = config.numSpectrumAnalyzerBands;
				numCapturedPcmSamples = config.numCapturedPcmSamples;
				if(config.enablePcmCaptureCallback && dataL == null)
				{
					dataL = new float[512];
					dataR = new float[512];
				}
			}
			else
			{
				throw new Exception("criAtomExOutputAnalyzer_Create() failed.");
			}
		}

		// [MonoPInvokeCallbackAttribute] // RVA: 0x635E90 Offset: 0x635E90 VA: 0x635E90
		// // RVA: 0x289EFEC Offset: 0x289EFEC VA: 0x289EFEC
		// private static void Callback(IntPtr ptrL, IntPtr ptrR, int numChannels, int numData) { }

		// // RVA: 0x28A09E8 Offset: 0x28A09E8 VA: 0x28A09E8
		// protected static extern IntPtr criAtomExOutputAnalyzer_Create(in CriAtomExOutputAnalyzer.Config config) { }
		protected static IntPtr criAtomExOutputAnalyzer_Create(in Config config)
		{
			TodoLogger.Log(TodoLogger.CriAtom, "criAtomExOutputAnalyzer_Create");
			return new IntPtr(1);
		}

		// // RVA: 0x289F7D8 Offset: 0x289F7D8 VA: 0x289F7D8
		// protected static extern void criAtomExOutputAnalyzer_Destroy(IntPtr analyzer) { }
		protected static void criAtomExOutputAnalyzer_Destroy(IntPtr analyzer)
		{
			TodoLogger.Log(TodoLogger.CriAtom, "criAtomExOutputAnalyzer_Destroy");
		}

		// // RVA: 0x289FA18 Offset: 0x289FA18 VA: 0x289FA18
		// protected static extern void criAtomExOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player) { }
		protected static void criAtomExOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player)
		{
			TodoLogger.Log(TodoLogger.CriAtom, "criAtomExOutputAnalyzer_AttachExPlayer");
		}

		// // RVA: 0x289FB38 Offset: 0x289FB38 VA: 0x289FB38
		// protected extern static void criAtomExOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player)
		protected static void criAtomExOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player)
		{
			TodoLogger.Log(TodoLogger.CriAtom, "criAtomExOutputAnalyzer_DetachExPlayer");
		}

		// // RVA: 0x289FD00 Offset: 0x289FD00 VA: 0x289FD00
		// protected static extern void criAtomExOutputAnalyzer_AttachDspBusByName(IntPtr analyzer, string busName) { }

		// // RVA: 0x289FE10 Offset: 0x289FE10 VA: 0x289FE10
		// protected static extern void criAtomExOutputAnalyzer_DetachDspBusByName(IntPtr analyzer, string busName) { }
		protected static void criAtomExOutputAnalyzer_DetachDspBusByName(IntPtr analyzer, string busName)
		{
			TodoLogger.Log(TodoLogger.CriAtom, "criAtomExOutputAnalyzer_DetachDspBusByName");
		}

		// // RVA: 0x28A0020 Offset: 0x28A0020 VA: 0x28A0020
		// protected static extern float criAtomExOutputAnalyzer_GetRms(IntPtr analyzer, int channel) { }

		// // RVA: 0x28A0250 Offset: 0x28A0250 VA: 0x28A0250
		// protected static extern IntPtr criAtomExOutputAnalyzer_GetSpectrumLevels(IntPtr analyzer) { }

		// // RVA: 0x28A04A0 Offset: 0x28A04A0 VA: 0x28A04A0
		// protected static extern IntPtr criAtomExOutputAnalyzer_GetPcmData(IntPtr analyzer, int ch) { }

		// // RVA: 0x28A07D0 Offset: 0x28A07D0 VA: 0x28A07D0
		// protected static extern void criAtomExOutputAnalyzer_ExecuteQueuedPcmCapturerCallbacks(IntPtr analyzer, IntPtr callback) { }
	}
}
