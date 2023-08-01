using XeApp.Game;
using UnityEngine.UI;
using UnityEngine;

public class DebugCheatUI_DecoAcquirer : DebugCheatUIBase
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	[SerializeField]
	private ScrollRect scroll_;
	[SerializeField]
	private GameObject scrollElement_;
	[SerializeField]
	private Button updateButton_;
}
