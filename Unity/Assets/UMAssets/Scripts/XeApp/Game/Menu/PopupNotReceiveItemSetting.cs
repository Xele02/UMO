
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupNotReceiveItemSetting : PopupSetting
	{
		public string DescText; // 0x34
		public int ItemId; // 0x38
		public int ItemCount; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x169D578
		public override string BundleName { get { return "ly/145.xab"; } } //0x169D5D4
		public override string AssetName { get { return "root_noget_pop_layout_root"; } } //0x169D630
		public override bool IsAssetBundle { get { return true; } } //0x169D68C
		public override bool IsPreload { get { return false; } } //0x169D694
		public override GameObject Content { get { return m_content; } } //0x169D69C

		//// RVA: 0x169D6A4 Offset: 0x169D6A4 VA: 0x169D6A4
		//public void SetContent(GameObject obj) { }
	}
}
