using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingItem : ShootingTask, ShootingSettingItemMethod
	{
		[SerializeField]
		private ShootingStageData.StageItemType m_itemType; // 0x10
		[SerializeField]
		protected ShootingCollision m_collision; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664254 Offset: 0x664254 VA: 0x664254
		protected SpriteRendererAnime m_spriteAnim; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66429C Offset: 0x66429C VA: 0x66429C
		protected float m_speed = 30; // 0x1C
		//[HeaderAttribute] // RVA: 0x6642E4 Offset: 0x6642E4 VA: 0x6642E4
		[SerializeField]
		protected int m_score = 1000; // 0x20
		protected float m_halfWidth; // 0x24
		protected float m_halfHeight; // 0x28
		protected Vector3 m_moveDir = Vector3.left; // 0x2C
		protected bool m_isCheckOutScreen; // 0x38

		public ShootingResulData ResulData { get; set; } // 0x3C
		public ShootingCollisionManager CollisionManager { get; set; } // 0x40
		public RectTransform MainScreen { get; set; } // 0x44

		//// RVA: 0x1CFEA28 Offset: 0x1CFEA28 VA: 0x1CFEA28 Slot: 21
		protected virtual void HitCallBack(ShootingCollision collisionObj)
		{
			return;
		}

		//// RVA: 0x1CFEA2C Offset: 0x1CFEA2C VA: 0x1CFEA2C Slot: 22
		public virtual void SetItem(Vector3 pos)
		{
			OnActive();
			transform.position = pos;
			m_spriteAnim.Play(0, null);
			ParamReset();
		}

		//// RVA: 0x1CFEAD0 Offset: 0x1CFEAD0 VA: 0x1CFEAD0 Slot: 23
		public virtual void ParamReset()
		{
			transform.rotation = Quaternion.identity;
		}

		//// RVA: 0x1CFEB98 Offset: 0x1CFEB98 VA: 0x1CFEB98 Slot: 24
		protected virtual void Death()
		{
			SetStatus(TaskStatus.Dead);
		}

		//// RVA: 0x1CFEBA4 Offset: 0x1CFEBA4 VA: 0x1CFEBA4 Slot: 25
		protected virtual void DestructMe()
		{
			OnSleep();
			CollisionManager.EraseCollision(m_collision);
		}

		//// RVA: 0x1CFEBEC Offset: 0x1CFEBEC VA: 0x1CFEBEC Slot: 26
		protected virtual void MoveUpdate(float elapsedTime)
		{
			return;
		}

		// RVA: 0x1CFEBF0 Offset: 0x1CFEBF0 VA: 0x1CFEBF0 Slot: 11
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

		// RVA: 0x1CFEE00 Offset: 0x1CFEE00 VA: 0x1CFEE00 Slot: 12
		public override void OnStart()
		{
			if (m_collision != null)
				m_collision.OnStart();
		}

		//// RVA: 0x1CFEE14 Offset: 0x1CFEE14 VA: 0x1CFEE14 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		//// RVA: 0x1CFEE24 Offset: 0x1CFEE24 VA: 0x1CFEE24 Slot: 14
		public override void Pause()
		{
			m_spriteAnim.Stop(false);
		}

		//// RVA: 0x1CFEE54 Offset: 0x1CFEE54 VA: 0x1CFEE54 Slot: 15
		public override void UnPause()
		{
			m_spriteAnim.Play(m_spriteAnim.PlayIndex, null);
		}

		// RVA: 0x1CFEEB8 Offset: 0x1CFEEB8 VA: 0x1CFEEB8 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			MoveUpdate(elapsedTime);
			m_collision.OnUpdate(elapsedTime);
			if(m_isCheckOutScreen)
			{
				if(ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, m_halfWidth, m_halfWidth))
				{
					Death();
				}
			}
		}

		// RVA: 0x1CFEF80 Offset: 0x1CFEF80 VA: 0x1CFEF80 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			if (!IsStatus(TaskStatus.Dead))
				return;
			DestructMe();
		}

		//// RVA: 0x1CFEFD0 Offset: 0x1CFEFD0 VA: 0x1CFEFD0 Slot: 19
		public ShootingStageData.StageItemType GetItemType()
		{
			return m_itemType;
		}

		//// RVA: 0x1CFEFD8 Offset: 0x1CFEFD8 VA: 0x1CFEFD8 Slot: 20
		//public Vector3 GetPos() { }
	}
}
