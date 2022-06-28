using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using System;
using System.Collections;

namespace XeApp.Game.Common
{
	[ExecuteInEditMode]
	public class PopupWindowControl : MonoBehaviour
	{
		public Text m_titleText; // 0xC
		public Image m_image; // 0x10
		public Image m_blackPanel; // 0x14
		public Image[] m_gradation; // 0x18
		public LayoutUGUIRuntime m_buttonUguiRuntime; // 0x1C
		public LayoutUGUIRuntime m_tabButtonUguiRuntime; // 0x20
		public AnimationCurve m_inCurve; // 0x24
		public AnimationCurve m_outCurve; // 0x28
		public float m_speed = 10.0f;// 0x2C
		public Sprite[] m_windowSprites; // 0x30
		// public Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> m_callBack; // 0x34
		// public Action<IPopupContent, PopupTabButton.ButtonLabel> m_contentUpdateCallBack; // 0x38
		public Action m_openStartCallBack; // 0x3C
		public Action m_openEndCallBack; // 0x40
		public Func<int> m_preCloseEndCallBack; // 0x44
		public Action<int> m_postCloseEndCallBack; // 0x48
		public Action m_closeEndCallBack; // 0x4C
		// [CompilerGeneratedAttribute] // RVA: 0x68BE8C Offset: 0x68BE8C VA: 0x68BE8C
		private Func<bool> m_closeWaitCallBack; // 0x50
		// public Func<PopupButton.ButtonType, PopupButton.ButtonLabel, bool> m_closeStartWaitCallBack; // 0x54
		// public Func<PopupWindowControl.SeType, bool> PlayWindowOpenHandler; // 0x58
		// public Func<PopupButton.ButtonLabel, PopupButton.ButtonType, bool> PlayPopupButtonSeHandler; // 0x5C
		private const string PositiveButtonSe = "se_btn_001";
		private const string NegativeButtonSe = "se_btn_002";
		private const string OtherButtonSe = "se_btn_001";
		private const string TabButtonSe = "se_btn_003";
		private const string WindowOpenSe = "se_wnd_000";
		private const string WindowCloseSe = "se_wnd_001";
		private AnimationCurve m_currentCurver; // 0x60
		private float m_time; // 0x64
		private bool m_isAnimation; // 0x68
		private bool m_isBlack; // 0x69
		// private PopupButton.ButtonLabel m_backButtonLabel; // 0x6C
		// private PopupButton.ButtonLabel m_negativeButtonLabel; // 0x70
		private PopupButton[] m_buttons; // 0x74
		private int m_validButtonCount; // 0x78
		private PopupTabButton[] m_tabButtons; // 0x7C
		private GameObject m_contentObject; // 0x80
		private ScrollRect m_scrollRect; // 0x84
		private bool m_isButtonEnable; // 0x88
		private WaitForEndOfFrame m_waitYielder = new WaitForEndOfFrame(); // 0x8C
		// private ButtonInfo[] m_tmpButtons = new ButtonInfo[6]; // 0x90
		private Mask m_rectMask; // 0x94
		private Image m_maskImage; // 0x98
		// private IPopupContent m_content; // 0x9C
		private bool m_isReady; // 0xA0
		private bool m_isSelected; // 0xA1
		// private PopupSetting m_setting; // 0xA4
		private bool m_isActive; // 0xA8
		private bool m_isOpenWindow; // 0xA9
		// private List<ButtonBase> m_inputTargetList = new List<ButtonBase>(64); // 0xAC
		private int m_blockCount; // 0xB0
		// private List<ScrollRect> m_scrollTargetList = new List<ScrollRect>(4); // 0xB4
		private int m_scrollBlockCount; // 0xB8
		private const int TitleFontSize = 28;
		private static Vector2[] s_sizeTbl = new Vector2[10] {
			new Vector2(708, 372), new Vector2(826, 470), new Vector2(1047, 660), new Vector2(544, 290), new Vector2(1047, 620),
			new Vector2(708, 372), new Vector2(826, 470), new Vector2(1047, 660), new Vector2(544, 290), new Vector2(1047, 620)
		}; // 0x0
		private static Vector2[] s_contentSizeTbl = new Vector2[10] {
			new Vector2(666, 174), new Vector2(772, 270), new Vector2(979, 461), new Vector2(502, 154), new Vector2(979, 431),
			new Vector2(666, 234), new Vector2(772, 328), new Vector2(979, 512), new Vector2(500, 152), new Vector2(979, 431)
		}; // 0x4
		private static Vector2[] s_contentSizeTbl2 = new Vector2[10] {
			new Vector2(666, 174), new Vector2(772, 270), new Vector2(980, 462), new Vector2(502, 154), new Vector2(980, 432),
			new Vector2(666, 234), new Vector2(772, 328), new Vector2(980, 512), new Vector2(500, 152), new Vector2(980, 432)
		}; // 0x8
		private static Vector2[] s_contentCenterTbl = new Vector2[10] {
			new Vector2(0, 18), new Vector2(0, 20), new Vector2(0, 20), new Vector2(0, 47), new Vector2(0, 47),
			new Vector2(0, 47), new Vector2(0, 47), new Vector2(0, 47), new Vector2(0, 47), new Vector2(0, 67)
		}; // 0xC
		private static Vector2[] s_buttonPositionTbl = new Vector2[10] {
			new Vector2(0, -123), new Vector2(0, -173), new Vector2(0, -268), new Vector2(0, -83), new Vector2(0, -248),
			new Vector2(0, -123), new Vector2(0, -173), new Vector2(0, -268), new Vector2(0, -83), new Vector2(0, -248)
		}; // 0x10
		private static float[] s_windowVerticalAdjust = new float[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, -20.0f }; // 0x14
		private const int SizeTableTitleOffset = 5;
		// public bool IsActive { get; } 0x1BB888C
		// public IPopupContent Content { get; } 0x1BB8894

