using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneGrowthInfinityPanel : SceneGrowthPanelBase, ISceneGrowthPanel
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private NumberBase m_stockNumber;
		[SerializeField]
		private NumberBase m_valueNumber;
		[SerializeField]
		private ActionButton m_button;
	}
}
