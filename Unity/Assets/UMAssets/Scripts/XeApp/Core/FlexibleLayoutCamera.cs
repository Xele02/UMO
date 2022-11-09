using UnityEngine;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Core
{
	public class FlexibleLayoutCamera : MonoBehaviour
	{
		[SerializeField]
		private List<Camera> flexibleViewportCameraList; // 0xC
		[SerializeField]
		private List<Camera> flexibleFovCameraList; // 0x10
		private List<float> flexibleDefaultFovList; // 0x14
		[SerializeField]
		private float baseWidth; // 0x18
		[SerializeField]
		private float baseHeight; // 0x1C
		private bool isEnableFov = true; // 0x20
		private bool isEnableViewPort = true; // 0x21

		//public bool IsEnableFov { get; set; } 0x1D704B0 0x1D704B8
		//public bool IsEnableViewPort { get; set; } 0x1D704C0 0x1D704C8
		//public List<Camera> FlexibleFovCameraList { get; } 0x1D704D0
		//public List<Camera> FlexibleViewportCameraList { get; } 0x1D704D8

		// RVA: 0x1D704E0 Offset: 0x1D704E0 VA: 0x1D704E0
		private void Start()
		{
			if (baseWidth <= 0)
				baseWidth = SystemManager.BaseScreenSize.x;
			if (baseHeight <= 0)
				baseHeight = SystemManager.BaseScreenSize.y;
			flexibleDefaultFovList = new List<float>(flexibleFovCameraList.Count);
			for(int i = 0; i < flexibleFovCameraList.Count; i++)
			{
				flexibleDefaultFovList.Add(flexibleFovCameraList[i].fieldOfView);
			}
			FlexibleAspectProcess();
			FlexibleFovProcess();
		}

		// RVA: 0x1D70F68 Offset: 0x1D70F68 VA: 0x1D70F68
		private void Update()
		{
			return;
		}

		//// RVA: 0x1D70F6C Offset: 0x1D70F6C VA: 0x1D70F6C
		//public void CameraListClear() { }

		//// RVA: 0x1D71030 Offset: 0x1D71030 VA: 0x1D71030
		//public void AddCamera(Camera camera, float fov) { }

		//// RVA: 0x1D70CCC Offset: 0x1D70CCC VA: 0x1D70CCC
		private void FlexibleFovProcess()
		{
			if(isEnableFov)
			{
				float baseRatio = baseWidth / baseHeight;
				bool needAdapt = baseRatio <= Screen.width * 1.0f / Screen.height;
				for (int i = 0; i < flexibleFovCameraList.Count; i++)
				{
					for(int j = 0; j < flexibleViewportCameraList.Count; j++)
					{
						if(flexibleViewportCameraList[j] == flexibleFovCameraList[i])
						{
							needAdapt &= GetOverPermissionAspectResult() == SystemManager.OverPermissionAspectResult.None;
							break;
						}
					}
					flexibleFovCameraList[i].fieldOfView = needAdapt ? baseRatio / (Screen.width * 1.0f / Screen.height) * flexibleDefaultFovList[i] : flexibleDefaultFovList[i];
				}
			}
		}

		//// RVA: 0x1D706F0 Offset: 0x1D706F0 VA: 0x1D706F0
		private void FlexibleAspectProcess()
		{
			if(isEnableViewPort)
			{
				if(SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.None)
				{
					for(int i = 0; i < flexibleViewportCameraList.Count; i++)
					{
						flexibleViewportCameraList[i].rect = new Rect(0, 0, 1, 1);
					}
				}
			}
			else
			{
				float w, h, sw, sh, r, sr;
				if(SystemManager.isLongScreenDevice)
				{
					if(SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.HdivV)
					{
						w = baseWidth;
						h = baseHeight;
						sw = Screen.width;
						sh = Screen.height;
						r = w / h;
					}
					else
					{
						w = baseWidth;
						h = baseHeight;
						sw = Screen.height;
						sh = Screen.width;
						r = w / h;
					}
					sr = sw / sh;
				}
				else
				{
					w = 1;
					h = 1;
					sw = Screen.width;
					sh = Screen.height;
					r = 1.777778f;
					sr = sw / sh;
				}
				float safeRatio = 1;
				if(SystemManager.rawSafeAreaRect.height >= 0)
				{
					safeRatio = SystemManager.rawSafeAreaRect.height / SystemManager.rawScreenAreaRect.height;
				}
				r = r / sr;
				float f = (1 - r) * 0.5f;
				for (int i = 0; i < flexibleViewportCameraList.Count; i++)
				{
					if (SystemManager.isLongScreenDevice)
					{
						if (SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.VdivH)
							flexibleViewportCameraList[i].rect = new Rect(0, f, 1, r);
						else
							flexibleViewportCameraList[i].rect = new Rect(f, 0, r, 1);
					}
					else
						flexibleViewportCameraList[i].rect = new Rect(f, 1 - safeRatio, r, safeRatio);
				}
			}
		}

		//// RVA: 0x1D711C0 Offset: 0x1D711C0 VA: 0x1D711C0
		//public void SetDisable() { }

		//// RVA: 0x1D711C4 Offset: 0x1D711C4 VA: 0x1D711C4
		//public void SetEnable() { }

		//// RVA: 0x1D711E0 Offset: 0x1D711E0 VA: 0x1D711E0
		//public float GetDefaultFov(int cameraListIndex) { }

		//// RVA: 0x1D71260 Offset: 0x1D71260 VA: 0x1D71260
		private SystemManager.OverPermissionAspectResult GetOverPermissionAspectResult()
		{
			return SystemManager.Instance.CheckOverPermissionAspectRatio();
		}

		//// RVA: 0x1D712FC Offset: 0x1D712FC VA: 0x1D712FC
		//private bool IsPermissionAspect() { }

		//// RVA: 0x1D711A8 Offset: 0x1D711A8 VA: 0x1D711A8
		//private bool IsOverPermissionAspect() { }

		//// RVA: 0x1D7131C Offset: 0x1D7131C VA: 0x1D7131C
		//private bool IsOverAspectHdivV() { }

		//// RVA: 0x1D71334 Offset: 0x1D71334 VA: 0x1D71334
		//private bool IsOverAspectVdivH() { }
	}
}
