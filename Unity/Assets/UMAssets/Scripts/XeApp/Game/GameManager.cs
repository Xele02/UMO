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
using XeApp.Game.Tutorial;

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
		private DFKGGBMFFGB_PlayerInfo m_viewPlayerData; // 0x7C
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
		public UnityAction<float> UpdateAction; // 0x140
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
		public DFKGGBMFFGB_PlayerInfo ViewPlayerData { get { return m_viewPlayerData; } } // get_ViewPlayerData 0x989990
		public EAJCBFGKKFA_FriendInfo SelectedGuestData { get; set; } // 0x80
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
		public bool InputEnabled { get { return eventSystemController.InputEnabled; } set { eventSystemController.InputEnabled = value; } } // 0x999F0C 0x999F38 
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
		public void DeleteIntro()
		{
			Destroy(m_intro.gameObject);
			m_intro = null;
		}

		// // RVA: 0x9888B0 Offset: 0x9888B0 VA: 0x9888B0
		public void AddPushBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			m_pushBackButtonHandlerList.Insert(0, handler);
		}

		// // RVA: 0x99A334 Offset: 0x99A334 VA: 0x99A334
		public void AddLastBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			m_pushBackButtonHandlerList.Add(handler);
		}

		// // RVA: 0x988E80 Offset: 0x988E80 VA: 0x988E80
		public void RemovePushBackButtonHandler(GameManager.PushBackButtonHandler handler)
		{
			m_pushBackButtonHandlerList.Remove(handler);
		}

		// // RVA: 0x98B534 Offset: 0x98B534 VA: 0x98B534
		public void ClearPushBackButtonHandler()
		{
			m_pushBackButtonHandlerList.Clear();
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
			//0x1428C74
			m_layoutObjectCache.ReleaseAll();
			BgControl.ForceDestoryTexture();
			sceneIconTextureCache.Terminated();
			menuResidentTextureCache.Terminated();
			divaIconTextureCache.Terminated();
			bgTextureCache.Terminated();
			itemTextureCache.Terminated();
			musicJacketTextureCache.Terminated();
			valkyrieIconTextureCache.Terminated();
			costumeTextureCache.Terminated();
			eventBannerTextureCache.Terminated();
			pilotTextureCache.Terminated();
			questEventTextureCache.Terminated();
			snsIconCache.Terminated();
			episodeIconCache.Terminated();
			gachaProductIconCache.Terminated();
			denomIconCache.Terminated();
			m_storyImageCache.Terminated();
			musicRatioTextureCache.Terminated();
			m_subPlateIconCache.Terminated();
			m_lobbyTextureCache.Terminated();
			m_decorationItemTextureCache.Terminated();
			m_raidBossTextureCache.Terminated();
			m_kiraDivaTextureCache.Terminated();
			m_homeBgIconTextureCache.Terminated();
			unionTextureManager.Release();
			uguiCommonManager.Release();
			IsUnionDataInitialized = false;
			TipsControl.Instance.Release();
			if(BasicTutorialManager.HasInstanced)
			{
				BasicTutorialManager.Instance.Release();
			}
			if(TutorialManager.HasInstanced)
			{
				TutorialManager.Instance.Release();
			}
			if(divaResource != null)
			{
				divaResource.ReleaseAll();
			}
			for(int i = 0; i < subDivaResource.Length; i++)
			{
				if (subDivaResource[i] != null)
					subDivaResource[i].ReleaseAll();
			}
			iconDecorationCache.Release();
			FacialNameDatabase.Release();
			if(m_snsNotification != null)
			{
				Destroy(m_snsNotification.gameObject);
				m_snsNotification = null;
			}
			yield return Co.R(AssetBundleManager.UnloadAllAssetBundle());
			yield return Resources.UnloadUnusedAssets();
			IsCacheActive = false;

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
#if UNITY_ANDROID
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
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADAB0 Offset: 0x6ADAB0 VA: 0x6ADAB0
		// // RVA: 0x99AC90 Offset: 0x99AC90 VA: 0x99AC90
		// private IEnumerator Co_ReInitScreen() { }

		// // RVA: 0x99AD18 Offset: 0x99AD18 VA: 0x99AD18
		private void Start()
		{
			this.StartCoroutineWatched(Co_InitScreen());
		}

		// // RVA: 0x99AD3C Offset: 0x99AD3C VA: 0x99AD3C
		private void OnDestroy()
		{
			Font.textureRebuilt -= OnFontTextureRebuilt;
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
			if(font.name == GetSystemFont().font.name)
				isDirtyFontUpdate = true;
		}

		// // RVA: 0x99B194 Offset: 0x99B194 VA: 0x99B194
		private void LateUpdate()
		{
			if(isDirtyFontUpdate)
				isDirtyFontUpdate = false;
			if(UpdateAction != null)
			{
				m_sceneIconAnimeTime += TimeWrapper.deltaTime;
				UpdateAction(m_sceneIconAnimeTime);
			}
		}

		// // RVA: 0x99B250 Offset: 0x99B250 VA: 0x99B250
		public void OnPushBackButton()
		{
			if (m_pushBackButtonHandlerList.IsEmpty())
				return;
			m_pushBackButtonHandlerList[0].Invoke();
		}

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
			this.StartCoroutineWatched(InitializeSystemCoroutine());
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
			NDABOOOOENC.HHCJCDFCLOB.NCDLCIPGPNC_Login();
			IsSystemInitialized = true;
		}

		// // RVA: 0x99DD84 Offset: 0x99DD84 VA: 0x99DD84
		public void InitializeUnionData()
		{
			if(IsUnionDataInitialized)
				return;
			this.StartCoroutineWatched(UnionDataCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADBA0 Offset: 0x6ADBA0 VA: 0x6ADBA0
		// // RVA: 0x99DDB8 Offset: 0x99DDB8 VA: 0x99DDB8
		private IEnumerator UnionDataCoroutine()
		{
			//0x14281D8
			MessageLoader.Instance.defaultInstallSource = MessageLoader.InstallSource.LocalStorage;
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("handmade/shader.xab"));
			Shader.WarmupAllShaders();
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("handmade/cmnparam.xab"));
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("ct/sc/ef.xab"));
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("dc/cmn.xab"));
			yield return Co.R(UnionTextureManager.LoadUnionTexture());
			yield return Co.R(uguiCommonManager.Load());
			if(!FacialNameDatabase.isInitialized)
			{
				AssetBundleLoadAssetOperation bootAssetOperation = AssetBundleManager.LoadAssetAsync("bt.xab", "facial_name_list", typeof(TextAsset));
				yield return Co.R(bootAssetOperation);
				FacialNameDatabase.Create(bootAssetOperation.GetAsset<TextAsset>());
				AssetBundleManager.UnloadAssetBundle("bt.xab");
			}
			TipsControl tips = TipsControl.Instance;
			GameObject root = GameObject.Find("Canvas-Popup");
			tips.transform.SetParent(root.transform.GetChild(0), false);
			tips.LoadResource();
			tips.transform.SetAsFirstSibling();
			while (!tips.IsInitialized)
				yield return null;
			AssetBundleLoadAssetOperation op = AssetBundleManager.LoadAssetAsync("ly/094.xab", "SnsNotification", typeof(GameObject));
			yield return op;
			m_snsNotification = Instantiate(op.GetAsset<GameObject>()).GetComponent<SnsNotification>();
			m_snsNotification.transform.SetParent(root.transform.GetChild(0), false);
			m_snsNotification.transform.SetAsLastSibling();
			yield return this.StartCoroutineWatched(m_snsNotification.LoadLayout());
			m_snsNotification.gameObject.SetActive(false);
			AssetBundleManager.UnloadAssetBundle("ly/094.xab", false);
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
				localSave = new ILDKBCLAFPB(AFEHLCGHAEE_Strings.IEGHKKJJMHI_SaveCipherPass, AFEHLCGHAEE_Strings.HBMPOOCGNEN_SaveCipherSalt);
				localSave.PCODDPDFLHK_Load();
			}
			if(!divaResource)
			{
				GameObject d = new GameObject("DivaResource", typeof(DivaResource));
				d.transform.SetParent(this.transform, false);
				divaResource = d.GetComponent<DivaResource>();
			}
			for(int i = 0; i < 4; i++)
			{
				if(subDivaResource[i] == null)
				{
					GameObject sd = new GameObject("SubDivaResource_"+i, typeof(DivaResource));
					sd.transform.SetParent(this.transform, false);
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
			if(SystemManager.isLongScreenDevice)
			{
				if(LongScreenFrameInstance != null)
				{
					LongScreenFrameInstance.SetActive(isShow);
				}
			}
		}

		// // RVA: 0x99E908 Offset: 0x99E908 VA: 0x99E908
		public void SetLongScreenFrameColor(int colorNo)
		{
			if(SystemManager.isLongScreenDevice)
			{
				if(SystemManager.HasSafeArea)
				{
					if(LongScreenFrame != null)
					{
						LongScreenFrame.SetFrameSprite(colorNo);
					}
				}
			}
		}

		// // RVA: 0x99EA40 Offset: 0x99EA40 VA: 0x99EA40
		public void ResetResetLetterBox()
		{
			if(SystemManager.isLongScreenDevice)
			{
				if(!SystemManager.HasSafeArea)
				{
					if(LongScreenFrame != null)
					{
						LongScreenFrame.ReasetLetterBox();
					}
				}
			}
		}

		// // RVA: 0x99EB70 Offset: 0x99EB70 VA: 0x99EB70
		private void ReInitScreen()
		{
			Rect r = XeSafeArea.GetRect();
			SystemManager.rawSafeAreaRect = r;
			Rect r2 = XeSafeArea.GetScreenArea();
			SystemManager.rawScreenAreaRect = r2;
			SystemManager.Instance.UpdateScreenSize();
			SystemManager.rawAppScreenRect = new Rect(0, 0, Screen.width, Screen.height);
			screenSizeType = Q.B();
			Debug.Log("SetupResolution:screenSizeType=" + screenSizeType);
			float baseWidth;
			float baseHeight;
			if (screenSizeType == 0)
			{
				if(!SystemManager.isLongScreenDevice)
				{
					Debug.Log("SetupResolution:AppEnv");
					baseWidth = 1184;
					baseHeight = 792;
				}
				else
				{
					Debug.Log("SetupResolution:AppEnv");
					baseWidth = 1184;
					baseHeight = 666;
				}
			}
			else
			{
				Debug.Log("SetupResolution:XGA");
				baseWidth = bx[screenSizeType - 1];
				baseHeight = by[screenSizeType - 1];
			}
			SetupResolution(baseWidth, baseHeight);
			UpdateInputArea(false);
			if(systemLayoutCanvas != null)
			{
				FlexibleCanvasLayoutChanger fl = systemLayoutCanvas.gameObject.GetComponent<FlexibleCanvasLayoutChanger>();
				if(fl != null)
				{
					fl.UpdateForLongScreenDevice();
					fl.CanvasScalerModeCheck();
				}
			}
			if(popupCanvas != null)
			{
				FlexibleCanvasLayoutChanger fl = systemLayoutCanvas.gameObject.GetComponent<FlexibleCanvasLayoutChanger>();
				if (fl != null)
				{
					fl.UpdateForLongScreenDevice();
					fl.CanvasScalerModeCheck();
				}
			}
			if (SystemManager.isLongScreenDevice)
			{
				if(SystemManager.HasSafeArea)
				{
					SetLongScreenFrameColor(localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.HLABNEIEJPM_SafeAreaDesign);
				}
				else
				{
					ResetResetLetterBox();
				}
			}
		}

		// // RVA: 0x99F2B4 Offset: 0x99F2B4 VA: 0x99F2B4
		public void UpdateInputArea(bool isAr)
		{
			if(isAr)
			{
				SystemManager.rawAppScreenRect = new Rect(0, 0, AppResolutionWidth, AppResolutionHeight);
			}
			else
			{
				if(!SystemManager.isLongScreenDevice)
				{
					SystemManager.rawAppScreenRect = new Rect(0, 0, AppResolutionWidth, AppResolutionHeight);
				}
				else
				{
					if(SystemManager.HasSafeArea)
					{
						Rect safe = XeSafeArea.GetRect();
						float safeWidth169 = safe.height * 16.0f / 9.0f;
						float marginX = (safe.width - safeWidth169) * 0.5f;
						SystemManager.rawAppScreenRect = new Rect(
							AppResolutionWidth / SystemManager.rawScreenAreaRect.width * (marginX + safe.x), 
							AppResolutionHeight / SystemManager.rawScreenAreaRect.height * safe.y, 
							safeWidth169 * AppResolutionWidth / SystemManager.rawScreenAreaRect.width, 
							AppResolutionHeight / SystemManager.rawScreenAreaRect.height * SystemManager.rawSafeAreaRect.height);
					}
					else
					{
						SystemManager.rawAppScreenRect = new Rect(0, 0, Screen.width, Screen.height);
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADC18 Offset: 0x6ADC18 VA: 0x6ADC18
		// // RVA: 0x99F6C8 Offset: 0x99F6C8 VA: 0x99F6C8
		public IEnumerator Co_CacheAppResources()
		{
			//0x1423ECC
			if (IsCacheActive)
				yield break;
			this.StartCoroutineWatched(SceneIconCache.Initialize());
			this.StartCoroutineWatched(DivaIconCache.EntryLoadingTexture());
			MenuResidentTextureCache.EntryCache();
			MusicRatioTextureCache.EntryCache();
			IconDecorationCache.Reserve();
			while (SceneIconCache.IsLoading())
				yield return null;
			while (MenuResidentTextureCache.IsLoading())
				yield return null;
			while(DivaIconCache.IsLoading())
				yield return null;
			while (!IconDecorationCache.IsReady())
				yield return null;
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
			float nativeX = SystemManager.NativeScreenSize.x;
			float nativeY = SystemManager.NativeScreenSize.y;
			float sX = nativeX;
			if(SystemManager.isLongScreenDevice)
			{
				sX = nativeY * 16.0f / 9.0f;
			}
			float d0, d1;
			if (SystemManager.rawSafeAreaRect.y <= 0)
			{
				d0 = baseHeight;
				if(SystemManager.isLongScreenDevice)
				{
					d1 = baseHeight / nativeY;
					d0 /= nativeY;
				}
				else
				{
					if (1 - nativeY / baseHeight < 1 - sX / baseWidth)
						d0 = baseHeight / nativeY;
					else
						d0 = baseWidth / sX;
					d1 = d0;
				}
			}
			else
			{
				if(!SystemManager.isLongScreenDevice)
				{
					if (1 - nativeY / baseHeight < 1 - sX / baseWidth)
						d0 = baseHeight / nativeY;
					else
						d0 = baseWidth / sX;
					d1 = d0;
				}
				else
				{
					d0 = (SystemManager.rawSafeAreaRect.y * baseHeight) / (SystemManager.rawScreenAreaRect.height - SystemManager.rawSafeAreaRect.y) + baseHeight;
					d0 /= nativeY;
					d1 = baseHeight / nativeY;
				}
			}
			// not sure of those 2 min
			float r2 = Mathf.Min(d1, 1);
			float r = Mathf.Min(d0, 1);
			float width = Mathf.RoundToInt(sX * r);
			float height = Mathf.RoundToInt(nativeY * r);
			SystemManager.longScreenReferenceResolution = new Vector2(sX * r2, nativeY * r2);
			if (SystemManager.isLongScreenDevice)
				width = nativeX * height / nativeY;
			ResolutionWidth = SystemManager.NativeScreenSize.x;
			ResolutionHeight = SystemManager.NativeScreenSize.y;
			object[] obj = new object[5];
			obj[0] = "Screen.SetResolution(";
			obj[1] = width;
			obj[2] = ",";
			obj[3] = height;
			obj[4] = ") start";
			Debug.Log(string.Concat(obj));
			Screen.SetResolution(Mathf.RoundToInt(width), Mathf.RoundToInt(height), true);
			obj = new object[5];
			obj[0] = "Screen.SetResolution(";
			obj[1] = width;
			obj[2] = ",";
			obj[3] = height;
			obj[4] = ") end";
			Debug.Log(string.Concat(obj));
			SystemManager.longScreenSizeWithSafeArea = new Vector2(width, height);
			AppResolutionWidth = width;
			AppResolutionHeight = height;
			ResetResetLetterBox();
		}

		// // RVA: 0x99F750 Offset: 0x99F750 VA: 0x99F750
		// public void ReSetupResolution(float baseWidth, float baseHeight) { }

		// // RVA: 0x99FB5C Offset: 0x99FB5C VA: 0x99FB5C
		public void RevertResolution()
		{
			Resolution res = Screen.currentResolution;
			float x = AppResolutionWidth;
			float y = AppResolutionHeight;
			if (x < y)
			{
				AppResolutionWidth = y;
				AppResolutionHeight = x;
			}
			if (AppResolutionWidth == res.width && AppResolutionHeight == res.height)
			{
				// Nothing
			}
			else
			{
				object[] obj = new object[5];
				obj[0] = "ReSetupResolution(";
				obj[1] = AppResolutionWidth;
				obj[2] = ",";
				obj[3] = AppResolutionHeight;
				obj[4] = ")";
				Debug.Log(string.Concat(obj));
				Screen.SetResolution((int)AppResolutionWidth, (int)AppResolutionHeight, true);
			}
			UpdateInputArea(false);
			ResetResetLetterBox();
		}

		// // RVA: 0x99FF14 Offset: 0x99FF14 VA: 0x99FF14
		public void SetupResolutionDefault()
		{
			if (Q.B() == screenSizeType)
				return;
			screenSizeType = Q.B();
			if (screenSizeType > 0 && screenSizeType <= bx.Length)
				SetupResolution(bx[screenSizeType - 1], by[screenSizeType - 1]);
		}

		// // RVA: 0x9A0068 Offset: 0x9A0068 VA: 0x9A0068
		// public void SetupResolutionInGame() { }

		// // RVA: 0x99E7D4 Offset: 0x99E7D4 VA: 0x99E7D4
		public void SetFPS(int fps)
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = fps;
		}

		// // RVA: 0x9A01BC Offset: 0x9A01BC VA: 0x9A01BC
		// public void SetRunInBackground(bool permit) { }

		// // RVA: 0x9A01C8 Offset: 0x9A01C8 VA: 0x9A01C8
		public void SetNeverSleep(bool enable)
		{
			Screen.sleepTimeout = enable ? -1 : -2;
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
			le = canvasSystemGo.GetComponent<LayoutElement>();
			CanvasScaler cs = canvasSystemGo.GetComponent<CanvasScaler>();

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
			systemCanvasCamera.orthographicSize = 5;
			systemCanvasCamera.nearClipPlane = 0.3f;
			systemCanvasCamera.farClipPlane = 1000;
			systemCanvasCamera.depth = 99;
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
		public static void FadeReset()
		{
			GameManager.Instance.fullscreenFader.Fade(0, Color.clear);
		}

		// // RVA: 0x9A08E0 Offset: 0x9A08E0 VA: 0x9A08E0
		public void ShowSnsNotice(int snsId, UnityAction pushAction, bool isButtonEnable = true)
		{
			if(m_snsNotification != null)
			{
				m_snsNotification.gameObject.SetActive(true);
				m_snsNotification.Show(snsId, pushAction, isButtonEnable);
			}
		}

		// // RVA: 0x9A09FC Offset: 0x9A09FC VA: 0x9A09FC
		public void CloseSnsNotice()
		{
			if(m_snsNotification != null)
			{
				m_snsNotification.Close();
			}
		}

		// // RVA: 0x9A0AB0 Offset: 0x9A0AB0 VA: 0x9A0AB0
		public void ShowOfferNotice(UnityAction pushAction, bool isButtonEnable = true)
		{
			if(m_snsNotification != null)
			{
				m_snsNotification.gameObject.SetActive(true);
				m_snsNotification.ShowOffer(pushAction, isButtonEnable);
			}
		}

		// // RVA: 0x9A0BB8 Offset: 0x9A0BB8 VA: 0x9A0BB8
		public void CloseOfferNotice()
		{
			if(m_snsNotification != null)
			{
				m_snsNotification.Close();
			}
		}

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
			if (!isVisible)
				m_touchParticle.Stop();
			m_touchParticle.gameObject.SetActive(isVisible);
		}

		// // RVA: 0x9A0C6C Offset: 0x9A0C6C VA: 0x9A0C6C
		public void SetTouchEffectMode(bool isRhythmGame)
		{
			m_touchParticle.SetTouchEffectMode(isRhythmGame);
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
		public FontInfo GetSystemFont(bool def = false)
		{
			if(!def && RuntimeSettings.CurrentSettings.Language == "zh_Hans" && RuntimeSettings.CurrentSettings.UseChineseFont)
				return font.GetFontInfo(4);
			else
				return font.GetFontInfo(3);
		}

		public float GetFontLineSpace(float lineSpace)
		{
			return GetSystemFont().GetLineSpace(lineSpace);
		}

		public FontInfo GetFontInfo(Font font)
		{
			FontInfo def = GetSystemFont(true);
			if(def.font == font)
			{
				return GetSystemFont();
			}
			def = new FontInfo();
			def.font = font;
			def.size = 1;
			return def;
		}

		// // RVA: 0x9A0D4C Offset: 0x9A0D4C VA: 0x9A0D4C
		public void CreateViewPlayerData()
		{
			if(m_viewPlayerData == null)
				m_viewPlayerData = new DFKGGBMFFGB_PlayerInfo();
			m_viewPlayerData.KHEKNNFCAOI_Init(null, false);
			JKIJLMMLNPL.DJNPDEOLNHD_UpdateMacrossCannonPower();
		}

		// // RVA: 0x98874C Offset: 0x98874C VA: 0x98874C
		public void ResetViewPlayerData()
		{
			if (m_viewPlayerData == null)
				return;
			m_viewPlayerData.KHEKNNFCAOI_Init(null, false);
			JKIJLMMLNPL.DJNPDEOLNHD_UpdateMacrossCannonPower();
		}

		// // RVA: 0x9A0DF8 Offset: 0x9A0DF8 VA: 0x9A0DF8
		// public void DeleteViewPlayerData() { }

		// // RVA: 0x9A0E04 Offset: 0x9A0E04 VA: 0x9A0E04
		public FFHPBEPOMAK_DivaInfo GetHomeDiva()
		{
			FFHPBEPOMAK_DivaInfo res = m_viewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
			if(localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId > 0)
			{
				res = m_viewPlayerData.NBIGLBMHEDC_Divas[localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId - 1];
			}
			return res;
		}

		// // RVA: 0x9A0F5C Offset: 0x9A0F5C VA: 0x9A0F5C
		public Camera GetSystemCanvasCamera()
		{
			return systemCanvasCamera;
		}

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
		private IEnumerator LoadGameIntroCoroutine()
		{
			AssetBundleLoadLayoutOperationBase layOperation;

			//0x14262B8
			if(m_intro == null)
			{
				layOperation = AssetBundleManager.LoadLayoutAsync("ly/062.xab", "UI_GameIntro");
				yield return Co.R(layOperation);
				yield return Co.R(layOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x9A1D00
					m_intro = instance.GetComponent<GameUIIntro>();
					instance.transform.SetParent(popupCanvas.transform, false);
					instance.transform.SetAsFirstSibling();
				}));
				AssetBundleManager.UnloadAssetBundle("ly/062.xab", false);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADDB0 Offset: 0x6ADDB0 VA: 0x6ADDB0
		// // RVA: 0x9A12B8 Offset: 0x9A12B8 VA: 0x9A12B8
		public IEnumerator ShowGameIntroCoroutine()
		{
			//0x14265E4
			yield return this.StartCoroutineWatched(LoadGameIntroCoroutine());
			GameManager.Instance.NowLoading.Show();
			SoundManager.Instance.bgmPlayer.Stop();
			bool isWait = false;
			yield return Co.R(Instance.LoadGameIntroCoroutine());
			Instance.GameUIIntro.onAnimationEndCallback = () =>
			{
				//0x1423DDC
				isWait = false;
				Instance.GameUIIntro.onAnimationEndCallback = null;
			};
			isWait = true;
			Instance.GameUIIntro.Enter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(Database.Instance.gameSetup.musicInfo.prismMusicId).KNMGEEFGDNI_Nam, Database.Instance.gameSetup.musicInfo.musicLoadText);
			while (isWait)
				yield return null;
		}

		// // RVA: 0x9A1340 Offset: 0x9A1340 VA: 0x9A1340
		// public void CleanCacheAssetBundle() { }

		// // RVA: 0x9A1348 Offset: 0x9A1348 VA: 0x9A1348
		public bool InstallEvent(int type, float per)
		{
			switch(type)
			{
				case 1:
					DownloadBar.HighResolutionModeFlag = false;
					DownloadBar.Begin();
				break;
				case 2:
					DownloadBar.SetPer(per);
					if(onDownLoadFinish != null)
						onDownLoadFinish();
					DownloadBar.End();
				break;
				case 3:
					DownloadBar.SetPer(per);
					break;
				case 4:
					return DownloadBar.IsReady;
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADE28 Offset: 0x6ADE28 VA: 0x6ADE28
		// // RVA: 0x9A1478 Offset: 0x9A1478 VA: 0x9A1478
		public IEnumerator TryInstallRhythmGameResource(GameSetupData gameSetupData)
		{
			GameSetupData setupData; // 0x14
			GameSetupData.TeamInfo ti; // 0x18
			GameSetupData.MusicInfo mi; // 0x1C
			OKGLGHCBCJP_Database master; // 0x20
			EONOEHOKBEB_Music musicBase; // 0x24
			int wavId; // 0x28
			StringBuilder bundleName; // 0x2C
			StringBuilder assetName; // 0x30
			AssetBundleLoadAssetOperation operation; // 0x34
			MusicDirectionParamBase directionParam; // 0x38

			//0x1426BDC
			setupData = gameSetupData;
			ti = setupData.teamInfo;
			mi = setupData.musicInfo;
			master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
			musicBase = master.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(mi.prismMusicId);
			wavId = musicBase.KKPAHLMJKIH_WavId;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			string waveName = GameManager.Instance.GetWavDirectoryName(wavId, "mc/{0}/sc.xab", mi.onStageDivaNum, 1, -1, true);
			bundleName.SetFormat("mc/{0}/sc.xab", waveName);
			assetName.SetFormat("p_{0:D4}", wavId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(MusicDirectionParamBase));
			yield return Co.R(operation);
			directionParam = operation.GetAsset<MusicDirectionParamBase>();
			assetName.SetFormat("bp_{0:D4}", wavId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(MusicDirectionBoolParam));
			yield return Co.R(operation);
			directionParam.BoolParam = operation.GetAsset<MusicDirectionBoolParam>();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);

			//master.MGFMPKLLGHE_Diva.GCINIJEMHFK(ti.divaList[0].prismDivaId).IDDHKOEFJFB;
			int a = 0;
			if(mi.isFreeMode)
			{
				a = master.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(mi.freeMusicId).KEFGPJBKAOD_WavId;
			}
			else
			{
				a = master.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(mi.storyMusicId).KEFGPJBKAOD_WavId;
			}
			PNGOLKLFFLH b = new PNGOLKLFFLH();
			b.KHEKNNFCAOI_Init(ti.prismValkyrieId, ti.valkyrieForm, 0);
			int vidQuality = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				vidQuality = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			List<MusicDirectionParamBase.ConditionSetting> settingList = new List<MusicDirectionParamBase.ConditionSetting>();
			for(int i = 0; i < mi.onStageDivaNum; i++)
			{
				MusicDirectionParamBase.ConditionSetting cond = new MusicDirectionParamBase.ConditionSetting();
				cond.divaId = ti.danceDivaList[i].prismDivaId;
				cond.costumeModelId = ti.danceDivaList[i].prismCostumeModelId;
				cond.valkyrieId = ti.prismValkyrieId;
				cond.pilotId = b.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId;
				cond.positionId = ti.danceDivaList[i].positionId;
				settingList.Add(cond);
			}
			List<int> l = new List<int>();
			for (int i = 0; i < mi.onStageDivaNum; i++)
			{
				l.Add(master.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(ti.danceDivaList[i].prismDivaId).IDDHKOEFJFB_BodyId);
			}
			int c = GameManager.Instance.GetMultipleDanceOverridePrimeId(l);
			int basaraPos = directionParam.basaraPositionId;
			int otherPos = 0;
			if (mi.onStageDivaNum > 1)
			{
				for(int i = 0; i < mi.onStageDivaNum; i++)
				{
					if(settingList[i].divaId == 9)
					{
						if (settingList[i].positionId == basaraPos)
							break;
						otherPos = settingList[i].positionId;
						settingList[i].positionId = basaraPos;
					}
				}
				if(otherPos != 0)
				{
					for (int i = 0; i < mi.onStageDivaNum; i++)
					{
						if (settingList[i].divaId != 9 && settingList[i].positionId == basaraPos)
						{
							settingList[i].positionId = otherPos;
						}
					}
				}
			}
			List<int>[] res = directionParam.GetSpecialDirectionResourceId(settingList);
			KDLPEDBKMID.HHCJCDFCLOB.KEILLGAJEPF_AddRhythmResources(wavId, c, a, res[1], res[2], res[4], res[0], res[3], res[8], vidQuality, res[9], mi.onStageDivaNum);
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6ADEA0 Offset: 0x6ADEA0 VA: 0x6ADEA0
		// // RVA: 0x9A1500 Offset: 0x9A1500 VA: 0x9A1500
		public IEnumerator ListupRhythmGameResourceFileList(int divaId, int divaModelId, int valkyrieId, int valkyrieFormType, int freeMusicId, int storyMusicId, Difficulty.Type difficulty, List<string> list, int stageDivaNum)
		{
			OKGLGHCBCJP_Database master; // 0x34
			bool isFreeMode; // 0x38
			MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo enemyInfo; // 0x3C
			EONOEHOKBEB_Music musicBase; // 0x40
			int wavId; // 0x44
			StringBuilder bundleName; // 0x48
			StringBuilder assetName; // 0x4C
			AssetBundleLoadAssetOperation operation; // 0x50
			MusicDirectionParamBase directionParam; // 0x54

			//0x1425060
			master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
			enemyInfo = null;
			isFreeMode = freeMusicId > 0;
			if(freeMusicId < 1)
			{
				if(storyMusicId > 0)
				{
					DJNPIGEFPMF_StoryMusicInfo mData = master.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(storyMusicId);
					enemyInfo = master.OPFBEAJJMJB_Enemy.INONDJKKOKG(mData.LHICAKGHIGF[(int)difficulty]);
					musicBase = master.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(mData.DLAEJOBELBH_Id);
				}
				musicBase = master.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(0);
			}
			else
			{
				KEODKEGFDLD_FreeMusicInfo fData = master.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(freeMusicId);
				enemyInfo = master.OPFBEAJJMJB_Enemy.INONDJKKOKG(fData.LHICAKGHIGF_EnemyIdByDiff[(int)difficulty]);
				musicBase = master.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fData.DLAEJOBELBH_MusicId);
			}
			wavId = musicBase.KKPAHLMJKIH_WavId;
			bundleName = new StringBuilder();
			assetName = new StringBuilder();
			bundleName.SetFormat("mc/{0}/sc.xab", Instance.GetWavDirectoryName(wavId, "mc/{0}/sc.xab", stageDivaNum, 1, -1, true));
			assetName.SetFormat("p_{0:D4}", wavId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(MusicDirectionParamBase));
			yield return operation;
			directionParam = operation.GetAsset<MusicDirectionParamBase>();
			assetName.SetFormat("bp_{0:D4}", wavId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(MusicDirectionBoolParam));
			yield return operation;
			directionParam.BoolParam = operation.GetAsset<MusicDirectionBoolParam>();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			int bodyDiva = master.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(divaId).IDDHKOEFJFB_BodyId;
			int a;
			if (!isFreeMode)
			{
				a = master.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(storyMusicId).KEFGPJBKAOD_WavId;
			}
			else
			{
				a = master.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(freeMusicId).KEFGPJBKAOD_WavId;
			}
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(valkyrieId, valkyrieFormType, 0);
			int pilotId = p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId;
			int videoQuality = 0;
			if (Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				videoQuality = Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			List<MusicDirectionParamBase.ConditionSetting> setting = new List<MusicDirectionParamBase.ConditionSetting>();
			for(int i = 0; i < stageDivaNum; i++)
			{
				MusicDirectionParamBase.ConditionSetting cond = new MusicDirectionParamBase.ConditionSetting(0, 0, 0, 0, 0);
				cond.divaId = divaId;
				cond.pilotId = pilotId;
				cond.costumeModelId = divaModelId;
				cond.valkyrieId = valkyrieId;
				cond.positionId = i + 1;
				setting.Add(cond);
			}
			List<int>[] l = directionParam.GetSpecialDirectionResourceId(setting);
			list.Add(string.Format("ct/pl/{0:D3}.xab", pilotId));
			list.Add(string.Format("vl/{0:D4}.xab", valkyrieId));
			list.Add(string.Format("ct/em/pl/{0:D3}.xab", enemyInfo.EELBHDJJJHH_Plt));
			list.Add(string.Format("ct/em/mh/{0:D3}.xab", enemyInfo.EAHPLCJMPHD_Pic));
			list.Add(string.Format("dv/cs/{0:D3}_{1:D3}.xab", divaId, divaModelId));
			list.Add(string.Format("dv/bs/{0:D3}_{1:D3}.xab", divaId, divaModelId));
			list.Add(string.Format("ct/dv/ps/{0:D2}_{1:D2}.xab", divaId, divaModelId));
			KDLPEDBKMID.HHCJCDFCLOB.IDCJNAFJLAA(wavId, bodyDiva, a, l[1], l[2], l[4], l[0], l[3], l[8], videoQuality, l[9], list, stageDivaNum);
		}

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
			if(transmissionIcon != null)
			{
				Vector2 pos = transmissionIcon.GetComponent<RectTransform>().anchoredPosition;
				Vector2 pos2 = pos;
				if (isARMode)
				{
					pos = new Vector2(0, -150);
				}
				else
				{
					pos = Vector2.zero;
				}
				transmissionIcon.GetComponent<RectTransform>().anchoredPosition = pos;
				transmissionIcon.GetComponent<RectTransform>().anchoredPosition = pos2;
			}
		}
	}
}
