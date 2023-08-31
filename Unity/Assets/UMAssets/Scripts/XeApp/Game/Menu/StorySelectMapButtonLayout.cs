using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class StorySelectMapButtonLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		private AbsoluteLayout m_root; // 0x1C

		// Properties
		public Action CallbackButton { get; set; } // 0x18

		//// RVA: 0x12E4F08 Offset: 0x12E4F08 VA: 0x12E4F08
		//public void SetStatus() { }

		// RVA: 0x12E4F0C Offset: 0x12E4F0C VA: 0x12E4F0C
		public void Reset()
		{
			return;
		}

		//// RVA: 0x12E4F10 Offset: 0x12E4F10 VA: 0x12E4F10
		//public void In() { }

		//// RVA: 0x12E4F90 Offset: 0x12E4F90 VA: 0x12E4F90
		//public void Out() { }

		//// RVA: 0x12E5010 Offset: 0x12E5010 VA: 0x12E5010
		public void Hide()
		{
			if (m_root != null)
				m_root.StartChildrenAnimGoStop("st_non");
		}

		// RVA: 0x12E5080 Offset: 0x12E5080 VA: 0x12E5080 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			if(m_button != null)
			{
				m_button.ClearOnClickCallback();
				m_button.AddOnClickCallback(() =>
				{
					//0x12E5238
					if (CallbackButton != null)
						CallbackButton();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			Loaded();
			return true;
		}
	}
}
