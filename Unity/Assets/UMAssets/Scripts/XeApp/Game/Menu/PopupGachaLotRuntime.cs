using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotRuntime : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_holdLabelImage; // 0x14
		[SerializeField]
		private Text m_messageText; // 0x18
		[SerializeField]
		private Text m_holdCurrencyText; // 0x1C
		[SerializeField]
		private ActionButton m_legalDescButton; // 0x20
		private Rect m_holdStoneUvRect; // 0x24
		private Rect m_holdTicketUvRect; // 0x34

		public Action onClickLegalDesc { private get; set; } // 0x44

		// // RVA: 0x17A0BE8 Offset: 0x17A0BE8 VA: 0x17A0BE8
		public void SetMessage(string msg)
		{
			m_messageText.text = msg;
		}

		// // RVA: 0x17A0368 Offset: 0x17A0368 VA: 0x17A0368 Slot: 6
		public virtual void SetCurrencyType(bool isTicket)
		{
			m_holdLabelImage.uvRect = isTicket ? m_holdTicketUvRect : m_holdStoneUvRect;
		}

		// // RVA: 0x17A0C24 Offset: 0x17A0C24 VA: 0x17A0C24
		public void SetHoldCurrency(string text)
		{
			m_holdCurrencyText.text = text;
		}

		// // RVA: 0x17A0C60 Offset: 0x17A0C60 VA: 0x17A0C60
		public void ShowLegalDescButton()
		{
			m_legalDescButton.Hidden = false;
		}

		// // RVA: 0x17A0C90 Offset: 0x17A0C90 VA: 0x17A0C90
		public void HideLegalDescButton()
		{
			m_legalDescButton.Hidden = true;
		}

		// // RVA: 0x17A0CC0 Offset: 0x17A0CC0 VA: 0x17A0CC0 Slot: 7
		public virtual void SetBalloon(bool enable)
		{
			return;
		}

		// RVA: 0x17A0A00 Offset: 0x17A0A00 VA: 0x17A0A00 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_holdStoneUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gacha_pop_font_01"));
			m_holdTicketUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("gacha_pop_font_02"));
			m_legalDescButton.ClearOnClickCallback();
			m_legalDescButton.AddOnClickCallback(() =>
			{
				//0x17A0CC4
				if(onClickLegalDesc != null)
					onClickLegalDesc();
			});
			Loaded();
			return true;
		}
	}
}
