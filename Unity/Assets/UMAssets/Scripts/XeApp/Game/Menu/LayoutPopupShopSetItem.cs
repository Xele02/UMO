using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System;
using XeSys;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupShopSetItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_textName; // 0x20
		[SerializeField]
		private Text m_textNum; // 0x24
		[SerializeField]
		private RawImageEx m_imageItem; // 0x28
		[SerializeField]
		private StayButton m_button; // 0x2C
		private int m_index; // 0x30
		private int m_itemId; // 0x38

		public Action<int> OnSelectCallback { get; set; } // 0x34

		// // RVA: 0x1788AE8 Offset: 0x1788AE8 VA: 0x1788AE8
		// public bool IsIconLoaded() { }

		// // RVA: 0x1787194 Offset: 0x1787194 VA: 0x1787194
		public void SetStatus(BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo data, int index)
		{
			m_index = index;
			int fullId = data.FKNBLDPIPMC_GetItemCode(index);
            EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(fullId);
            int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(fullId);
			int a = data.NKOHMLHLJGL_GetItemCount(index);
			SetItemImage(fullId);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string name = EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(cat, id);
			int max = EKLNMHFCAOI_ItemManager.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
			int num = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
			if(max < num + a)
			{
				name = RichTextUtility.MakeColorTagString(name, SystemTextColor.ImportantColor);
			}
			m_textName.text = name;
			m_textNum.text = a + EKLNMHFCAOI_ItemManager.NDBLEADIDLA(cat, id);
		}

		// // RVA: 0x1788B30 Offset: 0x1788B30 VA: 0x1788B30
		private void SetItemImage(int itemId)
		{
			m_itemId = itemId;
			m_imageItem.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x1788F04
				if(m_imageItem == null)
					return;
				if(m_itemId != itemId)
					return;
				m_imageItem.enabled = true;
				icon.Set(m_imageItem);
			});
		}

		// RVA: 0x1788CE8 Offset: 0x1788CE8 VA: 0x1788CE8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x1788E24
				if(OnSelectCallback != null)
					OnSelectCallback(m_index);
			});
			m_button.AddOnStayCallback(() =>
			{
				//0x1788E94
				if(OnSelectCallback != null)
					OnSelectCallback(m_index);
			});
			Loaded();
			return true;
		}
	}
}
