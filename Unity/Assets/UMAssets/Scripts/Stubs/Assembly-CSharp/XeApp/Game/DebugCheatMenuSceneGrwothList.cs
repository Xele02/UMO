using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatMenuSceneGrwothList : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Button leftButton;
		[SerializeField]
		private Button rightButton;
		[SerializeField]
		private Toggle SubBoard;
		[SerializeField]
		private GameObject listRoot;
	}
}
