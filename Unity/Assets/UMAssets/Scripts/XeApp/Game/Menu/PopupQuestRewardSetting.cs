
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupQuestRewardSetting : PopupSetting
	{
		public MFDJIFIIPJD ItemInfo { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x1611EE4
		public override string BundleName { get { return "ly/059.xab"; } } //0x1611F40
		public override string AssetName { get { return "root_sel_que_achieve_pop_layout_root"; } } //0x1611F9C
		public override bool IsAssetBundle { get { return true; } } //0x1611FF8
		public override bool IsPreload { get { return false; } } //0x1612000
		public override GameObject Content { get { return m_content; } } //0x1612008

		//// RVA: 0x1612010 Offset: 0x1612010 VA: 0x1612010
		//public void SetContent(GameObject obj) { }
	}
}
