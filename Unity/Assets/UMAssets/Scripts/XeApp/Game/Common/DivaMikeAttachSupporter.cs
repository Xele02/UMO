using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaMikeAttachSupporter : MonoBehaviour
	{
		public DivaObject diva; // 0xC

		//// RVA: 0x1BF0120 Offset: 0x1BF0120 VA: 0x1BF0120
		public void SetActiveMikePrefab(bool active)
		{
			diva.SetActiveMikePrefab(active);
		}

		//// RVA: 0x1BF020C Offset: 0x1BF020C VA: 0x1BF020C
		public void HideMike()
		{
			SetActiveMikePrefab(false);
		}

		//// RVA: 0x1BF0214 Offset: 0x1BF0214 VA: 0x1BF0214
		public void AttachMikeToLeftHand()
		{
			diva.AttachMikeToLeftHand();
		}

		//// RVA: 0x1BF0374 Offset: 0x1BF0374 VA: 0x1BF0374
		public void AttachMikeToRightHand()
		{
			diva.AttachMikeToRightHand();
		}

		//// RVA: 0x1BF04D4 Offset: 0x1BF04D4 VA: 0x1BF04D4
		public void AttachMikeToMikeStand()
		{
			diva.AttachToMikeStand();
		}
	}
}
