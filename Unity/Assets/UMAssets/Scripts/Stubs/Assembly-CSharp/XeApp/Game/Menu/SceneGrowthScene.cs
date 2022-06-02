using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneGrowthScene : TransitionRoot
	{
		[SerializeField]
		private SceneGrowth3dEffect[] m_3dEffectPrefab;
		[SerializeField]
		private GameObject[] m_panelLoopEffectPrefab;
	}
}
