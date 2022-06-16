namespace CriMana
{
	public class Player : CriDisposable
	{
		// private const int InvalidPlayerId = -1;
		// private static Player updatingPlayer; // 0x0
		// private int playerId; // 0x18
		// private bool isDisposed; // 0x1C
		// private Player.Status internalrequiredStatus; // 0x20
		// private Player.Status _nativeStatus; // 0x24
		// private Nullable<Player.Status> lastNativeStatus; // 0x28
		// private Nullable<Player.Status> lastPlayerStatus; // 0x30
		// private bool wasStopping; // 0x38
		// private bool isPreparingForRendering; // 0x39
		// private bool isNativeStartInvoked; // 0x3A
		// private bool isNativeInitialized; // 0x3B
		// private RendererResource rendererResource; // 0x3C
		// private MovieInfo _movieInfo; // 0x40
		// private FrameInfo _frameInfo; // 0x44
		// private bool isMovieInfoAvailable; // 0x48
		// private bool isFrameInfoAvailable; // 0x49
		// private Player.ShaderDispatchCallback _shaderDispatchCallback; // 0x4C
		// private bool enableSubtitle; // 0x50
		// private int subtitleBufferSize; // 0x54
		// private uint droppedFrameCount; // 0x58
		// private CriAtomExPlayer _atomExPlayer; // 0x5C
		// private CriAtomEx3dSource _atomEx3Dsource; // 0x60
		// private Player.TimerType _timerType; // 0x64
		// private bool isStoppingForSeek; // 0x68
		// public Player.CuePointCallback cuePointCallback; // 0x6C
		// public Player.StatusChangeCallback statusChangeCallback; // 0x70
		// [CompilerGeneratedAttribute] // RVA: 0x635294 Offset: 0x635294 VA: 0x635294
		// private Player.SubtitleChangeCallback OnSubtitleChanged; // 0x74

		// internal Player.Status nativeStatus { get; } 0x2957404
		// private Player.Status requiredStatus { get; set; } 0x295740C 0x2957414
		// public bool additiveMode { get; set; } // 0x78
		// public int maxFrameDrop { get; set; } // 0x7C
		// public bool applyTargetAlpha { get; set; } // 0x80
		// public bool uiRenderMode { get; set; } // 0x81
		// public bool isFrameAvailable { get; } 0x29577DC
		// public MovieInfo movieInfo { get; } 0x29577E4
		// public FrameInfo frameInfo { get; } 0x29577F8
		// public Player.Status status { get; } 0x295780C
		// public int numberOfEntries { get; } 0x29578A0
		// public IntPtr subtitleBuffer { get; private set; } // 0x84
		// public int subtitleSize { get; private set; } // 0x88
		// public CriAtomExPlayer atomExPlayer { get; } 0x2957A4C
		// public CriAtomEx3dSource atomEx3DsourceForAmbisonics { get; } 0x2957A54
		// public Player.TimerType timerType { get; } 0x2957A5C
		// public CriManaMoviePlayerHolder playerHolder { get; set; } // 0x8C
		// public bool isAlive { get; } 0x295E640

		// [CompilerGeneratedAttribute] // RVA: 0x63670C Offset: 0x63670C VA: 0x63670C
		// // RVA: 0x2957584 Offset: 0x2957584 VA: 0x2957584
		// public void add_OnSubtitleChanged(Player.SubtitleChangeCallback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x63671C Offset: 0x63671C VA: 0x63671C
		// // RVA: 0x2957690 Offset: 0x2957690 VA: 0x2957690
		// public void remove_OnSubtitleChanged(Player.SubtitleChangeCallback value) { }

		// // RVA: 0x2957A74 Offset: 0x2957A74 VA: 0x2957A74
		public Player()
		{
			UnityEngine.Debug.LogWarning("TODO CriMana Player");
		}

		// // RVA: 0x2957D9C Offset: 0x2957D9C VA: 0x2957D9C
		// public void .ctor(bool advanced_audio_mode, bool ambisonics_mode, uint max_path_length) { }

		// // RVA: 0x29582BC Offset: 0x29582BC VA: 0x29582BC Slot: 1
		// protected override void Finalize() { }

		// // RVA: 0x29585C0 Offset: 0x29585C0 VA: 0x29585C0 Slot: 5
		public override void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x2958650 Offset: 0x2958650 VA: 0x2958650
		// public void CreateRendererResource(int width, int height, bool alpha) { }

		// // RVA: 0x29590A4 Offset: 0x29590A4 VA: 0x29590A4
		// public void DisposeRendererResource() { }

		// // RVA: 0x29590CC Offset: 0x29590CC VA: 0x29590CC
		// public void Prepare() { }

		// // RVA: 0x29594E4 Offset: 0x29594E4 VA: 0x29594E4
		// public void PrepareForRendering() { }

		// // RVA: 0x29595E8 Offset: 0x29595E8 VA: 0x29595E8
		public void Start()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x2959670 Offset: 0x2959670 VA: 0x2959670
		// public void Stop() { }

		// // RVA: 0x2959850 Offset: 0x2959850 VA: 0x2959850
		// public void StopForSeek() { }

		// // RVA: 0x295953C Offset: 0x295953C VA: 0x295953C
		// public void Pause(bool sw) { }

		// // RVA: 0x2959A8C Offset: 0x2959A8C VA: 0x2959A8C
		// public bool IsPaused() { }

		// // RVA: 0x2959C1C Offset: 0x2959C1C VA: 0x2959C1C
		// public bool SetFile(CriFsBinder binder, string moviePath, Player.SetMode setMode = 0) { }

		// // RVA: 0x295A050 Offset: 0x295A050 VA: 0x295A050
		// public bool SetData(IntPtr data, long dataSize, Player.SetMode setMode = 0) { }

		// [ObsoleteAttribute] // RVA: 0x63680C Offset: 0x63680C VA: 0x63680C
		// // RVA: 0x295A32C Offset: 0x295A32C VA: 0x295A32C
		// public bool SetData(byte[] data, long datasize, Player.SetMode setMode = 0) { }

		// // RVA: 0x295A614 Offset: 0x295A614 VA: 0x295A614
		// public bool SetContentId(CriFsBinder binder, int contentId, Player.SetMode setMode = 0) { }

		// // RVA: 0x295A99C Offset: 0x295A99C VA: 0x295A99C
		// public bool SetFileRange(string filePath, ulong offset, long range, Player.SetMode setMode = 0) { }

		// // RVA: 0x295AD48 Offset: 0x295AD48 VA: 0x295AD48
		// public void Loop(bool sw) { }

		// // RVA: 0x295AEE4 Offset: 0x295AEE4 VA: 0x295AEE4
		// public void SetMasterTimerType(Player.TimerType timerType) { }

		// // RVA: 0x295B084 Offset: 0x295B084 VA: 0x295B084
		// public void SetSeekPosition(int frameNumber) { }

		// // RVA: 0x295B21C Offset: 0x295B21C VA: 0x295B21C
		// public void SetMovieEventSyncMode(Player.MovieEventSyncMode mode) { }

		// // RVA: 0x295B3B4 Offset: 0x295B3B4 VA: 0x295B3B4
		// public void SetSpeed(float speed) { }

		// // RVA: 0x295B54C Offset: 0x295B54C VA: 0x295B54C
		// public void SetMaxPictureDataSize(uint maxDataSize) { }

		// // RVA: 0x295B6E4 Offset: 0x295B6E4 VA: 0x295B6E4
		// public void SetBufferingTime(float sec) { }

		// // RVA: 0x295B87C Offset: 0x295B87C VA: 0x295B87C
		// public void SetMinBufferSize(int min_buffer_size) { }

		// // RVA: 0x295BA14 Offset: 0x295BA14 VA: 0x295BA14
		// public void SetAudioTrack(int track) { }

		// // RVA: 0x295BBAC Offset: 0x295BBAC VA: 0x295BBAC
		// public void SetAudioTrack(Player.AudioTrack track) { }

		// // RVA: 0x295BC88 Offset: 0x295BC88 VA: 0x295BC88
		// public void SetSubAudioTrack(int track) { }

		// // RVA: 0x295BE24 Offset: 0x295BE24 VA: 0x295BE24
		// public void SetSubAudioTrack(Player.AudioTrack track) { }

		// // RVA: 0x295BF00 Offset: 0x295BF00 VA: 0x295BF00
		// public void SetExtraAudioTrack(int track) { }

		// // RVA: 0x295C09C Offset: 0x295C09C VA: 0x295C09C
		// public void SetExtraAudioTrack(Player.AudioTrack track) { }

		// // RVA: 0x295C178 Offset: 0x295C178 VA: 0x295C178
		// public void SetVolume(float volume) { }

		// // RVA: 0x295C314 Offset: 0x295C314 VA: 0x295C314
		// public float GetVolume() { }

		// // RVA: 0x295C49C Offset: 0x295C49C VA: 0x295C49C
		// public void SetSubAudioVolume(float volume) { }

		// // RVA: 0x295C634 Offset: 0x295C634 VA: 0x295C634
		// public float GetSubAudioVolume() { }

		// // RVA: 0x295C7BC Offset: 0x295C7BC VA: 0x295C7BC
		// public void SetExtraAudioVolume(float volume) { }

		// // RVA: 0x295C954 Offset: 0x295C954 VA: 0x295C954
		// public float GetExtraAudioVolume() { }

		// // RVA: 0x295CADC Offset: 0x295CADC VA: 0x295CADC
		// public void SetBusSendLevel(string bus_name, float level) { }

		// // RVA: 0x295CCA0 Offset: 0x295CCA0 VA: 0x295CCA0
		// public void SetSubAudioBusSendLevel(string bus_name, float volume) { }

		// // RVA: 0x295CE68 Offset: 0x295CE68 VA: 0x295CE68
		// public void SetExtraAudioBusSendLevel(string bus_name, float volume) { }

		// // RVA: 0x295D030 Offset: 0x295D030 VA: 0x295D030
		// public void SetSubtitleChannel(int channel) { }

		// // RVA: 0x295D44C Offset: 0x295D44C VA: 0x295D44C
		// public void SetShaderDispatchCallback(Player.ShaderDispatchCallback shaderDispatchCallback) { }

		// // RVA: 0x295D454 Offset: 0x295D454 VA: 0x295D454
		// public long GetTime() { }

		// // RVA: 0x295D5DC Offset: 0x295D5DC VA: 0x295D5DC
		// public int GetDisplayedFrameNo() { }

		// // RVA: 0x295D764 Offset: 0x295D764 VA: 0x295D764
		// public bool HasRenderedNewFrame() { }

		// // RVA: 0x295D784 Offset: 0x295D784 VA: 0x295D784
		// public void SetAsrRackId(int asrRackId) { }

		// // RVA: 0x295D91C Offset: 0x295D91C VA: 0x295D91C
		// public void UpdateWithUserTime(ulong timeCount, ulong timeUnit) { }

		// // RVA: 0x295E0B4 Offset: 0x295E0B4 VA: 0x295E0B4
		// public void SetManualTimerUnit(ulong timeUnitN, ulong timeUnitD) { }

		// // RVA: 0x295E2D4 Offset: 0x295E2D4 VA: 0x295E2D4
		// public void UpdateWithManualTimeAdvanced() { }

		// // RVA: 0x295E4B4 Offset: 0x295E4B4 VA: 0x295E4B4
		public void Update()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x295E4C8 Offset: 0x295E4C8 VA: 0x295E4C8
		// public void OnWillRenderObject(CriManaMovieMaterial sender) { }

		// // RVA: 0x295E5EC Offset: 0x295E5EC VA: 0x295E5EC
		// public bool UpdateMaterial(Material material) { }

		// // RVA: 0x295E510 Offset: 0x295E510 VA: 0x295E510
		// public void IssuePluginEvent(Player.CriManaUnityPlayer_RenderEventAction renderEventAction) { }

		// // RVA: 0x2958324 Offset: 0x2958324 VA: 0x2958324
		// private void Dispose(bool disposing) { }

		// // RVA: 0x295DB44 Offset: 0x295DB44 VA: 0x295DB44
		// private void InternalUpdate() { }

		// [IteratorStateMachineAttribute] // RVA: 0x636864 Offset: 0x636864 VA: 0x636864
		// // RVA: 0x295E834 Offset: 0x295E834 VA: 0x295E834
		// private IEnumerator IssuePluginUpdatesForFrames(int frameCount, MonoBehaviour playerHolder, bool destroy, int playerId) { }

		// // RVA: 0x2959834 Offset: 0x2959834 VA: 0x2959834
		// private void DisableInfos(bool keepFrameInfo = False) { }

		// // RVA: 0x2959118 Offset: 0x2959118 VA: 0x2959118
		// private void PrepareNativePlayer() { }

		// // RVA: 0x2959220 Offset: 0x2959220 VA: 0x2959220
		// private void UpdateNativePlayer() { }

		// // RVA: 0x2957440 Offset: 0x2957440 VA: 0x2957440
		// private void InvokePlayerStatusCheck() { }

		// // RVA: 0x295D108 Offset: 0x295D108 VA: 0x295D108
		// private void AllocateSubtitleBuffer(int size) { }

		// // RVA: 0x295D254 Offset: 0x295D254 VA: 0x295D254
		// private void DeallocateSubtitleBuffer() { }

		// [MonoPInvokeCallbackAttribute] // RVA: 0x6368DC Offset: 0x6368DC VA: 0x6368DC
		// // RVA: 0x29572E4 Offset: 0x29572E4 VA: 0x29572E4
		// private static void CuePointCallbackFromNative(IntPtr ptr1, IntPtr ptr2, in EventPoint eventPoint) { }

		// // RVA: 0x2957CA8 Offset: 0x2957CA8 VA: 0x2957CA8
		// private static extern int CRIWARE4B9FFA91() { }

		// // RVA: 0x2960140 Offset: 0x2960140 VA: 0x2960140
		// private static extern int CRIWAREC904C89F() { }

		// // RVA: 0x29580A8 Offset: 0x29580A8 VA: 0x29580A8
		// private static extern int CRIWARED1C9883A(bool useAtomExPlayer, uint maxPathLength) { }

		// // RVA: 0x295E730 Offset: 0x295E730 VA: 0x295E730
		// private static extern void CRIWARE6536ABE0(int player_id) { }

		// // RVA: 0x2959DD8 Offset: 0x2959DD8 VA: 0x2959DD8
		// private static extern void CRIWARE941BB516(int player_id, IntPtr binder, string path) { }

		// // RVA: 0x295A760 Offset: 0x295A760 VA: 0x295A760
		// private static extern void CRIWARE7BB4D73A(int player_id, IntPtr binder, int content_id) { }

		// // RVA: 0x295AAB0 Offset: 0x295AAB0 VA: 0x295AAB0
		// private static extern void CRIWAREE6A1082E(int player_id, string path, ulong offset, long range) { }

		// // RVA: 0x295A150 Offset: 0x295A150 VA: 0x295A150
		// private static extern void CRIWARE3618D6B1(int player_id, IntPtr data, long datasize) { }

		// // RVA: 0x295A428 Offset: 0x295A428 VA: 0x295A428
		// private static extern void CRIWARE3618D6B1(int player_id, byte[] data, long datasize) { }

		// // RVA: 0x2959F08 Offset: 0x2959F08 VA: 0x2959F08
		// private static extern bool CRIWARE7FE26661(int player_id, IntPtr binder, string path, bool repeat) { }

		// // RVA: 0x295A878 Offset: 0x295A878 VA: 0x295A878
		// private static extern bool CRIWAREA23263A0(int player_id, IntPtr binder, int content_id, bool repeat) { }

		// // RVA: 0x295ABF0 Offset: 0x295ABF0 VA: 0x295ABF0
		// private static extern bool CRIWARE4C3CEFB0(int player_id, string path, ulong offset, long range, bool repeat) { }

		// // RVA: 0x295A238 Offset: 0x295A238 VA: 0x295A238
		// private static extern bool CRIWAREBC6115D8(int player_id, IntPtr data, long datasize, bool repeat) { }

		// // RVA: 0x295A518 Offset: 0x295A518 VA: 0x295A518
		// private static extern bool CRIWAREBC6115D8(int player_id, byte[] data, long datasize, bool repeat) { }

		// // RVA: 0x2960238 Offset: 0x2960238 VA: 0x2960238
		// private static extern void CRIWAREE1C2EB83(int player_id) { }

		// // RVA: 0x2957928 Offset: 0x2957928 VA: 0x2957928
		// private static extern int CRIWARED0DCBD5B(int player_id) { }

		// // RVA: 0x295ECB8 Offset: 0x295ECB8 VA: 0x295ECB8
		// private static extern void CRIWARE044D0246(int player_id, Player.CuePointCallbackFromNativeDelegate cbfunc) { }

		// // RVA: 0x295EA38 Offset: 0x295EA38 VA: 0x295EA38
		// private static extern void CRIWARE4A28D964(int player_id, [Out] MovieInfo movie_info) { }

		// // RVA: 0x295EED8 Offset: 0x295EED8 VA: 0x295EED8
		// private static extern int CRIWAREFE53CA2C(int player_id, IntPtr subtitle_buffer, ref uint subtitle_size) { }

		// // RVA: 0x295EDD0 Offset: 0x295EDD0 VA: 0x295EDD0
		// private static extern void CRIWARECB5086D8(int player_id) { }

		// // RVA: 0x295EB80 Offset: 0x295EB80 VA: 0x295EB80
		// private static extern void CRIWARE3D38F2C2(int player_id) { }

		// // RVA: 0x2959730 Offset: 0x2959730 VA: 0x2959730
		// private static extern void CRIWARE0C381E92(int player_id) { }

		// // RVA: 0x295B110 Offset: 0x295B110 VA: 0x295B110
		// private static extern void CRIWAREC92A5005(int player_id, int seek_frame_no) { }

		// // RVA: 0x295B2A8 Offset: 0x295B2A8 VA: 0x295B2A8
		// private static extern void CRIWARECED1DC1A(int player_id, Player.MovieEventSyncMode mode) { }

		// // RVA: 0x2959980 Offset: 0x2959980 VA: 0x2959980
		// private static extern void CRIWARED22E1E28(int player_id, int sw) { }

		// // RVA: 0x2959B10 Offset: 0x2959B10 VA: 0x2959B10
		// private static extern bool CRIWARE1E2E4671(int player_id) { }

		// // RVA: 0x295ADD8 Offset: 0x295ADD8 VA: 0x295ADD8
		// private static extern void CRIWARE851F97C9(int player_id, int sw) { }

		// // RVA: 0x295D4D8 Offset: 0x295D4D8 VA: 0x295D4D8
		// private static extern long CRIWARE29045DE2(int player_id) { }

		// // RVA: 0x2960340 Offset: 0x2960340 VA: 0x2960340
		// private static extern int CRIWARE3125B8D0(int player_id) { }

		// // RVA: 0x29581B8 Offset: 0x29581B8 VA: 0x29581B8
		// private static extern IntPtr CRIWARE453735B6(int player_id) { }

		// // RVA: 0x295D660 Offset: 0x295D660 VA: 0x295D660
		// private static extern int CRIWAREDA2D5E4D(int player_id) { }

		// // RVA: 0x295BAA0 Offset: 0x295BAA0 VA: 0x295BAA0
		// private static extern void CRIWARE671323A7(int player_id, int track) { }

		// // RVA: 0x295C208 Offset: 0x295C208 VA: 0x295C208
		// private static extern void CRIWARE0B62FCFA(int player_id, float vol) { }

		// // RVA: 0x295C398 Offset: 0x295C398 VA: 0x295C398
		// private static extern float CRIWARE72BA8380(int player_id) { }

		// // RVA: 0x295BD18 Offset: 0x295BD18 VA: 0x295BD18
		// private static extern void CRIWAREC2B76AF1(int player_id, int track) { }

		// // RVA: 0x295C528 Offset: 0x295C528 VA: 0x295C528
		// private static extern void CRIWARE3C47671B(int player_id, float vol) { }

		// // RVA: 0x295C6B8 Offset: 0x295C6B8 VA: 0x295C6B8
		// private static extern float CRIWARE20DEC945(int player_id) { }

		// // RVA: 0x295BF90 Offset: 0x295BF90 VA: 0x295BF90
		// private static extern void CRIWARE86DEE85D(int player_id, int track) { }

		// // RVA: 0x295C848 Offset: 0x295C848 VA: 0x295C848
		// private static extern void CRIWAREFF47FA95(int player_id, float vol) { }

		// // RVA: 0x295C9D8 Offset: 0x295C9D8 VA: 0x295C9D8
		// private static extern float CRIWAREF83F25D9(int player_id) { }

		// // RVA: 0x295CB70 Offset: 0x295CB70 VA: 0x295CB70
		// private static extern void CRIWARE2E7D4F7A(int player_id, string bus_name, float level) { }

		// // RVA: 0x295CD38 Offset: 0x295CD38 VA: 0x295CD38
		// private static extern void CRIWARE5F90D6E8(int player_id, string bus_name, float level) { }

		// // RVA: 0x295CF00 Offset: 0x295CF00 VA: 0x295CF00
		// private static extern void CRIWARE9FC31CDD(int player_id, string bus_name, float level) { }

		// // RVA: 0x295D340 Offset: 0x295D340 VA: 0x295D340
		// private static extern void CRIWARE9ED3F311(int player_id, int channel) { }

		// // RVA: 0x295B440 Offset: 0x295B440 VA: 0x295B440
		// private static extern void CRIWARE83EFC312(int player_id, float speed) { }

		// // RVA: 0x295B5D8 Offset: 0x295B5D8 VA: 0x295B5D8
		// private static extern void CRIWAREC56EBA7C(int player_id, uint max_data_size) { }

		// // RVA: 0x295B770 Offset: 0x295B770 VA: 0x295B770
		// public static extern void CRIWARE050732A5(int player_id, float sec) { }

		// // RVA: 0x295B908 Offset: 0x295B908 VA: 0x295B908
		// public static extern void CRIWARED40EE322(int player_id, int min_buffer_size) { }

		// // RVA: 0x295D810 Offset: 0x295D810 VA: 0x295D810
		// public static extern void CRIWARE7999B5AF(int player_id, int asr_rack_id) { }

		// // RVA: 0x295E930 Offset: 0x295E930 VA: 0x295E930
		// private static extern void CRIWARE55BA8D00(int player_id) { }

		// // RVA: 0x295AF78 Offset: 0x295AF78 VA: 0x295AF78
		// private static extern void CRIWARE31D7EFF8(int player_id, Player.TimerType timer_type) { }

		// // RVA: 0x295DA20 Offset: 0x295DA20 VA: 0x295DA20
		// private static extern void CRIWARE51B54144(int player_id, ulong user_count, ulong user_unit) { }

		// // RVA: 0x295E1B0 Offset: 0x295E1B0 VA: 0x295E1B0
		// private static extern void CRIWARE1E9C6BEC(int player_id, ulong timer_unit_n, ulong timer_unit_d) { }

		// // RVA: 0x295E3B0 Offset: 0x295E3B0 VA: 0x295E3B0
		// private static extern void CRIWAREE4C8241F(int player_id) { }

		// // RVA: 0x295FBD8 Offset: 0x295FBD8 VA: 0x295FBD8
		// private static extern void CRIWARE6AEEBF51(int player_id) { }

		// // RVA: 0x295FAC8 Offset: 0x295FAC8 VA: 0x295FAC8
		// private static extern IntPtr CRIWARE91AA6C29(int player_id, int bufferSize) { }

		// // RVA: 0x295EFF0 Offset: 0x295EFF0 VA: 0x295EFF0
		// private static extern bool CRIWARE6C94B6FB(int player_id) { }

		// // RVA: 0x295F560 Offset: 0x295F560 VA: 0x295F560
		// private static extern void CRIWAREC9D98FAA(int player_id) { }

		// // RVA: 0x295E658 Offset: 0x295E658 VA: 0x295E658
		// private static extern IntPtr criWareUnity_GetRenderEventFunc() { }
	}
}
