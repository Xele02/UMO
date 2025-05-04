using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

namespace XeApp.Game.Menu
{
	public class RaidMacrossCannonButton : LayoutUGUIScriptBase
	{
		public UnityAction OnClickMcrsButton; // 0x14
		[SerializeField]
		private ActionButton m_macrosCannonButton; // 0x18
		private bool m_isShow; // 0x1C
		private bool m_isShowCannon; // 0x1D
		private AbsoluteLayout m_rootAnim; // 0x20
		private AbsoluteLayout m_macrosCannonAnim; // 0x24
		private AbsoluteLayout m_macrosCannonLineAnim; // 0x28
		private int m_currentIndex; // 0x2C
		private int m_currentBossNum; // 0x30
		private int eventId; // 0x34

		// public int CurrentIndex { get; } 0x1BD1240

		// RVA: 0x1BD1248 Offset: 0x1BD1248 VA: 0x1BD1248 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_isShowCannon = false;
			m_rootAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_bc_anim_sw_raid_btn_mc_anim") as AbsoluteLayout;
			m_macrosCannonAnim = layout.FindViewByExId("sw_raid_btn_mc_all_anim_raid_btn_mc_01") as AbsoluteLayout;
			m_macrosCannonLineAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_bc_anim_swtbl_s_m_r_mcc_ef_06") as AbsoluteLayout;
			m_macrosCannonButton.AddOnClickCallback(OnClickMcrsCannonButton);
			return true;
		}

		// // RVA: 0x1BD1464 Offset: 0x1BD1464 VA: 0x1BD1464
		public void Initialize()
		{
			Hide();
			MCannonHide();
		}

		// // RVA: 0x1BD15E8 Offset: 0x1BD15E8 VA: 0x1BD15E8
		private void OnClickMcrsCannonButton()
		{
			if(OnClickMcrsButton != null)	
				OnClickMcrsButton();
		}

		// // RVA: 0x1BD15FC Offset: 0x1BD15FC VA: 0x1BD15FC
		public void DisableMcrsCannonLine(bool isDisable)
		{
			m_macrosCannonLineAnim.StartChildrenAnimGoStop(isDisable ? "02" : "01");
		}

		// // RVA: 0x1BD1690 Offset: 0x1BD1690 VA: 0x1BD1690
		public void Show()
		{
			m_isShow = true;
			m_rootAnim.StartSiblingAnimGoStop("st_in", "st_in");
		}

		// // RVA: 0x1BD1480 Offset: 0x1BD1480 VA: 0x1BD1480
		public void Hide()
		{
			m_isShow = false;
			m_isShowCannon = false;
			m_rootAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1BD1718 Offset: 0x1BD1718 VA: 0x1BD1718
		// public void Enter() { }

		// // RVA: 0x1BD17B8 Offset: 0x1BD17B8 VA: 0x1BD17B8
		public void Leave()
		{
			if(m_isShow)
			{
				m_rootAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
			m_isShowCannon = false;
		}

		// // RVA: 0x1BD1858 Offset: 0x1BD1858 VA: 0x1BD1858
		// public void MCannonShow() { }

		// // RVA: 0x1BD1508 Offset: 0x1BD1508 VA: 0x1BD1508
		public void MCannonHide()
		{
			m_isShowCannon = false;
			m_macrosCannonAnim.StartSiblingAnimGoStop("st_out", "st_out");
			this.StartCoroutineWatched(AnimEndCheck(m_macrosCannonAnim, () =>
			{
				//0x1BD1D9C
				Hide();
			}));
		}

		// // RVA: 0x1BD19E8 Offset: 0x1BD19E8 VA: 0x1BD19E8
		public void MCannonEnter()
		{
			if(!m_isShowCannon)
			{
				Show();
				m_macrosCannonAnim.StartSiblingAnimGoStop("go_in", "st_in");
				this.StartCoroutineWatched(AnimEndCheck(m_macrosCannonAnim, () =>
				{
					//0x1BD1DA0
					SoundManager.Instance.sePlayerRaidLoop.Play(2);
					MCannonLoopAnim();
				}));
			}
			m_isShowCannon = true;
		}

		// // RVA: 0x1BD1AE8 Offset: 0x1BD1AE8 VA: 0x1BD1AE8
		public void MCannonLeave()
		{
			if(m_isShowCannon)
			{
				m_macrosCannonAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShowCannon = false;
		}

		// // RVA: 0x1BD1B88 Offset: 0x1BD1B88 VA: 0x1BD1B88
		public void MCannonLoopAnim()
		{
			m_macrosCannonAnim.StartSiblingAnimLoop("logo_on", "loen_on");
		}

		// // RVA: 0x1BD1C14 Offset: 0x1BD1C14 VA: 0x1BD1C14
		// public void MCannonStopAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7123C4 Offset: 0x7123C4 VA: 0x7123C4
		// // RVA: 0x1BD1940 Offset: 0x1BD1940 VA: 0x1BD1940
		private IEnumerator AnimEndCheck(AbsoluteLayout layout, Action callback)
		{
			//0x1BD1E08
			while(layout.IsPlayingSibling())
				yield return null;
			callback();
		}

		// // RVA: 0x1BD1C60 Offset: 0x1BD1C60 VA: 0x1BD1C60
		public bool IsPlaying()
		{
			return m_rootAnim.IsPlayingSibling();
		}

		// RVA: 0x1BD1C8C Offset: 0x1BD1C8C VA: 0x1BD1C8C
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerRaidLoop.status != CriWare.CriAtomSource.Status.Playing)
				return;
			SoundManager.Instance.sePlayerRaidLoop.Stop();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71243C Offset: 0x71243C VA: 0x71243C
		// // RVA: 0x1BD1D38 Offset: 0x1BD1D38 VA: 0x1BD1D38
		// private void <MCannonShow>b__22_0() { }
	}
}
