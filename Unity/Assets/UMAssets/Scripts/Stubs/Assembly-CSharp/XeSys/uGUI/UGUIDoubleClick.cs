using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace XeSys.uGUI
{
	public class UGUIDoubleClick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public float interval;
		public UnityEvent onDoubleClick;

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
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
