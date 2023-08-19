
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ValkyrieSkillUpRewardPopupSetting : PopupSetting
	{
		public int itemId { get; set; } // 0x34
		public int cnt { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x1662B6C
		public override string BundleName { get { return "ly/045.xab"; } } //0x1662BC8
		public override string AssetName { get { return "PopupValSkillUpReward"; } } //0x1662C24
		public override bool IsAssetBundle { get { return true; } } //0x1662C80
		public override bool IsPreload { get { return true; } } //0x1662C88
		public override GameObject Content { get { return m_content; } } //0x1662C90

		//// RVA: 0x1662C98 Offset: 0x1662C98 VA: 0x1662C98
		//public void SetContent(GameObject obj) { }
	}
}
