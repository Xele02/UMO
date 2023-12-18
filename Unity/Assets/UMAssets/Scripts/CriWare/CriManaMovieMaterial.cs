using System.Collections;
using CriWare.CriMana;
using UnityEngine;

namespace CriWare
{

	// [AddComponentMenu] // RVA: 0x632920 Offset: 0x632920 VA: 0x632920
	public class CriManaMovieMaterial : CriMonoBehaviour
	{
		public delegate void OnApplicationPauseCallback(CriManaMovieMaterial manaMovieMaterial, bool appPause);

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
		public RenderMode renderMode; // 0x24
		public OnApplicationPauseCallback onApplicationPauseCallback; // 0x28
		private Player.TimerType _timerType = Player.TimerType.Audio; // 0x2C
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
		private bool materialOwn; // 0x45
		private bool isMonoBehaviourStartCalled; // 0x46
		// private GameObject ambisonicSource; // 0x48
		private bool wasDisabled; // 0x4C
		private bool wasPausedOnDisable; // 0x4D
		// private WaitForEndOfFrame frameEnd = new WaitForEndOfFrame(); // 0x50
		private bool unpauseOnApplicationUnpause; // 0x54
		private CriManaMoviePlayerHolder playerHolder; // 0x58
		// public const int DONT_FORGET_COMMENT_OUT_PLAYER_PAUSE = 0;

		public string moviePath { get { return _moviePath; } set {
			if(isMonoBehaviourStartCalled)
			{
				Debug.LogError("[CRIWARE] moviePath can not be changed. Use CriMana::Player::SetFile method.");
				return;
			}
			_moviePath = value;
		} } //0x2962720 0x2962728
		public bool loop { get { return _loop; } set { 
			if(isMonoBehaviourStartCalled)
			{
				Debug.LogError("[CRIWARE] loop property can not be changed. Use CriMana::Player::Loop method.");
				return;
			}
			_loop = value;
		} } //0x29627CC 0x29627D4
		// public CriManaMovieMaterial.MaxFrameDrop maxFrameDrop { get; set; } 0x2962878 0x2962880
		// public bool advancedAudio { get; set; } 0x2962894 0x296289C
		// public bool ambisonics { get; set; } 0x2962F10 0x2962958
		public bool additiveMode { get { return _additiveMode; } set {
			if(isMonoBehaviourStartCalled)
			{
				Debug.LogError("[CRIWARE] additiveMode can not be changed. Use CriMana::Player::additiveMode method.");
				return;
			}
			_additiveMode = value;
		} } //0x2962F18 0x2962F20
		// public bool applyTargetAlpha { get; set; } 0x2962FC4 0x2962FCC
		// public bool uiRenderMode { get; set; } 0x2963070 0x296214C
		public bool isMaterialAvailable { get; private set; } // 0x1E
		public Player player { get; private set; } // 0x20
		public Material material { get { return _material; } set {
			if(value == material)
				return;
			if(materialOwn)
			{
				Destroy(material);
				materialOwn = false;
			}
			isMaterialAvailable = false;
			_material = value;
		} } //0x29620A0 0x2963088
		// public Player.TimerType timerType { get; set; } 0x296317C 0x2963184
		protected bool HaveRendererOwner { get; private set; } // 0x55

		// // RVA: 0x29631A4 Offset: 0x29631A4 VA: 0x29631A4
		public void Play()
		{
			player.Start();
			CriInternalUpdate();
		}

		// // RVA: 0x29631E4 Offset: 0x29631E4 VA: 0x29631E4
		public void Stop()
		{
			player.Stop();
			if(!isMaterialAvailable)
				return;
			isMaterialAvailable = false;
			OnMaterialAvailableChanged();
		}

		// // RVA: 0x2963238 Offset: 0x2963238 VA: 0x2963238
		public void Pause(bool sw)
		{
			if (wasDisabled)
				wasPausedOnDisable = sw;
			player.Pause(sw);
		}

		// // RVA: 0x2963278 Offset: 0x2963278 VA: 0x2963278 Slot: 8
		protected virtual void OnMaterialAvailableChanged()
		{
			return;
		}

		// // RVA: 0x296327C Offset: 0x296327C VA: 0x296327C Slot: 9
		protected virtual void OnMaterialUpdated()
		{
			return;
		}

		// // RVA: 0x2963280 Offset: 0x2963280 VA: 0x2963280
		public void PlayerManualInitialize()
		{
			int max_path_length = 0;
			if(!string.IsNullOrEmpty(_moviePath))
			{
				max_path_length = _moviePath.Length + 1;
				if(Common.IsStreamingAssetsPath(_moviePath))
				{
					max_path_length += Common.streamingAssetsPath.Length;
				}
			}
			player = new Player(_advancedAudio, _ambisonics, (uint)max_path_length);
			player.SetMasterTimerType(_timerType);
			isMaterialAvailable = false;
			if(Application.isPlaying)
			{
				GameObject obj = new GameObject("CriManaMovieResources");
				playerHolder = obj.AddComponent<CriManaMoviePlayerHolder>();
				playerHolder.player = player;
				player.playerHolder = playerHolder;
			}
		}

		// // RVA: 0x29634C4 Offset: 0x29634C4 VA: 0x29634C4
		public void PlayerManualFinalize()
		{
			if(player == null)
				return;
			player.Dispose();
			player = null;
			material = null;
		}

