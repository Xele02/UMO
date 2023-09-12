using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffect : ShootingTask
	{
		[SerializeField]
		private EffectId m_effectId; // 0x10
		//[HeaderAttribute] // RVA: 0x6640D8 Offset: 0x6640D8 VA: 0x6640D8
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim; // 0x14

		public EffectId GetId { get { return m_effectId; } } //0x1CF56E4

		//// RVA: 0x1CF56EC Offset: 0x1CF56EC VA: 0x1CF56EC Slot: 19
		//public virtual void Play(Transform trans) { }

		// RVA: 0x1CF578C Offset: 0x1CF578C VA: 0x1CF578C Slot: 11
		public override void OnAwake()
		{
			OnSleep();
		}

		// RVA: 0x1CF579C Offset: 0x1CF579C VA: 0x1CF579C Slot: 12
		public override void OnStart()
		{
			return;
		}

		// RVA: 0x1CF57A0 Offset: 0x1CF57A0 VA: 0x1CF57A0 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CF57B0 Offset: 0x1CF57B0 VA: 0x1CF57B0 Slot: 14
		public override void Pause()
		{
			m_spriteAnim.Stop(false);
		}

		// RVA: 0x1CF57E0 Offset: 0x1CF57E0 VA: 0x1CF57E0 Slot: 15
		public override void UnPause()
		{
			m_spriteAnim.Play(m_spriteAnim.PlayIndex, null);
		}

		// RVA: 0x1CF5844 Offset: 0x1CF5844 VA: 0x1CF5844 Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}

		// RVA: 0x1CF5848 Offset: 0x1CF5848 VA: 0x1CF5848 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			return;
		}
	}
}
