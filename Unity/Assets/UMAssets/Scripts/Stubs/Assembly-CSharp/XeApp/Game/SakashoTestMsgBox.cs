using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class SakashoTestMsgBox : MonoBehaviour
	{
		[SerializeField]
		private Text messageText;
		[SerializeField]
		public Button btnCenter;
		[SerializeField]
		public Button btnLeft;
		[SerializeField]
		public Button btnRight;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
