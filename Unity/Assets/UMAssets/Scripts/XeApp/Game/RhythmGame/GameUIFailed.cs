using System;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.RhythmGame
{
	public class GameUIFailed : LayoutUGUIScriptBase
	{
		private enum ANIM_TABLE
		{
			NONE = -1,
			FAILED = 0,
			RETRY = 1,
		}

		private struct SePlayInfo
		{
			private ViewBase view; // 0x0
			private float frame; // 0x4
			private int seNo; // 0x8
			private DivaVoicePlayer.VoiceCategory voiceNo; // 0xC
			private bool isPlayed; // 0x10
			public Action m_cb_playvoice_game_failed; // 0x14

			//// RVA: 0x7FBC44 Offset: 0x7FBC44 VA: 0x7FBC44
			//public void .ctor(ViewBase view, string labelName, int seNo, DivaVoicePlayer.VoiceCategory voiceNo) { }

			//// RVA: 0x7FBC68 Offset: 0x7FBC68 VA: 0x7FBC68
			//public void Reset() { }

			//// RVA: 0x7FBC74 Offset: 0x7FBC74 VA: 0x7FBC74
			//public void Update() { }
		}

		private AbsoluteLayout m_root; // 0x14
		private GameUIFailed.ANIM_TABLE m_anim = ANIM_TABLE.NONE; // 0x18
		private GameUIFailed.SePlayInfo failedSeInfo; // 0x1C
		private GameUIFailed.SePlayInfo[] retrySeInfo; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x68EB58 Offset: 0x68EB58 VA: 0x68EB58
		//private Action failed_completed_event; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x68EB68 Offset: 0x68EB68 VA: 0x68EB68
		//private Action retry_completed_event; // 0x3C

		//// RVA: 0xF753CC Offset: 0xF753CC VA: 0xF753CC
		private void Start()
		{
			return;
		}

		//// RVA: 0xF753D0 Offset: 0xF753D0 VA: 0xF753D0
		private void Update()
		{
			TodoLogger.Log(0, "GameUIFailed Update");
		}

		//// RVA: 0xF7561C Offset: 0xF7561C VA: 0xF7561C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "GameUIFailed InitializeFromLayout");
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0xF759B0 Offset: 0xF759B0 VA: 0xF759B0
		//public void BeginFailedAnim() { }

		//// RVA: 0xF75A84 Offset: 0xF75A84 VA: 0xF75A84
		//public void BeginRetryAnim() { }

		//// RVA: 0xF75B84 Offset: 0xF75B84 VA: 0xF75B84
		//public void ShowBlackCurtainOnly() { }

		//// RVA: 0xF75C30 Offset: 0xF75C30 VA: 0xF75C30
		//public void HideAll() { }

		//// RVA: 0xF75CAC Offset: 0xF75CAC VA: 0xF75CAC
		//public bool IsPlayingAnim() { }

		//[CompilerGeneratedAttribute] // RVA: 0x746A6C Offset: 0x746A6C VA: 0x746A6C
		//							 // RVA: 0xF75CD8 Offset: 0xF75CD8 VA: 0xF75CD8
		//private void add_failed_completed_event(Action value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x746A7C Offset: 0x746A7C VA: 0x746A7C
		//							 // RVA: 0xF75DE4 Offset: 0xF75DE4 VA: 0xF75DE4
		//private void remove_failed_completed_event(Action value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x746A8C Offset: 0x746A8C VA: 0x746A8C
		//							 // RVA: 0xF75EF0 Offset: 0xF75EF0 VA: 0xF75EF0
		//private void add_retry_completed_event(Action value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x746A9C Offset: 0x746A9C VA: 0x746A9C
		//							 // RVA: 0xF75FFC Offset: 0xF75FFC VA: 0xF75FFC
		//private void remove_retry_completed_event(Action value) { }

		//// RVA: 0xF76108 Offset: 0xF76108 VA: 0xF76108
		//public void CleanupFailedCompletedCallback() { }

		//// RVA: 0xF76114 Offset: 0xF76114 VA: 0xF76114
		//public void AddFailedCompletedCallback(Action failed_completed_event) { }

		//// RVA: 0xF76118 Offset: 0xF76118 VA: 0xF76118
		//public void CleanupRetryCompletedCallback() { }

		//// RVA: 0xF76124 Offset: 0xF76124 VA: 0xF76124
		//public void AddRetryCompletedCallback(Action retry_completed_event) { }

		//// RVA: 0xF76128 Offset: 0xF76128 VA: 0xF76128
		public void SetCallback_PlayVoice_GameFailed(Action a_cb)
		{
			failedSeInfo.m_cb_playvoice_game_failed = a_cb;
		}
	}
}