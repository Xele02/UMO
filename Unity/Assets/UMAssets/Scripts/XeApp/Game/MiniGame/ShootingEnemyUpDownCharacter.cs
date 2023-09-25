using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyUpDownCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Move = 1,
			DeathMove = 2,
		}

		private MovementState m_movementState; // 0x90
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6634D0 Offset: 0x6634D0 VA: 0x6634D0
		private float m_radius; // 0x94
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663518 Offset: 0x663518 VA: 0x663518
		private float m_angleSpeed; // 0x98
		private float m_angle; // 0x9C
		private float m_startY; // 0xA0

		// RVA: 0x1CFDC18 Offset: 0x1CFDC18 VA: 0x1CFDC18
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

		// RVA: 0x1CFDD68 Offset: 0x1CFDD68 VA: 0x1CFDD68
		private void SinMove(float elapsedTime)
		{
			m_angle += m_angleSpeed * elapsedTime;
			Vector3 v = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			v.y = m_startY + m_radius * Mathf.Sin(m_angle);
			transform.position = v;
		}

		// RVA: 0x1CFDED8 Offset: 0x1CFDED8 VA: 0x1CFDED8 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFDEF4 Offset: 0x1CFDEF4 VA: 0x1CFDEF4 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_movementState == MovementState.DeathMove)
				DeathMove(elapsedTime);
			else if (m_movementState == MovementState.Entry)
				Entry(elapsedTime);
			else if (m_movementState == MovementState.Move)
				SinMove(elapsedTime);
		}

		// RVA: 0x1CFDF28 Offset: 0x1CFDF28 VA: 0x1CFDF28 Slot: 28
		protected override void HitCallBack(ShootingCollision collision)
		{
			if (collision.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFDF60 Offset: 0x1CFDF60 VA: 0x1CFDF60 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_angle = 0;
			m_movementState = MovementState.Entry;
			m_startY = transform.position.y;
		}

		// RVA: 0x1CFDFC0 Offset: 0x1CFDFC0 VA: 0x1CFDFC0 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFDFC4 Offset: 0x1CFDFC4 VA: 0x1CFDFC4 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFDFD8 Offset: 0x1CFDFD8 VA: 0x1CFDFD8 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFDFE8 Offset: 0x1CFDFE8 VA: 0x1CFDFE8 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFDFEC Offset: 0x1CFDFEC VA: 0x1CFDFEC Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
