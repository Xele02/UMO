using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingAnyPos : MonoBehaviour
	{
		[Serializable]
		public class Info
		{
			public string[] m_target_node_path;
			public GameObject m_node;
			public bool m_axis_y;
		}

		[SerializeField]
		public Info[] m_list_info;
	}
}
