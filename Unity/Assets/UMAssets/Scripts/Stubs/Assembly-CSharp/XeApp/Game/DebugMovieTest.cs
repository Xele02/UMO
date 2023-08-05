using XeApp.Core;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class DebugMovieTest : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private DivaModeObject divaModeObject;
		[SerializeField]
		private Text visibleButtonText;
		[SerializeField]
		private List<GameObject> visiblityChangeableObject;
	}
}
