using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieModeMotionRef : MotionRefBase
	{
		[Serializable]
		public class AnimationData : MotionRefBase.BaseData
		{
			public AnimationData(Animator animator, bool hasEnter, bool hasMain, bool hasLeave, bool hasFailed) : base(default(Animator))
			{
			}

			[SerializeField]
			private bool m_hasEnter;
			[SerializeField]
			private bool m_hasMain;
			[SerializeField]
			private bool m_hasLeave;
			[SerializeField]
			private bool m_hasFailed;
		}

		[SerializeField]
		private Transform m_cameraRoot;
		[SerializeField]
		private Transform m_lockOnTarget;
		[SerializeField]
		private Transform m_shootToTarget;
		[SerializeField]
		private List<ValkyrieModeMotionRef.AnimationData> m_animationDatas;
	}
}
