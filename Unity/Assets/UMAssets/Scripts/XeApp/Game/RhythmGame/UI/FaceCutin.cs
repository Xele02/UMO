using System;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class FaceCutin : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] m_prefab; // 0xC
		[SerializeField]
		private string[] m_stateName; // 0x10
		private Animator m_animator; // 0x14
		private int[] m_stateNameHash; // 0x18
		private Renderer m_cutRenderer; // 0x1C

		// RVA: 0x155EA1C Offset: 0x155EA1C VA: 0x155EA1C
		public void Initialize(GameObject parent, int prefabIndex = 0)
		{
			m_stateNameHash = new int[m_stateName.Length];
			for(int i = 0; i < m_stateName.Length; i++)
			{
				m_stateNameHash[i] = Animator.StringToHash(m_stateName[i]);
			}
			GameObject go = RhythmGameHUD.RhythmGameInstantiatePrefab(m_prefab[prefabIndex]);
			go.transform.SetParent(parent.transform, false);
			m_animator = go.GetComponent<Animator>();
			m_animator.Play(m_stateNameHash[0], 0, 1.0f);
		}

		//// RVA: 0x155ECB8 Offset: 0x155ECB8 VA: 0x155ECB8
		public void SetTexture(string cutMeshName, UiReplaceTexture texture)
		{
			m_cutRenderer = Array.Find(GetComponentsInChildren<MeshRenderer>(true), (MeshRenderer x) =>
			{
				//0x155EED0
				return cutMeshName == x.name;
			});
			texture.Set(m_cutRenderer.materials[0]);
		}

		//// RVA: 0x155EE48 Offset: 0x155EE48 VA: 0x155EE48
		public void Play(int index = 0)
		{
			m_animator.Play(m_stateNameHash[index], 0, 0);
		}
	}
}
