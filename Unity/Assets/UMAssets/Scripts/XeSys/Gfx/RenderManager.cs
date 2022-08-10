using XeSys;
using UnityEngine;

namespace XeSys.Gfx
{
	public class RenderManager : SingletonBehaviour<RenderManager>
	{
		private static Vector2 mOffset; // 0x14

		// public static Vector2 offset { get; }
		public static float renderingScale { get; private set; } // 0x0
		public static Rect renderingRect { get; private set; } // 0x4

		// // RVA: 0x1F1001C Offset: 0x1F1001C VA: 0x1F1001C
		// public static Vector2 get_offset() { }

		// // RVA: 0x1F10244 Offset: 0x1F10244 VA: 0x1F10244
		public static RenderManager Create(string name = "RenderManager")
		{
			TodoLogger.Log(5, "RenderManager.Create");
			return null;
		}

		// // RVA: 0x1F10338 Offset: 0x1F10338 VA: 0x1F10338 Slot: 4
		protected override void Awake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x1F10434 Offset: 0x1F10434 VA: 0x1F10434
		private void Start()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x1F10438 Offset: 0x1F10438 VA: 0x1F10438
		// private void UpdateParameter() { }

		// // RVA: 0x1F10814 Offset: 0x1F10814 VA: 0x1F10814
		public static Vector3 ScreenToAppPosition(Vector3 screenPosition)
		{
			TodoLogger.Log(5, "ScreenToAppPosition");
			return screenPosition;
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
