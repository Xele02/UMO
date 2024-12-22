using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class WebViewManager : MonoBehaviour
	{
		private WebView m_webView; // 0xC

		public WebView WebView { get { return m_webView; } } //0xD340A0

		// RVA: 0xD35428 Offset: 0xD35428 VA: 0xD35428
		private void Start()
		{
			m_webView = new WebView();
			m_webView.Initialize(GetComponent<WebViewObject>());
			m_webView.onCallJavaScriptCommand = (string msg) =>
			{
				//0xD3552C
				int cpid = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
				if(cpid == 0)
					cpid = UMO_PlayerPrefs.GetInt("cpid", 0);
				m_webView.DefaultOpenURL(msg.Replace("saka_player_id", cpid.ToString()));
				return true;
			};
		}
	}
}
