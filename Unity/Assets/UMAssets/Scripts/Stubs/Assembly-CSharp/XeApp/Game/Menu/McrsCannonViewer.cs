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
	}
}
