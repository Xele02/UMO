using System;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyCharacter : ShootingTask, ShootingSettingEnemyMethod
	{
		[Serializable]
		public class SpriteEnemyAnim
		{
			public SpriteRendererAnime[] spriteAnim = new SpriteRendererAnime[2]; // 0x8
			public SpriteRendererAnime damegeAnim; // 0xC
		}

		//[HeaderAttribute] // RVA: 0x663638 Offset: 0x663638 VA: 0x663638
		[SerializeField]
		private ShootingStageData.StageEnemyType m_enemyType; // 0x10
		//[HeaderAttribute] // RVA: 0x663684 Offset: 0x663684 VA: 0x663684
		[SerializeField]
		private ShootingStageData.StageItemType m_dropItemType; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6636E4 Offset: 0x6636E4 VA: 0x6636E4
		protected ShootingCollision m_collision; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663734 Offset: 0x663734 VA: 0x663734
		protected SpriteEnemyAnim[] m_anime; // 0x1C
		protected int m_animationType; // 0x20
		//[HeaderAttribute] // RVA: 0x66377C Offset: 0x66377C VA: 0x66377C
		[SerializeField]
		private ShootingSpriteAlphaAnime m_damegeAlpha; // 0x24
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6637E8 Offset: 0x6637E8 VA: 0x6637E8
		protected int m_deathScore = 100; // 0x28
		[SerializeField]
		protected int m_damegeScore = 50; // 0x2C
		//[HeaderAttribute] // RVA: 0x663840 Offset: 0x663840 VA: 0x663840
		[SerializeField]
		protected int m_hpMax = 1; // 0x30
		protected int m_hp; // 0x34
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66388C Offset: 0x66388C VA: 0x66388C
		protected float m_speed = 1; // 0x38
		protected Vector3 m_basicMoveDir = Vector3.left; // 0x3C
		protected Vector3 m_deathMoveDir; // 0x48
		protected float m_halfWidth; // 0x54
		protected float m_halfHeight; // 0x58
		protected bool m_isCheckOutScreen; // 0x5C
		private float m_deathSpeed = 100; // 0x60
		private float m_deathAngle; // 0x64
		private EffectId m_deathEffectId = EffectId.HitEffect; // 0x68

		public ShootingCollisionManager CollisionManager { get; set; }  // 0x6C
		public ShootingBulletManager BulletManager { get; set; } // 0x70
		public ShootingPlayerCharacter Player { get; set; } // 0x74
		public RectTransform MainScreen { get; set; } // 0x78
		public ShootingResulData ResulData { get; set; } // 0x7C
		public ShootingEffectManager EffectManager { get; set; } // 0x80
		public ShootingSoundManager SoundManager { get; set; } // 0x84
		public ShootingItemManager ItemManager { get; set; } // 0x88
		public ShootingEnemyManager EnemyManager { get; set; } // 0x8C

		//// RVA: 0x1CF99B4 Offset: 0x1CF99B4 VA: 0x1CF99B4 Slot: 23
		protected virtual void MoveUpdate(float elapsedTime)
		{
			return;
		}

		//// RVA: 0x1CF99B8 Offset: 0x1CF99B8 VA: 0x1CF99B8 Slot: 24
		protected virtual void DeathMove(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, Vector3.right, m_deathSpeed);
			m_deathAngle += elapsedTime * 720;
			transform.eulerAngles = new Vector3(0, 0, -m_deathAngle);
		}

		//// RVA: 0x1CF8AE4 Offset: 0x1CF8AE4 VA: 0x1CF8AE4
		protected void Damege()
		{
			m_hp--;
			ResulData.Score = m_damegeScore;
			if(m_hp < 1)
			{
				ResulData.Score = m_deathScore;
				ChangeDeathState();
				if(m_dropItemType != ShootingStageData.StageItemType.None)
				{
					ItemManager.SetItem(m_dropItemType, transform.position);
				}
			}
			else
			{
				m_damegeAlpha.Play();
				SoundManager.SePlay(4);
			}
		}

		//// RVA: 0x1CF87B0 Offset: 0x1CF87B0 VA: 0x1CF87B0 Slot: 25
		protected virtual void ChangeDeathState()
		{
			m_isCheckOutScreen = true;
			CollisionManager.EraseCollision(m_collision);
			EffectManager.Play(m_deathEffectId, transform);
			SoundManager.SePlay(6);
		}

		//// RVA: 0x1CF9B78 Offset: 0x1CF9B78 VA: 0x1CF9B78 Slot: 26
		protected virtual void Death()
		{
			SetStatus(TaskStatus.Dead);
		}

		//// RVA: 0x1CF8908 Offset: 0x1CF8908 VA: 0x1CF8908 Slot: 27
		protected virtual void DestructMe()
		{
			for(int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].Stop(false);
				m_anime[i].damegeAnim.Stop(false);
			}
			m_damegeAlpha.Stop();
			CollisionManager.EraseCollision(m_collision);
			OnSleep();
		}

		//// RVA: 0x1CF8AE0 Offset: 0x1CF8AE0 VA: 0x1CF8AE0 Slot: 28
		protected virtual void HitCallBack(ShootingCollision collisionObj)
		{
			return;
		}

		//// RVA: 0x1CF9B84 Offset: 0x1CF9B84 VA: 0x1CF9B84
		public void SetEnemy(ShootingStageData.SettingEnemyData data)
		{
			transform.position = new Vector3(data.pos.x + m_halfWidth, data.pos.y, data.pos.z);
			m_dropItemType = data.itemType;
			m_animationType = data.itemType != ShootingStageData.StageItemType.None ? 1 : (int)data.itemType;
			for(int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].Play(0, null);
				m_anime[i].damegeAnim.SyncAnime = m_anime[i].spriteAnim[m_animationType];
				m_anime[i].damegeAnim.Play(0, null);
			}
			m_damegeAlpha.Stop();
			ParamReset();
		}

		//// RVA: 0x1CF8E64 Offset: 0x1CF8E64 VA: 0x1CF8E64 Slot: 29
		public virtual void ParamReset()
		{
			m_isCheckOutScreen = false;
			m_deathAngle = 0;
			m_hp = m_hpMax;
			transform.rotation = Quaternion.identity;
		}

		// RVA: 0x1CF9000 Offset: 0x1CF9000 VA: 0x1CF9000 Slot: 11
		public override void OnAwake()
		{
			m_collision.Owner = this;
			m_collision.HitCallBack = HitCallBack;
			m_collision.OnAwake();
			m_basicMoveDir = Vector3.left;
			Rect r = GetComponentInChildren<SpriteRenderer>().sprite.rect;
			m_halfWidth = r.size.x * 0.5f;
			m_halfHeight = r.size.y * 0.5f;
			OnSleep();
		}

		// RVA: 0x1CF9274 Offset: 0x1CF9274 VA: 0x1CF9274 Slot: 12
		public override void OnStart()
		{
			if (m_collision != null)
				m_collision.OnStart();
		}

		//// RVA: 0x1CF9298 Offset: 0x1CF9298 VA: 0x1CF9298 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		//// RVA: 0x1CF9DBC Offset: 0x1CF9DBC VA: 0x1CF9DBC Slot: 14
		public override void Pause()
		{
			for(int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].Stop(false);
				m_anime[i].damegeAnim.Stop(false);
			}
		}

		//// RVA: 0x1CF9F04 Offset: 0x1CF9F04 VA: 0x1CF9F04 Slot: 15
		public override void UnPause()
		{
			for (int i = 0; i < m_anime.Length; i++)
			{
				m_anime[i].spriteAnim[m_animationType].Play(m_anime[i].spriteAnim[m_animationType].PlayIndex, null);
				m_anime[i].damegeAnim.Play(m_anime[i].damegeAnim.PlayIndex, null);
			}
		}

		// RVA: 0x1CF9574 Offset: 0x1CF9574 VA: 0x1CF9574 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			MoveUpdate(elapsedTime);
			m_collision.OnUpdate(elapsedTime);
			m_damegeAlpha.OnUpdate(elapsedTime, () =>
			{
				//0x1CFA188
				return;
			});
			if(m_isCheckOutScreen)
			{
				if (ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, m_halfWidth, m_halfHeight))
				{
					Death();
				}
			}
		}

		// RVA: 0x1CF9780 Offset: 0x1CF9780 VA: 0x1CF9780 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			if (!IsStatus(TaskStatus.Dead))
				return;
			DestructMe();
		}

		//// RVA: 0x1CFA0B4 Offset: 0x1CFA0B4 VA: 0x1CFA0B4 Slot: 19
		public ShootingStageData.StageEnemyType GetEnemyType()
		{
			return m_enemyType;
		}

		//// RVA: 0x1CFA0BC Offset: 0x1CFA0BC VA: 0x1CFA0BC Slot: 20
		//public Vector3 GetPos() { }

		//// RVA: 0x1CFA0FC Offset: 0x1CFA0FC VA: 0x1CFA0FC Slot: 21
		//public ShootingStageData.StageItemType GetItemType() { }

		//// RVA: 0x1CFA104 Offset: 0x1CFA104 VA: 0x1CFA104 Slot: 22
		//public void SetItemType(ShootingStageData.StageItemType itemType) { }
	}
}
