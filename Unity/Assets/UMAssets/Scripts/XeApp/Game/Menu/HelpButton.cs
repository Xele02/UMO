using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using mcrs;

namespace XeApp.Game.Menu
{
	public class HelpButton : LayoutUGUIScriptBase
	{
		private enum State
		{
			Hide = 0,
			Show = 1,
		}

		private struct HelpInfo
		{
			public byte pattern; // 0x0
			public int searchId; // 0x4
			public OHCAABOMEOF.KGOGMKMBCPP_EventType eveType; // 0x8
		}

		[SerializeField]
		private ActionButton m_button; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x66FD20 Offset: 0x66FD20 VA: 0x66FD20
		public UnityAction<int, int> HelpButtonListener; // 0x18
		private RectTransform m_rectTransform; // 0x1C
		private int m_searchId; // 0x20
		private int m_callHelpId; // 0x24
		private AbsoluteLayout m_buttonAnimLayout; // 0x28
		private bool m_isShow; // 0x2C
		private int m_blockCount; // 0x30
		private int m_pattern; // 0x34
		private State m_state; // 0x38
		private OHCAABOMEOF.KGOGMKMBCPP_EventType m_eventType; // 0x3C
		private VeiwOptionHelpCategoryData m_helpCategory = new VeiwOptionHelpCategoryData(); // 0x40
		private const int ResultButtonPattern = 3;
		private const int ResultSearchId = 106;
		private const int RaidResultSearchId = 128;
		private const int VerticalMusicSelectSearchId = 102;
		public const int LuckyLeafPopupHelpSearchId = 113;
		public const int MusicRateHelpSearchId = 119;
		private readonly HelpInfo MissionEventhelpPattern = new HelpInfo() { pattern = 5, searchId = 0, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL }; // 0x44
		private Dictionary<OHCAABOMEOF.KGOGMKMBCPP_EventType, int> m_eventHelpIdDict = new Dictionary<OHCAABOMEOF.KGOGMKMBCPP_EventType, int>(); // 0x50
		private Dictionary<int, HelpInfo> ButtonDispPlaceDict = new Dictionary<int, HelpInfo>()
		{
			{ 4, new HelpInfo() { pattern = 1, searchId = 101, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 5, new HelpInfo() { pattern = 4, searchId = 102, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 36, new HelpInfo() { pattern = 5, searchId = 1000, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 55, new HelpInfo() { pattern = 5, searchId = 3000, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 48, new HelpInfo() { pattern = 5, searchId = 2000, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 107, new HelpInfo() { pattern = 5, searchId = 14000, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 6, new HelpInfo() { pattern = 1, searchId = 103, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 12, new HelpInfo() { pattern = 1, searchId = 117, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 7, new HelpInfo() { pattern = 1, searchId = 104, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 31, new HelpInfo() { pattern = 2, searchId = 105, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 28, new HelpInfo() { pattern = 2, searchId = 107, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 30, new HelpInfo() { pattern = 1, searchId = 108, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 37, new HelpInfo() { pattern = 2, searchId = 109, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 39, new HelpInfo() { pattern = 1, searchId = 109, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 38, new HelpInfo() { pattern = 1, searchId = 109, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 56, new HelpInfo() { pattern = 2, searchId = 110, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 61, new HelpInfo() { pattern = 6, searchId = 8001, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 64, new HelpInfo() { pattern = 7, searchId = 8000, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 71, new HelpInfo() { pattern = 2, searchId = 112, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 72, new HelpInfo() { pattern = 2, searchId = 112, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 73, new HelpInfo() { pattern = 2, searchId = 111, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 74, new HelpInfo() { pattern = 1, searchId = 111, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 76, new HelpInfo() { pattern = 2, searchId = 111, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 75, new HelpInfo() { pattern = 1, searchId = 111, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 78, new HelpInfo() { pattern = 1, searchId = 114, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 79, new HelpInfo() { pattern = 2, searchId = 118, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 60, new HelpInfo() { pattern = 8, searchId = 115, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 86, new HelpInfo() { pattern = 10, searchId = 122, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 90, new HelpInfo() { pattern = 12, searchId = 122, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 87, new HelpInfo() { pattern = 9, searchId = 123, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 96, new HelpInfo() { pattern = 2, searchId = 123, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 94, new HelpInfo() { pattern = 1, searchId = 123, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 80, new HelpInfo() { pattern = 11, searchId = 121, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 98, new HelpInfo() { pattern = 2, searchId = 124, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 88, new HelpInfo() { pattern = 2, searchId = 120, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 100, new HelpInfo() { pattern = 10, searchId = 127, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } },
			{ 108, new HelpInfo() { pattern = 1, searchId = 104, eveType = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL } }
		}; // 0x54
		private Vector2[] AnchorPosTbl = new Vector2[14]
			{
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(1, 1),
				new Vector2(0, 1),
				new Vector2(0.5f, 0.5f),
				new Vector2(0.5f, 0.5f),
				new Vector2(0.5f, 0.5f),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(1, 1)
			}; // 0x58
		private Vector2[] PivotTbl = new Vector2[14]
			{
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1),
				new Vector2(0, 1)
			}; // 0x5C

		// [CompilerGeneratedAttribute] // RVA: 0x6E1A6C Offset: 0x6E1A6C VA: 0x6E1A6C
		// // RVA: 0xE301F8 Offset: 0xE301F8 VA: 0xE301F8
		// public void add_HelpButtonListener(UnityAction<int, int> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6E1A7C Offset: 0x6E1A7C VA: 0x6E1A7C
		// // RVA: 0xE30304 Offset: 0xE30304 VA: 0xE30304
		// public void remove_HelpButtonListener(UnityAction<int, int> value) { }

		// RVA: 0xE30410 Offset: 0xE30410 VA: 0xE30410 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_buttonAnimLayout = layout.FindViewByExId("sw_help_question_position_sw_question_btn_in_anim") as AbsoluteLayout;
			m_button.AddOnClickCallback(OnPushHelpButton);
			m_rectTransform = GetComponent<RectTransform>();
			return true;	
		}

		// // RVA: 0xE30560 Offset: 0xE30560 VA: 0xE30560
		public void TryShow(TransitionList.Type transitionName)
		{
			HelpInfo info;
			if (ButtonDispPlaceDict.TryGetValue((int)transitionName, out info))
			{
				int id = FindHelpUniqueId(info.searchId);
				if(id < 0)
				{
					int v;
					if(m_eventHelpIdDict.TryGetValue(info.eveType, out v))
					{
						m_searchId = info.searchId;
						m_callHelpId = v;
					}
					else
					{
						Hide();
					}
				}
				else
				{
					m_searchId = info.searchId;
					m_callHelpId = id;
				}
				m_eventType = info.eveType;
				m_pattern = info.pattern;
				Show(m_pattern);
			}
			else
			{
				Hide();
			}
		}

		// // RVA: 0xE306A4 Offset: 0xE306A4 VA: 0xE306A4
		public static int FindHelpUniqueId(int searchId)
		{
			DPGPEALHJOB[] hp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LOJAMHAADBF_HelpBrowser.LOMHJBIJMOD;
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < hp.Length; i++)
			{
				if (hp[i].DIJHLDAIBCA_SearchId == searchId)
				{
					TodoLogger.Log(TodoLogger.ToCheck, "int64");
					if(hp[i].PDBPFJJCADD <= time)
					{
						if(hp[i].FDBNFFNFOND >= time)
						{
							return hp[i].OBGBAOLONDD_UniqueId;
						}
					}
				}
			}
			return -1;
		}

		// // RVA: 0xE30C24 Offset: 0xE30C24 VA: 0xE30C24
		// public void ShowMusicSelectHelpButton() { }

		// // RVA: 0xE30C6C Offset: 0xE30C6C VA: 0xE30C6C
		public void ShowResultHelpButton()
		{
			TodoLogger.Log(0, "ShowResultHelpButton HelpButton");
		}

		// // RVA: 0xE30CB4 Offset: 0xE30CB4 VA: 0xE30CB4
		public void ShowRaidResultHelpButton()
		{
			TodoLogger.Log(0, "ShowRaidResultHelpButton HelpButton");
		}

		// // RVA: 0xE30CFC Offset: 0xE30CFC VA: 0xE30CFC
		public void HideResultHelpButton()
		{
			TodoLogger.Log(0, "HideResultHelpButton HelpButton");
		}

		// // RVA: 0xE30D00 Offset: 0xE30D00 VA: 0xE30D00
		// public void ShowMissiontEventHelpButton() { }

		// // RVA: 0xE30DC4 Offset: 0xE30DC4 VA: 0xE30DC4
		// public void HideMissionEventHelpButton() { }

		// // RVA: 0xE30DC8 Offset: 0xE30DC8 VA: 0xE30DC8
		// public void HideEventHelpButton() { }

		// // RVA: 0xE30DCC Offset: 0xE30DCC VA: 0xE30DCC
		// public void HideOfferHelpButton() { }

		// // RVA: 0xE30DD0 Offset: 0xE30DD0 VA: 0xE30DD0
		// public void HideDecoStorageHelpButton() { }

		// // RVA: 0xE30DD4 Offset: 0xE30DD4 VA: 0xE30DD4
		public void TryHide(TransitionList.Type transitionName)
		{
			TodoLogger.Log(0, "Help TryHide");
		}

		// // RVA: 0xE30964 Offset: 0xE30964 VA: 0xE30964
		private void Show(int pattern)
		{
			TodoLogger.Log(0, "HelpButton.Show");
		}

		// // RVA: 0xE30B7C Offset: 0xE30B7C VA: 0xE30B7C
		private void Hide()
		{
			if(m_isShow)
			{
				m_buttonAnimLayout.StartChildrenAnimGoStop("go_out", "st_out");
				m_isShow = false;
			}
			m_state = State.Hide;
		}

		// // RVA: 0xE30EB0 Offset: 0xE30EB0 VA: 0xE30EB0
		public void TryEnter()
		{
			TodoLogger.Log(0, "TryEnter");
		}

		// // RVA: 0xE30F5C Offset: 0xE30F5C VA: 0xE30F5C
		public void TryLeave()
		{
			TodoLogger.Log(0, "TryLeave");
		}

		// // RVA: 0xE31008 Offset: 0xE31008 VA: 0xE31008
		public void SetEnable()
		{
			m_blockCount--;
			if(m_blockCount > 0)
				return;
			m_button.IsInputOff = false;
			m_blockCount = 0;
		}

		// // RVA: 0xE31058 Offset: 0xE31058 VA: 0xE31058
		public void SetDisable()
		{
			m_button.IsInputOff = true;
			m_blockCount++;
		}

		// // RVA: 0xE31098 Offset: 0xE31098 VA: 0xE31098
		private void OnPushHelpButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (HelpButtonListener != null)
				HelpButtonListener(m_callHelpId, 0);
		}

		// // RVA: 0xE31158 Offset: 0xE31158 VA: 0xE31158
		// public void AddEventHelpId(OHCAABOMEOF.KGOGMKMBCPP type, int helpId) { }
	}
}
