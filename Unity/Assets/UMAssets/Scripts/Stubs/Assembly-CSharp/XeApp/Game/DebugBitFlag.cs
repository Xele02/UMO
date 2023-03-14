using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugBitFlag : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text _textArea;
		[SerializeField]
		private Dropdown _dropDown;
		[SerializeField]
		private GameObject _plateSource;
		[SerializeField]
		private ScrollRect _scrollRect;
	}
}
