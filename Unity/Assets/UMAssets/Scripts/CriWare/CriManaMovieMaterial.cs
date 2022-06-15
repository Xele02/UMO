using UnityEngine;

// [AddComponentMenu] // RVA: 0x632920 Offset: 0x632920 VA: 0x632920
public class CriManaMovieMaterial : CriMonoBehaviour
{
	public enum RenderMode
	{
		Always = 0,
		OnVisibility = 1,
		Never = 2,
	}

	public enum MaxFrameDrop
	{
		Disabled = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Infinite = -1,
	}

	public bool playOnStart; // 0x1C
	public bool restartOnEnable; // 0x1D
	// [CompilerGeneratedAttribute] // RVA: 0x634B64 Offset: 0x634B64 VA: 0x634B64
	// private bool <isMaterialAvailable>k__BackingField; // 0x1E
	// [CompilerGeneratedAttribute] // RVA: 0x634B74 Offset: 0x634B74 VA: 0x634B74
	// private Player <player>k__BackingField; // 0x20
	public CriManaMovieMaterial.RenderMode renderMode; // 0x24
	// public CriManaMovieMaterial.OnApplicationPauseCallback onApplicationPauseCallback; // 0x28
	// private Player.TimerType _timerType; // 0x2C
	[SerializeField] // RVA: 0x634B84 Offset: 0x634B84 VA: 0x634B84
	private Material _material; // 0x30
	[SerializeField] // RVA: 0x634B94 Offset: 0x634B94 VA: 0x634B94
	private string _moviePath; // 0x34
	[SerializeField] // RVA: 0x634BA4 Offset: 0x634BA4 VA: 0x634BA4
	private bool _loop; // 0x38
	[SerializeField] // RVA: 0x634BB4 Offset: 0x634BB4 VA: 0x634BB4
	private CriManaMovieMaterial.MaxFrameDrop _maxFrameDrop; // 0x3C
	[SerializeField] // RVA: 0x634BC4 Offset: 0x634BC4 VA: 0x634BC4
	private bool _additiveMode; // 0x40
	[SerializeField] // RVA: 0x634BD4 Offset: 0x634BD4 VA: 0x634BD4
	private bool _advancedAudio; // 0x41
	[SerializeField] // RVA: 0x634BE4 Offset: 0x634BE4 VA: 0x634BE4
	private bool _ambisonics; // 0x42
	[SerializeField] // RVA: 0x634BF4 Offset: 0x634BF4 VA: 0x634BF4
	private bool _applyTargetAlpha; // 0x43
	[SerializeField] // RVA: 0x634C04 Offset: 0x634C04 VA: 0x634C04
	private bool _uiRenderMode; // 0x44
	// private bool materialOwn; // 0x45
	// private bool isMonoBehaviourStartCalled; // 0x46
	// private GameObject ambisonicSource; // 0x48
	// private bool wasDisabled; // 0x4C
	// private bool wasPausedOnDisable; // 0x4D
	// private WaitForEndOfFrame frameEnd; // 0x50
	// private bool unpauseOnApplicationUnpause; // 0x54
	// [CompilerGeneratedAttribute] // RVA: 0x634C14 Offset: 0x634C14 VA: 0x634C14
	// private bool <HaveRendererOwner>k__BackingField; // 0x55
	// private CriManaMoviePlayerHolder playerHolder; // 0x58
	// public const int DONT_FORGET_COMMENT_OUT_PLAYER_PAUSE = 0;

	// public string moviePath { get; set; }
	// public bool loop { get; set; }
	// public CriManaMovieMaterial.MaxFrameDrop maxFrameDrop { get; set; }
	// public bool advancedAudio { get; set; }
	// public bool ambisonics { get; set; }
	// public bool additiveMode { get; set; }
	// public bool applyTargetAlpha { get; set; }
	// public bool uiRenderMode { get; set; }
	// public bool isMaterialAvailable { get; set; }
	// public Player player { get; set; }
	// public Material material { get; set; }
	// public Player.TimerType timerType { get; set; }
	// protected bool HaveRendererOwner { get; set; }

