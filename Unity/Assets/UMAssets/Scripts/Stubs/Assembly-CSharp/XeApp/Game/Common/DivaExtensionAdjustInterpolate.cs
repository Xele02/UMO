using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionAdjustInterpolate : MonoBehaviour
	{
		public float[] m_AdjustPosParam;
		public float[] m_AdjustScaleParam;
		[SerializeField]
		private List<Transform> m_AdjustPosTarget;
		[SerializeField]
		private List<Transform> m_AdjustScaleTarget;
		[SerializeField]
		private Transform m_change_param_obj;
	}
}
