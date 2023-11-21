
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupOfferUnclokPlattonSetting : PopupSetting
	{
		public int nextPlatoonNum; // 0x34
		public int ReleasePlatoonNum = -1; // 0x38

		public override string PrefabPath { get { return ""; } } //0x169E6CC
		public override string BundleName { get { return "ly/148.xab"; } } //0x169E728
		public override string AssetName { get { return "root_pop_vfo_02_layout_root"; } } //0x169E784
		public override bool IsAssetBundle { get { return true; } } //0x169E7E0
		public override bool IsPreload { get { return false; } } //0x169E7E8
		public override GameObject Content { get { return m_content; } } //0x169E7F0

		//// RVA: 0x169E7F8 Offset: 0x169E7F8 VA: 0x169E7F8
		//public void SetContent(GameObject obj) { }
	}
}
