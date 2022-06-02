using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RNoteCluster : PoolObject
	{
		[SerializeField]
		private bool isBeganTouched_;
		[SerializeField]
		private int touchFingerId_;
	}
}
