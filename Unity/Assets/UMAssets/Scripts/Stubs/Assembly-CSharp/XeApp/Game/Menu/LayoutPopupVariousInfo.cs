using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupVariousInfo : LayoutUGUIScriptBase
	{
		private enum eButtonType
		{
			OfficialSite = 0,
			PortalSite = 1,
			Wiki = 2,
			Twitter = 3,
			FAQ = 4,
			Byelaw = 5,
			Policy = 6,
			Transaction = 7,
			Settlement = 8,
			CopyRight = 9,
			Credit = 10,
		}

		[SerializeField]
		private ActionButton[] m_buttons; // 0x14

		public Action CallbackOfficialSite { get; set; } // 0x18
		public Action CallbackPortalSite { get; set; } // 0x1C
		public Action CallbackWiki { get; set; } // 0x20
		public Action CallbackPolicy { get; set; } // 0x24
		public Action CallbackTransaction { get; set; } // 0x28
		public Action CallbackByelaw { get; set; } // 0x2C
		public Action CallbackSettlement { get; set; } // 0x30
		public Action CallbackCopyRight { get; set; } // 0x34
		public Action CallbackTwitter { get; set; } // 0x38
		public Action CallbackFAQ { get; set; } // 0x3C
		public Action CallbackCredit { get; set; } // 0x40

		// RVA: 0x1793EE4 Offset: 0x1793EE4 VA: 0x1793EE4
		public int SetStatus()
		{
			SetupButton(m_buttons[0], LayoutPopupVariousInfoButtonLabel.eLabelType.OfficialSite, CallbackOfficialSite);
			SetupButton(m_buttons[1], LayoutPopupVariousInfoButtonLabel.eLabelType.PortalSite, CallbackPortalSite);
			int i = 0;
			if (!AppEnv.IsCBT() && !AppEnv.IsPresentation())
			{
				SetupButton(m_buttons[2], LayoutPopupVariousInfoButtonLabel.eLabelType.Wiki, CallbackWiki);
				i = 1;
			}
			else
			{
			}
			SetupButton(m_buttons[2 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Twitter, CallbackTwitter);
			SetupButton(m_buttons[3 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.FAQ, CallbackFAQ);
			SetupButton(m_buttons[4 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Byelaw, CallbackByelaw);
			SetupButton(m_buttons[5 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Policy, CallbackPolicy);
			SetupButton(m_buttons[6 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Transaction, CallbackTransaction);
			SetupButton(m_buttons[7 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Settlement, CallbackSettlement);
			SetupButton(m_buttons[8 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.CopyRight, CallbackCopyRight);
			SetupButton(m_buttons[9 + i], LayoutPopupVariousInfoButtonLabel.eLabelType.Credit, CallbackCredit);
			for(int j = i + 10; j < m_buttons.Length; j++)
			{
				m_buttons[j].Hidden = true;
			}
			return 10 + i;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FDC6C Offset: 0x6FDC6C VA: 0x6FDC6C
		//// RVA: 0x1794520 Offset: 0x1794520 VA: 0x1794520
		public IEnumerator CreditDark()
		{
			//0x1870254
			if(AppEnv.IsCBT())
			{
				yield return null;
				ActionButton btn = FindButtonByLabel(m_buttons, LayoutPopupVariousInfoButtonLabel.eLabelType.Credit);
				if (btn != null)
					btn.Disable = true;
			}
		}

		//// RVA: 0x17945A8 Offset: 0x17945A8 VA: 0x17945A8
		private ActionButton FindButtonByLabel(ActionButton[] buttons, LayoutPopupVariousInfoButtonLabel.eLabelType label)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				LayoutPopupVariousInfoButtonLabel l = buttons[i].GetComponent<LayoutPopupVariousInfoButtonLabel>();
				if(l != null)
				{
					if (l.ButtonLabel == label)
						return buttons[i];
				}
			}
			return null;
		}

		// RVA: 0x1794704 Offset: 0x1794704 VA: 0x1794704
		public void Reset()
		{
			return;
		}

		// RVA: 0x1794708 Offset: 0x1794708 VA: 0x1794708
		public void Show()
		{
			return;
		}

		// RVA: 0x179470C Offset: 0x179470C VA: 0x179470C
		public void Hide()
		{
			return;
		}

		//// RVA: 0x1794340 Offset: 0x1794340 VA: 0x1794340
		private void SetupButton(ActionButton button, LayoutPopupVariousInfoButtonLabel.eLabelType label, Action callback)
		{
			if(button != null)
			{
				button.ClearOnClickCallback();
				button.AddOnClickCallback(() =>
				{
					//0x187021C
					if (callback != null)
						callback();
				});
				LayoutPopupVariousInfoButtonLabel lbl = button.GetComponent<LayoutPopupVariousInfoButtonLabel>();
				if(lbl != null)
					lbl.SetLabel(label);
			}
		}

		// RVA: 0x1794710 Offset: 0x1794710 VA: 0x1794710 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
