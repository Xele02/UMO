using System;
using System.Runtime.InteropServices;

namespace CriWare
{
	public class CriAtomExPlayer : CriDisposable
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		/*private*/public struct Config {
			public CriAtomEx.VoiceAllocationMethod voiceAllocationMethod; // 0x0
			public int maxPathStrings; // 0x4
			public int maxPath; // 0x8
			public int maxAisacs; // 0xC
			public bool updatesTime; // 0x10
			public bool enableAudioSyncedTimer; // 0x11
			#if !UNITY_ANDROID
			public CriAtomSource source;
			#endif
		}

		public enum Status
		{
			Stop = 0,
			Prep = 1,
			Playing = 2,
			PlayEnd = 3,
			Error = 4,
		}

		// [CompilerGeneratedAttribute] // RVA: 0x634A04 Offset: 0x634A04 VA: 0x634A04
		private event CriAtomExBeatSync.CbFunc _onBeatSyncCallback = null; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x634A14 Offset: 0x634A14 VA: 0x634A14
		// private CriAtomExSequencer.EventCallback _onSequenceCallback; // 0x1C
		private bool hasExistingNativeHandle; // 0x20
		private IntPtr entryPoolHandle; // 0x24
		private int _entryPoolCapacity; // 0x28
		private int max_path; // 0x2C
		private IntPtr handle; // 0x30

		public IntPtr nativeHandle { get {return this.handle;} } // 0x289FA10
		public bool isAvailable {get {return this.handle != IntPtr.Zero;} } // 0x289F9AC
		// public int entryPoolCapacity { get; } // 0x28A51E4

		// [CompilerGeneratedAttribute] // RVA: 0x635F28 Offset: 0x635F28 VA: 0x635F28
		// // RVA: 0x28A30AC Offset: 0x28A30AC VA: 0x28A30AC
		// private void add__onBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x635F38 Offset: 0x635F38 VA: 0x635F38
		// // RVA: 0x28A31B8 Offset: 0x28A31B8 VA: 0x28A31B8
		// private void remove__onBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

		// // RVA: 0x28A32C4 Offset: 0x28A32C4 VA: 0x28A32C4
		// public void add_OnBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

		// // RVA: 0x28A339C Offset: 0x28A339C VA: 0x28A339C
		// public void remove_OnBeatSyncCallback(CriAtomExBeatSync.CbFunc value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x635F48 Offset: 0x635F48 VA: 0x635F48
		// // RVA: 0x28A3474 Offset: 0x28A3474 VA: 0x28A3474
		// private void add__onSequenceCallback(CriAtomExSequencer.EventCallback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x635F58 Offset: 0x635F58 VA: 0x635F58
		// // RVA: 0x28A3580 Offset: 0x28A3580 VA: 0x28A3580
		// private void remove__onSequenceCallback(CriAtomExSequencer.EventCallback value) { }

		// // RVA: 0x28A368C Offset: 0x28A368C VA: 0x28A368C
		// public void add_OnSequenceCallback(CriAtomExSequencer.EventCallback value) { }

		// // RVA: 0x28A37C4 Offset: 0x28A37C4 VA: 0x28A37C4
		// public void remove_OnSequenceCallback(CriAtomExSequencer.EventCallback value) { }

		// // RVA: 0x28A38E8 Offset: 0x28A38E8 VA: 0x28A38E8
		public CriAtomExPlayer() : this(null, 0, 0, false, IntPtr.Zero)
		{
			return;
		}
		public CriAtomExPlayer(CriAtomSource source) : this(source, 0, 0, false, IntPtr.Zero)
		{
			return;
		}

		// // RVA: 0x28A3B08 Offset: 0x28A3B08 VA: 0x28A3B08
		public CriAtomExPlayer(CriAtomSource source, int maxPath, int maxPathStrings) : this(source, maxPath, maxPathStrings, false, IntPtr.Zero)
		{
			return;
		}

		// // RVA: 0x28A3B80 Offset: 0x28A3B80 VA: 0x28A3B80
		public CriAtomExPlayer(CriAtomSource source, bool enableAudioSyncedTimer) : this(source, 0, 0, enableAudioSyncedTimer, IntPtr.Zero)
		{
			return;
		}

		// // RVA: 0x28A3BF4 Offset: 0x28A3BF4 VA: 0x28A3BF4
		public CriAtomExPlayer(CriAtomSource source, int maxPath, int maxPathStrings, bool enableAudioSyncedTimer)
			 : this(source, maxPath, maxPathStrings, enableAudioSyncedTimer, IntPtr.Zero)
		{
			return;
		}

		// // RVA: 0x28A3C70 Offset: 0x28A3C70 VA: 0x28A3C70
		public CriAtomExPlayer(CriAtomSource source, IntPtr existingNativeHandle) : this(source, 0, 0, false, existingNativeHandle)
		{
			return;
		}

		// // RVA: 0x28A3958 Offset: 0x28A3958 VA: 0x28A3958
		public CriAtomExPlayer(CriAtomSource source, int maxPath, int maxPathStrings, bool enableAudioSyncedTimer, IntPtr existingNativeHandle)
		{
			if (!CriAtomPlugin.IsLibraryInitialized()) {
				throw new Exception("CriAtomPlugin is not initialized.");
			}

			Config config;
			config.voiceAllocationMethod = CriAtomEx.VoiceAllocationMethod.Once;
			config.maxPath = maxPath;
			config.maxPathStrings = maxPathStrings;
			config.enableAudioSyncedTimer = enableAudioSyncedTimer;
			#if !UNITY_ANDROID
			config.source = source;
			#endif
			
			config.maxAisacs = 8;
			config.updatesTime = true;

			hasExistingNativeHandle = (existingNativeHandle != IntPtr.Zero);
			if (hasExistingNativeHandle) {
				this.handle = existingNativeHandle;
			} else {
				this.handle = criAtomExPlayer_Create(ref config, IntPtr.Zero, 0);
				this.max_path = config.maxPath;
			}

			CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		}

