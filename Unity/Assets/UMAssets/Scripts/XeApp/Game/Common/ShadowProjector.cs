using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ShadowProjector : MonoBehaviour
	{
		[SerializeField]
		private Projector m_projector; // 0xC
		private Transform m_fitTo; // 0x10
		private Action m_lateAction; // 0x14

		// RVA: 0x13922C8 Offset: 0x13922C8 VA: 0x13922C8
		private void Awake()
		{
			m_projector.enabled = false;
			m_projector.material = new Material(m_projector.material);
		}

		// RVA: 0x13923A4 Offset: 0x13923A4 VA: 0x13923A4
		private void LateUpdate()
		{
			if (m_lateAction != null)
				m_lateAction();
		}

		//// RVA: 0x13923B8 Offset: 0x13923B8 VA: 0x13923B8
		public void SetupTarget(Transform target)
		{
			m_fitTo = target;
			m_projector.enabled = true;
			m_lateAction = this.UpdateTarget;
		}

		//// RVA: 0x139246C Offset: 0x139246C VA: 0x139246C
		public void Reset()
		{
			m_fitTo = null;
			m_projector.enabled = false;
			m_lateAction = null;
		}

		//// RVA: 0x13924AC Offset: 0x13924AC VA: 0x13924AC
		public void SetColor(Color color)
		{
			m_projector.material.SetColor("_MainColor", color);
		}

		//// RVA: 0x139256C Offset: 0x139256C VA: 0x139256C
		private void UpdateTarget()
		{
			if(m_fitTo == null)
			{
				Reset();
				return;
			}
			transform.position = m_fitTo.transform.position;
			transform.rotation = Quaternion.identity;
		}
	}
}
