using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using System.Collections;
using mcrs;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class TipsWindow : LayoutUGUIScriptBase
	{
		private enum DirectionIndex
		{
			Left = 0,
			Right = 1,
			Num = 2,
		}

		private static readonly Vector2 GRAFFITI_SIZE = new Vector2(120, 296); // 0x0
		private static readonly Vector2[] GRAFFITI_UV_TABLE = new Vector2[4] {
			new Vector2(1, 1), new Vector2(129, 1), new Vector2(257, 1), new Vector2(385, 1)
		}; // 0x8
		[SerializeField] // RVA: 0x685EDC Offset: 0x685EDC VA: 0x685EDC
		private TipsContent m_conten; // 0x14
		[SerializeField] // RVA: 0x685EEC Offset: 0x685EEC VA: 0x685EEC
		private ActionButton[] m_arrowButtons; // 0x18
		[SerializeField] // RVA: 0x685EFC Offset: 0x685EFC VA: 0x685EFC
		private RawImageEx[] m_charaImages; // 0x1C
		[SerializeField] // RVA: 0x685F0C Offset: 0x685F0C VA: 0x685F0C
		private RawImageEx[] m_graffitiImages; // 0x20
		private int m_maxPage; // 0x24
		private int m_page; // 0x28
		private AbsoluteLayout m_root; // 0x2C
		private float m_scrollWaitSecond; // 0x30
		private bool m_isScroll; // 0x34
		private bool m_canAutoScroll = true; // 0x35
		private const float AutoScrollWaitSecond = 5;
		private List<TipsData> m_tipsList = new List<TipsData>(); // 0x38
		private const int MaxListupTips = 3;

		//public int MaxPage { get; } 0xA9C0D4
		//public int CurrentPage { get; } 0xA9C0DC
		//public bool CanAutoScroll { get; } 0xA9C0E4

		// RVA: 0xA9C0EC Offset: 0xA9C0EC VA: 0xA9C0EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_tips_window_sw_tips_window_anim") as AbsoluteLayout;
			ClearLoadedCallback();
			m_arrowButtons[0].AddOnClickCallback(OnPushLeftArrowButton);
			m_arrowButtons[1].AddOnClickCallback(OnPushRightArrowButton);
			m_root.StartChildrenAnimGoStop("st_out");
			return true;
		}

		//// RVA: 0xA9B388 Offset: 0xA9B388 VA: 0xA9B388
		public void SetContent(List<TipsData> tipsList)
		{
			m_isScroll = false;
			m_tipsList = tipsList;
			m_page = 1;
			SetMaxPage(tipsList.Count);
			m_page = 1;
			m_conten.SetContent(m_tipsList[0].title, m_tipsList[0].message, m_tipsList[0].texture);
			m_scrollWaitSecond = 0;
			SetCharaImage(DirectionIndex.Left, m_tipsList[0].divaL);
			SetCharaImage(DirectionIndex.Right, m_tipsList[0].divaR);
			SetGraffitiImage(m_tipsList[0].graffitiId, m_tipsList[0].graffiti);
			m_canAutoScroll = tipsList.Count > 1;
		}

		//// RVA: 0xA9C3BC Offset: 0xA9C3BC VA: 0xA9C3BC
		private void SetCharaImage(DirectionIndex dir, TipsTexture image)
		{
			if (image != null)
			{
				m_charaImages[(int)dir].enabled = true;
				image.Set(m_charaImages[(int)dir]);
			}
			else
			{
				m_charaImages[(int)dir].enabled = false;
			}
		}

		//// RVA: 0xA9C490 Offset: 0xA9C490 VA: 0xA9C490
		private void SetGraffitiImage(int id, TipsTexture image)
		{
			if(image == null)
			{
				for(int i = 0; i < m_graffitiImages.Length; i++)
				{
					m_graffitiImages[i].enabled = false;
				}
			}
			else
			{
				int x = id - 1;
				int x_ = (x % 2) * 2;
				for (int i = 0; i < m_graffitiImages.Length; i++)
				{
					m_graffitiImages[i].enabled = true;
					image.Set(m_graffitiImages[i]);
					Rect r = new Rect(GRAFFITI_UV_TABLE[x_ + i].x, GRAFFITI_UV_TABLE[x_ + i].y, GRAFFITI_SIZE.x, GRAFFITI_SIZE.y);
					m_graffitiImages[i].uvRect = new Rect(r.x / image.BaseTexture.width, 1 - (r.y + r.height) / image.BaseTexture.height, r.width / image.BaseTexture.width, r.height / image.BaseTexture.height);
				}
			}
		}

		//// RVA: 0xA9C3B8 Offset: 0xA9C3B8 VA: 0xA9C3B8
		//private void UpdateFlag(TipsData tipsData) { }

		// RVA: 0xA9C8C0 Offset: 0xA9C8C0 VA: 0xA9C8C0
		private void Update()
		{
			if(!m_isScroll && m_canAutoScroll)
			{
				m_scrollWaitSecond += TimeWrapper.deltaTime;
				if(m_scrollWaitSecond > 5)
				{
					this.StartCoroutineWatched(ScrollCoroutine(-1));
					m_scrollWaitSecond = 0;
				}
			}
		}

		//// RVA: 0xA9B520 Offset: 0xA9B520 VA: 0xA9B520
		public void Show()
		{
			m_scrollWaitSecond = 0;
			m_canAutoScroll = true;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("st_in");
		}

		//// RVA: 0xA9964C Offset: 0xA9964C VA: 0xA9964C
		public void Close()
		{
			m_root.StartAllAnimGoStop("st_out");
			this.StartCoroutineWatched(CloseCoroutine());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x735864 Offset: 0x735864 VA: 0x735864
		//// RVA: 0xA9C9E8 Offset: 0xA9C9E8 VA: 0xA9C9E8
		private IEnumerator CloseCoroutine()
		{
			//0xA9CE84
			while(IsPlayingAnime())
				yield return null;
			gameObject.SetActive(false);
		}

		//// RVA: 0xA998C4 Offset: 0xA998C4 VA: 0xA998C4
		public bool IsPlayingAnime()
		{
			return m_root.IsPlayingChildren();
		}

		//// RVA: 0xA9CA94 Offset: 0xA9CA94 VA: 0xA9CA94
		//public void StartAutoScroll() { }

		//// RVA: 0xA9C30C Offset: 0xA9C30C VA: 0xA9C30C
		private void SetMaxPage(int maxPage)
		{
			m_maxPage = maxPage;
			for(int i = 0; i < m_arrowButtons.Length; i++)
			{
				m_arrowButtons[i].Hidden = maxPage < 2;
			}
		}

		//// RVA: 0xA9C3B0 Offset: 0xA9C3B0 VA: 0xA9C3B0
		//private void SetPage(int page) { }

		//// RVA: 0xA9CAA8 Offset: 0xA9CAA8 VA: 0xA9CAA8
		private void OnPushLeftArrowButton()
		{
			if (m_isScroll)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(ScrollCoroutine(1));
			m_canAutoScroll = false;
		}

		//// RVA: 0xA9CB34 Offset: 0xA9CB34 VA: 0xA9CB34
		private void OnPushRightArrowButton()
		{
			if (m_isScroll)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(ScrollCoroutine(-1));
			m_canAutoScroll = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7358DC Offset: 0x7358DC VA: 0x7358DC
		//// RVA: 0xA9C940 Offset: 0xA9C940 VA: 0xA9C940
		private IEnumerator ScrollCoroutine(int dir)
		{
			//0xA9CFC8
			m_isScroll = true;
			if(dir < 0)
			{
				m_page++;
				if(m_maxPage < m_page)
					m_page = 1;
				TipsData tips = m_tipsList[m_page - 1];
				m_conten.SetContent(tips.title, tips.message, tips.texture);
				SetCharaImage(DirectionIndex.Left, tips.divaL);
				SetCharaImage(DirectionIndex.Right, tips.divaR);
				SetGraffitiImage(tips.graffitiId, tips.graffiti);
			}
			else if(dir > 0)
			{
				m_page--;
				if(m_page < 1)
					m_page = m_maxPage;
				TipsData tips = m_tipsList[m_page - 1];
				m_conten.SetContent(tips.title, tips.message, tips.texture);
				SetCharaImage(DirectionIndex.Left, tips.divaL);
				SetCharaImage(DirectionIndex.Right, tips.divaR);
				SetGraffitiImage(tips.graffitiId, tips.graffiti);
			}
			m_isScroll = false;
			m_scrollWaitSecond = 0;
			yield break;
		}
	}
}