		// // RVA: 0x28A3E0C Offset: 0x28A3E0C VA: 0x28A3E0C Slot: 5
		public override void Dispose()
		{
			CriDisposableObjectManager.Unregister(this);
			if (this.entryPoolHandle != IntPtr.Zero) {
				this.StopWithoutReleaseTime();
				CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy(this.entryPoolHandle);
			}
			this.entryPoolHandle = IntPtr.Zero;
			this._entryPoolCapacity = 0;
			if (hasExistingNativeHandle == false && isAvailable) {
				criAtomExPlayer_Destroy(this.handle);
			}
			if (_onBeatSyncCallback != null) {
				_onBeatSyncCallback = null;
				CriAtom.OnBeatSyncCallback -= OnBeatSyncCallbackChainInternal;
			}
			this.handle = IntPtr.Zero;
			GC.SuppressFinalize(this);
		}

		// // RVA: 0x28A41C4 Offset: 0x28A41C4 VA: 0x28A41C4
		public void SetCue(CriAtomExAcb acb, string name)
		{
			criAtomExPlayer_SetCueName(this.handle,
				(acb != null) ? acb.nativeHandle : IntPtr.Zero, name);
		}

		// // RVA: 0x28A4350 Offset: 0x28A4350 VA: 0x28A4350
		public void SetCue(CriAtomExAcb acb, int id)
		{
			criAtomExPlayer_SetCueId(this.handle,
				(acb != null) ? acb.nativeHandle : IntPtr.Zero, id);
		}

		// // RVA: 0x28A4500 Offset: 0x28A4500 VA: 0x28A4500
		// public void SetCueIndex(CriAtomExAcb acb, int index) { }

		// // RVA: 0x28A4674 Offset: 0x28A4674 VA: 0x28A4674
		// public void SetContentId(CriFsBinder binder, int contentId) { }

		// // RVA: 0x28A47E8 Offset: 0x28A47E8 VA: 0x28A47E8
		// public void SetFile(CriFsBinder binder, string path) { }

		// // RVA: 0x28A49B0 Offset: 0x28A49B0 VA: 0x28A49B0
		// public void SetData(byte[] buffer, int size) { }

		// // RVA: 0x28A4A9C Offset: 0x28A4A9C VA: 0x28A4A9C
		// public void SetData(IntPtr buffer, int size) { }

		// // RVA: 0x28A4B84 Offset: 0x28A4B84 VA: 0x28A4B84
		// public void SetFormat(CriAtomEx.Format format) { }

		// // RVA: 0x28A4CB0 Offset: 0x28A4CB0 VA: 0x28A4CB0
		// public void SetNumChannels(int numChannels) { }

		// // RVA: 0x28A4DA0 Offset: 0x28A4DA0 VA: 0x28A4DA0
		// public void SetSamplingRate(int samplingRate) { }

		// // RVA: 0x28A4E90 Offset: 0x28A4E90 VA: 0x28A4E90
		// public void PrepareEntryPool(int capacity, bool stopOnEmpty) { }

		// // RVA: 0x28A506C Offset: 0x28A506C VA: 0x28A506C
		// public int GetNumEntries() { }

		// // RVA: 0x28A51EC Offset: 0x28A51EC VA: 0x28A51EC
		// public bool EntryFile(CriFsBinder binder, string path, bool repeat) { }

		// // RVA: 0x28A5400 Offset: 0x28A5400 VA: 0x28A5400
		// public bool EntryContentId(CriFsBinder binder, int contentId, bool repeat) { }

		// // RVA: 0x28A55DC Offset: 0x28A55DC VA: 0x28A55DC
		// public bool EntryData(byte[] buffer, int size, bool repeat) { }

		// // RVA: 0x28A576C Offset: 0x28A576C VA: 0x28A576C
		// public bool EntryData(IntPtr buffer, int size, bool repeat) { }

		// // RVA: 0x28A58F4 Offset: 0x28A58F4 VA: 0x28A58F4
		// public bool EntryCue(CriAtomExAcb acb, string name, bool repeat) { }

		// // RVA: 0x28A5AF8 Offset: 0x28A5AF8 VA: 0x28A5AF8
		public CriAtomExPlayback Start()
		{
			return new CriAtomExPlayback(criAtomExPlayer_Start(this.handle));
		}

		// // RVA: 0x28A5C10 Offset: 0x28A5C10 VA: 0x28A5C10
		// public CriAtomExPlayback Prepare() { }

		// // RVA: 0x28A5D2C Offset: 0x28A5D2C VA: 0x28A5D2C
		public void Stop(bool ignoresReleaseTime)
		{
			if (!this.isAvailable) {
				return;
			}

			if (ignoresReleaseTime == false) {
				criAtomExPlayer_Stop(this.handle);
			} else {
				criAtomExPlayer_StopWithoutReleaseTime(this.handle);
			}
			if (this.entryPoolHandle != IntPtr.Zero) {
				CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(this.entryPoolHandle);
			}
		}

		// // RVA: 0x28A60C4 Offset: 0x28A60C4 VA: 0x28A60C4
		public void Pause()
		{
			criAtomExPlayer_Pause(this.handle, true);
		}

		// // RVA: 0x28A61E8 Offset: 0x28A61E8 VA: 0x28A61E8
		public void Resume(CriAtomEx.ResumeMode mode)
		{
			criAtomExPlayer_Resume(this.handle, mode);
		}

		// // RVA: 0x28A630C Offset: 0x28A630C VA: 0x28A630C
		public bool IsPaused()
		{
			return criAtomExPlayer_IsPaused(this.handle);
		}

		// // RVA: 0x28A6438 Offset: 0x28A6438 VA: 0x28A6438
		public void SetVolume(float volume)
		{
			criAtomExPlayer_SetVolume(this.handle, volume);
		}

		// // RVA: 0x28A6560 Offset: 0x28A6560 VA: 0x28A6560
		public void SetPitch(float pitch)
		{
			criAtomExPlayer_SetPitch(this.handle, pitch);
		}

		// // RVA: 0x28A6688 Offset: 0x28A6688 VA: 0x28A6688
		// public void SetPlaybackRatio(float ratio) { }

		// // RVA: 0x28A677C Offset: 0x28A677C VA: 0x28A677C
		// public void SetPan3dAngle(float angle) { }

		// // RVA: 0x28A6870 Offset: 0x28A6870 VA: 0x28A6870
		// public void SetPan3dInteriorDistance(float distance) { }

