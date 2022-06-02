using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class BoneSpringSuppressParam : ScriptableObject
	{
		[Serializable]
		public class TargetData
		{
			[SerializeField]
			private string m_pointPath;
			[SerializeField]
			private float m_influenceRate;
		}

		[SerializeField]
		private List<BoneSpringSuppressParam.TargetData> m_targets;
	}
}
