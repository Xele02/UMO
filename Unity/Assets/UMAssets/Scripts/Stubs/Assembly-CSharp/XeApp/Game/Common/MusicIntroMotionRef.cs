using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class MusicIntroMotionRef : MotionRefBase
	{
		[Serializable]
		public class AnimationData : MotionRefBase.BaseData
		{
			public AnimationData(Animator animator, bool hasIdle, bool hasTakeoff) : base(default(Animator))
			{
			}

			[SerializeField]
			private bool m_hasIdle;
			[SerializeField]
			private bool m_hasTakeoff;
		}

		[SerializeField]
		private Transform m_cameraRoot;
		[SerializeField]
		private Transform m_enviromentRoot;
		[SerializeField]
		private Transform m_valkyrieRoot;
		[SerializeField]
		private List<MusicIntroMotionRef.AnimationData> m_animationDatas;
	}
}
