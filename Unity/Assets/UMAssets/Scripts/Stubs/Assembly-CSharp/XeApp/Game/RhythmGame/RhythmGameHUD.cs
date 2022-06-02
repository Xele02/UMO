using UnityEngine;
using XeApp.Game.RhythmGame.UI;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameHUD : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_touchParent;
		[SerializeField]
		private GameObject m_touchPrefab;
		[SerializeField]
		private TouchArea[] m_touchAreas;
		[SerializeField]
		private GameObject m_userStateObject;
		[SerializeField]
		private GameObject m_targetSightPrefab;
		[SerializeField]
		private BattleEvaluateObject m_battleEvaluatePrefab;
		[SerializeField]
		private GameObject[] anchorRoots;
		[SerializeField]
		private GameObject leftTopPrefab;
		[SerializeField]
		private GameObject rightTopPrefab;
		[SerializeField]
		private GameObject centerPrefab;
		[SerializeField]
		private GameObject lowEnergyPrefab;
		[SerializeField]
		private GameObject bottomPrefab;
		[SerializeField]
		private GameObject valkyrieTopPrefab;
		[SerializeField]
		private GameObject valkyrieTop2dPrefab;
		[SerializeField]
		private GameObject valkyrieCenterPrefab;
		[SerializeField]
		private GameObject valkyrieBottomPrefab;
		[SerializeField]
		private GameObject valkyrieBottomWidePrefab;
		[SerializeField]
		private GameObject valkyrieTimer;
		[SerializeField]
		private GameObject divaBottomPrefab;
		[SerializeField]
		private GameObject divaBottomWidePrefab;
		[SerializeField]
		private GameObject divaToptPrefab;
		[SerializeField]
		private GameObject divaModeBeltPrefab;
		[SerializeField]
		private SkillCutin[] skillCutin;
		[SerializeField]
		private GameObject battleResultPrefab;
	}
}
