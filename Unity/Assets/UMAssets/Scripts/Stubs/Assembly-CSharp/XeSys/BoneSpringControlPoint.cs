using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class BoneSpringControlPoint : MonoBehaviour
	{
		public float radius;
		public float radiusEx;
		public BoneSpringControlPoint relational;
		public Vector3 m_bunding_sphere_pos;
		public float m_bunding_sphere_radius_sqr;
		public float weight;
		public float mass;
		public Vector3 localVelocity;
		public float stability;
		public float influence;
		public List<BoneSpringCollider> colliderList;
		public float influenceSuppressRateWind;
		public Vector3 m_forceFromOutside;
	}
}
