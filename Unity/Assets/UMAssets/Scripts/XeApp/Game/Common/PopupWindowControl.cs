using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using System;
using System.Collections;
using System.Collections.Generic;
using XeSys;
using CriWare;

namespace XeApp.Game.Common
{
	[ExecuteInEditMode]
	public class PopupWindowControl : MonoBehaviour
	{
		public enum SeType
		{
			WindowOpen = 0,
			WindowClose = 1,
		}

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
		public Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> m_callBack; // 0x34
		public Action<IPopupContent, PopupTabButton.ButtonLabel> m_contentUpdateCallBack; // 0x38
		public Action m_openStartCallBack; // 0x3C
		public Action m_openEndCallBack; // 0x40
		public Func<int> m_preCloseEndCallBack; // 0x44
		public Action<int> m_postCloseEndCallBack; // 0x48
		public Action m_closeEndCallBack; // 0x4C
		// [CompilerGeneratedAttribute] // RVA: 0x68BE8C Offset: 0x68BE8C VA: 0x68BE8C
		public Func<bool> m_closeWaitCallBack; // 0x50
		public Func<PopupButton.ButtonType, PopupButton.ButtonLabel, bool> m_closeStartWaitCallBack; // 0x54
		public Func<PopupWindowControl.SeType, bool> PlayWindowOpenHandler; // 0x58
		public Func<PopupButton.ButtonLabel, PopupButton.ButtonType, bool> PlayPopupButtonSeHandler; // 0x5C
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
		private PopupButton.ButtonLabel m_backButtonLabel; // 0x6C
		private PopupButton.ButtonLabel m_negativeButtonLabel; // 0x70
		private PopupButton[] m_buttons; // 0x74
		private int m_validButtonCount; // 0x78
		private PopupTabButton[] m_tabButtons; // 0x7C
		private GameObject m_contentObject; // 0x80
		private ScrollRect m_scrollRect; // 0x84
		private bool m_isButtonEnable; // 0x88
		private WaitForEndOfFrame m_waitYielder = new WaitForEndOfFrame(); // 0x8C
		private ButtonInfo[] m_tmpButtons = new ButtonInfo[6]; // 0x90
		private Mask m_rectMask; // 0x94
		private Image m_maskImage; // 0x98
		private IPopupContent m_content; // 0x9C
		private bool m_isReady; // 0xA0
		private bool m_isSelected; // 0xA1
		private PopupSetting m_setting; // 0xA4
		private bool m_isActive; // 0xA8
		private bool m_isOpenWindow; // 0xA9
		private List<ButtonBase> m_inputTargetList = new List<ButtonBase>(64); // 0xAC
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
		public bool IsActive { get { return m_isActive; } } //0x1BB888C
		public IPopupContent Content { get { return m_content; } } //0x1BB8894

		// [CompilerGeneratedAttribute] // RVA: 0x73EBD4 Offset: 0x73EBD4 VA: 0x73EBD4
		// // RVA: 0x1BB8674 Offset: 0x1BB8674 VA: 0x1BB8674
		// public void add_m_closeWaitCallBack(Func<bool> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73EBE4 Offset: 0x73EBE4 VA: 0x73EBE4
		// // RVA: 0x1BB8780 Offset: 0x1BB8780 VA: 0x1BB8780
		// public void remove_m_closeWaitCallBack(Func<bool> value) { }

		// // RVA: 0x1BB889C Offset: 0x1BB889C VA: 0x1BB889C
		private static int CalcTblIndex(SizeType size, bool isCaption = true)
		{
			return (int)size + (isCaption ? 0 : 5);
		}

		// // RVA: 0x1BB88A8 Offset: 0x1BB88A8 VA: 0x1BB88A8
		public static Vector2 GetWindowSize(SizeType size, bool isCaption = true)
		{
			return s_sizeTbl[CalcTblIndex(size, isCaption)];
		}

