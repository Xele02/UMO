using System.Text.RegularExpressions;
using UnityEngine;

namespace XeSys
{
	public delegate bool WebViewJavaScriptCommand(string msg);

	public class WebView
	{
		private WebViewObject mWebViewObject; // 0xC
		public WebViewJavaScriptCommand onCallJavaScriptCommand; // 0x10
		public static Regex rxOpenURL = new Regex("OpenURL\\s+url='(?<url>[^']+)'"); // 0x0

		public bool isInitialized { get; private set; } // 0x8

		// RVA: 0x274993C Offset: 0x274993C VA: 0x274993C
		public void Initialize(WebViewObject wvo)
		{
			if(wvo != null)
			{
				isInitialized = true;
				mWebViewObject = wvo;
				mWebViewObject.Init(ClassifyCommand, false, null);
			}
		}

		// // RVA: 0x2749A54 Offset: 0x2749A54 VA: 0x2749A54
		public void LoadURL(string url)
		{
			if(!isInitialized)
				return;
			mWebViewObject.LoadURL(url);
			mWebViewObject.SetVisibility(true);
		}

		// // RVA: 0x2749ABC Offset: 0x2749ABC VA: 0x2749ABC
		public void SetVisibility(bool visible)
		{
			if(!isInitialized)
				return;
			mWebViewObject.SetVisibility(visible);
		}

		// // RVA: 0x2749AFC Offset: 0x2749AFC VA: 0x2749AFC
		public void SetScreenRect(int x, int y, int w, int h, int screenWidth, int screenHeight)
		{
			if(isInitialized)
			{
				mWebViewObject.SetMargins(x, y, screenWidth - (x + x), screenHeight - (h + y));
			}
		}

		// // RVA: 0x2749B74 Offset: 0x2749B74 VA: 0x2749B74
		// public void SetScreenRect(int x, int y, int w, int h) { }

		// // RVA: 0x2749BCC Offset: 0x2749BCC VA: 0x2749BCC
		// public void SetBaseScreenRect(int x, int y, int w, int h) { }

		// // RVA: 0x2749CC0 Offset: 0x2749CC0 VA: 0x2749CC0
		public void GoBack()
		{
			if(!isInitialized)
				return;
			mWebViewObject.GoBack();
		}

		// // RVA: 0x2749CF8 Offset: 0x2749CF8 VA: 0x2749CF8
		public bool CanGoBack()
		{
			if(!isInitialized)
				return false;
			return mWebViewObject.CanGoBack();
		}

		// // RVA: 0x2749D34 Offset: 0x2749D34 VA: 0x2749D34
		public void CheckCanGoBack()
		{
			if(!isInitialized)
				return;
			mWebViewObject.CheckCanGoBack();
		}

		// // RVA: 0x2749D6C Offset: 0x2749D6C VA: 0x2749D6C
		private void ClassifyCommand(string msg)
		{
			if(onCallJavaScriptCommand != null)
			{
				if(onCallJavaScriptCommand.Invoke(msg))
					return;
			}
			DefaultOpenURL(msg);
		}

		// RVA: 0x274A5F0 Offset: 0x274A5F0 VA: 0x274A5F0
		public void DefaultOpenURL(string msg)
		{
			Debug.Log("DefaultOpenURL " + msg);
            Match match = rxOpenURL.Match(msg);
			if(!match.Success)
			{
				Debug.Log("not match");
				return;
			}
			Debug.Log("match");
			if(match.Groups.Count < 1)
				return;
			if(match.Groups["url"].Value == "")
				return;
			Debug.Log("OpenURL "+match.Groups["url"].Value);
			Application.OpenURL(match.Groups["url"].Value);
        }
	}
}
