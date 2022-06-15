using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Title
{
	public class LayoutTitleButtons : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_Inheriting; // 0x14
		[SerializeField]
		private ActionButton m_Support; // 0x18
		private AbsoluteLayout m_root; // 0x24
		private AbsoluteLayout[] m_buttonTbl = new AbsoluteLayout[2]; // 0x28

		public Action ButtonCallbackInheriting { get; set; } // 0x1C
		public Action ButtonCallbackSupport { get; set; } // 0x20

		// // RVA: 0xE35834 Offset: 0xE35834 VA: 0xE35834
		// public void SwitchButtonLabel(LayoutTitleButtons.eButtonType type) { }

		// // RVA: 0xE35950 Offset: 0xE35950 VA: 0xE35950
		public void CallbackClear()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE359A0 Offset: 0xE359A0 VA: 0xE359A0
		// public void SetCallback() { }

		// // RVA: 0xE35B70 Offset: 0xE35B70 VA: 0xE35B70
		// public void Reset() { }

		// // RVA: 0xE35B74 Offset: 0xE35B74 VA: 0xE35B74
		// public void Show() { }

		// // RVA: 0xE35BF4 Offset: 0xE35BF4 VA: 0xE35BF4
		// public void Hide() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B2EF8 Offset: 0x6B2EF8 VA: 0x6B2EF8
		// // RVA: 0xE35C74 Offset: 0xE35C74 VA: 0xE35C74
		// private IEnumerator InheritingDark() { }

		// // RVA: 0xE35D20 Offset: 0xE35D20 VA: 0xE35D20 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B2F70 Offset: 0x6B2F70 VA: 0x6B2F70
		// // RVA: 0xE3612C Offset: 0xE3612C VA: 0xE3612C
		// private void <SetCallback>b__15_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B2F80 Offset: 0x6B2F80 VA: 0x6B2F80
		// // RVA: 0xE36198 Offset: 0xE36198 VA: 0xE36198
		// private void <SetCallback>b__15_1() { }
	}
}
