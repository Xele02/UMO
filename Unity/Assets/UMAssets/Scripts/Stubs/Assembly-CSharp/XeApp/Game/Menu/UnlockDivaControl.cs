using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class UnlockDivaControl : MenuDivaControlBase
	{
		private DivaUnlockEventListener divaUnlockEventListener; // 0x10

		// RVA: 0x125EA0C Offset: 0x125EA0C VA: 0x125EA0C
		public void StartAnim()
		{
			divaUnlockEventListener = DivaObject.divaPrefab.AddComponent<DivaUnlockEventListener>();
			DivaObject.PlayDivaUnlockAnim();
		}

		// RVA: 0x125EAE0 Offset: 0x125EAE0 VA: 0x125EAE0
		public float GetNormalizedTime()
		{
			return DivaObject.GetNormalizedTime();
		}

		// RVA: 0x125EB14 Offset: 0x125EB14 VA: 0x125EB14
		public bool IsMatchAnimStep(MenuDivaObject.eUnlockDivaAnimStep step)
		{
			return DivaObject.IsMatchUnlockDivaAnimStep(step);
		}

		// // RVA: 0x125EB50 Offset: 0x125EB50 VA: 0x125EB50
		public bool IsFiredStartTelop()
		{
			return divaUnlockEventListener.isFiredTelop;
		}

		// RVA: 0x125EB74 Offset: 0x125EB74 VA: 0x125EB74 Slot: 9
		protected override void OnEndControl()
		{
			UnityEngine.Object.Destroy(divaUnlockEventListener);
		}
	}
}
