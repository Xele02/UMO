using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using XeSys;
using System;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class EventStoryWindowLayout : LayoutUGUIScriptBase
	{
		public enum Series
		{
			MCRS = 4,
			MCRS_S = 3,
			MCRS_F = 2,
			MCRS_D = 1,
			OTHER = 0,
			PLATE = 5,
			MAX = 6,
		}

		public struct tabInfo
		{
			public Series Info_series; // 0x0
			public AbsoluteLayout Info_btn; // 0x4

			//// RVA: 0x7FAED4 Offset: 0x7FAED4 VA: 0x7FAED4
			//public void init(Series _type) { }
		}
		
		private tabInfo[] m_tabList = new tabInfo[6]; // 0x14
		private Series m_selectSeries; // 0x18
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_tab_btn; // 0x1C
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_seven_tab_btn; // 0x20
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_frontier_tab_btn; // 0x24
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_delta_tab_btn; // 0x28
		[SerializeField]
		private EventStorySeriestabLayout m_other_tab_btn; // 0x2C
		[SerializeField]
		private EventStorySeriestabLayout m_plate_tab_btn; // 0x30
		[SerializeField]
		private ActionButton m_close_btn; // 0x34
		[SerializeField]
		private Text m_title_text; // 0x38
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x3C
		//[CompilerGeneratedAttribute] // RVA: 0x6766CC Offset: 0x6766CC VA: 0x6766CC
		public UnityAction<Series> ChangeTablistener;
		private AbsoluteLayout m_layoutRoot; // 0x44
		private AbsoluteLayout m_tabLayout; // 0x48
		private TexUVListManager m_uvMan; // 0x4C
		private DKKPBBBDKMJ m_view; // 0x50
		private List<DKKPBBBDKMJ.AGAAGMGKNCO> m_seriesDataList; // 0x54
		private Transform m_parentOption; // 0x58
		private Transform m_parentPopup; // 0x5C
		private ScrollRect m_scroll; // 0x60
		private int m_selectBannerPosition; // 0x64
		private bool m_isInput; // 0x68
		private float waitTime; // 0x6C
		private const float Wait = 0.2f;

		public SwapScrollList List { get { return m_scrollList; } } // 0x40 0xB998F0

		//// RVA: 0xB99B10 Offset: 0xB99B10 VA: 0xB99B10
		//public void InitializeTab() { }

		//// RVA: 0xB99C60 Offset: 0xB99C60 VA: 0xB99C60
		private void InittabList()
		{
			for(int i = 0; i < m_tabList.Length; i++)
			{
				m_tabList[i].Info_series = (Series)i;
				m_tabList[i].Info_btn.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0xB99B20 Offset: 0xB99B20 VA: 0xB99B20
		//private void InitSeriesSetting() { }

		//// RVA: 0xB99B2C Offset: 0xB99B2C VA: 0xB99B2C
		private void SetInfoTab(Series _series)
		{
			for(int i = 0; i < m_tabList.Length; i++)
			{
				m_tabList[i].Info_btn.StartChildrenAnimGoStop(m_tabList[i].Info_series == _series ? "02" : "01");
			}
		}

		//// RVA: 0xB99D74 Offset: 0xB99D74 VA: 0xB99D74
		private void SetSeriesData(int series)
		{
			m_view.NFGLACBNEEN(series);
			int c = m_view.KPEBMCLONHK();
			m_seriesDataList.Clear();
			for(int i = 0; i < c; i++)
			{
				m_seriesDataList.Add(m_view.NPIOEBNLBCI(i));
			}
		}

		//// RVA: 0xB99EA8 Offset: 0xB99EA8 VA: 0xB99EA8
		public void UpdateLayout()
		{
			newIconUpdate();
			SetSeriesData((int)m_selectSeries);
			SetupList(m_seriesDataList.Count, true, m_selectBannerPosition);
		}

		//// RVA: 0xB99F50 Offset: 0xB99F50 VA: 0xB99F50
		private void newIconUpdate()
		{
			m_mcrs_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(4));
			m_mcrs_seven_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(3));
			m_mcrs_frontier_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(2));
			m_mcrs_delta_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(1));
			m_other_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(0));
			m_plate_tab_btn.setNewIcon(m_view.ONIBJLOEMDF_IsNewInCategorie(5));
		}

		//// RVA: 0xB9A4BC Offset: 0xB9A4BC VA: 0xB9A4BC
		private void SetOpenPosition(int eventId)
		{
			if(eventId > -1)
			{
				for (int i = 0; i < 6; i++)
				{
					m_view.NFGLACBNEEN(i);
					for(int j = 0; j < m_view.KPEBMCLONHK(); j++)
					{
						if(m_view.NPIOEBNLBCI(j).PGIIDPEGGPI_EventId == eventId)
						{
							m_selectSeries = (Series)m_view.NPIOEBNLBCI(j).CPKMLLNADLJ;
							m_selectBannerPosition = i / m_scrollList.ColumnCount;
							if(m_selectBannerPosition <= m_scrollList.ColumnCount)
							{
								m_selectBannerPosition = 0;
								return;
							}
							m_selectBannerPosition = (m_selectBannerPosition + 1) - m_scrollList.ColumnCount;
							return;
						}
					}
				}
			}
			m_selectBannerPosition = 0;
			m_selectSeries = Series.OTHER;
		}

		//// RVA: 0xB9A678 Offset: 0xB9A678 VA: 0xB9A678
		//private void InitializeList() { }

		//// RVA: 0xB9A7DC Offset: 0xB9A7DC VA: 0xB9A7DC
		private void OnSelectListItem(int index, SwapScrollListContent content)
		{
			return;
		}

		//// RVA: 0xB9A110 Offset: 0xB9A110 VA: 0xB9A110
		public void SetupList(int count, bool resetScroll = true, int settingPos = 0)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
			{
				m_scrollList.SetPosition(settingPos, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
		}

		//// RVA: 0xB9A8A8 Offset: 0xB9A8A8 VA: 0xB9A8A8
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			EventStoryBannerListContent c = content as EventStoryBannerListContent;
			if(c != null)
			{
				if (index < m_seriesDataList.Count)
				{
					c.Setup(m_seriesDataList[index].PGIIDPEGGPI_EventId, m_seriesDataList[index].LLNKMABDDEB_Period);
					c.SetStatus(OnBannerClick);
					c.ShowNewMark(m_seriesDataList[index].CADENLBDAEB_IsNew);
				}
			}
		}

		// RVA: 0xB9AB48 Offset: 0xB9AB48 VA: 0xB9AB48
		public void OpenWindow()
		{
			SetOpenPosition(Database.Instance.selectedEventStoryEventId);
			SetPopupRoot();
			this.StartCoroutineWatched(co_OpenWindow());
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD6DC Offset: 0x6FD6DC VA: 0x6FD6DC
		//// RVA: 0xB9AD24 Offset: 0xB9AD24 VA: 0xB9AD24
		public IEnumerator co_OpenWindow()
		{
			//0xB9CA44
			MenuScene.Instance.RaycastDisable();
			m_tabLayout.StartChildrenAnimGoStop(m_view.MHCPOIEDLJF ? "01" : "02");
			yield return Co.R(Co_ChangeTab(true));
			m_isInput = true;
			while(waitTime <= 0.2f)
			{
				waitTime += Time.deltaTime;
				yield return null;
			}
			waitTime = 0;
			Enter();
			yield return null;
			while(m_layoutRoot.IsPlayingChildren())
				yield return null;
			MenuScene.Instance.RaycastEnable();
			m_isInput = false;
		}

		//// RVA: 0xB9ADD0 Offset: 0xB9ADD0 VA: 0xB9ADD0
		public void Enter()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xB9AEA8 Offset: 0xB9AEA8 VA: 0xB9AEA8
		public void Leave()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xB9AF80 Offset: 0xB9AF80 VA: 0xB9AF80
		//public void Show() { }

		// RVA: 0xB9B028 Offset: 0xB9B028 VA: 0xB9B028
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_out", "st_out");
		}

		//// RVA: 0xB9B0A8 Offset: 0xB9B0A8 VA: 0xB9B0A8
		//public bool IsPlaying() { }

		// RVA: 0xB9B0D4 Offset: 0xB9B0D4 VA: 0xB9B0D4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutRoot = layout.FindViewById("sw_pop_eve_story_window_inout_anim") as AbsoluteLayout;
			m_tabLayout = layout.FindViewByExId("sw_pop_eve_story_window_inout_anim_sw_pop_eve_story_window") as AbsoluteLayout;
			m_tabList[4].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_01") as AbsoluteLayout;
			m_tabList[3].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_02") as AbsoluteLayout;
			m_tabList[2].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_03") as AbsoluteLayout;
			m_tabList[1].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_04") as AbsoluteLayout;
			m_tabList[0].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_other") as AbsoluteLayout;
			m_tabList[5].Info_btn = m_layoutRoot.FindViewByExId("pop_eve_story_window_swtbl_p_e_s_tab_plate") as AbsoluteLayout;
			m_view = new DKKPBBBDKMJ();
			m_seriesDataList = new List<DKKPBBBDKMJ.AGAAGMGKNCO>();
			m_scroll = m_scrollList.transform.GetComponent<ScrollRect>();
			m_view.KHEKNNFCAOI();
			InittabList();
			m_selectSeries = Series.OTHER;
			SetInfoTab(0);
			m_view.JPLNEJFDPHN((int)m_selectSeries);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_title_text.text = bk.GetMessageByLabel("pop_eve_story_title");
			m_mcrs_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C214
				OnClickTab(Series.MCRS);
			});
			m_mcrs_seven_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C21C
				OnClickTab(Series.MCRS_S);
			});
			m_mcrs_frontier_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C224
				OnClickTab(Series.MCRS_F);
			});
			m_mcrs_delta_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C22C
				OnClickTab(Series.MCRS_D);
			});
			m_other_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C234
				OnClickTab(Series.OTHER);
			});
			m_plate_tab_btn.AddOnClickCallback(() =>
			{
				//0xB9C23C
				OnClickTab(Series.PLATE);
			});
			m_close_btn.AddOnClickCallback(() =>
			{
				//0xB9C244
				if (m_isInput)
					return;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				this.StartCoroutineWatched(co_close(false, 0));
			});
			Loaded();
			return true;
		}

		//// RVA: 0xB9BA80 Offset: 0xB9BA80 VA: 0xB9BA80
		private void OnClickTab(Series clickSeries)
		{
			if (m_selectSeries == clickSeries)
				return;
			if (m_isInput)
				return;
			InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_selectBannerPosition = 0;
			Series prev = m_selectSeries;
			m_selectSeries = clickSeries;
			m_view.JPLNEJFDPHN((int)clickSeries);
			this.StartCoroutineWatched(Co_ChangeTab(clickSeries == Series.PLATE || prev == Series.PLATE));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD754 Offset: 0x6FD754 VA: 0x6FD754
		//// RVA: 0xB9BBD4 Offset: 0xB9BBD4 VA: 0xB9BBD4
		private IEnumerator Co_ChangeTab(bool isUpdateTabLayout)
		{
			KDLPEDBKMID install; // 0x18
			bool InstallCheck; // 0x1C

			//0xB9C3E8
			InputDisable();
			if(ChangeTablistener != null && isUpdateTabLayout)
			{
				ChangeTablistener(m_selectSeries);
			}
			SetSeriesData((int)m_selectSeries);
			install = KDLPEDBKMID.HHCJCDFCLOB;
			InstallCheck = false;
			for(int i = 0; i < m_seriesDataList.Count; i++)
			{
				InstallCheck |= install.BDOFDNICMLC_StartInstallIfNeeded(EventBannerTextureCache.MakeBannerPath(m_seriesDataList[i].PGIIDPEGGPI_EventId));
			}
			install.OFLDICKPNFD(true, () =>
			{
				//0xB9C348
				MenuScene.Instance.GotoTitle();
			});
			yield return null;
			if(InstallCheck)
			{
				while (install.LNHFLJBGGJB_IsRunning)
					yield return null;
			}
			//LAB_00b9c4dc
			SetInfoTab(m_selectSeries);
			UpdateLayout();
			yield return Co.R(WaitTextureLoad());
			m_isInput = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD7CC Offset: 0x6FD7CC VA: 0x6FD7CC
		//// RVA: 0xB9BC9C Offset: 0xB9BC9C VA: 0xB9BC9C
		private IEnumerator WaitTextureLoad()
		{
			bool isLoading;

			//0xB9C890
			isLoading = true;
			while (GameManager.Instance.EventBannerTextureCache.IsLoading())
				yield return null;
			isLoading = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FD844 Offset: 0x6FD844 VA: 0x6FD844
		//// RVA: 0xB9BD30 Offset: 0xB9BD30 VA: 0xB9BD30
		private IEnumerator co_close(bool isTrans = false, int eventId = 0)
		{
			//0xB9CE18
			GameManager.Instance.InputEnabled = false;
			InputDisable();
			Leave();
			yield return null;
			while (m_layoutRoot.IsPlayingChildren())
				yield return null;
			gameObject.transform.SetParent(m_parentOption);
			if(isTrans)
			{
				CCAAJNJGNDO data = new CCAAJNJGNDO();
				data.KHEKNNFCAOI(eventId);
				EventStoryArgs args = new EventStoryArgs(data);
				MenuScene.Instance.Call(TransitionList.Type.EVENT_STORY, args, true);
			}
			GameManager.Instance.InputEnabled = true;
			m_isInput = false;
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		//// RVA: 0xB9BE10 Offset: 0xB9BE10 VA: 0xB9BE10
		private void OnBannerClick(int eventId)
		{
			if (m_isInput)
				return;
			InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(co_close(true, eventId));
			Database.Instance.selectedEventStoryEventId = eventId;
		}

		//// RVA: 0xB9BF0C Offset: 0xB9BF0C VA: 0xB9BF0C
		private void OnBackButton()
		{
			if (m_isInput)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(co_close(false, 0));
		}

		// RVA: 0xB9BF94 Offset: 0xB9BF94 VA: 0xB9BF94
		public void InitEvStWindow(Action callback)
		{
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			m_selectSeries = Series.OTHER;
			SetInfoTab(0);
			if (callback != null)
				callback();
			UpdateLayout();
		}

		//// RVA: 0xB9AC78 Offset: 0xB9AC78 VA: 0xB9AC78
		public void SetPopupRoot()
		{
			gameObject.transform.SetParent(m_parentPopup);
			gameObject.transform.SetAsFirstSibling();
		}

		// RVA: 0xB9C01C Offset: 0xB9C01C VA: 0xB9C01C
		public void SetRoot(Transform _root)
		{
			m_parentOption = _root;
			m_parentPopup = GameManager.Instance.PopupCanvas.transform.Find("Root").transform;
		}

		//// RVA: 0xB9C138 Offset: 0xB9C138 VA: 0xB9C138
		//public bool IsNew() { }

		//// RVA: 0xB9BB74 Offset: 0xB9BB74 VA: 0xB9BB74
		private void InputDisable()
		{
			m_scroll.vertical = false;
			m_scrollList.SetEnableScrollBar(false);
			m_isInput = true;
		}
	}
}
