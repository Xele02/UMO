using UnityEngine;

//[AddComponentMenu] // RVA: 0x632798 Offset: 0x632798 VA: 0x632798
public class CriAtomSource : CriMonoBehaviour
{
	public enum Status
	{
		Stop = 0,
		Prep = 1,
		Playing = 2,
		PlayEnd = 3,
		Error = 4,
	}

	// [CompilerGeneratedAttribute] // RVA: 0x63469C Offset: 0x63469C VA: 0x63469C
	// private CriAtomExPlayer <player>k__BackingField; // 0x1C
	// [CompilerGeneratedAttribute] // RVA: 0x6346AC Offset: 0x6346AC VA: 0x6346AC
	// private CriAtomEx3dSource <source>k__BackingField; // 0x20
	private bool initialized; // 0x24
	private Vector3 lastPosition; // 0x28
	private bool hasValidPosition; // 0x34
	private CriAtomRegion currentRegion; // 0x38
	private CriAtomListener currentListener; // 0x3C
	[SerializeField]
	private bool _playOnStart; // 0x40
	[SerializeField]
	private string _cueName; // 0x44
	[SerializeField]
	private string _cueSheet; // 0x48
	[SerializeField]
	private CriAtomRegion _regionOnStart; // 0x4C
	[SerializeField]
	private CriAtomListener _listenerOnStart; // 0x50
	[SerializeField]
	private bool _use3dPositioning; // 0x54
	[SerializeField]
	private bool _freezeOrientation; // 0x55
	[SerializeField]
	private bool _loop; // 0x56
	[SerializeField]
	private float _volume; // 0x58
	[SerializeField]
	private float _pitch; // 0x5C
	[SerializeField]
	private bool _androidUseLowLatencyVoicePool; // 0x60
	[SerializeField]
	private bool need_to_player_update_all; // 0x61
	[SerializeField]
	private bool _use3dRandomization; // 0x62
	[SerializeField]
	private uint _randomPositionListMaxLength; // 0x64
	[SerializeField]
	private CriAtomEx.Randomize3dConfig randomize3dConfig; // 0x68

	// Properties
	// public CriAtomExPlayer player { get; set; }
	// public CriAtomEx3dSource source { get; set; }
	protected virtual bool enable_audio_synced_timer { get; set; }
	public bool playOnStart { get; set; }
	public string cueName { get; set; }
	public string cueSheet { get; set; }
	public bool use3dPositioning { get; set; }
	public bool freezeOrientation { get; set; }
	public bool use3dRandomization { get; set; }
	public uint randomPositionListMaxLength { get; set; }
	// public CriAtomRegion region3d { get; set; }
	// public CriAtomListener listener { get; set; }
	// public CriAtomRegion regionOnStart { get; set; }
	// public CriAtomListener listenerOnStart { get; set; }
	public bool loop { get; set; }
	public float volume { get; set; }
	public float pitch { get; set; }
	public float pan3dAngle { get; set; }
	public float pan3dDistance { get; set; }
	public int startTime { get; set; }
	public long time { get; }
	public Status status { get; }
	public bool attenuationDistanceSetting { get; set; }
	public bool androidUseLowLatencyVoicePool { get; set; }

	// Methods

	// [CompilerGeneratedAttribute] // RVA: 0x6358B4 Offset: 0x6358B4 VA: 0x6358B4
	// // RVA: 0x28B55AC Offset: 0x28B55AC VA: 0x28B55AC
	// protected void set_player(CriAtomExPlayer value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6358C4 Offset: 0x6358C4 VA: 0x6358C4
	// // RVA: 0x28B55B4 Offset: 0x28B55B4 VA: 0x28B55B4
	// public CriAtomExPlayer get_player() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6358D4 Offset: 0x6358D4 VA: 0x6358D4
	// // RVA: 0x28B55BC Offset: 0x28B55BC VA: 0x28B55BC
	// protected void set_source(CriAtomEx3dSource value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6358E4 Offset: 0x6358E4 VA: 0x6358E4
	// // RVA: 0x28B55C4 Offset: 0x28B55C4 VA: 0x28B55C4
	// public CriAtomEx3dSource get_source() { }

