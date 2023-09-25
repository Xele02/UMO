using System;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyBossCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Phase01 = 1,
			Phase02 = 2,
			Phase03 = 3,
			DeathMove = 4,
			Wait = 5,
		}

		[Serializable]
		public class PhaseData01
		{
			//[HeaderAttribute] // RVA: 0x662D40 Offset: 0x662D40 VA: 0x662D40
			public int changePhaseHp = 50; // 0x8
			//[HeaderAttribute] // RVA: 0x662D74 Offset: 0x662D74 VA: 0x662D74
			public ShootingEnemySummon summonData; // 0xC
			//[HeaderAttribute] // RVA: 0x662DA8 Offset: 0x662DA8 VA: 0x662DA8
			public int fireNum = 16; // 0x10
			//[HeaderAttribute] // RVA: 0x662DDC Offset: 0x662DDC VA: 0x662DDC
			public float[] intervalTime; // 0x14
		}

		[Serializable]
		public class PhaseData02
		{
			//[HeaderAttribute] // RVA: 0x662E10 Offset: 0x662E10 VA: 0x662E10
			public int changePhaseHp = 50; // 0x8
			//[HeaderAttribute] // RVA: 0x662E44 Offset: 0x662E44 VA: 0x662E44
			public ShootingEnemySummon summonData; // 0xC
			//[HeaderAttribute] // RVA: 0x662E78 Offset: 0x662E78 VA: 0x662E78
			public int fireNum = 16; // 0x10
			//[HeaderAttribute] // RVA: 0x662EAC Offset: 0x662EAC VA: 0x662EAC
			public float radiationInterval = 0.1f; // 0x14
			//[HeaderAttribute] // RVA: 0x662EE0 Offset: 0x662EE0 VA: 0x662EE0
			public int radiationCountMax = 5; // 0x18
			//[HeaderAttribute] // RVA: 0x662F14 Offset: 0x662F14 VA: 0x662F14
			public float[] intervalTime; // 0x1C
		}

		[Serializable]
		public class PhaseData03 // TypeDefIndex: 7850
		{
			//[HeaderAttribute] // RVA: 0x662F48 Offset: 0x662F48 VA: 0x662F48
			public int changePhaseHp = 50; // 0x8
			//[HeaderAttribute] // RVA: 0x662F7C Offset: 0x662F7C VA: 0x662F7C
			public ShootingEnemySummon summonData; // 0xC
			//[HeaderAttribute] // RVA: 0x662FB0 Offset: 0x662FB0 VA: 0x662FB0
			public float angleSpeed = 1; // 0x10
			//[HeaderAttribute] // RVA: 0x662FF0 Offset: 0x662FF0 VA: 0x662FF0
			public float moveRadius = 10; // 0x14
			//[HeaderAttribute] // RVA: 0x663030 Offset: 0x663030 VA: 0x663030
			public int fireNum = 16; // 0x18
			//[HeaderAttribute] // RVA: 0x663064 Offset: 0x663064 VA: 0x663064
			public float radiationInterval = 0.1f; // 0x1C
			//[HeaderAttribute] // RVA: 0x663098 Offset: 0x663098 VA: 0x663098
			public int radiationCountMax = 5; // 0x20
			//[HeaderAttribute] // RVA: 0x6630CC Offset: 0x6630CC VA: 0x6630CC
			public float[] intervalTime; // 0x24
		}

		private MovementState m_movementState; // 0x90
		private int m_phaseCount; // 0x94
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x662ACC Offset: 0x662ACC VA: 0x662ACC
		private PhaseData01 m_phase01; // 0x98
		//[HeaderAttribute] // RVA: 0x662B24 Offset: 0x662B24 VA: 0x662B24
		[SerializeField]
		private PhaseData02 m_phase02; // 0x9C
		//[HeaderAttribute] // RVA: 0x662B7C Offset: 0x662B7C VA: 0x662B7C
		[SerializeField]
		private PhaseData03 m_phase03; // 0xA0
		//[HeaderAttribute] // RVA: 0x662BD4 Offset: 0x662BD4 VA: 0x662BD4
		[SerializeField]
		private float m_waitPahseTimeMax; // 0xA4
		private float m_waitPahseTime; // 0xA8
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x662C38 Offset: 0x662C38 VA: 0x662C38
		public float m_entryLength = 150; // 0xAC
		//[HeaderAttribute] // RVA: 0x662C9C Offset: 0x662C9C VA: 0x662C9C
		public GameObject[] laserPos; // 0xB0
		//[HeaderAttribute] // RVA: 0x662CE4 Offset: 0x662CE4 VA: 0x662CE4
		[SerializeField]
		private float m_laserTimeMax = 0.1f; // 0xB4
		private float m_intervalTime; // 0xB8
		private float m_startY; // 0xBC
		private float m_moveAngle; // 0xC0
		private int m_phaseAttackCount; // 0xC4
		private bool m_isLaser; // 0xC8
		private float m_laserTime; // 0xCC
		private int m_laserCount; // 0xD0
		private int m_laserCount2; // 0xD4
		private bool m_isPhaseLaser; // 0xD8
		private bool m_isRadiation; // 0xD9
		private int m_radiationCount; // 0xDC
		private float m_radiationTime; // 0xE0

		//// RVA: 0x1CF7720 Offset: 0x1CF7720 VA: 0x1CF7720
		private void RadiationFire(int fireNum)
		{
			SoundManager.SePlay(2);
			BulletManager.MultipleShotBullet(0, transform, Player.transform.position, 360, fireNum);
		}

		//// RVA: 0x1CF7804 Offset: 0x1CF7804 VA: 0x1CF7804
		private void LaserFire(Vector3 move)
		{
			SoundManager.SePlay(3);
			BulletManager.ShotBullet(BulletId.EnemyLaser, laserPos[m_laserCount].transform, move);
		}

		//// RVA: 0x1CF78D4 Offset: 0x1CF78D4 VA: 0x1CF78D4
		private void LaserUpdate(float elapsedTime, Vector3 move)
		{
			if(m_isLaser)
			{
				m_laserTime += elapsedTime;
				if(m_laserTimeMax <= m_laserTime)
				{
					LaserFire(move);
					m_laserTime = 0;
					m_laserCount++;
					if(laserPos.Length <= m_laserCount)
					{
						m_laserCount = 0;
						m_laserCount2++;
						if (m_laserCount2 > 2)
							m_isLaser = false;
						if (m_laserCount2 > 3) // ?
							m_laserCount2 = 0;
					}
				}
			}
		}

		//// RVA: 0x1CF7984 Offset: 0x1CF7984 VA: 0x1CF7984
		private void RadiationUpdate(float elapsedTime, int fireNum, float interval, int countMax)
		{
			if(m_isRadiation)
			{
				m_radiationTime += elapsedTime;
				if(interval <= m_radiationTime)
				{
					RadiationFire(fireNum);
					m_radiationCount++;
					m_radiationTime = 0;
					if(countMax <= m_radiationCount)
					{
						m_isRadiation = false;
						m_radiationCount = 0;
					}
				}
			}
		}

		//// RVA: 0x1CF79F0 Offset: 0x1CF79F0 VA: 0x1CF79F0
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(transform.localPosition.x <= m_entryLength)
			{
				m_movementState = MovementState.Phase01;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
				m_phase01.summonData.ReferencePosition = transform.position;
				m_phase02.summonData.ReferencePosition = transform.position;
				m_phase03.summonData.ReferencePosition = transform.position;
			}
		}

		//// RVA: 0x1CF7C78 Offset: 0x1CF7C78 VA: 0x1CF7C78
		private void Phase01(float elapsedTime)
		{
			m_intervalTime += elapsedTime;
			if(m_intervalTime > m_phase01.intervalTime[m_phaseAttackCount])
			{
				m_intervalTime = 0;
				if(m_phaseAttackCount == 1)
				{
					RadiationFire(m_phase01.fireNum + 1);
					m_intervalTime = 0;
					m_phaseAttackCount++;
				}
				else if(m_phaseAttackCount == 0)
				{
					RadiationFire(m_phase01.fireNum);
					m_intervalTime = 0;
					m_phaseAttackCount++;
				}
				else
				{
					m_intervalTime = 0;
					m_phaseAttackCount = 0;
				}
			}
			m_phase01.summonData.OnUpdate(elapsedTime);
			if (m_phase01.changePhaseHp <= m_hp)
				return;
			ChangeWait();
		}

		//// RVA: 0x1CF7F24 Offset: 0x1CF7F24 VA: 0x1CF7F24
		private void Phase02(float elapsedTime)
		{
			m_phase02.summonData.OnUpdate(elapsedTime);
			m_intervalTime += elapsedTime;
			if(m_phase02.intervalTime[m_phaseAttackCount] < m_intervalTime)
			{
				if(m_phaseAttackCount == 1)
				{
					m_isLaser = true;
					m_phaseAttackCount = 2;
				}
				else if(m_phaseAttackCount == 0)
				{
					m_isRadiation = true;
					m_phaseAttackCount = 1;
				}
				else
				{
					m_phaseAttackCount = 0;
				}
				m_intervalTime = 0;
			}
			if(m_hp < m_phase02.changePhaseHp)
			{
				ChangeWait();
				m_startY = transform.position.y;
			}
			RadiationUpdate(elapsedTime, m_phase02.fireNum, m_phase02.radiationInterval, m_phase02.radiationCountMax);
			LaserUpdate(elapsedTime, Vector3.left);
		}

		//// RVA: 0x1CF8184 Offset: 0x1CF8184 VA: 0x1CF8184
		private void Phase03(float elapsedTime)
		{
			m_phase03.summonData.OnUpdate(elapsedTime);
			m_moveAngle += m_phase03.angleSpeed * 0.01744444f * elapsedTime;
			if(m_moveAngle >= 6.28f)
			{
				m_isPhaseLaser = false;
				m_moveAngle -= 6.28f;
			}
			transform.position += new Vector3(0, m_startY + m_phase03.moveRadius * Mathf.Sin(m_moveAngle), 0);
			m_intervalTime += elapsedTime;
			if(m_phase02.intervalTime[m_phaseAttackCount] < m_intervalTime)
			{
				if(m_phaseAttackCount == 0)
				{
					m_isRadiation = true;
					m_phaseAttackCount = 1;
				}
				else
				{
					m_phaseAttackCount = 0;
				}
				m_intervalTime = 0;
			}
			if(!m_isPhaseLaser)
			{
				if(Player.transform.localPosition.y < transform.localPosition.y + m_halfHeight * 2)
				{
					if(transform.localPosition.y + m_halfHeight * -2 <= Player.transform.localPosition.y)
					{
						m_isLaser = true;
						m_isPhaseLaser = true;
					}
				}
			}
			RadiationUpdate(elapsedTime, m_phase03.fireNum, m_phase03.radiationInterval, m_phase03.radiationCountMax);
			LaserUpdate(elapsedTime, Vector3.left);
		}

		//// RVA: 0x1CF7EC4 Offset: 0x1CF7EC4 VA: 0x1CF7EC4
		private void ChangeWait()
		{
			m_phaseAttackCount = 0;
			m_movementState = MovementState.Wait;
			CollisionManager.EraseCollision(m_collision);
			m_isLaser = false;
			m_radiationCount = 0;
			m_radiationTime = 0;
			m_laserCount = 0;
			m_laserCount2 = 0;
			m_isPhaseLaser = false;
			m_isRadiation = false;
			m_laserTime = 0;
		}

		//// RVA: 0x1CF85A0 Offset: 0x1CF85A0 VA: 0x1CF85A0
		private void Wait(float elapsedTime)
		{
			m_waitPahseTime += elapsedTime;
			if (m_waitPahseTime < m_waitPahseTimeMax)
				return;
			m_waitPahseTime = 0;
			m_phaseCount++;
			if (m_phaseCount - 1 == 0)
				m_movementState = MovementState.Phase02;
			if (m_phaseCount > 1)
				m_movementState = MovementState.Phase03;
			for(int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].SetKeyFrame(m_phaseCount);
				m_anime[i].damegeAnim.Stop(false);
				m_anime[i].damegeAnim.SyncAnime = m_anime[i].spriteAnim[m_animationType];
			}
			CollisionManager.AddCollision(m_collision);
		}

		//// RVA: 0x1CF8794 Offset: 0x1CF8794 VA: 0x1CF8794 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CF8848 Offset: 0x1CF8848 VA: 0x1CF8848 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			switch(m_movementState)
			{
				case MovementState.Entry:
					Entry(elapsedTime);
					return;
				case MovementState.Phase01:
					Phase01(elapsedTime);
					return;
				case MovementState.Phase02:
					Phase02(elapsedTime);
					return;
				case MovementState.Phase03:
					Phase03(elapsedTime);
					return;
				case MovementState.DeathMove:
					DeathMove(elapsedTime);
					return;
				case MovementState.Wait:
					Wait(elapsedTime);
					return;
				default:
					return;
			}
		}

		// RVA: 0x1CF88A0 Offset: 0x1CF88A0 VA: 0x1CF88A0 Slot: 27
		protected override void DestructMe()
		{
			ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.GameClear;
		}

		// RVA: 0x1CF8AA8 Offset: 0x1CF8AA8 VA: 0x1CF8AA8 Slot: 28
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CF8C30 Offset: 0x1CF8C30 VA: 0x1CF8C30 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_intervalTime = 0;
			m_movementState = MovementState.Entry;
			m_phase01.summonData.ParamReset();
			m_phase02.summonData.ParamReset();
			m_phase03.summonData.ParamReset();
			m_waitPahseTime = 0;
			m_phaseCount = 0;
			m_radiationCount = 0;
			m_radiationTime = 0;
			m_startY = 0;
			m_moveAngle = 0;
			m_phaseAttackCount = 0;
			m_isLaser = false;
			m_laserTime = 0;
			m_laserCount = 0;
			m_laserCount2 = 0;
			m_isPhaseLaser = false;
			m_isRadiation = false;
			for(int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].SetKeyFrame(0);
			}
			ShootingGameSceneState.MainSceneState = ShootingGameSceneState.GameMainState.BossEntry;
		}

		// RVA: 0x1CF8F5C Offset: 0x1CF8F5C VA: 0x1CF8F5C Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
			m_phase01.summonData.EnemyManager = EnemyManager;
			m_phase02.summonData.EnemyManager = EnemyManager;
			m_phase03.summonData.EnemyManager = EnemyManager;
		}

		// RVA: 0x1CF9260 Offset: 0x1CF9260 VA: 0x1CF9260 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CF9288 Offset: 0x1CF9288 VA: 0x1CF9288 Slot: 13
		public override void Initialize()
		{
			base.Initialize();
		}

		// RVA: 0x1CF92A8 Offset: 0x1CF92A8 VA: 0x1CF92A8 Slot: 14
		public override void Pause()
		{
			base.Pause();
		}

		// RVA: 0x1CF93F0 Offset: 0x1CF93F0 VA: 0x1CF93F0 Slot: 15
		public override void UnPause()
		{
			base.UnPause();
		}

		// RVA: 0x1CF9570 Offset: 0x1CF9570 VA: 0x1CF9570 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CF977C Offset: 0x1CF977C VA: 0x1CF977C Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
