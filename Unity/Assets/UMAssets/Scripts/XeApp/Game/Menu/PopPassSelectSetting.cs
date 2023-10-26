
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopPassSelectSetting : PopupSetting
	{
		public Action OnClickNormal { get; set; } // 0x34
		public Action OnClickLoginBonus { get; set; } // 0x38
		public Action OnClickSpecial { get; set; } // 0x3C
		public bool EnableNormalPlan { get; set; } // 0x40
		public override string PrefabPath { get { return ""; } } //0xDF0464
		public override string BundleName { get { return "ly/150.xab"; } } //0xDF04C0
		public override string AssetName { get { return "root_pop_pass_banner_layout_root"; } } //0xDF051C
		public override bool IsAssetBundle { get { return true; } } //0xDF0578
		public override bool IsPreload { get { return false; } } //0xDF0580
		public override GameObject Content { get { return m_content; } } //0xDF0588

		//// RVA: 0xDF0590 Offset: 0xDF0590 VA: 0xDF0590
		//public void SetContent(GameObject obj) { }
	}
}
