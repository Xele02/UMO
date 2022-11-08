using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XeSys.uGUI
{
	public class uGUIClickSwapImage : MonoBehaviour
	{
		public UnityEvent onClick;
		public Sprite sprite1;
		public Sprite sprite2;
		public Image swapImage;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
