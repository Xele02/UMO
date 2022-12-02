using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class TeamSelectSceneUnit5 : LiveBeforeSceneBaseUnit5
	{
		
		private enum DispType
		{
			CurrentUnit = 0,
			UnitSet = 1,
			Prism = 2,
		}

		private enum SkipStatusType
		{
			Enable = 0,
			Story = 1,
			Lock = 2,
			Limit = 3,
			LackTicket = 4,
			Boost = 5,
			Rival = 6,
			Support = 7,
		}

		public static int UnitSetSelectIndex_Normal; // 0x0
		public static int UnitSetSelectIndex_GoDiva; // 0x4
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x67EE7C Offset: 0x67EE7C VA: 0x67EE7C
		private int m_switchDispTypeWaitFrame; // 0x64
		private static TeamSelectSceneUnit5.DispType m_dispType; // 0x8
		private UGUIObject m_headButtonsObject; // 0x68
		private UGUIObject m_unitStatusObject; // 0x6C
		private UGUIObject m_valkyrieButtonObject; // 0x70
		private UGUIObject m_unitInfoChangeButtonObject; // 0x74
		private UGUIObject m_unitInfoObject; // 0x78
		private UGUIObject m_musicInfoObject; // 0x7C
		private UGUIObject m_playButtonsObject; // 0x80
		private UGUIObject m_unitSetListButtonsObject; // 0x84
		private UGUIObject m_unitSetCloseButtonObject; // 0x88
		private UGUIObject m_unitSetSelectButtonsObject; // 0x8C
		private UGUIObject m_unitSetInfoObject; // 0x90
		private UGUIObject m_loadSaveButtonsObject; // 0x94
		private UGUIObject m_prismSettingButtonsObject; // 0x98
		private UGUIObject m_prismUnitInfoObject; // 0x9C
		private UGUIObject m_statusWindowObject; // 0xA0
		private SetDeckHeadButtons m_headButtons; // 0xA4
		private SetDeckUnitStatus m_unitStatus; // 0xA8
		private SetDeckValkyrieButton m_valkyrieButton; // 0xAC
		private SetDeckUnitInfoChangeButton m_unitInfoChangeButton; // 0xB0
		private SetDeckUnitInfo m_unitInfo; // 0xB4
		private SetDeckMusicInfo m_musicInfo; // 0xB8
		private SetDeckPlayButtons m_playButtons; // 0xBC
		private SetDeckUnitSetListButtons m_unitSetListButtons; // 0xC0
		private SetDeckUnitSetCloseButton m_unitSetCloseButton; // 0xC4
		private SetDeckUnitSetSelectButtons m_unitSetSelectButtons; // 0xC8
		private SetDeckUnitInfo m_unitSetInfo; // 0xCC
		private SetDeckLoadSaveButtons m_loadSaveButtons; // 0xD0
		private SetDeckPrismSettingButtons m_prismSettingButtons; // 0xD4
		private SetDeckUnitInfoSLive m_prismUnitInfo; // 0xD8
		private SetDeckStatusWindow m_statusWindow; // 0xDC
		private SetDeckParamCalculator m_paramCalculator = new SetDeckParamCalculator(); // 0xE0
		private SetDeckParamCalculator m_unitSetParamCalculator = new SetDeckParamCalculator(); // 0xE4
		private JLKEOGLJNOD m_viewUnitData; // 0xE8
		private EEDKAACNBBG m_viewMusicData; // 0xEC
		private EJKBKMBJMGL_EnemyData m_viewEnemyData; // 0xF0
		private int m_divaDispTypeIndex; // 0xF4
		private int m_sceneDispTypeIndex; // 0xF8
		private int m_useLiveSkipTicketCount; // 0xFC
		private bool m_isWaitOpenScene; // 0x100
		private bool m_isOpenEndAutoSetting; // 0x101
		private bool m_isDoSkip; // 0x102
		private ConfigMenu m_gameSettingMenu; // 0x104
		private bool m_isShowSubPlate; // 0x108
		private bool m_isWaitOnPostSetCanvas; // 0x109
		private bool m_isWaitActivateScene; // 0x10A
		private bool m_updateBaseScoreRatio; // 0x10B
		private SkipStatusType m_skipStatus; // 0x10C
		private bool m_isWaitEnterAnimation; // 0x110
		private bool m_isWaitExitAnimation; // 0x111
		//private TeamSelectDivaListArgs m_selectDivaListArgs = new TeamSelectDivaListArgs(); // 0x114
		//private CostumeChangeDivaArgs m_costumeChangeDivaArgs = new CostumeChangeDivaArgs(); // 0x118
		//private TeamSelectSceneListArgs m_selectSceneListArgs = new TeamSelectSceneListArgs(); // 0x11C
		//private CIKHPBBNEIM m_viewEpisodeBonus = new CIKHPBBNEIM(); // 0x120
		private PopupFilterSortUGUIInitParam m_dispTypePopupParam = new PopupFilterSortUGUIInitParam(); // 0x124
		private PopupEpisodeBonusListSetting m_episodeBonusPopupSetting = new PopupEpisodeBonusListSetting(); // 0x128
		private PopupUnitBonusContentSetting m_unitBonusPopupSetting = new PopupUnitBonusContentSetting(); // 0x12C
		private PopupValkyrieStatusSetting m_valkyriePopupSetting = new PopupValkyrieStatusSetting(); // 0x130
		private TextPopupSetting m_textPopupSetting = new TextPopupSetting(); // 0x134
		private ButtonInfo[] m_textPopupOkButtons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }; // 0x138
		private ButtonInfo[] m_textPopupButtons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } }; // 0x13C
		private PopupSkipTicketUseConfirmSetting m_skipTicketPopupSetting = new PopupSkipTicketUseConfirmSetting(); // 0x140
		private ButtonInfo[] m_skipTicketPopupButtons = new ButtonInfo[2] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
																			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }; // 0x144
		private IKDICBBFBMI m_eventCtrl; // 0x148
		private bool m_isRaidEvent; // 0x14C
		private bool m_isGoDivaEvent; // 0x14D
		private bool m_isGoDivaBonus; // 0x14E

		//private int UseLiveSkipTicketCount { get; set; } 0xA80220 0xA80234
		//private int UnitSetIndex { get; set; } 0xA80248 0xA8031C
		private EAJCBFGKKFA m_viewFriendPlayerData { get { return GameManager.Instance.SelectedGuestData; } } //0xA803F4
		//private bool IsEnableUnitInfoChange { get; } 0xA80490

		// RVA: 0xA804A4 Offset: 0xA804A4 VA: 0xA804A4 Slot: 4
		protected override void Awake()
		{
			m_useLiveSkipTicketCount = 3257895;
			IsReady = false;
			m_dispTypePopupParam.Scene = PopupFilterSortUGUI.Scene.UnitDispType;
			m_dispTypePopupParam.EnableSave = true;
			m_episodeBonusPopupSetting.WindowSize = SizeType.Large;
			m_episodeBonusPopupSetting.IsCaption = false;
			m_episodeBonusPopupSetting.SetParent(transform);
			m_episodeBonusPopupSetting.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			m_unitBonusPopupSetting.WindowSize = SizeType.Large;
			m_unitBonusPopupSetting.IsCaption = false;
			m_unitBonusPopupSetting.SetParent(transform);
			m_unitBonusPopupSetting.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			m_skipTicketPopupSetting.WindowSize = SizeType.Large;
			m_skipTicketPopupSetting.IsCaption = true;
			m_skipTicketPopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", "use_ticket_popup_title");
			m_skipTicketPopupSetting.SetParent(transform);
			m_skipTicketPopupSetting.Buttons = m_skipTicketPopupButtons;
			m_valkyriePopupSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_04");
			m_valkyriePopupSetting.SetParent(transform);
			m_valkyriePopupSetting.Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative } };
			SetupPrismPopupSetting();
			StartCoroutine(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F154 Offset: 0x72F154 VA: 0x72F154
		//// RVA: 0xA80A90 Offset: 0xA80A90 VA: 0xA80A90
		private IEnumerator Co_LoadResource()
		{
			//0xA94FF8
			yield return CreateUGUIObjectCache();
			IsReady = true;
		}

		// RVA: 0xA80B3C Offset: 0xA80B3C VA: 0xA80B3C Slot: 5
		protected override void Start()
		{
			return;
		}

		// RVA: 0xA80B44 Offset: 0xA80B44 VA: 0xA80B44 Slot: 16
		protected override void OnPreSetCanvas()
		{
			InitializeUGUIObject();
			m_headButtons.OnClickAutoSettingButton = OnClickAutoSettingButton;
			m_headButtons.OnClickUnitSetButton = OnClickUnitSetButton;
			m_headButtons.OnClickPrismButton = OnClickPrismSettingButton;
			m_headButtons.OnClickUnitButton = OnClickUnitSettingButton;
			m_headButtons.OnClickSettingButton = OnClickGameSettingButton;
			m_unitStatus.OnClickNameEditButton = OnChangeUnitName;
			m_unitStatus.OnClickEpisodeBonusButton = OnShowEpisodeBonusScenePopup;
			m_unitStatus.OnClickCheckStatusButton = OnShowStatusWindow;
			m_unitStatus.OnClickDispTypeButton = OnShowChangeStatusButton;
			m_valkyrieButton.OnClickValkyrieButton = OnClickValkyrieButton;
			m_valkyrieButton.OnStayValkyrieButton = OnStayValkyrieButton;
			m_unitInfoChangeButton.OnClickChangeButton = OnClickUnitInfoChangeButton;
			m_unitInfo.OnClickDiva = OnSelectDiva;
			m_unitInfo.OnStayDiva = OnShowDivaStatus;
			m_unitInfo.OnClickCostume = OnSelectCostume;
			m_unitInfo.OnClickScene = OnSelectScene;
			m_unitInfo.OnStayScene = OnShowSceneStatus;
			if(m_unitInfo.ExistAssistControl)
			{
				m_unitInfo.AssistControl.OnClickFriend = OnShowFriendDivaStatus;
			}
			m_unitInfo.SetTapGuard(false);
			m_musicInfo.OnClickExpectedScoreDescButton = OnShowScoreInfoPopup;
			m_musicInfo.ExpectedScoreGauge.OnClickMinusButton = () =>
			{
				//0xA936A4
				OnClickAnyButtons();
			};
			m_musicInfo.ExpectedScoreGauge.OnClickPlusButton = () =>
			{
				//0xA936CC
				OnClickAnyButtons();
			};
			m_playButtons.OnClickPlayButton = OnPlayButton;
			m_playButtons.OnClickSkipButton = OnSkipButton;
			m_unitSetListButtons.OnClickUnitButton = (int no, JLKEOGLJNOD data) =>
			{
				//0xA936F4
				OnClickAnyButtons();
			};
			m_unitSetListButtons.OnChangeUnit = OnChangeUnitSetSelect;
			m_unitSetListButtons.OnStartChangePage = OnStartChangeUnitSetPage;
			m_unitSetListButtons.OnEndChangePage = OnEndChangeUnitSetPage;
			m_unitSetCloseButton.OnClickCloseButton = OnClickUnitSetCloseButton;
			m_unitSetSelectButtons.OnClickSelectButtonLeft = () =>
			{
				//0xA9371C
				OnClickUnitSetSelectButton(-1);
			};
			m_unitSetSelectButtons.OnClickSelectButtonRight = () =>
			{
				//0xA93748
				OnClickUnitSetSelectButton(1);
			};
			m_unitSetInfo.OnClickDiva = null;
			m_unitSetInfo.OnStayDiva = null;
			m_unitSetInfo.OnClickCostume = null;
			m_unitSetInfo.OnClickScene = null;
			m_unitSetInfo.OnStayScene = null;
			m_unitSetInfo.SetTapGuard(true);
			m_loadSaveButtons.OnClickLoadButton = OnUnitSetLoad;
			m_loadSaveButtons.OnClickSaveButton = OnUnitSetSave;
			m_prismSettingButtons.OnClickOriginalSettingButton = OnClickOriginalSetting;
			m_prismUnitInfo.OnClickItem = OnClickPrismItems;
			if(Args != null)
			{
				m_dispType = DispType.CurrentUnit;
			}
			m_isGoDivaEvent = m_transitionName == TransitionList.Type.GODIVA_TEAM_SELECT;
			if(m_isGoDivaEvent)
			{
				TodoLogger.Log(0, "TODO Event");
			}
			m_viewMusicData = Database.Instance.selectedMusic.GetSelectedMusicData();
			m_viewEnemyData = Database.Instance.selectedMusic.GetEnemyData(Database.Instance.gameSetup.musicInfo.difficultyType);
			m_viewEnemyData.NPEKPHAFMGE(Database.Instance.gameSetup.musicInfo.enemyInfo.NJOPIPNGANO_CS, Database.Instance.gameSetup.musicInfo.enemyInfo.EDLACELKJIK_LS);
			UpdatePrismData(m_viewMusicData.DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo);
			m_isRaidEvent = Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid;
			if(TutorialProc.CanUnit5Help(Database.Instance.gameSetup.musicInfo))
			{
				TodoLogger.Log(0, "Tuto");
			}
			int energy = Database.Instance.selectedMusic.GetNeedEnergy(Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			m_updateBaseScoreRatio = true;
			if (PrevTransition != TransitionList.Type.STORY_SELECT && PrevTransition != TransitionList.Type.FRIEND_SELECT && PrevTransition != TransitionList.Type.EVENT_BATTLE && PrevTransition != TransitionList.Type.EVENT_GODIVA)
				m_updateBaseScoreRatio = false;
			m_eventCtrl = null;
			if (Database.Instance.gameSetup.musicInfo.gameEventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL)
			{
				TodoLogger.Log(0, "Todo Event");
			}
			UpdateEpisodeBonusList();
			m_viewUnitData = m_playerData.DPLBHAIKPGL(m_isGoDivaEvent);
			int divaSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem;
			int sceneSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem;
			m_divaDispTypeIndex = PopupSortMenu.UnitDivaSortItem.FindIndex((SortItem x) =>
			{
				//0xA93774
				return divaSortItem == (int)x;
			});
			m_sceneDispTypeIndex = PopupSortMenu.UnitSortItem.FindIndex((SortItem x) =>
			{
				//0xA93788
				return sceneSortItem == (int)x;
			});
			UpdateParamCalculator();
			if(m_updateBaseScoreRatio)
			{
				m_musicInfo.ExpectedScoreGauge.UpdateBaseGaugeRatio();
			}
			if(m_unitInfo.ExistAssistControl)
			{
				if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					TodoLogger.Log(0, "Event");
				}
				else
				{
					m_unitInfo.AssistControl.UpdateContent(m_viewFriendPlayerData, m_viewMusicData);
				}
			}
			m_musicInfo.Set(m_viewMusicData, Database.Instance.gameSetup.musicInfo, false, SetDeckMusicInfo.BottomType.ExpectedScoreGauge);
			m_musicInfo.SetPosType(SetDeckMusicInfo.PosType.Normal);
			m_skipStatus = CehckSkipStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			CheckExistOriginalSetting(m_prismData);
			SetDeckPlayButtons.SkipButtoType skipButton = SetDeckPlayButtons.SkipButtoType.Enable;
			TodoLogger.Log(0, "Fix skipButton");
			// L 909
			m_playButtons.Set(skipButton, GetSkipRestCount(), CheckPlayButtonType(Database.Instance.gameSetup.musicInfo), energy);
			m_playButtons.SetPosType(SetDeckPlayButtons.PosType.Normal);
			m_unitSetListButtons.UpdateContent(m_playerData, m_isGoDivaEvent, UnitSetIndex);
			m_prismSettingButtons.UpdateContent(m_prismData, SetDeckPrismSettingButtons.ModeType.Prism, CheckExistOriginalSetting(m_prismData));
			m_prismUnitInfo.UpdateContent(m_prismData, Database.Instance.gameSetup.musicInfo);
			m_unitStatus.SetCheckStatusButtonState(0);
			if(m_dispType == DispType.UnitSet)
			{
				ApplyUnitSetContent(UnitSetIndex);
			}
			else if (m_dispType == DispType.Prism)
			{
				ApplyCurrentUnitContent(true);
				ApplyPrismUnitContent();
			}
			else
			{
				ApplyCurrentUnitContent(false);
			}
			ApplyDispType(m_dispType);
			ApplyPrismSettingButton(m_prismData);
			m_statusWindow.gameObject.SetActive(false);
			MenuScene.Instance.BgControl.StorytBgReturn();
		}

		// RVA: 0xA853A8 Offset: 0xA853A8 VA: 0xA853A8 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !IsApplyWait() && !MenuScene.Instance.BgControl.IsLoadingStoryBg() && base.IsEndPreSetCanvas();
		}

		// RVA: 0xA8569C Offset: 0xA8569C VA: 0xA8569C Slot: 18
		protected override void OnPostSetCanvas()
		{
			StartCoroutine(Co_OnPostSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F1CC Offset: 0x72F1CC VA: 0x72F1CC
		//// RVA: 0xA856C0 Offset: 0xA856C0 VA: 0xA856C0
		//private IEnumerator Co_OnPostSetCanvas() { }

		// RVA: 0xA8576C Offset: 0xA8576C VA: 0xA8576C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isWaitOnPostSetCanvas == false;
		}

		// RVA: 0xA85788 Offset: 0xA85788 VA: 0xA85788 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			StartCoroutine(Co_EnterAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F244 Offset: 0x72F244 VA: 0x72F244
		//// RVA: 0xA857AC Offset: 0xA857AC VA: 0xA857AC
		//private IEnumerator Co_EnterAnimation() { }

		// RVA: 0xA85858 Offset: 0xA85858 VA: 0xA85858 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_isWaitEnterAnimation;
		}

		// RVA: 0xA8586C Offset: 0xA8586C VA: 0xA8586C Slot: 12
		protected override void OnStartExitAnimation()
		{
			StartCoroutine(Co_ExitAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F2BC Offset: 0x72F2BC VA: 0x72F2BC
		//// RVA: 0xA85890 Offset: 0xA85890 VA: 0xA85890
		//private IEnumerator Co_ExitAnimation() { }

		// RVA: 0xA8593C Offset: 0xA8593C VA: 0xA8593C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_isWaitExitAnimation;
		}

		// RVA: 0xA85950 Offset: 0xA85950 VA: 0xA85950 Slot: 21
		protected override void OnOpenScene()
		{
			m_isWaitOpenScene = true;
			StartCoroutine(OpenSceneCoroutine());
		}

		// RVA: 0xA85A0C Offset: 0xA85A0C VA: 0xA85A0C Slot: 22
		protected override bool IsEndOpenScene()
		{
			return !m_isWaitOpenScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F334 Offset: 0x72F334 VA: 0x72F334
		//// RVA: 0xA85980 Offset: 0xA85980 VA: 0xA85980
		//protected IEnumerator OpenSceneCoroutine() { }

		// RVA: 0xA85A40 Offset: 0xA85A40 VA: 0xA85A40 Slot: 23
		protected override void OnActivateScene()
		{
			StartCoroutine(Co_ShowHelp());
		}

		// RVA: 0xA85AF0 Offset: 0xA85AF0 VA: 0xA85AF0 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return !m_isWaitActivateScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F3AC Offset: 0x72F3AC VA: 0x72F3AC
		//// RVA: 0xA85A64 Offset: 0xA85A64 VA: 0xA85A64
		//private IEnumerator Co_ShowHelp() { }

		// RVA: 0xA85B24 Offset: 0xA85B24 VA: 0xA85B24 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			m_gameSettingMenu.Dispose();
			FinalizeUGUIObject();
			if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.Log(0, "Event");
			}
		}

		//// RVA: 0xA827E4 Offset: 0xA827E4 VA: 0xA827E4
		private void InitializeUGUIObject()
		{
			m_headButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckHeadButtons");
			m_unitStatusObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitStatus");
			m_valkyrieButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckValkyrieButton");
			m_unitInfoChangeButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfoChangeButton");
			if(!IsStoryMode() && m_transitionName != TransitionList.Type.GODIVA_TEAM_SELECT)
			{
				m_unitInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_Select");
			}
			else
			{
				m_unitInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_Edit");
			}
			m_musicInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckMusicInfo");
			m_playButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckPlayButtons");
			m_unitSetListButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetListButtons");
			m_unitSetCloseButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetCloseButton");
			m_unitSetSelectButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetSelectButtons");
			m_unitSetInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_Edit");
			m_loadSaveButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckLoadSaveButtons");
			m_prismSettingButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckPrismSettingButtons");
			m_prismUnitInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_SLive");
			m_statusWindowObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckStatusWindow");

			m_headButtonsObject.instanceObject.SetActive(true);
			m_unitStatusObject.instanceObject.SetActive(true);
			m_valkyrieButtonObject.instanceObject.SetActive(true);
			m_unitInfoChangeButtonObject.instanceObject.SetActive(true);
			m_unitInfoObject.instanceObject.SetActive(true);
			m_musicInfoObject.instanceObject.SetActive(true);
			m_playButtonsObject.instanceObject.SetActive(true);
			m_unitSetListButtonsObject.instanceObject.SetActive(true);
			m_unitSetCloseButtonObject.instanceObject.SetActive(true);
			m_unitSetSelectButtonsObject.instanceObject.SetActive(true);
			m_unitSetInfoObject.instanceObject.SetActive(true);
			m_loadSaveButtonsObject.instanceObject.SetActive(true);
			m_prismSettingButtonsObject.instanceObject.SetActive(true);
			m_prismUnitInfoObject.instanceObject.SetActive(true);
			m_statusWindowObject.instanceObject.SetActive(true);

			m_headButtons = m_headButtonsObject.instanceObject.GetComponentInChildren<SetDeckHeadButtons>();
			m_unitStatus = m_unitStatusObject.instanceObject.GetComponentInChildren<SetDeckUnitStatus>();
			m_valkyrieButton = m_valkyrieButtonObject.instanceObject.GetComponentInChildren<SetDeckValkyrieButton>();
			m_unitInfoChangeButton = m_unitInfoChangeButtonObject.instanceObject.GetComponentInChildren<SetDeckUnitInfoChangeButton>();
			m_unitInfo = m_unitInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfo>();
			m_musicInfo = m_musicInfoObject.instanceObject.GetComponentInChildren<SetDeckMusicInfo>();
			m_playButtons = m_playButtonsObject.instanceObject.GetComponentInChildren<SetDeckPlayButtons>();
			m_unitSetListButtons = m_unitSetListButtonsObject.instanceObject.GetComponentInChildren<SetDeckUnitSetListButtons>();
			m_unitSetCloseButton = m_unitSetCloseButtonObject.instanceObject.GetComponentInChildren<SetDeckUnitSetCloseButton>();
			m_unitSetSelectButtons = m_unitSetSelectButtonsObject.instanceObject.GetComponentInChildren<SetDeckUnitSetSelectButtons>();
			m_unitSetInfo = m_unitSetInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfo>();
			m_loadSaveButtons = m_loadSaveButtonsObject.instanceObject.GetComponentInChildren<SetDeckLoadSaveButtons>();
			m_prismSettingButtons = m_prismSettingButtonsObject.instanceObject.GetComponentInChildren<SetDeckPrismSettingButtons>();
			m_prismUnitInfo = m_prismUnitInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfoSLive>();
			m_statusWindow = m_statusWindowObject.instanceObject.GetComponentInChildren<SetDeckStatusWindow>();

			m_headButtonsObject.SetParent(transform);
			m_unitStatusObject.SetParent(transform);
			m_valkyrieButtonObject.SetParent(transform);
			m_unitInfoChangeButtonObject.SetParent(transform);
			m_unitInfoObject.SetParent(transform);
			m_musicInfoObject.SetParent(transform);
			m_playButtonsObject.SetParent(transform);
			m_unitSetListButtonsObject.SetParent(transform);
			m_unitSetCloseButtonObject.SetParent(transform);
			m_unitSetSelectButtonsObject.SetParent(transform);
			m_unitSetInfoObject.SetParent(transform);
			m_loadSaveButtonsObject.SetParent(transform);
			m_prismSettingButtonsObject.SetParent(transform);
			m_prismUnitInfoObject.SetParent(transform);
			m_statusWindowObject.SetParent(transform);

			m_unitSetInfo.transform.SetAsLastSibling();
			m_prismUnitInfo.transform.SetAsLastSibling();
			m_unitInfo.transform.SetAsLastSibling();
			m_unitInfoChangeButton.transform.SetAsLastSibling();
			m_unitSetSelectButtons.transform.SetAsLastSibling();
			m_unitStatus.transform.SetAsLastSibling();
			m_prismSettingButtons.transform.SetAsLastSibling();
			m_valkyrieButton.transform.SetAsLastSibling();
			m_headButtons.transform.SetAsLastSibling();
			m_unitSetListButtons.transform.SetAsLastSibling();
			m_unitSetCloseButton.transform.SetAsLastSibling();
			m_musicInfo.transform.SetAsLastSibling();
			m_playButtons.transform.SetAsLastSibling();
			m_loadSaveButtons.transform.SetAsLastSibling();
			m_statusWindow.transform.SetAsLastSibling();

			ClearUGUIObjectListener();
			HideUGUIObject();
		}

		//// RVA: 0xA85D5C Offset: 0xA85D5C VA: 0xA85D5C
		//private void FinalizeUGUIObject() { }

		//// RVA: 0xA864C0 Offset: 0xA864C0 VA: 0xA864C0
		//private void ClearUGUIObjectListener() { }

		//// RVA: 0xA86860 Offset: 0xA86860 VA: 0xA86860
		//private void HideUGUIObject() { }

		//// RVA: 0xA86D6C Offset: 0xA86D6C VA: 0xA86D6C
		//private bool IsStoryMode() { }

		//// RVA: 0xA86490 Offset: 0xA86490 VA: 0xA86490
		//private bool CheckUseAssist() { }

		//// RVA: 0xA8406C Offset: 0xA8406C VA: 0xA8406C
		private void UpdateEpisodeBonusList()
		{
			if (((int)Database.Instance.gameSetup.musicInfo.gameEventType | 4) == 4)
				return;
			if (m_eventCtrl == null)
				return;
			TodoLogger.Log(0, "Event");
		}

		//// RVA: 0xA86E48 Offset: 0xA86E48 VA: 0xA86E48
		//private void UpdateEpisodeBonusList(int unitSetIndex) { }

		//// RVA: 0xA86FA0 Offset: 0xA86FA0 VA: 0xA86FA0
		//private void UpdateUnitBonus() { }

		//// RVA: 0xA8711C Offset: 0xA8711C VA: 0xA8711C
		//private void UpdateUnitBonus(int unitSetIndex) { }

		//// RVA: 0xA847FC Offset: 0xA847FC VA: 0xA847FC
		//private SetDeckPlayButtons.PlayButtonType CheckPlayButtonType(GameSetupData.MusicInfo musicInfo) { }

		//// RVA: 0xA84314 Offset: 0xA84314 VA: 0xA84314
		//private TeamSelectSceneUnit5.SkipStatusType CehckSkipStatus(long consumeTime) { }

		//// RVA: 0xA84714 Offset: 0xA84714 VA: 0xA84714
		//private SetDeckPlayButtons.SkipButtoType ConvertSkipButtonType(TeamSelectSceneUnit5.SkipStatusType skipStatus) { }

		//// RVA: 0xA84730 Offset: 0xA84730 VA: 0xA84730
		//private int GetSkipRestCount() { }

		//// RVA: 0xA841B4 Offset: 0xA841B4 VA: 0xA841B4
		private void UpdateParamCalculator()
		{
			m_paramCalculator.Calc(Database.Instance.gameSetup.musicInfo, m_playerData, m_viewUnitData,
				m_viewMusicData, m_viewFriendPlayerData, m_viewEnemyData, Database.Instance.bonusData.EffectiveEpisodeBonus, 
				m_isRaidEvent);
		}

		//// RVA: 0xA8520C Offset: 0xA8520C VA: 0xA8520C
		//private void ApplyDispType(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA84DA4 Offset: 0xA84DA4 VA: 0xA84DA4
		//private void ApplyCurrentUnitContent(bool forPrism = False) { }

		//// RVA: 0xA84920 Offset: 0xA84920 VA: 0xA84920
		//private void ApplyUnitSetContent(int unitSetIndex) { }

		//// RVA: 0xA850FC Offset: 0xA850FC VA: 0xA850FC
		//private void ApplyPrismUnitContent() { }

		//// RVA: 0xA872A0 Offset: 0xA872A0 VA: 0xA872A0
		//private void SetExpectedScoreGauge() { }

		//// RVA: 0xA874DC Offset: 0xA874DC VA: 0xA874DC
		//private void ApplyUnitContent(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA87534 Offset: 0xA87534 VA: 0xA87534
		//private void UpdateContent() { }

		//// RVA: 0xA8548C Offset: 0xA8548C VA: 0xA8548C
		//private bool IsApplyWait() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72F424 Offset: 0x72F424 VA: 0x72F424
		//// RVA: 0xA875CC Offset: 0xA875CC VA: 0xA875CC
		//private IEnumerator Co_EnterContents(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA87694 Offset: 0xA87694 VA: 0xA87694
		//private void EnterNecessaryContent(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA87E3C Offset: 0xA87E3C VA: 0xA87E3C
		//private void LeaveUnnecessaryContent(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA883BC Offset: 0xA883BC VA: 0xA883BC
		//private void SetActiveNecessaryContent(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA8895C Offset: 0xA8895C VA: 0xA8895C
		//private void SetInactiveUnnecessaryContent(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA88E24 Offset: 0xA88E24 VA: 0xA88E24
		//private void LeaveContents() { }

		//// RVA: 0xA89300 Offset: 0xA89300 VA: 0xA89300
		//private bool IsPlayingContents() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72F49C Offset: 0x72F49C VA: 0x72F49C
		//// RVA: 0xA89790 Offset: 0xA89790 VA: 0xA89790
		//private IEnumerator Co_SwitchContents(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA89858 Offset: 0xA89858 VA: 0xA89858
		//private void SetTitleInOut(TeamSelectSceneUnit5.DispType prevType, TeamSelectSceneUnit5.DispType nextType) { }

		//// RVA: 0xA89B58 Offset: 0xA89B58 VA: 0xA89B58
		//private bool IsUseTitle(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA85328 Offset: 0xA85328 VA: 0xA85328
		//private void ApplyPrismSettingButton(AOJGDNFAIJL.AMIECPBIALP prismData) { }

		//// RVA: 0xA89B68 Offset: 0xA89B68 VA: 0xA89B68
		private void OnPlayButton()
		{
			TodoLogger.Log(0, "OnPlayButton");
		}

		//// RVA: 0xA8C708 Offset: 0xA8C708 VA: 0xA8C708
		private void OnSkipButton()
		{
			TodoLogger.Log(0, "OnSkipButton");
		}

		//// RVA: 0xA8A680 Offset: 0xA8A680 VA: 0xA8A680
		//private void PreGameSkipShow(Action onContinue) { }

		//// RVA: 0xA8C374 Offset: 0xA8C374 VA: 0xA8C374
		//private void PreGameSettingShow(Action onContinue) { }

		//// RVA: 0xA8B940 Offset: 0xA8B940 VA: 0xA8B940
		//private void AdvanceGame() { }

		//// RVA: 0xA8D2EC Offset: 0xA8D2EC VA: 0xA8D2EC
		//private void SettingCompleteShow(Action onClose) { }

		//// RVA: 0xA89EF8 Offset: 0xA89EF8 VA: 0xA89EF8
		//private bool CheckSetAllDiva() { }

		//// RVA: 0xA8A228 Offset: 0xA8A228 VA: 0xA8A228
		//private void NotSetAllDivaShow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72F514 Offset: 0x72F514 VA: 0x72F514
		//// RVA: 0xA8D5D0 Offset: 0xA8D5D0 VA: 0xA8D5D0
		//private IEnumerator Co_SwitchDivaSelectDisplay() { }

		//// RVA: 0xA8A504 Offset: 0xA8A504 VA: 0xA8A504
		//private bool IsForceSkip() { }

		//// RVA: 0xA8D67C Offset: 0xA8D67C VA: 0xA8D67C
		private void OnChangeUnitName()
		{
			TodoLogger.Log(0, "OnChangeUnitName");
		}

		//// RVA: 0xA8DCDC Offset: 0xA8DCDC VA: 0xA8DCDC
		private void OnShowEpisodeBonusScenePopup()
		{
			TodoLogger.Log(0, "OnShowEpisodeBonusScenePopup");
		}

		//// RVA: 0xA8E110 Offset: 0xA8E110 VA: 0xA8E110
		private void OnShowStatusWindow()
		{
			TodoLogger.Log(0, "OnShowStatusWindow");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F58C Offset: 0x72F58C VA: 0x72F58C
		//// RVA: 0xA8E1CC Offset: 0xA8E1CC VA: 0xA8E1CC
		//private IEnumerator Co_ShowStatusWindow(bool isShow) { }

		//// RVA: 0xA8E294 Offset: 0xA8E294 VA: 0xA8E294
		private void OnShowChangeStatusButton()
		{
			TodoLogger.Log(0, "OnShowChangeStatusButton");
		}

		//// RVA: 0xA8E3E8 Offset: 0xA8E3E8 VA: 0xA8E3E8
		//private void ApplyStatusDisplayType() { }

		//// RVA: 0xA8E530 Offset: 0xA8E530 VA: 0xA8E530
		private void OnClickValkyrieButton()
		{
			TodoLogger.Log(0, "OnClickValkyrieButton");
		}

		//// RVA: 0xA8E814 Offset: 0xA8E814 VA: 0xA8E814
		private void OnStayValkyrieButton()
		{
			TodoLogger.Log(0, "OnStayValkyrieButton");
		}

		//// RVA: 0xA8EA34 Offset: 0xA8EA34 VA: 0xA8EA34
		private void OnClickUnitInfoChangeButton()
		{
			TodoLogger.Log(0, "OnClickUnitInfoChangeButton");
		}

		//// RVA: 0xA83E8C Offset: 0xA83E8C VA: 0xA83E8C
		//private SetDeckUnitInfoAnimeControl.DispType ChangeUnitInfoDispType() { }

		//// RVA: 0xA8EC04 Offset: 0xA8EC04 VA: 0xA8EC04
		//private void OnClickSubPlateButton() { }

		//// RVA: 0xA8EC70 Offset: 0xA8EC70 VA: 0xA8EC70
		//private void ShowSubPlateWindow(bool isReShow = False) { }

		//// RVA: 0xA8EEE0 Offset: 0xA8EEE0 VA: 0xA8EEE0
		private void OnSelectDiva(int slotNumber, FFHPBEPOMAK divaData)
		{
			TodoLogger.Log(0, "OnSelectDiva");
		}

		//// RVA: 0xA8F050 Offset: 0xA8F050 VA: 0xA8F050
		private void OnShowDivaStatus(int slotNumber, FFHPBEPOMAK divaData)
		{
			TodoLogger.Log(0, "OnShowDivaStatus");
		}

		//// RVA: 0xA8F1CC Offset: 0xA8F1CC VA: 0xA8F1CC
		private void OnSelectCostume(int slotNumber, FFHPBEPOMAK divaData)
		{
			TodoLogger.Log(0, "OnSelectCostume");
		}

		//// RVA: 0xA8F334 Offset: 0xA8F334 VA: 0xA8F334
		private void OnSelectScene(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK divaData, GCIJNCFDNON sceneData)
		{
			TodoLogger.Log(0, "OnSelectScene");
		}

		//// RVA: 0xA8F5B4 Offset: 0xA8F5B4 VA: 0xA8F5B4
		private void OnShowSceneStatus(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK divaData, GCIJNCFDNON sceneData)
		{
			TodoLogger.Log(0, "OnShowSceneStatus");
		}

		//// RVA: 0xA8F73C Offset: 0xA8F73C VA: 0xA8F73C
		private void OnShowFriendDivaStatus(EAJCBFGKKFA friendData)
		{
			TodoLogger.Log(0, "OnShowFriendDivaStatus");
		}

		//// RVA: 0xA8F89C Offset: 0xA8F89C VA: 0xA8F89C
		private void OnShowScoreInfoPopup()
		{
			TodoLogger.Log(0, "OnShowScoreInfoPopup");
		}

		//// RVA: 0xA8FB84 Offset: 0xA8FB84 VA: 0xA8FB84
		private void OnClickAutoSettingButton()
		{
			TodoLogger.Log(0, "OnClickAutoSettingButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F604 Offset: 0x72F604 VA: 0x72F604
		//// RVA: 0xA8FF98 Offset: 0xA8FF98 VA: 0xA8FF98
		//private IEnumerator Co_ApplyCurrentUnitContentForAutoSetting() { }

		//// RVA: 0xA90044 Offset: 0xA90044 VA: 0xA90044
		private void OnClickUnitSetButton()
		{
			TodoLogger.Log(0, "OnClickUnitSetButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F67C Offset: 0x72F67C VA: 0x72F67C
		//// RVA: 0xA900BC Offset: 0xA900BC VA: 0xA900BC
		//private IEnumerator Co_EnterUnitSet() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72F6F4 Offset: 0x72F6F4 VA: 0x72F6F4
		//// RVA: 0xA90168 Offset: 0xA90168 VA: 0xA90168
		//private IEnumerator Co_DownloadUnitSetResources() { }

		//// RVA: 0xA90214 Offset: 0xA90214 VA: 0xA90214
		private void OnClickPrismSettingButton()
		{
			TodoLogger.Log(0, "OnClickPrismSettingButton");
		}

		//// RVA: 0xA90564 Offset: 0xA90564 VA: 0xA90564
		private void OnClickUnitSettingButton()
		{
			TodoLogger.Log(0, "OnClickUnitSettingButton");
		}

		//// RVA: 0xA905E0 Offset: 0xA905E0 VA: 0xA905E0
		private void OnClickGameSettingButton()
		{
			TodoLogger.Log(0, "OnClickGameSettingButton");
		}

		//// RVA: 0xA90668 Offset: 0xA90668 VA: 0xA90668
		private void OnChangeUnitSetSelect(int unitSetIndex, JLKEOGLJNOD unitData)
		{
			TodoLogger.Log(0, "OnChangeUnitSetSelect");
		}

		//// RVA: 0xA9079C Offset: 0xA9079C VA: 0xA9079C
		private void OnStartChangeUnitSetPage()
		{
			TodoLogger.Log(0, "OnStartChangeUnitSetPage");
		}

		//// RVA: 0xA90890 Offset: 0xA90890 VA: 0xA90890
		private void OnEndChangeUnitSetPage()
		{
			TodoLogger.Log(0, "OnEndChangeUnitSetPage");
		}

		//// RVA: 0xA9092C Offset: 0xA9092C VA: 0xA9092C
		private void OnClickUnitSetCloseButton()
		{
			TodoLogger.Log(0, "OnClickUnitSetCloseButton");
		}

		//// RVA: 0xA909A8 Offset: 0xA909A8 VA: 0xA909A8
		private void OnClickUnitSetSelectButton(int tick)
		{
			TodoLogger.Log(0, "OnClickUnitSetSelectButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F76C Offset: 0x72F76C VA: 0x72F76C
		//// RVA: 0xA90A28 Offset: 0xA90A28 VA: 0xA90A28
		//private IEnumerator Co_OnClickUnitSetSelect(int tick) { }

		//// RVA: 0xA90AF0 Offset: 0xA90AF0 VA: 0xA90AF0
		private void OnUnitSetLoad()
		{
			TodoLogger.Log(0, "OnUnitSetLoad");
		}

		//// RVA: 0xA90D30 Offset: 0xA90D30 VA: 0xA90D30
		private void OnUnitSetSave()
		{
			TodoLogger.Log(0, "OnUnitSetSave");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F7E4 Offset: 0x72F7E4 VA: 0x72F7E4
		//// RVA: 0xA906F4 Offset: 0xA906F4 VA: 0xA906F4
		//private IEnumerator Co_ApplyUnitSetContent(bool isApplyUnitSetList = True) { }

		//// RVA: 0xA91058 Offset: 0xA91058 VA: 0xA91058
		//private void SaveUnitSetByCurrentUnit(int unitSetIndex) { }

		//// RVA: 0xA9117C Offset: 0xA9117C VA: 0xA9117C
		//private void LoadUnitSetForCurrentUnit(int unitSetIndex) { }

		//// RVA: 0xA912FC Offset: 0xA912FC VA: 0xA912FC
		private void OnClickOriginalSetting()
		{
			TodoLogger.Log(0, "OnClickOriginalSetting");
		}

		//// RVA: 0xA914E0 Offset: 0xA914E0 VA: 0xA914E0
		private void OnClickPrismItems(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber)
		{
			TodoLogger.Log(0, "OnClickPrismItems");
		}

		//// RVA: 0xA89EAC Offset: 0xA89EAC VA: 0xA89EAC
		private void OnClickAnyButtons()
		{
			TodoLogger.Log(0, "OnClickAnyButtons");
		}

		// RVA: 0xA91658 Offset: 0xA91658 VA: 0xA91658 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva ||
				Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				TodoLogger.Log(0, "Event");
			}
			return null;
		}

		//// RVA: 0xA917F4 Offset: 0xA917F4 VA: 0xA917F4
		//private bool CheckTutorialCondition(TutorialConditionId conditionId) { }

		//// RVA: 0xA91804 Offset: 0xA91804 VA: 0xA91804
		//private bool CheckTutorialCondition_forSwitchDispType(TutorialConditionId conditionId) { }

		//// RVA: 0xA918F8 Offset: 0xA918F8 VA: 0xA918F8
		//private void OnBackButton() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F85C Offset: 0x72F85C VA: 0x72F85C
		//// RVA: 0xA9203C Offset: 0xA9203C VA: 0xA9203C
		//private bool <Co_ShowHelp>b__101_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F86C Offset: 0x72F86C VA: 0x72F86C
		//// RVA: 0xA92044 Offset: 0xA92044 VA: 0xA92044
		//private void <NotSetAllDivaShow>b__144_0(PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F87C Offset: 0x72F87C VA: 0x72F87C
		//// RVA: 0xA920FC Offset: 0xA920FC VA: 0xA920FC
		//private void <OnChangeUnitName>b__147_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F88C Offset: 0x72F88C VA: 0x72F88C
		//// RVA: 0xA922A0 Offset: 0xA922A0 VA: 0xA922A0
		//private void <OnShowChangeStatusButton>b__151_0(PopupFilterSortUGUI content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F89C Offset: 0x72F89C VA: 0x72F89C
		//// RVA: 0xA92574 Offset: 0xA92574 VA: 0xA92574
		//private void <OnClickValkyrieButton>b__153_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8AC Offset: 0x72F8AC VA: 0x72F8AC
		//// RVA: 0xA92578 Offset: 0xA92578 VA: 0xA92578
		//private void <ShowSubPlateWindow>b__158_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8BC Offset: 0x72F8BC VA: 0x72F8BC
		//// RVA: 0xA92584 Offset: 0xA92584 VA: 0xA92584
		//private void <OnShowScoreInfoPopup>b__165_0(PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8CC Offset: 0x72F8CC VA: 0x72F8CC
		//// RVA: 0xA925D0 Offset: 0xA925D0 VA: 0xA925D0
		//private void <OnClickAutoSettingButton>b__166_0(PopupAutoSettingContent content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8DC Offset: 0x72F8DC VA: 0x72F8DC
		//// RVA: 0xA92688 Offset: 0xA92688 VA: 0xA92688
		//private void <OnClickAutoSettingButton>b__166_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8EC Offset: 0x72F8EC VA: 0x72F8EC
		//// RVA: 0xA926AC Offset: 0xA926AC VA: 0xA926AC
		//private void <OnClickAutoSettingButton>b__166_2() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8FC Offset: 0x72F8FC VA: 0x72F8FC
		//// RVA: 0xA926B8 Offset: 0xA926B8 VA: 0xA926B8
		//private void <OnUnitSetLoad>b__180_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F90C Offset: 0x72F90C VA: 0x72F90C
		//// RVA: 0xA9276C Offset: 0xA9276C VA: 0xA9276C
		//private void <OnUnitSetLoad>b__180_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F91C Offset: 0x72F91C VA: 0x72F91C
		//// RVA: 0xA92828 Offset: 0xA92828 VA: 0xA92828
		//private void <OnUnitSetSave>b__181_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F92C Offset: 0x72F92C VA: 0x72F92C
		//// RVA: 0xA92974 Offset: 0xA92974 VA: 0xA92974
		//private void <OnClickOriginalSetting>b__185_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F93C Offset: 0x72F93C VA: 0x72F93C
		//// RVA: 0xA92978 Offset: 0xA92978 VA: 0xA92978
		//private void <OnClickPrismItems>b__186_0() { }
	}
}
