using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.UI
{
	public class RhythmUIEditor : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RectTransform _editorMenuRoot;
	}
}
