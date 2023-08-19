
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class ValkyriePopupSetting : PopupSetting
	{
		public ALEKLHIANJN before_data { get; set; } // 0x34
		public ALEKLHIANJN after_data { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x1655D00
		public override string BundleName { get { return "ly/045.xab"; } } //0x1655D5C
		public override string AssetName { get { return "PopupValkyrieSkillUp"; } } //0x1655DB8
		public override bool IsAssetBundle { get { return true; } } //0x1655E14
		public override bool IsPreload { get { return true; } } //0x1655E1C
		public override GameObject Content { get { return m_content; } } //0x1655E24

		//// RVA: 0x1655E2C Offset: 0x1655E2C VA: 0x1655E2C
		//public void SetContent(GameObject obj) { }
	}
}
