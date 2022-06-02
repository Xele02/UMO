using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjust3 : MonoBehaviour
	{
		public float[] m_AdjustPosParam;
		public float[] m_AdjustScaleParam;
		[SerializeField]
		private List<Transform> m_AdjustPosTarget;
		[SerializeField]
		private List<Transform> m_AdjustScaleTarget;
		[SerializeField]
		private float m_rate_x;
		[SerializeField]
		private float m_rate_y;
		[SerializeField]
		private float m_rate_z;
		[SerializeField]
		private int m_position_id_01;
		[SerializeField]
		private int m_position_id_02;
		[SerializeField]
		private float m_position_id_rate;
	}
}
