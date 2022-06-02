using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingTwoPos : MonoBehaviour
	{
		[Serializable]
		public class Info
		{
			public string m_target_node_path1;
			public string m_target_node_path2;
			public GameObject m_node;
		}

		[SerializeField]
		public Info[] m_list_info;
	}
}
