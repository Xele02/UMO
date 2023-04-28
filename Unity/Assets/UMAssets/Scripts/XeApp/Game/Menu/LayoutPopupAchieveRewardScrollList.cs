using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAchieveRewardScrollList : LayoutUGUIScriptBase
	{
		public class ItemParam
		{
			public enum eType
			{
				Clear = 0,
				Score = 1,
				Combo = 2,
				All = 3,
			}

			public eType type; // 0x8
			public FPGEMAIAMBF_RewardData.LOIJICNJMKA rewardData; // 0xC
			public LayoutPopupAchieveRewardItem item; // 0x10
			public Vector2 pos; // 0x14
			public Vector2 size; // 0x1C

			// RVA: 0x15E313C Offset: 0x15E313C VA: 0x15E313C
			public ItemParam(FPGEMAIAMBF_RewardData.LOIJICNJMKA reward, Vector2 pos, Vector2 size, eType type)
			{
				this.type = type;
				rewardData = reward;
				this.pos = pos;
				this.size = size;
			}
		}

		private const float ITEM_LAYOUT_W = 622;
		private const float ITEM_LAYOUT_H = 84;
		private const float ITEM_SPACE = 8;
		private const float VIEW_ITEM_OFFSET_X = 0;
		private const float BOTTOM_SPACE = 4;
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x14
		private List<LayoutPopupAchieveRewardItem> m_itemLayout = new List<LayoutPopupAchieveRewardItem>(); // 0x18
		private List<LayoutPopupAchieveRewardItem> m_freeLayout = new List<LayoutPopupAchieveRewardItem>(); // 0x1C
		private List<ItemParam> m_paramList = new List<ItemParam>(); // 0x20
		private Image m_raycastTarget; // 0x24
		private Vector2 m_contentsAreaSize; // 0x28

		public int selectMusicId { get; set; } // 0x30

		//// RVA: 0x15E28E8 Offset: 0x15E28E8 VA: 0x15E28E8
		public void AddView(List<LayoutPopupAchieveRewardItem> item)
		{
			m_itemLayout = item;
			m_scrollSupport.BeginAddView();
			for(int i = 0; i < m_itemLayout.Count; i++)
			{
				m_scrollSupport.AddView(m_itemLayout[i].GetBase(), 0, i * 84 + 8);
				m_freeLayout.Add(m_itemLayout[i]);
				m_freeLayout[i].Hide();
			}
			m_scrollSupport.EndAddView();
		}

		//// RVA: 0x15E2B6C Offset: 0x15E2B6C VA: 0x15E2B6C
		public void Setup(List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> clearList, List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> scoreList, List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> comboList)
		{
			Vector2 s = new Vector2(622, 92);
			for(int i = 0; i < scoreList.Count; i++)
			{
				ItemParam param = new ItemParam(scoreList[i], new Vector2(0, 0), s, ItemParam.eType.Score);
				m_paramList.Add(param);
			}
			for (int i = 0; i < comboList.Count; i++)
			{
				ItemParam param = new ItemParam(comboList[i], new Vector2(0, 0), s, ItemParam.eType.Combo);
				m_paramList.Add(param);
			}
			for (int i = 0; i < clearList.Count; i++)
			{
				ItemParam param = new ItemParam(clearList[i], new Vector2(0, 0), s, ItemParam.eType.Clear);
				m_paramList.Add(param);
			}
			int y = 0;
			for(int i = 0; i < m_paramList.Count; i++)
			{
				m_paramList[i].pos.x = 0;
				m_paramList[i].pos.y = y;
				y += (int)s.y;
			}
			SetContentsSizeHeight(m_paramList.Count * s.y + 4);
		}

		// RVA: 0x15E3254 Offset: 0x15E3254 VA: 0x15E3254
		public void Reset()
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
			m_paramList.Clear();
		}

		//// RVA: 0x15E3184 Offset: 0x15E3184 VA: 0x15E3184
		public void SetContentsSizeHeight(float height)
		{
			if(m_scrollSupport != null)
			{
				m_contentsAreaSize.y = height;
				m_scrollSupport.ContentSize = m_contentsAreaSize;
			}
		}

		//// RVA: 0x15E3568 Offset: 0x15E3568 VA: 0x15E3568
		public void Show()
		{
			if (m_raycastTarget != null)
			{
				m_raycastTarget.raycastTarget = true;
				ResetScrollPosition();
			}
		}

		//// RVA: 0x15E3954 Offset: 0x15E3954 VA: 0x15E3954
		public void Hide()
		{
			ResetScrollPosition();
		}

		//// RVA: 0x15E3630 Offset: 0x15E3630 VA: 0x15E3630
		public void ResetScrollPosition()
		{
			if(m_scrollSupport != null)
			{
				if(m_scrollSupport.scrollRect != null)
				{
					if(m_scrollSupport.scrollRect.content != null)
					{
						RectTransform rt = m_scrollSupport.scrollRect.content.GetComponent<RectTransform>();
						if (rt != null)
							rt.anchoredPosition = Vector3.zero;
						m_scrollSupport.scrollRect.StopMovement();
					}
				}
			}
		}

		//// RVA: 0x15E3958 Offset: 0x15E3958 VA: 0x15E3958
		public void UpdateScroll()
		{
			float top, bottom;
			CalcScrollVisibleRange(m_scrollSupport, out top, out bottom);
			for(int i = 0; i < m_paramList.Count; i++)
			{
				if(top < m_paramList[i].pos.y || m_paramList[i].pos.y + m_paramList[i].size.y < bottom)
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

		//// RVA: 0x15E3DB4 Offset: 0x15E3DB4 VA: 0x15E3DB4
		private LayoutPopupAchieveRewardItem GetFreeObject()
		{
			if (m_freeLayout.Count < 1)
				return null;
			LayoutPopupAchieveRewardItem item = m_freeLayout[0];
			m_freeLayout.RemoveAt(0);
			return item;
		}

		//// RVA: 0x15E34A4 Offset: 0x15E34A4 VA: 0x15E34A4
		private void ReleaseObject(LayoutPopupAchieveRewardItem obj)
		{
			if(obj != null)
			{
				m_freeLayout.Add(obj);
			}
		}

		//// RVA: 0x15E3C78 Offset: 0x15E3C78 VA: 0x15E3C78
		private void CalcScrollVisibleRange(LayoutUGUIScrollSupport support, out float yTop, out float yBottom)
		{
			float f = support.scrollRect.verticalNormalizedPosition;
			yTop = (1 - f) * (support.ContentHeight - support.RangeSize.y);
			yBottom = yTop + support.RangeSize.y;
		}

		//// RVA: 0x15E3D74 Offset: 0x15E3D74 VA: 0x15E3D74
		//private bool InScrollView(float x, float y, int w, int h, float yTop, float yBottom) { }

		// RVA: 0x15E3EA4 Offset: 0x15E3EA4 VA: 0x15E3EA4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(m_scrollSupport != null)
			{
				m_raycastTarget = m_scrollSupport.GetComponent<Image>();
				m_contentsAreaSize = m_scrollSupport.scrollRect.GetComponent<RectTransform>().sizeDelta;
				gameObject.GetComponent<RectTransform>().sizeDelta = m_contentsAreaSize;
			}
			Loaded();
			return true;
		}
	}
}
