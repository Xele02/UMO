using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class CostumeCameraParameter : ScriptableObject
	{
		public float m_borderline_eff_param;
		public float m_final_camera_move_sec;
		public Vector3 m_final_camera_pos;
		public Vector3 m_final_camera_lookat;
		public List<Vector3> m_final_camera_offset;
		public List<float> m_camera_adjust_scale;
	}
}
