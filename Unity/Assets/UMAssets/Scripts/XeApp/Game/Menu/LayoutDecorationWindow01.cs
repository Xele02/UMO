using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;
using mcrs;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationWindow01 : LayoutUGUIScriptBase
	{
		public enum SelectItemType
		{
			Chara = 0,
			Object = 1,
			Serif = 2,
			Bg = 3,
			Extra = 4,
			Poster = 5,
			Num = 6,
			None = -1,
		}
 
		public enum ContentCacheName
		{
			Cache1 = 0,
			Cache2 = 1,
			Cache3 = 2,
		}

		private enum TabFrameType
		{
			Tab7 = 0,
			Tab6 = 1,
			Tab5 = 2,
			Tab4 = 3,
			Tab3 = 4,
			Tab2 = 5,
			Tab0 = 6,
			Tab8 = 7,
		}

		private struct tabLayout
		{
			public AbsoluteLayout m_select; // 0x0
			public AbsoluteLayout m_type; // 0x4
			public AbsoluteLayout m_typeSelect; // 0x8
			public AbsoluteLayout m_newIcon; // 0xC
			public Action<int> ChangeTabCallback; // 0x10
		}

		public delegate void OnClickTabButtonCallBack(int tabInex, int index);

		private readonly int[,] ButtonTextureIdTable = new int[5, 2]
			{
				{ 0, 15 },
				{ 0, 15 }, 
				{ 0, 15 },
				{ 0, 15 },
				{ 15, 7 },
			}; // 0x14
		private readonly string[] TabViewNameTable = new string[8]
			{
				"swtbl_deco_tab_all_tab_01",
				"swtbl_deco_tab_all_tab_02",
				"swtbl_deco_tab_all_tab_03",
				"swtbl_deco_tab_all_tab_04",
				"swtbl_deco_tab_all_tab_05",
				"swtbl_deco_tab_all_tab_06",
				"swtbl_deco_tab_all_tab_08",
				"swtbl_deco_tab_all_tab_07"
			}; // 0x18
		private readonly int[] TabFrameByCountTable = new int[9]
			{
				6, 6, 5, 4, 3, 2, 1, 0, 7
			}; // 0x1C
		[SerializeField]
		private ActionButton m_leftButton; // 0x20
		[SerializeField]
		private RawImageEx m_leftButtonFont; // 0x24
		[SerializeField]
		private List<ActionButton> m_rightButton = new List<ActionButton>(); // 0x28
		[SerializeField]
		private List<RawImageEx> m_rightButtonFont = new List<RawImageEx>(); // 0x2C
		[SerializeField]
		private RawImageEx[] logoFirst; // 0x30
		[SerializeField]
		private RawImageEx[] logoSeven; // 0x34
		[SerializeField]
		private RawImageEx[] logoFrontia; // 0x38
		[SerializeField]
		private RawImageEx[] logoDelta; // 0x3C
		[SerializeField]
		private RawImageEx[] logoOther; // 0x40
		[SerializeField]
		private List<ButtonBase> m_tabButtons; // 0x44
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x48
		[SerializeField]
		private Text m_windowText; // 0x4C
		[SerializeField]
		private Vector2 m_windowSize; // 0x50
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x58
		private AbsoluteLayout m_windowBase; // 0x5C
		private AbsoluteLayout m_windowButtonTbl; // 0x60
		private AbsoluteLayout m_tabChangeBase; // 0x64
		private TexUVListManager m_uvManager; // 0x68
		private tabLayout[] m_tabLayoutList = new tabLayout[8]; // 0x6C
		public Action OnClickRightButton; // 0x70
		public Action OnClickLeftButton; // 0x74
		public DecorationConstants.DecideItemCallback OnDecideItem; // 0x78
		public OnClickTabButtonCallBack OnClickTabButton; // 0x7C
		public Action OnUpdateTab; // 0x80
		public bool IsEnter; // 0x85
		private List<KDKFHGHGFEK> m_viewDecoItemDataList = new List<KDKFHGHGFEK>(); // 0x88
		private List<FJGOKILCBJA> m_viewShopProductList = new List<FJGOKILCBJA>(); // 0x8C
		private SelectItemType m_type; // 0x90
		private DecorationDecorator.TabType m_tab; // 0x94
		private int m_selectTabIndex; // 0x98
		private DecorationDecorator.DecoratorType m_decorationType; // 0x9C
		private List<DecorationItemBase> m_postItemList; // 0xA0
		private Dictionary<int, List<LayoutDecorationSelectItemBase>> m_scrollContentCache = new Dictionary<int, List<LayoutDecorationSelectItemBase>>(); // 0xA4
		private bool m_isPower; // 0xA8
		private bool m_isPause; // 0xA9
		private CKPOGHOIBEP buyer = new CKPOGHOIBEP(); // 0xAC
		private int m_scrollPosition; // 0xB0
		private bool m_isEnableFamousPhrase4; // 0xB4
		private int m_tabNum; // 0xB8
		private bool m_isReShow; // 0xBC
		//[CompilerGeneratedAttribute] // RVA: 0x66C388 Offset: 0x66C388 VA: 0x66C388
		public Action OnStartDownLoad; // 0xC0
		//[CompilerGeneratedAttribute] // RVA: 0x66C398 Offset: 0x66C398 VA: 0x66C398
		public Action OnEndDownLoad; // 0xC4
		private Coroutine m_downLoadPolingCoroutine; // 0xC8
		private StringBuilder m_strBuilder = new StringBuilder(); // 0xCC
		private bool m_isResetItem; // 0xD0
		private DecorationChara m_speakChara; // 0xD4
		private int m_bgFloorId; // 0xD8
		private int m_bgWallLeftId; // 0xDC
		private int m_bgWallRightId; // 0xE0

		public bool LeftButtonHidden { set { m_leftButton.Hidden = value; } } //0x18C1810
		public bool LeftButtonDisable { set { m_leftButton.Disable = value; } } //0x18C1844
		public bool RightButtonHidden { set {
			m_rightButton.ForEach((ActionButton btn) =>
			{
				//0x18C6EBC
				btn.Hidden = value;
			});
		} } //0x18C1878
		public bool RightButtonDisable { set { m_rightButton.ForEach((ActionButton btn) =>
		{
			//0x18C6EF8
			btn.Disable = value;
		}); } } //0x18C1978
		public ScrollRect ScrollRect { get { return m_scrollRect; } } //0x18B4FF8
		public bool IsLoaded { get; private set; } // 0x84
		public bool IsAnimPlaying { get; set; } // 0xAA
		private int ListCount { get
		{
			return m_viewDecoItemDataList.Count + m_viewShopProductList.Count;
		} } //0x18C1A88

		// RVA: 0x18C1F64 Offset: 0x18C1F64 VA: 0x18C1F64
		private void OnApplicationPause(bool pauseStatus)
		{
			m_isPause = true;
		}

		// RVA: 0x18C1F70 Offset: 0x18C1F70 VA: 0x18C1F70
		private void OnApplicationFocus(bool hasFocus)
		{
			m_isPower = true;
		}

		//// RVA: 0x18B6F10 Offset: 0x18B6F10 VA: 0x18B6F10
		public bool GetIsDragCancel()
		{
			if(!m_isPower && !m_isPause)
				return false;
			m_isPower = false;
			m_isPause = false;
			return true;
		}

		// RVA: 0x18C1F7C Offset: 0x18C1F7C VA: 0x18C1F7C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewById("sw_deco_window_anim") as AbsoluteLayout;
			m_tabChangeBase = layout.FindViewById("swtbl_deco_tab_all") as AbsoluteLayout;
			m_windowButtonTbl = layout.FindViewById("swtbl_deco_btn_01") as AbsoluteLayout;
			for(int i = 0; i < 8; i++)
			{
				AbsoluteLayout l = layout.FindViewByExId(TabViewNameTable[i]) as AbsoluteLayout;
				if (l == null)
					m_tabLayoutList[i].m_select = null;
				else
				{
					m_tabLayoutList[i].m_select = l;
					m_tabLayoutList[i].m_type = l.FindViewById("swtbl_deco_tab_font_01") as AbsoluteLayout;
					m_tabLayoutList[i].m_typeSelect = l.FindViewById("swtbl_deco_tab_font_02") as AbsoluteLayout;
					m_tabLayoutList[i].m_newIcon = l.FindViewById("swtbl_new_icon_01") as AbsoluteLayout;
				}
			}
			m_rightButton.ForEach((ActionButton btn) =>
			{
				//0x18C6530
				btn.AddOnClickCallback(() =>
				{
					//0x18C65D8
					OnClickRightButton();
				});
			});
			m_leftButton.AddOnClickCallback(() =>
			{
				//0x18C6604
				OnClickLeftButton();
			});
			IsEnter = false;
			m_uvManager = uvMan;
			IsAnimPlaying = false;
			m_isPause = false;
			m_isPower = false;
			m_scrollPosition = 0;
			m_tab = DecorationDecorator.TabType.None;
			m_selectTabIndex = 0;
			m_decorationType = DecorationDecorator.DecoratorType.None;
			m_isReShow = false;
			m_isResetItem = false;
			m_speakChara = null;
			m_isEnableFamousPhrase4 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.LPJLEHAJADA("is_enable_famous_phrase_4", 0) == 1;
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(4, (IiconTexture texture) =>
			{
				//0x18C6630
				Array.ForEach(logoFirst, (RawImageEx x) =>
				{
					//0x18C6F34
					texture.Set(x);
				});
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(3, (IiconTexture texture) =>
			{
				//0x18C6720
				Array.ForEach(logoSeven, (RawImageEx x) =>
				{
					//0x18C7014
					texture.Set(x);
				});
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(2, (IiconTexture texture) =>
			{
				//0x18C6810
				Array.ForEach(logoFrontia, (RawImageEx x) =>
				{
					//0x18C70F4
					texture.Set(x);
				});
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(1, (IiconTexture texture) =>
			{
				//0x18C6900
				Array.ForEach(logoDelta, (RawImageEx x) =>
				{
					//0x18C71D4
					texture.Set(x);
				});
			});
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(11, (IiconTexture texture) =>
			{
				//0x18C69F0
				Array.ForEach(logoOther, (RawImageEx x) =>
				{
					//0x18C72B4
					texture.Set(x);
				});
			});
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D6F6C Offset: 0x6D6F6C VA: 0x6D6F6C
		//// RVA: 0x18C2980 Offset: 0x18C2980 VA: 0x18C2980
		public IEnumerator Co_LoadContentCache(ContentCacheName cacheName, LayoutUGUIRuntime sourceInstance)
		{
			List<LayoutDecorationSelectItemBase> list;

			//0x18C76BC
			list = null;
			Vector2 s = sourceInstance.GetComponent<LayoutDecorationSelectItemBase>().Size;
			int row, column;
			GetContentData(out row, out column, ref s);
			int count = row * column;
			if(!m_scrollContentCache.TryGetValue((int)cacheName, out list))
			{
				list = new List<LayoutDecorationSelectItemBase>();
				m_scrollContentCache.Add((int)cacheName, list);
			}
			for(int i = 0; i < count; i++)
			{
				LayoutUGUIRuntime r = Instantiate(sourceInstance);
				r.Layout = sourceInstance.Layout.DeepClone();
				r.UvMan = sourceInstance.UvMan;
				r.IsLayoutAutoLoad = false;
				r.LoadLayout();
				list.Add(r.GetComponent<LayoutDecorationSelectItemBase>());
			}
			yield return null;
			foreach(var l in list)
			{
				l.transform.SetParent(transform, false);
				l.gameObject.SetActive(false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D6FE4 Offset: 0x6D6FE4 VA: 0x6D6FE4
		//// RVA: 0x18C2A60 Offset: 0x18C2A60 VA: 0x18C2A60
		private IEnumerator Co_LoadItemLayout(SelectItemType type)
		{
			Vector2 size;
			int row;
			int col;

			//0x18C7D00
			int id = 0;
			if(type > 0 && (int)type - 1 < 4)
				id = new int[4] { 1, 2, 2, 1 } [(int)type - 1];
			List<LayoutDecorationSelectItemBase> l;
			if(m_scrollContentCache.TryGetValue(id, out l))
			{
				size = l[0].Size;
				GetContentData(out row, out col, ref size);
				for(int i = 0; i < l.Count; i++)
				{
					m_swapScrollList.AddScrollObject(l[i]);
					l[i].gameObject.SetActive(true);
				}
				yield return null;
				m_swapScrollList.Apply(row, col, size, new Vector2(5, 5));
				m_swapScrollList.SetContentEscapeMode(true);
				if(m_swapScrollList != null)
				{
					m_swapScrollList.OnUpdateItem.RemoveAllListeners();
					m_swapScrollList.OnUpdateItem.AddListener(Co_UpdateList);
				}
				m_windowText.text = "";
				IsLoaded = true;
			}
		}

		//// RVA: 0x18C2B28 Offset: 0x18C2B28 VA: 0x18C2B28
		private void ResetItem()
		{
			m_isResetItem = true;
			ResetTab();
			foreach(var obj in m_swapScrollList.ScrollObjects)
			{
				obj.transform.SetParent(transform, false);
				obj.gameObject.SetActive(false);
			}
			m_swapScrollList.RemoveScrollObject();
		}

		//// RVA: 0x18C2D58 Offset: 0x18C2D58 VA: 0x18C2D58
		private void ResetTab()
		{
			m_viewDecoItemDataList.Clear();
			m_viewShopProductList.Clear();
		}

		//// RVA: 0x18C2DFC Offset: 0x18C2DFC VA: 0x18C2DFC
		public void LoadResource(SelectItemType type)
		{
			m_type = type;
			IsLoaded = false;
			ResetItem();
			this.StartCoroutineWatched(Co_LoadItemLayout(type));
		}

		//// RVA: 0x18C2E40 Offset: 0x18C2E40 VA: 0x18C2E40
		public void UpdateTabNewIcon(int tabIndex, bool isNew)
		{
			int idx = GetLayoutIndex(tabIndex);
			if(idx == -1)
				return;
			m_tabLayoutList[idx].m_newIcon.StartChildrenAnimGoStop(!isNew ? 1 : 0, !isNew ? 1 : 0);
		}

		//// RVA: 0x18C2F4C Offset: 0x18C2F4C VA: 0x18C2F4C
		private void SettingTexture(DecorationDecorator.DecoratorType type)
		{
			if(ButtonTextureIdTable[(int)type, 0] == 0)
			{
				m_leftButton.Hidden = true;
			}
			else
			{
				m_leftButton.Hidden = false;
				m_leftButtonFont.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(string.Format("deco_fnt_{0:D2}", ButtonTextureIdTable[(int)type, 0])));
			}
			if(ButtonTextureIdTable[(int)type, 1] == 0)
			{
				RightButtonHidden = true;
			}
			else
			{
				RightButtonHidden = false;
				string k = string.Format("deco_fnt_{0:D2}", ButtonTextureIdTable[(int)type, 1]);
				m_rightButtonFont.ForEach((RawImageEx font) =>
				{
					//0x18C7394
					font.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(k));
				});
				m_windowButtonTbl.StartChildrenAnimGoStop(ButtonTextureIdTable[(int)type, 1] == 15 ? 1 : 0, ButtonTextureIdTable[(int)type, 1] == 15 ? 1 : 0);
			}
		}

		//// RVA: 0x18C33D4 Offset: 0x18C33D4 VA: 0x18C33D4
		public void Leave()
		{
			if(!IsEnter)
				return;
			IsEnter = false;
			m_windowBase.StartAllAnimGoStop("go_out", "st_out");
			m_swapScrollList.ScrollRect.enabled = false;
			m_swapScrollList.SetEnableScrollBar(false);
			DisableSelectItem();
		}

		//// RVA: 0x18C3778 Offset: 0x18C3778 VA: 0x18C3778
		public void SetSetting(DecorationDecorator.DecoratorType type, DecorationDecorator.TabType[] tab, Action<int> changeTabCallBack)
		{
			m_tabNum = tab.Length;
			int frame = TabFrameByTabCount(tab.Length);
			if(type == DecorationDecorator.DecoratorType.Extra)
			{
				m_tabNum = 1;
				frame = 6;
			}
			else
			{
				if(type == DecorationDecorator.DecoratorType.Serif && !m_isEnableFamousPhrase4)
				{
					frame = TabFrameByTabCount(tab.Length - 1);
					m_tabNum = tab.Length - 1;
				}
			}
			m_tabChangeBase.StartChildrenAnimGoStop(frame, frame);
			for(int i = 0; i < m_tabNum; i++)
			{
				int index = i;
				int i2 = GetLayoutIndex(i);
				if(i2 != -1)
				{
					m_tabLayoutList[i2].ChangeTabCallback = changeTabCallBack;
					if(type == DecorationDecorator.DecoratorType.Extra)
					{
						m_tabButtons[i2].ClearOnClickCallback();
					}
					else
					{
						m_tabLayoutList[i2].m_type.StartAllAnimGoStop((int)tab[i], (int)tab[i]);
						m_tabLayoutList[i2].m_typeSelect.StartAllAnimGoStop((int)tab[i], (int)tab[i]);
						m_tabButtons[i2].ClearOnClickCallback();
						m_tabButtons[i2].AddOnClickCallback(() =>
						{
							//0x18C7494
							ChangeTab(index);
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						});
					}
				}
			}
			SettingTexture(type);
			InitTabSetting(type);
		}

		//// RVA: 0x18C3DB4 Offset: 0x18C3DB4 VA: 0x18C3DB4
		public void Enter()
		{
			if(IsEnter)
				return;
			IsEnter = true;
			m_windowBase.StartAllAnimGoStop("go_in", "st_in");
			m_swapScrollList.ScrollRect.enabled = true;
			m_swapScrollList.SetEnableScrollBar(true);
		}

		//// RVA: 0x18C3EBC Offset: 0x18C3EBC VA: 0x18C3EBC
		public void Hide() 
		{
			m_windowBase.StartAllAnimGoStop("st_wait", "st_wait");
			m_swapScrollList.ScrollRect.enabled = false;
			m_swapScrollList.SetEnableScrollBar(false);
		}

		//// RVA: 0x18C3FA4 Offset: 0x18C3FA4 VA: 0x18C3FA4
		//private void SaveButtonCallBack() { }

		//// RVA: 0x18C3FA8 Offset: 0x18C3FA8 VA: 0x18C3FA8
		//private void ClearButtonCallBack() { }

		//// RVA: 0x18C3FAC Offset: 0x18C3FAC VA: 0x18C3FAC
		private void ChangeTab(int tabIndex)
		{
			m_selectTabIndex = tabIndex;
			int index = GetLayoutIndex(tabIndex);
			for(int i = 0; i < m_tabLayoutList.Length; i++)
			{
				if(m_tabLayoutList[i].m_select != null)
					m_tabLayoutList[i].m_select.StartChildrenAnimGoStop(index == i ? 1 : 0, index == i ? 1 : 0);
			}
			if(index == -1)
				return;
			m_tabLayoutList[index].ChangeTabCallback(m_selectTabIndex);
		}

		//// RVA: 0x18C2ED8 Offset: 0x18C2ED8 VA: 0x18C2ED8
		private int GetLayoutIndex(int tabIndex)
		{
			if(m_tabNum <= tabIndex)
				return -1;
			if(m_tabNum - 1 <= tabIndex)
				tabIndex = 7;
			if(m_tabLayoutList[tabIndex].m_select == null)
				tabIndex = -1;
			return tabIndex;
		}

		//// RVA: 0x18C3CCC Offset: 0x18C3CCC VA: 0x18C3CCC
		private int TabFrameByTabCount(int tabCount)
		{
			if(tabCount < 1)
				tabCount = 0;
			if(tabCount >= TabFrameByCountTable.Length)
				tabCount = TabFrameByCountTable.Length - 1;
			return TabFrameByCountTable[tabCount];
		}

		//// RVA: 0x18C4164 Offset: 0x18C4164 VA: 0x18C4164
		public void GetContentData(out int row, out int column, ref Vector2 size)
		{
			row = 0;
			column = 0;
			size.x += 20;
			size.y += 5;
			column = Mathf.FloorToInt(m_windowSize.x / size.x);
			row = Mathf.CeilToInt(m_windowSize.y / size.y) + 1;
		}

		//// RVA: 0x18C4254 Offset: 0x18C4254 VA: 0x18C4254
		//public string AssetName(LayoutDecorationWindow01.SelectItemType type) { }

		//// RVA: 0x18C4390 Offset: 0x18C4390 VA: 0x18C4390
		//private LayoutDecorationWindow01.ContentCacheName GetCacheName(LayoutDecorationWindow01.SelectItemType type) { }

		//// RVA: 0x18C43B0 Offset: 0x18C43B0 VA: 0x18C43B0
		//private LayoutDecorationSelectItemBase GetComponent(GameObject gameObject, LayoutDecorationWindow01.SelectItemType type) { }

		//// RVA: 0x18C44CC Offset: 0x18C44CC VA: 0x18C44CC
		//public void HideButton() { }

		//// RVA: 0x18C44D0 Offset: 0x18C44D0 VA: 0x18C44D0
		public bool IsPlayingEnd()
		{
			return !m_windowBase.IsPlayingChildren();
		}

		//// RVA: 0x18C4500 Offset: 0x18C4500 VA: 0x18C4500
		public void ChangeTab(DecorationDecorator.TabType tabType, List<KDKFHGHGFEK> selectItemDataList, List<FJGOKILCBJA> productList)
		{
			SetSelectItemDataList(tabType, selectItemDataList, productList);
			m_tab = tabType;
			SetUpList();
		}

		//// RVA: 0x18C452C Offset: 0x18C452C VA: 0x18C452C
		private void SetSelectItemDataList(DecorationDecorator.TabType tabType, List<KDKFHGHGFEK> selectItemDataList, List<FJGOKILCBJA> productList)
		{
			ResetTab();
			if(tabType == DecorationDecorator.TabType.Have && m_type == SelectItemType.Serif)
			{
				KDKFHGHGFEK data = new KDKFHGHGFEK();
				m_viewDecoItemDataList.Add(data);
			}
			for(int i = 0; i < selectItemDataList.Count; i++)
			{
				if(selectItemDataList[i].NPADACLCNAN_Category != 0)
				{
					m_viewDecoItemDataList.Add(selectItemDataList[i]);
				}
			}
			if(tabType == DecorationDecorator.TabType.Have)
				return;
			m_viewShopProductList.AddRange(productList);
		}

		//// RVA: 0x18C4754 Offset: 0x18C4754 VA: 0x18C4754
		//private void ChangeTabList(DecorationDecorator.TabType tab) { }

		//// RVA: 0x18C475C Offset: 0x18C475C VA: 0x18C475C
		private void SetUpList()
		{
			if(!m_isResetItem)
				UpdateList(ListCount, !m_isReShow && (m_tab < DecorationDecorator.TabType.BgSet || m_tab > DecorationDecorator.TabType.BgFloor));
			else
			{
				m_isResetItem = false;
				UpdateList(ListCount, true);
			}
		}

		//// RVA: 0x18C47C8 Offset: 0x18C47C8 VA: 0x18C47C8
		//private bool IsResetScrollPosition(DecorationDecorator.TabType tab) { }

		//// RVA: 0x18C4834 Offset: 0x18C4834 VA: 0x18C4834
		private void UpdateList(int count, bool resetScroll)
		{
			m_swapScrollList.SetItemCount(count);
			float y;
			if(resetScroll)
			{
				m_scrollPosition = 0;
				y = 0;
			}
			else
			{
				m_scrollPosition = m_swapScrollList.ListTopPosition;
				m_scrollPosition = Mathf.Clamp(m_scrollPosition, 0, m_scrollPosition);
				y = Mathf.Abs(m_swapScrollList.RelativePositon);
			}
			m_swapScrollList.ResetScrollVelocity();
			m_swapScrollList.SetPosition(m_scrollPosition, 0, y, false);
			m_swapScrollList.VisibleRegionUpdate();
			SetWindowText(ListCount);
			m_isReShow = false;
		}

		//// RVA: 0x18C4A00 Offset: 0x18C4A00 VA: 0x18C4A00
		private void SetWindowText(int itemCount)
		{
			if(itemCount != 0)
			{
				m_windowText.text = "";
			}
			else
			{
				m_windowText.text = MessageManager.Instance.GetMessage("menu", m_type == SelectItemType.Serif ? "customstamp_have_serif_not" : "deco_no_have_text");
			}
		}

		//// RVA: 0x18C3D70 Offset: 0x18C3D70 VA: 0x18C3D70
		private void InitTabSetting(DecorationDecorator.DecoratorType type)
		{
			if(m_decorationType == type)
			{
				m_isReShow = true;
				ChangeTab(m_selectTabIndex);
			}
			else
			{
				ChangeTab(0);
			}
			m_decorationType = type;
		}

		//// RVA: 0x18C4B34 Offset: 0x18C4B34 VA: 0x18C4B34
		private void Co_UpdateList(int index, SwapScrollListContent content)
		{
			LayoutDecorationSelectItemBase c = content as LayoutDecorationSelectItemBase;
			if(c == null)
				return;
			int itemId = 0;
			if(index < m_viewDecoItemDataList.Count)
			{
				c.Setting(m_viewDecoItemDataList[index], GetPostNum(m_viewDecoItemDataList[index].KGBAOKCMALD), m_viewDecoItemDataList[index].FMGBBKHJDEC_CanKira, m_tab, m_type, this);
				c.DecideItemCallback = (LayoutDecorationSelectItemBase it, bool isTapSelect) =>
				{
					//0x18C6AE0
					OnDecideItem(it, isTapSelect);
				};
				itemId = m_viewDecoItemDataList[index].KGBAOKCMALD;
			}
			else
			{
				FJGOKILCBJA item = m_viewShopProductList[index - m_viewDecoItemDataList.Count];
				c.SettingExchange(item, m_tab, m_type, this);
				c.DecideItemCallback = (LayoutDecorationSelectItemBase _, bool isTapSelect) =>
				{
					//0x18C6C4C
					buyer.IJELHNMHAJH(this, item, () =>
					{
						//0x18C6B1C
						if(OnUpdateTab != null)
							OnUpdateTab();
					}, null, () =>
					{
						//0x18C6BAC
						MenuScene.Instance.GotoTitle();
					}, () =>
					{
						//0x18C6C48
						return;
					});
				};
				itemId = item.KIJAPOFAGPN_ItemFullId;
			}
			if(itemId == 0 || !TryInstall(itemId))
			{
				c.EnableSelectItem();
			}
			else if(m_downLoadPolingCoroutine == null)
			{
				if(OnStartDownLoad != null)
					return;
				DisableSelectItem();
				m_downLoadPolingCoroutine = this.StartCoroutineWatched(Co_AssetDownLoadPoling());
			}
			c.LoadTexture();
			c.LayoutAllUpdate();
		}

		//// RVA: 0x18C5234 Offset: 0x18C5234 VA: 0x18C5234
		private bool TryInstall(int itemId)
		{
			m_strBuilder.Clear();
			KDKFHGHGFEK k = new KDKFHGHGFEK();
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
            k.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), cat);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
			{
				string str = DecorationConstants.GetItemBundleName(k, false, DecorationConstants.Attribute.Type.BgFloor);
				if(str != "")
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
				str = DecorationConstants.GetItemBundleName(k, false, DecorationConstants.Attribute.Type.BgWallL);
				if(str != "")
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
				str = DecorationConstants.GetItemBundleName(k, false, DecorationConstants.Attribute.Type.BgWallR);
				if(str != "")
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
			}
			else
			{
				string str = DecorationConstants.GetItemBundleName(k, false, DecorationConstants.Attribute.Type.None);
				if(str != "")
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
				if(k.OHAMGNMKOII())
				{
					str = DecorationConstants.GetItemBundleName(k, true, DecorationConstants.Attribute.Type.None);
					if(str != "")
						KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str);
				}
			}
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D705C Offset: 0x6D705C VA: 0x6D705C
		//// RVA: 0x18C5638 Offset: 0x18C5638 VA: 0x18C5638
		private IEnumerator Co_AssetDownLoadPoling()
		{
			//0x18C7514
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			if(OnEndDownLoad != null)
				OnEndDownLoad();
			EnableSelectItem();
			m_downLoadPolingCoroutine = null;
		}

		//// RVA: 0x18C4F50 Offset: 0x18C4F50 VA: 0x18C4F50
		private int GetPostNum(int id)
		{
			int _id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
			if(m_type == SelectItemType.Bg)
			{
				if(m_tab >= DecorationDecorator.TabType.BgSet && m_tab <= DecorationDecorator.TabType.BgFloor)
				{
					switch(m_tab)
					{
						case DecorationDecorator.TabType.BgSet:
							return -1;
						case DecorationDecorator.TabType.BgWallL:
							return _id == m_bgWallLeftId ? 1 : 0;
						case DecorationDecorator.TabType.BgWallR:
							return _id == m_bgWallRightId ? 1 : 0;
						case DecorationDecorator.TabType.BgFloor:
							return _id == m_bgFloorId ? 1 : 0;
					}
				}
				return 0;
			}
			else if(m_type == SelectItemType.Serif)
			{
				if(m_speakChara != null)
					return m_speakChara.GetSerifId() == _id ? 1 : 0;
				return 0;
			}
			else
			{
				int r = 0;
				foreach(var k in m_postItemList)
				{
					if(id == k.ResourceId)
						r++;
				}
				return r;
			}
		}

		//// RVA: 0x18C56E4 Offset: 0x18C56E4 VA: 0x18C56E4
		public void SetPostItemList(List<DecorationItemBase> list) 
		{
			m_postItemList = list;
		}

		//// RVA: 0x18C56EC Offset: 0x18C56EC VA: 0x18C56EC
		public void SetSpeakChara(DecorationChara chara)
		{
			m_speakChara = chara;
		}

		//// RVA: 0x18C56F4 Offset: 0x18C56F4 VA: 0x18C56F4
		public void SetBgResourceId(int flId, int wlId, int wrId)
		{
			m_bgFloorId = flId;
			m_bgWallLeftId = wlId;
			m_bgWallRightId = wrId;
		}

		//// RVA: 0x18C5700 Offset: 0x18C5700 VA: 0x18C5700
		public void UpdateHaveRestNum(int resourceId, List<DecorationItemBase> list)
		{
			m_postItemList = list;
			foreach (var s in m_swapScrollList.ScrollObjects)
			{
				LayoutDecorationSelectItemBase ss = s as LayoutDecorationSelectItemBase;
				if(ss.Data != null && ss.IsUpdateRestNum && ss.Data.KGBAOKCMALD == resourceId)
				{
					int c = GetPostNum(ss.Data.KGBAOKCMALD);
					ss.SetStatusIcon(c > -1);
					ss.SetNum(ss.Data.BFINGCJHOHI, ss.Data.BFINGCJHOHI - c);
					return;
				}
			}
		}

		//// RVA: 0x18C59F0 Offset: 0x18C59F0 VA: 0x18C59F0
		public void UpdateHaveRestNum()
		{
			foreach(var s in m_swapScrollList.ScrollObjects)
			{
				LayoutDecorationSelectItemBase ss = s as LayoutDecorationSelectItemBase;
				KDKFHGHGFEK d = ss.Data;
				if(d != null)
				{
					int c = GetPostNum(d.KGBAOKCMALD);
					ss.SetStatusIcon(c > -1);
					ss.SetNum(d.BFINGCJHOHI, d.BFINGCJHOHI - c);
				}
			}
		}

		//// RVA: 0x18C5CB8 Offset: 0x18C5CB8 VA: 0x18C5CB8
		public void EnableSelectItem()
		{
			foreach(var s in m_swapScrollList.ScrollObjects)
			{
				LayoutDecorationSelectItemBase l = s as LayoutDecorationSelectItemBase;
				l.EnableSelectItem();
			}
		}

		//// RVA: 0x18C34E4 Offset: 0x18C34E4 VA: 0x18C34E4
		public void DisableSelectItem()
		{
			foreach(var s in m_swapScrollList.ScrollObjects)
			{
				LayoutDecorationSelectItemBase layout = s as LayoutDecorationSelectItemBase;
				layout.DisableSelectItem();
			}
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6D7164 Offset: 0x6D7164 VA: 0x6D7164
		//// RVA: 0x18C6B1C Offset: 0x18C6B1C VA: 0x18C6B1C
		//private void <Co_UpdateList>b__115_2() { }
	}
}
