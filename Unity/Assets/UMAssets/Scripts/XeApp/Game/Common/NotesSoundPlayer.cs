using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class NotesSoundPlayer
	{
		private const int TRACK_ID_SFT = 24;
		private const int NOTE_RESULT_SFT = 16;
		private const int LONG_BEGIN = 1;
		private const int LONG_END = 2;
		private const int FLICK = 4;
		private const int MISS = 8;
		private const int LONG_CONTINUE = 16;
		private List<int> requestBuffer; // 0x8
		private int loopSeState; // 0xC
		private int preLoopSeState; // 0x10
		// private CriAtomExPlayback loopSEPlayback; // 0x14
		// private CriAtomSource sePlayerLongNotes; // 0x18
		public static bool isNewNoteSoundEnable; // 0x0
		private static int[] noteTouchSEIndex; // 0x4
		// private static NotesSoundPlayer.NoteSEType[] mixTable; // 0x8
		private float[] loopSeVoumeTable; // 0x1C

		// Methods

		// // RVA: 0xAED500 Offset: 0xAED500 VA: 0xAED500
		// public void .ctor() { }

		// // RVA: 0xAED608 Offset: 0xAED608 VA: 0xAED608
		// public void PreSetup() { }

		// // RVA: 0xAED6F4 Offset: 0xAED6F4 VA: 0xAED6F4
		// public void OnJudge(int trackId, int result, bool isLongBegin, bool isLongEnd, bool isLongContinue, bool isFlick, bool isMiss) { }

		// // RVA: 0xAED7CC Offset: 0xAED7CC VA: 0xAED7CC
		public void PostSetup(BgmPlayer bgmPlayer, bool isVolumeZero)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAEDFE0 Offset: 0xAEDFE0 VA: 0xAEDFE0
		// public void Pause() { }

		// // RVA: 0xAEDFEC Offset: 0xAEDFEC VA: 0xAEDFEC
		// public void Resume() { }

		// // RVA: 0xAEDEC8 Offset: 0xAEDEC8 VA: 0xAEDEC8
		// private void PlaySE(NotesSoundPlayer.NoteSEType type, int count) { }

		// // RVA: 0xAEDFFC Offset: 0xAEDFFC VA: 0xAEDFFC
		// private int GetBitsCount(int bits) { }

		// // RVA: 0xAEE01C Offset: 0xAEE01C VA: 0xAEE01C
		// private float GetLoopSEVolume(int n) { }

		// // RVA: 0xAEDB50 Offset: 0xAEDB50 VA: 0xAEDB50
		// private void ControlLongLoopSE(BgmPlayer bgmPlayer, bool isVolumeZero, int on, int off) { }

		// // RVA: 0xAEDD20 Offset: 0xAEDD20 VA: 0xAEDD20
		// private int TryPlayPerfectGreat(int great, int perfect, int flickGreat, int flickPerfect) { }

		// // RVA: 0xAEE070 Offset: 0xAEE070 VA: 0xAEE070
		// public void StopSound() { }

		// // RVA: 0xAEDB38 Offset: 0xAEDB38 VA: 0xAEDB38
		// public static int LineIDToLineGroup(int trackLineID) { }

		// // RVA: 0xAEE11C Offset: 0xAEE11C VA: 0xAEE11C
		// private static void .cctor() { }
	}
}
