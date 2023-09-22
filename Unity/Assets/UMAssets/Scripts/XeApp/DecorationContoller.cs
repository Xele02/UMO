using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp
{
	public class DecorationContoller : MonoBehaviour
	{
		public delegate void touchDelegate(TouchInfo touch1, TouchInfo touch2);

		[SerializeField]
		public float m_zoomMax; // 0xC
		private touchDelegate TouchUpdateCallback; // 0x54
		private List<DecorationControllerBase> m_contoller = new List<DecorationControllerBase>(); // 0x5C
		private Rect m_screenRect; // 0x60

		public Touch TouchData { get; private set; } // 0x10
		public DecorationScrollController scrollController { get; private set; } // 0x58
		public Rect VisibilityRect { get; private set; } // 0x70

		// RVA: 0x1ACECCC Offset: 0x1ACECCC VA: 0x1ACECCC
		public void Awake()
		{
			return;
		}

		//// RVA: 0x1ABAFBC Offset: 0x1ABAFBC VA: 0x1ABAFBC
		//public void Create(List<DecorationControllerBase.ControlData> controlData, DecorationBgManager bgManager, Camera decorationCamera, DecorationContoller.touchDelegate touchUpdateCallback) { }

		//// RVA: 0x1ACECD0 Offset: 0x1ACECD0 VA: 0x1ACECD0
		//private Rect GenerateScreenRect() { }

		//// RVA: 0x1ACF158 Offset: 0x1ACF158 VA: 0x1ACF158
		//private Rect GenerateVisibilityRect(DecorationBgManager bgManager) { }

		// RVA: 0x1ACF634 Offset: 0x1ACF634 VA: 0x1ACF634
		private void Update()
		{
			if(m_contoller.Count != 0)
			{
				foreach(var c in m_contoller)
				{
					c.Update();
				}
				if(TouchUpdateCallback != null)
				{
					TouchUpdateCallback(InputManager.Instance.GetCurrentTouchInfo(0), InputManager.Instance.GetCurrentTouchInfo(0));
				}
			}
		}

		//// RVA: 0x1ABB224 Offset: 0x1ABB224 VA: 0x1ABB224
		//public void SetAcive(bool active) { }

		//// RVA: 0x1ABE7DC Offset: 0x1ABE7DC VA: 0x1ABE7DC
		//public void AutoZoomOut() { }

		//// RVA: 0x1ACF5F4 Offset: 0x1ACF5F4 VA: 0x1ACF5F4
		//private int Gcd(int a, int b) { }
	}
}
