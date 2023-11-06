using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutQuestTab : LayoutUGUIScriptBase
	{
		public enum eTabType
		{
			Event = 0,
			Normal = 1,
			Daily = 2,
			Diva = 3,
			Beginner = 4,
			Bingo = 5,
		}

		public enum eTabNum
		{
			Beginner = 0,
			Normal = 1,
			Bingo = 2,
		}

		[SerializeField]
		private ActionButton[] m_buttons; // 0x14
		[SerializeField]
		private Text[] m_times; // 0x18
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout[] m_buttonLayouts; // 0x24
		private AbsoluteLayout m_buttonParentLayout; // 0x28
		private AbsoluteLayout m_bgTbl; // 0x2C
		private AbsoluteLayout[] m_badgeParentLayouts; // 0x30
		private GameObject[] m_badgeParentObject; // 0x34
		private BadgeIcon[] m_badgeIcons; // 0x38
		private LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0x3C
		public HGOAIGFPCBC m_badgeData = new HGOAIGFPCBC(); // 0x40

		public Action<eTabType> OnClickTabButton { get; set; } // 0x1C

		//// RVA: 0x187FA60 Offset: 0x187FA60 VA: 0x187FA60
		//public void SetStatus(int defaultTabIndex) { }

		//// RVA: 0x187FAE4 Offset: 0x187FAE4 VA: 0x187FAE4
		//public void SetTime(long remainTime) { }

		//// RVA: 0x187FCF0 Offset: 0x187FCF0 VA: 0x187FCF0
		//private void ApplyRemainTime(long remainSec) { }

		// RVA: 0x187FECC Offset: 0x187FECC VA: 0x187FECC
		private void Update()
		{
			m_timeWatcher.Update();
		}

		// RVA: 0x187FEF8 Offset: 0x187FEF8 VA: 0x187FEF8
		public void Show()
		{
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x187FF84 Offset: 0x187FF84 VA: 0x187FF84
		public void Hide()
		{
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x1880010 Offset: 0x1880010 VA: 0x1880010
		public bool IsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		// RVA: 0x188003C Offset: 0x188003C VA: 0x188003C
		public void InitializeBadge()
		{
			for(int i = 0; i < m_badgeIcons.Length; i++)
			{
				m_badgeIcons[i].Initialize(m_badgeParentObject[i], m_badgeParentLayouts[i]);
				SwitchEmphasisIcon(i, false);
			}
		}

		// RVA: 0x188068C Offset: 0x188068C VA: 0x188068C
		public void ReleaseBadge()
		{
			for(int i = 0; i < m_badgeIcons.Length; i++)
			{
				m_badgeIcons[i].Release();
			}
		}

		//// RVA: 0x187FE20 Offset: 0x187FE20 VA: 0x187FE20
		public void SetTextTimer(string text)
		{
			if (m_times == null)
				return;
			for(int i = 0; i < m_times.Length; i++)
			{
				m_times[i].text = text;
			}
		}

		//// RVA: 0x187FBFC Offset: 0x187FBFC VA: 0x187FBFC
		public void SetTab(int index)
		{
			for(int i = 0; i < m_buttons.Length; i++)
			{
				m_buttonLayouts[i].StartChildrenAnimGoStop(index != i ? "01" : "02");
			}
		}

		// RVA: 0x188014C Offset: 0x188014C VA: 0x188014C
		public void SwitchEmphasisIcon(int index, bool enable)
		{
			m_badgeData.FBANBDCOEJL((LayoutQuestTab.eTabType)index, true);
			Debug.Log(new object[8]
			{
				"tabIndex:", index, " / badgeID:", m_badgeData.BEEIIJJKDBH_BadgeId, " / badgeText:", m_badgeData.BHANMJKCCBC_BadgeText, " / achievedCount:", m_badgeData.PKNLMLDKCLM_AchievedCount
			});
			m_badgeIcons[index].Set(enable ? BadgeConstant.ID.Label : BadgeConstant.ID.None, m_badgeData.BHANMJKCCBC_BadgeText);
		}

		//// RVA: 0x188071C Offset: 0x188071C VA: 0x188071C
		private void OnButtonCallbackTab(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SetChangeBg(index == 4);
			SetTab(index);
			if (OnClickTabButton != null)
				OnClickTabButton((eTabType)index);
		}

		//// RVA: 0x1880888 Offset: 0x1880888 VA: 0x1880888
		public void SetTabType(int index, eTabNum tabNum = eTabNum.Normal)
		{
			if (tabNum == eTabNum.Beginner)
				m_buttonParentLayout.StartChildrenAnimGoStop("01");
			else
			{
				m_buttonParentLayout.StartChildrenAnimGoStop(tabNum == eTabNum.Bingo ? "03" : "02");
				SetTab(index);
			}
			SetChangeBg(index == 4);
		}

		//// RVA: 0x1880800 Offset: 0x1880800 VA: 0x1880800
		public void SetChangeBg(bool isBeginner)
		{
			if (m_bgTbl != null)
				m_bgTbl.StartChildrenAnimGoStop(isBeginner ? "02" : "01", isBeginner ? "02" : "01");
		}

		// RVA: 0x1880980 Offset: 0x1880980 VA: 0x1880980 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("sw_sel_que_window_anim") as AbsoluteLayout;
			m_bgTbl = layout.FindViewById("swtbl_sel_que_wind") as AbsoluteLayout;
			m_buttonLayouts = new AbsoluteLayout[m_buttons.Length];
			m_badgeParentLayouts = new AbsoluteLayout[m_buttons.Length];
			m_badgeParentObject = new GameObject[m_buttons.Length];
			m_badgeIcons = new BadgeIcon[m_buttons.Length];
			LayoutUGUIRuntime r = GetComponentInParent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_buttons.Length; i++)
			{
				m_buttonLayouts[i] = layout.FindViewByExId(string.Format("swtbl_sel_ep_tab_all_swtbl_sel_que_tab_{0:d2}", i + 1)) as AbsoluteLayout;
				m_badgeParentLayouts[i] = m_buttonLayouts[i].FindViewByExId(string.Format("swtbl_sel_que_tab_{0:d2}_badge", i + 1)) as AbsoluteLayout;
				m_badgeParentObject[i] = r.FindRectTransform(m_badgeParentLayouts[i]).gameObject;
				m_badgeIcons[i] = new BadgeIcon();
				int index = i;
				m_buttons[i].AddOnClickCallback(() =>
				{
					//0x18812C8
					OnButtonCallbackTab(index);
				});
			}
			m_buttonParentLayout = m_buttonLayouts[0].Parent as AbsoluteLayout;
			SetTextTimer("");
			Loaded();
			return true;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x7102A4 Offset: 0x7102A4 VA: 0x7102A4
		//// RVA: 0x18812A8 Offset: 0x18812A8 VA: 0x18812A8
		//private void <SetTime>b__18_0(long current, long limit, long remain) { }
	}
}
