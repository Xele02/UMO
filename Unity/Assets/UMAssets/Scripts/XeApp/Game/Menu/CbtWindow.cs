using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class CbtWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_image; // 0x14
		[SerializeField]
		private ActionButton m_btn; // 0x18
		private AbsoluteLayout m_abs; // 0x1C
		private Action m_end_call_back; // 0x20
		private bool is_open; // 0x24

		// RVA: 0x10ABFA0 Offset: 0x10ABFA0 VA: 0x10ABFA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_pickup_win_anim") as AbsoluteLayout;
			m_btn.AddOnClickCallback(() =>
			{
				//0x10AC3CC
				OnClick();
			});
			Loaded();
			return true;
		}

		// RVA: 0x10AC0D4 Offset: 0x10AC0D4 VA: 0x10AC0D4
		public void Show(Action end_call_back)
		{
			gameObject.SetActive(true);
			m_end_call_back = end_call_back;
			Enter();
		}

		// // RVA: 0x10AC120 Offset: 0x10AC120 VA: 0x10AC120
		private void Enter()
		{
			if(is_open)
				return;
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
			is_open = true;
		}

		// // RVA: 0x10AC1C0 Offset: 0x10AC1C0 VA: 0x10AC1C0
		// private void Leave() { }

		// // RVA: 0x10AC260 Offset: 0x10AC260 VA: 0x10AC260
		// public void None() { }

		// // RVA: 0x10AC2E8 Offset: 0x10AC2E8 VA: 0x10AC2E8
		private void OnClick()
		{
			m_end_call_back();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CBCB4 Offset: 0x6CBCB4 VA: 0x6CBCB4
		// // RVA: 0x10AC314 Offset: 0x10AC314 VA: 0x10AC314
		// private IEnumerator Co_End() { }

		// RVA: 0x10AC3C0 Offset: 0x10AC3C0 VA: 0x10AC3C0
		private void Update()
		{
			return;
		}
	}
}
