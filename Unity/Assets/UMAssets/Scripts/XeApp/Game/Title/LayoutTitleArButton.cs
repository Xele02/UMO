using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Title
{
	public class LayoutTitleArButton : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_Anim; // 0x14
		[SerializeField]
		private ActionButton m_Btn; // 0x18
		private Action m_OnClickArCallback; // 0x1C
		private bool isEnter; // 0x20

		public Action OnClickArButton { set { m_OnClickArCallback = value; } } //0xE354E0

		// RVA: 0xE354E8 Offset: 0xE354E8 VA: 0xE354E8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_ar_btn_inout_anim") as AbsoluteLayout;
			m_Btn.AddOnClickCallback(() =>
			{
				//0xE35800
				if (m_OnClickArCallback != null)
					m_OnClickArCallback();
			});
			Loaded();
			return true;
		}

		//// RVA: 0xE3561C Offset: 0xE3561C VA: 0xE3561C
		public void Show()
		{
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			isEnter = true;
		}

		//// RVA: 0xE356B0 Offset: 0xE356B0 VA: 0xE356B0
		//public void Leave() { }

		//// RVA: 0xE35750 Offset: 0xE35750 VA: 0xE35750
		//public bool IsPlaying() { }

		//// RVA: 0xE3577C Offset: 0xE3577C VA: 0xE3577C
		//public void Skip() { }
	}
}
