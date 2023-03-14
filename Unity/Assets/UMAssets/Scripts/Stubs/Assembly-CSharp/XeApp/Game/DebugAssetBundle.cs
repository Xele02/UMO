using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugAssetBundle : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text _textArea;
	}
}
