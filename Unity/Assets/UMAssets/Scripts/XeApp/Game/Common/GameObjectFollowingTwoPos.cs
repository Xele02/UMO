using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingTwoPos : MonoBehaviour
	{
		[Serializable]
		public class Info
		{
			public string m_target_node_path1; // 0x8
			public string m_target_node_path2; // 0xC
			public GameObject m_node; // 0x10
		}

		public class Data
		{
			public GameObjectFollowingTwoPos.Info m_info; // 0x8
			public Transform m_target_node1; // 0xC
			public Transform m_target_node2; // 0x10
			public Vector3 m_pos = Vector3.zero; // 0x14
		}

		[SerializeField]
		public GameObjectFollowingTwoPos.Info[] m_list_info = new Info[1] {
				new Info() { m_target_node_path1="joint_root/hips/upleg_l/leg_l/foot_l", m_target_node_path2 = "joint_root/hips/upleg_r/leg_r/foot_r", m_node = null } }; // 0xC
		public List<GameObjectFollowingTwoPos.Data> m_list_data; // 0x10

		// RVA: 0xE9BF98 Offset: 0xE9BF98 VA: 0xE9BF98
		public void Initialize(Transform a_obj)
		{ !!!;
			m_list_data = new List<Data>();
		}

		// RVA: 0xE9C264 Offset: 0xE9C264 VA: 0xE9C264
		public void Start() { !!!}

		// RVA: 0xE9C5B0 Offset: 0xE9C5B0 VA: 0xE9C5B0
		public void Update() {!!! }

		// RVA: 0xE9C268 Offset: 0xE9C268 VA: 0xE9C268
		public void LateUpdate() {!!! }
	}
}
