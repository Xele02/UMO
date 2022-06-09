using XeSys.Gfx;
using System.Collections;
using System;
using UnityEngine;

namespace XeApp.Game.Title
{
	public class LayoutTitleLogo : LayoutUGUIScriptBase
	{
		private const float FADE_TIME = 0.3f;
		private AbsoluteLayout m_logoTbl; // 0x14
		private AbsoluteLayout m_root; // 0x18
		private int[] m_logoIndexArray; // 0x1C
		private float[] m_skipWaitArray; // 0x20
		private float[] m_waitArray; // 0x24
		private int m_visibleIndex; // 0x28
		private Coroutine m_logoCoroutine; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x6655E4 Offset: 0x6655E4 VA: 0x6655E4
		// private bool <IsOpen>k__BackingField; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x6655F4 Offset: 0x6655F4 VA: 0x6655F4
		// private bool <IsClose>k__BackingField; // 0x31
		// [CompilerGeneratedAttribute] // RVA: 0x665604 Offset: 0x665604 VA: 0x665604
		// private bool <IsSkip>k__BackingField; // 0x32

		public bool IsOpen { get; set; }
		public bool IsClose { get; set; }
		public bool IsSkip { get; set; }

		// [CompilerGeneratedAttribute] // RVA: 0x6B3990 Offset: 0x6B3990 VA: 0x6B3990
		// // RVA: 0xE39A30 Offset: 0xE39A30 VA: 0xE39A30
		// public bool get_IsOpen() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B39A0 Offset: 0x6B39A0 VA: 0x6B39A0
		// // RVA: 0xE39A38 Offset: 0xE39A38 VA: 0xE39A38
		// private void set_IsOpen(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B39B0 Offset: 0x6B39B0 VA: 0x6B39B0
		// // RVA: 0xE39A40 Offset: 0xE39A40 VA: 0xE39A40
		// public bool get_IsClose() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B39C0 Offset: 0x6B39C0 VA: 0x6B39C0
		// // RVA: 0xE39A48 Offset: 0xE39A48 VA: 0xE39A48
		// private void set_IsClose(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B39D0 Offset: 0x6B39D0 VA: 0x6B39D0
		// // RVA: 0xE39A50 Offset: 0xE39A50 VA: 0xE39A50
		// public bool get_IsSkip() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6B39E0 Offset: 0x6B39E0 VA: 0x6B39E0
		// // RVA: 0xE39A58 Offset: 0xE39A58 VA: 0xE39A58
		// private void set_IsSkip(bool value) { }

		// // RVA: 0xE39A60 Offset: 0xE39A60 VA: 0xE39A60
		public void SetStatus()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE39B60 Offset: 0xE39B60 VA: 0xE39B60
		// public void Reset() { }

		// // RVA: 0xE39B64 Offset: 0xE39B64 VA: 0xE39B64
		// public void Update() { }

		// // RVA: 0xE39AB4 Offset: 0xE39AB4 VA: 0xE39AB4
		// public void SwitchLogo(int index) { }

		// // RVA: 0xE39C3C Offset: 0xE39C3C VA: 0xE39C3C
		public void Show()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xE39DDC Offset: 0xE39DDC VA: 0xE39DDC
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B39F0 Offset: 0x6B39F0 VA: 0x6B39F0
		// // RVA: 0xE39D50 Offset: 0xE39D50 VA: 0xE39D50
		// private IEnumerator UpdateLogo() { }

		// // RVA: 0xE39B68 Offset: 0xE39B68 VA: 0xE39B68
		// private void Skip() { }

		// // RVA: 0xE39EA0 Offset: 0xE39EA0 VA: 0xE39EA0 Slot: 5
		// public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// // RVA: 0xE3A004 Offset: 0xE3A004 VA: 0xE3A004
		// public void .ctor() { }
	}
}
