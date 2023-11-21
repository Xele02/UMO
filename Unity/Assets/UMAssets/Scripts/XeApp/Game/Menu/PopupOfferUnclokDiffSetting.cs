
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupOfferUnclokDiffSetting : PopupSetting
	{
		public string popupMsg; // 0x34
		public int preDiff; // 0x38
		public int nextDiff; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x169E590
		public override string BundleName { get { return "ly/148.xab"; } } //0x169E5EC
		public override string AssetName { get { return "root_pop_vfo_01_layout_root"; } } //0x169E648
		public override bool IsAssetBundle { get { return true; } } //0x169E6A4
		public override bool IsPreload { get { return false; } } //0x169E6AC
		public override GameObject Content { get { return m_content; } } //0x169E6B4

		//// RVA: 0x169E6BC Offset: 0x169E6BC VA: 0x169E6BC
		//public void SetContent(GameObject obj) { }
	}
}
