using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public struct TMP_GlyphAdjustmentRecord
	{
		public TMP_GlyphAdjustmentRecord(uint glyphIndex, TMP_GlyphValueRecord glyphValueRecord) : this()
		{
		}

		[SerializeField]
		private uint m_GlyphIndex;
		[SerializeField]
		private TMP_GlyphValueRecord m_GlyphValueRecord;
	}
}
