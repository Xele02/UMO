using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyUpDownFireCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Move = 1,
			Escape = 2,
			DeathMove = 3,
		}

		private MovementState m_movementState; // 0x90
		//[HeaderAttribute] // RVA: 0x663560 Offset: 0x663560 VA: 0x663560
		[SerializeField]
		private float m_fireLenght; // 0x94
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6635A8 Offset: 0x6635A8 VA: 0x6635A8
		private float m_radius; // 0x98
		//[HeaderAttribute] // RVA: 0x6635F0 Offset: 0x6635F0 VA: 0x6635F0
		[SerializeField]
		private float m_angleSpeed; // 0x9C
		private float m_angle; // 0xA0
		private float m_startY; // 0xA4

		// RVA: 0x1CFDFF4 Offset: 0x1CFDFF4 VA: 0x1CFDFF4
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.Move;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFE144 Offset: 0x1CFE144 VA: 0x1CFE144
		private void SinMove(float elapsedTime)
		{
			m_angle += m_angleSpeed * Time.deltaTime;
			Vector3 v = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			v.y = m_startY + m_radius * Mathf.Sin(m_angle);
			transform.position = v;
			if(transform.localPosition.x < m_fireLenght)
			{
				Vector3 dir = Player.transform.position - transform.position;
				dir.Normalize();
				SoundManager.SePlay(2);
				BulletManager.ShotBullet(BulletId.EnemyBullet, transform, dir);
				m_movementState = MovementState.Escape;
			}
		}

		// RVA: 0x1CFE470 Offset: 0x1CFE470 VA: 0x1CFE470
		private void Escape(float elapsedTime)
		{
			m_angle += m_angleSpeed * Time.deltaTime;
			Vector3 v = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			v.y = m_startY + m_radius * Mathf.Sin(m_angle);
			transform.position = v;
		}

		// RVA: 0x1CFE5E8 Offset: 0x1CFE5E8 VA: 0x1CFE5E8 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFE604 Offset: 0x1CFE604 VA: 0x1CFE604 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			switch(m_movementState)
			{
				case MovementState.Entry:
					Entry(elapsedTime);
					return;
				case MovementState.Move:
					SinMove(elapsedTime);
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

		// RVA: 0x1CFE64C Offset: 0x1CFE64C VA: 0x1CFE64C Slot: 28
		protected override void HitCallBack(ShootingCollision collision)
		{
			if (collision.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFE684 Offset: 0x1CFE684 VA: 0x1CFE684 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_angle = 0;
			m_movementState = MovementState.Entry;
			m_startY = transform.position.y;
		}

		// RVA: 0x1CFE6E4 Offset: 0x1CFE6E4 VA: 0x1CFE6E4 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFE6E8 Offset: 0x1CFE6E8 VA: 0x1CFE6E8 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFE6FC Offset: 0x1CFE6FC VA: 0x1CFE6FC Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFE70C Offset: 0x1CFE70C VA: 0x1CFE70C Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFE710 Offset: 0x1CFE710 VA: 0x1CFE710 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
