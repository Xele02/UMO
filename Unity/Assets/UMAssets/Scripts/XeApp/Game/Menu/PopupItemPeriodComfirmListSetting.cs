
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupItemPeriodComfirmListSetting : PopupSetting
	{
		public int TypeItemId { get; set; } // 0x34
		public List<NKFJNAANPNP.MOJLCADLMKH> List { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x17AE93C
		public override string BundleName { get { return "ly/131.xab"; } } //0x17AE998
		public override string AssetName { get { return "root_pop_rerity_rimit_03_layout_root"; } } //0x17AE9F4
		public override bool IsAssetBundle { get { return true; } } //0x17AEA50
		public override bool IsPreload { get { return false; } } //0x17AEA58
		public override GameObject Content { get { return m_content; } } //0x17AEA60

		//// RVA: 0x17AEA68 Offset: 0x17AEA68 VA: 0x17AEA68
		//public void SetContent(GameObject obj) { }
	}
}
