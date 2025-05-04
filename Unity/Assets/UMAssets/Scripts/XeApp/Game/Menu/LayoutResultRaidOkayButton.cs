using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultRaidOkayButton : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public Action onClick; // 0x18
		private AbsoluteLayout layoutRoot; // 0x1C
		private ActionButton actionButton; // 0x20
		private bool isHelpButtonEnter; // 0x24

		// RVA: 0x1D0F294 Offset: 0x1D0F294 VA: 0x1D0F294
		private void Start()
		{
			return;
		}

		// RVA: 0x1D0F298 Offset: 0x1D0F298 VA: 0x1D0F298
		private void Update()
		{
			return;
		}

		// RVA: 0x1D0F29C Offset: 0x1D0F29C VA: 0x1D0F29C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_btn_in") as AbsoluteLayout;
			actionButton = transform.Find("sw_btn_in (AbsoluteLayout)/sw_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			actionButton.AddOnClickCallback(OnButtonClick);
			Loaded();
			return true;
		}

		// // RVA: 0x1D0F43C Offset: 0x1D0F43C VA: 0x1D0F43C
		public void SetupCallback(Action onFinished, Action onClick)
		{
			this.onFinished = onFinished;
			this.onClick = onClick;
		}

		// // RVA: 0x1D0F448 Offset: 0x1D0F448 VA: 0x1D0F448
		// public void CleanupCallback() { }

		// // RVA: 0x1D0F458 Offset: 0x1D0F458 VA: 0x1D0F458
		public void InitAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("st_wait");
			actionButton.enabled = false;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		// // RVA: 0x1D0F588 Offset: 0x1D0F588 VA: 0x1D0F588
		public void StartBeginAnim(bool showHelpButton/* = True*/)
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_PlayingAnim());
			if(showHelpButton)
				EnterHelpButton();
		}

		// // RVA: 0x1D0F800 Offset: 0x1D0F800 VA: 0x1D0F800
		// public void StartEndAnim() { }

		// // RVA: 0x1D0F88C Offset: 0x1D0F88C VA: 0x1D0F88C
		public void Hide()
		{
			layoutRoot.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1D0F90C Offset: 0x1D0F90C VA: 0x1D0F90C
		public void HideHelpButton()
		{
			MenuScene.Instance.HelpButton.HideResultHelpButton();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71D744 Offset: 0x71D744 VA: 0x71D744
		// // RVA: 0x1D0F640 Offset: 0x1D0F640 VA: 0x1D0F640
		private IEnumerator Co_PlayingAnim()
		{
			//0x1D0FE10
			yield return new WaitWhile(() =>
			{
				//0x1D0FDE0
				return layoutRoot.IsPlayingChildren();
			});
			OnAnimationFinished();
		}

		// // RVA: 0x1D0F9E8 Offset: 0x1D0F9E8 VA: 0x1D0F9E8
		public void SkipAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("st_in");
			actionButton.enabled = true;
			EnterHelpButton();
		}

		// // RVA: 0x1D0FA90 Offset: 0x1D0FA90 VA: 0x1D0FA90
		public void OnButtonClick()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClick != null)
			{
				onClick();
				MenuScene.Instance.HelpButton.HideResultHelpButton();
				isHelpButtonEnter = false;
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			}
		}

		// // RVA: 0x1D0FC48 Offset: 0x1D0FC48 VA: 0x1D0FC48
		private void OnBackButton()
		{
			if(!actionButton.enabled)
				return;
			if(actionButton.IsInputOff)
				return;
			actionButton.PerformClick();
		}

		// // RVA: 0x1D0FCCC Offset: 0x1D0FCCC VA: 0x1D0FCCC
		private void OnAnimationFinished()
		{
			actionButton.enabled = true;
			if(onFinished != null)
				onFinished();
			onFinished = null;
		}

		// // RVA: 0x1D0F6CC Offset: 0x1D0F6CC VA: 0x1D0F6CC
		private void EnterHelpButton()
		{
			if(isHelpButtonEnter)
				return;
			if(GameManager.Instance.IsTutorial)
				return;
			MenuScene.Instance.HelpButton.ShowRaidResultHelpButton();
			isHelpButtonEnter = true;
		}

		// // RVA: 0x1D0FD1C Offset: 0x1D0FD1C VA: 0x1D0FD1C
		// public void SetEnable(bool isEnable) { }
	}
}
