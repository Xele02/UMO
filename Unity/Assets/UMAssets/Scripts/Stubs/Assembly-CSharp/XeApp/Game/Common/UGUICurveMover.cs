using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	[Serializable]
	public class UGUICurveMover
	{
		[Serializable]
		public struct CurveInfo
		{
			public AnimationCurve m_curve;
			public float m_animTime;
		}

	}
}
