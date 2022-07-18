using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class BoneSpringControlPoint : MonoBehaviour
	{
		public float radius = 1; // 0x10
		public float radiusEx = 1; // 0x14
		public BoneSpringControlPoint relational; // 0x18
		public Vector3 m_bunding_sphere_pos; // 0x1C
		public float m_bunding_sphere_radius_sqr; // 0x28
		[RangeAttribute(-1, 2)] // RVA: 0x6533FC Offset: 0x6533FC VA: 0x6533FC
		public float weight = 1; // 0x2C
		[RangeAttribute(0, 10000)] // RVA: 0x653418 Offset: 0x653418 VA: 0x653418
		public float mass = 1; // 0x30
		public Vector3 localVelocity; // 0x34
		[RangeAttribute(0, 1)] // RVA: 0x653434 Offset: 0x653434 VA: 0x653434
		public float stability = 1; // 0x40
		[RangeAttribute(0, 1)] // RVA: 0x65344C Offset: 0x65344C VA: 0x65344C
		public float influence = 1; // 0x44
		public List<BoneSpringCollider> colliderList; // 0x48
		private Vector3 currentPosition; // 0x4C
		private Vector3 prevPosition; // 0x58
		private Vector3 boneDirection; // 0x64
		private float originalBoneLength; // 0x70
		private float boneLength; // 0x74
		private Quaternion originalLocalRotation; // 0x78
		private Transform parentTransform; // 0x88
		public float influenceSuppressRateWind; // 0x94
		private Quaternion m_resultParentRot = Quaternion.identity; // 0x98
		public Vector3 m_forceFromOutside = new Vector3(0, 0, 0); // 0xA8

		public BoneSpringController controller { get; private set; } // 0xC
		public bool isRequestInitialize { get; private set; } // 0x8C
		public float influenceSuppressRate { private get; set; } // 0x90

		//// RVA: 0x1928B30 Offset: 0x1928B30 VA: 0x1928B30
		private void Awake()
		{
			parentTransform = transform.parent;
			if(parentTransform != null)
			{
				originalLocalRotation = parentTransform.localRotation;
				m_forceFromOutside = new Vector3(0, 0, 0);
			}
		}

		//// RVA: 0x1928C50 Offset: 0x1928C50 VA: 0x1928C50
		public void Initialize(BoneSpringController controller)
		{
			parentTransform = transform.parent;
			if(parentTransform != null)
			{
				isRequestInitialize = false;
				this.controller = controller;
				influenceSuppressRate = 0;
				influenceSuppressRateWind = 0;
				currentPosition = transform.position;
				prevPosition = transform.position;
				boneDirection = transform.position.normalized;
				originalBoneLength = (parentTransform.position - transform.position).sqrMagnitude;
			}
		}

		//// RVA: 0x1928EF0 Offset: 0x1928EF0 VA: 0x1928EF0
		//public void RequestInitialize() { }

		//// RVA: 0x1928EFC Offset: 0x1928EFC VA: 0x1928EFC
		//public void UpdatePoint() { }

		//// RVA: 0x19298C0 Offset: 0x19298C0 VA: 0x19298C0
		//public void UpdateBoundingSphere() { }

		//// RVA: 0x1929BD0 Offset: 0x1929BD0 VA: 0x1929BD0
		//public void CheckCollision() { }

		//// RVA: 0x1929FDC Offset: 0x1929FDC VA: 0x1929FDC
		//public void ApplyPoint() { }

		//// RVA: 0x192A0B8 Offset: 0x192A0B8 VA: 0x192A0B8
		//private void AfterCollisionProcess(float distance, float colRadius, Vector3 disangageVec) { }

		//// RVA: 0x1929728 Offset: 0x1929728 VA: 0x1929728
		//private void KeepBoneLength() { }

		//// RVA: 0x1929E88 Offset: 0x1929E88 VA: 0x1929E88
		//public bool CheckCollision(BoneSpringCollider collider) { }

		//// RVA: 0x192A1E0 Offset: 0x192A1E0 VA: 0x192A1E0
		//private bool CheckSphererSphererCollision(BoneSpringCollider collider) { }

		//// RVA: 0x192A3EC Offset: 0x192A3EC VA: 0x192A3EC
		//private bool CheckSphererCapsuleCollision(BoneSpringCollider collider) { }

		//// RVA: 0x192AADC Offset: 0x192AADC VA: 0x192AADC
		//private bool CheckCapsuleCapsuleCollision(BoneSpringCollider collider) { }

		//// RVA: 0x192B028 Offset: 0x192B028 VA: 0x192B028
		//public void CalcBoundingSphereFromCapsule(Vector3 t_st, Vector3 t_ed, float t_st_radius, float t_ed_radius, out Vector3 a_pos, out float a_radius) { }
	}
}
