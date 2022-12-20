using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleEvaluateObject : PoolObject
	{
		[SerializeField]
		private Animator _animator; // 0x14
		private static readonly int[] AnimationHashTable = new int[4] { Animator.StringToHash("target_MISS"),
			Animator.StringToHash("HIT"), Animator.StringToHash("target_HITS"), Animator.StringToHash("target_CRITICAL")
		}; // 0x0

		// // RVA: 0x15592D0 Offset: 0x15592D0 VA: 0x15592D0
		public void SetValkyrieOffPriority()
		{
			UIPriority ps = GetComponent<UIPriority>();
			for(int i = 0; i < ps.m_meshPrioritySets.Length; i++)
			{
				ps.m_meshPrioritySets[i].priority = 0;
			}
		}

		// // RVA: 0x155968C Offset: 0x155968C VA: 0x155968C
		public void Play(int index)
		{
			_animator.Play(AnimationHashTable[index]);
		}

		// // RVA: 0x155978C Offset: 0x155978C VA: 0x155978C
		public bool IsPlaying()
		{
			return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
		}

		// RVA: 0x1559820 Offset: 0x1559820 VA: 0x1559820 Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0x1559824 Offset: 0x1559824 VA: 0x1559824 Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0x1559828 Offset: 0x1559828 VA: 0x1559828 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0x155982C Offset: 0x155982C VA: 0x155982C Slot: 8
		protected override void PausableInPause()
		{
			return;
		}
	}
}
