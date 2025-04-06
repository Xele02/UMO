using XeApp.Core;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using System.Collections;
using XeApp.Game.Common;
using UnityEngine.Events;
using System;
using XeApp.Game.Tutorial;
using System.Collections.Generic;
using mcrs;
using XeApp.Game.MiniGame;
using XeSys.uGUI;
using CriWare;
using XeApp.Game.Gacha;

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

		public enum MusicPeriodMess
		{
			MusicSelect = 0,
			TeamSelect = 1,
		}

		public const float FADE_TIME = 0.4f;
		[SerializeField]
		private TransitionTreeObject treeObject; // 0x28
		private static SceneStack m_menuSceneStack = new SceneStack(); // 0x8
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
		private PopupItemList.PopupItemListSetting m_popupItemListSetting = new PopupItemList.PopupItemListSetting(); // 0x74
		private PopupItemDetail.PopupItemDetailSetting m_popupItemDetailSettinig = new PopupItemDetail.PopupItemDetailSetting(); // 0x78
		private PopupUseItemWindow m_popupUseItemWindow; // 0x7C
		private PopupDetailCostumeSetting m_popupDetailCostumeSetting = new PopupDetailCostumeSetting(); // 0x80
		private HomeLobbyButtonController m_lobbyButtonControl; // 0x84
		private FlexibleLayoutCamera _flexibleLayoutCamera; // 0x88
		private DenominationManager m_denomControl; // 0x8C
		private long m_enterToHomeTime; // 0x90
		private MenuSceneUpdater MenuUpdater; // 0x98
		private MenuScene.MenuSceneCamebackInfo m_sceneCamebackInfo; // 0x9C

		public static MenuScene Instance { get; private set; } // 0x0
		public static bool IsAlreadyHome { get; set; } // 0x4
		public static bool IsFirstTitleFlow { get; set; } // 0x5
		public static bool ComebackByRestart { private get;  set; } // 0x6
		public MenuDivaManager divaManager { get; set; } // 0x2C
		public SceneIconTextureCache SceneIconCache { get { return GameManager.Instance.SceneIconCache; } } //0xB2DCF8
		public DivaIconTextureCache DivaIconCache { get { return GameManager.Instance.DivaIconCache; } } //0xB2DD94
		public BgTextureCache BgTextureCache { get { return GameManager.Instance.BgTextureCache; } } //0xB2DE30
		public ItemTextureCache ItemTextureCache { get { return GameManager.Instance.ItemTextureCache; } } //0xB2DECC
		public MenuResidentTextureCache MenuResidentTextureCache { get { return GameManager.Instance.MenuResidentTextureCache; } } //0xB2DF68
		public MusicJacketTextureCache MusicJacketTextureCache { get { return GameManager.Instance.MusicJacketTextureCache; } } //0xB2E004
		public UnitPopupWindowControl UnitSaveWindowControl { get { return m_unitSaveWindowControl; } } //0xB2E0A0
		public StatusWindowControl StatusWindowControl { get { return m_statusWindowControl; } } //0xB2E0A8
		public MusicPopupWindowControl MusicPopupWindowControl { get { return m_musicPopupWindowControl; } } //0xB2E0B0
		public HelpPopupWindowControl HelpPopupWindowControl { get { return m_helpPopupWindowControl; } } //0xB2E0B8
		public LimitOverControl LimitOverControl { get { return m_limitOverControl; } } //0xB2E0C0
		public IntimacyController IntimacyControl { get { return m_intimacyControl; } } //0xB2E0C8
		public PopupUseItemWindow PopupUseItemWindow { get { return m_popupUseItemWindow; } } //0xB2E0D0
		public ValkyrieIconTextureCache ValkyrieIconCache { get { return GameManager.Instance.ValkyrieIconCache; } } //0xB2E0D8
		public CostumeTextureCache CostumeIconCache { get { return GameManager.Instance.CostumeIconCache; } } //0xB2E174
		// public QuestEventTextureCache QuestEventCache { get; } 0xB2E210
		// public SNSTextureCache SnsIconCache { get; } 0xB2E2AC
		public EpisodeTextuteCache EpisodeIconCache { get { return GameManager.Instance.EpisodeIconCache; } } //0xB2E348
		public StoryImageTextureCache StoryImageCache { get { return GameManager.Instance.storyImageCache; } } //0xB2E3E4
		public SubPlateIconTextureCache SubPlateIconTextureCahe { get { return GameManager.Instance.subPlateIconCache; } } //0xB2E480
		public DecorationItemTextureCache DecorationItemTextureCache { get { return GameManager.Instance.decorationItemTextureCache; } } //0xB2E51C
		public HomeBgIconBgTextureCache HomeBgIconTextureCache { get { return GameManager.Instance.HomeBgIconTextureCache; } } //0xB2E5B8
		public BgControl BgControl { get { return m_menuTransitionControl.bgControl; } } //0xB2E654
		public MenuHeaderControl HeaderMenu { get { return m_menuTransitionControl.MenuHeader; } } //0xB2E680
		public MenuFooterControl FooterMenu { get { return m_menuTransitionControl.MenuFooter; } } //0xB2E6AC
		public HelpButton HelpButton { get { return m_menuTransitionControl.HelpButton; } } //0xB2E6D8
		public bool DirtyChangeScene { get { return m_menuTransitionControl.DirtyChangeScene; } } //0xB2E704
		public HomeLobbyButtonController LobbyButtonControl { get { return m_lobbyButtonControl; } } //0xB2E730
		public FlexibleLayoutCamera FlexibleLayoutCamera { get
		{
			if(_flexibleLayoutCamera == null)
				_flexibleLayoutCamera = GetComponent<FlexibleLayoutCamera>();
			return _flexibleLayoutCamera;
		} } //0xB2E738
		public DenominationManager DenomControl { get { return m_denomControl; } } //0xB2AB9C
		public long EnterToHomeTime { get { return m_enterToHomeTime; } } //0xB2E7EC

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
			m_menuTransitionControl = new TransitionRoot.MenuTransitionControl(m_bgRootObject, m_uiRootObject, GetFont(), treeObject);
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
			this.StartCoroutineWatched(InitializeCoroutine());
		}

		// // RVA: 0xB305FC Offset: 0xB305FC VA: 0xB305FC Slot: 12
		protected override bool DoUpdateEnter()
		{
			if (!m_isInitializeing && m_isChangedCueSheet)
			{
				if (m_isSceneEnter)
					return false;
				MenuUpdater.updater = () =>
				{
					//0xB37CC8
					if (m_menuTransitionControl.DirtyChangeScene && m_isInTransition)
					{
						Debug.Log("transition requested but in transition");
					}
					if (m_menuTransitionControl.DirtyChangeScene && !m_isInTransition)
					{
						this.StartCoroutineWatched(ChangeTransitionCoroutine());
					}
					if (m_playerStatusData != null)
					{
						m_playerStatusData.FBANBDCOEJL();
						m_menuTransitionControl.ApplyPlayerStatus(m_playerStatusData);
					}
				};
				return true;
			}
			return false;
		}

		// // RVA: 0xB306D8 Offset: 0xB306D8 VA: 0xB306D8
		public static float GetLongScreenScale()
		{
			if(SystemManager.HasSafeArea)
			{
				return 1.7777778f / (GameManager.Instance.AppResolutionWidth / GameManager.Instance.AppResolutionHeight);
			}
			else
			{
				return 0.84f;
			}
		}

		// // RVA: 0xB2F0E0 Offset: 0xB2F0E0 VA: 0xB2F0E0
		private void MakeComebackSceneInfo(ref MenuSceneCamebackInfo info)
		{
			if(ComebackByRestart)
			{
				ComebackByRestart = false;
				info.category = SceneGroupCategory.LOGINBONUS;
				info.nextName = TransitionList.Type.LOGIN_BONUS;
				info.uniqueId = TransitionUniqueId.LOGINBONUS;
				return;
			}
			if(string.IsNullOrEmpty(prevSceneName))
			{
				info.flags = MenuSceneCamebackInfo.Flags.GotoTitle;
				return;
			}
			bool fromRhythmGame = true;
			if(prevSceneName != "RhythmGame")
			{
				fromRhythmGame = prevSceneName == "RhythmGameSkip";
			}
			if(RuntimeSettings.CurrentSettings.SLiveViewer)
				fromRhythmGame = false;
			GameManager.Instance.SetTouchEffectVisible(true);
			GameManager.Instance.SetTouchEffectMode(false);
			if(fromRhythmGame == false)
			{
				if(prevSceneName == "GachaDirection")
				{
					info.category = SceneGroupCategory.GACHA;
					info.nextName = TransitionList.Type.GACHA_2;
					info.uniqueId = TransitionUniqueId.GACHA2;
					info.args = new GachaScene.GachaArgs(GachaScene.GachaProductList[GachaScene.SelectIndex].FDEBLMKEMLF_TypeAndSeriesId, true);
					return;
				}
				if(prevSceneName == "RhythmAdjust")
				{
					if(GameManager.Instance.IsTutorial)
					{
						info.category = SceneGroupCategory.GACHA;
						info.nextName = TransitionList.Type.GACHA_2;
						info.uniqueId = TransitionUniqueId.GACHA2;
						return;
					}
					if(m_menuSceneStack[m_menuSceneStack.Count - 1].name == TransitionList.Type.TEAM_SELECT)
					{
						if(m_menuSceneStack[m_menuSceneStack.Count - 1].groupCategory == SceneGroupCategory.STORY)
						{
							BgControl.SetStoryParam(m_menuSceneStack[m_menuSceneStack.Count - 1].storyBgParam);
						}
					}
					else if(m_menuSceneStack[m_menuSceneStack.Count - 1].name == TransitionList.Type.OPTION_MENU)
					{
						OptionMenuScene.OptionMenuArgs arg = new OptionMenuScene.OptionMenuArgs();
						info.category = SceneGroupCategory.OPTION;
						info.nextName = TransitionList.Type.OPTION_MENU;
						info.parentName = TransitionList.Type.UNDEFINED;
						info.uniqueId = TransitionUniqueId.OPTIONMENU;
						arg.openConfig = true;
						info.args = arg;
						return;
					}
					info.flags = MenuSceneCamebackInfo.Flags.ReturnScene;
					return;
				}
				if(prevSceneName == "Adv")
				{
					info.uniqueId = Database.Instance.advResult.UniqueId;
					info.camBackUnityScene = MenuSceneCamebackInfo.CamBackUnityScene.Adv;
					if (info.uniqueId < TransitionUniqueId.EVENTQUEST_FRIENDSELECT)
					{
						if ((info.uniqueId | TransitionUniqueId.HOME) != TransitionUniqueId.EVENTQUEST)
							return;
					}
					else if (info.uniqueId != TransitionUniqueId.EVENTGODIVA && info.uniqueId != TransitionUniqueId.EVENTBATTLE)
						return;
					info.args = new EventMusicSelectSceneArgs(Database.Instance.advResult.EventUniqueId, false, false);
					return;
				}
				if(GameManager.Instance.IsTutorial)
				{
					ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint recovery = BasicTutorialManager.Instance.GetRecoveryPoint();
					switch(recovery)
					{
						case ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.DOEHLCLBCNN_3_Gacha:
						case ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.FBFBGLONIME_4_AfterGacha:
							info.category = SceneGroupCategory.GACHA;
							info.nextName = TransitionList.Type.GACHA_2;
							info.uniqueId = TransitionUniqueId.GACHA2;
							return;
						case ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.DJPFJGKGOOF_5_Setting:
							info.category = SceneGroupCategory.FORMATION;
							info.nextName = TransitionList.Type.SETTING_MENU;
							info.uniqueId = TransitionUniqueId.SETTINGMENU;
							return;
						case ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.BNLDNJNMFMC_6:
							{
								TeamSelectSceneListArgs arg = new TeamSelectSceneListArgs();
								arg.defaultSelectScene = 0;
								arg.divaSlotIndex = 0;
								arg.divaData = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id - 1];
								info.category = SceneGroupCategory.FORMATION;
								info.nextName = TransitionList.Type.SCENE_SELECT;
								info.parentName = TransitionList.Type.TEAM_EDIT;
								info.uniqueId = TransitionUniqueId.SETTINGMENU_TEAMEDIT;
								info.args = arg;
								return;
							}
						case ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint.KIDJFNEGAHO_7_ToMusicResult:
							info.isDivaActive = true;
							info.category = SceneGroupCategory.RESULT;
							info.nextName = TransitionList.Type.RESULT;
							info.uniqueId = TransitionUniqueId.RESULT;
							return;
						default:
							return;
					}
				}
				if(prevSceneName == "MiniGame")
				{
					info.category = SceneGroupCategory.FREE;
					info.nextName = TransitionList.Type.MUSIC_SELECT;
					info.uniqueId = TransitionUniqueId.MUSICSELECT;
					return;
				}
				else
				{
					info.category = SceneGroupCategory.LOGINBONUS;
					info.nextName = TransitionList.Type.LOGIN_BONUS;
					info.uniqueId = TransitionUniqueId.LOGINBONUS;
					return;
				}
			}
			GameManager.Instance.ResetViewPlayerData();
			if(GameManager.Instance.IsTutorial)
			{
				if(Database.Instance.gameResult.tutorialOneResult == GameResultData.TutorialOneResult.RETRY)
				{
					info.flags = MenuSceneCamebackInfo.Flags.RetryGame;
					return;
				}
				if (Database.Instance.gameResult.tutorialOneResult == GameResultData.TutorialOneResult.GACHA)
				{
					BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.HOIECIKEIHB_18);
					Database.Instance.advSetup.Setup(2);
					Database.Instance.advResult.Setup("Menu", TransitionUniqueId.GACHA2);
					info.flags = MenuSceneCamebackInfo.Flags.Adventure;
					return;
				}
				BasicTutorialManager.Instance.SaveMusicResult();
				BasicTutorialManager.Log(OAGBCBBHMPF.OGBCFNIKAFI.BJBDDPHJHFA_27);
				info.isDivaActive = true;
				info.category = SceneGroupCategory.RESULT;
				info.nextName = TransitionList.Type.RESULT;
				info.uniqueId = TransitionUniqueId.RESULT;
				return;
				// L 415
			}
			else
			{
				if (!Database.Instance.gameSetup.musicInfo.isFreeMode)
				{
					// L529
					if(!Database.Instance.gameSetup.musicInfo.isStoryMode)
						return;
					info.category = SceneGroupCategory.HOME;
					info.nextName = TransitionList.Type.STORY_SELECT;
					info.uniqueId = TransitionUniqueId.STORYSELECT;
					return;
				}
				if(!Database.Instance.gameResult.IsClear())
				{
					// L558
					if(Database.Instance.gameSetup.musicInfo.gameEventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
					{
						if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
						{
							TodoLogger.LogError(TodoLogger.EventCollection_1, "init from event 1");
						}
						if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
						{
							PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.JBAIEADLAGH_0);
							info.category = SceneGroupCategory.EVENT_BATTLE;
							info.nextName = TransitionList.Type.EVENT_BATTLE;
							info.uniqueId = TransitionUniqueId.EVENTBATTLE;
							info.args = new EventMusicSelectSceneArgs(Database.Instance.gameSetup.musicInfo.EventUniqueId, Database.Instance.gameSetup.musicInfo.IsLine6Mode, true);
							return;
						}
					}
					else
					{
						if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
						{
							PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.JBAIEADLAGH_0);
							info.category = SceneGroupCategory.EVENT_GODIVA;
							info.nextName = TransitionList.Type.EVENT_GODIVA;
							info.uniqueId = TransitionUniqueId.EVENTGODIVA;
							info.args = new EventMusicSelectSceneArgs(Database.Instance.gameSetup.musicInfo.EventUniqueId, Database.Instance.gameSetup.musicInfo.IsLine6Mode, true);
							return;
						}
						if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
						{
							TodoLogger.LogError(TodoLogger.EventRaid_11_13, "init from event 11");
						}
						if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
						{
							TodoLogger.LogError(TodoLogger.EventQuest_6, "init from event 6");
						}
					}
					PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.JBAIEADLAGH_0/*0*/);
					if (!Database.Instance.gameSetup.musicInfo.IsMvMode && !Database.Instance.gameSetup.musicInfo.IsLine6Mode)
					{
						;
					}
					else
					{
						MusicSelectArgs margs = new MusicSelectArgs();
						margs.isSimulation = Database.Instance.gameSetup.musicInfo.IsMvMode;
						margs.isLine6Mode = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
						info.args = margs;
					}
					info.category = SceneGroupCategory.FREE;
					info.nextName = TransitionList.Type.MUSIC_SELECT;
					info.uniqueId = TransitionUniqueId.MUSICSELECT;
					return;
				}
				// L746
				info.isDivaActive = true;
				if(Database.Instance.gameSetup.musicInfo.IsMvMode)
				{
					info.category = SceneGroupCategory.SIMULATIONLIVE_RESULT;
					info.nextName = TransitionList.Type.SIMULATIONLIVE_RESULT;
					info.uniqueId = TransitionUniqueId.SIMULATIONLIVERESULT;
					return;
				}
			}
			info.category = SceneGroupCategory.RESULT;
			info.nextName = TransitionList.Type.RESULT;
			info.uniqueId = TransitionUniqueId.RESULT;

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
			//0xB38ECC
			m_isInTransition = true;
			GameManager.Instance.RemovePushBackButtonHandler(this.OnBackButton);
			GameManager.Instance.CloseSnsNotice();
			if(!CheckDatelineAndAssetUpdateInner())
			{
				yield return this.StartCoroutineWatched(m_menuTransitionControl.ChangeTransition());
				GameManager.Instance.AddLastBackButtonHandler(this.OnBackButton);
			}
			else
			{
				m_menuTransitionControl.ClearDirtyChangeScene();
			}
			m_isInTransition = false;
		}

		// // RVA: 0xB309EC Offset: 0xB309EC VA: 0xB309EC
		public void OnDestroy()
		{
			GameManager.Instance.RemovePushBackButtonHandler(this.OnBackButton);
			m_musicPopupWindowControl.Release();
			m_helpPopupWindowControl.Release();
			MenuScene.Instance = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C78AC Offset: 0x6C78AC VA: 0x6C78AC
		// // RVA: 0xB30570 Offset: 0xB30570 VA: 0xB30570
		private IEnumerator InitializeCoroutine()
		{
			//0xB3C09C
			m_isInitializeing = true;
			m_isSceneEnter = true;
			bool isWait = true;

			this.StartCoroutineWatched(CoroutineDivaModel(() => {
				//0xB38588
				isWait = false;
			}));
			yield return this.StartCoroutineWatched(CoroutineSystemResource());

			while(isWait)
				yield return null;
			
			if(SystemManager.isLongScreenDevice)
			{
				FlexibleLayoutCamera.IsEnableFov = false;
				int a = Mathf.CeilToInt(FlexibleLayoutCamera.GetDefaultFov(0) * GetLongScreenScale());
				divaManager.SetCameraFov(a);
			}
			SetActiveDivaModel(m_sceneCamebackInfo.isDivaActive, true);
			if(m_sceneCamebackInfo.flags == MenuSceneCamebackInfo.Flags.GotoTitle)
			{
				this.StartCoroutineWatched(GotoTitleCoroutine());
			}
			else if(m_sceneCamebackInfo.flags == MenuSceneCamebackInfo.Flags.RetryGame)
			{
				GotoRhythmGame(Database.Instance.gameSetup.EnableLiveSkip, Database.Instance.gameSetup.LiveSkipTicketCount, Database.Instance.gameSetup.IsNotUpdateProfile);
			}
			else if(m_sceneCamebackInfo.flags == MenuSceneCamebackInfo.Flags.ReturnScene)
			{
				m_menuTransitionControl.LoadStack(m_menuSceneStack);
				m_menuTransitionControl.Return();
			}
			else if(m_sceneCamebackInfo.flags == MenuSceneCamebackInfo.Flags.Adventure)
			{
				GotoAdventure(false);
			}
			else
			{
				Mount(m_sceneCamebackInfo.uniqueId, m_sceneCamebackInfo.args, true, m_sceneCamebackInfo.camBackUnityScene);
			}
			m_isInitializeing = false;
			m_isSceneEnter = false;
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
			this.StartCoroutineWatched(m_menuTransitionControl.Initialize(this, () => {
				//0xB3859C
				loadCount++;
			}));
			reqCount++;
			this.StartCoroutineWatched(m_statusWindowControl.Initialize(gameObject, () => {
				//0xB385AC
				loadCount++;
			}));
			reqCount++;
			this.StartCoroutineWatched(m_sortWindowControl.Initialize(gameObject, () => {
				//0xB385BC
				loadCount++;
			}));
			reqCount++;
			this.StartCoroutineWatched(m_popupFilterSortWindowContrl.Initialize(gameObject, () => {
				//0xB385CC
				loadCount++;
			}));
			reqCount++;
			this.StartCoroutineWatched(m_unitSaveWindowControl.Initialize(gameObject, () => {
				//0xB385DC
				loadCount++;
			}));
			reqCount++;
			this.StartCoroutineWatched(GameManager.Instance.Co_CacheAppResources());
			while(!GameManager.Instance.IsCacheActive)
				yield return null;
			while(loadCount != reqCount)
				yield return null;
			HelpButton.HelpButtonListener += this.OnShowHelpPopup;
			m_menuTransitionControl.MenuFooter.Initialize();
			if(!GameManager.Instance.IsTutorial)
			{
				this.StartCoroutineWatched(m_lobbyButtonControl.Co_LoadLayout(m_uiRootObject));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C799C Offset: 0x6C799C VA: 0x6C799C
		// // RVA: 0xB30C08 Offset: 0xB30C08 VA: 0xB30C08
		private IEnumerator CoroutineDivaModel(UnityAction finish)
		{
			DivaResource.MenuFacialType divaFacialType; // 0x18
			int divaId; // 0x1C
			int modelId; // 0x20
			int colorId; // 0x24
			bool isResult; // 0x28

			//0xB3980C
			divaFacialType = DivaResource.MenuFacialType.Home;
			FFHPBEPOMAK_DivaInfo divaInfo = GameManager.Instance.GetHomeDiva();
			divaId = divaInfo.AHHJLDLAPAN_DivaId;
			modelId = divaInfo.EOJIGHEFIAA_GetHomeDivaPrismCostumeId();
			colorId = divaInfo.LHGJHJLGPBE_GetHomeDivaColorId();
			isResult = false;
			if(GameManager.Instance.IsTutorial)
			{
				isResult = true;
				if(prevSceneName != "RhythmGame")
				{
					isResult = prevSceneName == "Prologue";
				}
			}
			else
			{
				isResult = true;
				if(prevSceneName != "RhythmGame" && 
					prevSceneName != "RhythmGameSkip")
				{
					isResult = false;
				}
			}
			isResult &= Database.Instance.gameResult.IsClear();
			isResult &= Database.Instance.gameSetup.musicInfo.isFreeMode;
			while(divaManager == null)
				yield return null;
			if(!isResult)
			{
				if(!divaManager.Compare(divaId, modelId, colorId))
				{
					divaManager.Release(true);
				}
			}
			else
			{
				divaFacialType = DivaResource.MenuFacialType.Result;
				if(!GameManager.Instance.IsTutorial)
				{
					divaId = Database.Instance.gameSetup.teamInfo.divaList[0].prismDivaId;
					modelId = Database.Instance.gameSetup.teamInfo.divaList[0].prismCostumeModelId;
					colorId = Database.Instance.gameSetup.teamInfo.divaList[0].prismCostumeColorId;
				}
			}
			divaManager.Load(divaId, modelId, colorId, divaFacialType, true);
			while(divaManager.IsLoading)
				yield return null;
			if(finish != null)
				finish();
		}

		// // RVA: 0xB30CD0 Offset: 0xB30CD0 VA: 0xB30CD0
		public void SetActiveDivaModel(bool active, bool isIdle = true)
		{
			divaManager.SetActive(active, isIdle);
		}

		// // RVA: 0xB30D0C Offset: 0xB30D0C VA: 0xB30D0C
		public void SetDivaXposition(float xpos)
		{
			divaManager.SetPosition(new Vector3(xpos, 0, 0));
		}

		// // RVA: 0xB30D6C Offset: 0xB30D6C VA: 0xB30D6C Slot: 14
		protected override bool DoUpdateLeave()
		{
			DivaIconCache.Clear();
			BgTextureCache.Clear();
			ItemTextureCache.Clear();
			MusicJacketTextureCache.Clear();
			m_menuTransitionControl.MenuFooter.Release();
			MenuUpdater.updater = null;
			return true;
		}

		// // RVA: 0xB30E8C Offset: 0xB30E8C VA: 0xB30E8C
		public void InitializePlayerStatusData()
		{
			m_playerStatusData = new IFBCGCCJBHI();
			m_playerStatusData.KHEKNNFCAOI();
		}

		// // RVA: 0xB30F18 Offset: 0xB30F18 VA: 0xB30F18
		// public int GetMedalMonthId() { }

		// // RVA: 0xB30F58 Offset: 0xB30F58 VA: 0xB30F58
		public int GetCurrentStamina()
		{
			if(m_playerStatusData != null)
			{
				return m_playerStatusData.EPNALMONMHB_CurEnergy;
			}
			return 0;
		}

		// // RVA: 0xB30F70 Offset: 0xB30F70 VA: 0xB30F70
		public void InitAssitPlate()
		{
			EEMGHIINEHN data = new EEMGHIINEHN();
			data.IONKIJLHJDP();
		}

		// // RVA: 0xB30FF4 Offset: 0xB30FF4 VA: 0xB30FF4
		public void GotoRhythmGame(bool isSkip, int ticketCount, bool isNotUpdateProfile)
		{
			GameManager.Instance.SetSystemCanvasRenderMode(RenderMode.ScreenSpaceOverlay);
			GameManager.Instance.ChangePopupPriority(true);
			Database.Instance.gameSetup.SetLiveSkip(isSkip, ticketCount);
			Database.Instance.gameSetup.SetIsNotUpdateProfile(isNotUpdateProfile);
			m_menuTransitionControl.SetHeaderMenuButtonDisable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonDisable();
			m_menuTransitionControl.SetFooterMenuButtonDisable(MenuFooterControl.Button.All);
			this.StartCoroutineWatched(GotoRhythmGameCorotine(() => {
				return m_menuTransitionControl.DestroyTransion();
			}, isSkip));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7A14 Offset: 0x6C7A14 VA: 0x6C7A14
		// // RVA: 0xB312F8 Offset: 0xB312F8 VA: 0xB312F8
		public static IEnumerator RhythmGamePreLoad(Func<IEnumerator> wait)
		{
			//0xB3C79C
			GameManager.Instance.SetTouchEffectVisible(false);
			yield return Co.R(GameManager.Instance.TryInstallRhythmGameResource(Database.Instance.gameSetup));
			GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			if(wait != null)
				yield return Co.R(wait());
			GameManager.Instance.NowLoading.Show();
			SoundManager.Instance.bgmPlayer.Stop();
			yield return Co.R(RhythmGameStartVoicePlay());
			yield return Co.R(GameManager.Instance.ShowGameIntroCoroutine());
		}

		// // RVA: 0xB313A4 Offset: 0xB313A4 VA: 0xB313A4
		private static int SeachLiveStartMultiVoice()
		{
			List<int> l = new List<int>();
			for(int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
			{
				l.Add(Database.Instance.gameSetup.teamInfo.danceDivaList[i].prismDivaId);
			}
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.DCMGLKDJAKL(Database.Instance.gameSetup.musicInfo.musicId, Database.Instance.gameSetup.musicInfo.onStageDivaNum, l);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7A8C Offset: 0x6C7A8C VA: 0x6C7A8C
		// // RVA: 0xB316A4 Offset: 0xB316A4 VA: 0xB316A4
		public static IEnumerator RhythmGameStartVoicePlay()
		{
			GameSetupData.TeamInfo.DivaInfo t_center_diva; // 0x10
			GameSetupData.TeamInfo.DivaInfo t_diva2; // 0x14
			GameSetupData.TeamInfo.DivaInfo t_diva3; // 0x18
			int t_diva_num; // 0x1C

			//0xB3CC5C
			t_center_diva = Database.Instance.gameSetup.teamInfo.divaList[0];
			int forceVoice = Database.Instance.gameSetup.ForceDivaVoice();
			int a = SeachLiveStartMultiVoice();
			if(forceVoice < 1)
			{
				if(a < 1)
				{
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OOOPJNKBDIL(t_center_diva.prismDivaId, t_center_diva.prismCostumeModelId))
					{
						t_diva2 = Database.Instance.gameSetup.teamInfo.divaList[1];
						t_diva3 = Database.Instance.gameSetup.teamInfo.divaList[2];
						t_diva_num = Database.Instance.gameSetup.musicInfo.onStageDivaNum;
						int disable_game_start_multi_voices = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("disable_game_start_multi_voices", 0);
						if (disable_game_start_multi_voices != 0)
							t_diva_num = 1;
						bool isEndedChangeCueSheet = false;
						if(t_diva_num == 3)
						{
							SoundManager.Instance.voDivaCos.RequestChangeCueSheetUnit(t_center_diva.prismDivaId, t_diva2.prismDivaId, () =>
							{
								//0xB3862C
								isEndedChangeCueSheet = true;
							});
						}
						else if(t_diva_num == 2)
						{
							SoundManager.Instance.voDivaCos.RequestChangeCueSheetDuet(t_center_diva.prismDivaId, () =>
							{
								//0xB38638
								isEndedChangeCueSheet = true;
							});
						}
						else
						{
							SoundManager.Instance.voDivaCos.RequestChangeCueSheetSole(t_center_diva.prismDivaId, () =>
							{
								//0xB38644
								isEndedChangeCueSheet = true;
							});
						}
						yield return new WaitUntil(() =>
						{
							//0xB38650
							return isEndedChangeCueSheet;
						});
						//3
						if(t_diva_num == 3)
						{
							SoundManager.Instance.voDivaCos.Play(DivaCosVoicePlayer.Category.GameStartMulti, t_diva3.prismDivaId);
						}
						else if(t_diva_num == 2)
						{
							SoundManager.Instance.voDivaCos.Play(DivaCosVoicePlayer.Category.GameStartMulti, t_diva2.prismDivaId);
						}
						else
						{
							SoundManager.Instance.voDivaCos.Play(DivaCosVoicePlayer.Category.GameStart, 0);
						}
					}
					else
					{
						bool isEndedChangeCueSheet = false;
						SoundManager.Instance.voDiva.RequestChangeCueSheet(t_center_diva.prismDivaId, () =>
						{
							//0xB38660
							isEndedChangeCueSheet = true;
						});
						yield return new WaitUntil(() =>
						{
							//0xB3866C
							return isEndedChangeCueSheet;
						});
						//4
						SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.StartGame, 0);
					}
				}
				else
				{
					bool isEndedChangeCueSheet = false;
					SoundManager.Instance.voDiva.RequestChangeCueSheetForLiveStartMulti(a, () =>
					{
						//0xB38610
						isEndedChangeCueSheet = true;
					});
					yield return new WaitUntil(() =>
					{
						//0xB3861C
						return isEndedChangeCueSheet;
					});
					//2
					SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.StartGame, t_center_diva.prismDivaId);
				}
			}
			else
			{
				bool isEndedChangeCueSheet = false;
				SoundManager.Instance.voDiva.RequestChangeCueSheetForReplacement(forceVoice, () =>
				{
					//0xB385F4
					isEndedChangeCueSheet = true;
				});
				yield return new WaitUntil(() =>
				{
					//0xB38600
					return isEndedChangeCueSheet;
				});
				//1
				SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.StartGame, 0);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7B04 Offset: 0x6C7B04 VA: 0x6C7B04
		// // RVA: 0xB31238 Offset: 0xB31238 VA: 0xB31238
		private IEnumerator GotoRhythmGameCorotine(Func<IEnumerator> wait, bool isSkip = false)
		{
			//0xB3B65C
			yield return Co.R(RhythmGamePreLoad(wait));
			enableFade = false;
			while(SoundManager.Instance.voDiva.isPlaying || SoundManager.Instance.voDivaCos.isPlaying || 
				SoundManager.Instance.voPilot.isPlaying)
				yield return null;
			if(isSkip)
				NextScene("RhythmGameSkip");
			else
				NextScene("RhythmGame");
		}

		// // RVA: 0xB31758 Offset: 0xB31758 VA: 0xB31758
		public void GotoAdventure(bool isExecuteSceneExit = false)
		{
			m_menuTransitionControl.SetHeaderMenuButtonDisable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonDisable();
			m_menuTransitionControl.SetFooterMenuButtonDisable(MenuFooterControl.Button.All);
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			this.StartCoroutineWatched(Co_GotoAdventure(isExecuteSceneExit));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7B7C Offset: 0x6C7B7C VA: 0x6C7B7C
		// // RVA: 0xB318BC Offset: 0xB318BC VA: 0xB318BC
		private IEnumerator Co_GotoAdventure(bool isExecuteSceneExit)
		{
			//0xB391C4
			enableFade = false;
			GameManager.FadeOut(0.4f);
			GameManager.Instance.snsNotification.Close();
			if(isExecuteSceneExit)
			{
				yield return Co.R(m_menuTransitionControl.ExitTransition());
			}
			yield return GameManager.Instance.WaitFadeYielder;
			yield return Co.R(m_menuTransitionControl.DestroyTransion());
			GotoAdventureInner(true);
		}

		// // RVA: 0xB31984 Offset: 0xB31984 VA: 0xB31984
		private void GotoAdventureInner(bool isFade)
		{
			enableFade = isFade;
			NextScene("Adv");
		}

		// // RVA: 0xB31A00 Offset: 0xB31A00 VA: 0xB31A00
		public void GotoMiniGame(int miniGameId)
		{
			m_menuTransitionControl.SetHeaderMenuButtonDisable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonDisable();
			m_menuTransitionControl.SetFooterMenuButtonDisable(MenuFooterControl.Button.All);
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			this.StartCoroutineWatched(Co_GotoMiniGame(miniGameId, 1));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7BF4 Offset: 0x6C7BF4 VA: 0x6C7BF4
		// // RVA: 0xB31B68 Offset: 0xB31B68 VA: 0xB31B68
		private IEnumerator Co_GotoMiniGame(int miniGameId, int stageNum = 1)
		{
			//0xB394B0
			enableFade = false;
			GameManager.FadeOut(0.4f);
			GameManager.Instance.snsNotification.Close();
			yield return Co.R(m_menuTransitionControl.ExitTransition());
			yield return GameManager.Instance.WaitFadeYielder;
			yield return Co.R(m_menuTransitionControl.DestroyTransion());
			MiniGameScene.miniGameId = miniGameId;
			MiniGameScene.stageNum = stageNum;
			NextScene("MiniGame");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7C6C Offset: 0x6C7C6C VA: 0x6C7C6C
		// // RVA: 0xB31C48 Offset: 0xB31C48 VA: 0xB31C48
		private IEnumerator GotoTitleCoroutine()
		{
			UGUIFader fade;

			//0xB3B940
			GameManager.Instance.ClearPushBackButtonHandler();
			while(m_menuTransitionControl.IsTransition)
				yield return null;
			TipsControl.Instance.Close();
			GameManager.Instance.NowLoading.Hide();
			fade = GameManager.Instance.fullscreenFader;
			if(fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
				while (fade.isFading)
					yield return null;
			}
			yield return Co.R(m_menuTransitionControl.DestroyTransion());
			PopupWindowManager.Close(null, null);
			SoundManager.Instance.bgmPlayer.Stop();
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.MBOIDKCMCDL = false;
			SoundManager.Instance.voDiva.Stop();
			while (SoundManager.Instance.voDiva.isPlaying)
				yield return null;
			SoundManager.Instance.voDiva.RemoveCueSheet();
			SoundManager.Instance.voDivaCos.Stop();
			while (SoundManager.Instance.voDivaCos.isPlaying)
				yield return null;
			SoundManager.Instance.voDivaCos.RemoveCueSheet();
			EventGoDivaScene.IsViewedBonusOpenPopup = false;
			NextScene("Title");
		}

		// // RVA: 0xB2B4A8 Offset: 0xB2B4A8 VA: 0xB2B4A8
		public void GotoTitle()
		{
			this.StartCoroutineWatched(GotoTitleCoroutine());
		}

		// // RVA: 0xB2B620 Offset: 0xB2B620 VA: 0xB2B620
		public void GotoLoginBonus()
		{
			this.StartCoroutineWatched(GotoLoginBonsuCorotine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7CE4 Offset: 0x6C7CE4 VA: 0x6C7CE4
		// // RVA: 0xB31CF4 Offset: 0xB31CF4 VA: 0xB31CF4
		private IEnumerator GotoLoginBonsuCorotine()
		{
			UGUIFader fade;

			//0xB3AE00
			fade = GameManager.Instance.fullscreenFader;
			if(fade.currentColor.a < 1)
			{
				fade.Fade(0.1f, Color.black);
				while(fade.isFading)
					yield return null;
			}
			//LAB_00b3af78
			MenuScene.Instance.Mount(TransitionUniqueId.LOGINBONUS, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xB31DA0 Offset: 0xB31DA0 VA: 0xB31DA0
		public void GotoGachaDirection()
		{
			this.StartCoroutineWatched(GotoGachaDirectionCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7D5C Offset: 0x6C7D5C VA: 0x6C7D5C
		// // RVA: 0xB31DC4 Offset: 0xB31DC4 VA: 0xB31DC4
		private IEnumerator GotoGachaDirectionCoroutine()
		{
			UGUIFader fader; // 0x14
			CriAtomExPlayback playback; // 0x18

			//0xB3A9B0
			RaycastDisable();
			int id = GachaUtility.GetSeIdForMenuLeaving();
			if(id > -1)
			{
				playback = SoundManager.Instance.sePlayerMenu.Play((int)id);
				yield return null;
				while(playback.GetStatus() == CriAtomExPlayback.Status.Playing)
					yield return null;
				playback = new CriAtomExPlayback(0);
			}
			//LAB_00b3abe4
			fader = GameManager.Instance.fullscreenFader;
			fader.Fade(0.1f, Color.black);
			while(fader.isFading)
				yield return null;
			yield return Co.R(m_menuTransitionControl.DestroyTransion());
			GameManager.Instance.SetTouchEffectVisible(false);
			SoundManager.Instance.bgmPlayer.Stop();
			RaycastEnable();
			NextScene("GachaDirection");
		}

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
		public void Return(bool isFading = true)
		{
			m_menuTransitionControl.Return(isFading);
		}

		// // RVA: 0xB32044 Offset: 0xB32044 VA: 0xB32044
		public void Call(TransitionList.Type next, TransitionArgs args, bool isFading = true)
		{
			m_menuTransitionControl.Call(next, args, isFading);
		}

		// // RVA: 0xB32094 Offset: 0xB32094 VA: 0xB32094
		public void Mount(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0)
		{
			m_menuTransitionControl.Mount(uniqueId,args,isFading,cambackUnityScene);
		}

		// // RVA: 0xB320EC Offset: 0xB320EC VA: 0xB320EC
		public void MountWithFade(TransitionUniqueId uniqueId, TransitionArgs args, bool isFading = true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene cambackUnityScene = 0)
		{
			m_menuTransitionControl.MountWithFade(uniqueId,args,isFading,cambackUnityScene);
		}

		// // RVA: 0xB32144 Offset: 0xB32144 VA: 0xB32144
		// public GameObject GetCurrentBg() { }

		// // RVA: 0xB32170 Offset: 0xB32170 VA: 0xB32170
		public IEnumerator ChangeBgTexture(BgTextureType textureType, int bgId)
		{
			return m_menuTransitionControl.bgControl.LoadBgTexture(textureType, bgId, false);
		}

		// // RVA: 0xB321DC Offset: 0xB321DC VA: 0xB321DC
		public TransitionInfo GetCurrentScene()
		{
			return m_menuTransitionControl.GetCurrentScene();
		}

		// // RVA: 0xB32208 Offset: 0xB32208 VA: 0xB32208
		public TransitionRoot GetCurrentTransitionRoot()
		{
			return m_menuTransitionControl.GetCurrentTransitionRoot();
		}

		// // RVA: 0xB32234 Offset: 0xB32234 VA: 0xB32234
		public TransitionInfo GetNextScene()
		{
			return m_menuTransitionControl.GetNextScene();
		}

		// // RVA: 0xB32260 Offset: 0xB32260 VA: 0xB32260
		public bool IsTransition()
		{
			return m_menuTransitionControl.IsTransition;
		}

		// // RVA: 0xB3228C Offset: 0xB3228C VA: 0xB3228C
		// public bool OnPushReturnButton() { }

		// // RVA: 0xB322B8 Offset: 0xB322B8 VA: 0xB322B8
		public int GetDefaultBgmId(SceneGroupCategory category)
		{
			return m_menuTransitionControl.GetDefaultBgmId(category);
		}

		// // RVA: 0xB2B190 Offset: 0xB2B190 VA: 0xB2B190
		public void InputEnable()
		{
			m_inputDisableCount--;
			if(m_inputDisableCount < 0)
				m_inputDisableCount = 0;
			m_menuTransitionControl.SetHeaderMenuButtonEnable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonEnable();
			m_menuTransitionControl.SetFooterMenuButtonEnable(MenuFooterControl.Button.All);
			m_menuTransitionControl.SetHelpButtonEnable();
			m_lobbyButtonControl.EnableButton(true);
		}

		// // RVA: 0xB2AAD4 Offset: 0xB2AAD4 VA: 0xB2AAD4
		public void InputDisable()
		{
			m_inputDisableCount++;
			m_menuTransitionControl.SetHeaderMenuButtonDisable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonDisable();
			m_menuTransitionControl.SetFooterMenuButtonDisable(MenuFooterControl.Button.All);
			m_menuTransitionControl.SetHelpButtonDisable();
			m_lobbyButtonControl.EnableButton(false);
		}

		// // RVA: 0xB322EC Offset: 0xB322EC VA: 0xB322EC
		public void RaycastEnable()
		{
			m_raycastDisableCount--;
			if (m_raycastDisableCount > 0)
				return;
			m_uiRaycaster.enabled = true;
			m_raycastDisableCount = 0;
		}

		// // RVA: 0xB32338 Offset: 0xB32338 VA: 0xB32338
		public void RaycastDisable()
		{
			if(m_raycastDisableCount == 0)
			{
				m_uiRaycaster.enabled = false;
			}
			m_raycastDisableCount++;
		}

		// // RVA: 0xB32384 Offset: 0xB32384 VA: 0xB32384
		public void UpdateEnterToHomeTime()
		{
			m_enterToHomeTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}

		// // RVA: 0xB32468 Offset: 0xB32468 VA: 0xB32468
		public void HeaderEnter()
		{
			HeaderMenu.MenuStack.EnterLabel();
			HeaderMenu.Enter(false);
			HelpButton.TryEnter();
		}

		// // RVA: 0xB32500 Offset: 0xB32500 VA: 0xB32500
		public void HeaderLeave()
		{
			HeaderMenu.MenuStack.LeaveLabel(false);
			HeaderMenu.Leave(false);
			HelpButton.TryLeave();
		}

		// // RVA: 0xB3259C Offset: 0xB3259C VA: 0xB3259C
		public void FooterEnter()
		{
			FooterMenu.Enter(false);
		}

		// // RVA: 0xB325D0 Offset: 0xB325D0 VA: 0xB325D0
		public void FooterLeave()
		{
			FooterMenu.Leave(false);
		}

		// // RVA: 0xB32604 Offset: 0xB32604 VA: 0xB32604
		public void ShowSnsNotice(int snsId, UnityAction pushAction)
		{
			if(pushAction == null)
			{
				pushAction = () =>
				{
					//0xB37CF8
					HomeArgs arg = new HomeArgs();
					arg.SetOpenSns(true);
					m_menuTransitionControl.Mount(TransitionUniqueId.HOME, arg, true, 0);
				};
			}
			GameManager.Instance.ShowSnsNotice(snsId, pushAction, true);
		}

		// // RVA: 0xB32704 Offset: 0xB32704 VA: 0xB32704
		public void ShowOfferNotice(UnityAction pushAction)
		{
			if(pushAction == null)
			{ 
				pushAction = () =>
				{
					//0xB37DC0
					m_menuTransitionControl.Mount(TransitionUniqueId.OFFERSELECT, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
					KDHGBOOECKC.HHCJCDFCLOB.HJOLFCDAIGE(BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva/*3*/);
				};
			}
			GameManager.Instance.ShowOfferNotice(pushAction, true);
		}

		// // RVA: 0xB327F0 Offset: 0xB327F0 VA: 0xB327F0
		public void ShowDivaStatusPopupWindow(FFHPBEPOMAK_DivaInfo diva, DFKGGBMFFGB_PlayerInfo playerData, EEDKAACNBBG_MusicData musicData, bool isMoment, TransitionList.Type transitionName = TransitionList.Type.UNDEFINED, Action callBack = null, bool isChangeScene = true, bool isCloseOnly = false, int divaSlotNumber = -1, bool isGoDiva = false)
		{
			m_statusWindowControl.ShowDivaStatusPopupWindow(diva, playerData, null, musicData, isMoment, transitionName, callBack, false, isChangeScene, isCloseOnly, divaSlotNumber, isGoDiva);
		}

		// // RVA: 0xB32898 Offset: 0xB32898 VA: 0xB32898
		// public void ShowFriendDivaStatusPopupWindow(EAJCBFGKKFA friendData, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isMoment, TransitionList.Type transitionName = -2, Action callBack, bool isChangeScene = False) { }

		// // RVA: 0xB32938 Offset: 0xB32938 VA: 0xB32938
		public void ShowSceneStatusPopupWindow(GCIJNCFDNON_SceneInfo scene, DFKGGBMFFGB_PlayerInfo playerData, bool isMoment, TransitionList.Type transitionName = TransitionList.Type.UNDEFINED, Action callBack = null, bool isFriend = false, bool isReward = false, SceneStatusParam.PageSave pageSave = SceneStatusParam.PageSave.Player, bool isDisableZoom = false)
		{
			if(!isFriend && !isReward)
			{
				scene.LEHDLBJJBNC_SetNotNew();
				scene.CADENLBDAEB_New = false;
			}
			m_statusWindowControl.ShowSceneStatusPopupWindow(scene, playerData, isMoment, 
			transitionName, callBack, isFriend, isReward, pageSave, isDisableZoom);
		}

		// // RVA: 0xB32A3C Offset: 0xB32A3C VA: 0xB32A3C
		public void TryShowPopupWindow(TransitionRoot root, DFKGGBMFFGB_PlayerInfo playerData, EEDKAACNBBG_MusicData musicData, bool isMoment, TransitionList.Type transitionName, Action closeCallBack)
		{
			if (root.PrevTransition != TransitionList.Type.SCENE_SELECT &&
				root.PrevTransition != TransitionList.Type.SCENE_ABILITY_RELEASE_LIST &&
				root.PrevTransition != TransitionList.Type.DIVA_SELECT_LIST &&
				root.PrevTransition != TransitionList.Type.DIVA_GROWTH_CONF &&
				root.PrevTransition != TransitionList.Type.SCENE_GROWTH &&
				root.PrevTransition != TransitionList.Type.COSTUME_SELECT)
				return;
			m_statusWindowControl.TryShowPopupWindow(playerData, musicData, isMoment, transitionName, closeCallBack);
		}

		// // RVA: 0xB32BA0 Offset: 0xB32BA0 VA: 0xB32BA0
		public void ShowSortWindow(PopupSortMenu.SortPlace place, UnityAction<PopupSortMenu> okCallBack, Action endCallBack)
		{
			m_sortWindowControl.Show(place, 0, 0, okCallBack, endCallBack, SortItem.None);
		}

		// // RVA: 0xB32C00 Offset: 0xB32C00 VA: 0xB32C00
		public void ShowSortWindow(PopupSortMenu.SortPlace place, SortItem sortItem, UnityAction<PopupSortMenu> okCallBack, Action endCallBack)
		{
			m_sortWindowControl.Show(place, 0, 0, okCallBack, endCallBack, sortItem);
		}

		// // RVA: 0xB32C5C Offset: 0xB32C5C VA: 0xB32C5C
		public void ShowSortWindow(PopupSortMenu.SortPlace place, int divaId, int attrId, UnityAction<PopupSortMenu> okCallBack, Action endCallBack)
		{
			m_sortWindowControl.Show(place, divaId, attrId, okCallBack, endCallBack, SortItem.None);
		}

		// // RVA: 0xB32CC4 Offset: 0xB32CC4 VA: 0xB32CC4
		public void ShowSortWindow(PopupFilterSort.Scene a_type, UnityAction<PopupFilterSort> okCallBack, Action endCallBack, bool a_is_save = true)
		{
			m_popupFilterSortWindowContrl.Show(a_type, okCallBack, endCallBack, a_is_save);
		}

		// // RVA: 0xB32D1C Offset: 0xB32D1C VA: 0xB32D1C
		public void ShowSortWindow(PopupFilterSortInitParam a_init_param, UnityAction<PopupFilterSort> okCallBack, Action endCallBack)
		{
			m_popupFilterSortWindowContrl.Show(a_init_param, okCallBack, endCallBack);
		}

		// // RVA: 0xB32D6C Offset: 0xB32D6C VA: 0xB32D6C
		// public void ShowSortWindow(PopupFilterSortUGUI.Scene a_type, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack, bool a_is_save = True) { }

		// // RVA: 0xB32DC4 Offset: 0xB32DC4 VA: 0xB32DC4
		public void ShowSortWindow(PopupFilterSortUGUIInitParam a_init_param, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack)
		{
			m_popupFilterSortWindowContrl.Show(a_init_param, okCallBack, endCallBack);
		}

		// // RVA: 0xB32E14 Offset: 0xB32E14 VA: 0xB32E14
		public void ShowItemListWindow(PopupItemList.ItemType type, bool isTab = false)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popupItemListSetting.TitleText = bk.GetMessageByLabel("popup_text_10");
			m_popupItemListSetting.ItemType = type;
			m_popupItemListSetting.WindowSize = SizeType.Large;
			m_popupItemListSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("other_item_show", 0) < 1 || !isTab)
			{
				m_popupItemListSetting.Tabs = new PopupTabButton.ButtonLabel[0];
			}
			else
			{
				m_popupItemListSetting.Tabs = new PopupTabButton.ButtonLabel[2]
				{
					PopupTabButton.ButtonLabel.GrowItem, PopupTabButton.ButtonLabel.OtherItem
				};
			}
			m_popupItemListSetting.DefaultTab = type == PopupItemList.ItemType.Growth ? PopupTabButton.ButtonLabel.GrowItem : PopupTabButton.ButtonLabel.OtherItem;
			this.StartCoroutineWatched(ShowItemListWindowCoroutine());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7EC4 Offset: 0x6C7EC4 VA: 0x6C7EC4
		// // RVA: 0xB331B4 Offset: 0xB331B4 VA: 0xB331B4
		private IEnumerator ShowItemListWindowCoroutine()
		{
			//0xB3F4DC
			PopupWindowManager.Show(m_popupItemListSetting, null, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0xB37F94
				(content as PopupItemList).ChangeList(label);
			}, null, null);
			yield break;
		}

		// // RVA: 0xB33260 Offset: 0xB33260 VA: 0xB33260
		public void ShowItemDetail(int id, int count, ButtonInfo[] buttons, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack)
		{
			m_popupItemDetailSettinig.TitleText = MessageManager.Instance.GetMessage("menu", "item_detail_popup_title_00");
			m_popupItemDetailSettinig.ItemId = id;
			m_popupItemDetailSettinig.SubId = 0;
			m_popupItemDetailSettinig.Count = count;
			m_popupItemDetailSettinig.IsShop = false;
			m_popupItemDetailSettinig.OverrideName = "";
			m_popupItemDetailSettinig.OverrideText = "";
			m_popupItemDetailSettinig.WindowSize = SizeType.Middle;
			m_popupItemDetailSettinig.SetParent(transform);
			if (buttons == null)
			{
				m_popupItemDetailSettinig.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
			}
			else
				m_popupItemDetailSettinig.Buttons = buttons;
			PopupWindowManager.Show(m_popupItemDetailSettinig, buttonCallBack, null, null, null, true, true, false);
		}

		// // RVA: 0xB335DC Offset: 0xB335DC VA: 0xB335DC
		public void ShowItemDetail(int id, int count, Action closeCallback)
		{
			m_popupItemDetailSettinig.TitleText = MessageManager.Instance.GetMessage("menu", "item_detail_popup_title_00");
			m_popupItemDetailSettinig.ItemId = id;
			m_popupItemDetailSettinig.SubId = 0;
			m_popupItemDetailSettinig.Count = count;
			m_popupItemDetailSettinig.IsShop = false;
			m_popupItemDetailSettinig.OverrideName = "";
			m_popupItemDetailSettinig.OverrideText = "";
			m_popupItemDetailSettinig.WindowSize = SizeType.Middle;
			m_popupItemDetailSettinig.SetParent(transform);
			m_popupItemDetailSettinig.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_popupItemDetailSettinig, null, null, null, null, true, true, false, null, closeCallback);
		}

		// // RVA: 0xB3394C Offset: 0xB3394C VA: 0xB3394C
		public void ShowItemDetail(int id, int subId, int count, string name, string desc, Action closeCallback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_popupItemDetailSettinig.TitleText = bk.GetMessageByLabel("item_detail_popup_title_00");
			m_popupItemDetailSettinig.ItemId = id;
			m_popupItemDetailSettinig.SubId = subId;
			m_popupItemDetailSettinig.Count = count;
			m_popupItemDetailSettinig.IsShop = false;
			m_popupItemDetailSettinig.OverrideName = name;
			m_popupItemDetailSettinig.OverrideText = desc;
			m_popupItemDetailSettinig.WindowSize = SizeType.Middle;
			m_popupItemDetailSettinig.SetParent(transform);
			m_popupItemDetailSettinig.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_popupItemDetailSettinig, null, null, null, null, true, true, false, null, closeCallback);
		}

		// // RVA: 0xB33CB0 Offset: 0xB33CB0 VA: 0xB33CB0
		public PopupWindowControl ShowItemDetail(int id, string title, string desc, bool isShop = false)
		{
			m_popupItemDetailSettinig.TitleText = title;
			m_popupItemDetailSettinig.ItemId = id;
			m_popupItemDetailSettinig.SubId = 0;
			m_popupItemDetailSettinig.Count = 0;
			m_popupItemDetailSettinig.IsShop = isShop;
			m_popupItemDetailSettinig.OverrideName = "";
			m_popupItemDetailSettinig.OverrideText = desc;
			m_popupItemDetailSettinig.WindowSize = SizeType.Middle;
			m_popupItemDetailSettinig.SetParent(transform);
			m_popupItemDetailSettinig.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			return PopupWindowManager.Show(m_popupItemDetailSettinig, null, null, null, null);
		}

		// // RVA: 0xB33FA0 Offset: 0xB33FA0 VA: 0xB33FA0
		public PopupWindowControl ShowGoDivaStatusDetail(FFHPBEPOMAK_DivaInfo divaData, Action endCallback)
		{
			LayoutPopupEventGoDivaStatus.StatusParamSet p = new LayoutPopupEventGoDivaStatus.StatusParamSet();
			p.soul.totalLevel = divaData.IHANGGCHPAL.KAMIJDBFGDB_EvSoLevel;
			p.voice.totalLevel = divaData.IHANGGCHPAL.BPEFIIEPJBM_EvVoLevel;
			p.charm.totalLevel = divaData.IHANGGCHPAL.DNFEEOODOBF_EvChLevel;
			p.soul.upStatus = divaData.IHANGGCHPAL.PNOKIEEILJN();
			p.voice.upStatus = divaData.IHANGGCHPAL.LCDIGPJJJGI();
			p.charm.upStatus = divaData.IHANGGCHPAL.KDKCMCBLEMG();
			p.soul.totalStatus = divaData.JLJGCBOHJID_Status.soul;
			p.voice.totalStatus = divaData.JLJGCBOHJID_Status.vocal;
			p.charm.totalStatus = divaData.JLJGCBOHJID_Status.charm;
			PopupEventGoDivaStatusSetting s = new PopupEventGoDivaStatusSetting();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			s.TitleText = bk.GetMessageByLabel("popup_godiva_status_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = 0;
			s.IsCaption = true;
			s.m_statusParamSet = p;
			return PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xB38674
				if(endCallback != null)
					endCallback();
			}, null, null, null);
		}

		// // RVA: 0xB345E4 Offset: 0xB345E4 VA: 0xB345E4
		public PopupItemDetail.PopupItemDetailSetting CreateIconTextContent(int id, string title, SizeType size, string name, string desc, ButtonInfo[] buttons, bool isCaption = true)
		{
			m_popupItemDetailSettinig.ItemId = id;
			m_popupItemDetailSettinig.SubId = 0;
			m_popupItemDetailSettinig.Count = 0;
			m_popupItemDetailSettinig.IsShop = false;
			m_popupItemDetailSettinig.OverrideName = name;
			m_popupItemDetailSettinig.OverrideText = desc;
			m_popupItemDetailSettinig.WindowSize = size;
			m_popupItemDetailSettinig.SetParent(transform);
			m_popupItemDetailSettinig.TitleText = title;
			m_popupItemDetailSettinig.Buttons = buttons;
			m_popupItemDetailSettinig.WindowSize = size;
			m_popupItemDetailSettinig.IsCaption = isCaption;
			return m_popupItemDetailSettinig;
		}

		// // RVA: 0xB347DC Offset: 0xB347DC VA: 0xB347DC
		public void ShowCostumeDetailWindow(CKFGMNAIBNG data, int colorId = 0)
		{
			m_popupDetailCostumeSetting.ViewCostumeData = data;
			m_popupDetailCostumeSetting.ColorId = colorId;
			PopupWindowManager.Show(m_popupDetailCostumeSetting, null, null, null, null);
		}

		// // RVA: 0xB348F4 Offset: 0xB348F4 VA: 0xB348F4
		// public void ShowAutoCombined() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C7F3C Offset: 0x6C7F3C VA: 0x6C7F3C
		// // RVA: 0xB34C48 Offset: 0xB34C48 VA: 0xB34C48
		public IEnumerator ShowPosterReleaseWindowCoroutine()
		{
			BBHNACPENDM_ServerSaveData pd; // 0x1C
			bool isHaveAnyKiraPlate; // 0x20

			//0xB40A38
			pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			isHaveAnyKiraPlate = pd.PNLOINMCCKH_Scene.MBGEHFKKOEN_HasRarePlate(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene);
			if (!pd.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture))
			{
				if (HNDLICBDEMI.AFGKIJMPNNN_IsDecoEnabled())
					yield break;
				if (pd.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsShowKiraPlatePopUp1))
					yield break;
				pd.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsShowKiraPlatePopUp1, true);
				if (isHaveAnyKiraPlate)
				{
					yield return Co.R(ShowKiraSceneReleaseWindowCoroutine(false));
					//1
				}
				else
				{
					InputDisable();
					RaycastDisable();
					bool isSaved = false;
					Save(() =>
					{
						//0xB38690
						isSaved = true;
					}, null);
					//LAB_00b40fe0;
					//2
					while (!isSaved)
						yield return null;
					InputEnable();
					RaycastEnable();
				}
			}
			else
			{
				int a2 = pd.KCCLEHLLOFG_Common.JGMBAIMPGBK_GetPstVer();
				int a = pd.PNLOINMCCKH_Scene.FLPPOODHKAB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene, DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion, a2, true);
				int b2 = pd.KCCLEHLLOFG_Common.CPJHIHMCLMN_GetDvfVer();
				int b = pd.JJFFBDLIOCF_Valkyrie.HEGDAMANPMF(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie, DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion, b2);
				int c2 = pd.KCCLEHLLOFG_Common.NLAPKFFNEOC_GetTrsVer();
				int c = pd.BEKHNNCGIEL_Costume.AAKEPLHPLPL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion, c2);
				int d2 = pd.KCCLEHLLOFG_Common.PBHMDEJPLMJ_GetDMasVer();
				int d = pd.OMMNKDEODJP_DecoItem.KFFGHBCCCIJ(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem, DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion, d2);
				//??
				if (a <= a2 && b <= b2 && c <= c2 && d <= d2)
				{
					//LAB_00b411a0;
				}
				else
				{
					InputDisable();
					RaycastDisable();
					string msg = MessageManager.Instance.GetBank("menu").GetMessageByLabel("pop_deco_release_desc") + JpStringLiterals.StringLiteral_5812;
					if (a2 < a)
					{
						msg += MessageManager.Instance.GetBank("menu").GetMessageByLabel("deco_name_poster") + JpStringLiterals.StringLiteral_5812;
						pd.KCCLEHLLOFG_Common.HHCMHDKKFNF_SetPstVer(a);
					}
					if (b2 < b)
					{
						msg += MessageManager.Instance.GetBank("menu").GetMessageByLabel("deco_name_figure") + JpStringLiterals.StringLiteral_5812;
						pd.KCCLEHLLOFG_Common.HKAMGHBKNBH_SetDvfVer(b);
					}
					if (c2 < c)
					{
						msg += MessageManager.Instance.GetBank("menu").GetMessageByLabel("deco_name_torso") + JpStringLiterals.StringLiteral_5812;
						pd.KCCLEHLLOFG_Common.GCCOOJJHIAM_SetTrsVer(c);
					}
					if (d2 < d)
					{
						msg += MessageManager.Instance.GetBank("menu").GetMessageByLabel("deco_name_decomascot") + JpStringLiterals.StringLiteral_5812;
						pd.KCCLEHLLOFG_Common.JAHBNIMDNHJ_DMasVer(d);
					}
					ButtonInfo[] buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					TextPopupSetting setting = PopupWindowManager.CrateTextContent("", SizeType.Small, msg, buttons, false, false);
					bool done = false;
					bool close = false;
					Save(() =>
					{
						//0xB386A4
						done = true;
					}, null);
					PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xB386B0
						close = true;
					}, null, null, null, true, true, false);
					while (!close)
						yield return null;
					//3
					while (!done)
						yield return null;
					//4
					InputEnable();
					RaycastEnable();
				}
				//LAB_00b411a0
				if (isHaveAnyKiraPlate)
				{
					if (!pd.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsShowKiraPlatePopUp2))
					{
						pd.KCCLEHLLOFG_Common.BCLKCMDGDLD(GPFlagConstant.ID.IsShowKiraPlatePopUp2, true);
						yield return Co.R(ShowKiraSceneReleaseWindowCoroutine(true));
						//5
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C7FB4 Offset: 0x6C7FB4 VA: 0x6C7FB4
		// // RVA: 0xB34CF4 Offset: 0xB34CF4 VA: 0xB34CF4
		public IEnumerator ShowKiraSceneReleaseWindowCoroutine(bool isUnlockDeco)
		{
			//0xB3F744
			InputDisable();
			RaycastDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string s = string.Format(bk.GetMessageByLabel("popup_kira_scene_release_desc_1"), bk.GetMessageByLabel("config_text_93"));
			if(isUnlockDeco)
			{
				s += "\n\n" + bk.GetMessageByLabel("popup_kira_scene_release_desc_2");
			}
			TextPopupSetting setting = PopupWindowManager.CrateTextContent("", SizeType.Small, s, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false);
			bool done = false;
			bool close = false;
			Save(() =>
			{
				//0xB386C4
				done = true;
			}, null);
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB386D0
				close = true;
			}, null, null, null);
			while(!close)
				yield return null;
			while(!done)
				yield return null;
			InputEnable();
			RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C802C Offset: 0x6C802C VA: 0x6C802C
		// // RVA: 0xB34DBC Offset: 0xB34DBC VA: 0xB34DBC
		public IEnumerator ShowGetDecoItemWindow(int id)
		{
			//0xB3E214
			PopupGetDecoItemSetting s = new PopupGetDecoItemSetting();
			s.TitleText = "";
			s.WindowSize = SizeType.Small;
			s.Type = GONMPHKGKHI_RewardView.CECMLGBLHHG.JCGKGFLCKCP_8;
			s.typeAndId = id;
			s.prevNum = 0;
			s.nextNum = 1;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			bool close = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
			{
				//0xB386E4
				close = true;
			}, null, null, null, playSeEvent:(PopupWindowControl.SeType seType) =>
			{
				//0xB38124
				if(seType != PopupWindowControl.SeType.WindowOpen)
					return false;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
				return true;
			});
			while(!close)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C80A4 Offset: 0x6C80A4 VA: 0x6C80A4
		// // RVA: 0xB34E68 Offset: 0xB34E68 VA: 0xB34E68
		public IEnumerator ShowReceiveRewardWindowCoroutine()
		{
			HighScoreRatingRank.Type grade; // 0x18
			List<HighScoreRating.UtaGradeData> rewardList; // 0x1C

			//0xB419F0
			if (!HighScoreRating.IsNotReceivedRewardUtaGrade())
				yield break;
			grade = HighScoreRating.GetUtaGrade(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EAHPKPADCPL_TotalUtaRate);
			HighScoreRating hs = new HighScoreRating();
			hs.Init();
			rewardList = hs.GetUtaGradeList(grade);
			bool done = false;
			bool error = false;
			this.StartCoroutineWatched(OEGIPPCADNA.HHCJCDFCLOB.JAAOHPKMEAF_Coroutine_Receive_UnreceivedAchivements(() =>
			{
				//0xB386F8
				done = true;
			}, () =>
			{
				//0xB38704
				done = true;
				error = true;
			}));
			while (!done)
				yield return null;
			if(!error)
			{
				int total = 0;
				for(int i = 0; i < rewardList.Count; i++)
				{
					total += rewardList[i].items.Count;
				}
				if(total > 0)
				{
					PopupMusicGradeGetRewardSetting setting = new PopupMusicGradeGetRewardSetting();
					setting.WindowSize = SizeType.Large2;
					setting.IsCaption = false;
					setting.NowGrade = grade;
					setting.RewardList = rewardList;
					setting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					GameManager.Instance.ResetViewPlayerData();
					done = false;
					error = false;
					PopupWindowManager.Show(setting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xB38710
						done = true;
					}, null, null, null, true, true, false, null, null, (PopupWindowControl.SeType type) =>
					{
						//0xB38190
						if (type != PopupWindowControl.SeType.WindowOpen)
							return false;
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
						return true;
					});
					while (!done)
						yield return null;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C811C Offset: 0x6C811C VA: 0x6C811C
		// // RVA: 0xB34F14 Offset: 0xB34F14 VA: 0xB34F14
		public IEnumerator ShowMissionStepupWindowCoroutine()
		{
			List<AMLGMLNGMFB_EventAprilFool.FOFMLBPMIIC> nextList; // 0x14
			int i; // 0x18

			//0xB3FCD8
			nextList = new List<AMLGMLNGMFB_EventAprilFool.FOFMLBPMIIC>();
			if (!GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.AAFEFCNONGL_StepUpQuest.IAPNOPFIPAG_IsShowNextInfo)
				yield break;
			List<AMLGMLNGMFB_EventAprilFool> l = new List<AMLGMLNGMFB_EventAprilFool>();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(GetCurrentScene().name == TransitionList.Type.RESULT)
			{
				if(Database.Instance.gameSetup.musicInfo == null)
					yield break;
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(Database.Instance.gameSetup.musicInfo.EventUniqueId);
				if(ev != null)
				{
					AMLGMLNGMFB_EventAprilFool aprilEv = ev as AMLGMLNGMFB_EventAprilFool;
					if(aprilEv != null && time >= aprilEv.GLIMIGNNGGB_Start && time < aprilEv.DPJCPDKALGI_End1)
						l.Add(aprilEv);
				}
            }
			else
			{
				for(i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
				{
					AMLGMLNGMFB_EventAprilFool aprilEv = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN[i] as AMLGMLNGMFB_EventAprilFool;
					if(aprilEv != null)
					{
						if(time >= aprilEv.GLIMIGNNGGB_Start && time < aprilEv.DPJCPDKALGI_End1)
							l.Add(aprilEv);
						else
							aprilEv.ALEPIOKNOCL();
					}
				}
			}
			if(l.Count == 0)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.AAFEFCNONGL_StepUpQuest.IAPNOPFIPAG_IsShowNextInfo = false;
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
				yield break;
			}
			for(i = 0; i < l.Count; i++)
			{
				List<AMLGMLNGMFB_EventAprilFool.FOFMLBPMIIC> l2 = l[i].KLJKKJLFPDF();
				l[i].ALEPIOKNOCL();
				l[i].OAFLKGCGEOA(false);
				if(l2.Count != 0)
				{
					nextList.Add(l2[0]);
				}
			}
			for(i = 0; i < nextList.Count; i++)
			{
				PopupPlayerRankupSetting.SettingParam s = new PopupPlayerRankupSetting.SettingParam();
				s.jacketId = nextList[i].JNCPEGJGHOG_JacketId;
				s.currentStep = nextList[i].JJJNKGBCFMI_CurrentStep;
				s.nextStep = nextList[i].AGKIABJHDDG_NextStep;
				s.musicName = nextList[i].NEDBBJDAFBH_MusicName;
				s.missionDesc = nextList[i].FEMMDNIELFC_MissionDesc;
				PopupPlayerRankupSetting s2 = new PopupPlayerRankupSetting();
				s2.TitleText = "";
				s2.IsCaption = false;
				s2.WindowSize = SizeType.Small;
				s2.param = s;
				s2.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool isOpen = true;
				PopupWindowManager.Show(s2, null, null, null, null, endCallBaack:() =>
				{
					//0xB38724
					isOpen = false;
				});
				yield return new WaitWhile(() =>
				{
					//0xB38730
					return isOpen;
				});
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C8194 Offset: 0x6C8194 VA: 0x6C8194
		// // RVA: 0xB34FC0 Offset: 0xB34FC0 VA: 0xB34FC0
		public IEnumerator ShowConvertRareupStarWindowCoroutine()
		{
			//0xB3DB50
			InputDisable();
			RaycastDisable();
			yield return TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0xB381FC
				return conditionId == TutorialConditionId.Condition82;
			});
			InputEnable();
			RaycastEnable();
			if (!JHLCEOOMFLN.NAMDJCPDJDD())
				yield break;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int fullItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem, 1);
			string title = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 9);
			bool isEndPopup = false;
			PopupWindowManager.Show(CreateIconTextContent(fullItemId, title, SizeType.Middle, bk.GetMessageByLabel("popup_rareup_item_convert_desc_01"), bk.GetMessageByLabel("popup_rareup_item_convert_desc_02"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, true), (PopupWindowControl ctl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB38740
				isEndPopup = true;
				JHLCEOOMFLN.PBKLIKNOMEG();
			}, null, null, null);
			while(!isEndPopup)
				yield return null;
			bool done = false;
			MenuScene.Save(() =>
			{
				//0xB38750
				done = true;
			}, null);
			while(!done)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C820C Offset: 0x6C820C VA: 0x6C820C
		// // RVA: 0xB3506C Offset: 0xB3506C VA: 0xB3506C
		public IEnumerator ShowGetLiveSkipTicketWindowCoroutine()
		{
			ILDKBCLAFPB.IPHAEFKCNMN saveData; // 0x20
			int ticketCount; // 0x24
			bool isPossibleReceveLiveSkipTicket; // 0x28
			GameObject root; // 0x2C
			AssetBundleLoadLayoutOperationBase lyOp; // 0x30

			//0xB3E720
			saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave();
			ticketCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("live_skip_ticket_present_count", 3);
			isPossibleReceveLiveSkipTicket = false;
			if (CIOECGOMILE.HHCJCDFCLOB.NKMNJIAGHBB() && ticketCount > 0)
				isPossibleReceveLiveSkipTicket = true;
			bool isShowSkipTicketPopup = saveData.MCNEIJAOLNO_Select.KMCLFGMAKPA_Skip.OBMEMOOLLEI_SkipTicketPopup;
			bool b = false;
			if(isPossibleReceveLiveSkipTicket)
			{
				InputDisable();
				RaycastDisable();
				CIOECGOMILE.HHCJCDFCLOB.ONAAEGAJBBG(ticketCount);
				bool done = false;
				Save(() =>
				{
					//0xB38778
					done = true;
				}, null);
				while (!done)
					yield return null;
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
				{
					//0xB3820C
					return conditionId == TutorialConditionId.Condition83;
				}));
				InputEnable();
				RaycastEnable();
				b = isPossibleReceveLiveSkipTicket;
			}
			//LAB_00b3f078
			if (!(b && isShowSkipTicketPopup))
				yield break;
			RaycastDisable();
			root = GameObject.Find("Canvas-Popup/Root");
			HomeGetSkipTicket layout = null;
			lyOp = AssetBundleManager.LoadLayoutAsync("ly/006.xab", "root_home_skiptkt_window_layout_root");
			yield return lyOp;
			yield return Co.R(lyOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0xB3878C
				layout = obj.GetComponent<HomeGetSkipTicket>();
			}));
			AssetBundleManager.UnloadAssetBundle("ly/006.xab", false);
			yield return null;
			RaycastEnable();
			layout.Setup(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem, 1), ticketCount);
			layout.onClickRejectCheckbox = (bool isChecked) =>
			{
				//0xB38764
				isShowSkipTicketPopup = !isChecked;
			};
			layout.transform.SetParent(root.transform, false);
			layout.transform.SetAsFirstSibling();
			bool isWait = true;
			layout.Enter(!isShowSkipTicketPopup, false, () =>
			{
				//0xB38808
				isWait = false;
			});
			while (isWait)
				yield return null;
			while (layout.IsOpen)
				yield return null;
			layout.transform.SetParent(null, false);
			saveData.MCNEIJAOLNO_Select.KMCLFGMAKPA_Skip.OBMEMOOLLEI_SkipTicketPopup = isShowSkipTicketPopup;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			Destroy(layout.gameObject);
			root = null;
			lyOp = null;
		}

		// // RVA: 0xB35118 Offset: 0xB35118 VA: 0xB35118
		public void ChangeRhythmAdjustScene()
		{
			m_menuTransitionControl.SetHeaderMenuButtonDisable(MenuHeaderControl.Button.All);
			m_menuTransitionControl.SetMenuContentButtonDisable();
			m_menuTransitionControl.SetFooterMenuButtonDisable(MenuFooterControl.Button.All);
			m_menuTransitionControl.PushStack();
			m_menuTransitionControl.SaveStack(m_menuSceneStack);
			this.StartCoroutineWatched(GotoRhythmAdjustCorotine());

		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C8284 Offset: 0x6C8284 VA: 0x6C8284
		// // RVA: 0xB3526C Offset: 0xB3526C VA: 0xB3526C
		private IEnumerator GotoRhythmAdjustCorotine()
		{
			//0xB3B310
			GameManager.Instance.fullscreenFader.Fade(0.1f, Color.black);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			SoundManager.Instance.bgmPlayer.Stop();
			yield return Co.R(m_menuTransitionControl.DestroyTransion());
			enableFade = false;
			NextScene("RhythmAdjust");
		}

		// // RVA: 0xB35318 Offset: 0xB35318 VA: 0xB35318
		public static void SaveRequest()
		{
			MenuScene.Instance.m_menuTransitionControl.SaveRequest();
		}

		// // RVA: 0xB353C4 Offset: 0xB353C4 VA: 0xB353C4
		public static void Save(IMCBBOAFION onSuccess, DJBHIFLHJLK onError)
		{
			if(!GameManager.Instance.IsTutorial)
			{
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xB38814
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					if (onSuccess != null)
						onSuccess();
				}, () =>
				{
					//0xB3885C
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
					if(onError != null)
						onError();
					Instance.GotoTitle();
				}, null);
			}
		}

		// // RVA: 0xB355A0 Offset: 0xB355A0 VA: 0xB355A0
		private void ChangeGroupCategory(SceneGroupCategory prevCategory, SceneGroupCategory nextCategory)
		{
			m_statusWindowControl.ResetHistory();
			if(prevCategory < SceneGroupCategory.GACHA)
			{
				if(prevCategory == SceneGroupCategory.HOME || prevCategory == SceneGroupCategory.FREE)
				{
					//LAB_00b35634
					Database.Instance.bonusData.ClearEpisodeBonus();
					return;
				}
			}
			else if(prevCategory < SceneGroupCategory.VOP)
			{
				if (((1 << (int)((int)prevCategory & 0xffU)) & 0x41a00U) == 0)
					return;

				//LAB_00b35634
				Database.Instance.bonusData.ClearEpisodeBonus();
			}
		}

		// // RVA: 0xB3568C Offset: 0xB3568C VA: 0xB3568C
		public static bool SaveWithAchievement(ulong checkTarget, IMCBBOAFION onSuccess, IMCBBOAFION onError)
		{
			return CIOECGOMILE.HHCJCDFCLOB.BMKEBEJJKBE(() =>
			{
				//0xB38964
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				if (onSuccess != null)
					onSuccess();
			}, () =>
			{
				//0xB389AC
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
				if (onError != null)
					onError();
				Instance.StartCoroutineWatched(Instance.GotoTitleCoroutine());
			}, checkTarget);
		}

		// // RVA: 0xB2A834 Offset: 0xB2A834 VA: 0xB2A834
		public static bool CheckDatelineAndAssetUpdate()
		{
			return PGIGNJDPCAH.MNANNMDBHMP(() =>
			{
				// 0xB3821C
				Instance.StartCoroutineWatched(Instance.GotoLoginBonsuCorotine());
			}, () =>
			{
				//0xB382C0
				Instance.StartCoroutineWatched(Instance.GotoTitleCoroutine());
			});
		}

		// // RVA: 0xB35814 Offset: 0xB35814 VA: 0xB35814
		private bool CheckDatelineAndAssetUpdateInner()
		{
			if(((uint)m_menuTransitionControl.GetCurrentScene().name & 0xfffffffeU) != (uint)TransitionList.Type.UNLOCK_COSTUME)
			{
				if(((uint)m_menuTransitionControl.GetNextScene().name & 0xfffffffeU) != (uint)TransitionList.Type.UNLOCK_COSTUME)
				{
					return CheckDatelineAndAssetUpdate();
				}
			}
			return false;
		}

		// // RVA: 0xB35920 Offset: 0xB35920 VA: 0xB35920
		public bool CheckEventLimit(IBJAKJJICBC musicData, bool isCheckDateLine = true, bool isDoTransition = true, KGCNCBOKCBA.GNENJEHKMHD_EventStatus status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5/*5*/, int eventUniqueId = 0)
		{
			if(isCheckDateLine)
			{
				if (CheckDatelineAndAssetUpdate())
					return true;
			}
			if (musicData == null)
				return false;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			long date = 0;
			if (!musicData.AJGCPCMLGKO_IsEvent)
			{
				if (!musicData.BNIAJAKIAJC_IsEventMinigame)
				{
					IKDICBBFBMI_EventBase ev = null;
					if (musicData.OEILJHENAHN_PlayEventType < 5)
					{
						if (musicData.OEILJHENAHN_PlayEventType == 0)
							return false;
						if (musicData.OEILJHENAHN_PlayEventType != 4)
						{
							//LAB_00b35f18
							ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventUniqueId);
							if (ev != null)
							{
								ev.HCDGELDHFHB_UpdateStatus(time);
								if (ev.NGOFCFJHOMI_Status <= status)
									return false;
							}
							//LAB_00b35ad8
						}
						else
						{
							ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(status);
							if (ev != null)
								return false;
							//LAB_00b35ad8
						}
					}
					else if (musicData.OEILJHENAHN_PlayEventType == 5)
					{
						date = musicData.NKEIFPPGNLH_WeeklyendTime;
						//LAB_00b35acc
						if (date >= time)
							return false;
						//LAB_00b35ad8
					}
					else if (musicData.OEILJHENAHN_PlayEventType == 10)
					{
						ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, status);
						if (ev != null)
							return false;
						//LAB_00b35ad8
					}
					else
					{
						//LAB_00b35f18
						ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventUniqueId);
						if(ev != null)
						{
							ev.HCDGELDHFHB_UpdateStatus(time);
							if (ev.NGOFCFJHOMI_Status <= status)
								return false;
						}
						//LAB_00b35ad8
					}
				}
				else
				{
					date = musicData.NOKBLCDMLPP_MinigameEventInfo.EMEKFFHCHMH_End;
					//LAB_00b35acc
					if (date >= time)
						return false;
					//LAB_00b35ad8
				}
			}
			else
			{
				date = musicData.AFCMIOIGAJN_EventInfo.EMEKFFHCHMH_End;
				//LAB_00b35acc
				if (date >= time)
					return false;
				//LAB_00b35ad8
			}
			//LAB_00b35ad8
			if (isDoTransition)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0xB38364
					Instance.Mount(TransitionUniqueId.HOME, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
			}
			else
			{
				PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "", "popup_event_end_text_3", SizeType.Small, new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}), (PopupWindowControl ctl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xB38414
						return;
					}, null, null, null);
			}
			return true;
		}

		// // RVA: 0xB36020 Offset: 0xB36020 VA: 0xB36020
		public bool CheckEventLimit(OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, bool isCheckDateLine /*= True*/, bool isDoTransition /*= True*/, KGCNCBOKCBA.GNENJEHKMHD_EventStatus status /*= 5*/, int eventUniqueId /*= 0*/)
		{
			if(isCheckDateLine)
			{
				if(CheckDatelineAndAssetUpdate())
					return true;
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
				return false;
			else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENMHPBGOOII_Week)
				return false;
			else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
			{
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(status);
				if(ev != null)
					return false;
			}
			else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
			{
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool, status);
				if(ev != null)
					return false;
			}
			else
			{
				//LAB_00b36240
				IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventUniqueId);
				if(ev != null)
				{
					ev.HCDGELDHFHB_UpdateStatus(t);
					if(ev.NGOFCFJHOMI_Status < status)
						return false;
				}
				//LAB_00b362c8
			}
			//LAB_00b362c8
			if(isDoTransition)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0xB38418
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
			}
			else
			{
				PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "", "popup_event_end_text_3", SizeType.Small, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}), (PopupWindowControl ctl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB384C8
					return;
				}, null, null, null, true, true, false);
			}
			return true;
		}

		// // RVA: 0xB36680 Offset: 0xB36680 VA: 0xB36680
		public bool CheckEventLimit(IKDICBBFBMI_EventBase controller, bool isCheckDateLine/* = True*/, bool isDoTransition/* = True*/)
		{
			if(isCheckDateLine)
			{
				if(MenuScene.CheckDatelineAndAssetUpdate())
					return true;
			}
			if(controller != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if(controller.LJOHLEGGGMC >= t)
					return false;
			}
			if(isDoTransition)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.DNABPEOICIJ(() =>
				{
					//0xB384CC
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}, false);
			}
			else
			{
				PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "popup_event_end_title", "popup_event_end_text_3", SizeType.Small, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}), (PopupWindowControl ctl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xB3857C
					return;
				}, null, null, null, true, true, false);
			}
			return true;
		}

		// // RVA: 0xB36B6C Offset: 0xB36B6C VA: 0xB36B6C
		public bool TryMusicPeriod(long musicCloseAt, int unitqueId, OHCAABOMEOF.KGOGMKMBCPP_EventType eventType, bool isMvMode, MenuScene.MusicPeriodMess mess)
		{
			if (musicCloseAt == 0)
				return false;
			if (NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() < musicCloseAt)
				return false;
			TextPopupSetting s = new TextPopupSetting();
			s.IsCaption = false;
			if(mess == MusicPeriodMess.TeamSelect)
			{
				if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					s.Text = MessageManager.Instance.GetMessage("menu", "pupup_music_select_periodover_text_004");
				}
				else
				{
					if(isMvMode)
					{
						s.Text = MessageManager.Instance.GetMessage("menu", "pupup_music_select_periodover_text_003");
					}
					else
					{
						s.Text = MessageManager.Instance.GetMessage("menu", "pupup_music_select_periodover_text_002");
					}
				}
			}
			else if(mess == MusicPeriodMess.MusicSelect)
			{
				s.Text = MessageManager.Instance.GetMessage("menu", "pupup_music_select_periodover_text_001");
			}
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB38AB4
				if(eventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL_2)
				{
					if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
					{
						Instance.HelpButton.HideEventHelpButton();
						Instance.Mount(TransitionUniqueId.MUSICSELECT, new EventMusicSelectSceneArgs(unitqueId, false, false), true, MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
					{
						Instance.HelpButton.HideEventHelpButton();
						Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(unitqueId, false, false), true, MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
				}
				else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					Instance.HelpButton.HideEventHelpButton();
					Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(unitqueId, false, false), true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					Instance.MountWithFade(TransitionUniqueId.HOME, null, true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				else if(eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
				{
					Instance.HelpButton.HideEventHelpButton();
					Instance.Mount(TransitionUniqueId.EVENTQUEST, new EventMusicSelectSceneArgs(unitqueId, false, false), true, MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}, null, null, null);
			return true;
		}

		// // RVA: 0xB36F90 Offset: 0xB36F90 VA: 0xB36F90
		public static void RemainDivaOneTime()
		{
			MenuScene.Instance.m_menuTransitionControl.RemainDivaOneTime();
		}

		// // RVA: 0xB3703C Offset: 0xB3703C VA: 0xB3703C
		private void OnShowHelpPopup(int id, int eventHelpId)
		{
			InputDisable();
			GameManager.Instance.CloseSnsNotice();
			if(eventHelpId == 0)
			{
				m_helpPopupWindowControl.Show(this, id, () =>
				{
					//0xB37E38
					InputEnable();
				});
				return;
			}
			else
			{
				VeiwOptionHelpCategoryData data = new VeiwOptionHelpCategoryData();
				data.Init(eventHelpId);
				if(data.helps.Count > 0)
				{
					if(data.helps[0] != null)
					{
						this.StartCoroutineWatched(TutorialManager.ShowTutorial(data.helps[0].helpId, () =>
						{
							//0xB37E34
							InputEnable();
						}));
						return;
					}
				}
			}
			InputEnable();
		}

		// // RVA: 0xB372CC Offset: 0xB372CC VA: 0xB372CC
		private void OnBackButton()
		{
			if(m_inputDisableCount < 1 && m_raycastDisableCount < 1)
			{
				if(!GameManager.Instance.IsTutorial && !IsRequestChangeScene)
				{
					if(!m_menuTransitionControl.DirtyChangeScene)
					{
						TransitionInfo info = m_menuTransitionControl.GetCurrentScene();
						TransitionList.Type name = info.name;
						TransitionUniqueId transId = (TransitionUniqueId)info.uniqueId;
						if(!m_menuTransitionControl.MenuFooter.IsShow())
						{
							TransitionUniqueId backId = transId;
							if(transId != TransitionUniqueId.DECO_FRIENDSEARCH)
							{
								backId = TransitionUniqueId.MUSICSELECT_RAID_RAIDACTSELECT_FRIENDSELECT;
							}
							if(transId != TransitionUniqueId.DECO_FRIENDSEARCH && transId != backId)
							{
								backId = TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_FRIENDSELECT;
								if(transId != TransitionUniqueId.HOME_RAID_RAIDACTSELECT_FRIENDSELECT)
								{
									if(transId != TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_FRIENDSELECT)
									{
										backId = TransitionUniqueId.DECO_FRIENDSEARCH_PROFIL_LOBBYMAIN;
									}
									if(transId != TransitionUniqueId.HOME_LOBBYMAIN_RAID_RAIDACTSELECT_FRIENDSELECT && transId != backId)
									{
										backId = TransitionUniqueId.DECO_DECOCHAT_PROFIL_LOBBYMAIN;
										if(transId != TransitionUniqueId.DECO_DECOCHAT_PROFIL_LOBBYMAIN)
										{
											backId = transId;
										}
										if(transId != TransitionUniqueId.DECO_DECOCHAT_PROFIL_LOBBYMAIN && backId != TransitionUniqueId.DECO_DECOVISIT_DECOVISITLIST_PROFIL_LOBBYMAIN)
										{
											backId = TransitionUniqueId.DECO_DECOVISITLIST_PROFIL_LOBBYMAIN;
											if(transId != TransitionUniqueId.DECO_DECOVISITLIST_PROFIL_LOBBYMAIN && name != TransitionList.Type.GODIVA_SAVE_UNIT_DETAIL)
											{
												if(name != TransitionList.Type.DECO_STAMP && 
													name != TransitionList.Type.PROFIL && 
													name != TransitionList.Type.DECO_CHAT && 
													name != TransitionList.Type.LOBBY_MISSION && 
													name != TransitionList.Type.RAID_ACT_SELECT && 
													name != TransitionList.Type.RAID && 
													name != TransitionList.Type.DECO_VISIT_LIST && 
													name != TransitionList.Type.DECO_XAOS_STORE && 
													name != TransitionList.Type.DECO_BAST_STORAGE && 
													name != TransitionList.Type.LOBBY_MEMBER && 
													name != TransitionList.Type.LOBBY_GROUP_SEARCH && 
													name != TransitionList.Type.LOBBY_GROUP_SELECT && 
													name != TransitionList.Type.SHOP_PRODUCT && 
													name != TransitionList.Type.VALKYRIE_TUNEUP && 
													name != TransitionList.Type.SIMULATIONLIVE_SETTING && 
													name != TransitionList.Type.TEAM_SELECT && 
													name != TransitionList.Type.BINGO_SELECT && 
													name != TransitionList.Type.BINGO_MISSION && 
													name != TransitionList.Type.OFFER_TRANSFORMATION && 
													name != TransitionList.Type.OFFER_VALKYRIESELECT && 
													name != TransitionList.Type.OFFER_FORMATION && 
													name != TransitionList.Type.OFFER_SELECT && 
													name != TransitionList.Type.SAVE_UNIT_DETAIL && 
													name != TransitionList.Type.VALKYRIE_SELECT && 
													name != TransitionList.Type.COSTUME_SELECT && 
													name != TransitionList.Type.SCENE_SELECT && 
													name != TransitionList.Type.SCENE_GROWTH
												)
												{
													return;
												}
											}
										}
									}
								}
							}
						}
						if(!PopupWindowManager.IsOpenPopupWindow())
						{
							if(!m_menuTransitionControl.MenuHeader.MenuStack.TryPerformBackButton())
							{
								if(name != TransitionList.Type.HOME)
								{
									m_menuTransitionControl.MenuFooter.MenuBar.PerformHomeClick();
									return;
								}
								GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
								GameManager.Instance.snsNotification.Close();
								PopupWindowManager.ApplicationQuitPopupShow(() =>
								{
									//0xB37E3C
									GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
								});
							}
						}
					}
				}
			}
		}

		// // RVA: 0xB37B00 Offset: 0xB37B00 VA: 0xB37B00
		public int GetInputDisableCount()
		{
			return m_inputDisableCount;
		}

		// // RVA: 0xB37B08 Offset: 0xB37B08 VA: 0xB37B08
		public int GetRaycastDisableCount()
		{
			return m_raycastDisableCount;
		}

		// // RVA: 0xB37B10 Offset: 0xB37B10 VA: 0xB37B10
		public Vector3 GetDivaCameraRotByScene(TransitionList.Type type)
		{
			return m_menuTransitionControl.GetDivaCameraRotByScene(type);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6C831C Offset: 0x6C831C VA: 0x6C831C
		// // RVA: 0xB37CCC Offset: 0xB37CCC VA: 0xB37CCC
		// private IEnumerator <GotoRhythmGame>b__148_0() { }

		public XeSys.FontInfo GetFont()
		{
			return GameManager.Instance.GetSystemFont(m_font);
		}
	}
}
