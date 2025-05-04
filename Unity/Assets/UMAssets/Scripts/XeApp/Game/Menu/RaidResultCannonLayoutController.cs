using System;
using System.Collections;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultCannonLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public GJMCHHCPFDL viewEventRaidDamageData; // 0x8
			public DAFGPCEKAJB viewEventRaidRankingData; // 0xC
		}

		private LayoutResultRaidOkayButton m_layoutOkayButton; // 0xC
		private LayoutResultRaidHeaderTitle m_layoutHeaderTitle; // 0x10
		private RaidResultDamageLayout m_damageLayout; // 0x14
		private RaidResultRankingLayout m_rankingLayout; // 0x18
		public Action onClickOkayButton; // 0x1C
		private bool m_isStarted; // 0x20
		private bool m_isSkiped; // 0x21

		// RVA: 0x1BDBBFC Offset: 0x1BDBBFC VA: 0x1BDBBFC
		private void Awake()
		{
			m_damageLayout = transform.Find("DamageLayout").GetComponent<RaidResultDamageLayout>();
			m_rankingLayout = transform.Find("RankingLayout").GetComponent<RaidResultRankingLayout>();
			m_layoutOkayButton = transform.Find("Okay").GetComponent<LayoutResultRaidOkayButton>();
			m_layoutHeaderTitle = transform.Find("Title").GetComponent<LayoutResultRaidHeaderTitle>();
		}

		// RVA: 0x1BDBDF8 Offset: 0x1BDBDF8 VA: 0x1BDBDF8
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// RVA: 0x1BDBE1C Offset: 0x1BDBE1C VA: 0x1BDBE1C
		public bool IsReady()
		{
			if(m_damageLayout != null && !m_damageLayout.IsLoaded())
				return false;
			if(m_rankingLayout != null && !m_rankingLayout.IsLoaded())
				return false;
			if(m_layoutOkayButton != null && !m_layoutOkayButton.IsLoaded())
				return false;
			if(m_layoutHeaderTitle != null && !m_layoutHeaderTitle.IsLoaded())
				return false;
			return true;
		}

		// RVA: 0x1BDC154 Offset: 0x1BDC154 VA: 0x1BDC154
		public void Setup(InitParam initParam)
		{
			m_layoutOkayButton.SetupCallback(null, onClickOkayButton);
			m_damageLayout.Setup(true, initParam.viewEventRaidDamageData);
			m_rankingLayout.Setup(initParam.viewEventRaidRankingData);
		}

		// // RVA: 0x1BDC6CC Offset: 0x1BDC6CC VA: 0x1BDC6CC
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F254 Offset: 0x71F254 VA: 0x71F254
		// // RVA: 0x1BDC6F0 Offset: 0x1BDC6F0 VA: 0x1BDC6F0
		private IEnumerator Co_StartAnim()
		{
			//0x1BDC954
			MenuScene.Instance.RaycastDisable();
			m_isStarted = true;
			m_layoutHeaderTitle.StartBeginAnim();
			m_damageLayout.StartBeginAnim();
			bool done = false;
			m_damageLayout.onFinished = () =>
			{
				//0x1BDC938
				done = true;
			};
			while(!done)
				yield return null;
			m_rankingLayout.StartBeginAnim();
			done = false;
			m_rankingLayout.onFinished = () =>
			{
				//0x1BDC944
				done = true;
			};
			while(!done)
				yield return null;
			m_layoutOkayButton.StartBeginAnim(true);
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x1BDC79C Offset: 0x1BDC79C VA: 0x1BDC79C
		// public void SetActive(bool active) { }

		// // RVA: 0x1BDC044 Offset: 0x1BDC044 VA: 0x1BDC044
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					m_damageLayout.SkipBeginAnim();
					m_rankingLayout.SkipBeginAnim();
					m_isSkiped = true;
				}
			}
		}

		// // RVA: 0x1BDC8B8 Offset: 0x1BDC8B8 VA: 0x1BDC8B8
		// private void OnClickOkayButton() { }
	}
}
