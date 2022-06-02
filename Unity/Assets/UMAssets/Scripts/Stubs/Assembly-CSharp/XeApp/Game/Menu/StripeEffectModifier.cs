using UnityEngine;
using System;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class StripeEffectModifier : MonoBehaviour
	{
		[Serializable]
		public class BandParam
		{
			[SerializeField]
			public int m_colorId;
			[SerializeField]
			public float m_offsetLength;
		}

		[SerializeField]
		public List<Color> m_baseColors;
		[SerializeField]
		public float m_bandWidth;
		[SerializeField]
		public float m_crossOffset;
		[SerializeField]
		public float m_bandAngle;
		[SerializeField]
		public List<StripeEffectModifier.BandParam> m_bandParams;
		[SerializeField]
		public UGUICurveMover.CurveInfo m_enterAnimCurveInfo;
		[SerializeField]
		public UGUICurveMover.CurveInfo m_leaveAnimCurveInfo;
	}
}
