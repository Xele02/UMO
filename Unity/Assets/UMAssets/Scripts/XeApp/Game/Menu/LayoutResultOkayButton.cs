using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultOkayButton : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public Action onClick; // 0x18
		private AbsoluteLayout layoutRoot; // 0x1C
		private ActionButton actionButton; // 0x20
		private bool isHelpButtonEnter; // 0x24

		// RVA: 0x18E49C0 Offset: 0x18E49C0 VA: 0x18E49C0
		private void Start()
		{
			return;
		}

		// RVA: 0x18E49C4 Offset: 0x18E49C4 VA: 0x18E49C4
		private void Update()
		{
			return;
		}

		// RVA: 0x18E49C8 Offset: 0x18E49C8 VA: 0x18E49C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_btn_in") as AbsoluteLayout;
			actionButton = transform.Find("sw_btn_in (AbsoluteLayout)/sw_btn_anim (AbsoluteLayout)").GetComponent<ActionButton>();
			actionButton.AddOnClickCallback(OnButtonClick);
			Loaded();
			return true;
		}

		//// RVA: 0x18DD174 Offset: 0x18DD174 VA: 0x18DD174
		public void SetupCallback(Action onFinished, Action onClick)
		{
			this.onFinished = onFinished;
			this.onClick = onClick;
		}

		//// RVA: 0x18E4B68 Offset: 0x18E4B68 VA: 0x18E4B68
		//public void CleanupCallback() { }

		//// RVA: 0x18E4B78 Offset: 0x18E4B78 VA: 0x18E4B78
		public void InitAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("st_wait");
			actionButton.enabled = false;
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		//// RVA: 0x18DEA8C Offset: 0x18DEA8C VA: 0x18DEA8C
		public void StartBeginAnim(bool showHelpButton/* = true*/)
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_PlayingAnim());
			if (showHelpButton)
				EnterHelpButton();
		}

		//// RVA: 0x18DEB44 Offset: 0x18DEB44 VA: 0x18DEB44
		public void StartEndAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71C6C4 Offset: 0x71C6C4 VA: 0x71C6C4
		//// RVA: 0x18E4CA8 Offset: 0x18E4CA8 VA: 0x18E4CA8
		private IEnumerator Co_PlayingAnim()
		{
			//0x18E5298
			yield return new WaitWhile(() =>
			{
				//0x18E5268
				return layoutRoot.IsPlayingChildren();
			});
			OnAnimationFinished();
		}

		//// RVA: 0x18E4E88 Offset: 0x18E4E88 VA: 0x18E4E88
		public void SkipAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("st_in");
			actionButton.enabled = true;
			EnterHelpButton();
		}

		//// RVA: 0x18E4F30 Offset: 0x18E4F30 VA: 0x18E4F30
		public void OnButtonClick()
		{
			if(onClick != null)
			{
				onClick();
				MenuScene.Instance.HelpButton.HideResultHelpButton();
				isHelpButtonEnter = false;
				GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			}
		}

		//// RVA: 0x18E509C Offset: 0x18E509C VA: 0x18E509C
		private void OnBackButton()
		{
			if(!actionButton.enabled)
				return;
			if(actionButton.IsInputOff)
				return;
			actionButton.PerformClick();
		}

		//// RVA: 0x18E5120 Offset: 0x18E5120 VA: 0x18E5120
		private void OnAnimationFinished()
		{
			actionButton.enabled = true;
			if (onFinished != null)
				onFinished();
		}

		//// RVA: 0x18E4D34 Offset: 0x18E4D34 VA: 0x18E4D34
		private void EnterHelpButton()
		{
			if (isHelpButtonEnter)
				return;
			if (GameManager.Instance.IsTutorial)
				return;
			MenuScene.Instance.HelpButton.ShowResultHelpButton();
			isHelpButtonEnter = true;
		}

		//// RVA: 0x18E5170 Offset: 0x18E5170 VA: 0x18E5170
		public void SetEnable(bool isEnable)
		{
			if(actionButton != null)
				actionButton.IsInputOff = !isEnable;
		}

		//// RVA: 0x18E522C Offset: 0x18E522C VA: 0x18E522C
		//public void SetDisable(bool isDisable) { }
	}
}
