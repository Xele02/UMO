
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaSkillUpSetting : PopupSetting
	{
		public int SceneId { get; set; } // 0x34
		public GCIJNCFDNON_SceneInfo.DLAMEBMGKDO SkillType { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x17A6A44
		public override string BundleName { get { return "ly/222.xab"; } } //0x17A6AA0
		public override string AssetName { get { return "root_pop_skill_ul_layout_root"; } } //0x17A6AFC
		public override bool IsAssetBundle { get { return true; } } //0x17A6B58
		public override bool IsPreload { get { return false; } } //0x17A6B60
		public override GameObject Content { get { return m_content; } } //0x17A6B68

		//// RVA: 0x17A6B70 Offset: 0x17A6B70 VA: 0x17A6B70
		//public void SetContent(GameObject obj) { }
	}
}
