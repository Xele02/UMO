using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupMusicGradeGetRewardContent : UIBehaviour, IPopupContent
	{
		private List<IFlexibleListItem> m_scrollItemList = new List<IFlexibleListItem>(); // 0x10
		private PopupMusicGradeGetRewardSetting m_setting; // 0x14
		private LayoutPopupMusicGradeGetRewardList m_layout; // 0x18
		private bool m_isReceived; // 0x1C

		public Transform Parent { get; private set; } // 0xC

		//// RVA: 0x1693A38 Offset: 0x1693A38 VA: 0x1693A38 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			Parent = setting.m_parent;
			RectTransform rt = transform.GetComponent<RectTransform>();
			rt.sizeDelta = size;
			rt.localPosition = new Vector2(0, 0);
			m_setting = setting as PopupMusicGradeGetRewardSetting;
			m_layout = transform.GetComponent<LayoutPopupMusicGradeGetRewardList>();
			MakeScrollItem(m_setting.NowGrade, m_setting.RewardList);
			AGLHPOOPOCG.HHCJCDFCLOB.OAGGKCHJBEO(() =>
			{
				//0x169515C
				m_isReceived = true;
			}, () =>
			{
				//0x1695168
				m_isReceived = true;
			}, () =>
			{
				//0x1695174
				m_isReceived = true;
				MenuScene.Instance.GotoTitle();
			});
			gameObject.SetActive(true);
		}

		//// RVA: 0x1693D74 Offset: 0x1693D74 VA: 0x1693D74
		private void MakeScrollItem(HighScoreRatingRank.Type grade, List<HighScoreRating.UtaGradeData> list)
		{
			m_scrollItemList.Clear();
			for(int i = 0, k = 0; i < list.Count; i++)
			{
				for(int j = 0; j < list[i].items.Count; j++, k++)
				{
					LayoutMusicRateList.FlexibleListItem_Reward item = new LayoutMusicRateList.FlexibleListItem_Reward();
					item.Top = new Vector2(0, -(k * 111 + 10));
					item.Height = 111;
					item.ResourceType = 0;
					item.MusicGrade = (HighScoreRatingRank.Type)list[i].grade;
					item.MusicGradeName = HighScoreRatingRank.GetRankName((HighScoreRatingRank.Type)list[i].grade);
					item.MusicMustRate = string.Format("{0}", list[i].rate);
					item.Index = j;
					item.Item = list[i].items[j];
					item.Pickup = list[i].pickup == j;
					item.Get = list[i].grade <= (int)grade;
					m_scrollItemList.Add(item);
				}
			}
			for(int i = 0; i < m_scrollItemList.Count; i++)
			{
				if(m_scrollItemList[i] != null)
				{
					LayoutMusicRateList.FlexibleListItem_Reward item = m_scrollItemList[i] as LayoutMusicRateList.FlexibleListItem_Reward;
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(item.Item.JJBGOIMEIPF_ItemFullId, 0));
				}
			}
		}

		//// RVA: 0x1694354 Offset: 0x1694354 VA: 0x1694354
		private void SetupScrollContent()
		{
			m_layout.FxScrollView.SetupListItem(m_scrollItemList);
			int cnt = 0;
			int total = 0;
			for(int i = 0; i < m_setting.RewardList.Count; i++)
			{
				for(int j = 0; j < m_setting.RewardList[i].items.Count; j++)
				{
					total++;
					if (m_setting.RewardList[i].grade <= (int)m_setting.NowGrade)
						cnt++;
				}
			}
			m_layout.FxScrollView.SetlistTop(total - cnt);
		}

		//// RVA: 0x16945E4 Offset: 0x16945E4 VA: 0x16945E4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		//// RVA: 0x16945EC Offset: 0x16945EC VA: 0x16945EC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_layout.Setup();
			m_layout.FxScrollView.UpdateItemListener += UpdateContent;
			SetupScrollContent();
			this.StartCoroutineWatched(Co_Show());
			m_layout.FxScrollView.LockScroll();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x706784 Offset: 0x706784 VA: 0x706784
		//// RVA: 0x1694770 Offset: 0x1694770 VA: 0x1694770
		private IEnumerator Co_Show()
		{
			//0x1695470
			while (m_layout.IsPlayTitleAnime())
				yield return null;
			m_layout.StartTitleLoop();
		}

		//// RVA: 0x169481C Offset: 0x169481C VA: 0x169481C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_layout.FxScrollView.AllFree();
			m_scrollItemList.Clear();
			m_layout.FxScrollView.UpdateItemListener -= UpdateContent;
			m_layout.FxScrollView.LockScroll();
			OnDestroy();
		}

		//// RVA: 0x16949E0 Offset: 0x16949E0 VA: 0x16949E0 Slot: 21
		public bool IsReady()
		{
			if (!m_isReceived)
				return false;
			return m_layout.IsLoaded() && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		//// RVA: 0x1694AC8 Offset: 0x1694AC8 VA: 0x1694AC8 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_DelayOpenEnd());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7067FC Offset: 0x7067FC VA: 0x7067FC
		//// RVA: 0x1694AEC Offset: 0x1694AEC VA: 0x1694AEC
		private IEnumerator Co_DelayOpenEnd()
		{
			//0x169528C
			yield return new WaitForSeconds(0.1f);
			m_layout.FxScrollView.SetZeroVelocity();
			m_layout.FxScrollView.UnLockScroll();
		}

		//// RVA: 0x1694B98 Offset: 0x1694B98 VA: 0x1694B98
		private void UpdateContent(IFlexibleListItem item)
		{
			TodoLogger.Log(0, "UpdateContent");
		}

		//// RVA: 0x1694E50 Offset: 0x1694E50 VA: 0x1694E50
		//public void OnShowItemDetails(int itemId, int itemNum) { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x7068A4 Offset: 0x7068A4 VA: 0x7068A4
		//// RVA: 0x169521C Offset: 0x169521C VA: 0x169521C
		//private void <UpdateContent>b__18_0(int itemId, int itemNum) { }
	}
}
