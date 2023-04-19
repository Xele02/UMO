
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupFilterSortUGUISetting : PopupSetting
	{
		public class PartsInfo
		{
			public PopupFilterSortUGUI.Parts m_parts; // 0x8
			public PopupFilterSortUGUIPartsBase m_base; // 0xC
		}

		public class PrefabInfo
		{
			public string m_prefab_name; // 0x8

			// RVA: 0x179D308 Offset: 0x179D308 VA: 0x179D308
			public PrefabInfo(string a_prefab_name)
			{
				m_prefab_name = a_prefab_name;
			}
		}

		public PopupFilterSortUGUIInitParam m_param; // 0x34
		public List<PartsInfo> m_list_parts; // 0x38
		public PrefabInfo[] m_layout_info = new PrefabInfo[24]
			{
				new PrefabInfo("PopupFilterSortUGUIParts_Line"),
				new PrefabInfo("PopupFilterSortUGUIParts_Title01"),
				new PrefabInfo("PopupFilterSortUGUIParts_Title02"),
				new PrefabInfo("PopupFilterSortUGUIParts_Sort"),
				new PrefabInfo("PopupFilterSortUGUIParts_ToggleButtons"),
				new PrefabInfo("PopupFilterSortUGUIParts_ExclusiveToggleButtons"),
				new PrefabInfo("PopupFilterSortUGUIParts_CheckBoxes"),
				new PrefabInfo("PopupFilterSortUGUIParts_RangeSlider"),
				new PrefabInfo("PopupFilterSortUGUIParts_RangeSliderSingle"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterSeries"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterMusicAttr"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterGoDivaMusicExp"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterUnitLive"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterCombo"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterReward"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterDifficulty"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterBonus"),
				new PrefabInfo("PopupFilterSortUGUIParts_PlateFilter"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterMusicLock"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterMusicBookMark"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterRange"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterMusicSelectSeries"),
				new PrefabInfo("PopupFilterSortUGUIParts_FilterMusicSelect"),
				new PrefabInfo("PopupFilterSortUGUIParts_ShopProduct")
			}; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x179C494
		public override string BundleName { get { return "ly/223.xab"; } } //0x179C4F0
		public override string AssetName { get { return "PopupFilterSortUGUI"; } } //0x179C54C
		public override bool IsPreload { get { return true; } } //0x179C5A8
		public override bool IsAssetBundle { get { return true; } } //0x179C5B0
		public override GameObject Content { get { return m_content; } } //0x179C5B8

		//// RVA: 0x179BD8C Offset: 0x179BD8C VA: 0x179BD8C
		//public void Initialize(PopupFilterSortUGUIInitParam a_param, string titleText = "") { }

		//[IteratorStateMachineAttribute] // RVA: 0x7085D4 Offset: 0x7085D4 VA: 0x7085D4
		//// RVA: 0x179C320 Offset: 0x179C320 VA: 0x179C320 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70864C Offset: 0x70864C VA: 0x70864C
		//// RVA: 0x179C3E8 Offset: 0x179C3E8 VA: 0x179C3E8
		//public IEnumerator LoadAssetBundlePrefab_Parts(Transform parent) { }

		//// RVA: 0x179C154 Offset: 0x179C154 VA: 0x179C154
		//private void DestroyGameObject() { }
	}
}
