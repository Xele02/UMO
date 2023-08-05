
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupSubPlateContentSetting : PopupSetting
	{
		public UnityAction<PopupSubPlateContent> OkCallBack { get; set; } // 0x34
		public CFHDKAFLNEP SubPlateResult { get; set; } // 0x38
		public UnitWindowConstant.OperationMode OperationMode { get; set; } // 0x40
		public bool IsReShowSceneDetail { get; set; } // 0x44
		public override string PrefabPath { get { return ""; } } //0x1152B40
		public override string BundleName { get { return "ly/013.xab"; } } //0x1152BA4
		public override string AssetName { get { return "root_sub_deck_pop_layout_root"; } } //0x1152C00
		public override bool IsAssetBundle { get { return true; } } //0x1152C5C
		public override bool IsPreload { get { return true; } } //0x1152C64
		public override GameObject Content { get { return m_content; } } //0x1152C6C
	}
}
