
using UnityEngine;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public delegate void contentUpdate(LayoutPopUseStone content);

	public class PopupUseStoneSetting : PopupSetting
	{
		public DJBHIFLHJLK GotoTitleListener; // 0x34
		public string LimitText = ""; // 0x3C
		public bool IsLegalButton = true; // 0x44

		public override string PrefabPath { get { return "Layout/use_stone/root_use_stone_pop_layout_root"; } } //0x1BB56C4
		public override string BundleName { get { return ""; } } //0x1BB5720
		public override string AssetName { get { return "root_use_stone_pop_layout_root"; } } //0x1BB577C
		public override bool IsAssetBundle { get { return false; } } //0x1BB57D8
		public override bool IsPreload { get { return false; } } //0x1BB57E0
		public override GameObject Content { get { return m_content; } } //0x1BB57E8
		public string Text { get; set; } // 0x38
		public contentUpdate ContentUpdata { get; set; } // 0x40

		//// RVA: 0x1BB5800 Offset: 0x1BB5800 VA: 0x1BB5800
		//public void SetContent(GameObject obj) { }
	}
}
