using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightFireCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			ReadyFire = 1,
			Fire = 2,
			Escape = 3,
			DeathMove = 4,
		}

		private MovementState m_movementState; // 0x90
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663234 Offset: 0x663234 VA: 0x663234
		private float m_readyPos = 200; // 0x94
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6632AC Offset: 0x6632AC VA: 0x6632AC
		private int m_fireCountMax; // 0x98
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6632F4 Offset: 0x6632F4 VA: 0x6632F4
		private float m_fireTimeMax = 1; // 0x9C
		private int m_fireCount; // 0xA0
		private float m_fireElapsedTime; // 0xA4

		// RVA: 0x1CFC414 Offset: 0x1CFC414 VA: 0x1CFC414
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

		// RVA: 0x1CFC564 Offset: 0x1CFC564 VA: 0x1CFC564
		private void ReadyFire(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if (transform.localPosition.x <= m_readyPos)
				m_movementState = MovementState.Fire;
		}

		// RVA: 0x1CFC67C Offset: 0x1CFC67C VA: 0x1CFC67C
		private void Fire(float elapsedTime)
		{
			m_fireElapsedTime += elapsedTime;
			if(m_fireTimeMax < m_fireElapsedTime)
			{
				m_fireElapsedTime = 0;
				SoundManager.SePlay(2);
				BulletManager.ShotBullet(BulletId.EnemyBullet, transform, Vector3.left);
				m_fireCount++;
				if (m_fireCountMax <= m_fireCount)
					m_movementState = MovementState.Escape;
			}
		}

		// RVA: 0x1CFC7BC Offset: 0x1CFC7BC VA: 0x1CFC7BC
		private void Escape(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
		}

		// RVA: 0x1CFC880 Offset: 0x1CFC880 VA: 0x1CFC880 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFC89C Offset: 0x1CFC89C VA: 0x1CFC89C Slot: 23
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

		// RVA: 0x1CFC8EC Offset: 0x1CFC8EC VA: 0x1CFC8EC Slot: 28
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFC924 Offset: 0x1CFC924 VA: 0x1CFC924 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_movementState = MovementState.Entry;
			m_fireCount = 0;
			m_fireElapsedTime = 0;
		}

		// RVA: 0x1CFC948 Offset: 0x1CFC948 VA: 0x1CFC948 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFC94C Offset: 0x1CFC94C VA: 0x1CFC94C Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFC960 Offset: 0x1CFC960 VA: 0x1CFC960 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFC970 Offset: 0x1CFC970 VA: 0x1CFC970 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFC974 Offset: 0x1CFC974 VA: 0x1CFC974 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
