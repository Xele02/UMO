using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ResultDropLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public MOLKENLNCPE_DropData viewDropResultData; // 0x8
			public EAJCBFGKKFA_FriendInfo viewFriendPlayerData; // 0xC
			public LayoutResultOkayButton layoutOkayButton; // 0x10
			public List<LayoutResultDropItem> layoutItemList; // 0x14
		}

		private LayoutResultDropMain layoutDropMain; // 0xC
		private LayoutResultDropFriendInfo layoutFriendInfo; // 0x10
		private LayoutResultOkayButton layoutOkayButton; // 0x14
		public Action onClickOkayButton; // 0x18
		public Action onClickSendFriendRequest; // 0x1C
		private bool isStarted; // 0x20
		private bool isSkiped; // 0x21
		private bool isEnableFriendInfo; // 0x22
		private List<Action> stepEndActionList = new List<Action>(); // 0x24
		private Coroutine coroutine; // 0x28

		// RVA: 0xD01244 Offset: 0xD01244 VA: 0xD01244
		private void Awake()
		{
			layoutDropMain = transform.Find("DropMain").GetComponent<LayoutResultDropMain>();
			layoutFriendInfo = transform.Find("FriendInfo").GetComponent<LayoutResultDropFriendInfo>();
		}

		// RVA: 0xD01368 Offset: 0xD01368 VA: 0xD01368
		private void Update()
		{
			if(!IsReady())
				return;
			CheckSkipStep();
		}

		// RVA: 0xD01524 Offset: 0xD01524 VA: 0xD01524
		private void OnDestroy()
		{
			layoutFriendInfo.Release();
		}

		// // RVA: 0xD0138C Offset: 0xD0138C VA: 0xD0138C
		public bool IsReady()
		{
			return layoutDropMain.IsLoaded() && layoutFriendInfo.IsLoaded();
		}

		// // RVA: 0xD01550 Offset: 0xD01550 VA: 0xD01550
		public void Setup(InitParam initParam)
		{
			layoutOkayButton = initParam.layoutOkayButton;
			layoutOkayButton.SetupCallback(OnFinishedOkayButton, OnClickOkayButton);
			for(int i = 0; i < initParam.layoutItemList.Count; i++)
			{
				initParam.layoutItemList[i].Setup(initParam.viewDropResultData.HBHMAKNGKFK[i], initParam.viewDropResultData.DCBDCHPKLCN_Rank != ResultScoreRank.Type.C);
			}
			isEnableFriendInfo = initParam.viewFriendPlayerData != null;
			layoutFriendInfo.Setup(initParam.viewFriendPlayerData);
			layoutDropMain.Setup(initParam.viewDropResultData, initParam.layoutItemList);
			layoutDropMain.onFinished = OnFinishedDropAnim;
			layoutFriendInfo.onFinished = OnFinishedFriendAnim;
			layoutFriendInfo.onClickSendFriendRequestCallback = OnClickSendFriendRequest;
		}

		// // RVA: 0xD018B0 Offset: 0xD018B0 VA: 0xD018B0
		public void StartAnim()
		{
			isStarted = true;
			layoutDropMain.StartBeginAnim();
			MenuScene.Instance.RaycastDisable();
		}

		// // RVA: 0xD01978 Offset: 0xD01978 VA: 0xD01978
		public void StartEndAnim(Action endAnimCallback)
		{
			layoutDropMain.StartEndAnim(endAnimCallback);
		}

		// // RVA: 0xD013E8 Offset: 0xD013E8 VA: 0xD013E8
		private void CheckSkipStep()
		{
			if(isStarted && !isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(ResultScene.IsScreenTouch())
					{
						if(!layoutDropMain.IsSkip)
							return;
						if(!layoutDropMain.IsOpenPopupRecordPlate())
						{
							StartCoroutine(CO_Skip());
						}
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721514 Offset: 0x721514 VA: 0x721514
		// // RVA: 0xD019AC Offset: 0xD019AC VA: 0xD019AC
		private IEnumerator CO_Skip()
		{
			TodoLogger.Log(0, "CO_Skip");
			yield return null;

		}

		// // RVA: 0xD01A58 Offset: 0xD01A58 VA: 0xD01A58
		// public void DisableFriendRequestButton() { }

		// // RVA: 0xD01A90 Offset: 0xD01A90 VA: 0xD01A90
		private void OnFinishedDropAnim()
		{
			if(!isEnableFriendInfo)
			{
				OnFinishedFriendAnim();
			}
			else
			{
				layoutFriendInfo.StartBeginAnim();
			}
		}

		// // RVA: 0xD01A94 Offset: 0xD01A94 VA: 0xD01A94
		// private void StartFriendInfoAnim() { }

		// // RVA: 0xD01AD0 Offset: 0xD01AD0 VA: 0xD01AD0
		private void OnFinishedFriendAnim()
		{
			layoutOkayButton.StartBeginAnim(true);
			isSkiped = true;
		}

		// // RVA: 0xD01B0C Offset: 0xD01B0C VA: 0xD01B0C
		private void OnFinishedOkayButton()
		{
			TodoLogger.Log(0, "OnFinishedOkayButton");
		}

		// // RVA: 0xD01B10 Offset: 0xD01B10 VA: 0xD01B10
		// private void StartPopupProcess() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72158C Offset: 0x72158C VA: 0x72158C
		// // RVA: 0xD01B48 Offset: 0xD01B48 VA: 0xD01B48
		// private IEnumerator Co_PopupProcess() { }

		// [IteratorStateMachineAttribute] // RVA: 0x721604 Offset: 0x721604 VA: 0x721604
		// // RVA: 0xD01BF4 Offset: 0xD01BF4 VA: 0xD01BF4
		// private IEnumerator ShowDropTutorialPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72167C Offset: 0x72167C VA: 0x72167C
		// // RVA: 0xD01CA0 Offset: 0xD01CA0 VA: 0xD01CA0
		// private IEnumerator ShowUnlockPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7216F4 Offset: 0x7216F4 VA: 0x7216F4
		// // RVA: 0xD01D4C Offset: 0xD01D4C VA: 0xD01D4C
		// private IEnumerator ShowReviewPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72176C Offset: 0x72176C VA: 0x72176C
		// // RVA: 0xD01DF8 Offset: 0xD01DF8 VA: 0xD01DF8
		// private IEnumerator ShowFoldRadarAnim() { }

		// // RVA: 0xD01EA4 Offset: 0xD01EA4 VA: 0xD01EA4
		private void OnClickOkayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
		}

		// // RVA: 0xD01F14 Offset: 0xD01F14 VA: 0xD01F14
		private void OnClickSendFriendRequest()
		{
			TodoLogger.LogNotImplemented("OnClickSendFriendRequest");
		}

		// // RVA: 0xD01F84 Offset: 0xD01F84 VA: 0xD01F84
		// private bool CheckTutorialCodition(TutorialConditionId conditionId) { }
	}
}
