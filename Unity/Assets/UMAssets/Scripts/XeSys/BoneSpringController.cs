using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class BoneSpringController : MonoBehaviour
	{
		public enum PerformanceMode
		{
			High = 0,
			Low = 1,
		}
		
		private class Average
		{
			private int m_cnt; // 0x8
			private int m_max; // 0xC
			private float[] m_data; // 0x10
			private float m_average; // 0x14

			// RVA: 0x192B400 Offset: 0x192B400 VA: 0x192B400
			public Average(int a_max)
			{
				m_data = new float[a_max];
				m_cnt = 0;
				m_max = a_max;
				m_average = 0.0f;
			}

			//// RVA: 0x192B4EC Offset: 0x192B4EC VA: 0x192B4EC
			public void SetData(float a_data)
			{
				m_data[m_cnt] = a_data;
				m_cnt = (m_cnt + 1) % m_max;
			}

			//// RVA: 0x192B55C Offset: 0x192B55C VA: 0x192B55C
			public float CalcAverage()
			{
				float sum = 0;
				for(int i = 0; i < m_max; i++)
				{
					sum += m_data[i];
				}
				m_average = sum / m_max;
				return m_average;
			}
		}

		private List<BoneSpringControlPoint> controlPoints = new List<BoneSpringControlPoint>(); // 0xC
		public Vector3 fieldForce_ = new Vector3(0, -0.98f, 0); // 0x10
		[RangeAttribute(0, 1)] // RVA: 0x6532F4 Offset: 0x6532F4 VA: 0x6532F4
		public float influence = 1.0f; // 0x1C
		public float Scale = 1; // 0x20
		private BoneSpringController.Average averageGameDeltaTime; // 0x30
		public const int BIT_LOCK_DEFAULT = 0;
		public const int BIT_LOCK_ANIMETION = 1;
		private int isLockBit; // 0x34
		//[HideInInspector] // RVA: 0x65333C Offset: 0x65333C VA: 0x65333C
		[SerializeField]
		private BoneSpringSettingParameter highPerformanceSettingParameter; // 0x38
		//[HideInInspector] // RVA: 0x65336C Offset: 0x65336C VA: 0x65336C
		[SerializeField]
		private BoneSpringSettingParameter lowPerformanceSettingParameter; // 0x3C
		//[HideInInspector] // RVA: 0x65339C Offset: 0x65339C VA: 0x65339C
		[SerializeField]
		private BoneSpringController.PerformanceMode currentPerformanceMode; // 0x40
		[SerializeField]
		private List<BoneSpringCollider> m_collider; // 0x44
		[SerializeField]
		private bool m_enable = true; // 0x48

		private float gameDeltaTime { get; set; } // 0x24
		public float fpsRate { get; private set; } // 0x28
		public float fpsRateSq { get; private set; } // 0x2C

		//// RVA: 0x192B390 Offset: 0x192B390 VA: 0x192B390
		private void Awake()
		{
			averageGameDeltaTime = new Average(15);
		}

		//// RVA: 0x192B488 Offset: 0x192B488 VA: 0x192B488
		private void Start()
		{
			return;
		}

		//// RVA: 0x192B48C Offset: 0x192B48C VA: 0x192B48C
		private void Update()
		{
			gameDeltaTime = Time.smoothDeltaTime;
			averageGameDeltaTime.SetData(gameDeltaTime);
			gameDeltaTime = averageGameDeltaTime.CalcAverage();
		}

		//// RVA: 0x192B5F4 Offset: 0x192B5F4 VA: 0x192B5F4
		private void LateUpdate()
		{
			if (!m_enable)
				return;
			UpdateControlPoint();
		}

		//// RVA: 0x192B9E4 Offset: 0x192B9E4 VA: 0x192B9E4
		private void FixedUpdate()
		{
			return;
		}

		//// RVA: 0x192B9E8 Offset: 0x192B9E8 VA: 0x192B9E8
		public void Initialize(BoneSpringController.PerformanceMode mode)
		{
			currentPerformanceMode = mode;
			Scale = 1;
			BoneSpringSettingParameter param = highPerformanceSettingParameter;
			if (mode == PerformanceMode.Low)
			{
				param = lowPerformanceSettingParameter;
			}
			if(param != null)
			{
				param.Load(gameObject);
			}
			controlPoints.Clear();
			SearchControlPoint(gameObject.transform);
			for(int i = 0; i < controlPoints.Count; i++)
			{
				controlPoints[i].Initialize(this);
			}
			m_collider.Clear();
			m_collider.AddRange(gameObject.transform.GetComponentsInChildren<BoneSpringCollider>(true));
			for(int i = 0; i < m_collider.Count; i++)
			{
				m_collider[i].Initialize(this);
			}
			gameDeltaTime = 1.0f / Application.targetFrameRate;
		}

		//// RVA: 0x192BD68 Offset: 0x192BD68 VA: 0x192BD68
		private void SearchControlPoint(Transform t)
		{
			BoneSpringControlPoint[] cps = t.GetComponents<BoneSpringControlPoint>();
			for(int i = 0; i < cps.Length; i++)
			{
				controlPoints.Add(cps[i]);
			}
			for(int i = 0; i < t.childCount; i++)
			{
				SearchControlPoint(t.GetChild(i));
			}
		}

		//// RVA: 0x192B604 Offset: 0x192B604 VA: 0x192B604
		private void UpdateControlPoint()
		{
			if(isLockBit == 0)
			{
				fpsRate = gameDeltaTime / (1.0f/60);
				fpsRate = Mathf.Max(fpsRate, 1.0f);
				fpsRateSq = fpsRate * fpsRate;
				for(int i = 0; i < m_collider.Count; i++)
				{
					m_collider[i].UpdatePosition();
				}
				for(int i = 0; i < m_collider.Count; i++)
				{
					m_collider[i].UpdateBoundingSphere();
				}
				for(int i = 0; i < controlPoints.Count; i++)
				{
					if(controlPoints[i].gameObject.activeInHierarchy)
					{
						controlPoints[i].UpdatePoint();
					}
				}
				for (int i = 0; i < controlPoints.Count; i++)
				{
					if (controlPoints[i].gameObject.activeInHierarchy)
					{
						controlPoints[i].CheckCollision();
					}
				}
			}
		}

		//// RVA: 0x192BED0 Offset: 0x192BED0 VA: 0x192BED0
		//private void ApplyControlPoint() { }

		//// RVA: 0x192C02C Offset: 0x192C02C VA: 0x192C02C
		public void Lock(int a_index = 0)
		{
			isLockBit |= 1 << a_index;
		}

		//// RVA: 0x192C044 Offset: 0x192C044 VA: 0x192C044
		public void Unlock(int a_index = 0)
		{
			isLockBit &= ~(1 << a_index);
		}

		//// RVA: 0x192C05C Offset: 0x192C05C VA: 0x192C05C
		public bool IsLock(int a_index = 0)
		{
			return (isLockBit & (1 << a_index)) != 0;
		}

		//// RVA: 0x192C078 Offset: 0x192C078 VA: 0x192C078
		public void RequestInitialize()
		{
			for(int i = 0; i < controlPoints.Count; i++)
			{
				controlPoints[i].RequestInitialize();
			}
		}

		//// RVA: 0x192C150 Offset: 0x192C150 VA: 0x192C150
		public List<BoneSpringControlPoint> GetListBSCP()
		{
			return controlPoints;
		}
	}
}
