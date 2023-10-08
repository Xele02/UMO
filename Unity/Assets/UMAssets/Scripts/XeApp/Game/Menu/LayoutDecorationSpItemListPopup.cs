using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpItemListPopup : FlexibleListItemLayout
	{
		public static readonly string AssetName = "SelectListContent"; // 0x0
		[SerializeField]
		private ActionButton m_itemButton; // 0x18
		[SerializeField]
		private RawImageEx m_itemImage; // 0x1C
		[SerializeField]
		private Text m_nameText; // 0x20
		[SerializeField]
		private Text m_numText; // 0x24
		private int m_itemId; // 0x28
		private bool m_isLoadedTexture; // 0x2C

		// RVA: 0x18BAA04 Offset: 0x18BAA04 VA: 0x18BAA04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_itemButton.AddOnClickCallback(() =>
			{
				//0x18BAF14
				ShowPopupItemDetail();
			});
			return true;
		}

		// // RVA: 0x18BAAB0 Offset: 0x18BAAB0 VA: 0x18BAAB0
		public void Setting(int id, int num)
		{
			m_itemId = id;
			LoadItem();
			SetItem(id);
			SetItemNum(id, num);
		}

		// // RVA: 0x18BAC04 Offset: 0x18BAC04 VA: 0x18BAC04
		private void SetItem(int id)
		{
			m_nameText.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(id);
		}

		// // RVA: 0x18BACBC Offset: 0x18BACBC VA: 0x18BACBC
		private void SetItemNum(int id, int num)
		{
			m_numText.text = num.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(id));
		}

		// // RVA: 0x18BADC0 Offset: 0x18BADC0 VA: 0x18BADC0
		// public bool IsLoading() { }

		// // RVA: 0x18BADD4 Offset: 0x18BADD4 VA: 0x18BADD4
		// public bool IsPlayingEnd() { }

		// // RVA: 0x18BAAEC Offset: 0x18BAAEC VA: 0x18BAAEC
		private void LoadItem()
		{
			m_isLoadedTexture = false;
			MenuScene.Instance.ItemTextureCache.Load(m_itemId, (IiconTexture texture) =>
			{
				//0x18BAF18
				texture.Set(m_itemImage);
				m_isLoadedTexture = true;
			});
		}

		// // RVA: 0x18BADDC Offset: 0x18BADDC VA: 0x18BADDC
		private void ShowPopupItemDetail()
		{
			MenuScene.Instance.ShowItemDetail(m_itemId, m_itemId, null);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6D6C8C Offset: 0x6D6C8C VA: 0x6D6C8C
		// // RVA: 0x18BAF18 Offset: 0x18BAF18 VA: 0x18BAF18
		// private void <LoadItem>b__13_0(IiconTexture texture) { }
	}
}
