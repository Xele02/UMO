using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicDetail : MonoBehaviour
	{
		[SerializeField]
		private Color m_invalidDigitColor;
		[SerializeField]
		private RawImage m_imageJacket;
		[SerializeField]
		private UGUIButton m_jacketSelectButton;
		[SerializeField]
		private TextMeshProUGUI m_highScore;
		[SerializeField]
		private GameObject m_scoreObj;
		[SerializeField]
		private Image m_scoreRnak;
		[SerializeField]
		private Sprite[] m_changeScoreRank;
		[SerializeField]
		private GameObject m_musicUtaRateObj;
		[SerializeField]
		private TextMeshProUGUI m_musicUtaRate;
		[SerializeField]
		private GameObject m_musicTimeObj;
		[SerializeField]
		private TextMeshProUGUI m_musicTime;
		[SerializeField]
		private CanvasGroup m_bookMarkObj;
		[SerializeField]
		private GameObject m_bookMarkSaveObj;
		[SerializeField]
		private GameObject m_bookMarkNotSaveObj;
		[SerializeField]
		private UGUIButton m_bookMarakButton;
		[SerializeField]
		private CanvasGroup m_unitToggleButtonGroupObj;
		[SerializeField]
		private UGUIToggleButtonGroup m_unitToggleButtonGroup;
		[SerializeField]
		private UGUIToggleButton[] m_unitToggleButton;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private Image m_backImage;
		[SerializeField]
		private Sprite[] m_changeBackImage;
		[SerializeField]
		private CanvasGroup m_lockObj;
		[SerializeField]
		private Image m_lockIcon;
		[SerializeField]
		private CanvasGroup m_weeklyObj;
		[SerializeField]
		private RawImageEx[] m_weeklyItemImage;
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainTime;
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainCount;
		[SerializeField]
		private UGUIButton m_weeklyDescButton;
		[SerializeField]
		private CanvasGroup m_highLevelFrmObj;
		[SerializeField]
		private CanvasGroup m_highLevelRemainTimeObj;
		[SerializeField]
		private Text m_highLevelRemainTime;
		[SerializeField]
		private CanvasGroup m_highLevelClearStateObj;
		[SerializeField]
		private Image m_highLevelClearStateImage;
		[SerializeField]
		private Sprite[] m_highLevelClearStateSprites;
		[SerializeField]
		private GameObject m_ScoreRankingObj;
		[SerializeField]
		private TextMeshProUGUI m_ScoreRankingNum;
		[SerializeField]
		private UGUIButton m_ScoreRankingDescButton;
		[SerializeField]
		private UGUIButton m_ScoreRankingEventRewardButton;
		[SerializeField]
		private CanvasGroup m_eventObj;
		[SerializeField]
		private CanvasGroup m_eventCountingObj;
		[SerializeField]
		private TextMeshProUGUI m_eventRemainTime;

		// // Fields
		// [SerializeField] // RVA: 0x674A74 Offset: 0x674A74 VA: 0x674A74
		// private Color m_invalidDigitColor; // 0xC
		// private string m_invalidDigitColorHtml; // 0x1C
		// private int m_validScoreDigit; // 0x20
		// private int m_validUtaRateDigit; // 0x24
		// private StringBuilder m_invalidDigitSb; // 0x28
		// private string m_eventRemainTimeFormat; // 0x2C
		// private string m_eventRemainCountFormat; // 0x30
		// private int m_coverId; // 0x34
		// private bool m_isEventCover; // 0x38
		// [SerializeField] // RVA: 0x674A84 Offset: 0x674A84 VA: 0x674A84
		// [HeaderAttribute] // RVA: 0x674A84 Offset: 0x674A84 VA: 0x674A84
		// private RawImage m_imageJacket; // 0x3C
		// [SerializeField] // RVA: 0x674AD4 Offset: 0x674AD4 VA: 0x674AD4
		// private UGUIButton m_jacketSelectButton; // 0x40
		// [SerializeField] // RVA: 0x674AE4 Offset: 0x674AE4 VA: 0x674AE4
		// [HeaderAttribute] // RVA: 0x674AE4 Offset: 0x674AE4 VA: 0x674AE4
		// private TextMeshProUGUI m_highScore; // 0x44
		// [SerializeField] // RVA: 0x674B34 Offset: 0x674B34 VA: 0x674B34
		// [HeaderAttribute] // RVA: 0x674B34 Offset: 0x674B34 VA: 0x674B34
		// private GameObject m_scoreObj; // 0x48
		// [SerializeField] // RVA: 0x674B88 Offset: 0x674B88 VA: 0x674B88
		// private Image m_scoreRnak; // 0x4C
		// [SerializeField] // RVA: 0x674B98 Offset: 0x674B98 VA: 0x674B98
		// private Sprite[] m_changeScoreRank; // 0x50
		// [HeaderAttribute] // RVA: 0x674BA8 Offset: 0x674BA8 VA: 0x674BA8
		// [SerializeField] // RVA: 0x674BA8 Offset: 0x674BA8 VA: 0x674BA8
		// private GameObject m_musicUtaRateObj; // 0x54
		// [SerializeField] // RVA: 0x674BF8 Offset: 0x674BF8 VA: 0x674BF8
		// private TextMeshProUGUI m_musicUtaRate; // 0x58
		// [HeaderAttribute] // RVA: 0x674C08 Offset: 0x674C08 VA: 0x674C08
		// [SerializeField] // RVA: 0x674C08 Offset: 0x674C08 VA: 0x674C08
		// private GameObject m_musicTimeObj; // 0x5C
		// [SerializeField] // RVA: 0x674C58 Offset: 0x674C58 VA: 0x674C58
		// private TextMeshProUGUI m_musicTime; // 0x60
		// [HeaderAttribute] // RVA: 0x674C68 Offset: 0x674C68 VA: 0x674C68
		// [SerializeField] // RVA: 0x674C68 Offset: 0x674C68 VA: 0x674C68
		// private CanvasGroup m_bookMarkObj; // 0x64
		// [SerializeField] // RVA: 0x674CC4 Offset: 0x674CC4 VA: 0x674CC4
		// private GameObject m_bookMarkSaveObj; // 0x68
		// [SerializeField] // RVA: 0x674CD4 Offset: 0x674CD4 VA: 0x674CD4
		// private GameObject m_bookMarkNotSaveObj; // 0x6C
		// [SerializeField] // RVA: 0x674CE4 Offset: 0x674CE4 VA: 0x674CE4
		// private UGUIButton m_bookMarakButton; // 0x70
		// [HeaderAttribute] // RVA: 0x674CF4 Offset: 0x674CF4 VA: 0x674CF4
		// [SerializeField] // RVA: 0x674CF4 Offset: 0x674CF4 VA: 0x674CF4
		// private CanvasGroup m_unitToggleButtonGroupObj; // 0x74
		// [SerializeField] // RVA: 0x674D3C Offset: 0x674D3C VA: 0x674D3C
		// private UGUIToggleButtonGroup m_unitToggleButtonGroup; // 0x78
		// [SerializeField] // RVA: 0x674D4C Offset: 0x674D4C VA: 0x674D4C
		// private UGUIToggleButton[] m_unitToggleButton; // 0x7C
		// [HeaderAttribute] // RVA: 0x674D5C Offset: 0x674D5C VA: 0x674D5C
		// [SerializeField] // RVA: 0x674D5C Offset: 0x674D5C VA: 0x674D5C
		// private InOutAnime m_inOut; // 0x80
		// [HeaderAttribute] // RVA: 0x674DA4 Offset: 0x674DA4 VA: 0x674DA4
		// [SerializeField] // RVA: 0x674DA4 Offset: 0x674DA4 VA: 0x674DA4
		// private Image m_backImage; // 0x84
		// [SerializeField] // RVA: 0x674DFC Offset: 0x674DFC VA: 0x674DFC
		// private Sprite[] m_changeBackImage; // 0x88
		// [HeaderAttribute] // RVA: 0x674E0C Offset: 0x674E0C VA: 0x674E0C
		// [SerializeField] // RVA: 0x674E0C Offset: 0x674E0C VA: 0x674E0C
		// private CanvasGroup m_lockObj; // 0x8C
		// [SerializeField] // RVA: 0x674E5C Offset: 0x674E5C VA: 0x674E5C
		// private Image m_lockIcon; // 0x90
		// [SerializeField] // RVA: 0x674E6C Offset: 0x674E6C VA: 0x674E6C
		// [HeaderAttribute] // RVA: 0x674E6C Offset: 0x674E6C VA: 0x674E6C
		// private CanvasGroup m_weeklyObj; // 0x94
		// [SerializeField] // RVA: 0x674EC0 Offset: 0x674EC0 VA: 0x674EC0
		// private RawImageEx[] m_weeklyItemImage; // 0x98
		// [SerializeField] // RVA: 0x674ED0 Offset: 0x674ED0 VA: 0x674ED0
		// private TextMeshProUGUI m_weeklyRemainTime; // 0x9C
		// [SerializeField] // RVA: 0x674EE0 Offset: 0x674EE0 VA: 0x674EE0
		// private TextMeshProUGUI m_weeklyRemainCount; // 0xA0
		// [SerializeField] // RVA: 0x674EF0 Offset: 0x674EF0 VA: 0x674EF0
		// private UGUIButton m_weeklyDescButton; // 0xA4
		// [HeaderAttribute] // RVA: 0x674F00 Offset: 0x674F00 VA: 0x674F00
		// [SerializeField] // RVA: 0x674F00 Offset: 0x674F00 VA: 0x674F00
		// private CanvasGroup m_highLevelFrmObj; // 0xA8
		// [SerializeField] // RVA: 0x674F48 Offset: 0x674F48 VA: 0x674F48
		// private CanvasGroup m_highLevelRemainTimeObj; // 0xAC
		// [SerializeField] // RVA: 0x674F58 Offset: 0x674F58 VA: 0x674F58
		// private Text m_highLevelRemainTime; // 0xB0
		// [SerializeField] // RVA: 0x674F68 Offset: 0x674F68 VA: 0x674F68
		// private CanvasGroup m_highLevelClearStateObj; // 0xB4
		// [SerializeField] // RVA: 0x674F78 Offset: 0x674F78 VA: 0x674F78
		// private Image m_highLevelClearStateImage; // 0xB8
		// [SerializeField] // RVA: 0x674F88 Offset: 0x674F88 VA: 0x674F88
		// private Sprite[] m_highLevelClearStateSprites; // 0xBC
		// [HeaderAttribute] // RVA: 0x674F98 Offset: 0x674F98 VA: 0x674F98
		// [SerializeField] // RVA: 0x674F98 Offset: 0x674F98 VA: 0x674F98
		// private GameObject m_ScoreRankingObj; // 0xC0
		// [SerializeField] // RVA: 0x675000 Offset: 0x675000 VA: 0x675000
		// private TextMeshProUGUI m_ScoreRankingNum; // 0xC4
		// [SerializeField] // RVA: 0x675010 Offset: 0x675010 VA: 0x675010
		// private UGUIButton m_ScoreRankingDescButton; // 0xC8
		// [SerializeField] // RVA: 0x675020 Offset: 0x675020 VA: 0x675020
		// private UGUIButton m_ScoreRankingEventRewardButton; // 0xCC
		// [SerializeField] // RVA: 0x675030 Offset: 0x675030 VA: 0x675030
		// [HeaderAttribute] // RVA: 0x675030 Offset: 0x675030 VA: 0x675030
		// private CanvasGroup m_eventObj; // 0xD0
		// [SerializeField] // RVA: 0x675088 Offset: 0x675088 VA: 0x675088
		// private CanvasGroup m_eventCountingObj; // 0xD4
		// [SerializeField] // RVA: 0x675098 Offset: 0x675098 VA: 0x675098
		// private TextMeshProUGUI m_eventRemainTime; // 0xD8
		// private int m_isOnUnitIndex; // 0xDC
		// private List<int> m_itemIdList; // 0xE0
		// [CompilerGeneratedAttribute] // RVA: 0x6750A8 Offset: 0x6750A8 VA: 0x6750A8
		// private Action <OnMusicBookMarkButtonClickListener>k__BackingField; // 0xE4
		// [CompilerGeneratedAttribute] // RVA: 0x6750B8 Offset: 0x6750B8 VA: 0x6750B8
		// private Action<int> <OnUnitButtonClickListener>k__BackingField; // 0xE8
		// [CompilerGeneratedAttribute] // RVA: 0x6750C8 Offset: 0x6750C8 VA: 0x6750C8
		// private Action <OnJacketButtonClickListener>k__BackingField; // 0xEC
		// [CompilerGeneratedAttribute] // RVA: 0x6750D8 Offset: 0x6750D8 VA: 0x6750D8
		// private Action <OnEventDetailClickListener>k__BackingField; // 0xF0
		// [CompilerGeneratedAttribute] // RVA: 0x6750E8 Offset: 0x6750E8 VA: 0x6750E8
		// private Action <OnEventRewardClickListener>k__BackingField; // 0xF4

		// // Properties
		// private Action OnMusicBookMarkButtonClickListener { get; set; }
		// private Action<int> OnUnitButtonClickListener { get; set; }
		// private Action OnJacketButtonClickListener { get; set; }
		// private Action OnEventDetailClickListener { get; set; }
		// private Action OnEventRewardClickListener { get; set; }
		// private MusicJacketTextureCache jacketTexCache { get; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F5A5C Offset: 0x6F5A5C VA: 0x6F5A5C
		// // RVA: 0xBDE5C4 Offset: 0xBDE5C4 VA: 0xBDE5C4
		// private Action get_OnMusicBookMarkButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5A6C Offset: 0x6F5A6C VA: 0x6F5A6C
		// // RVA: 0xBDE5CC Offset: 0xBDE5CC VA: 0xBDE5CC
		// public void set_OnMusicBookMarkButtonClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5A7C Offset: 0x6F5A7C VA: 0x6F5A7C
		// // RVA: 0xBDE5D4 Offset: 0xBDE5D4 VA: 0xBDE5D4
		// private Action<int> get_OnUnitButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5A8C Offset: 0x6F5A8C VA: 0x6F5A8C
		// // RVA: 0xBDE5DC Offset: 0xBDE5DC VA: 0xBDE5DC
		// public void set_OnUnitButtonClickListener(Action<int> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5A9C Offset: 0x6F5A9C VA: 0x6F5A9C
		// // RVA: 0xBDE5E4 Offset: 0xBDE5E4 VA: 0xBDE5E4
		// private Action get_OnJacketButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5AAC Offset: 0x6F5AAC VA: 0x6F5AAC
		// // RVA: 0xBDE5EC Offset: 0xBDE5EC VA: 0xBDE5EC
		// public void set_OnJacketButtonClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5ABC Offset: 0x6F5ABC VA: 0x6F5ABC
		// // RVA: 0xBDE5F4 Offset: 0xBDE5F4 VA: 0xBDE5F4
		// private Action get_OnEventDetailClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5ACC Offset: 0x6F5ACC VA: 0x6F5ACC
		// // RVA: 0xBDE5FC Offset: 0xBDE5FC VA: 0xBDE5FC
		// public void set_OnEventDetailClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5ADC Offset: 0x6F5ADC VA: 0x6F5ADC
		// // RVA: 0xBDE604 Offset: 0xBDE604 VA: 0xBDE604
		// private Action get_OnEventRewardClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5AEC Offset: 0x6F5AEC VA: 0x6F5AEC
		// // RVA: 0xBDE60C Offset: 0xBDE60C VA: 0xBDE60C
		// public void set_OnEventRewardClickListener(Action value) { }

		// // RVA: 0xBDE614 Offset: 0xBDE614 VA: 0xBDE614
		// private MusicJacketTextureCache get_jacketTexCache() { }

		// // RVA: 0xBDE6B0 Offset: 0xBDE6B0 VA: 0xBDE6B0
		// private void Awake() { }

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
		// public void SetUnitButton(int index) { }

		// // RVA: 0xBE0124 Offset: 0xBE0124 VA: 0xBE0124
		// public void ShowUnitDanceButton(IBJAKJJICBC musicData, MMOLNAHHDOM saveUnitData, bool isMusicLock) { }

		// // RVA: 0xBE0680 Offset: 0xBE0680 VA: 0xBE0680
		// private int GetDivaDanceNum(VerticalMusicSelectMusicDetail.Number num) { }

		// // RVA: 0xBE069C Offset: 0xBE069C VA: 0xBE069C
		// public int GetDanceNum() { }

		// // RVA: 0xBE07B4 Offset: 0xBE07B4 VA: 0xBE07B4
		// public void Enter() { }

		// // RVA: 0xBE07E4 Offset: 0xBE07E4 VA: 0xBE07E4
		// public void Leave() { }

		// // RVA: 0xBE0848 Offset: 0xBE0848 VA: 0xBE0848
		// public bool IsPlaying() { }

		// // RVA: 0xBE0874 Offset: 0xBE0874 VA: 0xBE0874
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xBE08F8 Offset: 0xBE08F8 VA: 0xBE08F8
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5B74 Offset: 0x6F5B74 VA: 0x6F5B74
		// // RVA: 0xBE0A1C Offset: 0xBE0A1C VA: 0xBE0A1C
		// private void <Awake>b__76_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5B84 Offset: 0x6F5B84 VA: 0x6F5B84
		// // RVA: 0xBE0A30 Offset: 0xBE0A30 VA: 0xBE0A30
		// private void <Awake>b__76_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5B94 Offset: 0x6F5B94 VA: 0x6F5B94
		// // RVA: 0xBE0A44 Offset: 0xBE0A44 VA: 0xBE0A44
		// private void <Awake>b__76_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5BA4 Offset: 0x6F5BA4 VA: 0x6F5BA4
		// // RVA: 0xBE0A58 Offset: 0xBE0A58 VA: 0xBE0A58
		// private void <Awake>b__76_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5BB4 Offset: 0x6F5BB4 VA: 0x6F5BB4
		// // RVA: 0xBE0A6C Offset: 0xBE0A6C VA: 0xBE0A6C
		// private void <Awake>b__76_4() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5BC4 Offset: 0x6F5BC4 VA: 0x6F5BC4
		// // RVA: 0xBE0A80 Offset: 0xBE0A80 VA: 0xBE0A80
		// private void <Awake>b__76_5(int index) { }
	}
}
