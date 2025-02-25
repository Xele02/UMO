using System;
using System.Collections;
using UnityEngine;

namespace CriWare
{

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

		private bool initialized; // 0x24
		private Vector3 lastPosition; // 0x28
		private bool hasValidPosition; // 0x34
		private CriAtomRegion currentRegion; // 0x38
		private CriAtomListener currentListener; // 0x3C
		[SerializeField]
		private bool _playOnStart; // 0x40
		[SerializeField]
		private string _cueName = ""; // 0x44
		[SerializeField]
		private string _cueSheet = ""; // 0x48
		[SerializeField]
		private CriAtomRegion _regionOnStart; // 0x4C
		[SerializeField]
		private CriAtomListener _listenerOnStart; // 0x50
		[SerializeField]
		private bool _use3dPositioning = true; // 0x54
		[SerializeField]
		private bool _freezeOrientation = false; // 0x55
		[SerializeField]
		private bool _loop = false; // 0x56
		[SerializeField]
		private float _volume = 1.0f; // 0x58
		[SerializeField]
		private float _pitch = 0; // 0x5C
		[SerializeField]
		private bool _androidUseLowLatencyVoicePool = false; // 0x60
		[SerializeField]
		private bool need_to_player_update_all = true; // 0x61
		[SerializeField]
		private bool _use3dRandomization = false; // 0x62
		[SerializeField]
		private uint _randomPositionListMaxLength = 0; // 0x64
		[SerializeField]
		private CriAtomEx.Randomize3dConfig randomize3dConfig = new CriAtomEx.Randomize3dConfig (false, CriAtomEx.Randomize3dCalcType.Rectangle, 0, 0, 0); // 0x68

		#if !UNITY_ANDROID
		public AudioSource unityAudioSource = null;
		#endif

