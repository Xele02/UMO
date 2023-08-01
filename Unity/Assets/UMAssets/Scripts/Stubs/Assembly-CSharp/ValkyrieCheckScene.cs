using XeApp.Core;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

public class ValkyrieCheckScene : MainSceneBase
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	[SerializeField]
	private GameValkyrieObject valkyrieObject;
	[SerializeField]
	private Button btnChangeFighter;
	[SerializeField]
	private Button btnChangeGerwalk;
	[SerializeField]
	private Button btnChangeBattroid;
}
