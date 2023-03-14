using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultHighScoreNumLayout : MonoBehaviour
	{
		[SerializeField]
		private UGUINumController m_number;
		[SerializeField]
		private InOutAnime m_inOutAnim;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