		// // RVA: 0x28A696C Offset: 0x28A696C VA: 0x28A696C
		// public void SetPan3dVolume(float volume) { }

		// // RVA: 0x28A6A60 Offset: 0x28A6A60 VA: 0x28A6A60
		public void SetPanType(CriAtomEx.PanType panType)
		{
			criAtomExPlayer_SetPanType(this.handle, panType);
		}

		// // RVA: 0x28A6B4C Offset: 0x28A6B4C VA: 0x28A6B4C
		// public void SetSendLevel(int channel, CriAtomEx.Speaker id, float level) { }

		// // RVA: 0x28A6C60 Offset: 0x28A6C60 VA: 0x28A6C60
		// public void SetBiquadFilterParameters(CriAtomEx.BiquadFilterType type, float frequency, float gain, float q) { }

		// // RVA: 0x28A6D94 Offset: 0x28A6D94 VA: 0x28A6D94
		// public void SetBandpassFilterParameters(float cofLow, float cofHigh) { }

		// // RVA: 0x28A6E9C Offset: 0x28A6E9C VA: 0x28A6E9C
		// public void SetBusSendLevel(string busName, float level) { }

		// // RVA: 0x28A6FBC Offset: 0x28A6FBC VA: 0x28A6FBC
		// public bool GetBusSendLevel(string busName, out float level) { }

		// [ObsoleteAttribute] // RVA: 0x635F68 Offset: 0x635F68 VA: 0x635F68
		// // RVA: 0x28A70EC Offset: 0x28A70EC VA: 0x28A70EC
		// public void SetBusSendLevel(int busId, float level) { }

		// // RVA: 0x28A71E8 Offset: 0x28A71E8 VA: 0x28A71E8
		// public void SetBusSendLevelOffset(string busName, float levelOffset) { }

		// // RVA: 0x28A7308 Offset: 0x28A7308 VA: 0x28A7308
		// public bool GetBusSendLevelOffset(string busName, out float level) { }

		// [ObsoleteAttribute] // RVA: 0x635F9C Offset: 0x635F9C VA: 0x635F9C
		// // RVA: 0x28A7438 Offset: 0x28A7438 VA: 0x28A7438
		// public void SetBusSendLevelOffset(int busId, float levelOffset) { }

		// // RVA: 0x28A7538 Offset: 0x28A7538 VA: 0x28A7538
		// public void AttachAisac(string globalAisacName) { }

		// // RVA: 0x28A7640 Offset: 0x28A7640 VA: 0x28A7640
		// public void DetachAisac(string globalAisacName) { }

		// // RVA: 0x28A7748 Offset: 0x28A7748 VA: 0x28A7748
		// public void SetAisacControl(string controlName, float value) { }

		// [ObsoleteAttribute] // RVA: 0x635FD0 Offset: 0x635FD0 VA: 0x635FD0
		// // RVA: 0x28A7864 Offset: 0x28A7864 VA: 0x28A7864
		// public void SetAisac(string controlName, float value) { }

		// // RVA: 0x28A786C Offset: 0x28A786C VA: 0x28A786C
		// public void SetAisacControl(uint controlId, float value) { }

		// [ObsoleteAttribute] // RVA: 0x636020 Offset: 0x636020 VA: 0x636020
		// // RVA: 0x28A796C Offset: 0x28A796C VA: 0x28A796C
		// public void SetAisac(uint controlId, float value) { }

		// // RVA: 0x28A7978 Offset: 0x28A7978 VA: 0x28A7978
		// public bool GetAttachedAisacInfo(int aisacAttachedIndex, out CriAtomEx.AisacInfo aisacInfo) { }

		// // RVA: 0x28A7CB8 Offset: 0x28A7CB8 VA: 0x28A7CB8
		public void Set3dSource(CriAtomEx3dSource source)
		{
			criAtomExPlayer_Set3dSourceHn(this.handle, (source == null) ? IntPtr.Zero : source.nativeHandle);
		}

		// // RVA: 0x28A7E20 Offset: 0x28A7E20 VA: 0x28A7E20
		public void Set3dListener(CriAtomEx3dListener listener)
		{
			criAtomExPlayer_Set3dListenerHn(this.handle, ((listener == null) ? IntPtr.Zero : listener.nativeHandle));
		}

		// // RVA: 0x28A7F88 Offset: 0x28A7F88 VA: 0x28A7F88
		public void SetStartTime(long startTimeMs)
		{
			criAtomExPlayer_SetStartTime(this.handle, startTimeMs);
		}

		// // RVA: 0x28A8098 Offset: 0x28A8098 VA: 0x28A8098
		// public void SetFirstBlockIndex(int index) { }

		// // RVA: 0x28A818C Offset: 0x28A818C VA: 0x28A818C
		// public void SetSelectorLabel(string selector, string label) { }

		// // RVA: 0x28A82C0 Offset: 0x28A82C0 VA: 0x28A82C0
		// public void UnsetSelectorLabel(string selector, string label) { }

		// // RVA: 0x28A83F0 Offset: 0x28A83F0 VA: 0x28A83F0
		// public void ClearSelectorLabels() { }

		// // RVA: 0x28A84DC Offset: 0x28A84DC VA: 0x28A84DC
		// public void SetCategory(int categoryId) { }

		// // RVA: 0x28A85D0 Offset: 0x28A85D0 VA: 0x28A85D0
		// public void SetCategory(string categoryName) { }

		// // RVA: 0x28A86E0 Offset: 0x28A86E0 VA: 0x28A86E0
		// public void UnsetCategory() { }

		// // RVA: 0x28A87C8 Offset: 0x28A87C8 VA: 0x28A87C8
		// public void SetCuePriority(int priority) { }

		// // RVA: 0x28A88B8 Offset: 0x28A88B8 VA: 0x28A88B8
		// public void SetVoicePriority(int priority) { }

		// // RVA: 0x28A89AC Offset: 0x28A89AC VA: 0x28A89AC
		// public void SetVoiceControlMethod(CriAtomEx.VoiceControlMethod method) { }

		// // RVA: 0x28A8AA8 Offset: 0x28A8AA8 VA: 0x28A8AA8
		// public void SetPreDelayTime(float time) { }

		// // RVA: 0x28A8B98 Offset: 0x28A8B98 VA: 0x28A8B98
		// public void SetEnvelopeAttackTime(float time) { }

