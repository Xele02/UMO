using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyNormalBullet : ShootingBullet
	{
		private enum State
		{
			Move = 0,
			CheckOutScreen = 1,
		}
		
		private State m_state; // 0x40

		//// RVA: 0x1CFB76C Offset: 0x1CFB76C VA: 0x1CFB76C
		private void Move(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
			if(ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				CollisionManager.EraseCollision(m_collision);
				m_state = State.CheckOutScreen;
				m_isCheckOutScreen = true;
			}
		}

		//// RVA: 0x1CFB8BC Offset: 0x1CFB8BC VA: 0x1CFB8BC
		private void CheckOutScreen(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
		}

		// RVA: 0x1CFB980 Offset: 0x1CFB980 VA: 0x1CFB980 Slot: 19
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_state == State.CheckOutScreen)
				CheckOutScreen(elapsedTime);
			else if (m_state == State.Move)
				Move(elapsedTime);
		}

		// RVA: 0x1CFB99C Offset: 0x1CFB99C VA: 0x1CFB99C Slot: 22
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.Player)
				return;
			SetStatus(TaskStatus.Dead);
		}

		// RVA: 0x1CFB9DC Offset: 0x1CFB9DC VA: 0x1CFB9DC Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFB9E0 Offset: 0x1CFB9E0 VA: 0x1CFB9E0 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFB9F4 Offset: 0x1CFB9F4 VA: 0x1CFB9F4 Slot: 13
		public override void Initialize()
		{
			OnSleep();
			transform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(Vector3.left, m_move, Vector3.forward));
		}

		// RVA: 0x1CFBB30 Offset: 0x1CFBB30 VA: 0x1CFBB30 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFBB34 Offset: 0x1CFBB34 VA: 0x1CFBB34 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
