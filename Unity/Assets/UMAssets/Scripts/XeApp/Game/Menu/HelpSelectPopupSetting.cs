
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class HelpSelectPopupSetting : PopupSetting
	{
		public int uniqueId { get; set; } // 0x34
		public bool IsWiki { get; set; } // 0x38
		public bool IsDefault { get; set; } // 0x39
		public override string PrefabPath { get { return ""; } } //0x9559B4
		public override string BundleName { get { return "ly/091.xab"; } } //0x955A10
		public override string AssetName { get { return "PopupHelpWindow"; } } //0x955A6C
		public override bool IsAssetBundle { get { return true; } } //0x955AC8
		public override bool IsPreload { get { return true; } } //0x955AD0
		public override GameObject Content { get { return m_content; } } //0x955AD8

		//// RVA: 0x9544DC Offset: 0x9544DC VA: 0x9544DC
		//public void SetContent(GameObject obj) { }
	}
}
