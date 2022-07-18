using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingAnyPos : MonoBehaviour
	{
		[Serializable]
		public class Info
		{
			public string[] m_target_node_path = new string[2] {
				"joint_root/hips/upleg_l/leg_l/foot_l",
				"joint_root/hips/upleg_r/leg_r/foot_r"
			}; // 0x8
			public GameObject m_node; // 0xC
			public bool m_axis_y = true; // 0x10
		}
		
		public class Data
		{
			public GameObjectFollowingAnyPos.Info m_info; // 0x8
			public List<Transform> m_target_node; // 0xC
			public Vector3 m_pos = Vector3.zero; // 0x10
		}


		[SerializeField]
		public GameObjectFollowingAnyPos.Info[] m_list_info = new Info[1] {
			new Info()
		}; // 0xC
		public List<GameObjectFollowingAnyPos.Data> m_list_data = new List<Data>(); // 0x10
		private bool m_initialize; // 0x14

		// RVA: 0xE9B0F4 Offset: 0xE9B0F4 VA: 0xE9B0F4
		public void Initialize(Transform a_obj)
		{
			m_list_data = new List<Data>();
			for(int i = 0; i < m_list_info.Length; i++)
			{
				Data data = new Data();
				data.m_info = m_list_info[i];
				data.m_target_node = new List<Transform>();
				for(int j = 0; j < m_list_info[i].m_target_node_path.Length; j++)
				{
					if(!string.IsNullOrEmpty(m_list_info[i].m_target_node_path[j]))
					{
						Transform t = a_obj.transform.Find(m_list_info[i].m_target_node_path[j]);
						if(t != null)
						{
							data.m_target_node.Add(t);
						}
					}
				}
				if(data.m_target_node.Count > 0)
				{
					m_list_data.Add(data);
				}
			}
		}

		// RVA: 0xE9B538 Offset: 0xE9B538 VA: 0xE9B538
		public void Start()
		{
			LateUpdate();
		}

		// RVA: 0xE9B82C Offset: 0xE9B82C VA: 0xE9B82C
		public void Update()
		{
			for(int i = 0; i < m_list_data.Count; i++)
			{
				m_list_data[i].m_info.m_node.transform.position = m_list_data[i].m_pos;
			}
		}

		// RVA: 0xE9B53C Offset: 0xE9B53C VA: 0xE9B53C
		public void LateUpdate()
		{
			for(int i = 0; i < m_list_data.Count; i++)
			{
				Vector3 pos = Vector3.zero;
				for(int j = 0; j < m_list_data[i].m_target_node.Count; j++)
				{
					pos += m_list_data[i].m_target_node[j].transform.position;
				}
				pos = pos / m_list_data[i].m_target_node.Count;
				if(!m_list_data[i].m_info.m_axis_y)
					pos.y = 0;
				m_list_data[i].m_pos = pos;
			}
		}
	}
}
