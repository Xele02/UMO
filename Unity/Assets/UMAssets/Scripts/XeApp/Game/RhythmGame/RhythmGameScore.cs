using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameScore
	{
		private float musicLevelBonusRate; // 0x8
		private List<float> noteResultBonusRateList = new List<float>(); // 0xC
		private List<JANMKFAKHIC_ComboBonus> comboBonusDataList = new List<JANMKFAKHIC_ComboBonus>(); // 0x10
		private CEBFFLDKAEC_SecureInt totalComboCount_ = new CEBFFLDKAEC_SecureInt(); // 0x14
		private DDBNGDNJJHN_SecureFloat baseNoteScore_ = new DDBNGDNJJHN_SecureFloat(); // 0x18
		private LINJMMGGDKL_SecureInt2 currentScore_ = new LINJMMGGDKL_SecureInt2(); // 0x1C
		private LINJMMGGDKL_SecureInt2 nonExcellentScore_ = new LINJMMGGDKL_SecureInt2(); // 0x20
		private DDBNGDNJJHN_SecureFloat scoreNotesValue_ = new DDBNGDNJJHN_SecureFloat(); // 0x2C

		public int totalComboCount { get { return totalComboCount_.DNJEJEANJGL_Value; } private set { totalComboCount_.DNJEJEANJGL_Value = value; } } //0xBFDF2C 0xBFDF58
		public float baseNoteScore { get { return baseNoteScore_.DNJEJEANJGL_Value; } private set { baseNoteScore_.DNJEJEANJGL_Value = value; } } //0xBFDF8C 0xBFDFB8
		public int currentScore { get { return currentScore_.DNJEJEANJGL_Value; } private set { currentScore_.DNJEJEANJGL_Value = value; } } //0xBFDFEC 0xBFE018
		public int nonExcellentScore { get { return nonExcellentScore_.DNJEJEANJGL_Value; } private set { nonExcellentScore_.DNJEJEANJGL_Value = value; } } //0xBFE04C 0xBFE078
		public int musicLevel { get; private set; } // 0x24
		public ADDHLABEFKH musicLevelData { get; private set; } // 0x28
		public float scoreNotesValue { get { return scoreNotesValue_.DNJEJEANJGL_Value; } private set { scoreNotesValue_.DNJEJEANJGL_Value = value; } } //0xBFE0CC 0xBFE0F8

		//// RVA: 0xBFE12C Offset: 0xBFE12C VA: 0xBFE12C
		public FENCAJJBLBH CheckFalisification()
		{
			FENCAJJBLBH res = currentScore_.NMNHBJIAPGG;
			if (res == null)
			{
				res = nonExcellentScore_.NMNHBJIAPGG;
				if(res == null)
				{
					res = totalComboCount_.NMNHBJIAPGG;
					if(res == null)
					{
						res = scoreNotesValue_.NMNHBJIAPGG;
					}
				}
			}
			return res;
		}

		//// RVA: 0xBFE1B8 Offset: 0xBFE1B8 VA: 0xBFE1B8
		public void Initialize(MusicData musicData, int teamScoreBonusValue)
		{
			OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
			GameSetupData setup = Database.Instance.gameSetup;
			short wavId = musicData.musicBase.KKPAHLMJKIH_WavId; // ENODDPDBIPA
			short variationId = musicData.musicBase.BKJGCEOEPFB_VariationId; // FNEBPBJBIIP
			Difficulty.Type diff = setup.musicInfo.difficultyType;
			bool line6 = setup.musicInfo.IsLine6Mode;
			if(setup.musicInfo.isStoryMode)
			{
				musicLevelData = db.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(setup.musicInfo.storyMusicId).COGKJBAFBKN_ByDiff[(int)diff];
			}
			else
			{
				musicLevelData = db.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(setup.musicInfo.freeMusicId).EMJCHPDJHEI(line6, (int)diff);
			}
			totalComboCount = musicData.musicScoreData.CalcComboLimit();
			musicLevel = db.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(wavId, variationId, (int)diff, line6, true).ANAJIAENLNB_MusicLevel;
			musicLevelBonusRate = db.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(musicLevel, line6) / 1000.0f;
			baseNoteScore = musicLevelBonusRate * teamScoreBonusValue / totalComboCount;
			scoreNotesValue = musicLevelBonusRate * teamScoreBonusValue / db.HNMMJINNHII_Game.GAHIBKLEDBF((int)diff, line6);
			currentScore = 0;
			nonExcellentScore = 0;
			noteResultBonusRateList.Clear();
			for(int i = 0; i < db.HNMMJINNHII_Game.PDNEMDIEGFB_JudgeCoef.Count; i++)
			{
				noteResultBonusRateList.Add(db.HNMMJINNHII_Game.PDNEMDIEGFB_JudgeCoef[i] / 100.0f);
			}
			comboBonusDataList = new List<JANMKFAKHIC_ComboBonus>(db.HNMMJINNHII_Game.KGHLOJNCFDO_ComboBonus);
		}

		//// RVA: 0xBFE9D4 Offset: 0xBFE9D4 VA: 0xBFE9D4
		public void Reset()
		{
			currentScore = 0;
			nonExcellentScore = 0;
		}

		//// RVA: 0xBFE9F8 Offset: 0xBFE9F8 VA: 0xBFE9F8
		public void IncreaseScore(RhythmGameConsts.NoteResultEx a_result_ex, int combo, float bonusRate, int bonusValue, RhythmGameConsts.SpecialNoteType spType, float a_excellent_score_rate, bool a_enable_combo_bonus = true)
		{
			float f = 1;
			if(a_enable_combo_bonus)
			{
				int totalCombo = totalComboCount;
				for (int i = 0; i < comboBonusDataList.Count; i++)
				{
					if(combo * 1.0f / totalCombo >= comboBonusDataList[i].ADKDHKMPMHP / 100.0f)
					{
						f = comboBonusDataList[i].DHIPGHBJLIL / 100.0f;
						break;
					}
				}
			}
			float g = bonusRate - 1 + f - 1 + 1;
			float s = noteResultBonusRateList[(int)a_result_ex.m_result];
			float h = spType == RhythmGameConsts.SpecialNoteType.Score && a_result_ex.m_result >= RhythmGameConsts.NoteResult.Good ? scoreNotesValue : 0;
			nonExcellentScore += Mathf.FloorToInt(f * h * s + s * g * baseNoteScore + 0);
			if (a_result_ex.m_excellent)
				s += a_excellent_score_rate;
			currentScore += Mathf.FloorToInt(f * h * s + g * baseNoteScore * s + 0);
		}

		//// RVA: 0xBFED3C Offset: 0xBFED3C VA: 0xBFED3C
		public ResultScoreRank.Type CalcCurrentRank()
		{
			return (ResultScoreRank.Type)musicLevelData.DLPBHJALHCK_GetScoreRank(currentScore);
		}

		//// RVA: 0xBFED74 Offset: 0xBFED74 VA: 0xBFED74
		//public float CalcRatioBetweenUpToNextRank() { }

		//// RVA: 0xBFED94 Offset: 0xBFED94 VA: 0xBFED94
		public float CalcRatioBetweenUpToNextRank(ResultScoreRank.Type currentRank)
		{
			int prevVal = 0;
			if(currentRank != 0)
			{
				prevVal = musicLevelData.KNIFCANOHOC_RankScore[(int)currentRank - 1];
			}
			int val = musicLevelData.KNIFCANOHOC_RankScore[(int)currentRank];
			return (currentScore - prevVal) * 1.0f / (val - prevVal);
		}
	}
}
