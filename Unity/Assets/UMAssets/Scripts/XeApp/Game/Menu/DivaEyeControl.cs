using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class DivaEyeControl : MonoBehaviour
	{
		[Serializable]
		public class AngleData
		{
			public float angle; // 0x8
			public float offset; // 0xC
		}

		[Serializable]
		public class EyeUVData
		{
			public AngleData xMin; // 0x8
			public AngleData xMax; // 0xC
			public AngleData yMin; // 0x10
			public AngleData yMax; // 0x14
		}
		
		private class OffsetData
		{
			public bool is_update; // 0x8
			public float target; // 0xC
			public float last; // 0x10
		}

		[SerializeField]
		private EyeUVData m_uvData; // 0xC
		private SkinnedMeshRenderer m_renderer; // 0x10
		private Transform m_head; // 0x14
		private GameObject m_targetObj; // 0x18
		private Vector3 m_targetPos = Vector3.zero; // 0x1C
		private bool m_isUpdate; // 0x28
		private bool m_isUpdateX; // 0x29
		private bool m_isUpdateY; // 0x2A
		private OffsetData m_offsetDataX = new OffsetData(); // 0x2C
		private OffsetData m_offsetDataY = new OffsetData(); // 0x30
		private Action m_updater; // 0x34
		private float m_elapsedTime; // 0x38
		private float m_restoreTime; // 0x3C

		public EyeUVData eyeUVData { get { return m_uvData; } set { m_uvData = value; } } //0x17DD790 0x17DD798

		// RVA: 0x17DD7A0 Offset: 0x17DD7A0 VA: 0x17DD7A0
		public void Awake()
		{
			return;
		}

		//// RVA: 0x17DD7A4 Offset: 0x17DD7A4 VA: 0x17DD7A4
		public void Initialize(GameObject diva_obj)
		{
			m_renderer = diva_obj.transform.Find("mesh_root/eye").GetComponent<SkinnedMeshRenderer>();
			m_head = FindTransformInDescendant("head", diva_obj.transform.Find("joint_root/hips"));
			m_offsetDataX.last = m_renderer.material.mainTextureOffset.x;
			m_offsetDataY.last = m_renderer.material.mainTextureOffset.y;
			m_isUpdate = false;
		}

		//// RVA: 0x17DD964 Offset: 0x17DD964 VA: 0x17DD964
		private Transform FindTransformInDescendant(string name, Transform tf)
		{
			Transform[] ts = tf.GetComponentsInChildren<Transform>(true);
			for(int i = 0; i < ts.Length; i++)
			{
				if (ts[i].name == name)
					return ts[i];
			}
			return null;
		}

		//// RVA: 0x17DDA84 Offset: 0x17DDA84 VA: 0x17DDA84
		//private float angleRound180(float euler) { }

		//// RVA: 0x17DDAEC Offset: 0x17DDAEC VA: 0x17DDAEC
		public void On()
		{
			enabled = true;
			m_updater = UpdateIdle;
		}

		//// RVA: 0x17DDB84 Offset: 0x17DDB84 VA: 0x17DDB84
		public void Off()
		{
			enabled = false;
			m_updater = null;
		}

		//// RVA: 0x17DDBA8 Offset: 0x17DDBA8 VA: 0x17DDBA8
		public void SetTargetObj(GameObject target, bool is_update_x = true, bool is_update_y = true)
		{
			m_isUpdateX = is_update_x;
			m_targetObj = target;
			m_isUpdateY = is_update_y;
		}

		//// RVA: 0x17DDBB8 Offset: 0x17DDBB8 VA: 0x17DDBB8
		//public void SetTargetPos(Vector3 position) { }

		//// RVA: 0x17DDBCC Offset: 0x17DDBCC VA: 0x17DDBCC
		public void SetAngleX(float angle)
		{
			m_offsetDataX.is_update = true;
			m_offsetDataX.target = Mathf.Lerp(m_uvData.xMin.offset, m_uvData.xMax.offset, Mathf.Clamp01((angle - m_uvData.xMin.angle) / (m_uvData.xMax.angle - m_uvData.xMin.angle)));
		}

		//// RVA: 0x17DDD68 Offset: 0x17DDD68 VA: 0x17DDD68
		//public void SetAngleY(float angle) { }

		//// RVA: 0x17DDF04 Offset: 0x17DDF04 VA: 0x17DDF04
		//public void SetAngle(Vector2 angle) { }

		//// RVA: 0x17DDF28 Offset: 0x17DDF28 VA: 0x17DDF28
		public void Restore(float time)
		{
			m_elapsedTime = 0;
			m_restoreTime = time;
			m_updater = UpdateRestore;
		}

		//// RVA: 0x17DDFC8 Offset: 0x17DDFC8 VA: 0x17DDFC8
		private void LookAt(Vector3 target)
		{
			if(m_isUpdateX)
			{
				Vector3 v1 = (target - m_head.position).normalized;
				Vector3 v2 = m_head.forward.normalized;
				float angle = Vector3.Dot(v1, v2);
				angle = Mathf.Acos(Mathf.Clamp(angle, -1, 1));
				if(Vector3.Cross(v1, v2).y < 0)
				{
					angle = -angle;
				}
				SetAngleX(angle * 57.29578f);
			}
		}

		// RVA: 0x17DE298 Offset: 0x17DE298 VA: 0x17DE298
		public void LateUpdate()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x17DE2AC Offset: 0x17DE2AC VA: 0x17DE2AC
		private void UpdateIdle()
		{
			if(m_targetObj != null)
			{
				m_isUpdate = true;
				m_targetPos = m_targetObj.transform.position;
			}
			if(m_isUpdate)
			{
				LookAt(m_targetPos);
				m_isUpdate = false;
			}
			Vector2 offset = m_renderer.material.mainTextureOffset;
			if(m_offsetDataX.is_update)
			{
				offset.x = Mathf.Lerp(m_offsetDataX.last, m_offsetDataX.target, 0.1f);
				m_offsetDataX.last = offset.x;
				if(Mathf.Abs(m_offsetDataX.target - offset.x) < 0.001f)
				{
					offset.x = m_offsetDataX.target;
					m_offsetDataX.is_update = false;
				}
				m_offsetDataX.last = offset.x;
			}
			if (m_offsetDataY.is_update)
			{
				offset.y = Mathf.Lerp(m_offsetDataY.last, m_offsetDataY.target, 0.1f);
				m_offsetDataY.last = offset.y;
				if (Mathf.Abs(m_offsetDataY.target - offset.y) < 0.001f)
				{
					offset.y = m_offsetDataY.target;
					m_offsetDataY.is_update = false;
				}
				m_offsetDataY.last = offset.y;
			}
			m_renderer.material.mainTextureOffset = offset;
		}

		//// RVA: 0x17DE6C4 Offset: 0x17DE6C4 VA: 0x17DE6C4
		private void UpdateRestore()
		{
			m_elapsedTime += Time.deltaTime;
			float r = Mathf.Clamp01(m_elapsedTime / m_restoreTime);
			if (r >= 1)
			{
				m_updater = null;
			}
			else
			{
				m_offsetDataX.last = Mathf.Lerp(m_offsetDataX.last, m_renderer.material.mainTextureOffset.x, r);
				m_offsetDataY.last = Mathf.Lerp(m_offsetDataY.last, m_renderer.material.mainTextureOffset.y, r);
				m_renderer.material.mainTextureOffset = new Vector2(m_offsetDataX.last, m_offsetDataY.last);
			}
		}
	}
}
