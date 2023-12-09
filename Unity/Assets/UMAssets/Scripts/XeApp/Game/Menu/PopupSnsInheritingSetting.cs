
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupSnsInheritingSetting : PopupSetting
	{
		public Action ButtonCallbackTwitter { get; set; } // 0x34
		public Action ButtonCallbackFacebook { get; set; } // 0x38
		public Action ButtonCallbackLine { get; set; } // 0x3C
		public Action ButtonCallbackApple { get; set; } // 0x40
		public Action ButtonCallbackCaution { get; set; } // 0x44
		public bool IsTitle { get; set; } // 0x48
		public bool IsPreparation { get; set; } // 0x49
		public override string PrefabPath { get { return "Layout/sel_inheriting/root_inh_pop_02_layout_root"; } } //0x11498A8
		public override string AssetName { get { return "root_inh_pop_02_layout_root"; } } //0x1149904
		public override bool IsAssetBundle { get { return false; } } //0x1149960
		public override bool IsPreload { get { return false; } } //0x1149968
		public override GameObject Content { get { return m_content; } } //0x1149970

		//// RVA: 0x1149978 Offset: 0x1149978 VA: 0x1149978
		//public void SetContent(GameObject obj) { }
	}
}
