using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class ValkyrieModeLockOnTarget : MonoBehaviour
	{
		private bool m_isRunning; // 0xC
		private bool m_isPause; // 0xD
		private Transform m_target; // 0x10
		private Quaternion m_revertToRot = Quaternion.identity; // 0x14
		private float m_lerpTime = -1; // 0x24
		private float m_lerpLength = -1; // 0x28

		// RVA: 0x1CE2634 Offset: 0x1CE2634 VA: 0x1CE2634
		private void LateUpdate()
		{
			if (!m_isRunning || m_isPause)
				return;
			if(m_lerpLength >= 0)
			{
				m_lerpTime += TimeWrapper.deltaTime;
				if(m_lerpTime < m_lerpLength)
				{
					m_target.rotation = Quaternion.Lerp(m_target.rotation, Quaternion.LookRotation(transform.position - m_target.position, Vector3.up), m_lerpTime / m_lerpLength);
					return;
				}
				m_lerpTime = -1;
				m_lerpLength = -1;
			}
			m_target.LookAt(transform);
		}

		//// RVA: 0x1CE28D8 Offset: 0x1CE28D8 VA: 0x1CE28D8
		public void Register(Transform target)
		{
			m_target = target;
		}

		//// RVA: 0x1CE28E0 Offset: 0x1CE28E0 VA: 0x1CE28E0
		public void Begin(float lerpSec = -1)
		{
			m_isRunning = true;
			m_isPause = false;
			m_revertToRot = m_target.localRotation;
			if (lerpSec >= 0)
			{
				m_lerpTime = 0.0f;
				m_lerpLength = lerpSec;
			}
		}

		//// RVA: 0x1CE2958 Offset: 0x1CE2958 VA: 0x1CE2958
		//public void Pause() { }

		//// RVA: 0x1CE2964 Offset: 0x1CE2964 VA: 0x1CE2964
		//public void Resume() { }

		//// RVA: 0x1CE2970 Offset: 0x1CE2970 VA: 0x1CE2970
		//public void End() { }

		//// RVA: 0x1CE2A50 Offset: 0x1CE2A50 VA: 0x1CE2A50
		//public void Unregister() { }
	}
}
