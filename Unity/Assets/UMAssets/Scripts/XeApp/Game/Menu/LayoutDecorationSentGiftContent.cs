using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSentGiftContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_itemImage; // 0x14
		[SerializeField]
		private StayButton m_button; // 0x18
		[SerializeField]
		private Text m_message; // 0x1C
		[SerializeField]
		private Text m_resultMessage; // 0x20
		private int m_itemId; // 0x24

		// RVA: 0x18B8364 Offset: 0x18B8364 VA: 0x18B8364 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x18B837C Offset: 0x18B837C VA: 0x18B837C
		public void UpdateContent(int itemId, int itemCount, int sentCount)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_button.ClearOnClickCallback();
			m_button.ClearOnStayCallback();
			m_itemId = itemId;
			m_button.AddOnClickCallback(ShowItemDetails);
			m_button.AddOnStayCallback(ShowItemDetails);
			m_message.text = string.Format(bk.GetMessageByLabel(sentCount < 2 ? "pop_deco_gift_single_message" : "pop_deco_gift_multi_message"), sentCount);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
            m_resultMessage.text = string.Format(bk.GetMessageByLabel("pop_deco_gift_item_message"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, id), itemCount, EKLNMHFCAOI.NDBLEADIDLA(cat, id));
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x18B8884
				texture.Set(m_itemImage);
			});
		}

		// // RVA: 0x18B87C0 Offset: 0x18B87C0 VA: 0x18B87C0
		private void ShowItemDetails()
		{
			MenuScene.Instance.ShowItemDetail(m_itemId, 0, null);
		}
	}
}
