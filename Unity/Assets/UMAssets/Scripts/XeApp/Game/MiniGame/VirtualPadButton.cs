using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.MiniGame
{
	public class VirtualPadButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private int buttonId; // 0xC
		private bool isPress; // 0x10

		public int ButtonId { get { return buttonId; } } //0xC8E6D8
		public bool IsPress { get { return isPress; } set { isPress = value; } } //0xC8E6E0 0xC92E08

		// RVA: 0xC92E18 Offset: 0xC92E18 VA: 0xC92E18 Slot: 4
		public void OnPointerDown(PointerEventData eventData)
		{
			isPress = true;
		}

		// RVA: 0xC92E24 Offset: 0xC92E24 VA: 0xC92E24 Slot: 5
		public void OnPointerUp(PointerEventData eventData)
		{
			isPress = false;
		}
	}
}
