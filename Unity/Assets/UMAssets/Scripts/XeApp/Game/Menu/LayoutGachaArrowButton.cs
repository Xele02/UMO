using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutGachaArrowButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ButtonBase m_button; // 0x14

		public Action OnClickButton { private get; set; } // 0x18

		// RVA: 0x1996CB0 Offset: 0x1996CB0 VA: 0x1996CB0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_button.AddOnClickCallback(() =>
			{
				//0x1996DA4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}

		// RVA: 0x1996D68 Offset: 0x1996D68 VA: 0x1996D68
		public void SetActive(bool active)
		{
			m_button.Hidden = !active;
		}
	}
}
