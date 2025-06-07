using UnityEngine;

namespace XeApp.Game.Menu
{
	public class McrsCannonShakeObject : MonoBehaviour
	{
		public Vector3 Move; // 0xC
		public Vector3 Rotate; // 0x18
		public float Speed; // 0x24
		public float Duration; // 0x28
		public float Scale; // 0x2C
		private bool m_play; // 0x30
		private Camera m_camera; // 0x34
		private float m_startTime; // 0x38
		private bool m_loop; // 0x3C
		private Vector3 m_seed; // 0x40
		private const float TransitionTime = 1;
		private const float SeedMinRange = 500;
		private const float SeedMaxRange = 1000;

		// RVA: 0xEBCECC Offset: 0xEBCECC VA: 0xEBCECC
		private void LateUpdate()
		{
			if(m_play)
			{
				Matrix4x4 m = CreateMatrix();
				if(m_loop || CurrentEaseOutSin() < 1)
				{
					Matrix4x4 m2 = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(1, 1, -1)) * m;
					m_camera.worldToCameraMatrix = m_camera.transform.worldToLocalMatrix * m2;
				}
				else
				{
					Destroy(gameObject);
					m_camera.ResetWorldToCameraMatrix();
					m_play = false;
				}
			}
		}

		// RVA: 0xEBBA34 Offset: 0xEBBA34 VA: 0xEBBA34
		public void Play(Camera camera)
		{
			m_camera = camera;
			m_startTime = Time.time;
			m_loop = Duration == -1;
			m_seed = new Vector3(UnityEngine.Random.Range(500.0f, 1000.0f), UnityEngine.Random.Range(500.0f, 1000.0f), UnityEngine.Random.Range(500.0f, 1000.0f));
			if(m_loop)
				Duration = 1;
			m_play = true;
		}

		// // RVA: 0xEBDBE4 Offset: 0xEBDBE4 VA: 0xEBDBE4
		// public void Finish(bool immediate = False) { }

		// // RVA: 0xEBD694 Offset: 0xEBD694 VA: 0xEBD694
		public Matrix4x4 CreateMatrix()
		{
			float f = CurrentEaseOutSin();
			Vector3 a0 = Speed * (Time.time * Vector3.one + m_seed);
			Vector3 b8 = Vector3.Slerp(Move, Vector3.zero, f);
			Vector3 d0 = Vector3.Slerp(Rotate, Vector3.zero, f);
			Vector3 location = Vector3.zero;
			if(Move != Vector3.zero)
			{
				location = new Vector3(b8.x * Mathf.Sin(a0.x), b8.y * Mathf.Sin(a0.y), b8.z * Mathf.Sin(a0.z));
				location.z += location.sqrMagnitude * Scale;
			}
			Quaternion quat = Quaternion.identity;
			if(Rotate != Vector3.zero)
			{
				quat = Quaternion.Euler(new Vector3(d0.x * Mathf.Sin(a0.x), d0.y * Mathf.Sin(a0.y), d0.z * Mathf.Sin(a0.z)));
			}
			return Matrix4x4.TRS(location, quat, Vector3.one);
		}

		// // RVA: 0xEBDBA0 Offset: 0xEBDBA0 VA: 0xEBDBA0
		// public bool IsDone() { }

		// // RVA: 0xEBDC4C Offset: 0xEBDC4C VA: 0xEBDC4C
		private float CurrentEaseOutSin()
		{
			return ApplyEaseOutSin(0, 1, Mathf.Clamp((Time.time - m_startTime) / Duration, 0, 1));
		}

		// // RVA: 0xEBDD18 Offset: 0xEBDD18 VA: 0xEBDD18
		private float ApplyEaseOutSin(float start, float end, float current)
		{
			return (end - start) * Mathf.Sin(current * 1.570796f) + start;
		}
	}
}
