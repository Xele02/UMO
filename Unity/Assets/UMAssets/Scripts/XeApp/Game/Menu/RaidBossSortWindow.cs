using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class RaidBossSortWindow : LayoutUGUIScriptBase
	{
		public enum FilterType
		{
			Boss = 0,
			Rank = 1,
			Join = 2,
		}
 
		public enum SortOption
		{
			Rank = 0,
			HpRatio = 1,
			HpAmount = 2,
			Time = 3,
			Join = 4,
		}
 
		public enum FilOptBoss
		{
			All = 0,
			Normal = 2,
			Sp = 4,
		}

		public enum FilOptRank
		{
			All = 0,
			SSS = 2,
			SS = 4,
			S = 8,
			A = 16,
			B = 32,
			C = 64,
			D = 128,
		}

		public enum FilOptJoin
		{
			All = 0,
			Joining = 2,
			NotJoin = 4,
		}

		[Serializable]
		public class SortButtonEvent : UnityEvent<int>
		{
			//
		}

		[Serializable]
		public class FilterButtonEvent : UnityEvent<uint>
		{
			//
		}

		[SerializeField]
		private ActionButton m_resetButton; // 0x14
		[SerializeField]
		private ToggleButtonGroup m_toggleBtnGroup; // 0x18
		[SerializeField]
		private ToggleButton[] m_sortToggles; // 0x1C
		[SerializeField]
		private ToggleButton[] m_bossToggles; // 0x20
		[SerializeField]
		private ToggleButton[] m_rankToggles; // 0x24
		[SerializeField]
		private ToggleButton[] m_joinToggles; // 0x28
		private bool m_IsInialize; // 0x2C
		private Action<RaidBossHelpWindow.SelectType> onSelectType; // 0x30
		private int m_currentFilOptBoss; // 0x34
		private int m_currentFilOptRank; // 0x38
		private int m_currentFilOptJoin; // 0x3C
		private int m_sortType; // 0x40
		private uint m_bossButtonStateBit; // 0x44
		private uint m_rankButtonStateBit; // 0x48
		private uint m_joinButtonStateBit; // 0x4C

		// RVA: 0x1BCA98C Offset: 0x1BCA98C VA: 0x1BCA98C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			AbsoluteLayout l = (layout.FindViewByExId("raid_sort_set_sw_sort_btn_01_anim_02") as AbsoluteLayout).FindViewByExId("sw_sort_btn_02_anim_sort_fnt_set") as AbsoluteLayout;
			AbsoluteLayout l2 = (layout.FindViewByExId("raid_sort_set_sw_sort_btn_01_anim_03") as AbsoluteLayout).FindViewByExId("sw_sort_btn_02_anim_sort_fnt_set") as AbsoluteLayout;
			AbsoluteLayout l3 = (layout.FindViewByExId("raid_sort_set_sw_sort_btn_01_anim_04") as AbsoluteLayout).FindViewByExId("sw_sort_btn_02_anim_sort_fnt_set") as AbsoluteLayout;
			AbsoluteLayout l4 = (layout.FindViewByExId("raid_sort_set_sw_sort_btn_01_anim_05") as AbsoluteLayout).FindViewByExId("sw_sort_btn_02_anim_sort_fnt_set") as AbsoluteLayout;
			l.StartChildrenAnimGoStop("01", "01");
			l2.StartChildrenAnimGoStop("02", "02");
			l3.StartChildrenAnimGoStop("03", "03");
			l4.StartChildrenAnimGoStop("04", "04");
			return true;
		}

		// // RVA: 0x1BCB1EC Offset: 0x1BCB1EC VA: 0x1BCB1EC
		private void InitButtons(ToggleButton[] buttons)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetOff();
			}
		}

		// // RVA: 0x1BCB268 Offset: 0x1BCB268 VA: 0x1BCB268
		public void SetDefault(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty sortProperty)
		{
			m_sortType = sortProperty.JGAFBCMOGLP_Raid.LHPDCGNKPHD_sortItem;
			m_bossButtonStateBit = (uint)sortProperty.JGAFBCMOGLP_Raid.AOKFAJOMCKK_bossFilter;
			m_rankButtonStateBit = (uint)sortProperty.JGAFBCMOGLP_Raid.MOAJJHLGILP_rankFilter;
			m_joinButtonStateBit = (uint)sortProperty.JGAFBCMOGLP_Raid.COIKKDHMGID_joinFilter;
			m_toggleBtnGroup.SelectGroupButton(m_sortType);
			SetFilterButton(FilterType.Boss, m_bossButtonStateBit);
			SetFilterButton(FilterType.Rank, m_rankButtonStateBit);
			SetFilterButton(FilterType.Join, m_joinButtonStateBit);
		}

		// RVA: 0x1BCB490 Offset: 0x1BCB490 VA: 0x1BCB490
		public void Initialize()
		{
			Vector3 s = (transform as RectTransform).sizeDelta;
			transform.GetComponent<RectTransform>().sizeDelta = new Vector3(s.x, 650);
			InitButtons(m_sortToggles);
			InitButtons(m_bossToggles);
			InitButtons(m_rankToggles);
			InitButtons(m_joinToggles);
			m_toggleBtnGroup.SelectGroupButton(0);
			m_toggleBtnGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_toggleBtnGroup.OnSelectToggleButtonEvent.AddListener(OnSelectToggleButton);
			m_resetButton.ClearOnClickCallback();
			m_resetButton.AddOnClickCallback(OnFilterReset);
			SetFilterButtonEvent(m_bossToggles, OnChangeBossFilter);
			SetFilterButtonEvent(m_rankToggles, OnChangeRankFilter);
			SetFilterButtonEvent(m_joinToggles, OnChangeJoinFilter);
			SetDefault(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty);
			m_IsInialize = true;
		}

		// // RVA: 0x1BCBBB4 Offset: 0x1BCBBB4 VA: 0x1BCBBB4
		public void OnSelectToggleButton(int value)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_sortType = value;
		}

		// // RVA: 0x1BCBC18 Offset: 0x1BCBC18 VA: 0x1BCBC18
		private void OnFilterReset()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			PushFilterButton(0, m_bossToggles);
			PushFilterButton(0, m_rankToggles);
			PushFilterButton(0, m_joinToggles);
			m_bossButtonStateBit = 0;
			m_rankButtonStateBit = 0;
			m_joinButtonStateBit = 0;
		}

		// // RVA: 0x1BCBCC0 Offset: 0x1BCBCC0 VA: 0x1BCBCC0
		private void PushFilterButton(int index, ToggleButton[] buttons)
		{
			if(index == 0)
			{
				buttons[0].SetOn();
				for(int i = 1; i < buttons.Length; i++)
				{
					buttons[i].SetOff();
				}
			}
			else 
			{
				bool notSet = true;
				for(int i = 1; i < buttons.Length; i++)
				{
					if(buttons[i].IsOn)
					{
						notSet = false;
						break;
					}
				}
				if(notSet)
					buttons[0].SetOn();
				else
					buttons[0].SetOff();
			}
		}

		// // RVA: 0x1BCB928 Offset: 0x1BCB928 VA: 0x1BCB928
		private void SetFilterButtonEvent(ToggleButton[] buttons, Action<uint> buttonEvent)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				int index = i;
				buttons[i].ClearOnClickCallback();
				buttons[i].AddOnClickCallback(() =>
				{
					//0x1BCBFE4
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					PushFilterButton(index, buttons);
					buttonEvent(GetFilterButtonBit(buttons));
				});
			}
		}

		// // RVA: 0x1BCBE78 Offset: 0x1BCBE78 VA: 0x1BCBE78
		private uint GetFilterButtonBit(ToggleButton[] buttons)
		{
			uint res = 0;
			for(int i = 1; i < buttons.Length; i++)
			{
				if(buttons[i].IsOn)
					res |= (uint)(1 << i);
			}
			return res;
		}

		// // RVA: 0x1BCBF04 Offset: 0x1BCBF04 VA: 0x1BCBF04
		// private void OnChangeSort(int index) { }

		// // RVA: 0x1BCBCA8 Offset: 0x1BCBCA8 VA: 0x1BCBCA8
		private void OnChangeBossFilter(uint bit)
		{
			m_bossButtonStateBit = bit;
		}

		// // RVA: 0x1BCBCB0 Offset: 0x1BCBCB0 VA: 0x1BCBCB0
		private void OnChangeRankFilter(uint bit)
		{
			m_rankButtonStateBit = bit;
		}

		// // RVA: 0x1BCBCB8 Offset: 0x1BCBCB8 VA: 0x1BCBCB8
		private void OnChangeJoinFilter(uint bit)
		{
			m_joinButtonStateBit = bit;
		}

		// // RVA: 0x1BCB354 Offset: 0x1BCB354 VA: 0x1BCB354
		public void SetFilterButton(FilterType type, uint bit)
		{
			ToggleButton[] btns = null;
			if(type == FilterType.Join)
				btns = m_joinToggles;
			else if(type == FilterType.Rank)
				btns = m_rankToggles;
			else if(type == FilterType.Boss)
				btns = m_bossToggles;
			if(bit == 0)
				PushFilterButton(0, btns);
			else
			{
				btns[0].SetOff();
				for(int i = 1; i < btns.Length; i++)
				{
					if((bit & (uint)(1 << i)) != 0)
						btns[i].SetOn();
					else 
						btns[i].SetOff();
				}
			}
		}

		// // RVA: 0x1BCBF08 Offset: 0x1BCBF08 VA: 0x1BCBF08
		public void ApplyLocalSaveData(ref ILDKBCLAFPB.IJDOCJCLAIL_SortProprty localSaveData)
		{
			localSaveData.JGAFBCMOGLP_Raid.LHPDCGNKPHD_sortItem = m_sortType;
			localSaveData.JGAFBCMOGLP_Raid.AOKFAJOMCKK_bossFilter = (int)m_bossButtonStateBit;
			localSaveData.JGAFBCMOGLP_Raid.MOAJJHLGILP_rankFilter = (int)m_rankButtonStateBit;
			localSaveData.JGAFBCMOGLP_Raid.COIKKDHMGID_joinFilter = (int)m_joinButtonStateBit;
		}
	}
}
