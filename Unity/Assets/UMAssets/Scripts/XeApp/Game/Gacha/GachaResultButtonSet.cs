using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using XeSys;

namespace XeApp.Game.Gacha
{
	public class GachaResultButtonSet : LayoutLabelScriptBase
	{
		[SerializeField]
		private GachaResultRetryButton m_retryButton; // 0x18
		[SerializeField]
		private ActionButton m_backButton; // 0x1C
		[SerializeField]
		private ActionButton m_legalDescButton; // 0x20
		[SerializeField]
		private ActionButton m_confirmButton; // 0x24
		[SerializeField]
		private RawImageEx m_imageKakuteiInfo; // 0x28
		[SerializeField]
		private Font m_fontKakutei; // 0x2C
		[SerializeField]
		private Text m_textKakutei; // 0x30
		[SerializeField]
		private Text m_textTelop; // 0x34
		private LayoutSymbolData m_symbolMain; // 0x38
		private LayoutSymbolData m_symbolStyle; // 0x3C
		private LayoutSymbolData m_symbolDrawRarity; // 0x40
		private LayoutSymbolData m_symbolButton; // 0x44
		private AbsoluteLayout m_layoutTelop; // 0x48
		private TexUVListManager m_uvMan; // 0x4C

		public Action onClickBackButton { private get; set; } // 0x50
		public Action onClickRetryButton { private get; set; } // 0x54
		public Action onClickLegalDescButton { private get; set; } // 0x58
		public Action onClickConfirmButton { private get; set; } // 0x5C

		// // RVA: 0x98E5C8 Offset: 0x98E5C8 VA: 0x98E5C8
		private void OnClickBackButton()
		{
			if(onClickBackButton != null)
				onClickBackButton();
		}

		// // RVA: 0x98E5DC Offset: 0x98E5DC VA: 0x98E5DC
		private void OnClickRetryButton()
		{
			if(onClickRetryButton != null)
				onClickRetryButton();
		}

		// // RVA: 0x98E5F0 Offset: 0x98E5F0 VA: 0x98E5F0
		private void OnClickLegalDescButton()
		{
			if(onClickLegalDescButton != null)
				onClickLegalDescButton();
		}

		// // RVA: 0x98E604 Offset: 0x98E604 VA: 0x98E604
		private void OnClickConfirmButton()
		{
			if(onClickConfirmButton != null)
				onClickConfirmButton();
		}

		// // RVA: 0x98C9A8 Offset: 0x98C9A8 VA: 0x98C9A8
		// public void Setup(GachaDirectionResource resource, DirectionInfo directionInfo) { }

		// RVA: 0x98D5C0 Offset: 0x98D5C0 VA: 0x98D5C0
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x988834 Offset: 0x988834 VA: 0x988834
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x98A434 Offset: 0x98A434 VA: 0x98A434
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		// RVA: 0x987A08 Offset: 0x987A08 VA: 0x987A08
		public void SetRetryConsume(int itemId, int count)
		{
			m_symbolStyle.StartAnim("br");
			m_retryButton.SetConsume(count);
			m_retryButton.SetCurrencyType(itemId);
		}

		// // RVA: 0x98E85C Offset: 0x98E85C VA: 0x98E85C
		// public void SetRetryDisable() { }

		// RVA: 0x98798C Offset: 0x98798C VA: 0x98798C
		public void HideRetry()
		{
			m_symbolStyle.StartAnim("b");
		}

		// // RVA: 0x98E88C Offset: 0x98E88C VA: 0x98E88C
		// public void ShowLegalDesc() { }

		// RVA: 0x98B100 Offset: 0x98B100 VA: 0x98B100
		public void HideLegalDesc()
		{
			m_legalDescButton.Hidden = true;
		}

		// RVA: 0x98B130 Offset: 0x98B130 VA: 0x98B130
		public void ShowConfirm()
		{
			m_confirmButton.Hidden = false;
		}

		// RVA: 0x98E618 Offset: 0x98E618 VA: 0x98E618
		public void HideConfirm()
		{
			m_confirmButton.Hidden = true;
		}

