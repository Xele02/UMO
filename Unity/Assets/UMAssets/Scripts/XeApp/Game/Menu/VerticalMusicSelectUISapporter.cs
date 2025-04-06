using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectUISapporter : MonoBehaviour
	{
		public enum MusicInfoStyle
		{
			Music = 0,
			SLlive = 1,
			MiniGameEventEntrance = 2,
			OtherEventEntrance = 3,
			Lock = 4,
			Unlockable = 5,
			NoneFilter = 6,
			None6Line = 7,
		}

		public bool isLine6Mode; // 0xC
		public KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus; // 0x10
		private Difficulty.Type m_difficulty; // 0x14
		private MusicSelectConsts.SeriesType m_series; // 0x18
		private VerticalMusicSelectSortOrder.SortOrder m_sortOrder; // 0x1C
		private FPGEMAIAMBF_RewardData m_rewardData; // 0x20
		private List<MusicRewardStat> m_rewardStats; // 0x24
		// private StringBuilder m_stringBuffer = new StringBuilder(64); // 0x28
		// private List<FKMOKDCJFEN> m_questList; // 0x2C
		// private FDDIIKBJNNA m_snsData = new FDDIIKBJNNA(); // 0x30
		private VerticalMusicSelectMusicList m_musicSelectList; // 0x34
		private VerticalMusicSelectMusicDetail m_musicDetail; // 0x38
		private VerticalMusicSelectUtaRate m_utaRate; // 0x3C
		private VerticalMusicSelectEventBanner m_eventBanner; // 0x40
		private VerticalMusicSelectDifficultyButtonGroup m_difficultyButtonGroup; // 0x44
		private VerticalMusicSelectSeriesButtonGroup m_seriesButtonGroup; // 0x48
		private VerticalMusicSelectPlayButton m_playButton; // 0x4C
		private VerticalMusicSelctSimulationButton m_simulationButton; // 0x50
		private VerticalMusicSelectSortOrder m_orderButton; // 0x54
		private VerticalMusicSelecLine6Button m_line6Button; // 0x58
		private VerticalMusicSelecChoiceMusicListTab m_choiceMusicTab; // 0x5C
		// private LayoutEventGoDivaFeverLimit m_feverLimit; // 0x60
		private MMOLNAHHDOM m_unitLiveLocalSaveData; // 0x64
		private IKDICBBFBMI_EventBase m_eventCtrl; // 0x68

		public Difficulty.Type difficulty { get { return m_difficulty; } } //0xAD9F84
		public MusicSelectConsts.SeriesType series { get { return m_series; } } //0xAD9F8C
		public VerticalMusicSelectSortOrder.SortOrder sortOrder { get { return m_sortOrder; } } //0xAD9F94
		// public bool IsEventCounting { get; } 0xADA1B8
		// public bool IsEventEndChallengePeriod { get; } 0xADA1CC
		// public bool IsEventRankingEnd { get; } 0xADA1E0

		// // RVA: 0xAC7248 Offset: 0xAC7248 VA: 0xAC7248
		public void SetUp(VerticalMusicSelectMusicList musicSelectList, VerticalMusicSelectMusicDetail musicDetail, VerticalMusicSelectUtaRate utaRate, VerticalMusicSelectEventBanner eventBanner, VerticalMusicSelectDifficultyButtonGroup difficultyButtonGroup, VerticalMusicSelectSeriesButtonGroup seriesButtonGroup, VerticalMusicSelectPlayButton playButton, VerticalMusicSelctSimulationButton simulationButton, VerticalMusicSelectSortOrder orderButton, IKDICBBFBMI_EventBase eventCtrl, MMOLNAHHDOM unitLiveLocalSaveData, VerticalMusicSelecLine6Button line6Button, VerticalMusicSelecChoiceMusicListTab choiceMusicListTab)
		{
			m_musicDetail = musicDetail;
			m_musicSelectList = musicSelectList;
			m_utaRate = utaRate;
			m_eventBanner = eventBanner;
			m_difficultyButtonGroup = difficultyButtonGroup;
			m_seriesButtonGroup = seriesButtonGroup;
			m_unitLiveLocalSaveData = unitLiveLocalSaveData;
			m_eventCtrl = eventCtrl;
			m_playButton = playButton;
			m_simulationButton = simulationButton;
			m_orderButton = orderButton;
			m_line6Button = line6Button;
			m_choiceMusicTab = choiceMusicListTab;
			RewardSetUp();
		}

		// // RVA: 0xADA0C0 Offset: 0xADA0C0 VA: 0xADA0C0
		// private void CrateQuestList(IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xADA168 Offset: 0xADA168 VA: 0xADA168
		// private void CreateSnsList(IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xADA1F4 Offset: 0xADA1F4 VA: 0xADA1F4
		// public bool IsNewStory() { }

		// // RVA: 0xADA75C Offset: 0xADA75C VA: 0xADA75C
		// protected bool IsReceiveMission() { }

		// // RVA: 0xADA8C4 Offset: 0xADA8C4 VA: 0xADA8C4
		// private bool IsEnableEvMission() { }

		// // RVA: 0xADA950 Offset: 0xADA950 VA: 0xADA950
		public void SetMusicInfoStyle(VerticalMusicSelectUISapporter.MusicInfoStyle infostyle)
		{
			m_difficultyButtonGroup.SetDifficultStyle(infostyle);
			m_musicDetail.SetMusicInfoStyle(infostyle);
			m_musicSelectList.SetMusicListStyle(infostyle, m_choiceMusicTab.isNormal);
			switch(infostyle)
			{
				case MusicInfoStyle.Music:
				case MusicInfoStyle.SLlive:
					m_difficultyButtonGroup.SetDifficultyButton(m_difficulty);
					m_playButton.SetButtonEnable(true);
					return;
				case MusicInfoStyle.MiniGameEventEntrance:
				case MusicInfoStyle.OtherEventEntrance:
				case MusicInfoStyle.Lock:
				case MusicInfoStyle.Unlockable:
					m_playButton.SetButtonEnable(true);
					return;
				case MusicInfoStyle.NoneFilter:
				case MusicInfoStyle.None6Line:
					break;
				default:
					return;
			}
			m_difficultyButtonGroup.SetDifficultyButton(m_difficulty);
			m_playButton.SetButtonEnable(false);
			m_simulationButton.SetButtonState(VerticalMusicSelctSimulationButton.ButtonState.Disable);
		}

		// // RVA: 0xAD9F9C Offset: 0xAD9F9C VA: 0xAD9F9C
		private void RewardSetUp()
		{
			if(m_rewardData == null)
			{
				m_rewardData = new FPGEMAIAMBF_RewardData();
			}
			if (m_rewardStats != null)
				return;
			m_rewardStats = new List<MusicRewardStat>();
			for(int i = 0; i < 5; i++)
			{
				m_rewardStats.Add(new MusicRewardStat());
			}
		}

		// // RVA: 0xADAAF4 Offset: 0xADAAF4 VA: 0xADAAF4
		public void SetupRewardStat(IBJAKJJICBC musicData)
		{
			m_rewardData.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, 0, isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
			for(int i = 0; i < musicData.MGJKEJHEBPO_DiffInfos.Count; i++)
			{
				m_rewardData.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, i, isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
				m_rewardStats[i].Init(m_rewardData);
			}
		}

		// // RVA: 0xADAD1C Offset: 0xADAD1C VA: 0xADAD1C
		public void SetRewardMark(IBJAKJJICBC musicData, bool withoutReward)
		{
			MusicRewardStat r = m_rewardStats[(int)m_difficulty];
			MusicScrollCenterItem item = m_musicSelectList.MusicScrollView.CenterItem;
			if(withoutReward)
			{
				item.SetRewardState(false, false, false);
			}
			else
			{
				item.SetRewardState(r.isScoreComplete, r.isComboComplete, r.isClearCountComplete);
			}
		}

		// // RVA: 0xADAEC4 Offset: 0xADAEC4 VA: 0xADAEC4
		public void SetDifftatus(VerticalMusicDataList.MusicListData musicListData)
		{
			if(!musicListData.IsHighLevel)
			{
				for(int i = 0; i < musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos.Count; i++)
				{
					m_difficultyButtonGroup.SetDifficultyStatus(i, musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos[i].CADENLBDAEB_IsNew,
						musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos[i].BCGLDMKODLC_IsClear,
						(RhythmGameConsts.ResultComboType)musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos[i].LCOHGOIDMDF_ComboRank);
				}
			}
			else
			{
				m_musicDetail.SetHighLevelClearStatus(musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos[musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos.Count - 1].BCGLDMKODLC_IsClear,
					(RhythmGameConsts.ResultComboType)musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos[musicListData.ViewMusic.MGJKEJHEBPO_DiffInfos.Count - 1].LCOHGOIDMDF_ComboRank);
			}
		}

		// // RVA: 0xAC2ADC Offset: 0xAC2ADC VA: 0xAC2ADC
		public void SetDiffity(Difficulty.Type diffity)
		{
			m_difficulty = diffity;
			Difficulty.Type diff = 0;
			if (!isLine6Mode)
			{
				m_difficultyButtonGroup.SetDifficultyButtonStyle(VerticalMusicSelectDifficultyButtonGroup.ButtonStyle.NormalLine);
				diff = m_difficulty;
			}
			else
			{
				m_difficultyButtonGroup.SetDifficultyButtonStyle(VerticalMusicSelectDifficultyButtonGroup.ButtonStyle.Line6);
				diff = m_difficulty;
				if((int)diff < 2)
				{
					diff = Difficulty.Type.Hard;
					m_difficulty = Difficulty.Type.Hard;
				}
			}
			m_difficultyButtonGroup.SetDifficultyButton(diff);
		}

		// // RVA: 0xAC2B68 Offset: 0xAC2B68 VA: 0xAC2B68
		public void SetLineTypeToggle(bool is6Lane)
		{
			if (is6Lane)
				m_line6Button.Set6Line();
			else
				m_line6Button.Set4Line();
		}

		// // RVA: 0xADB23C Offset: 0xADB23C VA: 0xADB23C
		public void SetSeries(MusicSelectConsts.SeriesType seriesType)
		{
			m_series = seriesType;
			m_seriesButtonGroup.SetSeriesButton((int)seriesType);
		}

		// // RVA: 0xADB270 Offset: 0xADB270 VA: 0xADB270
		public void SetUtaRateIcon(HighScoreRatingRank.Type rank)
		{
			m_utaRate.SetScoreRatingRank(rank);
		}

		// // RVA: 0xADB400 Offset: 0xADB400 VA: 0xADB400
		public void SetUtaRateRating(int ratingValue)
		{
			m_utaRate.SetUtaRateRating(ratingValue);
		}

		// // RVA: 0xADB47C Offset: 0xADB47C VA: 0xADB47C
		public void SetEnemyData(EJKBKMBJMGL_EnemyData enemyData)
		{
			return;
		}

		// // RVA: 0xADB480 Offset: 0xADB480 VA: 0xADB480
		public void SetMusicJacket(int jacketId)
		{
			m_musicDetail.SetImageJacket(jacketId);
		}

		// // RVA: 0xADB4B4 Offset: 0xADB4B4 VA: 0xADB4B4
		public void SetMusicEventJacket(int jacketId)
		{
			m_musicDetail.SetImageJacketIsEvent(jacketId);
		}

		// // RVA: 0xADB4E8 Offset: 0xADB4E8 VA: 0xADB4E8
		public void SetMusicJacketNew(IBJAKJJICBC musicData)
		{
			//musicData.GEBJMDIJNAH
			return;
		}

		// // RVA: 0xADB514 Offset: 0xADB514 VA: 0xADB514
		public void SetMusicLevel(IBJAKJJICBC musicData)
		{
			for(int i = 0; i < 5; i++)
			{
				if(musicData.MGJKEJHEBPO_DiffInfos[i].HHMLMKAEJBJ_Score != null)
				{
					m_difficultyButtonGroup.SetMusicLevel(i, musicData.MGJKEJHEBPO_DiffInfos[i].HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel, isLine6Mode ? VerticalMusicSelectDifficultyButtonGroup.ButtonStyle.Line6 : VerticalMusicSelectDifficultyButtonGroup.ButtonStyle.NormalLine);
				}
			}
		}

		// // RVA: 0xADB628 Offset: 0xADB628 VA: 0xADB628
		public void SetMusicScore(IBJAKJJICBC musicData)
		{
			if(!musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BCGLDMKODLC_IsClear)
			{
				if(musicData.AFCMIOIGAJN_EventInfo == null)
				{
					m_musicDetail.SetHighScore(0, false);
					m_musicDetail.SetScoreRank(ResultScoreRank.Type.Illegal);
					return;
				}
			}
			int score = musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].KNIFCANOHOC_Score;
			m_musicDetail.SetHighScore(score, true);
			m_musicDetail.SetScoreRank((ResultScoreRank.Type)musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BAKLKJLPLOJ.DLPBHJALHCK_GetScoreRank(score));
		}

		// // RVA: 0xADB804 Offset: 0xADB804 VA: 0xADB804
		public void SetJacketAttr(int attr, bool isVisible)
		{
			m_musicDetail.SetAttr(attr, isVisible);
		}

		// // RVA: 0xADB840 Offset: 0xADB840 VA: 0xADB840
		public void SetMusicUtaRating(int rating, bool isVisible)
		{
			m_musicDetail.SetMusicUtaRate(rating, isVisible);
		}

		// // RVA: 0xADB87C Offset: 0xADB87C VA: 0xADB87C
		public void SetMusicTime(string time, bool isVisible)
		{
			m_musicDetail.SetMusicTime(time, isVisible);
		}

		// // RVA: 0xADB8B8 Offset: 0xADB8B8 VA: 0xADB8B8
		public void SetUnitButton(IBJAKJJICBC musicData, bool isMusicLock)
		{
			m_musicDetail.ShowUnitDanceButton(musicData, m_unitLiveLocalSaveData, isMusicLock);
		}

		// // RVA: 0xADB908 Offset: 0xADB908 VA: 0xADB908
		public void SetUnitButton(int index, IBJAKJJICBC musicData)
		{
			m_musicDetail.SetUnitButton(index);
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(musicData.GHBPLHBNMBK_FreeMusicId, m_musicDetail.GetDanceNum() > 1);
		}

		// // RVA: 0xADB9B8 Offset: 0xADB9B8 VA: 0xADB9B8
		public void SetDetailEventType(bool isVisible, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType, bool showRemainTime = true)
		{
			m_musicDetail.SetEventInfo(isVisible, remainTimeType, showRemainTime);
		}

		// // RVA: 0xADBA08 Offset: 0xADBA08 VA: 0xADBA08
		public void SetWeeklyEventCount(int count)
		{
			m_musicDetail.SetWeeklyEventCount(count);
		}

		// // RVA: 0xADBA3C Offset: 0xADBA3C VA: 0xADBA3C
		public void SetWeeklyItem(IBJAKJJICBC musicData)
		{
			m_musicDetail.SetWeeklyItem(musicData);
		}

		// // RVA: 0xADBA70 Offset: 0xADBA70 VA: 0xADBA70
		public void SetScoreRankingNum(int num)
		{
			m_musicDetail.SetScoreRankingNum(num);
		}

		// // RVA: 0xADBAA4 Offset: 0xADBAA4 VA: 0xADBAA4
		public void SetWeeklyEventCountEmptyEnable(bool isEnable)
		{
			m_playButton.WeeklyRecoveryEnable(isEnable);
		}

		// // RVA: 0xADBAD8 Offset: 0xADBAD8 VA: 0xADBAD8
		public void SetEnergy(IBJAKJJICBC musicData)
		{
			m_playButton.SetEnergy(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BPLOEAHOPFI_Energy);
		}

		// // RVA: 0xAC7F7C Offset: 0xAC7F7C VA: 0xAC7F7C
		public void SetSmallBigOrder(VerticalMusicSelectSortOrder.SortOrder sortOrder)
		{
			m_sortOrder = sortOrder;
			m_orderButton.SetOrder(sortOrder);
		}

		// // RVA: 0xADBBC0 Offset: 0xADBBC0 VA: 0xADBBC0
		public void SetSmallBigOrderEnable(bool isEnable)
		{
			m_orderButton.SetButtonEnable(isEnable);
		}

		// // RVA: 0xADBBF0 Offset: 0xADBBF0 VA: 0xADBBF0
		public void SetSeriesButtonEnable(bool isEnable)
		{
			m_seriesButtonGroup.SetPullDownEnable(isEnable);
		}

		// // RVA: 0xADBC20 Offset: 0xADBC20 VA: 0xADBC20
		public void SetBookMark(bool isEnable, bool isBookMark)
		{
			m_musicDetail.SetSaveBookMark(isEnable, isBookMark);
		}

		// // RVA: 0xADBC5C Offset: 0xADBC5C VA: 0xADBC5C
		// public void SetSnsBadge() { }

		// // RVA: 0xADBC60 Offset: 0xADBC60 VA: 0xADBC60
		// public void SetMissionBadge() { }

		// // RVA: 0xADBC64 Offset: 0xADBC64 VA: 0xADBC64
		// public void SetStepCount(int count) { }

		// // RVA: 0xADBC68 Offset: 0xADBC68 VA: 0xADBC68
		// public void SetMissionEventBonus(int bonus) { }

		// // RVA: 0xADBC6C Offset: 0xADBC6C VA: 0xADBC6C
		// public void SetEventGoDivaRank(int rank) { }

		// // RVA: 0xADBC70 Offset: 0xADBC70 VA: 0xADBC70
		// public void SetGoDivaExpType(ExpType expType) { }

		// // RVA: 0xADBC74 Offset: 0xADBC74 VA: 0xADBC74
		// public void ApplyEventGodivaExp(int exp) { }

		// // RVA: 0xADBC78 Offset: 0xADBC78 VA: 0xADBC78
		// public void SetCollectionEventRanking(IBJAKJJICBC musicData, int rank) { }
	}
}
