using System;
using XeApp.Game;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	[Serializable]
	public class RNote
	{
		public enum PassingStatus
		{
			Before = 0,
			Alive = 1,
			After = 2,
		}
		
		public class ModeInfo
		{
			public RhythmGameConsts.SpecialNoteType specialNoteType; // 0x8
			public int itemIndex = -1; // 0xC
			public int itemID; // 0x10
		}

		[SerializeField]
		private PassingStatus passingStatus_; // 0xC
		[SerializeField]
		private RhythmGameConsts.NoteResultEx m_result_ex = new RhythmGameConsts.NoteResultEx(); // 0x10
		[SerializeField]
		public MusicData.NoteModeType modeType; // 0x28
		private int[] indexInMode = new int[4]; // 0x2C
		private ModeInfo unknownModeInfo = new ModeInfo(); // 0x30
		private ModeInfo[] modeInfo = new ModeInfo[7]; // 0x34

		public MusicScoreData.InputNoteInfo noteInfo { get; private set; } // 0x8
		//public RNote.PassingStatus passingStatus { get; private set; } 0xF628AC 0xF77A28
		public RhythmGameConsts.NoteResult result { get { return m_result_ex.m_result; } private set { m_result_ex.m_result = value; } } //0xF77A30 0xF77A54
		//public RhythmGameConsts.NoteResultEx resultEx { get; } 0xF77A7C
		public RNoteResultJudge resultJudge { get; private set; } // 0x14
		public RNoteResultJudge passJudge { get; private set; } // 0x18
		public bool resultReset { get; private set; } // 0x1C
		public int gapMilliSec { get; private set; } // 0x20
		public float positionRate { get; private set; } // 0x24

		// RVA: 0xF60308 Offset: 0xF60308 VA: 0xF60308
		public RNote(MusicScoreData.InputNoteInfo noteInfo, RNoteResultJudge resultJudge, RNoteResultJudge passJudge, MusicData.NoteModeType modeType, int indexInMode)
		{
			this.noteInfo = noteInfo;
			this.resultJudge = resultJudge;
			this.passJudge = passJudge;
			this.modeType = modeType;
			for(int i = 0; i < 4; i++)
			{
				if((int)modeType == i)
				{
					this.indexInMode[i] = indexInMode;
				}
				else
				{
					this.indexInMode[i] = -1;
				}
			}
			unknownModeInfo.itemIndex = -1;
			unknownModeInfo.itemID = 0;
			unknownModeInfo.specialNoteType = RhythmGameConsts.SpecialNoteType.None;
			for(int i = 0; i < 7; i++)
			{
				modeInfo[i] = new ModeInfo();
			}
			Initialize();
		}

		//// RVA: 0xF77ACC Offset: 0xF77ACC VA: 0xF77ACC
		public void Initialize()
		{
			gapMilliSec = -0x7fffffff;
			positionRate = 0;
			passingStatus_ = 0;
			m_result_ex.Init(RhythmGameConsts.NoteResult.None);
		}

		//// RVA: 0xF62804 Offset: 0xF62804 VA: 0xF62804
		//public void Update(int musicTimeMilliSec, int noteDisplayMilliSec, int skillEffect) { }

		//// RVA: 0xF633BC Offset: 0xF633BC VA: 0xF633BC
		//public void Spawn() { }

		//// RVA: 0xF77B58 Offset: 0xF77B58 VA: 0xF77B58
		//public void Judged(RhythmGameConsts.NoteResultEx a_result_ex) { }

		//// RVA: 0xF77B8C Offset: 0xF77B8C VA: 0xF77B8C
		//public int GetLineNo() { }

		//// RVA: 0xF77BB8 Offset: 0xF77BB8 VA: 0xF77BB8
		public int GetIndexInMode(MusicData.NoteModeType mode)
		{
			return indexInMode[(int)mode];
		}

		//// RVA: 0xF62FB4 Offset: 0xF62FB4 VA: 0xF62FB4
		//public RhythmGameConsts.NoteResult CalcEvaluation(int skillEffect) { }

		//// RVA: 0xF77B10 Offset: 0xF77B10 VA: 0xF77B10
		//public bool IsInScreenNote(int musicMilliSec, int noteDisplayMilliSec) { }

		//// RVA: 0xF77C00 Offset: 0xF77C00 VA: 0xF77C00
		//public void SetModeAttr(KLJCBKMHKNK.HHMPIIILOLD modeType, RhythmGameConsts.SpecialNoteType spType) { }

		//// RVA: 0xF77C60 Offset: 0xF77C60 VA: 0xF77C60
		//public void SetModeItemInfo(KLJCBKMHKNK.HHMPIIILOLD modeType, int itemId, int itemIndex) { }

		//// RVA: 0xF77D14 Offset: 0xF77D14 VA: 0xF77D14
		public ModeInfo CurrentModeInfo(RhythmGameMode mode)
		{
			if(!mode.isAllItemMode)
			{
				switch (modeType)
				{
					case MusicData.NoteModeType.Normal:
						return modeInfo[0];
					case MusicData.NoteModeType.Valkyrie:
						if (!mode.IsNormal())
						{
							if (mode.IsNone())
							{
								return modeInfo[4];
							}
							if (mode.type == RhythmGameMode.Type.Valkyrie || mode.isValkyriePlayed)
							{
								return modeInfo[1];
							}
						}
						break;
					case MusicData.NoteModeType.Diva:
						if (!mode.IsNormal() && !mode.IsValkyrie())
						{
							if (mode.IsNone())
							{
								return modeInfo[5];
							}
							if (mode.type == RhythmGameMode.Type.Diva || mode.isDivaPlayed)
							{
								return modeInfo[2];
							}
							if (mode.type == RhythmGameMode.Type.AwakenDiva)
								return modeInfo[3];
						}
						break;
				}
				return unknownModeInfo;
			}
			else
			{
				return modeInfo[6];
			}
		}

		//// RVA: 0xF77FC4 Offset: 0xF77FC4 VA: 0xF77FC4
		//public void ResetSlideNoteResult() { }
	}
}
