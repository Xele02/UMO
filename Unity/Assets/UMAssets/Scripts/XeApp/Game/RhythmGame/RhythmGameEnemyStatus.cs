using System.Collections.Generic;
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
		//public Mode mode { get; private set; } 0xDC3D04 0xDC3D2C

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
			for (int i = 0; i < vals.Length; i++)
			{
				int v = evaluationNotesNum / vals.Length + r;
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
		//public void SetFixDamageParamter(float a_team_atk, float a_team_acc) { }

		// RVA: 0xDC4A80 Offset: 0xDC4A80 VA: 0xDC4A80
		public void Reset()
		{
			currentValue = 0;
		}

		//// RVA: 0xDC4A8C Offset: 0xDC4A8C VA: 0xDC4A8C
		//public int Damage(RhythmGameConsts.NoteResult result, int notesNumberInMode, int comboCount, float damageBonusRate, float hitBonusRate, RhythmGameConsts.SpecialNoteType spType) { }

		//// RVA: 0xDC4B50 Offset: 0xDC4B50 VA: 0xDC4B50
		//private int CalcDamageValue(RhythmGameConsts.NoteResult result, int notesNumberInMode, int comboCount, float damageBonusRate, float hitBonusRate, out int hitResult) { }

		//// RVA: 0xDC4D48 Offset: 0xDC4D48 VA: 0xDC4D48
		//private float CalcHitRate(RhythmGameConsts.NoteResult result, float hitBonusRate, out int hitResult) { }

		//// RVA: 0xDC4E28 Offset: 0xDC4E28 VA: 0xDC4E28
		//public void ForceDefeat() { }

		//// RVA: 0xDC4E3C Offset: 0xDC4E3C VA: 0xDC4E3C
		//public bool CalcPossiblityNextMode() { }

		//// RVA: 0xDC4F3C Offset: 0xDC4F3C VA: 0xDC4F3C
		//public bool SetupEnemyLife(SkillBase skill) { }
	}
}
