using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class ViewAnimation
	{
		public enum LoopType
		{
			none = 0,
			loop = 1,
			round = 2,
		}

		public enum InterpolationType
		{
			linear = 0,
			acc = 1,
			dec = 2,
		}

		[SerializeField]
		private ViewTransformData m_BaseTransform;
		[SerializeField]
		private ViewTransformData m_TargetTransform;
		[SerializeField]
		private float m_timeScale;
		[SerializeField]
		private float m_AnimTime;
		[SerializeField]
		private float m_AnimCount;
		[SerializeField]
		private bool m_IsAnimEnd;
		[SerializeField]
		private LoopType m_LoopType;
		[SerializeField]
		private InterpolationType m_InterType;
		public bool m_IsPosAnim;
		public bool m_IsSizeAnim;
		public bool m_IsScaleAnim;
		public bool m_IsRotAnim;
		public bool m_IsColAnim;
		public bool m_IsCenterAnim;
	}
}