		// // RVA: 0x1BB36F4 Offset: 0x1BB36F4 VA: 0x1BB36F4
		public static Vector2 GetContentSize(SizeType size, bool isCaption = true)
		{
			return s_contentSizeTbl[CalcTblIndex(size, isCaption)];
		}

		// // RVA: 0x1BADFE0 Offset: 0x1BADFE0 VA: 0x1BADFE0
		// public static Vector2 GetContentSize2(SizeType size, bool isCaption = True) { }

		// // RVA: 0x1BB8988 Offset: 0x1BB8988 VA: 0x1BB8988
		public static Vector2 GetContentButtonPosition(SizeType size, bool isCaption = true)
		{
			return s_buttonPositionTbl[CalcTblIndex(size, isCaption)];
		}

		// // RVA: 0x1BB8A68 Offset: 0x1BB8A68 VA: 0x1BB8A68
		public static Vector2 GetContentCenterOffset(SizeType size, bool isCaption = true)
		{
			return s_contentCenterTbl[CalcTblIndex(size, isCaption)];
		}

		// // RVA: 0x1BB8B48 Offset: 0x1BB8B48 VA: 0x1BB8B48
		public static Vector2 GetWindowVerticalAdjust(SizeType size, bool isCaption = true)
		{
			return new Vector2(0, s_windowVerticalAdjust[CalcTblIndex(size, isCaption)]);
		}

		// // RVA: 0x1BB8C38 Offset: 0x1BB8C38 VA: 0x1BB8C38
		private void OnPlayWindowOpenSe()
		{
			if(PlayWindowOpenHandler != null)
				if(PlayWindowOpenHandler(SeType.WindowOpen))
					return;
			PlayPopupWindowOpenSe(SeType.WindowOpen, SoundManager.Instance.sePlayerBoot);
		}

		// // RVA: 0x1BB8E08 Offset: 0x1BB8E08 VA: 0x1BB8E08
		private void OnPlayWindowCloseSe()
		{
			if(PlayWindowOpenHandler != null)
				if(PlayWindowOpenHandler(SeType.WindowClose))
					return;
			PlayPopupWindowOpenSe(SeType.WindowClose, SoundManager.Instance.sePlayerBoot);
		}

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
				int index = i;
				PopupButton button = m_buttons[i];
				m_buttons[i].AddOnClickCallback(() => {
					//0x1BBDC54
					if(m_isSelected)
						return;
					m_isSelected = true;
					if(PlayPopupButtonSeHandler != null)
					{
						PlayPopupButtonSeHandler.Invoke(button.Label, button.Type);
					}
					else
					{
						PlayPopupButtonSe(button.Label, button.Type, SoundManager.Instance.sePlayerBoot);
					}
					InputDisable();
					Action endCallback = () => {
						//0x1BBDEDC
						if(m_callBack != null)
						{
							m_callBack.Invoke(this, button.Type, button.Label);
						}
					};
					Close(endCallback, button);
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
				PopupTabButton button = m_tabButtons[i];
				int count = m_tabButtons.Length;
				m_tabButtons[i].AddOnClickCallback(() => {
					// 0x1BBDFF0
					for(int j = 0; j < count; j++)
					{
						m_tabButtons[j].SetOff();
					}
					if(SoundManager.Instance.sePlayerBoot != null)
					{
						SoundManager.Instance.sePlayerBoot.Play("se_btn_003");
					}
					if (m_contentUpdateCallBack == null)
						return;
					IPopupContent content = GetComponentInChildren<IPopupContent>(true);
					m_contentUpdateCallBack(content, button.Label);
				});
			}
			m_scrollRect = GetComponentInChildren<ScrollRect>(true);
			m_rectMask = m_scrollRect.GetComponent<Mask>();
			m_maskImage = m_scrollRect.GetComponent<Image>();
			this.StartCoroutineWatched(WaitLoadLayout());
		}

