using XeSys;
using UnityEngine;

namespace XeSys.Gfx
{
	public class RenderManager : SingletonBehaviour<RenderManager>
	{
		// Fields
		// [CompilerGeneratedAttribute] // RVA: 0x653EB4 Offset: 0x653EB4 VA: 0x653EB4
		// private static float <renderingScale>k__BackingField; // 0x0
		// [CompilerGeneratedAttribute] // RVA: 0x653EC4 Offset: 0x653EC4 VA: 0x653EC4
		// private static Rect <renderingRect>k__BackingField; // 0x4
		private static Vector2 mOffset; // 0x14

		// Properties
		public static Vector2 offset { get; }
		public static float renderingScale { get; set; }
		public static Rect renderingRect { get; set; }

		// Methods

		// // RVA: 0x1F1001C Offset: 0x1F1001C VA: 0x1F1001C
		// public static Vector2 get_offset() { }

		// [CompilerGeneratedAttribute] // RVA: 0x692A50 Offset: 0x692A50 VA: 0x692A50
		// // RVA: 0x1F1008C Offset: 0x1F1008C VA: 0x1F1008C
		// public static float get_renderingScale() { }

		// [CompilerGeneratedAttribute] // RVA: 0x692A60 Offset: 0x692A60 VA: 0x692A60
		// // RVA: 0x1F100F0 Offset: 0x1F100F0 VA: 0x1F100F0
		// private static void set_renderingScale(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x692A70 Offset: 0x692A70 VA: 0x692A70
		// // RVA: 0x1F1015C Offset: 0x1F1015C VA: 0x1F1015C
		// public static Rect get_renderingRect() { }

		// [CompilerGeneratedAttribute] // RVA: 0x692A80 Offset: 0x692A80 VA: 0x692A80
		// // RVA: 0x1F101C8 Offset: 0x1F101C8 VA: 0x1F101C8
		// private static void set_renderingRect(Rect value) { }

		// // RVA: 0x1F10244 Offset: 0x1F10244 VA: 0x1F10244
		public static RenderManager Create(string name = "RenderManager")
		{
			UnityEngine.Debug.LogWarning("TODO RenderManager.Create");
			return null;
		}

		// // RVA: 0x1F10338 Offset: 0x1F10338 VA: 0x1F10338 Slot: 4
		// protected override void Awake() { }

		// // RVA: 0x1F10434 Offset: 0x1F10434 VA: 0x1F10434
		// private void Start() { }

		// // RVA: 0x1F10438 Offset: 0x1F10438 VA: 0x1F10438
		// private void UpdateParameter() { }

		// // RVA: 0x1F10814 Offset: 0x1F10814 VA: 0x1F10814
		// public static Vector3 ScreenToAppPosition(Vector3 screenPosition) { }

		// // RVA: 0x1F10984 Offset: 0x1F10984 VA: 0x1F10984
		// public static Vector3 AppToScreenPosition(Vector3 appPosi) { }

		// // RVA: 0x1F10BB0 Offset: 0x1F10BB0 VA: 0x1F10BB0
		// public static Vector2 AppToScreenPosition(Vector2 appPosi) { }

		// // RVA: 0x1F10DD4 Offset: 0x1F10DD4 VA: 0x1F10DD4
		// public static Vector3 UnityToAppPosition(Vector3 unityPosi) { }

		// // RVA: 0x1F10E8C Offset: 0x1F10E8C VA: 0x1F10E8C
		// public static Rect MakeScreenRect(float rx, float ry, float rw, float rh) { }

		// // RVA: 0x1F10F60 Offset: 0x1F10F60 VA: 0x1F10F60
		// public void .ctor() { }
	}
}
