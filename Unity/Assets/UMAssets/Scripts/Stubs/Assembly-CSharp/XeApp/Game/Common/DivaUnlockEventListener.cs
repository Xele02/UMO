using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaUnlockEventListener : MonoBehaviour
	{
		public bool isFiredTelop; // 0xC

		// RVA: 0x1C09D68 Offset: 0x1C09D68 VA: 0x1C09D68
		public void StartTelop()
		{
			isFiredTelop = true;
		}
	}
}
