using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutShopListItem : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textLimit; // 0x20
		[SerializeField]
		private Text m_textGetLimit; // 0x24
		[SerializeField]
		private Text m_textName; // 0x28
		[SerializeField]
		private Text m_textMedal; // 0x2C
		[SerializeField]
		private Text m_textClose; // 0x30
		[SerializeField]
		private RawImageEx[] m_imageMedal; // 0x34
		[SerializeField]
		private ActionButton m_button; // 0x38
		private AbsoluteLayout m_layoutLimit; // 0x3C
		private AbsoluteLayout m_layoutNew; // 0x40
		private AbsoluteLayout m_layoutMedal; // 0x44
		private TexUVListManager m_uvMan; // 0x48
		private TextureListSupport m_texListSupport; // 0x4C
		private AODFBGCCBPE m_view; // 0x50

		public AODFBGCCBPE View { get { return m_view; } } //0x193FEC0
		protected override ButtonBase selectButton { get { return m_button; } } //0x193FEC8

		//// RVA: 0x193FED0 Offset: 0x193FED0 VA: 0x193FED0
		//public bool IsLoaded() { }

		// RVA: 0x193FF78 Offset: 0x193FF78 VA: 0x193FF78
		public void SetStatus(AODFBGCCBPE view)
		{
			m_view = view;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textClose.text = bk.GetMessageByLabel("item_shop_closed");
			m_button.Disable = view.MHKCPJDNJKI.Count < 1;
			m_textName.text = view.NEMKDKDIIDK;
			if(view.NEMKDKDIIDK.Length < 11)
			{
				m_textName.horizontalOverflow = HorizontalWrapMode.Overflow;
				m_textName.resizeTextForBestFit = false;
			}
			else
			{
				m_textName.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_textName.resizeTextForBestFit = true;
			}
			if(!view.FPJBMCDMAMO)
			{
				m_layoutLimit.StartChildrenAnimGoStop("limit_off");
			}
			else
			{
				DateTime date = Utility.GetLocalDateTime(view.GJFPFFBAKGK);
				m_textLimit.text = string.Format(bk.GetMessageByLabel("item_shop_period"), new object[4]
					{
						date.Month, date.Day, date.Hour, date.Minute
					});
				m_layoutLimit.StartChildrenAnimGoStop("limit_on");
			}
			m_layoutNew.enabled = view.CADENLBDAEB;
			if(view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3)
			{
				m_layoutMedal.StartChildrenAnimGoStop("coin_off");
			}
			else
			{
				m_textMedal.text = view.JJPAFPIOBCK_GetCount().ToString();
				if(!view.HKKPNKOIOKL)
				{
					m_layoutMedal.StartChildrenAnimGoStop("coin_on");
				}
				else
				{
					DateTime date = Utility.GetLocalDateTime(view.GIOIPNIMAIG);
					m_textGetLimit.text = string.Format(bk.GetMessageByLabel("item_shop_get_period"), new object[4]
						{
						date.Month, date.Day, date.Hour, date.Minute
						});
					m_layoutMedal.StartChildrenAnimGoStop("coin_on_get");
				}
			}
			m_imageMedal[1].enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.EAHPLCJMPHD_PayItemId, (IiconTexture image) =>
			{
				//0x1940F38
				m_imageMedal[1].enabled = true;
				image.Set(m_imageMedal[1]);
			});
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.EAHPLCJMPHD_PayItemId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.EAHPLCJMPHD_PayItemId);
			if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
			{
				if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
				{
					if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
						return;
					m_texListSupport.SetImage(m_imageMedal[0], string.Format("cmn_evecoin_icon_{0:D2}", id));
				}
				else
				{
					m_texListSupport.SetImage(m_imageMedal[0], "cmn_coin_icon");
				}
			}
			else
			{
				if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
				{
					if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
					{
						return;
					}
					m_texListSupport.SetImage(m_imageMedal[0], string.Format("cmn_sphere_icon_{0:D2}", id));
				}
				else
				{
					if(id == 7)
					{
						m_texListSupport.SetImage(m_imageMedal[0], "cmn_raid_icon");
					}
					else if(id == 15)
					{
						m_texListSupport.SetImage(m_imageMedal[0], "cmn_ticket_icon_05");
					}
					else if(id == 8)
					{
						m_texListSupport.SetImage(m_imageMedal[0], "cmn_deco_icon");
					}
				}
			}
		}

		// RVA: 0x1940D44 Offset: 0x1940D44 VA: 0x1940D44 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_texListSupport = GetComponent<TextureListSupport>();
			m_layoutLimit = layout.FindViewById("swtbl_limit") as AbsoluteLayout;
			m_layoutNew = layout.FindViewById("swtbl_icon_new") as AbsoluteLayout;
			m_layoutMedal = layout.FindViewById("swtbl_sel_shop_btn") as AbsoluteLayout;
			Loaded();
			return true;
		}
    }
}
