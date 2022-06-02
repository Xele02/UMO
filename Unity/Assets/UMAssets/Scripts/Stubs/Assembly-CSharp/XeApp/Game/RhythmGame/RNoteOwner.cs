using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteOwner : MonoBehaviour
	{
		[SerializeField]
		private List<RNote> rNoteList;
		[SerializeField]
		private GameObject judgePointObject;
		[SerializeField]
		private GameObject judgePointObjectWide;
		[SerializeField]
		private Transform[] judgePointTransforms;
		[SerializeField]
		private float[] neutralCounter;
		public bool isPause;
		public int checkStartNotesIndex;
		public int checkEndNotesIndex;
		public bool assignedCenterLiveSkillNote;
	}
}
