using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public struct TMP_GlyphValueRecord
	{
		public TMP_GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance) : this()
		{
		}

		[SerializeField]
		private float m_XPlacement;
		[SerializeField]
		private float m_YPlacement;
		[SerializeField]
		private float m_XAdvance;
		[SerializeField]
		private float m_YAdvance;
	}
}
