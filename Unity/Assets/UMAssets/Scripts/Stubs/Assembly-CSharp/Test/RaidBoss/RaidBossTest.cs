using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;

namespace Test.RaidBoss
{
	public class RaidBossTest : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text text;
		[SerializeField]
		private int buttonWidth;
		[SerializeField]
		private int buttonHeight;
	}
}
