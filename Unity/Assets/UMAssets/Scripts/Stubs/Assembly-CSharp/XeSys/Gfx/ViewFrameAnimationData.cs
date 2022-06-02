using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	internal class ViewFrameAnimationData
	{
		[SerializeField]
		public FrameData[] m_FrameDataList;
		[SerializeField]
		public LabelData[] m_LabelList;
		[SerializeField]
		private TimeMap m_AnimTimeMap;
		[SerializeField]
		private uint m_AnimFlag;
		[SerializeField]
		private string m_Id;
		[SerializeField]
		private int m_FrameNum;
	}
}
