using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class SakashoTestWebView : UIBehaviour
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public string url;
		[SerializeField]
		private Button buttonGoBack;
		[SerializeField]
		private Button buttonQuit;
		[SerializeField]
		private Image toolBar;
		[SerializeField]
		private WebViewObject webViewObject;
	}
}
