using UnityEngine;
using XeSys.File;
using System;

namespace XeSys
{
	public class SystemManager : MonoBehaviour
	{
		// Fields
		[SerializeField]
		private DebugTextRenderer debugTextRendererPrefab; // 0xC
		[SerializeField]
		private DebugFPS debugFpsPrefab; // 0x10
		[SerializeField]
		private InputManager inputManagerPrefab; // 0x14
		[SerializeField]
		private CriFileRequestManager criFileRequestManagerPrefab; // 0x18

		private static SystemManager mInstance; // 0x0
		// [CompilerGeneratedAttribute] // RVA: 0x6531E4 Offset: 0x6531E4 VA: 0x6531E4
		// private static Vector2 <ScreenHalfSize>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x6531F4 Offset: 0x6531F4 VA: 0x6531F4
		// private static float <ScreenAspect>k__BackingField; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x653204 Offset: 0x653204 VA: 0x653204
		// private static Vector2 <BaseScreenSize>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x653214 Offset: 0x653214 VA: 0x653214
		// private static Vector2 <BaseScreenHalfSize>k__BackingField; // 0x28
		// [CompilerGeneratedAttribute] // RVA: 0x653224 Offset: 0x653224 VA: 0x653224
		// private static float <BaseAspect>k__BackingField; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x653234 Offset: 0x653234 VA: 0x653234
		// private static Vector2 <AdjustScale>k__BackingField; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x653244 Offset: 0x653244 VA: 0x653244
		// private static Vector2 <AdjustInvScale>k__BackingField; // 0x3C
		// [CompilerGeneratedAttribute] // RVA: 0x653254 Offset: 0x653254 VA: 0x653254
		// private static float <AdjustScaleValue>k__BackingField; // 0x44
		// [CompilerGeneratedAttribute] // RVA: 0x653264 Offset: 0x653264 VA: 0x653264
		// private static float <AdjustScaleInvValue>k__BackingField; // 0x48
		// [CompilerGeneratedAttribute] // RVA: 0x653274 Offset: 0x653274 VA: 0x653274
		// private static long <gcMinUseMemorySize>k__BackingField; // 0x50
		// [CompilerGeneratedAttribute] // RVA: 0x653284 Offset: 0x653284 VA: 0x653284
		// private static long <gcMaxUseMemorySize>k__BackingField; // 0x58
		// [CompilerGeneratedAttribute] // RVA: 0x653294 Offset: 0x653294 VA: 0x653294
		// private static float <gcCheckTime>k__BackingField; // 0x60
		private GameObject mSystemGroupObject; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x6532A4 Offset: 0x6532A4 VA: 0x6532A4
		// private Action <DoUpdate>k__BackingField; // 0x20
		private const float permissionHdivVAspectRatio = 1.782778f;
		private const float permissionVdivHAspectRatio = 0.755f;
		public static bool isLongScreenDevice; // 0x64
		public static Vector2 longScreenBaseSize; // 0x68
		public static Vector2 longScreenReferenceResolution; // 0x70
		public static Vector2 longScreenSizeWithSafeArea; // 0x78
		public static Rect rawSafeAreaRect; // 0x80
		public static Rect rawScreenAreaRect; // 0x90
		// [CompilerGeneratedAttribute] // RVA: 0x6532B4 Offset: 0x6532B4 VA: 0x6532B4
		// private static Vector2 <safeAreaScale>k__BackingField; // 0xA0
		// [CompilerGeneratedAttribute] // RVA: 0x6532C4 Offset: 0x6532C4 VA: 0x6532C4
		// private static bool <CanWideScreenMenu>k__BackingField; // 0xA8
		public static int width_withSafeArea; // 0xAC
		public static int height_withSafeArea; // 0xB0
		public static Rect rawAppScreenRect; // 0xB4
		private const string forceWideScreen_prefs_key = "forceWideScreen";
		private static bool isForceWideScreen; // 0xC4

		// Properties
		public static SystemManager Instance { get; }
		public static Vector2 NativeScreenSize { get; set; } // 0x4
		public static Vector2 ScreenSize { get; set; } // 0xC
		public static Vector2 ScreenHalfSize { get; set; }
		public static float ScreenAspect { get; set; }
		public static Vector2 BaseScreenSize { get; set; }
		public static Vector2 BaseScreenHalfSize { get; set; }
		public static float BaseAspect { get; set; }
		public static Vector2 AdjustScale { get; set; }
		public static Vector2 AdjustInvScale { get; set; }
		public static float AdjustScaleValue { get; set; }
		public static float AdjustScaleInvValue { get; set; }
		public static long gcMinUseMemorySize { get; set; }
		public static long gcMaxUseMemorySize { get; set; }
		private static float gcCheckTime { get; set; }
		private Action DoUpdate { get; set; }
		public static Vector2 safeAreaScale { get; set; }
		public static bool CanWideScreenMenu { get; set; }
		public static bool HasSafeArea { get; }
		public static bool IsForceWideScreen { get; }

