
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ValkyrieSkillCheckPopupSetting : PopupSetting
	{
		public ALEKLHIANJN data { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x16622A0
		public override string BundleName { get { return "ly/045.xab"; } } //0x16622FC
		public override string AssetName { get { return "PopupValkyrieSkillCheck"; } } //0x1662358
		public override bool IsAssetBundle { get { return true; } } //0x16623B4
		public override bool IsPreload { get { return true; } } //0x16623BC
		public override GameObject Content { get { return m_content; } } //0x16623C4

		//// RVA: 0x16623CC Offset: 0x16623CC VA: 0x16623CC
		//public void SetContent(GameObject obj) { }
	}
}
