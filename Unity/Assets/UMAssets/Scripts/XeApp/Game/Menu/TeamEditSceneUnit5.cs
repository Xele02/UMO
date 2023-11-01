using mcrs;
using System.Collections;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class TeamEditSceneUnit5 : TransitionRoot
	{
		private enum DispType
		{
			CurrentUnit = 0,
			UnitSet = 1,
		}

		private struct PrefabCacheParam
		{
			public string prefabName; // 0x0
			public int count; // 0x4

			// RVA: 0x7FBCEC Offset: 0x7FBCEC VA: 0x7FBCEC
			public PrefabCacheParam(string prefabName, int count)
			{
				this.prefabName = prefabName;
				this.count = count;
			}
		}

		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66CA88 Offset: 0x66CA88 VA: 0x66CA88
		private int m_switchDispTypeWaitFrame; // 0x48
		private static DispType m_dispType; // 0x0
		private static readonly PrefabCacheParam[] m_prefabCacheParams = new PrefabCacheParam[10]
			{
				new PrefabCacheParam("SetDeckHeadButtons", 1),
				new PrefabCacheParam("SetDeckUnitStatus", 1),
				new PrefabCacheParam("SetDeckValkyrieButton", 1),
				new PrefabCacheParam("SetDeckUnitInfoChangeButton", 1),
				new PrefabCacheParam("SetDeckUnitInfo_Edit", 2),
				new PrefabCacheParam("SetDeckUnitSetListButtons", 1),
				new PrefabCacheParam("SetDeckUnitSetCloseButton", 1),
				new PrefabCacheParam("SetDeckUnitSetSelectButtons", 1),
				new PrefabCacheParam("SetDeckLoadSaveButtons", 1),
				new PrefabCacheParam("SetDeckStatusWindow", 1)
			}; // 0x4
		private UGUIObject m_headButtonsObject; // 0x4C
		private UGUIObject m_unitStatusObject; // 0x50
		private UGUIObject m_valkyrieButtonObject; // 0x54
		private UGUIObject m_unitInfoChangeButtonObject; // 0x58
		private UGUIObject m_unitInfoObject; // 0x5C
		private UGUIObject m_unitSetListButtonsObject; // 0x60
		private UGUIObject m_unitSetCloseButtonObject; // 0x64
		private UGUIObject m_unitSetSelectButtonsObject; // 0x68
		private UGUIObject m_unitSetInfoObject; // 0x6C
		private UGUIObject m_loadSaveButtonsObject; // 0x70
		private UGUIObject m_statusWindowObject; // 0x74
		private SetDeckHeadButtons m_headButtons; // 0x78
		private SetDeckUnitStatus m_unitStatus; // 0x7C
		private SetDeckValkyrieButton m_valkyrieButton; // 0x80
		private SetDeckUnitInfoChangeButton m_unitInfoChangeButton; // 0x84
		private SetDeckUnitInfo m_unitInfo; // 0x88
		private SetDeckUnitSetListButtons m_unitSetListButtons; // 0x8C
		private SetDeckUnitSetCloseButton m_unitSetCloseButton; // 0x90
		private SetDeckUnitSetSelectButtons m_unitSetSelectButtons; // 0x94
		private SetDeckUnitInfo m_unitSetInfo; // 0x98
		private SetDeckLoadSaveButtons m_loadSaveButtons; // 0x9C
		private SetDeckStatusWindow m_statusWindow; // 0xA0
		private bool m_isFromBeginner; // 0xA4
		private int m_beginnerMissionId; // 0xA8
		private SetDeckParamCalculator m_paramCalculator = new SetDeckParamCalculator(); // 0xAC
		private SetDeckParamCalculator m_unitSetParamCalculator = new SetDeckParamCalculator(); // 0xB0
		private JLKEOGLJNOD_TeamInfo m_viewUnitData; // 0xB4
		private int m_divaDispTypeIndex; // 0xB8
		private int m_sceneDispTypeIndex; // 0xBC
		private bool m_isWaitOpenScene; // 0xC0
		private bool m_isOpenEndAutoSetting; // 0xC1
		private bool m_isShowSubPlate; // 0xC2
		private bool m_isWaitOnPostSetCanvas; // 0xC3
		private bool m_isWaitActivateScene; // 0xC4
		private bool m_isWaitEnterAnimation; // 0xC5
		private bool m_isWaitExitAnimation; // 0xC6
		private TeamSelectDivaListArgs m_selectDivaListArgs = new TeamSelectDivaListArgs(); // 0xC8
		private CostumeChangeDivaArgs m_costumeChangeDivaArgs = new CostumeChangeDivaArgs(); // 0xCC
		private TeamSelectSceneListArgs m_selectSceneListArgs = new TeamSelectSceneListArgs(); // 0xD0
		private PopupFilterSortUGUIInitParam m_dispTypePopupParam = new PopupFilterSortUGUIInitParam(); // 0xD4
		private PopupValkyrieStatusSetting m_valkyriePopupSetting = new PopupValkyrieStatusSetting(); // 0xD8

		private DFKGGBMFFGB_PlayerInfo PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0xF9ECFC 
		private int UnitSetIndex { get { return TeamSelectSceneUnit5.UnitSetSelectIndex_Normal; } set { TeamSelectSceneUnit5.UnitSetSelectIndex_Normal = value; } } //0xF9ED98  0xF9EE24 

		// RVA: 0xF9EEB4 Offset: 0xF9EEB4 VA: 0xF9EEB4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_dispTypePopupParam.Scene = PopupFilterSortUGUI.Scene.UnitDispType;
			m_dispTypePopupParam.EnableSave = true;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_valkyriePopupSetting.TitleText = bk.GetMessageByLabel("popup_title_04");
			m_valkyriePopupSetting.SetParent(transform);
			m_valkyriePopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			this.StartCoroutineWatched(Co_LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D8EB4 Offset: 0x6D8EB4 VA: 0x6D8EB4
		//// RVA: 0xF9F0FC Offset: 0xF9F0FC VA: 0xF9F0FC
		private IEnumerator Co_LoadResource()
		{
			//0xFA9FC8
			yield return Co.R(CreateUGUIObjectCache());
			IsReady = true;
		}

		// RVA: 0xF9F1A8 Offset: 0xF9F1A8 VA: 0xF9F1A8 Slot: 5
		protected override void Start()
		{
			base.Start();
		}

		// RVA: 0xF9F1B0 Offset: 0xF9F1B0 VA: 0xF9F1B0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			InitializeUGUIObject();
			m_headButtons.OnClickAutoSettingButton = OnClickAutoSettingButton;
			m_headButtons.OnClickUnitSetButton = OnClickUnitSetButton;
			m_unitStatus.OnClickNameEditButton = OnChangeUnitName;
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
			m_unitInfo.SetTapGuard(false);
			m_unitSetListButtons.OnClickUnitButton = (int no, JLKEOGLJNOD_TeamInfo data) =>
			{
				//0xFA86E4
				OnClickAnyButtons();
			};
			m_unitSetListButtons.OnChangeUnit = OnChangeUnitSetSelect;
			m_unitSetListButtons.OnStartChangePage = OnStartChangeUnitSetPage;
			m_unitSetListButtons.OnEndChangePage = OnEndChangeUnitSetPage;
			m_unitSetCloseButton.OnClickCloseButton = OnClickUnitSetCloseButton;
			m_unitSetSelectButtons.OnClickSelectButtonLeft = () =>
			{
				//0xFA870C
				OnClickUnitSetSelectButton(-1);
			};
			m_unitSetSelectButtons.OnClickSelectButtonRight = () =>
			{
				//0xFA8738
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
			if(Args != null)
			{
				m_isFromBeginner = (Args as TeamEditSceneArgs).IsFromBeginner;
				m_beginnerMissionId = (Args as TeamEditSceneArgs).BeginnerMissionId;
			}
			if (TransitionType != MenuTransitionControl.TransitionType.Return)
				m_dispType = DispType.CurrentUnit;
			if(GameManager.Instance.IsTutorial)
			{
				TodoLogger.LogError(0, "Tuto");
			}
			m_viewUnitData = PlayerData.DPLBHAIKPGL_GetTeam(false);
			int divaSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem;
			int sceneSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem;
			m_divaDispTypeIndex = PopupSortMenu.UnitDivaSortItem.FindIndex((SortItem x) =>
			{
				//0xFA8764
				return divaSortItem == (int)x;
			});
			m_sceneDispTypeIndex = PopupSortMenu.UnitSortItem.FindIndex((SortItem x) =>
			{
				//0xFA8778
				return sceneSortItem == (int)x;
			});
			UpdateParamCalculator();
			m_unitSetListButtons.UpdateContent(PlayerData, false, UnitSetIndex);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
			if(m_dispType == DispType.UnitSet)
			{
				ApplyUnitSetContent(UnitSetIndex);
			}
			else
			{
				ApplyCurrentUnitContent(false);
			}
			ApplyDispType(m_dispType);
			m_statusWindow.gameObject.SetActive(false);
		}

		// RVA: 0xFA1730 Offset: 0xFA1730 VA: 0xFA1730 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !IsApplyWait() && base.IsEndPreSetCanvas();
		}

		// RVA: 0xFA17E4 Offset: 0xFA17E4 VA: 0xFA17E4 Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_OnPostSetCanvas());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D8F2C Offset: 0x6D8F2C VA: 0x6D8F2C
		//// RVA: 0xFA1808 Offset: 0xFA1808 VA: 0xFA1808
		private IEnumerator Co_OnPostSetCanvas()
		{
			//0xFAA4B8
			m_isWaitOnPostSetCanvas = true;
			yield return null;
			m_isWaitOnPostSetCanvas = false;
		}

		// RVA: 0xFA18B4 Offset: 0xFA18B4 VA: 0xFA18B4 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return !m_isWaitOnPostSetCanvas && base.IsEndPostSetCanvas();
		}

		// RVA: 0xFA18CC Offset: 0xFA18CC VA: 0xFA18CC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			this.StartCoroutineWatched(Co_EnterAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D8FA4 Offset: 0x6D8FA4 VA: 0x6D8FA4
		//// RVA: 0xFA18F0 Offset: 0xFA18F0 VA: 0xFA18F0
		private IEnumerator Co_EnterAnimation()
		{
			//0xFA9778
			m_isWaitEnterAnimation = true;
			SetTitleInOut(0, m_dispType);
			SetFooterInOut(0, m_dispType);
			SetInactiveUnnecessaryContent(m_dispType);
			yield return Co.R(Co_EnterContents(m_dispType));
			m_isWaitEnterAnimation = false;
		}

		// RVA: 0xFA199C Offset: 0xFA199C VA: 0xFA199C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_isWaitEnterAnimation;
		}

		// RVA: 0xFA19B0 Offset: 0xFA19B0 VA: 0xFA19B0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			this.StartCoroutineWatched(Co_ExitAnimation());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D901C Offset: 0x6D901C VA: 0x6D901C
		//// RVA: 0xFA19D4 Offset: 0xFA19D4 VA: 0xFA19D4
		private IEnumerator Co_ExitAnimation()
		{
			//0xFA9E10
			m_isWaitExitAnimation = true;
			while (IsPlayingContents())
				yield return null;
			LeaveContents();
			while (IsPlayingContents())
				yield return null;
			m_isWaitExitAnimation = false;
		}

		// RVA: 0xFA1A80 Offset: 0xFA1A80 VA: 0xFA1A80 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_isWaitExitAnimation;
		}

		// RVA: 0xFA1A94 Offset: 0xFA1A94 VA: 0xFA1A94 Slot: 21
		protected override void OnOpenScene()
		{
			m_isWaitOpenScene = true;
			this.StartCoroutineWatched(SceneOpenCoroutine());
		}

		// RVA: 0xFA1B50 Offset: 0xFA1B50 VA: 0xFA1B50 Slot: 22
		protected override bool IsEndOpenScene()
		{
			return !m_isWaitOpenScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9094 Offset: 0x6D9094 VA: 0x6D9094
		//// RVA: 0xFA1AC4 Offset: 0xFA1AC4 VA: 0xFA1AC4
		protected IEnumerator SceneOpenCoroutine()
		{
			int i;

			//0xFABC5C
			while (IsPlayingContents())
				yield return null;
			for (i = 0; i <= 4; i++)
				yield return null;
			MenuScene.Instance.TryShowPopupWindow(this, GameManager.Instance.ViewPlayerData, null, false, TransitionName, UpdateContent);
			if (m_isShowSubPlate)
			{
				m_isShowSubPlate = false;
				if(PrevTransition == TransitionList.Type.SCENE_GROWTH)
				{
					ShowSubPlateWindow(true);
				}
			}
			m_isWaitOpenScene = false;
		}

		// RVA: 0xFA1B84 Offset: 0xFA1B84 VA: 0xFA1B84 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_ShowHelp());
		}

		// RVA: 0xFA1C34 Offset: 0xFA1C34 VA: 0xFA1C34 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return !m_isWaitActivateScene;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D910C Offset: 0x6D910C VA: 0x6D910C
		//// RVA: 0xFA1BA8 Offset: 0xFA1BA8 VA: 0xFA1BA8
		private IEnumerator Co_ShowHelp()
		{
			//0xFAA5D0
			m_isWaitActivateScene = true;
			if(TutorialProc.CanAutoSettingHelp())
			{
				yield return this.StartCoroutineWatched(TutorialProc.Co_TutorialAutoUnitSetting(m_headButtons.AutoSettingButton, () =>
				{
					//0xFA7DAC
					return m_isOpenEndAutoSetting;
				}));
			}
			if(m_isFromBeginner)
			{
				TodoLogger.LogError(0, "ShowHelp m_isFromBeginner");
			}
			if(!GameManager.Instance.IsTutorial)
			{
				MenuScene.Instance.InputDisable();
				yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCondition));
				MenuScene.Instance.InputEnable();
			}
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_isWaitActivateScene = false;
		}

		// RVA: 0xFA1C68 Offset: 0xFA1C68 VA: 0xFA1C68 Slot: 14
		protected override void OnDestoryScene()
		{
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton); // Fix original game bug (AddPushBackButtonHandler)
			FinalizeUGUIObject();
		}

		// RVA: 0xFA220C Offset: 0xFA220C VA: 0xFA220C Slot: 15
		protected override void OnDeleteCache()
		{
			if (TransitionName != TransitionList.Type.TEAM_EDIT)
				return;
			MenuScene.Instance.divaManager.Release(true);
		}

		//// RVA: 0xFA2310 Offset: 0xFA2310 VA: 0xFA2310
		//private bool IsDifferHomeDivaModel(JLKEOGLJNOD unitData) { }

		// RVA: 0xFA2804 Offset: 0xFA2804 VA: 0xFA2804 Slot: 25
		protected override void OnTutorial()
		{
			this.StartCoroutineWatched(Co_ShowTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9184 Offset: 0x6D9184 VA: 0x6D9184
		//// RVA: 0xFA2828 Offset: 0xFA2828 VA: 0xFA2828
		private IEnumerator Co_ShowTutorial()
		{
			//0xFAAE94
			MenuScene.Instance.InputDisable();
			bool isWait = true;
			BasicTutorialManager.Instance.ShowMessageWindow(BasicTutorialMessageId.Id_PlateSelect, () =>
			{
				//0xFA879C
				isWait = false;
			}, null);
			yield return new WaitWhile(() =>
			{
				//0xFA8794
				return isWait;
			});
			MenuScene.Instance.InputEnable();
			BasicTutorialManager.Instance.SetInputLimit(InputLimitButton.Delegate, null, () =>
			{
				//0xFA87A8
				return m_unitInfo.CenterMainSceneButton;
			}, TutorialPointer.Direction.Normal);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D91FC Offset: 0x6D91FC VA: 0x6D91FC
		//// RVA: 0xFA28D4 Offset: 0xFA28D4 VA: 0xFA28D4
		protected IEnumerator CreateUGUIObjectCache()
		{
			int reqCount;

			//0xFAB748
			yield return AssetBundleManager.LoadUnionAssetBundle("ly/013.xab");
			int loadCount = 0;
			reqCount = 0;
			for(int i = 0; i < m_prefabCacheParams.Length; i++)
			{
				if(!GameManager.Instance.LayoutObjectCache.IsLoadedObject(m_prefabCacheParams[i].prefabName))
				{
					this.StartCoroutineWatched(GameManager.Instance.LayoutObjectCache.CreateUGUI("ly/013.xab", m_prefabCacheParams[i].prefabName, null, m_prefabCacheParams[i].count, () =>
					{
						//0xFA87F0
						loadCount++;
					}));
					reqCount++;
				}
			}
			while (loadCount < reqCount)
				yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/013.xab", false);
			yield return null;
		}

		//// RVA: 0xFA007C Offset: 0xFA007C VA: 0xFA007C
		private void InitializeUGUIObject()
		{
			m_headButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckHeadButtons");
			m_unitStatusObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitStatus");
			m_valkyrieButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckValkyrieButton");
			m_unitInfoChangeButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfoChangeButton");
			m_unitInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_Edit");
			m_unitSetListButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetListButtons");
			m_unitSetCloseButtonObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetCloseButton");
			m_unitSetSelectButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitSetSelectButtons");
			m_unitSetInfoObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckUnitInfo_Edit");
			m_loadSaveButtonsObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckLoadSaveButtons");
			m_statusWindowObject = GameManager.Instance.LayoutObjectCache.GetUGUIInstance("SetDeckStatusWindow");
			m_headButtonsObject.instanceObject.SetActive(true);
			m_unitStatusObject.instanceObject.SetActive(true);
			m_valkyrieButtonObject.instanceObject.SetActive(true);
			m_unitInfoChangeButtonObject.instanceObject.SetActive(true);
			m_unitInfoObject.instanceObject.SetActive(true);
			m_unitSetListButtonsObject.instanceObject.SetActive(true);
			m_unitSetCloseButtonObject.instanceObject.SetActive(true);
			m_unitSetSelectButtonsObject.instanceObject.SetActive(true);
			m_unitSetInfoObject.instanceObject.SetActive(true);
			m_loadSaveButtonsObject.instanceObject.SetActive(true);
			m_statusWindowObject.instanceObject.SetActive(true);
			m_headButtons = m_headButtonsObject.instanceObject.GetComponentInChildren<SetDeckHeadButtons>();
			m_unitStatus = m_unitStatusObject.instanceObject.GetComponentInChildren<SetDeckUnitStatus>();
			m_valkyrieButton = m_valkyrieButtonObject.instanceObject.GetComponentInChildren<SetDeckValkyrieButton>();
			m_unitInfoChangeButton = m_unitInfoChangeButtonObject.instanceObject.GetComponentInChildren<SetDeckUnitInfoChangeButton>();
			m_unitInfo = m_unitInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfo>();
			m_unitSetListButtons = m_unitSetListButtonsObject.instanceObject.GetComponentInChildren<SetDeckUnitSetListButtons>();
			m_unitSetCloseButton = m_unitSetCloseButtonObject.instanceObject.GetComponentInChildren<SetDeckUnitSetCloseButton>();
			m_unitSetSelectButtons = m_unitSetSelectButtonsObject.instanceObject.GetComponentInChildren<SetDeckUnitSetSelectButtons>();
			m_unitSetInfo = m_unitSetInfoObject.instanceObject.GetComponentInChildren<SetDeckUnitInfo>();
			m_loadSaveButtons = m_loadSaveButtonsObject.instanceObject.GetComponentInChildren<SetDeckLoadSaveButtons>();
			m_statusWindow = m_statusWindowObject.instanceObject.GetComponentInChildren<SetDeckStatusWindow>();
			m_headButtonsObject.SetParent(transform, null);
			m_unitStatusObject.SetParent(transform, null);
			m_valkyrieButtonObject.SetParent(transform, null);
			m_unitInfoChangeButtonObject.SetParent(transform, null);
			m_unitInfoObject.SetParent(transform, null);
			m_unitSetListButtonsObject.SetParent(transform, null);
			m_unitSetCloseButtonObject.SetParent(transform, null);
			m_unitSetSelectButtonsObject.SetParent(transform, null);
			m_unitSetInfoObject.SetParent(transform, null);
			m_loadSaveButtonsObject.SetParent(transform, null);
			m_statusWindowObject.SetParent(transform, null);
			m_unitSetInfo.transform.SetAsLastSibling();
			m_unitInfo.transform.SetAsLastSibling();
			m_unitInfoChangeButton.transform.SetAsLastSibling();
			m_unitSetSelectButtons.transform.SetAsLastSibling();
			m_unitStatus.transform.SetAsLastSibling();
			m_valkyrieButton.transform.SetAsLastSibling();
			m_headButtons.transform.SetAsLastSibling();
			m_unitSetListButtons.transform.SetAsLastSibling();
			m_unitSetCloseButton.transform.SetAsLastSibling();
			m_loadSaveButtons.transform.SetAsLastSibling();
			m_statusWindow.transform.SetAsLastSibling();
			ClearUGUIObjectListener();
			HideUGUIObject();
		}

		//// RVA: 0xFA1D4C Offset: 0xFA1D4C VA: 0xFA1D4C
		private void FinalizeUGUIObject()
		{
			ClearUGUIObjectListener();
			HideUGUIObject();
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckHeadButtons", m_headButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitStatus", m_unitStatusObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckValkyrieButton", m_valkyrieButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfoChangeButton", m_unitInfoChangeButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_Edit", m_unitInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetListButtons", m_unitSetListButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetCloseButton", m_unitSetCloseButtonObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitSetSelectButtons", m_unitSetSelectButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckUnitInfo_Edit", m_unitSetInfoObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckLoadSaveButtons", m_loadSaveButtonsObject);
			GameManager.Instance.LayoutObjectCache.ReturnUGUIInstance("SetDeckStatusWindow", m_statusWindowObject);
			m_unitSetSelectButtonsObject = null;
			m_unitSetInfoObject = null;
			m_loadSaveButtonsObject = null;
			m_statusWindowObject = null;
			m_headButtonsObject = null;
			m_unitStatusObject = null;
			m_valkyrieButtonObject = null;
			m_unitInfoChangeButtonObject = null;
			m_unitInfoObject = null;
			m_unitSetListButtonsObject = null;
			m_unitSetCloseButtonObject = null;
			m_unitSetSelectButtonsObject = null;
		}

		//// RVA: 0xFA2980 Offset: 0xFA2980 VA: 0xFA2980
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
		}

		//// RVA: 0xFA2C9C Offset: 0xFA2C9C VA: 0xFA2C9C
		private void HideUGUIObject()
		{
			m_headButtons.InOut.Leave(0, false, null);
			m_unitStatus.InOut.Leave(0, false, null);
			m_valkyrieButton.InOut.Leave(0, false, null);
			m_unitInfoChangeButton.InOut.Leave(0, false, null);
			m_unitInfo.AnimeControl.Hide();
			m_unitSetListButtons.InOut.Leave(0, false, null);
			m_unitSetCloseButton.InOut.Leave(0, false, null);
			m_unitSetSelectButtons.InOutLeft.Leave(0, false, null);
			m_unitSetSelectButtons.InOutRight.Leave(0, false, null);
			m_unitSetInfo.AnimeControl.Hide();
			m_loadSaveButtons.InOut.Leave(0, false, null);
			m_statusWindow.InOut.Leave(0, false, null);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
		}

		//// RVA: 0xFA107C Offset: 0xFA107C VA: 0xFA107C
		private void UpdateParamCalculator()
		{
			m_paramCalculator.Calc(PlayerData, m_viewUnitData, null, null);
		}

		//// RVA: 0xFA1684 Offset: 0xFA1684 VA: 0xFA1684
		private void ApplyDispType(DispType dispType)
		{
			if(dispType == DispType.UnitSet)
			{
				m_unitStatus.SetUnitNameEditButtonEnable(false);
				m_unitStatus.SetCheckStatusButtonEnable(true);
			}
			else if(m_dispType == DispType.CurrentUnit)
			{
				m_headButtons.SetType(SetDeckHeadButtons.Type.TeamEdit);
				m_unitStatus.SetUnitNameEditButtonEnable(true);
				m_unitStatus.SetCheckStatusButtonEnable(true);
			}
		}

		//// RVA: 0xFA13F4 Offset: 0xFA13F4 VA: 0xFA13F4
		private void ApplyCurrentUnitContent(bool forPrism = false)
		{
			UpdateParamCalculator();
			m_unitStatus.UpdateContent(m_paramCalculator);
			m_unitStatus.SetUnitName(m_viewUnitData.BHKALCOAHHO_Name);
			if(!forPrism)
			{
				m_valkyrieButton.UpdateContent(m_viewUnitData);
			}
			m_valkyrieButton.SetTapGuard(false);
			m_unitInfo.UpdateContent(PlayerData, m_viewUnitData, m_paramCalculator, null, null, false);
			m_unitInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
			m_statusWindow.UpdateContent(PlayerData, m_viewUnitData, null, null, null, UnitWindowConstant.OperationMode.Check, false);
		}

		//// RVA: 0xFA10D4 Offset: 0xFA10D4 VA: 0xFA10D4
		private void ApplyUnitSetContent(int unitSetIndex)
		{
			JLKEOGLJNOD_TeamInfo unit = PlayerData.JKIJFGGMNAN_GetUnit(unitSetIndex, false);
			m_unitSetParamCalculator.Calc(PlayerData, unit, null, null);
			m_unitStatus.UpdateContent(m_unitSetParamCalculator);
			m_unitStatus.SetUnitName(unit.BHKALCOAHHO_Name);
			m_valkyrieButton.UpdateContent(unit);
			m_valkyrieButton.SetTapGuard(true);
			m_unitSetInfo.UpdateContent(PlayerData, unit, m_unitSetParamCalculator, null, null, false);
			m_unitSetInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
			m_statusWindow.UpdateContent(PlayerData, unit, null, null, null, UnitWindowConstant.OperationMode.Check, false);
			m_loadSaveButtons.SetType(unit.EIGKIHENKNC_HasNoDivaSet ? SetDeckLoadSaveButtons.ModeType.NewSave : SetDeckLoadSaveButtons.ModeType.Overwrite);
		}

		//// RVA: 0xFA3078 Offset: 0xFA3078 VA: 0xFA3078
		private void ApplyUnitContent(DispType dispType)
		{
			if (dispType == DispType.UnitSet)
				ApplyUnitSetContent(UnitSetIndex);
			else
				ApplyCurrentUnitContent(false);
		}

		//// RVA: 0xFA30B8 Offset: 0xFA30B8 VA: 0xFA30B8
		private void UpdateContent()
		{
			ApplyUnitContent(m_dispType);
		}

		//// RVA: 0xFA175C Offset: 0xFA175C VA: 0xFA175C
		private bool IsApplyWait()
		{
			return m_valkyrieButton.IsUpdatingContent || m_unitInfo.IsUpdatingContent() || m_unitSetInfo.IsUpdatingContent();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9274 Offset: 0x6D9274 VA: 0x6D9274
		//// RVA: 0xFA3150 Offset: 0xFA3150 VA: 0xFA3150
		private IEnumerator Co_EnterContents(DispType dispType)
		{
			//0xFA9968
			SetActiveNecessaryContent(dispType);
			LeaveUnnecessaryContent(dispType);
			EnterNecessaryContent(dispType);
			while (IsPlayingContents())
				yield return null;
			SetInactiveUnnecessaryContent(dispType);
		}

		//// RVA: 0xFA3218 Offset: 0xFA3218 VA: 0xFA3218
		private void EnterNecessaryContent(DispType dispType)
		{
			SetDeckUnitInfoAnimeControl.DispType d = (SetDeckUnitInfoAnimeControl.DispType)GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType;
			if(dispType == DispType.CurrentUnit)
			{
				m_headButtons.InOut.Enter(false, null);
				m_unitStatus.InOut.Enter(false, null);
				m_valkyrieButton.InOut.Enter(false, null);
				m_unitInfoChangeButton.InOut.Enter(false, null);
				m_unitInfo.AnimeControl.TryEnter(d);
			}
			else if(dispType == DispType.UnitSet)
			{
				m_unitStatus.InOut.Enter(false, null);
				m_valkyrieButton.InOut.Enter(false, null);
				m_unitInfoChangeButton.InOut.Enter(false, null);
				m_unitSetListButtons.InOut.Enter(false, null);
				m_unitSetListButtons.ResetUnitNameScroll();
				m_unitSetCloseButton.InOut.Enter(false, null);
				m_unitSetSelectButtons.InOutLeft.Enter(false, null);
				m_unitSetSelectButtons.InOutRight.Enter(false, null);
				m_unitSetInfo.AnimeControl.TryEnter(d);
				m_loadSaveButtons.InOut.Enter(false);
			}
		}

		//// RVA: 0xFA3738 Offset: 0xFA3738 VA: 0xFA3738
		private void LeaveUnnecessaryContent(DispType dispType)
		{
			if(dispType == DispType.UnitSet)
			{
				m_headButtons.InOut.Leave(false, null);
				m_unitInfo.AnimeControl.TryLeave();
			}
			else if(dispType == DispType.CurrentUnit)
			{
				m_unitSetListButtons.InOut.Leave(false, null);
				m_unitSetCloseButton.InOut.Leave(false, null);
				m_unitSetSelectButtons.InOutLeft.Leave(false, null);
				m_unitSetSelectButtons.InOutRight.Leave(false, null);
				m_unitSetInfo.AnimeControl.TryLeave();
				m_loadSaveButtons.InOut.Leave(false, null);
			}
		}

		//// RVA: 0xFA398C Offset: 0xFA398C VA: 0xFA398C
		private void SetActiveNecessaryContent(DispType dispType)
		{
			if(dispType == DispType.UnitSet)
			{
				m_unitStatus.gameObject.SetActive(true);
				m_valkyrieButton.gameObject.SetActive(true);
				m_unitInfoChangeButton.gameObject.SetActive(true);
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
				m_unitInfoChangeButton.gameObject.SetActive(true);
				m_unitInfo.gameObject.SetActive(true);
			}
		}

		//// RVA: 0xFA3CE4 Offset: 0xFA3CE4 VA: 0xFA3CE4
		private void SetInactiveUnnecessaryContent(DispType dispType)
		{
			if(dispType == DispType.UnitSet)
			{
				m_headButtons.gameObject.SetActive(false);
				m_unitInfo.gameObject.SetActive(false);
			}
			else if(dispType == DispType.CurrentUnit)
			{
				m_unitSetListButtons.gameObject.SetActive(false);
				m_unitSetCloseButton.gameObject.SetActive(false);
				m_unitSetSelectButtons.gameObject.SetActive(false);
				m_unitSetInfo.gameObject.SetActive(false);
				m_loadSaveButtons.gameObject.SetActive(false);
			}
		}

		//// RVA: 0xFA3EA4 Offset: 0xFA3EA4 VA: 0xFA3EA4
		private void LeaveContents()
		{
			m_headButtons.InOut.Leave(false, null);
			m_unitStatus.InOut.Leave(false, null);
			m_valkyrieButton.InOut.Leave(false, null);
			m_unitInfoChangeButton.InOut.Leave(false, null);
			m_unitInfo.AnimeControl.TryLeave();
			m_unitSetListButtons.InOut.Leave(false, null);
			m_unitSetCloseButton.InOut.Leave(false, null);
			m_unitSetSelectButtons.InOutLeft.Leave(false, null);
			m_unitSetSelectButtons.InOutRight.Leave(false, null);
			m_unitSetInfo.AnimeControl.TryLeave();
			m_unitSetInfo.MessageControl.Leave();
			m_loadSaveButtons.InOut.Leave(false, null);
			m_statusWindow.InOut.Leave(false, null);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
		}

		//// RVA: 0xFA4268 Offset: 0xFA4268 VA: 0xFA4268
		private bool IsPlayingContents()
		{
			return m_headButtons.InOut.IsPlaying() ||
				m_unitStatus.InOut.IsPlaying() ||
				m_valkyrieButton.InOut.IsPlaying() ||
				m_unitInfoChangeButton.InOut.IsPlaying() ||
				m_unitInfo.AnimeControl.IsPlaying() ||
				m_unitSetListButtons.InOut.IsPlaying() ||
				m_unitSetCloseButton.InOut.IsPlaying() ||
				m_unitSetSelectButtons.InOutLeft.IsPlaying() ||
				m_unitSetSelectButtons.InOutRight.IsPlaying() ||
				m_unitSetInfo.AnimeControl.IsPlaying() ||
				m_loadSaveButtons.InOut.IsPlaying() ||
				m_statusWindow.InOut.IsPlaying();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D92EC Offset: 0x6D92EC VA: 0x6D92EC
		//// RVA: 0xFA45D8 Offset: 0xFA45D8 VA: 0xFA45D8
		private IEnumerator Co_SwitchContents(DispType dispType)
		{
			DispType prevDispType; // 0x18
			int waitCount; // 0x1C

			//0xFAB238
			MenuScene.Instance.RaycastDisable();
			prevDispType = m_dispType;
			m_dispType = dispType;
			SetActiveNecessaryContent(dispType);
			ApplyDispType(dispType);
			ApplyUnitContent(dispType);
			while (IsApplyWait())
				yield return null;
			while (m_statusWindow.InOut.IsPlaying())
				yield return null;
			m_statusWindow.InOut.Leave(false, null);
			m_unitStatus.SetCheckStatusButtonState(SetDeckUnitStatus.CheckStatusButtonState.Normal);
			m_unitSetInfo.MessageControl.Leave();
			SetTitleInOut(prevDispType, dispType);
			SetFooterInOut(prevDispType, dispType);
			LeaveUnnecessaryContent(dispType);
			waitCount = 0;
			while(waitCount < m_switchDispTypeWaitFrame)
			{
				m_switchDispTypeWaitFrame++;
				yield return null;
			}
			EnterNecessaryContent(dispType);
			while (IsPlayingContents())
				yield return null;
			SetInactiveUnnecessaryContent(dispType);
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xFA46A0 Offset: 0xFA46A0 VA: 0xFA46A0
		private void SetTitleInOut(DispType prevType, DispType nextType)
		{
			if (prevType == nextType)
				return;
			if (nextType == DispType.UnitSet)
			{
				MenuScene.Instance.HelpButton.TryLeave();
				MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
				MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
			}
			else
			{
				MenuScene.Instance.HelpButton.TryEnter();
				MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
				MenuScene.Instance.HeaderMenu.MenuStack.EnterLabel();
			}
		}

		//// RVA: 0xFA49A0 Offset: 0xFA49A0 VA: 0xFA49A0
		//private bool IsUseTitle(TeamEditSceneUnit5.DispType dispType) { }

		//// RVA: 0xFA49B0 Offset: 0xFA49B0 VA: 0xFA49B0
		private void SetFooterInOut(DispType prevType, DispType nextType)
		{
			if (prevType == nextType)
				return;
			if(nextType == DispType.UnitSet)
			{
				MenuScene.Instance.FooterLeave();
			}
			else
			{
				MenuScene.Instance.FooterEnter();
			}
		}

		//// RVA: 0xFA4AC4 Offset: 0xFA4AC4 VA: 0xFA4AC4
		//private bool IsUseFooter(TeamEditSceneUnit5.DispType dispType) { }

		//// RVA: 0xFA4AD4 Offset: 0xFA4AD4 VA: 0xFA4AD4
		private void OnChangeUnitName()
		{
			OnClickAnyButtons();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			InputPopupSetting s = new InputPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_title_01");
			s.Description = PopupWindowManager.FormatTextBank(bk, "popup_text_00", new object[1] { 15 });
			s.InputText = m_viewUnitData.BHKALCOAHHO_Name;
			s.Notes = PopupWindowManager.FormatTextBank(bk, "popup_text_01", new object[1] { 15 });
			s.CharacterLimit = 15;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xFA7DB4
				if(type == PopupButton.ButtonType.Positive)
				{
					m_viewUnitData.BHKALCOAHHO_Name = (control.Content as InputContent).Text;
					m_unitStatus.SetUnitName((control.Content as InputContent).Text);
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0xFA8608
				return;
			}, null, null, true, true, false);
		}

		//// RVA: 0xFA5180 Offset: 0xFA5180 VA: 0xFA5180
		private void OnShowStatusWindow()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_ShowStatusWindow(!m_statusWindow.InOut.IsEnter));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9364 Offset: 0x6D9364 VA: 0x6D9364
		//// RVA: 0xFA523C Offset: 0xFA523C VA: 0xFA523C
		private IEnumerator Co_ShowStatusWindow(bool isShow)
		{
			//0xFAAB10
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

		//// RVA: 0xFA5304 Offset: 0xFA5304 VA: 0xFA5304
		private void OnShowChangeStatusButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(m_dispTypePopupParam, (PopupFilterSortUGUI content) =>
			{
				//0xFA7F58
				int divaSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem;
				int sceneSortItem = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem;
				m_divaDispTypeIndex = PopupSortMenu.UnitDivaSortItem.FindIndex((SortItem x) =>
				{
					//0xFA86A8
					return divaSortItem == (int)x;
				});
				m_sceneDispTypeIndex = PopupSortMenu.UnitSortItem.FindIndex((SortItem x) =>
				{
					//0xFA86BC
					return sceneSortItem == (int)x;
				});
				ApplyStatusDisplayType();
			}, null);
		}

		//// RVA: 0xFA5458 Offset: 0xFA5458 VA: 0xFA5458
		private void ApplyStatusDisplayType()
		{
			m_unitInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
			m_unitSetInfo.SetStatusDisplayType(PopupSortMenu.UnitDivaSortItem[m_divaDispTypeIndex], PopupSortMenu.UnitSortItem[m_sceneDispTypeIndex]);
		}

		//// RVA: 0xFA55A0 Offset: 0xFA55A0 VA: 0xFA55A0
		private void OnClickValkyrieButton()
		{
			OnClickAnyButtons();
			if (m_dispType == DispType.CurrentUnit)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ValkyrieDataArgs arg = new ValkyrieDataArgs();
				arg.isGoDiva = false;
				MenuScene.Instance.Call(TransitionList.Type.VALKYRIE_SELECT, arg, true);
			}
		}

		//// RVA: 0xFA5730 Offset: 0xFA5730 VA: 0xFA5730
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

		//// RVA: 0xFA5950 Offset: 0xFA5950 VA: 0xFA5950
		private void OnClickUnitInfoChangeButton()
		{
			OnClickAnyButtons();
			if(m_dispType == DispType.CurrentUnit)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_unitInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
			}
			else if(m_dispType == DispType.UnitSet)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				m_unitSetInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
			}
		}

		//// RVA: 0xFA5B20 Offset: 0xFA5B20 VA: 0xFA5B20
		private SetDeckUnitInfoAnimeControl.DispType ChangeUnitInfoDispType()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType = (GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType + 1) % 2;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			return (SetDeckUnitInfoAnimeControl.DispType)GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType;
		}

		//// RVA: 0xFA5D00 Offset: 0xFA5D00 VA: 0xFA5D00
		//private void OnClickSubPlateButton() { }

		//// RVA: 0xFA5D6C Offset: 0xFA5D6C VA: 0xFA5D6C
		private void ShowSubPlateWindow(bool isReShow = false)
		{
			CFHDKAFLNEP c = new CFHDKAFLNEP();
			if (m_dispType == DispType.UnitSet)
				c = m_unitSetParamCalculator.SubPlateResult;
			if(c.CDOCOLOKCJK())
			{
				m_isShowSubPlate = true;
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateWindow(c, null, UnitWindowConstant.OperationMode.Check, null, () =>
				{
					//0xFA822C
					m_isShowSubPlate = false;
				}, isReShow);
			}
			else
			{
				MenuScene.Instance.UnitSaveWindowControl.ShowSubPlateLockWindow(null);
			}
		}

		//// RVA: 0xFA5FDC Offset: 0xFA5FDC VA: 0xFA5FDC
		private void OnSelectDiva(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_selectDivaListArgs.slot = slotNumber;
			m_selectDivaListArgs.viewPlayerData = PlayerData;
			m_selectDivaListArgs.isFromBeginner = m_isFromBeginner;
			m_selectDivaListArgs.beginnerMissionId = m_beginnerMissionId;
			MenuScene.Instance.Call(TransitionList.Type.DIVA_SELECT_LIST, m_selectDivaListArgs, true);
		}

		//// RVA: 0xFA6160 Offset: 0xFA6160 VA: 0xFA6160
		private void OnShowDivaStatus(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			if(divaData != null)
			{
				OnClickAnyButtons();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.ShowDivaStatusPopupWindow(divaData, PlayerData, null, false, TransitionName, null, true, false, slotNumber, false);
			}
		}

		//// RVA: 0xFA62AC Offset: 0xFA62AC VA: 0xFA62AC
		private void OnSelectCostume(int slotNumber, FFHPBEPOMAK_DivaInfo divaData)
		{
			OnClickAnyButtons();
			if(slotNumber > -1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_costumeChangeDivaArgs.DivaId = divaData.AHHJLDLAPAN_DivaId;
				m_costumeChangeDivaArgs.is_godiva = false;
				MenuScene.Instance.Call(TransitionList.Type.COSTUME_SELECT, m_costumeChangeDivaArgs, true);
			}
		}

		//// RVA: 0xFA6414 Offset: 0xFA6414 VA: 0xFA6414
		private void OnSelectScene(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			OnClickAnyButtons();
			if(divaSlotNumber > -1)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_selectSceneListArgs.divaSlotIndex = divaSlotNumber;
				m_selectSceneListArgs.divaData = divaData;
				m_selectSceneListArgs.defaultSelectScene = sceneSlotNumber;
				m_selectSceneListArgs.scelectType = SceneSelectType.SceneSelect;
				m_selectSceneListArgs.isGoDiva = false;
				MenuScene.Instance.Call(TransitionList.Type.SCENE_SELECT, m_selectSceneListArgs, true);
			}
		}

		//// RVA: 0xFA65B4 Offset: 0xFA65B4 VA: 0xFA65B4
		private void OnShowSceneStatus(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK_DivaInfo divaData, GCIJNCFDNON_SceneInfo sceneData)
		{
			if(sceneData != null)
			{
				OnClickAnyButtons();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, PlayerData, false, TransitionName, UpdateContent, false, false, SceneStatusParam.PageSave.Player, false);
			}
		}

		//// RVA: 0xFA6730 Offset: 0xFA6730 VA: 0xFA6730
		private void OnClickAutoSettingButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_isOpenEndAutoSetting = false;
			MenuScene.Instance.UnitSaveWindowControl.ShowUnitAutoSettingWindow(PlayerData, PopupAutoSettingContent.Place.UnitSelect, 0, 0, 0, (PopupAutoSettingContent content) =>
			{
				//0xFA8238
				content.ApplyAutoSetting(PlayerData.DPLBHAIKPGL_GetTeam(false), PlayerData, false);
				this.StartCoroutineWatched(Co_ApplyCurrentUnitContentForAutoSetting());
			}, () =>
			{
				//0xFA82CC
				this.StartCoroutineWatched(Co_ApplyCurrentUnitContentForAutoSetting());
			}, () =>
			{
				//0xFA82F0
				m_isOpenEndAutoSetting = true;
			}, null, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D93DC Offset: 0x6D93DC VA: 0x6D93DC
		//// RVA: 0xFA693C Offset: 0xFA693C VA: 0xFA693C
		private IEnumerator Co_ApplyCurrentUnitContentForAutoSetting()
		{
			//0xFA8804
			MenuScene.Instance.RaycastDisable();
			if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.ECNAIALHHBO_UnitMenu.BLABFAMKLIN_UnitInfoDispType != 0)
			{
				yield return null;
				m_unitInfo.AnimeControl.ChangeDispType(ChangeUnitInfoDispType());
				while (m_unitInfo.AnimeControl.IsPlaying())
					yield return null;
			}
			ApplyCurrentUnitContent(false);
			while (IsApplyWait())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xFA69E8 Offset: 0xFA69E8 VA: 0xFA69E8
		private void OnClickUnitSetButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_EnterUnitSet());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9454 Offset: 0x6D9454 VA: 0x6D9454
		//// RVA: 0xFA6A60 Offset: 0xFA6A60 VA: 0xFA6A60
		private IEnumerator Co_EnterUnitSet()
		{
			//0xFA9B0C
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(Co_DownloadUnitSetResources());
			yield return Co.R(Co_SwitchContents(DispType.UnitSet));
			m_unitSetInfo.MessageControl.Enter(PlayerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, false).EIGKIHENKNC_HasNoDivaSet ? SetDeckUnitInfoMessageControl.DispType.Keep : SetDeckUnitInfoMessageControl.DispType.OneShot, SetDeckUnitInfoMessageControl.MessageType.UnitSetHelp);
			MenuScene.Instance.RaycastEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D94CC Offset: 0x6D94CC VA: 0x6D94CC
		//// RVA: 0xFA6B0C Offset: 0xFA6B0C VA: 0xFA6B0C
		private IEnumerator Co_DownloadUnitSetResources()
		{
			//0xFA8E98
			for(int i = 0; i < PlayerData.DDMBOKCCLBD_GetUnits(false).Count; i++)
			{
				for(int j = 0; j < PlayerData.JKIJFGGMNAN_GetUnit(i, false).BCJEAJPLGMB_MainDivas.Count; j++)
				{
					FFHPBEPOMAK_DivaInfo d = PlayerData.JKIJFGGMNAN_GetUnit(i, false).BCJEAJPLGMB_MainDivas[j];
					if(d != null)
					{
						MenuScene.Instance.DivaIconCache.TryInstall(d.AHHJLDLAPAN_DivaId, d.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, d.EKFONBFDAAP_ColorId);
						if(d.FGFIBOBAPIA_SceneId > 0)
						{
							GCIJNCFDNON_SceneInfo scene = PlayerData.OPIBAPEGCLA_Scenes[d.FGFIBOBAPIA_SceneId - 1];
							MenuScene.Instance.SceneIconCache.TryInstall(scene.BCCHOBPJJKE_SceneId, scene.CGIELKDLHGE_GetEvolveId());
						}
						for (int k = 0; k < d.DJICAKGOGFO_SubSceneIds.Count; k++)
						{
							if(d.DJICAKGOGFO_SubSceneIds[k] > 0)
							{
								GCIJNCFDNON_SceneInfo scene = PlayerData.OPIBAPEGCLA_Scenes[d.DJICAKGOGFO_SubSceneIds[k] - 1];
								MenuScene.Instance.SceneIconCache.TryInstall(scene.BCCHOBPJJKE_SceneId, scene.CGIELKDLHGE_GetEvolveId());
							}
						}
					}
				}
				for (int j = 0; j < PlayerData.JKIJFGGMNAN_GetUnit(i, false).CMOPCCAJAAO_AddDivas.Count; j++)
				{
					FFHPBEPOMAK_DivaInfo d = PlayerData.JKIJFGGMNAN_GetUnit(i, false).CMOPCCAJAAO_AddDivas[j];
					if (d != null)
					{
						MenuScene.Instance.DivaIconCache.TryInstall(d.AHHJLDLAPAN_DivaId, d.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, d.EKFONBFDAAP_ColorId);
					}
				}
			}
			while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		//// RVA: 0xFA6BB8 Offset: 0xFA6BB8 VA: 0xFA6BB8
		private void OnChangeUnitSetSelect(int unitSetIndex, JLKEOGLJNOD_TeamInfo unitData)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			UnitSetIndex = unitSetIndex;
			this.StartCoroutineWatched(Co_ApplyUnitSetContent(true));
		}

		//// RVA: 0xFA6CE8 Offset: 0xFA6CE8 VA: 0xFA6CE8
		private void OnStartChangeUnitSetPage()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.RaycastDisable();
		}

		//// RVA: 0xFA6DDC Offset: 0xFA6DDC VA: 0xFA6DDC
		private void OnEndChangeUnitSetPage()
		{
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xFA6E78 Offset: 0xFA6E78 VA: 0xFA6E78
		private void OnClickUnitSetCloseButton()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
			this.StartCoroutineWatched(Co_SwitchContents(DispType.CurrentUnit));
		}

		//// RVA: 0xFA6EF4 Offset: 0xFA6EF4 VA: 0xFA6EF4
		private void OnClickUnitSetSelectButton(int tick)
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_OnClickUnitSetSelect(tick));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9544 Offset: 0x6D9544 VA: 0x6D9544
		//// RVA: 0xFA6F74 Offset: 0xFA6F74 VA: 0xFA6F74
		private IEnumerator Co_OnClickUnitSetSelect(int tick)
		{
			//0xFAA0F0
			MenuScene.Instance.RaycastDisable();
			int a = UnitSetIndex;
			int i;
			for (i = tick + a; i < 0; i += a)
			{
				a = m_unitSetListButtons.UnitCount;
			}
			for(; i < m_unitSetListButtons.UnitCount; i -= m_unitSetListButtons.UnitCount)
			{
			}
			UnitSetIndex = i;
			yield return Co.R(Co_ApplyUnitSetContent(false));
			bool isWait = true;
			m_unitSetListButtons.ChangeSelect(UnitSetIndex, () =>
			{
				//0xFA86D8
				isWait = false;
			});
			while (isWait)
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xFA703C Offset: 0xFA703C VA: 0xFA703C
		private void OnUnitSetLoad()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			MenuScene.Instance.UnitSaveWindowControl.ShowConfirmWindow(ConfirmType.Load, PlayerData, PlayerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, false).CDPKOIDDKIJ, null, null, null, () =>
			{
				//0xFA82FC
				MenuScene.Instance.RaycastDisable();
				LoadUnitSetForCurrentUnit(UnitSetIndex);
			}, () =>
			{
				//0xFA83A4
				MenuScene.Instance.RaycastEnable();
				this.StartCoroutineWatched(Co_SwitchContents(DispType.CurrentUnit));
			}, null, false);
		}

		//// RVA: 0xFA7248 Offset: 0xFA7248 VA: 0xFA7248
		private void OnUnitSetSave()
		{
			OnClickAnyButtons();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			MenuScene.Instance.UnitSaveWindowControl.ShowConfirmWindow(ConfirmType.Save, PlayerData, PlayerData.JKIJFGGMNAN_GetUnit(UnitSetIndex, false).CDPKOIDDKIJ, null, null, null, () =>
			{
				//0xFA8460
				MenuScene.Instance.RaycastDisable();
				SaveUnitSetByCurrentUnit(UnitSetIndex);
				ApplyUnitSetContent(UnitSetIndex);
				m_unitSetListButtons.UpdateContent(PlayerData, false);
				m_unitSetInfo.MessageControl.Leave();
			}, () =>
			{
				//0xFA860C
				MenuScene.Instance.RaycastEnable();
			}, null, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D95BC Offset: 0x6D95BC VA: 0x6D95BC
		//// RVA: 0xFA6C40 Offset: 0xFA6C40 VA: 0xFA6C40
		private IEnumerator Co_ApplyUnitSetContent(bool isApplyUnitSetList = true)
		{
			//0xFA8C04
			MenuScene.Instance.RaycastDisable();
			ApplyUnitSetContent(UnitSetIndex);
			if(isApplyUnitSetList)
			{
				m_unitSetListButtons.UpdateContent(PlayerData, false);
			}
			while (IsApplyWait())
				yield return null;
			MenuScene.Instance.RaycastEnable();
		}

		//// RVA: 0xFA7518 Offset: 0xFA7518 VA: 0xFA7518
		private void SaveUnitSetByCurrentUnit(int unitSetIndex)
		{
			PlayerData.JKIJFGGMNAN_GetUnit(unitSetIndex, false).KMLFHLOBPNH(PlayerData.OPIBAPEGCLA_Scenes);
		}

		//// RVA: 0xFA7594 Offset: 0xFA7594 VA: 0xFA7594
		private void LoadUnitSetForCurrentUnit(int unitSetIndex)
		{
			PlayerData.LCCKKHFEIGH(unitSetIndex);
			ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_19612, unitSetIndex + 1, true, false, 1);
		}

		//// RVA: 0xFA5134 Offset: 0xFA5134 VA: 0xFA5134
		private void OnClickAnyButtons()
		{
			m_unitSetInfo.MessageControl.Leave();
		}

		//// RVA: 0xFA7688 Offset: 0xFA7688 VA: 0xFA7688
		private bool CheckTutorialCondition(TutorialConditionId conditionId)
		{
			return false;
		}

		//// RVA: 0xFA7690 Offset: 0xFA7690 VA: 0xFA7690
		private void OnBackButton()
		{
			if(MenuScene.Instance.GetInputDisableCount() < 1)
			{
				if(MenuScene.Instance.GetRaycastDisableCount() < 1)
				{
					if(!GameManager.Instance.IsTutorial)
					{
						if (!MenuScene.Instance.IsRequestChangeScene)
						{
							if (MenuScene.Instance.DirtyChangeScene)
								return;
							if(m_dispType == DispType.UnitSet)
							{
								OnClickUnitSetCloseButton();
							}
							else
							{
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
								MenuScene.SaveRequest();
								MenuScene.Instance.Return(true);
							}
						}
					}
				}
			}
		}
	}
}
