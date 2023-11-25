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
			m_textName.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(info.JJBGOIMEIPF_ItemFullId);
			int value = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId, null);
			int max = EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId, null);
			int d = info.MBJIFDBEDAC_Cnt - max + Mathf.Clamp(value, 0, max);
			m_textRecvNum.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_quest_receive_get"), Mathf.Clamp(info.MBJIFDBEDAC_Cnt - d, 0, max).ToString() + EKLNMHFCAOI.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId));
			m_textLoseNum.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_quest_receive_lose"), d, EKLNMHFCAOI.NDBLEADIDLA(info.NPPNDDMPFJJ_ItemCategory, info.NNFNGLJOKKF_ItemId));
		}

		// RVA: 0x187BF70 Offset: 0x187BF70 VA: 0x187BF70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}
	}
}
