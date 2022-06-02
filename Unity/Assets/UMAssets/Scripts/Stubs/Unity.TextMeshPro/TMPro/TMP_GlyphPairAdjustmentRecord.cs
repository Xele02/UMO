using System;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	public class TMP_GlyphPairAdjustmentRecord
	{
		public TMP_GlyphPairAdjustmentRecord(TMP_GlyphAdjustmentRecord firstAdjustmentRecord, TMP_GlyphAdjustmentRecord secondAdjustmentRecord)
		{
		}

		[SerializeField]
		private TMP_GlyphAdjustmentRecord m_FirstAdjustmentRecord;
		[SerializeField]
		private TMP_GlyphAdjustmentRecord m_SecondAdjustmentRecord;
		[SerializeField]
		private FontFeatureLookupFlags m_FeatureLookupFlags;
	}
}
