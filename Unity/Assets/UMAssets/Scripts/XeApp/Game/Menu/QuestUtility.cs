
using System;
using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;
using static XeApp.Game.Menu.GachaScene;

namespace XeApp.Game.Menu
{ 
	public class QuestUtility
	{
		public class EventQuestData
		{
			public string m_masterName; // 0x8
			public int m_uniqueId; // 0xC
			public OHCAABOMEOF.KGOGMKMBCPP_EventType m_eventType; // 0x10
			public List<FKMOKDCJFEN> m_viewList; // 0x14
			public int m_achievedCount; // 0x18
		}

		public const int QUEST_ACHIEVED_COUNT_MAX = 99;
		public static List<FKMOKDCJFEN> m_dailyViewList; // 0x0
		public static List<FKMOKDCJFEN> m_beginnerViewList; // 0x4
		public static List<FKMOKDCJFEN> m_normalViewList; // 0x8
		public static List<FKMOKDCJFEN> m_snsViewList; // 0xC
		public static List<CGJKNOCAPII> m_eventViewList; // 0x10
		public static List<CGJKNOCAPII> m_bingoViewList; // 0x14
		public static MFDJIFIIPJD m_selectedItemInfo; // 0x18
		public static int m_dailyAchievedCount; // 0x1C
		public static int m_beginnerAchievedCount; // 0x20
		public static int m_normalAchievedCount; // 0x24
		public static int m_snsAchievedCount; // 0x28
		public static List<EventQuestData> m_eventQuestDataList; // 0x2C
		private const int M = 60;
		private const int H = 3600;
		private const int D = 86400;
		private static Action m_showSnsCallback; // 0x30

