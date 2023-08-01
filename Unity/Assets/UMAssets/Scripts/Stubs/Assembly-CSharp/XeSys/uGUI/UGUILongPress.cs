using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace XeSys.uGUI
{
	public class UGUILongPress : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
	{
		public float interval;
		public bool callEventFirstPress;
		public UnityEvent onLongPressDown;
		public UnityEvent onLongPress;
		public UnityEvent onLongPressUp;

		public void OnPointerDown(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
