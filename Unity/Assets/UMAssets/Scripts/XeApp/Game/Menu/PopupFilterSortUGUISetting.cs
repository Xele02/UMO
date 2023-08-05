
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

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
		public void Initialize(PopupFilterSortUGUIInitParam a_param, string titleText = "")
		{
			if(m_param != null)
			{
				if(m_param.Scene != a_param.Scene)
					DestroyGameObject();
			}
			m_param = a_param;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_param.Scene == PopupFilterSortUGUI.Scene.UnitDispType)
			{
				WindowSize = SizeType.Large;
				TitleText = bk.GetMessageByLabel("popup_sort_title_unit");
			}
			else if(m_param.Scene == PopupFilterSortUGUI.Scene.GoDivaMusicSelect)
			{
				WindowSize = SizeType.Large;
				TitleText = bk.GetMessageByLabel("popup_godiva_filter_title");
			}
			else
			{
				WindowSize = SizeType.Large;
				TitleText = bk.GetMessageByLabel("popup_sort_title");
			}
			Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			if(titleText.Length > 0)
				TitleText = titleText;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7085D4 Offset: 0x7085D4 VA: 0x7085D4
		//// RVA: 0x179C320 Offset: 0x179C320 VA: 0x179C320 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x179D4A0
			yield return LoadAssetBundlePrefab_Parts(parent);
			GameObject t_content = null;
			m_parent = parent;
			if(m_content == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x179D330
					t_content = instance;
				});
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = null;
			}
			foreach(var k in m_list_parts)
			{
				k.m_base.transform.SetParent(t_content.transform, false);
				k.m_base.Initialize();
			}
			foreach(var k in m_list_parts)
			{
				while(!k.m_base.IsReady)
					yield return null;
			}
			t_content.transform.SetParent(m_parent, false);
			t_content.gameObject.SetActive(false);
			m_content = t_content;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70864C Offset: 0x70864C VA: 0x70864C
		//// RVA: 0x179C3E8 Offset: 0x179C3E8 VA: 0x179C3E8
		public IEnumerator LoadAssetBundlePrefab_Parts(Transform parent)
		{
			PopupFilterSortUGUI.Parts[] t_table_parts;
			int i;
			AssetBundleLoadUGUIOperationBase operation;

			//0x179DCA8
			m_list_parts = new List<PartsInfo>();
			AssetBundleManager.LoadUnionAssetBundle(BundleName);
			t_table_parts = PopupFilterSortUGUI.GetPartsTable(m_param.Scene);
			i = 0;
			for(; i < t_table_parts.Length; i++)
			{
				PopupFilterSortUGUI.Parts t_parts_type = t_table_parts[i];
				operation = AssetBundleManager.LoadUGUIAsync(BundleName, m_layout_info[(int)t_parts_type].m_prefab_name);
				yield return operation;
				yield return operation.InitializeUGUICoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x179D340
					PopupFilterSortUGUIPartsBase p = instance.GetComponent<PopupFilterSortUGUIPartsBase>();
					if(p == null)
						return;
					PartsInfo t = new PartsInfo();
					t.m_parts = t_parts_type;
					t.m_base = p;
					m_list_parts.Add(t);
				});
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
			t_table_parts = null;
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		//// RVA: 0x179C154 Offset: 0x179C154 VA: 0x179C154
		private void DestroyGameObject()
		{
			if(m_content != null)
			{
				UnityEngine.Object.Destroy(m_content);
				m_content = null;
			}
			if(m_list_parts != null)
			{
				for(int i = 0; i < m_list_parts.Count; i++)
				{
					UnityEngine.Object.Destroy(m_list_parts[i].m_base.gameObject);
				}
				m_list_parts = null;
			}
		}
	}
}
