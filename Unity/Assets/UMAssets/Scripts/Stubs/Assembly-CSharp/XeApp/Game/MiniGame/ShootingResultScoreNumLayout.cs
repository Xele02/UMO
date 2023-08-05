using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultScoreNumLayout : MonoBehaviour
	{
		[SerializeField]
		private UGUINumController m_number;
		[SerializeField]
		private InOutAnime m_inOutAnim;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
