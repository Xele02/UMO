using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageExtensionWindCtrl : StageExtensionObjectComponentBase
	{
		[SerializeField]
		public float m_power;
		[SerializeField]
		public Vector3 m_wind_dir;
		[SerializeField]
		public Vector2 m_rand_x;
		[SerializeField]
		public Vector2 m_rand_y;
		[SerializeField]
		public float m_sub_power;
		[SerializeField]
		public Vector2 m_sub_rand_x;
		[SerializeField]
		public Vector2 m_sub_rand_y;
		[SerializeField]
		public float m_interval;
		[SerializeField]
		public float m_speed;
		public bool m_pause;
	}
}
