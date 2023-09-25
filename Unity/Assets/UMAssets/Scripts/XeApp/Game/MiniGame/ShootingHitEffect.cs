using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingHitEffect : ShootingEffect
	{

		//// RVA: 0x1CFE970 Offset: 0x1CFE970 VA: 0x1CFE970 Slot: 19
		public override void Play(Transform trans)
		{
			base.Play(trans);
		}

		// RVA: 0x1CFE974 Offset: 0x1CFE974 VA: 0x1CFE974 Slot: 11
		public override void OnAwake()
		{
			OnSleep();
		}

		// RVA: 0x1CFE984 Offset: 0x1CFE984 VA: 0x1CFE984 Slot: 12
		public override void OnStart()
		{
			return;
		}

		// RVA: 0x1CFE988 Offset: 0x1CFE988 VA: 0x1CFE988 Slot: 13
		public override void Initialize()
		{
			OnSleep();
		}

		// RVA: 0x1CFE998 Offset: 0x1CFE998 VA: 0x1CFE998 Slot: 14
		public override void Pause()
		{
			m_spriteAnim.Stop(false);
		}

		// RVA: 0x1CFE99C Offset: 0x1CFE99C VA: 0x1CFE99C Slot: 15
		public override void UnPause()
		{
			m_spriteAnim.Play(m_spriteAnim.PlayIndex, null);
		}

		// RVA: 0x1CFE9A0 Offset: 0x1CFE9A0 VA: 0x1CFE9A0 Slot: 16
		public override void OnUpdate(float elapsedTime)
		{
			if (m_spriteAnim.IsPlaying())
				return;
			OnSleep();
		}

		// RVA: 0x1CFE9EC Offset: 0x1CFE9EC VA: 0x1CFE9EC Slot: 17
		public override void OnLateUpdate(float elapsedTime)
		{
			return;
		}
	}
}
