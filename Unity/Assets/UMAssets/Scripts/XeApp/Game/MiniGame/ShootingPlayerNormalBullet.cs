using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingPlayerNormalBullet : ShootingBullet
	{
		private enum State
		{
			Move = 0,
			CheckOutScreen = 1,
		}

		private State m_state; // 0x40

		//// RVA: 0xC8FC3C Offset: 0xC8FC3C VA: 0xC8FC3C
		private void Move(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
			if (ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_state = State.CheckOutScreen;
				CollisionManager.EraseCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		//// RVA: 0xC8FDA0 Offset: 0xC8FDA0 VA: 0xC8FDA0
		private void CheckOutScreen(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_move, m_speed);
		}

		// RVA: 0xC8FE5C Offset: 0xC8FE5C VA: 0xC8FE5C Slot: 19
		protected override void MoveUpdate(float elapsedTime)
		{
			if (m_state == State.CheckOutScreen)
				CheckOutScreen(elapsedTime);
			else if (m_state == State.Move)
				Move(elapsedTime);
		}

		// RVA: 0xC8FE78 Offset: 0xC8FE78 VA: 0xC8FE78 Slot: 22
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.Enemy)
				return;
			Death();
		}

		// RVA: 0xC8FEBC Offset: 0xC8FEBC VA: 0xC8FEBC Slot: 20
		public override void SetBullet(Transform transform, Vector3 move)
		{
			base.SetBullet(transform, move);
			transform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(Vector3.right, m_move, Vector3.forward));
		}

		// RVA: 0xC90018 Offset: 0xC90018 VA: 0xC90018 Slot: 21
		public override void ParamReset()
		{
			base.ParamReset();
		}

		// RVA: 0xC90020 Offset: 0xC90020 VA: 0xC90020 Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0xC90028 Offset: 0xC90028 VA: 0xC90028 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0xC90030 Offset: 0xC90030 VA: 0xC90030 Slot: 13
		public override void Initialize()
		{
			base.Initialize();
		}

		// RVA: 0xC90038 Offset: 0xC90038 VA: 0xC90038 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0xC90040 Offset: 0xC90040 VA: 0xC90040 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
