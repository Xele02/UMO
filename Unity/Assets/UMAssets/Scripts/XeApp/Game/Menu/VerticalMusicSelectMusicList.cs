using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using TMPro;
using System.Collections.Generic;
using System;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicList : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675148 Offset: 0x675148 VA: 0x675148
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675190 Offset: 0x675190 VA: 0x675190
		private MusicScrollView m_musicScroll; // 0x10
		// [HeaderAttribute] // RVA: 0x6751E8 Offset: 0x6751E8 VA: 0x6751E8
		[SerializeField]
		private GameObject m_emptyTextObj; // 0x14
		[SerializeField]
		private TextMeshProUGUI m_emptyText; // 0x18
		[SerializeField]
		private Animator m_listUpdateAnim; // 0x1C
		private static readonly int hashStateIn = Animator.StringToHash("Base Layer.In"); // 0x0
		private static readonly int hashStateOut = Animator.StringToHash("Base Layer.Out"); // 0x4
		private static readonly int hashStateClip = Animator.StringToHash("Base Layer.Clip"); // 0x8
		private List<VerticalMusicDataList.MusicListData> m_musicList = new List<VerticalMusicDataList.MusicListData>(); // 0x20
		private int m_difficult; // 0x24
		private bool m_isSingleMusic; // 0x28

		public MusicScrollView MusicScrollView { get { return m_musicScroll; } } //0xBE1ABC
		public Action<int> OnUpdateCenter { get; set; } // 0x2C
		public Action OnUpdateClip { get; set; } // 0x30

		// // RVA: 0xBE1AE4 Offset: 0xBE1AE4 VA: 0xBE1AE4
		private void Awake()
		{
			m_musicScroll.OnUpdateCenter.AddListener(this.MusicUpdateCenterItem);
			m_musicScroll.OnUpdateListItem.AddListener(this.MusicUpdateListItem);
			m_musicScroll.OnUpdateClipItem.AddListener(() => {
				//0xBE4864
				m_listUpdateAnim.Play(hashStateClip);
				if (OnUpdateClip != null)
					OnUpdateClip();
			});
		}

		// // RVA: 0xBE1CB0 Offset: 0xBE1CB0 VA: 0xBE1CB0
		public void SetMusicListStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style, bool isTabNormal)
		{
			if(isTabNormal)
			{
				if(style == VerticalMusicSelectUISapporter.MusicInfoStyle.NoneFilter)
				{
					m_musicScroll.SetListEnable(false);
					m_emptyTextObj.SetActive(true);
					m_emptyText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_not_exist_text_01");
				}
				else if(style != VerticalMusicSelectUISapporter.MusicInfoStyle.None6Line)
				{
					m_musicScroll.SetListEnable(true);
					m_emptyTextObj.SetActive(false);
				}
				else
				{
					m_musicScroll.SetListEnable(false);
					m_emptyTextObj.SetActive(true);
					m_emptyText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_not_exist_line6_text_01");
				}
			}
			else
			{
				if(style != VerticalMusicSelectUISapporter.MusicInfoStyle.NoneFilter && style != VerticalMusicSelectUISapporter.MusicInfoStyle.None6Line)
				{
					m_musicScroll.SetListEnable(true);
					m_emptyTextObj.SetActive(false);
				}
				else
				{
					m_musicScroll.SetListEnable(false);
					m_emptyTextObj.SetActive(true);
					m_emptyText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_not_exist_text_02");
				}
			}
		}

		// // RVA: 0xBE1F30 Offset: 0xBE1F30 VA: 0xBE1F30
		// public void SetScroll(int listNo) { }

		// // RVA: 0xBE1F34 Offset: 0xBE1F34 VA: 0xBE1F34
		public void ChangeDifficult(int diff)
		{
			m_difficult = diff;
			m_musicScroll.UpdateListPosition(true);
		}

		// // RVA: 0xBE1F68 Offset: 0xBE1F68 VA: 0xBE1F68
		public void SetMusicDataList(List<VerticalMusicDataList.MusicListData> musicList, int listNo, int diff)
		{
			m_isSingleMusic = false;
			m_musicList = musicList;
			m_difficult = diff;
			if(m_musicList.Count == 1)
			{
				m_musicList = new List<VerticalMusicDataList.MusicListData>(musicList);
				m_musicList.Add(m_musicList[0]);
				m_isSingleMusic = true;
			}
			m_musicScroll.ItemCount = m_musicList.Count;
			m_musicScroll.SetPosition(listNo);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F5C94 Offset: 0x6F5C94 VA: 0x6F5C94
		// // RVA: 0xBE2130 Offset: 0xBE2130 VA: 0xBE2130
		public IEnumerator Co_UpdateAnim(Action outEndCallback)
		{
			//0xBE493C
			MenuScene.Instance.InputDisable();
			m_listUpdateAnim.Play(hashStateOut);
			yield return new WaitForSeconds(0.3f);
			outEndCallback();
			while (m_listUpdateAnim.GetCurrentAnimatorStateInfo(0).fullPathHash == hashStateOut)
				yield return null;
			while (m_listUpdateAnim.GetCurrentAnimatorStateInfo(0).fullPathHash == hashStateIn)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xBE21F8 Offset: 0xBE21F8 VA: 0xBE21F8
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBE2228 Offset: 0xBE2228 VA: 0xBE2228
		public void Leave()
		{
			if (!gameObject.activeSelf)
				return;
			m_inOut.ForceLeave(null);
		}

		// // RVA: 0xBE228C Offset: 0xBE228C VA: 0xBE228C
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBE22B8 Offset: 0xBE22B8 VA: 0xBE22B8
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xBE233C Offset: 0xBE233C VA: 0xBE233C
		private void MusicUpdateCenterItem(int listIndex, MusicScrollCenterItem obj)
		{
			if(m_musicList.Count == 0)
				return;
			if(m_musicList.Count <= listIndex)
				return;
			if (m_isSingleMusic)
				listIndex = 0;
			if (OnUpdateCenter != null)
				OnUpdateCenter.Invoke(listIndex);
			obj.ResetScroll();
			if(m_musicList[listIndex].ViewMusic.AJGCPCMLGKO_IsEvent)
			{
				obj.SetListType(MusicScrollCenterItem.ListType.EventEntrance);
				obj.SetEventName(m_musicList[listIndex].ViewMusic.AFCMIOIGAJN_EventInfo.OPFGFINHFCE_EventName);
				obj.SetEventDescription(m_musicList[listIndex].ViewMusic.AFCMIOIGAJN_EventInfo.KLMPFGOCBHC_EventDesc);
				obj.SetEventPeriod(m_musicList[listIndex].EventPeriod);
				obj.SetAttribute(4);
			}
			else if (m_musicList[listIndex].ViewMusic.BNIAJAKIAJC_IsEventMinigame)
			{
				obj.SetListType(MusicScrollCenterItem.ListType.EventEntrance);
				obj.SetEventName(m_musicList[listIndex].ViewMusic.NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_EventName);
				obj.SetEventDescription(m_musicList[listIndex].ViewMusic.NOKBLCDMLPP_MinigameEventInfo.KLMPFGOCBHC_EventDesc);
				obj.SetEventPeriod(m_musicList[listIndex].EventPeriod);
				obj.SetAttribute(4);
			}
			else if (m_musicList[listIndex].IsSimulation)
			{
				obj.SetListType(MusicScrollCenterItem.ListType.LimitedSLive);
				obj.SetEventName(m_musicList[listIndex].MusicName);
				obj.SetEventDescription(m_musicList[listIndex].VocalName);
				obj.SetAttribute(m_musicList[listIndex].ViewMusic.FKDCCLPGKDK_JacketAttr);
				obj.SetNewIcon(false);
			}
			else
			{
				if (m_musicList[listIndex].IsHighLevel)
				{
					obj.SetListType(MusicScrollCenterItem.ListType.HighLevel);
					obj.SetHighLevelMusicTitle(m_musicList[listIndex].MusicName);
					obj.SetHighLevelSingerName(m_musicList[listIndex].VocalName);
				}
				else
				{
					obj.SetListType(MusicScrollCenterItem.ListType.Normal);
					obj.SetTitle(m_musicList[listIndex].MusicName);
					obj.SetSingerName(m_musicList[listIndex].VocalName);
				}
				obj.SetAttribute(m_musicList[listIndex].ViewMusic.FKDCCLPGKDK_JacketAttr);
				obj.SetLockIcon(m_musicList[listIndex].IsOpen, m_musicList[listIndex].IsUnlockable);
				if(!m_musicList[listIndex].ViewMusic.BJANNALFGGA)
				{
					obj.SetRankingButton(m_musicList[listIndex].ViewMusic.LEBDMNIGOJB);
				}
				else
				{
					obj.SetRankingButton(true);
				}
				if (!m_musicList[listIndex].IsOpen)
					obj.SetNewIcon(false);
				else
					obj.SetNewIcon(m_musicList[listIndex].IsNew);
			}
			if(!m_isSingleMusic)
			{
				obj.SetMusicNo(listIndex + 1, m_musicList.Count);
			}
			else
			{
				obj.SetMusicNo(1, 1);
			}
			if (m_musicList[listIndex].IsSimulation)
			{
				obj.LabelGroup.EnableLimitedSLiveLabel();
				obj.LabelGroup.DisableTimeLabel();
				obj.LabelGroup.DisableEventLabel();
				obj.LabelGroup.DisableMusicTypeLabel();
				obj.LabelGroup.DisablePlayBoostLabel();
				obj.SetRewardState(false, false, false);
			}
			else
			{
				obj.LabelGroup.DisableLimitedSLiveLabel();
				obj.LabelGroup.SetTimeLabel(m_musicList[listIndex].TimeType);
				obj.LabelGroup.SetEventLabel(m_musicList[listIndex].EventType);
				obj.LabelGroup.SetMusicTypeLabel(m_musicList[listIndex].MusicType);
				obj.LabelGroup.SetPlayBoostLabel(m_musicList[listIndex].PlayBoostType);
				if (m_musicList[listIndex].RewardStat != null && m_difficult < m_musicList[listIndex].RewardStat.Count)
				{
					obj.SetRewardState(m_musicList[listIndex].RewardStat[m_difficult].isScoreComplete, m_musicList[listIndex].RewardStat[m_difficult].isComboComplete
						, m_musicList[listIndex].RewardStat[m_difficult].isClearCountComplete);
				}
				else
				{
					obj.SetRewardState(false, false, false);
				}
			}
			if(m_musicList[listIndex].ViewMusic.AIHCEGFANAM_Serie < 5)
			{
				obj.SetSeries(m_musicList[listIndex].ViewMusic.AIHCEGFANAM_Serie);
			}
			else
			{
				obj.SetSeries(10);
			}
		}

		// // RVA: 0xBE3850 Offset: 0xBE3850 VA: 0xBE3850
		private void MusicUpdateListItem(int listIndex, MusicScrollItem obj)
		{
			if(m_musicList.Count == 0)
				return;
			if(m_musicList.Count <= listIndex)
				return;
			if (m_isSingleMusic)
				listIndex = 0;
			if (m_musicList[listIndex].ViewMusic.AJGCPCMLGKO_IsEvent)
			{
				obj.SetListType(MusicScrollItem.ListType.EventEntrance);
				obj.SetEventName(m_musicList[listIndex].ViewMusic.AFCMIOIGAJN_EventInfo.OPFGFINHFCE_EventName);
				obj.SetNewIcon(false);
				obj.SetAttribute(4);
			}
			else if (m_musicList[listIndex].ViewMusic.BNIAJAKIAJC_IsEventMinigame)
			{
				obj.SetListType(MusicScrollItem.ListType.EventEntrance);
				obj.SetEventName(m_musicList[listIndex].ViewMusic.NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_EventName);
				obj.SetNewIcon(false);
				obj.SetAttribute(4);
			}
			else if (m_musicList[listIndex].IsSimulation)
			{
				obj.SetListType(MusicScrollItem.ListType.EventEntrance);
				obj.SetEventName(m_musicList[listIndex].MusicName);
				obj.SetAttribute(m_musicList[listIndex].ViewMusic.FKDCCLPGKDK_JacketAttr);
				obj.SetNewIcon(false);
			}
			else
			{
				if (m_musicList[listIndex].IsHighLevel)
				{
					obj.SetListType(MusicScrollItem.ListType.HighLevel);
					obj.SetHighLevelMusicTitle(m_musicList[listIndex].MusicName);
				}
				else
				{
					obj.SetListType(MusicScrollItem.ListType.Normal);
					obj.SetTitle(m_musicList[listIndex].MusicName);
				}
				obj.SetAttribute(m_musicList[listIndex].ViewMusic.FKDCCLPGKDK_JacketAttr);
				obj.SetLockIcon(m_musicList[listIndex].IsOpen, m_musicList[listIndex].IsUnlockable);
				if(!m_musicList[listIndex].IsOpen)
					obj.SetNewIcon(false);
				else
					obj.SetNewIcon(m_musicList[listIndex].IsNew);
			}
			if (m_musicList[listIndex].IsSimulation)
			{
				obj.LabelGroup.EnableLimitedSLiveLabel();
				obj.LabelGroup.DisableTimeLabel();
				obj.LabelGroup.DisableEventLabel();
				obj.LabelGroup.DisableMusicTypeLabel();
				obj.LabelGroup.DisablePlayBoostLabel();
				obj.SetRewardState(false, false, false);
			}
			else
			{
				obj.LabelGroup.DisableLimitedSLiveLabel();
				obj.LabelGroup.SetTimeLabel(m_musicList[listIndex].TimeType);
				obj.LabelGroup.SetEventLabel(m_musicList[listIndex].EventType);
				obj.LabelGroup.SetMusicTypeLabel(m_musicList[listIndex].MusicType);
				obj.LabelGroup.SetPlayBoostLabel(m_musicList[listIndex].PlayBoostType);
				if (m_musicList[listIndex].RewardStat != null && m_difficult < m_musicList[listIndex].RewardStat.Count)
				{
					obj.SetRewardState(m_musicList[listIndex].RewardStat[m_difficult].isScoreComplete, m_musicList[listIndex].RewardStat[m_difficult].isComboComplete
						, m_musicList[listIndex].RewardStat[m_difficult].isClearCountComplete);
				}
				else
				{
					obj.SetRewardState(false, false, false);
				}
			}
		}
	}
}
