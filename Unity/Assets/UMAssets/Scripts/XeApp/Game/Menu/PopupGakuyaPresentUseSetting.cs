
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGakuyaPresentUseSetting : PopupSettingUGUI
	{
		public OJEGDIBEBHP m_divaPresentData; // 0x34

		public override string PrefabPath { get { return ""; } } //0x17A7CB0
		public override string BundleName { get { return "ly/081.xab"; } } //0x17A7D0C
		public override string AssetName { get { return "GakuyaPopupPresentUse"; } } //0x17A7D68
		public override bool IsAssetBundle { get { return true; } } //0x17A7DC4
		public override bool IsPreload { get { return false; } } //0x17A7DCC
		public override GameObject Content { get { return m_content; } } //0x17A7DD4

		//// RVA: 0x17A7DDC Offset: 0x17A7DDC VA: 0x17A7DDC
		//public void SetContent(GameObject obj) { }
	}
}
