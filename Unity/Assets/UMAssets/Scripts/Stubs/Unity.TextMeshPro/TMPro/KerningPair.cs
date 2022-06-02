using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class KerningPair
	{
		[SerializeField]
		private uint m_FirstGlyph;
		[SerializeField]
		private GlyphValueRecord_Legacy m_FirstGlyphAdjustments;
		[SerializeField]
		private uint m_SecondGlyph;
		[SerializeField]
		private GlyphValueRecord_Legacy m_SecondGlyphAdjustments;
		public float xOffset;
		[SerializeField]
		private bool m_IgnoreSpacingAdjustments;
	}
}
