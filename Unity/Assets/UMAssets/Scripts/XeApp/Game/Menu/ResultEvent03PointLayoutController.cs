using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ResultEvent03PointLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public BKKMNPEEILG viewMyData; // 0x8
			public GJOOGLGLFID viewEventGameResultData; // 0xC
			public DCAKKIJODME viewEventExRivalResultData; // 0x10
			public LayoutResultOkayButton layoutOkayButton; // 0x14
		}

		private LayoutResultEvent03Point m_layoutResult; // 0xC
		private LayoutPopupExBattleScore m_layoutBattleScore; // 0x10
		private LayoutPopupExBattleScoreTotal m_layoutBattleScoreTotal; // 0x14
		private LayoutResultOkayButton layoutOkayButton; // 0x18
		public Action onClickOkayButton; // 0x1C
		private int m_lastExRivalIdx = -1; // 0x20
		private bool m_isStarted; // 0x24
		private bool m_isSkiped; // 0x25
		private bool m_isHighScore; // 0x26

		// RVA: 0xD03F50 Offset: 0xD03F50 VA: 0xD03F50
		private void Awake()
		{
			m_layoutResult = transform.Find("Event03Point").GetComponent<LayoutResultEvent03Point>();
			this.StartCoroutineWatched(Co_LoadLayout());
		}

		// RVA: 0xD040AC Offset: 0xD040AC VA: 0xD040AC
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// // RVA: 0xD040D0 Offset: 0xD040D0 VA: 0xD040D0
		public bool IsReady()
		{
			return m_layoutResult.IsLoaded();
		}

		// // RVA: 0xD041F4 Offset: 0xD041F4 VA: 0xD041F4
		public void Setup(InitParam initParam)
		{
			layoutOkayButton = initParam.layoutOkayButton;
			layoutOkayButton.SetupCallback(null, OnClickOkayButton);
			m_layoutResult.Setup(initParam.viewEventGameResultData, initParam.viewEventExRivalResultData.JNALKFEADEM());
            DCAKKIJODME viewExResultData = initParam.viewEventExRivalResultData;
            if (initParam.viewEventGameResultData.IDBJPDBLIIG_ScoreResultRank >= 3)
			{
				m_lastExRivalIdx = initParam.viewEventGameResultData.BOLHMCFBGBP_ExRivalIdx;
                EMGOCNMMPHC em = initParam.viewEventExRivalResultData.KLMPGMPHNOP(m_lastExRivalIdx);
                m_isHighScore = em.FFHMPNGJCLK_IsHighScore;
				if(m_isHighScore)
				{
					m_layoutBattleScore.Setup(em);
				}
				m_layoutBattleScoreTotal.SetUp(initParam.viewEventExRivalResultData, false);
				m_layoutResult.onClickButton = () =>
				{
					//0xD04DFC
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					m_layoutBattleScoreTotal.SetUp(viewExResultData, false);
					m_layoutBattleScoreTotal.OpenWindow(OpenPopupExBattleSchedule, (EMGOCNMMPHC view) =>
					{
						//0xD04FCC
						m_layoutBattleScore.Setup(view);
						m_layoutBattleScore.TryEnter(false);
					}, m_lastExRivalIdx);
				};
			}
		}

		// // RVA: 0xD04480 Offset: 0xD04480 VA: 0xD04480
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721A8C Offset: 0x721A8C VA: 0x721A8C
		// // RVA: 0xD044A4 Offset: 0xD044A4 VA: 0xD044A4
		private IEnumerator Co_StartAnim()
		{
			//0xD05D00
			MenuScene.Instance.RaycastDisable();
			m_isStarted = true;
			m_layoutResult.StartBeginAnim();
			m_layoutResult.onCheckScoreUpdate = Co_OpenPopupExHiScoreUpdate();
			bool done = false;
			m_layoutResult.onFinished = () =>
			{
				//0xD075C0
				done = true;
			};
			while(!done)
				yield return null;
			yield return Co.R(Co_OpenPopupGetReward());
			layoutOkayButton.StartBeginAnim(true);
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721B04 Offset: 0x721B04 VA: 0x721B04
		// // RVA: 0xD04550 Offset: 0xD04550 VA: 0xD04550
		private IEnumerator Co_OpenPopupExHiScoreUpdate()
		{
			//0xD05598
			if(m_isHighScore)
			{
				m_layoutBattleScoreTotal.OpenWindow(OpenPopupExBattleSchedule, (EMGOCNMMPHC view) =>
				{
					//0xD04AFC
					m_layoutBattleScore.Setup(view);
					m_layoutBattleScore.TryEnter(false);
				}, m_lastExRivalIdx);
				m_layoutBattleScore.TryEnter(true);
				yield return new WaitWhile(() =>
				{
					//0xD04B58
					return m_layoutBattleScoreTotal.IsShow;
				});
				yield return new WaitWhile(() =>
				{
					//0xD04B84
					return m_layoutBattleScore.IsShow;
				});
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721B7C Offset: 0x721B7C VA: 0x721B7C
		// // RVA: 0xD045FC Offset: 0xD045FC VA: 0xD045FC
		private IEnumerator Co_OpenPopupGetReward()
		{
			//0xD058A8
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
			if(ev != null)
			{
				if(ev.JOFBHHHLBBN.Count > 0)
				{
					bool closed = false;
					yield return Co.R(PopupRewardEvResult.Co_ShowPopup_CumulativePoint(transform, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xD0506C
						closed = true;
					}));
					yield return new WaitWhile(() =>
					{
						//0xD05078
						return !closed;
					});
					closed = false;
					yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.EventResult, () =>
					{
						//0xD0508C
						closed = true;
					}, false));
					yield return new WaitWhile(() =>
					{
						//0xD05098
						return !closed;
					});
				}
			}
		}

		// // RVA: 0xD046A8 Offset: 0xD046A8 VA: 0xD046A8
		private void OpenPopupExBattleSchedule()
		{
			m_layoutBattleScoreTotal.ButtonDisable();
			PopupExBattleScheduleSetting s = new PopupExBattleScheduleSetting();
			s.View = new CDDODEHEKGB();
			s.WindowSize = SizeType.Large;
			s.IsCaption = false;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xD04DF8
				return;
			}, null, null, () =>
			{
				//0xD04BB0
				m_layoutBattleScoreTotal.ButtonEnable();
			});
		}

		// // RVA: 0xD04A08 Offset: 0xD04A08 VA: 0xD04A08
		public void SetActive(bool active)
		{
			m_layoutResult.gameObject.SetActive(active);
		}

		// // RVA: 0xD040FC Offset: 0xD040FC VA: 0xD040FC
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(ResultScene.IsScreenTouch())
					{
						m_layoutResult.SkipBeginAnim();
						m_isSkiped = true;
					}
				}
			}
		}

		// // RVA: 0xD04A5C Offset: 0xD04A5C VA: 0xD04A5C
		private void OnClickOkayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickOkayButton != null)
				onClickOkayButton();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x721BF4 Offset: 0x721BF4 VA: 0x721BF4
		// // RVA: 0xD04020 Offset: 0xD04020 VA: 0xD04020
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName;// 0x14
			int bundleCount;// 0x18
			AssetBundleLoadLayoutOperationBase operation;// 0x1C
			FontInfo fontInfo;// 0x20

			//0xD050B0
			bundleName = new StringBuilder();
			bundleName.Set("ly/122.xab");
			bundleCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_ex_btl_win_scr_01_layout_root");
			yield return operation;
			fontInfo = GameManager.Instance.GetSystemFont();
			yield return operation.InitializeLayoutCoroutine(fontInfo, (GameObject instance) =>
			{
				//0xD04BDC
				instance.transform.SetParent(transform, false);
				m_layoutBattleScore = instance.GetComponent<LayoutPopupExBattleScore>();
			});
			bundleCount++;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_ex_btl_win_scr_02_layout_root");
			yield return operation;
			yield return operation.InitializeLayoutCoroutine(fontInfo, (GameObject instance) =>
			{
				//0xD04CAC
				instance.transform.SetParent(transform, false);
				m_layoutBattleScoreTotal = instance.GetComponent<LayoutPopupExBattleScoreTotal>();
			});
			bundleCount++;
			for(int i = 0; i < bundleCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}
	}
}
