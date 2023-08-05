using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Core
{
	public class AnimatorPauseUnifier : PauseUnifierBase
	{
		private List<Animator> m_elements = new List<Animator>(); // 0x10

		// // RVA: 0xE0D3F0 Offset: 0xE0D3F0 VA: 0xE0D3F0 Slot: 9
		// public override void Register(GameObject root) { }

		// // RVA: 0xE0D4A0 Offset: 0xE0D4A0 VA: 0xE0D4A0 Slot: 10
		// public override void UnregisterAll() { }

		// RVA: 0xE0D518 Offset: 0xE0D518 VA: 0xE0D518 Slot: 11
		protected override void InternalPause()
		{
			TodoLogger.LogError(0, "TODO");
		}

		// RVA: 0xE0D5F8 Offset: 0xE0D5F8 VA: 0xE0D5F8 Slot: 12
		protected override void InternalResume()
		{
			TodoLogger.LogError(0, "TODO");
		}
	}
}
