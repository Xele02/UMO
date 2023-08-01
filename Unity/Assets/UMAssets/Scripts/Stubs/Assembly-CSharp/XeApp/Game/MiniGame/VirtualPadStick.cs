using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.MiniGame
{
	public class VirtualPadStick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
	{
		public void OnBeginDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

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
