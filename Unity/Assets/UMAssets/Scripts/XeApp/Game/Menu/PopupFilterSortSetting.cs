
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupFilterSortSetting : PopupSetting
	{
		public class PartsInfo
		{
			//public PopupFilterSort.Parts m_parts; // 0x8
			public PopupFilterSortPartsBase m_base; // 0xC
		}

		public class LayoutInfo
		{
			public string m_prefab_name; // 0x8

			// RVA: 0x1C8DDD0 Offset: 0x1C8DDD0 VA: 0x1C8DDD0
			public LayoutInfo(string a_prefab_name)
			{
				m_prefab_name = a_prefab_name;
			}
		}

		//public PopupFilterSortInitParam m_param; // 0x34
		public List<PartsInfo> m_list_parts; // 0x38
		public LayoutInfo[] m_layout_info = new LayoutInfo[12]
			{
				new LayoutInfo("root_cmn_sort_filter_diva_layout_root"),
				new LayoutInfo("root_cmn_sort_filter_mainep_layout_root"),
				new LayoutInfo("root_cmn_sort_filter_series_layout_root"),
				new LayoutInfo("root_cmn_sort_layout_root"),
				new LayoutInfo("root_cmn_sort_line_layout_root"),
				new LayoutInfo("root_cmn_sort_title_h1_layout_root"),
				new LayoutInfo("root_cmn_sort_title_h2_layout_root"),
				new LayoutInfo("root_cmn_sort_filter_rarity_layout_root"),
				new LayoutInfo("root_cmn_sort_filter_status_layout_root"),
				new LayoutInfo("root_cmn_sort_title_h3_layout_root"),
				new LayoutInfo("root_cmn_sort_filter_diva2_layout_root"),
				new LayoutInfo("root_cmn_sort2_layout_root")
			}; // 0x3C

		public override string PrefabPath { get { return ""; } } //0x1C8D5BC
		public override string BundleName { get { return "ly/223.xab"; } } //0x1C8D618
		public override string AssetName { get { return "PopupFilterSort"; } } //0x1C8D674
		public override bool IsPreload { get { return true; } } //0x1C8D6D0
		public override bool IsAssetBundle { get { return true; } } //0x1C8D6D8
		public override GameObject Content { get { return m_content; } } //0x1C8D6E0

		//// RVA: 0x1C8CF58 Offset: 0x1C8CF58 VA: 0x1C8CF58
		//public void Initialize(PopupFilterSortInitParam a_param) { }

		//[IteratorStateMachineAttribute] // RVA: 0x707F5C Offset: 0x707F5C VA: 0x707F5C
		//// RVA: 0x1C8D448 Offset: 0x1C8D448 VA: 0x1C8D448 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707FD4 Offset: 0x707FD4 VA: 0x707FD4
		//// RVA: 0x1C8D510 Offset: 0x1C8D510 VA: 0x1C8D510
		//public IEnumerator LoadAssetBundlePrefab_Parts(Transform parent) { }

		//// RVA: 0x1C8D27C Offset: 0x1C8D27C VA: 0x1C8D27C
		//private void DestroyGameObject() { }
	}
}