		// // RVA: 0x2963504 Offset: 0x2963504 VA: 0x2963504
		public void PlayerManualSetup()
		{
			Renderer r = GetComponent<Renderer>();
			HaveRendererOwner = r != null;
			if(material == null)
				CreateMaterial();
			if(!string.IsNullOrEmpty(_moviePath))
			{
				player.SetFile(null, _moviePath, 0);
			}
			player.Loop(_loop);
			player.additiveMode = _additiveMode;
			player.maxFrameDrop = (int)_maxFrameDrop;
			player.applyTargetAlpha = _applyTargetAlpha;
			player.uiRenderMode = _uiRenderMode;
			if(playOnStart)
			{
				player.Start();
			}
		}

		// // RVA: 0x29637A4 Offset: 0x29637A4 VA: 0x29637A4 Slot: 10
		public virtual bool RenderTargetManualSetup()
		{
			return true;
		}

		// // RVA: 0x29637AC Offset: 0x29637AC VA: 0x29637AC Slot: 11
		public virtual void RenderTargetManualFinalize()
		{
			return;
		}

		// // RVA: 0x29637B0 Offset: 0x29637B0 VA: 0x29637B0
		public void PlayerManualUpdate()
		{
			if(player != null)
			{
				if(player.timerType == Player.TimerType.User)
				{
					player.UpdateWithUserTime(0, 1000);
				}
				else
				{
					player.Update();
				}
				if(player.isFrameAvailable)
				{
					if(player.UpdateMaterial(_material))
					{
						OnMaterialUpdated();
						if(isMaterialAvailable)
							return;
						isMaterialAvailable = true;
						OnMaterialAvailableChanged();
						return;
					}
				}
				isMaterialAvailable = false;
				OnMaterialAvailableChanged();
			}
		}

		// // RVA: 0x29621F0 Offset: 0x29621F0 VA: 0x29621F0 Slot: 12
		protected virtual void Awake()
		{
			PlayerManualInitialize();
		}

		// // RVA: 0x2963908 Offset: 0x2963908 VA: 0x2963908 Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
			if(wasDisabled)
			{
				if(player != null && player.isAlive)
				{
					player.Pause(wasPausedOnDisable);
					if(restartOnEnable)
					{
						this.StartCoroutineWatched(RestartPlayerRoutine());
					}
				}
			}
			wasDisabled = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6363EC Offset: 0x6363EC VA: 0x6363EC
		// // RVA: 0x2963970 Offset: 0x2963970 VA: 0x2963970
		private IEnumerator RestartPlayerRoutine()
		{
			//0x296457C
			if(player.status != Player.Status.Playing && player.status != Player.Status.PlayEnd)
				yield break;
			Stop();
			do
			{
				if(player.status == Player.Status.Stop)
				{
					Play();
					player.Pause(wasPausedOnDisable);
					break;
				}
				else if(player.status == Player.Status.StopProcessing)
					yield return null;
				else
					break;
			} while(true);
		}

		// // RVA: 0x2963A1C Offset: 0x2963A1C VA: 0x2963A1C Slot: 5
		protected override void OnDisable()
		{
			base.OnDisable();
			if(player != null && player.isAlive)
			{
				wasPausedOnDisable = player.IsPaused();
				player.Pause(true);
			}
			wasDisabled = true;
		}

		// // RVA: 0x2963AF4 Offset: 0x2963AF4 VA: 0x2963AF4 Slot: 13
		protected virtual void OnDestroy()
		{
			RenderTargetManualFinalize();
			PlayerManualFinalize();
		}

		// // RVA: 0x2963B20 Offset: 0x2963B20 VA: 0x2963B20 Slot: 14
		protected virtual void Start()
		{
			PlayerManualSetup();
			isMonoBehaviourStartCalled = true;
			if(!RenderTargetManualSetup())
			{
				Destroy(this);
			}
		}

		// // RVA: 0x2961C84 Offset: 0x2961C84 VA: 0x2961C84 Slot: 6
		public override void CriInternalUpdate()
		{
			PlayerManualUpdate();
		}

		// // RVA: 0x2963BD0 Offset: 0x2963BD0 VA: 0x2963BD0 Slot: 15
		// public virtual void RenderMovie() { }

		// // RVA: 0x2963BF8 Offset: 0x2963BF8 VA: 0x2963BF8 Slot: 7
		public override void CriInternalLateUpdate()
		{
			if(renderMode != RenderMode.Always)
				return;
			player.OnWillRenderObject(null);
		}

		// // RVA: 0x2963C2C Offset: 0x2963C2C VA: 0x2963C2C Slot: 16
		// protected virtual void OnWillRenderObject() { }

		// // RVA: 0x2963C60 Offset: 0x2963C60 VA: 0x2963C60
		private void OnApplicationPause(bool appPause)
		{
			ProcessApplicationPause(appPause);
		}

		// // RVA: 0x2963C64 Offset: 0x2963C64 VA: 0x2963C64
		private void ProcessApplicationPause(bool appPause)
		{
			if(onApplicationPauseCallback != null)
			{
				onApplicationPauseCallback(this, appPause);
				return;
			}
			if(!appPause)
			{
				unpauseOnApplicationUnpause = false;
				return;
			}
			unpauseOnApplicationUnpause = !player.IsPaused();
			if(player.IsPaused())
				return;
			player.Pause(true);
		}

		// // RVA: 0x29636E0 Offset: 0x29636E0 VA: 0x29636E0
		private void CreateMaterial()
		{
			_material = new Material(Shader.Find("VertexLit"));
			_material.name = "CriMana-MovieMaterial";
			materialOwn = true;
		}
	}
}
