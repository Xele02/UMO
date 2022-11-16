using System;

namespace CriWare
{
	public struct CriAtomExPlayback
	{
		public enum Status
		{
			Prep = 1,
			Playing = 2,
			Removed = 3,
		}

		public struct TrackInfo
		{
			public CriAtomEx.CueType sequenceType; // 0x4
			public IntPtr playerHn; // 0x8
			public ushort trackNo; // 0xC
			public ushort reserved; // 0xE
		}

		public const uint invalidId = 0xFFFFFFFF;

		public uint id { get; private set; } // 0x0
		// public CriAtomExPlayback.Status status { get; } 0x81E494
		// public long time { get; } 0x81E49C
		public long timeSyncedWithAudio { get { return criAtomExPlayback_GetTimeSyncedWithAudio(id); } } //0x81E4A4

		// RVA: 0x81E408 Offset: 0x81E408 VA: 0x81E408
		public CriAtomExPlayback(uint id) : this()
		{
			this.id = id;
		#if CRIWARE_ENABLE_HEADLESS_MODE
			this._dummyStatus = Status.Prep;
		#endif
		}

		// // RVA: 0x81E410 Offset: 0x81E410 VA: 0x81E410
		public void Stop(bool ignoresReleaseTime)
		{
			if (!CriAtomPlugin.IsLibraryInitialized())
				return;
			if (ignoresReleaseTime)
				criAtomExPlayback_StopWithoutReleaseTime(id);
			else
				criAtomExPlayback_Stop(id);
		}

		// // RVA: 0x81E418 Offset: 0x81E418 VA: 0x81E418
		public void Pause()
		{
			Pause(true);
		}

		// // RVA: 0x81E424 Offset: 0x81E424 VA: 0x81E424
		public void Resume(CriAtomEx.ResumeMode mode)
		{
			criAtomExPlayback_Resume(this.id, mode);
		}

		// // RVA: 0x81E42C Offset: 0x81E42C VA: 0x81E42C
		// public bool IsPaused() { }

		// // RVA: 0x81E434 Offset: 0x81E434 VA: 0x81E434
		// public bool GetFormatInfo(out CriAtomEx.FormatInfo info) { }

		// // RVA: 0x81E43C Offset: 0x81E43C VA: 0x81E43C
		public CriAtomExPlayback.Status GetStatus()
		{
			return criAtomExPlayback_GetStatus(this.id);
		}

		// // RVA: 0x81E444 Offset: 0x81E444 VA: 0x81E444
		// public long GetTime() { }

		// // RVA: 0x81E44C Offset: 0x81E44C VA: 0x81E44C
		// public long GetTimeSyncedWithAudio() { }

		// // RVA: 0x81E454 Offset: 0x81E454 VA: 0x81E454
		// public bool GetNumPlayedSamples(out long numSamples, out int samplingRate) { }

		// // RVA: 0x81E45C Offset: 0x81E45C VA: 0x81E45C
		// public long GetSequencePosition() { }

		// // RVA: 0x81E464 Offset: 0x81E464 VA: 0x81E464
		// public int GetCurrentBlockIndex() { }

		// // RVA: 0x81E46C Offset: 0x81E46C VA: 0x81E46C
		// public bool GetTrackInfo(out CriAtomExPlayback.TrackInfo info) { }

		// // RVA: 0x81E474 Offset: 0x81E474 VA: 0x81E474
		// public bool GetBeatSyncInfo(out CriAtomExBeatSync.Info info) { }

		// // RVA: 0x81E47C Offset: 0x81E47C VA: 0x81E47C
		// public void SetNextBlockIndex(int index) { }

		// // RVA: 0x81E4AC Offset: 0x81E4AC VA: 0x81E4AC
		public void Stop()
		{
			Stop(false);
		}

		// // RVA: 0x81E4B4 Offset: 0x81E4B4 VA: 0x81E4B4
		// public void StopWithoutReleaseTime() { }

		// // RVA: 0x81E4BC Offset: 0x81E4BC VA: 0x81E4BC
		public void Pause(bool sw)
		{
			criAtomExPlayback_Pause(this.id, sw);
		}

