using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomePlayRecordBanner : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68AAF8 Offset: 0x68AAF8 VA: 0x68AAF8
		private ButtonBase m_button; // 0xC
		//[HeaderAttribute] // RVA: 0x68AB40 Offset: 0x68AB40 VA: 0x68AB40
		[SerializeField]
		private InOutAnime m_inOutAnime; // 0x10
		//[HeaderAttribute] // RVA: 0x68AB88 Offset: 0x68AB88 VA: 0x68AB88
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x14
		private bool m_setup; // 0x1C

		public Action onClickButton { private get; set; } // 0x18

		//// RVA: 0xEB11BC Offset: 0xEB11BC VA: 0xEB11BC
		//public bool IsSetup() { }

		//// RVA: 0xEB11C4 Offset: 0xEB11C4 VA: 0xEB11C4
		//public bool IsAvailabilityPeriod(long mver) { }

		//// RVA: 0xEB12E0 Offset: 0xEB12E0 VA: 0xEB12E0
		//public void Setup() { }

		//// RVA: 0xEB13B0 Offset: 0xEB13B0 VA: 0xEB13B0
		//public void SetActive(bool active) { }

		//// RVA: 0xEB1488 Offset: 0xEB1488 VA: 0xEB1488
		//public void Enter() { }

		//// RVA: 0xEB14C8 Offset: 0xEB14C8 VA: 0xEB14C8
		//public void Enter(float animTime) { }

		//// RVA: 0xEB151C Offset: 0xEB151C VA: 0xEB151C
		//public void Leave() { }

		//// RVA: 0xEB155C Offset: 0xEB155C VA: 0xEB155C
		//public void Leave(float animTime) { }

		//// RVA: 0xEB15B0 Offset: 0xEB15B0 VA: 0xEB15B0
		//public bool IsPlaying() { }

		//[CompilerGeneratedAttribute] // RVA: 0x73D914 Offset: 0x73D914 VA: 0x73D914
		//// RVA: 0xEB15E4 Offset: 0xEB15E4 VA: 0xEB15E4
		//private void <Setup>b__10_0() { }
	}
}