		// Methods

		// // RVA: 0x239B690 Offset: 0x239B690 VA: 0x239B690
		// public static SystemManager get_Instance() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6919B4 Offset: 0x6919B4 VA: 0x6919B4
		// // RVA: 0x23A3F08 Offset: 0x23A3F08 VA: 0x23A3F08
		// public static Vector2 get_NativeScreenSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6919C4 Offset: 0x6919C4 VA: 0x6919C4
		// // RVA: 0x23A3FA4 Offset: 0x23A3FA4 VA: 0x23A3FA4
		// private static void set_NativeScreenSize(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6919D4 Offset: 0x6919D4 VA: 0x6919D4
		// // RVA: 0x23A403C Offset: 0x23A403C VA: 0x23A403C
		// public static Vector2 get_ScreenSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6919E4 Offset: 0x6919E4 VA: 0x6919E4
		// // RVA: 0x23A40D8 Offset: 0x23A40D8 VA: 0x23A40D8
		// private static void set_ScreenSize(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6919F4 Offset: 0x6919F4 VA: 0x6919F4
		// // RVA: 0x23A4170 Offset: 0x23A4170 VA: 0x23A4170
		// public static Vector2 get_ScreenHalfSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A04 Offset: 0x691A04 VA: 0x691A04
		// // RVA: 0x23A420C Offset: 0x23A420C VA: 0x23A420C
		// private static void set_ScreenHalfSize(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A14 Offset: 0x691A14 VA: 0x691A14
		// // RVA: 0x23A42A4 Offset: 0x23A42A4 VA: 0x23A42A4
		// public static float get_ScreenAspect() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A24 Offset: 0x691A24 VA: 0x691A24
		// // RVA: 0x23A4330 Offset: 0x23A4330 VA: 0x23A4330
		// private static void set_ScreenAspect(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A34 Offset: 0x691A34 VA: 0x691A34
		// // RVA: 0x239CB44 Offset: 0x239CB44 VA: 0x239CB44
		// public static Vector2 get_BaseScreenSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A44 Offset: 0x691A44 VA: 0x691A44
		// // RVA: 0x23A43CC Offset: 0x23A43CC VA: 0x23A43CC
		// public static void set_BaseScreenSize(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A54 Offset: 0x691A54 VA: 0x691A54
		// // RVA: 0x23A4464 Offset: 0x23A4464 VA: 0x23A4464
		// public static Vector2 get_BaseScreenHalfSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A64 Offset: 0x691A64 VA: 0x691A64
		// // RVA: 0x23A4500 Offset: 0x23A4500 VA: 0x23A4500
		// private static void set_BaseScreenHalfSize(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A74 Offset: 0x691A74 VA: 0x691A74
		// // RVA: 0x23A4598 Offset: 0x23A4598 VA: 0x23A4598
		// public static float get_BaseAspect() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A84 Offset: 0x691A84 VA: 0x691A84
		// // RVA: 0x23A4624 Offset: 0x23A4624 VA: 0x23A4624
		// public static void set_BaseAspect(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691A94 Offset: 0x691A94 VA: 0x691A94
		// // RVA: 0x239CD38 Offset: 0x239CD38 VA: 0x239CD38
		// public static Vector2 get_AdjustScale() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AA4 Offset: 0x691AA4 VA: 0x691AA4
		// // RVA: 0x23A46C0 Offset: 0x23A46C0 VA: 0x23A46C0
		// private static void set_AdjustScale(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AB4 Offset: 0x691AB4 VA: 0x691AB4
		// // RVA: 0x23A4758 Offset: 0x23A4758 VA: 0x23A4758
		// public static Vector2 get_AdjustInvScale() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AC4 Offset: 0x691AC4 VA: 0x691AC4
		// // RVA: 0x23A47F4 Offset: 0x23A47F4 VA: 0x23A47F4
		// private static void set_AdjustInvScale(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AD4 Offset: 0x691AD4 VA: 0x691AD4
		// // RVA: 0x23A488C Offset: 0x23A488C VA: 0x23A488C
		// public static float get_AdjustScaleValue() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AE4 Offset: 0x691AE4 VA: 0x691AE4
		// // RVA: 0x23A4918 Offset: 0x23A4918 VA: 0x23A4918
		// private static void set_AdjustScaleValue(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691AF4 Offset: 0x691AF4 VA: 0x691AF4
		// // RVA: 0x23A49B4 Offset: 0x23A49B4 VA: 0x23A49B4
		// public static float get_AdjustScaleInvValue() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B04 Offset: 0x691B04 VA: 0x691B04
		// // RVA: 0x23A4A40 Offset: 0x23A4A40 VA: 0x23A4A40
		// private static void set_AdjustScaleInvValue(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B14 Offset: 0x691B14 VA: 0x691B14
		// // RVA: 0x23A4ADC Offset: 0x23A4ADC VA: 0x23A4ADC
		// public static long get_gcMinUseMemorySize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B24 Offset: 0x691B24 VA: 0x691B24
		// // RVA: 0x23A4B68 Offset: 0x23A4B68 VA: 0x23A4B68
		// private static void set_gcMinUseMemorySize(long value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B34 Offset: 0x691B34 VA: 0x691B34
		// // RVA: 0x23A4BFC Offset: 0x23A4BFC VA: 0x23A4BFC
		// public static long get_gcMaxUseMemorySize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B44 Offset: 0x691B44 VA: 0x691B44
		// // RVA: 0x23A4C88 Offset: 0x23A4C88 VA: 0x23A4C88
		// private static void set_gcMaxUseMemorySize(long value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B54 Offset: 0x691B54 VA: 0x691B54
		// // RVA: 0x23A4D1C Offset: 0x23A4D1C VA: 0x23A4D1C
		// private static float get_gcCheckTime() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B64 Offset: 0x691B64 VA: 0x691B64
		// // RVA: 0x23A4DA8 Offset: 0x23A4DA8 VA: 0x23A4DA8
		// private static void set_gcCheckTime(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B74 Offset: 0x691B74 VA: 0x691B74
		// // RVA: 0x23A4E44 Offset: 0x23A4E44 VA: 0x23A4E44
		// private Action get_DoUpdate() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B84 Offset: 0x691B84 VA: 0x691B84
		// // RVA: 0x23A4E4C Offset: 0x23A4E4C VA: 0x23A4E4C
		// public void set_DoUpdate(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691B94 Offset: 0x691B94 VA: 0x691B94
		// // RVA: 0x23A4E54 Offset: 0x23A4E54 VA: 0x23A4E54
		// public static Vector2 get_safeAreaScale() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691BA4 Offset: 0x691BA4 VA: 0x691BA4
		// // RVA: 0x23A4EF0 Offset: 0x23A4EF0 VA: 0x23A4EF0
		// private static void set_safeAreaScale(Vector2 value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x691BB4 Offset: 0x691BB4 VA: 0x691BB4
		// // RVA: 0x23A4F88 Offset: 0x23A4F88 VA: 0x23A4F88
		// public static bool get_CanWideScreenMenu() { }

