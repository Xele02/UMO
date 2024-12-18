using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class McrsCannonViewer : MonoBehaviour
	{
		[SerializeField]
		private MacrossCannon m_mcrsCannonPrefab;
		[SerializeField]
		private McrsCannonShakeObject m_mcrsCannonShakePrefab;
		[SerializeField]
		private ButtonBase m_hitCheck;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
