using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Test
{
	public class AspectTestAspectSwitcher : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Button prevButton;
		[SerializeField]
		private Button nextButton;
		[SerializeField]
		private Text resolutionText;
	}
}
