using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossPop : MonoBehaviour
	{
		[SerializeField]
		private RaidBossPopLayout m_bossPopLayout;
		[SerializeField]
		private RaidBossPopLayout m_spBossPopLayout;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
