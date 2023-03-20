
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{ 
	public class QuestUtility
	{
		public class EventQuestData
		{
			public string m_masterName; // 0x8
			public int m_uniqueId; // 0xC
			public OHCAABOMEOF.KGOGMKMBCPP_EventType m_eventType; // 0x10
			//public List<FKMOKDCJFEN> m_viewList; // 0x14
			public int m_achievedCount; // 0x18
		}

		public const int QUEST_ACHIEVED_COUNT_MAX = 99;
		public static List<FKMOKDCJFEN> m_dailyViewList; // 0x0
		public static List<FKMOKDCJFEN> m_beginnerViewList; // 0x4
		public static List<FKMOKDCJFEN> m_normalViewList; // 0x8
		public static List<FKMOKDCJFEN> m_snsViewList; // 0xC
		public static List<CGJKNOCAPII> m_eventViewList; // 0x10
		public static List<CGJKNOCAPII> m_bingoViewList; // 0x14
		//public static MFDJIFIIPJD m_selectedItemInfo; // 0x18
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
						/*data.m_masterName = l[i].JOPOPMLFINI;
						data.m_uniqueId = */
						TodoLogger.Log(0, "UpdateQuestData event");
						m_eventQuestDataList.Add(data);
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
					m_snsViewList = FKMOKDCJFEN.IHEMBPBBIEO(false);
					m_snsAchievedCount = GetQuestCountByStatus(m_snsViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Beginner:
					m_beginnerViewList = FKMOKDCJFEN.BAENBNLMPMO(false);
					m_beginnerAchievedCount = GetQuestCountByStatus(m_beginnerViewList, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
					break;
				case LayoutQuestTab.eTabType.Bingo:
					m_eventQuestDataList = new List<EventQuestData>();
					m_bingoViewList = CGJKNOCAPII.GOGBAODOOAO(false);
					for (int i = 0; i < m_bingoViewList.Count; i++)
					{
						EventQuestData data = new EventQuestData();
						data.m_masterName = m_bingoViewList[i].JOPOPMLFINI;
						data.m_uniqueId = m_bingoViewList[i].JHAOHBNPMNA;
						data.m_eventType = OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO;
						data.m_achievedCount = GNGMCIAIKMA.HHCJCDFCLOB.OBOGIOGEBPK(m_bingoViewList[i].PGIIDPEGGPI, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved);
						m_eventQuestDataList.Add(data);
						m_bingoViewList[i].PKNLMLDKCLM = data.m_achievedCount;
						if(data.m_achievedCount < 1)
						{
							m_bingoViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.None;
							m_bingoViewList[i].BHANMJKCCBC = "";
						}
						else
						{
							m_bingoViewList[i].BEEIIJJKDBH = Common.BadgeConstant.ID.Label;
							m_bingoViewList[i].BHANMJKCCBC = GetAchievedCountText(data.m_achievedCount);
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
		//public static bool FindAchievedQuestList(List<FKMOKDCJFEN> list) { }

		//// RVA: 0x9E2CD8 Offset: 0x9E2CD8 VA: 0x9E2CD8
		//public static List<FKMOKDCJFEN> GetEventQuestList(string masterName) { }

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
		//public static bool IsCrossDateline() { }

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
					return _.CMCKNKKCNDK_Status != FKMOKDCJFEN.ADCPCCNCOMD_Status.CADDNFIKDLG;
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
				return _.PKNLMLDKCLM > 0;
			}) != null;
		}

		//// RVA: 0x9DADA8 Offset: 0x9DADA8 VA: 0x9DADA8
		//public static bool IsEmphasis(LayoutQuestTab.eTabType type) { }

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
		//private static void BackButtonEmpty() { }

		//// RVA: 0x9E209C Offset: 0x9E209C VA: 0x9E209C
		//public static void SetBackButton() { }

		//// RVA: 0x9E2174 Offset: 0x9E2174 VA: 0x9E2174
		//public static void RemoveBackButton() { }

		//// RVA: 0x9E3DA8 Offset: 0x9E3DA8 VA: 0x9E3DA8
		//public static int GetCount(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9E408C Offset: 0x9E408C VA: 0x9E408C
		//public static int GetAchievedCount(List<CGJKNOCAPII> list) { }

		//// RVA: 0x9E4164 Offset: 0x9E4164 VA: 0x9E4164
		//public static int GetAchievedCount(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9E439C Offset: 0x9E439C VA: 0x9E439C
		//public static int GetAchievedCount() { }

		//// RVA: 0x9E2AA4 Offset: 0x9E2AA4 VA: 0x9E2AA4
		public static string GetAchievedCountText(int count)
		{
			TodoLogger.Log(0, "GetAchievedCountText");
			return "";
		}

		//// RVA: 0x9E449C Offset: 0x9E449C VA: 0x9E449C
		//public static string GetAchievedCountText(LayoutQuestTab.eTabType type) { }

		//// RVA: 0x9E4520 Offset: 0x9E4520 VA: 0x9E4520
		//public static string GetAchievedCountText() { }

		//// RVA: 0x9DD7F0 Offset: 0x9DD7F0 VA: 0x9DD7F0
		//public static void SetCallbackSns(Action callback) { }

		//// RVA: 0x9DDC64 Offset: 0x9DDC64 VA: 0x9DDC64
		//public static void SetCallbackSnsClear() { }

		//// RVA: 0x9E459C Offset: 0x9E459C VA: 0x9E459C
		//public static void ShowSNS() { }

		//// RVA: 0x9E4684 Offset: 0x9E4684 VA: 0x9E4684
		//public static void Challenge(FKMOKDCJFEN view) { }

		//// RVA: 0x9E6E3C Offset: 0x9E6E3C VA: 0x9E6E3C
		//public static void Receive(FKMOKDCJFEN view, LayoutQuestVerticalItem layout, Action endCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x710DB4 Offset: 0x710DB4 VA: 0x710DB4
		//// RVA: 0x9E6F28 Offset: 0x9E6F28 VA: 0x9E6F28
		//private static IEnumerator Co_Receive(FKMOKDCJFEN view, LayoutQuestVerticalItem layout, Action endCallback) { }

		//// RVA: 0x9D6458 Offset: 0x9D6458 VA: 0x9D6458
		//public static void ReceiveAll(List<FKMOKDCJFEN> list, Action endCallback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x710E2C Offset: 0x710E2C VA: 0x710E2C
		//// RVA: 0x9E7008 Offset: 0x9E7008 VA: 0x9E7008
		//private static IEnumerator Co_ReceiveAll(List<FKMOKDCJFEN> list, Action endCallback) { }

		//// RVA: 0x9E70D0 Offset: 0x9E70D0 VA: 0x9E70D0
		//private static int CheckItemPossessionLimit(BBHNACPENDM pd, OKGLGHCBCJP md, int itemId, int addCount) { }

		//// RVA: 0x9E721C Offset: 0x9E721C VA: 0x9E721C
		//public static void OpenURL(FKMOKDCJFEN view, Action onSuccess) { }

		//[IteratorStateMachineAttribute] // RVA: 0x710EA4 Offset: 0x710EA4 VA: 0x710EA4
		//// RVA: 0x9E7300 Offset: 0x9E7300 VA: 0x9E7300
		//private static IEnumerator Co_OpenURL(FKMOKDCJFEN view, Action onSuccess) { }

		//// RVA: 0x9E6D18 Offset: 0x9E6D18 VA: 0x9E6D18
		//private static void GoToFreeMusic(int freeMusicId) { }

		//// RVA: 0x9E5E6C Offset: 0x9E5E6C VA: 0x9E5E6C
		//private static void GotoCurrentEventScene(FKMOKDCJFEN view) { }

		//[IteratorStateMachineAttribute] // RVA: 0x710F1C Offset: 0x710F1C VA: 0x710F1C
		//// RVA: 0x9E73C8 Offset: 0x9E73C8 VA: 0x9E73C8
		//public static IEnumerator PopupItemPossessionLimit(MFDJIFIIPJD info, Action<bool> callback) { }

		//[IteratorStateMachineAttribute] // RVA: 0x710F94 Offset: 0x710F94 VA: 0x710F94
		//// RVA: 0x9E2010 Offset: 0x9E2010 VA: 0x9E2010
		//public static IEnumerator PopupReceive(MFDJIFIIPJD itemInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x71100C Offset: 0x71100C VA: 0x71100C
		//// RVA: 0x9E74B0 Offset: 0x9E74B0 VA: 0x9E74B0
		//public static IEnumerator PopupReceiveAll(List<MFDJIFIIPJD> list, bool isLimit) { }

		//[IteratorStateMachineAttribute] // RVA: 0x711084 Offset: 0x711084 VA: 0x711084
		//// RVA: 0x9E7578 Offset: 0x9E7578 VA: 0x9E7578
		//private static IEnumerator CallUnlockScene(MFDJIFIIPJD itemInfo) { }

		//// RVA: 0x9E7624 Offset: 0x9E7624 VA: 0x9E7624
		//private static int GetLogoId(EKLNMHFCAOI.FKGCBLHOOCL type, int id) { }
	}
}
