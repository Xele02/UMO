
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{ 
	public class PopupFilterSortSetting : PopupSetting
	{
		public class PartsInfo
		{
			public PopupFilterSort.Parts m_parts; // 0x8
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

		public PopupFilterSortInitParam m_param; // 0x34
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
		public void Initialize(PopupFilterSortInitParam a_param)
		{
			if(m_param != null)
			{
				if(a_param.Scene != m_param.Scene)
					DestroyGameObject();
			}
			m_param = a_param;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_param.Scene == PopupFilterSort.Scene.DivaSelect)
			{
				WindowSize = SizeType.Middle;
				TitleText = bk.GetMessageByLabel("popup_diva_select_title");
			}
			else
			{
				WindowSize = SizeType.Large;
				if(m_param.Scene == PopupFilterSort.Scene.GoDivaMusicSelect)
				{
					TitleText = bk.GetMessageByLabel("popup_godiva_filter_title");
				}
				else
				{
					TitleText = bk.GetMessageByLabel("popup_sort_title");
				}
			}
			Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707F5C Offset: 0x707F5C VA: 0x707F5C
		//// RVA: 0x1C8D448 Offset: 0x1C8D448 VA: 0x1C8D448 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1C8DF68
			yield return LoadAssetBundlePrefab_Parts(parent);
			GameObject t_content = null;
			m_parent = parent;
			if(m_content == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
				yield return operation;
				yield return operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1C8DDF8
					t_content = instance;
				});
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = null;
			}
			foreach(var k in m_list_parts)
			{
				k.m_base.transform.SetParent(t_content.transform, false);
			}
			t_content.transform.SetParent(m_parent, false);
			t_content.gameObject.SetActive(false);
			m_content = t_content;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707FD4 Offset: 0x707FD4 VA: 0x707FD4
		//// RVA: 0x1C8D510 Offset: 0x1C8D510 VA: 0x1C8D510
		public IEnumerator LoadAssetBundlePrefab_Parts(Transform parent)
		{
			PopupFilterSort.Parts[] t_table_parts; // 0x18
			int i; // 0x1C
			AssetBundleLoadLayoutOperationBase operationBase;

			//0x1C8E5C8
			m_list_parts = new List<PartsInfo>();
			AssetBundleManager.LoadUnionAssetBundle(BundleName);
			t_table_parts = PopupFilterSort.GetPartsTable(m_param.Scene);
			i = 0;
			for(; i < t_table_parts.Length; i++)
			{
                PopupFilterSort.Parts t_parts_type = t_table_parts[i];
				operationBase = AssetBundleManager.LoadLayoutAsync(BundleName, m_layout_info[(int)t_parts_type].m_prefab_name);
				yield return operationBase;
				yield return Co.R(operationBase.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1C8DE08
					PopupFilterSortPartsBase p = instance.GetComponent<PopupFilterSortPartsBase>();
					if(p == null)
						return;
					PartsInfo pinfo = new PartsInfo();
					pinfo.m_base = p;
					pinfo.m_parts = t_parts_type;
					m_list_parts.Add(pinfo);
				}));
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
            }
			t_table_parts = null;
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		//// RVA: 0x1C8D27C Offset: 0x1C8D27C VA: 0x1C8D27C
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
					UnityEngine.Object.Destroy(m_list_parts[i].m_base);
				}
				m_list_parts = null;
			}
		}
	}
}
