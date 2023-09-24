namespace XeApp.Game.MiniGame
{
	public class ShootingKyururuItem : ShootingItem
	{
		private enum MovementState
		{
			Entry = 0,
			Move = 1,
		}

		private MovementState m_movementState; // 0x48

		//// RVA: 0x1CFFE38 Offset: 0x1CFFE38 VA: 0x1CFFE38
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_moveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.Move;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		//// RVA: 0x1CFFF88 Offset: 0x1CFFF88 VA: 0x1CFFF88
		private void Move(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_moveDir, m_speed);
		}

		// RVA: 0x1D0004C Offset: 0x1D0004C VA: 0x1D0004C Slot: 21
		protected override void HitCallBack(ShootingCollision collisionObj) { }

		// RVA: 0x1D000B8 Offset: 0x1D000B8 VA: 0x1D000B8 Slot: 26
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_movementState == MovementState.Move)
				Move(elapsedTime);
			else if (m_movementState == MovementState.Entry)
				Entry(elapsedTime);
		}

		// RVA: 0x1D000D4 Offset: 0x1D000D4 VA: 0x1D000D4 Slot: 23
		public override void ParamReset()
		{
			base.ParamReset();
			m_movementState = MovementState.Entry;
		}

		// RVA: 0x1D000F0 Offset: 0x1D000F0 VA: 0x1D000F0 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1D000F4 Offset: 0x1D000F4 VA: 0x1D000F4 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1D00108 Offset: 0x1D00108 VA: 0x1D00108 Slot: 14
		public override void Pause()
		{
			base.Pause();
		}

		// RVA: 0x1D0010C Offset: 0x1D0010C VA: 0x1D0010C Slot: 15
		public override void UnPause()
		{
			base.UnPause();
		}

		// RVA: 0x1D00110 Offset: 0x1D00110 VA: 0x1D00110 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1D00120 Offset: 0x1D00120 VA: 0x1D00120 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1D00124 Offset: 0x1D00124 VA: 0x1D00124 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
