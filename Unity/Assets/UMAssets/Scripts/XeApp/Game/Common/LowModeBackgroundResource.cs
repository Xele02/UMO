using UnityEngine;

namespace XeApp.Game.Common
{
	public class LowModeBackgroundResource : MonoBehaviour
	{
		public Texture introTexture;
		public Texture cardTexture;
		public Texture battleTexture;
		public bool isTitleBg;
		public int baseRare;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
