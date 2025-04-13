using mcrs;
using System;
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
		private static DispType m_dispType; // 0x8
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
		private JLKEOGLJNOD_TeamInfo m_viewUnitData; // 0xE8
		private EEDKAACNBBG_MusicData m_viewMusicData; // 0xEC
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
		private TeamSelectDivaListArgs m_selectDivaListArgs = new TeamSelectDivaListArgs(); // 0x114
		private CostumeChangeDivaArgs m_costumeChangeDivaArgs = new CostumeChangeDivaArgs(); // 0x118
		private TeamSelectSceneListArgs m_selectSceneListArgs = new TeamSelectSceneListArgs(); // 0x11C
		private CIKHPBBNEIM m_viewEpisodeBonus = new CIKHPBBNEIM(); // 0x120
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
		private IKDICBBFBMI_EventBase m_eventCtrl; // 0x148
		private bool m_isRaidEvent; // 0x14C
		private bool m_isGoDivaEvent; // 0x14D
		private bool m_isGoDivaBonus; // 0x14E

		private int UseLiveSkipTicketCount { get { return m_useLiveSkipTicketCount ^ 3257895; } set { m_useLiveSkipTicketCount = value ^ 3257895; } } //0xA80220 0xA80234
		private int UnitSetIndex { get { return m_isGoDivaEvent ? UnitSetSelectIndex_GoDiva : UnitSetSelectIndex_Normal; } set { if (m_isGoDivaEvent) UnitSetSelectIndex_GoDiva = value; UnitSetSelectIndex_Normal = value; } } //0xA80248 0xA8031C
		private EAJCBFGKKFA_FriendInfo m_viewFriendPlayerData { get { return GameManager.Instance.SelectedGuestData; } } //0xA803F4
		//private bool IsEnableUnitInfoChange { get; } 0xA80490

		// RVA: 0xA804A4 Offset: 0xA804A4 VA: 0xA804A4 Slot: 4
		protected override void Awake()
		{
			UseLiveSkipTicketCount = 0;
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
			this.StartCoroutineWatched(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F154 Offset: 0x72F154 VA: 0x72F154
		//// RVA: 0xA80A90 Offset: 0xA80A90 VA: 0xA80A90
		private IEnumerator Co_LoadResource()
		{
			//0xA94FF8
			yield return Co.R(CreateUGUIObjectCache());
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
			m_unitSetListButtons.OnClickUnitButton = (int no, JLKEOGLJNOD_TeamInfo data) =>
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
				BBOPDOIIOGM b = new BBOPDOIIOGM();
				b.KHEKNNFCAOI();
				int id_ = b.EPCHEDJFAON_SelDiva;
				if(id_ < 2)
					id_ = 1;
				m_playerData.HMCMKKNLBII_LoadGoDivaUnit(id_);
				GameManager.Instance.DivaIconCache.TryLoadEventGoDivaIcon(id_);
				m_isGoDivaBonus = false;
				IBJAKJJICBC ib = Database.Instance.selectedMusic.GetSelectedMusicData() as IBJAKJJICBC;
				if(ib != null && b.GEGAEDDGNMA_Bonuses.Count != 0 && ib.OGHOPBAKEFE_IsEventSpecial)
				{
					m_isGoDivaBonus = true;
				}
				m_unitInfo.OnClickDiva = OnShowDivaStatus;
			}
			m_viewMusicData = Database.Instance.selectedMusic.GetSelectedMusicData();
			m_viewEnemyData = Database.Instance.selectedMusic.GetEnemyData(Database.Instance.gameSetup.musicInfo.difficultyType);
			m_viewEnemyData.NPEKPHAFMGE_OverrideSkill(Database.Instance.gameSetup.musicInfo.enemyInfo.NJOPIPNGANO_CS, Database.Instance.gameSetup.musicInfo.enemyInfo.EDLACELKJIK_LiveSkill);
			UpdatePrismData(m_viewMusicData.DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo);
			m_isRaidEvent = Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid;
			if(TutorialProc.CanUnit5Help(Database.Instance.gameSetup.musicInfo))
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType != 0)
					ChangeUnitInfoDispType();
			}
			int energy = Database.Instance.selectedMusic.GetNeedEnergy(Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
			m_updateBaseScoreRatio = true;
			if (PrevTransition != TransitionList.Type.STORY_SELECT && PrevTransition != TransitionList.Type.FRIEND_SELECT && PrevTransition != TransitionList.Type.EVENT_BATTLE && PrevTransition != TransitionList.Type.EVENT_GODIVA)
				m_updateBaseScoreRatio = false;
			m_eventCtrl = null;
			if(m_isRaidEvent)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				//L 722
			}
			else
			{
				if (Database.Instance.gameSetup.musicInfo.gameEventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
				{
					m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(Database.Instance.gameSetup.musicInfo.EventUniqueId);
				}
			}
			UpdateEpisodeBonusList();
			m_viewUnitData = m_playerData.DPLBHAIKPGL_GetTeam(m_isGoDivaEvent);
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
					m_unitInfo.AssistControl.UpdateContent(Database.Instance.selectedMusic.GetGhostData());
				}
				else
				{
					m_unitInfo.AssistControl.UpdateContent(m_viewFriendPlayerData, m_viewMusicData);
				}
			}
			m_musicInfo.Set(m_viewMusicData, Database.Instance.gameSetup.musicInfo, false, SetDeckMusicInfo.BottomType.ExpectedScoreGauge);
			m_musicInfo.SetPosType(SetDeckMusicInfo.PosType.Normal);
			m_skipStatus = CehckSkipStatus(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			CheckExistOriginalSetting(m_prismData);
			SetDeckPlayButtons.SkipButtoType skipButton = SetDeckPlayButtons.SkipButtoType.Enable;
			/*
			 
			Enable = 0,
			Story = 1,
			Lock = 2,
			Limit = 3,
			LackTicket = 4,
			Boost = 5,
			Rival = 6,
			Support = 7,
			 */
			/*

		   Hide = 0,
		   Enable = 1,
		   Disable = 2,
		   Lock = 3, 
			*/
			if (m_skipStatus == SkipStatusType.Lock)
				skipButton = SetDeckPlayButtons.SkipButtoType.Lock;
			else if (m_skipStatus != SkipStatusType.Enable)
				skipButton = SetDeckPlayButtons.SkipButtoType.Hide;
			TodoLogger.LogError(TodoLogger.ToCheck, "Check skipButton, read in a array somewhere");
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
			this.StartCoroutineWatched(Co_OnPostSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F1CC Offset: 0x72F1CC VA: 0x72F1CC
		//// RVA: 0xA856C0 Offset: 0xA856C0 VA: 0xA856C0
		private IEnumerator Co_OnPostSetCanvas()
		{
			//0xA954EC
			m_isWaitOnPostSetCanvas = true;
			yield return null;
			m_isWaitOnPostSetCanvas = false;
		}

		// RVA: 0xA8576C Offset: 0xA8576C VA: 0xA8576C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isWaitOnPostSetCanvas == false;
		}

		// RVA: 0xA85788 Offset: 0xA85788 VA: 0xA85788 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			this.StartCoroutineWatched(Co_EnterAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F244 Offset: 0x72F244 VA: 0x72F244
		//// RVA: 0xA857AC Offset: 0xA857AC VA: 0xA857AC
		private IEnumerator Co_EnterAnimation()
		{
			//0xA9479C
			m_isWaitEnterAnimation = true;
			SetTitleInOut(DispType.CurrentUnit, m_dispType);
			SetInactiveUnnecessaryContent(m_dispType);
			yield return Co.R(Co_EnterContents(m_dispType));
			m_isWaitEnterAnimation = false;
		}

		// RVA: 0xA85858 Offset: 0xA85858 VA: 0xA85858 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_isWaitEnterAnimation;
		}

		// RVA: 0xA8586C Offset: 0xA8586C VA: 0xA8586C Slot: 12
		protected override void OnStartExitAnimation()
		{
			this.StartCoroutineWatched(Co_ExitAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F2BC Offset: 0x72F2BC VA: 0x72F2BC
		//// RVA: 0xA85890 Offset: 0xA85890 VA: 0xA85890
		private IEnumerator Co_ExitAnimation()
		{
			//0xA94E40
			m_isWaitExitAnimation = true;
			while (IsPlayingContents())
				yield return null;
			LeaveContents();
			while (IsPlayingContents())
				yield return null;
			m_isWaitExitAnimation = false;
		}

		// RVA: 0xA8593C Offset: 0xA8593C VA: 0xA8593C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_isWaitExitAnimation;
		}

		// RVA: 0xA85950 Offset: 0xA85950 VA: 0xA85950 Slot: 21
		protected override void OnOpenScene()
		{
			m_isWaitOpenScene = true;
			this.StartCoroutineWatched(OpenSceneCoroutine());
		}

		// RVA: 0xA85A0C Offset: 0xA85A0C VA: 0xA85A0C Slot: 22
		protected override bool IsEndOpenScene()
		{
			return !m_isWaitOpenScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F334 Offset: 0x72F334 VA: 0x72F334
		//// RVA: 0xA85980 Offset: 0xA85980 VA: 0xA85980
		protected IEnumerator OpenSceneCoroutine()
		{
			int i;

			//0xA967A0
			if (IsPlayingContents())
				yield return null;
			i = 0;
			yield return null;
			i++;
			while (i <= 4)
			{
				i++;
				yield return null;
			}
			bool isWait = false;
			m_gameSettingMenu = ConfigMenu.Create(null);
			if(ConfigManager.gotoTimingScene)
			{
				if(!GameManager.Instance.IsTutorial)
				{
					isWait = true;
					m_gameSettingMenu.ShowPopupRhythm(null, (PopupButton.ButtonLabel label) =>
					{
						//0xA937A4
						isWait = false;
					});
					while (isWait)
						yield return null;
				}
			}
			MenuScene.Instance.TryShowPopupWindow(this, GameManager.Instance.ViewPlayerData, m_viewMusicData, false, m_transitionName, UpdateContent);
			if(m_isShowSubPlate)
			{
				m_isShowSubPlate = false;
				if(PrevTransition == TransitionList.Type.SCENE_GROWTH)
				{
					ShowSubPlateWindow(true);
				}
			}
			m_isWaitOpenScene = false;
		}

		// RVA: 0xA85A40 Offset: 0xA85A40 VA: 0xA85A40 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_ShowHelp());
		}

		// RVA: 0xA85AF0 Offset: 0xA85AF0 VA: 0xA85AF0 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return !m_isWaitActivateScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F3AC Offset: 0x72F3AC VA: 0x72F3AC
		//// RVA: 0xA85A64 Offset: 0xA85A64 VA: 0xA85A64
		private IEnumerator Co_ShowHelp()
		{
			//0xA95604
			m_isWaitActivateScene = true;
			if(TutorialProc.CanAutoSettingHelp())
			{
				yield return this.StartCoroutineWatched(TutorialProc.Co_TutorialAutoUnitSetting(m_headButtons.AutoSettingButton, () =>
				{
					//0xA9203C
					return m_isOpenEndAutoSetting;
				}));
			}
			if(TutorialProc.CanUnit5Help(Database.Instance.gameSetup.musicInfo))
			{
				yield return Co.R(TutorialProc.Co_TutorialUnit5(m_unitInfoChangeButton.ChangeButton));
			}
			MenuScene.Instance.InputDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition));
			MenuScene.Instance.InputEnable();
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_isWaitActivateScene = false;
		}

		// RVA: 0xA85B24 Offset: 0xA85B24 VA: 0xA85B24 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			m_gameSettingMenu.Dispose();
			FinalizeUGUIObject();
			if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
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

			m_headButtonsObject.SetParent(transform, null);
			m_unitStatusObject.SetParent(transform, null);
			m_valkyrieButtonObject.SetParent(transform, null);
			m_unitInfoChangeButtonObject.SetParent(transform, null);
			m_unitInfoObject.SetParent(transform, null);
			m_musicInfoObject.SetParent(transform, null);
			m_playButtonsObject.SetParent(transform, null);
			m_unitSetListButtonsObject.SetParent(transform, null);
			m_unitSetCloseButtonObject.SetParent(transform, null);
			m_unitSetSelectButtonsObject.SetParent(transform, null);
			m_unitSetInfoObject.SetParent(transform, null);
			m_loadSaveButtonsObject.SetParent(transform, null);
			m_prismSettingButtonsObject.SetParent(transform, null);
			m_prismUnitInfoObject.SetParent(transform, null);
			m_statusWindowObject.SetParent(transform, null);

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
		private void FinalizeUGUIObject()
		{
			ClearUGUIObjectListener();
			HideUGUIObject();
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckHeadButtons", m_headButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitStatus", m_unitStatusObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckValkyrieButton", m_valkyrieButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfoChangeButton", m_unitInfoChangeButtonObject);
			if(!IsStoryMode() && m_transitionName != TransitionList.Type.GODIVA_TEAM_SELECT)
			{
				GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_Select", m_unitInfoObject);
			}
			else
			{
				GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_Edit", m_unitInfoObject);
			}
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckMusicInfo", m_musicInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckPlayButtons", m_playButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetListButtons", m_unitSetListButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetCloseButton", m_unitSetCloseButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetSelectButtons", m_unitSetSelectButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_Edit", m_unitSetInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckLoadSaveButtons", m_loadSaveButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckPrismSettingButtons", m_prismSettingButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_SLive", m_prismUnitInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckStatusWindow", m_statusWindowObject);
			m_loadSaveButtonsObject = null;
			m_prismSettingButtonsObject = null;
			m_prismUnitInfoObject = null;
			m_statusWindowObject = null;
			m_unitSetCloseButtonObject = null;
			m_unitSetSelectButtonsObject = null;
			m_unitSetInfoObject = null;
			m_loadSaveButtonsObject = null;
			m_headButtonsObject = null;
			m_unitStatusObject = null;
			m_valkyrieButtonObject = null;
			m_unitInfoChangeButtonObject = null;
			m_unitInfoObject = null;
			m_musicInfoObject = null;
			m_playButtonsObject = null;
			m_unitSetListButtonsObject = null;
		}

		//// RVA: 0xA864C0 Offset: 0xA864C0 VA: 0xA864C0
		private void ClearUGUIObjectListener()
		{
			m_headButtons.OnClickAutoSettingButton = null;
			m_headButtons.OnClickUnitSetButton = null;
			m_headButtons.OnClickPrismButton = null;
			m_headButtons.OnClickUnitButton = null;
			m_headButtons.OnClickSettingButton = null;
			m_unitStatus.OnClickNameEditButton = null;
			m_unitStatus.OnClickCheckStatusButton = null;
			m_unitStatus.OnClickDispTypeButton = null;
			m_unitStatus.OnClickEpisodeBonusButton = null;
			m_valkyrieButton.OnClickValkyrieButton = null;
			m_valkyrieButton.OnStayValkyrieButton = null;
			m_unitInfoChangeButton.OnClickChangeButton = null;
			m_unitInfo.OnClickDiva = null;
			m_unitInfo.OnStayDiva = null;
			m_unitInfo.OnClickCostume = null;
			m_unitInfo.OnClickScene = null;
			m_unitInfo.OnStayScene = null;
			m_musicInfo.OnClickExpectedScoreDescButton = null;
			m_playButtons.OnClickPlayButton = null;
			m_playButtons.OnClickSkipButton = null;
			m_unitSetListButtons.OnChangeUnit = null;
			m_unitSetListButtons.OnStartChangePage = null;
			m_unitSetListButtons.OnEndChangePage = null;
			m_unitSetCloseButton.OnClickCloseButton = null;
			m_unitSetSelectButtons.OnClickSelectButtonLeft = null;
			m_unitSetSelectButtons.OnClickSelectButtonRight = null;
			m_unitSetInfo.OnClickDiva = null;
			m_unitSetInfo.OnStayDiva = null;
			m_unitSetInfo.OnClickCostume = null;
			m_unitSetInfo.OnClickScene = null;
			m_unitSetInfo.OnStayScene = null;
			m_loadSaveButtons.OnClickLoadButton = null;
			m_loadSaveButtons.OnClickSaveButton = null;
			m_prismSettingButtons.OnClickOriginalSettingButton = null;
			m_prismUnitInfo.OnClickItem = null;
		}

		//// RVA: 0xA86860 Offset: 0xA86860 VA: 0xA86860
		private void HideUGUIObject()
		{
			m_headButtons.InOut.Leave(0, false, null);
			m_unitStatus.InOut.Leave(0, false, null);
			m_valkyrieButton.InOut.Leave(0, false, null);
			m_unitInfoChangeButton.InOut.Leave(0, false, null);
			m_unitInfo.AnimeControl.Hide();
			m_musicInfo.InOut.Leave(0, false, null);
			m_playButtons.InOut.Leave(0, false, null);
			m_unitSetListButtons.InOut.Leave(0, false, null);
			m_unitSetCloseButton.InOut.Leave(0, false, null);
			m_unitSetSelectButtons.InOutLeft.Leave(0, false, null);
			m_unitSetSelectButtons.InOutRight.Leave(0, false, null);
			m_unitSetInfo.AnimeControl.Hide();
			m_loadSaveButtons.InOut.Leave(0, false, null);
			m_prismSettingButtons.InOut.Leave(0, false, null);
			m_prismUnitInfo.AnimeControl.Hide();
			m_statusWindow.InOut.Leave(0, false, null);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
		}

		//// RVA: 0xA86D6C Offset: 0xA86D6C VA: 0xA86D6C
		private bool IsStoryMode()
		{
			return Database.Instance.selectedMusic.GetSelectedMusicData() is LIEJFHMGNIA;
		}

		//// RVA: 0xA86490 Offset: 0xA86490 VA: 0xA86490
		//private bool CheckUseAssist() { }

		//// RVA: 0xA8406C Offset: 0xA8406C VA: 0xA8406C
		private void UpdateEpisodeBonusList()
		{
			if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 || 
				Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
				return;
			if (m_eventCtrl == null)
				return;
			Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
		}

		//// RVA: 0xA86E48 Offset: 0xA86E48 VA: 0xA86E48
		private void UpdateEpisodeBonusList(int unitSetIndex)
		{
			if ((int)Database.Instance.gameSetup.musicInfo.gameEventType == 0)
				return;
			if (m_eventCtrl == null)
				return;
			Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.NFMDGIFKPMM(unitSetIndex, 0, 0));
		}

		//// RVA: 0xA86FA0 Offset: 0xA86FA0 VA: 0xA86FA0
		private void UpdateUnitBonus()
		{
			if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
			}
		}

		//// RVA: 0xA8711C Offset: 0xA8711C VA: 0xA8711C
		private void UpdateUnitBonus(int unitSetIndex)
		{
			if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
			}
		}

		//// RVA: 0xA847FC Offset: 0xA847FC VA: 0xA847FC
		private SetDeckPlayButtons.PlayButtonType CheckPlayButtonType(GameSetupData.MusicInfo musicInfo)
		{
			if(musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid && m_eventCtrl != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
			}
			if (!musicInfo.isEnergyRequired)
				return SetDeckPlayButtons.PlayButtonType.Play;
			if (m_isRaidEvent)
				return SetDeckPlayButtons.PlayButtonType.Play_EN;
			return SetDeckPlayButtons.PlayButtonType.Play_AP;
		}

		//// RVA: 0xA84314 Offset: 0xA84314 VA: 0xA84314
		private SkipStatusType CehckSkipStatus(long consumeTime)
		{
			SkipStatusType res = SkipStatusType.Story;
			if (!IsStoryMode())
			{
				if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					if(Database.Instance.selectedMusic.GetGhostData().GAOGOMKKJON())
						return SkipStatusType.Rival;
				}
				if (Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid && m_eventCtrl != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
				}
				res = SkipStatusType.Boost;
				if(Database.Instance.gameSetup.SelectedDashIndex < 1)
				{
					res = SkipStatusType.Lock;
					if((Database.Instance.selectedMusic.GetSelectedMusicData() as IBJAKJJICBC).JHLDFOLFNGB(Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode) || RuntimeSettings.CurrentSettings.CanSkipUnplayedSongs)
					{
						res = SkipStatusType.Limit;
						if(!CIOECGOMILE.HHCJCDFCLOB.PPDOILECBAD())
						{
							res = SkipStatusType.LackTicket;
							if(CIOECGOMILE.HHCJCDFCLOB.HDKICOHCCJB(consumeTime))
							{
								res = SkipStatusType.Enable;
							}
						}
					}
				}
			}
			return res;
		}

		//// RVA: 0xA84714 Offset: 0xA84714 VA: 0xA84714
		//private SetDeckPlayButtons.SkipButtoType ConvertSkipButtonType(TeamSelectSceneUnit5.SkipStatusType skipStatus) { }

		//// RVA: 0xA84730 Offset: 0xA84730 VA: 0xA84730
		private int GetSkipRestCount()
		{
			return CIOECGOMILE.HHCJCDFCLOB.PPADGJPHDAD() - CIOECGOMILE.HHCJCDFCLOB.PIEPAMPMODI();
		}

		//// RVA: 0xA841B4 Offset: 0xA841B4 VA: 0xA841B4
		private void UpdateParamCalculator()
		{
			m_paramCalculator.Calc(Database.Instance.gameSetup.musicInfo, m_playerData, m_viewUnitData,
				m_viewMusicData, m_viewFriendPlayerData, m_viewEnemyData, Database.Instance.bonusData.EffectiveEpisodeBonus, 
				m_isRaidEvent);
		}

		//// RVA: 0xA8520C Offset: 0xA8520C VA: 0xA8520C
		private void ApplyDispType(DispType dispType)
		{
			if(dispType == DispType.Prism)
			{
				m_headButtons.SetType(SetDeckHeadButtons.Type.Prism);
				m_unitStatus.SetUnitNameEditButtonEnable(true);
				m_unitStatus.SetCheckStatusButtonEnable(false);
			}
			else if(dispType == DispType.UnitSet)
			{
				m_unitStatus.SetUnitNameEditButtonEnable(false);
				m_unitStatus.SetCheckStatusButtonEnable(true);
			}
			else if(dispType == DispType.CurrentUnit)
			{
				m_headButtons.SetType(SetDeckHeadButtons.Type.TeamSelect);
				m_unitStatus.SetUnitNameEditButtonEnable(true);
				m_unitStatus.SetCheckStatusButtonEnable(true);
			}
		}

		//// RVA: 0xA84DA4 Offset: 0xA84DA4 VA: 0xA84DA4
		private void ApplyCurrentUnitContent(bool forPrism = false)
		{
			UpdateEpisodeBonusList();
			UpdateUnitBonus();
			UpdateParamCalculator();
			m_unitStatus.UpdateContent(m_paramCalculator);
			m_unitStatus.SetUnitName(m_viewUnitData.BHKALCOAHHO_Name);
			if(!forPrism)
			{
				m_valkyrieButton.UpdateContent(m_viewUnitData, m_viewMusicData);
			}
			m_valkyrieButton.SetTapGuard(false);
			m_unitInfo.UpdateContent(m_playerData, m_viewUnitData, m_paramCalculator, m_viewMusicData, Database.Instance.gameSetup.musicInfo, m_isGoDivaEvent);
			m_unitInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
			SetExpectedScoreGauge();
			m_statusWindow.UpdateContent(m_playerData, m_viewUnitData, m_viewMusicData, m_viewEnemyData, m_viewFriendPlayerData, 0, m_isGoDivaEvent);
			m_musicInfo.ReStartMusicAttrAnime();
		}

		//// RVA: 0xA84920 Offset: 0xA84920 VA: 0xA84920
		private void ApplyUnitSetContent(int unitSetIndex)
		{
			UpdateEpisodeBonusList(unitSetIndex);
			UpdateUnitBonus(unitSetIndex);
			m_unitSetParamCalculator.Calc(Database.Instance.gameSetup.musicInfo, m_playerData, m_playerData.JKIJFGGMNAN_GetUnit(unitSetIndex, m_isGoDivaEvent), m_viewMusicData, m_viewFriendPlayerData, m_viewEnemyData, Database.Instance.bonusData.EffectiveEpisodeBonus, m_isRaidEvent);
			m_unitStatus.UpdateContent(m_unitSetParamCalculator);
			JLKEOGLJNOD_TeamInfo viewUnitData = m_playerData.JKIJFGGMNAN_GetUnit(unitSetIndex, m_isGoDivaEvent);
			m_unitStatus.SetUnitName(viewUnitData.BHKALCOAHHO_Name);
			m_valkyrieButton.UpdateContent(viewUnitData, m_viewMusicData);
			m_valkyrieButton.SetTapGuard(true);
			m_unitSetInfo.UpdateContent(m_playerData, viewUnitData, m_unitSetParamCalculator, m_viewMusicData, Database.Instance.gameSetup.musicInfo, m_isGoDivaEvent);
			m_unitSetInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
			SetExpectedScoreGauge();
			m_statusWindow.UpdateContent(m_playerData, viewUnitData, m_viewMusicData, m_viewEnemyData, m_viewFriendPlayerData, 0, m_isGoDivaEvent);
			m_loadSaveButtons.SetType(!viewUnitData.EIGKIHENKNC_HasNoDivaSet ? SetDeckLoadSaveButtons.ModeType.Overwrite : SetDeckLoadSaveButtons.ModeType.NewSave);
			m_musicInfo.ReStartMusicAttrAnime();
		}

		//// RVA: 0xA850FC Offset: 0xA850FC VA: 0xA850FC
		private void ApplyPrismUnitContent()
		{
			m_valkyrieButton.UpdateContent(m_prismData);
			m_valkyrieButton.SetTapGuard(false);
			m_prismUnitInfo.UpdateContent(m_prismData, Database.Instance.gameSetup.musicInfo);
		}

		//// RVA: 0xA872A0 Offset: 0xA872A0 VA: 0xA872A0
		private void SetExpectedScoreGauge()
		{
			int[] score = new int[10];
			float[] rank = new float[5];
			for(int i = 0; i < 10; i++)
			{
				score[i] = CMMKCEPBIHI.NDNOLJACLLC_GetScore((CMMKCEPBIHI.NOJENDEDECD_ScoreType)i);
			}
			for(int i = 0; i < rank.Length; i++)
			{
				rank[i] = CMMKCEPBIHI.GPCKPNJGANO_GetRank((ResultScoreRank.Type)i);
			}
			m_musicInfo.ExpectedScoreGauge.Set(CMMKCEPBIHI.KHCOOPDAGOE_ScoreRank, CMMKCEPBIHI.FDLECNKJCGG_GaugeRatio, rank, score);
		}

		//// RVA: 0xA874DC Offset: 0xA874DC VA: 0xA874DC
		private void ApplyUnitContent(DispType dispType)
		{
			if(dispType == DispType.Prism)
			{
				ApplyPrismUnitContent();
			}
			else if(dispType == DispType.CurrentUnit)
			{
				ApplyCurrentUnitContent();
			}
			else if(dispType == DispType.UnitSet)
			{
				ApplyUnitSetContent(UnitSetIndex);
			}
		}

		//// RVA: 0xA87534 Offset: 0xA87534 VA: 0xA87534
		private void UpdateContent()
		{
			ApplyUnitContent(m_dispType);
		}

		//// RVA: 0xA8548C Offset: 0xA8548C VA: 0xA8548C
		private bool IsApplyWait()
		{
			return m_valkyrieButton.IsUpdatingContent || m_unitInfo.IsUpdatingContent() || m_unitSetInfo.IsUpdatingContent() || m_prismUnitInfo.IsUpdatingContent();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F424 Offset: 0x72F424 VA: 0x72F424
		//// RVA: 0xA875CC Offset: 0xA875CC VA: 0xA875CC
		private IEnumerator Co_EnterContents(DispType dispType)
		{
			//0xA94974
			SetActiveNecessaryContent(dispType);
			LeaveUnnecessaryContent(dispType);
			EnterNecessaryContent(dispType);
			while (IsPlayingContents())
				yield return null;
			SetInactiveUnnecessaryContent(dispType);
		}

		//// RVA: 0xA87694 Offset: 0xA87694 VA: 0xA87694
		private void EnterNecessaryContent(DispType dispType)
		{
			SetDeckUnitInfoAnimeControl.DispType deckDisp = (SetDeckUnitInfoAnimeControl.DispType)GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType;
			if (m_isGoDivaEvent)
				deckDisp = SetDeckUnitInfoAnimeControl.DispType.Skill;
			if(dispType == DispType.Prism)
			{
				m_headButtons.InOut.Enter();
				m_valkyrieButton.InOut.Enter();
				m_musicInfo.InOut.Enter();
				m_playButtons.InOut.Enter();
				m_prismSettingButtons.InOut.Enter();
				m_prismUnitInfo.AnimeControl.TryEnter();
			}
			else if(dispType == DispType.UnitSet)
			{
				m_unitStatus.InOut.Enter();
				m_valkyrieButton.InOut.Enter();
				if(!m_isGoDivaEvent)
				{
					m_unitInfoChangeButton.InOut.Enter();
				}
				m_musicInfo.InOut.Enter();
				m_unitSetListButtons.InOut.Enter();
				m_unitSetListButtons.ResetUnitNameScroll();
				m_unitSetCloseButton.InOut.Enter();
				m_unitSetSelectButtons.InOutLeft.Enter();
				m_unitSetSelectButtons.InOutRight.Enter();
				m_unitSetInfo.AnimeControl.TryEnter(deckDisp);
				m_loadSaveButtons.InOut.Enter();
			}
			else if(dispType == DispType.CurrentUnit)
			{
				m_headButtons.InOut.Enter();
				m_unitStatus.InOut.Enter();
				m_valkyrieButton.InOut.Enter();
				if(!m_isGoDivaEvent)
				{
					m_unitInfoChangeButton.InOut.Enter();
				}
				m_unitInfo.AnimeControl.TryEnter(deckDisp);
				m_musicInfo.InOut.Enter();
				m_playButtons.InOut.Enter();
			}
		}

		//// RVA: 0xA87E3C Offset: 0xA87E3C VA: 0xA87E3C
		private void LeaveUnnecessaryContent(DispType dispType)
		{
			if(dispType != DispType.Prism)
			{
				if(dispType == DispType.UnitSet)
				{
					m_headButtons.InOut.Leave(false);
					m_unitInfo.AnimeControl.TryLeave();
					m_playButtons.InOut.Leave(false);
				}
				else if(dispType == DispType.CurrentUnit)
				{
					m_unitSetListButtons.InOut.Leave(false);
					m_unitSetCloseButton.InOut.Leave(false);
					m_unitSetSelectButtons.InOutLeft.Leave(false);
					m_unitSetSelectButtons.InOutRight.Leave(false);
					m_unitSetInfo.AnimeControl.TryLeave();
					m_loadSaveButtons.InOut.Leave(false);
					m_prismSettingButtons.InOut.Leave(false);
					m_prismUnitInfo.AnimeControl.TryLeave();
				}
			}
			else
			{
				m_unitStatus.InOut.Leave(false);
				m_unitInfoChangeButton.InOut.Leave(false);
				m_unitInfo.AnimeControl.TryLeave();
				m_unitSetListButtons.InOut.Leave(false);
				m_unitSetCloseButton.InOut.Leave(false);
				m_unitSetSelectButtons.InOutLeft.Leave(false);
				m_unitSetSelectButtons.InOutRight.Leave(false);
				m_unitSetInfo.AnimeControl.TryLeave();
				m_loadSaveButtons.InOut.Leave(false);
			}
		}

		//// RVA: 0xA883BC Offset: 0xA883BC VA: 0xA883BC
		private void SetActiveNecessaryContent(DispType dispType)
		{
			if(dispType == DispType.Prism)
			{
				m_headButtons.gameObject.SetActive(true);
				m_valkyrieButton.gameObject.SetActive(true);
				m_musicInfo.gameObject.SetActive(true);
				m_playButtons.gameObject.SetActive(true);
				m_prismSettingButtons.gameObject.SetActive(true);
				m_prismUnitInfo.gameObject.SetActive(true);
			}
			else if(dispType == DispType.UnitSet)
			{
				m_unitStatus.gameObject.SetActive(true);
				m_valkyrieButton.gameObject.SetActive(true);
				if(!m_isGoDivaEvent)
				{
					m_unitInfoChangeButton.gameObject.SetActive(true);
				}
				m_musicInfo.gameObject.SetActive(true);
				m_unitSetListButtons.gameObject.SetActive(true);
				m_unitSetCloseButton.gameObject.SetActive(true);
				m_unitSetSelectButtons.gameObject.SetActive(true);
				m_unitSetInfo.gameObject.SetActive(true);
				m_loadSaveButtons.gameObject.SetActive(true);
			}
			else if(dispType == DispType.CurrentUnit)
			{
				m_headButtons.gameObject.SetActive(true);
				m_unitStatus.gameObject.SetActive(true);
				m_valkyrieButton.gameObject.SetActive(true);
				if(!m_isGoDivaEvent)
				{
					m_unitInfoChangeButton.gameObject.SetActive(true);
				}
				m_unitInfo.gameObject.SetActive(true);
				m_musicInfo.gameObject.SetActive(true);
				m_playButtons.gameObject.SetActive(true);
			}
		}

		//// RVA: 0xA8895C Offset: 0xA8895C VA: 0xA8895C
		private void SetInactiveUnnecessaryContent(TeamSelectSceneUnit5.DispType dispType)
		{
			if (dispType == DispType.Prism)
			{
				m_unitStatus.gameObject.SetActive(false);
				m_unitInfoChangeButton.gameObject.SetActive(false);
				m_unitInfo.gameObject.SetActive(false);
				m_unitSetListButtons.gameObject.SetActive(false);
				m_unitSetCloseButton.gameObject.SetActive(false);
				m_unitSetSelectButtons.gameObject.SetActive(false);
				m_unitSetInfo.gameObject.SetActive(false);
				m_loadSaveButtons.gameObject.SetActive(false);
			}
			else
			{
				if (dispType == DispType.UnitSet)
				{
					m_headButtons.gameObject.SetActive(false);
					m_unitInfo.gameObject.SetActive(false);
					m_playButtons.gameObject.SetActive(false);
				}
				else
				{
					m_unitSetListButtons.gameObject.SetActive(false);
					m_unitSetCloseButton.gameObject.SetActive(false);
					m_unitSetSelectButtons.gameObject.SetActive(false);
					m_unitSetInfo.gameObject.SetActive(false);
					m_loadSaveButtons.gameObject.SetActive(false);
				}
				m_prismSettingButtons.gameObject.SetActive(false);
				m_prismUnitInfo.gameObject.SetActive(false);
			}
			if (!m_isGoDivaEvent)
				return;
			m_unitInfoChangeButton.gameObject.SetActive(false);
		}

		//// RVA: 0xA88E24 Offset: 0xA88E24 VA: 0xA88E24
		private void LeaveContents()
		{
			m_headButtons.InOut.Leave(false);
			m_unitStatus.InOut.Leave(false);
			m_valkyrieButton.InOut.Leave(false);
			m_unitInfoChangeButton.InOut.Leave(false);
			m_unitInfo.AnimeControl.TryLeave();
			m_musicInfo.InOut.Leave(false);
			m_playButtons.InOut.Leave(false);
			m_unitSetListButtons.InOut.Leave(false);
			m_unitSetCloseButton.InOut.Leave(false);
			m_unitSetSelectButtons.InOutLeft.Leave(false);
			m_unitSetSelectButtons.InOutRight.Leave(false);
			m_unitSetInfo.AnimeControl.TryLeave();
			m_unitSetInfo.MessageControl.Leave();
			m_loadSaveButtons.InOut.Leave(false);
			m_prismSettingButtons.InOut.Leave(false);
			m_prismUnitInfo.AnimeControl.TryLeave();
			m_statusWindow.InOut.Leave(false);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
		}

		//// RVA: 0xA89300 Offset: 0xA89300 VA: 0xA89300
		private bool IsPlayingContents()
		{
			return m_headButtons.InOut.IsPlaying() || m_unitStatus.InOut.IsPlaying() || m_valkyrieButton.InOut.IsPlaying() ||
				m_unitInfoChangeButton.InOut.IsPlaying() || m_unitInfo.AnimeControl.IsPlaying() || m_musicInfo.InOut.IsPlaying() ||
				m_playButtons.InOut.IsPlaying() || m_unitSetListButtons.InOut.IsPlaying() || m_unitSetCloseButton.InOut.IsPlaying() ||
				m_unitSetSelectButtons.InOutLeft.IsPlaying() || m_unitSetSelectButtons.InOutRight.IsPlaying() || m_unitSetInfo.AnimeControl.IsPlaying() ||
				m_loadSaveButtons.InOut.IsPlaying() || m_prismSettingButtons.InOut.IsPlaying() || m_prismUnitInfo.AnimeControl.IsPlaying() ||
				m_statusWindow.InOut.IsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F49C Offset: 0x72F49C VA: 0x72F49C
		//// RVA: 0xA89790 Offset: 0xA89790 VA: 0xA89790
		private IEnumerator Co_SwitchContents(DispType dispType)
		{
			DispType prevDispType;
			int waitCount;

			//0xA95E14
			MenuScene.Instance.RaycastDisable();
			prevDispType = m_dispType;
			m_dispType = dispType;
			SetActiveNecessaryContent(dispType);
			ApplyDispType(dispType);
			ApplyPrismSettingButton(m_prismData);
			ApplyUnitContent(dispType);
			while (IsApplyWait())
				yield return null;
			while (m_statusWindow.InOut.IsPlaying())
				yield return null;
			m_statusWindow.InOut.Leave(false);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
			m_unitSetInfo.MessageControl.Leave();
			SetTitleInOut(prevDispType, dispType);
			LeaveUnnecessaryContent(dispType);
			waitCount = 0;
			while(waitCount < m_switchDispTypeWaitFrame)
			{
				waitCount++;
				yield return null;
			}
			EnterNecessaryContent(dispType);
			while (IsPlayingContents())
				yield return null;
			SetInactiveUnnecessaryContent(dispType);
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition_forSwitchDispType));
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA89858 Offset: 0xA89858 VA: 0xA89858
		private void SetTitleInOut(DispType prevType, DispType nextType)
		{
			if ((prevType != DispType.UnitSet) == (nextType != DispType.UnitSet))
				return;
			if(nextType == DispType.UnitSet)
			{
				MenuScene.Instance.HelpButton.TryLeave();
				MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
				MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
				return;
			}
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
			MenuScene.Instance.HeaderMenu.MenuStack.EnterLabel();
		}

		//// RVA: 0xA89B58 Offset: 0xA89B58 VA: 0xA89B58
		//private bool IsUseTitle(TeamSelectSceneUnit5.DispType dispType) { }

		//// RVA: 0xA85328 Offset: 0xA85328 VA: 0xA85328
		private void ApplyPrismSettingButton(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			if(prismData.OFHMEAJBIEL_IsPrismUnlocked())
			{
				m_headButtons.SetPrismType(prismData.FBGAKINEIPG ? SetDeckHeadButtons.PrismType.ON : SetDeckHeadButtons.PrismType.OFF);
			}
			else
			{
				m_headButtons.SetPrismType(SetDeckHeadButtons.PrismType.Lock);
			}
		}

		//// RVA: 0xA89B68 Offset: 0xA89B68 VA: 0xA89B68
		private void OnPlayButton()
		{
			OnClickAnyButtons();
			//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			UseLiveSkipTicketCount = 0;
			UpdatePrismData(m_viewMusicData.DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo);
			if(!CheckSetAllDiva())
			{
				NotSetAllDivaShow();
				return;
			}
			m_isDoSkip = IsForceSkip();
			if(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DCJKPJFIJKH_IsNotesSpeedAutoRejected())
			{
				if(!m_isDoSkip)
				{
					PreGameSettingShow(AdvanceGame);
					return;
				}
			}
			else if(!m_isDoSkip)
			{
				AdvanceGame();
				return;
			}
			PreGameSkipShow(AdvanceGame);
		}

		//// RVA: 0xA8C708 Offset: 0xA8C708 VA: 0xA8C708
		private void OnSkipButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			UseLiveSkipTicketCount = 0;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			switch(m_skipStatus)
			{
				case SkipStatusType.Story:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("unit_skip_story_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("unit_skip_story_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.Lock:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("unit_skip_condition_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("unit_skip_condition_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.Limit:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("unit_skip_ticket_count_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("unit_skip_ticket_count_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.LackTicket:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("unit_skip_ticket_lack_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("unit_skip_ticket_lack_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.Boost:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("boost_skip_ticket_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("boost_skip_ticket_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.Rival:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("boost_skip_battle_ex_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("boost_skip_battle_ex_text");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				case SkipStatusType.Support:
					m_textPopupSetting.TitleText = bk.GetMessageByLabel("pop_raid_assist_attack_skip_title");
					m_textPopupSetting.IsCaption = true;
					m_textPopupSetting.Text = bk.GetMessageByLabel("pop_raid_assist_attack_skip_desc_02");
					m_textPopupSetting.WindowSize = SizeType.Middle;
					m_textPopupSetting.Buttons = m_textPopupButtons;
					break;
				default:
					if(!CheckSetAllDiva())
					{
						NotSetAllDivaShow();
						return;
					}
					m_isDoSkip = true;
					PreGameSkipShow(AdvanceGame);
					return;
			}
			PopupWindowManager.Show(m_textPopupSetting, null, null, null, null);
		}

		//// RVA: 0xA8A680 Offset: 0xA8A680 VA: 0xA8A680
		private void PreGameSkipShow(Action onContinue)
		{
			IBJAKJJICBC d = m_viewMusicData as IBJAKJJICBC;
			if (d == null)
				return;
			if (MenuScene.Instance.CheckEventLimit(d, true, true, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5/*5*/, Database.Instance.gameSetup.musicInfo.EventUniqueId))
				return;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int cnt = Mathf.Min(CIOECGOMILE.HHCJCDFCLOB.KJBENABMBCA(time), CIOECGOMILE.HHCJCDFCLOB.GGJMFEGHGIA());
			m_skipTicketPopupSetting.UseItemId = LimitedCompoItemCompoConstants.MakeItemId(LimitedCompoContentsId.NormalSkipTicket);
			m_skipTicketPopupSetting.ItemHaveMaxValue = CIOECGOMILE.HHCJCDFCLOB.KJBENABMBCA(time);
			m_skipTicketPopupSetting.ConsumeItemId = 0;
			int weeklyEventCount = d.MOJMEFIENDM_WeeklyEventCount;
			if (m_eventCtrl == null)
			{
				m_skipTicketPopupSetting.ConsumeItem = PopupSkipTicketUseConfirm.ConsumeItem.Energy;
				m_skipTicketPopupSetting.ConsumeItemMax = MenuScene.Instance.GetCurrentStamina();
				int needEnergy = Database.Instance.selectedMusic.GetNeedEnergy(Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
				cnt = Mathf.Min(MenuScene.Instance.GetCurrentStamina() / needEnergy, cnt);
				if(weeklyEventCount < 1)
				{
					m_skipTicketPopupSetting.IsWeekdayEvent = false;
				}
				else
				{
					cnt = Mathf.Min(cnt, weeklyEventCount);
					m_skipTicketPopupSetting.IsWeekdayEvent = true;
				}
				m_skipTicketPopupSetting.ItemCurrentValue = 1;
				m_skipTicketPopupSetting.ItemUseMaxValue = cnt;
				m_skipTicketPopupSetting.ConsumeItemValue = needEnergy;
				m_skipTicketPopupSetting.IsOneUseForced = false;
			}
			else
			{
				if(m_eventCtrl is PKNOKJNLPOE_EventRaid)
				{
					// L 619
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PreGameSkipShow event raid");
				}
				else if(m_eventCtrl is HJNNLPIGHLM_EventCollection)
				{
					// L 508
					TodoLogger.LogError(TodoLogger.EventCollection_1, "PreGameSkipShow event collection");
				}
				else
				{
					m_skipTicketPopupSetting.ConsumeItem = PopupSkipTicketUseConfirm.ConsumeItem.Energy;
					m_skipTicketPopupSetting.ConsumeItemMax = MenuScene.Instance.GetCurrentStamina();
					m_skipTicketPopupSetting.IsWeekdayEvent = false;
					int energy = Database.Instance.selectedMusic.GetNeedEnergy(Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode);
					cnt = Mathf.Min(MenuScene.Instance.GetCurrentStamina() / energy, cnt);
					bool b1 = false;
					if(m_eventCtrl is HAEDCCLHEMN_EventBattle)
					{
						// L464
						HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
						b1 = false;
                        BKKMNPEEILG ghost = Database.Instance.selectedMusic.GetGhostData();
                        if (ghost != null)
						{
							if(ghost.GAOGOMKKJON())
								cnt = 1;
							b1 = ghost.GAOGOMKKJON();
						}
					}
					else if(m_eventCtrl is MANPIONIGNO_EventGoDiva && m_isGoDivaBonus)
					{
						m_skipTicketPopupSetting.IsWeekdayEvent = false;
						b1 = false;
						MANPIONIGNO_EventGoDiva evGoDiva = m_eventCtrl as MANPIONIGNO_EventGoDiva;
						cnt = Mathf.Min(cnt, Mathf.Min(Mathf.Min(CIOECGOMILE.HHCJCDFCLOB.GGJMFEGHGIA(), CIOECGOMILE.HHCJCDFCLOB.KJBENABMBCA(time)), evGoDiva.CLELOGKMNCE_GetEventSaveData().PFPGHILKGIG_BnsCnt + 1));
						m_skipTicketPopupSetting.IsGoDivaEventDailyBonus = evGoDiva.CLELOGKMNCE_GetEventSaveData().JHKKAKJCJOF_Bns2 > 0;
					}
					else
					{
						if(weeklyEventCount < 1)
						{
							m_skipTicketPopupSetting.IsWeekdayEvent = false;
						}
						else
						{
							cnt = Mathf.Min(cnt, weeklyEventCount);
							m_skipTicketPopupSetting.IsWeekdayEvent = true;
						}
					}
					m_skipTicketPopupSetting.ItemCurrentValue = 1;
					m_skipTicketPopupSetting.ItemUseMaxValue = cnt;
					m_skipTicketPopupSetting.ConsumeItemValue = energy;
					m_skipTicketPopupSetting.IsOneUseForced = b1;
				}
			}
			//LAB_00a8b0e8
			PopupWindowManager.Show(m_skipTicketPopupSetting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA92B3C
				if(type == PopupButton.ButtonType.Positive && onContinue != null)
				{
					int c = (ctrl.Content as PopupSkipTicketUseConfirm).UseTcketCount;
					long time_ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					if(!CIOECGOMILE.HHCJCDFCLOB.LNCGIOILBDD(c, time_))
					{
						JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() =>
						{
							//0xA929F8
							MenuScene.Instance.GotoTitle();
						}, "");
						return;
					}
					UseLiveSkipTicketCount = c;
					if (onContinue != null)
						onContinue();
				}
			}, null, null, null);
		}

		//// RVA: 0xA8C374 Offset: 0xA8C374 VA: 0xA8C374
		private void PreGameSettingShow(Action onContinue)
		{
			PopupConfigPreGameSetting setting = new PopupConfigPreGameSetting();
			setting.WindowSize = SizeType.Large;
			setting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("config_text_21");
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			MenuScene.Instance.InputDisable();
			PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA92F08
				bool isSave = type == PopupButton.ButtonType.Positive;
				bool isPositive = isSave;
				ConfigManager.Instance.ApplyValue(isSave, () =>
				{
					//0xA93044
					MenuScene.Instance.InputEnable();
					if (!isPositive)
						return;
					if (!ConfigManager.Instance.GetNotesSpeedAutoRejected())
					{
						if(onContinue != null)
						{
							onContinue();
						}
						return;
					}
					SettingCompleteShow(onContinue);
				});
			}, null, null, null);
		}

		//// RVA: 0xA8B940 Offset: 0xA8B940 VA: 0xA8B940
		private void AdvanceGame()
		{
			bool isNotUpdate = false;
			if(m_isRaidEvent)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
			}
			Database.Instance.gameSetup.teamInfo.SetupInfo(m_paramCalculator.AddStatus, m_playerData, 0, m_viewMusicData, m_viewFriendPlayerData, m_paramCalculator.LimitOverStatus, m_prismData, m_isGoDivaEvent);
			AdvanceGame(m_paramCalculator.AddStatus, m_playerData, m_viewFriendPlayerData, m_paramCalculator.LimitOverStatus, m_isDoSkip, UseLiveSkipTicketCount, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), m_paramCalculator.LogParams, isNotUpdate);
		}

		//// RVA: 0xA8D2EC Offset: 0xA8D2EC VA: 0xA8D2EC
		private void SettingCompleteShow(Action onClose)
		{
			TextPopupSetting setting = PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetBank("menu").GetMessageByLabel("config_text_67"), new ButtonInfo[1] {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false);
			MenuScene.Instance.InputDisable();
			PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA935B4
				MenuScene.Instance.InputEnable();
				if (onClose != null)
					onClose();
			}, null, null, null);
		}

		//// RVA: 0xA89EF8 Offset: 0xA89EF8 VA: 0xA89EF8
		private bool CheckSetAllDiva()
		{
			bool valid = true;
			if (m_prismData.FBGAKINEIPG)
			{
				for(int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum; i++)
				{
					valid &= m_prismData.PNBKLGKCKGO_GetPrismDivaIdForSlot(i) > 0 && m_prismData.OCNHIHMAGMJ_GetPrismCostumeIdForSlot(i) > 0;
				}
				valid &= m_prismData.PNDKNFBLKDP_GetPrismValkyrieId() > 0;
			}
			else
			{
				int divaNum = Mathf.Min(Database.Instance.gameSetup.musicInfo.onStageDivaNum, 3);
				for(int i = 0; i < divaNum; i++)
				{
					valid &= m_playerData.DPLBHAIKPGL_GetTeam(m_isGoDivaEvent).BCJEAJPLGMB_MainDivas[i] != null;
				}
				for(int i = 0; i < Database.Instance.gameSetup.musicInfo.onStageDivaNum - divaNum; i++)
				{
					valid &= m_playerData.DPLBHAIKPGL_GetTeam(m_isGoDivaEvent).CMOPCCAJAAO_AddDivas[i] != null;
				}
			}
			return valid;
		}

		//// RVA: 0xA8A228 Offset: 0xA8A228 VA: 0xA8A228
		private void NotSetAllDivaShow()
		{
			TextPopupSetting setting = PopupWindowManager.CrateTextContent("", SizeType.Small, MessageManager.Instance.GetBank("menu").GetMessageByLabel(m_prismData.FBGAKINEIPG ? "unit_multi_dance_popup_01" : "unit_multi_dance_popup_00"), new ButtonInfo[1] {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, false);
			MenuScene.Instance.InputDisable();
			PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA92044
				this.StartCoroutineWatched(Co_SwitchDivaSelectDisplay());
				MenuScene.Instance.InputEnable();
			}, null, null, null);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F514 Offset: 0x72F514 VA: 0x72F514
		//// RVA: 0xA8D5D0 Offset: 0xA8D5D0 VA: 0xA8D5D0
		private IEnumerator Co_SwitchDivaSelectDisplay()
		{
			//0xA963E0
			if(m_prismData.FBGAKINEIPG)
			{
				if (m_dispType != DispType.Prism)
					yield return Co.R(Co_SwitchContents(DispType.Prism));
			}
			else
			{
				bool switched = false;
				if(Database.Instance.gameSetup.musicInfo.onStageDivaNum > 3)
				{
					int type = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType;
					if (type != 1)
					{
						ChangeUnitInfoDispType();
						switched = true;
					}
				}
				if(m_dispType == DispType.CurrentUnit)
				{
					if(switched)
					{
						m_unitInfo.AnimeControl.ChangeDispType(SetDeckUnitInfoAnimeControl.DispType.Divas);
					}
				}
				else
				{
					yield return Co.R(Co_SwitchContents(DispType.CurrentUnit));
				}
			}
		}

		//// RVA: 0xA8A504 Offset: 0xA8A504 VA: 0xA8A504
		private bool IsForceSkip()
		{
			if(m_viewMusicData != null)
			{
				if(m_viewMusicData is IBJAKJJICBC && Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid && m_eventCtrl != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
				}
			}
			return false;
		}

		//// RVA: 0xA8D67C Offset: 0xA8D67C VA: 0xA8D67C
		private void OnChangeUnitName()
		{
			OnClickAnyButtons();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			InputPopupSetting s = new InputPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_01");
			s.Description = PopupWindowManager.FormatTextBank(bk, "popup_text_00", new object[] { 15 });
			s.InputText = m_viewUnitData.BHKALCOAHHO_Name;
			s.Notes = PopupWindowManager.FormatTextBank(bk, "popup_text_01", new object[] { 15 });
			s.CharacterLimit = 15;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA920FC
				if(type == PopupButton.ButtonType.Positive)
				{
					InputContent c = control.Content as InputContent;
					m_viewUnitData.BHKALCOAHHO_Name = c.Text;
					m_unitStatus.SetUnitName(c.Text);
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0xA92A94
				return;
			}, null, null);
		}

		//// RVA: 0xA8DCDC Offset: 0xA8DCDC VA: 0xA8DCDC
		private void OnShowEpisodeBonusScenePopup()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(!m_isRaidEvent)
			{
				if(m_dispType == DispType.UnitSet)
				{
					m_viewEpisodeBonus.NFEECBNKKHD(m_eventCtrl, UnitSetIndex, m_isGoDivaEvent);
				}
				else
				{
					m_viewEpisodeBonus.OBKGEDCKHHE(m_eventCtrl, m_isGoDivaEvent);
				}
				m_episodeBonusPopupSetting.Setup(Database.Instance.bonusData.EffectiveEpisodeBonus, m_viewEpisodeBonus);
				PopupWindowManager.Show(m_episodeBonusPopupSetting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xA92A9C
					return;
				}, null, null, null);
			}
			else
			{
				PopupWindowManager.Show(m_unitBonusPopupSetting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xA92A98
					return;
				}, null, null, null);
			}
		}

		//// RVA: 0xA8E110 Offset: 0xA8E110 VA: 0xA8E110
		private void OnShowStatusWindow()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ShowStatusWindow(!m_statusWindow.InOut.IsEnter));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F58C Offset: 0x72F58C VA: 0x72F58C
		//// RVA: 0xA8E1CC Offset: 0xA8E1CC VA: 0xA8E1CC
		private IEnumerator Co_ShowStatusWindow(bool isShow)
		{
			//0xA95A90
			MenuScene.Instance.RaycastDisable();
			m_unitStatus.SetCheckStatusButtonState(isShow ? SetDeckUnitStatus.CheckStatusButtonState.Display : SetDeckUnitStatus.CheckStatusButtonState.Normal);
			if(!isShow)
			{
				m_statusWindow.InOut.Leave(false, null);
			}
			else
			{
				m_statusWindow.gameObject.SetActive(true);
				m_statusWindow.InOut.Enter(false, null);
			}
			while (m_statusWindow.InOut.IsPlaying())
				yield return null;
			if(!isShow)
			{
				m_statusWindow.gameObject.SetActive(false);
			}
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA8E294 Offset: 0xA8E294 VA: 0xA8E294
		private void OnShowChangeStatusButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(m_dispTypePopupParam, (PopupFilterSortUGUI content) =>
			{
				//0xA922A0
				int divaSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem;
				int sceneSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem;
				m_divaDispTypeIndex = PopupSortMenu.UnitDivaSortItem.FindIndex((SortItem x) =>
				{
					//0xA93668
					return divaSortItem == (int)x;
				});
				m_sceneDispTypeIndex = PopupSortMenu.UnitSortItem.FindIndex((SortItem x) =>
				{
					//0xA9367C
					return sceneSortItem == (int)x;
				});
				ApplyStatusDisplayType();
			}, null);
		}

		//// RVA: 0xA8E3E8 Offset: 0xA8E3E8 VA: 0xA8E3E8
		private void ApplyStatusDisplayType()
		{
			SortItem divaItem = PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex];
			SortItem sceneItem = PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex];
			m_unitInfo.SetStatusDisplayType(divaItem, sceneItem);
			m_unitSetInfo.SetStatusDisplayType(divaItem, sceneItem);
		}

		//// RVA: 0xA8E530 Offset: 0xA8E530 VA: 0xA8E530
		private void OnClickValkyrieButton()
		{
			OnClickAnyButtons();
			if (m_dispType == DispType.CurrentUnit)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ValkyrieDataArgs arg = new ValkyrieDataArgs();
				arg.isGoDiva = m_isGoDivaEvent;
				MenuScene.Instance.Call(TransitionList.Type.VALKYRIE_SELECT, arg, true);
			}
			else if(m_dispType == DispType.Prism)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ShowPrismSelectPopup(PopupMvModeSelectListContent.SelectTarget.Valkyrie, 0, m_viewMusicData != null ? m_viewMusicData.DLAEJOBELBH_MusicId : 0, Database.Instance.gameSetup.musicInfo, false, () =>
				{
					//0xA92574
					ApplyPrismUnitContent();
				}, null);
			}
		}

		//// RVA: 0xA8E814 Offset: 0xA8E814 VA: 0xA8E814
		private void OnStayValkyrieButton()
		{
			OnClickAnyButtons();
			if (m_dispType == DispType.CurrentUnit)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_viewUnitData.JOKFNBLEILN_Valkyrie != null)
				{
					m_valkyriePopupSetting.ViewValkyrieData = m_viewUnitData.JOKFNBLEILN_Valkyrie;
					m_valkyriePopupSetting.ViewValkyrieAbilityData = m_paramCalculator.ValkyrieAbilityData;
					PopupWindowManager.Show(m_valkyriePopupSetting, null, null, null, null);
				}
			}
		}

		//// RVA: 0xA8EA34 Offset: 0xA8EA34 VA: 0xA8EA34
		private void OnClickUnitInfoChangeButton()
		{
			OnClickAnyButtons();
			if(m_dispType == DispType.CurrentUnit)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_unitInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
			}
			else if(m_dispType == DispType.Prism)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_unitSetInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
			}
		}

		//// RVA: 0xA83E8C Offset: 0xA83E8C VA: 0xA83E8C
		private SetDeckUnitInfoAnimeControl.DispType ChangeUnitInfoDispType()
		{
			int type = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType;
			type = (type + 1) % (int)SetDeckUnitInfoAnimeControl.DispType.Num;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType = type;
			return (SetDeckUnitInfoAnimeControl.DispType)type;
		}

		//// RVA: 0xA8EC04 Offset: 0xA8EC04 VA: 0xA8EC04
		//private void OnClickSubPlateButton() { }

		//// RVA: 0xA8EC70 Offset: 0xA8EC70 VA: 0xA8EC70
		private void ShowSubPlateWindow(bool isReShow = false)
		{
			CFHDKAFLNEP c = new CFHDKAFLNEP();
			if(m_dispType == DispType.UnitSet)
			{
				c = m_unitSetParamCalculator.SubPlateResult;
			}
			if(c.CDOCOLOKCJK())
			{
				m_isShowSubPlate = true;
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateWindow(c, null, UnitWindowConstant.OperationMode.Edit, null, () =>
				{
					//0xA92578
					m_isShowSubPlate = false;
				}, isReShow);
			}
			else
			{
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateLockWindow(null);
			}
		}

		//// RVA: 0xA8EEE0 Offset: 0xA8EEE0 VA: 0xA8EEE0
		private void OnSelectDiva(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_selectDivaListArgs.slot = slotNumber;
			m_selectDivaListArgs.viewPlayerData = m_playerData;
			m_selectDivaListArgs.viewMusicBaseData = m_viewMusicData;
			MenuScene.Instance.Call(TransitionList.Type.DIVA_SELECT_LIST, m_selectDivaListArgs, true);
		}

		//// RVA: 0xA8F050 Offset: 0xA8F050 VA: 0xA8F050
		private void OnShowDivaStatus(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			if(divaData != null)
			{
				OnClickAnyButtons();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.ShowDivaStatusPopupWindow(divaData, m_playerData, m_viewMusicData,
				false, m_transitionName, null, true, slotNumber != 0 && m_isGoDivaEvent, slotNumber, 
				m_isGoDivaEvent);
			}
		}

		//// RVA: 0xA8F1CC Offset: 0xA8F1CC VA: 0xA8F1CC
		private void OnSelectCostume(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			OnClickAnyButtons();
			if(slotNumber > -1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_costumeChangeDivaArgs.DivaId = divaData.AHHJLDLAPAN_DivaId;
				m_costumeChangeDivaArgs.is_godiva = m_isGoDivaEvent;
				MenuScene.Instance.Call(TransitionList.Type.COSTUME_SELECT, m_costumeChangeDivaArgs, true);
			}
		}

		//// RVA: 0xA8F334 Offset: 0xA8F334 VA: 0xA8F334
		private void OnSelectScene(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			OnClickAnyButtons();
			if(divaSlotNumber > -1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_selectSceneListArgs.divaSlotIndex = divaSlotNumber;
				m_selectSceneListArgs.divaData = divaData;
				m_selectSceneListArgs.defaultSelectScene = sceneSlotNumber;
				m_selectSceneListArgs.scelectType = 0;
				m_selectSceneListArgs.friendPlayerData = m_viewFriendPlayerData;
				m_selectSceneListArgs.musicBaseData = m_viewMusicData;
				m_selectSceneListArgs.enemyData = m_viewEnemyData;
				m_selectSceneListArgs.difficulty = Database.Instance.gameSetup.musicInfo.difficultyType;
				m_selectSceneListArgs.isGoDiva = m_isGoDivaEvent;
				MenuScene.Instance.Call(TransitionList.Type.SCENE_SELECT, m_selectSceneListArgs, true);
			}
		}

		//// RVA: 0xA8F5B4 Offset: 0xA8F5B4 VA: 0xA8F5B4
		private void OnShowSceneStatus(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			if(sceneData != null)
			{
				OnClickAnyButtons();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, m_playerData, false,
					m_transitionName, UpdateContent, divaSlotNumber == -1, false, SceneStatusParam.PageSave.Player, false);
			}
		}

		//// RVA: 0xA8F73C Offset: 0xA8F73C VA: 0xA8F73C
		private void OnShowFriendDivaStatus(EAJCBFGKKFA_FriendInfo friendData)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = friendData;
			arg.infoType = ProfilMenuLayout.InfoType.ASSIST;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		//// RVA: 0xA8F89C Offset: 0xA8F89C VA: 0xA8F89C
		private void OnShowScoreInfoPopup()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetDeckGaugePopupSetting setting = new SetDeckGaugePopupSetting();
			setting.WindowSize = SizeType.Large;
			setting.TitleText = bk.GetMessageByLabel("pop_score_detail_title");
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xA92584
				m_musicInfo.ExpectedScoreGauge.UpdateScore();
			}, null, null, null);
		}

		//// RVA: 0xA8FB84 Offset: 0xA8FB84 VA: 0xA8FB84
		private void OnClickAutoSettingButton()
		{
			OnClickAnyButtons();
			KLBKPANJCPL_Score score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(m_viewMusicData.KKPAHLMJKIH_WavId, m_viewMusicData.BKJGCEOEPFB_Variation, (int)Database.Instance.gameSetup.musicInfo.difficultyType, Database.Instance.gameSetup.musicInfo.IsLine6Mode, true);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_isOpenEndAutoSetting = false;
			MenuScene.Instance.UnitSaveWindowControl.ShowUnitAutoSettingWindow(m_playerData, PopupAutoSettingContent.Place.UnitSelect, m_viewMusicData.FKDCCLPGKDK_JacketAttr, m_viewMusicData.AIHCEGFANAM_Serie, m_viewMusicData.DLAEJOBELBH_MusicId, (PopupAutoSettingContent content) =>
			{
				//0xA925D0
				content.ApplyAutoSetting(m_playerData.DPLBHAIKPGL_GetTeam(m_isGoDivaEvent), m_playerData, m_isGoDivaEvent);
				this.StartCoroutineWatched(Co_ApplyCurrentUnitContentForAutoSetting());
			}, () =>
			{
				//0xA92688
				this.StartCoroutineWatched(Co_ApplyCurrentUnitContentForAutoSetting());
			}, () =>
			{
				//0xA926AC
				m_isOpenEndAutoSetting = true;
			}, score, m_isGoDivaEvent);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F604 Offset: 0x72F604 VA: 0x72F604
		//// RVA: 0xA8FF98 Offset: 0xA8FF98 VA: 0xA8FF98
		private IEnumerator Co_ApplyCurrentUnitContentForAutoSetting()
		{
			//0xA937B4
			MenuScene.Instance.RaycastDisable();
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType != 0)
			{
				yield return null;
				m_unitInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
				while(m_unitInfo.AnimeControl.IsPlaying())
					yield return  null;
			}
			//LAB_00a93a60
			ApplyCurrentUnitContent(false);
			while(IsApplyWait())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA90044 Offset: 0xA90044 VA: 0xA90044
		private void OnClickUnitSetButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_EnterUnitSet());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F67C Offset: 0x72F67C VA: 0x72F67C
		//// RVA: 0xA900BC Offset: 0xA900BC VA: 0xA900BC
		private IEnumerator Co_EnterUnitSet()
		{
			//0xA94B18
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(Co_DownloadUnitSetResources());
			yield return Co.R(Co_SwitchContents(DispType.UnitSet));
			m_unitSetInfo.MessageControl.Enter(m_playerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, m_isGoDivaEvent).EIGKIHENKNC_HasNoDivaSet ? SetDeckUnitInfoMessageControl.DispType.Keep : SetDeckUnitInfoMessageControl.DispType.OneShot);
			MenuScene.Instance.RaycastEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F6F4 Offset: 0x72F6F4 VA: 0x72F6F4
		//// RVA: 0xA90168 Offset: 0xA90168 VA: 0xA90168
		private IEnumerator Co_DownloadUnitSetResources()
		{
			//0xA93E80
			for(int i = 0; i < m_playerData.DDMBOKCCLBD_GetUnits(m_isGoDivaEvent).Count; i++)
			{
				JLKEOGLJNOD_TeamInfo unit = m_playerData.JKIJFGGMNAN_GetUnit(i, m_isGoDivaEvent);
				for(int j = 0; j < unit.BCJEAJPLGMB_MainDivas.Count; j++)
				{
					FFHPBEPOMAK_DivaInfo diva = unit.BCJEAJPLGMB_MainDivas[j];
					if(diva != null)
					{
						MenuScene.Instance.DivaIconCache.TryInstall(diva.AHHJLDLAPAN_DivaId, diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, diva.EKFONBFDAAP_ColorId);
						if(diva.FGFIBOBAPIA_SceneId > 0)
						{
							GCIJNCFDNON_SceneInfo sceneInfo = m_playerData.OPIBAPEGCLA_Scenes[diva.FGFIBOBAPIA_SceneId - 1];
							MenuScene.Instance.SceneIconCache.TryInstall(sceneInfo.BCCHOBPJJKE_SceneId, sceneInfo.CGIELKDLHGE_GetEvolveId());
						}
						for(int k = 0; k < diva.DJICAKGOGFO_SubSceneIds.Count; k++)
						{
							if (diva.DJICAKGOGFO_SubSceneIds[k] > 0)
							{
								GCIJNCFDNON_SceneInfo sceneInfo = m_playerData.OPIBAPEGCLA_Scenes[diva.DJICAKGOGFO_SubSceneIds[k] - 1];
								MenuScene.Instance.SceneIconCache.TryInstall(sceneInfo.BCCHOBPJJKE_SceneId, sceneInfo.CGIELKDLHGE_GetEvolveId());
							}
						}
					}
				}
				for (int j = 0; j < unit.CMOPCCAJAAO_AddDivas.Count; j++)
				{
					FFHPBEPOMAK_DivaInfo diva = unit.CMOPCCAJAAO_AddDivas[j];
					if (diva != null)
					{
						MenuScene.Instance.DivaIconCache.TryInstall(diva.AHHJLDLAPAN_DivaId, diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, diva.EKFONBFDAAP_ColorId);
					}
				}
			}
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		//// RVA: 0xA90214 Offset: 0xA90214 VA: 0xA90214
		private void OnClickPrismSettingButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdatePrismData(m_viewMusicData.DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo);
			if(m_prismData.OFHMEAJBIEL_IsPrismUnlocked())
			{
				this.StartCoroutineWatched(Co_SwitchContents(DispType.Prism));
				return;
			}
			m_textPopupSetting.IsCaption = false;
			m_textPopupSetting.Text = string.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_prism_unlock_text"), m_prismData.DPHIJENPBCJ_GetPrismLevelRequired());
			m_textPopupSetting.WindowSize = SizeType.Small;
			m_textPopupSetting.Buttons = m_textPopupOkButtons;
			PopupWindowManager.Show(m_textPopupSetting, null, null, null, null);
		}

		//// RVA: 0xA90564 Offset: 0xA90564 VA: 0xA90564
		private void OnClickUnitSettingButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_SwitchContents(DispType.CurrentUnit));
		}

		//// RVA: 0xA905E0 Offset: 0xA905E0 VA: 0xA905E0
		private void OnClickGameSettingButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_gameSettingMenu.ShowPopupRhythm(null, null);
		}

		//// RVA: 0xA90668 Offset: 0xA90668 VA: 0xA90668
		private void OnChangeUnitSetSelect(int unitSetIndex, JLKEOGLJNOD_TeamInfo unitData)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitSetIndex = unitSetIndex;
			this.StartCoroutineWatched(Co_ApplyUnitSetContent(true));
		}

		//// RVA: 0xA9079C Offset: 0xA9079C VA: 0xA9079C
		private void OnStartChangeUnitSetPage()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.RaycastDisable();
		}

		//// RVA: 0xA90890 Offset: 0xA90890 VA: 0xA90890
		private void OnEndChangeUnitSetPage()
		{
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA9092C Offset: 0xA9092C VA: 0xA9092C
		private void OnClickUnitSetCloseButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
			this.StartCoroutineWatched(Co_SwitchContents(DispType.CurrentUnit));
		}

		//// RVA: 0xA909A8 Offset: 0xA909A8 VA: 0xA909A8
		private void OnClickUnitSetSelectButton(int tick)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_OnClickUnitSetSelect(tick));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F76C Offset: 0x72F76C VA: 0x72F76C
		//// RVA: 0xA90A28 Offset: 0xA90A28 VA: 0xA90A28
		private IEnumerator Co_OnClickUnitSetSelect(int tick)
		{
			//0xA95118
			MenuScene.Instance.RaycastDisable();
			int cnt = tick + UnitSetIndex;
			for (; cnt < 0; )
			{
				cnt += m_unitSetListButtons.UnitCount;
			}
			for(; cnt >= m_unitSetListButtons.UnitCount; cnt -= m_unitSetListButtons.UnitCount)
			{
			}
			UnitSetIndex = cnt;
			yield return Co.R(Co_ApplyUnitSetContent(false));
			bool isWait = true;
			m_unitSetListButtons.ChangeSelect(UnitSetIndex, () =>
			{
				//0xA93698
				isWait = false;
			});
			while (isWait)
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA90AF0 Offset: 0xA90AF0 VA: 0xA90AF0
		private void OnUnitSetLoad()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			MenuScene.Instance.UnitSaveWindowControl.ShowConfirmWindow(ConfirmType.Load, m_playerData, m_playerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, m_isGoDivaEvent).CDPKOIDDKIJ, m_viewMusicData, m_viewEnemyData, m_viewFriendPlayerData, () =>
			{
				//0xA926B8
				MenuScene.Instance.RaycastDisable();
				LoadUnitSetForCurrentUnit(UnitSetIndex);
			}, () =>
			{
				//0xA9276C
				MenuScene.Instance.RaycastEnable();
				this.StartCoroutineWatched(Co_SwitchContents(DispType.CurrentUnit));
			}, null, m_isGoDivaEvent);
		}

		//// RVA: 0xA90D30 Offset: 0xA90D30 VA: 0xA90D30
		private void OnUnitSetSave()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			MenuScene.Instance.UnitSaveWindowControl.ShowConfirmWindow(ConfirmType.Save, m_playerData, m_playerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, m_isGoDivaEvent).CDPKOIDDKIJ, m_viewMusicData, m_viewEnemyData, m_viewFriendPlayerData, () =>
			{
				//0xA92828
				MenuScene.Instance.RaycastDisable();
				SaveUnitSetByCurrentUnit(UnitSetIndex);
				ApplyUnitSetContent(UnitSetIndex);
				m_unitSetListButtons.UpdateContent(m_playerData, m_isGoDivaEvent);
				m_unitSetInfo.MessageControl.Leave();
			}, () =>
			{
				//0xA92AA0
				MenuScene.Instance.RaycastEnable();
			}, null, m_isGoDivaEvent);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72F7E4 Offset: 0x72F7E4 VA: 0x72F7E4
		//// RVA: 0xA906F4 Offset: 0xA906F4 VA: 0xA906F4
		private IEnumerator Co_ApplyUnitSetContent(bool isApplyUnitSetList = true)
		{
			//0xA93BB4
			MenuScene.Instance.RaycastDisable();
			ApplyUnitSetContent(UnitSetIndex);
			if(isApplyUnitSetList)
			{
				m_unitSetListButtons.UpdateContent(m_playerData, m_isGoDivaEvent);
			}
			while (IsApplyWait())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xA91058 Offset: 0xA91058 VA: 0xA91058
		private void SaveUnitSetByCurrentUnit(int unitSetIndex)
		{
			if(!m_isGoDivaEvent)
			{
				m_playerData.JKIJFGGMNAN_GetUnit(unitSetIndex, m_isGoDivaEvent).KMLFHLOBPNH(m_playerData.OPIBAPEGCLA_Scenes);
			}
			else
			{
				m_playerData.JKIJFGGMNAN_GetUnit(unitSetIndex, m_isGoDivaEvent).MLNLDMABAEA(m_playerData.DPLBHAIKPGL_GetTeam(true).PDJEMLMOEPF_CenterDivaId, m_playerData.OPIBAPEGCLA_Scenes);
			}
		}

		//// RVA: 0xA9117C Offset: 0xA9117C VA: 0xA9117C
		private void LoadUnitSetForCurrentUnit(int unitSetIndex)
		{
			if(!m_isGoDivaEvent)
			{
				m_playerData.LCCKKHFEIGH(unitSetIndex);
				ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_19612, unitSetIndex + 1, true, m_isGoDivaEvent, 1);
			}
			else
			{
				m_playerData.JHDADIMLHII(m_playerData.DPLBHAIKPGL_GetTeam(true).PDJEMLMOEPF_CenterDivaId, unitSetIndex);
				ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_19612, unitSetIndex + 1, true, m_isGoDivaEvent, m_playerData.DPLBHAIKPGL_GetTeam(true).PDJEMLMOEPF_CenterDivaId);
			}
		}

		//// RVA: 0xA912FC Offset: 0xA912FC VA: 0xA912FC
		private void OnClickOriginalSetting()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UpdatePrismData(m_viewMusicData.DLAEJOBELBH_MusicId, Database.Instance.gameSetup.musicInfo);
			ShowOriginalPrismSettingPopup(m_viewMusicData != null ? m_viewMusicData.DLAEJOBELBH_MusicId : 0, Database.Instance.gameSetup.musicInfo, false, () =>
			{
				//0xA92974
				ApplyPrismUnitContent();
			});
		}

		//// RVA: 0xA914E0 Offset: 0xA914E0 VA: 0xA914E0
		private void OnClickPrismItems(PopupMvModeSelectListContent.SelectTarget target, int divaSlotNumber)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ShowPrismSelectPopup(target, divaSlotNumber, m_viewMusicData != null ? m_viewMusicData.DLAEJOBELBH_MusicId : 0, Database.Instance.gameSetup.musicInfo, false, () =>
			{
				//0xA92978
				ApplyPrismUnitContent();
			}, null);
		}

		//// RVA: 0xA89EAC Offset: 0xA89EAC VA: 0xA89EAC
		private void OnClickAnyButtons()
		{
			m_unitSetInfo.MessageControl.Leave();
		}

		// RVA: 0xA91658 Offset: 0xA91658 VA: 0xA91658 Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			if(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva ||
				Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				return new EventMusicSelectSceneArgs(Database.Instance.gameSetup.musicInfo.EventUniqueId, Database.Instance.gameSetup.musicInfo.IsLine6Mode, false);
			}
			return null;
		}

		//// RVA: 0xA917F4 Offset: 0xA917F4 VA: 0xA917F4
		private bool CheckTutorialCondition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition73;
		}

		//// RVA: 0xA91804 Offset: 0xA91804 VA: 0xA91804
		private bool CheckTutorialCondition_forSwitchDispType(TutorialConditionId conditionId)
		{
			int v = UnitSetSelectIndex_Normal;
			if (conditionId == TutorialConditionId.Condition60)
				v = UnitSetSelectIndex_GoDiva;
			if (conditionId != TutorialConditionId.Condition60 || v != 2)
				return false;
			return CheckExistOriginalSetting(m_prismData);
		}

		//// RVA: 0xA918F8 Offset: 0xA918F8 VA: 0xA918F8
		private void OnBackButton()
		{
			if(MenuScene.Instance.GetInputDisableCount() < 1)
			{
				if(MenuScene.Instance.GetRaycastDisableCount() < 1)
				{
					if(!GameManager.Instance.IsTutorial)
					{
						if(!MenuScene.Instance.IsRequestChangeScene)
						{
							if (MenuScene.Instance.DirtyChangeScene)
								return;
							if(m_dispType == DispType.UnitSet)
							{
								OnClickUnitSetCloseButton();
								return;
							}
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
							MenuScene.SaveRequest();
							MenuScene.Instance.Return(true);
						}
					}
				}
			}
		}

		//[CompilerGeneratedAttribute] // RVA: 0x72F85C Offset: 0x72F85C VA: 0x72F85C
		//// RVA: 0xA9203C Offset: 0xA9203C VA: 0xA9203C
		//private bool <Co_ShowHelp>b__101_0() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x72F8AC Offset: 0x72F8AC VA: 0x72F8AC
		//// RVA: 0xA92578 Offset: 0xA92578 VA: 0xA92578
		//private void <ShowSubPlateWindow>b__158_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8CC Offset: 0x72F8CC VA: 0x72F8CC
		//// RVA: 0xA925D0 Offset: 0xA925D0 VA: 0xA925D0
		//private void <OnClickAutoSettingButton>b__166_0(PopupAutoSettingContent content) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8DC Offset: 0x72F8DC VA: 0x72F8DC
		//// RVA: 0xA92688 Offset: 0xA92688 VA: 0xA92688
		//private void <OnClickAutoSettingButton>b__166_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x72F8EC Offset: 0x72F8EC VA: 0x72F8EC
		//// RVA: 0xA926AC Offset: 0xA926AC VA: 0xA926AC
		//private void <OnClickAutoSettingButton>b__166_2() { }
	}
}