		// [CompilerGeneratedAttribute] // RVA: 0x73EBD4 Offset: 0x73EBD4 VA: 0x73EBD4
		// // RVA: 0x1BB8674 Offset: 0x1BB8674 VA: 0x1BB8674
		// public void add_m_closeWaitCallBack(Func<bool> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73EBE4 Offset: 0x73EBE4 VA: 0x73EBE4
		// // RVA: 0x1BB8780 Offset: 0x1BB8780 VA: 0x1BB8780
		// public void remove_m_closeWaitCallBack(Func<bool> value) { }

		// // RVA: 0x1BB889C Offset: 0x1BB889C VA: 0x1BB889C
		// private static int CalcTblIndex(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB88A8 Offset: 0x1BB88A8 VA: 0x1BB88A8
		// public static Vector2 GetWindowSize(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB36F4 Offset: 0x1BB36F4 VA: 0x1BB36F4
		// public static Vector2 GetContentSize(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BADFE0 Offset: 0x1BADFE0 VA: 0x1BADFE0
		// public static Vector2 GetContentSize2(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB8988 Offset: 0x1BB8988 VA: 0x1BB8988
		// public static Vector2 GetContentButtonPosition(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB8A68 Offset: 0x1BB8A68 VA: 0x1BB8A68
		// public static Vector2 GetContentCenterOffset(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB8B48 Offset: 0x1BB8B48 VA: 0x1BB8B48
		// public static Vector2 GetWindowVerticalAdjust(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB8C38 Offset: 0x1BB8C38 VA: 0x1BB8C38
		// private void OnPlayWindowOpenSe() { }

		// // RVA: 0x1BB8E08 Offset: 0x1BB8E08 VA: 0x1BB8E08
		// private void OnPlayWindowCloseSe() { }

