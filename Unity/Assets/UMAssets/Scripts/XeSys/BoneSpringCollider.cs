using UnityEngine;

namespace XeSys
{
	public class BoneSpringCollider : MonoBehaviour
	{
		public float radius = 1; // 0x10
		public float radiusEx = 1; // 0x14
		public Vector3 offset; // 0x18
		public BoneSpringCollider relational; // 0x24
		public Vector3 m_bunding_sphere_pos; // 0x28
		public float m_bunding_sphere_radius_sqr; // 0x34

		public BoneSpringController controller { get; private set; } // 0xC
		public Vector3 position { get; private set; } // 0x38

		//// RVA: 0x1928650 Offset: 0x1928650 VA: 0x1928650
		public void Initialize(BoneSpringController a_controller)
		{
			controller = a_controller;
		}

		//// RVA: 0x1928658 Offset: 0x1928658 VA: 0x1928658
		public void UpdatePosition()
		{
			position = transform.rotation * offset + transform.position;
		}

		//// RVA: 0x19287D0 Offset: 0x19287D0 VA: 0x19287D0
		public void UpdateBoundingSphere()
		{
			radiusEx = radius * controller.Scale;
			if(relational != null)
			{
				Vector3 dir = (relational.position - position).normalized;
				Vector3 halfDist = (relational.position + (dir * relational.radiusEx * 1) - ((dir * radiusEx * -1) + position)) * 0.5f;
				m_bunding_sphere_pos = halfDist + ((dir * radiusEx * -1) + position);
				m_bunding_sphere_radius_sqr = halfDist.sqrMagnitude;
			}
		}
	}
}