		// // RVA: 0x1BB956C Offset: 0x1BB956C VA: 0x1BB956C
		// public static void PlaySePositive() { }

		// // RVA: 0x1BB967C Offset: 0x1BB967C VA: 0x1BB967C
		// public static void PlaySeNegative() { }

		// // RVA: 0x1BB978C Offset: 0x1BB978C VA: 0x1BB978C
		// public void PushNegativeOtherButton() { }

		// // RVA: 0x1BB995C Offset: 0x1BB995C VA: 0x1BB995C
		private void PushBackButton()
		{
			int idx = 0;
			if(m_blockCount < 1 && m_validButtonCount > 0)
			{
				if (m_backButtonLabel == PopupButton.ButtonLabel.None)
					idx = m_validButtonCount - 1;
				else
				{					
					for(int i = 0; i < m_validButtonCount; i++)
					{
						if(m_buttons[i].Label == m_backButtonLabel)
						{
							idx = i;
						}
					}
				}
				if (!m_buttons[idx].Hidden && !m_buttons[idx].Disable && !m_buttons[idx].IsInputOff && m_buttons[idx].enabled)
					m_buttons[idx].PerformClick();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73EBF4 Offset: 0x73EBF4 VA: 0x73EBF4
		// // RVA: 0x1BB94E0 Offset: 0x1BB94E0 VA: 0x1BB94E0
		private IEnumerator WaitLoadLayout()
		{
			//0x1BBF9FC
			UnityEngine.Debug.Log("Enter Popup WaitLoadLayout");
			while(!IsLoadedLayout())
			{
				yield return null;
			}
			m_isReady = true;
			m_image.gameObject.SetActive(false);
			m_blackPanel.gameObject.SetActive(false);
			UnityEngine.Debug.Log("Exit Popup WaitLoadLayout");
		}

		// // RVA: 0x1BB9B18 Offset: 0x1BB9B18 VA: 0x1BB9B18
		public bool IsReady()
		{
			return m_isReady;
		}

		// // RVA: 0x1BB9B20 Offset: 0x1BB9B20 VA: 0x1BB9B20
		private bool IsLoadedLayout()
		{
			for(int i = 0; i < m_buttons.Length; i++)
			{
				if(!m_buttons[i].IsLoaded())
					return false;
			}
			return true;
		}

		// // RVA: 0x1BB9BC4 Offset: 0x1BB9BC4 VA: 0x1BB9BC4
		public void Show(PopupSetting setting, bool isShowBlack = true, bool isButtonEnable = true, bool isError = false)
		{
			m_isBlack = isShowBlack;
			m_blockCount = 0;
			m_isButtonEnable = isButtonEnable;
			m_isSelected = false;
			m_inputTargetList.Clear();
			ReleaseResource();
			m_titleText.text = setting.TitleText;
			m_titleText.color = SystemTextColor.GetNormalColor();
			m_titleText.fontSize = 28;
			m_backButtonLabel = setting.BackButtonLabel;
			m_negativeButtonLabel = setting.NegativeButtonLabel;
			if(setting.Buttons.Length == 0)
			{
				m_buttonUguiRuntime.Layout.StartAllAnimGoStop("04");
			}
			else
			{
				m_buttonUguiRuntime.Layout.StartAllAnimGoStop(setting.Buttons.Length.ToString("00"));
				Array.Copy(setting.Buttons, m_tmpButtons, setting.Buttons.Length);
				Array.Reverse(m_tmpButtons, 0, setting.Buttons.Length);
			}
			for(int i = 0; i < setting.Buttons.Length; i++)
			{
				m_buttons[i].SetLabel(this, m_tmpButtons[i].Label, m_tmpButtons[i].Type);
				m_buttons[i].SetOff();
			}
			m_buttonUguiRuntime.GetComponent<RectTransform>().anchoredPosition = GetContentButtonPosition(setting.WindowSize, setting.IsCaption);
			m_validButtonCount = m_buttons.Length;
			m_tabButtonUguiRuntime.gameObject.SetActive(setting.Tabs.Length != 0);
			if(setting.Tabs.Length != 0)
			{
				AbsoluteLayout layout = m_tabButtonUguiRuntime.Layout.Root[0] as AbsoluteLayout;
				layout.StartChildrenAnimGoStop(setting.Tabs.Length.ToString("00"));
				for(int i = 0; i < setting.Tabs.Length; i++)
				{
					m_tabButtons[i].SetLabel(setting.Tabs[i]);
					if(setting.Tabs[i] == setting.DefaultTab)
					{
						m_tabButtons[i].SetOn();
					}
					else
					{
						m_tabButtons[i].SetOff();
					}
				}
			}
			m_image.sprite = m_windowSprites[setting.IsCaption ? 0 : 1];
			m_titleText.enabled = setting.IsCaption;
			m_image.rectTransform.sizeDelta = GetWindowSize(setting.WindowSize, setting.IsCaption);
			m_image.rectTransform.anchoredPosition = GetWindowVerticalAdjust(setting.WindowSize, setting.IsCaption);
			m_setting = setting;
			if(setting.ISLoaded())
			{
				SetupContent(m_setting.Content);
			}
			else if(m_setting.IsAssetBundle)
			{
				this.StartCoroutineWatched(LoadResourceAssetBundleCoroutine());
			}
			else
			{
				ResourcesManager.Instance.Load(m_setting.PrefabPath, this.LoadResourceCallBack);
			}
		}

		// // RVA: 0x1BBB064 Offset: 0x1BBB064 VA: 0x1BBB064
		public void Close(Action endCallBack, PopupButton button)
		{
			endCallBack += () => {
				//0x1BBD934
				GameManager.Instance.RemovePushBackButtonHandler(this.PushBackButton);
				InputEnable();
				m_inputTargetList.Clear();
			};
			this.StartCoroutineWatched(ClosePopupWindow(endCallBack, button));
		}

		// // RVA: 0x1BBB25C Offset: 0x1BBB25C VA: 0x1BBB25C
		public void ShowGradation()
		{
			for(int i = 0; i < m_gradation.Length; i++)
			{
				m_gradation[i].enabled = true;
			}
		}

		// // RVA: 0x1BBB2F0 Offset: 0x1BBB2F0 VA: 0x1BBB2F0
		private bool LoadResourceCallBack(FileResultObject fro)
		{
			GameObject obj = UnityEngine.Object.Instantiate(fro.unityObject) as GameObject;
			SetupContent(obj);
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73EC6C Offset: 0x73EC6C VA: 0x73EC6C
		// // RVA: 0x1BBAFD8 Offset: 0x1BBAFD8 VA: 0x1BBAFD8
		private IEnumerator LoadResourceAssetBundleCoroutine()
		{
			//0x1BBEB3C
			bool isShowNowLoding = false;
			if(m_setting.IsPreload)
			{
				if(m_blackPanel != null)
				{
					m_blackPanel.gameObject.SetActive(m_isBlack);
					GameManager.Instance.NowLoading.Show();
					isShowNowLoding = true;
				}
			}
			yield return m_setting.LoadAssetBundlePrefab(m_setting.m_parent);
			if(isShowNowLoding)
			{
				GameManager.Instance.NowLoading.Hide();
			}
			if(m_setting.ISLoaded())
			{
				SetupContent(m_setting.Content);
			}
		}

		// // RVA: 0x1BBA7FC Offset: 0x1BBA7FC VA: 0x1BBA7FC
		private void SetupContent(GameObject content)
		{
			m_contentObject = content;
			content.transform.SetParent(m_scrollRect.viewport, false);
			m_content = m_contentObject.GetComponent<IPopupContent>();
			m_content.Initialize(m_setting, GetContentSize(m_setting.WindowSize, m_setting.IsCaption), this);
			m_scrollRect.transform.localPosition = GetContentCenterOffset(m_setting.WindowSize, m_setting.IsCaption);
			m_scrollRect.GetComponent<RectTransform>().sizeDelta = GetContentSize(m_setting.WindowSize, m_setting.IsCaption);
			m_scrollRect.content = m_contentObject.GetComponent<RectTransform>();
			m_scrollRect.enabled = false;
			if(m_content.IsScrollable())
			{
				m_scrollRect.verticalScrollbar.gameObject.SetActive(true);
				m_rectMask.enabled = true;
				m_maskImage.enabled = true;
				for(int i = 0; i < m_gradation.Length; i++)
				{
					m_gradation[i].enabled = true;
				}
			}
			else
			{
				m_scrollRect.verticalScrollbar.gameObject.SetActive(false);
				m_rectMask.enabled = false;
				m_maskImage.enabled = false;
				for(int i = 0; i < m_gradation.Length; i++)
				{
					m_gradation[i].enabled = false;
				}
			}
			InputDisable();
			m_openEndCallBack += () => {
				//0x1BBDA44
				InputEnable();
			};
			GameManager.Instance.AddPushBackButtonHandler(this.PushBackButton);
			this.StartCoroutineWatched(ShowPopupWindow());
		}

		// // RVA: 0x1BBA6D0 Offset: 0x1BBA6D0 VA: 0x1BBA6D0
		private void ReleaseResource()
		{
			if(m_contentObject == null)
				return;
			if(!m_setting.IsPreload)
			{
				UnityEngine.Object.Destroy(m_contentObject);
			}
			m_scrollRect.content = null;
			m_contentObject = null;
		}

		// // RVA: 0x1BBB480 Offset: 0x1BBB480 VA: 0x1BBB480
		private void SetActiveImage(bool active)
		{
			m_image.gameObject.SetActive(active);
			m_blackPanel.gameObject.SetActive(active);
		}

		// // RVA: 0x1BBB528 Offset: 0x1BBB528 VA: 0x1BBB528
		private bool IsPlayingButtonAnim() 
		{
			for(int i = 0; i < m_buttons.Length; i++)
			{
				if(m_buttons[i].IsPlaying())
					return true;
			}
			for(int i = 0; i < m_tabButtons.Length; i++)
			{
				if(m_tabButtons[i].IsPlaying())
					return true;
			}
			return false;
		}

		// // RVA: 0x1BBB660 Offset: 0x1BBB660 VA: 0x1BBB660
		public bool IsActivePopupWindow()
		{
			return m_isActive;
		}

		// // RVA: 0x1BBB668 Offset: 0x1BBB668 VA: 0x1BBB668
		public bool IsOpenPopupWindow()
		{
			return m_isOpenWindow;
		}

		// // RVA: 0x1BBB670 Offset: 0x1BBB670 VA: 0x1BBB670
		public void SetButtonHiddenEnable(bool enable)
		{
			for(int i = 0; i < m_buttons.Length; i++)
			{
				if(m_buttons[i].RootAbsoluteLayout.IsVisible)
				{
					m_buttons[i].Hidden = !enable;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73ECE4 Offset: 0x73ECE4 VA: 0x73ECE4
		// // RVA: 0x1BBB3F4 Offset: 0x1BBB3F4 VA: 0x1BBB3F4
		private IEnumerator ShowPopupWindow()
		{
			//0x1BBF1B0
			m_isOpenWindow = true;
			m_currentCurver = m_inCurve;
			m_image.rectTransform.localScale = Vector3.one * m_inCurve.Evaluate(0.0f);
			SetActiveImage(true);
			m_isActive = true;
			while(!m_content.IsReady())
				yield return m_waitYielder;
			if(m_blackPanel != null && m_isBlack)
			{
				m_blackPanel.gameObject.SetActive(true);
			}
			IEnumerator readyButtons = IsReadyButtons();
			yield return null;
			while(readyButtons.MoveNext())
				yield return null;
			SetButtonHiddenEnable(m_isButtonEnable);
			OnPlayWindowOpenSe();
			m_isAnimation = true;
			m_time = 0;
			if(m_setting.IsOpenAnimeMoment)
				m_time = 1;
			if(m_openStartCallBack != null)
			{
				m_openStartCallBack();
				m_openStartCallBack = null;
			}
			m_content.Show();
			if(m_content.IsScrollable())
			{
				m_scrollRect.enabled = true;
			}
			yield return this.StartCoroutineWatched(PlayPopupWindowAnim());
			m_isAnimation = false;
			if(m_openEndCallBack != null)
			{
				m_openEndCallBack.Invoke();
				m_content.CallOpenEnd();
				m_openEndCallBack = null;
			}
			
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73ED5C Offset: 0x73ED5C VA: 0x73ED5C
		// // RVA: 0x1BBB19C Offset: 0x1BBB19C VA: 0x1BBB19C
		private IEnumerator ClosePopupWindow(Action endCallBack, PopupButton button)
		{
			//0x1BBE258
			while(IsPlayingButtonAnim())
				yield return null;
			if(m_closeStartWaitCallBack != null)
			{
				while(!m_closeStartWaitCallBack.Invoke(button.Type, button.Label))
					yield return null;
			}
			OnPlayWindowCloseSe();
			m_isAnimation = true;
			m_currentCurver = m_outCurve;
			m_time = 0;
			m_content.Hide();
			if(m_content.Parent != null)
			{
				if(m_contentObject != null)
				{
					m_contentObject.transform.SetParent(m_content.Parent, false);
				}
			}
			m_isOpenWindow = false;
			yield return this.StartCoroutineWatched(PlayPopupWindowAnim());
			m_isAnimation = false;
			SetActiveImage(false);
			ReleaseResource();
			yield return null;
			int popupId = -1;
			if(m_preCloseEndCallBack != null)
			{
				popupId = m_preCloseEndCallBack();
				m_preCloseEndCallBack = null;
			}
			endCallBack();
			if(m_closeWaitCallBack != null)
			{
				while(!m_closeWaitCallBack())
					yield return null;
			}
			if(m_closeEndCallBack != null)
			{
				m_closeEndCallBack();
				m_closeEndCallBack = null;
			}
			if(m_postCloseEndCallBack != null)
			{
				m_postCloseEndCallBack.Invoke(popupId);
				m_postCloseEndCallBack = null;
			}
			m_isActive = false;
			m_closeWaitCallBack = null;
			PlayWindowOpenHandler = null;
			m_preCloseEndCallBack = null;
			m_closeEndCallBack = null;
			m_callBack = null;
			m_openStartCallBack = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73EDD4 Offset: 0x73EDD4 VA: 0x73EDD4
		// // RVA: 0x1BBB7C8 Offset: 0x1BBB7C8 VA: 0x1BBB7C8
		private IEnumerator PlayPopupWindowAnim()
		{
			//0x1BBEEE8
			while(m_time < 1.0f)
			{
				m_time += Time.deltaTime * m_speed;
				float val = m_currentCurver.Evaluate(m_time);
				m_image.rectTransform.localScale = Vector2.one * val;
				yield return null;
			}
		}

		// // RVA: 0x1BB113C Offset: 0x1BB113C VA: 0x1BB113C
		public void InputDisable()
		{
			if(m_blockCount == 0)
			{
				ListGraphicObject();
				for(int i = 0; i < m_inputTargetList.Count; i++)
				{
					m_inputTargetList[i].IsInputOff = true;
				}
			}
			m_blockCount++;
		}

		// // RVA: 0x1BB1264 Offset: 0x1BB1264 VA: 0x1BB1264
		public void InputEnable()
		{
			m_blockCount--;
			if (m_blockCount > 0)
				return;
			ListGraphicObject();
			for(int i = 0; i < m_inputTargetList.Count; i++)
			{
				m_inputTargetList[i].IsInputOff = false;
			}
		}

		// // RVA: 0x1BBB904 Offset: 0x1BBB904 VA: 0x1BBB904
		// public void ScrollDisable() { }

		// // RVA: 0x1BBBCC8 Offset: 0x1BBBCC8 VA: 0x1BBBCC8
		// public void ScrollEnable() { }

		// // RVA: 0x1BBB874 Offset: 0x1BBB874 VA: 0x1BBB874
		private void ListGraphicObject()
		{
			transform.GetComponentsInChildren<ButtonBase>(true, m_inputTargetList);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73EE4C Offset: 0x73EE4C VA: 0x73EE4C
		// // RVA: 0x1BBC090 Offset: 0x1BBC090 VA: 0x1BBC090
		private IEnumerator IsReadyButtons()
		{
			//0x1BBE908
			bool isReadyButtons = false;
			while(true)
			{
				isReadyButtons = true;
				for(int i = 0; i < m_buttons.Length; i++)
				{
					if(m_buttons[i].RootAbsoluteLayout.IsVisible)
					{
						isReadyButtons &= m_buttons[i].IsReady;
					}
				}
				if(isReadyButtons)
					break;
				yield return null;
			}
		}

		// // RVA: 0x1BAC4B4 Offset: 0x1BAC4B4 VA: 0x1BAC4B4
		// public PopupButton FindButton(PopupButton.ButtonLabel label) { }

		// // RVA: 0x1BBC144 Offset: 0x1BBC144 VA: 0x1BBC144
		// public PopupButton FindButton(PopupButton.ButtonType type) { }

		// // RVA: 0x1BBC234 Offset: 0x1BBC234 VA: 0x1BBC234
		public void ForceChangeScrollPosition(float value)
		{
			m_scrollRect.verticalScrollbar.value = value;
		}

		// // RVA: 0x1BBC288 Offset: 0x1BBC288 VA: 0x1BBC288
		public void ResetScroll(PopupSetting setting, IPopupContent content, float scrollPosition = 1)
		{
			m_scrollRect.content = setting.Content.GetComponent<RectTransform>();
			if (content.IsScrollable())
			{
				m_scrollRect.enabled = true;
				m_scrollRect.verticalScrollbar.gameObject.SetActive(true);
				m_rectMask.enabled = true;
			}
			else
			{
				m_scrollRect.enabled = false;
				m_scrollRect.verticalScrollbar.gameObject.SetActive(false);
				m_rectMask.enabled = false;
			}
			ForceChangeScrollPosition(scrollPosition);
		}

		// // RVA: 0x1BBC534 Offset: 0x1BBC534 VA: 0x1BBC534
		// public void StopScrollMovement() { }

		// // RVA: 0x1BBC568 Offset: 0x1BBC568 VA: 0x1BBC568
		public static void PlayPopupButtonSe(PopupButton.ButtonLabel label, PopupButton.ButtonType type, CriAtomSource source)
		{
			if(source != null)
			{
				source.Play(type == PopupButton.ButtonType.Negative ? (label != PopupButton.ButtonLabel.Cancel && label != PopupButton.ButtonLabel.Disagree ? "se_btn_001" : "se_btn_002") : "se_btn_001");
			}
		}

		// // RVA: 0x1BB8D14 Offset: 0x1BB8D14 VA: 0x1BB8D14
		public static void PlayPopupWindowOpenSe(PopupWindowControl.SeType type, CriAtomSource source)
		{
			if(source == null)
				return;
			if(type == SeType.WindowClose)
			{
				source.Play("se_wnd_001");
			}
			else if(type == SeType.WindowOpen)
			{
				source.Play("se_wnd_000");
			}
		}
	}
}
