using UnityEngine;
using System;

namespace XeApp.Game.RhythmGame
{
	public class EffectBundleControllerSimple : MonoBehaviour
	{
		[Serializable]
		public class Param
		{
			public string groupName;
			public GameObject[] gameObject;
		}

		[SerializeField]
		public Param[] m_params;
		[SerializeField]
		public AnimationCurve m_curve_eff;
		[SerializeField]
		public AnimationCurve m_curve_fnt;
		[SerializeField]
		public AnimationCurve m_curve_fnt_pos;
	}
}