		// // RVA: 0x28A8C90 Offset: 0x28A8C90 VA: 0x28A8C90
		// public void SetEnvelopeHoldTime(float time) { }

		// // RVA: 0x28A8D84 Offset: 0x28A8D84 VA: 0x28A8D84
		// public void SetEnvelopeDecayTime(float time) { }

		// // RVA: 0x28A8E80 Offset: 0x28A8E80 VA: 0x28A8E80
		// public void SetEnvelopeReleaseTime(float time) { }

		// // RVA: 0x28A8F78 Offset: 0x28A8F78 VA: 0x28A8F78
		// public void SetEnvelopeSustainLevel(float level) { }

		// // RVA: 0x28A9070 Offset: 0x28A9070 VA: 0x28A9070
		// public void AttachFader() { }

		// // RVA: 0x28A91CC Offset: 0x28A91CC VA: 0x28A91CC
		// public void DetachFader() { }

		// // RVA: 0x28A92B4 Offset: 0x28A92B4 VA: 0x28A92B4
		// public void SetFadeOutTime(int ms) { }

		// // RVA: 0x28A93A8 Offset: 0x28A93A8 VA: 0x28A93A8
		// public void SetFadeInTime(int ms) { }

		// // RVA: 0x28A9498 Offset: 0x28A9498 VA: 0x28A9498
		// public void SetFadeInStartOffset(int ms) { }

		// // RVA: 0x28A9590 Offset: 0x28A9590 VA: 0x28A9590
		// public void SetFadeOutEndDelay(int ms) { }

		// // RVA: 0x28A9684 Offset: 0x28A9684 VA: 0x28A9684
		// public bool IsFading() { }

		// // RVA: 0x28A97B0 Offset: 0x28A97B0 VA: 0x28A97B0
		// public void ResetFaderParameters() { }

		// // RVA: 0x28A98A0 Offset: 0x28A98A0 VA: 0x28A98A0
		// public void SetGroupNumber(int group_no) { }

		// // RVA: 0x28A9990 Offset: 0x28A9990 VA: 0x28A9990
		// public void Update(CriAtomExPlayback playback) { }

		// // RVA: 0x28A9AB4 Offset: 0x28A9AB4 VA: 0x28A9AB4
		public void UpdateAll()
		{
			criAtomExPlayer_UpdateAll(handle);
		}

		// // RVA: 0x28A9BD8 Offset: 0x28A9BD8 VA: 0x28A9BD8
		// public void ResetParameters() { }

		// // RVA: 0x28A9CC0 Offset: 0x28A9CC0 VA: 0x28A9CC0
		// public long GetTime() { }

		// // RVA: 0x289FA08 Offset: 0x289FA08 VA: 0x289FA08
		public CriAtomExPlayer.Status GetStatus()
		{
			return criAtomExPlayer_GetStatus(this.handle);
		}

		// // RVA: 0x28A9EF8 Offset: 0x28A9EF8 VA: 0x28A9EF8
		// public float GetParameterFloat32(CriAtomEx.Parameter id) { }

		// // RVA: 0x28A9FEC Offset: 0x28A9FEC VA: 0x28A9FEC
		// public uint GetParameterUint32(CriAtomEx.Parameter id) { }

		// // RVA: 0x28AA0E4 Offset: 0x28AA0E4 VA: 0x28AA0E4
		// public int GetParameterSint32(CriAtomEx.Parameter id) { }

		// // RVA: 0x28AA1DC Offset: 0x28AA1DC VA: 0x28AA1DC
		public void SetSoundRendererType(CriAtomEx.SoundRendererType type)
		{
			criAtomExPlayer_SetSoundRendererType(this.handle, type);
		}

		// // RVA: 0x28AA2D8 Offset: 0x28AA2D8 VA: 0x28AA2D8
		// public void SetRandomSeed(uint seed) { }

		// // RVA: 0x28AA3C8 Offset: 0x28AA3C8 VA: 0x28AA3C8
		public void Loop(bool sw)
		{
			if (sw)
			{
				criAtomExPlayer_LimitLoopCount(this.handle, -3);
			}else
			{
				ushort CRIATOMPARAMETER2_ID_LOOP_COUNT = CriAtomPlugin.GetLoopCountParameterId();
				IntPtr player_parameter = criAtomExPlayer_GetPlayerParameter(this.handle);
				criAtomExPlayerParameter_RemoveParameter(player_parameter, CRIATOMPARAMETER2_ID_LOOP_COUNT);
			}
		}

		// // RVA: 0x28AA844 Offset: 0x28AA844 VA: 0x28AA844
		// public void SetAsrRackId(int asr_rack_id) { }

		// // RVA: 0x28AA938 Offset: 0x28AA938 VA: 0x28AA938
		// public void SetVoicePoolIdentifier(uint identifier) { }

		// // RVA: 0x28AAA30 Offset: 0x28AAA30 VA: 0x28AAA30
		// public void SetDspTimeStretchRatio(float ratio) { }

		// // RVA: 0x28AAA48 Offset: 0x28AAA48 VA: 0x28AAA48
		// public void SetDspPitchShifterPitch(float pitch) { }

		// // RVA: 0x28AAA40 Offset: 0x28AAA40 VA: 0x28AAA40
		// public void SetDspParameter(int id, float value) { }

		// // RVA: 0x28AAB60 Offset: 0x28AAB60 VA: 0x28AAB60
		// public void SetSequencePrepareTime(uint ms) { }

		// // RVA: 0x28AAC58 Offset: 0x28AAC58 VA: 0x28AAC58
		// public void AttachTween(CriAtomExTween tween) { }

		// // RVA: 0x28AAD74 Offset: 0x28AAD74 VA: 0x28AAD74
		// public void DetachTween(CriAtomExTween tween) { }

		// // RVA: 0x28AAE8C Offset: 0x28AAE8C VA: 0x28AAE8C
		// public void DetachTweenAll() { }

		// // RVA: 0x28AAF78 Offset: 0x28AAF78 VA: 0x28AAF78
		public void Stop()
		{
			if (this.isAvailable) {
				criAtomExPlayer_Stop(this.handle);
				CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(this.entryPoolHandle);
			}
		}