		// // RVA: 0x28A1AE0 Offset: 0x28A1AE0 VA: 0x28A1AE0
		
		#if UNITY_ANDROID
		private static extern void criAtomExPlayback_Stop(uint id) { }
		#else
		private static void criAtomExPlayback_Stop(uint id)
		{
			ExternLib.LibCriWare.criAtomExPlayback_Stop(id);
		}
		#endif

		// // RVA: 0x28A1BF8 Offset: 0x28A1BF8 VA: 0x28A1BF8
	
		#if UNITY_ANDROID
		private static extern void criAtomExPlayback_StopWithoutReleaseTime(uint id) { }
		#else
		private static void criAtomExPlayback_StopWithoutReleaseTime(uint id)
		{
			ExternLib.LibCriWare.criAtomExPlayback_StopWithoutReleaseTime(id);
		}
		#endif

		// // RVA: 0x28A1CF0 Offset: 0x28A1CF0 VA: 0x28A1CF0
		#if UNITY_ANDROID
		private static extern void criAtomExPlayback_Pause(uint id, bool sw);
		#else
		private static void criAtomExPlayback_Pause(uint id, bool sw)
		{
			ExternLib.LibCriWare.criAtomExPlayback_Pause(id, sw);
		}
		#endif

		// // RVA: 0x28A1E18 Offset: 0x28A1E18 VA: 0x28A1E18
		#if UNITY_ANDROID
		private static extern void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode) { }
		#else
		private static void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode)
		{
			ExternLib.LibCriWare.criAtomExPlayback_Resume(id, mode);
		}
		#endif

		// // RVA: 0x28A1F40 Offset: 0x28A1F40 VA: 0x28A1F40
		// private static extern bool criAtomExPlayback_IsPaused(uint id) { }

		// // RVA: 0x28A2128 Offset: 0x28A2128 VA: 0x28A2128
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern Status criAtomExPlayback_GetStatus(uint id);
		#else
		private static CriAtomExPlayback.Status criAtomExPlayback_GetStatus(uint id)
		{
			return ExternLib.LibCriWare.criAtomExPlayback_GetStatus(id);
		}
		#endif

		// // RVA: 0x28A2030 Offset: 0x28A2030 VA: 0x28A2030
		// private static extern bool criAtomExPlayback_GetFormatInfo(uint id, out CriAtomEx.FormatInfo info) { }

		// // RVA: 0x28A2210 Offset: 0x28A2210 VA: 0x28A2210
		// private static extern long criAtomExPlayback_GetTime(uint id) { }

		// // RVA: 0x28A2330 Offset: 0x28A2330 VA: 0x28A2330
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern long criAtomExPlayback_GetTimeSyncedWithAudio(uint id);
		#else
		private static long criAtomExPlayback_GetTimeSyncedWithAudio(uint id)
		{
			return ExternLib.LibCriWare.criAtomExPlayback_GetTimeSyncedWithAudio(id);
		}
		#endif

		// // RVA: 0x28A2428 Offset: 0x28A2428 VA: 0x28A2428
		// private static extern bool criAtomExPlayback_GetNumPlayedSamples(uint id, out long num_samples, out int sampling_rate) { }

		// // RVA: 0x28A2530 Offset: 0x28A2530 VA: 0x28A2530
		// private static extern long criAtomExPlayback_GetSequencePosition(uint id) { }

		// // RVA: 0x28A2910 Offset: 0x28A2910 VA: 0x28A2910
		// private static extern void criAtomExPlayback_SetNextBlockIndex(uint id, int index) { }

		// // RVA: 0x28A2620 Offset: 0x28A2620 VA: 0x28A2620
		// private static extern int criAtomExPlayback_GetCurrentBlockIndex(uint id) { }

		// // RVA: 0x28A2710 Offset: 0x28A2710 VA: 0x28A2710
		// private static extern bool criAtomExPlayback_GetPlaybackTrackInfo(uint id, out CriAtomExPlayback.TrackInfo info) { }

		// // RVA: 0x28A2810 Offset: 0x28A2810 VA: 0x28A2810
		// private static extern bool criAtomExPlayback_GetBeatSyncInfo(uint id, out CriAtomExBeatSync.Info info) { }
	}
}
