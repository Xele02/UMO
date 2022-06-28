using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Title
{
	public class LayoutTitleScreenTap : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_Tap; // 0x14

		public Action ButtonCallbackTap { get; set; } // 0x18

		// // RVA: 0xE3AE0C Offset: 0xE3AE0C VA: 0xE3AE0C
		public void SetCallback()
		{
			if(m_Tap == null)
				return;

			m_Tap.ClearOnClickCallback();
			m_Tap.AddOnClickCallback(() => {
				//0xE3AFF0
				UnityEngine.Debug.LogError("ScreenTap CB");
				if(ButtonCallbackTap != null)
					ButtonCallbackTap();
			});
		}

		// // RVA: 0xE3AF1C Offset: 0xE3AF1C VA: 0xE3AF1C
		public void ClearCallback()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutTitleScreenTap ClearCallback");
		}

		// // RVA: 0xE3AFD0 Offset: 0xE3AFD0 VA: 0xE3AFD0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO");
			return true;
		}
	}
}
