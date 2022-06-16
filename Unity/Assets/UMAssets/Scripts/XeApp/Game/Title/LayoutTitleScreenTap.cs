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
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE3AF1C Offset: 0xE3AF1C VA: 0xE3AF1C
		public void ClearCallback()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE3AFD0 Offset: 0xE3AFD0 VA: 0xE3AFD0 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3BA0 Offset: 0x6B3BA0 VA: 0x6B3BA0
		// // RVA: 0xE3AFF0 Offset: 0xE3AFF0 VA: 0xE3AFF0
		// private void <SetCallback>b__5_0() { }
	}
}
