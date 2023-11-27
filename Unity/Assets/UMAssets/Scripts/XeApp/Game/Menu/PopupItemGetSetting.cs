
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupItemGetSetting : PopupSetting
	{
		public int ItemId { get; set; } // 0x34
		public int Count { get; set; } // 0x38
		public bool IsPresentBox { get; set; } // 0x3C
		public string ItemContent { get; set; } // 0x40
		public override string PrefabPath { get { return "ly/root_sel_que_achieve_pop_layout_root"; } } //0x17AC678
		public override string BundleName { get { return "ly/115.xab"; } } //0x17AC6D4
		public override string AssetName { get { return "root_sel_que_achieve_pop_layout_root"; } } //0x17AC750
		public override bool IsAssetBundle { get { return true; } } //0x17AC7AC
		public override bool IsPreload { get { return false; } } //0x17AC7B4
		public override GameObject Content { get { return m_content; } } //0x17AC7BC

		// RVA: 0x17AC730 Offset: 0x17AC730 VA: 0x17AC730
		public PopupItemGetSetting()
		{
			Count = 0;
		}

		//// RVA: 0x17AC7C4 Offset: 0x17AC7C4 VA: 0x17AC7C4
		//public void SetContent(GameObject obj) { }
	}
}
