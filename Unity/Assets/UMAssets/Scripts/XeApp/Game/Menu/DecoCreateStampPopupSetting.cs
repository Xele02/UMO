
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class DecoCreateStampPopupSetting : PopupSetting
	{
		public int charactorId { get; set; } // 0x34
		public int serifId { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0xC59D44
		public override string BundleName { get { return "ly/206.xab"; } } //0xC59DA0
		public override string AssetName { get { return "root_cstm_deco_pop_01_layout_root"; } } //0xC59DFC
		public override bool IsAssetBundle { get { return true; } } //0xC59E58
		public override bool IsPreload { get { return true; } } //0xC59E60
		public override GameObject Content { get { return m_content; } } //0xC59E68

		//// RVA: 0xC59E70 Offset: 0xC59E70 VA: 0xC59E70
		//public void SetContent(GameObject obj) { }
	}
}
