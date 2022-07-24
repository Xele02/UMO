using UnityEngine;
using XeSys;
using XeSys.uGUI;
using XeApp.Game.RhythmGame;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Core;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.UI;
using Mana.Service.Ad;
using System.IO;
using CriWare;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class GameManager : MonoBehaviour
	{
		public delegate void PushBackButtonHandler();

		public class FadeYielder : CustomYieldInstruction
		{
			public override bool keepWaiting { get { return GameManager.Instance.fullscreenFader.isFading; } } // get_keepWaiting 0x1429B28 
		}

		private static GameManager mInstance = null; // 0x0
		private static GameObject mMyObject = null; // 0x4
		[SerializeField]
		private FontManager fontManagerPrefab; // 0xC
		//[SpaceAttribute] // RVA: 0x6623E4 Offset: 0x6623E4 VA: 0x6623E4
		[SerializeField]
		private UGUILetterBoxController letterboxPrefab; // 0x10
		[SerializeField]
		private UGUIFader faderPrefab; // 0x14
		[SerializeField]
		private GameObject popupPrefab; // 0x18
		[SerializeField]
		private GameObject transmissionIconPrefab; // 0x1C
		[SerializeField]
		private GameObject downloadBarPrefab; // 0x20
		[SerializeField]
		private GameObject progressBarPrefab; // 0x24
		[SerializeField]
		private GameObject nowloadingPrefab; // 0x28
		[SerializeField]
		private GameObject touchEffectPrefab; // 0x2C
		[SerializeField]
		private Camera systemCanvasCamera; // 0x30
		[SerializeField]
		private GameObject cbtWindowPrefab; // 0x34
		[SerializeField]
		private DebugCheatMenu debugCheatMenuPrefab; // 0x38
		[SerializeField]
		private DebugNetworkPause debugNetworkPausePrefab; // 0x3C
		[SerializeField]
		private NotesSpeedSetting notesSpeedSetting; // 0x40
		[SerializeField]
		private GameObject longScreenFramePrefab; // 0x44
		[SerializeField]
		private EnableOnGUIObjects m_enableOnGUIObjects; // 0x48
		[HideInInspector]
		public float ResolutionWidth;
		[HideInInspector]
		public float ResolutionHeight; // 0x64
		[HideInInspector]
		public float AppResolutionWidth; // 0x68
		[HideInInspector]
		public float AppResolutionHeight; // 0x6C
		private const int PopupWindowCount = 4;
		private bool isDirtyFontUpdate; // 0x72
		private bool isBootInitialized; // 0x73
		[HideInInspector]
		public CriAtom criAtom; // 0x74
		public string ar_session_id; // 0x78
		private DFKGGBMFFGB m_viewPlayerData; // 0x7C
		private FadeYielder m_fadeYielder = new FadeYielder(); // 0x88
		private Canvas popupCanvas; // 0x90
		private Canvas fadeCanvas; // 0x94
		private Canvas systemLayoutCanvas; // 0x98
		public GameObject transmissionIcon; // 0x9C
		private UILoadWait nowloading; // 0xA8
		private TouchParticle m_touchParticle; // 0xB0
		public const int g_SubDivaMax = 4;
		public DivaResource[] subDivaResource = new DivaResource[4]; // 0xB8
		private LayoutCommonTextureManager unionTextureManager = new LayoutCommonTextureManager(); // 0xBC
		private UGUICommonManager uguiCommonManager = new UGUICommonManager(); // 0xC0
		private LayoutPoolManager iconDecorationCache; // 0xC4
		private SceneIconTextureCache sceneIconTextureCache; // 0xC8
		private MenuResidentTextureCache menuResidentTextureCache; // 0xCC
		private DivaIconTextureCache divaIconTextureCache; // 0xD0
		private BgTextureCache bgTextureCache; // 0xD4
		private ItemTextureCache itemTextureCache; // 0xD8
		private MusicJacketTextureCache musicJacketTextureCache; // 0xDC
		private ValkyrieIconTextureCache valkyrieIconTextureCache; // 0xE0
		private CostumeTextureCache costumeTextureCache; // 0xE4
		private EventBannerTextureCache eventBannerTextureCache; // 0xE8
		private PilotTextureCache pilotTextureCache; // 0xEC
		private QuestEventTextureCache questEventTextureCache; // 0xF0
		private SNSTextureCache snsIconCache; // 0xF4
		private EpisodeTextuteCache episodeIconCache; // 0xF8
		private GachaProductTextureCache gachaProductIconCache; // 0xFC
		private EventSystemControl eventSystemController; // 0x100
		private DenomIconTextureCache denomIconCache; // 0x104
		private MenuLayoutGameObjectCahce m_layoutObjectCache; // 0x108
		private StoryImageTextureCache m_storyImageCache; // 0x10C
		private MusicRatioTextureCache musicRatioTextureCache; // 0x110
		private GameObject LongScreenFrameInstance; // 0x118
		private SubPlateIconTextureCache m_subPlateIconCache; // 0x120
		private LobbyTextureCache m_lobbyTextureCache; // 0x124
		private DecorationItemTextureCache m_decorationItemTextureCache; // 0x128
		private RaidBossTextureCache m_raidBossTextureCache; // 0x12C
		private KiraDivaTextureCache m_kiraDivaTextureCache; // 0x130
		private HomeBgIconBgTextureCache m_homeBgIconTextureCache; // 0x134
		// [CompilerGeneratedAttribute] // RVA: 0x66266C Offset: 0x66266C VA: 0x66266C
		private UnityAction<float> UpdateAction; // 0x140
		// [CompilerGeneratedAttribute] // RVA: 0x6AD9A0 Offset: 0x6AD9A0 VA: 0x6AD9A0
		// // RVA: 0x99A05C Offset: 0x99A05C VA: 0x99A05C
		// public void add_UpdateAction(UnityAction<float> value) { }
		// [CompilerGeneratedAttribute] // RVA: 0x6AD9B0 Offset: 0x6AD9B0 VA: 0x6AD9B0
		// // RVA: 0x99A168 Offset: 0x99A168 VA: 0x99A168
		// public void remove_UpdateAction(UnityAction<float> value) { }

		private float m_sceneIconAnimeTime; // 0x144
		private SnsNotification m_snsNotification; // 0x148
		private GameUIIntro m_intro; // 0x14C
		private List<PushBackButtonHandler> m_pushBackButtonHandlerList = new List<PushBackButtonHandler>(); // 0x150
		private static float[] bx = new float[4] { 1024, 960, 800, 720}; // 0x8
		private static float[] by = new float[4] { 768, 720, 600, 540}; // 0xC
		private int screenSizeType; // 0x154
		private const float DEFAULT_FADE_TIME = 0.4f;
		private const int multipleOverridePrimeId = 2;

		public static GameManager Instance { get { return mInstance; } } // get_Instance() 0x984FB8
		public EnableOnGUIObjects EnableInGUI { get { return m_enableOnGUIObjects; } set {} }  // get_EnableInGUI 0x999DF4  set_EnableInGUI 0x999DF0 
		public AppBootTimeManager appBootTime { get; set; } // 0x4C
		public FontManager font { get; set; } // 0x50
		public UGUIFader fullscreenFader { get; set; } // 0x54
		public int screenWidth { get; set; } // 0x58
		public int screenHeight { get; set; } // 0x5C
		public bool IsSystemInitialized { get; set; } // 0x70
		public bool IsUnionDataInitialized { get; set; } // 0x71
		public DFKGGBMFFGB ViewPlayerData { get { return m_viewPlayerData; } } // get_ViewPlayerData 0x989990
		public EAJCBFGKKFA SelectedGuestData { get; set; } // 0x80
		public bool IsTutorial { get; set; } // 0x84
		public FadeYielder WaitFadeYielder { get { return m_fadeYielder; } } // get_WaitFadeYielder 0x999E7C 
		public Canvas PopupCanvas { get { return popupCanvas; } } // get_PopupCanvas 0x999E84 
		public ILDKBCLAFPB localSave { get; set; } // 0x8C
		public UIDownloadWait DownloadBar { get; set; } // 0xA0
		public UILoadProgress ProgressBar { get; set; } // 0xA4
		public UILoadWait NowLoading { get { return nowloading; } } // get_NowLoading 0x999EB4 
		public CbtWindow CbtWindow { get; set; } // 0xAC
		public DivaResource divaResource { get; set; } // 0xB4
		public UGUILetterBoxController LetterBox { get; set; } // 0x114
		public LongScreenFrame LongScreenFrame { get; set; } // 0x11C
		public UnityAction onDownLoadFinish { get; set; }	// 0x138
		public bool InputEnabled { get { Debug.LogWarning("TODO"); return true; } set { Debug.LogError("TODO Set Input Enabled "+value); } } // get_InputEnabled 0x999F0C set_InputEnabled 0x999F38 
		public EventSystemControl EventSystemControl { get { return eventSystemController; } } // get_EventSystemControl 0x999F6C 
		public LayoutCommonTextureManager UnionTextureManager { get { return unionTextureManager; } } // get_UnionTextureManager 0x999F74 
		public UGUICommonManager UguiCommonManager { get { return uguiCommonManager; } } // get_UguiCommonManager 0x999F7C 
		public bool IsCacheActive { get; set; } // 0x13C
		public LayoutPoolManager IconDecorationCache { get { return iconDecorationCache; } } // get_IconDecorationCache 0x999F94 
		public SceneIconTextureCache SceneIconCache { get { return sceneIconTextureCache; } } // get_SceneIconCache 0x999F9C 
		public MenuResidentTextureCache MenuResidentTextureCache { get { return menuResidentTextureCache; } } // get_MenuResidentTextureCache 0x999FA4 
		public DivaIconTextureCache DivaIconCache { get { return divaIconTextureCache; } } // get_DivaIconCache 0x999FAC 
		public BgTextureCache BgTextureCache { get { return bgTextureCache; } } // get_BgTextureCache 0x999FB4 
		public ItemTextureCache ItemTextureCache { get { return itemTextureCache; } } // get_ItemTextureCache 0x98F864 
		public MusicJacketTextureCache MusicJacketTextureCache { get { return musicJacketTextureCache; } } // get_MusicJacketTextureCache 0x999FBC 
		public ValkyrieIconTextureCache ValkyrieIconCache { get { return valkyrieIconTextureCache; } } // get_ValkyrieIconCache 0x999FC4 
		public CostumeTextureCache CostumeIconCache { get { return costumeTextureCache; } } // get_CostumeIconCache 0x999FCC 
		public EventBannerTextureCache EventBannerTextureCache { get { return eventBannerTextureCache; } } // get_EventBannerTextureCache 0x999FD4 
		public PilotTextureCache PilotTextureCache { get { return pilotTextureCache; } } // get_PilotTextureCache 0x999FDC 
		public QuestEventTextureCache QuestEventTextureCache { get { return questEventTextureCache; } } // get_QuestEventTextureCache 0x999FE4 
		public SNSTextureCache SnsIconCache { get { return snsIconCache; } } //  get_SnsIconCache 0x999FEC 
		public GachaProductTextureCache GachaProductIconCache { get { return gachaProductIconCache; } } // get_GachaProductIconCache 0x999FF4 
		public EpisodeTextuteCache EpisodeIconCache { get { return episodeIconCache; } } // get_EpisodeIconCache 0x999FFC 
		public DenomIconTextureCache DenomIconCache { get { return denomIconCache; } } // get_DenomIconCache 0x99A004 
		public MenuLayoutGameObjectCahce LayoutObjectCache { get { return m_layoutObjectCache; } } // get_LayoutObjectCache 0x99A00C 
		public StoryImageTextureCache storyImageCache { get { return m_storyImageCache; } } // get_storyImageCache 0x99A014 
		public MusicRatioTextureCache MusicRatioTextureCache { get { return musicRatioTextureCache; } } // get_MusicRatioTextureCache 0x99A01C 
		public NotesSpeedSetting rhythmNotesSpeedSetting { get { return notesSpeedSetting; } } // get_rhythmNotesSpeedSetting 0x99A024 
		public SubPlateIconTextureCache subPlateIconCache { get { return m_subPlateIconCache; } } // get_subPlateIconCache 0x99A02C 
		public LobbyTextureCache LobbyTextureCache { get { return m_lobbyTextureCache; } } // get_LobbyTextureCache 0x99A034 
		public DecorationItemTextureCache decorationItemTextureCache { get { return m_decorationItemTextureCache; } } // get_decorationItemTextureCache 0x99A03C 
		public RaidBossTextureCache RaidBossTextureCache { get { return m_raidBossTextureCache; } } // get_RaidBossTextureCache 0x99A044 
		public KiraDivaTextureCache KiraDivaTextureCache { get { return m_kiraDivaTextureCache; } } //  get_KiraDivaTextureCache 0x99A04C 
		public HomeBgIconBgTextureCache HomeBgIconTextureCache { get { return m_homeBgIconTextureCache; } } // get_HomeBgIconTextureCache 0x99A054 
		public SnsNotification snsNotification { get { return m_snsNotification; } } // get_snsNotification 0x99A274 
		public GameUIIntro GameUIIntro { get { return m_intro; } } // get_GameUIIntro 0x99A27C 

		// // RVA: 0x99A284 Offset: 0x99A284 VA: 0x99A284
		// public void DeleteIntro() { }

		// // RVA: 0x9888B0 Offset: 0x9888B0 VA: 0x9888B0
		public void AddPushBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			UnityEngine.Debug.LogWarning("TODO AddPushBackButtonHandler");
		}

		// // RVA: 0x99A334 Offset: 0x99A334 VA: 0x99A334
		public void AddLastBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			UnityEngine.Debug.LogWarning("TODO AddLastBackButtonHandler");
		}

		// // RVA: 0x988E80 Offset: 0x988E80 VA: 0x988E80
		public void RemovePushBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			UnityEngine.Debug.LogWarning("TODO RemovePushBackButtonHandler");
		}

		// // RVA: 0x98B534 Offset: 0x98B534 VA: 0x98B534
		public void ClearPushBackButtonHandler()
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.ClearPushBackButtonHandler()");
		}

		// // RVA: 0x99A3B4 Offset: 0x99A3B4 VA: 0x99A3B4
		public static void Create(GameObject prefab)
		{
			if(mInstance == null)
			{
				if(prefab != null)
				{
					mMyObject = GameObject.Find("GameManager");
					if(mMyObject != null)
						return;
					mMyObject = Instantiate<GameObject>(prefab);
					mMyObject.name = "GameManager";
				}
			}
		}

		// // RVA: 0x99A63C Offset: 0x99A63C VA: 0x99A63C
		// public static void Release() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6AD9C0 Offset: 0x6AD9C0 VA: 0x6AD9C0
		// // RVA: 0x99A7A4 Offset: 0x99A7A4 VA: 0x99A7A4
		public IEnumerator UnloadAllAssets()
		{
    		UnityEngine.Debug.Log("Enter UnloadAllAssets");
			//0x1428C74
			UnityEngine.Debug.LogWarning("TODO GameManager.UnloadAllAssets");
    		UnityEngine.Debug.Log("Exit UnloadAllAssets");
			yield break;
		}

		// // RVA: 0x99A82C Offset: 0x99A82C VA: 0x99A82C
		private void Awake()
		{
			DontDestroyOnLoad(this);
			mInstance = this;
			Initialize();
			if(m_enableOnGUIObjects != null)
				m_enableOnGUIObjects.enabled = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADA38 Offset: 0x6ADA38 VA: 0x6ADA38
		// // RVA: 0x99AC08 Offset: 0x99AC08 VA: 0x99AC08
		private IEnumerator Co_InitScreen()
		{
    		UnityEngine.Debug.Log("Enter Co_InitScreen");
			// private int <>1__state; // 0x8
			// private object <>2__current; // 0xC
			// public GameManager <>4__this; // 0x10
			// private int <w>5__2; // 0x14
			// private int <h>5__3; // 0x18
			// private bool <needUpdateScreen>5__4; // 0x1C
			// private bool <loop>5__5; // 0x1D
			// 0x1424340

			int w = UnityEngine.Screen.width;
			int h = UnityEngine.Screen.height;
			bool needUpdateScreen = false;
			if(w < h)
			{
				needUpdateScreen = true;
				w = UnityEngine.Screen.height;
				h = UnityEngine.Screen.width;
			}
#if !UNITY_EDITOR
			while(UnityEngine.Screen.orientation == ScreenOrientation.Portrait)
			{
				UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;
				UnityEngine.Screen.autorotateToLandscapeLeft = true;
				UnityEngine.Screen.autorotateToLandscapeRight = true;
				UnityEngine.Screen.autorotateToPortrait = false;
				UnityEngine.Screen.autorotateToPortraitUpsideDown = false;
				needUpdateScreen = true;
				yield return null;
			}

			if(UnityEngine.Screen.orientation == ScreenOrientation.LandscapeRight)
			{
				if(needUpdateScreen)
				{
					UnityEngine.Screen.SetResolution(w, h, true);
				}
			}
			else
			{
				if(needUpdateScreen)
				{
					UnityEngine.Screen.SetResolution(w, h, true);
				}
				UnityEngine.Screen.orientation = ScreenOrientation.LandscapeLeft;
			}
#endif
			yield return null;
			Initialize_ScreenAndSystemLayout();
			UnityEngine.Font.textureRebuilt += this.OnFontTextureRebuilt;
			yield return null;
			ReInitScreen();
			yield return null;
			isBootInitialized = true;
    		UnityEngine.Debug.Log("Exit Co_InitScreen");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADAB0 Offset: 0x6ADAB0 VA: 0x6ADAB0
		// // RVA: 0x99AC90 Offset: 0x99AC90 VA: 0x99AC90
		// private IEnumerator Co_ReInitScreen() { }

		// // RVA: 0x99AD18 Offset: 0x99AD18 VA: 0x99AD18
		private void Start()
		{
			StartCoroutine(Co_InitScreen());
		}

		// // RVA: 0x99AD3C Offset: 0x99AD3C VA: 0x99AD3C
		private void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x99ADD8 Offset: 0x99ADD8 VA: 0x99ADD8
		private void Update()
		{
			if(!isBootInitialized)
				return;
			sceneIconTextureCache.Update();
			menuResidentTextureCache.Update();
			divaIconTextureCache.Update();
			bgTextureCache.Update();
			itemTextureCache.Update();
			musicJacketTextureCache.Update();
			valkyrieIconTextureCache.Update();
			costumeTextureCache.Update();
			eventBannerTextureCache.Update();
			pilotTextureCache.Update();
			questEventTextureCache.Update();
			snsIconCache.Update();
			episodeIconCache.Update();
			gachaProductIconCache.Update();
			denomIconCache.Update();
			m_storyImageCache.Update();
			musicRatioTextureCache.Update();
			m_subPlateIconCache.Update();
			m_lobbyTextureCache.Update();
			m_decorationItemTextureCache.Update();
			m_raidBossTextureCache.Update();
			m_kiraDivaTextureCache.Update();
			m_homeBgIconTextureCache.Update();
		}

		// // RVA: 0x99B0D4 Offset: 0x99B0D4 VA: 0x99B0D4
		private void OnFontTextureRebuilt(Font font)
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.OnFontTextureRebuilt");
		}

		// // RVA: 0x99B194 Offset: 0x99B194 VA: 0x99B194
		private void LateUpdate()
		{
			if(isDirtyFontUpdate)
				isDirtyFontUpdate = false;
			if(UpdateAction != null)
			{
				m_sceneIconAnimeTime = m_sceneIconAnimeTime + TimeWrapper.deltaTime;
				UpdateAction(TimeWrapper.deltaTime);
			}
		}

		// // RVA: 0x99B250 Offset: 0x99B250 VA: 0x99B250
		// public void OnPushBackButton() { }

		// // RVA: 0x99A938 Offset: 0x99A938 VA: 0x99A938
		private void Initialize()
		{
			//Debug.unityLogger.setlogenabled(false);
			GameObject go = new GameObject("AppBootTimeManager");
			appBootTime = go.AddComponent<AppBootTimeManager>();
			go.transform.SetParent(transform, false);
			UnityEngine.Screen.sleepTimeout = -2;
			criAtom = GetComponentInChildren<CriAtom>();
			//ManaAdAPIHelper.Instance;
			XeApp.Core.Q.A();
			P.A();
			SetupAssetBundleBasePath();
			MessageManager.Create();
			gameObject.AddComponent<FCMTokenReceiver>();
		}

		// // RVA: 0x99B46C Offset: 0x99B46C VA: 0x99B46C
		private void Initialize_ScreenAndSystemLayout()
		{
			CreateFont();
			CreateSystemObject();
			CreateUGUI();
			screenWidth = UnityEngine.Screen.width;
			screenHeight = UnityEngine.Screen.height;
			AppSpecial();
		}

		// // RVA: 0x99DBFC Offset: 0x99DBFC VA: 0x99DBFC
		public void InitializeSystem()
		{
			if(IsSystemInitialized)
				return;
			
			OnBootInitialize();
			StartCoroutine(InitializeSystemCoroutine());
		}

		// // RVA: 0x99DC34 Offset: 0x99DC34 VA: 0x99DC34
		private void OnBootInitialize()
		{
			SoundManager.Instance.Initialize();
			NKGJPJPHLIF.HHCJCDFCLOB.ODLGKIJCHGH(null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADB28 Offset: 0x6ADB28 VA: 0x6ADB28
		// // RVA: 0x99DCFC Offset: 0x99DCFC VA: 0x99DCFC
		private IEnumerator InitializeSystemCoroutine()
		{
    		UnityEngine.Debug.Log("Enter InitializeSystemCoroutine");
			//private int <>1__state; // 0x8
			//private object <>2__current; // 0xC
			//public GameManager <>4__this; // 0x10
			//0x142484C

			yield return null;
			
			Database.Instance.gameSetup.OnAppBoot();
			MessageLoader.Create();
			MessageLoader.Instance.Request(MessageLoader.eSheet.common, 0);
			yield return MessageLoader.Instance.WaitForDone(this);
			
			MessageLoader.Instance.Request(MessageLoader.eSheet.menu, 0);
			yield return MessageLoader.Instance.WaitForDone(this);
			
			while(!NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
				yield return null;

			KDLPEDBKMID.HHCJCDFCLOB.OEPPEGHGNNO = this.InstallEvent;
			NDABOOOOENC.HHCJCDFCLOB.NCDLCIPGPNC();
			IsSystemInitialized = true;
    		UnityEngine.Debug.Log("Exit InitializeSystemCoroutine");
		}

		// // RVA: 0x99DD84 Offset: 0x99DD84 VA: 0x99DD84
		public void InitializeUnionData()
		{
			if(IsUnionDataInitialized)
				return;
			StartCoroutine(UnionDataCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADBA0 Offset: 0x6ADBA0 VA: 0x6ADBA0
		// // RVA: 0x99DDB8 Offset: 0x99DDB8 VA: 0x99DDB8
		private IEnumerator UnionDataCoroutine()
		{
			//0x14281D8
			MessageLoader.Instance.defaultInstallSource = MessageLoader.InstallSource.LocalStorage;
			yield return AssetBundleManager.LoadUnionAssetBundle("handmade/shader.xab");
			Shader.WarmupAllShaders();
			yield return AssetBundleManager.LoadUnionAssetBundle("handmade/cmnparam.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle("ct/sc/ef.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle("dc/cmn.xab");
			yield return UnionTextureManager.LoadUnionTexture();
			yield return uguiCommonManager.Load();
			if(!FacialNameDatabase.isInitialized)
			{
				AssetBundleLoadAssetOperation bootAssetOperation = AssetBundleManager.LoadAssetAsync("bt.xab", "facial_name_list", typeof(TextAsset));
				yield return bootAssetOperation;
				FacialNameDatabase.Create(bootAssetOperation.GetAsset<TextAsset>());
				AssetBundleManager.UnloadAssetBundle("bt.xab");
			}

			UnityEngine.Debug.LogError("TODO finish UnionDataCoroutine (Tips / Sns");

			IsUnionDataInitialized = true;
		}

		// // RVA: 0x99CDA8 Offset: 0x99CDA8 VA: 0x99CDA8
		private void AppSpecial()
		{
			screenSizeType = XeApp.Core.Q.B();
			UnityEngine.Debug.Log("SetupResolution:screenSizeType="+screenSizeType);
			float w = 0;
			float h = 0;
			if(screenSizeType == 0)
			{
				if(!SystemManager.isLongScreenDevice)
				{
					UnityEngine.Debug.Log("SetupResolution:AppEnv");
					w = 1184; // 0x44940000
					h = 792;// 0x44460000
				}
				else
				{
					UnityEngine.Debug.Log("SetupResolution:AppEnv");
					w = 1184; // 0x44940000
					h = 664;// 0x44260000
				}
			}
			else
			{
				UnityEngine.Debug.Log("SetupResolution:XGA");
				w = bx[screenSizeType - 1];
				h = by[screenSizeType - 1];
			}
			SetupResolution(w, h);
			UnityEngine.Screen.autorotateToLandscapeLeft = true;
			UnityEngine.Screen.autorotateToLandscapeRight = true;
			UnityEngine.Screen.autorotateToPortrait = false;
			UnityEngine.Screen.autorotateToPortraitUpsideDown = false;
			UnityEngine.Screen.orientation = ScreenOrientation.AutoRotation;
			UnityEngine.QualitySettings.vSyncCount = 0;
			UnityEngine.Application.targetFrameRate = 60;
			GHNFIINGIGM.HKICMNAACDA();
			if(localSave == null)
			{
				localSave = new ILDKBCLAFPB(AFEHLCGHAEE.IEGHKKJJMHI, AFEHLCGHAEE.HBMPOOCGNEN);
				localSave.PCODDPDFLHK();
			}
			if(!divaResource)
			{
				GameObject d = new GameObject("DivaResource", typeof(DivaResource));
				d.transform.SetParent(this.transform);
				divaResource = d.GetComponent<DivaResource>();
			}
			for(int i = 0; i < 4; i++)
			{
				if(subDivaResource[i] == null)
				{
					GameObject sd = new GameObject("SubDivaResource_"+i, typeof(DivaResource));
					sd.transform.SetParent(this.transform);
					subDivaResource[i] = sd.GetComponent<DivaResource>();
				}
			}
			if(iconDecorationCache == null)
			{
				iconDecorationCache = new LayoutPoolManager(gameObject);
				iconDecorationCache.Initialize(this, GetSystemFont());
			}
			sceneIconTextureCache = new SceneIconTextureCache();
			menuResidentTextureCache = new MenuResidentTextureCache();
			divaIconTextureCache = new DivaIconTextureCache();
			bgTextureCache = new BgTextureCache();
			itemTextureCache = new ItemTextureCache();
			musicJacketTextureCache = new MusicJacketTextureCache();
			valkyrieIconTextureCache = new ValkyrieIconTextureCache();
			costumeTextureCache = new CostumeTextureCache();
			eventBannerTextureCache = new EventBannerTextureCache();
			pilotTextureCache = new PilotTextureCache();
			questEventTextureCache = new QuestEventTextureCache();
			snsIconCache = new SNSTextureCache();
			episodeIconCache = new EpisodeTextuteCache();
			gachaProductIconCache = new GachaProductTextureCache();
			denomIconCache = new DenomIconTextureCache();
			m_storyImageCache = new StoryImageTextureCache();
			musicRatioTextureCache = new MusicRatioTextureCache();
			m_subPlateIconCache = new SubPlateIconTextureCache();
			m_lobbyTextureCache = new LobbyTextureCache();
			m_decorationItemTextureCache = new DecorationItemTextureCache();
			m_raidBossTextureCache = new RaidBossTextureCache();
			m_kiraDivaTextureCache = new KiraDivaTextureCache();
			m_homeBgIconTextureCache = new HomeBgIconBgTextureCache();
			if(SystemManager.isLongScreenDevice)
			{
				LongScreenFrameInstance = UnityEngine.Object.Instantiate<GameObject>(longScreenFramePrefab);
				LongScreenFrameInstance.transform.SetParent(systemLayoutCanvas.transform.GetChild(0), false);
				LongScreenFrameInstance.transform.SetAsLastSibling();
				LongScreenFrame = LongScreenFrameInstance.GetComponent<LongScreenFrame>();
				LetterBox.gameObject.SetActive(false);
			}
		}

		// // RVA: 0x99E7FC Offset: 0x99E7FC VA: 0x99E7FC
		public void SetDispLongScreenFrame(bool isShow)
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.SetDispLongScreenFrame");
		}

		// // RVA: 0x99E908 Offset: 0x99E908 VA: 0x99E908
		// public void SetLongScreenFrameColor(int colorNo) { }

		// // RVA: 0x99EA40 Offset: 0x99EA40 VA: 0x99EA40
		// public void ResetResetLetterBox() { }

		// // RVA: 0x99EB70 Offset: 0x99EB70 VA: 0x99EB70
		private void ReInitScreen()
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.ReInitScreen");
		}

		// // RVA: 0x99F2B4 Offset: 0x99F2B4 VA: 0x99F2B4
		public void UpdateInputArea(bool isAr)
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.UpdateInputArea");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADC18 Offset: 0x6ADC18 VA: 0x6ADC18
		// // RVA: 0x99F6C8 Offset: 0x99F6C8 VA: 0x99F6C8
		public IEnumerator Co_CacheAppResources()
		{
			UnityEngine.Debug.LogError("TODO Co_CacheAppResources");
			IsCacheActive = true;
			yield break;
		}

		// // RVA: 0x99B318 Offset: 0x99B318 VA: 0x99B318
		private void SetupAssetBundleBasePath()
		{
			string k = KEHOJEJMGLJ.OGCDNCDMLCA_PersistentDataPath;
			string platform = AssetBundleManager.GetPlatformName();
			string path = Path.Combine(k, platform);
			AssetBundleManager.BaseAssetBundleInstallPath = path;
			string cp = CriWare.Common.streamingAssetsPath;
			AssetBundleManager.StreamingAssetBundlePath = Path.Combine(cp, platform);
		}

		// // RVA: 0x99DE40 Offset: 0x99DE40 VA: 0x99DE40
		public void SetupResolution(float baseWidth, float baseHeight)
		{
			UnityEngine.Debug.LogWarning("TODO SetupResolution");
		}

		// // RVA: 0x99F750 Offset: 0x99F750 VA: 0x99F750
		// public void ReSetupResolution(float baseWidth, float baseHeight) { }

		// // RVA: 0x99FB5C Offset: 0x99FB5C VA: 0x99FB5C
		public void RevertResolution()
		{
			UnityEngine.Debug.LogWarning("TODO GameMAnager.RevertResolution()");
		}

		// // RVA: 0x99FF14 Offset: 0x99FF14 VA: 0x99FF14
		public void SetupResolutionDefault()
		{
			UnityEngine.Debug.LogWarning("TODO SetupResolutionDefault");
		}

		// // RVA: 0x9A0068 Offset: 0x9A0068 VA: 0x9A0068
		// public void SetupResolutionInGame() { }

		// // RVA: 0x99E7D4 Offset: 0x99E7D4 VA: 0x99E7D4
		public void SetFPS(int fps)
		{
			UnityEngine.QualitySettings.vSyncCount = 0;
			UnityEngine.Application.targetFrameRate = fps;
		}

		// // RVA: 0x9A01BC Offset: 0x9A01BC VA: 0x9A01BC
		// public void SetRunInBackground(bool permit) { }

		// // RVA: 0x9A01C8 Offset: 0x9A01C8 VA: 0x9A01C8
		public void SetNeverSleep(bool enable)
		{
			UnityEngine.Debug.LogWarning("TODO GameManager SetNeverSleep");
		}

		// // RVA: 0x9A01DC Offset: 0x9A01DC VA: 0x9A01DC
		// public void SetTimeScale(float time) { }

		// // RVA: 0x99B6C4 Offset: 0x99B6C4 VA: 0x99B6C4
		private void CreateSystemObject()
		{
			GameObject go = UnityEngine.Object.Instantiate<GameObject>(touchEffectPrefab);
			m_touchParticle = go.GetComponent<TouchParticle>();
			m_touchParticle.Camera = systemCanvasCamera;
			go.transform.SetParent(transform, false);
			m_layoutObjectCache = go.AddComponent<MenuLayoutGameObjectCahce>();
			SetTouchEffectVisible(false);
		}

		// // RVA: 0x99B84C Offset: 0x99B84C VA: 0x99B84C
		private void CreateUGUI()
		{
			GameObject eventGo = new GameObject("EventSystem");
			UnityEngine.Object.DontDestroyOnLoad(eventGo);
			EventSystem es = eventGo.AddComponent<EventSystem>();
			eventGo.AddComponent<StandaloneInputModule>();

			eventSystemController = new EventSystemControl();
			eventSystemController.Init(es);
			
			GameObject fade = new GameObject("Canvas-Fade");
			fade.transform.SetParent(transform, false);
			fadeCanvas = fade.AddComponent<Canvas>();
			fadeCanvas.pixelPerfect = false;
			fadeCanvas.sortingOrder = 0;
			fadeCanvas.planeDistance = 5.0f;
			CanvasScaler fcs = fade.AddComponent<CanvasScaler>();
			fcs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			fcs.referenceResolution = SystemManager.BaseScreenSize;
			fcs.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			fcs.referencePixelsPerUnit = 100;
			GraphicRaycaster gr = fade.AddComponent<GraphicRaycaster>();
			gr.ignoreReversedGraphics = true;
			gr.blockingObjects = 0;
			fadeCanvas.worldCamera = systemCanvasCamera;
			fadeCanvas.renderMode = RenderMode.ScreenSpaceCamera;
			fadeCanvas.sortingLayerName = "SystemUI";

			UGUIFader fader = UnityEngine.Object.Instantiate<UGUIFader>(faderPrefab);
			fader.transform.SetParent(fadeCanvas.transform, false);
			fader.Fade(0, Color.black);
			fullscreenFader = fader;

			ChangeLayerWithChild(fade, LayerMask.NameToLayer("Fade"));
			fade.SetActive(true);

			GameObject popup = new GameObject("Canvas-Popup");
			popup.transform.SetParent(transform, false);
			GameObject root = new GameObject("Root");
			root.transform.SetParent(popup.transform, false);
			popupCanvas = popup.AddComponent<Canvas>();
			popup.AddComponent<FlexibleCanvasLayoutChanger>();

			LayoutElement le = popup.GetComponent<LayoutElement>();
			CanvasScaler pcs = popup.GetComponent<CanvasScaler>();

			RectTransform rt = root.AddComponent<RectTransform>();
			GraphicRaycaster pgrc = popup.AddComponent<GraphicRaycaster>();
			
			popupCanvas.pixelPerfect = false;
			popupCanvas.sortingOrder = 1;
			popupCanvas.worldCamera = systemCanvasCamera;
			popupCanvas.renderMode = RenderMode.ScreenSpaceCamera;
			popupCanvas.sortingLayerName = "SystemUI";
			popupCanvas.planeDistance = 5;

			rt.sizeDelta = SystemManager.BaseScreenSize;
			le.minWidth = SystemManager.BaseScreenSize.x;
			le.minHeight = SystemManager.BaseScreenSize.y;

			pcs.referenceResolution = SystemManager.BaseScreenSize;
			pcs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			pcs.referenceResolution = SystemManager.BaseScreenSize;
			pcs.screenMatchMode = CanvasScaler.ScreenMatchMode.Shrink;
			pcs.referencePixelsPerUnit = 100;

			for(int i = 0; i < 4; i++)
			{
				GameObject popupGo = UnityEngine.Object.Instantiate<GameObject>(popupPrefab);
				popupGo.transform.SetParent(root.transform, false);
			}
			ChangeLayerWithChild(popup, LayerMask.NameToLayer("Fade"));

			GameObject canvasSystemGo = new GameObject("Canvas-System");
			canvasSystemGo.transform.SetParent(transform, false);
			systemLayoutCanvas = canvasSystemGo.AddComponent<Canvas>();
			systemLayoutCanvas.pixelPerfect = false;
			systemLayoutCanvas.sortingOrder = 2;
			systemLayoutCanvas.sortingLayerName = "SystemUI";
			systemLayoutCanvas.planeDistance = 5;

			root = new GameObject("Root");
			canvasSystemGo.AddComponent<FlexibleCanvasLayoutChanger>();
			le = canvasSystemGo.AddComponent<LayoutElement>();
			CanvasScaler cs = canvasSystemGo.AddComponent<CanvasScaler>();

			rt = root.AddComponent<RectTransform>();
			rt.SetParent(systemLayoutCanvas.transform,false);
			cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			cs.referenceResolution = SystemManager.BaseScreenSize;
			cs.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			cs.referencePixelsPerUnit = 100;
			le.minWidth = SystemManager.BaseScreenSize.x;
			le.minHeight = SystemManager.BaseScreenSize.y;
			gr = canvasSystemGo.AddComponent<GraphicRaycaster>();
			gr.ignoreReversedGraphics = true;
			gr.blockingObjects = 0;
			systemLayoutCanvas.worldCamera = systemCanvasCamera;
			systemLayoutCanvas.renderMode = RenderMode.ScreenSpaceCamera;
			
			transmissionIcon = UnityEngine.Object.Instantiate<GameObject>(transmissionIconPrefab);
			transmissionIcon.transform.SetParent(root.transform, false);
			transmissionIcon.SetActive(true);

			GameObject dlbar = UnityEngine.Object.Instantiate<GameObject>(downloadBarPrefab);
			DownloadBar = dlbar.AddComponent<UIDownloadWait>();
			dlbar.transform.SetParent(rt, false);

			GameObject progressBar = UnityEngine.Object.Instantiate<GameObject>(progressBarPrefab);
			ProgressBar = progressBar.AddComponent<UILoadProgress>();
			progressBar.transform.SetParent(rt, false);

			GameObject nowLoadingGo = UnityEngine.Object.Instantiate<GameObject>(nowloadingPrefab);
			nowLoadingGo.transform.SetParent(rt, false);
			nowloading = nowLoadingGo.AddComponent<UILoadWait>();

			LetterBox = UnityEngine.Object.Instantiate<UGUILetterBoxController>(letterboxPrefab);
			DontDestroyOnLoad(LetterBox);

			LetterBox.transform.SetParent(systemLayoutCanvas.transform, false);

			if(SystemManager.IsForceWideScreen)
			{
				Vector3 scale = nowloading.transform.localScale;
				scale.x *= 0.8409091f;
				scale.y *= 0.8409091f;
				nowloading.transform.localScale = scale;

				scale = DownloadBar.transform.localScale;
				scale.x *= 0.8409091f;
				scale.y *= 0.8409091f;
				DownloadBar.transform.localScale = scale;

				scale = transmissionIcon.transform.localScale;
				scale.x *= 0.8409091f;
				scale.y *= 0.8409091f;
				transmissionIcon.transform.localScale = scale;
			}

			ChangeLayerWithChild(canvasSystemGo, LayerMask.NameToLayer("Fade"));
			ChangePopupPriority(false);
		}

		// // RVA: 0x9A0628 Offset: 0x9A0628 VA: 0x9A0628
		public bool IsInitializedSystemLayout()
		{
			if(isBootInitialized)
			{
				if(PopupWindowManager.IsReady())
				{
					if(nowloading.IsInitialized)
					{
						if(!DownloadBar.gameObject.activeSelf)
						{
							return !transmissionIcon.activeSelf;
						}
					}
				}
			}
			return false;
		}

		// // RVA: 0x9A0758 Offset: 0x9A0758 VA: 0x9A0758
		public void ResetSystemCanvasCamera()
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.ResetSystemCanvasCamera");
		}

		// // RVA: 0x99B4B0 Offset: 0x99B4B0 VA: 0x99B4B0
		private void CreateFont()
		{
			if (fontManagerPrefab == null)
				return;
			Object obj = Utility.SearchGameObjectRecursively("Font", transform);
			if (obj != null)
				return;
			font = Object.Instantiate<FontManager>(fontManagerPrefab);
			DontDestroyOnLoad(font);
			font.name = "Font";
			font.transform.SetParent(transform, false);
		}

		// // RVA: 0x98060C Offset: 0x98060C VA: 0x98060C
		public static void FadeIn(float time = 0.4f)
		{
			if(GameManager.Instance.fullscreenFader != null)
			{
				GameManager.Instance.fullscreenFader.Fade(time, Color.clear);
			}
		}

		// // RVA: 0x9809CC Offset: 0x9809CC VA: 0x9809CC
		public static void FadeOut(float time = 0.4f)
		{
			if(GameManager.Instance.fullscreenFader != null)
			{
				GameManager.Instance.fullscreenFader.Fade(time, Color.black);
			}
		}

		// // RVA: 0x97FDB0 Offset: 0x97FDB0 VA: 0x97FDB0
		public static bool IsFading()
		{
			if(GameManager.Instance.fullscreenFader != null)
			{
				return GameManager.Instance.fullscreenFader.isFading;
			}
			return false;
		}

		// // RVA: 0x9A0808 Offset: 0x9A0808 VA: 0x9A0808
		// public static void FadeReset() { }

		// // RVA: 0x9A08E0 Offset: 0x9A08E0 VA: 0x9A08E0
		// public void ShowSnsNotice(int snsId, UnityAction pushAction, bool isButtonEnable = True) { }

		// // RVA: 0x9A09FC Offset: 0x9A09FC VA: 0x9A09FC
		public void CloseSnsNotice()
		{
			UnityEngine.Debug.LogWarning("TODO GameManager CloseSnsNotice");
		}

		// // RVA: 0x9A0AB0 Offset: 0x9A0AB0 VA: 0x9A0AB0
		// public void ShowOfferNotice(UnityAction pushAction, bool isButtonEnable = True) { }

		// // RVA: 0x9A0BB8 Offset: 0x9A0BB8 VA: 0x9A0BB8
		// public void CloseOfferNotice() { }

		// // RVA: 0x9A040C Offset: 0x9A040C VA: 0x9A040C
		public void ChangePopupPriority(bool popupTop)
		{
			int maxLayer = Mathf.Max(popupCanvas.sortingOrder, Mathf.Max(fadeCanvas.sortingOrder, systemLayoutCanvas.sortingOrder));
			int minLayer = Mathf.Min(popupCanvas.sortingOrder, Mathf.Min(fadeCanvas.sortingOrder, systemLayoutCanvas.sortingOrder));

			if(popupCanvas.sortingOrder < fadeCanvas.sortingOrder)
			{
				if(!popupTop)
					return;
				popupCanvas.sortingOrder = maxLayer + 0x31;
				systemLayoutCanvas.sortingOrder =  maxLayer + 0x32;
				fadeCanvas.sortingOrder = minLayer + 0x32;
			}
			else
			{
				if(popupTop)
					return;
				popupCanvas.sortingOrder = minLayer + 0x32;
				systemLayoutCanvas.sortingOrder = minLayer + 0x33;
				fadeCanvas.sortingOrder = maxLayer + 0x32;
			}
		}

		// // RVA: 0x9A0314 Offset: 0x9A0314 VA: 0x9A0314
		private void ChangeLayerWithChild(GameObject go, int layer)
		{
			go.layer = layer;
			for(int i = 0; i < go.transform.childCount; i++)
			{
				ChangeLayerWithChild(go.transform.GetChild(i).gameObject, layer);
			}
		}

		// // RVA: 0x9A0294 Offset: 0x9A0294 VA: 0x9A0294
		public void SetTouchEffectVisible(bool isVisible)
		{
			UnityEngine.Debug.LogWarning("TODO SetTouchEffectVisible");
		}

		// // RVA: 0x9A0C6C Offset: 0x9A0C6C VA: 0x9A0C6C
		public void SetTouchEffectMode(bool isRhythmGame)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x9A0CA0 Offset: 0x9A0CA0 VA: 0x9A0CA0
		public void SetSystemCanvasRenderMode(RenderMode mode)
		{
			return;
		}

		// // RVA: 0x9A0CA4 Offset: 0x9A0CA4 VA: 0x9A0CA4
		public void SetSystemCanvasResolution(Vector2 resolution)
		{
			systemLayoutCanvas.GetComponent<CanvasScaler>().referenceResolution = resolution;
		}

		// // RVA: 0x99B14C Offset: 0x99B14C VA: 0x99B14C
		public Font GetSystemFont()
		{
			return font.GetFontInfo(3).font;
		}

		// // RVA: 0x9A0D4C Offset: 0x9A0D4C VA: 0x9A0D4C
		public void CreateViewPlayerData()
		{
			if(m_viewPlayerData == null)
				m_viewPlayerData = new DFKGGBMFFGB();
			m_viewPlayerData.KHEKNNFCAOI_Init(null, false);
			UnityEngine.Debug.LogError("TODO CreateViewPlayerData");
			//JKIJLMMLNPL.DJNPDEOLNHD();
		}

		// // RVA: 0x98874C Offset: 0x98874C VA: 0x98874C
		public void ResetViewPlayerData()
		{
			UnityEngine.Debug.LogError("TODO ResetViewPlayerData");
			//tmp
			CreateViewPlayerData();
		}

		// // RVA: 0x9A0DF8 Offset: 0x9A0DF8 VA: 0x9A0DF8
		// public void DeleteViewPlayerData() { }

		// // RVA: 0x9A0E04 Offset: 0x9A0E04 VA: 0x9A0E04
		// public FFHPBEPOMAK GetHomeDiva() { }

		// // RVA: 0x9A0F5C Offset: 0x9A0F5C VA: 0x9A0F5C
		// public Camera GetSystemCanvasCamera() { }

		// // RVA: 0x9A0F64 Offset: 0x9A0F64 VA: 0x9A0F64
		// public void InstantiateCbtWindow() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6ADC90 Offset: 0x6ADC90 VA: 0x6ADC90
		// // RVA: 0x9A1004 Offset: 0x9A1004 VA: 0x9A1004
		// public IEnumerator InstantiateCbtWindowCoroutine() { }

		// [SkipAttribute] // RVA: 0x6ADD08 Offset: 0x6ADD08 VA: 0x6ADD08
		// // RVA: 0x9A108C Offset: 0x9A108C VA: 0x9A108C
		// public void OnSetLaunchURL(string url) { }

		// [SkipAttribute] // RVA: 0x6ADD18 Offset: 0x6ADD18 VA: 0x6ADD18
		// // RVA: 0x9A111C Offset: 0x9A111C VA: 0x9A111C
		// public void OnSetLaunchURLWithFOX(string url) { }

		// [SkipAttribute] // RVA: 0x6ADD28 Offset: 0x6ADD28 VA: 0x6ADD28
		// // RVA: 0x9A11AC Offset: 0x9A11AC VA: 0x9A11AC
		// public void OnSetDecoURL(string url) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6ADD38 Offset: 0x6ADD38 VA: 0x6ADD38
		// // RVA: 0x9A1230 Offset: 0x9A1230 VA: 0x9A1230
		// private IEnumerator LoadGameIntroCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6ADDB0 Offset: 0x6ADDB0 VA: 0x6ADDB0
		// // RVA: 0x9A12B8 Offset: 0x9A12B8 VA: 0x9A12B8
		public IEnumerator ShowGameIntroCoroutine()
		{
			UnityEngine.Debug.LogError("TODO ShowGameIntroCoroutine");
			yield break;
		}

		// // RVA: 0x9A1340 Offset: 0x9A1340 VA: 0x9A1340
		// public void CleanCacheAssetBundle() { }

		// // RVA: 0x9A1348 Offset: 0x9A1348 VA: 0x9A1348
		public bool InstallEvent(int type, float per)
		{
			UnityEngine.Debug.LogError("TODO");
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADE28 Offset: 0x6ADE28 VA: 0x6ADE28
		// // RVA: 0x9A1478 Offset: 0x9A1478 VA: 0x9A1478
		public IEnumerator TryInstallRhythmGameResource(GameSetupData gameSetupData)
		{
			UnityEngine.Debug.LogError("TODO TryInstallRhythmGameResource");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADEA0 Offset: 0x6ADEA0 VA: 0x6ADEA0
		// // RVA: 0x9A1500 Offset: 0x9A1500 VA: 0x9A1500
		// public IEnumerator ListupRhythmGameResourceFileList(int divaId, int divaModelId, int valkyrieId, int valkyrieFormType, int freeMusicId, int storyMusicId, Difficulty.Type difficulty, List<string> list, int stageDivaNum) { }

		// // RVA: 0x9A165C Offset: 0x9A165C VA: 0x9A165C
		public string GetWavDirectoryName(int wavId, string format, int stageDivaNum, int primeId = 1, int assetId = -1, bool isNoFindSoloChange = true)
		{
			//? format
			StringBuilder sb = new StringBuilder();
			if(stageDivaNum == 1)
			{
				sb.SetFormat("{0:D4}",wavId);
			}
			else
			{
				sb.SetFormat("{0:D4}_{1}",wavId, stageDivaNum);
			}
			return sb.ToString();
		}

		// // RVA: 0x9A17B4 Offset: 0x9A17B4 VA: 0x9A17B4
		public int GetMultipleDanceOverridePrimeId(List<int> primeIdList)
		{
			int res = primeIdList[0];
			for(int i = 0; i < primeIdList.Count; i++)
			{
				if(primeIdList[i] == 2)
				{
					res = 2;
					break;
				}
			}
			return res;
		}

		// // RVA: 0x9A1948 Offset: 0x9A1948 VA: 0x9A1948
		// public bool IsMultipleOverridePrimeId(int primeId) { }

		// // RVA: 0x9A1958 Offset: 0x9A1958 VA: 0x9A1958
		public void SetTransmissionIconPosition(bool isARMode)
		{
			UnityEngine.Debug.LogWarning("TODO GameManager.SetTransmissionIconPosition()");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6ADF18 Offset: 0x6ADF18 VA: 0x6ADF18
		// // RVA: 0x9A1D00 Offset: 0x9A1D00 VA: 0x9A1D00
		// private void <LoadGameIntroCoroutine>b__299_0(GameObject instance) { }
	}
}
