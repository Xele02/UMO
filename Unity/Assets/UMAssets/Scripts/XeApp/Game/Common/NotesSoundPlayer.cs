using System.Collections.Generic;
using CriWare;

namespace XeApp.Game.Common
{
	public class NotesSoundPlayer
	{
		private enum NoteSEType
		{
			Exempt = 0,
			LongLoop = 1,
			Bad = 2,
			Good = 3,
			Great = 4,
			Perfect = 5,
			FlickGreat = 6,
			FlickPerfect = 7,
			Perfect_Great = 8,
			Great_Great = 9,
			Perfect_Perfect = 10,
			FlickPerfect_FlickGreat = 11,
			FlickGreat_FlickGreat = 12,
			Perfect_FlickPerfect = 13,
			Great_FlickPerfect = 14,
			Great_FlickGreat = 15,
			Perfect_FlickGreat = 16,
			FlickPerfect_FlickPerfect = 17,
			Num = 18,
			None = -1,
		}

		private enum MixID
		{
			none = 0,
			great = 1,
			perfect = 2,
			flickgreat = 3,
			flickperfect = 4,
			num = 5,
		}

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
		private CriAtomExPlayback loopSEPlayback; // 0x14
		private CriAtomSource sePlayerLongNotes; // 0x18
		public static bool isNewNoteSoundEnable = true; // 0x0
		public static int[] noteTouchSEIndex = new int[18] { 4, 5, 3, 2, 1, 0, 7, 6, 14, 15, 13, 17, 18, 19, 21, 22, 20, 16 }; // 0x4
		private static NoteSEType[] mixTable = new NoteSEType[25] { 
			NoteSEType.None,
			NoteSEType.Great,
			NoteSEType.Perfect,
			NoteSEType.FlickGreat,
			NoteSEType.FlickPerfect,
			NoteSEType.Great,
			NoteSEType.Great_Great,
			NoteSEType.Perfect_Great,
			NoteSEType.Great_FlickGreat,
			NoteSEType.Great_FlickPerfect,
			NoteSEType.Perfect,
			NoteSEType.Perfect_Great,
			NoteSEType.Perfect_Perfect,
			NoteSEType.Perfect_FlickGreat,
			NoteSEType.Perfect_FlickPerfect,
			NoteSEType.FlickGreat,
			NoteSEType.Great_FlickGreat,
			NoteSEType.Perfect_FlickGreat,
			NoteSEType.FlickGreat_FlickGreat,
			NoteSEType.FlickPerfect_FlickGreat,
			NoteSEType.FlickPerfect,
			NoteSEType.Great_FlickPerfect,
			NoteSEType.Perfect_FlickPerfect,
			NoteSEType.FlickPerfect_FlickGreat,
			NoteSEType.FlickPerfect_FlickPerfect }; // 0x8
		private float[] loopSeVoumeTable = new float[2] { 1.0f, 2.0f }; // 0x1C

		// // RVA: 0xAED608 Offset: 0xAED608 VA: 0xAED608
		public void PreSetup()
		{
			requestBuffer.Clear();
			if(sePlayerLongNotes == null)
				sePlayerLongNotes = SoundManager.Instance.sePlayerLongNotes;
		}

		// // RVA: 0xAED6F4 Offset: 0xAED6F4 VA: 0xAED6F4
		public void OnJudge(int trackId, int result, bool isLongBegin, bool isLongEnd, bool isLongContinue, bool isFlick, bool isMiss)
		{
			int val = 0;
			if (isLongContinue)
				val |= 16;
			if (isMiss)
				val |= 8;
			if (isFlick)
				val |= 4;
			val |= result << 16;
			val |= trackId << 24;
			val |= isLongBegin ? 1 : 0;
			val |= isLongEnd ? 2 : 0;
			requestBuffer.Add(val);
		}

		// // RVA: 0xAED7CC Offset: 0xAED7CC VA: 0xAED7CC
		public void PostSetup(BgmPlayer bgmPlayer, bool isVolumeZero)
		{
			int off = 0;
			int on = 0;
			int good = 0;
			int bad = 0;
			int flickGreat = 0;
			int flickPerfect = 0;
			int great = 0;
			int perfect = 0;
			for(int i = 0; i < requestBuffer.Count; i++)
			{
				int trackId = requestBuffer[i] >> 24;
				if((requestBuffer[i] & 8) == 0 && (requestBuffer[i] & 17) != 0) // not miss & long begin | continue
				{
					int idx = trackId & 1;
					if(trackId < 4)
						idx = trackId / 2;
					on |= 1 << idx;
				}
				bool notLongEnd = (requestBuffer[i] & 2) == 0;
				if(notLongEnd)
					notLongEnd = (requestBuffer[i] & 16) == 0 && ((requestBuffer[i] & 8) >> 3) == 0; // not miss & !long continue
				if(!notLongEnd)
				{
					int idx = trackId & 1;
					if(trackId < 4)
						idx = trackId / 2;
					off |= 1 << idx;
				}
				int result = ((requestBuffer[i] >> 16) & 0xff) - 1;
				if((requestBuffer[i] & 4) == 0) // not flick
				{
					switch(result)
					{
						case 0:
							bad++;
							break;
						case 1:
							good++;
							break;
						case 2:
							great++;
							break;
						case 3:
							perfect++;
							break;
					}
				}
				else
				{
					switch(result)
					{
						case 0:
							bad++;
							break;
						case 1:
							good++;
							break;
						case 2:
							flickGreat++;
							break;
						case 3:
							flickPerfect++;
							break;
					}
				}
			}
			ControlLongLoopSE(bgmPlayer, isVolumeZero, on, off);
			if(!isVolumeZero)
			{
				int numPlayed = TryPlayPerfectGreat(great, perfect, flickGreat, flickPerfect);
				if(good > 0 && numPlayed < 2)
				{
					PlaySE(NoteSEType.Good, perfect);
					numPlayed++;
				}
				if(bad > 0 && numPlayed < 2)
				{
					PlaySE(NoteSEType.Bad, perfect);
				}
			}
			requestBuffer.Clear();
		}

