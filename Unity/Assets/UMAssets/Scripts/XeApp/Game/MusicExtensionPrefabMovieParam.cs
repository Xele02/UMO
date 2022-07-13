using UnityEngine;

namespace XeApp.Game
{
	public class MusicExtensionPrefabMovieParam : ScriptableObject
	{
		[SerializeField]
		private string m_MoivePath = ""; // 0xC

		public string pathMovie { get { return m_MoivePath; } } //0xC97744
	}
}
