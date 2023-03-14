using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipScene : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Button prevSceneButton;
		public bool isReady;
	}
}
