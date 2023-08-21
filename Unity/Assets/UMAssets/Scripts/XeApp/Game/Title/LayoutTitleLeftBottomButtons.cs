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
			if(m_buttonGpgs != null)
				m_buttonGpgs.ClearOnClickCallback();
		}

		// // RVA: 0xE39724 Offset: 0xE39724 VA: 0xE39724
		public void SetCallback()
		{
			if(m_buttonGpgs != null)
			{
				m_buttonGpgs.AddOnClickCallback(() => {
					// 0xE399C4
					//TodoLogger.LogNotImplemented("LayoutTitleLeftBottomButton");
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Check File?", SizeType.Small, "Recheck all file integrity ?", new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative }
					}) , (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						if(type == PopupButton.ButtonType.Positive)
							KEHOJEJMGLJ.FJDOHLADGFI = true;
						else
							KEHOJEJMGLJ.FJDOHLADGFI = false;
					}, null, null, null);
				});
			}
		}

		// // RVA: 0xE39814 Offset: 0xE39814 VA: 0xE39814
		// public void Reset() { }

		// // RVA: 0xE3667C Offset: 0xE3667C VA: 0xE3667C
		public void Show()
		{
			if(m_buttonGpgsLayout == null)
				return;
			if(!AppEnv.IsCBT())
			{
				if(NDABOOOOENC.HHCJCDFCLOB.LHGFPPIEKPJ)
				{
					m_buttonGpgsLayout.StartChildrenAnimGoStop("go_in", "st_in");
					return;
				}
			}
			m_buttonGpgsLayout.StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0xE39818 Offset: 0xE39818 VA: 0xE39818
		// public void Hide() { }

		// // RVA: 0xE39898 Offset: 0xE39898 VA: 0xE39898 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttonGpgsLayout = layout.Root[0] as AbsoluteLayout;
			SetCallback();
			m_buttonGpgsLayout.StartChildrenAnimGoStop("st_non");
			Loaded();
			return true;
		}
	}
}
