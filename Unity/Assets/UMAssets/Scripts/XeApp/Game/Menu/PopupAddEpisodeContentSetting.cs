
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddEpisodeContentSetting : PopupSetting
	{
		public int EpisodeId { get; set; } // 0x34
		public LayoutPopupAddEpisode.Type Type { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x132ED0C
		public override string BundleName { get { return "ly/057.xab"; } } //0x132ED68
		public override string AssetName { get { return "root_pop_ep_layout_root"; } } //0x132EDC4
		public override bool IsAssetBundle { get { return true; } } //0x132EE20
		public override bool IsPreload { get { return true; } } //0x132EE28
		public override GameObject Content { get { return m_content; } } //0x132EE30

		//// RVA: 0x132EE38 Offset: 0x132EE38 VA: 0x132EE38
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
