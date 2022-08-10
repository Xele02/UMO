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
		private List<int> requestBuffer = new List<int>(16); // 0x8
		private int loopSeState; // 0xC
		private int preLoopSeState; // 0x10
		// private CriAtomExPlayback loopSEPlayback; // 0x14
		// private CriAtomSource sePlayerLongNotes; // 0x18
		public static bool isNewNoteSoundEnable; // 0x0
		private static int[] noteTouchSEIndex = new int[18] { 4, 5, 3, 2, 1, 0, 7, 8, 0xe, 0xf, 0xd, 0x11, 0x12, 0x13, 0x15, 0x16, 0x14, 0x10 }; // 0x4
		// private static NotesSoundPlayer.NoteSEType[] mixTable = new NotesSoundPlayer.NoteSEType[25] {90F02A84C31F5632D4095B6046021D892411CBCC}; // 0x8
		private float[] loopSeVoumeTable = new float[2] { 1.0f, 2.0f }; // 0x1C

		// // RVA: 0xAED608 Offset: 0xAED608 VA: 0xAED608
		public void PreSetup()
		{
			TodoLogger.Log(0, "NoteSoundPlayer PreSetup");
		}

		// // RVA: 0xAED6F4 Offset: 0xAED6F4 VA: 0xAED6F4
		// public void OnJudge(int trackId, int result, bool isLongBegin, bool isLongEnd, bool isLongContinue, bool isFlick, bool isMiss) { }

		// // RVA: 0xAED7CC Offset: 0xAED7CC VA: 0xAED7CC
		public void PostSetup(BgmPlayer bgmPlayer, bool isVolumeZero)
		{
			TodoLogger.Log(0, "TODO");
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
	}
}
