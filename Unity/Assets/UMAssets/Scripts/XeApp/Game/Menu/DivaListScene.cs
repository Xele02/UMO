using mcrs;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaListScene : TransitionRoot
	{
		[SerializeField]
		private ListSortButtonGroup m_listSortButton; // 0x48
		[SerializeField]
		private DivaList m_divaList; // 0x4C
		private DivaSortExecutor m_divaSortExecutor = new DivaSortExecutor(); // 0x50
		private SortItem m_sortItem; // 0x54
		private byte m_sortOrder = (byte)ListSortButtonGroup.DefaultSortOrder; // 0x58
		private List<int> m_divaIndexList = new List<int>(); // 0x5C

		private DFKGGBMFFGB_PlayerInfo PlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x17E6B24

		// RVA: 0x17E6BC0 Offset: 0x17E6BC0 VA: 0x17E6BC0
		private void Awake()
		{
			m_listSortButton.OnListSortEvent.AddListener(OnSort);
			m_divaList.OnPushIconEvent.AddListener(OnShowDivaStatus);
			m_divaList.OnStayIconEvent.AddListener(OnShowDivaStatus);
			IsReady = true;
		}

		// RVA: 0x17E6DC0 Offset: 0x17E6DC0 VA: 0x17E6DC0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_divaSortExecutor.Initialize(PlayerData);
			m_divaIndexList.Clear();
			for(int i = 0; i < PlayerData.NBIGLBMHEDC_Divas.Count; i++)
			{
				if(PlayerData.NBIGLBMHEDC_Divas[i].FJODMPGPDDD)
				{
					if(PlayerData.NBIGLBMHEDC_Divas[i].IPJMPBANBPP_Enabled)
					{
						m_divaIndexList.Add(i);
					}
				}
			}
			m_sortItem = (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.ONPAMDMIEKM_divaSortItem;
			m_sortOrder = (byte)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HNGHNBNPCHO_divaSortOrder;
			m_divaSortExecutor.Execute(m_divaIndexList, m_sortItem, m_sortOrder);
			m_listSortButton.SetVisibleLimitOverListButton(false);
			m_listSortButton.UpdateContent(m_sortItem, (ListSortButtonGroup.SortOrder)m_sortOrder, false, false);
			m_divaList.InitializeDecoration();
			m_divaList.UpdateContent(PlayerData, m_divaIndexList);
			m_divaList.ChangeIcon(PlayerData, m_divaIndexList, UnitWindowConstant.SortItemToDisplayType[(int)m_sortItem]);
		}

		// RVA: 0x17E7270 Offset: 0x17E7270 VA: 0x17E7270 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && base.IsEndPreSetCanvas();
		}

		// RVA: 0x17E7328 Offset: 0x17E7328 VA: 0x17E7328 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_divaList.Show();
			m_listSortButton.Show();
		}

		// RVA: 0x17E7374 Offset: 0x17E7374 VA: 0x17E7374 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_divaList.IsPlaying();
		}

		// RVA: 0x17E73A0 Offset: 0x17E73A0 VA: 0x17E73A0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_divaList.Hide();
			m_listSortButton.Hide();
		}

		// RVA: 0x17E73EC Offset: 0x17E73EC VA: 0x17E73EC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_divaList.IsPlaying();
		}

		// RVA: 0x17E7418 Offset: 0x17E7418 VA: 0x17E7418 Slot: 14
		protected override void OnDestoryScene()
		{
			m_divaList.ReleaseDecoration();
		}

		//// RVA: 0x17E7440 Offset: 0x17E7440 VA: 0x17E7440
		private void OnSort(SortItem item, ListSortButtonGroup.SortOrder order, bool isBonus)
		{
			m_divaSortExecutor.Execute(m_divaIndexList, item, (byte)order);
			m_divaList.UpdateContent(PlayerData, m_divaIndexList);
			m_divaList.ChangeIcon(PlayerData, m_divaIndexList, UnitWindowConstant.SortItemToDisplayType[(int)item]);
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.ONPAMDMIEKM_divaSortItem = (int)item;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HNGHNBNPCHO_divaSortOrder = (byte)order;
			m_sortItem = item;
		}

		//// RVA: 0x17E76C8 Offset: 0x17E76C8 VA: 0x17E76C8
		private void OnShowDivaStatus(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowDivaStatusPopupWindow(PlayerData.NBIGLBMHEDC_Divas[m_divaIndexList[index]], PlayerData, null, false, TransitionName, UpdateContent, true, false, -1, false);
		}

		// RVA: 0x17E78C4 Offset: 0x17E78C4 VA: 0x17E78C4 Slot: 21
		protected override void OnOpenScene()
		{
			MenuScene.Instance.TryShowPopupWindow(this, PlayerData, null, true, TransitionName, UpdateContent);
		}

		//// RVA: 0x17E79D8 Offset: 0x17E79D8 VA: 0x17E79D8
		private void UpdateContent()
		{
			m_divaList.ChangeIcon(PlayerData, m_divaIndexList, UnitWindowConstant.SortItemToDisplayType[(int)m_sortItem]);
		}
	}
}