		public CriAtomExPlayer player { get; protected set; } // 0x1C
		public CriAtomEx3dSource source { get; protected set; } // 0x20
		public virtual bool enable_audio_synced_timer { get { return false; } protected set { return; } } //0x28B55CC 0x28B55D4
		public bool playOnStart { 
			get {return this._playOnStart;}
			set {this._playOnStart = value;}
		} //0x28B55D8 0x28B55E0
		public string cueName { get { return _cueName; } set { _cueName = value; } } //0x28B55E8 0x28B55F0
		public string cueSheet { get { return _cueSheet; } set { _cueSheet = value; } } //0x28B55F8 0x28B5600
		public bool use3dPositioning { 
			get
			{
				// 0x28B5644
				return _use3dPositioning;
			} 
			set
			{
				// 0x28B5608
				_use3dPositioning = value;
				if(player == null)
					return;
				player.Set3dSource(value ? source : null);
				need_to_player_update_all = true;
			} } 
		public bool freezeOrientation 
		{
			get { return this._freezeOrientation; }
			set { this._freezeOrientation = value; } 
		} //0x28B5658 0x28B5660
		public bool use3dRandomization { 
			set {
				this._use3dRandomization = value;
				if (this.source != null) {
					if (this._use3dRandomization) {
						this.source.SetRandomPositionConfig(this.randomize3dConfig);
					} else {
						this.source.SetRandomPositionConfig(null);
					}
				}
			}
			get { return this._use3dRandomization; } 
		} //0x28B5668 0x28B5740
		public uint randomPositionListMaxLength { 
			set {
				if (initialized) {
					Debug.LogError("[CRIWARE] Max length of random position list cannot be changed after initialization of the CriAtomSource.", this);
					return;
				}
				this._randomPositionListMaxLength = value;
			}
			get {
				return this._randomPositionListMaxLength;
			}
		} //0x28B5748 0x28B57F0
		public CriAtomRegion region3d { 
			get { return this.currentRegion; }
			set {
				if (this._use3dPositioning == false) {
					Debug.LogWarning("[CRIWARE] Cannot set 3D Region on audio source with 3d positioning disabled.");
					return;
				}

				CriAtomEx3dRegion regionHandle = (value == null) ? null : value.region3dHn;
				if (this.source != null) {
					this.source.Set3dRegion(regionHandle);
					this.source.Update();
					this.currentRegion = value;
				} else {
					Debug.LogError("[CRIWARE] Internal: 3D Positioning is not initialized correctly.");
					this.currentRegion = null;
				}
			}
		} //0x28B57F8 0x28B5800
		public CriAtomListener listener
		{ 
			get { return currentListener; }
			set {
				if (this._use3dPositioning == false) {
					Debug.LogWarning("[CRIWARE] Cannot set 3D Listener on audio source with 3d positioning disabled.");
					return;
				}
				currentListener = value;
				player.Set3dListener(value == null ? null : value.nativeListener);
			}
		} //0x28B5988 0x28B5990
		public CriAtomRegion regionOnStart { 
			get { return this._regionOnStart; }
			set { this._regionOnStart = value; }
		} //0x28B5AB4 0x28B5ABC
		public CriAtomListener listenerOnStart { 
			get { return _listenerOnStart; }
			set { _listenerOnStart = value; }
		} //0x28B5AC4 0x28B5ACC
		// public bool loop { get; set; } 0x28B5AD4 0x28B5ADC
		public float volume { 
			set { // 0x28B5B14
				this._volume = value;
				if (this.player != null) {
					this.player.SetVolume(this._volume);
					this.SetNeedToPlayerUpdateAll();
				}
			}
			get { return this._volume; } // 0x28B5AE4
		}
		// public float pitch { get; set; } 0x28B5B1C 0x28B5B4C
		// public float pan3dAngle { get; set; } 0x28B5B54 0x28B5B80
		// public float pan3dDistance { get; set; } 0x28B5B9C 0x28B5BC8
		// public int startTime { get; set; } 0x28B5BE4 0x28B5C20
		// public long time { get; } 0x28B5C3C
		public Status status { get { if(player != null) return (Status)player.GetStatus(); else return Status.Error; } } //0x28B5C58
		// public bool attenuationDistanceSetting { get; set; } 0x28B5C70 0x28B5CB4
		public bool androidUseLowLatencyVoicePool { get { return _androidUseLowLatencyVoicePool; } set { _androidUseLowLatencyVoicePool = value;} } //0x28B5CCC 0x28B5CD4

		// // RVA: 0x28B564C Offset: 0x28B564C VA: 0x28B564C
		protected void SetNeedToPlayerUpdateAll()
		{
			this.need_to_player_update_all = true;
		}

		// // RVA: 0x28B5CDC Offset: 0x28B5CDC VA: 0x28B5CDC Slot: 9
		protected virtual void InternalInitialize()
		{
			#if !UNITY_ANDROID
			if(unityAudioSource == null)
			{
				unityAudioSource = gameObject.AddComponent<AudioSource>();
				unityAudioSource.playOnAwake = false;
			}
			#endif
			CriAtomPlugin.InitializeLibrary();
			this.player = new CriAtomExPlayer(this, enable_audio_synced_timer);
			this.source = new CriAtomEx3dSource(this, randomPositionListMaxLength:this.randomPositionListMaxLength);
			this.initialized = true;
		}

		// // RVA: 0x28B5DCC Offset: 0x28B5DCC VA: 0x28B5DCC Slot: 10
		protected virtual void InternalFinalize()
		{
			this.initialized = false;
			this.player.Dispose();
			this.player = null;
			this.source.Dispose();
			this.source = null;
			CriAtomPlugin.FinalizeLibrary();
		}

		// // RVA: 0x28B5EAC Offset: 0x28B5EAC VA: 0x28B5EAC
		private void Awake()
		{
			this.InternalInitialize();
		}

