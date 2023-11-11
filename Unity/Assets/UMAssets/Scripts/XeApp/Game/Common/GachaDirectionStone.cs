using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GachaDirectionStone : MonoBehaviour
	{
		[Serializable]
		public class RefData
		{
			[SerializeField]
			private Transform m_memory; // 0x8
			[SerializeField]
			private Transform m_quartz; // 0xC
			[SerializeField]
			private List<Transform> m_quartzBreak; // 0x10

			// RVA: 0xE95354 Offset: 0xE95354 VA: 0xE95354
			public RefData(Transform memory, Transform quartz, List<Transform> quartzBreak)
			{
				m_memory = memory;
				m_quartz = quartz;
				m_quartzBreak = new List<Transform>(quartzBreak);
			}

			// // RVA: 0xE953F8 Offset: 0xE953F8 VA: 0xE953F8
			public void SetParent(RefData parent, bool worldPositionStays)
			{
				m_memory.SetParent(parent.m_memory, worldPositionStays);
				m_quartz.SetParent(parent.m_quartz, worldPositionStays);
				for(int i = 0; i < Mathf.Min(m_quartzBreak.Count, parent.m_quartzBreak.Count); i++)
				{
					m_quartzBreak[i].SetParent(parent.m_quartzBreak[i], worldPositionStays);
				}
			}

			// // RVA: 0xE95610 Offset: 0xE95610 VA: 0xE95610
			public void SetParent(Transform parent, bool worldPositionStays)
			{
				m_memory.SetParent(parent, worldPositionStays);
				m_quartz.SetParent(parent, worldPositionStays);
				for(int i = 0; i < m_quartzBreak.Count; i++)
				{
					m_quartzBreak[i].SetParent(parent, worldPositionStays);
				}
			}
		}

		[Serializable]
		public class TypeChangeData
		{
			[SerializeField]
			private Cubemap quartz_Cube_map; // 0x8
			[SerializeField]
			private Texture memory_DiffuseTex; // 0xC
			[SerializeField]
			private List<ParticleSystem> particles; // 0x10

			// // RVA: 0xE950D4 Offset: 0xE950D4 VA: 0xE950D4
			public void Apply(Material quartzMat, Material memoryMat)
			{
				quartzMat.SetTexture("_Cube_map", quartz_Cube_map);
				memoryMat.SetTexture("_MainTex", memory_DiffuseTex);
				for(int i = 0; i < particles.Count; i++)
				{
					particles[i].Play();
				}
			}

			// // RVA: 0xE95220 Offset: 0xE95220 VA: 0xE95220
			public void Disapply()
			{
				for(int i = 0; i < particles.Count; i++)
				{
					particles[i].Clear();
					particles[i].Stop();
				}
			}
		}

		[SerializeField]
		[Header("---- for Design ----")] // RVA: 0x687410 Offset: 0x687410 VA: 0x687410
		private GachaDirectionStone.TypeChangeData m_changeToBlue; // 0xC
		[SerializeField]
		private GachaDirectionStone.TypeChangeData m_changeToRed; // 0x10
		[SerializeField]
		private GachaDirectionStone.TypeChangeData m_changeToGold; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x687488 Offset: 0x687488 VA: 0x687488
		[Header("---- for Program ----")] // RVA: 0x687488 Offset: 0x687488 VA: 0x687488
		private List<GameObject> m_quartzRename; // 0x18
		//[TooltipAttribute] // RVA: 0x687508 Offset: 0x687508 VA: 0x687508
		[SerializeField]
		private List<GameObject> m_memoryRename; // 0x1C
		[SerializeField]
		private RefData m_meshRefData; // 0x20
		private List<Renderer> m_quartzRenderers; // 0x24
		private List<Renderer> m_memoryRenderers; // 0x28
		private Material m_quartzMaterial; // 0x2C
		private Material m_memoryMaterial; // 0x30
		private List<TypeChangeData> m_changeDatas; // 0x34

		public RefData meshRefData { get { return m_meshRefData; } } //0xE94A58

		// RVA: 0xE94A60 Offset: 0xE94A60 VA: 0xE94A60
		private void Awake()
		{
			m_quartzRenderers = new List<Renderer>(m_quartzRename.Count);
			for(int i = 0; i < m_quartzRename.Count; i++)
			{
				Renderer r = m_quartzRename[i].GetComponentInChildren<Renderer>(true);
				if(m_quartzMaterial == null)
				{
					m_quartzMaterial = new Material(r.material);
				}
				r.sharedMaterial = m_quartzMaterial;
				m_quartzRenderers.Add(r);
			}
			m_memoryRenderers = new List<Renderer>(m_memoryRename.Count);
			for(int i = 0; i < m_memoryRename.Count; i++)
			{
				Renderer r = m_memoryRename[i].GetComponentInChildren<Renderer>(true);
				if(m_memoryMaterial == null)
				{
					m_memoryMaterial = new Material(r.material);
				}
				r.sharedMaterial = m_memoryMaterial;
				m_memoryRenderers.Add(r);
			}
			m_changeDatas = new List<TypeChangeData>(3);
			m_changeDatas.Add(m_changeToBlue);
			m_changeDatas.Add(m_changeToRed);
			m_changeDatas.Add(m_changeToGold);
		}

		// RVA: 0xE94FAC Offset: 0xE94FAC VA: 0xE94FAC
		public void ChangeQuartzType(GachaDirectionQuartzTable.QuartzType type)
		{
			for(int i = 0; i < m_changeDatas.Count; i++)
			{
				if((int)type == i)
				{
					m_changeDatas[i].Apply(m_quartzMaterial, m_memoryMaterial);
				}
				else
				{
					m_changeDatas[i].Disapply();
				}
			}
		}
	}
}
