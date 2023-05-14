using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneImageViewer : MonoBehaviour
	{
		public enum ScenePage
		{
			NORMAL = 0,
			EVOLV = 1,
			KIRA = 2,
		}

		private enum ChildObject
		{
			SwaipTouch = 3,
			LeftArrow = 4,
			RightArrow = 5,
			Page = 6,
			Close = 7,
		}

		[SerializeField]
		private SceneViewerArrow leftArrow; // 0xC
		[SerializeField]
		private SceneViewerArrow rightArrow; // 0x10
		[SerializeField]
		private RawImageEx m_kiraEffectImage; // 0x14
		[SerializeField]
		private RawImageEx m_kiraOverlayEffectImage; // 0x18
		private List<ActionButton> m_arrowButton = new List<ActionButton>(); // 0x1C
		private List<GameObject> m_arrowButtonObject = new List<GameObject>(); // 0x20
		private ActionButton m_closeButton; // 0x24
		private GameObject m_closeButtonObject; // 0x28
		private ZoomSceneFrame[] m_frameInstance = new ZoomSceneFrame[2]; // 0x2C
		private GameObject m_frameRootObject; // 0x30
		private RawImageEx m_sceneImage; // 0x34
		private RectTransform m_rectTransform; // 0x38
		private const string AssetBundleName = "ly/016.xab";
		private readonly string[] framePrefabNames = new string[9]
		{
			"PlateFrame001", "PlateFrame002", "PlateFrame003", "PlateFrame004", 
			"PlateFrame005", "PlateFrame006", "PlateFrame007_1", "PlateFrame007_2",
			"PlateFrame003_4"
		}; // 0x40
		private Material material; // 0x44
		private int m_page = 1; // 0x48
		private bool m_isKira; // 0x4C
		private bool m_EndViewer; // 0x4D
		private bool IsRArrowEnable; // 0x4E
		private bool IsLArrowEnable; // 0x4F
		private static Vector2 CardSize = new Vector2(244, 138); // 0x0
		private static Vector2 CardSizeHighRare = new Vector2(1184, 666); // 0x8
		private static Rect CardUv = new Rect(0.0234375f, 0.2319336f, 0.9526367f, 0.5366211f); // 0x10
		private static Rect CardUvHighRare = new Rect(0.0f, 0.21875f, 1.0f, 0.5625f); // 0x20
		private SceneViewerPageLamp m_pageLamp; // 0x50
		//[CompilerGeneratedAttribute] // RVA: 0x67B82C Offset: 0x67B82C VA: 0x67B82C
		public UnityAction<int> onLeftArrow; // 0x54
		//[CompilerGeneratedAttribute] // RVA: 0x67B83C Offset: 0x67B83C VA: 0x67B83C
		public UnityAction<int> onRightArrow; // 0x58
		//[CompilerGeneratedAttribute] // RVA: 0x67B84C Offset: 0x67B84C VA: 0x67B84C
		public UnityAction onClose; // 0x5C
		private bool m_isEventCall; // 0x60
		private bool m_isEvolv; // 0x61
		private bool m_isVisible; // 0x62
		private bool m_isToucheDisable; // 0x63
		private bool m_isTouchImage; // 0x64
		private bool m_isScroll; // 0x65
		private SwaipTouch m_swaipTouch; // 0x68
		private Button m_touchButton; // 0x6C
		private Rect m_cardUv; // 0x70

		public bool IsZoomable { get; set; } // 0x3C

		// RVA: 0x1372C38 Offset: 0x1372C38 VA: 0x1372C38
		private void Start()
		{
			TodoLogger.Log(0, "Start");
		}

		// // RVA: 0x137334C Offset: 0x137334C VA: 0x137334C
		// public void SetTexture(Texture2D texture) { }

		// // RVA: 0x1373544 Offset: 0x1373544 VA: 0x1373544
		// public void SetTexture(IiconTexture texture) { }

		// // RVA: 0x1373BA8 Offset: 0x1373BA8 VA: 0x1373BA8
		// private void OnLeftArrow() { }

		// // RVA: 0x1373C18 Offset: 0x1373C18 VA: 0x1373C18
		// private void OnRightArrow() { }

		// // RVA: 0x1373C88 Offset: 0x1373C88 VA: 0x1373C88
		// private void PushLeftArrow() { }

		// // RVA: 0x1373DA8 Offset: 0x1373DA8 VA: 0x1373DA8
		// private void PushRightArrow() { }

		// // RVA: 0x1373E20 Offset: 0x1373E20 VA: 0x1373E20
		// private void OnPushClose() { }

		// // RVA: 0x1373E4C Offset: 0x1373E4C VA: 0x1373E4C
		// public void Initialize(bool isEvolv, int baseRare, bool isKira = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70F68C Offset: 0x70F68C VA: 0x70F68C
		// // RVA: 0x137482C Offset: 0x137482C VA: 0x137482C
		// public IEnumerator Co_LoadRareFrame(int baseRare) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70F704 Offset: 0x70F704 VA: 0x70F704
		// // RVA: 0x13748F4 Offset: 0x13748F4 VA: 0x13748F4
		// public IEnumerator Co_ReleaseRareFrame() { }

		// // RVA: 0x13749A0 Offset: 0x13749A0 VA: 0x13749A0
		// public void Show() { }

		// // RVA: 0x1374BD8 Offset: 0x1374BD8 VA: 0x1374BD8
		// public void Close() { }

		// // RVA: 0x1374D20 Offset: 0x1374D20 VA: 0x1374D20
		// public void InputDisable() { }

		// // RVA: 0x1374A94 Offset: 0x1374A94 VA: 0x1374A94
		// public void InputEnable() { }

		// // RVA: 0x13743A4 Offset: 0x13743A4 VA: 0x13743A4
		// public void SetPage(int page) { }

		// // RVA: 0x1374E64 Offset: 0x1374E64 VA: 0x1374E64
		// private void ChangeEnableKiraEffect(bool _isKira) { }

		// // RVA: 0x13744D4 Offset: 0x13744D4 VA: 0x13744D4
		// private void UpdateArrow(int page) { }

		// // RVA: 0x137503C Offset: 0x137503C VA: 0x137503C
		// private void OnUiToggle() { }

		// // RVA: 0x1375338 Offset: 0x1375338 VA: 0x1375338
		// public static Vector2 GetCardSize(float screenWidth) { }

		// // RVA: 0x1375380 Offset: 0x1375380 VA: 0x1375380
		// public static Vector3 GetStartScale(int baseRare, float width) { }

		// // RVA: 0x13753D8 Offset: 0x13753D8 VA: 0x13753D8
		// public static float GetEndScale(int baseRare) { }

		// // RVA: 0x13743F8 Offset: 0x13743F8 VA: 0x13743F8
		// public static Rect GetCardUv(int baseRare) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70F77C Offset: 0x70F77C VA: 0x70F77C
		// // RVA: 0x1375278 Offset: 0x1375278 VA: 0x1375278
		// private IEnumerator Co_ImageSizeChange(bool isZoom, UnityAction endCb) { }

		// RVA: 0x1375400 Offset: 0x1375400 VA: 0x1375400
		private void Update()
		{
			TodoLogger.Log(0, "Update");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F7F4 Offset: 0x70F7F4 VA: 0x70F7F4
		// // RVA: 0x1373D00 Offset: 0x1373D00 VA: 0x1373D00
		// private IEnumerator Co_Scroll(int dir) { }

		// // RVA: 0x13755EC Offset: 0x13755EC VA: 0x13755EC
		// private void ScrollRight() { }

		// // RVA: 0x137561C Offset: 0x137561C VA: 0x137561C
		// private void ScrollLeft() { }

		// // RVA: 0x1374FCC Offset: 0x1374FCC VA: 0x1374FCC
		// private void ArrowLayoutChange() { }

		// // RVA: 0x137564C Offset: 0x137564C VA: 0x137564C
		// public void SetFrame(int baseRare, int attr, bool isRankUp) { }

		// // RVA: 0x1375904 Offset: 0x1375904 VA: 0x1375904
		// public void PerformClick() { }

		// [CompilerGeneratedAttribute] // RVA: 0x70F86C Offset: 0x70F86C VA: 0x70F86C
		// // RVA: 0x1375FF8 Offset: 0x1375FF8 VA: 0x1375FF8
		// private void <OnUiToggle>b__67_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x70F87C Offset: 0x70F87C VA: 0x70F87C
		// // RVA: 0x1376030 Offset: 0x1376030 VA: 0x1376030
		// private void <OnUiToggle>b__67_1() { }
	}
}
