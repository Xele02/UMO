using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotFewRuntime : PopupGachaLotRuntime
	{
		[SerializeField]
		private RawImageEx m_needLabelImage; // 0x48
		[SerializeField]
		private Text[] m_messageCautionTexts; // 0x4C
		[SerializeField]
		private Text m_needCurrencyText; // 0x50
		private Rect m_needStoneUvRect; // 0x54
		private Rect m_needTicketUvRect; // 0x64
		private AbsoluteLayout m_layoutRoot; // 0x74
		private AbsoluteLayout m_layoutBalloon; // 0x78

		// // RVA: 0x17A02E8 Offset: 0x17A02E8 VA: 0x17A02E8 Slot: 6
		public override void SetCurrencyType(bool isTicket)
		{
			base.SetCurrencyType(isTicket);
			m_needLabelImage.uvRect = isTicket ? m_needTicketUvRect : m_needStoneUvRect;
		}

		// // RVA: 0x17A03DC Offset: 0x17A03DC VA: 0x17A03DC Slot: 7
		public override void SetBalloon(bool enable)
		{
			m_layoutBalloon.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		// // RVA: 0x17A0474 Offset: 0x17A0474 VA: 0x17A0474
		public void SetMessageCaution(string text)
		{
			if(text == null)
				m_layoutRoot.StartChildrenAnimGoStop("03");
			else
			{
				string[] strs = text.Split(new char[] { '\n' });
				if(strs.Length < 2)
				{
					m_layoutRoot.StartChildrenAnimGoStop("01");
					m_messageCautionTexts[0].text = text;
					m_messageCautionTexts[0].text = "";
				}
				else
				{
					m_layoutRoot.StartChildrenAnimGoStop("02");
					m_messageCautionTexts[0].text = strs[0];
					m_messageCautionTexts[0].text = strs[1];
				}
			}
		}

		// // RVA: 0x17A078C Offset: 0x17A078C VA: 0x17A078C
		public void SetNeedCurrency(string text)
		{
			m_needCurrencyText.text = text;
		}

		// RVA: 0x17A07C8 Offset: 0x17A07C8 VA: 0x17A07C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_needStoneUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gacha_pop_font_03"));
			m_needTicketUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gacha_pop_font_04"));
			m_layoutRoot = layout.FindViewById("swtbl_gacha_pop_supple") as AbsoluteLayout;
			m_layoutBalloon = layout.FindViewById("swtbl_gacha_pop_balloon") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
