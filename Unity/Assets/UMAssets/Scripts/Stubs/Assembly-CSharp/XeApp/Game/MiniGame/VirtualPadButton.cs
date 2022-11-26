using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.MiniGame
{
	public class VirtualPadButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private int buttonId;

		public void OnPointerDown(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			throw new System.NotImplementedException();
		}

		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
