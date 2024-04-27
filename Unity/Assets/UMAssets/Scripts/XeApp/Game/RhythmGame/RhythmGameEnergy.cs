using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameEnergy
	{
		public enum Mode
		{
			Normal = 0,
			Subgoal = 1,
			Goal = 2,
		}

		private class PilotVoiceTimingData
		{
			public int threshold; // 0x8
			public bool played; // 0xC
		}

		private int basicValue; // 0x8
		private float awakenIncreaseRate; // 0xC
		private float awakenDecreaseRate; // 0x10
		private float rateMinValue; // 0x14
		private int specialNotesBonusValue; // 0x18
		private float[] resultRateTable; // 0x1C
		public int currentValue; // 0x2C
		private int teamPowerValue; // 0x34
		private Action<int> onPlayPilotVoice; // 0x38
		private bool usedForceSubgoal; // 0x3C
		private PilotVoiceTimingData[] pilotVoiceTimingTable = new PilotVoiceTimingData[2] {
			new PilotVoiceTimingData() { threshold = 50, played = false },
			new PilotVoiceTimingData() { threshold = 100, played = false }
		}; // 0x40

		public int subgoalValue { get; private set; } // 0x20
		public int goalValue { get; private set; } // 0x24
		public int maxValue { get; private set; } // 0x28
		public int evaluationNotesNum { get; private set; } // 0x30 
		public Mode mode { get 
		{ 
			if (RuntimeSettings.CurrentSettings.ForceLiveValkyrieMode)
			{
				return Mode.Goal;
			}
			return currentValue < goalValue ? (subgoalValue <= currentValue ? Mode.Subgoal : Mode.Normal) : Mode.Goal; } set { return; } 
		}// 0xDC5380 0xDC53A8

		// // RVA: 0xDC53AC Offset: 0xDC53AC VA: 0xDC53AC
		public void Initialize(MusicData musicData, GameSetupData.MusicInfo musicInfo, int teamPowerValue, Action<int> onPlayPilotVoice)
		{
			LDDDBPNGGIN_Game gameDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game;
			short wavId = musicData.musicBase.KKPAHLMJKIH_WavId;
			short variationId = musicData.musicBase.BKJGCEOEPFB_VariationId;
			if(musicInfo.isFreeMode)
			{
				KEODKEGFDLD_FreeMusicInfo musicdb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicInfo.freeMusicId);
				if (!musicInfo.IsLine6Mode)
				{
					subgoalValue = musicdb.HLKHOFPAOMK_SubGoalFreeModeByDiff[(int)musicInfo.difficultyType];
					goalValue = musicdb.HLLJIICKNIP_GoalFreeModeByDiff[(int)musicInfo.difficultyType];
					maxValue = musicdb.FENOHOEIJOE_MaxValueFreeModeByDiff[(int)musicInfo.difficultyType];
				}
				else
				{
					subgoalValue = musicdb.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[(int)musicInfo.difficultyType];
					goalValue = musicdb.JEANDFEBLIG_GoalFreeModeL6ByDiff[(int)musicInfo.difficultyType];
					maxValue = musicdb.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[(int)musicInfo.difficultyType];
				}
			}
			else
			{
				DJNPIGEFPMF_StoryMusicInfo musicdb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(musicInfo.storyMusicId);
				subgoalValue = musicdb.HLKHOFPAOMK_SubGoalByDiff[(int)musicInfo.difficultyType];
				goalValue = musicdb.HLLJIICKNIP_GoalByDiff[(int)musicInfo.difficultyType];
				maxValue = musicdb.FENOHOEIJOE_MaxValueByDiff[(int)musicInfo.difficultyType];
			}
			basicValue = gameDb.LECAOCJCEKF_FCoeff0;
			awakenIncreaseRate = gameDb.IHIONKFAAED_FCoeff1 / 100.0f;
			awakenDecreaseRate = gameDb.HHPJIALEPEE_FCoeff2 / 100.0f;
			specialNotesBonusValue = gameDb.BCCKJLPNJJM_FCoeff3;
			rateMinValue = gameDb.CIFKMCKFMOA_FCoeff4 / 10000.0f;
			resultRateTable = new float[gameDb.CPNJJKDKNOO_FPt.Count];
			for(int i = 0; i < gameDb.CPNJJKDKNOO_FPt.Count; i++)
			{
				resultRateTable[i] = gameDb.CPNJJKDKNOO_FPt[i] / 100.0f;
			}
			evaluationNotesNum = 0;
			for(int i = 0; i < musicData.musicScoreData.inputNoteTrack.Count; i++)
			{
				if(musicData.valkyrieModeStartMillisec >= musicData.musicScoreData.inputNoteTrack[i].time)
				{
					evaluationNotesNum++;
				}
			}
			this.teamPowerValue = teamPowerValue;
			this.onPlayPilotVoice = onPlayPilotVoice;
		}

		// // RVA: 0xDC5BAC Offset: 0xDC5BAC VA: 0xDC5BAC
		public void DisableCallbackPilotVoice()
		{
			onPlayPilotVoice = null;
		}

		// // RVA: 0xDC5BB8 Offset: 0xDC5BB8 VA: 0xDC5BB8
		public void Reset()
		{
			usedForceSubgoal = false;
			currentValue = 0;
			for(int i = 0; i < pilotVoiceTimingTable.Length; i++)
			{
				pilotVoiceTimingTable[i].played = false;
			}
		}

		// // RVA: 0xDC5C4C Offset: 0xDC5C4C VA: 0xDC5C4C
		public int GetGaugeValue()
		{
			float f = 0;
			if (subgoalValue < currentValue)
			{
				f = (currentValue - subgoalValue) * 1.0f / (goalValue - subgoalValue) * 100 + 100;
			}
			else
			{
				f = (currentValue * 1.0f / subgoalValue) * 100;
			}
			return (int)f;
		}

		// // RVA: 0xDC5CC0 Offset: 0xDC5CC0 VA: 0xDC5CC0
		// private int GetGaugeValue(int current) { }

		// // RVA: 0xDC5D30 Offset: 0xDC5D30 VA: 0xDC5D30
		public void ChangeValue(RhythmGameConsts.NoteResult result, float bonusRate, RhythmGameConsts.SpecialNoteType spType)
		{
			int inc = CalcIncreaseValue(result, bonusRate, currentValue);
			int bonus = 0;
			if (result > RhythmGameConsts.NoteResult.Bad && spType == RhythmGameConsts.SpecialNoteType.Fold)
				bonus = specialNotesBonusValue;
			inc += currentValue + bonus;
			if(usedForceSubgoal)
			{
				inc = Mathf.Max(inc, currentValue);
			}
			currentValue = inc;
			currentValue = Mathf.Clamp(currentValue, 0, maxValue);
			PlayPilotVoice();
		}

		// // RVA: 0xDC5E68 Offset: 0xDC5E68 VA: 0xDC5E68
		private int CalcIncreaseValue(RhythmGameConsts.NoteResult result, float bonusRate, int current)
		{
			float change = resultRateTable[(int)result] * teamPowerValue * bonusRate;
			return Mathf.RoundToInt(CalcNotesBasicValue(change, current) * change);
		}

		// // RVA: 0xDC6288 Offset: 0xDC6288 VA: 0xDC6288
		public void ForceChangePercentage100()
		{
			usedForceSubgoal = true;
			if(subgoalValue <= currentValue)
				return;
			currentValue = subgoalValue;
			PlayPilotVoice();
		}

		// // RVA: 0xDC5F6C Offset: 0xDC5F6C VA: 0xDC5F6C
		private void PlayPilotVoice()
		{
			int f = GetGaugeValue();
			for (int i = 0; i < pilotVoiceTimingTable.Length; i++)
			{
				if (!pilotVoiceTimingTable[i].played && pilotVoiceTimingTable[i].threshold <= f)
				{
					pilotVoiceTimingTable[i].played = true;
					if(onPlayPilotVoice != null)
					{
						onPlayPilotVoice(i);
					}
					return;
				}
			}
		}

		// // RVA: 0xDC60F0 Offset: 0xDC60F0 VA: 0xDC60F0
		private float CalcNotesBasicValue(float change, int current)
		{
			if (evaluationNotesNum < 1)
				return 0;
			if(change >= 0)
			{
				if(current < subgoalValue)
				{
					return basicValue * 1.0f / evaluationNotesNum * Mathf.Max((maxValue - current) * 1.0f / maxValue, rateMinValue);
				}
				return basicValue * 1.0f  / evaluationNotesNum * Mathf.Max((maxValue - current) * 1.0f / maxValue, rateMinValue) * awakenIncreaseRate;
			}
			else
			{
				if(current < subgoalValue)
				{
					return basicValue * 1.0f  / evaluationNotesNum * (current * 1.0f  / maxValue);
				}
				return basicValue * 1.0f  / evaluationNotesNum * (current * 1.0f  / maxValue) * awakenDecreaseRate;
			}
		}

		// // RVA: 0xDC62A8 Offset: 0xDC62A8 VA: 0xDC62A8
		public bool CalcPossiblityNextMode()
		{
			int current = 0;
			for(int i = 0; i < evaluationNotesNum; i++)
			{
				current += CalcIncreaseValue(RhythmGameConsts.NoteResult.Perfect, 1.0f, current);
			}
			return subgoalValue <= current;
		}
	}
}
