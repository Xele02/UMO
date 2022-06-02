using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCutinSet : GachaDirectionAnimSetBase
	{
		[Serializable]
		public class RefData
		{
			[SerializeField]
			private List<GameObject> m_gameObjects;
		}

		[Serializable]
		public class TypeChangeData
		{
			[SerializeField]
			private Cubemap quartz_Cube_map;
		}

		[SerializeField]
		private GachaDirectionStone.RefData m_quartzRefData;
		[SerializeField]
		private List<GachaDirectionCutinSet.RefData> m_cutinRefData;
		[SerializeField]
		private List<Renderer> m_changeRenderers;
		[SerializeField]
		private TypeChangeData m_changeToBlue;
		[SerializeField]
		private TypeChangeData m_changeToRed;
		[SerializeField]
		private TypeChangeData m_changeToGold;
	}
}
