using System;
using System.Linq;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupCampaignPrizeItem : FlexibleListItemLayout
	{
		private RawImageEx m_imageItem; // 0x18
		private StayButton m_button; // 0x1C
		private Text m_textItemName; // 0x20
		private Text m_textItemNum; // 0x24
		private MFDJIFIIPJD m_itemInfo; // 0x28
		public Action OnClickButton; // 0x2C

		// RVA: 0x15E9EDC Offset: 0x15E9EDC VA: 0x15E9EDC
		public void Setup(MFDJIFIIPJD info)
		{
			m_itemInfo = info;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(info.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				m_textItemName.text = string.Format(bk.GetMessageByLabel("popup_event_reward_platetitle"), EKLNMHFCAOI.APDHLDGBENB(info.JJBGOIMEIPF_ItemId), EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId));
			}
			else
			{
				m_textItemName.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId);
			}
			string s = EKLNMHFCAOI.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId);
			if(!string.IsNullOrEmpty(s))
			{
				m_textItemNum.text = info.MBJIFDBEDAC_Cnt.ToString() + s;
			}
			else
			{
				m_textItemNum.text = "";
			}
			m_imageItem.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(info.JJBGOIMEIPF_ItemId, (IiconTexture texture) =>
			{
				//0x15EA7D8
				m_imageItem.enabled = true;
				texture.Set(m_imageItem);
			});
		}

		// RVA: 0x15EA2A4 Offset: 0x15EA2A4 VA: 0x15EA2A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime l = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = l.GetComponentsInChildren<RawImageEx>();
			m_imageItem = imgs.Where((RawImageEx _) =>
			{
				//0x15EA96C
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			Text[] txts = l.GetComponentsInChildren<Text>();
			m_textItemNum = txts.Where((Text _) =>
			{
				//0x15EA9EC
				return _.name == "item_num (TextView)";
			}).First();
			m_textItemName = txts.Where((Text _) =>
			{
				//0x15EAA6C
				return _.name == "item_name (TextView)";
			}).First();
			m_textItemName.resizeTextForBestFit = true;
			m_textItemName.resizeTextMaxSize = 22;
			m_textItemName.horizontalOverflow = UnityEngine.HorizontalWrapMode.Wrap;
			m_textItemName.verticalOverflow = UnityEngine.VerticalWrapMode.Truncate;
			m_button = l.GetComponentInChildren<StayButton>();
			m_button.AddOnClickCallback(() =>
			{
				//0x15EA8DC
				if(OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}
	}
}
