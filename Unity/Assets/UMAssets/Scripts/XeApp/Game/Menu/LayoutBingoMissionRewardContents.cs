using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMissionRewardContents : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx ItemIcon; // 0x20
		[SerializeField]
		private Text MissionText; // 0x24
		[SerializeField]
		private Text ItemName; // 0x28

		// RVA: 0x14C5D40 Offset: 0x14C5D40 VA: 0x14C5D40
		private void Start()
		{
			return;
		}

		// RVA: 0x14C5D44 Offset: 0x14C5D44 VA: 0x14C5D44
		private void Update()
		{
			return;
		}

		// RVA: 0x14C5D48 Offset: 0x14C5D48 VA: 0x14C5D48
		public void Setup(int _itemId, int _itemCount, string _missionText, Action<int> textureLoadedAct)
		{
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_itemId);
            int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_itemId);
			string itemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, itemId);
			string itemStr = EKLNMHFCAOI.NDBLEADIDLA(cat, 0);
			MissionText.text = _missionText;
			ItemName.text = itemName+"   "+_itemCount + itemStr;
			GameManager.Instance.ItemTextureCache.Load(ItemTextureCache.MakeItemIconTexturePath(_itemId, 0), (IiconTexture icon) =>
			{
				//0x14C5FEC
				icon.Set(ItemIcon);
				textureLoadedAct(Index);
			});
		}

		// RVA: 0x14C5FCC Offset: 0x14C5FCC VA: 0x14C5FCC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
