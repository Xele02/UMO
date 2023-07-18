using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteResultJudge
	{
		public enum Timing
		{
			Start = 0,
			End = 1,
			Num = 2,
		}

		[SerializeField]
		public int[] Perfect = new int[2]; // 0x8
		[SerializeField]
		public int[] Great = new int[2]; // 0xC
		[SerializeField]
		public int[] Good = new int[2]; // 0x10
		[SerializeField]
		public int[] Bad = new int[2]; // 0x14

		// RVA: 0xDB3124 Offset: 0xDB3124 VA: 0xDB3124
		public RNoteResultJudge(List<int> startFrames, List<int> endFrames)
		{
			Bad[0] = startFrames[0];
			Good[0] = startFrames[1];
			Great[0] = startFrames[2];
			Perfect[0] = startFrames[3];

			Bad[1] = endFrames[0];
			Good[1] = endFrames[1];
			Great[1] = endFrames[2];
			Perfect[1] = endFrames[3];
		}

		// RVA: 0xDBDB6C Offset: 0xDBDB6C VA: 0xDBDB6C
		public RhythmGameConsts.NoteResult CalcEvaluation(int gapMilliSec, int skillEffect)
		{
			if (RuntimeSettings.CurrentSettings.ForcePerfectNote)
				return RhythmGameConsts.NoteResult.Perfect;

			if (Perfect[0] - skillEffect <= gapMilliSec)
				if (Perfect[1] + skillEffect >= gapMilliSec)
					return RhythmGameConsts.NoteResult.Perfect;

			if (Great[0] - skillEffect <= gapMilliSec)
				if (Great[1] + skillEffect >= gapMilliSec)
					return RhythmGameConsts.NoteResult.Great;

			if (Good[0] - skillEffect <= gapMilliSec)
				if (Good[1] + skillEffect >= gapMilliSec)
					return RhythmGameConsts.NoteResult.Good;

			if (Bad[0] - skillEffect <= gapMilliSec)
				if (Bad[1] + skillEffect >= gapMilliSec)
					return RhythmGameConsts.NoteResult.Bad;

			//return (RhythmGameConsts.NoteResult)((gapMilliSec >> 0x1f) & 7);
			return gapMilliSec > 0 ? RhythmGameConsts.NoteResult.Miss : RhythmGameConsts.NoteResult.Exempt;
		}
	}

}
