using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Title
{
	public class LayoutTitleLeftBottomButtons : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonGpgs; // 0x14
		private AbsoluteLayout m_buttonGpgsLayout; // 0x1C

		public Action ButtonCallbackGpgs { get; set; } // 0x18

		// // RVA: 0xE39670 Offset: 0xE39670 VA: 0xE39670
		public void CallbackClear()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE39724 Offset: 0xE39724 VA: 0xE39724
		// public void SetCallback() { }

		// // RVA: 0xE39814 Offset: 0xE39814 VA: 0xE39814
		// public void Reset() { }

		// // RVA: 0xE3667C Offset: 0xE3667C VA: 0xE3667C
		// public void Show() { }

		// // RVA: 0xE39818 Offset: 0xE39818 VA: 0xE39818
		// public void Hide() { }

		// // RVA: 0xE39898 Offset: 0xE39898 VA: 0xE39898 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3980 Offset: 0x6B3980 VA: 0x6B3980
		// // RVA: 0xE399C4 Offset: 0xE399C4 VA: 0xE399C4
		// private void <SetCallback>b__7_0() { }
	}
}
