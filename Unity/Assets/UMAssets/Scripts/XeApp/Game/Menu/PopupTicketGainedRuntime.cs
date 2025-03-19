using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupTicketGainedRuntime : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textTitle; // 0x14
		[SerializeField]
		private Text m_textLabel01; // 0x18
		[SerializeField]
		private Text m_textLabel02; // 0x1C
		[SerializeField]
		private RawImageEx m_itemImage; // 0x20
		private AbsoluteLayout m_AbsoluteLabel01; // 0x24
		private AbsoluteLayout m_AbsoluteLabel02; // 0x28

		// // RVA: 0x11549E0 Offset: 0x11549E0 VA: 0x11549E0
		public void SetText(string a_title, string a_label01, string a_label02, int a_layout_type)
		{
			m_textTitle.text = a_title;
			m_textLabel01.text = a_label01;
			m_textLabel02.text = a_label02;
			if(a_layout_type == 2)
			{
				m_AbsoluteLabel01.StartChildrenAnimGoStop("02");
				m_AbsoluteLabel02.StartChildrenAnimGoStop("03");
			}
			else if(a_layout_type == 1)
			{
				m_AbsoluteLabel01.StartChildrenAnimGoStop("01");
				m_AbsoluteLabel02.StartChildrenAnimGoStop("02");
			}
			else if(a_layout_type == 0)
			{
				m_AbsoluteLabel01.StartChildrenAnimGoStop("01");
				m_AbsoluteLabel02.StartChildrenAnimGoStop("01");
			}
		}

		// // RVA: 0x11548D0 Offset: 0x11548D0 VA: 0x11548D0
		public void SetItem(IiconTexture image)
		{
			if(image == null)
				m_itemImage.enabled = false;
			else
			{
				m_itemImage.enabled = true;
				image.Set(m_itemImage);
			}
		}

		// RVA: 0x1154BE0 Offset: 0x1154BE0 VA: 0x1154BE0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_AbsoluteLabel01 = layout.FindViewByExId("sw_pop_ticket_swtbl_fnt2") as AbsoluteLayout;
			m_AbsoluteLabel02 = layout.FindViewByExId("sw_pop_ticket_swtbl_fnt") as AbsoluteLayout;
			m_itemImage.enabled = false;
			Loaded();
			return true;
		}
	}
}
