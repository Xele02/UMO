using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicInfoWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_font; // 0x14
		[SerializeField]
		private Text m_title; // 0x18
		[SerializeField]
		private Text m_info; // 0x1C
		[SerializeField]
		private RawImageEx m_cd; // 0x20
		[SerializeField]
		private ActionButton m_music_buy_btn; // 0x24
		private AbsoluteLayout m_frameLayout; // 0x28
		private AbsoluteLayout m_musicBuyButtonLayout; // 0x2C
		private int m_music_id; // 0x30
		private Action m_updater; // 0x34
		private Image m_image; // 0x38
		private bool m_isLoadingImage; // 0x3C
		private List<RectTransform> m_rect_list = new List<RectTransform>(); // 0x40
		private LayoutElement m_range; // 0x44
		private ScrollRect m_scroll_rect; // 0x48
		private Transform m_scrol_bar; // 0x4C
		private RectTransform m_content; // 0x50
		private bool m_is_scroll; // 0x54

		public Action OnClickMusicButton { private get; set; } // 0x58

		// RVA: 0x104A4B4 Offset: 0x104A4B4 VA: 0x104A4B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_musicBuyButtonLayout = layout.FindViewByExId("sw_pop_music_info_sw_pop_music_btn_anim") as AbsoluteLayout;
			m_frameLayout = layout.FindViewByExId("sw_pop_music_info_sw_pop_music_play_fnt") as AbsoluteLayout;
			Transform t = transform.Find("sw_pop_music_info (AbsoluteLayout)");
			m_scroll_rect = t.Find("scroll_area (AbsoluteLayout)/music_info (ScrollView)").GetComponent<ScrollRect>();
			m_image = t.Find("scroll_area (AbsoluteLayout)/music_info (ScrollView)").GetComponent<Image>();
			Transform t2 = t.Find("scroll_area (AbsoluteLayout)/music_info (ScrollView)/Content/Range/root_pop_music_fnt_layout_root/sw_pop_music_fnt (AbsoluteLayout)");
			for(int i = 0; i < t2.childCount; i++)
			{
				m_rect_list.Add(t2.GetChild(i).GetComponent<RectTransform>());
			}
			m_range = t.Find("scroll_area (AbsoluteLayout)/music_info (ScrollView)/Content/Range").GetComponent<LayoutElement>();
			m_content = t.Find("scroll_area (AbsoluteLayout)/music_info (ScrollView)/Content").GetComponent<RectTransform>();
			m_music_buy_btn.AddOnClickCallback(() =>
			{
				//0x104B584
				if (OnClickMusicButton != null)
					OnClickMusicButton();
			});
			m_font.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_music_info_01");
			Loaded();
			return true;
		}

		// RVA: 0x104A9A4 Offset: 0x104A9A4 VA: 0x104A9A4
		private void Start()
		{
			return;
		}

		// RVA: 0x104A9A8 Offset: 0x104A9A8 VA: 0x104A9A8
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x104A9BC Offset: 0x104A9BC VA: 0x104A9BC
		private void UpdateEnter()
		{
			float h = 0;
			for(int i = 0; i < m_rect_list.Count; i++)
			{
				h += m_rect_list[i].rect.height;
			}
			m_range.minHeight = h;
			m_image.raycastTarget = true;
			m_scroll_rect.enabled = false;
			m_scroll_rect.verticalScrollbar.gameObject.SetActive(false);
			m_is_scroll = m_scroll_rect.transform.GetComponent<RectTransform>().rect.height <= h;
			m_scroll_rect.movementType = ScrollRect.MovementType.Clamped;
			m_content.anchoredPosition = new Vector2(0, 0);
			m_updater = UpdateOpenEnd;
		}

		//// RVA: 0x104AD08 Offset: 0x104AD08 VA: 0x104AD08
		private void UpdateOpenEnd()
		{
			m_content.anchoredPosition = new Vector2(0, 0);
			m_scroll_rect.enabled = false;
		}

		//// RVA: 0x104AD88 Offset: 0x104AD88 VA: 0x104AD88
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x104AD8C Offset: 0x104AD8C VA: 0x104AD8C
		public void CallOpenEnd()
		{
			if(!m_is_scroll)
			{
				m_scroll_rect.enabled = false;
				m_scroll_rect.verticalScrollbar.gameObject.SetActive(false);
			}
			else
			{
				m_scroll_rect.enabled = true;
				m_scroll_rect.verticalScrollbar.gameObject.SetActive(true);
			}
			m_scroll_rect.movementType = ScrollRect.MovementType.Elastic;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x104AF38 Offset: 0x104AF38 VA: 0x104AF38
		public void SetMusicBuyButtonEnable(bool enable)
		{
			if (m_musicBuyButtonLayout == null)
				return;
			m_music_buy_btn.Hidden = !enable;
		}

		//// RVA: 0x104AF78 Offset: 0x104AF78 VA: 0x104AF78
		public void SetMusicData(EEDKAACNBBG_MusicData data, bool isDetailCD = false)
		{
			m_title.text = data.NBKFBCLDGAL_OfficialName;
			m_info.text = data.KLMPFGOCBHC_Description;
			if(isDetailCD)
			{
				SetDetailCD(data.NNHOBFBCIIJ_Cd);
			}
			else
			{
				SetCD(data.JNCPEGJGHOG_JacketId);
			}
			m_content.anchoredPosition = new Vector2(0, 0);
			m_scroll_rect.enabled = false;
			m_music_id = data.DLAEJOBELBH_MusicId;
		}

		//// RVA: 0x104B360 Offset: 0x104B360 VA: 0x104B360
		public void Enter()
		{
			m_updater = UpdateEnter;
		}

		//// RVA: 0x104B0B4 Offset: 0x104B0B4 VA: 0x104B0B4
		//public void SetTitle(string title) { }

		//// RVA: 0x104B0F0 Offset: 0x104B0F0 VA: 0x104B0F0
		//public void SetInfo(string info) { }

		//// RVA: 0x104B240 Offset: 0x104B240 VA: 0x104B240
		public void SetCD(int coverId)
		{
			m_isLoadingImage = true;
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture icon) =>
			{
				//0x104B598
				icon.Set(m_cd);
				m_isLoadingImage = false;
			});
		}

		//// RVA: 0x104B12C Offset: 0x104B12C VA: 0x104B12C
		public void SetDetailCD(int cdId)
		{
			m_isLoadingImage = true;
			GameManager.Instance.MusicJacketTextureCache.LoadDetail(cdId, (IiconTexture icon) =>
			{
				//0x104B680
				icon.Set(m_cd);
				m_isLoadingImage = false;
			});
		}

		//// RVA: 0x104B4C0 Offset: 0x104B4C0 VA: 0x104B4C0
		public bool IsLoading()
		{
			return m_isLoadingImage;
		}

		//// RVA: 0x104B4C8 Offset: 0x104B4C8 VA: 0x104B4C8
		public void SetActiveFlame(bool active)
		{
			m_frameLayout.enabled = active;
		}

		//// RVA: 0x104B4E4 Offset: 0x104B4E4 VA: 0x104B4E4
		//private void OnClickMusicBtn() { }
	}
}
