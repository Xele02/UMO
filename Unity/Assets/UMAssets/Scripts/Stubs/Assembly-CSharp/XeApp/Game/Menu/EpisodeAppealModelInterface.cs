using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EpisodeAppealModelInterface : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer m_plateMesh;
		[SerializeField]
		private MeshRenderer[] m_rankUpPlateMesh;
		[SerializeField]
		private GameObject m_episodeTextMeshRoot;
		[SerializeField]
		private GameObject m_costumeTitleMessMeshRoot;
		[SerializeField]
		private GameObject m_costumeNameTextMeshRoot;
		[SerializeField]
		private GameObject m_rewardDivaTextMeshRoot;
		[SerializeField]
		private GameObject m_pilotNameTextMeshRoot;
		[SerializeField]
		private GameObject m_pilotTextureMeshRoot;
		[SerializeField]
		private GameObject[] m_logObjects;
		[SerializeField]
		private GameObject[] m_divaNameObjects;
		[SerializeField]
		private GameObject[] m_scaleChangeObjects;
		[SerializeField]
		private EpisodeAppealVoiceDelayParam m_divaVoiceDelayTime;
		[SerializeField]
		private EpisodeAppealVoiceDelayParam m_pilotVoiceDelayTime;
		[SerializeField]
		private EpisodeAppealDivaAdjustParam m_adjustParam;
	}
}
