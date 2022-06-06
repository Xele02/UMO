using UnityEngine;

namespace XeApp.Game.Common
{
	public class CheerPlayer
	{
		public class PlayerEx : VoicePlayerBase
		{
			// // Methods

			// // RVA: 0xE6591C Offset: 0xE6591C VA: 0xE6591C
			// public void Play(string a_name) { }

			// // RVA: 0xE65924 Offset: 0xE65924 VA: 0xE65924
			// public void Stop() { }

			// // RVA: 0xE65B8C Offset: 0xE65B8C VA: 0xE65B8C
			// public void ChangeVolume(float sec, float targetVol, Action onEnd) { }

			// // RVA: 0xE65C38 Offset: 0xE65C38 VA: 0xE65C38
			// public void FadeOut(float sec, Action onStop) { }

			// // RVA: 0xE65CC4 Offset: 0xE65CC4 VA: 0xE65CC4
			// public void .ctor() { }
		}

		public const int MAX = 3;
		private PlayerEx[] m_player; // 0x8
		private bool m_create; // 0xC
		private bool m_load_request; // 0xD
		private int m_load_cnt; // 0x10

		// // Methods

		// // RVA: 0xE653C0 Offset: 0xE653C0 VA: 0xE653C0
		// private bool InvalidIndex(int a_index) { }

		// // RVA: 0xE653D0 Offset: 0xE653D0 VA: 0xE653D0
		public void Create(GameObject a_sound_manager)
		{
			UnityEngine.Debug.LogWarning("TODO CheerPlayer.Create");
		}

		// // RVA: 0xE654CC Offset: 0xE654CC VA: 0xE654CC
		// public void RequestChangeCueSheet() { }

		// // RVA: 0xE655EC Offset: 0xE655EC VA: 0xE655EC
		// public bool IsLoaded() { }

		// // RVA: 0xE65614 Offset: 0xE65614 VA: 0xE65614
		// public bool IsPlaying() { }

		// // RVA: 0xE656A4 Offset: 0xE656A4 VA: 0xE656A4
		// public bool IsFading() { }

		// // RVA: 0xE65734 Offset: 0xE65734 VA: 0xE65734
		// public void Play(int a_index, int voiceId) { }

		// // RVA: 0xE658A4 Offset: 0xE658A4 VA: 0xE658A4
		// public void Stop(int a_index) { }

		// // RVA: 0xE6592C Offset: 0xE6592C VA: 0xE6592C
		// public void Stop() { }

		// // RVA: 0xE659AC Offset: 0xE659AC VA: 0xE659AC
		// public void Pause() { }

		// // RVA: 0xE65A4C Offset: 0xE65A4C VA: 0xE65A4C
		// public void Resume() { }

		// // RVA: 0xE65AEC Offset: 0xE65AEC VA: 0xE65AEC
		// public void ChangeVolume(float sec, float targetVol) { }

		// // RVA: 0xE65BAC Offset: 0xE65BAC VA: 0xE65BAC
		// public void FadeOut(float sec) { }

		// // RVA: 0xE65C40 Offset: 0xE65C40 VA: 0xE65C40
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73AA94 Offset: 0x73AA94 VA: 0x73AA94
		// // RVA: 0xE65CB4 Offset: 0xE65CB4 VA: 0xE65CB4
		// private void <RequestChangeCueSheet>b__8_0() { }
	}
}
