
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Title
{
	public class PopupContractSetting : PopupSetting
	{
		public override string PrefabPath { get { return "Layout/contract/root_contract_pop_01_layout_root"; } } //0xE3BC24
		public override string BundleName { get { return ""; } } //0xE3BC80
		public override string AssetName { get { return "root_contract_pop_01_layout_root"; } } //0xE3BCDC
		public override bool IsAssetBundle { get { return false; } } //0xE3BD38
		public override bool IsPreload { get { return false; } } //0xE3BD40
		public override GameObject Content { get { return m_content; } } //0xE3BD48

		// RVA: 0xE3BD50 Offset: 0xE3BD50 VA: 0xE3BD50
		//public void SetContent(GameObject obj) { }
	}
}
