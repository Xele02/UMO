using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainScore : MonoBehaviour
	{
		[SerializeField]
		private UGUINumController m_number;
		[SerializeField]
		private InOutAnime m_inOutCount;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
