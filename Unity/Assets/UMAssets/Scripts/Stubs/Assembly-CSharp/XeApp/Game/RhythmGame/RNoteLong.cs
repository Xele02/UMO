using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RNoteLong : PoolObject
	{
		[SerializeField]
		protected int divid;
		public RNoteObject firstRNoteObject;
		public RNoteObject lastRNoteObject;
		[SerializeField]
		private int touchFingerId_;
	}
}