	// // RVA: 0x2962720 Offset: 0x2962720 VA: 0x2962720
	// public string get_moviePath() { }

	// // RVA: 0x2962728 Offset: 0x2962728 VA: 0x2962728
	// public void set_moviePath(string value) { }

	// // RVA: 0x29627CC Offset: 0x29627CC VA: 0x29627CC
	// public bool get_loop() { }

	// // RVA: 0x29627D4 Offset: 0x29627D4 VA: 0x29627D4
	// public void set_loop(bool value) { }

	// // RVA: 0x2962878 Offset: 0x2962878 VA: 0x2962878
	// public CriManaMovieMaterial.MaxFrameDrop get_maxFrameDrop() { }

	// // RVA: 0x2962880 Offset: 0x2962880 VA: 0x2962880
	// public void set_maxFrameDrop(CriManaMovieMaterial.MaxFrameDrop value) { }

	// // RVA: 0x2962894 Offset: 0x2962894 VA: 0x2962894
	// public bool get_advancedAudio() { }

	// // RVA: 0x296289C Offset: 0x296289C VA: 0x296289C
	// public void set_advancedAudio(bool value) { }

	// // RVA: 0x2962F10 Offset: 0x2962F10 VA: 0x2962F10
	// public bool get_ambisonics() { }

	// // RVA: 0x2962958 Offset: 0x2962958 VA: 0x2962958
	// public void set_ambisonics(bool value) { }

	// // RVA: 0x2962F18 Offset: 0x2962F18 VA: 0x2962F18
	// public bool get_additiveMode() { }

	// // RVA: 0x2962F20 Offset: 0x2962F20 VA: 0x2962F20
	// public void set_additiveMode(bool value) { }

	// // RVA: 0x2962FC4 Offset: 0x2962FC4 VA: 0x2962FC4
	// public bool get_applyTargetAlpha() { }

	// // RVA: 0x2962FCC Offset: 0x2962FCC VA: 0x2962FCC
	// public void set_applyTargetAlpha(bool value) { }

	// // RVA: 0x2963070 Offset: 0x2963070 VA: 0x2963070
	// public bool get_uiRenderMode() { }

	// // RVA: 0x296214C Offset: 0x296214C VA: 0x296214C
	// public void set_uiRenderMode(bool value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x63638C Offset: 0x63638C VA: 0x63638C
	// // RVA: 0x2962098 Offset: 0x2962098 VA: 0x2962098
	// public bool get_isMaterialAvailable() { }

	// [CompilerGeneratedAttribute] // RVA: 0x63639C Offset: 0x63639C VA: 0x63639C
	// // RVA: 0x2963078 Offset: 0x2963078 VA: 0x2963078
	// private void set_isMaterialAvailable(bool value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6363AC Offset: 0x6363AC VA: 0x6363AC
	// // RVA: 0x2961300 Offset: 0x2961300 VA: 0x2961300
	// public Player get_player() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6363BC Offset: 0x6363BC VA: 0x6363BC
	// // RVA: 0x2963080 Offset: 0x2963080 VA: 0x2963080
	// private void set_player(Player value) { }

	// // RVA: 0x29620A0 Offset: 0x29620A0 VA: 0x29620A0
	// public Material get_material() { }

	// // RVA: 0x2963088 Offset: 0x2963088 VA: 0x2963088
	// public void set_material(Material value) { }

	// // RVA: 0x296317C Offset: 0x296317C VA: 0x296317C
	// public Player.TimerType get_timerType() { }