		// // RVA: 0xAEDFE0 Offset: 0xAEDFE0 VA: 0xAEDFE0
		public void Pause()
		{
			loopSEPlayback.Pause();
		}

		// // RVA: 0xAEDFEC Offset: 0xAEDFEC VA: 0xAEDFEC
		public void Resume()
		{
			loopSEPlayback.Pause(false);
		}

		// // RVA: 0xAEDEC8 Offset: 0xAEDEC8 VA: 0xAEDEC8
		private void PlaySE(NoteSEType type, int count)
		{
			if(type == NoteSEType.None)
				return;
			SoundManager.Instance.sePlayerNotes.Play(noteTouchSEIndex[(int)type]);
		}

		// // RVA: 0xAEDFFC Offset: 0xAEDFFC VA: 0xAEDFFC
		// private int GetBitsCount(int bits) { }

		// // RVA: 0xAEE01C Offset: 0xAEE01C VA: 0xAEE01C
		private float GetLoopSEVolume(int n)
		{
			return loopSeVoumeTable[1 < n ? 1 : 0];
		}

		// // RVA: 0xAEDB50 Offset: 0xAEDB50 VA: 0xAEDB50
		private void ControlLongLoopSE(BgmPlayer bgmPlayer, bool isVolumeZero, int on, int off)
		{
			int p = preLoopSeState;
			preLoopSeState = loopSeState;
			loopSeState = (loopSeState | on) & ~off;
			int numBefore = 0;
			for(int i = 6; i != 0;)
			{
				i--;
				numBefore += (p & 1);
				p = p >> 1;
			}
			int numAfter = 0;
			p = preLoopSeState;
			for(int i = 6; i != 0;)
			{
				i--;
				numAfter += (p & 1);
				p = p >> 1;
			}
			if(numBefore != 0 || numAfter == 0)
			{
				if(numBefore != numAfter && numAfter != 0)
				{
					SoundManager.Instance.sePlayerLongNotes.volume = GetLoopSEVolume(numAfter);
				}
				if(numBefore != 0 && numAfter == 0)
				{
					loopSEPlayback.Stop();
				}
				return;
			}
			loopSEPlayback.Stop();
			sePlayerLongNotes.volume = GetLoopSEVolume(numAfter);
			if(!isVolumeZero)
			{
				loopSEPlayback = sePlayerLongNotes.Play(5);
			}
			loopSEPlayback.Pause(bgmPlayer.source.IsPaused());
		}

		// // RVA: 0xAEDD20 Offset: 0xAEDD20 VA: 0xAEDD20
		private int TryPlayPerfectGreat(int great, int perfect, int flickGreat, int flickPerfect)
		{
			int res;
			int a1;
			if(flickPerfect < 1)
			{
				if(flickGreat < 1)
				{
					if(perfect < 1)
					{
						res = 0;
						if(great < 1)
						{
							a1 = 0;
						}
						else
						{
							res = great != 1 ? 1 : 0;
							a1 = 1;
						}
					}
					else
					{
						a1 = 2;
						if(perfect == 1)
						{
							res = great > 0 ? 1 : 0;
						}
						else
						{
							res = 2;
						}
					}
					//LAB_00aeddc8
				}
				else
				{
					a1 = 3;
					if(flickGreat == 1)
					{
						res = 2;
						if(perfect < 1)
							res = 0;
						//LAB_00aeddc0
					}
					else
					{	
						res = 3;
					}
				}
			}
			else
			{
				if(flickGreat < 1)
				{
					res = 2;
					if(perfect < 1)
					{
						res = 0;
					}
					a1 = 4;
					if(flickPerfect != 1)
						res = 4;
					//LAB_00aeddc0
					if(great > 0)
						res = 1;
					//LAB_00aeddc8
				}
				else
				{
					a1 = 4;
					res = 3;
				}
			}
			//LAB_00aeddc8
			int idx = a1 * 5 + res;
			NoteSEType mix = mixTable[idx];
			if(mix == NoteSEType.None)
				return 0;
			else
			{
				PlaySE(mix, perfect);
				if(res != 0)
					res = 1;
				if(a1 != 0)
					res++;
				return res;
			}
		}

		// // RVA: 0xAEE070 Offset: 0xAEE070 VA: 0xAEE070
		public void StopSound()
		{
			loopSeState = 0;
			preLoopSeState = 0;
			SoundManager.Instance.sePlayerLongNotes.Stop();
			SoundManager.Instance.sePlayerLongNotes.Pause(false);
		}

		// // RVA: 0xAEDB38 Offset: 0xAEDB38 VA: 0xAEDB38
		public static int LineIDToLineGroup(int trackLineID)
		{
			return trackLineID < 4 ? trackLineID / 2 : trackLineID & 1;
		}
	}
}
