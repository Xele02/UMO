using XeApp.Core;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using System.Collections;
using XeApp.Game.Common;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class MenuScene : MainSceneBase
	{
		public struct MenuSceneCamebackInfo
		{
			public enum Flags
			{
				None = 0,
				RetryGame = 1,
				ReturnScene = 2,
				GotoTitle = 3,
				Adventure = 4,
			}

			public enum CamBackUnityScene
			{
				None = 0,
				Adv = 1,
			}

			public SceneGroupCategory category; // 0x0
			public TransitionList.Type nextName; // 0x4
			public TransitionList.Type parentName; // 0x8
			public TransitionUniqueId uniqueId; // 0xC
			public TransitionArgs args; // 0x10
			public MenuScene.MenuSceneCamebackInfo.Flags flags; // 0x14
			public bool isDivaActive; // 0x18
			public MenuScene.MenuSceneCamebackInfo.CamBackUnityScene camBackUnityScene; // 0x1C

			// // RVA: 0x7FAAF8 Offset: 0x7FAAF8 VA: 0x7FAAF8
			// public void Initialize() { }

			// // RVA: 0x7FAB24 Offset: 0x7FAB24 VA: 0x7FAB24
			// public bool IsRetryGame() { }

			// // RVA: 0x7FAB34 Offset: 0x7FAB34 VA: 0x7FAB34
			// public bool IsReturnScene() { }

			// // RVA: 0x7FAB48 Offset: 0x7FAB48 VA: 0x7FAB48
			// public bool IsGotoTitle() { }

			// // RVA: 0x7FAB5C Offset: 0x7FAB5C VA: 0x7FAB5C
			// public bool IsAdventure() { }
		}

		public const float FADE_TIME = 0.4f;
		[SerializeField]
		private TransitionTreeObject treeObject; // 0x28
		// private static SceneStack m_menuSceneStack = new SceneStack(); // 0x8
		public const string titleSceneName = "Title";
		public const string gameSceneName = "RhythmGame";
		public const string gameSkipSceneName = "RhythmGameSkip";
		public const string downLoadSceneName = "DownLoad";
		private const string bunchDownLoadSceneName = "BunchDownLoad";
		private const string gachaDirectionSceneName = "GachaDirection";
		private const string adjustSceneName = "RhythmAdjust";
		private const string prologueSceneName = "Prologue";
		private const string nameEntrySceneName = "NameEntry";
		private const string advSceneName = "Adv";
		private const string miniSceneName = "MiniGame";
		private const float BgmFadeOutSec = 0.3f;
		private bool m_isInitializeing; // 0x30
		private bool m_isChangedCueSheet; // 0x31
		private bool m_isSceneEnter; // 0x32
		private bool m_isInTransition; // 0x33
		private int m_inputDisableCount; // 0x34
		private int m_raycastDisableCount; // 0x38
		public GameObject m_bgRootObject; // 0x3C
		public GameObject m_uiRootObject; // 0x40
		private GraphicRaycaster m_uiRaycaster; // 0x44
		public Font m_font; // 0x48
		private TransitionRoot.MenuTransitionControl m_menuTransitionControl; // 0x4C
		private StatusWindowControl m_statusWindowControl; // 0x50
		private SortWindowControl m_sortWindowControl; // 0x54
		private PopupFilterSortWindowControl m_popupFilterSortWindowContrl; // 0x58
		private IFBCGCCJBHI m_playerStatusData; // 0x5C
		private UnitPopupWindowControl m_unitSaveWindowControl; // 0x60
		private MusicPopupWindowControl m_musicPopupWindowControl; // 0x64
		private HelpPopupWindowControl m_helpPopupWindowControl; // 0x68
		private LimitOverControl m_limitOverControl; // 0x6C
		private IntimacyController m_intimacyControl; // 0x70
		// private PopupItemList.PopupItemListSetting m_popupItemListSetting = new PopupItemList.PopupItemListSetting(); // 0x74
		// private PopupItemDetail.PopupItemDetailSetting m_popupItemDetailSettinig = new PopupItemDetail.PopupItemDetailSetting(); // 0x78
		private PopupUseItemWindow m_popupUseItemWindow; // 0x7C
		private PopupDetailCostumeSetting m_popupDetailCostumeSetting = new PopupDetailCostumeSetting(); // 0x80
		private HomeLobbyButtonController m_lobbyButtonControl; // 0x84
		// private FlexibleLayoutCamera _flexibleLayoutCamera; // 0x88
		private DenominationManager m_denomControl; // 0x8C
		// private long m_enterToHomeTime; // 0x90
		private MenuSceneUpdater MenuUpdater; // 0x98
		private MenuScene.MenuSceneCamebackInfo m_sceneCamebackInfo; // 0x9C

		public static MenuScene Instance { get; private set; } // 0x0
		public static bool IsAlreadyHome { get; set; } // 0x4
		public static bool IsFirstTitleFlow { get; set; } // 0x5
		public static bool ComebackByRestart { get; private set; } // 0x6
		// public MenuDivaManager divaManager { get; set; } // 0x2C
		// public SceneIconTextureCache SceneIconCache { get; } 0xB2DCF8
		// public DivaIconTextureCache DivaIconCache { get; } 0xB2DD94
		// public BgTextureCache BgTextureCache { get; } 0xB2DE30
		// public ItemTextureCache ItemTextureCache { get; } 0xB2DECC
		// public MenuResidentTextureCache MenuResidentTextureCache { get; } 0xB2DF68
		// public MusicJacketTextureCache MusicJacketTextureCache { get; } 0xB2E004
		// public UnitPopupWindowControl UnitSaveWindowControl { get; } 0xB2E0A0
		// public StatusWindowControl StatusWindowControl { get; } 0xB2E0A8
		// public MusicPopupWindowControl MusicPopupWindowControl { get; } 0xB2E0B0
		// public HelpPopupWindowControl HelpPopupWindowControl { get; } 0xB2E0B8
		// public LimitOverControl LimitOverControl { get; } 0xB2E0C0
		// public IntimacyController IntimacyControl { get; } 0xB2E0C8
		// public PopupUseItemWindow PopupUseItemWindow { get; } 0xB2E0D0
		// public ValkyrieIconTextureCache ValkyrieIconCache { get; } 0xB2E0D8
		// public CostumeTextureCache CostumeIconCache { get; } 0xB2E174
		// public QuestEventTextureCache QuestEventCache { get; } 0xB2E210
		// public SNSTextureCache SnsIconCache { get; } 0xB2E2AC
		// public EpisodeTextuteCache EpisodeIconCache { get; } 0xB2E348
		// public StoryImageTextureCache StoryImageCache { get; } 0xB2E3E4
		// public SubPlateIconTextureCache SubPlateIconTextureCahe { get; } 0xB2E480
		// public DecorationItemTextureCache DecorationItemTextureCache { get; } 0xB2E51C
		// public HomeBgIconBgTextureCache HomeBgIconTextureCache { get; } 0xB2E5B8
		// public BgControl BgControl { get; } 0xB2E654
		// public MenuHeaderControl HeaderMenu { get; } 0xB2E680
		// public MenuFooterControl FooterMenu { get; } 0xB2E6AC
		public HelpButton HelpButton { get { return m_menuTransitionControl.HelpButton; } } //0xB2E6D8
		// public bool DirtyChangeScene { get; } 0xB2E704
		// public HomeLobbyButtonController LobbyButtonControl { get; } 0xB2E730
		// public FlexibleLayoutCamera FlexibleLayoutCamera { get; } 0xB2E738
		// public DenominationManager DenomControl { get; } 0xB2AB9C
		// public long EnterToHomeTime { get; } 0xB2E7EC

		// // RVA: 0xB2E7F4 Offset: 0xB2E7F4 VA: 0xB2E7F4 Slot: 9
		protected override void DoAwake()
		{
			GameManager.Instance.SetFPS(30);
			enableFade = false;
			MenuScene.Instance = this;
			MenuUpdater = gameObject.AddComponent<MenuSceneUpdater>();
			m_uiRaycaster = m_uiRootObject.GetComponentInParent<GraphicRaycaster>();
			PausableBehaviour.isPause = false;
		}

		// // RVA: 0xB2E990 Offset: 0xB2E990 VA: 0xB2E990 Slot: 10
		protected override void DoStart()
		{
			m_menuTransitionControl = new TransitionRoot.MenuTransitionControl(m_bgRootObject, m_uiRootObject, m_font, treeObject);
			m_statusWindowControl = new StatusWindowControl();
			m_sortWindowControl = new SortWindowControl();
			m_popupFilterSortWindowContrl = new PopupFilterSortWindowControl();
			m_unitSaveWindowControl = new UnitPopupWindowControl();
			m_musicPopupWindowControl = new MusicPopupWindowControl();
			m_musicPopupWindowControl.Initialize(transform);
			m_helpPopupWindowControl = new HelpPopupWindowControl();
			m_helpPopupWindowControl.Initialize(transform);
			m_limitOverControl = new LimitOverControl();
			m_intimacyControl = gameObject.AddComponent<IntimacyController>();
			m_denomControl = DenominationManager.Create(transform);
			m_popupUseItemWindow = new PopupUseItemWindow();
			m_popupUseItemWindow.Initialize();
			m_lobbyButtonControl = gameObject.AddComponent<HomeLobbyButtonController>();
			m_popupDetailCostumeSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_05");
			m_popupDetailCostumeSetting.SetParent(transform);
			m_popupDetailCostumeSetting.WindowSize = 0;
			m_popupDetailCostumeSetting.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			m_isChangedCueSheet = false;
			SoundManager.Instance.RequestEntryMenuCueSheet(() => {
				//0xB37CBC
				m_isChangedCueSheet = true;
			});
			m_menuTransitionControl.ChangeGroupCategoryListener += this.ChangeGroupCategory;
			GameManager.Instance.SetSystemCanvasRenderMode(RenderMode.ScreenSpaceCamera);
			m_sceneCamebackInfo.uniqueId = 0;
			m_sceneCamebackInfo.flags = 0;
			m_sceneCamebackInfo.nextName = TransitionList.Type.UNDEFINED;
			m_sceneCamebackInfo.parentName = TransitionList.Type.UNDEFINED;
			m_sceneCamebackInfo.camBackUnityScene = 0;
			m_sceneCamebackInfo.args = null;
			m_sceneCamebackInfo.isDivaActive = false;
			m_sceneCamebackInfo.category = SceneGroupCategory.UNDEFINED;
			MakeComebackSceneInfo(ref m_sceneCamebackInfo);
			GameManager.Instance.NowLoading.Show();
			int numTips = 0;
			if(m_menuTransitionControl.CanShowTips(TransitionList.Type.UNDEFINED, m_sceneCamebackInfo.nextName, m_sceneCamebackInfo.camBackUnityScene, out numTips))
			{
				TipsControl.Instance.Show(numTips);
			}
			StartCoroutine(InitializeCoroutine());
		}

		// // RVA: 0xB305FC Offset: 0xB305FC VA: 0xB305FC Slot: 12
		protected override bool DoUpdateEnter()
		{
			if(!m_isInitializeing && m_isChangedCueSheet)
			{
				if(m_isSceneEnter)
					return false;
				MenuUpdater.updater = () => {
					//0xB37CC8
					if(m_menuTransitionControl.DirtyChangeScene && m_isInTransition)
					{
						Debug.Log("transition requested but in transition");
					}
					if(m_menuTransitionControl.DirtyChangeScene && !m_isInTransition)
					{
						StartCoroutine(ChangeTransitionCoroutine());
						m_playerStatusData.FBANBDCOEJL();
						m_menuTransitionControl.ApplyPlayerStatus(m_playerStatusData);
					}
				};
				return true;
			}
			return false;
		}

		// // RVA: 0xB306D8 Offset: 0xB306D8 VA: 0xB306D8
		// public static float GetLongScreenScale() { }

		// // RVA: 0xB2F0E0 Offset: 0xB2F0E0 VA: 0xB2F0E0
		private void MakeComebackSceneInfo(ref MenuScene.MenuSceneCamebackInfo info)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xB307F0 Offset: 0xB307F0 VA: 0xB307F0 Slot: 13
		protected override void DoUpdateMain()
		{
			base.DoUpdateMain();
		}

		// // RVA: 0xB307F8 Offset: 0xB307F8 VA: 0xB307F8
		// private void MenuObservationChengeScene() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7834 Offset: 0x6C7834 VA: 0x6C7834
		// // RVA: 0xB30940 Offset: 0xB30940 VA: 0xB30940
		private IEnumerator ChangeTransitionCoroutine()
		{
			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// // RVA: 0xB309EC Offset: 0xB309EC VA: 0xB309EC
		public void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C78AC Offset: 0x6C78AC VA: 0x6C78AC
		// // RVA: 0xB30570 Offset: 0xB30570 VA: 0xB30570
		private IEnumerator InitializeCoroutine()
		{
			//0xB3C09C
			m_isInitializeing = true;
			m_isSceneEnter = true;
			bool isWait = true;

			StartCoroutine(CoroutineDivaModel(() => {
				//0xB38588
				isWait = false;
			}));
			yield return StartCoroutine(CoroutineSystemResource());

			UnityEngine.Debug.LogError("TODO");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7924 Offset: 0x6C7924 VA: 0x6C7924
		// // RVA: 0xB30B5C Offset: 0xB30B5C VA: 0xB30B5C
		private IEnumerator CoroutineSystemResource()
		{
			// // RVA:  Offset: 0xB385DC VA: 0xB385DC
			// internal void <CoroutineSystemResource>b__4() { }
			
			//0xB39FF8
			int reqCount = 0;
			int loadCount = 0;
			StartCoroutine(m_menuTransitionControl.Initialize(this, () => {
				//0xB3859C
				loadCount++;
			}));
			reqCount++;
			StartCoroutine(m_statusWindowControl.Initialize(gameObject, () => {
				//0xB385AC
				loadCount++;
			}));
			reqCount++;
			StartCoroutine(m_sortWindowControl.Initialize(gameObject, () => {
				//0xB385BC
				loadCount++;
			}));
			reqCount++;
			StartCoroutine(m_popupFilterSortWindowContrl.Initialize(gameObject, () => {
				//0xB385CC
				loadCount++;
			}));
			reqCount++;
			StartCoroutine(m_unitSaveWindowControl.Initialize(gameObject, () => {
				//0xB385DC
				loadCount++;
			}));
			reqCount++;
			StartCoroutine(GameManager.Instance.Co_CacheAppResources());
			while(!GameManager.Instance.IsCacheActive)
				yield return null;
			while(loadCount != reqCount)
				yield return null;
			HelpButton.HelpButtonListener += this.OnShowHelpPopup;
			m_menuTransitionControl.MenuFooter.Initialize();
			if(!GameManager.Instance.IsTutorial)
			{
				StartCoroutine(m_lobbyButtonControl.Co_LoadLayout(m_uiRootObject));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C799C Offset: 0x6C799C VA: 0x6C799C
		// // RVA: 0xB30C08 Offset: 0xB30C08 VA: 0xB30C08
		private IEnumerator CoroutineDivaModel(UnityAction finish)
		{
			// private DivaResource.MenuFacialType <divaFacialType>5__2; // 0x18
			// private int <divaId>5__3; // 0x1C
			// private int <modelId>5__4; // 0x20
			// private int <colorId>5__5; // 0x24
			// private bool <isResult>5__6; // 0x28
			//0xB3980C
			UnityEngine.Debug.LogError("TODO");
			finish();
			yield break;
		}

		// // RVA: 0xB30CD0 Offset: 0xB30CD0 VA: 0xB30CD0
		// public void SetActiveDivaModel(bool active, bool isIdle = True) { }

		// // RVA: 0xB30D0C Offset: 0xB30D0C VA: 0xB30D0C
		// public void SetDivaXposition(float xpos) { }

		// // RVA: 0xB30D6C Offset: 0xB30D6C VA: 0xB30D6C Slot: 14
		protected override bool DoUpdateLeave()
		{
			UnityEngine.Debug.LogError("TODO");
			return false;
		}

		// // RVA: 0xB30E8C Offset: 0xB30E8C VA: 0xB30E8C
		// public void InitializePlayerStatusData() { }

		// // RVA: 0xB30F18 Offset: 0xB30F18 VA: 0xB30F18
		// public int GetMedalMonthId() { }

		// // RVA: 0xB30F58 Offset: 0xB30F58 VA: 0xB30F58
		// public int GetCurrentStamina() { }

		// // RVA: 0xB30F70 Offset: 0xB30F70 VA: 0xB30F70
		// public void InitAssitPlate() { }

		// // RVA: 0xB30FF4 Offset: 0xB30FF4 VA: 0xB30FF4
		// public void GotoRhythmGame(bool isSkip, int ticketCount, bool isNotUpdateProfile) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7A14 Offset: 0x6C7A14 VA: 0x6C7A14
		// // RVA: 0xB312F8 Offset: 0xB312F8 VA: 0xB312F8
		// public static IEnumerator RhythmGamePreLoad(Func<IEnumerator> wait) { }

		// // RVA: 0xB313A4 Offset: 0xB313A4 VA: 0xB313A4
		// private static int SeachLiveStartMultiVoice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7A8C Offset: 0x6C7A8C VA: 0x6C7A8C
		// // RVA: 0xB316A4 Offset: 0xB316A4 VA: 0xB316A4
		// public static IEnumerator RhythmGameStartVoicePlay() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7B04 Offset: 0x6C7B04 VA: 0x6C7B04
		// // RVA: 0xB31238 Offset: 0xB31238 VA: 0xB31238
		// private IEnumerator GotoRhythmGameCorotine(Func<IEnumerator> wait, bool isSkip = False) { }

		// // RVA: 0xB31758 Offset: 0xB31758 VA: 0xB31758
		// public void GotoAdventure(bool isExecuteSceneExit = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7B7C Offset: 0x6C7B7C VA: 0x6C7B7C
		// // RVA: 0xB318BC Offset: 0xB318BC VA: 0xB318BC
		// private IEnumerator Co_GotoAdventure(bool isExecuteSceneExit) { }

		// // RVA: 0xB31984 Offset: 0xB31984 VA: 0xB31984
		// private void GotoAdventureInner(bool isFade) { }

		// // RVA: 0xB31A00 Offset: 0xB31A00 VA: 0xB31A00
		// public void GotoMiniGame(int miniGameId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7BF4 Offset: 0x6C7BF4 VA: 0x6C7BF4
		// // RVA: 0xB31B68 Offset: 0xB31B68 VA: 0xB31B68
		// private IEnumerator Co_GotoMiniGame(int miniGameId, int stageNum = 1) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7C6C Offset: 0x6C7C6C VA: 0x6C7C6C
		// // RVA: 0xB31C48 Offset: 0xB31C48 VA: 0xB31C48
		// private IEnumerator GotoTitleCoroutine() { }

		// // RVA: 0xB2B4A8 Offset: 0xB2B4A8 VA: 0xB2B4A8
		public void GotoTitle()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xB2B620 Offset: 0xB2B620 VA: 0xB2B620
		// public void GotoLoginBonus() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7CE4 Offset: 0x6C7CE4 VA: 0x6C7CE4
		// // RVA: 0xB31CF4 Offset: 0xB31CF4 VA: 0xB31CF4
		// private IEnumerator GotoLoginBonsuCorotine() { }

		// // RVA: 0xB31DA0 Offset: 0xB31DA0 VA: 0xB31DA0
		// public void GotoGachaDirection() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7D5C Offset: 0x6C7D5C VA: 0x6C7D5C
		// // RVA: 0xB31DC4 Offset: 0xB31DC4 VA: 0xB31DC4
		// private IEnumerator GotoGachaDirectionCoroutine() { }

		// // RVA: 0xB31E70 Offset: 0xB31E70 VA: 0xB31E70
		// public void GotoNameEntry() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7DD4 Offset: 0x6C7DD4 VA: 0x6C7DD4
		// // RVA: 0xB31E94 Offset: 0xB31E94 VA: 0xB31E94
		// private IEnumerator GotoNameEntryCoroutine() { }

		// // RVA: 0xB31F40 Offset: 0xB31F40 VA: 0xB31F40
		// public void GotoBunchDownLoad() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7E4C Offset: 0x6C7E4C VA: 0x6C7E4C
		// // RVA: 0xB31F64 Offset: 0xB31F64 VA: 0xB31F64
		// private IEnumerator GotoBunchDownLoadCoroutine() { }

		// // RVA: 0xB32010 Offset: 0xB32010 VA: 0xB32010
		// public void Return(bool isFading = True) { }

		// // RVA: 0xB32044 Offset: 0xB32044 VA: 0xB32044
		// public void Call(TransitionList.Type next, TransitionArgs args, bool isFading = True) { }

		// // RVA: 0xB32094 Offset: 0xB32094 VA: 0xB32094
		// public void Mount(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = True, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0) { }

		// // RVA: 0xB320EC Offset: 0xB320EC VA: 0xB320EC
		// public void MountWithFade(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = True, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0) { }

		// // RVA: 0xB32144 Offset: 0xB32144 VA: 0xB32144
		// public GameObject GetCurrentBg() { }

		// // RVA: 0xB32170 Offset: 0xB32170 VA: 0xB32170
		// public IEnumerator ChangeBgTexture(BgTextureType textureType, int bgId) { }

		// // RVA: 0xB321DC Offset: 0xB321DC VA: 0xB321DC
		// public TransitionInfo GetCurrentScene() { }

		// // RVA: 0xB32208 Offset: 0xB32208 VA: 0xB32208
		// public TransitionRoot GetCurrentTransitionRoot() { }

		// // RVA: 0xB32234 Offset: 0xB32234 VA: 0xB32234
		// public TransitionInfo GetNextScene() { }

		// // RVA: 0xB32260 Offset: 0xB32260 VA: 0xB32260
		// public bool IsTransition() { }

		// // RVA: 0xB3228C Offset: 0xB3228C VA: 0xB3228C
		// public bool OnPushReturnButton() { }

		// // RVA: 0xB322B8 Offset: 0xB322B8 VA: 0xB322B8
		// public int GetDefaultBgmId(SceneGroupCategory category) { }

		// // RVA: 0xB2B190 Offset: 0xB2B190 VA: 0xB2B190
		// public void InputEnable() { }

		// // RVA: 0xB2AAD4 Offset: 0xB2AAD4 VA: 0xB2AAD4
		// public void InputDisable() { }

		// // RVA: 0xB322EC Offset: 0xB322EC VA: 0xB322EC
		// public void RaycastEnable() { }

		// // RVA: 0xB32338 Offset: 0xB32338 VA: 0xB32338
		// public void RaycastDisable() { }

		// // RVA: 0xB32384 Offset: 0xB32384 VA: 0xB32384
		// public void UpdateEnterToHomeTime() { }

		// // RVA: 0xB32468 Offset: 0xB32468 VA: 0xB32468
		// public void HeaderEnter() { }

		// // RVA: 0xB32500 Offset: 0xB32500 VA: 0xB32500
		// public void HeaderLeave() { }

		// // RVA: 0xB3259C Offset: 0xB3259C VA: 0xB3259C
		// public void FooterEnter() { }

		// // RVA: 0xB325D0 Offset: 0xB325D0 VA: 0xB325D0
		// public void FooterLeave() { }

		// // RVA: 0xB32604 Offset: 0xB32604 VA: 0xB32604
		// public void ShowSnsNotice(int snsId, UnityAction pushAction) { }

		// // RVA: 0xB32704 Offset: 0xB32704 VA: 0xB32704
		// public void ShowOfferNotice(UnityAction pushAction) { }

		// // RVA: 0xB327F0 Offset: 0xB327F0 VA: 0xB327F0
		// public void ShowDivaStatusPopupWindow(FFHPBEPOMAK diva, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isChangeScene = True, bool isCloseOnly = False, int divaSlotNumber = -1, bool isGoDiva = False) { }

		// // RVA: 0xB32898 Offset: 0xB32898 VA: 0xB32898
		// public void ShowFriendDivaStatusPopupWindow(EAJCBFGKKFA friendData, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isChangeScene = False) { }

		// // RVA: 0xB32938 Offset: 0xB32938 VA: 0xB32938
		// public void ShowSceneStatusPopupWindow(GCIJNCFDNON scene, DFKGGBMFFGB playerData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isFriend = False, bool isReward = False, SceneStatusParam.PageSave pageSave = 1, bool isDisableZoom = False) { }

		// // RVA: 0xB32A3C Offset: 0xB32A3C VA: 0xB32A3C
		// public void TryShowPopupWindow(TransitionRoot root, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName, Action closeCallBack) { }

		// // RVA: 0xB32BA0 Offset: 0xB32BA0 VA: 0xB32BA0
		// public void ShowSortWindow(PopupSortMenu.SortPlace place, UnityAction<PopupSortMenu> okCallBack, Action endCallBack) { }

		// // RVA: 0xB32C00 Offset: 0xB32C00 VA: 0xB32C00
		// public void ShowSortWindow(PopupSortMenu.SortPlace place, SortItem sortItem, UnityAction<PopupSortMenu> okCallBack, Action endCallBack) { }

		// // RVA: 0xB32C5C Offset: 0xB32C5C VA: 0xB32C5C
		// public void ShowSortWindow(PopupSortMenu.SortPlace place, int divaId, int attrId, UnityAction<PopupSortMenu> okCallBack, Action endCallBack) { }

		// // RVA: 0xB32CC4 Offset: 0xB32CC4 VA: 0xB32CC4
		// public void ShowSortWindow(PopupFilterSort.Scene a_type, UnityAction<PopupFilterSort> okCallBack, Action endCallBack, bool a_is_save = True) { }

		// // RVA: 0xB32D1C Offset: 0xB32D1C VA: 0xB32D1C
		// public void ShowSortWindow(PopupFilterSortInitParam a_init_param, UnityAction<PopupFilterSort> okCallBack, Action endCallBack) { }

		// // RVA: 0xB32D6C Offset: 0xB32D6C VA: 0xB32D6C
		// public void ShowSortWindow(PopupFilterSortUGUI.Scene a_type, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack, bool a_is_save = True) { }

		// // RVA: 0xB32DC4 Offset: 0xB32DC4 VA: 0xB32DC4
		// public void ShowSortWindow(PopupFilterSortUGUIInitParam a_init_param, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack) { }

		// // RVA: 0xB32E14 Offset: 0xB32E14 VA: 0xB32E14
		// public void ShowItemListWindow(PopupItemList.ItemType type, bool isTab = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7EC4 Offset: 0x6C7EC4 VA: 0x6C7EC4
		// // RVA: 0xB331B4 Offset: 0xB331B4 VA: 0xB331B4
		// private IEnumerator ShowItemListWindowCoroutine() { }

		// // RVA: 0xB33260 Offset: 0xB33260 VA: 0xB33260
		// public void ShowItemDetail(int id, int count, ButtonInfo[] buttons, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack) { }

		// // RVA: 0xB335DC Offset: 0xB335DC VA: 0xB335DC
		// public void ShowItemDetail(int id, int count, Action closeCallback) { }

		// // RVA: 0xB3394C Offset: 0xB3394C VA: 0xB3394C
		// public void ShowItemDetail(int id, int subId, int count, string name, string desc, Action closeCallback) { }

		// // RVA: 0xB33CB0 Offset: 0xB33CB0 VA: 0xB33CB0
		// public PopupWindowControl ShowItemDetail(int id, string title, string desc, bool isShop = False) { }

		// // RVA: 0xB33FA0 Offset: 0xB33FA0 VA: 0xB33FA0
		// public PopupWindowControl ShowGoDivaStatusDetail(FFHPBEPOMAK divaData, Action endCallback) { }

		// // RVA: 0xB345E4 Offset: 0xB345E4 VA: 0xB345E4
		// public PopupItemDetail.PopupItemDetailSetting CreateIconTextContent(int id, string title, SizeType size, string name, string desc, ButtonInfo[] buttons, bool isCaption = True) { }

		// // RVA: 0xB347DC Offset: 0xB347DC VA: 0xB347DC
		// public void ShowCostumeDetailWindow(CKFGMNAIBNG data, int colorId = 0) { }

		// // RVA: 0xB348F4 Offset: 0xB348F4 VA: 0xB348F4
		// public void ShowAutoCombined() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7F3C Offset: 0x6C7F3C VA: 0x6C7F3C
		// // RVA: 0xB34C48 Offset: 0xB34C48 VA: 0xB34C48
		// public IEnumerator ShowPosterReleaseWindowCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7FB4 Offset: 0x6C7FB4 VA: 0x6C7FB4
		// // RVA: 0xB34CF4 Offset: 0xB34CF4 VA: 0xB34CF4
		// public IEnumerator ShowKiraSceneReleaseWindowCoroutine(bool isUnlockDeco) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C802C Offset: 0x6C802C VA: 0x6C802C
		// // RVA: 0xB34DBC Offset: 0xB34DBC VA: 0xB34DBC
		// public IEnumerator ShowGetDecoItemWindow(int id) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C80A4 Offset: 0x6C80A4 VA: 0x6C80A4
		// // RVA: 0xB34E68 Offset: 0xB34E68 VA: 0xB34E68
		// public IEnumerator ShowReceiveRewardWindowCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C811C Offset: 0x6C811C VA: 0x6C811C
		// // RVA: 0xB34F14 Offset: 0xB34F14 VA: 0xB34F14
		// public IEnumerator ShowMissionStepupWindowCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C8194 Offset: 0x6C8194 VA: 0x6C8194
		// // RVA: 0xB34FC0 Offset: 0xB34FC0 VA: 0xB34FC0
		// public IEnumerator ShowConvertRareupStarWindowCoroutine() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C820C Offset: 0x6C820C VA: 0x6C820C
		// // RVA: 0xB3506C Offset: 0xB3506C VA: 0xB3506C
		// public IEnumerator ShowGetLiveSkipTicketWindowCoroutine() { }

		// // RVA: 0xB35118 Offset: 0xB35118 VA: 0xB35118
		// public void ChangeRhythmAdjustScene() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C8284 Offset: 0x6C8284 VA: 0x6C8284
		// // RVA: 0xB3526C Offset: 0xB3526C VA: 0xB3526C
		// private IEnumerator GotoRhythmAdjustCorotine() { }

		// // RVA: 0xB35318 Offset: 0xB35318 VA: 0xB35318
		// public static void SaveRequest() { }

		// // RVA: 0xB353C4 Offset: 0xB353C4 VA: 0xB353C4
		// public static void Save(IMCBBOAFION onSuccess, DJBHIFLHJLK onError) { }

		// // RVA: 0xB355A0 Offset: 0xB355A0 VA: 0xB355A0
		private void ChangeGroupCategory(SceneGroupCategory prevCategory, SceneGroupCategory nextCategory)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xB3568C Offset: 0xB3568C VA: 0xB3568C
		// public static bool SaveWithAchievement(ulong checkTarget, IMCBBOAFION onSuccess, IMCBBOAFION onError) { }

		// // RVA: 0xB2A834 Offset: 0xB2A834 VA: 0xB2A834
		// public static bool CheckDatelineAndAssetUpdate() { }

		// // RVA: 0xB35814 Offset: 0xB35814 VA: 0xB35814
		// private bool CheckDatelineAndAssetUpdateInner() { }

		// // RVA: 0xB35920 Offset: 0xB35920 VA: 0xB35920
		// public bool CheckEventLimit(IBJAKJJICBC musicData, bool isCheckDateLine = True, bool isDoTransition = True, KGCNCBOKCBA.GNENJEHKMHD status = 5, int eventUniqueId = 0) { }

		// // RVA: 0xB36020 Offset: 0xB36020 VA: 0xB36020
		// public bool CheckEventLimit(OHCAABOMEOF.KGOGMKMBCPP eventType, bool isCheckDateLine = True, bool isDoTransition = True, KGCNCBOKCBA.GNENJEHKMHD status = 5, int eventUniqueId = 0) { }

		// // RVA: 0xB36680 Offset: 0xB36680 VA: 0xB36680
		// public bool CheckEventLimit(IKDICBBFBMI controller, bool isCheckDateLine = True, bool isDoTransition = True) { }

		// // RVA: 0xB36B6C Offset: 0xB36B6C VA: 0xB36B6C
		// public bool TryMusicPeriod(long musicCloseAt, int unitqueId, OHCAABOMEOF.KGOGMKMBCPP eventType, bool isMvMode, MenuScene.MusicPeriodMess mess) { }

		// // RVA: 0xB36F90 Offset: 0xB36F90 VA: 0xB36F90
		// public static void RemainDivaOneTime() { }

		// // RVA: 0xB3703C Offset: 0xB3703C VA: 0xB3703C
		private void OnShowHelpPopup(int id, int eventHelpId)
		{
			UnityEngine.Debug.LogError("TODO OnShowHelpPopup");
		}

		// // RVA: 0xB372CC Offset: 0xB372CC VA: 0xB372CC
		// private void OnBackButton() { }

		// // RVA: 0xB37B00 Offset: 0xB37B00 VA: 0xB37B00
		// public int GetInputDisableCount() { }

		// // RVA: 0xB37B08 Offset: 0xB37B08 VA: 0xB37B08
		// public int GetRaycastDisableCount() { }

		// // RVA: 0xB37B10 Offset: 0xB37B10 VA: 0xB37B10
		// public Vector3 GetDivaCameraRotByScene(TransitionList.Type type) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C831C Offset: 0x6C831C VA: 0x6C831C
		// // RVA: 0xB37CCC Offset: 0xB37CCC VA: 0xB37CCC
		// private IEnumerator <GotoRhythmGame>b__148_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C832C Offset: 0x6C832C VA: 0x6C832C
		// // RVA: 0xB37CF8 Offset: 0xB37CF8 VA: 0xB37CF8
		// private void <ShowSnsNotice>b__189_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C833C Offset: 0x6C833C VA: 0x6C833C
		// // RVA: 0xB37DC0 Offset: 0xB37DC0 VA: 0xB37DC0
		// private void <ShowOfferNotice>b__190_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C834C Offset: 0x6C834C VA: 0x6C834C
		// // RVA: 0xB37E34 Offset: 0xB37E34 VA: 0xB37E34
		// private void <OnShowHelpPopup>b__232_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C835C Offset: 0x6C835C VA: 0x6C835C
		// // RVA: 0xB37E38 Offset: 0xB37E38 VA: 0xB37E38
		// private void <OnShowHelpPopup>b__232_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C836C Offset: 0x6C836C VA: 0x6C836C
		// // RVA: 0xB37E3C Offset: 0xB37E3C VA: 0xB37E3C
		// private void <OnBackButton>b__233_0() { }
	}
}
