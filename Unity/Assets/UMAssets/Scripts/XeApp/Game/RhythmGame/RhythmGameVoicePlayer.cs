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

		// // Fields
		// private MusicVoiceChangerParam m_param; // 0x8

		// // Methods

		// // RVA: 0x15518BC Offset: 0x15518BC VA: 0x15518BC
		// public void Initialize(MusicVoiceChangerParam a_param) { }

		// // RVA: 0x15518C4 Offset: 0x15518C4 VA: 0x15518C4
		public Result ChangePlayVoice(Voice a_voice)
		{
			UnityEngine.Debug.LogError("TODO");
			return Result.None;
		}

		// // RVA: 0x1551A68 Offset: 0x1551A68 VA: 0x1551A68
		// public int GetChangeVoiceId(RhythmGameVoicePlayer.Voice a_voice, MusicVoiceChangerParam.VoiceList a_list) { }

		// // RVA: 0x1551C04 Offset: 0x1551C04 VA: 0x1551C04
		// public void .ctor() { }
	}
}
