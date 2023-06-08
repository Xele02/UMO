
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOverlapListSetting : PopupSetting
	{
		public GONMPHKGKHI_RewardView.CECMLGBLHHG Type { get; set; } // 0x34
		public List<GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo> List { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x1609E1C
		public override string BundleName { get { return "ly/074.xab"; } } //0x1609E78
		public override string AssetName { get { return "root_pop_overlap_win_layout_root"; } } //0x1609ED4
		public override bool IsAssetBundle { get { return true; } } //0x1609F30
		public override bool IsPreload { get { return false; } } //0x1609F38
		public override GameObject Content { get { return m_content; } } //0x1609F40

		//// RVA: 0x1609F48 Offset: 0x1609F48 VA: 0x1609F48
		//public void SetContent(GameObject obj) { }
	}
}
