using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieModeEventListener : MonoBehaviour
	{
		public Action onPlayerCutInStart { private get; set; } // 0xC
		public Action onEnemyCutInStart { private get; set; } // 0x10
		public Action onEnemyLockOnStart { private get; set; } // 0x14

		//// RVA: 0x1CE25F0 Offset: 0x1CE25F0 VA: 0x1CE25F0
		public void Ev_PlayerCutInStart()
		{
			if(onPlayerCutInStart != null)
				onPlayerCutInStart();
		}

		//// RVA: 0x1CE2604 Offset: 0x1CE2604 VA: 0x1CE2604
		public void Ev_EnemyCutInStart()
		{
			if(onEnemyCutInStart != null)
				onEnemyCutInStart();
		}

		//// RVA: 0x1CE2618 Offset: 0x1CE2618 VA: 0x1CE2618
		public void Ev_EnemyLockOnStart()
		{
			if(onEnemyLockOnStart != null)
				onEnemyLockOnStart();
		}
	}
}
