using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameLife
	{
		private int changeBeganValue; // 0x24
		private int changeTargetValue; // 0x28
		private float changeRequiredTime; // 0x2C
		private float changeBeganTime; // 0x30
		private bool isChanging; // 0x34

		public int max { get; private set; } // 0x8
		public int current { get; private set; } // 0xC
		public int view { get; private set; } // 0x10
		public int badDamage { get; private set; } // 0x14
		public int missDamage { get; private set; } // 0x18
		public int healNotesValue { get; private set; } // 0x1C
		public bool isInvincibleCheat { get; set; } // 0x20
		public bool isInvincibleGameEnd { get; set; } // 0x21
		public bool isInvincibleModeMV { get; set; } // 0x22
		//public bool isInvincible { get; } 0x9A897C
		public bool isLiveSkip { get; set; } // 0x23

		// RVA: 0x9A89B0 Offset: 0x9A89B0 VA: 0x9A89B0
		public void Initialize(MusicData musicData, int max, bool a_is_liveskip = false)
		{
			short wavId = musicData.musicBase.KKPAHLMJKIH_WavId;
			short variationId = musicData.musicBase.BKJGCEOEPFB_VariationId;
			Difficulty.Type diff = Database.Instance.gameSetup.musicInfo.difficultyType;
			bool isLine6 = Database.Instance.gameSetup.musicInfo.IsLine6Mode;
			KLBKPANJCPL_Score score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(wavId, variationId, (int)diff, isLine6, true);
			badDamage = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GOLHPPFLJNF(score.ANAJIAENLNB_MusicLevel, isLine6);
			missDamage = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AOGJFPLIOGB(score.ANAJIAENLNB_MusicLevel, isLine6);
			healNotesValue = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AFDONIMNHEJ(score.ANAJIAENLNB_MusicLevel, isLine6);
			isInvincibleModeMV = false;
			this.max = max;
			isLiveSkip = a_is_liveskip;
		}

		// RVA: 0x9A8D54 Offset: 0x9A8D54 VA: 0x9A8D54
		public void Reset()
		{
			current = max;
			view = max;
		}

		//// RVA: 0x9A8D64 Offset: 0x9A8D64 VA: 0x9A8D64
		public void HealNotes()
		{
			ChangeLife(healNotesValue, 1.0f);
		}

		//// RVA: 0x9A8E94 Offset: 0x9A8E94 VA: 0x9A8E94
		public void HealPercentage(int percentage)
		{
			changeRequiredTime = 0.5f;
			changeBeganValue = view;
			changeBeganTime = TimeWrapper.time;
			isChanging = true;
			ChangeLife(max, percentage / 100.0f);
		}

		//// RVA: 0x9A8F20 Offset: 0x9A8F20 VA: 0x9A8F20
		public void HealValue(int value)
		{
			changeRequiredTime = 0.5f;
			changeBeganValue = view;
			changeBeganTime = TimeWrapper.time;
			isChanging = true;
			ChangeLife(value, 1.0f);
		}

		//// RVA: 0x9A8F68 Offset: 0x9A8F68 VA: 0x9A8F68
		public void DamageValue(int value)
		{
			if(!isInvincibleCheat && !isInvincibleGameEnd && !isInvincibleModeMV)
			{
				ChangeLife(-value, 1);
			}
		}

		//// RVA: 0x9A8F98 Offset: 0x9A8F98 VA: 0x9A8F98
		public void DamageNotes(RhythmGameConsts.NoteResult type, float damageRate)
		{
			if (isInvincibleCheat)
				return;
			if (isInvincibleGameEnd || isInvincibleModeMV)
				return;
			if (type == RhythmGameConsts.NoteResult.Miss)
				ChangeLife(-missDamage, damageRate);
			else if(type == RhythmGameConsts.NoteResult.Bad)
				ChangeLife(-badDamage, damageRate);
		}

		//// RVA: 0x9A8D70 Offset: 0x9A8D70 VA: 0x9A8D70
		private void ChangeLife(int value, float rate)
		{
			current = (int)Mathf.Clamp(current + (int)(value * rate), 0, max);
			if(isLiveSkip)
			{
				current = Mathf.Max(1, current);
			}
			if(RuntimeSettings.CurrentSettings.IsInvincibleCheat)
			{
				current = Mathf.Max(current, 1);
			}
			if (isChanging)
				changeTargetValue = current;
			else
				view = current;
		}

		//// RVA: 0x9A8FE8 Offset: 0x9A8FE8 VA: 0x9A8FE8
		public void Full()
		{
			current = max;
			changeBeganValue = view;
			changeTargetValue = max;
			changeRequiredTime = 0.5f;
			changeBeganTime = TimeWrapper.time;
			isChanging = true;
		}

		//// RVA: 0x9A9028 Offset: 0x9A9028 VA: 0x9A9028
		//public void Zero() { }

		//// RVA: 0x9A9068 Offset: 0x9A9068 VA: 0x9A9068
		public void Update()
		{
			if(isChanging)
			{
				if(changeBeganTime + changeRequiredTime < Time.time)
				{
					isChanging = true;
					view = changeTargetValue;
				}
				else
				{
					view = changeBeganValue + Mathf.RoundToInt((Time.time - changeBeganTime) / changeRequiredTime * (changeTargetValue - changeBeganValue));
				}
			}
		}

		//// RVA: 0x9A9174 Offset: 0x9A9174 VA: 0x9A9174
		//public int GetCurrentPercentage() { }

		//// RVA: 0x9A91A0 Offset: 0x9A91A0 VA: 0x9A91A0
		//public int GetViewPercentage() { }

		//// RVA: 0x9A8EF0 Offset: 0x9A8EF0 VA: 0x9A8EF0
		//private void SetupChangeLife(float requireTime) { }
	}
}
