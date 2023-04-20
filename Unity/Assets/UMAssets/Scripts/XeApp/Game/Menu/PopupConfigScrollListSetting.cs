
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupConfigScrollListSetting : PopupSetting
	{
		public GameObject ListContents { get; set; } // 0x34
		//public ConfigMenu.eType ConfigType { get; set; } // 0x38
		//public LayoutPopupConfigScrollList.LayoutType LayoutType { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x1340DC0
		public override string BundleName { get { return "ly/072.xab"; } } //0x1340E1C
		public override string AssetName { get { return "root_cmn_con_space_pop_layout_root"; } } //0x1340E78
		public override bool IsAssetBundle { get { return true; } } //0x1340ED4
		public override bool IsPreload { get { return true; } } //0x1340EDC
		public override GameObject Content { get { return m_content; } } //0x1340EE4

		//// RVA: 0x1340EEC Offset: 0x1340EEC VA: 0x1340EEC
		//public void SetContent(GameObject obj) { }
	}
}
