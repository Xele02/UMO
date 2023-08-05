
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupLoginBonusSetting : PopupSetting
	{
		public IKIIAFKHDFP loginBonusManager { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } // 0x168F15C
		public override string BundleName { get { return "ly/001.xab"; } } //0x168F1B8
		public override string AssetName { get { return "root_login_03_layout_root"; } } //0x168F214
		public override bool IsAssetBundle { get { return true; } } //0x168F270
		public override bool IsPreload { get { return false; } } //0x168F278
		public override GameObject Content { get { return m_content; } } //0x168F280

		//// RVA: 0x168F288 Offset: 0x168F288 VA: 0x168F288
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
