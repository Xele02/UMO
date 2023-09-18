
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupGakuyaPresentUse2Setting : PopupSettingUGUI
	{
		public OJEGDIBEBHP m_divaPresentData; // 0x34
		public int m_haveItemVal; // 0x38
		public int m_maxUseItemVal; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x17A7610
		public override string BundleName { get { return "ly/081.xab"; } } //0x17A766C
		public override string AssetName { get { return "GakuyaPopupPresentUse2"; } } //0x17A76C8
		public override bool IsAssetBundle { get { return true; } } //0x17A7724
		public override bool IsPreload { get { return false; } } //0x17A772C
		public override GameObject Content { get { return m_content; } } //0x17A7734

		//// RVA: 0x17A773C Offset: 0x17A773C VA: 0x17A773C
		//public void SetContent(GameObject obj) { }
	}
}
