using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutOfferItemDetail : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text ItemNameText; // 0x14
		[SerializeField]
		private Text ItemDetailText; // 0x18
		[SerializeField]
		private RawImageEx ItemImage; // 0x1C
		private AbsoluteLayout icon; // 0x20

		// RVA: 0x15D4A00 Offset: 0x15D4A00 VA: 0x15D4A00
		public void popSetUp(string name, string detail, int itemId, bool IsSecret)
		{
			ItemNameText.text = name;
			ItemDetailText.text = detail;
			icon.StartChildrenAnimGoStop(IsSecret ? "02" : "01");
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
			{
				//0x15D4CAC
				ItemImage.enabled = true;
				image.Set(ItemImage);
			});
		}

		// RVA: 0x15D4BB8 Offset: 0x15D4BB8 VA: 0x15D4BB8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			icon = layout.FindViewByExId("sw_item_detail_swtbl_item") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
