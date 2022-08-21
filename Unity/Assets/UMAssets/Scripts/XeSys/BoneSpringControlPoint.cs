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
				boneDirection = transform.localPosition.normalized;
				originalBoneLength = (parentTransform.position - transform.position).magnitude;
			}
		}

		//// RVA: 0x1928EF0 Offset: 0x1928EF0 VA: 0x1928EF0
		public void RequestInitialize()
		{
			isRequestInitialize = true;
		}

		//// RVA: 0x1928EFC Offset: 0x1928EFC VA: 0x1928EFC
		public void UpdatePoint()
		{
			if (parentTransform == null)
				return;
			if (isRequestInitialize)
				Initialize(controller);
			radiusEx = radius * controller.Scale;
			boneLength = originalBoneLength * controller.Scale;
			parentTransform.localRotation = originalLocalRotation;
			Vector3 savePrevPos = prevPosition;
			prevPosition = currentPosition;
			currentPosition = (2 * currentPosition) - savePrevPos + ((controller.fpsRateSq * (parentTransform.rotation * localVelocity)) + ((m_forceFromOutside * (1- influenceSuppressRateWind)) + (controller.fpsRateSq * (parentTransform.rotation * boneDirection * weight)) + (controller.fpsRateSq * (controller.fieldForce_ * mass))) + (controller.fpsRate * (stability * (savePrevPos - currentPosition))));
			float inf = influence * (1 - influenceSuppressRate) * controller.influence;
			if(inf <= 0)
			{
				currentPosition = transform.position;
			}
			else if(inf < 1)
			{
				currentPosition = Vector3.Lerp(transform.position, currentPosition, inf);
			}
			KeepBoneLength();
			parentTransform.rotation = Quaternion.FromToRotation(parentTransform.TransformDirection(boneDirection), currentPosition - parentTransform.position) * parentTransform.rotation;
			m_resultParentRot = parentTransform.rotation;
		}

		//// RVA: 0x19298C0 Offset: 0x19298C0 VA: 0x19298C0
		public void UpdateBoundingSphere()
		{
			if(relational != null)
			{
				Vector3 dir = (relational.currentPosition - currentPosition).normalized;
				Vector3 halfdist = ((relational.currentPosition + (dir * relational.radiusEx * 1) - (currentPosition + (dir * radiusEx * -1))) * 0.5f);
				m_bunding_sphere_pos = halfdist+(currentPosition + (dir * radiusEx * -1));
				m_bunding_sphere_radius_sqr = halfdist.sqrMagnitude;
			}
		}

		//// RVA: 0x1929BD0 Offset: 0x1929BD0 VA: 0x1929BD0
		public void CheckCollision()
		{
			UpdateBoundingSphere();
			bool hasCollision = false;
			for(int i = 0; i < colliderList.Count; i++)
			{
				hasCollision |= CheckCollision(colliderList[i]);
			}
			if(hasCollision)
			{
				parentTransform.rotation = Quaternion.FromToRotation(parentTransform.TransformDirection(boneDirection), currentPosition - parentTransform.position) * parentTransform.rotation;
				m_resultParentRot = parentTransform.rotation;
			}
		}

		//// RVA: 0x1929FDC Offset: 0x1929FDC VA: 0x1929FDC
		//public void ApplyPoint() { }

		//// RVA: 0x192A0B8 Offset: 0x192A0B8 VA: 0x192A0B8
		private void AfterCollisionProcess(float distance, float colRadius, Vector3 disangageVec)
		{
			currentPosition = currentPosition + disangageVec * (1 - distance / colRadius);
			KeepBoneLength();
			UpdateBoundingSphere();
		}

		//// RVA: 0x1929728 Offset: 0x1929728 VA: 0x1929728
		private void KeepBoneLength()
		{
			currentPosition = parentTransform.position + ((currentPosition - parentTransform.position) * boneLength / (currentPosition - parentTransform.position).magnitude);
		}

		//// RVA: 0x1929E88 Offset: 0x1929E88 VA: 0x1929E88
		public bool CheckCollision(BoneSpringCollider collider)
		{
			if(collider != null)
			{
				if (relational == null && collider.relational == null)
					return CheckSphererSphererCollision(collider);
				else if (relational != null && collider.relational != null)
					return CheckCapsuleCapsuleCollision(collider);
				else
					return CheckSphererCapsuleCollision(collider);
			}
			return false;
		}

		//// RVA: 0x192A1E0 Offset: 0x192A1E0 VA: 0x192A1E0
		private bool CheckSphererSphererCollision(BoneSpringCollider collider)
		{
			float realDist = (currentPosition - collider.position).sqrMagnitude;
			float sqrDist = radiusEx + collider.radiusEx;
			sqrDist = sqrDist * sqrDist;
			if(realDist <= sqrDist)
			{
				AfterCollisionProcess(Vector3.Distance(currentPosition, collider.position), radiusEx + collider.radiusEx, currentPosition - collider.position);
				return true;
			}
			return false;
		}

		//// RVA: 0x192A3EC Offset: 0x192A3EC VA: 0x192A3EC
		private bool CheckSphererCapsuleCollision(BoneSpringCollider collider)
		{
			float lineNearestTargetRate;
			float intersectRadius, testRadius, intersectDist;
			Vector3 testPos, testPos2;
			if (relational != null)
			{
				// This is a sphere, other is a capsule
				intersectDist = Math.CalcNearDistancePointToLine(collider.position, currentPosition, relational.transform.position, out lineNearestTargetRate);
				Vector3 v = collider.position;
				intersectRadius = collider.radiusEx;
				testRadius = Mathf.Lerp(radiusEx, relational.radiusEx, lineNearestTargetRate);
				testPos2 = collider.position;
				testPos = currentPosition + ((relational.transform.position - currentPosition) * lineNearestTargetRate);
			}
			else
			{
				intersectDist = Math.CalcNearDistancePointToLine(currentPosition, collider.position, collider.relational.position, out lineNearestTargetRate);
				intersectRadius = Mathf.Lerp(collider.radiusEx, collider.relational.radiusEx, lineNearestTargetRate);
				testRadius = radiusEx;
				testPos2 = collider.position + (collider.relational.position - collider.position) * lineNearestTargetRate;
				testPos = currentPosition;
			}
			float fullRadius = intersectRadius + testRadius;
			if (intersectDist <= fullRadius)
			{
				Vector3 dir = testPos - testPos2;
				if(relational != null)
				{
					AfterCollisionProcess(intersectDist, fullRadius, dir * (1 - lineNearestTargetRate));
					relational.AfterCollisionProcess(intersectDist, fullRadius, dir * lineNearestTargetRate);
				}
				else
				{
					AfterCollisionProcess(intersectDist, fullRadius, dir);
				}
				return true;
			}
			return false;
		}

		//// RVA: 0x192AADC Offset: 0x192AADC VA: 0x192AADC
		private bool CheckCapsuleCapsuleCollision(BoneSpringCollider collider)
		{
			if((m_bunding_sphere_pos - collider.m_bunding_sphere_pos).sqrMagnitude <= (m_bunding_sphere_radius_sqr + collider.m_bunding_sphere_radius_sqr))
			{
				float line1targetRate, line2TargetRate;
				float dist = Math.CalcNearDistanceLineToLine(currentPosition, relational.transform.position, collider.position, collider.relational.position, out line1targetRate, out line2TargetRate);
				float radius1 = Mathf.Lerp(radiusEx, relational.radiusEx, line1targetRate);
				float radius2 = Mathf.Lerp(collider.radiusEx, collider.relational.radiusEx, line2TargetRate);
				if(dist <= (radius1 + radius2))
				{
					Vector3 dir = (((relational.transform.position - currentPosition) * line1targetRate + currentPosition) - (collider.position + ((collider.relational.position - collider.position) * line2TargetRate))) * (1 - line1targetRate);
					AfterCollisionProcess(dist, (radius1 + radius2), dir);
					dir = (((relational.transform.position - currentPosition) * line1targetRate + currentPosition) - (collider.position + ((collider.relational.position - collider.position) * line2TargetRate))) * (line1targetRate);
					relational.AfterCollisionProcess(dist, (radius1 + radius2), dir);
					return true;
				}
			}
			return false;
		}

		//// RVA: 0x192B028 Offset: 0x192B028 VA: 0x192B028
		//public void CalcBoundingSphereFromCapsule(Vector3 t_st, Vector3 t_ed, float t_st_radius, float t_ed_radius, out Vector3 a_pos, out float a_radius) { }

		public void DrawDebugVolume()
		{
			Gizmos.DrawSphere(transform.position, radius);
			if(relational != null)
			{
				Gizmos.DrawSphere(relational.transform.position, relational.radius);
				Gizmos.DrawLine(transform.position, relational.transform.position);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (UnityEditor.Selection.activeGameObject != this.gameObject) return;
			Gizmos.color = Color.red;
			DrawDebugVolume();
			Gizmos.color = Color.blue;
			if (colliderList != null)
			{
				foreach (var col in colliderList)
				{
					if (col)
					{
						col.DrawDebugVolume();
						//Gizmos.DrawRay(new Ray(GetComponent<Transform>().position, col.GetComponent<Transform>().position));
						//Gizmos.DrawLine(GetComponent<Transform>().position, col.GetComponent<Transform>().position);
					}
				}
			}
		}
	}
}
