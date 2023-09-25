using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyLaserCharacte : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			ReadyFire = 1,
			SetFireDir = 2,
			Fire = 3,
			Escape = 4,
			DeeathMove = 5,
		}

		private MovementState m_movementState; // 0x90
		//[HeaderAttribute] // RVA: 0x663100 Offset: 0x663100 VA: 0x663100
		[SerializeField]
		private float m_readyLength = 200; // 0x94
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663148 Offset: 0x663148 VA: 0x663148
		private int m_fireCountMax; // 0x98
		//[HeaderAttribute] // RVA: 0x663190 Offset: 0x663190 VA: 0x663190
		[SerializeField]
		private float m_fireTimeMax = 1; // 0x9C
		//[HeaderAttribute] // RVA: 0x6631D8 Offset: 0x6631D8 VA: 0x6631D8
		[SerializeField]
		private float m_setFireDirTimeMax = 1; // 0xA0
		private int m_fireCount; // 0xA4
		private float m_fireElapsedTime; // 0xA8
		private float m_setFireDirElapsedTime; // 0xAC
		private Vector3 m_fireDir; // 0xB0

		// RVA: 0x1CFA5D4 Offset: 0x1CFA5D4 VA: 0x1CFA5D4
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.ReadyFire;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFA724 Offset: 0x1CFA724 VA: 0x1CFA724
		private void ReadyFire(float elapsedTime)
		{
			Vector3 dir = Player.transform.position - transform.position;
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, dir, m_speed);
			if (Vector3.Distance(transform.position, Player.transform.position) <= m_readyLength)
				m_movementState = MovementState.SetFireDir;
		}

		// RVA: 0x1CFA9D0 Offset: 0x1CFA9D0 VA: 0x1CFA9D0
		private void SetFireDir(float elapsedTime)
		{
			m_setFireDirElapsedTime += elapsedTime;
			if(m_setFireDirTimeMax < m_setFireDirElapsedTime)
			{
				Vector3 dir = Player.transform.position - transform.position;
				dir.Normalize();
				m_fireDir = dir;
				m_movementState = MovementState.Fire;
				m_fireElapsedTime = m_fireTimeMax;
			}
		}

		// RVA: 0x1CFAB58 Offset: 0x1CFAB58 VA: 0x1CFAB58
		private void Fire(float elapsedTime)
		{
			m_fireElapsedTime += elapsedTime;
			if(m_fireTimeMax < m_fireElapsedTime)
			{
				m_fireElapsedTime = 0;
				SoundManager.SePlay(3);
				BulletManager.ShotBullet(BulletId.EnemyLaser, transform, m_fireDir);
				m_fireCount++;
				if (m_fireCountMax <= m_fireCount)
					m_movementState = MovementState.Escape;
			}
		}

		// RVA: 0x1CFAC20 Offset: 0x1CFAC20 VA: 0x1CFAC20
		private void Escape(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
		}

		// RVA: 0x1CFACE4 Offset: 0x1CFACE4 VA: 0x1CFACE4 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeeathMove;
		}

		// RVA: 0x1CFAD00 Offset: 0x1CFAD00 VA: 0x1CFAD00 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			switch(m_movementState)
			{
				case MovementState.Entry:
					Entry(elapsedTime);
					return;
				case MovementState.ReadyFire:
					ReadyFire(elapsedTime);
					return;
				case MovementState.SetFireDir:
					SetFireDir(elapsedTime);
					return;
				case MovementState.Fire:
					Fire(elapsedTime);
					return;
				case MovementState.Escape:
					Escape(elapsedTime);
					return;
				case MovementState.DeeathMove:
					DeathMove(elapsedTime);
					return;
				default:
					return;
			}
		}

		// RVA: 0x1CFAD58 Offset: 0x1CFAD58 VA: 0x1CFAD58 Slot: 28
		protected override void HitCallBack(ShootingCollision collision)
		{
			if (collision.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFAD90 Offset: 0x1CFAD90 VA: 0x1CFAD90 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_movementState = MovementState.Entry;
			m_fireCount = 0;
			m_fireElapsedTime = 0;
			m_setFireDirElapsedTime = 0;
		}

		// RVA: 0x1CFADB8 Offset: 0x1CFADB8 VA: 0x1CFADB8 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFADBC Offset: 0x1CFADBC VA: 0x1CFADBC Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFADD0 Offset: 0x1CFADD0 VA: 0x1CFADD0 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFADE0 Offset: 0x1CFADE0 VA: 0x1CFADE0 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFADE4 Offset: 0x1CFADE4 VA: 0x1CFADE4 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
