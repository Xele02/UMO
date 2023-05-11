
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckGaugePopupSetting : PopupSettingUGUI
	{
		public override string PrefabPath { get { return ""; } } //0xA6E36C
		public override string BundleName { get { return "ly/013.xab"; } } //0xA6E3C8
		public override string AssetName { get { return "SetDeckGaugePopup"; } } //0xA6E424
		public override bool IsAssetBundle { get { return true; } } //0xA6E480
		public override bool IsPreload { get { return false; } } //0xA6E488
		public override GameObject Content { get { return m_content; } } //0xA6E490

		// RVA: 0xA6E498 Offset: 0xA6E498 VA: 0xA6E498
		//public void SetContent(GameObject obj) { }
	}
}
