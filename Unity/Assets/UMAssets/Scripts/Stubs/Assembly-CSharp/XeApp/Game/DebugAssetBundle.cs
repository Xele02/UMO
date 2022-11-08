using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugAssetBundle : DebugCheatUIBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Text _textArea;
	}
}
