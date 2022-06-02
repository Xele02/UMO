using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GameObjectFollowingPosition : MonoBehaviour
	{
		[SerializeField]
		private List<Transform> m_target_trans;
		[SerializeField]
		private bool m_freeze_x;
		[SerializeField]
		private bool m_freeze_y;
		[SerializeField]
		private bool m_freeze_z;
	}
}
