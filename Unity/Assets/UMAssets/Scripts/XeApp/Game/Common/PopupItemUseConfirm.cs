using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeApp.Game.Menu;
using System;
using System.Collections.Generic;
using mcrs;

namespace XeApp.Game.Common
{
	public class PopupItemUseConfirm : LayoutUGUIScriptBase, IPopupContent
	{
		[SerializeField]
		private RawImageEx m_imageIcon; // 0x14
		[SerializeField]
		private ActionButton m_buttonIcon; // 0x18
		[SerializeField]
		private ActionButton m_buttonDetail; // 0x1C
		[SerializeField]
		private NumberBase m_numberCost; // 0x20
		[SerializeField]
		private Text m_textDesc; // 0x24
		[SerializeField]
		private Text[] m_textCount = new Text[2]; // 0x28
		[SerializeField]
		private Text m_textCaution_1; // 0x2C
		[SerializeField]
		private Text m_textCaution_2; // 0x30
		[SerializeField]
		private Text m_textCaution_3; // 0x34
		[SerializeField]
		private Text m_textPeriod; // 0x38
		private AbsoluteLayout m_layoutPeriod; // 0x3C
		private AbsoluteLayout m_layoutButton; // 0x40
		private AbsoluteLayout m_layoutCount; // 0x44
		private AbsoluteLayout m_layoutNumber; // 0x48
		private AbsoluteLayout m_layoutNumberBack; // 0x4C
		private Matrix23 m_identity; // 0x50

		public Transform Parent { get; private set; } // 0x68

		// RVA: 0x1BAB194 Offset: 0x1BAB194 VA: 0x1BAB194 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutPeriod = layout.FindViewById("swtbl_rimit") as AbsoluteLayout;
			m_layoutButton = layout.FindViewById("sw_item_frm_anim") as AbsoluteLayout;
			m_layoutCount = layout.FindViewById("swtbl_fnt_shoji_anim") as AbsoluteLayout;
			m_layoutNumber = layout.FindViewByExId("sw_btn_item_anim_sw_num_onoff_anim") as AbsoluteLayout;
			m_layoutNumberBack = layout.FindViewByExId("sw_btn_item_anim_swtbl_cmn_icon_base_4") as AbsoluteLayout;
			for(int i = 0; i < m_textCount.Length; i++)
			{
				m_textCount[i].horizontalOverflow = HorizontalWrapMode.Wrap;
				m_textCount[i].verticalOverflow = VerticalWrapMode.Truncate;
				m_textCount[i].resizeTextForBestFit = true;
			}
			Loaded();
			return true;
		}

		//// RVA: 0x1BAB578 Offset: 0x1BAB578 VA: 0x1BAB578 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupItemUseConfirmSetting setup = setting as PopupItemUseConfirmSetting;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			Parent = setting.m_parent;
			MenuScene.Instance.ItemTextureCache.Load(setup.TypeItemId, (IiconTexture texture) =>
			{
				//0x1BAD740
				texture.Set(m_imageIcon);
			});
			m_numberCost.SetNumber(setup.Cost, 0);
			if (!setup.HideUseNum)
			{
				m_layoutNumber.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_layoutNumber.StartChildrenAnimGoStop("02");
				m_layoutNumberBack.StartChildrenAnimGoStop("03");
			}
			if(string.IsNullOrEmpty(setup.OverrideText))
			{
				m_textDesc.text = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(setup.TypeItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(setup.TypeItemId));
			}
			else
			{
				m_textDesc.text = setup.OverrideText;
			}
			for(int i = 0; i < m_textCount.Length; i++)
			{
				m_textCount[i].text = string.Format(bk.GetMessageByLabel("growth_popup_text01"), setup.OwnCount);
			}
			m_layoutButton.StartChildrenAnimGoStop(setup.OwnCount < setup.Cost ? "02" : "01");
			m_layoutCount.StartChildrenAnimGoStop(setup.OwnCount < setup.Cost ? "02" : "01");
			if(setup.Period < 1)
			{
				PopupButton btn = control.FindButton(PopupButton.ButtonLabel.PassPurchase);
				if(btn != null)
				{
					m_textCaution_3.text = string.Format(bk.GetMessageByLabel("rarityup_item_get_desc_1"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(setup.TypeItemId));
					m_layoutPeriod.StartChildrenAnimGoStop("03");
				}
				else
				{
					m_layoutPeriod.StartChildrenAnimGoStop("02");
				}
			}
			else
			{
				if(string.IsNullOrEmpty(setup.OverrideCaution_1))
				{
					m_textCaution_1.text = bk.GetMessageByLabel("item_use_caution_1");
				}
				else
				{
					m_textCaution_1.text = setup.OverrideCaution_1;
				}
				if (string.IsNullOrEmpty(setup.OverrideCaution_2))
				{
					m_textCaution_2.text = bk.GetMessageByLabel("item_use_caution_2");
				}
				else
				{
					m_textCaution_2.text = setup.OverrideCaution_2;
				}
				DateTime date = Utility.GetLocalDateTime(setup.Period);
				m_textPeriod.text = string.Format(bk.GetMessageByLabel("item_use_period"), new object[5]
					{
						date.Year, date.Month, date.Day, date.Hour, date.Minute
					});
				m_layoutPeriod.StartChildrenAnimGoStop("01");
			}
			m_buttonIcon.ClearOnClickCallback();
			m_buttonIcon.AddOnClickCallback(() =>
			{
				//0x1BAD834
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.ShowItemDetail(setup.TypeItemId, setup.OwnCount, null);
			});
			m_buttonDetail.ClearOnClickCallback();
			m_buttonDetail.AddOnClickCallback(() =>
			{
				//0x1BAD970
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OpenPopupItemPeriodComfirmList(setup.TypeItemId);
			});
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<NKFJNAANPNP.MOJLCADLMKH> l = GetHaveItemInfoList(setup.TypeItemId, time);
			if(l.Count < 1)
			{
				m_buttonDetail.Hidden = true;
			}
			else
			{
				m_buttonDetail.Hidden = setup.HideDetail;
			}
		}

