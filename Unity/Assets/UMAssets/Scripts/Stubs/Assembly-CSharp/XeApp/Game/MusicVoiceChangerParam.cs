using UnityEngine;
using System;

namespace XeApp.Game
{
	public class MusicVoiceChangerParam : ScriptableObject
	{
		[Serializable]
		public class VoiceList
		{
			[SerializeField]
			public int m_take_off;
			[SerializeField]
			public int m_fold_wave_50;
			[SerializeField]
			public int m_fold_wave_100;
			[SerializeField]
			public int m_mode_diva;
			[SerializeField]
			public int m_mode_diva_awake;
			[SerializeField]
			public int m_mode_valkyrie_start;
			[SerializeField]
			public int m_mode_valkyrie_success1;
			[SerializeField]
			public int m_mode_valkyrie_success2;
			[SerializeField]
			public int m_mode_valkyrie_failed;
			[SerializeField]
			public int m_game_over;
			[SerializeField]
			public int m_game_clear_perfect_full_combo;
			[SerializeField]
			public int m_game_clear_full_combo;
			[SerializeField]
			public int m_active_skill;
		}

		[SerializeField]
		public bool isTakeoffDivaVoice;
		[SerializeField]
		public int takeoffVoiceId;
		[SerializeField]
		public int enterdValkyrieModeVoiceId;
		[SerializeField]
		public int enterdDivaModeVoiceId;
		[SerializeField]
		public int enterdAwakenDivaModeVoiceId;
		[SerializeField]
		public int enterdFoldWaveId_50;
		[SerializeField]
		public int enterdFoldWaveId_100;
		[SerializeField]
		public VoiceList m_voice_diva;
		[SerializeField]
		public VoiceList m_voice_pilot;
	}
}
