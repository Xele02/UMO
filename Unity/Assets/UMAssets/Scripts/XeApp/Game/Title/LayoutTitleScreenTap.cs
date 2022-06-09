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
		// [CompilerGeneratedAttribute] // RVA: 0x665624 Offset: 0x665624 VA: 0x665624
		// private Action <ButtonCallbackTap>k__BackingField; // 0x18

		public Action ButtonCallbackTap { get; set; }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3B80 Offset: 0x6B3B80 VA: 0x6B3B80
		// // RVA: 0xE3ADFC Offset: 0xE3ADFC VA: 0xE3ADFC
		// public Action get_ButtonCallbackTap() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3B90 Offset: 0x6B3B90 VA: 0x6B3B90
		// // RVA: 0xE3AE04 Offset: 0xE3AE04 VA: 0xE3AE04
		// public void set_ButtonCallbackTap(Action value) { }

		// // RVA: 0xE3AE0C Offset: 0xE3AE0C VA: 0xE3AE0C
		// public void SetCallback() { }

		// // RVA: 0xE3AF1C Offset: 0xE3AF1C VA: 0xE3AF1C
		public void ClearCallback()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE3AFD0 Offset: 0xE3AFD0 VA: 0xE3AFD0 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// // RVA: 0xE3AFE8 Offset: 0xE3AFE8 VA: 0xE3AFE8
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3BA0 Offset: 0x6B3BA0 VA: 0x6B3BA0
		// // RVA: 0xE3AFF0 Offset: 0xE3AFF0 VA: 0xE3AFF0
		// private void <SetCallback>b__5_0() { }
	}
}
