using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemySummon : MonoBehaviour
	{
		private enum SummonType
		{
			Limit = 0,
			NoLimit = 1,
		}

		[SerializeField]
		private SummonType m_summonType;
		[SerializeField]
		private GameObject m_parentObjeck;
		[SerializeField]
		private int m_summonRepeatCountMax;
		[SerializeField]
		private float[] m_summonTime;
		[SerializeField]
		private ShootingEnemySummonData[] m_summonDatas;
	}
}
