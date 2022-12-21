using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameEnemyStatus
	{
		public enum Mode
		{
			Normal = 0,
			Subgoal = 1,
			Goal = 2,
		}

		private enum SkillEnemyLifeUp
		{
			Easy = 0,
			Normal = 1,
			Hard = 2,
			VeryHard = 3,
			Extreme = 4,
			Hard_6 = 5,
			VeryHard_6 = 6,
			Extreme_6 = 7,
			Max = 8,
		}

		public static readonly int AttackComboCount = 4; // 0x0
		private List<int> basicValues; // 0x8
		private List<int> basicValueStepThresholdList; // 0xC
		private int specialNotesBonusValue; // 0x10
		public int currentValue; // 0x1C
		private float evadeRate = 100.0f; // 0x24
		private float teamAttack; // 0x28
		private float teamAccuracy = 100.0f; // 0x2C
		private float[] resultRateTable; // 0x30
		private LDDDBPNGGIN_Game gameMaster; // 0x34

		public int subgoalValue { get; private set; } // 0x14
		public int goalValue { get; private set; } // 0x18
		public int evaluationNotesNum { get; private set; } // 0x20
		public Mode mode { get 
		{ 
			if (RuntimeSettings.CurrentSettings.ForceLiveDivaMode)
			{
				return Mode.Subgoal;
			}
			if (RuntimeSettings.CurrentSettings.ForceLiveAwakenDivaMode)
			{
				return Mode.Goal;
			}
			return (currentValue < goalValue ? (subgoalValue <= currentValue ? Mode.Subgoal : Mode.Normal ) : Mode.Goal); } private set { } 
		} //0xDC3D04 0xDC3D2C

		// RVA: 0xDC3D30 Offset: 0xDC3D30 VA: 0xDC3D30
		public void Initialize(MusicData musicData, GameSetupData.MusicInfo musicInfo, float supportRate, int valkyrieId)
		{
			short wavId = musicData.musicBase.KKPAHLMJKIH_WavId;
			short variationId = musicData.musicBase.BKJGCEOEPFB_VariationId;
			int enemyId = 0;
			if(musicInfo.isFreeMode)
			{
				KEODKEGFDLD musicdb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicInfo.freeMusicId);
				if(!musicInfo.IsLine6Mode)
				{
					subgoalValue = musicdb.LJPKLMJPLAC[(int)musicInfo.difficultyType];
					goalValue = musicdb.MALHPBKPIDE[(int)musicInfo.difficultyType];
					enemyId = musicdb.LHICAKGHIGF[(int)musicInfo.difficultyType];
				}
				else
				{
					subgoalValue = musicdb.ILCJOOPIILK[(int)musicInfo.difficultyType];
					goalValue = musicdb.BGILEHEJHHA[(int)musicInfo.difficultyType];
					enemyId = musicdb.PJNFOCDANCE[(int)musicInfo.difficultyType];
				}
			}
			else
			{
				DJNPIGEFPMF musicdb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(musicInfo.storyMusicId);
				subgoalValue = musicdb.LJPKLMJPLAC[(int)musicInfo.difficultyType];
				goalValue = musicdb.MALHPBKPIDE[(int)musicInfo.difficultyType];
				enemyId = musicdb.LHICAKGHIGF[(int)musicInfo.difficultyType];
			}
			gameMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			int[] vals = new int[3] { gameMaster.IJDBNKCLGIC_BCoeff3, gameMaster.GLMKBFEHPLA_BCoeff4, gameMaster.LPDACKNMGNK_BCoeff5 };
			basicValues = new List<int>(vals.Length);
			for(int i = 0; i < vals.Length; i++)
			{
				basicValues.Add(vals[i]);
			}
			specialNotesBonusValue = gameMaster.NELJPDJEKNM_BCoeff1;
			resultRateTable = new float[gameMaster.EONACOOGKCA_BPt.Count];
			for(int i = 0; i < gameMaster.EONACOOGKCA_BPt.Count; i++)
			{
				resultRateTable[i] = gameMaster.EONACOOGKCA_BPt[i] / 100.0f;
			}
			evaluationNotesNum = 0;
			for(int i = 0; i < musicData.musicScoreData.inputNoteTrack.Count; i++)
			{
				if(musicData.valkyrieModeStartMillisec <= musicData.musicScoreData.inputNoteTrack[i].time)
				{
					if(musicData.musicScoreData.inputNoteTrack[i].time <= musicData.divaModeJudgeMillisec)
					{
						evaluationNotesNum++;
					}
				}
			}
			evaluationNotesNum = evaluationNotesNum + 1 - AttackComboCount;
			basicValueStepThresholdList = new List<int>();
			int r = 0;
			int v = 0;
			for (int i = 0; i < vals.Length; i++)
			{
				v += evaluationNotesNum / vals.Length + r;
				if (i == 1)
					r += evaluationNotesNum % vals.Length;
				basicValueStepThresholdList.Add(v);
			}
			NHDJHOPLMDE data = new NHDJHOPLMDE(valkyrieId, 0);
			int v1 = 0;
			int v2 = 0;
			if(data.LAKLFHGMCLI((SeriesAttr.Type)musicData.musicBase.AIHCEGFANAM_SerieId))
			{
				v1 = data.NONBCCLGBAO;
				v2 = data.KINFGHHNFCF;
			}
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo vInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[valkyrieId - 1];
			teamAttack = (v2 + vInfo.OJHINEMKMOP(0)) * supportRate;
			teamAccuracy = (v1 + vInfo.PAELLCKLEJP(0)) * supportRate;
			evadeRate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(enemyId).ADMMEMNGKEN_Avo;
		}

		//// RVA: 0xDC4A74 Offset: 0xDC4A74 VA: 0xDC4A74
		public void SetFixDamageParamter(float a_team_atk, float a_team_acc)
		{
			teamAttack = a_team_atk;
			teamAccuracy = a_team_acc;
		}

		// RVA: 0xDC4A80 Offset: 0xDC4A80 VA: 0xDC4A80
		public void Reset()
		{
			currentValue = 0;
		}

		//// RVA: 0xDC4A8C Offset: 0xDC4A8C VA: 0xDC4A8C
		public int Damage(RhythmGameConsts.NoteResult result, int notesNumberInMode, int comboCount, float damageBonusRate, float hitBonusRate, RhythmGameConsts.SpecialNoteType spType)
		{
			int res = 0;
			if(evaluationNotesNum > 0)
			{
				currentValue += CalcDamageValue(result, notesNumberInMode, comboCount, damageBonusRate, hitBonusRate, out res);
				if (result < RhythmGameConsts.NoteResult.Good || spType != RhythmGameConsts.SpecialNoteType.Attack)
				{
					// nothing
				}
				else
				{
					currentValue += specialNotesBonusValue;
					res = 3;
				}
			}
			return res;
		}

		//// RVA: 0xDC4B50 Offset: 0xDC4B50 VA: 0xDC4B50
		private int CalcDamageValue(RhythmGameConsts.NoteResult result, int notesNumberInMode, int comboCount, float damageBonusRate, float hitBonusRate, out int hitResult)
		{
			int v = gameMaster.FHHPNFAECCJ(comboCount);
			float hitRate = CalcHitRate(result, hitBonusRate, out hitResult);
			int i = 0;
			for (; i < basicValueStepThresholdList.Count; i++)
			{
				if ((notesNumberInMode + 1 - AttackComboCount) < basicValueStepThresholdList[i])
					break;
			}
			return Mathf.RoundToInt(hitRate * v / 100.0f * teamAttack * basicValues[i] / evaluationNotesNum * damageBonusRate);
		}

		//// RVA: 0xDC4D48 Offset: 0xDC4D48 VA: 0xDC4D48
		private float CalcHitRate(RhythmGameConsts.NoteResult result, float hitBonusRate, out int hitResult)
		{
			int val = (int)((teamAccuracy * resultRateTable[(int)result] - evadeRate) * hitBonusRate);
			hitResult = gameMaster.FHFLCJHEEPK(val);
			return gameMaster.IKIGFABDFMB(val) / 100.0f;
		}

		//// RVA: 0xDC4E28 Offset: 0xDC4E28 VA: 0xDC4E28
		//public void ForceDefeat() { }

		//// RVA: 0xDC4E3C Offset: 0xDC4E3C VA: 0xDC4E3C
		public bool CalcPossiblityNextMode()
		{
			int current = 0;
			for(int i = 0; i < evaluationNotesNum; i++)
			{
				int a;
				current += CalcDamageValue(RhythmGameConsts.NoteResult.Perfect, i, i + AttackComboCount, 1.0f, 1.0f, out a);
			}
			return subgoalValue <= current;
		}

		//// RVA: 0xDC4F3C Offset: 0xDC4F3C VA: 0xDC4F3C
		public bool SetupEnemyLife(SkillBase skill)
		{
			if(skill != null)
			{
				LiveSkillBase ls = skill as LiveSkillBase;
				if(ls != null)
				{
					if(skill.buffEffectValue > 0)
					{
						int diff = (int)Database.Instance.gameSetup.musicInfo.difficultyType;
						if (Database.Instance.gameSetup.musicInfo.IsLine6Mode)
						{
							diff = Mathf.Clamp(diff - 2, 0, 7) + 5;
						}
						subgoalValue = Mathf.RoundToInt(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BGDOCIBFLBM_EnemyBuffs[skill.buffEffectValue - 1].OMIMBPNKOKE_SubGoalPercent[diff] * 0.01f * subgoalValue);
						goalValue = Mathf.RoundToInt(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BGDOCIBFLBM_EnemyBuffs[skill.buffEffectValue - 1].HGIOBLMAAEO_GoalPercent[diff] * 0.01f * goalValue);
						return true;
					}
				}
			}
			return false;
		}
	}
}
