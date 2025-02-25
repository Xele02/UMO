using UnityEngine;
using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class StripeEffectModifier : MonoBehaviour, IMeshModifier
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
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}

		public void ModifyMesh(Mesh mesh)
		{
			throw new NotImplementedException();
		}

		public void ModifyMesh(VertexHelper verts)
		{
			throw new NotImplementedException();
		}
	}
}
