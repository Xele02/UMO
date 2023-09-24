using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingPlayerCharacter : ShootingTask
	{
		private enum State
		{
			Wait = 0,
			Entry = 1,
			Move = 2,
			Damege = 3,
		}

		private enum DamegeState
		{
			Wait = 0,
			DamegeMove = 1,
			Entry = 2,
		}

		private State m_state; // 0x10
		private DamegeState m_damegeState; // 0x14
		[SerializeField]
		private ShootingPlayerHpLayout m_hpLayout; // 0x18
		[SerializeField]
		private SpriteRenderer m_playerRenderer; // 0x1C
		[SerializeField]
		private ShootingCollision m_collision; // 0x20
		private Animator m_animator; // 0x24
		private float m_animSpeed; // 0x28
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663CE0 Offset: 0x663CE0 VA: 0x663CE0
		public float m_speed = 1; // 0x2C
		//[HeaderAttribute] // RVA: 0x663D28 Offset: 0x663D28 VA: 0x663D28
		[SerializeField]
		private float m_fireTimeMax = 1; // 0x30
		private float m_fireElapsedTime; // 0x34
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663D80 Offset: 0x663D80 VA: 0x663D80
		private float m_invincibleTimeMax; // 0x38
		private float m_invincibleElapsedTime; // 0x3C
		private float m_blinkingTimeMax; // 0x40
		private float m_blinkingElapsedTime; // 0x44
		private bool m_isInvincible; // 0x48
		private bool m_isInvincibleAnime; // 0x49
		private SpriteRenderer[] m_invincibleRender; // 0x4C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663DD0 Offset: 0x663DD0 VA: 0x663DD0
		private float m_damegeMoveTime = 1; // 0x50
		//[HeaderAttribute] // RVA: 0x663E30 Offset: 0x663E30 VA: 0x663E30
		[SerializeField] // RVA: 0x663E30 Offset: 0x663E30 VA: 0x663E30
		private float m_damegeEntryTimeMax = 0.5f; // 0x54
		private float m_damegeSpeed = 50; // 0x58
		private Vector3 m_damegeMoveDir; // 0x5C
		private float m_deathAngle; // 0x68
		private float m_damegEntrySpeed; // 0x6C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663E90 Offset: 0x663E90 VA: 0x663E90
		private int m_hpMax; // 0x70
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663EE4 Offset: 0x663EE4 VA: 0x663EE4
		private int m_hpSecretMax = 9; // 0x74
		private int m_hp; // 0x78
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x663F2C Offset: 0x663F2C VA: 0x663F2C
		private float m_startEntryTimeMax = 1; // 0x7C
		private Vector3 m_entryLocalPos; // 0x80
		private Vector3 m_startPos; // 0x8C
		private float m_entrySpeed; // 0x98
		private float m_playerHalfWidth; // 0x9C
		private float m_playerHalfHeight; // 0xA0
		//[HeaderAttribute] // RVA: 0x663F80 Offset: 0x663F80 VA: 0x663F80
		[SerializeField]
		private float[] m_spreadBulletAngle; // 0xA4
		private int m_fireBulletNum = 1; // 0xA8

		public VirtualPad VirtualPad { get; set; } // 0xAC
		public ShootingCollisionManager CollisionManager { get; set; } // 0xB0
		public ShootingBulletManager BulletManager { get; set; } // 0xB4
		public RectTransform MainScreen { get; set; } // 0xB8
		public ShootingSoundManager SoundManager { get; set; } // 0xBC
		public ShootingSecretCommand SecretCommand { get; set; } // 0xC0

		//// RVA: 0xC8D8C0 Offset: 0xC8D8C0 VA: 0xC8D8C0
		private void Damege(Vector3 hitPos)
		{
			if(!m_isInvincible)
			{
				BulletPowerUpReset();
				SoundManager.SePlay(5);
				m_damegeMoveDir = transform.position - hitPos;
				m_damegeMoveDir.Normalize();
				float f = -0.5f;
				if(m_damegeMoveDir.x >= 0)
				{
					f = 0.5f;
				}
				f *= MainScreen.sizeDelta.x;
				float f2 = -0.5f;
				if(m_damegeMoveDir.y >= 0)
				{
					f2 = 0.5f;
				}
				f2 *= MainScreen.sizeDelta.y;
				f = Vector3.Distance(transform.localPosition, new Vector3(f, f2, 0));
				m_state = State.Damege;
				m_damegeState = DamegeState.DamegeMove;
				m_isInvincible = true;
				m_damegeSpeed = f / m_damegeMoveTime;
				m_animator.SetBool("IsRise", false);
				m_animator.SetBool("IsDescent", false);
				if(m_hp > -1)
				{
					m_hpLayout.Damege(m_hp);
					if(!RuntimeSettings.CurrentSettings.MinigameAutoPlay)
						m_hp--;
					if(m_hp < 0)
					{
						SetStatus(TaskStatus.Dead);
						CollisionManager.EraseCollision(m_collision);
						ShootingGameSceneState.SceneState = ShootingGameSceneState.GameSceneState.GameOver;
					}
				}
			}
		}

		//// RVA: 0xC8DD80 Offset: 0xC8DD80 VA: 0xC8DD80
		private void BulletPowerUp()
		{
			m_fireBulletNum++;
			if(m_fireBulletNum <= m_spreadBulletAngle.Length)
			{
				SoundManager.SePlay(8);
			}
			else
			{
				m_fireBulletNum = m_spreadBulletAngle.Length;
				SoundManager.SePlay(7);
			}
		}

		//// RVA: 0xC8DC24 Offset: 0xC8DC24 VA: 0xC8DC24
		private void BulletPowerUpReset()
		{
			if (!SecretCommand.IsSecretCommand)
				m_fireBulletNum = 1;
			else
				m_fireBulletNum = m_spreadBulletAngle.Length;
		}

		//// RVA: 0xC8DE1C Offset: 0xC8DE1C VA: 0xC8DE1C
		private void HitCallBack(ShootingCollision collisionObj)
		{
			if(collisionObj.m_objType >= ShootingCollision.ObjType.Enemy && collisionObj.m_objType <= ShootingCollision.ObjType.EnemyBullet)
			{
				Damege(collisionObj.m_pos);
			}
			else if(collisionObj.m_objType == ShootingCollision.ObjType.Kyururu)
			{
				BulletPowerUp();
			}
		}

		//// RVA: 0xC8DE80 Offset: 0xC8DE80 VA: 0xC8DE80
		private void Fire()
		{
			SoundManager.SePlay(1);
			for(int i = 0; i < m_fireBulletNum; i++)
			{
				BulletManager.ShotBullet(BulletId.PlayerBullet, transform, Quaternion.Euler(0, 0, m_spreadBulletAngle[i]) * Vector3.right);
			}
		}

		//// RVA: 0xC8E088 Offset: 0xC8E088 VA: 0xC8E088
		//private void PushFireButton(bool isFire, float elapsedTime) { }

		//// RVA: 0xC8E0BC Offset: 0xC8E0BC VA: 0xC8E0BC
		private void MoveUpdate(float elapsedTime, Vector3 moveDir)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, moveDir, m_speed);
			transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, m_playerHalfWidth - MainScreen.sizeDelta.x * 0.5f, MainScreen.sizeDelta.x * 0.5f - m_playerHalfWidth), Mathf.Clamp(transform.localPosition.y, m_playerHalfHeight - MainScreen.sizeDelta.y * 0.5f, MainScreen.sizeDelta.y * 0.5f - m_playerHalfHeight), transform.localPosition.z);
		}

		//// RVA: 0xC8E418 Offset: 0xC8E418 VA: 0xC8E418
		private void AnimationUpdate(Vector3 moveDir)
		{
			m_animator.SetBool("IsRise", 0 <= moveDir.y);
			m_animator.SetBool("IsDescent", moveDir.y < 0);
		}

		bool debugGoUp = false;

		//// RVA: 0xC8E4F4 Offset: 0xC8E4F4 VA: 0xC8E4F4
		private void MoveStateUpdate(float elapsedTime)
		{
			Vector3 dir = new Vector3(VirtualPad.Stick.Axis.x, VirtualPad.Stick.Axis.y, 0);
			dir.Normalize();
			if(RuntimeSettings.CurrentSettings.MinigameAutoPlay)
			{
				if (debugGoUp)
				{
					if (transform.localPosition.y < MainScreen.sizeDelta.y * 0.5f - 2 * m_playerHalfHeight)
						dir.y = 1;
					else
						debugGoUp = false;
				}
				else
				{
					if (transform.localPosition.y > -MainScreen.sizeDelta.y * 0.5f + 2 * m_playerHalfHeight)
						dir.y = -1;
					else
						debugGoUp = true;
				}
			}
			if(dir.x != 0 || dir.y != 0)
			{
				MoveUpdate(elapsedTime, dir);
			}
			AnimationUpdate(dir);
			for(int i = 0; i < VirtualPad.Buttons.Length; i++)
			{
				if(VirtualPad.Buttons[i].ButtonId == 1)
				{
					m_fireElapsedTime -= elapsedTime;
					if((VirtualPad.Buttons[i].IsPress || RuntimeSettings.CurrentSettings.MinigameAutoPlay) && m_fireElapsedTime < 0)
					{
						m_fireElapsedTime = m_fireTimeMax;
						Fire();
					}
				}
			}
		}

		//// RVA: 0xC8E6E8 Offset: 0xC8E6E8 VA: 0xC8E6E8
		private void DamegeMoveupdate(float elapsedTime)
		{
			m_deathAngle = elapsedTime * 360 + m_deathAngle;
			transform.eulerAngles = new Vector3(0, 0, m_deathAngle);
			transform.localPosition = ShootingUtility.PosAfterMovement(elapsedTime, transform.localPosition, m_damegeMoveDir, m_damegeSpeed);
			if(ShootingUtility.CheckOutTheScreen(MainScreen, transform.localPosition, m_playerHalfWidth, m_playerHalfHeight))
			{
				transform.localPosition = m_entryLocalPos;
				transform.rotation = Quaternion.identity;
				m_isInvincibleAnime = true;
				m_damegeState = IsStatus(TaskStatus.Dead) ? DamegeState.Wait : DamegeState.Entry;
			}
		}

		//// RVA: 0xC8EA90 Offset: 0xC8EA90 VA: 0xC8EA90
		private void DamegeEntryUpdate(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, Vector3.right, m_damegEntrySpeed);
			if(m_startPos.x <= transform.position.x)
			{
				m_state = State.Move;
				m_damegeState = DamegeState.Wait;
			}
		}

		//// RVA: 0xC8EC18 Offset: 0xC8EC18 VA: 0xC8EC18
		private void DamegeUpdate(float elapsedTime)
		{
			if(m_damegeState == DamegeState.Entry)
			{
				DamegeEntryUpdate(elapsedTime);
			}
			else if(m_damegeState == DamegeState.DamegeMove)
			{
				DamegeMoveupdate(elapsedTime);
			}
		}

		//// RVA: 0xC8EC34 Offset: 0xC8EC34 VA: 0xC8EC34
		private void EntryMoveUpdate(float elapsedTime)
		{
			transform.position = ShootingUtility.PosAfterMovement(elapsedTime, transform.position, Vector3.right, m_entrySpeed);
			if(m_startPos.x <= transform.position.x)
			{
				m_state = State.Move;
			}
		}

		//// RVA: 0xC8EDB4 Offset: 0xC8EDB4 VA: 0xC8EDB4
		//private void EntryUpdate(float elapsedTime) { }

		//// RVA: 0xC8EDB8 Offset: 0xC8EDB8 VA: 0xC8EDB8
		private void StateUpdate(float elapsedTime)
		{
			if(m_state == State.Damege)
			{
				DamegeUpdate(elapsedTime);
			}
			else if(m_state == State.Move)
			{
				MoveStateUpdate(elapsedTime);
			}
			else if(m_state == State.Entry)
			{
				EntryMoveUpdate(elapsedTime);
			}
		}

		//// RVA: 0xC8EDE0 Offset: 0xC8EDE0 VA: 0xC8EDE0
		private void InvincibleUpdate(float elapsedTime)
		{
			if(m_isInvincibleAnime)
			{
				m_blinkingElapsedTime += elapsedTime;
				if(m_blinkingTimeMax <= m_blinkingElapsedTime)
				{
					m_blinkingElapsedTime = 0;
					for(int i = 0; i < m_invincibleRender.Length; i++)
					{
						Color c = m_invincibleRender[i].color;
						if (c.a < 1)
							c.a = 1;
						else
							c.a = 0;
						m_invincibleRender[i].color = c;
					}
				}
				m_invincibleElapsedTime += elapsedTime;
				if(m_invincibleTimeMax <= m_invincibleElapsedTime)
				{
					m_invincibleElapsedTime = 0;
					m_isInvincible = false;
					m_isInvincibleAnime = false;
					for(int i = 0; i < m_invincibleRender.Length; i++)
					{
						Color c = m_invincibleRender[i].color;
						c.a = 1;
						m_invincibleRender[i].color = c;
					}
				}
			}
		}

		// RVA: 0xC8F074 Offset: 0xC8F074 VA: 0xC8F074 Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_hpLayout.gameObject.SetActive(false);
			m_animator = GetComponent<Animator>();
			m_collision.Owner = this;
			m_collision.HitCallBack = HitCallBack;
			m_collision.OnAwake();
			m_invincibleRender = GetComponentsInChildren<SpriteRenderer>();
			m_playerHalfWidth = 2 * m_playerRenderer.sprite.rect.size.x * 0.5f;
			m_playerHalfHeight = 2 * m_playerRenderer.sprite.rect.size.y * 0.5f;
			m_blinkingTimeMax = 1.0f / Application.targetFrameRate * 5;
			m_animSpeed = m_animator.speed;
		}

		// RVA: 0xC8F370 Offset: 0xC8F370 VA: 0xC8F370 Slot: 12
		public override void OnStart()
		{
			m_startPos = transform.position;
			m_entryLocalPos = new Vector3(MainScreen.sizeDelta.x * -0.5f - m_playerHalfWidth, transform.localPosition.y, transform.localPosition.z);
			m_collision.OnStart();
		}

		//// RVA: 0xC8F498 Offset: 0xC8F498 VA: 0xC8F498 Slot: 13
		public override void Initialize()
		{
			OnActive();
			CollisionManager.AddCollision(m_collision);
			for(int i = 0; i < m_invincibleRender.Length; i++)
			{
				Color c = m_invincibleRender[i].color;
				c.a = 1;
				m_invincibleRender[i].color = c;
			}
			m_state = State.Entry;
			m_damegeState = DamegeState.Wait;
			transform.localPosition = m_entryLocalPos;
			transform.rotation = Quaternion.identity;
			m_deathAngle = 0;
			m_isInvincible = false;
			m_isInvincibleAnime = false;
			m_invincibleElapsedTime = 0;
			m_blinkingElapsedTime = 0;
			m_fireElapsedTime = m_fireTimeMax;
			float f = Vector3.Distance(m_startPos, transform.position);
			m_entrySpeed = f / m_startEntryTimeMax;
			m_damegEntrySpeed = f / m_damegeEntryTimeMax;
			if (!SecretCommand.IsSecretCommand)
			{
				m_hp = m_hpMax - 1;
				m_fireBulletNum = 1;
			}
			else
			{
				m_hp = m_hpSecretMax - 1;
				m_fireBulletNum = m_spreadBulletAngle.Length;
			}
			m_hpLayout.gameObject.SetActive(true);
			m_hpLayout.ResetParam(m_hp);
			m_animator.speed = m_animSpeed;
		}

		//// RVA: 0xC8F9DC Offset: 0xC8F9DC VA: 0xC8F9DC Slot: 14
		public override void Pause()
		{
			m_animSpeed = m_animator.speed;
			m_animator.speed = 0;
		}

		//// RVA: 0xC8FA34 Offset: 0xC8FA34 VA: 0xC8FA34 Slot: 15
		public override void UnPause()
		{
			m_animator.speed = m_animSpeed;
		}

		// RVA: 0xC8FA70 Offset: 0xC8FA70 VA: 0xC8FA70 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			StateUpdate(elapsedTime);
			InvincibleUpdate(elapsedTime);
			m_collision.OnUpdate(elapsedTime);
		}

		// RVA: 0xC8FAB8 Offset: 0xC8FAB8 VA: 0xC8FAB8 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			m_collision.OnLateUpdate(elapsedTime);
		}

		// RVA: 0xC8FAEC Offset: 0xC8FAEC VA: 0xC8FAEC Slot: 18
		public override void OnSleep()
		{
			base.OnSleep();
			m_hpLayout.gameObject.SetActive(false);
		}
	}
}
