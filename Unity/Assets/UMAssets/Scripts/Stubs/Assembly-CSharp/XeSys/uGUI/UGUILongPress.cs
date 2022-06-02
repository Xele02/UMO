using UnityEngine;
using UnityEngine.Events;

namespace XeSys.uGUI
{
	public class UGUILongPress : MonoBehaviour
	{
		public float interval;
		public bool callEventFirstPress;
		public UnityEvent onLongPressDown;
		public UnityEvent onLongPress;
		public UnityEvent onLongPressUp;
	}
}
