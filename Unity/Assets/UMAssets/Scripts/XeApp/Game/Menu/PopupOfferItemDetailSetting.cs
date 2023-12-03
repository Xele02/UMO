
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupOfferItemDetailSetting : PopupSetting
	{
		public bool IsSecret; // 0x34
		public string ItemName; // 0x38
		public string ItemDetail; // 0x3C
		public int ItemId; // 0x40

		public override string PrefabPath { get { return ""; } } //0x169DF54
		public override string BundleName { get { return "ly/149.xab"; } } //0x169DFB0
		public override string AssetName { get { return "root_pop_vfo_item_detail_layout_root"; } } //0x169E00C
		public override bool IsAssetBundle { get { return true; } } //0x169E068
		public override bool IsPreload { get { return false; } } //0x169E070
		public override GameObject Content { get { return m_content; } } //0x169E078

		//// RVA: 0x169E080 Offset: 0x169E080 VA: 0x169E080
		//public void SetContent(GameObject obj) { }
	}
}
