using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EpisodeNameParts : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] sprites; // 0xC

		public Sprite this[int index] { get { return sprites[index]; } } // 0xEF93EC
	}
}
