
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDivaLevelupSetting : PopupSetting
	{
		public FFHPBEPOMAK_DivaInfo beforeDivaData; // 0x34
		public FFHPBEPOMAK_DivaInfo afterDivaData; // 0x38

		public override string PrefabPath { get { return ""; } } //0xF82098
		public override string BundleName { get { return "ly/025.xab"; } } //0xF820F4
		public override string AssetName { get { return "root_dlvup_layout_root"; } } //0xF82150
		public override bool IsAssetBundle { get { return true; } } //0xF821AC
		public override bool IsPreload { get { return false; } } //0xF821B4
		public override GameObject Content { get { return m_content; } } //0xF821BC

		//// RVA: 0xF821C4 Offset: 0xF821C4 VA: 0xF821C4
		//public void SetContent(GameObject obj) { }
	}
}
