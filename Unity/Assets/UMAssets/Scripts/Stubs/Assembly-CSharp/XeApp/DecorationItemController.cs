using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp
{
	public class DecorationItemController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
	{
		public void OnBeginDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnDrag(PointerEventData eventData)
		{
			//throw new System.NotImplementedException();
		}

		public void OnPointerClick(PointerEventData eventData)
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
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
