using UnityEngine;
using System;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class StripeEffect : MonoBehaviour
	{
		[Serializable]
		private class PatternInfo
		{
			[SerializeField]
			public StripeEffectModifier m_modifier;
			[SerializeField]
			public float m_delayTime;
		}

		[SerializeField]
		private List<Color> m_baseColors;
		[SerializeField]
		private float m_bandWidth;
		[SerializeField]
		private UGUICurveMover.CurveInfo m_baseAnimCurveInfo;
		[SerializeField]
		private int m_patternNum;
		[SerializeField]
		private List<StripeEffect.PatternInfo> m_patternInfos;
	}
}
