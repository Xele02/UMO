using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class TouchParticleObject : PoolObject
	{
		[SerializeField]
		private ParticleSystem m_particle_touch; // 0x14
		private Transform m_transform_touch; // 0x18
		[SerializeField]
		private Transform m_transform_sub; // 0x1C
		[SerializeField]
		private Animator m_touch_circle; // 0x20
		private Transform m_transform_circle; // 0x24
		private const int TouchSortingOrder = 200;
		private static readonly int m_animeStateName = Animator.StringToHash("Touchi_en"); // 0x0

		// RVA: 0x1CD09BC Offset: 0x1CD09BC VA: 0x1CD09BC
		private void Awake()
		{
			m_particle_touch.Stop();
			m_transform_touch = m_particle_touch.GetComponent<Transform>();
			m_transform_circle = m_touch_circle.GetComponent<Transform>();
			MeshRenderer[] mr = GetComponentsInChildren<MeshRenderer>();
			for(int i = 0; i < mr.Length; i++)
			{
				mr[i].sortingOrder = 200;
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x1CD0B3C Offset: 0x1CD0B3C VA: 0x1CD0B3C
		private void Start()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x1CD0B40 Offset: 0x1CD0B40 VA: 0x1CD0B40
		private void Update()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x1CD0BD8 Offset: 0x1CD0BD8 VA: 0x1CD0BD8
		// private void Release() { }

		// // RVA: 0x1CD0124 Offset: 0x1CD0124 VA: 0x1CD0124
		// public void Enter(Vector3 pos) { }

		// // RVA: 0x1CD0C28 Offset: 0x1CD0C28 VA: 0x1CD0C28
		// public void SetScale(Vector3 scale) { }

		// RVA: 0x1CD0C2C Offset: 0x1CD0C2C VA: 0x1CD0C2C Slot: 5
		protected override void PausableAwake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x1CD0C30 Offset: 0x1CD0C30 VA: 0x1CD0C30 Slot: 6
		protected override void PausableStart()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x1CD0C34 Offset: 0x1CD0C34 VA: 0x1CD0C34 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0x1CD0C38 Offset: 0x1CD0C38 VA: 0x1CD0C38 Slot: 8
		protected override void PausableInPause()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0x1CD0770 Offset: 0x1CD0770 VA: 0x1CD0770
		// public void Stop() { }
	}
}
