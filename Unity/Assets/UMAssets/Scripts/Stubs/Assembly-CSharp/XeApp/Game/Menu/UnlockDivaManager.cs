using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class UnlockDivaManager : MonoBehaviour
	{
		[SerializeField]
		private Vector3 m_camera_pos;
		[SerializeField]
		private Vector3 m_camera_default_target_pos;
		[SerializeField]
		private Vector3 m_camera_final_target_pos;
		[SerializeField]
		private float DIVA_MOVE_TIME;
		[SerializeField]
		private List<float> m_diva_target_pos_y;
	}
}
