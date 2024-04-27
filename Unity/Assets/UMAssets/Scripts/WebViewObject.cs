using System;
using UnityEngine;

public class WebViewObject : MonoBehaviour
{
	private Action<string> onJS; // 0xC
	private Action<string> onError; // 0x10
	private bool visibility; // 0x14
	private AndroidJavaObject webView; // 0x18
	private bool mIsKeyboardVisible; // 0x1C

	// public bool IsKeyboardVisible { get; } 0x2F93288

	// // RVA: 0x2F93218 Offset: 0x2F93218 VA: 0x2F93218
	// public void SetKeyboardVisible(string pIsVisible) { }

	// RVA: 0x2F93290 Offset: 0x2F93290 VA: 0x2F93290
	public void Init(Action<string> cb, bool transparent = false, Action<string> err = null)
	{
		Debug.Log("WebViewObject name=" + name);
		onJS = cb;
		onError = err;
		webView = new AndroidJavaObject("jp.co.xeen.xeapp.CWebViewPlugin", Array.Empty<object>());
		webView.Call("Init", new object[2]
		{
			name, transparent
		});
	}

	// RVA: 0x2F934DC Offset: 0x2F934DC VA: 0x2F934DC Slot: 4
	protected virtual void OnDestroy()
	{
		if(webView == null)
			return;
		webView.Call("Destroy", Array.Empty<object>());
		webView = null;
	}

	// // RVA: 0x2F93570 Offset: 0x2F93570 VA: 0x2F93570
	// public void SetCenterPositionWithScale(Vector2 center, Vector2 scale) { }

	// // RVA: 0x2F93574 Offset: 0x2F93574 VA: 0x2F93574
	public void SetMargins(int left, int top, int right, int bottom)
	{
		if(webView != null)
		{
			webView.Call("SetMargins", new object[4]
			{
				left, top, right, bottom
			});
		}
	}

	// // RVA: 0x2F937F0 Offset: 0x2F937F0 VA: 0x2F937F0
	public void SetVisibility(bool v)
	{
		if(webView != null)
		{
			webView.Call("SetVisibility", new object[1] { v });
		}
	}

	// // RVA: 0x2F93914 Offset: 0x2F93914 VA: 0x2F93914
	// public bool GetVisibility() { }

	// // RVA: 0x2F9391C Offset: 0x2F9391C VA: 0x2F9391C
	public void LoadURL(string url)
	{
		if(string.IsNullOrEmpty(url))
			return;
		if(webView == null)
			return;
		webView.Call("LoadURL", new object[1] { url });
	}

	// // RVA: 0x2F93A2C Offset: 0x2F93A2C VA: 0x2F93A2C
	// public void EvaluateJS(string js) { }

	// // RVA: 0x2F93B44 Offset: 0x2F93B44 VA: 0x2F93B44
	// public void CallOnError(string message) { }

	// // RVA: 0x2F93BB8 Offset: 0x2F93BB8 VA: 0x2F93BB8
	// public void CallFromJS(string message) { }

	// // RVA: 0x2F93C2C Offset: 0x2F93C2C VA: 0x2F93C2C
	public bool CanGoBack()
	{
		if(webView != null)
		{
			return webView.Get<bool>("canGoBack");
		}
		return false;
	}

	// // RVA: 0x2F93CB0 Offset: 0x2F93CB0 VA: 0x2F93CB0
	public void GoBack()
	{
		if(webView != null)
			webView.Call("GoBack", Array.Empty<object>());
	}

	// // RVA: 0x2F93D3C Offset: 0x2F93D3C VA: 0x2F93D3C
	public void CheckCanGoBack()
	{
		return;
	}
}
