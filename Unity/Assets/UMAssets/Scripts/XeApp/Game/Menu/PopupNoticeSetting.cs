
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupNoticeSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x169DADC
		public override string BundleName { get { return "ly/072.xab"; } } //0x169DB38
		public override string AssetName { get { return "root_cmn_con_notice_pop_layout_root"; } } //0x169DB94
		public override bool IsAssetBundle { get { return true; } } //0x169DBF0
		public override bool IsPreload { get { return false; } } //0x169DBF8
		public override GameObject Content { get { return m_content; } } //0x169DC00

		//// RVA: 0x169DC08 Offset: 0x169DC08 VA: 0x169DC08
		//public void SetContent(GameObject obj) { }
	}
}
