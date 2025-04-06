using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	internal class LayoutResultGoDivaMain : MonoBehaviour
	{
		public class InitParam
		{
			public JLCHNKIHGHK viewEventResultData; // 0x8
			public LayoutResultOkayButton layoutOkayButton; // 0xC
			public LayoutResultEventHiScoreWindow layoutEventHiScoreWindow; // 0x10
		}

		public GoDivaPointResultLayoutController m_pointResultLayoutController; // 0xC
		public GoDivaGrowResultLayoutController m_growResultLayoutController; // 0x10
		public GoDivaResultBalloonLayoutController m_balloonLayoutController; // 0x14
		public Action onClickOkayLastButton; // 0x18
		private LayoutResultEventHiScoreWindow m_layoutEventHiScoreWindow; // 0x1C
		private LayoutResultOkayButton m_layoutOkayButton; // 0x20
		private JLCHNKIHGHK m_resultData; // 0x24

		// RVA: 0x18DCFF0 Offset: 0x18DCFF0 VA: 0x18DCFF0
		public void Setup(InitParam initParam)
		{
			m_resultData = initParam.viewEventResultData;
			m_pointResultLayoutController.Setup(m_resultData);
			m_pointResultLayoutController.onClickRankingButton = OnClickRankingButton;
			m_layoutEventHiScoreWindow = initParam.layoutEventHiScoreWindow;
			m_layoutOkayButton = initParam.layoutOkayButton;
			m_layoutOkayButton.onFinished = null;
			m_layoutOkayButton.onClick = OnClickOkayLastButton;
			m_balloonLayoutController.Setup();
			m_layoutEventHiScoreWindow.Setup(m_resultData);
		}

		// // RVA: 0x18DD180 Offset: 0x18DD180 VA: 0x18DD180
		public bool IsReady()
		{
			return m_pointResultLayoutController != null && m_growResultLayoutController != null && m_balloonLayoutController != null && 
				m_pointResultLayoutController.IsLoaded() && m_growResultLayoutController.IsLoaded() && m_balloonLayoutController.IsLoaded();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7172DC Offset: 0x7172DC VA: 0x7172DC
		// // RVA: 0x18DD31C Offset: 0x18DD31C VA: 0x18DD31C
		private IEnumerator Co_OpenPopupGetReward()
		{
            //0x18DDDFC
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
			if(ev != null)
			{
				if(ev.JOFBHHHLBBN.Count > 0)
				{
					bool closed = false;
					yield return Co.R(PopupRewardEvResult.Co_ShowPopup_CumulativePoint(transform, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0x18DD7E0
						closed = true;
					}));
					yield return new WaitWhile(() =>
					{
						//0x18DD7EC
						return !closed;
					});
					closed = false;
					yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.EventResult, () =>
					{
						//0x18DD800
						closed = true;
					}, false));
					yield return new WaitWhile(() =>
					{
						//0x18DD80C
						return !closed;
					});
				}
			}
        }

		// RVA: 0x18DD3C8 Offset: 0x18DD3C8 VA: 0x18DD3C8
		public bool IsLoading()
		{
			return !m_layoutEventHiScoreWindow.IsSetup() || !m_pointResultLayoutController.IsSetup();
		}

		// // RVA: 0x18DD428 Offset: 0x18DD428 VA: 0x18DD428
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717354 Offset: 0x717354 VA: 0x717354
		// // RVA: 0x18DD44C Offset: 0x18DD44C VA: 0x18DD44C
		private IEnumerator Co_StartAnim()
		{
			//0x18DE254
			bool isOkClick = false;
			m_layoutOkayButton.onFinished = null;
			m_layoutOkayButton.onClick = () =>
			{
				//0x18DD828
				isOkClick = true;
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			};
			m_growResultLayoutController.gameObject.SetActive(false);
			yield return Co.R(m_pointResultLayoutController.Co_BeginAnim());
			yield return new WaitForSeconds(0.5f);
			if(m_resultData.FPKGGEIMAFD_HasRanking)
			{
				if(m_resultData.FFHMPNGJCLK_NewRecode)
				{
					yield return Co.R(Co_OpenEventHiScoreWindow(1));
				}
			}
			yield return Co.R(Co_OpenPopupGetReward());
			m_layoutOkayButton.StartBeginAnim(true);
			yield return new WaitWhile(() =>
			{
				//0x18DD888
				return !isOkClick;
			});
			m_layoutOkayButton.StartEndAnim();
			m_pointResultLayoutController.EndAnim();
			GameManager.Instance.fullscreenFader.Fade(0.2f, Color.white);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			m_growResultLayoutController.gameObject.SetActive(true);
			m_growResultLayoutController.Setup(m_resultData, m_balloonLayoutController);
			yield return new WaitWhile(() =>
			{
				//0x18DD89C
				return !m_growResultLayoutController.IsSetup();
			});
			GameManager.Instance.fullscreenFader.Fade(0.2f, 0);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			yield return Co.R(m_growResultLayoutController.Co_BeginAnim());
			yield return new WaitForSeconds(1);
			m_layoutOkayButton.StartBeginAnim(true);
			m_layoutOkayButton.onFinished = null;
			m_layoutOkayButton.onClick = OnClickOkayLastButton;
		}

		// // RVA: 0x18DD4F8 Offset: 0x18DD4F8 VA: 0x18DD4F8
		private void OnClickOkayLastButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_Exit());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7173CC Offset: 0x7173CC VA: 0x7173CC
		// // RVA: 0x18DD56C Offset: 0x18DD56C VA: 0x18DD56C
		private IEnumerator Co_Exit()
		{
			//0x18DD8E4
			GameManager.Instance.fullscreenFader.Fade(0.2f, Color.black);
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			yield return Co.R(m_growResultLayoutController.Release());
			if(onClickOkayLastButton != null)
				onClickOkayLastButton();
		}

		// // RVA: 0x18DD618 Offset: 0x18DD618 VA: 0x18DD618
		private void OnClickRankingButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_OpenEventHiScoreWindow(0));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717444 Offset: 0x717444 VA: 0x717444
		// // RVA: 0x18DD690 Offset: 0x18DD690 VA: 0x18DD690
		private IEnumerator Co_OpenEventHiScoreWindow(int a_open_se/* = 0*/)
		{
			//0x18DDBBC
			if(m_layoutEventHiScoreWindow != null)
			{
				m_layoutEventHiScoreWindow.transform.SetAsLastSibling();
				yield return Co.R(m_layoutEventHiScoreWindow.Co_PlayAnimOpen(a_open_se));
				while(m_layoutEventHiScoreWindow.IsOpen())
					yield return null;
				yield return null;
			}
		}

		// // RVA: 0x18DD758 Offset: 0x18DD758 VA: 0x18DD758
		// private void CallbackBtnClick_EventDetail() { }
	}
}
