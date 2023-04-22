using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Core
{
	[RequireComponent(typeof(Camera))] // RVA: 0x6512DC Offset: 0x6512DC VA: 0x6512DC
	public class FlexibleCameraChanger : MonoBehaviour
	{
		private List<Camera> flexibleViewportCameraList = new List<Camera>(); // 0xC
		private List<Camera> flexibleFovCameraList = new List<Camera>(); // 0x10
		private List<float> flexibleDefaultFovList; // 0x14
		[SerializeField]
		private bool isEnableFlexibleViewport = true; // 0x18
		[SerializeField]
		private bool isEnableFlexibleFov; // 0x19
		[SerializeField]
		private float baseWidth; // 0x1C
		[SerializeField]
		private float baseHeight; // 0x20

		//public bool IsEnableFlexibleViewport { get; set; } 0x1D6EF60 0x1D6EF68
		//public bool IsEnableFlexibleFov { get; set; } 0x1D6EF70 0x1D6EF78

		// RVA: 0x1D6EF80 Offset: 0x1D6EF80 VA: 0x1D6EF80
		private void Start()
		{
			Initialize();
		}

		// RVA: 0x1D6F29C Offset: 0x1D6F29C VA: 0x1D6F29C
		private void Update()
		{
			return;
		}

		//// RVA: 0x1D6F2A0 Offset: 0x1D6F2A0 VA: 0x1D6F2A0
		private void FlexibleFovProcess()
		{
			if(isEnableFlexibleFov)
			{
				var r = baseWidth / baseHeight;
				bool b = false;
				if (r <= (Screen.width / Screen.height))
					b = true;
				for (int i = 0; i < flexibleFovCameraList.Count; i++)
				{
					for(int j = 0; j < flexibleViewportCameraList.Count; j++)
					{
						if(flexibleViewportCameraList[j] == flexibleFovCameraList[i])
						{
							b &= GetOverPermissionAspectResult() == SystemManager.OverPermissionAspectResult.None;
							break;
						}
					}
					if(b)
					{
						flexibleFovCameraList[i].fieldOfView = (r / (Screen.width / Screen.height)) * flexibleDefaultFovList[i];
					}
					else
					{
						flexibleFovCameraList[i].fieldOfView = flexibleDefaultFovList[i];
					}
				}
			}
		}

		//// RVA: 0x1D6F554 Offset: 0x1D6F554 VA: 0x1D6F554
		private void FlexibleAspectProcess()
		{
			if(isEnableFlexibleViewport)
			{
				if(SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.None)
				{
					for(int i = 0; i < flexibleViewportCameraList.Count; i++)
					{
						flexibleViewportCameraList[i].rect = new Rect(0, 0, 1, 1);
					}
				}
				else
				{
					float sw, sh, bw, bh, r, sr;
					if(!SystemManager.isLongScreenDevice)
					{
						if (SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.HdivV)
						{
							bw = baseWidth;
							bh = baseHeight;
							sw = Screen.width;
							sh = Screen.height;
							r = bw / bh;
						}
						else
						{
							bw = baseHeight;
							bh = baseWidth;
							sw = Screen.height;
							sh = Screen.width;
							r = bw / bh;
						}
						sr = sw / sh;
					}
					else
					{
						r = 1.777778f;
						sr = Screen.width / Screen.height;
					}
					float g = 1;
					if(SystemManager.rawSafeAreaRect.yMin >= 0)
					{
						g = SystemManager.rawSafeAreaRect.width / SystemManager.rawScreenAreaRect.width;
					}
					r = r / sr;
					float h = (1 - r) * 0.5f;
					for(int i = 0; i < flexibleViewportCameraList.Count; i++)
					{
						if(!SystemManager.isLongScreenDevice)
						{
							if(SystemManager.Instance.CheckOverPermissionAspectRatio() == SystemManager.OverPermissionAspectResult.VdivH)
							{
								flexibleViewportCameraList[i].rect = new Rect(0, h, 1, r);
							}
							else
							{
								flexibleViewportCameraList[i].rect = new Rect(h, 0, r, 1);
							}
						}
						else
						{
							flexibleViewportCameraList[i].rect = new Rect(h, 1 - g, r, g);
						}
					}
				}
			}
		}

		//// RVA: 0x1D6FB30 Offset: 0x1D6FB30 VA: 0x1D6FB30
		private SystemManager.OverPermissionAspectResult GetOverPermissionAspectResult()
		{
			return SystemManager.Instance.CheckOverPermissionAspectRatio();
		}

		//// RVA: 0x1D6FBCC Offset: 0x1D6FBCC VA: 0x1D6FBCC
		//private bool IsPermissionAspect() { }

		//// RVA: 0x1D6F53C Offset: 0x1D6F53C VA: 0x1D6F53C
		//private bool IsOverPermissionAspect() { }

		//// RVA: 0x1D6FBEC Offset: 0x1D6FBEC VA: 0x1D6FBEC
		//private bool IsOverAspectHdivV() { }

		//// RVA: 0x1D6FC04 Offset: 0x1D6FC04 VA: 0x1D6FC04
		//private bool IsOverAspectVdivH() { }

		//// RVA: 0x1D6FC24 Offset: 0x1D6FC24 VA: 0x1D6FC24
		public static FlexibleCameraChanger AddComponent(GameObject go, bool flexibleViewport, bool flexibleFov, float baseWidth = 0, float baseHeight = 0)
		{
			FlexibleCameraChanger res = go.AddComponent<FlexibleCameraChanger>();
			res.isEnableFlexibleFov = flexibleFov;
			res.isEnableFlexibleViewport = flexibleViewport;
			res.baseWidth = baseWidth;
			res.baseHeight = baseHeight;
			return res;
		}

		//// RVA: 0x1D6EF84 Offset: 0x1D6EF84 VA: 0x1D6EF84
		public void Initialize()
		{
			if(baseWidth <= 0.0)
			{
				baseWidth = SystemManager.BaseScreenSize.x;
			}
			if(baseHeight <= 0.0)
			{
				baseHeight = SystemManager.BaseScreenSize.y;
			}
			flexibleViewportCameraList.Clear();
			flexibleFovCameraList.Clear();
			if(isEnableFlexibleViewport)
			{
				flexibleViewportCameraList.AddRange(GetComponents<Camera>());
			}
			if(isEnableFlexibleFov)
			{
				flexibleFovCameraList.AddRange(GetComponents<Camera>());
			}
			flexibleDefaultFovList = new List<float>(flexibleFovCameraList.Count);
			for(int i = 0; i < flexibleFovCameraList.Count; i++)
			{
				flexibleDefaultFovList.Add(flexibleFovCameraList[i].fieldOfView);
			}
			FlexibleAspectProcess();
			FlexibleFovProcess();
		}

		//// RVA: 0x1D6FD0C Offset: 0x1D6FD0C VA: 0x1D6FD0C
		//public float GetDefaultFov(int cameraListIndex) { }
	}
}
