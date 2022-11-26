using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class CameraStretchBillboard : MonoBehaviour
	{
		[SerializeField]
		private Camera m_camera; // 0xC
		[SerializeField]
		private float m_distance; // 0x10
		private Func<float> m_aspectRatioCallback; // 0x14

		private float aspectRatio { get { return m_aspectRatioCallback != null ? m_aspectRatioCallback() : m_camera.aspect; } } //0xE64DFC

		// RVA: 0xE64E8C Offset: 0xE64E8C VA: 0xE64E8C
		public void Setup(Camera camera, float distance, Func<float> aspectRatioCallback)
		{
			m_camera = camera;
			m_distance = distance;
			m_aspectRatioCallback = aspectRatioCallback;
		}

		// RVA: 0xE64E98 Offset: 0xE64E98 VA: 0xE64E98
		private void LateUpdate()
		{
			if(m_camera == null)
				return;
			m_distance = m_camera.farClipPlane * 0.99f;
			transform.position = m_camera.transform.position + m_camera.transform.forward * m_distance;
			transform.LookAt(m_camera.transform.position, m_camera.transform.up);
			float f = m_camera.fieldOfView * 0.5f * 0.01745329f * m_distance * 2;
			transform.localScale = new Vector3(f * aspectRatio, f, 1.0f);
		}
	}
}
