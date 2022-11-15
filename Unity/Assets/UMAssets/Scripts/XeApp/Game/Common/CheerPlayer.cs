using System;
using System.Text;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class CheerPlayer
	{
		public class PlayerEx : VoicePlayerBase
		{
			// // RVA: 0xE6591C Offset: 0xE6591C VA: 0xE6591C
			public void Play(string a_name)
			{
				PlayCue(a_name);
			}

			// // RVA: 0xE65924 Offset: 0xE65924 VA: 0xE65924
			public void Stop()
			{
				StopCue();
			}

			// // RVA: 0xE65B8C Offset: 0xE65B8C VA: 0xE65B8C
			public new void ChangeVolume(float sec, float targetVol, Action onEnd)
			{
				base.ChangeVolume(sec, targetVol, onEnd);
			}

			// // RVA: 0xE65C38 Offset: 0xE65C38 VA: 0xE65C38
			// public void FadeOut(float sec, Action onStop) { }
		}

		public const int MAX = 3;
		private PlayerEx[] m_player = new PlayerEx[MAX]; // 0x8
		private bool m_create; // 0xC
		private bool m_load_request; // 0xD
		private int m_load_cnt; // 0x10

		// // RVA: 0xE653C0 Offset: 0xE653C0 VA: 0xE653C0
		// private bool InvalidIndex(int a_index) { }

		// // RVA: 0xE653D0 Offset: 0xE653D0 VA: 0xE653D0
		public void Create(GameObject a_sound_manager)
		{
			for(int i = 0; i < MAX; i++)
			{
				m_player[i] = a_sound_manager.AddComponent<PlayerEx>();
			}
			m_create = true;
		}

		// // RVA: 0xE654CC Offset: 0xE654CC VA: 0xE654CC
		public void RequestChangeCueSheet()
		{
			if(m_create && !m_load_request)
			{
				for(int i = 0; i < MAX; i++)
				{
					m_player[i].RequestChangeCueSheet("cs_se_game", () => {
						//0xE65CB4
						m_load_cnt++;
					});
				}
				m_load_request = true;
			}
		}

		// // RVA: 0xE655EC Offset: 0xE655EC VA: 0xE655EC
		public bool IsLoaded()
		{
			return !m_load_request || m_load_cnt == MAX;
		}

		// // RVA: 0xE65614 Offset: 0xE65614 VA: 0xE65614
		// public bool IsPlaying() { }

		// // RVA: 0xE656A4 Offset: 0xE656A4 VA: 0xE656A4
		// public bool IsFading() { }

		// // RVA: 0xE65734 Offset: 0xE65734 VA: 0xE65734
		public void Play(int a_index, int voiceId)
		{
			if(a_index < MAX && m_create)
			{
				Stop(a_index);
				StringBuilder str = new StringBuilder(32);
				str.AppendFormat("se_mv_{0:D3}", voiceId);
				m_player[a_index].Play(str.ToString());
			}
		}

		// // RVA: 0xE658A4 Offset: 0xE658A4 VA: 0xE658A4
		public void Stop(int a_index)
		{
			if(a_index < MAX && m_create)
			{
				m_player[a_index].Stop();
			}
		}

		// // RVA: 0xE6592C Offset: 0xE6592C VA: 0xE6592C
		public void Stop()
		{
			if (!m_create)
				return;
			for(int i = 0; i < m_player.Length; i++)
			{
				m_player[i].Stop();
			}
		}

		// // RVA: 0xE659AC Offset: 0xE659AC VA: 0xE659AC
		public void Pause()
		{
			for (int i = 0; i < m_player.Length; i++)
			{
				m_player[i].source.Pause(true);
			}
		}

		// // RVA: 0xE65A4C Offset: 0xE65A4C VA: 0xE65A4C
		public void Resume()
		{
			for (int i = 0; i < m_player.Length; i++)
			{
				m_player[i].source.Pause(false);
			}
		}

		// // RVA: 0xE65AEC Offset: 0xE65AEC VA: 0xE65AEC
		public void ChangeVolume(float sec, float targetVol)
		{
			if(m_create)
			{
				for(int i = 0; i < MAX; i++)
				{
					m_player[i].ChangeVolume(sec, targetVol, null);
				}
			}
		}

		// // RVA: 0xE65BAC Offset: 0xE65BAC VA: 0xE65BAC
		// public void FadeOut(float sec) { }
	}
}