		// // RVA: 0x289FB08 Offset: 0x289FB08 VA: 0x289FB08
		public void StopWithoutReleaseTime()
		{
			if (this.isAvailable) {
				criAtomExPlayer_StopWithoutReleaseTime(this.handle);
				CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(this.entryPoolHandle);
			}
		}

		// // RVA: 0x28AAFA4 Offset: 0x28AAFA4 VA: 0x28AAFA4
		// public void Pause(bool sw) { }

		// // RVA: 0x28AAFAC Offset: 0x28AAFAC VA: 0x28AAFAC Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x28AB020 Offset: 0x28AB020 VA: 0x28AB020
		private void OnBeatSyncCallbackChainInternal(ref CriAtomExBeatSync.Info info)
		{
			if (info.playerHn != this.nativeHandle) {
				return;
			}
			_onBeatSyncCallback(ref info);
		}

		// // RVA: 0x28AB06C Offset: 0x28AB06C VA: 0x28AB06C
		// private void OnSequenceCallbackChainInternal(ref CriAtomExSequencer.CriAtomExSequenceEventInfo info) { }

		// // RVA: 0x28A3C98 Offset: 0x28A3C98 VA: 0x28A3C98
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern IntPtr criAtomExPlayer_Create(ref Config config, IntPtr work, int work_size);
		#else
		private static IntPtr criAtomExPlayer_Create(ref CriAtomExPlayer.Config config, IntPtr work, int work_size)
		{
			return ExternLib.LibCriWare.criAtomExPlayer_Create(ref config, work, work_size);
		}
		#endif