		// // RVA: 0x1BB8EE4 Offset: 0x1BB8EE4 VA: 0x1BB8EE4
		private void Start()
		{
			if(m_blackPanel != null)
			{
				m_blackPanel.gameObject.SetActive(false);
			}
			m_buttons = GetComponentsInChildren<PopupButton>(true);
			Array.Sort(m_buttons, (PopupButton left, PopupButton right) => {
				//0x1BBDAC4
				return string.Compare(left.name, right.name);
			});
			for(int i = 0; i < m_buttons.Length; i++)
			{
				m_buttons[i].AddOnClickCallback(() => {
					//0x1BBDC54
					UnityEngine.Debug.LogError("TODO");
				});
			}
			m_tabButtons = GetComponentsInChildren<PopupTabButton>(true);
			Array.Sort(m_buttons, (PopupButton left, PopupButton right) => {
				//0x1BBDB24
				return string.Compare(left.name, right.name);
			});
			Array.Reverse(m_tabButtons, 0, m_tabButtons.Length);
			for(int i = 0; i < m_tabButtons.Length; i++)
			{
				m_tabButtons[i].AddOnClickCallback(() => {
					// 0x1BBDFF0
					UnityEngine.Debug.LogError("TODO");
				});
			}
			m_scrollRect = GetComponentInChildren<ScrollRect>(true);
			m_rectMask = m_scrollRect.GetComponent<Mask>();
			m_maskImage = m_scrollRect.GetComponent<Image>();
			StartCoroutine(WaitLoadLayout());
		}

		// // RVA: 0x1BB956C Offset: 0x1BB956C VA: 0x1BB956C
		// public static void PlaySePositive() { }

		// // RVA: 0x1BB967C Offset: 0x1BB967C VA: 0x1BB967C
		// public static void PlaySeNegative() { }

		// // RVA: 0x1BB978C Offset: 0x1BB978C VA: 0x1BB978C
		// public void PushNegativeOtherButton() { }

		// // RVA: 0x1BB995C Offset: 0x1BB995C VA: 0x1BB995C
		// private void PushBackButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73EBF4 Offset: 0x73EBF4 VA: 0x73EBF4
		// // RVA: 0x1BB94E0 Offset: 0x1BB94E0 VA: 0x1BB94E0
		private IEnumerator WaitLoadLayout()
		{
			UnityEngine.Debug.Log("Enter Popup WaitLoadLayout");
			UnityEngine.Debug.LogWarning("TODO Popup WaitLoadLayout");
			UnityEngine.Debug.Log("Exit Popup WaitLoadLayout");
			m_image.gameObject.SetActive(false);
			yield break;
		}

		// // RVA: 0x1BB9B18 Offset: 0x1BB9B18 VA: 0x1BB9B18
		// public bool IsReady() { }

		// // RVA: 0x1BB9B20 Offset: 0x1BB9B20 VA: 0x1BB9B20
		// private bool IsLoadedLayout() { }

		// // RVA: 0x1BB9BC4 Offset: 0x1BB9BC4 VA: 0x1BB9BC4
		// public void Show(PopupSetting setting, bool isShowBlack = True, bool isButtonEnable = True, bool isError = False) { }

		// // RVA: 0x1BBB064 Offset: 0x1BBB064 VA: 0x1BBB064
		// public void Close(Action endCallBack, PopupButton button) { }

		// // RVA: 0x1BBB25C Offset: 0x1BBB25C VA: 0x1BBB25C
		// public void ShowGradation() { }

		// // RVA: 0x1BBB2F0 Offset: 0x1BBB2F0 VA: 0x1BBB2F0
		// private bool LoadResourceCallBack(FileResultObject fro) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73EC6C Offset: 0x73EC6C VA: 0x73EC6C
		// // RVA: 0x1BBAFD8 Offset: 0x1BBAFD8 VA: 0x1BBAFD8
		// private IEnumerator LoadResourceAssetBundleCoroutine() { }

		// // RVA: 0x1BBA7FC Offset: 0x1BBA7FC VA: 0x1BBA7FC
		// private void SetupContent(GameObject content) { }

		// // RVA: 0x1BBA6D0 Offset: 0x1BBA6D0 VA: 0x1BBA6D0
		// private void ReleaseResource() { }

		// // RVA: 0x1BBB480 Offset: 0x1BBB480 VA: 0x1BBB480
		// private void SetActiveImage(bool active) { }

