using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SceneGrowthUnlockButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonSta; // 0x14
		[SerializeField]
		private ActionButton m_buttonEpi; // 0x18
		[SerializeField]
		private ActionButton m_buttonAll; // 0x1C
		private AbsoluteLayout m_layoutInOut; // 0x20
		private bool m_isShow; // 0x24

		public Action OnClickStaButton { get; set; } // 0x28
		public Action OnClickEpiButton { get; set; } // 0x2C
		public Action OnClickAllButton { get; set; } // 0x30

		// RVA: 0x1368BC0 Offset: 0x1368BC0 VA: 0x1368BC0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutInOut = layout.FindViewById("sw_ad_btn_free_inout_anim") as AbsoluteLayout;
			m_buttonSta.AddOnClickCallback(() =>
			{
				//0x1369580
				if (OnClickStaButton != null)
					OnClickStaButton();
			});
			m_buttonEpi.AddOnClickCallback(() =>
			{
				//0x1369594
				if (OnClickEpiButton != null)
					OnClickEpiButton();
			});
			m_buttonAll.AddOnClickCallback(() =>
			{
				//0x13695A8
				if (OnClickAllButton != null)
					OnClickAllButton();
			});
			((GetComponentInParent<LayoutUGUIRuntime>().FindViewBase(m_buttonSta.transform as RectTransform) as AbsoluteLayout).FindViewById("swtbl_ab_free_fnt") as AbsoluteLayout).StartChildrenAnimGoStop("03");
			((GetComponentInParent<LayoutUGUIRuntime>().FindViewBase(m_buttonAll.transform as RectTransform) as AbsoluteLayout).FindViewById("swtbl_ab_free_fnt") as AbsoluteLayout).StartChildrenAnimGoStop("02");
			Loaded();
			return true;
		}

		//// RVA: 0x1369188 Offset: 0x1369188 VA: 0x1369188
		public void Show()
		{
			if (m_isShow)
				return;
			m_isShow = true;
			m_layoutInOut.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x1369228 Offset: 0x1369228 VA: 0x1369228
		public void Hide()
		{
			if (!m_isShow)
				return;
			m_isShow = false;
			m_layoutInOut.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x13692C8 Offset: 0x13692C8 VA: 0x13692C8
		public void UpdateLayout(SceneGrowthBoard board)
		{
			m_buttonSta.Disable = true;
			m_buttonEpi.Disable = true;
			m_buttonAll.Disable = true;
			if (board != null)
			{
				SceneGrowthMainBoard b = board as SceneGrowthMainBoard;
				if(b != null)
				{
					List<byte> l1 = new List<byte>();
					List<byte> l2 = new List<byte>();
					List<byte> l3 = new List<byte>();
					List<byte> l4 = new List<byte>();
					b.UnlockStatusPanelListup(l1, l4);
					b.UnlockEpisodePanelListup(l2, l4);
					b.UnlockAllPanelListup(l3, l4);
					m_buttonSta.Disable = l1.Count < 1;
					m_buttonEpi.Disable = l2.Count < 1;
					m_buttonAll.Disable = l3.Count < 1;
				}
			}

		}
	}
}
