using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class MotionRefBase : MonoBehaviour
	{
		[Serializable]
		public class BaseData
		{
			public BaseData(Animator animator)
			{
			}

			[SerializeField]
			private Animator m_animator;
		}

	}
}
