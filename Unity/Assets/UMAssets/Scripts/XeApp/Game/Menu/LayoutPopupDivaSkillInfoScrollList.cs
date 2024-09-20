using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDivaSkillInfoScrollList : LayoutUGUIScriptBase
	{
		public class ItemParam
		{
			public FFHPBEPOMAK_DivaInfo divaData; // 0x8
			public LayoutPopupDivaSkillInfoItem item; // 0xC
			public Vector2 pos; // 0x10
			public Vector2 size; // 0x18

			// RVA: 0x1720A54 Offset: 0x1720A54 VA: 0x1720A54
			public ItemParam(FFHPBEPOMAK_DivaInfo diva, Vector2 pos, Vector2 size)
			{
				divaData = diva;
				this.pos = pos;
				this.size = size;
			}
		}

		private const float ITEM_LAYOUT_W = 318;
		private const float ITEM_LAYOUT_H = 95;
		private const float ITEM_SPACE = 8;
		private const float VIEW_ITEM_OFFSET_X = 20;
		[SerializeField]
		private GameObject m_scrollArea; // 0x14
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x18
		private List<LayoutPopupDivaSkillInfoItem> m_itemLayout = new List<LayoutPopupDivaSkillInfoItem>(); // 0x1C
		private List<LayoutPopupDivaSkillInfoItem> m_freeLayout = new List<LayoutPopupDivaSkillInfoItem>(); // 0x20
		private List<ItemParam> m_paramList = new List<ItemParam>(); // 0x24
		private Image m_raycastTarget; // 0x28
		private Vector2 m_contentsAreaSize; // 0x2C
		private const float ScrollAreaWidth = 759;

		private DFKGGBMFFGB_PlayerInfo ViewPlayerData { get { return GameManager.Instance.ViewPlayerData; } } //0x172027C
		public int selectMusicId { get; set; } // 0x34

		//// RVA: 0x1720328 Offset: 0x1720328 VA: 0x1720328
		public void AddView(List<LayoutPopupDivaSkillInfoItem> item)
		{
			m_itemLayout = item;
			m_scrollSupport.BeginAddView();
			for(int i = 0; i < m_itemLayout.Count; i++)
			{
				m_scrollSupport.AddView(m_itemLayout[i].GetBase(), 20, i * 95 + 8);
				m_freeLayout.Add(m_itemLayout[i]);
				m_itemLayout[i].Reset();
				m_freeLayout[i].SetConditionsCallback(() =>
				{
					//0x1722484
					for (int j = 0; j < m_paramList.Count; j++)
					{
						if (m_paramList[i].item != null)
						{
							m_paramList[i].item.SetConditionsButtonEnable(false);
						}
					}
				}, () =>
				{
					//0x1722608
					for(int j = 0; j < m_paramList.Count; j++)
					{
						if(m_paramList[i].item != null)
						{
							m_paramList[i].item.SetConditionsButtonEnable(true);
						}
					}
				});
			}
			m_scrollSupport.EndAddView();
		}

		//// RVA: 0x172063C Offset: 0x172063C VA: 0x172063C
		public void Setup(List<FFHPBEPOMAK_DivaInfo> divaList)
		{
			Vector2 p = new Vector2(318, 103);
			for(int i = 0; i < divaList.Count; i++)
			{
				if(divaList[i].IPJMPBANBPP_Enabled && divaList[i].FJODMPGPDDD_DivaHave)
				{
					ItemParam item = new ItemParam(divaList[i], new Vector2(0, 0), p);
					m_paramList.Add(item);
				}
			}
			m_paramList.Sort(DivaSort);
			float y = 0;
			for(int i = 0; i < m_paramList.Count; i++)
			{
				m_paramList[i].pos = new Vector2(20, y);
				y += p.y;
			}
			SetContentsSizeHeight(p.y * m_paramList.Count);
		}

		// RVA: 0x1720B64 Offset: 0x1720B64 VA: 0x1720B64
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

		//// RVA: 0x1720A94 Offset: 0x1720A94 VA: 0x1720A94
		public void SetContentsSizeHeight(float height)
		{
			if(m_scrollSupport != null)
			{
				m_contentsAreaSize.y = height;
				m_scrollSupport.ContentSize = m_contentsAreaSize;
			}
		}

		//// RVA: 0x1720E78 Offset: 0x1720E78 VA: 0x1720E78
		public void Show()
		{
			if(m_raycastTarget != null)
			{
				m_raycastTarget.raycastTarget = true;
				m_scrollSupport.scrollRect.enabled = true;
			}
		}

		//// RVA: 0x1720F7C Offset: 0x1720F7C VA: 0x1720F7C
		public void Hide()
		{
			ResetScrollPosition(m_scrollSupport);
		}

		//// RVA: 0x1720F84 Offset: 0x1720F84 VA: 0x1720F84
		private void ResetScrollPosition(LayoutUGUIScrollSupport support)
		{
			if(support != null)
			{
				support.scrollRect.content.anchoredPosition = Vector2.zero;
				support.scrollRect.StopMovement();
			}
		}

		//// RVA: 0x17210F8 Offset: 0x17210F8 VA: 0x17210F8
		private bool IsNotSameIdSlot(int slotIndex, ItemParam p1, ItemParam p2)
		{
			if(slotIndex < ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count)
			{
				if(ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[slotIndex] != null)
				{
					return ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[slotIndex].AHHJLDLAPAN_DivaId != p1.divaData.AHHJLDLAPAN_DivaId ||
						ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[slotIndex].AHHJLDLAPAN_DivaId != p2.divaData.AHHJLDLAPAN_DivaId;
				}
			}
			return false;
		}

		//// RVA: 0x1721394 Offset: 0x1721394 VA: 0x1721394
		private int DivaSort(ItemParam p1, ItemParam p2)
		{
			if(IsNotSameIdSlot(0, p1, p2))
			{
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == p1.divaData.AHHJLDLAPAN_DivaId)
					return -1;
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == p2.divaData.AHHJLDLAPAN_DivaId)
					return 1;
			}
			if (IsNotSameIdSlot(1, p1, p2))
			{
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[1].AHHJLDLAPAN_DivaId == p1.divaData.AHHJLDLAPAN_DivaId)
					return -1;
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[1].AHHJLDLAPAN_DivaId == p2.divaData.AHHJLDLAPAN_DivaId)
					return 1;
			}
			if (IsNotSameIdSlot(2, p1, p2))
			{
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[2].AHHJLDLAPAN_DivaId == p1.divaData.AHHJLDLAPAN_DivaId)
					return -1;
				if (ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[2].AHHJLDLAPAN_DivaId == p2.divaData.AHHJLDLAPAN_DivaId)
					return 1;
			}
			int r = p2.divaData.PKLPGBKKFOL_DivaLevels[selectMusicId - 1] - p1.divaData.PKLPGBKKFOL_DivaLevels[selectMusicId - 1];
			if(r == 0)
			{
				r = p2.divaData.HMBECPGHPOE_DivaExps[selectMusicId - 1] - p1.divaData.HMBECPGHPOE_DivaExps[selectMusicId - 1];
				if(r == 0)
				{
					r = p1.divaData.AHHJLDLAPAN_DivaId - p2.divaData.AHHJLDLAPAN_DivaId;
				}
			}
			return r;
		}

		//// RVA: 0x1721A30 Offset: 0x1721A30 VA: 0x1721A30
		public void UpdateScroll()
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			float f = 0;
			float f2 = 0;
			AIPOFGJGPKI_CampaignDiva.KBLBMGDILAI a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NGCCGLLLDIB_CampaignDiva.MDKOCDHIDMA(time);
			CalcScrollVisibleRange(m_scrollSupport, out f, out f2);
			for(int i = 0; i < m_paramList.Count; i++)
			{
				if(m_paramList[i].pos.y > f2 || m_paramList[i].pos.y + m_paramList[i].size.y < f)
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
					if (m_paramList[i].item == null)
					{
						m_paramList[i].item = GetFreeObject();
						if(m_paramList[i].item != null)
						{
							m_paramList[i].item.SetStatus(m_paramList[i].divaData, selectMusicId, a != null && a.MFKKADJIHHK[(int)Mathf.Clamp(m_paramList[i].divaData.AHHJLDLAPAN_DivaId - 1, 0, a.MFKKADJIHHK.Length)] > 0);
							m_paramList[i].item.SetPosition((int)m_paramList[i].pos.x, (int)m_paramList[i].pos.y);
							m_paramList[i].item.Show();
						}
					}
				}
			}
		}

		//// RVA: 0x17220BC Offset: 0x17220BC VA: 0x17220BC
		private LayoutPopupDivaSkillInfoItem GetFreeObject()
		{
			if(m_freeLayout.Count > 0)
			{
				var item = m_freeLayout[0];
				m_freeLayout.RemoveAt(0);
				return item;
			}
			return null;
		}

		//// RVA: 0x1720DB4 Offset: 0x1720DB4 VA: 0x1720DB4
		private void ReleaseObject(LayoutPopupDivaSkillInfoItem obj)
		{
			if (obj == null)
				return;
			m_freeLayout.Add(obj);
		}

		//// RVA: 0x1721F80 Offset: 0x1721F80 VA: 0x1721F80
		private void CalcScrollVisibleRange(LayoutUGUIScrollSupport support, out float yTop, out float yBottom)
		{
			yTop = (1 - support.scrollRect.verticalNormalizedPosition) * (support.ContentHeight - support.RangeSize.y);
			yBottom = yTop + support.RangeSize.y;
		}

		//// RVA: 0x172207C Offset: 0x172207C VA: 0x172207C
		//private bool InScrollView(float x, float y, int w, int h, float yTop, float yBottom) { }

		// RVA: 0x17221AC Offset: 0x17221AC VA: 0x17221AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_scrollSupport = m_scrollArea.GetComponent<LayoutUGUIScrollSupport>();
			m_raycastTarget = m_scrollArea.GetComponent<Image>();
			if(m_scrollSupport != null)
			{
				m_contentsAreaSize = m_scrollSupport.scrollRect.GetComponent<RectTransform>().sizeDelta;
				gameObject.GetComponent<RectTransform>().sizeDelta = m_contentsAreaSize;
				m_contentsAreaSize.x = 759;
			}
			Loaded();
			return true;
		}
	}
}
