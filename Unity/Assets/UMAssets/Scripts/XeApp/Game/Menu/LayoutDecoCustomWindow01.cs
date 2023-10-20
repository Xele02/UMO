using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;
using XeApp.Core;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomWindow01 : LayoutUGUIScriptBase
	{
		public enum SelectItemType
		{
			Chara = 0,
			Serif = 1,
			Num = 2,
		}

		private struct tabLayout
		{
			public AbsoluteLayout m_select; // 0x0
			public AbsoluteLayout m_type; // 0x4
			public AbsoluteLayout m_typeSelect; // 0x8
			public AbsoluteLayout m_newIcon; // 0xC
			public Action<int> m_callBack; // 0x10
		}

		public struct SelectItemData
		{
			public int id; // 0x0
			public SelectItemType type; // 0x4
			public string text; // 0x8
			public SeriesAttr.Type series; // 0xC
			public bool isShopProduct; // 0x10
			public int charaId; // 0x14
			public int charaType; // 0x18
			public int emotion; // 0x1C
			public bool IsNew; // 0x20
			public int tabCategory; // 0x24
			public FJGOKILCBJA product; // 0x28
		}

		private readonly int[,] ButtonTextureIdTable = new int[2, 2] { { 4, 2 }, { 4, 1 } }; // 0x14
		[SerializeField]
		private ActionButton m_leftButton; // 0x18
		[SerializeField]
		private RawImageEx m_leftButtonFont; // 0x1C
		[SerializeField]
		private ActionButton m_rightButton; // 0x20
		[SerializeField]
		private RawImageEx m_rightButtonFont; // 0x24
		[SerializeField]
		private List<ButtonBase> m_tab; // 0x28
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x2C
		[SerializeField]
		private Text m_windowText; // 0x30
		[SerializeField]
		private Vector2 m_windowSize; // 0x34
		private AbsoluteLayout m_windowBase; // 0x3C
		private AbsoluteLayout m_tabChangeBase; // 0x40
		private TexUVListManager m_uvManager; // 0x44
		private const int TabMax = 6;
		private tabLayout[] m_tabLayoutList = new tabLayout[6]; // 0x48
		public Action OnClickRightButton; // 0x4C
		public Action OnClickLeftButton; // 0x50
		public Action<LayoutDecoCustomSelectItemBase> OnDecideItem; // 0x54
		private GameObject m_source; // 0x58
		private List<SelectItemData> m_selectItemDataList = new List<SelectItemData>(); // 0x5C
		private List<SelectItemData> m_tabItemDataList = new List<SelectItemData>(); // 0x60

		public bool LeftButtonHidden { set { m_leftButton.Hidden = value; } } //0x19E3FCC
		public bool RightButtonHidden { set { m_rightButton.Hidden = value; } } //0x19E4000
		public int TargetStampId { get; set; } // 0x64
		public int TargetSerifId { get; set; } // 0x68
		public bool IsLoaded { get; set; } // 0x6C
		public bool IsOpen { get; set; } // 0x6D

		// RVA: 0x19E4074 Offset: 0x19E4074 VA: 0x19E4074 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewById("sw_cstm_deco_window_anim") as AbsoluteLayout;
			m_tabChangeBase = layout.FindViewById("deco_tab_all") as AbsoluteLayout;
			for(int i = 0; i < 6; i++)
			{
				m_tabLayoutList[i].m_select = layout.FindViewByExId("swtbl_deco_tab_all_tab_0" + (i + 1)) as AbsoluteLayout;
				m_tabLayoutList[i].m_type = m_tabLayoutList[i].m_select.FindViewById("swtbl_deco_tab_font_01") as AbsoluteLayout;
				m_tabLayoutList[i].m_typeSelect = m_tabLayoutList[i].m_select.FindViewById("swtbl_deco_tab_font_02") as AbsoluteLayout;
				m_tabLayoutList[i].m_newIcon = m_tabLayoutList[i].m_select.FindViewById("swtbl_new_icon_01") as AbsoluteLayout;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_windowText.text = bk.GetMessageByLabel("customstamp_have_serif_not");
			m_rightButton.AddOnClickCallback(() =>
			{
				//0x19E71E4
				OnClickRightButton();
			});
			m_leftButton.AddOnClickCallback(() =>
			{
				//0x19E7210
				OnClickLeftButton();
			});
			IsOpen = false;
			m_uvManager = uvMan;
			TargetStampId = 0;
			TargetSerifId = 0;
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D7CAC Offset: 0x6D7CAC VA: 0x6D7CAC
		//// RVA: 0x19E46A0 Offset: 0x19E46A0 VA: 0x19E46A0
		private IEnumerator Co_LoadItemLayout(SelectItemType type, List<SelectItemData> itemData)
		{
			int row; // 0x1C
			int col; // 0x20
			Vector2 size; // 0x24

			//0x19E7450
			yield return this.StartCoroutineWatched(Co_LoadLayoutItemSource(type));
			m_selectItemDataList = itemData;
			LayoutDecoCustomSelectItemBase l = GetComponent(m_source, type);
			size = l.Size;
			GetContentData(out row, out col, ref size, 0);
			int num = row * col;
			LayoutUGUIRuntime runtime = m_source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < num; i++)
			{
				GameObject g = Instantiate(m_source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_swapScrollList.AddScrollObject(g.GetComponent<LayoutDecoCustomSelectItemBase>());
			}
			yield return null;
			m_swapScrollList.Apply(row, col, size, new Vector2(5, 5));
			m_swapScrollList.SetContentEscapeMode(true);
			AssetBundleManager.UnloadAssetBundle("ly/206.xab", false);
			Destroy(m_source);
			if(m_swapScrollList != null)
			{
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(Co_UpdateList);
			}
			for(int i = 0; i < m_swapScrollList.ScrollObjects.Count; i++)
			{
				m_swapScrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_swapScrollList.ScrollObjects[i].ClickButton.AddListener(SelectItem);
			}
			IsLoaded = true;
		}

		//// RVA: 0x19E4780 Offset: 0x19E4780 VA: 0x19E4780
		public void ResetList(List<SelectItemData> itemData)
		{
			m_selectItemDataList = itemData;
		}

		//// RVA: 0x19E4788 Offset: 0x19E4788 VA: 0x19E4788
		private void SelectItem(int index, SwapScrollListContent content)
		{
			LayoutDecoCustomSelectItemBase l = content as LayoutDecoCustomSelectItemBase;
			if(l != null)
			{
				if(OnDecideItem != null)
					OnDecideItem(l);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D7D24 Offset: 0x6D7D24 VA: 0x6D7D24
		//// RVA: 0x19E488C Offset: 0x19E488C VA: 0x19E488C
		private IEnumerator Co_LoadLayoutItemSource(SelectItemType type)
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x19E7D14
			op = AssetBundleManager.LoadLayoutAsync("ly/206.xab", AssetName(type));
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x19E723C
				m_source = instance;
			}));
		}

		//// RVA: 0x19E4954 Offset: 0x19E4954 VA: 0x19E4954
		private void ResetItem()
		{
			m_selectItemDataList.Clear();
			foreach(var k in m_swapScrollList.ScrollObjects)
			{
				Destroy(k.gameObject);
			}
			m_swapScrollList.RemoveScrollObject();
		}

		//// RVA: 0x19E4B5C Offset: 0x19E4B5C VA: 0x19E4B5C
		public void LoadResource(SelectItemType type, List<SelectItemData> itemData)
		{
			IsLoaded = false;
			ResetItem();
			this.StartCoroutineWatched(Co_LoadItemLayout(type, itemData));
		}

		//// RVA: 0x19E4BA4 Offset: 0x19E4BA4 VA: 0x19E4BA4
		public void Enter(DecoCustomDecorator.DecoratorType type, int tabNumIndex, DecoCustomDecorator.TabType[] tab, Action<int> tabCallBack, bool isCreate, bool isMatch, Action<int> callback)
		{
			m_tabChangeBase.StartChildrenAnimGoStop(tabNumIndex, tabNumIndex);
			for(int i = 0; i < tab.Length; i++)
			{
				int index = i;
				int tabIndex = i < tab.Length - 1 ? i : 5;
				m_tabLayoutList[tabIndex].m_callBack = tabCallBack;
				m_tabLayoutList[tabIndex].m_type.StartAllAnimGoStop((int)tab[i], (int)tab[i]);
				m_tabLayoutList[tabIndex].m_typeSelect.StartAllAnimGoStop((int)tab[i], (int)tab[i]);
				UpdateTabNewIcon(type, tab[i], tabIndex);
				m_tab[tabIndex].ClearOnClickCallback();
				m_tab[tabIndex].AddOnClickCallback(() =>
				{
					//0x19E73C4
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					SelectTab(tabIndex, index);
				});
			}
			SelectTab(0, 0);
			if(callback != null)
			{
				if(m_tabItemDataList.Count > 0)
				{
					if(isCreate)
					{
						callback(m_tabItemDataList[0].id);
					}
					if(type == DecoCustomDecorator.DecoratorType.Serif && !isMatch)
					{
						callback(m_tabItemDataList[0].id);
					}
				}
			}
			SettingTexture(type);
		}

		//// RVA: 0x19E50F4 Offset: 0x19E50F4 VA: 0x19E50F4
		private void UpdateTabNewIcon(DecoCustomDecorator.DecoratorType selectType, DecoCustomDecorator.TabType tabType, int tabIndex)
		{
			CreateTabItemList(selectType, tabType);
			m_tabLayoutList[tabIndex].m_newIcon.StartChildrenAnimGoStop(1, 1);
			foreach(var k in m_tabItemDataList)
			{
				if(k.IsNew)
				{
					m_tabLayoutList[tabIndex].m_newIcon.StartChildrenAnimGoStop(0, 0);
					break;
				}
			}
		}

		//// RVA: 0x19E5500 Offset: 0x19E5500 VA: 0x19E5500
		private void SettingTexture(DecoCustomDecorator.DecoratorType type)
		{
			if (ButtonTextureIdTable[(int)type, 0] == 0)
				m_leftButton.Hidden = true;
			else
			{
				m_leftButton.Hidden = false;
				m_leftButtonFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(string.Format("deco_fnt_{0:D2}", ButtonTextureIdTable[(int)type, 0])));
			}
			if (ButtonTextureIdTable[(int)type, 1] == 0)
				m_rightButton.Hidden = true;
			else
			{
				m_rightButton.Hidden = false;
				m_rightButtonFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(string.Format("deco_fnt_{0:D2}", ButtonTextureIdTable[(int)type, 1])));
			}
		}

		//// RVA: 0x19E5A18 Offset: 0x19E5A18 VA: 0x19E5A18
		public void Leave()
		{
			IsOpen = false;
			m_windowBase.StartAllAnimGoStop("go_out", "st_out");
			m_swapScrollList.ScrollRect.enabled = false;
			m_swapScrollList.SetEnableScrollBar(false);
		}

		//// RVA: 0x19E5B14 Offset: 0x19E5B14 VA: 0x19E5B14
		public void Open()
		{
			IsOpen = true;
			m_windowBase.StartAllAnimGoStop("go_in", "st_in");
			m_swapScrollList.ScrollRect.enabled = true;
			m_swapScrollList.SetEnableScrollBar(true);
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x19E5C30 Offset: 0x19E5C30 VA: 0x19E5C30
		public void Hide()
		{
			m_windowBase.StartAllAnimGoStop("st_wait", "st_wait");
			m_swapScrollList.ScrollRect.enabled = false;
			m_swapScrollList.SetEnableScrollBar(false);
		}

		//// RVA: 0x19E5D18 Offset: 0x19E5D18 VA: 0x19E5D18
		//private void SaveButtonCallBack() { }

		//// RVA: 0x19E5D1C Offset: 0x19E5D1C VA: 0x19E5D1C
		//private void ClearButtonCallBack() { }

		//// RVA: 0x19E535C Offset: 0x19E535C VA: 0x19E535C
		public void SelectTab(int layouIndex, int index)
		{
			for(int i = 0; i < m_tabLayoutList.Length; i++)
			{
				m_tabLayoutList[i].m_select.StartChildrenAnimGoStop(layouIndex == i ? 1 : 0, layouIndex == i ? 1 : 0);
			}
			m_tabLayoutList[layouIndex].m_callBack(index);
			m_swapScrollList.ScrollRect.StopMovement();
		}

		//// RVA: 0x19E5D20 Offset: 0x19E5D20 VA: 0x19E5D20
		private void GetContentData(out int row, out int column, ref Vector2 size, int num)
		{
			row = 0;
			column = 0;
			size.x += 20;
			size.y += 5;
			column = Mathf.FloorToInt(m_windowSize.x / size.x);
			row = Mathf.CeilToInt(m_windowSize.y / size.y) + 1;
		}

		//// RVA: 0x19E5E10 Offset: 0x19E5E10 VA: 0x19E5E10
		public string AssetName(SelectItemType type)
		{
			if (type == SelectItemType.Serif)
				return LayoutDecoCustomSelectSerif.AssetName;
			else if (type == SelectItemType.Chara)
				return LayoutDecoCustomSelectChara.AssetName;
			return null;
		}

		//// RVA: 0x19E5EF0 Offset: 0x19E5EF0 VA: 0x19E5EF0
		public LayoutDecoCustomSelectItemBase GetComponent(GameObject gameObject, SelectItemType type)
		{
			if (type == SelectItemType.Serif)
				return m_source.GetComponent<LayoutDecoCustomSelectSerif>();
			else if (type == SelectItemType.Chara)
				return m_source.GetComponent<LayoutDecoCustomSelectChara>();
			else return null;
		}

		//// RVA: 0x19E5FBC Offset: 0x19E5FBC VA: 0x19E5FBC
		//public void HideButton() { }

		//// RVA: 0x19E5FC0 Offset: 0x19E5FC0 VA: 0x19E5FC0
		public bool IsPlayingEnd()
		{
			return !m_windowBase.IsPlayingChildren();
		}

		//// RVA: 0x19E58F0 Offset: 0x19E58F0 VA: 0x19E58F0
		private void CreateTabItemList(DecoCustomDecorator.DecoratorType selectType, DecoCustomDecorator.TabType tab)
		{
			m_tabItemDataList.Clear();
			if (tab > DecoCustomDecorator.TabType.Use && tab - 1 < DecoCustomDecorator.TabType.serif4)
				TabSerifChenge(tab);
			else if (tab > DecoCustomDecorator.TabType.serif4 && tab <= DecoCustomDecorator.TabType.pose3)
				TabCharaChenge(tab);
			else if (tab == DecoCustomDecorator.TabType.Use)
				ChangeAll(selectType);
			m_windowText.enabled = m_tabItemDataList.Count < 1;
		}

		//// RVA: 0x19E69C0 Offset: 0x19E69C0 VA: 0x19E69C0
		public void ChangeTab(DecoCustomDecorator.DecoratorType selectType, DecoCustomDecorator.TabType tab)
		{
			CreateTabItemList(selectType, tab);
			m_swapScrollList.SetItemCount(m_tabItemDataList.Count);
			m_swapScrollList.SetPosition(0, 0, 0, false);
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x19E6AD4 Offset: 0x19E6AD4 VA: 0x19E6AD4
		public void UpdateTab(DecoCustomDecorator.DecoratorType selectType, DecoCustomDecorator.TabType tab)
		{
			CreateTabItemList(selectType, tab);
			m_swapScrollList.SetItemCount(m_tabItemDataList.Count);
			m_swapScrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x19E6BAC Offset: 0x19E6BAC VA: 0x19E6BAC
		private int GetStampCharaId(int targetId)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(targetId > 0)
				{
					if (targetId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps.Count)
						return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[targetId - 1].JBFLEDKDFCO_CharaId;
				}
			}
			return 0;
		}

		//// RVA: 0x19E6D00 Offset: 0x19E6D00 VA: 0x19E6D00
		private SeriesAttr.Type GetStampCharaSeries(int charaId)
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if (charaId > 0)
				{
					if (charaId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters.Count)
					{
						if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaId - 1].PPEGAKEIEGM_Enabled == 2)
						{
							return (SeriesAttr.Type)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaId - 1].CPKMLLNADLJ_Serie;
						}
					}
				}
			}
			return SeriesAttr.Type.None;
		}

		//// RVA: 0x19E6754 Offset: 0x19E6754 VA: 0x19E6754
		private int ChangeAll(DecoCustomDecorator.DecoratorType selectType)
		{
			int charaId = 0;
			SeriesAttr.Type serieId = 0;
			if(selectType == DecoCustomDecorator.DecoratorType.Serif)
			{
				if(TargetStampId > 0)
				{
					charaId = GetStampCharaId(TargetStampId);
					serieId = GetStampCharaSeries(charaId);
				}
			}
			for(int i = 0; i < m_selectItemDataList.Count; i++)
			{
				if(selectType != DecoCustomDecorator.DecoratorType.Serif || 
					(m_selectItemDataList[i].series <= SeriesAttr.Type.None || m_selectItemDataList[i].series == serieId) && !m_selectItemDataList[i].isShopProduct && (m_selectItemDataList[i].charaId < 1 || m_selectItemDataList[i].charaId == charaId))
				{
					m_tabItemDataList.Add(m_selectItemDataList[i]);
				}
			}
			return m_tabItemDataList.Count;
		}

		//// RVA: 0x19E5FF0 Offset: 0x19E5FF0 VA: 0x19E5FF0
		public void TabCharaChenge(DecoCustomDecorator.TabType tab)
		{
			NCPPAHHCCAO.FKDIMODKKJD();
			int idx = 0;
			if (tab >= DecoCustomDecorator.TabType.pose1 && tab <= DecoCustomDecorator.TabType.pose3)
				idx = (int)tab - 5;
			for(int i = 0; i < m_selectItemDataList.Count; i++)
			{
				if(m_selectItemDataList[i].emotion == idx)
				{
					m_tabItemDataList.Add(m_selectItemDataList[i]);
				}
			}
			m_tabItemDataList.Sort((SelectItemData data1, SelectItemData data2) =>
			{
				//0x19E72C0
				int res = data1.series - data2.series;
				if (res == 0)
					res = data1.charaType - data2.charaType;
				if (res == 0)
					res = data1.charaId - data2.charaId;
				if (res == 0)
					res = data1.emotion - data2.emotion;
				return res;
			});
		}

		//// RVA: 0x19E6340 Offset: 0x19E6340 VA: 0x19E6340
		public void TabSerifChenge(DecoCustomDecorator.TabType tab)
		{
			if (tab < DecoCustomDecorator.TabType.Temp || tab > DecoCustomDecorator.TabType.serif4)
				tab = DecoCustomDecorator.TabType.Use;
			int charaId = 0;
			SeriesAttr.Type serieId = SeriesAttr.Type.None;
			if(TargetStampId > 0)
			{
				charaId = GetStampCharaId(TargetStampId);
				serieId = GetStampCharaSeries(charaId);
			}
			for(int i = 0; i < m_selectItemDataList.Count; i++)
			{
				if(m_selectItemDataList[i].series <= SeriesAttr.Type.None || m_selectItemDataList[i].series == serieId)
				{
					if(m_selectItemDataList[i].charaId > 0)
					{
						if (m_selectItemDataList[i].charaId != charaId)
							continue;
					}
					if(tab != DecoCustomDecorator.TabType.Use)
					{
						if (m_selectItemDataList[i].tabCategory != (int)tab)
							continue;
					}
					m_tabItemDataList.Add(m_selectItemDataList[i]);
				}
			}
			m_tabItemDataList.Sort((SelectItemData data1, SelectItemData data2) =>
			{
				//0x19E72FC
				int res = Convert.ToInt32(data1.isShopProduct) - Convert.ToInt32(data2.isShopProduct);
				if (res != 0)
					return res;
				res = data1.type - data2.type;
				if (res == 0)
					res = data1.id - data2.id;
				return res;
			});
		}

		//// RVA: 0x19E6EAC Offset: 0x19E6EAC VA: 0x19E6EAC
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			LayoutDecoCustomSelectItemBase l = content as LayoutDecoCustomSelectItemBase;
			if(l != null)
			{
				l.SetExchangeText(false);
				l.SetData(m_tabItemDataList[index].id, m_tabItemDataList[index].type, m_tabItemDataList[index].IsNew, m_tabItemDataList[index].isShopProduct, m_tabItemDataList[index].product);
				l.LoadTexture();
				if (l.Type == SelectItemType.Chara ? TargetStampId == l.Id : TargetSerifId == l.Id)
					l.SelectEffectOn();
				else
					l.SelectEffectOff();
				l.AnimUpdateAll();
			}
		}

		//// RVA: 0x19E70A4 Offset: 0x19E70A4 VA: 0x19E70A4
		public void ScrollVisibleUpdate()
		{
			m_swapScrollList.VisibleRegionUpdate();
		}
	}
}
