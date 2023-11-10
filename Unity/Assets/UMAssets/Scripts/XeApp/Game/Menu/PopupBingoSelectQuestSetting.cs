
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupBingoSelectQuestSetting : PopupSetting
	{
		public int ItemId; // 0x34
		public string ItemDetailText; // 0x38
		public string QuestText; // 0x3C
		public Action OnClickItemIcon; // 0x40

		public override string PrefabPath { get { return ""; } } //0x133BB8C
		public override string BundleName { get { return "ly/153.xab"; } } //0x133BBE8
		public override string AssetName { get { return "root_pop_bingo_mission_layout_root"; } } //0x133BC44
		public override bool IsAssetBundle { get { return true; } } //0x133BCA0
		public override bool IsPreload { get { return false; } } //0x133BCA8
		public override GameObject Content { get { return m_content; } } //0x133BCB0

		//// RVA: 0x133BCB8 Offset: 0x133BCB8 VA: 0x133BCB8
		//public void SetContent(GameObject obj) { }
	}
}