		// // RVA: 0x1BBB528 Offset: 0x1BBB528 VA: 0x1BBB528
		// private bool IsPlayingButtonAnim() { }

		// // RVA: 0x1BBB660 Offset: 0x1BBB660 VA: 0x1BBB660
		// public bool IsActivePopupWindow() { }

		// // RVA: 0x1BBB668 Offset: 0x1BBB668 VA: 0x1BBB668
		// public bool IsOpenPopupWindow() { }

		// // RVA: 0x1BBB670 Offset: 0x1BBB670 VA: 0x1BBB670
		// public void SetButtonHiddenEnable(bool enable) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73ECE4 Offset: 0x73ECE4 VA: 0x73ECE4
		// // RVA: 0x1BBB3F4 Offset: 0x1BBB3F4 VA: 0x1BBB3F4
		// private IEnumerator ShowPopupWindow() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73ED5C Offset: 0x73ED5C VA: 0x73ED5C
		// // RVA: 0x1BBB19C Offset: 0x1BBB19C VA: 0x1BBB19C
		// private IEnumerator ClosePopupWindow(Action endCallBack, PopupButton button) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73EDD4 Offset: 0x73EDD4 VA: 0x73EDD4
		// // RVA: 0x1BBB7C8 Offset: 0x1BBB7C8 VA: 0x1BBB7C8
		// private IEnumerator PlayPopupWindowAnim() { }

		// // RVA: 0x1BB113C Offset: 0x1BB113C VA: 0x1BB113C
		// public void InputDisable() { }

		// // RVA: 0x1BB1264 Offset: 0x1BB1264 VA: 0x1BB1264
		// public void InputEnable() { }

		// // RVA: 0x1BBB904 Offset: 0x1BBB904 VA: 0x1BBB904
		// public void ScrollDisable() { }

		// // RVA: 0x1BBBCC8 Offset: 0x1BBBCC8 VA: 0x1BBBCC8
		// public void ScrollEnable() { }

		// // RVA: 0x1BBB874 Offset: 0x1BBB874 VA: 0x1BBB874
		// private void ListGraphicObject() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73EE4C Offset: 0x73EE4C VA: 0x73EE4C
		// // RVA: 0x1BBC090 Offset: 0x1BBC090 VA: 0x1BBC090
		// private IEnumerator IsReadyButtons() { }

		// // RVA: 0x1BAC4B4 Offset: 0x1BAC4B4 VA: 0x1BAC4B4
		// public PopupButton FindButton(PopupButton.ButtonLabel label) { }

		// // RVA: 0x1BBC144 Offset: 0x1BBC144 VA: 0x1BBC144
		// public PopupButton FindButton(PopupButton.ButtonType type) { }

		// // RVA: 0x1BBC234 Offset: 0x1BBC234 VA: 0x1BBC234
		// public void ForceChangeScrollPosition(float value) { }

		// // RVA: 0x1BBC288 Offset: 0x1BBC288 VA: 0x1BBC288
		// public void ResetScroll(PopupSetting setting, IPopupContent content, float scrollPosition = 1) { }

		// // RVA: 0x1BBC534 Offset: 0x1BBC534 VA: 0x1BBC534
		// public void StopScrollMovement() { }

		// // RVA: 0x1BBC568 Offset: 0x1BBC568 VA: 0x1BBC568
		// public static void PlayPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type, CriAtomSource source) { }

		// // RVA: 0x1BB8D14 Offset: 0x1BB8D14 VA: 0x1BB8D14
		// public static void PlayPopupWindowOpenSe(PopupWindowControl.SeType type, CriAtomSource source) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73EEC4 Offset: 0x73EEC4 VA: 0x73EEC4
		// // RVA: 0x1BBD934 Offset: 0x1BBD934 VA: 0x1BBD934
		// private void <Close>b__86_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73EED4 Offset: 0x73EED4 VA: 0x73EED4
		// // RVA: 0x1BBDA44 Offset: 0x1BBDA44 VA: 0x1BBDA44
		// private void <SetupContent>b__90_0() { }
	}
}
