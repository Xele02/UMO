using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DecorationDecorator : MonoBehaviour
	{
		public enum DecoratorType
		{
			Bg = 0,
			Chara = 1,
			Object = 2,
			Extra = 3,
			ButtonNum = 4,
			Serif = 4,
			Num = 5,
			None = -1,
		}

		public enum TabType
		{
			None = -1,
			Have = 0,
			Furniture_L = 1,
			Furniture_M = 2,
			Poster = 3,
			Furniture_S = 4,
			Rug = 5,
			Furniture_Wall = 6,
			SerifCommon = 7,
			SerifFamous1 = 8,
			SerifFamous2 = 9,
			SerifFamous3 = 10,
			SerifFamous4 = 11,
			Pose1 = 12,
			Pose2 = 13,
			Pose3 = 14,
			BgSet = 15,
			BgWallL = 16,
			BgWallR = 17,
			BgFloor = 18,
			McDelta = 19,
			McFrontia = 20,
			McSeven = 21,
			McFirst = 22,
			McOthers = 23,
			Collect = 24,
			Transporter = 25,
			PlushToy = 26,
		}

		public class TabCallBackData
		{
			public TabType[] m_typeList; // 0x8

			// RVA: 0x11DF8C4 Offset: 0x11DF8C4 VA: 0x11DF8C4
			public TabCallBackData(TabType[] typeList)
			{
				m_typeList = typeList;
			}
		}

		private const string BundleName = "ly/220.xab";
		private const string AssetName = "root_deco_window_01_layout_root";
		public const int TabMax = 8;
		public static readonly TabCallBackData[] tabCallBackList = new TabCallBackData[5]
			{
				new TabCallBackData(new TabType[4] { TabType.BgSet, TabType.BgWallL, TabType.BgWallR, TabType.BgFloor }),
				new TabCallBackData(new TabType[6] { TabType.Have, TabType.McFirst, TabType.McSeven, TabType.McFrontia, TabType.McDelta, TabType.McOthers }),
				new TabCallBackData(new TabType[8] { TabType.Have, TabType.Furniture_L, TabType.Furniture_M, TabType.Furniture_S, TabType.Furniture_Wall, TabType.Poster, TabType.PlushToy, TabType.Rug }),
				new TabCallBackData(new TabType[2] { TabType.Have, TabType.Collect }),
				new TabCallBackData(new TabType[6] { TabType.Have, TabType.SerifCommon, TabType.SerifFamous1, TabType.SerifFamous2, TabType.SerifFamous3, TabType.SerifFamous4 })
			}; // 0x0
		public Action ClickLeftButtonCallback; // 0x10
		public Action ClickRightButtonCallback; // 0x14
		public DecorationConstants.DecideItemCallback NewPostItemCallback; // 0x18
		public Action<TabType> OnClickTabButton; // 0x1C
		public Action BuyItemCallback; // 0x20
		//[CompilerGeneratedAttribute] // RVA: 0x66B838 Offset: 0x66B838 VA: 0x66B838
		public Action OnStartDownLoad; // 0x24
		//[CompilerGeneratedAttribute] // RVA: 0x66B848 Offset: 0x66B848 VA: 0x66B848
		public Action OnEndDownLoad; // 0x28
		private LayoutDecorationWindow01 m_layoutDecorationWindow01; // 0x2C
		private DecoratorType m_decoratorType; // 0x30
		private TabType m_tabType = TabType.None; // 0x34
		private List<GameObject> m_scrollContentCache1 = new List<GameObject>(); // 0x38
		private List<GameObject> m_scrollContentCache2 = new List<GameObject>(); // 0x3C
		private List<GameObject> m_scrollContentCache3 = new List<GameObject>(); // 0x40
		private Action m_closeCallBack; // 0x44

		public bool IsLoaded { get; private set; } // 0xC
		public bool IsLoadedResource { get; private set; } // 0xD
		public bool RightButtonHidden { set { m_layoutDecorationWindow01.RightButtonHidden = value; } } //0x11DEB24
		public bool LeftButtonHidden { set { m_layoutDecorationWindow01.LeftButtonHidden = value; } } //0x11DEB58
		public bool RightButtonDisable { set { m_layoutDecorationWindow01.RightButtonDisable = value; } } //0x11DEB8C
		public bool LeftButtonDisable { set { m_layoutDecorationWindow01.LeftButtonDisable = value; } } //0x11DEBC0

		//// RVA: 0x11DE858 Offset: 0x11DE858 VA: 0x11DE858
		//public DecorationDecorator.TabType GetTabType() { }

		//// RVA: 0x11DE860 Offset: 0x11DE860 VA: 0x11DE860
		public void LoadResoruce()
		{
			IsLoaded = false;
			this.StartCoroutineWatched(LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D0C34 Offset: 0x6D0C34 VA: 0x6D0C34
		//// RVA: 0x11DE890 Offset: 0x11DE890 VA: 0x11DE890
		private IEnumerator LoadResource()
		{
			//0x11E0058
			yield return this.StartCoroutineWatched(LoadWindow());
			IsLoaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D0CAC Offset: 0x6D0CAC VA: 0x6D0CAC
		//// RVA: 0x11DE93C Offset: 0x11DE93C VA: 0x11DE93C
		private IEnumerator LoadWindow()
		{
			int loadCount;
			AssetBundleLoadLayoutOperationBase op;

			//0x11E01A0
			loadCount = 0;
			op = AssetBundleManager.LoadLayoutAsync("ly/220.xab", "root_deco_window_01_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11DF918
				instance.transform.SetParent(transform, false);
				m_layoutDecorationWindow01 = instance.GetComponent<LayoutDecorationWindow01>();
				m_layoutDecorationWindow01.Hide();
				m_layoutDecorationWindow01.OnClickRightButton = OnClickRightButton;
				m_layoutDecorationWindow01.OnClickLeftButton = OnClickLeftButton;
				m_layoutDecorationWindow01.OnDecideItem = NewPostItemCallback;
				m_layoutDecorationWindow01.OnStartDownLoad += () =>
				{
					//0x11DFC6C
					if(OnStartDownLoad == null)
						return;
					OnStartDownLoad();
				};
				m_layoutDecorationWindow01.OnEndDownLoad += () =>
				{
					//0x11DFCD0
					if(OnEndDownLoad == null)
						return;
					OnEndDownLoad();
				};
			}));
			loadCount++;
			GameObject sourceInstance = null;
			op = AssetBundleManager.LoadLayoutAsync("ly/220.xab", "root_deco_item_00_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11DFD34
				sourceInstance = instance;
			}));
			yield return Co.R(m_layoutDecorationWindow01.Co_LoadContentCache(LayoutDecorationWindow01.ContentCacheName.Cache1, sourceInstance.GetComponent<LayoutUGUIRuntime>()));
			Destroy(sourceInstance);
			loadCount++;
			sourceInstance = null;
			op = AssetBundleManager.LoadLayoutAsync("ly/220.xab", "root_deco_item_01_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11DFD3C
				sourceInstance = instance;
			}));
			yield return Co.R(m_layoutDecorationWindow01.Co_LoadContentCache(LayoutDecorationWindow01.ContentCacheName.Cache2, sourceInstance.GetComponent<LayoutUGUIRuntime>()));
			Destroy(sourceInstance);
			loadCount++;
			sourceInstance = null;
			op = AssetBundleManager.LoadLayoutAsync("ly/220.xab", "root_deco_item_02_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11DFD44
				sourceInstance = instance;
			}));
			yield return Co.R(m_layoutDecorationWindow01.Co_LoadContentCache(LayoutDecorationWindow01.ContentCacheName.Cache3, sourceInstance.GetComponent<LayoutUGUIRuntime>()));
			Destroy(sourceInstance);
			loadCount++;
			sourceInstance = null;
			yield return null;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/220.xab", false);
			}
		}

		//// RVA: 0x11DE9E8 Offset: 0x11DE9E8 VA: 0x11DE9E8
		public void LoadSelectItems(DecoratorType type, TabType tabType)
		{
			m_decoratorType = type;
			m_tabType = tabType;
			IsLoadedResource = false;
			this.StartCoroutineWatched(Co_LoadSelectItem());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D0D24 Offset: 0x6D0D24 VA: 0x6D0D24
		//// RVA: 0x11DEA20 Offset: 0x11DEA20 VA: 0x11DEA20
		public IEnumerator Co_LoadSelectItem()
		{
			//0x11DFE18
			LayoutDecorationWindow01.SelectItemType type = LayoutDecorationWindow01.SelectItemType.None;
			if(m_decoratorType < DecoratorType.Num)
			{
				type = LayoutDecorationWindow01.SelectItemType.Bg;
				switch(m_decoratorType)
				{
					case DecoratorType.Chara:
						type = LayoutDecorationWindow01.SelectItemType.Chara;
						break;
					case DecoratorType.Object:
						type = LayoutDecorationWindow01.SelectItemType.Object;
						if(m_tabType == TabType.Poster)
							type = LayoutDecorationWindow01.SelectItemType.Poster;
						break;
					case DecoratorType.Extra:
						type = LayoutDecorationWindow01.SelectItemType.Extra;
						break;
					case DecoratorType.Serif:
						type = LayoutDecorationWindow01.SelectItemType.Serif;
						break;
				}
			}
			m_layoutDecorationWindow01.LoadResource(type);
			yield return new WaitUntil(() =>
			{
				//0x11DF8E4
				return m_layoutDecorationWindow01.IsLoaded;
			});
			IsLoadedResource = true;
		}

		//// RVA: 0x11DEACC Offset: 0x11DEACC VA: 0x11DEACC
		public void OnClickRightButton()
		{
			ClickRightButtonCallback();
		}

		//// RVA: 0x11DEAF8 Offset: 0x11DEAF8 VA: 0x11DEAF8
		public void OnClickLeftButton()
		{
			ClickLeftButtonCallback();
		}

		//// RVA: 0x11DEBF4 Offset: 0x11DEBF4 VA: 0x11DEBF4
		public void Enter()
		{
			m_layoutDecorationWindow01.SetSetting(m_decoratorType, tabCallBackList[(int)m_decoratorType].m_typeList, ChangeTabCallBack);
			m_layoutDecorationWindow01.Enter();
		}

		//// RVA: 0x11DED78 Offset: 0x11DED78 VA: 0x11DED78
		//public void ReShow() { }

		//// RVA: 0x11DEDA4 Offset: 0x11DEDA4 VA: 0x11DEDA4
		public void Leave()
		{
			m_layoutDecorationWindow01.Leave();
		}

		//// RVA: 0x11DEDD0 Offset: 0x11DEDD0 VA: 0x11DEDD0
		public bool IsPlayingEnd()
		{
			return m_layoutDecorationWindow01.IsPlayingEnd();
		}

		//// RVA: 0x11DEDFC Offset: 0x11DEDFC VA: 0x11DEDFC
		private void ChangeTabCallBack(int tabId)
		{
            TabType tab = tabCallBackList[(int)m_decoratorType].m_typeList[tabId];
            OnClickTabButton(tab);
			m_layoutDecorationWindow01.OnUpdateTab = () =>
			{
				//0x11DFD4C
				OnClickTabButton(tab);
				BuyItemCallback();
			};
		}

		//// RVA: 0x11DEFD0 Offset: 0x11DEFD0 VA: 0x11DEFD0
		//public DecorationDecorator.TabType GetDefaultTab(DecorationDecorator.DecoratorType type) { }

		//// RVA: 0x11DF0DC Offset: 0x11DF0DC VA: 0x11DF0DC
		public void SetSelectItemDataList(TabType tabType, List<KDKFHGHGFEK> selectItemDataList, List<FJGOKILCBJA> productList)
		{
			m_tabType = tabType;
			m_layoutDecorationWindow01.ChangeTab(tabType,selectItemDataList, productList);
		}

		//// RVA: 0x11DF130 Offset: 0x11DF130 VA: 0x11DF130
		//private LayoutDecorationWindow01.SelectItemType DecorationTypeToSelectItemType() { }

		//// RVA: 0x11DF19C Offset: 0x11DF19C VA: 0x11DF19C
		public void SetPostItemList(List<DecorationItemBase> list) 
		{
			m_layoutDecorationWindow01.SetPostItemList(list);
		}

		//// RVA: 0x11DF1D0 Offset: 0x11DF1D0 VA: 0x11DF1D0
		public void UpdateHaveRestNum(int resourceId, List<DecorationItemBase> list)
		{
			m_layoutDecorationWindow01.UpdateHaveRestNum(resourceId, list);
		}

		//// RVA: 0x11DF20C Offset: 0x11DF20C VA: 0x11DF20C
		public void UpdateHaveRestNum()
		{
			m_layoutDecorationWindow01.UpdateHaveRestNum();
		}

		//// RVA: 0x11DF238 Offset: 0x11DF238 VA: 0x11DF238
		public void SetNewIcon(List<bool> isNewList)
		{
			for(int i = 0; i < isNewList.Count; i++)
			{
				m_layoutDecorationWindow01.UpdateTabNewIcon(i, isNewList[i]);
			}
		}

		//// RVA: 0x11DF324 Offset: 0x11DF324 VA: 0x11DF324
		public void EnableSelectItem()
		{
			m_layoutDecorationWindow01.EnableSelectItem();
		}

		//// RVA: 0x11DF350 Offset: 0x11DF350 VA: 0x11DF350
		//public void DisableSelectItem() { }

		//// RVA: 0x11DF37C Offset: 0x11DF37C VA: 0x11DF37C
		public void SetSpeakChara(DecorationChara speakChara)
		{
			m_layoutDecorationWindow01.SetSpeakChara(speakChara);
		}

		//// RVA: 0x11DF3B0 Offset: 0x11DF3B0 VA: 0x11DF3B0
		internal void SetBgResourceId(int flId, int wlId, int wrId)
		{
			m_layoutDecorationWindow01.SetBgResourceId(flId, wlId, wrId);
		}
	}
}