		// [CompilerGeneratedAttribute] // RVA: 0x691BC4 Offset: 0x691BC4 VA: 0x691BC4
		// // RVA: 0x23A5014 Offset: 0x23A5014 VA: 0x23A5014
		// private static void set_CanWideScreenMenu(bool value) { }

		// // RVA: 0x23A50A4 Offset: 0x23A50A4 VA: 0x23A50A4
		// public static bool get_HasSafeArea() { }

		// // RVA: 0x23A5150 Offset: 0x23A5150 VA: 0x23A5150
		// public static bool get_IsForceWideScreen() { }

		// // RVA: 0x23A51DC Offset: 0x23A51DC VA: 0x23A51DC
		// public static void SetForceWideScreen(bool isOn) { }

		// // RVA: 0x23A524C Offset: 0x23A524C VA: 0x23A524C
		public static void Create(GameObject prefab)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x23A54A0 Offset: 0x23A54A0 VA: 0x23A54A0
		// private void Awake() { }

		// // RVA: 0x23A5930 Offset: 0x23A5930 VA: 0x23A5930
		// private void ResetGcMemoryProfile() { }

		// // RVA: 0x23A61F4 Offset: 0x23A61F4 VA: 0x23A61F4
		// private void Start() { }

		// // RVA: 0x23A61F8 Offset: 0x23A61F8 VA: 0x23A61F8
		// private void Update() { }

		// // RVA: 0x23A6430 Offset: 0x23A6430 VA: 0x23A6430
		// private void OnDestroy() { }

		// // RVA: 0x23A59C8 Offset: 0x23A59C8 VA: 0x23A59C8
		// public void UpdateScreenSize() { }

		// // RVA: 0x239B71C Offset: 0x239B71C VA: 0x239B71C
		// public void AddToSystemGroup(GameObject go) { }

		// // RVA: 0x23A64D0 Offset: 0x23A64D0 VA: 0x23A64D0
		// public static bool IsExistGameObject(string name) { }

		// // RVA: 0x23A6434 Offset: 0x23A6434 VA: 0x23A6434
		// public SystemManager.OverPermissionAspectResult CheckOverPermissionAspectRatio() { }

		// // RVA: 0x23A6584 Offset: 0x23A6584 VA: 0x23A6584
		// public void .ctor() { }

		// // RVA: 0x23A658C Offset: 0x23A658C VA: 0x23A658C
		// private static void .cctor() { }
	}
}
