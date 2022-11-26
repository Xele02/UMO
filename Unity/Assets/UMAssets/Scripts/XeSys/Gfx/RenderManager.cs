using XeSys;
using UnityEngine;

namespace XeSys.Gfx
{
	public class RenderManager : SingletonBehaviour<RenderManager>
	{
		private static Vector2 mOffset; // 0x14

		// public static Vector2 offset { get; } 0x1F1001C
		public static float renderingScale { get; private set; } // 0x0
		public static Rect renderingRect { get; private set; } // 0x4

		// // RVA: 0x1F10244 Offset: 0x1F10244 VA: 0x1F10244
		public static RenderManager Create(string name = "RenderManager")
		{
			GameObject go = new GameObject(name);
			RenderManager r = go.AddComponent<RenderManager>();
			SystemManager.Instance.AddToSystemGroup(go);
			return r;
		}

		// // RVA: 0x1F10338 Offset: 0x1F10338 VA: 0x1F10338 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			DontDestroyOnLoad(this);
			mOffset = Vector2.zero;
		}

		// // RVA: 0x1F10434 Offset: 0x1F10434 VA: 0x1F10434
		private void Start()
		{
			if(SystemManager.ScreenAspect >= SystemManager.BaseAspect)
			{
				mOffset = new Vector2(Mathf.Abs(SystemManager.ScreenSize.x - SystemManager.ScreenSize.x * SystemManager.BaseAspect) * 0.5f * SystemManager.AdjustInvScale.y, 0);
				renderingScale = SystemManager.AdjustInvScale.y;
			}
			else
			{
				mOffset = new Vector2(0, Mathf.Abs(SystemManager.ScreenSize.y - SystemManager.ScreenSize.y * 1.0f / SystemManager.BaseAspect) * 0.5f * SystemManager.AdjustInvScale.x);
				renderingScale = SystemManager.AdjustInvScale.x;
			}
			renderingRect = Rect.MinMaxRect(-mOffset.x, -mOffset.y, SystemManager.BaseScreenSize.x + mOffset.x, SystemManager.BaseScreenSize.y + mOffset.y);
		}

		// // RVA: 0x1F10438 Offset: 0x1F10438 VA: 0x1F10438
		// private void UpdateParameter() { }

		// // RVA: 0x1F10814 Offset: 0x1F10814 VA: 0x1F10814
		public static Vector3 ScreenToAppPosition(Vector3 screenPosition)
		{
			return new Vector3(screenPosition.x * renderingScale - mOffset.x, screenPosition.y * renderingScale - mOffset.y, screenPosition.z);
		}

		// // RVA: 0x1F10984 Offset: 0x1F10984 VA: 0x1F10984
		// public static Vector3 AppToScreenPosition(Vector3 appPosi) { }

		// // RVA: 0x1F10BB0 Offset: 0x1F10BB0 VA: 0x1F10BB0
		// public static Vector2 AppToScreenPosition(Vector2 appPosi) { }

		// // RVA: 0x1F10DD4 Offset: 0x1F10DD4 VA: 0x1F10DD4
		// public static Vector3 UnityToAppPosition(Vector3 unityPosi) { }

		// // RVA: 0x1F10E8C Offset: 0x1F10E8C VA: 0x1F10E8C
		// public static Rect MakeScreenRect(float rx, float ry, float rw, float rh) { }
	}
}
