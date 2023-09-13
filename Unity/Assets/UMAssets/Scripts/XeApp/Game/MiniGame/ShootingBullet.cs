using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingBullet : ShootingTask
	{
		[SerializeField]
		private BulletId m_bulletId; // 0x10
		[SerializeField]
		protected ShootingCollision m_collision; // 0x14
		//[HeaderAttribute] // RVA: 0x6629CC Offset: 0x6629CC VA: 0x6629CC
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x662A14 Offset: 0x662A14 VA: 0x662A14
		protected float m_speed = 1; // 0x1C
		protected Vector3 m_move; // 0x20
		protected float m_halfWidth; // 0x2C
		protected float m_halfHeight; // 0x30
		protected bool m_isCheckOutScreen; // 0x34

		public BulletId GetId { get { return m_bulletId; } } //0x1CF2E1C
		public RectTransform MainScreen { get; set; } // 0x38
		public ShootingCollisionManager CollisionManager { get; set; } // 0x3C

		//// RVA: 0x1CF2E44 Offset: 0x1CF2E44 VA: 0x1CF2E44 Slot: 19
		protected virtual void MoveUpdate(float elapsedTime)
		{
			return;
		}

		//// RVA: 0x1CF2E48 Offset: 0x1CF2E48 VA: 0x1CF2E48 Slot: 20
		public virtual void SetBullet(Transform transform, Vector3 move)
		{
			OnActive();
			ParamReset();
			this.transform.position = transform.position;
			m_move = move;
			transform.localPosition += m_move * m_halfWidth;
			CollisionManager.AddCollision(m_collision);
			m_spriteAnim.Play(0, null);
		}

		//// RVA: 0x1CF3124 Offset: 0x1CF3124 VA: 0x1CF3124 Slot: 21
		public virtual void ParamReset()
		{
			transform.rotation = Quaternion.identity;
		}

		//// RVA: 0x1CF31EC Offset: 0x1CF31EC VA: 0x1CF31EC
		protected void Death()
		{
			SetStatus(TaskStatus.Dead);
		}

		//// RVA: 0x1CF31F8 Offset: 0x1CF31F8 VA: 0x1CF31F8
		protected void DestructMe()
		{
			OnSleep();
			CollisionManager.EraseCollision(m_collision);
		}

		//// RVA: 0x1CF3300 Offset: 0x1CF3300 VA: 0x1CF3300 Slot: 22
		protected virtual void HitCallBack(ShootingCollision collisionObj)
		{
			return;
		}

		// RVA: 0x1CF3304 Offset: 0x1CF3304 VA: 0x1CF3304 Slot: 11
		public override void OnAwake()
		{
			m_collision.Owner = this;
			m_collision.HitCallBack = HitCallBack;
			m_collision.OnAwake();
			Rect r = GetComponentInChildren<SpriteRenderer>().sprite.rect;
			m_halfWidth = 2 * r.size.x * 0.5f;
			m_halfHeight = 2 * r.size.y * 0.5f;
			OnSleep();
		}

		// RVA: 0x1CF353C Offset: 0x1CF353C VA: 0x1CF353C Slot: 12
		public override void OnStart()
		{
			if (m_collision != null)
				m_collision.OnStart();
		}

		//// RVA: 0x1CF3554 Offset: 0x1CF3554 VA: 0x1CF3554 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		//// RVA: 0x1CF3564 Offset: 0x1CF3564 VA: 0x1CF3564 Slot: 14
		public override void Pause()
		{
			m_spriteAnim.Stop(false);
		}

		//// RVA: 0x1CF3594 Offset: 0x1CF3594 VA: 0x1CF3594 Slot: 15
		public override void UnPause()
		{
			m_spriteAnim.Play(m_spriteAnim.PlayIndex, null);
		}

		// RVA: 0x1CF35F8 Offset: 0x1CF35F8 VA: 0x1CF35F8 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			MoveUpdate(elapsedTime);
			m_collision.OnUpdate(elapsedTime);
			if(m_isCheckOutScreen)
			{
				if (ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, m_halfWidth, m_halfWidth))
					SetStatus(TaskStatus.Dead);
			}
		}

		// RVA: 0x1CF3724 Offset: 0x1CF3724 VA: 0x1CF3724 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			if (!IsStatus(TaskStatus.Dead))
				return;
			DestructMe();
		}
	}
}
