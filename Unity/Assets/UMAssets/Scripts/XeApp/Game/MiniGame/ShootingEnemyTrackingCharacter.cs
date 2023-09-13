using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyTrackingCharacter : ShootingEnemyCharacter
	{
		private enum MovementState
		{
			Entry = 0,
			Tracking = 1,
			Escape = 2,
			DeathMove = 3,
		}

		private MovementState m_movementState; // 0x90
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6633CC Offset: 0x6633CC VA: 0x6633CC
		private int m_angleLimit = 30; // 0x94
		//[HeaderAttribute] // RVA: 0x663420 Offset: 0x663420 VA: 0x663420
		[SerializeField]
		private float m_angleElapsedTimeMax = 0.5f; // 0x98
		private float m_angleElapsedTime; // 0x9C
		private float m_nowAngle; // 0xA0
		//[HeaderAttribute] // RVA: 0x66347C Offset: 0x66347C VA: 0x66347C
		[SerializeField]
		private float m_trackingTimeMax = 8; // 0xA4
		private float m_trackingTime; // 0xA8

		// RVA: 0x1CFD1E8 Offset: 0x1CFD1E8 VA: 0x1CFD1E8
		private void Entry(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, m_basicMoveDir, m_speed);
			if(ShootingUtility.CheckInTheScreen(MainScreen, transform.localPosition, 0, 0))
			{
				m_movementState = MovementState.Tracking;
				CollisionManager.AddCollision(m_collision);
				m_isCheckOutScreen = true;
			}
		}

		// RVA: 0x1CFD338 Offset: 0x1CFD338 VA: 0x1CFD338
		private void PlayerTracking(float elapsedTime)
		{
			if(Player != null)
			{
				m_angleElapsedTime += elapsedTime;
				if(m_angleElapsedTimeMax <= m_angleElapsedTime)
				{
					m_angleElapsedTime = 0;
					Vector3 dir = Player.transform.position - transform.position;
					dir.Normalize();
					float f1 = Vector3.SignedAngle(Vector3.left, dir, Vector3.forward);
					float f2 = Vector3.SignedAngle(Vector3.left, -transform.right, Vector3.forward);
					if((int)(f2 - f1) / m_angleLimit != 0)
					{
						Vector3 v = Vector3.Cross(dir, -transform.right);
						m_nowAngle += v.z >= 0 ? m_angleLimit : -m_angleLimit;
					}
					if (m_nowAngle >= 180)
						m_nowAngle -= 360;
					if (m_nowAngle < -180)
						m_nowAngle += 360;
					transform.eulerAngles = new Vector3(0, 0, -m_nowAngle);
				}
				transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, -transform.right, m_speed);
			}
			m_trackingTime += elapsedTime;
			if (m_trackingTimeMax <= m_trackingTime)
				m_movementState = MovementState.Escape;
		}

		// RVA: 0x1CFD8D0 Offset: 0x1CFD8D0 VA: 0x1CFD8D0
		private void Escape(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, -transform.right, m_speed);
		}

		// RVA: 0x1CFDA48 Offset: 0x1CFDA48 VA: 0x1CFDA48 Slot: 25
		protected override void ChangeDeathState()
		{
			base.ChangeDeathState();
			m_movementState = MovementState.DeathMove;
		}

		// RVA: 0x1CFDA64 Offset: 0x1CFDA64 VA: 0x1CFDA64 Slot: 23
		protected override void MoveUpdate(float elapsedTime)
		{
			switch(m_movementState)
			{
				case MovementState.Entry:
					Entry(elapsedTime);
					return;
				case MovementState.Tracking:
					PlayerTracking(elapsedTime);
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

		// RVA: 0x1CFDAAC Offset: 0x1CFDAAC VA: 0x1CFDAAC Slot: 28
		protected override void HitCallBack(ShootingCollision collisionObj)
		{
			if (collisionObj.m_objType != ShootingCollision.ObjType.PlayerBullet)
				return;
			Damege();
		}

		// RVA: 0x1CFDAE4 Offset: 0x1CFDAE4 VA: 0x1CFDAE4 Slot: 29
		public override void ParamReset()
		{
			base.ParamReset();
			m_movementState = MovementState.Entry;
			m_angleElapsedTime = 0;
			m_nowAngle = 0;
			transform.rotation = Quaternion.identity;
			m_nowAngle = 0;
			m_trackingTime = 0;
		}

		// RVA: 0x1CFDBCC Offset: 0x1CFDBCC VA: 0x1CFDBCC Slot: 11
		public override void OnAwake()
		{
			base.OnAwake();
		}

		// RVA: 0x1CFDBD0 Offset: 0x1CFDBD0 VA: 0x1CFDBD0 Slot: 12
		public override void OnStart()
		{
			base.OnStart();
		}

		// RVA: 0x1CFDBE4 Offset: 0x1CFDBE4 VA: 0x1CFDBE4 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFDBF4 Offset: 0x1CFDBF4 VA: 0x1CFDBF4 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			base.OnUpdate(elapsedTime);
		}

		// RVA: 0x1CFDBF8 Offset: 0x1CFDBF8 VA: 0x1CFDBF8 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			base.OnLateUpdate(elapsedTime);
		}
	}
}
