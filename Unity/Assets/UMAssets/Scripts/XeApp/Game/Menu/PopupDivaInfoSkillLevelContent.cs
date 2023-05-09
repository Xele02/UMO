using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDivaInfoSkillLevelContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupDivaSkillInfoScrollList m_scrollLayout; // 0x10

		public Transform Parent { get; private set; } // 0xC
		public int selectMusicId { get; set; } // 0x14

		// RVA: 0xF8113C Offset: 0xF8113C VA: 0xF8113C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDivaSkillLevelSetting s = setting as PopupDivaSkillLevelSetting;
			Parent = setting.m_parent;
			m_scrollLayout = setting.Content.GetComponent<LayoutPopupDivaSkillInfoScrollList>();
			selectMusicId = s.selectMusicId;
			m_scrollLayout.selectMusicId = selectMusicId;
			DFKGGBMFFGB_PlayerInfo p = new DFKGGBMFFGB_PlayerInfo();
			p.KHEKNNFCAOI_Init(null, false);
			m_scrollLayout.Reset();
			m_scrollLayout.Setup(p.NBIGLBMHEDC);
			m_scrollLayout.UpdateScroll();
			for(int i = 0; i < p.NBIGLBMHEDC.Count; i++)
			{
				if(p.NBIGLBMHEDC[i].IPJMPBANBPP)
				{
					if(p.NBIGLBMHEDC[i].FJODMPGPDDD)
					{
						GameManager.Instance.DivaIconCache.Load(p.NBIGLBMHEDC[i].AHHJLDLAPAN_DivaId, 1, 0, (IiconTexture textrue) =>
						{
							//0xF81950
							return;
						});
					}
				}
			}
		}

		// RVA: 0xF81664 Offset: 0xF81664 VA: 0xF81664 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8166C Offset: 0xF8166C VA: 0xF8166C
		public void Update()
		{
			if(m_scrollLayout != null)
			{
				m_scrollLayout.UpdateScroll();
			}
		}

		// RVA: 0xF81720 Offset: 0xF81720 VA: 0xF81720 Slot: 19
		public void Show()
		{
			m_scrollLayout.selectMusicId = selectMusicId;
			m_scrollLayout.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0xF817A8 Offset: 0xF817A8 VA: 0xF817A8 Slot: 20
		public void Hide()
		{
			m_scrollLayout.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0xF81808 Offset: 0xF81808 VA: 0xF81808 Slot: 21
		public bool IsReady()
		{
			return !GameManager.Instance.DivaIconCache.IsLoading();
		}

		// RVA: 0xF818C8 Offset: 0xF818C8 VA: 0xF818C8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