		//// RVA: 0x9DB964 Offset: 0x9DB964 VA: 0x9DB964
		public static void UpdateQuestData(LayoutQuestTab.eTabType type)
		{
			switch(type)
			{
				case LayoutQuestTab.eTabType.Event:
					m_eventViewList = CGJKNOCAPII.JHCHAOJFHFG(false);
					m_eventQuestDataList = new List<EventQuestData>();
					for(int i = 0; i < m_eventViewList.Count; i++)
					{
						EventQuestData data = new EventQuestData();
						data.m_masterName = m_eventViewList[i].JOPOPMLFINI_QuastName;
						data.m_uniqueId = m_eventViewList[i].JHAOHBNPMNA_EventId;
						data.m_eventType = m_eventViewList[i].COAMJFMEIBF.HIDHLFCBIDE_EventType;
						data.m_viewList = FKMOKDCJFEN.KJHKBBBDBAL(m_eventViewList[i].JOPOPMLFINI_QuastName, false, m_eventViewList[i].BCOKKAALGHC);
						data.m_achievedCount = GetQuestCountByStatus(data.m_viewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
						m_eventQuestDataList.Add(data);
						m_eventViewList[i].PKNLMLDKCLM_AchievedQuests = data.m_achievedCount;
						if(data.m_achievedCount < 1)
						{
							m_eventViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.None;
							m_eventViewList[i].BHANMJKCCBC_QuestAchievedCountText = "";
						}
						else
						{
							m_eventViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.Label;
							m_eventViewList[i].BHANMJKCCBC_QuestAchievedCountText = GetAchievedCountText(data.m_achievedCount);
						}
					}
					break;
				case LayoutQuestTab.eTabType.Normal:
					m_normalViewList = FKMOKDCJFEN.ABHPOFCEAEN_GetNormalQuests(false);
					m_normalAchievedCount = GetQuestCountByStatus(m_normalViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Daily:
					m_dailyViewList = FKMOKDCJFEN.NNEHCMNOKFO_GetDailyQuests(false);
					m_dailyAchievedCount = GetQuestCountByStatus(m_dailyViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Diva:
					m_snsViewList = FKMOKDCJFEN.IHEMBPBBIEO_GetSnsQuest(false);
					m_snsAchievedCount = GetQuestCountByStatus(m_snsViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Beginner:
					m_beginnerViewList = FKMOKDCJFEN.BAENBNLMPMO_GetBeginnerQuest(false);
					m_beginnerAchievedCount = GetQuestCountByStatus(m_beginnerViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Bingo:
					m_eventQuestDataList = new List<EventQuestData>();
					m_bingoViewList = CGJKNOCAPII.GOGBAODOOAO(false);
					for (int i = 0; i < m_bingoViewList.Count; i++)
					{
						EventQuestData data = new EventQuestData();
						data.m_masterName = m_bingoViewList[i].JOPOPMLFINI_QuastName;
						data.m_uniqueId = m_bingoViewList[i].JHAOHBNPMNA_EventId;
						data.m_eventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO;
						data.m_achievedCount = GNGMCIAIKMA.HHCJCDFCLOB.OBOGIOGEBPK(m_bingoViewList[i].PGIIDPEGGPI_EventId, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
						m_eventQuestDataList.Add(data);
						m_bingoViewList[i].PKNLMLDKCLM_AchievedQuests = data.m_achievedCount;
						if(data.m_achievedCount < 1)
						{
							m_bingoViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.None;
							m_bingoViewList[i].BHANMJKCCBC_QuestAchievedCountText = "";
						}
						else
						{
							m_bingoViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.Label;
							m_bingoViewList[i].BHANMJKCCBC_QuestAchievedCountText = GetAchievedCountText(data.m_achievedCount);
						}
					}
					break;
			}
		}

		//// RVA: 0x9D60CC Offset: 0x9D60CC VA: 0x9D60CC
		public static void UpdateQuestData()
		{
			UpdateQuestData(LayoutQuestTab.eTabType.Daily);
			UpdateQuestData(LayoutQuestTab.eTabType.Normal);
			UpdateQuestData(LayoutQuestTab.eTabType.Beginner);
			UpdateQuestData(LayoutQuestTab.eTabType.Diva);
			UpdateQuestData(LayoutQuestTab.eTabType.Event);
			UpdateQuestData(LayoutQuestTab.eTabType.Bingo);
		}

		//// RVA: 0x9E2BEC Offset: 0x9E2BEC VA: 0x9E2BEC
		public static bool FindAchievedQuestList(List<FKMOKDCJFEN> list)
		{
			if(list != null)
			{
				for(int i = 0; i < list.Count; i++)
				{
					if (list[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
						return true;
				}
			}
			return false;
		}

		//// RVA: 0x9E2CD8 Offset: 0x9E2CD8 VA: 0x9E2CD8
		public static List<FKMOKDCJFEN> GetEventQuestList(string masterName)
		{
			if (m_eventQuestDataList != null)
			{
				EventQuestData data = m_eventQuestDataList.Find((EventQuestData _) =>
				{
					//0x9E7D50
					return _.m_masterName == masterName;
				});
				if(data != null)
				{
					return data.m_viewList;
				}
			}
			return null;
		}

		//// RVA: 0x9E29AC Offset: 0x9E29AC VA: 0x9E29AC
		public static int GetQuestCountByStatus(List<FKMOKDCJFEN> list, FKMOKDCJFEN.ADCPCCNCOMD_Status status)
		{
			int res = 0;
			if(list != null)
			{
				for(int i = 0; i < list.Count; i++)
				{
					if(list[i].CMCKNKKCNDK_Status == status)
					{
						res++;
					}
				}
			}
			return res;
		}

		//// RVA: 0x9E2E60 Offset: 0x9E2E60 VA: 0x9E2E60
		public static void FooterMenuBadge(bool enable)
		{
			if(MenuScene.Instance != null && MenuScene.Instance.FooterMenu != null)
			{
				MenuScene.Instance.FooterMenu.SetButtonNew(MenuFooterControl.Button.Mission, enable);
			}
		}

		//// RVA: 0x9D6170 Offset: 0x9D6170 VA: 0x9D6170
		public static void FooterMenuBadge()
		{
			FooterMenuBadge(IsEmphasisAll());
		}

		//// RVA: 0x9E322C Offset: 0x9E322C VA: 0x9E322C
		//public static long GetCurrentServerUnixTime() { }

		//// RVA: 0x9DB754 Offset: 0x9DB754 VA: 0x9DB754
		public static bool IsCrossDateline()
		{
			return MenuScene.CheckDatelineAndAssetUpdate();
		}

		//// RVA: 0x9E3308 Offset: 0x9E3308 VA: 0x9E3308
		//public static int TimeInteger(long unix_time) { }

		//// RVA: 0x9E3408 Offset: 0x9E3408 VA: 0x9E3408
		//public static string Time(long unix_time) { }

		//// RVA: 0x9E3630 Offset: 0x9E3630 VA: 0x9E3630
		//public static void PopupShowBeginner(Transform parent, Action openEndCallback, Action callback, int faceIndex = 4) { }

		//// RVA: 0x9E39B4 Offset: 0x9E39B4 VA: 0x9E39B4
		//private static TutorialTextPopupSetting CreateTutorialPopup(Transform parent, int face, string message, SizeType size, ButtonInfo[] buttons) { }

		//// RVA: 0x9DAAD4 Offset: 0x9DAAD4 VA: 0x9DAAD4
		public static bool IsBeginnerQuest()
		{
			return m_beginnerViewList.Find((FKMOKDCJFEN _) =>
			{
				//0x9E7A80
				if (_.OAPCHMHAJID)
					return _.CMCKNKKCNDK_Status != FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG_Received;
				return false;
			}) != null;
		}

		//// RVA: 0x9E3AEC Offset: 0x9E3AEC VA: 0x9E3AEC
		public static bool IsEmphasis(List<FKMOKDCJFEN> list)
		{
			return list.Find((FKMOKDCJFEN _) =>
			{
				//0x9E7AC4
				return _.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
			}) != null;
		}

		//// RVA: 0x9E3C48 Offset: 0x9E3C48 VA: 0x9E3C48
		public static bool IsEmphasis(List<CGJKNOCAPII> list)
		{
			return list.Find((CGJKNOCAPII _) =>
			{
				//0x9E7AF4
				return _.PKNLMLDKCLM_AchievedQuests > 0;
			}) != null;
		}

		//// RVA: 0x9DADA8 Offset: 0x9DADA8 VA: 0x9DADA8
		public static bool IsEmphasis(LayoutQuestTab.eTabType type)
		{
			switch(type)
			{
				case LayoutQuestTab.eTabType.Event:
					return IsEmphasis(m_eventViewList);
				case LayoutQuestTab.eTabType.Normal:
					return IsEmphasis(m_normalViewList);
				case LayoutQuestTab.eTabType.Daily:
					return IsEmphasis(m_dailyViewList);
				case LayoutQuestTab.eTabType.Diva:
					return IsEmphasis(m_snsViewList);
				case LayoutQuestTab.eTabType.Beginner:
					return IsEmphasis(m_beginnerViewList);
				case LayoutQuestTab.eTabType.Bingo:
					return IsEmphasis(m_bingoViewList);
				default:
					return false;
			}
		}

		//// RVA: 0x9E3004 Offset: 0x9E3004 VA: 0x9E3004
		public static bool IsEmphasisAll()
		{
			if(IsEmphasis(m_dailyViewList))
				return true;
			if (IsEmphasis(m_normalViewList))
				return true;
			if (IsEmphasis(m_eventViewList))
				return true;
			if (IsEmphasis(m_snsViewList))
				return true;
			if (IsEmphasis(m_beginnerViewList))
				return true;
			if (IsEmphasis(m_bingoViewList))
				return true;
			return false;
		}

		//// RVA: 0x9E3DA4 Offset: 0x9E3DA4 VA: 0x9E3DA4
		private static void BackButtonEmpty()
		{
			return;
		}

		//// RVA: 0x9E209C Offset: 0x9E209C VA: 0x9E209C
		public static void SetBackButton()
		{
			GameManager.Instance.AddPushBackButtonHandler(BackButtonEmpty);
		}

		//// RVA: 0x9E2174 Offset: 0x9E2174 VA: 0x9E2174
		public static void RemoveBackButton()
		{
			GameManager.Instance.RemovePushBackButtonHandler(BackButtonEmpty);
		}

		//// RVA: 0x9E3DA8 Offset: 0x9E3DA8 VA: 0x9E3DA8
		//public static int GetCount(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9E408C Offset: 0x9E408C VA: 0x9E408C
		public static int GetAchievedCount(List<CGJKNOCAPII> list)
		{
			int res = 0;
			for(int i = 0; i < list.Count; i++)
			{
				res += list[i].PKNLMLDKCLM_AchievedQuests;
			}
			return res;
		}

		//// RVA: 0x9E4164 Offset: 0x9E4164 VA: 0x9E4164
		public static int GetAchievedCount(LayoutQuestTab.eTabType type)
		{
			switch(type)
			{
				case LayoutQuestTab.eTabType.Event:
					return GetAchievedCount(m_eventViewList);
				case LayoutQuestTab.eTabType.Normal:
					return m_normalAchievedCount;
				case LayoutQuestTab.eTabType.Daily:
					return m_dailyAchievedCount;
				case LayoutQuestTab.eTabType.Diva:
					return m_snsAchievedCount;
				case LayoutQuestTab.eTabType.Beginner:
					return m_beginnerAchievedCount;
				case LayoutQuestTab.eTabType.Bingo:
					return GetAchievedCount(m_bingoViewList);
			}
			return 0;
		}

		//// RVA: 0x9E439C Offset: 0x9E439C VA: 0x9E439C
		public static int GetAchievedCount()
		{
			int a = GetAchievedCount(LayoutQuestTab.eTabType.Daily);
			int b = GetAchievedCount(LayoutQuestTab.eTabType.Normal);
			int c = GetAchievedCount(LayoutQuestTab.eTabType.Event);
			int d = GetAchievedCount(LayoutQuestTab.eTabType.Diva);
			int e = 0;
			if (IsBeginnerQuest())
				e = GetAchievedCount(LayoutQuestTab.eTabType.Beginner);
			else
				e = GetAchievedCount(LayoutQuestTab.eTabType.Bingo);
			return b + a + c + d + e;
		}

		//// RVA: 0x9E2AA4 Offset: 0x9E2AA4 VA: 0x9E2AA4
		public static string GetAchievedCountText(int count)
		{
			string res = "";
			if(count > 0)
			{
				MessageBank bank = MessageManager.Instance.GetBank("menu");
				if (count < 100)
					res = string.Format(bank.GetMessageByLabel("badge_label_quest_achieved"), count.ToString() + JpStringLiterals.StringLiteral_10089);
				else
					res = string.Format(bank.GetMessageByLabel("badge_label_quest_achieved"), 99.ToString() + "+");
			}
			return res;
		}

		//// RVA: 0x9E449C Offset: 0x9E449C VA: 0x9E449C
		//public static string GetAchievedCountText(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9E4520 Offset: 0x9E4520 VA: 0x9E4520
		//public static string GetAchievedCountText() { }

		//// RVA: 0x9DD7F0 Offset: 0x9DD7F0 VA: 0x9DD7F0
		public static void SetCallbackSns(Action callback)
		{
			m_showSnsCallback = callback;
		}

		//// RVA: 0x9DDC64 Offset: 0x9DDC64 VA: 0x9DDC64
		public static void SetCallbackSnsClear()
		{
			m_showSnsCallback = null;
		}

		//// RVA: 0x9E459C Offset: 0x9E459C VA: 0x9E459C
		public static void ShowSNS()
		{
			if (m_showSnsCallback == null)
				return;
			m_showSnsCallback();
		}

		//// RVA: 0x9E4684 Offset: 0x9E4684 VA: 0x9E4684
		public static void Challenge(FKMOKDCJFEN view)
		{
			switch (view.NNHHNFFLCFO)
			{
				case BKANGIKIEML.NODKLJHEAJB.DOEHLCLBCNN_1:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, new GachaArgs(10001, true), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.DJPFJGKGOOF_2:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3:
					MenuScene.Instance.Mount(TransitionUniqueId.STORYSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.EKHDECEEFFJ_4:
					MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_EPISODESELECT, new EpisodeSelectSceneArgs(view.OAPCHMHAJID), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5:
				case BKANGIKIEML.NODKLJHEAJB.LINKBPIPHAK_17:
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.HBIPNFMLLBF_6:
				case BKANGIKIEML.NODKLJHEAJB.OEFNIAKHGKD_7:
				case BKANGIKIEML.NODKLJHEAJB.MLINGAKKDEP_8:
				case BKANGIKIEML.NODKLJHEAJB.GONENLHJLCJ_9:
				case BKANGIKIEML.NODKLJHEAJB.AGCMIOFBFMG_10:
				case BKANGIKIEML.NODKLJHEAJB.BBAEIHMIFFI_11:
					{
						MusicSelectArgs arg = new MusicSelectArgs();
						arg.SetSelection((FreeCategoryId.Type)view.NNHHNFFLCFO - 5);
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.OBDLOMGHHED_12:
					{
						MusicSelectArgs arg = null;
						List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(5, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), true, false, false, false);
						for(int i = 0; i < l.Count; i++)
						{
							if(l[i].LHONOILACFL_IsWeeklyEvent)
							{
								if(l[i].BELHFPMBAPJ_WeekPlay < l[i].JOJNGDPHOKG_WeeklyMax)
								{
									if(l[i].GHBPLHBNMBK_FreeMusicId > 0)
									{
										arg = new MusicSelectArgs();
										arg.SetSelection(l[i].GHBPLHBNMBK_FreeMusicId);
									}
									break;
								}
							}
						}
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				default:
					return;
				case BKANGIKIEML.NODKLJHEAJB.JHEBCLKNOHC_14:
					{
						int a = 0;
						if (view.COAMJFMEIBF != null)
						{
							List<int> l = view.COAMJFMEIBF.HEACCHAKMFG_GetMusicsList();
							if (l.Count > 0)
								a = l[0];
						}
						GoToFreeMusic(a);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15:
					{
						int a = 0;
						if(view.COAMJFMEIBF != null)
						{
							List<int> l = view.COAMJFMEIBF.HEACCHAKMFG_GetMusicsList();
							if (view.COAMJFMEIBF.AGLILDLEFDK_Missions[view.CMEJFJFOIIJ_QuestId - 1].HMOJCCPIPBP_TargetMusicType == 1)
							{
								int cond = view.COAMJFMEIBF.AGLILDLEFDK_Missions[view.CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId;
								int idx = l.Find((int x) =>
								{
									//0x9E7DAC
									return cond == x;
								});
								if(idx < 0)
								{
									idx = IBJAKJJICBC.CJHOOLJFGFB().FindIndex((int x) =>
									{
										//0x9E7DC0
										return cond == x;
									});
									if(idx < 0)
									{
										MusicSelectArgs arg = new MusicSelectArgs();
										arg.SetSelection(FreeCategoryId.Type.Event);
										MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
										return;
									}
								}
								a = cond;
							}
							else
							{
								if (l.Count > 0)
									a = l[0];
							}
						}
						GoToFreeMusic(a);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.GAPJLFLINME_16:
					{
						int a = 0;
						if(view.COAMJFMEIBF != null && view.COAMJFMEIBF.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
						{
							AMLGMLNGMFB_EventAprilFool ev = view.COAMJFMEIBF as AMLGMLNGMFB_EventAprilFool;
							AKIIJBEJOEP ak = ev.AGLILDLEFDK_Missions[view.CMEJFJFOIIJ_QuestId - 1];
							List<int> l = view.COAMJFMEIBF.HEACCHAKMFG_GetMusicsList();
							if(ak.HMOJCCPIPBP_TargetMusicType == 6)
							{
								int cond = ev.BMBELGEDKEG(ak.HBJJCDIMOPO_TargetMusicConditionId);
								int idx = l.Find((int x) =>
								{
									//0x9E7DD4
									return cond == x;
								});
								if (idx >= 0)
									a = cond;
							}
						}
						GoToFreeMusic(a);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.ANBJBLLMHMB_18:
					{
						MusicSelectArgs arg = null;
						if(view.COAMJFMEIBF != null)
						{
							int a = 0;
							if(view.COAMJFMEIBF.AGLILDLEFDK_Missions[view.CMEJFJFOIIJ_QuestId - 1] != null)
							{
								a = view.COAMJFMEIBF.AGLILDLEFDK_Missions[view.CMEJFJFOIIJ_QuestId - 1].HBJJCDIMOPO_TargetMusicConditionId;
							}
							if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
							{
								List<int> l = IBJAKJJICBC.CJHOOLJFGFB();
								l.Sort();
								if(JGEOBNENMAH.HHCJCDFCLOB.NNABDGKFEMK_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 && JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId > 0)
								{
									l.Insert(0, JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId);
								}
								for(int i = 0; i < l.Count; i++)
								{
									KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]);
									if(fminfo.DEPGBBJMFED_CategoryId != 5)
									{
										EONOEHOKBEB_Music minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
										if(minfo.FKDCCLPGKDK_Ma == a)
										{
											if(fminfo.GHBPLHBNMBK_FreeMusicId > 0)
											{
												arg = new MusicSelectArgs();
												arg.SetSelection(fminfo.GHBPLHBNMBK_FreeMusicId);
												break;
											}
										}
									}
								}
							}
						}
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.GFLALMCKGAH_19:
					{
						MusicSelectArgs arg = new MusicSelectArgs();
						if(view.COAMJFMEIBF != null && view.COAMJFMEIBF is AMLGMLNGMFB_EventAprilFool)
						{
							arg.SetSelectionMiniGame((view.COAMJFMEIBF as AMLGMLNGMFB_EventAprilFool).NDIILFIFCDL_GetMinigameId());
						}
						else
						{
							arg.SetSelection(FreeCategoryId.Type.Event);
						}
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.OBBOJKJAHIE_20:
					{
						TeamEditSceneArgs arg = new TeamEditSceneArgs();
						arg.IsFromBeginner = view.OAPCHMHAJID;
						arg.BeginnerMissionId = view.CMEJFJFOIIJ_QuestId;
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.ADNIADMMBPM_21:
					{
						SceneListArgs arg = new SceneListArgs();
						arg.IsFromBiginner = view.OAPCHMHAJID;
						arg.QuestType = view.EEPNJFCNIEF_ClearType;
						arg.MissionId = view.CMEJFJFOIIJ_QuestId;
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.GFCAMHABJIC_22:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_PROFIL, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.ICAPJDDJIEA_23:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_PRESENTLIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PHKLLDPCDBO_24:
				case BKANGIKIEML.NODKLJHEAJB.KIBGKANOLLP_25:
				case BKANGIKIEML.NODKLJHEAJB.DFDKJPOHGAD_26:
				case BKANGIKIEML.NODKLJHEAJB.JBMMAOHHEJH_27:
				case BKANGIKIEML.NODKLJHEAJB.CJCABIKGFGG_28:
					GotoCurrentEventScene(view);
					break;
				case BKANGIKIEML.NODKLJHEAJB.IJMFEGLNDFI_30:
					{
						OptionMenuScene.OptionMenuArgs arg = new OptionMenuScene.OptionMenuArgs();
						arg.openSnsLink = true;
						MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.HGOGFPOCKFA_31:
					ShowSNS();
					break;
				case BKANGIKIEML.NODKLJHEAJB.DFEBFNNJMBM_32:
					MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.KBHGPMNGALJ_33:
					{
						CostumeChangeDivaArgs arg = new CostumeChangeDivaArgs();
						arg.DivaId = 1;
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_TEAMEDIT_COSTUMESELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.LJILBHPMPOG_34:
					MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_SHOP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.NHIOLMNADIO_35:
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.OCNIBCBBLAA_36:
					MenuScene.Instance.Mount(KDHGBOOECKC.HHCJCDFCLOB == null ? TransitionUniqueId.HOME : KDHGBOOECKC.HHCJCDFCLOB.OOFNEPBLPEA(), null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.LEHHJINPFHA_37:
					if(!MOEALEGLGCH.CDOCOLOKCJK())
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					else
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_COSTUMEUPGRADE, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				case BKANGIKIEML.NODKLJHEAJB.PKHEABDDHKB_40:
					{
						int a;
						bool b;
						HNDLICBDEMI.FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out a, out b);
						if(!b)
							MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						else
							MenuScene.Instance.Mount(TransitionUniqueId.DECO, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
					break;
				case BKANGIKIEML.NODKLJHEAJB.JDCENDOKKIE_41:
					if(!SettingMenuPanel.IsValkyrieTuneUpUnlock())
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					else
						MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_VALKYRIETUNEUP, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
			}
		}

		//// RVA: 0x9E6E3C Offset: 0x9E6E3C VA: 0x9E6E3C
		public static void Receive(FKMOKDCJFEN view, LayoutQuestVerticalItem layout, Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_Receive(view, layout, endCallback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710DB4 Offset: 0x710DB4 VA: 0x710DB4
		//// RVA: 0x9E6F28 Offset: 0x9E6F28 VA: 0x9E6F28
		private static IEnumerator Co_Receive(FKMOKDCJFEN view, LayoutQuestVerticalItem layout, Action endCallback)
		{
			//0x9E8B44
			if (view != null)
			{
				if (view.COAMJFMEIBF != null)
				{
					bool isClosed = false;
					yield return Co.R(view.COAMJFMEIBF.EPOOEDJCBDN_Co_CheckClosedEvent((bool result) =>
					{
						//0x9E7E20
						isClosed = result;
					}));
					if(isClosed)
						MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				//LAB_009e9018
				if (!MenuScene.CheckDatelineAndAssetUpdate())
				{
					bool cancel = false;
					yield return Co.R(PopupItemPossessionLimit(view.GOOIIPFHOIG, (bool isOk) =>
					{
						//0x9E7DF0
						if (!isOk)
							cancel = true;
					}));
					if (cancel)
						yield break;
					List<int> l = new List<int>();
					l.Add(view.CMEJFJFOIIJ_QuestId);
					MenuScene.Instance.RaycastDisable();
					bool done = false;
					bool err = false;
					FKMOKDCJFEN.JKBOOMAPOBL(view.JONPKLHMOBL, l, view.JOPOPMLFINI, (List<int> _list, bool limit) =>
					{
						//0x9E7E00
						done = true;
					}, () =>
					{
						//0x9E7E0C
						done = true;
						err = true;
					}, true);
					while (!done)
						yield return null;
					MenuScene.Instance.RaycastEnable();
					if(!err)
					{
						GameManager.Instance.ResetViewPlayerData();
						view.CMCKNKKCNDK_Status = FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG_Received;
						if(m_beginnerViewList.Count == 1)
						{
							if(view.OAPCHMHAJID)
							{
								QuestTopScene r = MenuScene.Instance.GetCurrentTransitionRoot() as QuestTopScene;
								if(r != null)
								{
									yield return Co.R(r.Co_TutorialBeginnerComplete(view, layout));
									yield break;
								}
							}
						}
						//LAB_009e9314
						layout.SwitchButton(LayoutQuestVerticalItem.eButtonType.Clear);
						yield return Co.R(PopupReceive(view.GOOIIPFHOIG));
					}
				}
			}
			//LAB_009e9054
			if (endCallback != null)
				endCallback();
		}

		//// RVA: 0x9D6458 Offset: 0x9D6458 VA: 0x9D6458
		public static void ReceiveAll(List<FKMOKDCJFEN> list, Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_ReceiveAll(list, endCallback));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710E2C Offset: 0x710E2C VA: 0x710E2C
		//// RVA: 0x9E7008 Offset: 0x9E7008 VA: 0x9E7008
		private static IEnumerator Co_ReceiveAll(List<FKMOKDCJFEN> list, Action endCallback)
		{
			List<FKMOKDCJFEN> viewList; // 0x20
			FKMOKDCJFEN view; // 0x24

			//0x9E94C4
			viewList = new List<FKMOKDCJFEN>();
			for(int i = 0; i < list.Count; i++)
			{
				if(list[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved)
				{
					viewList.Add(list[i]);
				}
			}
			if(viewList.Count > 0)
			{
				view = viewList[0];
				if(view.COAMJFMEIBF != null)
				{
					bool isClosed = false;
					yield return Co.R(view.COAMJFMEIBF.EPOOEDJCBDN_Co_CheckClosedEvent((bool result) =>
					{
						//0x9E7E5C
						isClosed = result;
					}));
					if(isClosed)
					{
						MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
						if (endCallback != null)
							endCallback();
						yield break;
					}
				}
				if(!MenuScene.CheckDatelineAndAssetUpdate())
				{
					List<int> idList = new List<int>();
					for(int i = 0; i < viewList.Count; i++)
					{
						idList.Add(viewList[i].CMEJFJFOIIJ_QuestId);
					}
					MenuScene.Instance.RaycastDisable();
					bool done = false;
					bool err = false;
					bool isLimit = false;
					FKMOKDCJFEN.JKBOOMAPOBL(view.JONPKLHMOBL, idList, view.JOPOPMLFINI, (List<int> _list, bool limit) =>
					{
						//0x9E7E30
						isLimit = limit;
						done = true;
						idList = _list;
					}, () =>
					{
						//0x9E7E44
						err = true;
						done = true;
					}, false);
					while (!done)
						yield return null;
					MenuScene.Instance.RaycastEnable();
					if(!err)
					{
						GameManager.Instance.ResetViewPlayerData();
						List<MFDJIFIIPJD> l3 = new List<MFDJIFIIPJD>();
						for(int i = 0; i < viewList.Count; i++)
						{
							view = viewList[i];
							if(idList.Contains(view.CMEJFJFOIIJ_QuestId))
							{
								l3.Add(view.GOOIIPFHOIG);
							}
						}
						l3.Sort((MFDJIFIIPJD a, MFDJIFIIPJD b) =>
						{
							//0x9E7B24
							return a.JJBGOIMEIPF_ItemId - b.JJBGOIMEIPF_ItemId;
						});
						yield return Co.R(PopupReceiveAll(l3, isLimit));
					}
				}
				//LAB_009e989c
			}
			if (endCallback != null)
				endCallback();
		}

		//// RVA: 0x9E70D0 Offset: 0x9E70D0 VA: 0x9E70D0
		private static int CheckItemPossessionLimit(BBHNACPENDM_ServerSaveData pd, OKGLGHCBCJP_Database md, int itemId, int addCount)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			if(cat > EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None && cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem && ((0x39U >> ((int)cat - 1)) & 1) != 0) // 00111001
			{
				return 0;
			}
			return addCount - EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(md, pd, cat, id, null) + EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(md, pd, cat, id, null);
		}

		//// RVA: 0x9E721C Offset: 0x9E721C VA: 0x9E721C
		public static void OpenURL(FKMOKDCJFEN view, Action onSuccess)
		{
			GameManager.Instance.StartCoroutineWatched(Co_OpenURL(view, onSuccess));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710EA4 Offset: 0x710EA4 VA: 0x710EA4
		//// RVA: 0x9E7300 Offset: 0x9E7300 VA: 0x9E7300
		private static IEnumerator Co_OpenURL(FKMOKDCJFEN view, Action onSuccess)
		{
			//0x9E88BC
			bool isWait = true;
			bool isSuccess = false;
			view.KKFFEJEKFEG(() =>
			{
				//0x9E7E6C
				isWait = false;
				isSuccess = true;
			}, () =>
			{
				//0x9E7E78
				isWait = false;
			});
			while(isWait)
				yield return null;
			if(isSuccess)
			{
				if(onSuccess != null)
					onSuccess();
			}
		}

		//// RVA: 0x9E6D18 Offset: 0x9E6D18 VA: 0x9E6D18
		private static void GoToFreeMusic(int freeMusicId)
		{
			MusicSelectArgs args = new MusicSelectArgs();
			if (freeMusicId < 1)
				args.SetSelection(FreeCategoryId.Type.Event);
			else
				args.SetSelection(freeMusicId);
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		//// RVA: 0x9E5E6C Offset: 0x9E5E6C VA: 0x9E5E6C
		private static void GotoCurrentEventScene(FKMOKDCJFEN view)
		{
			IKDICBBFBMI_EventBase ev = view.COAMJFMEIBF;
			if(ev.HIDHLFCBIDE_EventType >= OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp && ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign)
			{
				ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
			}
			TransitionUniqueId goScene = TransitionUniqueId.MUSICSELECT_RAID;
			if (ev.FBLGGLDPFDF_CanShowStartAdventure())
			{
				GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData dbAdv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
				if(dbAdv != null && dbAdv.KKPPFAHFOJI_FileId > 0)
				{
					int advId = dbAdv.KKPPFAHFOJI_FileId;
					AdvSetupParam param = new AdvSetupParam();
					param.eventUniqueId = ev.PGIIDPEGGPI_EventId;
					if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
					{
						if (ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
						{
							Database.Instance.advResult.Setup("Menu", goScene, param);
							goScene = TransitionUniqueId.EVENTMUSICSELECT;
						}
						else if (ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
						{
							Database.Instance.advResult.Setup("Menu", goScene, param);
							goScene = TransitionUniqueId.EVENTBATTLE;
						}
					}
					else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					{
						Database.Instance.advResult.Setup("Menu", goScene, param);
						goScene = TransitionUniqueId.EVENTGODIVA;
					}
					else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
					}
					else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
					{
						Database.Instance.advResult.Setup("Menu", goScene, param);
						goScene = TransitionUniqueId.EVENTQUEST;
					}
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
					Database.Instance.advSetup.Setup(advId);
					MenuScene.Instance.GotoAdventure(true);
					return;
				}
			}
			if(ev.HIDHLFCBIDE_EventType < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
			{
				if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					MenuScene.Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(ev.PGIIDPEGGPI_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					MenuScene.Instance.Mount(TransitionUniqueId.EVENTBATTLE, new EventMusicSelectSceneArgs(ev.PGIIDPEGGPI_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(ev.PGIIDPEGGPI_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
			}
			else if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
			{
				MenuScene.Instance.Mount(TransitionUniqueId.EVENTQUEST, new EventMusicSelectSceneArgs(ev.PGIIDPEGGPI_EventId, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710F1C Offset: 0x710F1C VA: 0x710F1C
		//// RVA: 0x9E73C8 Offset: 0x9E73C8 VA: 0x9E73C8
		public static IEnumerator PopupItemPossessionLimit(MFDJIFIIPJD info, Action<bool> callback)
		{
			//0x9EA060
			List<MFDJIFIIPJD> l = new List<MFDJIFIIPJD>();
			if(info.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem)
			{
				HHPEMHHCKBE_Compo.MLMDKHBFOJM dbCompo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ALFKMKICDPP_Compo.CDENCMNHNGA[info.NNFNGLJOKKF_ItemId - 1];
				for(int i = 0; i < dbCompo.JCJGGHGIKIJ(); i++)
				{
					if(CheckItemPossessionLimit(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, dbCompo.CBLLFCGEJAI(i), dbCompo.HBJMCLGKLBA(i) * info.MBJIFDBEDAC_Cnt) > 0)
					{
						MFDJIFIIPJD data = new MFDJIFIIPJD();
						data.KHEKNNFCAOI(dbCompo.CBLLFCGEJAI(i), dbCompo.HBJMCLGKLBA(i) * info.MBJIFDBEDAC_Cnt);
						l.Add(data);
					}
				}
			}
			else
			{
				if(CheckItemPossessionLimit(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, info.JJBGOIMEIPF_ItemId, info.MBJIFDBEDAC_Cnt) > 0)
				{
					MFDJIFIIPJD data = new MFDJIFIIPJD();
					data.KHEKNNFCAOI(info.JJBGOIMEIPF_ItemId, info.MBJIFDBEDAC_Cnt);
					l.Add(data);
				}
			}
			if (l.Count < 1)
				yield break;
			PopupQuestRewardListSetting s = new PopupQuestRewardListSetting();
			s.WindowSize = SizeType.Large;
			s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_quest_receive_limit_title");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.PopupType = PopupQuestRewardListSetting.Type.Confirm;
			s.ItemList = l;
			s.IsLimit = true;
			bool done = false;
			bool isOk = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x9E7E8C
				if (type == PopupButton.ButtonType.Positive)
					isOk = true;
				done = true;
			}, null, null, null);
			while (!done)
				yield return null;
			if (callback != null)
				callback(isOk);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x710F94 Offset: 0x710F94 VA: 0x710F94
		//// RVA: 0x9E2010 Offset: 0x9E2010 VA: 0x9E2010
		public static IEnumerator PopupReceive(MFDJIFIIPJD itemInfo)
		{
			//0x9EA99C
			if (itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume ||
				itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				//LAB_009eaa90
				yield return CallUnlockScene(itemInfo);
			}
			else
			{
				MenuScene.Instance.RaycastDisable();
				if(itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					bool popupWait = true;
					yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Quest, () =>
					{
						//0x9E7EC4
						popupWait = false;
					}, false));
					while (popupWait)
						yield return null;
				}
				else
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					PopupQuestRewardSetting s = new PopupQuestRewardSetting();
					s.ItemInfo = itemInfo;
					s.TitleText = bk.GetMessageByLabel("popup_quest_reward_title");
					s.WindowSize = SizeType.Small;
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					bool popupWait = true;
					PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x9E7CE4
						return;
					}, null, null, null, closeWaitCallBack: () =>
					{
						//0x9E7EAC
						popupWait = false;
						return true;
					});
					while (popupWait)
						yield return null;
				}
				//LAB_009eab38
				MenuScene.Instance.RaycastEnable();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71100C Offset: 0x71100C VA: 0x71100C
		//// RVA: 0x9E74B0 Offset: 0x9E74B0 VA: 0x9E74B0
		public static IEnumerator PopupReceiveAll(List<MFDJIFIIPJD> list, bool isLimit)
		{
			//0x9EB0E8
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupSetting s;
			if(list.Count < 1)
			{
				s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("popup_quest_receive_limit_title"), SizeType.Small, bk.GetMessageByLabel("popup_quest_receive_limit_failure_02"), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true);
			}
			else
			{
				s = new PopupQuestRewardListSetting()
				{
					WindowSize = SizeType.Large,
					TitleText = bk.GetMessageByLabel("popup_quest_reward_title"),
					Buttons = new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } },
					PopupType = PopupQuestRewardListSetting.Type.Receive,
					ItemList = list,
					IsLimit = isLimit
				};
			}
			bool done = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x9E7ED8
				done = true;
			}, null, null, null);
			while (!done)
				yield return null;
			MenuScene.Instance.RaycastDisable();
			MFDJIFIIPJD m = list.Find((MFDJIFIIPJD x) =>
			{
				//0x9E7CE8
				return x.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
			});
			if(m != null)
			{
				bool popupWait = true;
				yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Quest, () =>
				{
					//0x9E7EEC
					popupWait = false;
				}, false));
				while (popupWait)
					yield return null;
			}
			//LAB_009eb810
			MenuScene.Instance.RaycastEnable();
			m = list.Find((MFDJIFIIPJD x) =>
			{
				//0x9E7D18
				return x.NPPNDDMPFJJ_ItemCategory >= EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume && x.NPPNDDMPFJJ_ItemCategory <= EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie;
			});
			if(m != null)
			{
				yield return Co.R(CallUnlockScene(m));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x711084 Offset: 0x711084 VA: 0x711084
		//// RVA: 0x9E7578 Offset: 0x9E7578 VA: 0x9E7578
		private static IEnumerator CallUnlockScene(MFDJIFIIPJD itemInfo)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category type; // 0x14
			int id; // 0x18

			//0x9E7F8C
			type = itemInfo.NPPNDDMPFJJ_ItemCategory;
			id = itemInfo.NNFNGLJOKKF_ItemId;
			SetBackButton();
			MenuScene.Instance.InputDisable();
			UnlockFadeManager.Create();
			GameManager.Instance.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(GetLogoId(type, id)));
			while (!UnlockFadeManager.Instance.IsLoaded())
				yield return null;
			UnlockFadeManager.Instance.GetEffect().Enter();
			while (!UnlockFadeManager.Instance.GetEffect().IsEntered())
				yield return null;
			RemoveBackButton();
			MenuScene.Instance.InputEnable();
			if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Find((JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo _) =>
				{
					//0x9E7F00
					return itemId == _.GPPEFLKGGGJ_Id;
				});
				UnlockValkyrieArgs args = new UnlockValkyrieArgs();
				args.valkyrie_id = valk != null ? valk.GPPEFLKGGGJ_Id : 1;
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_VALKYRIE, args, true);
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1];
				UnlockCostumeArgs args = new UnlockCostumeArgs();
				args.diva_id = cos != null ? cos.AHHJLDLAPAN_PrismDivaId : 1;
				args.after_costume_data = new UnlockCostumeScene.CostumeData();
				args.after_costume_data.id = cos != null ? cos.DAJGPBLEEOB_PrismCostumeModelId : 1;
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_COSTUME, args, true);
			}
		}

		//// RVA: 0x9E7624 Offset: 0x9E7624 VA: 0x9E7624
		private static int GetLogoId(EKLNMHFCAOI.FKGCBLHOOCL_Category type, int id)
		{
			if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList.Find((JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo _) =>
				{
					//0x9E7F44
					return itemId == _.GPPEFLKGGGJ_Id;
				});
				if (valk != null)
					return valk.AIHCEGFANAM_Sa;
			}
			else if(type == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
			{
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[itemId - 1];
				int idx = 0;
				if(cos != null)
				{
					idx = cos.AHHJLDLAPAN_PrismDivaId - 1;
				}
				return GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[idx].AIHCEGFANAM_Serie;
			}
			return 1;
		}
	}
}
