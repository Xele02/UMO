using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyBossBullet : ShootingBullet
	{
		private enum State
		{
			Move = 0,
			CheckOutScreen = 1,
		}

		private State m_state; // 0x40

		// RVA: 0x1CF734C Offset: 0x1CF734C VA: 0x1CF734C
		private void Move(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
			if(ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_state = State.CheckOutScreen;
				CollisionManager.EraseCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CF749C Offset: 0x1CF749C VA: 0x1CF749C
		private void CheckOutScreen(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
		}

		// RVA: 0x1CF7560 Offset: 0x1CF7560 VA: 0x1CF7560 Slot: 19
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_state == State.CheckOutScreen)
				CheckOutScreen(elapsedTime);
			else if (m_state == State.Move)
				Move(elapsedTime);
		}

		// RVA: 0x1CF757C Offset: 0x1CF757C VA: 0x1CF757C Slot: 22
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			base.HitCallBack(collisionObj);
		}

		// RVA: 0x1CF758C Offset: 0x1CF758C VA: 0x1CF758C Slot: 20
		public override void SetBullet(Transform transform, Vector3 move)
		{
			base.SetBullet(transform, move);
			transform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(Vector3.left, m_move, Vector3.forward));
		}

		// RVA: 0x1CF76DC Offset: 0x1CF76DC VA: 0x1CF76DC Slot: 21
		public override void ParamReset()
		{
			base.ParamReset();
		}

		// RVA: 0x1CF76E0 Offset: 0x1CF76E0 VA: 0x1CF76E0 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CF76E4 Offset: 0x1CF76E4 VA: 0x1CF76E4 Slot: 12
		public override void OnStart()
		{
			return;
		}

		// RVA: 0x1CF76F8 Offset: 0x1CF76F8 VA: 0x1CF76F8 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CF7708 Offset: 0x1CF7708 VA: 0x1CF7708 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CF770C Offset: 0x1CF770C VA: 0x1CF770C Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
