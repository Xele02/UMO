using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Core
{
	[RequireComponent(typeof(CanvasScaler))] // RVA: 0x651354 Offset: 0x651354 VA: 0x651354
	[RequireComponent(typeof(LayoutElement))]
	[RequireComponent(typeof(ContentSizeFitter))]
	public class FlexibleCanvasLayoutChanger : MonoBehaviour
	{
		private bool isExpand; // 0xC
		private RectTransform rect; // 0x10
		private RectTransform childRootRect; // 0x14
		private CanvasScaler canvasScaler; // 0x18
		private LayoutElement layoutElement; // 0x1C
		private ContentSizeFitter contentSizeFitter; // 0x20
		private CanvasScaler.ScreenMatchMode defaultMatchMode; // 0x24

		// // RVA: 0x1D6FE38 Offset: 0x1D6FE38 VA: 0x1D6FE38
		private void Start()
		{
			rect = GetComponent<RectTransform>();
			childRootRect = transform.Find("Root").GetComponent<RectTransform>();
			canvasScaler = GetComponent<CanvasScaler>();
			layoutElement = GetComponent<LayoutElement>();
			contentSizeFitter = GetComponent<ContentSizeFitter>();
			defaultMatchMode = canvasScaler.screenMatchMode;
			UpdateForLongScreenDevice();
			CanvasScalerModeCheck();
		}

		// // RVA: 0x1D702EC Offset: 0x1D702EC VA: 0x1D702EC
		private void Update()
		{
			return;
		}

		// // RVA: 0x1D702F0 Offset: 0x1D702F0 VA: 0x1D702F0
		private void LateUpdate()
		{
			if(!isExpand)
			{
				childRootRect.sizeDelta = rect.sizeDelta;
			}
			else
			{
				childRootRect.sizeDelta = canvasScaler.referenceResolution;
			}
		}

		// // RVA: 0x1D70230 Offset: 0x1D70230 VA: 0x1D70230
		public void CanvasScalerModeCheck()
		{
			if(SystemManager.Instance.CheckOverPermissionAspectRatio() != SystemManager.OverPermissionAspectResult.None)
			{
				ToExpand();
			}
			else
			{
				ToDefault();
			}
		}

		// // RVA: 0x1D6FF94 Offset: 0x1D6FF94 VA: 0x1D6FF94
		public void UpdateForLongScreenDevice()
		{
			if(SystemManager.isLongScreenDevice)
			{
				canvasScaler.referenceResolution = SystemManager.longScreenReferenceResolution;
				if(SystemManager.rawSafeAreaRect.y > 0)
				{
					childRootRect.localScale = new Vector3(SystemManager.rawSafeAreaRect.height * 1.0f / SystemManager.rawScreenAreaRect.height, SystemManager.rawSafeAreaRect.height * 1.0f / SystemManager.rawScreenAreaRect.height, 1);
					childRootRect.localPosition = new Vector3(0, SystemManager.rawSafeAreaRect.position.y * SystemManager.longScreenReferenceResolution.y * 1.0f / SystemManager.rawScreenAreaRect.height * 0.5f, 0);
				}
			}
		}

		// // RVA: 0x1D70418 Offset: 0x1D70418 VA: 0x1D70418
		private void ToExpand()
		{
			canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			layoutElement.enabled = true;
			contentSizeFitter.enabled = true;
			isExpand = true;
		}

		// // RVA: 0x1D70384 Offset: 0x1D70384 VA: 0x1D70384
		private void ToDefault()
		{
			canvasScaler.screenMatchMode = defaultMatchMode;
			layoutElement.enabled = false;
			contentSizeFitter.enabled = false;
			isExpand = false;
		}
	}
}
