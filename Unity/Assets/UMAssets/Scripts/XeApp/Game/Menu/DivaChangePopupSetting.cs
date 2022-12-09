
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaChangePopupSetting : PopupSettingUGUI
	{
		public override string PrefabPath { get { return ""; } } //0x17D28DC
		public override string BundleName { get { return "ly/013.xab"; } } //0x17D2938
		public override string AssetName { get { return "DivaChangePopup"; } } //0x17D2994
		public override bool IsAssetBundle { get { return true;  } } //0x17D29F0
		public override bool IsPreload { get { return false; } } //0x17D29F8
		public override GameObject Content { get { return m_content; } } //0x17D2A00
		public FFHPBEPOMAK AfterDiva { get; set; } // 0x34
		public FFHPBEPOMAK BeforeDiva { get; set; } // 0x38

		//// RVA: 0x17D2A08 Offset: 0x17D2A08 VA: 0x17D2A08
		//public void SetContent(GameObject obj) { }
	}
}
