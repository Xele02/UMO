using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class SceneGrowthPassButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		private AbsoluteLayout m_layout; // 0x18
		public Action OnClickButton; // 0x1C

		// RVA: 0x10DD078 Offset: 0x10DD078 VA: 0x10DD078 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewById("sw_ab_btn_pass_inout_anim") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x10DD1B4
				if (OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}

		//// RVA: 0x10DBF38 Offset: 0x10DBF38 VA: 0x10DBF38
		public void Show()
		{
			m_layout.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x10DC10C Offset: 0x10DC10C VA: 0x10DC10C
		public void Hide()
		{
			m_layout.StartChildrenAnimGoStop("st_wait");
		}
	}
}
