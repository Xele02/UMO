using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Core
{
	[RequireComponent(typeof(CanvasScaler))] // RVA: 0x651354 Offset: 0x651354 VA: 0x651354
	[RequireComponent(typeof(LayoutElement))]
	[RequireComponent(typeof(ContentSizeFitter))]
	public class FlexibleCanvasLayoutChanger : MonoBehaviour
	{
		// Fields
		private bool isExpand; // 0xC
		private RectTransform rect; // 0x10
		private RectTransform childRootRect; // 0x14
		private CanvasScaler canvasScaler; // 0x18
		private LayoutElement layoutElement; // 0x1C
		private ContentSizeFitter contentSizeFitter; // 0x20
		private CanvasScaler.ScreenMatchMode defaultMatchMode; // 0x24

		// Methods

		// // RVA: 0x1D6FE38 Offset: 0x1D6FE38 VA: 0x1D6FE38
		// private void Start() { }

		// // RVA: 0x1D702EC Offset: 0x1D702EC VA: 0x1D702EC
		// private void Update() { }

		// // RVA: 0x1D702F0 Offset: 0x1D702F0 VA: 0x1D702F0
		// private void LateUpdate() { }

		// // RVA: 0x1D70230 Offset: 0x1D70230 VA: 0x1D70230
		// public void CanvasScalerModeCheck() { }

		// // RVA: 0x1D6FF94 Offset: 0x1D6FF94 VA: 0x1D6FF94
		// public void UpdateForLongScreenDevice() { }

		// // RVA: 0x1D70418 Offset: 0x1D70418 VA: 0x1D70418
		// private void ToExpand() { }

		// // RVA: 0x1D70384 Offset: 0x1D70384 VA: 0x1D70384
		// private void ToDefault() { }

		// // RVA: 0x1D704A8 Offset: 0x1D704A8 VA: 0x1D704A8
		// public void .ctor() { }
	}
}
