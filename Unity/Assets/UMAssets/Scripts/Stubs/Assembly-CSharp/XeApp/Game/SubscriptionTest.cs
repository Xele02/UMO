using XeApp.Core;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class SubscriptionTest : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public Button updateButton;
		public Button lowPlanPurchaseButton;
		public Button topPlanPurchaseButton;
		public Text outputText;
		public Text logText;
	}
}
