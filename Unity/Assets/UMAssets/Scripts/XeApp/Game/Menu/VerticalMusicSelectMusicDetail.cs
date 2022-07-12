using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicDetail : MonoBehaviour
	{
		[SerializeField]
		private Color m_invalidDigitColor = Color.gray; // 0xC
		private string m_invalidDigitColorHtml; // 0x1C
		// private int m_validScoreDigit = 8; // 0x20
		// private int m_validUtaRateDigit = 4; // 0x24
		// private StringBuilder m_invalidDigitSb = new StringBuilder(); // 0x28
		private string m_eventRemainTimeFormat; // 0x2C
		private string m_eventRemainCountFormat; // 0x30
		// private int m_coverId; // 0x34
		// private bool m_isEventCover; // 0x38
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x674A84 Offset: 0x674A84 VA: 0x674A84
		private RawImage m_imageJacket; // 0x3C
		[SerializeField]
		private UGUIButton m_jacketSelectButton; // 0x40
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x674AE4 Offset: 0x674AE4 VA: 0x674AE4
		private TextMeshProUGUI m_highScore; // 0x44
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x674B34 Offset: 0x674B34 VA: 0x674B34
		private GameObject m_scoreObj; // 0x48
		[SerializeField]
		private Image m_scoreRnak; // 0x4C
		[SerializeField]
		private Sprite[] m_changeScoreRank; // 0x50
		// [HeaderAttribute] // RVA: 0x674BA8 Offset: 0x674BA8 VA: 0x674BA8
		[SerializeField]
		private GameObject m_musicUtaRateObj; // 0x54
		[SerializeField]
		private TextMeshProUGUI m_musicUtaRate; // 0x58
		// [HeaderAttribute] // RVA: 0x674C08 Offset: 0x674C08 VA: 0x674C08
		[SerializeField]
		private GameObject m_musicTimeObj; // 0x5C
		[SerializeField]
		private TextMeshProUGUI m_musicTime; // 0x60
		// [HeaderAttribute] // RVA: 0x674C68 Offset: 0x674C68 VA: 0x674C68
		[SerializeField]
		private CanvasGroup m_bookMarkObj; // 0x64
		[SerializeField]
		private GameObject m_bookMarkSaveObj; // 0x68
		[SerializeField]
		private GameObject m_bookMarkNotSaveObj; // 0x6C
		[SerializeField]
		private UGUIButton m_bookMarakButton; // 0x70
		// [HeaderAttribute] // RVA: 0x674CF4 Offset: 0x674CF4 VA: 0x674CF4
		[SerializeField]
		private CanvasGroup m_unitToggleButtonGroupObj; // 0x74
		[SerializeField]
		private UGUIToggleButtonGroup m_unitToggleButtonGroup; // 0x78
		[SerializeField]
		private UGUIToggleButton[] m_unitToggleButton; // 0x7C
		// [HeaderAttribute] // RVA: 0x674D5C Offset: 0x674D5C VA: 0x674D5C
		[SerializeField]
		private InOutAnime m_inOut; // 0x80
		// [HeaderAttribute] // RVA: 0x674DA4 Offset: 0x674DA4 VA: 0x674DA4
		[SerializeField]
		private Image m_backImage; // 0x84
		[SerializeField]
		private Sprite[] m_changeBackImage; // 0x88
		// [HeaderAttribute] // RVA: 0x674E0C Offset: 0x674E0C VA: 0x674E0C
		[SerializeField]
		private CanvasGroup m_lockObj; // 0x8C
		[SerializeField]
		private Image m_lockIcon; // 0x90
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x674E6C Offset: 0x674E6C VA: 0x674E6C
		private CanvasGroup m_weeklyObj; // 0x94
		[SerializeField]
		private RawImageEx[] m_weeklyItemImage = new RawImageEx[3]; // 0x98
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainTime; // 0x9C
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainCount; // 0xA0
		[SerializeField]
		private UGUIButton m_weeklyDescButton; // 0xA4
		// [HeaderAttribute] // RVA: 0x674F00 Offset: 0x674F00 VA: 0x674F00
		[SerializeField]
		private CanvasGroup m_highLevelFrmObj; // 0xA8
		[SerializeField]
		private CanvasGroup m_highLevelRemainTimeObj; // 0xAC
		[SerializeField]
		private Text m_highLevelRemainTime; // 0xB0
		[SerializeField]
		private CanvasGroup m_highLevelClearStateObj; // 0xB4
		[SerializeField]
		private Image m_highLevelClearStateImage; // 0xB8
		[SerializeField]
		private Sprite[] m_highLevelClearStateSprites = new Sprite[3]; // 0xBC
		// [HeaderAttribute] // RVA: 0x674F98 Offset: 0x674F98 VA: 0x674F98
		[SerializeField]
		private GameObject m_ScoreRankingObj; // 0xC0
		[SerializeField]
		private TextMeshProUGUI m_ScoreRankingNum; // 0xC4
		[SerializeField]
		private UGUIButton m_ScoreRankingDescButton; // 0xC8
		[SerializeField]
		private UGUIButton m_ScoreRankingEventRewardButton; // 0xCC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675030 Offset: 0x675030 VA: 0x675030
		private CanvasGroup m_eventObj; // 0xD0
		[SerializeField]
		private CanvasGroup m_eventCountingObj; // 0xD4
		[SerializeField]
		private TextMeshProUGUI m_eventRemainTime; // 0xD8
		private int m_isOnUnitIndex; // 0xDC
		// private List<int> m_itemIdList = new List<int>(3); // 0xE0

		public Action OnMusicBookMarkButtonClickListener { private get; set; } // 0xE4
		public Action<int> OnUnitButtonClickListener { private get; set; } // 0xE8
		public Action OnJacketButtonClickListener { private get; set; } // 0xEC
		public Action OnEventDetailClickListener { private get; set; } // 0xF0
		public Action OnEventRewardClickListener { private get; set; } // 0xF4
		// private MusicJacketTextureCache jacketTexCache { get; } 0xBDE614

		// // RVA: 0xBDE6B0 Offset: 0xBDE6B0 VA: 0xBDE6B0
		private void Awake()
		{
			m_eventRemainTimeFormat = MessageManager.Instance.GetBank("menu").GetMessageByLabel("vertical_music_select_event_remain_time");
			m_eventRemainCountFormat = MessageManager.Instance.GetBank("menu").GetMessageByLabel("vertical_music_select_event_remain_count");
			m_invalidDigitColorHtml = "#"+ColorUtility.ToHtmlStringRGBA(m_invalidDigitColor);
			m_jacketSelectButton.ClearOnClickCallback();
			m_jacketSelectButton.AddOnClickCallback(() => {
				//0xBE0A1C
				if(OnJacketButtonClickListener != null)
					OnJacketButtonClickListener();
			});
			m_bookMarakButton.ClearOnClickCallback();
			m_bookMarakButton.AddOnClickCallback(() => {
				//0xBE0A30
				if(OnMusicBookMarkButtonClickListener != null)
					OnMusicBookMarkButtonClickListener();
			});
			m_weeklyDescButton.ClearOnClickCallback();
			m_weeklyDescButton.AddOnClickCallback(() => {
				//0xBE0A44
				if(OnEventDetailClickListener != null)
					OnEventDetailClickListener();
			});
			m_ScoreRankingDescButton.ClearOnClickCallback();
			m_ScoreRankingDescButton.AddOnClickCallback(() => {
				//0xBE0A58
				if(OnEventDetailClickListener != null)
					OnEventDetailClickListener();
			});
			m_ScoreRankingEventRewardButton.ClearOnClickCallback();
			m_ScoreRankingEventRewardButton.AddOnClickCallback(() => {
				//0xBE0A6C
				if(OnEventRewardClickListener != null)
					OnEventRewardClickListener();
			});
			m_unitToggleButtonGroup.OnSelectToggleButtonEvent.AddListener((int index) => {
				//0xBE0A80
				for(int i = 0; i < m_unitToggleButton.Length; i++)
				{
					if(!m_unitToggleButton[i].Hidden && m_isOnUnitIndex != i)
					{
						if(OnUnitButtonClickListener != null)
						{
							OnUnitButtonClickListener(i);
						}
					}
				}
			});
		}

		// // RVA: 0xBDEB04 Offset: 0xBDEB04 VA: 0xBDEB04
		// public void SetHighLevelClearStatus(bool isClear, RhythmGameConsts.ResultComboType comboRank) { }

		// // RVA: 0xBDEC30 Offset: 0xBDEC30 VA: 0xBDEC30
		// public void SetEventInfo(bool isVisible, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType, bool showRemainTime) { }

		// // RVA: 0xBDF004 Offset: 0xBDF004 VA: 0xBDF004
		// public void SetMusicInfoStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style) { }

		// // RVA: 0xBDF348 Offset: 0xBDF348 VA: 0xBDF348
		// public void SetImageJacket(int jacketId) { }

		// // RVA: 0xBDF494 Offset: 0xBDF494 VA: 0xBDF494
		// public void SetImageJacketIsEvent(int jacketId) { }

		// // RVA: 0xBDF5E0 Offset: 0xBDF5E0 VA: 0xBDF5E0
		// public void EventCountingEnable(bool isEnabel) { }

		// // RVA: 0xBDF62C Offset: 0xBDF62C VA: 0xBDF62C
		// public void SetHighScore(int highScore, bool isVisible) { }

		// // RVA: 0xBDF834 Offset: 0xBDF834 VA: 0xBDF834
		// public void SetScoreRank(ResultScoreRank.Type scoreRank) { }

		// // RVA: 0xBDF8E0 Offset: 0xBDF8E0 VA: 0xBDF8E0
		// public void SetAttr(int attr, bool isVisible) { }

		// // RVA: 0xBDF9F8 Offset: 0xBDF9F8 VA: 0xBDF9F8
		// public void SetMusicUtaRate(int utaRate, bool isVisible) { }

		// // RVA: 0xBDFAA4 Offset: 0xBDFAA4 VA: 0xBDFAA4
		// public void SetMusicTime(string time, bool isVisible) { }

		// // RVA: 0xBDFB30 Offset: 0xBDFB30 VA: 0xBDFB30
		// public void SetSaveBookMark(bool isEnable, bool isBookMark) { }

		// // RVA: 0xBDFBE8 Offset: 0xBDFBE8 VA: 0xBDFBE8
		// private int GetDigit(int num) { }

		// // RVA: 0xBDF678 Offset: 0xBDF678 VA: 0xBDF678
		// private string AppendInvalidDigitString(int num, int validDigit, bool isAllInvalid) { }

		// // RVA: 0xBDFC90 Offset: 0xBDFC90 VA: 0xBDFC90
		// public void SetEventTime(string time, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType) { }

		// // RVA: 0xBDFD40 Offset: 0xBDFD40 VA: 0xBDFD40
		// public void SetWeeklyEventCount(int count) { }

		// // RVA: 0xBDFDF0 Offset: 0xBDFDF0 VA: 0xBDFDF0
		// public void SetWeeklyItem(IBJAKJJICBC musicData) { }

		// // RVA: 0xBDFFFC Offset: 0xBDFFFC VA: 0xBDFFFC
		// public void SetScoreRankingNum(int num) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5AFC Offset: 0x6F5AFC VA: 0x6F5AFC
		// // RVA: 0xBDFF54 Offset: 0xBDFF54 VA: 0xBDFF54
		// private IEnumerator Co_LoadItemImages(List<int> itemIdList) { }

		// // RVA: 0xBE00E8 Offset: 0xBE00E8 VA: 0xBE00E8
		public void SetUnitButton(int index)
		{
			m_unitToggleButtonGroup.SelectGroupButton(index);
			m_isOnUnitIndex = index;
		}

		// // RVA: 0xBE0124 Offset: 0xBE0124 VA: 0xBE0124
		public void ShowUnitDanceButton(IBJAKJJICBC musicData, MMOLNAHHDOM saveUnitData, bool isMusicLock)
		{
			for (int i = 0; i < 4; i++)
			{
				int[] array = new int[4] { 1, 2, 3, 5 };

				m_unitToggleButton[i].Hidden = musicData.BENDFLDLIAG_IsAvaiableForNumDiva(array[i]) != true;
			}
			m_unitToggleButtonGroupObj.blocksRaycasts = true;
			if (!musicData.DBIGDCOHOIC())
			{
				UnityEngine.Debug.LogError("TODO ShowUnitDanceButton for locked");
			}
			else if (isMusicLock)
			{
				UnityEngine.Debug.LogError("TODO ShowUnitDanceButton for isMusicLock");
			}
			else
			{
				UnityEngine.Debug.LogError("TODO ShowUnitDanceButton for other lock check");
			}
		}

		// // RVA: 0xBE0680 Offset: 0xBE0680 VA: 0xBE0680
		// private int GetDivaDanceNum(VerticalMusicSelectMusicDetail.Number num) { }

		// // RVA: 0xBE069C Offset: 0xBE069C VA: 0xBE069C
		public int GetDanceNum()
		{
			for(int i = 0; i < m_unitToggleButton.Length; i++)
			{
				if(m_unitToggleButton[i].IsOn && !m_unitToggleButton[i].Hidden)
				{
					if (i > 3)
						return 0;
					return new int[4]{ 1, 2, 3, 5 }[i];
				}
			}
			return 1;
		}

		// // RVA: 0xBE07B4 Offset: 0xBE07B4 VA: 0xBE07B4
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBE07E4 Offset: 0xBE07E4 VA: 0xBE07E4
		// public void Leave() { }

		// // RVA: 0xBE0848 Offset: 0xBE0848 VA: 0xBE0848
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBE0874 Offset: 0xBE0874 VA: 0xBE0874
		// public void SetEnable(bool isEneble) { }
	}
}
