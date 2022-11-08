using UnityEngine;
using System;
using UnityEngine.Events;

namespace XeApp.Game
{
	public class SliderPushEvent : MonoBehaviour
	{
		[Serializable]
		public class OnSelectEvent : UnityEvent<float>
		{
		}

		[SerializeField]
		public OnSelectEvent onSelectEvent;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
