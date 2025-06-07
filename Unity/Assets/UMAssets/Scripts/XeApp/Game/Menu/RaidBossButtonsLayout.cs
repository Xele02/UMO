using XeSys.Gfx;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class RaidBossButtonsLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RaidActSelectOptionButton m_rankingButton; // 0x14
		[SerializeField]
		private RaidActSelectOptionButton m_rewardListButton; // 0x18
		[SerializeField]
		private RaidActSelectOptionButton m_missionButton; // 0x1C
		public UnityAction PushRankingButtonListner; // 0x20
		public UnityAction PushRewardListButtonListner; // 0x24
		public UnityAction PushMissionButtonListner; // 0x28
		private bool m_isShow; // 0x2C
		private AbsoluteLayout m_rootLayout; // 0x30

		// RVA: 0x145B1D0 Offset: 0x145B1D0 VA: 0x145B1D0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = true;
			m_rootLayout = layout.FindViewByExId("root_sel_music_raid_boss_btn_sw_sel_music_raid_boss_btn_anim") as AbsoluteLayout;
			m_rankingButton.AddOnClickCallback(OnPushRankingButton);
			m_rewardListButton.AddOnClickCallback(OnPushRewardListButton);
			m_missionButton.AddOnClickCallback(OnPushMissionButton);
			Hide();
			return true;
		}

		// // RVA: 0x145B448 Offset: 0x145B448 VA: 0x145B448
		public void SetMissionBadge(bool isOn)
		{
			m_missionButton.SetBadge(isOn);
		}

		// // RVA: 0x145B478 Offset: 0x145B478 VA: 0x145B478
		public void DisableRankingButton(bool isDisable)
		{
			m_rankingButton.Disable = isDisable;
		}

		// // RVA: 0x145B4AC Offset: 0x145B4AC VA: 0x145B4AC
		private void OnPushRewardListButton()
		{
			if(PushRewardListButtonListner != null)
				PushRewardListButtonListner();
		}

		// // RVA: 0x145B4C0 Offset: 0x145B4C0 VA: 0x145B4C0
		private void OnPushRankingButton()
		{
			if(PushRankingButtonListner != null)
				PushRankingButtonListner();
		}

		// // RVA: 0x145B4D4 Offset: 0x145B4D4 VA: 0x145B4D4
		private void OnPushMissionButton()
		{
			if(PushMissionButtonListner != null)
				PushMissionButtonListner();
		}

		// // RVA: 0x145B4E8 Offset: 0x145B4E8 VA: 0x145B4E8
		// public void Show() { }

		// // RVA: 0x145B3C0 Offset: 0x145B3C0 VA: 0x145B3C0
		public void Hide()
		{
			m_isShow = false;
			m_rootLayout.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x145B570 Offset: 0x145B570 VA: 0x145B570
		public void Enter()
		{
			if(!m_isShow)
			{
				m_rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x145B610 Offset: 0x145B610 VA: 0x145B610
		public void Leave()
		{
			if(m_isShow)
			{
				m_rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x145B6B0 Offset: 0x145B6B0 VA: 0x145B6B0
		public bool IsPlaying()
		{
			return m_rootLayout.IsPlayingChildren();
		}
	}
}
