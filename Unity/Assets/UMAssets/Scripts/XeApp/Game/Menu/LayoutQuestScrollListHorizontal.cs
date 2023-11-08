using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutQuestScrollListHorizontal : LayoutUGUIScriptBase
	{
		public class ItemParam
		{
			public CGJKNOCAPII questData; // 0x8
			public LayoutQuestHorizontalItem item; // 0xC
			public Vector2 pos; // 0x10
			public Vector2 size; // 0x18

			// RVA: 0x187D8A4 Offset: 0x187D8A4 VA: 0x187D8A4
			public ItemParam(CGJKNOCAPII view, Vector2 pos, Vector2 size)
			{
				this.pos = pos;
				this.size = size;
				questData = view;
			}
		}

		private const float ITEM_LAYOUT_W = 370;
		private const float ITEM_LAYOUT_H = 370;
		private const float ITEM_SPACE = 0;
		private const float VIEW_ITEM_OFFSET_Y = 0;
		private readonly Vector2 BASIC_SIZE = new Vector2(370, 370); // 0x14
		private readonly Vector2 START_POS = new Vector2(0, 0); // 0x1C
		[SerializeField] // RVA: 0x67BDBC Offset: 0x67BDBC VA: 0x67BDBC
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x24
		[SerializeField] // RVA: 0x67BDCC Offset: 0x67BDCC VA: 0x67BDCC
		private Text m_nonText; // 0x28
		private List<LayoutQuestHorizontalItem> m_itemLayout = new List<LayoutQuestHorizontalItem>(8); // 0x2C
		private List<LayoutQuestHorizontalItem> m_freeLayout = new List<LayoutQuestHorizontalItem>(8); // 0x30
		private List<ItemParam> m_paramList = new List<ItemParam>(); // 0x34
		private Dictionary<int, List<ItemParam>> m_paramDict = new Dictionary<int, List<ItemParam>>(4); // 0x38
		private Vector2 m_contentsAreaSize; // 0x3C
		private AbsoluteLayout m_root; // 0x44
		private AbsoluteLayout m_leftGuideLayout; // 0x48
		private AbsoluteLayout m_rightGideLayout; // 0x4C
		private AbsoluteLayout m_noneTextLayout; // 0x50

		public bool IsOpen { get; private set; } // 0x54
		public bool IsItemAttach { get; set; } // 0x55

		// RVA: 0x187CFE0 Offset: 0x187CFE0 VA: 0x187CFE0
		private void Update()
		{
			if (!IsOpen)
				return;
			UpdateScroll();
		}

		// RVA: 0x187D30C Offset: 0x187D30C VA: 0x187D30C
		public void AddView(List<LayoutQuestHorizontalItem> item)
		{
			if (IsItemAttach)
				return;
			m_itemLayout = item;
			IsItemAttach = item != null && item.Count > 0;
			m_scrollSupport.BeginAddView();
			for(int i = 0; i < m_itemLayout.Count; i++)
			{
				m_scrollSupport.AddView(m_itemLayout[i].GetBase(), 0, 0);
				m_freeLayout.Add(m_itemLayout[i]);
				m_itemLayout[i].ResetParam();
				m_itemLayout[i].Hide();
			}
			m_scrollSupport.EndAddView();
		}

		//// RVA: 0x187D5B8 Offset: 0x187D5B8 VA: 0x187D5B8
		public void Setup(int type, List<CGJKNOCAPII> viewList)
		{
			if(m_paramDict.ContainsKey(type))
			{
				m_paramDict[type].Clear();
			}
			else
			{
				m_paramDict.Add(type, new List<ItemParam>());
			}
			if(viewList != null)
			{
				for(int i = 0; i < viewList.Count; i++)
				{
					m_paramDict[type].Add(new ItemParam(viewList[i], Vector2.zero, BASIC_SIZE));
				}
			}
		}

		//// RVA: 0x187D8E4 Offset: 0x187D8E4 VA: 0x187D8E4
		public void SetStatus(int type)
		{
			if (!m_paramDict.ContainsKey(type))
				return;
			m_paramList = m_paramDict[type];
			float sizeX = BASIC_SIZE.x;
			float posX = START_POS.x;
			if(m_paramList.Count == 1)
			{
				if (m_scrollSupport != null)
					posX = m_scrollSupport.RangeSize.x * 0.5f;
				else
					posX = 0;
				posX += sizeX * -0.5f + 13;
				m_paramList[0].pos = new Vector2(posX, 0);
			}
			else
			{
				if(m_paramList.Count != 2)
				{
					for(int i = 0; i < m_paramList.Count; i++)
					{
						m_paramList[i].pos = new Vector2(posX, 0);
						posX += sizeX;
					}
				}
				else
				{
					m_paramList[0].pos = new Vector2(130, 0);
					m_paramList[1].pos = new Vector2(540, 0);
				}
			}
			SwitchNoneText(m_paramList.Count == 0);
			SetContentsSizeWidth(m_paramList.Count * sizeX);
		}

		//// RVA: 0x187DE44 Offset: 0x187DE44 VA: 0x187DE44
		public void SetContentsSizeWidth(float width)
		{
			if(m_scrollSupport != null)
			{
				m_contentsAreaSize.x = width;
				m_scrollSupport.ContentSize = m_contentsAreaSize;
			}
		}

		//// RVA: 0x187DF14 Offset: 0x187DF14 VA: 0x187DF14
		public void SwitchGuideEnable(float posX)
		{
			if(m_leftGuideLayout != null)
				m_leftGuideLayout.enabled = posX > 0 && m_paramList.Count > 2;
			if (m_rightGideLayout != null)
				m_rightGideLayout.enabled = posX < 1 && m_paramList.Count > 2;

		}

		//// RVA: 0x187DCBC Offset: 0x187DCBC VA: 0x187DCBC
		public void SwitchNoneText(bool enable)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_nonText != null)
			{
				m_nonText.text = enable ? bk.GetMessageByLabel("quest_event_none_list") : "";
			}
			m_noneTextLayout.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		//// RVA: 0x187E024 Offset: 0x187E024 VA: 0x187E024
		public void ResetList()
		{
			for(int i = 0; i < m_paramList.Count; i++)
			{
				if(m_paramList[i].item != null)
				{
					m_paramList[i].item.Hide();
					ReleaseObject(m_paramList[i].item);
					m_paramList[i].item = null;
				}
			}
			ResetScrollPosition();
		}

		// RVA: 0x187E49C Offset: 0x187E49C VA: 0x187E49C
		public void Enter()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x187E53C Offset: 0x187E53C VA: 0x187E53C
		public void Leave()
		{
			if (!IsOpen)
				return;
			IsOpen = true;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x187E5DC Offset: 0x187E5DC VA: 0x187E5DC
		public void Show()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_root.StartChildrenAnimGoStop("st_in", "st_in");
		}

		//// RVA: 0x187E670 Offset: 0x187E670 VA: 0x187E670
		public void Hide()
		{
			if (!IsOpen)
				return;
			IsOpen = false;
			m_root.StartChildrenAnimGoStop("st_out", "st_out");
			ResetScrollPosition();
		}

		// RVA: 0x187E70C Offset: 0x187E70C VA: 0x187E70C
		public bool IsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		//// RVA: 0x187E31C Offset: 0x187E31C VA: 0x187E31C
		public void ResetScrollPosition()
		{
			if(m_scrollSupport != null)
			{
				m_scrollSupport.scrollRect.content.anchoredPosition = Vector2.zero;
				m_scrollSupport.scrollRect.StopMovement();
			}
		}

		//// RVA: 0x187CFF0 Offset: 0x187CFF0 VA: 0x187CFF0
		private void UpdateScroll()
		{
			float l, r;
			CalcScrollVisibleRange(m_scrollSupport, out l, out r);
			for(int i = 0; i < m_paramList.Count; i++)
			{
				if(m_paramList[i].pos.x + m_paramList[i].size.x < l || r < m_paramList[i].pos.x)
				{
					if(m_paramList[i].item != null)
					{
						m_paramList[i].item.Hide();
						ReleaseObject(m_paramList[i].item);
						m_paramList[i].item = null;
					}
				}
				else
				{
					if(m_paramList[i].item == null)
					{
						m_paramList[i].item = GetFreeObject();
						if(m_paramList[i].item != null)
						{
							m_paramList[i].item.SetStatus(m_paramList[i]);
							m_paramList[i].item.SetPosition((int)m_paramList[i].pos.x, (int)m_paramList[i].pos.y);
							m_paramList[i].item.Show();
						}
					}
				}
			}
		}

		//// RVA: 0x187E880 Offset: 0x187E880 VA: 0x187E880
		private LayoutQuestHorizontalItem GetFreeObject()
		{
			if (m_freeLayout.Count < 1)
				return null;
			LayoutQuestHorizontalItem item = m_freeLayout[0];
			m_freeLayout.RemoveAt(0);
			return item;
		}

		//// RVA: 0x187E258 Offset: 0x187E258 VA: 0x187E258
		private void ReleaseObject(LayoutQuestHorizontalItem obj)
		{
			if (obj == null)
				return;
			m_freeLayout.Add(obj);
		}

		//// RVA: 0x187E738 Offset: 0x187E738 VA: 0x187E738
		private void CalcScrollVisibleRange(LayoutUGUIScrollSupport support, out float xLeft, out float xRight)
		{
			float f = support.scrollRect.horizontalNormalizedPosition;
			SwitchGuideEnable(f);
			xLeft = f * (support.ContentWidth - support.RangeSize.x);
			xRight = xLeft + support.RangeSize.x;
		}

		//// RVA: 0x187E840 Offset: 0x187E840 VA: 0x187E840
		//private bool InScrollView(float x, float y, int w, int h, float xLeft, float xRight) { }

		// RVA: 0x187E970 Offset: 0x187E970 VA: 0x187E970 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("sw_sel_que_ev_select_anim") as AbsoluteLayout;
			m_leftGuideLayout = layout.FindViewByExId("sw_sel_que_ev_select_cmn_arr_l_01") as AbsoluteLayout;
			m_rightGideLayout = layout.FindViewByExId("sw_sel_que_ev_select_cmn_arr_r_01") as AbsoluteLayout;
			m_noneTextLayout = layout.FindViewByExId("sw_sel_que_ev_select_swtbl_ev_non_txt") as AbsoluteLayout;
			SwitchNoneText(false);
			Loaded();
			return true;
		}
	}
}
