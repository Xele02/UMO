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
		public void Create(List<DecorationControllerBase.ControlData> controlData, DecorationBgManager bgManager, Camera decorationCamera, touchDelegate touchUpdateCallback)
		{
			TouchUpdateCallback = touchUpdateCallback;
			m_screenRect = GenerateScreenRect();
			VisibilityRect = GenerateVisibilityRect(bgManager);
			DecorationScrollControllerArgs args = new DecorationScrollControllerArgs();
			args.m_screenRect = m_screenRect;
			args.m_scrollRect = VisibilityRect;
			args.m_decorationCamera = decorationCamera;
			scrollController = new DecorationScrollController(controlData, args);
			m_contoller.Add(scrollController);
			DecorationZoomControllerArgs args2 = new DecorationZoomControllerArgs();
			args2.m_screenRect = m_screenRect;
			args2.m_zoomMax = m_zoomMax;
			args2.m_zoomRect = VisibilityRect;
			args2.m_scrollController = scrollController;
			m_contoller.Add(new DecorationZoomController(controlData, args2));
		}

		//// RVA: 0x1ACECD0 Offset: 0x1ACECD0 VA: 0x1ACECD0
		private Rect GenerateScreenRect()
		{
			Rect res = new Rect(0, 0, Screen.width, Screen.height);
			if(!SystemManager.isLongScreenDevice)
			{
				SystemManager.OverPermissionAspectResult r = SystemManager.Instance.CheckOverPermissionAspectRatio();
				if(r == SystemManager.OverPermissionAspectResult.None)
					return res;
				if(r == SystemManager.OverPermissionAspectResult.HdivV)
				{
					float f = Screen.width / SystemManager.BaseScreenSize.y * SystemManager.BaseScreenSize.x;
					return new Rect((Screen.width - f) * 0.5f, 0, f, Screen.height);
				}
				else
				{
					float f = Screen.width / SystemManager.BaseScreenSize.x * SystemManager.BaseScreenSize.y;
					return new Rect(0, (Screen.height - f) * 0.5f, Screen.width, f);
				}
			}
			else
			{
				if(SystemManager.HasSafeArea)
				{
					return SystemManager.rawAppScreenRect;
				}
				else
				{
					float f = Screen.width - Mathf.Min(Screen.height * 1.0f / Screen.width / 0.5625f, 1.0f) * Screen.width;
					return new Rect(f * 0.5f, 0, Screen.width - f, Screen.height);
				}
			}
		}

		//// RVA: 0x1ACF158 Offset: 0x1ACF158 VA: 0x1ACF158
		private Rect GenerateVisibilityRect(DecorationBgManager bgManager)
		{
			Rect r = bgManager.GetRect();
			float f1 = m_screenRect.width;
			float f2 = m_screenRect.height;
			float f = 0;
			do
			{
				do
				{
					f = f2;
					f2 = f1;
					f1 = f;
				} while((int)f2 < (int)f);
				f2 = f2 % f;
			} while(f2 != 0);
			int a1 = (int)m_screenRect.width / (int)f;
			int a2 = (int)m_screenRect.height / (int)f;
			Vector2[] leftLine;
			Vector2[] rightLine;
			bgManager.GetWallTopLine(out leftLine, out rightLine);
			Vector2 v1 = leftLine[1] - leftLine[0];
			int i = 0;
			Vector2 tl = Vector2.zero;
			while(true)
			{
				Vector2 v2 = new Vector2(i * 0.01f * a1 * -0.5f, i * 0.01f * a2 * 0.5f);
				v2 += r.center;
				Vector2 v3 = v2 - leftLine[0];
				if(v3.x * v1.y - v1.x * v3.y < 0)
				{
					return new Rect(tl, new Vector2(i * 0.01f * a1, i * 0.01f * a2));
				}
				tl = v2;
				if(r.width * 0.5f <= Mathf.Abs(v2.x))
				{
					return new Rect(tl, new Vector2(i * 0.01f * a1, i * 0.01f * a2));
				}
				if(r.height * 0.5f <= Mathf.Abs(v2.y))
				{
					return new Rect(tl, new Vector2(i * 0.01f * a1, i * 0.01f * a2));
				}
				i++;
			}
		}

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
		public void SetAcive(bool active)
		{
			foreach(var c in m_contoller)
			{
				c.Active = active;
			}
		}

		//// RVA: 0x1ABE7DC Offset: 0x1ABE7DC VA: 0x1ABE7DC
		public void AutoZoomOut()
		{
			foreach(var c in m_contoller)
			{
				if(c is DecorationZoomController)
				{
					(c as DecorationZoomController).AutoZoomOut();
					break;
				}
			}
		}

		//// RVA: 0x1ACF5F4 Offset: 0x1ACF5F4 VA: 0x1ACF5F4
		//private int Gcd(int a, int b) { }
	}
}
