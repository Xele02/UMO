using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EpisodeAppeal : MonoBehaviour
	{
		[SerializeField]
		private TextMesh m_cosNameTextPrefab;
		[SerializeField]
		private TextMesh m_newEpisodeNameTextPrefab;
		[SerializeField]
		private TextMesh m_episodeNameTextPrefab;
		[SerializeField]
		private TextMesh m_pilotNameTextPrefab;
		public bool IsSkip;
		public bool IsAppeal;
	}
}
