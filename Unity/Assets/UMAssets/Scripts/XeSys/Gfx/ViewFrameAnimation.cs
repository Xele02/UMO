using System;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class ViewFrameAnimation
	{
		[SerializeField]
		private ViewFrameAnimationData data;
		[SerializeField]
		private float m_FrameSec;
		[SerializeField]
		private float m_BaseX;
		[SerializeField]
		private float m_BaseY;
	}
}
