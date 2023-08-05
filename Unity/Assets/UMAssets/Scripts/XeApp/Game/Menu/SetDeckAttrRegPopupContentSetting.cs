
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class SetDeckAttrRegPopupContentSetting : PopupSettingUGUI
	{
		public GameAttribute.Type MusicAttribute { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0xA69F84
		public override string BundleName { get { return "ly/013.xab"; } } //0xA69FE8
		public override string AssetName { get { return "SetDeckAttrRegPopup"; } } //0xA6A044
		public override bool IsAssetBundle { get { return true; } } //0xA6A0A0
		public override bool IsPreload { get { return false; } } //0xA6A0A8
		public override GameObject Content { get { return m_content; } } //0xA6A0B0
	}
}
