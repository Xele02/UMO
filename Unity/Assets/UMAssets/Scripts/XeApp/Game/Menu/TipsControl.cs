using XeSys;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class TipsControl : SingletonMonoBehaviour<TipsControl>
	{
		public enum SituationId
		{
			None = 0,
			GameOver = 1,
			Boot1stInformation = 2,
			BattleEventFailed_01 = 3,
			BattleEventFailed_02 = 4,
			BattleEventFailed_03 = 5,
			BattleEventFailed_04 = 6,
			Num = 7,
		}

		private struct ListupInfo
		{
			public enum Flags
			{
				HasPict = 1,
			}
			public int tipsId; // 0x0
			public int weight; // 0x4
			public uint flags; // 0x8

			// // RVA: 0x7FA894 Offset: 0x7FA894 VA: 0x7FA894
			// public bool IsPict() { }
		}

		private TipsMusicInfo m_musicInfo; // 0xC
		private TipsWindow m_window; // 0x10
		private bool m_isShow; // 0x14
		private bool m_isLoding; // 0x15
		private List<int> m_firstPageTipsIdList = new List<int>(); // 0x18
		private List<int> m_graphicTipsIdList = new List<int>(); // 0x1C
		private List<int> m_otherPageTipsIdList = new List<int>(); // 0x20
		private List<int> m_notPriorityTipsIdList = new List<int>(); // 0x24
		private List<TipsControl.ListupInfo> m_listUpList = new List<TipsControl.ListupInfo>(); // 0x28
		private List<int> m_historyList = new List<int>(); // 0x2C
		// private List<TipsData> m_tipsList = new List<TipsData>(); // 0x30
		private TipsTextureCache m_tipsTextureCache = new TipsTextureCache(); // 0x34
		private WaitWhile m_waitLoading; // 0x38
		private int m_totalWeight; // 0x3C
		public const int TipsMax = 3;
		private const int HistoryMax = 10;
		private static int[] m_situationValues = new int[7]; // 0x0

		public bool IsInitialized { get; private set; } // 0x40
		public WaitWhile WaitLoadingYield { get { return m_waitLoading; } } //0xA974F4
		// public bool IsLoading { get; } 0xA974FC

		// // RVA: 0xA97284 Offset: 0xA97284 VA: 0xA97284
		public static void SetSituationValue(TipsControl.SituationId id, int val)
		{
			TodoLogger.Log(5, "SetSituationValue");
		}

		// // RVA: 0xA9734C Offset: 0xA9734C VA: 0xA9734C
		// public static int GetSituationValue(TipsControl.SituationId id) { }

		// // RVA: 0xA97410 Offset: 0xA97410 VA: 0xA97410
		// public static void ResetSituationValues() { }

		// // RVA: 0xA97504 Offset: 0xA97504 VA: 0xA97504
		private void Start()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xA97708 Offset: 0xA97708 VA: 0xA97708
		private void OnDestroy()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xA978D0 Offset: 0xA978D0 VA: 0xA978D0
		private void Update()
		{
			TodoLogger.Log(5, "Tips update");
		}

		// // RVA: 0xA978FC Offset: 0xA978FC VA: 0xA978FC
		public new void Release()
		{
			if (!IsInitialized)
				return;
			m_tipsTextureCache.Terminated();
			Destroy(m_window.gameObject);
			Destroy(m_musicInfo.gameObject);
			m_musicInfo = null;
			m_window = null;
			IsInitialized = false;
			m_historyList.Clear();
		}

		// // RVA: 0xA97A3C Offset: 0xA97A3C VA: 0xA97A3C
		// public void LoadResource() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73559C Offset: 0x73559C VA: 0x73559C
		// // RVA: 0xA97A60 Offset: 0xA97A60 VA: 0xA97A60
		// private IEnumerator LoadResourceCoroutine() { }

		// // RVA: 0xA97B0C Offset: 0xA97B0C VA: 0xA97B0C
		// private int SearchPriorityTableIndex(int playerLevel) { }

		// // RVA: 0xA97D2C Offset: 0xA97D2C VA: 0xA97D2C
		// private void InitializeTipsList() { }

		// // RVA: 0xA98660 Offset: 0xA98660 VA: 0xA98660
		public void Show(int count = 3)
		{
			TodoLogger.Log(0, "TipsControl Show");
		}

		// // RVA: 0xA99004 Offset: 0xA99004 VA: 0xA99004
		public void Show(IBJAKJJICBC musicData)
		{
			TodoLogger.Log(0, "TipsControl Show");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x735614 Offset: 0x735614 VA: 0x735614
		// // RVA: 0xA98F78 Offset: 0xA98F78 VA: 0xA98F78
		// private IEnumerator ShowCoroutine(IBJAKJJICBC musicData) { }

		// // RVA: 0xA9906C Offset: 0xA9906C VA: 0xA9906C
		// private void LoadTexture(int index, TipsData data) { }

		// // RVA: 0xA99520 Offset: 0xA99520 VA: 0xA99520
		public void Close()
		{
			TodoLogger.Log(0, "Tips Close");
		}

		// // RVA: 0xA99794 Offset: 0xA99794 VA: 0xA99794
		public bool isPlayingAnime()
		{
			TodoLogger.Log(0, "Tips isPlayinganime");
			return false;
		}

		// // RVA: 0xA9874C Offset: 0xA9874C VA: 0xA9874C
		// private void MakeTipsList(int listUpCount) { }

		// // RVA: 0xA99A14 Offset: 0xA99A14 VA: 0xA99A14
		// private void MakePriorityTmpList(List<int> tmpList, List<int> idList) { }

		// // RVA: 0xA984D8 Offset: 0xA984D8 VA: 0xA984D8
		// private bool IsSessionEvent(int eventTypeId) { }

		// // RVA: 0xA99D0C Offset: 0xA99D0C VA: 0xA99D0C
		// private bool IsRegisteredTips(int tipsId) { }

		// // RVA: 0xA98748 Offset: 0xA98748 VA: 0xA98748
		// private void DatelineUpdate() { }

		// // RVA: 0xA99DF0 Offset: 0xA99DF0 VA: 0xA99DF0
		// private bool IsDatelineUpdate() { }

		// // RVA: 0xA98584 Offset: 0xA98584 VA: 0xA98584
		// private long GetServerUnixTime() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73568C Offset: 0x73568C VA: 0x73568C
		// // RVA: 0xA9A030 Offset: 0xA9A030 VA: 0xA9A030
		// private bool <Start>b__30_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73569C Offset: 0x73569C VA: 0x73569C
		// // RVA: 0xA9A038 Offset: 0xA9A038 VA: 0xA9A038
		// private void <LoadResourceCoroutine>b__35_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7356AC Offset: 0x7356AC VA: 0x7356AC
		// // RVA: 0xA9A0B4 Offset: 0xA9A0B4 VA: 0xA9A0B4
		// private void <LoadResourceCoroutine>b__35_1(GameObject instance) { }
	}
}
