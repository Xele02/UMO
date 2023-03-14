
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class SceneStatePopupSetting : PopupSetting
	{
		public GCIJNCFDNON_SceneInfo Scene { get; set; } // 0x34
		public DFKGGBMFFGB_PlayerInfo PlayerData { get; set; } // 0x38
		public bool IsFriend { get; set; } // 0x3C
		public bool IsDisableZoom { get; set; } // 0x3D
		public bool IsDiableLuckyLeaf { get; set; } // 0x3E
		public SceneStatusParam.PageSave PageSave { get; set; } // 0x40
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/PopupSceneState"; } } //0xA599C4
		public override string BundleName { get { return "ly/016.xab"; } } //0xA59A20
		public override string AssetName { get { return "PopupSceneState"; } } //0xA59A7C
		public override bool IsAssetBundle { get { return true; } } //0xA59AD8
		public override bool IsPreload { get { return true; } } //0xA59AE0
		public override GameObject Content { get { return m_content; } } //0xA59AE8

		// RVA: 0xA599A4 Offset: 0xA599A4 VA: 0xA599A4
		public SceneStatePopupSetting()
		{
			PageSave = SceneStatusParam.PageSave.Player;
		}

		//// RVA: 0xA59AF0 Offset: 0xA59AF0 VA: 0xA59AF0
		//public void SetContent(GameObject obj) { }
	}
}