		// // RVA: 0x28B5EBC Offset: 0x28B5EBC VA: 0x28B5EBC Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
			this.hasValidPosition = false;
			this.SetInitialParameters();
			this.SetNeedToPlayerUpdateAll();
		}

		// // RVA: 0x28B5EF8 Offset: 0x28B5EF8 VA: 0x28B5EF8
		private void OnDestroy()
		{
			this.InternalFinalize();
		}

		// // RVA: 0x28B5F08 Offset: 0x28B5F08 VA: 0x28B5F08
		protected bool SetInitialSourcePosition()
		{
			Vector3 position = this.transform.position;
			this.lastPosition = position;
			if (this.source != null) {
				this.source.SetPosition(position.x, position.y, position.z);
				this.source.Update();
				return true;
			} else {
				return false;
			}
		}

		// // RVA: 0x28B5F9C Offset: 0x28B5F9C VA: 0x28B5F9C Slot: 11
		protected virtual void SetInitialParameters()
		{
			this.use3dPositioning = this.use3dPositioning;
			this.use3dRandomization = this.use3dRandomization;
			if (this.SetInitialSourcePosition() == false) {
				Debug.LogError("[ADX2][SetInitialParameters] source is null.",this);
			}

			this.player.SetVolume(this._volume);
			this.player.SetPitch(this._pitch);
		}

		// // RVA: 0x28B60C4 Offset: 0x28B60C4 VA: 0x28B60C4 Slot: 12
		protected virtual void UpdatePosition()
		{
			Vector3 position = this.transform.position;
			this.source.SetPosition(position.x, position.y, position.z);
			if (this.hasValidPosition == true) {
				Vector3 velocity = (position - this.lastPosition) / Time.deltaTime;
				this.source.SetVelocity(velocity.x, velocity.y, velocity.z);
			}
			if (this.freezeOrientation == false) {
				this.source.SetOrientation(this.transform.forward, this.transform.up);
			}
			this.source.Update();
			this.lastPosition = position;
			this.hasValidPosition = true;
		}

		// // RVA: 0x28B632C Offset: 0x28B632C VA: 0x28B632C
		private void Start()
		{
			if (this.use3dPositioning && this.regionOnStart != null) {
				this.region3d = this.regionOnStart;
			}
			if (use3dPositioning && listenerOnStart != null)
				listener = listenerOnStart;
			this.PlayOnStart();
		}

		// // RVA: 0x28B6490 Offset: 0x28B6490 VA: 0x28B6490 Slot: 6
		public override void CriInternalUpdate()
		{
			return;
		}

		// // RVA: 0x28B6494 Offset: 0x28B6494 VA: 0x28B6494 Slot: 7
		public override void CriInternalLateUpdate()
		{
			if(use3dPositioning)
			{
				UpdatePosition();
			}
			if(!need_to_player_update_all)
				return;
			player.UpdateAll();
			need_to_player_update_all = false;
		}

		// // RVA: 0x28B64F4 Offset: 0x28B64F4 VA: 0x28B64F4
		public CriAtomExPlayback Play()
		{
			return this.Play(this.cueName);
		}

		// // RVA: 0x28B64FC Offset: 0x28B64FC VA: 0x28B64FC
		public CriAtomExPlayback Play(string cueName)
		{
			if (this.player == null)
				return new CriAtomExPlayback(CriAtomExPlayback.invalidId);

			CriAtomExAcb acb = null;
			if (!String.IsNullOrEmpty(this.cueSheet)) {
				acb = CriAtom.GetAcb(this.cueSheet);
			}
			this.player.SetCue(acb, cueName);
	#if !UNITY_EDITOR && UNITY_ANDROID
			if (androidUseLowLatencyVoicePool) {
				this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
			} else {
				this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
			}
	#endif
			if (this.hasValidPosition == false) {
				this.SetInitialSourcePosition();
				this.hasValidPosition = true;
			}
			if (this.status == Status.Stop) {
				this.player.Loop(this._loop);
			}
			return this.player.Start();
		}

		// // RVA: 0x28B66EC Offset: 0x28B66EC VA: 0x28B66EC
		public CriAtomExPlayback Play(int cueId)
		{
			if (this.player == null)
				return new CriAtomExPlayback(CriAtomExPlayback.invalidId);


			CriAtomExAcb acb = null;
			if (!String.IsNullOrEmpty(this.cueSheet)) {
				acb = CriAtom.GetAcb(this.cueSheet);
			}
			this.player.SetCue(acb, cueId);
	#if !UNITY_EDITOR && UNITY_ANDROID
			if (androidUseLowLatencyVoicePool) {
				this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
			} else {
				this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
			}
	#endif
			if (this.hasValidPosition == false) {
				this.SetInitialSourcePosition();
				this.hasValidPosition = true;
			}
			if (this.status == Status.Stop) {
				this.player.Loop(this._loop);
			}
			return this.player.Start();
		}

		// // RVA: 0x28B6440 Offset: 0x28B6440 VA: 0x28B6440
		private void PlayOnStart()
		{
			if (this.playOnStart && !String.IsNullOrEmpty(this.cueName)) {
				this.StartCoroutineWatched(PlayAsync(this.cueName));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6358F4 Offset: 0x6358F4 VA: 0x6358F4
		// // RVA: 0x28B68DC Offset: 0x28B68DC VA: 0x28B68DC
		private IEnumerator PlayAsync(string cueName)
		{
			CriAtomExAcb acb = null;
			while (acb == null && !String.IsNullOrEmpty(this.cueSheet)) {
				acb = CriAtom.GetAcb(this.cueSheet);
				if (acb == null) {
					yield return null;
				}
			}
			this.player.SetCue(acb, cueName);
	#if !UNITY_EDITOR && UNITY_ANDROID
			if (androidUseLowLatencyVoicePool) {
				this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
			} else {
				this.player.SetSoundRendererType(CriAtomEx.androidDefaultSoundRendererType);
			}
	#endif
			if (this.hasValidPosition == false) {
				this.SetInitialSourcePosition();
				this.hasValidPosition = true;
			}
			if (this.status == Status.Stop) {
				this.player.Loop(this._loop);
			}
			this.player.Start();
		}

		// // RVA: 0x28B69A4 Offset: 0x28B69A4 VA: 0x28B69A4
		public void Stop()
		{
			if (this.player != null) {
				this.player.Stop();
			}
		}

		// // RVA: 0x28B69B4 Offset: 0x28B69B4 VA: 0x28B69B4
		public void Pause(bool sw)
		{
			if (this.player == null)
				return;

			if (sw == false) {
				this.player.Resume(CriAtomEx.ResumeMode.PausedPlayback);
			} else {
				this.player.Pause();
			}
		}

		// // RVA: 0x28B69DC Offset: 0x28B69DC VA: 0x28B69DC
		public bool IsPaused()
		{
			return (this.player != null) ? this.player.IsPaused() : false;
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
		public void AttachToAnalyzer(CriAtomExOutputAnalyzer analyzer)
		{
			if (player == null)
				return;
			analyzer.AttachExPlayer(player);
		}

		// // RVA: 0x28B6B94 Offset: 0x28B6B94 VA: 0x28B6B94
		public void DetachFromAnalyzer(CriAtomExOutputAnalyzer analyzer)
		{
			analyzer.DetachExPlayer();
		}

		//UMO
		public void Preload(string cueName)
		{
#if !UNITY_ANDROID
			CriAtomExAcb acb = null;
			if (!String.IsNullOrEmpty(this.cueSheet))
			{
				acb = CriAtom.GetAcb(this.cueSheet);
			}
			ExternLib.LibCriWare.PreloadCue(acb.nativeHandle, cueName);
#endif
		}
		public void Preload(int cueId)
		{
#if !UNITY_ANDROID
			CriAtomExAcb acb = null;
			if (!String.IsNullOrEmpty(this.cueSheet))
			{
				acb = CriAtom.GetAcb(this.cueSheet);
			}
			ExternLib.LibCriWare.PreloadCue(acb.nativeHandle, cueId);
#endif
		}
		//
	}
}
