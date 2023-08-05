using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class StayForReleaseButton : StayButton
	{
		public bool isRelease { get; private set; } // 0x92

		// RVA: 0x12E368C Offset: 0x12E368C VA: 0x12E368C Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			m_isPointerInside = true;
			isRelease = false;
			base.OnPointerDown(eventData);
		}

		// RVA: 0x12E36A4 Offset: 0x12E36A4 VA: 0x12E36A4 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			isRelease = true;
			base.OnPointerUp(eventData);
		}
	}
}
