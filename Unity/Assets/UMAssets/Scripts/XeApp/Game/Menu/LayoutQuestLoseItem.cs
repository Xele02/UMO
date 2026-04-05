using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutQuestLoseItem : LayoutQuestRewardItem
	{
		
		[SerializeField]
		private Text m_textName; // 0x30
		[SerializeField]
		private Text m_textRecvNum; // 0x34
		[SerializeField]
		private Text m_textLoseNum; // 0x38

		// RVA: 0x187B9C0 Offset: 0x187B9C0 VA: 0x187B9C0 Slot: 6
		public override void SetStatus(MFDJIFIIPJD info)
		{
			base.SetStatus(info);
			m_textName.text = EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemId);
			int value = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId, null);
			int max = EKLNMHFCAOI_ItemManager.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId, null);
			int d = info.MBJIFDBEDAC_item_count - max + Mathf.Clamp(value, 0, max);
			m_textRecvNum.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_quest_receive_get"), Mathf.Clamp(info.MBJIFDBEDAC_item_count - d, 0, max).ToString() + EKLNMHFCAOI_ItemManager.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId));
			m_textLoseNum.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_quest_receive_lose"), d, EKLNMHFCAOI_ItemManager.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId));
		}

		// RVA: 0x187BF70 Offset: 0x187BF70 VA: 0x187BF70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}
	}
}
