using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame.UI
{
	public class UIPriority : MonoBehaviour
	{
		[Serializable]
		public struct PrioritySet
		{
			public Renderer renderer;
			public int offset;
			public UIPriority.Priority priority;
		}

		public enum Priority
		{
			SystemUI = -2,
			Default = -1,
			TopMost = 0,
			UnderNotes = 1,
			CutIn = 2,
			FaceCutinOver = 3,
			FaceCutin = 4,
			FaceCutinUnder = 5,
		}

		[SerializeField]
		public PrioritySet[] m_meshPrioritySets;
		[SerializeField]
		public PrioritySet[] m_particlePrioritySets;
		[SerializeField]
		public PrioritySet[] m_linePrioritySets;
	}
}
