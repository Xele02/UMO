using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;
using System.Collections;

namespace XeApp.Game.Common
{
	public class WebContent : UIBehaviour
	{
		[SerializeField]
		private RectTransform m_webArea; // 0xC
		private bool m_canReturnButton = true; // 0x10
		private bool m_isShow; // 0x11
		private WaitForSeconds m_yielder; // 0x14
		private Canvas m_rootCanvas; // 0x18
		private PopupWebViewButtonControl m_buttonControl; // 0x1C
		private Image m_blackImage; // 0x20
		private WebViewManager m_webViewManager; // 0x24

		public Action onClosed { private get; set; } // 0x28

		// RVA: 0xD33B2C Offset: 0xD33B2C VA: 0xD33B2C
		private void Awake()
		{
			m_webViewManager = GetComponentInChildren<WebViewManager>();
			m_rootCanvas = GetComponentInParent<Canvas>();
			m_blackImage = m_rootCanvas.GetComponentInChildren<Image>(true);
			m_buttonControl = GetComponentInChildren<PopupWebViewButtonControl>(true);
			m_buttonControl.PushCloseButtonHandler += Close;
			m_buttonControl.PushReturnButtonHandler += GoBack;
		}

		// RVA: 0xD33CBC Offset: 0xD33CBC VA: 0xD33CBC
		private void Start()
		{
			m_webViewManager.WebView.SetVisibility(false);
			this.StartCoroutineWatched(PollingCheckBackCoroutine());
			if(SystemManager.isLongScreenDevice)
			{
				RectTransform rt1 = m_rootCanvas.transform.GetChild(0).GetComponent<RectTransform>();
				Vector2 sb1 = m_blackImage.rectTransform.sizeDelta;
				float y = ((SystemManager.rawScreenAreaRect.height - SystemManager.rawAppScreenRect.height) + rt1.anchoredPosition.y) * 0.5f ;
				Vector2 v1 = new Vector2((SystemManager.rawScreenAreaRect.width - SystemManager.rawAppScreenRect.width) / (SystemManager.rawAppScreenRect.width / 1184f) + sb1.x, y + sb1.y);
				m_blackImage.rectTransform.sizeDelta = v1;
				m_blackImage.rectTransform.anchoredPosition = new Vector2(m_blackImage.rectTransform.anchoredPosition.x, y * -0.5f);
			}
		}

		// // RVA: 0xD34134 Offset: 0xD34134 VA: 0xD34134
		private void LoadURL(string url)
		{
			Rect r = GetScreenRect();
			m_webViewManager.WebView.SetScreenRect((int)r.x, (int)r.y, (int)r.width, (int)r.height, GameManager.Instance.screenWidth, GameManager.Instance.screenHeight);
			m_webViewManager.WebView.LoadURL(url);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73FAF4 Offset: 0x73FAF4 VA: 0x73FAF4
		// // RVA: 0xD346E0 Offset: 0xD346E0 VA: 0xD346E0
		public IEnumerator Show(string url, bool isShowBackButton = false, bool isShowCheckbox = false)
		{
			//0xD34FFC
			m_rootCanvas.enabled = false;
			m_isShow = false;
			while(!m_buttonControl.IsLoaded())
				yield return null;
			yield return null;
			LoadURL(url);
			m_buttonControl.ShowReturnButton(isShowBackButton);
			m_buttonControl.ShowRejectCheckbox(isShowCheckbox);
			m_buttonControl.ResetRejectCheckbox();
			yield return null;
			GameManager.Instance.AddPushBackButtonHandler(Close);
			m_rootCanvas.enabled = true;
			m_webViewManager.WebView.SetVisibility(true);
			m_isShow = true;
		}

		// // RVA: 0xD347D8 Offset: 0xD347D8 VA: 0xD347D8
		public void Close()
		{
			m_isShow = false;
			GameManager.Instance.RemovePushBackButtonHandler(Close);
			this.StartCoroutineWatched(Hide());
			PopupWindowControl.PlayPopupButtonSe(PopupButton.ButtonLabel.Close, PopupButton.ButtonType.Negative, SoundManager.Instance.sePlayerBoot);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73FB6C Offset: 0x73FB6C VA: 0x73FB6C
		// // RVA: 0xD34940 Offset: 0xD34940 VA: 0xD34940
		private IEnumerator Hide()
		{
			//0xD34C30
			yield return null;
			m_webViewManager.WebView.SetVisibility(false);
			if(onClosed != null)
				onClosed();
			yield return null;
			Destroy(m_rootCanvas.gameObject);
		}

		// // RVA: 0xD349EC Offset: 0xD349EC VA: 0xD349EC
		public void GoBack()
		{
			m_webViewManager.WebView.GoBack();
			PopupWindowControl.PlayPopupButtonSe(PopupButton.ButtonLabel.Return, PopupButton.ButtonType.Other, SoundManager.Instance.sePlayerBoot);
		}

		// // RVA: 0xD34AD8 Offset: 0xD34AD8 VA: 0xD34AD8
		public bool CanGoBack()
		{
			return m_webViewManager.WebView.CanGoBack();
		}

		// // RVA: 0xD34B18 Offset: 0xD34B18 VA: 0xD34B18
		public void CheckCanGoBack()
		{
			m_webViewManager.WebView.CheckCanGoBack();
		}

		// // RVA: 0xD34B58 Offset: 0xD34B58 VA: 0xD34B58
		// public bool GetRejectChecked() { }

		// // RVA: 0xD34B84 Offset: 0xD34B84 VA: 0xD34B84
		// public bool IsReady() { }

		// // RVA: 0xD3433C Offset: 0xD3433C VA: 0xD3433C
		private Rect GetScreenRect()
		{
			Canvas c = GetComponentInParent<Canvas>();
			Vector3[] corners = new Vector3[4];
			m_webArea.GetComponent<RectTransform>().GetWorldCorners(corners);
			Vector2 v = RectTransformUtility.WorldToScreenPoint(c.worldCamera, corners[0]);
			Vector2 v2 = RectTransformUtility.WorldToScreenPoint(c.worldCamera, corners[2]);
			Vector2 s = new Vector2(GameManager.Instance.screenWidth * 1.0f / Screen.width * v.x, GameManager.Instance.screenHeight - GameManager.Instance.screenHeight * 1.0f / Screen.height * v2.y);
			return new Rect(s.x, s.y, GameManager.Instance.screenWidth * 1.0f / Screen.width * v2.x - s.x, (GameManager.Instance.screenHeight - GameManager.Instance.screenHeight * 1.0f / Screen.height * v.y) - s.y);
		}

		// RVA: 0xD34B8C Offset: 0xD34B8C VA: 0xD34B8C
		private void Update()
		{
			if(!m_isShow)
				return;
			if(m_canReturnButton == CanGoBack())
				return;
			m_canReturnButton = CanGoBack();
			m_buttonControl.SetDisableReturnButton(!m_canReturnButton);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73FBE4 Offset: 0x73FBE4 VA: 0x73FBE4
		// // RVA: 0xD340A8 Offset: 0xD340A8 VA: 0xD340A8
		private IEnumerator PollingCheckBackCoroutine()
		{
			//0xD34E48
			m_yielder = new WaitForSeconds(1.0f / Application.targetFrameRate * 10);
			yield return m_yielder;
			CheckCanGoBack();
		}
	}
}
