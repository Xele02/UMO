using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class EpisodeAppealModelInterface : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer m_plateMesh; // 0xC
		[SerializeField]
		private MeshRenderer[] m_rankUpPlateMesh; // 0x10
		[SerializeField]
		private GameObject m_episodeTextMeshRoot; // 0x14
		//[TooltipAttribute] // RVA: 0x66CB40 Offset: 0x66CB40 VA: 0x66CB40
		[SerializeField]
		private GameObject m_costumeTitleMessMeshRoot; // 0x18
		[SerializeField]
		private GameObject m_costumeNameTextMeshRoot; // 0x1C
		[SerializeField]
		private GameObject m_rewardDivaTextMeshRoot; // 0x20
		[SerializeField]
		private GameObject m_pilotNameTextMeshRoot; // 0x24
		[SerializeField]
		private GameObject m_pilotTextureMeshRoot; // 0x28
		[SerializeField]
		private GameObject[] m_logObjects; // 0x2C
		[SerializeField]
		private GameObject[] m_divaNameObjects; // 0x30
		[SerializeField]
		private GameObject[] m_scaleChangeObjects; // 0x34
		[SerializeField]
		private EpisodeAppealVoiceDelayParam m_divaVoiceDelayTime; // 0x38
		[SerializeField]
		private EpisodeAppealVoiceDelayParam m_pilotVoiceDelayTime; // 0x3C
		[SerializeField]
		private EpisodeAppealDivaAdjustParam m_adjustParam; // 0x40

		public MeshRenderer PlateMesh { get { return m_plateMesh; } } //0x1277A54
		public MeshRenderer[] RankupPlateMesh { get { return m_rankUpPlateMesh; } } //0x1277A5C
		public GameObject EpisodeTextMeshRoot { get { return m_episodeTextMeshRoot; } } //0x1277A44
		public GameObject CostumeTitleMessMeshRoot { get { return m_costumeTitleMessMeshRoot; } } //0x127CDD0
		public GameObject CostumeNameTextMeshRoot { get { return m_costumeNameTextMeshRoot; } } //0x1277A3C
		public GameObject RewardDivaTextMeshRoot { get { return m_rewardDivaTextMeshRoot; } } //0x127CDD8
		public GameObject PilotNameTextMeshRoot { get { return m_pilotNameTextMeshRoot; } } //0x1277A4C
		public GameObject PilotTextureMeshRoot { get { return m_pilotTextureMeshRoot; } } //0x127CD28
		public EpisodeAppealVoiceDelayParam DivaVoiceDelayTime { get { return m_divaVoiceDelayTime; } } //0x1278B54
		public EpisodeAppealVoiceDelayParam PilotVoiceDelayTime { get { return m_pilotVoiceDelayTime; } } //0x12797AC
		public EpisodeAppealDivaAdjustParam DivaAdjustParam { get { return m_adjustParam; } } //0x1278B5C

		// RVA: 0x127BC88 Offset: 0x127BC88 VA: 0x127BC88
		public void SetLog(SeriesAttr.Type attr)
		{
			Array.ForEach(m_logObjects, (GameObject x) =>
			{
				//0x127CE70
				x.SetActive(false);
			});
			m_logObjects[(int)attr - 1].SetActive(true);
		}

		// // RVA: 0x127CDE0 Offset: 0x127CDE0 VA: 0x127CDE0
		// public void SetAttribute(GameAttribute.Type attr) { }

		// // RVA: 0x1278A60 Offset: 0x1278A60 VA: 0x1278A60
		public void SetPlateScale(float scale)
		{
			Array.ForEach(m_scaleChangeObjects, (GameObject x) =>
			{
				//0x127CED0
				x.transform.localScale = new Vector3(scale, scale, 1);
			});
		}

		// // RVA: 0x12788B8 Offset: 0x12788B8 VA: 0x12788B8
		public void SetDivaName(int divaId)
		{
			Array.ForEach(m_divaNameObjects, (GameObject x) =>
			{
				//0x127CEA0
				x.SetActive(false);
			});
			m_divaNameObjects[divaId - 1].SetActive(true);
		}
	}
}
