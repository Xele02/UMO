using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationVisitButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_btn_layout_root"; // 0x0
		[SerializeField]
		private ActionButton m_sortButton; // 0x14
		[SerializeField]
		private ActionButton m_sortOrderButton; // 0x18
		[SerializeField]
		private ActionButton m_memberReloadButton; // 0x1C
		[SerializeField]
		private RawImageEx m_sortImage; // 0x20
		public Action ClickSortButtonCallback; // 0x24
		public Action ClickSortOrderButtonCallback; // 0x28
		public Action ClickMemberReloadButtonCallback; // 0x2C
		private AbsoluteLayout m_base; // 0x30
		private TexUVListManager m_uvManager; // 0x34
		private AbsoluteLayout m_sortOrder; // 0x38
		private bool IsEnter; // 0x3C

		// RVA: 0x18BD40C Offset: 0x18BD40C VA: 0x18BD40C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_deco_sort_all_anim") as AbsoluteLayout;
			m_sortOrder = layout.FindViewById("swtbl_cmn_orde_fnt") as AbsoluteLayout;
			m_sortButton.AddOnClickCallback(() =>
			{
				//0x18BDAB8
				ClickSortButtonCallback();
			});
			m_sortOrderButton.AddOnClickCallback(() =>
			{
				//0x18BDAE4
				ClickSortOrderButtonCallback();
			});
			m_memberReloadButton.AddOnClickCallback(() =>
			{
				//0x18BDB10
				ClickMemberReloadButtonCallback();
			});
			m_uvManager = uvMan;
			UpdateSortImage(SortItem.LastPlayDate);
			return true;
		}

		// RVA: 0x18BD7A0 Offset: 0x18BD7A0 VA: 0x18BD7A0
		public void Enter()
		{
			if (IsEnter)
				return;
			IsEnter = true;
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x18BD840 Offset: 0x18BD840 VA: 0x18BD840
		public void Leave()
		{
			if (!IsEnter)
				return;
			IsEnter = false;
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x18BD8E0 Offset: 0x18BD8E0 VA: 0x18BD8E0
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18BD960 Offset: 0x18BD960 VA: 0x18BD960
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlaying();
		}

		//// RVA: 0x18BD678 Offset: 0x18BD678 VA: 0x18BD678
		public void UpdateSortImage(SortItem sortItem)
		{
			m_sortImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(SortMenuWindow.GetSortLabelUv(sortItem)));
		}

		// RVA: 0x18BD990 Offset: 0x18BD990 VA: 0x18BD990
		public void UpdateSortOrder(bool isDesc)
		{
			m_sortOrder.StartChildrenAnimGoStop(!isDesc ? 1 : 0, isDesc ? 1 : 0);
		}

		// RVA: 0x18BD9DC Offset: 0x18BD9DC VA: 0x18BD9DC
		public void SetReloadButtonLock(bool isLock)
		{
			m_memberReloadButton.Disable = isLock;
		}

		//// RVA: 0x18BDA10 Offset: 0x18BDA10 VA: 0x18BDA10
		//public bool GetReloadButtonLock() { }
	}
}
