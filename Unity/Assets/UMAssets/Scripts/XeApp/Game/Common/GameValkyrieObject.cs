using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Common
{
	public class GameValkyrieObject : ValkyrieObject
	{
		// Fields
		protected static readonly int EnterStateHash; // 0x0
		protected static readonly int MainStateHash; // 0x4
		protected static readonly int DamageStateHash; // 0x8
		protected static readonly int TransformStateHash; // 0xC
		protected static readonly int BattroidMainStateHash; // 0x10
		protected static readonly int BattroidDamageStateHash; // 0x14
		protected static readonly int EndStateHash; // 0x18
		protected static readonly int TransformParamStateHash; // 0x1C
		private double m_animationBaseTime; // 0x40
		private bool m_resetAnimationBaseTime; // 0x48
		private bool m_isPause; // 0x49
		private Coroutine m_coWaitDamageEnd; // 0x4C
		// [CompilerGeneratedAttribute] // RVA: 0x687E2C Offset: 0x687E2C VA: 0x687E2C
		// private bool <isDamage>k__BackingField; // 0x50
		// [CompilerGeneratedAttribute] // RVA: 0x687E3C Offset: 0x687E3C VA: 0x687E3C
		// private bool <isShootLock>k__BackingField; // 0x51
		// [CompilerGeneratedAttribute] // RVA: 0x687E4C Offset: 0x687E4C VA: 0x687E4C
		// private bool <isShootTiming>k__BackingField; // 0x52
		// [CompilerGeneratedAttribute] // RVA: 0x687E5C Offset: 0x687E5C VA: 0x687E5C
		// private bool <isShooting>k__BackingField; // 0x53
		// [CompilerGeneratedAttribute] // RVA: 0x687E6C Offset: 0x687E6C VA: 0x687E6C
		// private bool <isTransforming>k__BackingField; // 0x54
		private Func<string> m_getHitEffectName; // 0x58
		private bool m_shootOnlyOnce; // 0x5C
		private bool m_isShooted; // 0x5D

		// Properties
		protected override bool usingEffectFactory { get; }
		protected override bool usingQualitySetting { get; }
		private bool isDamage { get; set; }
		public bool isShootLock { get; set; }
		private bool isShootTiming { get; set; }
		private bool isShooting { get; set; }
		private bool isTransforming { get; set; }

		// Methods

		// // RVA: 0xEA07B8 Offset: 0xEA07B8 VA: 0xEA07B8 Slot: 4
		// protected override bool get_usingEffectFactory() { }

		// // RVA: 0xEA07C0 Offset: 0xEA07C0 VA: 0xEA07C0 Slot: 5
		// protected override bool get_usingQualitySetting() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73BFF0 Offset: 0x73BFF0 VA: 0x73BFF0
		// // RVA: 0xEA07C8 Offset: 0xEA07C8 VA: 0xEA07C8
		// private bool get_isDamage() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C000 Offset: 0x73C000 VA: 0x73C000
		// // RVA: 0xEA07D0 Offset: 0xEA07D0 VA: 0xEA07D0
		// private void set_isDamage(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C010 Offset: 0x73C010 VA: 0x73C010
		// // RVA: 0xEA07D8 Offset: 0xEA07D8 VA: 0xEA07D8
		// public bool get_isShootLock() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C020 Offset: 0x73C020 VA: 0x73C020
		// // RVA: 0xEA07E0 Offset: 0xEA07E0 VA: 0xEA07E0
		// private void set_isShootLock(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C030 Offset: 0x73C030 VA: 0x73C030
		// // RVA: 0xEA07E8 Offset: 0xEA07E8 VA: 0xEA07E8
		// private bool get_isShootTiming() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C040 Offset: 0x73C040 VA: 0x73C040
		// // RVA: 0xEA07F0 Offset: 0xEA07F0 VA: 0xEA07F0
		// private void set_isShootTiming(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C050 Offset: 0x73C050 VA: 0x73C050
		// // RVA: 0xEA07F8 Offset: 0xEA07F8 VA: 0xEA07F8
		// private bool get_isShooting() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C060 Offset: 0x73C060 VA: 0x73C060
		// // RVA: 0xEA0800 Offset: 0xEA0800 VA: 0xEA0800
		// private void set_isShooting(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C070 Offset: 0x73C070 VA: 0x73C070
		// // RVA: 0xEA0808 Offset: 0xEA0808 VA: 0xEA0808
		// private bool get_isTransforming() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C080 Offset: 0x73C080 VA: 0x73C080
		// // RVA: 0xEA0810 Offset: 0xEA0810 VA: 0xEA0810
		// private void set_isTransforming(bool value) { }

		// // RVA: 0xEA0818 Offset: 0xEA0818 VA: 0xEA0818 Slot: 7
		// protected override void OnInitialize(ValkyrieResource resource) { }

		// // RVA: 0xEA0D40 Offset: 0xEA0D40 VA: 0xEA0D40 Slot: 8
		// protected override void OnRelease() { }

		// // RVA: 0xEA0D44 Offset: 0xEA0D44 VA: 0xEA0D44
		// public void ResetAnimationBaseTime() { }

		// // RVA: 0xEA0D50 Offset: 0xEA0D50 VA: 0xEA0D50
		// public void ChangeAnimationTime(double time) { }

		// // RVA: 0xEA0F64 Offset: 0xEA0F64 VA: 0xEA0F64
		// public void Pause() { }

		// // RVA: 0xEA1044 Offset: 0xEA1044 VA: 0xEA1044
		// public void Resume() { }

		// // RVA: 0xEA11C0 Offset: 0xEA11C0 VA: 0xEA11C0
		// public void StartEnterAnimation(bool isDebug) { }

		// // RVA: 0xEA1398 Offset: 0xEA1398 VA: 0xEA1398
		// public void StartMainAnimation() { }

		// // RVA: 0xEA146C Offset: 0xEA146C VA: 0xEA146C
		// public void StartLeaveAnimation() { }

		// // RVA: 0xEA157C Offset: 0xEA157C VA: 0xEA157C
		// public void StartTransformAnimation() { }

		// // RVA: 0xEA176C Offset: 0xEA176C VA: 0xEA176C
		// public void SetShootLock(bool isLock) { }

		// // RVA: 0xEA1760 Offset: 0xEA1760 VA: 0xEA1760
		// public void ForceShootStop() { }

		// // RVA: 0xEA1780 Offset: 0xEA1780 VA: 0xEA1780
		// private void OnShootStartEvent() { }

		// // RVA: 0xEA1774 Offset: 0xEA1774 VA: 0xEA1774
		// private void OnShootStopEvent() { }

		// // RVA: 0xEA178C Offset: 0xEA178C VA: 0xEA178C
		// private void OnShootSingleEvent() { }

		// // RVA: 0xEA112C Offset: 0xEA112C VA: 0xEA112C
		// private void CheckShootAction() { }

		// // RVA: 0xEA1790 Offset: 0xEA1790 VA: 0xEA1790
		// private void CheckSingleShoot() { }

		// // RVA: 0xEA1834 Offset: 0xEA1834 VA: 0xEA1834
		// private void ShootStart() { }

		// // RVA: 0xEA1B94 Offset: 0xEA1B94 VA: 0xEA1B94
		// private void ShootStop() { }

		// // RVA: 0xEA1CFC Offset: 0xEA1CFC VA: 0xEA1CFC
		// public string GetHitEffectName() { }

		// // RVA: 0xEA1D74 Offset: 0xEA1D74 VA: 0xEA1D74
		// public void DamageStart() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73C090 Offset: 0x73C090 VA: 0x73C090
		// // RVA: 0xEA1F8C Offset: 0xEA1F8C VA: 0xEA1F8C
		// private IEnumerator Co_WaitDamageEffectProcess() { }

		// // RVA: 0xEA2038 Offset: 0xEA2038 VA: 0xEA2038
		// public void DamageStop() { }

		// // RVA: 0xEA20F4 Offset: 0xEA20F4 VA: 0xEA20F4
		// public void SetOverrideAnimationIntro(MusicIntroResource a_resource) { }

		// // RVA: 0xEA22BC Offset: 0xEA22BC VA: 0xEA22BC
		// public void .ctor() { }

		// // RVA: 0xEA2354 Offset: 0xEA2354 VA: 0xEA2354
		// private static void .cctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C108 Offset: 0x73C108 VA: 0x73C108
		// // RVA: 0xEA24C8 Offset: 0xEA24C8 VA: 0xEA24C8
		// private void <StartTransformAnimation>b__48_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73C118 Offset: 0x73C118 VA: 0x73C118
		// // RVA: 0xEA24D4 Offset: 0xEA24D4 VA: 0xEA24D4
		// private void <DamageStart>b__59_0() { }
	}
}
