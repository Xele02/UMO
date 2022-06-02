using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RNoteResultJudge
	{
		public RNoteResultJudge(List<int> startFrames, List<int> endFrames)
		{
		}

		[SerializeField]
		public int[] Perfect;
		[SerializeField]
		public int[] Great;
		[SerializeField]
		public int[] Good;
		[SerializeField]
		public int[] Bad;
	}
}
