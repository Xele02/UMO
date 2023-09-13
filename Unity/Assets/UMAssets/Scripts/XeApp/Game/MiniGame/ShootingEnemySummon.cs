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
		//[HeaderAttribute] // RVA: 0x663A04 Offset: 0x663A04 VA: 0x663A04
		private SummonType m_summonType; // 0xC
		//[HeaderAttribute] // RVA: 0x663A58 Offset: 0x663A58 VA: 0x663A58
		[SerializeField]
		private GameObject m_parentObjeck; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663AB4 Offset: 0x663AB4 VA: 0x663AB4
		private int m_summonRepeatCountMax = 5; // 0x14
		//[HeaderAttribute] // RVA: 0x663B10 Offset: 0x663B10 VA: 0x663B10
		[SerializeField]
		private float[] m_summonTime; // 0x18
		//[HeaderAttribute] // RVA: 0x663B64 Offset: 0x663B64 VA: 0x663B64
		[SerializeField]
		private ShootingEnemySummonData[] m_summonDatas; // 0x1C
		private bool m_isSummon; // 0x20
		private int m_summonCount; // 0x24
		private int m_summonRepeatCount; // 0x28
		private float m_summonElapsedTime; // 0x2C
		private Vector3 m_summonOriginPos; // 0x30

		public Vector3 ReferencePosition { get; set; } // 0x3C
		public ShootingEnemyManager EnemyManager { get; set; } // 0x48

		// RVA: 0x1CF8F40 Offset: 0x1CF8F40 VA: 0x1CF8F40
		public void ParamReset()
		{
			m_isSummon = true;
			m_summonCount = 0;
			m_summonRepeatCount = 0;
			m_summonElapsedTime = 0;
		}

		//// RVA: 0x1CFCF6C Offset: 0x1CFCF6C VA: 0x1CFCF6C
		public void EnemySummon(int summonCount)
		{
			for(int i = 0; i < m_summonDatas.Length; i++)
			{
				if(m_summonDatas[i].enemyData[summonCount].enemytype != ShootingStageData.StageEnemyType.None)
				{
					ShootingStageData.SettingEnemyData d = new ShootingStageData.SettingEnemyData();
					d.pos = m_summonDatas[i].transform.position + new Vector3(0, ReferencePosition.y - m_parentObjeck.transform.position.y, 0);
					d.type = m_summonDatas[i].enemyData[summonCount].enemytype;
					d.itemType = m_summonDatas[i].enemyData[summonCount].dropItemType;
					EnemyManager.SetEnemy(d);
				}
			}
		}

		// RVA: 0x1CF7DD8 Offset: 0x1CF7DD8 VA: 0x1CF7DD8
		public void OnUpdate(float elapsedTime)
		{
			if(m_isSummon)
			{
				m_summonElapsedTime += elapsedTime;
				if(m_summonTime[m_summonCount] <= m_summonElapsedTime)
				{
					m_summonElapsedTime = 0;
					EnemySummon(m_summonCount);
					m_summonCount++;
					if(m_summonDatas.Length <= m_summonCount)
					{
						m_summonCount = 0;
						if(m_summonType == SummonType.Limit)
						{
							m_summonRepeatCount++;
							if(m_summonRepeatCountMax <= m_summonRepeatCount)
							{
								m_isSummon = false;
							}
						}
					}
				}
			}
		}
	}
}
