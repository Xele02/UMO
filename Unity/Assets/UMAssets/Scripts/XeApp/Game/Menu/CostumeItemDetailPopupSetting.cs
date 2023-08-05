
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class CostumeItemDetailPopupSetting : PopupSetting
	{
		public LFAFJCNKLML data; // 0x34
		public int lv; // 0x38

		public override string PrefabPath { get { return ""; } } //0x162FF1C
		public override string BundleName { get { return "ly/128.xab"; } } //0x162FF78
		public override string AssetName { get { return "PopupCostumeItemDetail"; } } //0x162FFD4
		public override bool IsAssetBundle { get { return true; } } //0x1630030
		public override bool IsPreload { get { return true; } } //0x1630038
		public override GameObject Content { get { return m_content; } } //0x1630040

		//// RVA: 0x1630048 Offset: 0x1630048 VA: 0x1630048
		//public void SetContent(GameObject obj) { }
	}
}
