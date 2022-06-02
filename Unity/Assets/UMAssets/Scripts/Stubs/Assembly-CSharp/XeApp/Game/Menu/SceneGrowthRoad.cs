using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthRoad : SceneGrowthPanelBase
	{
		public enum Type
		{
			Normal = 0,
			Down = 1,
			Up = 2,
		}

		[SerializeField]
		private Type m_type;
		[SerializeField]
		private RawImageEx[] m_replaceUvImages;
		[SerializeField]
		private string m_rootExId;
		[SerializeField]
		private string m_addEffectExId;
	}
}
