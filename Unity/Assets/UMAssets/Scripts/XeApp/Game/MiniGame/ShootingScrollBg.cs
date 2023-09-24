using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingScrollBg : ShootingTask
	{
		[SerializeField]
		private SpriteRenderer m_sprite; // 0x10
		[SerializeField]
		private float m_speed = 1; // 0x14
		private Vector3 m_initPos; // 0x18
		private float m_width; // 0x24
		private float m_resetX; // 0x28

		// RVA: 0xC90A5C Offset: 0xC90A5C VA: 0xC90A5C Slot: 11
		public override void OnAwake()
		{
			OnActive();
			m_initPos = transform.localPosition;
			Rect r = m_sprite.sprite.rect;
			m_width = 2 * r.size.x;
			m_resetX = m_initPos.x - m_width;
		}

		// RVA: 0xC90B3C Offset: 0xC90B3C VA: 0xC90B3C Slot: 12
		public override void OnStart()
		{
			return;
		}

		// RVA: 0xC90B40 Offset: 0xC90B40 VA: 0xC90B40 Slot: 13
		public override void Initialize()
		{
			OnActive();
		}

		// RVA: 0xC90B44 Offset: 0xC90B44 VA: 0xC90B44 Slot: 14
		public override void Pause()
		{
			return;
		}

		// RVA: 0xC90B48 Offset: 0xC90B48 VA: 0xC90B48 Slot: 15
		public override void UnPause()
		{
			return;
		}

		// RVA: 0xC90B4C Offset: 0xC90B4C VA: 0xC90B4C Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			Vector3 v = transform.localPosition + Vector3.left * m_speed * elapsedTime;
			if (v.x <= m_resetX)
				v.x += m_width;
			transform.localPosition = v;
		}

		// RVA: 0xC90CDC Offset: 0xC90CDC VA: 0xC90CDC Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
