using mcrs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.RhythmGame
{
	public class GameUIComplete : LayoutLabelScriptBase
	{
		private RhythmGameConsts.ResultComboType m_clear_rank; // 0x18
		private Action m_updater; // 0x1C
		private LayoutSymbolData m_mainSymbol; // 0x20
		private LayoutSymbolData m_completeSymbol; // 0x24
		private LayoutSymbolData m_fullcomboSymbol; // 0x28
		private LayoutSymbolData m_pfullcomboSymbol; // 0x2C
		private LayoutSymbolData m_referenceSymbol; // 0x30
		private Action m_cb_playvoice_clear_fullcombo; // 0x34
		private Action m_cb_playvoice_clear_perfectfullcombo; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x68EB48 Offset: 0x68EB48 VA: 0x68EB48
		private Action leave_completed_event = () =>
		{
			//0xF75264
			return;
		}; // 0x3C

		//// RVA: 0xF74860 Offset: 0xF74860 VA: 0xF74860
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0xF74874 Offset: 0xF74874 VA: 0xF74874 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_mainSymbol = CreateSymbol("main", layout);
			m_completeSymbol = CreateSymbol("complete", layout);
			m_fullcomboSymbol = CreateSymbol("fullcombo", layout);
			m_pfullcomboSymbol = CreateSymbol("pfullcombo", layout);
			Loaded();
			return true;
		}

		//// RVA: 0xF709C8 Offset: 0xF709C8 VA: 0xF709C8
		public void BeginCompleteAnim(RhythmGameConsts.ResultComboType type)
		{
			gameObject.SetActive(true);
			if(type == RhythmGameConsts.ResultComboType.FullCombo)
			{
				m_mainSymbol.StartAnim("fullcombo");
				m_fullcomboSymbol.StartAnim("enter");
				m_referenceSymbol = m_fullcomboSymbol;
			}
			else if(type == RhythmGameConsts.ResultComboType.PerfectFullCombo)
			{
				m_mainSymbol.StartAnim("pfullcombo");
				m_pfullcomboSymbol.StartAnim("enter");
				m_referenceSymbol = m_pfullcomboSymbol;
			}
			else
			{
				m_mainSymbol.StartAnim("complete");
				m_completeSymbol.StartAnim("enter");
				m_referenceSymbol = m_completeSymbol;
			}
			m_clear_rank = type;
			PlayClearRankSe();
			m_updater = UpdateLeaveWait;
		}

		//// RVA: 0xF749F8 Offset: 0xF749F8 VA: 0xF749F8
		//public void EndCompleteAnim() { }

		//// RVA: 0xF74A30 Offset: 0xF74A30 VA: 0xF74A30
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xF74A34 Offset: 0xF74A34 VA: 0xF74A34
		public void BeginCompleteAnimSimulate()
		{
			gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_WaitComplateAnimeSimulate(m_completeSymbol.lyt.FrameAnimation.SearchLabelFrame("st_in") / 60.0f, () =>
			{
				//0xF751B8
				leave_completed_event();
			}));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x746974 Offset: 0x746974 VA: 0x746974
		//								// RVA: 0xF74B88 Offset: 0xF74B88 VA: 0xF74B88
		private IEnumerator Co_WaitComplateAnimeSimulate(float waitSec, UnityAction end)
		{
			//0xF7526C
			yield return new WaitForSeconds(waitSec);
			if(end != null)
				end();
		}

		//// RVA: 0xF74C5C Offset: 0xF74C5C VA: 0xF74C5C
		private void UpdateLeaveWait()
		{
			if(m_referenceSymbol != null)
			{
				if (m_referenceSymbol.IsPlaying())
					return;
			}
			leave_completed_event();
			m_updater = UpdateIdle;
		}

		//// RVA: 0xF74964 Offset: 0xF74964 VA: 0xF74964
		private void PlayClearRankSe()
		{
			int cueId = (int)cs_se_game.SE_GAME_002;
			if(m_clear_rank == RhythmGameConsts.ResultComboType.FullCombo)
			{
				if (m_cb_playvoice_clear_fullcombo != null)
					m_cb_playvoice_clear_fullcombo();
				cueId = (int)cs_se_game.SE_GAME_012;
			}
			else if(m_clear_rank == RhythmGameConsts.ResultComboType.PerfectFullCombo)
			{
				if (m_cb_playvoice_clear_perfectfullcombo != null)
					m_cb_playvoice_clear_perfectfullcombo();
				cueId = (int)cs_se_game.SE_GAME_010;
			}
			SoundManager.Instance.sePlayerGame.Play(cueId);
		}

		//[CompilerGeneratedAttribute] // RVA: 0x7469EC Offset: 0x7469EC VA: 0x7469EC
		//							 // RVA: 0xF74D20 Offset: 0xF74D20 VA: 0xF74D20
		//private void add_leave_completed_event(Action value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7469FC Offset: 0x7469FC VA: 0x7469FC
		//							 // RVA: 0xF74E2C Offset: 0xF74E2C VA: 0xF74E2C
		//private void remove_leave_completed_event(Action value) { }

		//// RVA: 0xF74F38 Offset: 0xF74F38 VA: 0xF74F38
		public void CleanupLeaveCompletedCallback()
		{
			leave_completed_event = () => {
				//0xF75260
				return;
			};
		}

		//// RVA: 0xF75068 Offset: 0xF75068 VA: 0xF75068
		public void AddLeaveCompletedCallback(Action callback)
		{
			leave_completed_event += callback;
		}

		//// RVA: 0xF7506C Offset: 0xF7506C VA: 0xF7506C
		public void SetCallback_PlayVoice_FullCombo(Action a_cb)
		{
			m_cb_playvoice_clear_fullcombo = a_cb;
		}

		//// RVA: 0xF75074 Offset: 0xF75074 VA: 0xF75074
		public void SetCallback_PlayVoice_PerfectFullCombo(Action a_cb)
		{
			m_cb_playvoice_clear_perfectfullcombo = a_cb;
		}
	}
}
