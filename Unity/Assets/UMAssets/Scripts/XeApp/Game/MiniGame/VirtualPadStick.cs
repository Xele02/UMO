using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.MiniGame
{
	public class VirtualPadStick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
	{
		private Vector2 axis = new Vector2(0, 0); // 0xC
		private Vector2 beginDragPosition; // 0x14
		private Vector2 size; // 0x1C

		public Vector2 Axis { get { return axis; } } //0xC8E6BC

		// RVA: 0xC92E38 Offset: 0xC92E38 VA: 0xC92E38
		private void Start()
		{
			EventSystem.current.pixelDragThreshold = 0;
		}

		// RVA: 0xC92ED8 Offset: 0xC92ED8 VA: 0xC92ED8
		private void OnDestroy()
		{
			EventSystem.current.pixelDragThreshold = 16;
		}

		// RVA: 0xC92F78 Offset: 0xC92F78 VA: 0xC92F78 Slot: 5
		public void OnBeginDrag(PointerEventData eventData)
		{
			beginDragPosition = eventData.position;
			axis = GetPadAxis(GetTouchPosition(eventData));
		}

		// RVA: 0xC931A8 Offset: 0xC931A8 VA: 0xC931A8 Slot: 7
		public void OnDrag(PointerEventData eventData)
		{
			axis = GetPadAxis(GetTouchPosition(eventData));
		}

		// RVA: 0xC931F0 Offset: 0xC931F0 VA: 0xC931F0 Slot: 6
		public void OnEndDrag(PointerEventData eventData)
		{
			axis = Vector2.zero;
		}

		// RVA: 0xC92FF4 Offset: 0xC92FF4 VA: 0xC92FF4
		private Vector2 GetTouchPosition(PointerEventData eventData)
		{
			Vector2 res;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, Camera.main, out res);
			return res;
		}

		// RVA: 0xC93288 Offset: 0xC93288 VA: 0xC93288 Slot: 8
		public void OnPointerUp(PointerEventData eventData)
		{
			axis = Vector2.zero;
		}

		// RVA: 0xC93320 Offset: 0xC93320 VA: 0xC93320 Slot: 4
		public void OnPointerDown(PointerEventData eventData)
		{
			axis = GetPadAxis(GetTouchPosition(eventData));
		}

		// RVA: 0xC92DC4 Offset: 0xC92DC4 VA: 0xC92DC4
		public void ResetAxis()
		{
			axis = Vector2.zero;
		}

		// RVA: 0xC930FC Offset: 0xC930FC VA: 0xC930FC
		private Vector2 GetPadAxis(Vector2 touchPosition)
		{
			Vector2 res = new Vector2(0, 0);
			if (-16 <= touchPosition.x)
			{
				if (16 <= touchPosition.x)
					res.x = 1;
			}
			else
				res.x = -1;
			if (-16 <= touchPosition.y)
			{
				if (16 <= touchPosition.y)
					res.y = 1;
			}
			else
				res.y = -1;
			return res;
		}
	}
}
