using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListWin : LayoutUGUIScriptBase
	{
		public class ItemInfo
		{
			public int m_index; // 0x8
			public int m_cos_id; // 0xC
			public int m_cos_model_id; // 0x10
			public int m_cos_color; // 0x14
			public int m_lv_release; // 0x18
			public int m_lv_max; // 0x1C
			public int m_lv; // 0x20
			public bool m_is_have; // 0x24
			public bool m_is_new; // 0x25
			public bool m_is_set; // 0x26
			public string m_name; // 0x28
			public string m_name_base; // 0x2C
			public string m_status; // 0x30
			public FFHPBEPOMAK m_view_diva; // 0x34
			public ItemInfo m_src_item; // 0x38
		}

		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x14
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x18
		[SerializeField]
		private AbsoluteLayout m_anim_root; // 0x1C
		[SerializeField]
		private AbsoluteLayout m_anim_lock; // 0x20
		[SerializeField]
		private AbsoluteLayout m_anim_btn_cos_build; // 0x24
		[SerializeField]
		private ActionButton m_btn_cos_change; // 0x28
		[SerializeField]
		private ActionButton m_btn_cos_build; // 0x2C
		//[CompilerGeneratedAttribute] // RVA: 0x66B338 Offset: 0x66B338 VA: 0x66B338
		public UnityAction<int> m_cb_try; // 0x30
		//[CompilerGeneratedAttribute] // RVA: 0x66B348 Offset: 0x66B348 VA: 0x66B348
		public UnityAction<int> m_cb_getinfo; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x66B358 Offset: 0x66B358 VA: 0x66B358
		public UnityAction m_cb_cos_change; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x66B368 Offset: 0x66B368 VA: 0x66B368
		public UnityAction m_cb_cos_build; // 0x3C
		public int m_diva_id; // 0x40
		public int m_index_set; // 0x44
		public int m_index_try; // 0x48
		public List<ItemInfo> m_list_item = new List<ItemInfo>(); // 0x4C

		// RVA: 0x1646AA0 Offset: 0x1646AA0 VA: 0x1646AA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim_root = layout.FindViewById("sw_sel_cos_win_anim") as AbsoluteLayout;
			m_anim_lock = layout.FindViewById("swtbl_cmn_lock_icon_02") as AbsoluteLayout;
			m_anim_btn_cos_build = layout.FindViewById("sel_cos_btn_build_anim") as AbsoluteLayout;
			m_scrollRect = GetComponentInChildren<ScrollRect>(true);
			ActionButton[] bs = GetComponentsInChildren<ActionButton>(true);
			m_btn_cos_build = System.Array.Find(bs, (ActionButton _) =>
			{
				//0x16DDF60
				return _.name.Contains("sel_cos_btn_build_anim");
			});
			m_btn_cos_change = System.Array.Find(bs, (ActionButton _) =>
			{
				//0x16DDFF8
				return _.name.Contains("sel_cos_btn_select_anim");
			});
			m_btn_cos_build.AddOnClickCallback(CB_CostumeBuild);
			m_btn_cos_change.AddOnClickCallback(CB_CostumeChange);
			Loaded();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CCD2C Offset: 0x6CCD2C VA: 0x6CCD2C
		//// RVA: 0x1646F70 Offset: 0x1646F70 VA: 0x1646F70
		public IEnumerator Co_LoadListContent()
		{
			Font font; // 0x18
			string bundleName; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0x16DE0C4
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/044.xab";
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_cos_list_layout_root");
			yield return lytOp;

			GameObject t_source = null;
			yield return lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x16DE098
				t_source = instance;
			});

			LayoutUGUIRuntime runtime = t_source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_swapScrollList.ColumnCount * m_swapScrollList.RowCount; i++)
			{
				GameObject inst = Instantiate(t_source);
				LayoutUGUIRuntime instRun = inst.GetComponent<LayoutUGUIRuntime>();
				instRun.Layout = runtime.Layout.DeepClone();
				instRun.LoadLayout();
				CostumeSelectListElem elem = inst.GetComponent<CostumeSelectListElem>();
				elem.m_parent = this;
				elem.m_cb_try += CB_Try;
				elem.m_cb_getinfo += CB_GetInfo;
				m_swapScrollList.AddScrollObject(elem);
			}
			yield return null;
			m_swapScrollList.Apply();
			Destroy(t_source);
			t_source = null;
			AssetBundleManager.UnloadAssetBundle(bundleName);
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(CB_UpdateList);
			}
		}

		//// RVA: 0x1646FF8 Offset: 0x1646FF8 VA: 0x1646FF8
		private void CB_UpdateList(int index, SwapScrollListContent content)
		{
			CostumeSelectListElem elem = content as CostumeSelectListElem;
			if(elem != null)
			{
				elem.SetItem(index, m_diva_id, m_list_item[index]);
			}
		}

		//// RVA: 0x164713C Offset: 0x164713C VA: 0x164713C
		private void CB_Try(int a_index)
		{
			DisableNewMark(a_index);
			m_index_try = a_index;
			m_swapScrollList.VisibleRegionUpdate();
			m_cb_try.Invoke(a_index);
		}

		//// RVA: 0x1647298 Offset: 0x1647298 VA: 0x1647298
		private void CB_GetInfo(int a_index)
		{
			TodoLogger.Log(0, "CB_GetInfo");
		}

		//// RVA: 0x164730C Offset: 0x164730C VA: 0x164730C
		private void CB_CostumeChange()
		{
			DisableNewMark(m_index_try);
			if (m_cb_cos_change != null)
				m_cb_cos_change();
		}

		//// RVA: 0x1647338 Offset: 0x1647338 VA: 0x1647338
		private void CB_CostumeBuild()
		{
			TodoLogger.Log(0, "CB_CostumeBuild");
		}

		//// RVA: 0x164734C Offset: 0x164734C VA: 0x164734C
		public void CreateItem(int a_diva_id, bool a_first_transition = true, TransitionList.Type transition = TransitionList.Type.COSTUME_SELECT, bool a_debug = false, bool isGoDiva = false)
		{
			m_diva_id = a_diva_id;
			FFHPBEPOMAK selectedCostume = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC[m_diva_id - 1];
			List<ItemInfo> l1 = new List<ItemInfo>();
			List<ItemInfo> l2 = new List<ItemInfo>();
			List<FFHPBEPOMAK> fl;
			if(isGoDiva)
			{
				fl = FFHPBEPOMAK.OOJFGDKBOHK(a_diva_id, a_debug);
			}
			else
			{
				fl = FFHPBEPOMAK.DNAIGDHCILM_GetCostumeList(a_diva_id, a_debug);
			}
			int i = 0;
			foreach(var f_ in fl)
			{
				ItemInfo data = new ItemInfo();
				data.m_view_diva = f_;
				data.m_src_item = null;
				data.m_index = i;
				data.m_name = f_.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
				data.m_name_base = f_.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
				data.m_status = f_.FFKMJNHFFFL_Costume.FCEGELPJAMH_Status;
				data.m_cos_id = f_.FFKMJNHFFFL_Costume.JPIDIENBGKH_CostumeId;
				data.m_cos_model_id = f_.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				data.m_cos_color = 0;
				data.m_lv = f_.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB(a_diva_id, data.m_cos_id);
				data.m_lv_max = cosInfo.LLLCMHENKKN_LevelMax;
				data.m_is_have = f_.JLKPGDEKPEO_IsHave;
				data.m_is_new = f_.MBFADDHOEOK_IsNew;
				if(transition == TransitionList.Type.COSTUME_SELECT && selectedCostume.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == f_.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId)
				{
					data.m_is_set = data.m_cos_color == selectedCostume.EKFONBFDAAP_ColorId;
					if (!data.m_is_set)
					{
						if(!data.m_is_have)
						{
							l2.Add(data);
						}
						else
						{
							l1.Add(data);
						}
					}
					else
					{
						l1.Insert(0, data);
					}
				}
				else
				{
					data.m_is_set = false;
					if (!data.m_is_have)
					{
						l2.Add(data);
					}
					else
					{
						l1.Add(data);
					}
				}
				i++;
				short[] cols = cosInfo.CHDBGFLFPNC_GetAvaiableColors();
				short[] avaiableCols = cosInfo.KKLPLPGBOFD_GetAvaiableColor(f_.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level);
				for (int j = 0; j < cols.Length; j++)
				{
					ItemInfo dataCol = new ItemInfo();
					dataCol.m_view_diva = f_;
					dataCol.m_src_item = data;
					dataCol.m_index = i;
					dataCol.m_name = f_.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(cols[j]);
					dataCol.m_name_base = f_.FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(0);
					dataCol.m_status = f_.FFKMJNHFFFL_Costume.FCEGELPJAMH_Status;
					dataCol.m_cos_id = f_.FFKMJNHFFFL_Costume.JPIDIENBGKH_CostumeId;
					dataCol.m_cos_model_id = f_.FFKMJNHFFFL_Costume.HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId;
					dataCol.m_cos_color = cols[j];
					dataCol.m_lv = f_.FFKMJNHFFFL_Costume.GKIKAABHAAD_Level;
					dataCol.m_lv_max = cosInfo.LLLCMHENKKN_LevelMax;
					dataCol.m_is_set = false;
					if(transition == TransitionList.Type.COSTUME_SELECT)
					{
						if(selectedCostume.FFKMJNHFFFL_Costume.HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId == f_.FFKMJNHFFFL_Costume.HNJNKCPDKAL_PrismCostumeId_CryptedPrismCostumeId)
						{
							dataCol.m_is_set = selectedCostume.EKFONBFDAAP_ColorId == f_.EKFONBFDAAP_ColorId;
						}
					}
					dataCol.m_is_have = false;
					dataCol.m_is_new = false;
					for (int k = 0; k < avaiableCols.Length; k++)
					{
						if(avaiableCols[k] == dataCol.m_cos_color)
						{
							dataCol.m_is_have = true;
							if(f_.FFKMJNHFFFL_Costume.EJODLFBKFDK_ColNewflags.Length != 0)
							{
								dataCol.m_is_new = f_.FFKMJNHFFFL_Costume.EJODLFBKFDK_ColNewflags[j];
							}
							break;
						}
					}
					if(!dataCol.m_is_set)
					{
						if(!dataCol.m_is_have)
						{
							l2.Add(dataCol);
						}
						else
						{
							l1.Add(dataCol);
						}
					}
					else
					{
						l1.Insert(0, dataCol);
					}
					i++;
				}
			}
			m_list_item.Clear();
			m_list_item.AddRange(l1);
			m_list_item.AddRange(l2);
			if(a_first_transition)
			{
				for(int j = 0; j < m_list_item.Count; j++)
				{
					if(transition == TransitionList.Type.COSTUME_SELECT)
					{
						if((selectedCostume.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId == m_list_item[j].m_view_diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId) && 
							selectedCostume.EKFONBFDAAP_ColorId == m_list_item[j].m_cos_color)
						{
							m_index_set = j;
							m_index_try = j;
						}
					}
				}
			}
			m_swapScrollList.SetItemCount(m_list_item.Count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x1648208 Offset: 0x1648208 VA: 0x1648208
		public ItemInfo GetSelectItem()
		{
			return m_list_item[m_index_try];
		}

		//// RVA: 0x1648288 Offset: 0x1648288 VA: 0x1648288
		public ItemInfo GetItem(int a_index)
		{
			return m_list_item[a_index];
		}

		//// RVA: 0x1648308 Offset: 0x1648308 VA: 0x1648308
		public void Enter()
		{
			m_anim_lock.StartChildrenAnimGoStop(MOEALEGLGCH.CDOCOLOKCJK() ? "02" : "01");
			m_anim_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x16483E8 Offset: 0x16483E8 VA: 0x16483E8
		//public void Leave() { }

		//// RVA: 0x1648474 Offset: 0x1648474 VA: 0x1648474
		public void Exit()
		{
			m_swapScrollList.enabled = false;
		}

		//// RVA: 0x16471E0 Offset: 0x16471E0 VA: 0x16471E0
		public void DisableNewMark(int a_index)
		{
			ItemInfo item = GetItem(a_index);
			if (!item.m_is_new)
				return;
			if(item.m_cos_color == 0)
			{
				item.m_view_diva.LEHDLBJJBNC();
			}
			else
			{
				item.m_view_diva.FFKMJNHFFFL_Costume.PDADHMIODCA(item.m_cos_color, false);
			}
			item.m_is_new = false;
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x16484A4 Offset: 0x16484A4 VA: 0x16484A4
		public void HiddenButtonCostumeUpgrade(bool a_hidden)
		{
			m_anim_btn_cos_build.StartChildrenAnimGoStop(a_hidden ? "st_wait" : "st_out");
			m_btn_cos_build.Hidden = a_hidden;
		}

		//// RVA: 0x1648560 Offset: 0x1648560 VA: 0x1648560
		public void CreateNewMark()
		{
			for(int i = 0; i < m_swapScrollList.ScrollObjects.Count; i++)
			{
				(m_swapScrollList.ScrollObjects[i] as CostumeSelectListElem).CreateNewIcon();
			}
		}

		//// RVA: 0x1648714 Offset: 0x1648714 VA: 0x1648714
		public void DestroyNewMark()
		{
			for (int i = 0; i < m_swapScrollList.ScrollObjects.Count; i++)
			{
				(m_swapScrollList.ScrollObjects[i] as CostumeSelectListElem).DestroyNewIcon();
			}
		}
	}
}
