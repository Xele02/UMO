using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicCameraFollower : MonoBehaviour
	{
		[SerializeField]
		private float m_baseFov = -1; // 0xC
		private float m_baseTan = -1; // 0x10
		private Transform m_targetTransform; // 0x14
		private Camera m_targetCamera; // 0x18

		private bool isInitialized { get { return m_targetTransform != null; } } //0x111B194

		// RVA: 0x111B220 Offset: 0x111B220 VA: 0x111B220
		public void Initialize(MusicCameraObject cameraObject)
		{
			m_baseTan = CalcTan(m_baseFov);
			m_targetTransform = cameraObject.GetCameraTransform();
			m_targetCamera = m_targetTransform.GetComponent<Camera>();
		}

		// RVA: 0x111B36C Offset: 0x111B36C VA: 0x111B36C
		public void Initialize(Camera a_camera)
		{
			m_baseTan = CalcTan(m_baseFov);
			m_targetTransform = a_camera.transform;
			m_targetCamera = a_camera;
		}

		// RVA: 0x111B2CC Offset: 0x111B2CC VA: 0x111B2CC
		private float CalcTan(float fieldOfView)
		{
			return Mathf.Tan(fieldOfView * 0.5f * 0.01745329f);
		}

		// RVA: 0x111B3B0 Offset: 0x111B3B0 VA: 0x111B3B0
		private void LateUpdate()
		{
			if(isInitialized)
			{
				transform.position = m_targetTransform.position;
				transform.rotation = m_targetTransform.rotation;
				if(m_baseFov >= 0)
				{
					float tan = CalcTan(m_targetCamera.fieldOfView);
					float ratio = tan / m_baseTan;
					transform.localScale = new Vector3(ratio, ratio, 1);
				}
			}
		}
	}
}