		// // RVA: 0x28A40B0 Offset: 0x28A40B0 VA: 0x28A40B0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Destroy(IntPtr player);
		#else
		private static void criAtomExPlayer_Destroy(IntPtr player)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Destroy(player);
		}
		#endif

		// // RVA: 0x28A43D8 Offset: 0x28A43D8 VA: 0x28A43D8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetCueId(
			IntPtr player, IntPtr acb_hn, int id);
		#else
		private static void criAtomExPlayer_SetCueId(IntPtr player, IntPtr acb_hn, int id)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetCueId(player, acb_hn, id);
		}
		#endif

		// // RVA: 0x28A4248 Offset: 0x28A4248 VA: 0x28A4248
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetCueName(
			IntPtr player, IntPtr acb_hn, string cue_name);
		#else
		private static void criAtomExPlayer_SetCueName(IntPtr player, IntPtr acb_hn, string cue_name)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetCueName(player, acb_hn, cue_name);
		}
		#endif

		// // RVA: 0x28A4588 Offset: 0x28A4588 VA: 0x28A4588
		// private static extern void criAtomExPlayer_SetCueIndex(IntPtr player, IntPtr acb_hn, int index) { }

		// // RVA: 0x28A4870 Offset: 0x28A4870 VA: 0x28A4870
		// private static extern void criAtomExPlayer_SetFile(IntPtr player, IntPtr binder, string path) { }

		// // RVA: 0x28A49B8 Offset: 0x28A49B8 VA: 0x28A49B8
		// private static extern void criAtomExPlayer_SetData(IntPtr player, byte[] buffer, int size) { }

		// // RVA: 0x28A4AA8 Offset: 0x28A4AA8 VA: 0x28A4AA8
		// private static extern void criAtomExPlayer_SetData(IntPtr player, IntPtr buffer, int size) { }

		// // RVA: 0x28A46F8 Offset: 0x28A46F8 VA: 0x28A46F8
		// private static extern void criAtomExPlayer_SetContentId(IntPtr player, IntPtr binder, int id) { }

		// // RVA: 0x28AA940 Offset: 0x28AA940 VA: 0x28AA940
		// private static extern void criAtomExPlayer_SetVoicePoolIdentifier(IntPtr player, uint identifier) { }

		// // RVA: 0x28A5B00 Offset: 0x28A5B00 VA: 0x28A5B00
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern uint criAtomExPlayer_Start(IntPtr player);
		#else
		private static uint criAtomExPlayer_Start(IntPtr player)
		{
			return ExternLib.LibCriWare.criAtomExPlayer_Start(player);
		}
		#endif

		// // RVA: 0x28A5C18 Offset: 0x28A5C18 VA: 0x28A5C18
		// private static extern uint criAtomExPlayer_Prepare(IntPtr player) { }

		// // RVA: 0x28A5DC8 Offset: 0x28A5DC8 VA: 0x28A5DC8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Stop(IntPtr player);
		#else
		private static void criAtomExPlayer_Stop(IntPtr player)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Stop(player);
		}
		#endif

		// // RVA: 0x28A5ED8 Offset: 0x28A5ED8 VA: 0x28A5ED8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player);
		#else
		private static void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player)
		{
			ExternLib.LibCriWare.criAtomExPlayer_StopWithoutReleaseTime(player);
		}
		#endif

		// // RVA: 0x28A60D0 Offset: 0x28A60D0 VA: 0x28A60D0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Pause(IntPtr player, bool sw);
		#else
		private static void criAtomExPlayer_Pause(IntPtr player, bool sw)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Pause(player, sw);
		}
		#endif

		// // RVA: 0x28A61F0 Offset: 0x28A61F0 VA: 0x28A61F0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode);
		#else
		private static void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Resume(player, mode);
		}
		#endif

		// // RVA: 0x28A6318 Offset: 0x28A6318 VA: 0x28A6318
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern bool criAtomExPlayer_IsPaused(IntPtr player);
		#else
		private static bool criAtomExPlayer_IsPaused(IntPtr player)
		{
			return ExternLib.LibCriWare.criAtomExPlayer_IsPaused(player);
		}
		#endif

		// // RVA: 0x28A9DE0 Offset: 0x28A9DE0 VA: 0x28A9DE0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern Status criAtomExPlayer_GetStatus(IntPtr player);
		#else
		private static CriAtomExPlayer.Status criAtomExPlayer_GetStatus(IntPtr player)
		{
			return ExternLib.LibCriWare.criAtomExPlayer_GetStatus(player);
		}
		#endif

		// // RVA: 0x28A9CC8 Offset: 0x28A9CC8 VA: 0x28A9CC8
		// private static extern long criAtomExPlayer_GetTime(IntPtr player) { }

		// // RVA: 0x28A4B90 Offset: 0x28A4B90 VA: 0x28A4B90
		// private static extern void criAtomExPlayer_SetFormat(IntPtr player, CriAtomEx.Format format) { }

		// // RVA: 0x28A4CB8 Offset: 0x28A4CB8 VA: 0x28A4CB8
		// private static extern void criAtomExPlayer_SetNumChannels(IntPtr player, int num_channels) { }

		// // RVA: 0x28A4DA8 Offset: 0x28A4DA8 VA: 0x28A4DA8
		// private static extern void criAtomExPlayer_SetSamplingRate(IntPtr player, int sampling_rate) { }

		// // RVA: 0x28A4F50 Offset: 0x28A4F50 VA: 0x28A4F50
		// private static extern IntPtr CRIWARE22E9B625(IntPtr player, int capacity, int max_path, bool stopOnEmpty) { }

		// // RVA: 0x28A3FA8 Offset: 0x28A3FA8 VA: 0x28A3FA8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE693E0CA2(IntPtr pool);
		#endif
		private static void CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy(IntPtr pool)
		{
			#if UNITY_ANDROID
			CRIWARE693E0CA2(pool);
			#else
			ExternLib.LibCriWare.CRIWARE693E0CA2_criAtomUnityEntryPool_Destroy(pool);
			#endif
		}

		// // RVA: 0x28A50E0 Offset: 0x28A50E0 VA: 0x28A50E0
		// private static extern int CRIWARE9D24E4DD(IntPtr pool) { }

		// // RVA: 0x28A52B0 Offset: 0x28A52B0 VA: 0x28A52B0
		// private static extern bool CRIWAREBDB22DA2(IntPtr pool, IntPtr binder, string path, bool repeat, int max_path) { }

		// // RVA: 0x28A54B8 Offset: 0x28A54B8 VA: 0x28A54B8
		// private static extern bool CRIWARED285FCAF(IntPtr pool, IntPtr binder, int id, bool repeat) { }

		// // RVA: 0x28A5678 Offset: 0x28A5678 VA: 0x28A5678
		// private static extern bool CRIWARE4B47A141(IntPtr pool, byte[] buffer, int size, bool repeat) { }

		// // RVA: 0x28A5808 Offset: 0x28A5808 VA: 0x28A5808
		// private static extern bool CRIWARE4B47A141(IntPtr pool, IntPtr buffer, int size, bool repeat) { }

		// // RVA: 0x28A59B0 Offset: 0x28A59B0 VA: 0x28A59B0
		// private static extern bool CRIWAREB1D71078(IntPtr pool, IntPtr acbhn, string name, bool repeat) { }

		// // RVA: 0x28A5FC0 Offset: 0x28A5FC0 VA: 0x28A5FC0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE0C3ECA83(IntPtr pool);
		#endif
		private static void CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(IntPtr pool)
		{
			#if UNITY_ANDROID
			CRIWARE0C3ECA83(pool);
			#else
			ExternLib.LibCriWare.CRIWARE0C3ECA83_criAtomUnityEntryPool_Clear(pool);
			#endif
		}

		// // RVA: 0x28A7FA8 Offset: 0x28A7FA8 VA: 0x28A7FA8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetStartTime(
			IntPtr player, long start_time_ms);
		#else
		private static void criAtomExPlayer_SetStartTime(IntPtr player, long start_time_ms)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetStartTime(player, start_time_ms);
		}
		#endif

		// // RVA: 0x28AAB68 Offset: 0x28AAB68 VA: 0x28AAB68
		// private static extern void criAtomExPlayer_SetSequencePrepareTime(IntPtr player, uint seq_prep_time_ms) { }

		// // RVA: 0x28AA478 Offset: 0x28AA478 VA: 0x28AA478
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_LimitLoopCount(IntPtr player, int count);
		#else
		private static void criAtomExPlayer_LimitLoopCount(IntPtr player, int count)
		{
			ExternLib.LibCriWare.criAtomExPlayer_LimitLoopCount(player, count);
		}
		#endif

		// // RVA: 0x28A9998 Offset: 0x28A9998 VA: 0x28A9998
		// private static extern void criAtomExPlayer_Update(IntPtr player, uint id) { }

		// // RVA: 0x28A9AC0 Offset: 0x28A9AC0 VA: 0x28A9AC0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_UpdateAll(IntPtr player);
		#else
		private static void criAtomExPlayer_UpdateAll(IntPtr player)
		{
			ExternLib.LibCriWare.criAtomExPlayer_UpdateAll(player);
		}
		#endif

		// // RVA: 0x28A9BE0 Offset: 0x28A9BE0 VA: 0x28A9BE0
		// private static extern void criAtomExPlayer_ResetParameters(IntPtr player) { }

		// // RVA: 0x28A9F00 Offset: 0x28A9F00 VA: 0x28A9F00
		// private static extern float criAtomExPlayer_GetParameterFloat32(IntPtr player, CriAtomEx.Parameter id) { }

		// // RVA: 0x28A9FF8 Offset: 0x28A9FF8 VA: 0x28A9FF8
		// private static extern uint criAtomExPlayer_GetParameterUint32(IntPtr player, CriAtomEx.Parameter id) { }

		// // RVA: 0x28AA0F0 Offset: 0x28AA0F0 VA: 0x28AA0F0
		// private static extern int criAtomExPlayer_GetParameterSint32(IntPtr player, CriAtomEx.Parameter id) { }

		// // RVA: 0x28AA668 Offset: 0x28AA668 VA: 0x28AA668
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player);
		#else
		private static IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player)
		{
			return ExternLib.LibCriWare.criAtomExPlayer_GetPlayerParameter(player);
		}
		#endif

		// // RVA: 0x28AA750 Offset: 0x28AA750 VA: 0x28AA750
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, System.UInt16 id);
		#else
		private static void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, ushort id)
		{
			ExternLib.LibCriWare.criAtomExPlayerParameter_RemoveParameter(player_parameter, id);
		}
		#endif

		// // RVA: 0x28A6440 Offset: 0x28A6440 VA: 0x28A6440
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetVolume(IntPtr player, float volume);
		#else
		private static void criAtomExPlayer_SetVolume(IntPtr player, float volume)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetVolume(player, volume);
		}
		#endif

		// // RVA: 0x28A6568 Offset: 0x28A6568 VA: 0x28A6568
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetPitch(IntPtr player, float pitch);
		#else
		private static void criAtomExPlayer_SetPitch(IntPtr player, float pitch)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetPitch(player, pitch);
		}
		#endif

		// // RVA: 0x28A6690 Offset: 0x28A6690 VA: 0x28A6690
		// private static extern void criAtomExPlayer_SetPlaybackRatio(IntPtr player, float playback_ratio) { }

		// // RVA: 0x28A6788 Offset: 0x28A6788 VA: 0x28A6788
		// private static extern void criAtomExPlayer_SetPan3dAngle(IntPtr player, float pan3d_angle) { }

		// // RVA: 0x28A6878 Offset: 0x28A6878 VA: 0x28A6878
		// private static extern void criAtomExPlayer_SetPan3dInteriorDistance(IntPtr player, float pan3d_interior_distance) { }

		// // RVA: 0x28A6978 Offset: 0x28A6978 VA: 0x28A6978
		// private static extern void criAtomExPlayer_SetPan3dVolume(IntPtr player, float pan3d_volume) { }

		// // RVA: 0x28A6A68 Offset: 0x28A6A68 VA: 0x28A6A68
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType);
		#else
		private static void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType)
		{
			ExternLib.LibCriWare.criAtomExPlayer_SetPanType(player, panType);
		}
		#endif

		// // RVA: 0x28A6B68 Offset: 0x28A6B68 VA: 0x28A6B68
		// private static extern void criAtomExPlayer_SetSendLevel(IntPtr player, int channel, CriAtomEx.Speaker id, float level) { }

		// // RVA: 0x28A70F8 Offset: 0x28A70F8 VA: 0x28A70F8
		// private static extern void criAtomExPlayer_SetBusSendLevel(IntPtr player, int bus_id, float level) { }

		// // RVA: 0x28A6EA8 Offset: 0x28A6EA8 VA: 0x28A6EA8
		// private static extern void criAtomExPlayer_SetBusSendLevelByName(IntPtr player, string bus_name, float level) { }

		// // RVA: 0x28A6FC8 Offset: 0x28A6FC8 VA: 0x28A6FC8
		// private static extern bool criAtomExPlayer_GetBusSendLevelByName(IntPtr player, string bus_name, out float level) { }

		// // RVA: 0x28A7440 Offset: 0x28A7440 VA: 0x28A7440
		// private static extern void criAtomExPlayer_SetBusSendLevelOffset(IntPtr player, int bus_id, float level_offset) { }

		// // RVA: 0x28A71F0 Offset: 0x28A71F0 VA: 0x28A71F0
		// private static extern void criAtomExPlayer_SetBusSendLevelOffsetByName(IntPtr player, string bus_name, float level_offset) { }

		// // RVA: 0x28A7310 Offset: 0x28A7310 VA: 0x28A7310
		// private static extern bool criAtomExPlayer_GetBusSendLevelOffsetByName(IntPtr player, string bus_name, out float level_offset) { }

		// // RVA: 0x28A6DA0 Offset: 0x28A6DA0 VA: 0x28A6DA0
		// private static extern void criAtomExPlayer_SetBandpassFilterParameters(IntPtr player, float cof_low, float cof_high) { }

		// // RVA: 0x28A6C88 Offset: 0x28A6C88 VA: 0x28A6C88
		// private static extern void criAtomExPlayer_SetBiquadFilterParameters(IntPtr player, CriAtomEx.BiquadFilterType type, float frequency, float gain, float q) { }

		// // RVA: 0x28A88C0 Offset: 0x28A88C0 VA: 0x28A88C0
		// private static extern void criAtomExPlayer_SetVoicePriority(IntPtr player, int priority) { }

		// // RVA: 0x28A89B8 Offset: 0x28A89B8 VA: 0x28A89B8
		// private static extern void criAtomExPlayer_SetVoiceControlMethod(IntPtr player, CriAtomEx.VoiceControlMethod method) { }

		// // RVA: 0x28A7878 Offset: 0x28A7878 VA: 0x28A7878
		// private static extern void criAtomExPlayer_SetAisacControlById(IntPtr player, ushort control_id, float control_value) { }

		// // RVA: 0x28A7750 Offset: 0x28A7750 VA: 0x28A7750
		// private static extern void criAtomExPlayer_SetAisacControlByName(IntPtr player, string control_name, float control_value) { }

		// // RVA: 0x28A7D38 Offset: 0x28A7D38 VA: 0x28A7D38
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Set3dSourceHn(
			IntPtr player, IntPtr source);
		#else
		private static void criAtomExPlayer_Set3dSourceHn(IntPtr player, IntPtr source)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Set3dSourceHn(player, source);
		}
		#endif

		// // RVA: 0x28A7EA0 Offset: 0x28A7EA0 VA: 0x28A7EA0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_Set3dListenerHn(
			IntPtr player, IntPtr listener);
		#else
		private static void criAtomExPlayer_Set3dListenerHn(IntPtr player, IntPtr listener)
		{
			ExternLib.LibCriWare.criAtomExPlayer_Set3dListenerHn(player, listener);
		}
		#endif

		// // RVA: 0x28A84E8 Offset: 0x28A84E8 VA: 0x28A84E8
		// private static extern void criAtomExPlayer_SetCategoryById(IntPtr player, uint category_id) { }

		// // RVA: 0x28A85D8 Offset: 0x28A85D8 VA: 0x28A85D8
		// private static extern void criAtomExPlayer_SetCategoryByName(IntPtr player, string category_name) { }

		// // RVA: 0x28A86E8 Offset: 0x28A86E8 VA: 0x28A86E8
		// private static extern void criAtomExPlayer_UnsetCategory(IntPtr player) { }

		// // RVA: 0x28A87D0 Offset: 0x28A87D0 VA: 0x28A87D0
		// private static extern void criAtomExPlayer_SetCuePriority(IntPtr player, int cue_priority) { }

		// // RVA: 0x28A8AB0 Offset: 0x28A8AB0 VA: 0x28A8AB0
		// private static extern void criAtomExPlayer_SetPreDelayTime(IntPtr player, float predelay_time_ms) { }

		// // RVA: 0x28A8BA0 Offset: 0x28A8BA0 VA: 0x28A8BA0
		// private static extern void criAtomExPlayer_SetEnvelopeAttackTime(IntPtr player, float attack_time_ms) { }

		// // RVA: 0x28A8C98 Offset: 0x28A8C98 VA: 0x28A8C98
		// private static extern void criAtomExPlayer_SetEnvelopeHoldTime(IntPtr player, float hold_time_ms) { }

		// // RVA: 0x28A8D90 Offset: 0x28A8D90 VA: 0x28A8D90
		// private static extern void criAtomExPlayer_SetEnvelopeDecayTime(IntPtr player, float decay_time_ms) { }

		// // RVA: 0x28A8E88 Offset: 0x28A8E88 VA: 0x28A8E88
		// private static extern void criAtomExPlayer_SetEnvelopeReleaseTime(IntPtr player, float release_time_ms) { }

		// // RVA: 0x28A8F80 Offset: 0x28A8F80 VA: 0x28A8F80
		// private static extern void criAtomExPlayer_SetEnvelopeSustainLevel(IntPtr player, float susutain_level) { }

		// // RVA: 0x28A90D8 Offset: 0x28A90D8 VA: 0x28A90D8
		// private static extern void criAtomExPlayer_AttachFader(IntPtr player, IntPtr config, IntPtr work, int work_size) { }

		// // RVA: 0x28A7540 Offset: 0x28A7540 VA: 0x28A7540
		// private static extern void criAtomExPlayer_AttachAisac(IntPtr player, string globalAisacName) { }

		// // RVA: 0x28A7648 Offset: 0x28A7648 VA: 0x28A7648
		// private static extern void criAtomExPlayer_DetachAisac(IntPtr player, string globalAisacName) { }

		// // RVA: 0x28A91D8 Offset: 0x28A91D8 VA: 0x28A91D8
		// private static extern void criAtomExPlayer_DetachFader(IntPtr player) { }

		// // RVA: 0x28A92C0 Offset: 0x28A92C0 VA: 0x28A92C0
		// private static extern void criAtomExPlayer_SetFadeOutTime(IntPtr player, int ms) { }

		// // RVA: 0x28A93B0 Offset: 0x28A93B0 VA: 0x28A93B0
		// private static extern void criAtomExPlayer_SetFadeInTime(IntPtr player, int ms) { }

		// // RVA: 0x28A94A0 Offset: 0x28A94A0 VA: 0x28A94A0
		// private static extern void criAtomExPlayer_SetFadeInStartOffset(IntPtr player, int ms) { }

		// // RVA: 0x28A9598 Offset: 0x28A9598 VA: 0x28A9598
		// private static extern void criAtomExPlayer_SetFadeOutEndDelay(IntPtr player, int ms) { }

		// // RVA: 0x28A9690 Offset: 0x28A9690 VA: 0x28A9690
		// private static extern bool criAtomExPlayer_IsFading(IntPtr player) { }

		// // RVA: 0x28A97B8 Offset: 0x28A97B8 VA: 0x28A97B8
		// private static extern void criAtomExPlayer_ResetFaderParameters(IntPtr player) { }

		// // RVA: 0x28A98A8 Offset: 0x28A98A8 VA: 0x28A98A8
		// private static extern void criAtomExPlayer_SetGroupNumber(IntPtr player, int group_no) { }

		// // RVA: 0x28A7BB8 Offset: 0x28A7BB8 VA: 0x28A7BB8
		// private static extern bool criAtomExPlayer_GetAttachedAisacInfo(IntPtr player, int aisac_attached_index, IntPtr aisac_info) { }

		// // RVA: 0x28A80A0 Offset: 0x28A80A0 VA: 0x28A80A0
		// private static extern void criAtomExPlayer_SetFirstBlockIndex(IntPtr player, int index) { }

		// // RVA: 0x28A8198 Offset: 0x28A8198 VA: 0x28A8198
		// private static extern void criAtomExPlayer_SetSelectorLabel(IntPtr player, string selector, string label) { }

		// // RVA: 0x28A82C8 Offset: 0x28A82C8 VA: 0x28A82C8
		// private static extern void criAtomExPlayer_UnsetSelectorLabel(IntPtr player, string selector, string label) { }

		// // RVA: 0x28A83F8 Offset: 0x28A83F8 VA: 0x28A83F8
		// private static extern void criAtomExPlayer_ClearSelectorLabels(IntPtr player) { }

		// // RVA: 0x28AA1E8 Offset: 0x28AA1E8 VA: 0x28AA1E8
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criAtomExPlayer_SetSoundRendererType(IntPtr player, CriAtomEx.SoundRendererType type);
		#else
		private static void criAtomExPlayer_SetSoundRendererType(IntPtr player, CriAtomEx.SoundRendererType type)
		{
			
		}
		#endif

		// // RVA: 0x28AA2E0 Offset: 0x28AA2E0 VA: 0x28AA2E0
		// private static extern void criAtomExPlayer_SetRandomSeed(IntPtr player, uint seed) { }

		// // RVA: 0x28AB520 Offset: 0x28AB520 VA: 0x28AB520
		// private static extern void CRIWARE80A6337D(IntPtr player, bool sw) { }

		// // RVA: 0x28AA850 Offset: 0x28AA850 VA: 0x28AA850
		// private static extern void criAtomExPlayer_SetAsrRackId(IntPtr player, int asr_rack_id) { }

		// // RVA: 0x28AAA70 Offset: 0x28AAA70 VA: 0x28AAA70
		// private static extern void criAtomExPlayer_SetDspParameter(IntPtr player, int id, float value) { }

		// // RVA: 0x28AAC90 Offset: 0x28AAC90 VA: 0x28AAC90
		// private static extern void criAtomExPlayer_AttachTween(IntPtr player, IntPtr tween) { }

		// // RVA: 0x28AADA8 Offset: 0x28AADA8 VA: 0x28AADA8
		// private static extern void criAtomExPlayer_DetachTween(IntPtr player, IntPtr tween) { }

		// // RVA: 0x28AAE98 Offset: 0x28AAE98 VA: 0x28AAE98
		// private static extern void criAtomExPlayer_DetachTweenAll(IntPtr player) { }
	}
}
