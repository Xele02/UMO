using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;
using mcrs;

namespace XeApp.Game.Title
{
	public class LayoutPopupTitleSupport : LayoutUGUIScriptBase
	{
		public enum eButtonType
		{
			Cache = 0,
			Information = 1,
			Inquiry = 2,
			Paid = 3,
			Num = 4,
		}

		[SerializeField]
		private ActionButton[] m_buttons = new ActionButton[4]; // 0x14
		private AbsoluteLayout m_root; // 0x2C
		private AbsoluteLayout[] m_buttonTbl = new AbsoluteLayout[4]; // 0x30

		public Action ButtonCallbackCache { get; set; } // 0x18
		public Action ButtonCallbackInformation { get; set; } // 0x1C
		public Action ButtonCallbackInquiry { get; set; } // 0x20
		public Action ButtonCallbackPaid { get; set; } // 0x24
		public PopupWindowControl popupControl { get; set; } // 0x28

		//// RVA: 0xE33B58 Offset: 0xE33B58 VA: 0xE33B58
		public void SetStatus()
		{
			ButtonCallbackCache = () =>
			{
				//0xE3530C
				PopupWindowManager.OpenCacheClearWindow(null);
			};
			ButtonCallbackInformation = () =>
			{
				//0xE34BB8
				ShowInformation();
			};
			ButtonCallbackInquiry = () =>
			{
				//0xE34BBC
				if (popupControl != null)
					popupControl.InputDisable();
				MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry, () =>
				{
					//0xE34D40
					if (popupControl != null)
						popupControl.InputEnable();
				}, () =>
				{
					//0xE34DF4
					if (popupControl != null)
					{
						popupControl.InputEnable();
						popupControl.Close(() =>
						{
							//0xE3538C
							return;
						}, null);
					}
				});
			};
		}

		//// RVA: 0xE33CF4 Offset: 0xE33CF4 VA: 0xE33CF4
		public void SwitchButtonLabel(eButtonType type)
		{
			if (m_buttonTbl.Length <= (int)type)
				return;
			if (m_buttonTbl[(int)type] == null)
				return;
			switch(type)
			{
				case eButtonType.Cache:
					m_buttonTbl[0].StartAllAnimGoStop("00");
					break;
				case eButtonType.Information:
					m_buttonTbl[1].StartAllAnimGoStop("02");
					break;
				case eButtonType.Inquiry:
					m_buttonTbl[2].StartAllAnimGoStop("01");
					break;
				case eButtonType.Paid:
					m_buttonTbl[3].StartAllAnimGoStop("03");
					break;
				default:
					break;
			}
		}

		// RVA: 0xE33F2C Offset: 0xE33F2C VA: 0xE33F2C
		public void Reset()
		{
			return;
		}

		//// RVA: 0xE33F30 Offset: 0xE33F30 VA: 0xE33F30
		public void Show()
		{
			if (m_root != null)
				m_root.StartAllAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xE33FB0 Offset: 0xE33FB0 VA: 0xE33FB0
		public void Hide()
		{
			if (m_root != null)
				m_root.StartAllAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xE34030 Offset: 0xE34030 VA: 0xE34030
		private void ShowInformation()
		{
			if(popupControl != null)
			{
				popupControl.InputDisable();
				MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.GCCBFIFJHII_Information, () =>
				{
					//0xE34FA0
					if (popupControl != null)
						popupControl.InputEnable();
				}, () =>
				{
					//0xE35054
					if(popupControl != null)
					{
						popupControl.InputEnable();
						popupControl.Close(() =>
						{
							//0xE35390
							return;
						}, null);
					}
				});
			}
		}

		//// RVA: 0xE341B4 Offset: 0xE341B4 VA: 0xE341B4
		private void SetButtonCallback(ActionButton button, ButtonBase.OnClickCallback callback)
		{
			if(button != null)
			{
				button.AddOnClickCallback(callback);
			}
		}

		//// RVA: 0xE34268 Offset: 0xE34268 VA: 0xE34268
		private void PlaySe()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B2D40 Offset: 0x6B2D40 VA: 0x6B2D40
		//// RVA: 0xE342C0 Offset: 0xE342C0 VA: 0xE342C0
		private IEnumerator PaidDark()
		{
			//0xE35398
			yield return null;
			m_buttons[3].Dark = true;
		}

		// RVA: 0xE3436C Offset: 0xE3436C VA: 0xE3436C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_buttonTbl[0] = layout.FindViewByExId("sw_support_btn_all_sw_support_btn_anim_01") as AbsoluteLayout;
			m_buttonTbl[1] = layout.FindViewByExId("sw_support_btn_all_sw_support_btn_anim_02") as AbsoluteLayout;
			m_buttonTbl[2] = layout.FindViewByExId("sw_support_btn_all_sw_support_btn_anim_03") as AbsoluteLayout;
			m_buttonTbl[3] = layout.FindViewByExId("sw_support_btn_all_sw_support_btn_anim_04") as AbsoluteLayout;
			SetButtonCallback(m_buttons[0], () =>
			{
				//0xE35200
				if (ButtonCallbackCache != null)
					ButtonCallbackCache();
				PlaySe();
			});
			SetButtonCallback(m_buttons[1], () =>
			{
				//0xE35224
				if (ButtonCallbackInformation != null)
					ButtonCallbackInformation();
				PlaySe();
			});
			SetButtonCallback(m_buttons[2], () =>
			{
				//0xE35248
				if (ButtonCallbackInquiry != null)
					ButtonCallbackInquiry();
				PlaySe();
			});
			SetButtonCallback(m_buttons[3], () =>
			{
				//0xE3526C
				if (ButtonCallbackPaid != null)
					ButtonCallbackPaid();
				PlaySe();
			});
			for(int i = 0; i < 4; i++)
			{
				SwitchButtonLabel((eButtonType)i);
			}
			if(AppEnv.IsCBT())
			{
				m_buttons[3].ClearOnClickCallback();
				this.StartCoroutineWatched(PaidDark());
			}
			Loaded();
			return true;
		}
	}
}
