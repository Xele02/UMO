using System;
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
			TodoLogger.Log(0, "TODO GameUIComplete InitializeFromLayout");
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0xF709C8 Offset: 0xF709C8 VA: 0xF709C8
		//public void BeginCompleteAnim(RhythmGameConsts.ResultComboType type) { }

		//// RVA: 0xF749F8 Offset: 0xF749F8 VA: 0xF749F8
		//public void EndCompleteAnim() { }

		//// RVA: 0xF74A30 Offset: 0xF74A30 VA: 0xF74A30
		//private void UpdateIdle() { }

		//// RVA: 0xF74A34 Offset: 0xF74A34 VA: 0xF74A34
		//public void BeginCompleteAnimSimulate() { }

		//[IteratorStateMachineAttribute] // RVA: 0x746974 Offset: 0x746974 VA: 0x746974
		//								// RVA: 0xF74B88 Offset: 0xF74B88 VA: 0xF74B88
		//private IEnumerator Co_WaitComplateAnimeSimulate(float waitSec, UnityAction end) { }

		//// RVA: 0xF74C5C Offset: 0xF74C5C VA: 0xF74C5C
		//private void UpdateLeaveWait() { }

		//// RVA: 0xF74964 Offset: 0xF74964 VA: 0xF74964
		//private void PlayClearRankSe() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7469EC Offset: 0x7469EC VA: 0x7469EC
		//							 // RVA: 0xF74D20 Offset: 0xF74D20 VA: 0xF74D20
		//private void add_leave_completed_event(Action value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7469FC Offset: 0x7469FC VA: 0x7469FC
		//							 // RVA: 0xF74E2C Offset: 0xF74E2C VA: 0xF74E2C
		//private void remove_leave_completed_event(Action value) { }

		//// RVA: 0xF74F38 Offset: 0xF74F38 VA: 0xF74F38
		//public void CleanupLeaveCompletedCallback() { }

		//// RVA: 0xF75068 Offset: 0xF75068 VA: 0xF75068
		//public void AddLeaveCompletedCallback(Action callback) { }

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

		//[CompilerGeneratedAttribute] // RVA: 0x746A0C Offset: 0x746A0C VA: 0x746A0C
		//							 // RVA: 0xF751B8 Offset: 0xF751B8 VA: 0xF751B8
		//private void <BeginCompleteAnimSimulate>b__14_0() { }
	}
}
