using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaSelectListScene : TransitionRoot
	{
		private enum RemoveDivaState
		{
			CenterDiva = 0,
			EmptySlot = 1,
			Ok = 2,
		}

		[SerializeField]
		private ListSortButtonGroup m_sortGroupButton; // 0x48
		[SerializeField]
		private DivaSelectList m_divaSelectList; // 0x4C
		private AbsoluteLayout m_listWindowAnime; // 0x50
		private List<int> m_divaSortIdList = new List<int>(10); // 0x54
		private DivaComparisonPopupSetting m_divaComparisonPopupSetting; // 0x58
		private DivaChangePopupSetting m_divaChangePopupSetting; // 0x5C
		private const int LayoutMaxDivaCount = 11;
		private const int RemoveButtonId = -1;
		private List<int> m_divaIndexList = new List<int>(); // 0x60
		private StayButton[] m_stayButtons; // 0x64
		private ActionButton m_releaseButton; // 0x68
		private ActionButton m_changeButton; // 0x6C
		private RawImageEx m_changeButtonLabel; // 0x70
		private RawImageEx m_releaseInvalidImage; // 0x74
		private Action m_updater; // 0x78
		private LayoutUGUIRuntime m_runtime; // 0x7C
		private FFHPBEPOMAK_DivaInfo m_selectedDiva; // 0x80
		private EEDKAACNBBG m_musicData; // 0x84
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x88
		private TeamSelectDivaListArgs m_args; // 0x8C
		private GameObject m_popupContent; // 0x90
		private DivaSortExecutor m_divaSortExecutor = new DivaSortExecutor(); // 0x94
		private SortItem m_sortType; // 0x98
		private int m_selectedSlot; // 0x9C
		private byte m_order = (byte)ListSortButtonGroup.DefaultSortOrder; // 0xA0
		private bool m_isOpenEndConfirmPopup; // 0xA1
		private bool m_isWaitHelp; // 0xA2
		private readonly DisplayType[] m_displayTypeTbl = new DisplayType[11] {
			DisplayType.Total, DisplayType.Soul, DisplayType.Vocal, DisplayType.Charm, DisplayType.Get, DisplayType.Rarity,
			DisplayType.Level, DisplayType.Life, DisplayType.Support, DisplayType.Fold, DisplayType.Luck
		}; // 0xA4

		private DFKGGBMFFGB PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x17EE0F8
		//public bool IsEnableRelease { get; } 0x17EE194

		// RVA: 0x17EE1A8 Offset: 0x17EE1A8 VA: 0x17EE1A8
		private void Start()
		{
			StartCoroutine(InitializeCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D89C Offset: 0x72D89C VA: 0x72D89C
		//// RVA: 0x17EE1CC Offset: 0x17EE1CC VA: 0x17EE1CC
		private IEnumerator InitializeCoroutine()
		{
			//0x1265144
			m_divaComparisonPopupSetting = new DivaComparisonPopupSetting();
			m_divaComparisonPopupSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_02");
			m_divaComparisonPopupSetting.WindowSize = SizeType.Large;
			m_divaComparisonPopupSetting.SetContent(m_popupContent);
			m_divaComparisonPopupSetting.SetParent(transform);
			m_divaChangePopupSetting = new DivaChangePopupSetting();
			m_divaChangePopupSetting.TitleText = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_title_02");
			m_divaChangePopupSetting.WindowSize = SizeType.Middle;
			yield return StartCoroutine(m_divaSelectList.LoadDivaIconPanelCoroutine());
			IsReady = true;
		}

		//// RVA: 0x17EE254 Offset: 0x17EE254 VA: 0x17EE254
		private void ReturnScene()
		{
			MenuScene.SaveRequest();
			MenuScene.Instance.Return(true);
		}

		//// RVA: 0x17EE2FC Offset: 0x17EE2FC VA: 0x17EE2FC
		private void Listup(int selectedDivaId)
		{
			m_divaSortIdList.Clear();
			for(int i = 0; i < PlayerData.NBIGLBMHEDC.Count; i++)
			{
				if(PlayerData.NBIGLBMHEDC[i].FJODMPGPDDD)
				{
					if (PlayerData.NBIGLBMHEDC[i].IPJMPBANBPP)
					{
						if(PlayerData.NBIGLBMHEDC[i].AHHJLDLAPAN_DivaId != selectedDivaId)
						{
							m_divaSortIdList.Add(i);
						}
					}
				}
			}
		}

		//// RVA: 0x17EE550 Offset: 0x17EE550 VA: 0x17EE550
		private RemoveDivaState ValidateRemoveDiva()
		{
			FFHPBEPOMAK_DivaInfo f = GetDivaDataBySlotNumber(m_args.slot);
			if(f != null)
			{
				return m_args.slot < 1 ? RemoveDivaState.CenterDiva : RemoveDivaState.Ok;
			}
			return RemoveDivaState.EmptySlot;
		}

		//// RVA: 0x17EE5E8 Offset: 0x17EE5E8 VA: 0x17EE5E8
		private bool TeamSettingDivaButton(int index)
		{
			FFHPBEPOMAK_DivaInfo d = GetDivaDataBySlotNumber(PlayerData.NPFCMHCCDDH, m_args.slot);
			FFHPBEPOMAK_DivaInfo afterDiva = null;
			if (index < 0)
			{
				RemoveDivaState removeState = ValidateRemoveDiva();
				if(removeState != RemoveDivaState.Ok)
				{
					if (removeState != RemoveDivaState.CenterDiva)
						return false;
					PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "popup_title_03", "popup_text_02", SizeType.Middle, new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }), null, null, null, null);
					return true;
				}
				ShowComparisonPopupWindow(d, null, PlayerData.NPFCMHCCDDH, m_args.slot, m_musicData);
			}
			else
			{
				afterDiva = PlayerData.NBIGLBMHEDC[index];
				if (d == null)
				{
					FFHPBEPOMAK_DivaInfo f = PlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
					if(f != null)
					{
						if(afterDiva.AHHJLDLAPAN_DivaId == f.AHHJLDLAPAN_DivaId)
						{
							PopupWindowManager.Show(PopupWindowManager.CreateMessageBankTextContent("menu", "popup_title_02", "popup_text_03", SizeType.Middle, new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }), null, null, null, null);
							return true;
						}
					}
				}
				ShowComparisonPopupWindow(d, afterDiva, PlayerData.NPFCMHCCDDH, m_args.slot, m_musicData);
			}
			return true;
		}

		//// RVA: 0x17EF090 Offset: 0x17EF090 VA: 0x17EF090 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(Args != null)
			{
				m_args = Args as TeamSelectDivaListArgs;
			}
			m_selectedDiva = GetDivaDataBySlotNumber(m_args.slot);
			m_selectedSlot = m_args.slot;
			m_musicData = m_args.viewMusicBaseData;
			m_divaSortExecutor.Initialize(PlayerData);
			m_sortGroupButton.OnListSortEvent.RemoveAllListeners();
			m_sortGroupButton.OnListSortEvent.AddListener(OnSort);
			m_sortGroupButton.SetVisibleLimitOverListButton(false);
			m_divaSelectList.OnRemoveEvent.RemoveAllListeners();
			m_divaSelectList.OnRemoveEvent.AddListener(OnRemove);
			m_divaSelectList.OnSelectDivaEvent.RemoveAllListeners();
			m_divaSelectList.OnSelectDivaEvent.AddListener(OnSelectDiva);
			m_divaSelectList.OnShowDivaStatusEvent.RemoveAllListeners();
			m_divaSelectList.OnShowDivaStatusEvent.AddListener(OnShowDivaStatus);
			m_divaSelectList.OnShowSelectedDivaSceneStatus.RemoveAllListeners();
			m_divaSelectList.OnShowSelectedDivaSceneStatus.AddListener(OnShowSelectedDivaSceneStatus);
			m_sortType = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.ONPAMDMIEKM_divaSortItem;
			m_order = (byte)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HNGHNBNPCHO_divaSortOrder;
			Listup(m_selectedDiva == null ? 0 : m_selectedDiva.AHHJLDLAPAN_DivaId);
			m_divaSortExecutor.Execute(m_divaSortIdList, m_sortType, m_order);
			m_sortGroupButton.UpdateContent(m_sortType, (ListSortButtonGroup.SortOrder)m_order, false, false);
			m_divaSelectList.Initialize();
			m_divaSelectList.UpdateContent(m_selectedDiva, m_divaSortIdList, m_selectedSlot, m_musicData);
			m_divaSelectList.UpdateDecoration(m_selectedDiva, m_divaSortIdList, UnitWindowConstant.SortItemToDisplayType[(int)m_sortType]);
			m_divaSelectList.Wait();
			GameManager.Instance.DivaIconCache.TryInstall(PlayerData);
		}

		// RVA: 0x17EF948 Offset: 0x17EF948 VA: 0x17EF948 Slot: 21
		protected override void OnOpenScene()
		{
			MenuScene.Instance.TryShowPopupWindow(this, PlayerData, m_musicData, false, TransitionName, UpdateContent);
		}

		// RVA: 0x17EFA58 Offset: 0x17EFA58 VA: 0x17EFA58 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_sortGroupButton.Show();
			m_divaSelectList.Show();
		}

		// RVA: 0x17EFAA4 Offset: 0x17EFAA4 VA: 0x17EFAA4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_sortGroupButton.IsPlaying() && !m_divaSelectList.IsPlaying();
		}

		// RVA: 0x17EFB00 Offset: 0x17EFB00 VA: 0x17EFB00 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_sortGroupButton.Hide();
			m_divaSelectList.Hide();
		}

		// RVA: 0x17EFB4C Offset: 0x17EFB4C VA: 0x17EFB4C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_sortGroupButton.IsPlaying() && !m_divaSelectList.IsPlaying();
		}

		//// RVA: 0x17EEBEC Offset: 0x17EEBEC VA: 0x17EEBEC
		private void ShowComparisonPopupWindow(FFHPBEPOMAK_DivaInfo beforeDiva, FFHPBEPOMAK_DivaInfo afterDiva, JLKEOGLJNOD unit, int slot, EEDKAACNBBG musicData)
		{
			PopupSetting set = null;
			if(IsAddDiva(slot))
			{
				m_divaChangePopupSetting.AfterDiva = afterDiva;
				m_divaChangePopupSetting.BeforeDiva = beforeDiva;
				set = m_divaChangePopupSetting;
			}
			else
			{
				m_divaComparisonPopupSetting.AfterDiva = afterDiva;
				m_divaComparisonPopupSetting.BeforeDiva = beforeDiva;
				m_divaComparisonPopupSetting.IsCenterDiva = slot == 0;
				m_divaComparisonPopupSetting.PlayerData = PlayerData;
				m_divaComparisonPopupSetting.MusicData = m_musicData;
				set = m_divaComparisonPopupSetting;
			}
			set.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative},
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive}
			};
			m_isOpenEndConfirmPopup = false;
			PopupWindowManager.Show(set, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1264CAC
				if (type == PopupButton.ButtonType.Negative)
					return;
				ILCCJNDFFOB.HHCJCDFCLOB.KHMDGNKEFOD(JpStringLiterals.StringLiteral_15651, 0, false, false, 1);
				SwapDiva(unit, beforeDiva, afterDiva, slot);
				if(afterDiva != null)
				{
					ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.GNLPMEDLIJJ/*44*/, 2, false);
				}
				unit.HCDGELDHFHB();
				ReturnScene();
			}, null, null, () =>
			{
				//0x1264E5C
				m_isOpenEndConfirmPopup = true;
			});
		}

		//// RVA: 0x17EFC68 Offset: 0x17EFC68 VA: 0x17EFC68
		private void SwapDiva(JLKEOGLJNOD unitData, FFHPBEPOMAK_DivaInfo beforeDiva, FFHPBEPOMAK_DivaInfo afterDiva, int slotNumber)
		{
			for(int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				if(afterDiva != null && unitData.BCJEAJPLGMB_MainDivas[i] != null && unitData.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == afterDiva.AHHJLDLAPAN_DivaId)
				{
					SetDivaDataBySlotNumber(unitData, beforeDiva, i);
					SetDivaDataBySlotNumber(unitData, afterDiva, slotNumber);
					return;
				}
			}
			int found = -1;
			for(int i = 0; i < unitData.CMOPCCAJAAO_AddDivas.Count; i++)
			{
				if (afterDiva != null && unitData.CMOPCCAJAAO_AddDivas[i] != null && unitData.CMOPCCAJAAO_AddDivas[i].AHHJLDLAPAN_DivaId == afterDiva.AHHJLDLAPAN_DivaId)
				{
					found = unitData.BCJEAJPLGMB_MainDivas.Count + i;
					break;
				}
			}
			if(found > -1)
			{
				SetDivaDataBySlotNumber(unitData, beforeDiva, found);
			}
			SetDivaDataBySlotNumber(unitData, afterDiva, slotNumber);
		}

		//// RVA: 0x17F0060 Offset: 0x17F0060 VA: 0x17F0060 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && base.IsEndPreSetCanvas();
		}

		// RVA: 0x17F0118 Offset: 0x17F0118 VA: 0x17F0118 Slot: 23
		protected override void OnActivateScene()
		{
			if(!m_args.isFromBeginner)
			{
				StartCoroutine(Co_ShowHelp());
			}
			else if(!TutorialProc.CanDivaSelect(m_args.beginnerMissionId))
			{
				return;
			}
			StartCoroutine(TutorialProc.Co_DivaSelectList(m_divaSelectList.GetNavigationDivaListButton(), () =>
			{
				//0x17F1110
				return m_isOpenEndConfirmPopup;
			}));
		}

		// RVA: 0x17F02C4 Offset: 0x17F02C4 VA: 0x17F02C4 Slot: 24
		protected override bool IsEndActivateScene()
		{
			return !m_isWaitHelp && base.IsEndActivateScene();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D914 Offset: 0x72D914 VA: 0x72D914
		//// RVA: 0x17F023C Offset: 0x17F023C VA: 0x17F023C
		private IEnumerator Co_ShowHelp()
		{
			TodoLogger.Log(0, "Co_ShowHelp");
			yield return null;
		}

		//// RVA: 0x17F02DC Offset: 0x17F02DC VA: 0x17F02DC Slot: 14
		protected override void OnDestoryScene()
		{
			m_divaSelectList.Release();
		}

		// RVA: 0x17F0304 Offset: 0x17F0304 VA: 0x17F0304 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_popupContent != null)
			{
				Destroy(m_popupContent);
				m_divaComparisonPopupSetting = null;
				m_popupContent = null;
			}
		}

		//// RVA: 0x17F03E0 Offset: 0x17F03E0 VA: 0x17F03E0
		private void OnSort(SortItem item, ListSortButtonGroup.SortOrder order, bool isBonus)
		{
			TodoLogger.Log(0, "OnSort");
		}

		//// RVA: 0x17F0670 Offset: 0x17F0670 VA: 0x17F0670
		private void OnRemove()
		{
			TodoLogger.Log(0, "OnRemove");
		}

		//// RVA: 0x17F077C Offset: 0x17F077C VA: 0x17F077C
		private void OnSelectDiva(int sortListIndex)
		{
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_transitionName == TransitionList.Type.DIVA_SELECT_LIST)
				{
					TeamSettingDivaButton(m_divaSortIdList[sortListIndex]);
				}
				else
				{
					MenuScene.Instance.ShowDivaStatusPopupWindow(PlayerData.NBIGLBMHEDC[sortListIndex], PlayerData, m_musicData, false, TransitionList.Type.UNDEFINED, UpdateContent, true, false, -1, false);
				}
			}
		}

		//// RVA: 0x17F0A14 Offset: 0x17F0A14 VA: 0x17F0A14
		private void OnShowDivaStatus(int sortListIndex)
		{
			TodoLogger.LogNotImplemented("OnShowDivaStatus");
		}

		//// RVA: 0x17F0C8C Offset: 0x17F0C8C VA: 0x17F0C8C
		private void OnShowSelectedDivaSceneStatus(int slot)
		{
			TodoLogger.LogNotImplemented("OnShowSelectedDivaSceneStatus");
		}

		//// RVA: 0x17F0E9C Offset: 0x17F0E9C VA: 0x17F0E9C
		private void UpdateContent()
		{
			m_divaSelectList.UpdateDecoration(m_selectedDiva, m_divaSortIdList, UnitWindowConstant.SortItemToDisplayType[(int)m_sortType]);
		}

		//// RVA: 0x17EFBA8 Offset: 0x17EFBA8 VA: 0x17EFBA8
		private bool IsAddDiva(int slotNumber)
		{
			return PlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count <= slotNumber;
		}

		//// RVA: 0x17EEA80 Offset: 0x17EEA80 VA: 0x17EEA80
		private FFHPBEPOMAK_DivaInfo GetDivaDataBySlotNumber(JLKEOGLJNOD unitData, int slotNumber)
		{
			if (slotNumber < unitData.BCJEAJPLGMB_MainDivas.Count)
			{
				return unitData.BCJEAJPLGMB_MainDivas[slotNumber];
			}
			else
			{
				return unitData.CMOPCCAJAAO_AddDivas[slotNumber - unitData.BCJEAJPLGMB_MainDivas.Count];
			}
		}

		//// RVA: 0x17EE5B4 Offset: 0x17EE5B4 VA: 0x17EE5B4
		private FFHPBEPOMAK_DivaInfo GetDivaDataBySlotNumber(int slotNumber)
		{
			return GetDivaDataBySlotNumber(PlayerData.NPFCMHCCDDH, slotNumber);
		}

		//// RVA: 0x17EFEE0 Offset: 0x17EFEE0 VA: 0x17EFEE0
		private void SetDivaDataBySlotNumber(JLKEOGLJNOD unitData, FFHPBEPOMAK_DivaInfo divaData, int slotNumber)
		{
			if(unitData != null)
			{
				if (slotNumber < unitData.BCJEAJPLGMB_MainDivas.Count)
				{
					unitData.BCJEAJPLGMB_MainDivas[slotNumber] = divaData;
				}
				else
				{
					slotNumber -= unitData.BCJEAJPLGMB_MainDivas.Count;
					unitData.CMOPCCAJAAO_AddDivas[slotNumber] = divaData;
				}
			}
		}

		//// RVA: 0x17F0F90 Offset: 0x17F0F90 VA: 0x17F0F90
		//private bool CheckTutorialCondition(TutorialConditionId conditionId) { }
	}
}
