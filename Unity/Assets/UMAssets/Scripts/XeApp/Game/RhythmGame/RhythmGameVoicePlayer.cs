using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameVoicePlayer
	{
		public enum Voice
		{
			TakeOff = 0,
			Wave_50 = 1,
			Wave_100 = 2,
			Mode_Valkyrie_Start = 3,
			Mode_Valkyrie_Success1 = 4,
			Mode_Valkyrie_Success2 = 5,
			Mode_Valkyrie_Failed = 6,
			Mode_Diva = 7,
			Mode_Diva_Awake = 8,
			ActiveSkill = 9,
			GameOver = 10,
			GameClear_PerfectFullCombo = 11,
			GameClear_FullCombo = 12,
		}

		public enum Result
		{
			None = 0,
			Pilot = 1,
			Diva = 2,
		}

		private MusicVoiceChangerParam m_param; // 0x8

		// // RVA: 0x15518BC Offset: 0x15518BC VA: 0x15518BC
		public void Initialize(MusicVoiceChangerParam a_param)
		{
			m_param = a_param;
		}

		// // RVA: 0x15518C4 Offset: 0x15518C4 VA: 0x15518C4
		public Result ChangePlayVoice(Voice a_voice)
		{
			if(m_param != null)
			{
				int v = GetChangeVoiceId(a_voice, m_param.m_voice_diva);
				if(v < 0)
				{
					v = GetChangeVoiceId(a_voice, m_param.m_voice_pilot);
					if(v > -1)
					{
						SoundManager.Instance.voPilot.Play(PilotVoicePlayer.VoiceCategory.Change, v);
						return Result.Pilot;
					}
				}
				else
				{
					SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Change, v);
					return Result.Diva;
				}
			}
			return Result.None;
		}

		// // RVA: 0x1551A68 Offset: 0x1551A68 VA: 0x1551A68
		public int GetChangeVoiceId(RhythmGameVoicePlayer.Voice a_voice, MusicVoiceChangerParam.VoiceList a_list)
		{
			switch(a_voice)
			{
				case RhythmGameVoicePlayer.Voice.TakeOff:
					return a_list.m_take_off;
				case RhythmGameVoicePlayer.Voice.Wave_50:
					return a_list.m_fold_wave_50;
				case RhythmGameVoicePlayer.Voice.Wave_100:
					return a_list.m_fold_wave_100;
				case RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Start:
					return a_list.m_mode_valkyrie_start;
				case RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success1:
					return a_list.m_mode_valkyrie_success1;
				case RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Success2:
					return a_list.m_mode_valkyrie_success2;
				case RhythmGameVoicePlayer.Voice.Mode_Valkyrie_Failed:
					return a_list.m_mode_valkyrie_failed;
				case RhythmGameVoicePlayer.Voice.Mode_Diva:
					return a_list.m_mode_diva;
				case RhythmGameVoicePlayer.Voice.Mode_Diva_Awake:
					return a_list.m_mode_diva_awake;
				case RhythmGameVoicePlayer.Voice.ActiveSkill:
					return a_list.m_active_skill;
				case RhythmGameVoicePlayer.Voice.GameOver:
					return a_list.m_game_over;
				case RhythmGameVoicePlayer.Voice.GameClear_PerfectFullCombo:
					return a_list.m_game_clear_perfect_full_combo;
				case RhythmGameVoicePlayer.Voice.GameClear_FullCombo:
					return a_list.m_game_clear_full_combo;
				default:
					return -1;
			}
		}
	}
}
