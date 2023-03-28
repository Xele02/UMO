using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CharTouchButton : StayButton
	{
		public bool isTouch { get; private set; } // 0x92
		public Vector2 touchPosition { get; private set; } // 0x94

		// RVA: 0x10AC5B0 Offset: 0x10AC5B0 VA: 0x10AC5B0 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnPointerDown");
		}

		// RVA: 0x10AC614 Offset: 0x10AC614 VA: 0x10AC614 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnPointerUp");
		}
	}
}
