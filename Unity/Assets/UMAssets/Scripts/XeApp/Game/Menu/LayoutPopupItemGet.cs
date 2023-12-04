using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupItemGet : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_ItemName; // 0x14
		[SerializeField]
		private Text m_ItemContent; // 0x18
		[SerializeField]
		private RawImageEx m_imageItem; // 0x1C
		private AbsoluteLayout m_layoutTable; // 0x20
		private AbsoluteLayout m_queGetFnt; // 0x24

		// RVA: 0x172E1EC Offset: 0x172E1EC VA: 0x172E1EC
		public void SetStatus(int itemId, bool isPresentBox, int count = 0, string content = null)
		{
			if(count == 0)
				m_ItemName.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId);
			else
				m_ItemName.text = string.Format(JpStringLiterals.StringLiteral_15697, EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId), count, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId)));
			m_ItemContent.text = content;
			m_layoutTable.StartChildrenAnimGoStop(content == null ? "01" : "02");
			m_queGetFnt.StartChildrenAnimGoStop(isPresentBox ? "02" : "01");
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
			{
				//0x172E680
				m_imageItem.enabled = true;
				image.Set(m_imageItem);
			});
		}

		// RVA: 0x172E510 Offset: 0x172E510 VA: 0x172E510
		public bool IsLoading()
		{
			return !IsLoaded();
		}

		// RVA: 0x172E528 Offset: 0x172E528 VA: 0x172E528 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutTable = layout.FindViewById("sw_sel_que_achieve") as AbsoluteLayout;
			m_queGetFnt = layout.FindViewById("swtbl_sel_que_get_fnt") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
