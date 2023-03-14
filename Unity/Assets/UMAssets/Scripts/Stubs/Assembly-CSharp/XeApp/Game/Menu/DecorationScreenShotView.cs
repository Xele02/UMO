using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class DecorationScreenShotView : MonoBehaviour
	{
		[SerializeField]
		private Button closeButton;
		[SerializeField]
		private Button returnButton;
		[SerializeField]
		private Button shareButton;
		[SerializeField]
		private Button takeButton;
		[SerializeField]
		private Button messagePanelButton;
		[SerializeField]
		private RawImage captureImage;
		[SerializeField]
		private RectTransform captureResultPanel;
		[SerializeField]
		private Image infomationSprite;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
