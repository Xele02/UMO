
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupDivaSkillLevelSetting : PopupSetting
	{
		public int selectMusicId { get; set; } // 0x34
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/root_pop_diva_exp_layout_root"; } } //0xF821DC
		public override string BundleName { get { return "ly/042.xab"; } } //0xF82238
		public override string AssetName { get { return "root_pop_diva_exp_layout_root"; } } //0xF82294
		public override bool IsAssetBundle { get { return true; } } //0xF822F0
		public override bool IsPreload { get { return true; } } //0xF822F8
		public override GameObject Content { get { return m_content; } } //0xF82300

		//// RVA: 0xF82308 Offset: 0xF82308 VA: 0xF82308
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707B1C Offset: 0x707B1C VA: 0x707B1C
		//// RVA: 0xF82310 Offset: 0xF82310 VA: 0xF82310 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}
	}
}
