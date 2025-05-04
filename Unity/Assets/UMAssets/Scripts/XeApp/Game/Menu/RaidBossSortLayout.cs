using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class RaidBossSortLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_sortInfoBtn; // 0x14
		[SerializeField]
		private ActionButton m_sortOrderBtn; // 0x18
		[SerializeField]
		private ActionButton m_updateBtn; // 0x1C
		public UnityAction PushSortInfoButtonListner; // 0x20
		public UnityAction PushSortOrderButtonListner; // 0x24
		public UnityAction PushUpdateButtonListner; // 0x28
		private bool m_isShow; // 0x2C
		private AbsoluteLayout m_bossSortAnim; // 0x30
		private AbsoluteLayout m_bossOrderAnim; // 0x34
		private AbsoluteLayout m_sortTextAnim; // 0x38
		private bool m_enableUpdateButton; // 0x3C
		private float m_elapsedTime; // 0x40
		private const float UpdateButtonRefreshTime = 3;

		// RVA: 0x1BC9F2C Offset: 0x1BC9F2C VA: 0x1BC9F2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = true;
			m_bossSortAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_tr_anim_sw_sel_music_list_btn_set") as AbsoluteLayout;
			m_bossOrderAnim = layout.FindViewByExId("sw_raid_btn_b_01_anim_cmn_btn_orde_set") as AbsoluteLayout;
			m_sortTextAnim = layout.FindViewByExId("sw_raid_btn_b_02_anim_raid_btn_fnt_set_02") as AbsoluteLayout;
			m_sortInfoBtn.AddOnClickCallback(OnPushSortInfoButton);
			m_sortOrderBtn.AddOnClickCallback(OnPushSortOrderButton);
			m_updateBtn.AddOnClickCallback(OnPushUpdateButton);
			m_elapsedTime = 0;
			m_enableUpdateButton = true;
			return true;
		}

		// RVA: 0x1BCA214 Offset: 0x1BCA214 VA: 0x1BCA214
		private void Update()
		{
			if(m_enableUpdateButton)
			{
				m_elapsedTime += Time.deltaTime;
				if(m_elapsedTime >= 3)
				{
					m_updateBtn.Disable = false;
				}
			}
		}

		// // RVA: 0x1BCA28C Offset: 0x1BCA28C VA: 0x1BCA28C
		public void DisableSortButtons(bool isDisable)
		{
			m_sortInfoBtn.Disable = isDisable;
			m_sortOrderBtn.Disable = isDisable;
		}

		// // RVA: 0x1BCA2E8 Offset: 0x1BCA2E8 VA: 0x1BCA2E8
		public void DisableUpdateButton(bool isDisable)
		{
			m_enableUpdateButton = !isDisable;
			m_updateBtn.Disable = isDisable;
		}

		// RVA: 0x1BCA324 Offset: 0x1BCA324 VA: 0x1BCA324
		public void UpdateSortText()
		{
			switch(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.LHPDCGNKPHD_sortItem)
			{
				case 0:
					m_sortTextAnim.StartChildrenAnimGoStop("01", "01");
					break;
				case 1:
					m_sortTextAnim.StartChildrenAnimGoStop("02", "02");
					break;
				case 2:
					m_sortTextAnim.StartChildrenAnimGoStop("03", "03");
					break;
				case 3:
					m_sortTextAnim.StartChildrenAnimGoStop("04", "04");
					break;
				case 4:
					m_sortTextAnim.StartChildrenAnimGoStop("05", "05");
					break;
				default:
					break;
			}
		}

		// // RVA: 0x1BCA514 Offset: 0x1BCA514 VA: 0x1BCA514
		public void UpdateOrderText()
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JGAFBCMOGLP_Raid.EILKGEADKGH_order == 0)
				m_bossOrderAnim.StartChildrenAnimGoStop("01", "01");
			else
				m_bossOrderAnim.StartChildrenAnimGoStop("02", "02");
		}

		// // RVA: 0x1BCA660 Offset: 0x1BCA660 VA: 0x1BCA660
		private void OnPushSortInfoButton()
		{
			if(PushSortInfoButtonListner != null)
				PushSortInfoButtonListner();
		}

		// // RVA: 0x1BCA674 Offset: 0x1BCA674 VA: 0x1BCA674
		private void OnPushSortOrderButton()
		{
			if(PushSortOrderButtonListner != null)
				PushSortOrderButtonListner();
		}

		// // RVA: 0x1BCA688 Offset: 0x1BCA688 VA: 0x1BCA688
		private void OnPushUpdateButton()
		{
			m_updateBtn.Disable = true;
			m_elapsedTime = 0;
			if(PushUpdateButtonListner != null)
				PushUpdateButtonListner();
		}

		// // RVA: 0x1BCA6D8 Offset: 0x1BCA6D8 VA: 0x1BCA6D8
		public void RefreshUpdateButton()
		{
			m_updateBtn.Disable = false;
		}

		// // RVA: 0x1BCA708 Offset: 0x1BCA708 VA: 0x1BCA708
		// public void Show() { }

		// // RVA: 0x1BCA790 Offset: 0x1BCA790 VA: 0x1BCA790
		public void Hide()
		{
			m_isShow = false;
			m_bossSortAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1BCA818 Offset: 0x1BCA818 VA: 0x1BCA818
		public void Enter()
		{
			if(!m_isShow)
			{
				m_bossSortAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x1BCA8B8 Offset: 0x1BCA8B8 VA: 0x1BCA8B8
		public void Leave()
		{
			if(m_isShow)
			{
				m_bossSortAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x1BCA958 Offset: 0x1BCA958 VA: 0x1BCA958
		public bool IsPlaying()
		{
			return m_bossSortAnim.IsPlayingSibling();
		}
	}
}
