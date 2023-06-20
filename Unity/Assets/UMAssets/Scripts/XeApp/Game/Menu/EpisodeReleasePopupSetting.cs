
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class EpisodeReleasePopupSetting : PopupSetting
	{
		public PIGBBNDPPJC data { get; set; } // 0x34
		public int item_type { get; set; } // 0x38
		public int item_count { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0xEF945C
		public override string BundleName { get { return "ly/052.xab"; } } //0xEF94B8
		public override string AssetName { get { return "PopupEpisodeRelease"; } } //0xEF9514
		public override bool IsAssetBundle { get { return true; } } //0xEF9570
		public override bool IsPreload { get { return true; } } //0xEF9578
		public override GameObject Content { get { return m_content; } } //0xEF9580

		//// RVA: 0xEF8448 Offset: 0xEF8448 VA: 0xEF8448
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
