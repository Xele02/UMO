using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ResultEvent01LayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public GCODMEIACDE viewEventResultData; // 0x8
			public LayoutResultOkayButton layoutOkayButton; // 0xC
		}

		private LayoutResultEvent01Main layoutMain; // 0xC
		private LayoutResultOkayButton layoutOkayButton; // 0x10
		public Action onClickOkayButton; // 0x14
		private bool isStarted; // 0x18
		private bool isSkiped; // 0x19
		private bool isReward; // 0x1A

		// RVA: 0xD03628 Offset: 0xD03628 VA: 0xD03628
		private void Awake()
		{
			layoutMain = transform.Find("Event01Main").GetComponent<LayoutResultEvent01Main>();
		}

		// RVA: 0xD036E0 Offset: 0xD036E0 VA: 0xD036E0
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// RVA: 0xD03704 Offset: 0xD03704 VA: 0xD03704
		public bool IsReady()
		{
			return layoutMain.IsLoaded();
		}

		// RVA: 0xD03878 Offset: 0xD03878 VA: 0xD03878
		public void Setup(InitParam initParam, LayoutResultEventHiScoreWindow a_window)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
            isReward = ev != null && ev.JOFBHHHLBBN_Rewards.Count > 0;
			layoutOkayButton = initParam.layoutOkayButton;
			layoutOkayButton.SetupCallback(null, OnClickOkayButton);
			layoutMain.m_layoutEventHiScoreWindow = a_window;
			layoutMain.Setup(initParam.viewEventResultData, isReward);
			layoutMain.m_OnOpenPopup = OnOpenPopup;
			layoutMain.m_OnFinished = OnFinishedAllAnim;
		}

		// // RVA: 0xD03AE4 Offset: 0xD03AE4 VA: 0xD03AE4
		// public void SetEventHiScoreWindow(LayoutResultEventHiScoreWindow a_window) { }

		// RVA: 0xD03AE8 Offset: 0xD03AE8 VA: 0xD03AE8
		public bool IsLoading()
		{
			return layoutMain.IsLoading();
		}

		// RVA: 0xD03B14 Offset: 0xD03B14 VA: 0xD03B14
		public void StartAnim()
		{
			isStarted = true;
			layoutMain.StartBeginAnim();
		}

		// // RVA: 0xD03730 Offset: 0xD03730 VA: 0xD03730
		private void CheckSkipStep()
		{
			if(isStarted && !isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					if(layoutMain.m_enable_skip)
					{
						layoutMain.SkipBeginAnim();
						if(!isReward)
						{
							layoutOkayButton.SkipAnim();
						}
						isSkiped = true;
					}
				}
			}
		}

		// // RVA: 0xD03B48 Offset: 0xD03B48 VA: 0xD03B48
		private void OnOpenPopup()
		{
			isSkiped = true;
		}

		// // RVA: 0xD03B54 Offset: 0xD03B54 VA: 0xD03B54
		private void OnFinishedAllAnim()
		{
			isSkiped = true;
			this.StartCoroutineWatched(Co_Finish());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7219C4 Offset: 0x7219C4 VA: 0x7219C4
		// // RVA: 0xD03B84 Offset: 0xD03B84 VA: 0xD03B84
		private IEnumerator Co_Finish()
		{
			//0xD03CD4
			if(isReward)
			{
				bool is_close = false;
				this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.EventResult, () =>
				{
					//0xD03CB0
					is_close = true;
				}, false));
				yield return new WaitWhile(() =>
				{
					//0xD03CBC
					return !is_close;
				});
			}
			layoutOkayButton.StartBeginAnim(true);
		}

		// // RVA: 0xD03C30 Offset: 0xD03C30 VA: 0xD03C30
		private void OnClickOkayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
		}
	}
}
