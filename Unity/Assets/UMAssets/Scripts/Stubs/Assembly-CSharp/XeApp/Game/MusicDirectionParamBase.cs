using UnityEngine;
using System;

namespace XeApp.Game
{
	public class MusicDirectionParamBase : ScriptableObject
	{
		[Serializable]
		public class MikeReplaceTargetData
		{
			public int divaId;
			public int costumeModelId;
		}

		[Serializable]
		public class SpecialDirectionData
		{
			public int divaId;
			public int costumeModelId;
			public int valkyrieId;
			public int pilotId;
			public int positionId;
			public int directionGroupId;
		}

		[SerializeField]
		protected float m_startOffsetSec;
		[SerializeField]
		protected bool m_psylliumOverride;
		[SerializeField]
		protected Color m_psylliumColor;
		[SerializeField]
		protected float m_mikeStandOffsetRate;
	}
}
