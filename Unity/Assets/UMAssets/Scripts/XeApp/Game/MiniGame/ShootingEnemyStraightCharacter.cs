namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Escape = 1,
			DeathMove = 2,
		}

		private MovementState m_movementState; // 0x90

		// RVA: 0x1CFC128 Offset: 0x1CFC128 VA: 0x1CFC128
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.Escape;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFC278 Offset: 0x1CFC278 VA: 0x1CFC278
		private void Escape(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
		}

		// RVA: 0x1CFC33C Offset: 0x1CFC33C VA: 0x1CFC33C Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFC358 Offset: 0x1CFC358 VA: 0x1CFC358 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_movementState == MovementState.Entry)
				Entry(elapsedTime);
			else if (m_movementState == MovementState.Escape)
				Escape(elapsedTime);
			else if (m_movementState == MovementState.DeathMove)
				DeathMove(elapsedTime);
		}

		// RVA: 0x1CFC38C Offset: 0x1CFC38C VA: 0x1CFC38C Slot: 28
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFC3C4 Offset: 0x1CFC3C4 VA: 0x1CFC3C4 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_movementState = MovementState.Entry;
		}

		// RVA: 0x1CFC3E0 Offset: 0x1CFC3E0 VA: 0x1CFC3E0 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFC3E4 Offset: 0x1CFC3E4 VA: 0x1CFC3E4 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFC3F8 Offset: 0x1CFC3F8 VA: 0x1CFC3F8 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFC408 Offset: 0x1CFC408 VA: 0x1CFC408 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFC40C Offset: 0x1CFC40C VA: 0x1CFC40C Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
