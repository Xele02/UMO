using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupSnsSetting : LayoutUGUIScriptBase
	{
		protected enum eText
		{
			Desc1 = 0,
			Desc2 = 1,
			Desc3 = 2,
			Desc4 = 3,
			Num = 4,
		}

		public enum eButtonType
		{
			Facebook = 0,
			Twitter = 1,
			Line = 2,
			Apple = 3,
			Num = 4,
		}

		public enum eButtonStatus
		{
			NotCoop = 0,
			Coop = 1,
			Release = 2,
		}

		[SerializeField]
		private Text[] m_texts; // 0x14
		[SerializeField]
		private LayoutInhertingSnsButton[] m_buttons; // 0x18
		[SerializeField]
		private ToggleButton m_toggleButton; // 0x1C
		private AbsoluteLayout m_checkBoxLayout; // 0x38
		private List<AbsoluteLayout> m_inh_link_Icon; // 0x3C

		public Action OnButtonCallbackFacebook { get; set; } // 0x20
		public Action OnButtonCallbackTwitter { get; set; } // 0x24
		public Action OnButtonCallbackLine { get; set; } // 0x28
		public Action OnButtonCallbackApple { get; set; } // 0x2C
		public Action<bool> OnButtonCallbackShow { get; set; } // 0x30
		public bool IsTitle { get; set; } // 0x34

		//// RVA: 0x178981C Offset: 0x178981C VA: 0x178981C Slot: 6
		public virtual void SetStatus()
		{
			MessageBank bank = MessageManager.Instance.GetBank("common");
			SetText(eText.Desc1, bank.GetMessageByLabel("popup_inh_sns_000"));
			SetText(eText.Desc2, bank.GetMessageByLabel("popup_inh_sns_001"));
			SetText(eText.Desc3, bank.GetMessageByLabel("popup_inh_sns_002"));
			SetText(eText.Desc4, bank.GetMessageByLabel("popup_inh_sns_003"));
			SetCheckBoxEnable(!GameManager.Instance.localSave.EPJOACOONAC_GetSave().OFMECFHNCHA_Popup.MDBINDIACKP_CanShowPopup(ILDKBCLAFPB.EHNBPANMAKA_Popup.FEGJEHDIEMM.HLFFEADNEHB));
			if (IsTitle)
				return;
			SetText(eText.Desc3, "");
			SetText(eText.Desc4, "");
			m_checkBoxLayout.enabled = false;
		}

		//// RVA: 0x1789C40 Offset: 0x1789C40 VA: 0x1789C40
		//public void Reset() { }

		//// RVA: 0x1789C44 Offset: 0x1789C44 VA: 0x1789C44
		public void Show()
		{
			SetStatus();
		}

		//// RVA: 0x1789C54 Offset: 0x1789C54 VA: 0x1789C54
		public void Hide()
		{
			return;
		}

		//// RVA: 0x1789C58 Offset: 0x1789C58 VA: 0x1789C58
		public void SetButtonSnsStatus(eButtonType buttonType, eButtonStatus status)
		{
			if((int)buttonType > -1)
			{
				if((int)buttonType < m_buttons.Length)
				{
					if(m_buttons[(int)buttonType] != null)
					{
						m_buttons[(int)buttonType].SetStatus(buttonType, status);
					}
				}
			}
		}

		//// RVA: 0x1789B0C Offset: 0x1789B0C VA: 0x1789B0C
		public void SetCheckBoxEnable(bool enable)
		{
			if(m_toggleButton != null)
			{
				if (enable)
					m_toggleButton.SetOn();
				else
					m_toggleButton.SetOff();
			}
		}

		//// RVA: 0x17891FC Offset: 0x17891FC VA: 0x17891FC
		protected void SetText(eText type, string text)
		{
			m_texts[(int)type].text = text;
		}

		// RVA: 0x17893C8 Offset: 0x17893C8 VA: 0x17893C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			AbsoluteLayout a = layout.FindViewById("swtbl_sel_inh_btn_form") as AbsoluteLayout;
			if(a != null)
			{
				a.StartChildrenAnimGoStop("02");
			}
			m_buttons[0].SetCallback(() =>
			{
				//0x1789D78
				if (OnButtonCallbackFacebook != null)
					OnButtonCallbackFacebook();
			});
			m_buttons[1].SetCallback(() =>
			{
				//0x1789D8C
				if (OnButtonCallbackTwitter != null)
					OnButtonCallbackTwitter();
			});
			m_buttons[2].SetCallback(() =>
			{
				//0x1789DA0
				if (OnButtonCallbackLine != null)
					OnButtonCallbackLine();
			});
			m_buttons[3].SetCallback(() =>
			{
				//0x1789DB4
				if (OnButtonCallbackApple != null)
					OnButtonCallbackApple();
			});
			if(m_toggleButton != null)
			{
				m_toggleButton.AddOnClickCallback(() =>
				{
					//0x1789DC8
					TodoLogger.LogNotImplemented("LayoutPopupSnsSetting.m_toggleButton click");
				});
			}
			m_checkBoxLayout = layout.FindViewByExId("sw_inh_pop_sns_sw_cmn_btn_check_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

	}
}
