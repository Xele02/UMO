
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRecordPlateOverlapSetting : PopupSetting
	{
		public GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo RareUpInfo { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x161B748
		public override string BundleName { get { return "ly/073.xab"; } } //0x161B7A4
		public override string AssetName { get { return "root_gacha_overlap_layout_root"; } } //0x161B800
		public override bool IsAssetBundle { get { return true; } } //0x161B85C
		public override bool IsPreload { get { return true; } } //0x161B864
		public override GameObject Content { get { return m_content; } } //0x161B86C

		//// RVA: 0x161B874 Offset: 0x161B874 VA: 0x161B874
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
