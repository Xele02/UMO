using XeApp.Core;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameSkipScene : MainSceneBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Button prevSceneButton;
		public bool isReady;
	}
}
