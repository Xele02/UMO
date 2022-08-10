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
		private List<TouchInfoRecord> touchListTempList = new List<TouchInfoRecord>(6); // 0x34
		private List<Touch> unityTouchListTempList = new List<Touch>(6); // 0x38
		private const float AccelerometerUpdateInterval = 0.01666667f;
		private const float LowPassKernelWidthInSeconds = 1;
		private const float LowPassFilterFactor = 0.01666667f;

		public static int fingerCount { get; private set; } // 0x4
		public static int recordFrameSize { get; private set; } // 0x8
		public static float swipeVelocity { get; private set; } // 0xC
		public static float swipeDistance { get; private set; } // 0x10
		public static InputManager Instance { get { return instance;} } //0x1EF5F58
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
			GameObject go = GameObject.Find("InputManager");
			if(go == null)
			{
				InputManager im = UnityEngine.Object.Instantiate<InputManager>(prefab, Vector3.zero, Quaternion.identity);
				im.name = "InputManager";
				go = im.gameObject;
			}
			return go;
		}

		// // RVA: 0x1EF603C Offset: 0x1EF603C VA: 0x1EF603C
		public InputManager()
		{
			instance = this;
			fingerCount = 4;
			recordFrameSize = 5;
			swipeDistance = 100.0f;
			swipeVelocity = 20.0f;
			pinchRatio = 1.0f;
			pinch = false;
			pinchStartLength = 0.0f;
			pinchCurrentLength = 0.0f;
			lowPassAcceleration = Vector3.zero;
		}

		// // RVA: 0x1EF61D4 Offset: 0x1EF61D4 VA: 0x1EF61D4
		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
			touchInfoRecords = new TouchInfoRecord[fingerCount];
			for(int i = 0; i < fingerCount; i++)
			{
				touchInfoRecords[i] = new TouchInfoRecord(i, fingerCount);
			}
		}

		// // RVA: 0x1EF63B8 Offset: 0x1EF63B8 VA: 0x1EF63B8
		private void Start()
		{
			lowPassAcceleration = Input.acceleration;
		}

		// // RVA: 0x1EF63E8 Offset: 0x1EF63E8 VA: 0x1EF63E8
		private void Update()
		{
			UpdateAcceleration();
			if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			{
				MobileAction();
			}
			else
			{
				MouseAction();
			}
		}

		// // RVA: 0x1EF6424 Offset: 0x1EF6424 VA: 0x1EF6424
		private void UpdateAcceleration()
		{
			lowPassAcceleration = Vector3.Lerp(Input.acceleration, lowPassAcceleration, 0.0166667f);
		}

		// // RVA: 0x1EF64F4 Offset: 0x1EF64F4 VA: 0x1EF64F4
		private void MobileAction()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x1EF6744 Offset: 0x1EF6744 VA: 0x1EF6744
		private void MouseAction()
		{
			TouchInfoRecord info = touchInfoRecords[0];
			touchCount = 0;
			TouchPhase phase = TouchPhase.Began;
			Vector2 position = Vector2.zero;
			if(Input.GetMouseButtonDown(0))
			{
				phase = TouchPhase.Began;
				position = Input.mousePosition;
			}
			else if(Input.GetMouseButtonUp(0))
			{
				position = Input.mousePosition;
				phase = TouchPhase.Ended;
			}
			else if(Input.GetMouseButton(0))
			{
				position = Input.mousePosition;
				phase = TouchPhase.Stationary;
			}
			else
			{
				info.UpdateReleased();
				MousePinchAction();
				return;
			}
			info.Update(phase, position);
			MousePinchAction();
		}

		// // RVA: 0x1EF68C8 Offset: 0x1EF68C8 VA: 0x1EF68C8
		// private void MobilePinchAction() { }

		// // RVA: 0x1EF7158 Offset: 0x1EF7158 VA: 0x1EF7158
		public bool IsTouchPositionInScreen(Vector2 screenPosition)
		{
			if(SystemManager.rawAppScreenRect.xMin < screenPosition.x && 
				SystemManager.rawAppScreenRect.xMax >= screenPosition.x && 
				SystemManager.rawAppScreenRect.yMin < screenPosition.y && 
				SystemManager.rawAppScreenRect.yMax >= screenPosition.y)
				return true;
			return false;
			
		}

		// // RVA: 0x1EF6D64 Offset: 0x1EF6D64 VA: 0x1EF6D64
		// public int GetInScreenTouchCount() { }

		// // RVA: 0x1EF7318 Offset: 0x1EF7318 VA: 0x1EF7318
		public TouchInfoRecord GetFirstInScreenTouchRecord()
		{
			TouchInfoRecord res = null;
			int id = 99999;
			for(int i = 0; i < touchCount; i++)
			{
				TouchInfoRecord record = GetTouchInfoRecord(touchCount);
				if(IsTouchPositionInScreen(record.beganInfo.GetSceneInnerPosition()))
				{
					if(record.beganInfo.id < id)
					{
						id = record.beganInfo.id;
						res = record;
					}
				}
			}
			return res;
		}

		// // RVA: 0x1EF74FC Offset: 0x1EF74FC VA: 0x1EF74FC
		// public TouchInfoRecord GetInScreenTouchRecord(int order) { }

		// // RVA: 0x1EF6DD0 Offset: 0x1EF6DD0 VA: 0x1EF6DD0
		// public bool GetInScreenTouch(int order, out Touch touch) { }

		// // RVA: 0x1EF6C84 Offset: 0x1EF6C84 VA: 0x1EF6C84
		private void MousePinchAction()
		{
			if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
			{
				pinchRatio = 1.0f;
				pinchDelta = 0.0f;
				pinch = false;
				return;
			}
			if(!pinch)
			{
				pinchRatio = 1.0f;
				pinchDelta = 0.0f;
			}
			pinch = true;
			float wheel = Input.GetAxis("Mouse ScrollWheel");
			pinchRatio = pinchRatio - wheel;
			pinchDelta = -wheel;
		}

		// // RVA: 0x1EF7434 Offset: 0x1EF7434 VA: 0x1EF7434
		public TouchInfoRecord GetTouchInfoRecord(int fingerId)
		{
			if(fingerCount <= fingerId)
				return null;
			return touchInfoRecords[fingerId];
		}

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
