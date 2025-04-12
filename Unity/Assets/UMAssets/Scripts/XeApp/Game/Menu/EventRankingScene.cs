using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EventRankingScene : RankingSceneBase
	{
		private enum EnRankingType
		{
			Point = 0,
			Score = 1,
			Music = 2,
			ExBattlePoint = 3,
			ExBattleScore = 4,
			Raid = 5,
			GoDivaScore_01 = 6,
			GoDivaScore_02 = 7,
			GoDivaScore_03 = 8,
			GoDivaScore_04 = 9,
			GoDivaScore_05 = 10,
			GoDivaScore_06 = 11,
			GoDivaScore_07 = 12,
			GoDivaScore_08 = 13,
			GoDivaScore_09 = 14,
			GoDivaScore_10 = 15,
		}

		private EnRankingType m_current_ranking_type; // 0x78
		private EnRankingType[] m_ranking_types = new EnRankingType[10]; // 0x7C
		private int m_currentRankingIndex; // 0x80
		private int m_rankingMax = 1; // 0x84
		private IKDICBBFBMI_EventBase m_eventCtrl; // 0x88
		private bool m_isPast; // 0x8C
		private string[] m_nameForApi = new string[10]; // 0x90
		private int m_eventId = 1; // 0x94
		private List<int> m_rankRangeList; // 0x98
		private List<string> m_rankRangeLabelList; // 0x9C
		private int m_currentRankRange; // 0xA0
		private int m_nextRankRange; // 0xA4
		private RankRangePopupSetting m_rankRangePopupSetting = new RankRangePopupSetting(); // 0xA8
		private bool m_enableChangeRanking; // 0xAC

		// // RVA: 0xB8B0C4 Offset: 0xB8B0C4 VA: 0xB8B0C4
		// private bool IsBattleRanking() { }

		// // RVA: 0xB8B0DC Offset: 0xB8B0DC VA: 0xB8B0DC
		// private bool IsGoDivaRanking() { }

		// RVA: 0xB8B0F4 Offset: 0xB8B0F4 VA: 0xB8B0F4 Slot: 31
		protected override void Initialize()
		{
			EventRankingSceneArgs Arg = Args as EventRankingSceneArgs;
			if(Arg != null)
			{
				m_eventCtrl = Arg.eventCtrl;
				m_isPast = Arg.isPast;
				int v1 = m_eventCtrl.DBOLCELMBJG_GetMainRankingIndex();
				m_nameForApi[0] = m_eventCtrl.DAKMIKNKHMF_GetRankingInfoForIndex(v1).OCGFKMHNEOF_NameForApi;
				m_nameForApi[1] = "";
				m_rankingMax = m_eventCtrl.NGIHFKHOJOK_GetRankingMax(false);
				m_eventId = m_eventCtrl.PGIIDPEGGPI_EventId;
				m_currentRankingIndex = Arg.CurrentRankingIndex;
				if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
				{
					m_ranking_types[0] = EnRankingType.Score;
				}
				else if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					m_ranking_types[0] = EnRankingType.Raid;
					m_enableChangeRanking = false;
				}
				else if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					m_ranking_types[0] = EnRankingType.GoDivaScore_01 + Arg.selectDiva - 1;
					m_enableChangeRanking = false;
				}
				else
				{
					if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					{
						m_ranking_types[0] = v1 != 0 ? EnRankingType.ExBattleScore : EnRankingType.ExBattlePoint;
						m_ranking_types[1] = v1 != 0 ? EnRankingType.ExBattlePoint : EnRankingType.ExBattleScore;
					}
					else
					{ 
						m_ranking_types[0] = v1 != 0 ? EnRankingType.Music : EnRankingType.Point;
						m_ranking_types[1] = v1 != 0 ? EnRankingType.Point : EnRankingType.Music;
					}
					if(m_eventCtrl.NGIHFKHOJOK_GetRankingMax() > 1)
					{
						m_nameForApi[1] = m_eventCtrl.DAKMIKNKHMF_GetRankingInfoForIndex(v1 == 0 ? 1 : 0).OCGFKMHNEOF_NameForApi;
						m_enableChangeRanking = true;
					}
					else
					{
						m_enableChangeRanking = false;
					}
				}
				m_current_ranking_type = m_ranking_types[m_currentRankingIndex];
			}
			InitializeDecos();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_current_ranking_type == EnRankingType.Score)
			{
				KEODKEGFDLD_FreeMusicInfo fmi = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[m_eventCtrl.HEACCHAKMFG_GetMusicsList()[0] - 1];
				EONOEHOKBEB_Music mi = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[fmi.DLAEJOBELBH_MusicId - 1];
				m_windowUi.ChangePreset(GeneralListWindow.Preset.ScoreEventRanking, false);
				m_windowUi.SetMusicTitle(Database.Instance.musicText.Get(mi.KNMGEEFGDNI_Nam).musicName, GameAttributeTextColor.Colors[mi.FKDCCLPGKDK_Ma - 1]);
				m_windowUi.SetMusicAttr((GameAttribute.Type) mi.FKDCCLPGKDK_Ma);
				m_windowUi.SetMusicDiffVisible(false);
				if(!m_isPast)
					m_windowUi.SetRankingMessage(bk.GetMessageByLabel("ranking_message"));
				else
					m_windowUi.SetRankingMessage("");
				GameManager.Instance.MusicJacketTextureCache.Load(mi.JNCPEGJGHOG_Cov, (IiconTexture image) =>
				{
					//0xB8E5B0
					m_windowUi.SetMusicJacket(image);
				});
			}
			else
			{
				if(m_current_ranking_type == EnRankingType.ExBattlePoint || m_current_ranking_type == EnRankingType.ExBattleScore)
					m_windowUi.ChangePreset(GeneralListWindow.Preset.BattleEventRanking, m_enableChangeRanking);
				else if(m_current_ranking_type >= EnRankingType.GoDivaScore_01 && m_current_ranking_type <= EnRankingType.GoDivaScore_10)
					m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaEventRanking, m_enableChangeRanking);
				//int y, m, d, H, M;
				//ExtractDateTime(m_eventCtrl.GLIMIGNNGGB_Start, out y, out m, out d, out H, out M);
				if(!m_isPast)
					m_windowUi.SetRankingMessage(bk.GetMessageByLabel("ranking_ev_message"));
				else
					m_windowUi.SetRankingMessage("");
				GameManager.Instance.EventBannerTextureCache.LoadBanner(m_eventId, (IiconTexture image) =>
				{
					//0xB8E5E4
					m_windowUi.SetEventBanner(image);
				});
				if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI(m_eventCtrl.HEACCHAKMFG_GetMusicsList()[0], false, 0, 0, 0, false, false, false);
					SetEventMusicRankingJacket(ib.JNCPEGJGHOG_JacketId, 0);
				}
				else
				{
					if(m_enableChangeRanking)
					{
						m_windowUi.onClickChangeRankingButton = OnClickChangeRankingButton;
						IBJAKJJICBC ib = new IBJAKJJICBC();
						if(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
						{
							DCAKKIJODME dc = new DCAKKIJODME();
							dc.KHEKNNFCAOI(false);
							List<EMGOCNMMPHC> l = dc.JNALKFEADEM();
							for(int i = 0; i < l.Count; i++)
							{
								SetEventMusicRankingJacket(l[i].JNCPEGJGHOG_JackedId, i);
							}
						}
						else
						{
							ib.KHEKNNFCAOI(m_eventCtrl.HEACCHAKMFG_GetMusicsList()[0], false, 0, 0, 0, false, false, false);
							SetEventMusicRankingJacket(ib.JNCPEGJGHOG_JacketId, 0);
						}
					}
				}
			}
			//LAB_00b8c564
			ChangeRankingWindowStyle(m_current_ranking_type);
			m_windowUi.onClickTotalRankButton = OnClickTotalButton;
			m_windowUi.onClickFriendRankButton = OnClickFriendButton;
			m_windowUi.onClickRankRangeButton = OnClickRankRangeButton;
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			if(CheckTransitByReturn())
			{
				m_scrollList.VisibleRegionUpdate();
				if(isFriendList)
				{
					OnSetupFriendRanking();
				}
			}
			else
			{
				m_rankRangeList = new List<int>(m_eventCtrl.HGLAFGHHFKP.Count + 1);
				m_rankRangeList.Add(0);
				m_rankRangeList.AddRange(m_eventCtrl.HGLAFGHHFKP);
				m_rankRangeLabelList = new List<string>(m_eventCtrl.HGLAFGHHFKP.Count);
				StringBuilder str = new StringBuilder(8);
				for(int i = 0; i < m_rankRangeList.Count; i++)
				{
					if(m_rankRangeList[i] == 0)
					{
						m_rankRangeLabelList.Add(bk.GetMessageByLabel("popup_rank_range_myself"));
					}
					else
					{
						str.SetFormatSmart(bk.GetMessageByLabel("popup_rank_range_place"), m_rankRangeList[i]);
						m_rankRangeLabelList.Add(str.ToString());
					}
				}
				m_currentRankRange = 0;
				m_windowUi.SetRankButtonLabel(m_rankRangeLabelList[0]);
				m_windowUi.SelectTotalRankingTab();
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
				ResetReceivedFlag();
				SetupTotalRanking();
			}
		}

		// // RVA: 0xB8CFB0 Offset: 0xB8CFB0 VA: 0xB8CFB0
		private void SetEventMusicRankingJacket(int coverId, int index)
		{
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture texture) =>
			{
				//0xB8E754
				m_windowUi.SetEventMusicRankingJacket(texture, index);
			});
		}

		// // RVA: 0xB8CE94 Offset: 0xB8CE94 VA: 0xB8CE94
		// protected static void ExtractDateTime(long unixTime, out int years, out int months, out int days, out int hours, out int minutes) { }

		// RVA: 0xB8D6A4 Offset: 0xB8D6A4 VA: 0xB8D6A4 Slot: 32
		protected override void Release()
		{
			ReleaseDecos();
		}

		// RVA: 0xB8D6AC Offset: 0xB8D6AC VA: 0xB8D6AC Slot: 33
		protected override int GetCurrentBaseRank()
		{
			if(!isFriendList)
				return m_rankRangeList[m_currentRankRange];
			return 1;
		}

		// RVA: 0xB8D744 Offset: 0xB8D744 VA: 0xB8D744 Slot: 34
		protected override void GetRankingList(int baseRank, int rankingIdx)
		{
			if(m_current_ranking_type >= EnRankingType.GoDivaScore_01 && m_current_ranking_type <= EnRankingType.GoDivaScore_10)
			{
				MANPIONIGNO_EventGoDiva ev = m_eventCtrl as MANPIONIGNO_EventGoDiva;
				if(ev != null)
				{
					m_windowUi.SetMessageVisible(false);
					m_eventCtrl.FAMFKPBPIAA_GetRankingPlayerList(isFriendList, baseRank, (int)m_current_ranking_type - 6, OnReceivedRankingList, OnRankingError, OnNetError);
				}
			}
			else
			{
				//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
				m_windowUi.SetMessageVisible(false);
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(m_nameForApi[m_currentRankingIndex], isFriendList, baseRank, rankingIdx, OnReceivedRankingList, OnRankingError, OnNetError, false);
			}
		}

		// RVA: 0xB8DAAC Offset: 0xB8DAAC VA: 0xB8DAAC Slot: 35
		protected override void GetRankingListAdditive(bool isUpper)
		{
			if(m_current_ranking_type >= EnRankingType.GoDivaScore_01 && m_current_ranking_type <= EnRankingType.GoDivaScore_10)
			{
				MANPIONIGNO_EventGoDiva ev = m_eventCtrl as MANPIONIGNO_EventGoDiva;
				if(ev != null)
				{
					ev.JPNACOLKHLB_AddRankingPlayerListSecond(GetListEdgeRank(isUpper), isUpper ? -1 : 1, OnReceivedRankingListAdditive, OnRankingError, OnNetError);
				}
			}
			else
			{
				KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(GetListEdgeRank(isUpper), isUpper ? -1 : 1, OnReceivedRankingListAdditive, OnRankingError, OnNetError, false);
			}
		}

		// RVA: 0xB8DD90 Offset: 0xB8DD90 VA: 0xB8DD90 Slot: 36
		protected override string GetRankingNotFoundMessage()
		{
			if(!isFriendList)
			{
				if(GetCurrentBaseRank() == 0)
					return MessageManager.Instance.GetMessage("menu", "ranking_ev_no_entry");
				else
					return MessageManager.Instance.GetMessage("menu", "ranking_ev_range_not_found");
			}
			else
			{
				return MessageManager.Instance.GetMessage("menu", "ranking_ev_no_entry");
			}
		}

		// RVA: 0xB8DE7C Offset: 0xB8DE7C VA: 0xB8DE7C Slot: 37
		protected override void OnSetupTotalRanking()
		{
			if(m_current_ranking_type == EnRankingType.Score)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.ScoreEventRanking, false);
			}
			else if(m_current_ranking_type == EnRankingType.ExBattlePoint || m_current_ranking_type == EnRankingType.ExBattleScore)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.BattleEventRanking, m_enableChangeRanking);
			}
			else if(m_current_ranking_type >= EnRankingType.GoDivaScore_01 && m_current_ranking_type <= EnRankingType.GoDivaScore_10)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaEventRanking, m_enableChangeRanking);
			}
			else
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.CollectEventRanking, m_enableChangeRanking);
			}
		}

		// RVA: 0xB8DF44 Offset: 0xB8DF44 VA: 0xB8DF44 Slot: 38
		protected override void OnSetupFriendRanking()
		{
			if(m_current_ranking_type == EnRankingType.Score)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.ScoreEventRankingFriend, false);
			}
			else if(m_current_ranking_type == EnRankingType.ExBattlePoint || m_current_ranking_type == EnRankingType.ExBattleScore)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.BattleEventRankingFriend, m_enableChangeRanking);
			}
			else if(m_current_ranking_type >= EnRankingType.GoDivaScore_01 && m_current_ranking_type <= EnRankingType.GoDivaScore_10)
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.GoDivaEventRankingFriend, m_enableChangeRanking);
			}
			else
			{
				m_windowUi.ChangePreset(GeneralListWindow.Preset.CollectEventRankingFriend, m_enableChangeRanking);
			}
		}

		// // RVA: 0xB8E00C Offset: 0xB8E00C VA: 0xB8E00C
		private void OnClickRankRangeButton()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_rankRangePopupSetting.TitleText = bk.GetMessageByLabel("popup_rank_range_title");
			m_rankRangePopupSetting.SetParent(transform);
			m_rankRangePopupSetting.WindowSize = SizeType.Small;
			m_rankRangePopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_rankRangePopupSetting.itemLabels = m_rankRangeLabelList;
			m_rankRangePopupSetting.initialLabelIndex = m_currentRankRange;
			m_rankRangePopupSetting.onDecideIndex = OnChangedRankRange;
			m_nextRankRange = m_currentRankRange;
			PopupWindowManager.Show(m_rankRangePopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xB8E618
				if(m_currentRankRange == m_nextRankRange)
					return;
				m_currentRankRange = m_nextRankRange;
				m_windowUi.SetRankButtonLabel(m_rankRangeLabelList[m_nextRankRange]);
				MenuScene.Instance.RaycastDisable();
				GetRankingList(GetCurrentBaseRank(), 0);
			}, null, null, null, true, true, false);
		}

		// // RVA: 0xB8E38C Offset: 0xB8E38C VA: 0xB8E38C
		private void OnChangedRankRange(int rangeIndex)
		{
			m_nextRankRange = rangeIndex;
		}

		// // RVA: 0xB8E394 Offset: 0xB8E394 VA: 0xB8E394
		private void OnClickChangeRankingButton()
		{
			m_currentRankingIndex++;
			m_currentRankingIndex = Math.Repeat(m_currentRankingIndex, 0, m_rankingMax - 1);
			m_current_ranking_type = m_ranking_types[m_currentRankingIndex];
			if(isFriendList)
			{
				OnClickFriendButton();
			}
			else
			{
				OnClickTotalButton();
			}
			ChangeRankingWindowStyle(m_current_ranking_type);
		}

		// // RVA: 0xB8D110 Offset: 0xB8D110 VA: 0xB8D110
		private void ChangeRankingWindowStyle(EnRankingType a_type)
		{
			switch(a_type)
			{
				case EnRankingType.Point:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.Point);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.TotalRanking, 0);
					break;
				case EnRankingType.Score:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.Score);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.DefaultRanking, 0);
					break;
				case EnRankingType.Music:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.EventHiScore);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.MusicRanking, 0);
					break;
				case EnRankingType.ExBattlePoint:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.Point);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.ExBattleTotalRanking, 0);
					break;
				case EnRankingType.ExBattleScore:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.EventExBattleScore);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.ExBattleScoreRanking, 0);
					break;
				case EnRankingType.Raid:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.Raid);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.TotalRanking, 0);
					break;
				case EnRankingType.GoDivaScore_01:
				case EnRankingType.GoDivaScore_02:
				case EnRankingType.GoDivaScore_03:
				case EnRankingType.GoDivaScore_04:
				case EnRankingType.GoDivaScore_05:
				case EnRankingType.GoDivaScore_06:
				case EnRankingType.GoDivaScore_07:
				case EnRankingType.GoDivaScore_08:
				case EnRankingType.GoDivaScore_09:
				case EnRankingType.GoDivaScore_10:
					for(int i = 0; i < m_elems.Count; i++)
					{
						m_elems[i].SetStyle(RankingListElemBase.StyleType.DivaEventRanking);
					}
					m_windowUi.ChangeEventSubHeaderStyle(GeneralListWindow.EventSubHeaderStyle.DivaRanking, (int)a_type - 5);
					break;
				default:
					break;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E13CC Offset: 0x6E13CC VA: 0x6E13CC
		// // RVA: 0xB8E444 Offset: 0xB8E444 VA: 0xB8E444 Slot: 39
		protected override IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			FontInfo systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int i; // 0x28

			//0xB8EAD0
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB8E7B0
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GeneralListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
			}));
			bundleLoadCount++;
			yield return Co.R(Co_LoadListElem(bundleName.ToString(), "UI_ScoreRankingListElem", systemFont, m_scrollList.ScrollObjectCount, "RankingListElem {0:D2}", (LayoutUGUIRuntime instance) =>
			{
				//0xB8E8F4
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<ScoreRankingListElem>());
			}));
			bundleLoadCount++;
			PopupRankRangeContent popupContent = null;
			operation = AssetBundleManager.LoadLayoutAsync(m_rankRangePopupSetting.BundleName, m_rankRangePopupSetting.AssetName);
			bundleLoadCount++;
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB8EA18
				m_rankRangePopupSetting.SetContent(instance);
				popupContent = instance.GetComponent<PopupRankRangeContent>();
			}));
			yield return Co.R(popupContent.Co_LoadElements(m_rankRangePopupSetting.BundleName));
			m_rankRangePopupSetting.SetParent(transform);
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while(!m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while(!m_elems[i].IsLoaded())
					yield return null;
			}
		}
	}
}