	// // RVA: 0x28B55CC Offset: 0x28B55CC VA: 0x28B55CC Slot: 8
	// protected virtual bool get_enable_audio_synced_timer() { }

	// // RVA: 0x28B55D4 Offset: 0x28B55D4 VA: 0x28B55D4
	// private void set_enable_audio_synced_timer(bool value) { }

	// // RVA: 0x28B55D8 Offset: 0x28B55D8 VA: 0x28B55D8
	// public bool get_playOnStart() { }

	// // RVA: 0x28B55E0 Offset: 0x28B55E0 VA: 0x28B55E0
	// public void set_playOnStart(bool value) { }

	// // RVA: 0x28B55E8 Offset: 0x28B55E8 VA: 0x28B55E8
	// public string get_cueName() { }

	// // RVA: 0x28B55F0 Offset: 0x28B55F0 VA: 0x28B55F0
	// public void set_cueName(string value) { }

	// // RVA: 0x28B55F8 Offset: 0x28B55F8 VA: 0x28B55F8
	// public string get_cueSheet() { }

	// // RVA: 0x28B5600 Offset: 0x28B5600 VA: 0x28B5600
	// public void set_cueSheet(string value) { }

	// // RVA: 0x28B5608 Offset: 0x28B5608 VA: 0x28B5608
	// public void set_use3dPositioning(bool value) { }

	// // RVA: 0x28B5644 Offset: 0x28B5644 VA: 0x28B5644
	// public bool get_use3dPositioning() { }

	// // RVA: 0x28B5658 Offset: 0x28B5658 VA: 0x28B5658
	// public bool get_freezeOrientation() { }

	// // RVA: 0x28B5660 Offset: 0x28B5660 VA: 0x28B5660
	// public void set_freezeOrientation(bool value) { }

	// // RVA: 0x28B5668 Offset: 0x28B5668 VA: 0x28B5668
	// public void set_use3dRandomization(bool value) { }

	// // RVA: 0x28B5740 Offset: 0x28B5740 VA: 0x28B5740
	// public bool get_use3dRandomization() { }

	// // RVA: 0x28B5748 Offset: 0x28B5748 VA: 0x28B5748
	// public void set_randomPositionListMaxLength(uint value) { }

	// // RVA: 0x28B57F0 Offset: 0x28B57F0 VA: 0x28B57F0
	// public uint get_randomPositionListMaxLength() { }

	// // RVA: 0x28B57F8 Offset: 0x28B57F8 VA: 0x28B57F8
	// public CriAtomRegion get_region3d() { }

	// // RVA: 0x28B5800 Offset: 0x28B5800 VA: 0x28B5800
	// public void set_region3d(CriAtomRegion value) { }

	// // RVA: 0x28B5988 Offset: 0x28B5988 VA: 0x28B5988
	// public CriAtomListener get_listener() { }

	// // RVA: 0x28B5990 Offset: 0x28B5990 VA: 0x28B5990
	// public void set_listener(CriAtomListener value) { }

	// // RVA: 0x28B5AB4 Offset: 0x28B5AB4 VA: 0x28B5AB4
	// public CriAtomRegion get_regionOnStart() { }

	// // RVA: 0x28B5ABC Offset: 0x28B5ABC VA: 0x28B5ABC
	// public void set_regionOnStart(CriAtomRegion value) { }

	// // RVA: 0x28B5AC4 Offset: 0x28B5AC4 VA: 0x28B5AC4
	// public CriAtomListener get_listenerOnStart() { }

	// // RVA: 0x28B5ACC Offset: 0x28B5ACC VA: 0x28B5ACC
	// public void set_listenerOnStart(CriAtomListener value) { }

	// // RVA: 0x28B5AD4 Offset: 0x28B5AD4 VA: 0x28B5AD4
	// public void set_loop(bool value) { }

	// // RVA: 0x28B5ADC Offset: 0x28B5ADC VA: 0x28B5ADC
	// public bool get_loop() { }

