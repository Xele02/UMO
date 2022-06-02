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

		public RNote(MusicScoreData.InputNoteInfo noteInfo, RNoteResultJudge resultJudge, RNoteResultJudge passJudge, MusicData.NoteModeType modeType, int indexInMode)
		{
		}

		[SerializeField]
		private PassingStatus passingStatus_;
		[SerializeField]
		public MusicData.NoteModeType modeType;
	}
}
