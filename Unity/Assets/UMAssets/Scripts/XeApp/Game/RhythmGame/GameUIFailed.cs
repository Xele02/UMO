using mcrs;
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
			public SePlayInfo(ViewBase view, string labelName, int seNo, DivaVoicePlayer.VoiceCategory voiceNo)
			{
				this.view = view;
				frame = view.FrameAnimation.SearchLabelFrame(labelName);
				this.seNo = seNo;
				this.voiceNo = voiceNo;
				isPlayed = false;
				m_cb_playvoice_game_failed = null;
			}

			//// RVA: 0x7FBC68 Offset: 0x7FBC68 VA: 0x7FBC68
			public void Reset()
			{
				isPlayed = false;
			}

			//// RVA: 0x7FBC74 Offset: 0x7FBC74 VA: 0x7FBC74
			public void Update()
			{
				if(isPlayed)
					return;
				if(frame <= view.FrameAnimation.FrameCount)
				{
					if(seNo > -1)
					{
						SoundManager.Instance.sePlayerGame.Play(seNo);
					}
					if(voiceNo != DivaVoicePlayer.VoiceCategory.None)
					{
						if(m_cb_playvoice_game_failed != null)
							m_cb_playvoice_game_failed();
					}
					isPlayed = true;
				}
			}
		}

		private AbsoluteLayout m_root; // 0x14
		private GameUIFailed.ANIM_TABLE m_anim = ANIM_TABLE.NONE; // 0x18
		private GameUIFailed.SePlayInfo failedSeInfo; // 0x1C
		private GameUIFailed.SePlayInfo[] retrySeInfo; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x68EB58 Offset: 0x68EB58 VA: 0x68EB58
		private Action failed_completed_event; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x68EB68 Offset: 0x68EB68 VA: 0x68EB68
		private Action retry_completed_event; // 0x3C

		//// RVA: 0xF753CC Offset: 0xF753CC VA: 0xF753CC
		private void Start()
		{
			return;
		}

		//// RVA: 0xF753D0 Offset: 0xF753D0 VA: 0xF753D0
		private void Update()
		{
			if(m_anim == ANIM_TABLE.RETRY)
			{
				if(!m_root.IsPlayingAll())
				{
					if(retry_completed_event != null)
						retry_completed_event();
					gameObject.SetActive(false);
					m_anim = ANIM_TABLE.NONE;
				}
				for(int i = 0; i < retrySeInfo.Length; i++)
				{
					retrySeInfo[i].Update();
				}
				return;
			}
			if(m_anim != ANIM_TABLE.FAILED)
				return;
			if(!m_root.IsPlayingAll())
			{
				if(failed_completed_event != null)
					failed_completed_event();
				m_anim = ANIM_TABLE.NONE;
			}
			failedSeInfo.Update();
		}

		//// RVA: 0xF7561C Offset: 0xF7561C VA: 0xF7561C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_root = layout.FindViewByExId("root_failed_failed") as AbsoluteLayout;
			Loaded();
			failedSeInfo = new SePlayInfo(m_root.GetView(0), "se_failed", (int)cs_se_game.SE_GAME_003, DivaVoicePlayer.VoiceCategory.GameFailed);
			retrySeInfo = new SePlayInfo[3];
			retrySeInfo[0] = new SePlayInfo(m_root.GetView(0), "se_retry3", (int)cs_se_game.SE_GAME_004, DivaVoicePlayer.VoiceCategory.None);
			retrySeInfo[1] = new SePlayInfo(m_root.GetView(0), "se_retry2", (int)cs_se_game.SE_GAME_004, DivaVoicePlayer.VoiceCategory.None);
			retrySeInfo[2] = new SePlayInfo(m_root.GetView(0), "se_retry1", (int)cs_se_game.SE_GAME_004, DivaVoicePlayer.VoiceCategory.None);
			return true;
		}

		//// RVA: 0xF759B0 Offset: 0xF759B0 VA: 0xF759B0
		//public void BeginFailedAnim() { }

		//// RVA: 0xF75A84 Offset: 0xF75A84 VA: 0xF75A84
		public void BeginRetryAnim()
		{
			m_root.StartAllAnimGoStop("go_act", "st_act");
			m_anim = ANIM_TABLE.RETRY;
			for(int i = 0; i < retrySeInfo.Length; i++)
			{
				retrySeInfo[i].Reset();
			}
		}

		//// RVA: 0xF75B84 Offset: 0xF75B84 VA: 0xF75B84
		public void ShowBlackCurtainOnly()
		{
			gameObject.SetActive(true);
			m_root.StartAllAnimGoStop("st_stop");
		}

		//// RVA: 0xF75C30 Offset: 0xF75C30 VA: 0xF75C30
		public void HideAll()
		{
			m_root.StartAllAnimGoStop("st_non");
		}

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
		public void CleanupRetryCompletedCallback()
		{
			retry_completed_event = null;
		}

		//// RVA: 0xF76124 Offset: 0xF76124 VA: 0xF76124
		public void AddRetryCompletedCallback(Action retry_completed_event)
		{
			this.retry_completed_event += retry_completed_event;
		}

		//// RVA: 0xF76128 Offset: 0xF76128 VA: 0xF76128
		public void SetCallback_PlayVoice_GameFailed(Action a_cb)
		{
			failedSeInfo.m_cb_playvoice_game_failed = a_cb;
		}
	}
}
