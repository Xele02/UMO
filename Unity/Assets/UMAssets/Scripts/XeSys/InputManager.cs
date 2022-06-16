using UnityEngine;
using XeSys;
using System.Collections.Generic;
using System;

namespace XeSys
{
	public class InputManager : MonoBehaviour
	{
		private static InputManager instance; // 0x0
		private TouchInfoRecord[] touchInfoRecords; // 0xC
		private float pinchStartLength; // 0x20
		private float pinchCurrentLength; // 0x24
		private Vector3 lowPassAcceleration; // 0x28
		private List<TouchInfoRecord> touchListTempList; // 0x34
		private List<Touch> unityTouchListTempList; // 0x38
		private const float AccelerometerUpdateInterval = 0.01666667f;
		private const float LowPassKernelWidthInSeconds = 1;
		private const float LowPassFilterFactor = 0.01666667f;

		public static int fingerCount { get; private set; } // 0x4
		public static int recordFrameSize { get; private set; } // 0x8
		public static float swipeVelocity { get; private set; } // 0xC
		public static float swipeDistance { get; private set; } // 0x10
		// public static InputManager Instance { get; } 0x1EF5F58
		public int touchCount { get; private set; } // 0x10
		public bool pinch { get; private set; } // 0x14
		public float pinchRatio { get; private set; } // 0x18
		public float pinchDelta { get; private set; } // 0x1C
		// [ObsoleteAttribute("use touchCount")]
		// public int TouchCount { get; } 0x1EF6024
		// [ObsoleteAttribute("use pinchRatio")] 
		// public float PinchRatio { get; } 0x1EF602C
		// [ObsoleteAttribute("use pinchDelta")]
		// public float PinchDelta { get; } 0x1EF6034

		// // RVA: 0x1EF5D64 Offset: 0x1EF5D64 VA: 0x1EF5D64
		public static GameObject Create(InputManager prefab)
		{
			UnityEngine.Debug.LogWarning("TODO InputManager.Create");
			return null;
		}

		// // RVA: 0x1EF603C Offset: 0x1EF603C VA: 0x1EF603C
		public InputManager()
		{
			UnityEngine.Debug.LogWarning("TODO InputManager");
		}

		// // RVA: 0x1EF61D4 Offset: 0x1EF61D4 VA: 0x1EF61D4
		private void Awake()
		{
			UnityEngine.Debug.LogWarning("TODO InputManager");
		}

		// // RVA: 0x1EF63B8 Offset: 0x1EF63B8 VA: 0x1EF63B8
		private void Start()
		{
			UnityEngine.Debug.LogWarning("TODO InputManager");
		}

		// // RVA: 0x1EF63E8 Offset: 0x1EF63E8 VA: 0x1EF63E8
		private void Update()
		{
			UnityEngine.Debug.LogWarning("TODO InputManager");
		}

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
