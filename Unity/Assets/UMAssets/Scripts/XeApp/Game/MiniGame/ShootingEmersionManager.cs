using System.Collections;
using System.Collections.Generic;
using XeApp.Core;

namespace XeApp.Game.MiniGame
{
	public class ShootingEmersionManager : ShootingTask
	{
		public class EmersionData
		{
			public List<ShootingStageData.SettingEnemyData> enemyData; // 0x8
			public List<bool> isEnemyEemersion = new List<bool>(); // 0xC
			public List<ShootingStageData.SettingItemData> itemData; // 0x10
			public List<bool> isItemEemersion = new List<bool>(); // 0x14
		}

		private EmersionData m_emersionData = new EmersionData(); // 0x10
		private float m_elapsedTime; // 0x14
		private bool isReady; // 0x18

		public ShootingEnemyManager EnemyManager { get; set; } // 0x1C
		public ShootingItemManager ItemManager { get; set; } // 0x20
		public int StageNum { get; set; } // 0x24
		public bool IsReady { get { return isReady; } } //0x1CEEDDC

		//[IteratorStateMachineAttribute] // RVA: 0x6B18A0 Offset: 0x6B18A0 VA: 0x6B18A0
		//// RVA: 0x1CF6624 Offset: 0x1CF6624 VA: 0x1CF6624
		public IEnumerator SetStageData()
		{
			string bundleName; // 0x14
			AssetBundleLoadAssetOperation op; // 0x18

			//0x1CF6E54
			bundleName = "ap/001.xab";
			op = AssetBundleManager.LoadAssetAsync(bundleName, string.Format("StageData{0:D3}", StageNum), typeof(ShootingStageData));
			yield return op;
			ShootingStageData data = op.GetAsset<ShootingStageData>();
			m_emersionData.enemyData = data.m_settingEnemyDatas;
			m_emersionData.isEnemyEemersion.Clear();
			for(int i = 0; i < m_emersionData.enemyData.Count; i++)
			{
				m_emersionData.isEnemyEemersion.Add(false);
			}
			m_emersionData.itemData = data.m_settingItemDatas;
			m_emersionData.isItemEemersion.Clear();
			for(int i = 0; i < m_emersionData.itemData.Count; i++)
			{
				m_emersionData.isItemEemersion.Add(false);
			}
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			isReady = true;
		}

		// RVA: 0x1CF66D0 Offset: 0x1CF66D0 VA: 0x1CF66D0 Slot: 11
		public override void OnAwake()
		{
			OnActive();
		}

		//// RVA: 0x1CF66D8 Offset: 0x1CF66D8 VA: 0x1CF66D8 Slot: 12
		public override void OnStart()
		{
			return;
		}

		//// RVA: 0x1CF66DC Offset: 0x1CF66DC VA: 0x1CF66DC Slot: 13
		public override void Initialize()
		{
			OnActive();
			isReady = false;
			m_elapsedTime = 0;
			this.StartCoroutineWatched(SetStageData());
		}

		//// RVA: 0x1CF6718 Offset: 0x1CF6718 VA: 0x1CF6718 Slot: 14
		public override void Pause()
		{
			return;
		}

		//// RVA: 0x1CF671C Offset: 0x1CF671C VA: 0x1CF671C Slot: 15
		public override void UnPause()
		{
			return;
		}

		// RVA: 0x1CF6720 Offset: 0x1CF6720 VA: 0x1CF6720 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			m_elapsedTime += elapsedTime;
			for(int i = 0; i < m_emersionData.enemyData.Count; i++)
			{
				if(!m_emersionData.isEnemyEemersion[i])
				{
					if(m_emersionData.enemyData[i].emersionTime <= m_elapsedTime)
					{
						EnemyManager.SetEnemy(m_emersionData.enemyData[i]);
						m_emersionData.isEnemyEemersion[i] = true;
					}
				}
			}
			for(int i = 0; i < m_emersionData.itemData.Count; i++)
			{
				if(!m_emersionData.isItemEemersion[i])
				{
					if(m_emersionData.itemData[i].emersionTime <= m_elapsedTime)
					{
						ItemManager.SetItem(m_emersionData.itemData[i].type, m_emersionData.itemData[i].pos);
						m_emersionData.isItemEemersion[i] = true;
					}
				}
			}
		}

		// RVA: 0x1CF6D30 Offset: 0x1CF6D30 VA: 0x1CF6D30 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
