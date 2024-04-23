using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Core
{
	public class ParticlePauseUnifier : PauseUnifierBase
	{
		private class Data
		{
			public ParticleSystem particle; // 0x8
			public bool isPaused; // 0xC
		}

		private List<Data> m_elements = new List<Data>(); // 0x10


		// // RVA: 0x1D74284 Offset: 0x1D74284 VA: 0x1D74284 Slot: 9
		// public override void Register(GameObject root) { }

		// // RVA: 0x1D743C8 Offset: 0x1D743C8 VA: 0x1D743C8 Slot: 10
		// public override void UnregisterAll() { }

		// RVA: 0x1D74440 Offset: 0x1D74440 VA: 0x1D74440 Slot: 11
		protected override void InternalPause()
		{
			for(int i = 0; i < m_elements.Count; i++)
			{
				if(m_elements[i].particle.isPlaying)
				{
					m_elements[i].particle.Pause(false);
					m_elements[i].isPaused = true;
				}
			}
		}

		// RVA: 0x1D7456C Offset: 0x1D7456C VA: 0x1D7456C Slot: 12
		protected override void InternalResume()
		{
			for(int i = 0; i < m_elements.Count; i++)
			{
				if(m_elements[i].isPaused)
				{
					m_elements[i].particle.Play(false);
					m_elements[i].isPaused = false;
				}
			}
		}
	}
}
