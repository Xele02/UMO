using System;
using System.Collections.Generic;
using CriWare;
using mcrs;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionQuartzSet : GachaDirectionAnimSetBase
	{
		private static readonly int[] State_QuartzPaid = new int[10]
		{
			Animator.StringToHash("Quartz_01"),
			Animator.StringToHash("Quartz_02"),
			Animator.StringToHash("Quartz_03"),
			Animator.StringToHash("Quartz_04"),
			Animator.StringToHash("Quartz_05"),
			Animator.StringToHash("Quartz_06"),
			Animator.StringToHash("Quartz_07"),
			Animator.StringToHash("Quartz_08"),
			Animator.StringToHash("Quartz_09"),
			Animator.StringToHash("Quartz_10")
		}; // 0x0
		private static readonly int State_QuartzFree = Animator.StringToHash("Quartz_01"); // 0x4
		[SerializeField]
		private List<GachaDirectionStone.RefData> m_quartzRefData; // 0x18
		private int m_playState; // 0x1C
		private CriAtomExPlayback m_loopSePlayback; // 0x20

		// public int quartzRefDataNum { get; } 0x1C1DF38
		public Action onEndMainAnim { private get; set; } // 0x24

		// RVA: 0x1C1B420 Offset: 0x1C1B420 VA: 0x1C1B420
		public GachaDirectionStone.RefData GetQuartzRefData(int index)
		{
			return m_quartzRefData[index];
		}

		// // RVA: 0x1C1DFB8 Offset: 0x1C1DFB8 VA: 0x1C1DFB8 Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
			if(directionInfo.isPaid)
			{
				m_playState = State_QuartzPaid[directionInfo.cardNum - 1];
			}
			else
			{
				m_playState = State_QuartzFree;
			}
		}

		// // RVA: 0x1C1CAA8 Offset: 0x1C1CAA8 VA: 0x1C1CAA8
		public void Begin()
		{
			m_loopSePlayback = SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_005);
			gameObject.SetActive(true);
			animator.Play(m_playState, 0, 0);
			WaitForAnimationEnd(() =>
			{
				//0x1C1E44C
				if(onEndMainAnim != null)
					onEndMainAnim();
			});
		}

		// // RVA: 0x1C1CC28 Offset: 0x1C1CC28 VA: 0x1C1CC28
		public void End()
		{
			m_loopSePlayback.Stop();
			gameObject.SetActive(false);
		}
	}
}
