using System;
using System.Collections;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultPointLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public FLCAECNBMML viewEventRaidPointData; // 0x8
			public DAFGPCEKAJB viewEventRaidRankingData; // 0xC
		}

		private LayoutResultRaidOkayButton m_layoutOkayButton; // 0xC
		private LayoutResultRaidHeaderTitle m_layoutHeaderTitle; // 0x10
		private RaidResultScoreLayout m_scoreLayout; // 0x14
		private RaidResultRankingLayout m_rankingLayout; // 0x18
		public Action onClickOkayButton; // 0x1C
		private bool m_isStarted; // 0x20
		private bool m_isSkiped; // 0x21

		// RVA: 0x1BDFAAC Offset: 0x1BDFAAC VA: 0x1BDFAAC
		private void Awake()
		{
			m_scoreLayout = transform.Find("ScoreLayout").GetComponent<RaidResultScoreLayout>();
			m_rankingLayout = transform.Find("RankingLayout").GetComponent<RaidResultRankingLayout>();
			m_layoutOkayButton = transform.Find("Okay").GetComponent<LayoutResultRaidOkayButton>();
			m_layoutHeaderTitle = transform.Find("Title").GetComponent<LayoutResultRaidHeaderTitle>();
		}

		// RVA: 0x1BDFCA8 Offset: 0x1BDFCA8 VA: 0x1BDFCA8
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// // RVA: 0x1BDFCCC Offset: 0x1BDFCCC VA: 0x1BDFCCC
		public bool IsReady()
		{
			return (m_scoreLayout == null || m_scoreLayout.IsLoaded()) && 
				(m_rankingLayout == null || m_rankingLayout.IsLoaded()) && 
				(m_layoutOkayButton == null || m_layoutOkayButton.IsLoaded()) && 
				(m_layoutHeaderTitle == null || m_layoutHeaderTitle.IsLoaded());
		}

		// // RVA: 0x1BE0008 Offset: 0x1BE0008 VA: 0x1BE0008
		public void Setup(InitParam initParam)
		{
			m_layoutOkayButton.SetupCallback(null, onClickOkayButton);
			m_layoutHeaderTitle.StartBeginAnim();
			m_scoreLayout.Setup(initParam.viewEventRaidPointData);
			m_rankingLayout.Setup(initParam.viewEventRaidRankingData);
		}

		// // RVA: 0x1BE00D8 Offset: 0x1BE00D8 VA: 0x1BE00D8
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71FAEC Offset: 0x71FAEC VA: 0x71FAEC
		// // RVA: 0x1BE00FC Offset: 0x1BE00FC VA: 0x1BE00FC
		private IEnumerator Co_StartAnim()
		{
			//0x1BE03B8
			MenuScene.Instance.RaycastDisable();
			m_isStarted = true;
			m_scoreLayout.StartBeginAnim();
			bool done = false;
			m_scoreLayout.onFinished = () =>
			{
				//0x1BE039C
				done = true;
			};
			while(!done)
				yield return null;
			m_rankingLayout.StartBeginAnim();
			done = false;
			m_rankingLayout.onFinished = () =>
			{
				//0x1BE03A8
				done = true;
			};
			while(!done)
				yield return null;
			m_layoutOkayButton.StartBeginAnim(true);
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x1BE01A8 Offset: 0x1BE01A8 VA: 0x1BE01A8
		// public void SetActive(bool active) { }

		// // RVA: 0x1BDFEF4 Offset: 0x1BDFEF4 VA: 0x1BDFEF4
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					m_scoreLayout.SkipBeginAnim();
					m_rankingLayout.SkipBeginAnim();
					m_isSkiped = true;
				}
			}
		}

		// // RVA: 0x1BE0244 Offset: 0x1BE0244 VA: 0x1BE0244
		// private void OnClickOkayButton() { }

		// // RVA: 0x1BE02B4 Offset: 0x1BE02B4 VA: 0x1BE02B4
		public void ChangeViewForResultPoint()
		{
			m_layoutHeaderTitle.gameObject.SetActive(true);
			m_layoutHeaderTitle.StartAlreadyAnim();
			m_layoutOkayButton.gameObject.SetActive(true);
			m_layoutOkayButton.InitAnim();
		}
	}
}