	// // RVA: 0x28B5AE4 Offset: 0x28B5AE4 VA: 0x28B5AE4
	// public void set_volume(float value) { }

	// // RVA: 0x28B5B14 Offset: 0x28B5B14 VA: 0x28B5B14
	// public float get_volume() { }

	// // RVA: 0x28B5B1C Offset: 0x28B5B1C VA: 0x28B5B1C
	// public void set_pitch(float value) { }

	// // RVA: 0x28B5B4C Offset: 0x28B5B4C VA: 0x28B5B4C
	// public float get_pitch() { }

	// // RVA: 0x28B5B54 Offset: 0x28B5B54 VA: 0x28B5B54
	// public void set_pan3dAngle(float value) { }

	// // RVA: 0x28B5B80 Offset: 0x28B5B80 VA: 0x28B5B80
	// public float get_pan3dAngle() { }

	// // RVA: 0x28B5B9C Offset: 0x28B5B9C VA: 0x28B5B9C
	// public void set_pan3dDistance(float value) { }

	// // RVA: 0x28B5BC8 Offset: 0x28B5BC8 VA: 0x28B5BC8
	// public float get_pan3dDistance() { }

	// // RVA: 0x28B5BE4 Offset: 0x28B5BE4 VA: 0x28B5BE4
	// public void set_startTime(int value) { }

	// // RVA: 0x28B5C20 Offset: 0x28B5C20 VA: 0x28B5C20
	// public int get_startTime() { }

	// // RVA: 0x28B5C3C Offset: 0x28B5C3C VA: 0x28B5C3C
	// public long get_time() { }

	// // RVA: 0x28B5C58 Offset: 0x28B5C58 VA: 0x28B5C58
	// public CriAtomSource.Status get_status() { }

	// // RVA: 0x28B5C70 Offset: 0x28B5C70 VA: 0x28B5C70
	// public void set_attenuationDistanceSetting(bool value) { }

	// // RVA: 0x28B5CB4 Offset: 0x28B5CB4 VA: 0x28B5CB4
	// public bool get_attenuationDistanceSetting() { }

	// // RVA: 0x28B5CCC Offset: 0x28B5CCC VA: 0x28B5CCC
	// public bool get_androidUseLowLatencyVoicePool() { }

	// // RVA: 0x28B5CD4 Offset: 0x28B5CD4 VA: 0x28B5CD4
	// public void set_androidUseLowLatencyVoicePool(bool value) { }

	// // RVA: 0x28B564C Offset: 0x28B564C VA: 0x28B564C
	// protected void SetNeedToPlayerUpdateAll() { }

	// // RVA: 0x28B5CDC Offset: 0x28B5CDC VA: 0x28B5CDC Slot: 9
	// protected virtual void InternalInitialize() { }

	// // RVA: 0x28B5DCC Offset: 0x28B5DCC VA: 0x28B5DCC Slot: 10
	// protected virtual void InternalFinalize() { }

	// // RVA: 0x28B5EAC Offset: 0x28B5EAC VA: 0x28B5EAC
	// private void Awake() { }

	// // RVA: 0x28B5EBC Offset: 0x28B5EBC VA: 0x28B5EBC Slot: 4
	// protected override void OnEnable() { }

	// // RVA: 0x28B5EF8 Offset: 0x28B5EF8 VA: 0x28B5EF8
	// private void OnDestroy() { }

	// // RVA: 0x28B5F08 Offset: 0x28B5F08 VA: 0x28B5F08
	// protected bool SetInitialSourcePosition() { }

	// // RVA: 0x28B5F9C Offset: 0x28B5F9C VA: 0x28B5F9C Slot: 11
	// protected virtual void SetInitialParameters() { }

	// // RVA: 0x28B60C4 Offset: 0x28B60C4 VA: 0x28B60C4 Slot: 12
	// protected virtual void UpdatePosition() { }

	// // RVA: 0x28B632C Offset: 0x28B632C VA: 0x28B632C
	// private void Start() { }

