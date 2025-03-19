using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupLoginBonusPackItem : SwapScrollListContent
	{
		public const int InvokeId_Select = 0;
		private RawImageEx m_imageItem; // 0x20
		private StayButton m_button; // 0x24
		private Text m_textItemName; // 0x28
		private Text m_textItemNum; // 0x2C
		private MFDJIFIIPJD m_itemInfo; // 0x30
		public Action OnClickButton; // 0x34

		// RVA: 0x172FA84 Offset: 0x172FA84 VA: 0x172FA84
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
				m_textItemNum.text = info.MBJIFDBEDAC_Cnt + s;
			}
			else
			{
				m_textItemNum.text = "";
			}
			m_imageItem.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(info.JJBGOIMEIPF_ItemId, (IiconTexture texture) =>
			{
				//0x1730380
				m_imageItem.enabled = true;
				texture.Set(m_imageItem);
			});
		}

		// RVA: 0x172FE4C Offset: 0x172FE4C VA: 0x172FE4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime r = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = r.GetComponentsInChildren<RawImageEx>();
			m_imageItem = imgs.Where((RawImageEx _) =>
			{
				//0x1730514
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			Text[] txts = r.GetComponentsInChildren<Text>();
			m_textItemNum = txts.Where((Text _) =>
			{
				//0x1730594
				return _.name == "item_num (TextView)";
			}).First();
			m_textItemName = txts.Where((Text _) =>
			{
				//0x1730614
				return _.name == "item_name (TextView)";
			}).First();
			m_textItemName.resizeTextForBestFit = true;
			m_textItemName.resizeTextMaxSize = 22;
			m_textItemName.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_textItemName.verticalOverflow = VerticalWrapMode.Truncate;
			m_button = r.GetComponentInChildren<StayButton>();
			m_button.AddOnClickCallback(() =>
			{
				//0x1730484
				if (OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}
	}
}
