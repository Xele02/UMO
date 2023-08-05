using UnityEngine;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MenuDivaGazeControl : MonoBehaviour
	{
		[Serializable]
		public class RotateData
		{
			public float min; // 0x8
			public float max; // 0xC
			public RotateType type; // 0x10
		}

		[Serializable]
		public class Data
		{
			[Serializable]
			public class NodeData
			{
				public RotateData Head; // 0x8
				public RotateData Neck; // 0xC
				public RotateData Spine2; // 0x10
				public RotateData Spine1; // 0x14
				public RotateData Spine; // 0x18
			}
			
			public DivaEyeControl.EyeUVData eyeUVData = new DivaEyeControl.EyeUVData() {
				xMin = new DivaEyeControl.AngleData() { angle = -30, offset = 0.04f },
				xMax = new DivaEyeControl.AngleData() { angle = 30, offset = -0.04f },
				yMin = new DivaEyeControl.AngleData() { angle = -45, offset = 0.1f },
				yMax = new DivaEyeControl.AngleData() { angle = 45, offset = -0.1f }
			}; // 0x8
			public NodeData nodeData = new NodeData()
			{
				Head = new RotateData() { min = -35, max = 35, type = RotateType.X },
				Neck = new RotateData() { min = -20, max = 20, type = RotateType.X },
				Spine2 = new RotateData() { min = -11, max = 11, type = RotateType.X },
				Spine1 = new RotateData() { min = -11, max = 11, type = RotateType.X },
				Spine = new RotateData() { min = -11, max = 11, type = RotateType.Y }
			}; // 0xC
			public float threshold = 45; // 0x10

			// RVA: 0xEC9884 Offset: 0xEC9884 VA: 0xEC9884
			//public MenuDivaGazeControl.RotateData GetRotateData(MenuDivaGazeControl.NodeType type) { }
		}
		
		// Namespace: 
		public enum NodeType
		{
			None = -1,
			Head = 0,
			Neck = 1,
			Spine2 = 2,
			Spine1 = 3,
			Spine = 4,
			Num = 5,
		}

		public enum RotateType
		{
			None = -1,
			X = 0,
			Y = 1,
			Z = 2,
			Num = 3,
		}
		
		private static readonly string[] NodeTable = new string[5] { "head", "neck", "spine2", "spine1", "spine" }; // 0x0
		private DivaEyeControl m_EyeControl; // 0xC
		private GameObject m_TargetObj; // 0x10
		private Data m_ControlData; // 0x14
		private Transform[] m_Nodes = new Transform[5]; // 0x18
		private Quaternion[] m_Rots = new Quaternion[5]; // 0x1C
		private Action m_Updater; // 0x20
		private float m_ElapsedTime; // 0x24
		private bool m_IsRight; // 0x28

		public GameObject TargetObj { set { m_TargetObj = value; } } //0xEC86C4
		public Data ControlData { set
			{
				m_ControlData = value;
				if(m_EyeControl != null)
				{
					m_EyeControl.eyeUVData = m_ControlData.eyeUVData;
				}
			} } //0xEC86CC

		//// RVA: 0xEC87A4 Offset: 0xEC87A4 VA: 0xEC87A4
		private Transform FindTransformInDescendant(string name, Transform tf)
		{
			Transform[] ts = tf.GetComponentsInChildren<Transform>(true);
			for (int i = 0; i < ts.Length; i++)
			{
				if (ts[i].name == name)
					return ts[i];
			}
			return null;
		}

		//// RVA: 0xEC88C4 Offset: 0xEC88C4 VA: 0xEC88C4
		//private float angleRound180(float euler) { }

		// RVA: 0xEC892C Offset: 0xEC892C VA: 0xEC892C
		public void Awake()
		{
			m_EyeControl = gameObject.AddComponent<DivaEyeControl>();
		}

		// RVA: 0xEC89B4 Offset: 0xEC89B4 VA: 0xEC89B4
		public void OnDestroy()
		{
			Destroy(m_EyeControl);
			m_EyeControl = null;
		}

		//// RVA: 0xEC8A44 Offset: 0xEC8A44 VA: 0xEC8A44
		public void Initialize()
		{
			DivaObject d = GetComponent<DivaObject>();
			m_EyeControl.Initialize(d.divaPrefab);
			m_EyeControl.SetTargetObj(m_TargetObj, true, false);
			Transform hips = d.divaPrefab.transform.Find("joint_root/hips");
			for(int i = 0; i < NodeTable.Length; i++)
			{
				m_Nodes[i] = FindTransformInDescendant(NodeTable[i], hips);
				m_Rots[i] = m_Nodes[i].localRotation;
			}
		}

		//// RVA: 0xEC8DD0 Offset: 0xEC8DD0 VA: 0xEC8DD0
		public void On()
		{
			enabled = true;
			m_EyeControl.On();
			m_Updater = UpdateGazeControl;
		}

		//// RVA: 0xEC8E88 Offset: 0xEC8E88 VA: 0xEC8E88
		public void Off()
		{
			enabled = false;
			m_EyeControl.Off();
			m_Updater = null;
		}

		//// RVA: 0xEC8ECC Offset: 0xEC8ECC VA: 0xEC8ECC
		public void Restore()
		{
			m_ElapsedTime = 0;
			m_EyeControl.Restore(ViewModeCameraManCs.TRANSITION_TIME);
			m_Updater = UpdateRestore;
		}

		// RVA: 0xEC8FCC Offset: 0xEC8FCC VA: 0xEC8FCC
		public void LateUpdate()
		{
			if(m_ControlData != null && m_Updater != null)
			{
				m_Updater();
			}
		}

		//// RVA: 0xEC8FEC Offset: 0xEC8FEC VA: 0xEC8FEC
		private void UpdateGazeControl()
		{
			Vector3 v1 = (m_TargetObj.transform.position - m_Nodes[0].transform.position).normalized;
			Vector3 v2 = m_Nodes[0].transform.forward.normalized;
			Vector3 v = Vector3.Cross(v1, v2);
			float f = Vector3.Dot(v1, v2);
			f = Mathf.Acos(f);
			if((180 - f * 57.29578f) <= (m_ControlData.threshold))
			{
				;
			}
			else
			{
				m_IsRight = v.y < 0;
			}

			DivaEyeControl.AngleData data;
			if (m_IsRight)
			{
				data = m_EyeControl.eyeUVData.xMin;
			}
			else
			{
				data = m_EyeControl.eyeUVData.xMax;
			}
			f = f * 57.29578f - Mathf.Abs(data.angle);
			for(int i = 0; i < 5; i++)
			{
				Vector3 a = m_Nodes[i].localEulerAngles;
				float resX, resY, resZ;
				resZ = a.z;
				float a_ = a.y;
				float b_ = a.x;
				if (f < 0)
				{
					resX = a.x;
					resY = a.y;
				}
				else
				{
					RotateData d = null;
					switch (i)
					{
						case 0:
							d = m_ControlData.nodeData.Head;
							break;
						case 1:
							d = m_ControlData.nodeData.Neck;
							break;
						case 2:
							d = m_ControlData.nodeData.Spine2;
							break;
						case 3:
							d = m_ControlData.nodeData.Spine1;
							break;
						case 4:
							d = m_ControlData.nodeData.Spine;
							break;
					}
					resX = b_;
					float d_;
					float e_;
					if(d.type == RotateType.Y)
					{
						float f2 = a.y % 360;
						if(-180 <= f2)
						{
							if(180 <= f2)
							{
								f2 -= 360;
							}
						}
						else
						{
							f2 += 360;
						}
						resY = Mathf.Clamp((m_IsRight ? f : -f) + f2, d.min, d.max);
						d_ = resY;
						e_ = a_;
					}
					else
					{
						resY = a_;
						d_ = 0;
						e_ = 0;
						if(d.type == RotateType.X)
						{
							float f3 = a.x % 360;
							if (-180 <= f3)
							{
								if (180 <= f3)
								{
									f3 -= 360;
								}
							}
							else
							{
								f3 += 360;
							}
							resX = Mathf.Clamp((m_IsRight ? -f : f) + f3, d.min, d.max);
							d_ = resX;
							e_ = b_;
						}
					}
					float f4 = e_ % 360;
					if (-180 <= f4)
					{
						if (180 <= f4)
						{
							f4 -= 360;
						}
					}
					else
					{
						f4 += 360;
					}
					f = f - Mathf.Abs(d_ - f4);
				}
				m_Rots[i] = Quaternion.Lerp(m_Rots[i], Quaternion.Euler(resX, resY, resZ), 0.05f);
				m_Nodes[i].localRotation = m_Rots[i];
			}
		}

		//// RVA: 0xEC98E8 Offset: 0xEC98E8 VA: 0xEC98E8
		private void UpdateRestore()
		{
			m_ElapsedTime += Time.deltaTime;
			float r = Mathf.Clamp01(m_ElapsedTime / ViewModeCameraManCs.TRANSITION_TIME);
			if(r >= 1)
			{
				Off();
				return;
			}
			for(int i = 0; i < m_Nodes.Length; i++)
			{
				m_Nodes[i].localRotation = Quaternion.Lerp(m_Rots[i], m_Nodes[i].localRotation, r);
			}
		}
	}
}