		//// RVA: 0x1BACB48 Offset: 0x1BACB48 VA: 0x1BACB48
		public void OpenPopupItemPeriodComfirmList(int typeItemId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			PopupItemPeriodComfirmListSetting s = new PopupItemPeriodComfirmListSetting();
			s.TypeItemId = typeItemId;
			s.TitleText = string.Format(bk.GetMessageByLabel("item_use_period_title"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(typeItemId));
			s.WindowSize = SizeType.Middle;
			s.List = GetHaveItemInfoList(typeItemId, time);
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, null, null, null, null);
		}

		//// RVA: 0x1BAC59C Offset: 0x1BAC59C VA: 0x1BAC59C
		private List<NKFJNAANPNP.MOJLCADLMKH> GetHaveItemInfoList(int typeItemId, long currentTime)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category itemCat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(typeItemId);
			List<NKFJNAANPNP.MOJLCADLMKH> res = new List<NKFJNAANPNP.MOJLCADLMKH>();
			if(itemCat < EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
			{
				if(itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
				{
					PMDCIJMMNGK_GachaTicket.EJAKHFONNGN t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.ACEHGKOLBCG(typeItemId);
					if(NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI != null && t != null)
					{
						List<HPBDNNACBAK.MBMMGKJBJGD> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.GGKFCDDFHFP.FindAll((HPBDNNACBAK.MBMMGKJBJGD x) =>
						{
							//0x1BADA00
							return x.PPFNGGCBJKC_Id == t.GJDNBENICPF_VcId;
						});
						for(int i = 0; i < l.Count; i++)
						{
							NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
							data.HNKFMAJIFJD_ExpireAt = (int)l[i].DJJENNPDPCM_ExpireAt;
							data.HMFFHLPNMPH_Remaining = l[i].HNBFOAJIIAL_Remaining;
							res.Add(data);
						}
					}
				}
				else if(itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem)
				{
					return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.MCPIBDPKBBD(currentTime);
				}
			}
			else
			{
				if (itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
				{
					return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.BNGLMLIMFDM(EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId), currentTime);
				}
				else if (itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem)
				{
					return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.BNGLMLIMFDM(EKLNMHFCAOI.DEACAHNLMNI_getItemId(typeItemId), currentTime);
				}
			}
			return res;
		}

		// RVA: 0x1BAD578 Offset: 0x1BAD578 VA: 0x1BAD578 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAD580 Offset: 0x1BAD580 VA: 0x1BAD580 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
			m_layoutPeriod.UpdateAllAnimation(TimeWrapper.deltaTime);
			m_layoutPeriod.UpdateAll(m_identity, Color.white);
		}

		// RVA: 0x1BAD688 Offset: 0x1BAD688 VA: 0x1BAD688 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAD6C0 Offset: 0x1BAD6C0 VA: 0x1BAD6C0 Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1BAD6C8 Offset: 0x1BAD6C8 VA: 0x1BAD6C8 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}
	}
}
