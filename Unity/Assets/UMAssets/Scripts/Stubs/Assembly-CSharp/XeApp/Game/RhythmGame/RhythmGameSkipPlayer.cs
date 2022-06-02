using UnityEngine;
using XeApp.Game;
using XeSys.uGUI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipPlayer : MonoBehaviour
	{
		[SerializeField]
		private RhythmGameSkipScene scene;
		[SerializeField]
		private RNoteOwner rNoteOwner;
		public int noteOffsetMillisec;
		public int currentRawMusicMillisec;
		public int continueCount;
		[SerializeField]
		private CRIAtomMemoryPoolInfo memPoolInfo;
		[SerializeField]
		private UGUIFader uguiFader;
	}
}
