using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightPlayerFireCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Fire = 1,
			Escape = 2,
			DeathMove = 3,
		}

		private MovementState m_movementState; // 0x90
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66333C Offset: 0x66333C VA: 0x66333C
		private int m_fireCountMax; // 0x94
		private int m_fireCount; // 0x98
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663384 Offset: 0x663384 VA: 0x663384
		private float m_fireTimeMax = 1; // 0x9C
		private float m_fireElapsedTime; // 0xA0

		// RVA: 0x1CFC990 Offset: 0x1CFC990 VA: 0x1CFC990
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.Fire;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFCAE0 Offset: 0x1CFCAE0 VA: 0x1CFCAE0
		private void Fire(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			m_fireElapsedTime += elapsedTime;
			if(m_fireTimeMax < m_fireElapsedTime)
			{
				m_fireElapsedTime = 0;
				Vector2 dir = Player.transform.position - transform.position;
				dir.Normalize();
				SoundManager.SePlay(2);
				BulletManager.ShotBullet(BulletId.EnemyBullet, transform, dir);
				m_fireCount++;
				if (m_fireCountMax < m_fireCount)
					m_movementState = MovementState.Escape;
			}
		}

		// RVA: 0x1CFCD90 Offset: 0x1CFCD90 VA: 0x1CFCD90
		private void Escape(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
		}

		// RVA: 0x1CFCE54 Offset: 0x1CFCE54 VA: 0x1CFCE54 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFCE70 Offset: 0x1CFCE70 VA: 0x1CFCE70 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			switch(m_movementState)
			{
				case MovementState.Entry:
					Entry(elapsedTime);
					return;
				case MovementState.Fire:
					Fire(elapsedTime);
					return;
				case MovementState.Escape:
					Escape(elapsedTime);
					return;
				case MovementState.DeathMove:
					DeathMove(elapsedTime);
					return;
				default:
					return;
			}
		}

		// RVA: 0x1CFCEB8 Offset: 0x1CFCEB8 VA: 0x1CFCEB8 Slot: 28
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFCEF0 Offset: 0x1CFCEF0 VA: 0x1CFCEF0 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_fireElapsedTime = 0;
			m_movementState = MovementState.Entry;
			m_fireCount = 0;
		}

		// RVA: 0x1CFCF14 Offset: 0x1CFCF14 VA: 0x1CFCF14 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFCF18 Offset: 0x1CFCF18 VA: 0x1CFCF18 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFCF2C Offset: 0x1CFCF2C VA: 0x1CFCF2C Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFCF3C Offset: 0x1CFCF3C VA: 0x1CFCF3C Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFCF40 Offset: 0x1CFCF40 VA: 0x1CFCF40 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