	// // RVA: 0x28B6490 Offset: 0x28B6490 VA: 0x28B6490 Slot: 6
	// public override void CriInternalUpdate() { }

	// // RVA: 0x28B6494 Offset: 0x28B6494 VA: 0x28B6494 Slot: 7
	// public override void CriInternalLateUpdate() { }

	// // RVA: 0x28B64F4 Offset: 0x28B64F4 VA: 0x28B64F4
	// public CriAtomExPlayback Play() { }

	// // RVA: 0x28B64FC Offset: 0x28B64FC VA: 0x28B64FC
	// public CriAtomExPlayback Play(string cueName) { }

	// // RVA: 0x28B66EC Offset: 0x28B66EC VA: 0x28B66EC
	public CriAtomExPlayback Play(int cueId)
	{
		UnityEngine.Debug.LogError("TODO");
		return new CriAtomExPlayback();
	}

	// // RVA: 0x28B6440 Offset: 0x28B6440 VA: 0x28B6440
	// private void PlayOnStart() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6358F4 Offset: 0x6358F4 VA: 0x6358F4
	// // RVA: 0x28B68DC Offset: 0x28B68DC VA: 0x28B68DC
	// private IEnumerator PlayAsync(string cueName) { }

	// // RVA: 0x28B69A4 Offset: 0x28B69A4 VA: 0x28B69A4
	public void Stop()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x28B69B4 Offset: 0x28B69B4 VA: 0x28B69B4
	public void Pause(bool sw)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x28B69DC Offset: 0x28B69DC VA: 0x28B69DC
	public bool IsPaused()
	{
		UnityEngine.Debug.LogError("TODO");
		return false;
	}

	// // RVA: 0x28B69F4 Offset: 0x28B69F4 VA: 0x28B69F4
	// public void SetBusSendLevel(string busName, float level) { }

	// [ObsoleteAttribute] // RVA: 0x63596C Offset: 0x63596C VA: 0x63596C
	// // RVA: 0x28B6A20 Offset: 0x28B6A20 VA: 0x28B6A20
	// public void SetBusSendLevel(int busId, float level) { }

	// // RVA: 0x28B6A4C Offset: 0x28B6A4C VA: 0x28B6A4C
	// public void SetBusSendLevelOffset(string busName, float levelOffset) { }

	// [ObsoleteAttribute] // RVA: 0x6359CC Offset: 0x6359CC VA: 0x6359CC
	// // RVA: 0x28B6A78 Offset: 0x28B6A78 VA: 0x28B6A78
	// public void SetBusSendLevelOffset(int busId, float levelOffset) { }

	// // RVA: 0x28B6AA4 Offset: 0x28B6AA4 VA: 0x28B6AA4
	// public void SetAisacControl(string controlName, float value) { }

	// [ObsoleteAttribute] // RVA: 0x635A30 Offset: 0x635A30 VA: 0x635A30
	// // RVA: 0x28B6AD0 Offset: 0x28B6AD0 VA: 0x28B6AD0
	// public void SetAisac(string controlName, float value) { }

	// // RVA: 0x28B6AFC Offset: 0x28B6AFC VA: 0x28B6AFC
	// public void SetAisacControl(uint controlId, float value) { }

	// [ObsoleteAttribute] // RVA: 0x635A64 Offset: 0x635A64 VA: 0x635A64
	// // RVA: 0x28B6B2C Offset: 0x28B6B2C VA: 0x28B6B2C
	// public void SetAisac(uint controlId, float value) { }

	// // RVA: 0x28B6B5C Offset: 0x28B6B5C VA: 0x28B6B5C
	// public void AttachToAnalyzer(CriAtomExOutputAnalyzer analyzer) { }

	// // RVA: 0x28B6B94 Offset: 0x28B6B94 VA: 0x28B6B94
	// public void DetachFromAnalyzer(CriAtomExOutputAnalyzer analyzer) { }

	// // RVA: 0x28B6BBC Offset: 0x28B6BBC VA: 0x28B6BBC
	// public void .ctor() { }
}
