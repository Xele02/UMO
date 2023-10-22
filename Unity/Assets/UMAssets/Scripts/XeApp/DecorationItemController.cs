using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp
{
	public class DecorationItemController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
	{
		public Action<Vector2> onPointerClick; // 0xC
		public Action<Vector2> onPointerDown; // 0x10
		public Action<Vector2> onBeginDrag; // 0x14
		public Action<Vector2> onDrag; // 0x18
		public Action onPointerUp; // 0x1C
		private BoxCollider2D m_collider; // 0x20

		// // RVA: 0x1AD1CCC Offset: 0x1AD1CCC VA: 0x1AD1CCC
		public void Setting(Vector2 size)
		{
			m_collider = GetComponent<BoxCollider2D>();
			m_collider.size = (size + DecorationConstants.ItemHitAddictionScale) * 0.01f;
			m_collider.offset = Vector2.zero;
		}

		// RVA: 0x1AD5180 Offset: 0x1AD5180 VA: 0x1AD5180 Slot: 9
		public virtual void SetEnable(bool isEnable)
		{
			m_collider.enabled = isEnable;
		}

		// RVA: 0x1AD51B4 Offset: 0x1AD51B4 VA: 0x1AD51B4 Slot: 4
		public void OnPointerClick(PointerEventData eventData)
		{
			if(
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1
#endif
				&& onPointerClick != null)
			{
				onPointerClick.Invoke(eventData.position);
			}
		}

		// RVA: 0x1AD52B4 Offset: 0x1AD52B4 VA: 0x1AD52B4 Slot: 5
		public void OnPointerDown(PointerEventData eventData)
		{
			if(
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1
#endif
				&& onPointerDown != null)
			{
				onPointerDown.Invoke(eventData.position);
			}
		}

		// RVA: 0x1AD5378 Offset: 0x1AD5378 VA: 0x1AD5378 Slot: 6
		public void OnPointerUp(PointerEventData eventData)
		{
			if(
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1
#endif
				&& onPointerUp != null)
			{
				onPointerUp.Invoke();
			}
		}

		// RVA: 0x1AD53C8 Offset: 0x1AD53C8 VA: 0x1AD53C8 Slot: 7
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1
#endif
				&& onBeginDrag != null)
			{
				onBeginDrag.Invoke(eventData.position);
			}
		}

		// RVA: 0x1AD548C Offset: 0x1AD548C VA: 0x1AD548C Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			if(
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1
#endif
				&& onDrag != null)
			{
				onDrag.Invoke(eventData.position);
			}
		}

		// // RVA: 0x1AD5278 Offset: 0x1AD5278 VA: 0x1AD5278
		// public bool IsEnableTouchId(PointerEventData eventData) { }
	}
}
