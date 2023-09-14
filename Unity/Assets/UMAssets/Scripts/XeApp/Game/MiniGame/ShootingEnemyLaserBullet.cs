using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyLaserBullet : ShootingBullet
	{
		private enum State
		{
			Move = 0,
			CheckOutScreen = 1,
		}

		private State m_state; // 0x40

		// RVA: 0x1CFA200 Offset: 0x1CFA200 VA: 0x1CFA200
		private void Move(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
			if (ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				CollisionManager.EraseCollision(m_collision);
				m_state = State.CheckOutScreen;
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFA350 Offset: 0x1CFA350 VA: 0x1CFA350
		private void CheckOutScreen(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
		}

		// RVA: 0x1CFA414 Offset: 0x1CFA414 VA: 0x1CFA414 Slot: 19
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_state == State.CheckOutScreen)
				CheckOutScreen(elapsedTime);
			else if (m_state == State.Move)
				Move(elapsedTime);
		}

		// RVA: 0x1CFA430 Offset: 0x1CFA430 VA: 0x1CFA430 Slot: 22
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			return;
		}

		// RVA: 0x1CFA440 Offset: 0x1CFA440 VA: 0x1CFA440 Slot: 20
		public override void SetBullet(Transform transform, Vector3 move)
		{
			base.SetBullet(transform, move);
			this.transform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(Vector3.left, m_move, Vector3.forward));
		}

		// RVA: 0x1CFA590 Offset: 0x1CFA590 VA: 0x1CFA590 Slot: 21
		public override void ParamReset()
		{
			base.ParamReset();
		}

		// RVA: 0x1CFA594 Offset: 0x1CFA594 VA: 0x1CFA594 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFA598 Offset: 0x1CFA598 VA: 0x1CFA598 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFA5AC Offset: 0x1CFA5AC VA: 0x1CFA5AC Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFA5BC Offset: 0x1CFA5BC VA: 0x1CFA5BC Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFA5C0 Offset: 0x1CFA5C0 VA: 0x1CFA5C0 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
