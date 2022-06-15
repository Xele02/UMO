using UnityEngine;
using XeSys;
using System.Collections.Generic;
using System;

namespace XeSys
{
	public class InputManager : MonoBehaviour
	{
		// Fields
		private static InputManager instance; // 0x0
		// [CompilerGeneratedAttribute] // RVA: 0x652DBC Offset: 0x652DBC VA: 0x652DBC
		// private static int <fingerCount>k__BackingField; // 0x4
		// [CompilerGeneratedAttribute] // RVA: 0x652DCC Offset: 0x652DCC VA: 0x652DCC
		// private static int <recordFrameSize>k__BackingField; // 0x8
		// [CompilerGeneratedAttribute] // RVA: 0x652DDC Offset: 0x652DDC VA: 0x652DDC
		// private static float <swipeVelocity>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x652DEC Offset: 0x652DEC VA: 0x652DEC
		// private static float <swipeDistance>k__BackingField; // 0x10
		private TouchInfoRecord[] touchInfoRecords; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x652DFC Offset: 0x652DFC VA: 0x652DFC
		// private int <touchCount>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x652E0C Offset: 0x652E0C VA: 0x652E0C
		// private bool <pinch>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x652E1C Offset: 0x652E1C VA: 0x652E1C
		// private float <pinchRatio>k__BackingField; // 0x18
		// [CompilerGeneratedAttribute] // RVA: 0x652E2C Offset: 0x652E2C VA: 0x652E2C
		// private float <pinchDelta>k__BackingField; // 0x1C
		private float pinchStartLength; // 0x20
		private float pinchCurrentLength; // 0x24
		private Vector3 lowPassAcceleration; // 0x28
		private List<TouchInfoRecord> touchListTempList; // 0x34
		private List<Touch> unityTouchListTempList; // 0x38
		private const float AccelerometerUpdateInterval = 0.01666667f;
		private const float LowPassKernelWidthInSeconds = 1;
		private const float LowPassFilterFactor = 0.01666667f;