		// RVA: 0x987AF0 Offset: 0x987AF0 VA: 0x987AF0
		public void SetRemainCount(int count, int max = 1)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(count < 1)
			{
				m_layoutTelop.StartChildrenAnimGoStop("02");
			}
			else
			{
				if(max < 2)
					m_textTelop.text = bk.GetMessageByLabel("gacha_telop_01");
				else
					m_textTelop.text = string.Format(bk.GetMessageByLabel("gacha_telop_02"), count);
				m_layoutTelop.StartChildrenAnimGoStop("01");
			}
		}

		// RVA: 0x987E10 Offset: 0x987E10 VA: 0x987E10
		public void SetTelopType(GCAHJLOGMCI.KNMMOMEHDON selectMode, KBPDNHOKEKD_ProductId productData, string msg)
		{
            KBPDNHOKEKD_ProductId.KNEKLJHNHAK a = KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0;
			if(selectMode == GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
			{
				m_textTelop.text = "";
			}
			else
			{
				a = productData.FJICMLBOJCH();
				m_textTelop.text = msg;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(a == KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA_4)
			{
				m_symbolButton.StartAnim("free");
				m_layoutTelop.StartChildrenAnimGoStop("01");
				m_textTelop.text = bk.GetMessageByLabel("gacha_telop_05");
			}
			else if(a == KBPDNHOKEKD_ProductId.KNEKLJHNHAK.DKIKNLEDDBK_3)
			{
				m_symbolButton.StartAnim("normal");
				m_retryButton.SetConsume(productData.NPPGKNGIFGK_Price);
				m_layoutTelop.StartChildrenAnimGoStop("01");
				m_textTelop.text = string.Format(bk.GetMessageByLabel("gacha_telop_04"), productData.HCMGHDNNJOM());
			}
			else if(a == KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0)
			{
				m_layoutTelop.StartChildrenAnimGoStop("02");
			}
		}

		// RVA: 0x988394 Offset: 0x988394 VA: 0x988394
		public void SetDrawRarity(string kakutei)
		{
			if(kakutei == "")
			{
				m_symbolDrawRarity.StartAnim("hide");
			}
			else
			{
				int a = 0;
				string str = "";
				if(Regex.IsMatch(kakutei, JpStringLiterals.StringLiteral_14844))
				{
					int.TryParse(Regex.Replace(Regex.Match(kakutei, JpStringLiterals.StringLiteral_14845).Value, JpStringLiterals.StringLiteral_14845, (Match p) =>
					{
						//0x98ECF4
						return (p.Value[0] + 0x120).ToString();
					}), out a);
					if(a < 5)
					{
						str = "gacha_button_ribbon_b";
					}
					else
					{
						str = "gacha_button_ribbon_p";
					}
				}
				else
				{
					str = "gacha_button_ribbon_b";
				}
				m_textKakutei.text = kakutei;
				TexUVData data = m_uvMan.GetUVData(str);
				if(data != null)
				{
					m_imageKakuteiInfo.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
				}
				m_symbolDrawRarity.StartAnim("show");
			}
		}

		// RVA: 0x98915C Offset: 0x98915C VA: 0x98915C
		public void PerformClickButton()
		{
			if(m_backButton != null)
			{
				if(m_backButton.gameObject.activeInHierarchy && !m_backButton.Hidden && !m_backButton.Disable && !m_backButton.IsInputOff)
					m_backButton.PerformClick();
			}
		}

		// RVA: 0x98E8BC Offset: 0x98E8BC VA: 0x98E8BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvMan = uvMan;
			m_textKakutei.font = m_fontKakutei;
			m_textKakutei.material = m_fontKakutei.material;
			m_textKakutei.verticalOverflow = VerticalWrapMode.Overflow;
			m_textKakutei.horizontalOverflow = HorizontalWrapMode.Overflow;
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStyle = CreateSymbol("style", layout);
			m_symbolDrawRarity = CreateSymbol("rare", layout);
			m_symbolButton = CreateSymbol("button", layout);
			m_layoutTelop = layout.FindViewById("sw_ann_first_anim") as AbsoluteLayout;
			m_backButton.AddOnClickCallback(OnClickBackButton);
			m_retryButton.AddOnClickCallback(OnClickRetryButton);
			m_legalDescButton.AddOnClickCallback(OnClickLegalDescButton);
			m_confirmButton.AddOnClickCallback(OnClickConfirmButton);
			Loaded();
			return true;
		}
	}
}
