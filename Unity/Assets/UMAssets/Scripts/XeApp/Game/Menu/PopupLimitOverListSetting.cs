
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverListSetting : PopupSetting
	{
		public DFKGGBMFFGB_PlayerInfo playerData { get; set; } // 0x34
		public uint order { get; set; } // 0x38
		public List<GCIJNCFDNON_SceneInfo> sceneList { get; set; } // 0x3C
		public List<int> sceneIndexList { get; set; } // 0x40
		public PopupWindowControl control { get; set; } // 0x44
		public bool isBeginner { get; set; } // 0x48
		public override string PrefabPath { get { return ""; } } //0x168A5F0
		public override string BundleName { get { return PopupLimitOverList.BundleName; } } //0x168A64C
		public override string AssetName { get { return PopupLimitOverList.AssetName; } } //0x168A6C8
		public override bool IsAssetBundle { get { return true; } } //0x168A744
		public override bool IsPreload { get { return false; } } //0x168A74C
		public override GameObject Content { get { return m_content; } } //0x168A754

		//// RVA: 0x1687138 Offset: 0x1687138 VA: 0x1687138
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
