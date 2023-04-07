using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class HomeGetSkipTicket : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonClose; // 0x14
		[SerializeField]
		private CheckboxButton m_checkboxReject; // 0x18
		[SerializeField]
		private Text m_textTitle; // 0x1C
		[SerializeField]
		private Text m_textDesc1; // 0x20
		[SerializeField]
		private Text m_textDesc2; // 0x24
		[SerializeField]
		private Text m_textNumLabel; // 0x28
		[SerializeField]
		private Text m_textNumCount; // 0x2C
		[SerializeField]
		private Text m_textReject; // 0x30
		[SerializeField]
		private RawImageEx m_imageIcon; // 0x34
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker; // 0x38
		private AbsoluteLayout m_layoutRoot; // 0x3C
		private int m_typeItemId; // 0x40
		private bool m_isOpen; // 0x44

		public bool IsOpen { get { return m_isOpen; } } //0x963E9C
		public Action onClickCloseButton { private get; set; } // 0x48
		public Action<bool> onClickRejectCheckbox { private get; set; } // 0x4C

		//// RVA: 0x963EC4 Offset: 0x963EC4 VA: 0x963EC4
		public void Enter(bool checkReject = false, bool checkBoxHidden = false, Action callback = null)
		{
			TodoLogger.Log(0, "Enter");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E2474 Offset: 0x6E2474 VA: 0x6E2474
		//// RVA: 0x963F6C Offset: 0x963F6C VA: 0x963F6C
		//private IEnumerator Co_Enter(Action callback) { }

		//// RVA: 0x964034 Offset: 0x964034 VA: 0x964034
		//public void Leave(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E24EC Offset: 0x6E24EC VA: 0x6E24EC
		//// RVA: 0x964068 Offset: 0x964068 VA: 0x964068
		//private IEnumerator Co_Leave(Action callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6E2564 Offset: 0x6E2564 VA: 0x6E2564
		//// RVA: 0x964130 Offset: 0x964130 VA: 0x964130
		//public IEnumerator WaitAnim(AbsoluteLayout layout) { }

		//// RVA: 0x9641DC Offset: 0x9641DC VA: 0x9641DC
		public void Setup(int typeItemId, int getCount)
		{
			TodoLogger.Log(0, "Setup");
		}

		//// RVA: 0x964844 Offset: 0x964844 VA: 0x964844 Slot: 5
		//public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		//// RVA: 0x964A58 Offset: 0x964A58 VA: 0x964A58
		//private void ShowConfirmWindow(bool isChecked, Action<bool> callback) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E25DC Offset: 0x6E25DC VA: 0x6E25DC
		//// RVA: 0x964E78 Offset: 0x964E78 VA: 0x964E78
		//private void <Setup>b__28_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E25EC Offset: 0x6E25EC VA: 0x6E25EC
		//// RVA: 0x964F58 Offset: 0x964F58 VA: 0x964F58
		//private void <InitializeFromLayout>b__29_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E25FC Offset: 0x6E25FC VA: 0x6E25FC
		//// RVA: 0x964FD4 Offset: 0x964FD4 VA: 0x964FD4
		//private void <InitializeFromLayout>b__29_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6E260C Offset: 0x6E260C VA: 0x6E260C
		//// RVA: 0x9650E4 Offset: 0x9650E4 VA: 0x9650E4
		//private void <InitializeFromLayout>b__29_2(bool isChecked) { }
	}
}
