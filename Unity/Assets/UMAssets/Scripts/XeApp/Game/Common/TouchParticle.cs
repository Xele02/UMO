using UnityEngine;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Common
{
	public class TouchParticle : MonoBehaviour
	{
		private Camera m_camera; // 0xC
		[SerializeField]
		private ParticleSystem m_particle_press; // 0x10
		private Transform m_transform_press; // 0x14
		private TouchParticlePool m_particle_pool; // 0x18
		[SerializeField]
		private TouchParticleObject m_particle_object; // 0x1C
		private Transform m_transform_object; // 0x20
		[SerializeField]
		private Transform m_pool; // 0x24
		private List<TouchParticleObject> m_useParticlePoolList = new List<TouchParticleObject>(); // 0x28
		private ParticleSystem[] m_patricles; // 0x2C
		private Action m_updater; // 0x30
		private bool m_is_touch; // 0x34
		private bool m_is_acceleration; // 0x35
		private int m_frame; // 0x38
		private Vector3 m_old_pos; // 0x3C
		private const int POOL_OBJECT_MAX = 5;
		private const int PARTICLE_START_TIME = 0;
		[SerializeField]
		private float MAGNITUDE_MIN = 0.0125f; // 0x48

		public Camera Camera { get { return m_camera; } set { m_camera = value; } } //0x1CCFAC4 0x1CCFACC

		// // RVA: 0x1CCFAD4 Offset: 0x1CCFAD4 VA: 0x1CCFAD4
		private void Awake()
		{
			m_particle_press.Stop();
			m_transform_press = m_particle_press.GetComponent<Transform>();
			if (m_particle_pool != null)
				m_particle_pool.Dispose();
			m_particle_pool = new TouchParticlePool();
			m_particle_pool.Create("ParticleObject_", gameObject, m_particle_object, 5, false);
			m_updater = this.UpdateIdle;
			m_patricles = GetComponentsInChildren<ParticleSystem>(true);
		}

		// // RVA: 0x1CCFCE0 Offset: 0x1CCFCE0 VA: 0x1CCFCE0
		private void Update()
		{
			m_updater();
		}

		// // RVA: 0x1CCFD0C Offset: 0x1CCFD0C VA: 0x1CCFD0C
		private void UpdateIdle()
		{
			if(!m_is_touch)
			{
				if(!InputManager.Instance.GetCurrentTouchInfo(0).isIllegal)
				{
					TodoLogger.Log(0, "Touch particle UpdateIdle");
				}
			}
		}

		// // RVA: 0x1CD02A8 Offset: 0x1CD02A8 VA: 0x1CD02A8
		// private void UpdateEnterParticlePress() { }

		// // RVA: 0x1CCFF48 Offset: 0x1CCFF48 VA: 0x1CCFF48
		// private Vector3 TouchPosition() { }

		// // RVA: 0x1CD0560 Offset: 0x1CD0560 VA: 0x1CD0560
		// private void UpdateStop() { }

		// // RVA: 0x1CD0610 Offset: 0x1CD0610 VA: 0x1CD0610
		// public void Stop() { }

		// // RVA: 0x1CD07C8 Offset: 0x1CD07C8 VA: 0x1CD07C8
		// public void SetTouchEffectMode(bool isRhythmGame) { }
	}
}