	// // RVA: 0x2963184 Offset: 0x2963184 VA: 0x2963184
	// public void set_timerType(Player.TimerType value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6363CC Offset: 0x6363CC VA: 0x6363CC
	// // RVA: 0x2961C88 Offset: 0x2961C88 VA: 0x2961C88
	// protected bool get_HaveRendererOwner() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6363DC Offset: 0x6363DC VA: 0x6363DC
	// // RVA: 0x296319C Offset: 0x296319C VA: 0x296319C
	// private void set_HaveRendererOwner(bool value) { }

	// // RVA: 0x29631A4 Offset: 0x29631A4 VA: 0x29631A4
	// public void Play() { }

	// // RVA: 0x29631E4 Offset: 0x29631E4 VA: 0x29631E4
	// public void Stop() { }

	// // RVA: 0x2963238 Offset: 0x2963238 VA: 0x2963238
	// public void Pause(bool sw) { }

	// // RVA: 0x2963278 Offset: 0x2963278 VA: 0x2963278 Slot: 8
	// protected virtual void OnMaterialAvailableChanged() { }

	// // RVA: 0x296327C Offset: 0x296327C VA: 0x296327C Slot: 9
	// protected virtual void OnMaterialUpdated() { }

	// // RVA: 0x2963280 Offset: 0x2963280 VA: 0x2963280
	// public void PlayerManualInitialize() { }

	// // RVA: 0x29634C4 Offset: 0x29634C4 VA: 0x29634C4
	// public void PlayerManualFinalize() { }

	// // RVA: 0x2963504 Offset: 0x2963504 VA: 0x2963504
	// public void PlayerManualSetup() { }

	// // RVA: 0x29637A4 Offset: 0x29637A4 VA: 0x29637A4 Slot: 10
	// public virtual bool RenderTargetManualSetup() { }

	// // RVA: 0x29637AC Offset: 0x29637AC VA: 0x29637AC Slot: 11
	// public virtual void RenderTargetManualFinalize() { }

	// // RVA: 0x29637B0 Offset: 0x29637B0 VA: 0x29637B0
	// public void PlayerManualUpdate() { }

	// // RVA: 0x29621F0 Offset: 0x29621F0 VA: 0x29621F0 Slot: 12
	protected virtual void Awake()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2963908 Offset: 0x2963908 VA: 0x2963908 Slot: 4
	protected override void OnEnable()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6363EC Offset: 0x6363EC VA: 0x6363EC
	// // RVA: 0x2963970 Offset: 0x2963970 VA: 0x2963970
	// private IEnumerator RestartPlayerRoutine() { }

	// // RVA: 0x2963A1C Offset: 0x2963A1C VA: 0x2963A1C Slot: 5
	protected override void OnDisable()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2963AF4 Offset: 0x2963AF4 VA: 0x2963AF4 Slot: 13
	protected virtual void OnDestroy()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2963B20 Offset: 0x2963B20 VA: 0x2963B20 Slot: 14
	protected virtual void Start()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2961C84 Offset: 0x2961C84 VA: 0x2961C84 Slot: 6
	public override void CriInternalUpdate()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2963BD0 Offset: 0x2963BD0 VA: 0x2963BD0 Slot: 15
	// public virtual void RenderMovie() { }

	// // RVA: 0x2963BF8 Offset: 0x2963BF8 VA: 0x2963BF8 Slot: 7
	public override void CriInternalLateUpdate()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x2963C2C Offset: 0x2963C2C VA: 0x2963C2C Slot: 16
	// protected virtual void OnWillRenderObject() { }

	// // RVA: 0x2963C60 Offset: 0x2963C60 VA: 0x2963C60
	// private void OnApplicationPause(bool appPause) { }

	// // RVA: 0x2963C64 Offset: 0x2963C64 VA: 0x2963C64
	// private void ProcessApplicationPause(bool appPause) { }

	// // RVA: 0x29636E0 Offset: 0x29636E0 VA: 0x29636E0
	// private void CreateMaterial() { }

	// // RVA: 0x29620AC Offset: 0x29620AC VA: 0x29620AC
	// public void .ctor() { }
}