		public static int fingerCount { get; set; }
		public static int recordFrameSize { get; set; }
		public static float swipeVelocity { get; set; }
		public static float swipeDistance { get; set; }
		public static InputManager Instance { get; }
		public int touchCount { get; set; }
		public bool pinch { get; set; }
		public float pinchRatio { get; set; }
		public float pinchDelta { get; set; }
		[ObsoleteAttribute("use touchCount")]
		public int TouchCount { get; }
		[ObsoleteAttribute("use pinchRatio")] 
		public float PinchRatio { get; }
		[ObsoleteAttribute("use pinchDelta")]
		public float PinchDelta { get; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6910BC Offset: 0x6910BC VA: 0x6910BC
		// // RVA: 0x1EF58DC Offset: 0x1EF58DC VA: 0x1EF58DC
		// public static int get_fingerCount() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6910CC Offset: 0x6910CC VA: 0x6910CC
		// // RVA: 0x1EF5968 Offset: 0x1EF5968 VA: 0x1EF5968
		// private static void set_fingerCount(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6910DC Offset: 0x6910DC VA: 0x6910DC
		// // RVA: 0x1EF59F8 Offset: 0x1EF59F8 VA: 0x1EF59F8
		// public static int get_recordFrameSize() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6910EC Offset: 0x6910EC VA: 0x6910EC
		// // RVA: 0x1EF5A84 Offset: 0x1EF5A84 VA: 0x1EF5A84
		// private static void set_recordFrameSize(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6910FC Offset: 0x6910FC VA: 0x6910FC
		// // RVA: 0x1EF5B14 Offset: 0x1EF5B14 VA: 0x1EF5B14
		// public static float get_swipeVelocity() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69110C Offset: 0x69110C VA: 0x69110C
		// // RVA: 0x1EF5BA0 Offset: 0x1EF5BA0 VA: 0x1EF5BA0
		// private static void set_swipeVelocity(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x69111C Offset: 0x69111C VA: 0x69111C
		// // RVA: 0x1EF5C3C Offset: 0x1EF5C3C VA: 0x1EF5C3C
		// public static float get_swipeDistance() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69112C Offset: 0x69112C VA: 0x69112C
		// // RVA: 0x1EF5CC8 Offset: 0x1EF5CC8 VA: 0x1EF5CC8
		// private static void set_swipeDistance(float value) { }

		// // RVA: 0x1EF5D64 Offset: 0x1EF5D64 VA: 0x1EF5D64
		public static GameObject Create(InputManager prefab)
		{
			UnityEngine.Debug.LogWarning("TODO InputManager.Create");
			return null;
		}

		// // RVA: 0x1EF5F58 Offset: 0x1EF5F58 VA: 0x1EF5F58
		// public static InputManager get_Instance() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69113C Offset: 0x69113C VA: 0x69113C
		// // RVA: 0x1EF5FE4 Offset: 0x1EF5FE4 VA: 0x1EF5FE4
		// public int get_touchCount() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69114C Offset: 0x69114C VA: 0x69114C
		// // RVA: 0x1EF5FEC Offset: 0x1EF5FEC VA: 0x1EF5FEC
		// private void set_touchCount(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x69115C Offset: 0x69115C VA: 0x69115C
		// // RVA: 0x1EF5FF4 Offset: 0x1EF5FF4 VA: 0x1EF5FF4
		// public bool get_pinch() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69116C Offset: 0x69116C VA: 0x69116C
		// // RVA: 0x1EF5FFC Offset: 0x1EF5FFC VA: 0x1EF5FFC
		// private void set_pinch(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x69117C Offset: 0x69117C VA: 0x69117C
		// // RVA: 0x1EF6004 Offset: 0x1EF6004 VA: 0x1EF6004
		// public float get_pinchRatio() { }

		// [CompilerGeneratedAttribute] // RVA: 0x69118C Offset: 0x69118C VA: 0x69118C
		// // RVA: 0x1EF600C Offset: 0x1EF600C VA: 0x1EF600C
		// private void set_pinchRatio(float value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x69119C Offset: 0x69119C VA: 0x69119C
		// // RVA: 0x1EF6014 Offset: 0x1EF6014 VA: 0x1EF6014
		// public float get_pinchDelta() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6911AC Offset: 0x6911AC VA: 0x6911AC
		// // RVA: 0x1EF601C Offset: 0x1EF601C VA: 0x1EF601C
		// private void set_pinchDelta(float value) { }

		// // RVA: 0x1EF6024 Offset: 0x1EF6024 VA: 0x1EF6024
		// public int get_TouchCount() { }

		// // RVA: 0x1EF602C Offset: 0x1EF602C VA: 0x1EF602C
		// public float get_PinchRatio() { }

		// // RVA: 0x1EF6034 Offset: 0x1EF6034 VA: 0x1EF6034
		// public float get_PinchDelta() { }

		// // RVA: 0x1EF603C Offset: 0x1EF603C VA: 0x1EF603C
		public InputManager()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1EF61D4 Offset: 0x1EF61D4 VA: 0x1EF61D4
		// private void Awake() { }

		// // RVA: 0x1EF63B8 Offset: 0x1EF63B8 VA: 0x1EF63B8
		// private void Start() { }

		// // RVA: 0x1EF63E8 Offset: 0x1EF63E8 VA: 0x1EF63E8
		// private void Update() { }

		// // RVA: 0x1EF6424 Offset: 0x1EF6424 VA: 0x1EF6424
		// private void UpdateAcceleration() { }

		// // RVA: 0x1EF64F4 Offset: 0x1EF64F4 VA: 0x1EF64F4
		// private void MobileAction() { }

		// // RVA: 0x1EF6744 Offset: 0x1EF6744 VA: 0x1EF6744
		// private void MouseAction() { }

		// // RVA: 0x1EF68C8 Offset: 0x1EF68C8 VA: 0x1EF68C8
		// private void MobilePinchAction() { }

		// // RVA: 0x1EF7158 Offset: 0x1EF7158 VA: 0x1EF7158
		// public bool IsTouchPositionInScreen(Vector2 screenPosition) { }

		// // RVA: 0x1EF6D64 Offset: 0x1EF6D64 VA: 0x1EF6D64
		// public int GetInScreenTouchCount() { }

		// // RVA: 0x1EF7318 Offset: 0x1EF7318 VA: 0x1EF7318
		// public TouchInfoRecord GetFirstInScreenTouchRecord() { }

		// // RVA: 0x1EF74FC Offset: 0x1EF74FC VA: 0x1EF74FC
		// public TouchInfoRecord GetInScreenTouchRecord(int order) { }

		// // RVA: 0x1EF6DD0 Offset: 0x1EF6DD0 VA: 0x1EF6DD0
		// public bool GetInScreenTouch(int order, out Touch touch) { }

		// // RVA: 0x1EF6C84 Offset: 0x1EF6C84 VA: 0x1EF6C84
		// private void MousePinchAction() { }

		// // RVA: 0x1EF7434 Offset: 0x1EF7434 VA: 0x1EF7434
		// public TouchInfoRecord GetTouchInfoRecord(int fingerId) { }

		// // RVA: 0x1EF7798 Offset: 0x1EF7798 VA: 0x1EF7798
		// public TouchInfo GetCurrentTouchInfo(int fingerId) { }

		// // RVA: 0x1EF729C Offset: 0x1EF729C VA: 0x1EF729C
		// public TouchInfo GetBeganTouchInfo(int fingerId) { }

		// // RVA: 0x1EF7814 Offset: 0x1EF7814 VA: 0x1EF7814
		// public TouchInfo GetEndedTouchInfo(int fingerId) { }

		// // RVA: 0x1EF7890 Offset: 0x1EF7890 VA: 0x1EF7890
		// public TouchInfo FindRecentTouchInfo(int fingerId, int frameFromLatest) { }

		// // RVA: 0x1EF7914 Offset: 0x1EF7914 VA: 0x1EF7914
		// public Vector3 GetTrueAcceleration() { }

		// // RVA: 0x1EF7928 Offset: 0x1EF7928 VA: 0x1EF7928
		// public Vector3 GetLowPassAcceleration() { }

		// // RVA: 0x1EF793C Offset: 0x1EF793C VA: 0x1EF793C
		// public void Debug() { }
	}
}
