using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class GachaDirectionOrbTable : ScriptableObject
	{
		[Serializable]
		public class RegionData
		{
			[SerializeField]
			private List<int> m_weights;
		}

		[SerializeField]
		private RegionData m_missRegionData;
		[SerializeField]
		private RegionData m_rare4RegionData;
		[SerializeField]
		private RegionData m_rare5RegionData;
		[SerializeField]
		private List<int> m_expantionRatios;
	}
}
