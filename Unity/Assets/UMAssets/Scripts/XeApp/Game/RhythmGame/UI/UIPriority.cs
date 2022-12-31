using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame.UI
{
	[ExecuteInEditMode] // RVA: 0x650F48 Offset: 0x650F48 VA: 0x650F48
	public class UIPriority : MonoBehaviour
	{
		[Serializable]
		public struct PrioritySet
		{
			public Renderer renderer; // 0x0
			[RangeAttribute(-200, 200)] // RVA: 0x68F0F4 Offset: 0x68F0F4 VA: 0x68F0F4
			public int offset; // 0x4
			public Priority priority; // 0x8
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
		public PrioritySet[] m_meshPrioritySets; // 0xC
		[SerializeField]
		public PrioritySet[] m_particlePrioritySets; // 0x10
		[SerializeField]
		public PrioritySet[] m_linePrioritySets; // 0x14
		private readonly float[] m_zPositionTable = new float[6] { -5, 1000, 2950, 2960, 2970, 3000 }; // 0x18
		private const float m_sortingOrderRange = 200;

		// RVA: 0x1567A14 Offset: 0x1567A14 VA: 0x1567A14
		private void Start()
		{
			Apply();
		}

		//// RVA: 0x1567A18 Offset: 0x1567A18 VA: 0x1567A18
		private int CalcSortingOrder(UIPriority.Priority priority, float offset)
		{
			float f = (offset + 100) * 200;
			if(priority != Priority.Default)
				return Mathf.RoundToInt(f / 200) - Mathf.RoundToInt((int)priority * 200);
			return Mathf.RoundToInt(f / 200);
		}

		//// RVA: 0x15593BC Offset: 0x15593BC VA: 0x15593BC
		public void Apply()
		{
			for(int i = 0; i < m_meshPrioritySets.Length; i++)
			{
				if (m_meshPrioritySets[i].renderer != null)
					Apply(ref m_meshPrioritySets[i]);
			}
			for(int i = 0; i < m_particlePrioritySets.Length; i++)
			{
				if(m_particlePrioritySets[i].renderer != null)
					Apply(ref m_particlePrioritySets[i]);
			}
			for(int i = 0; i < m_linePrioritySets.Length; i++)
			{
				if (m_linePrioritySets[i].renderer != null)
					Apply(ref m_linePrioritySets[i]);
			}
		}

		//// RVA: 0x1567A74 Offset: 0x1567A74 VA: 0x1567A74
		private void Apply(ref UIPriority.PrioritySet set)
		{
			if (set.priority == Priority.SystemUI)
				set.renderer.sortingLayerName = "SystemUI";
			else if (set.priority == Priority.Default)
				set.renderer.sortingLayerName = "Default";
			else if (set.priority == Priority.TopMost)
				set.renderer.sortingLayerName = "Forward";
			else
				set.renderer.sortingLayerName = "Back";
			set.renderer.sortingOrder = CalcSortingOrder(set.priority, set.offset);
		}
	}
}
