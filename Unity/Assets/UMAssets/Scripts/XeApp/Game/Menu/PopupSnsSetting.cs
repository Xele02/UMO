
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSnsSetting : PopupSetting
	{
		public Action ButtonCallbackTwitter { get; set; } // 0x34
		public Action ButtonCallbackFacebook { get; set; } // 0x38
		public Action ButtonCallbackLine { get; set; } // 0x3C
		public Action ButtonCallbackApple { get; set; } // 0x40
		public Action<bool> ButtonCallbackShow { get; set; } // 0x44
		public bool IsTitle { get; set; } // 0x48
		public override string PrefabPath { get { return "Layout/sel_inheriting/root_inh_pop_01_layout_root"; } } //0x11499B8
		public override string BundleName { get { return ""; } } //0x1149A14
		public override string AssetName { get { return "root_inh_pop_01_layout_root"; } } //0x1149A70
		public override bool IsAssetBundle { get { return false; } } //0x1149ACC
		public override bool IsPreload { get { return false; } } //0x1149AD4
		public override GameObject Content { get { return m_content; } } //0x1149ADC

		// RVA: 0x1149AE4 Offset: 0x1149AE4 VA: 0x1149AE4
		//public void SetContent(GameObject obj) { }
	}
}
