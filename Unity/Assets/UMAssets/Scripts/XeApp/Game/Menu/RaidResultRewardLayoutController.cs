using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultRewardLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public PLFJMDBBAJD viewEventRaidRewardData; // 0x8
		}

		private LayoutResultRaidOkayButton m_layoutOkayButton; // 0xC
		private LayoutResultRaidHeaderTitle m_layoutHeaderTitle; // 0x10
		private RaidResultRewardFinishLayout m_finishLayout; // 0x14
		private RaidResultRewardBoxLayout m_boxLayout; // 0x18
		private RaidResultRewardItemLayout m_itemLayout; // 0x1C
		private RaidResultBossFilterLayout m_bossFilter; // 0x20
		public Action onClickOkayButton; // 0x24
		public Action onClickMemberListButton; // 0x28
		public Action startFinishAnim; // 0x2C
		public Action endFinishAnim; // 0x30
		private Coroutine m_coroutine; // 0x34
		private bool m_isStarted; // 0x38
		private bool m_isSkiped; // 0x39
		private bool m_raycastDisable; // 0x3A

		public RaidResultBossFilterLayout BossFilter { set { m_bossFilter = value; } } //0x1BE621C

		// RVA: 0x1BE6224 Offset: 0x1BE6224 VA: 0x1BE6224
		private void Awake()
		{
			m_finishLayout = transform.Find("FinishLayout").GetComponent<RaidResultRewardFinishLayout>();
			m_boxLayout = transform.Find("BoxLayout").GetComponent<RaidResultRewardBoxLayout>();
			m_itemLayout = transform.Find("ItemLayout").GetComponent<RaidResultRewardItemLayout>();
			m_layoutOkayButton = transform.Find("Okay").GetComponent<LayoutResultRaidOkayButton>();
			m_layoutHeaderTitle = transform.Find("Title").GetComponent<LayoutResultRaidHeaderTitle>();
		}

		// RVA: 0x1BE648C Offset: 0x1BE648C VA: 0x1BE648C
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// // RVA: 0x1BE64B0 Offset: 0x1BE64B0 VA: 0x1BE64B0
		public bool IsReady()
		{
			return (m_finishLayout == null || m_finishLayout.IsLoaded()) && 
				(m_itemLayout == null || m_itemLayout.IsLoaded()) && 
				(m_layoutOkayButton == null || m_layoutOkayButton.IsLoaded()) && 
				(m_layoutHeaderTitle == null || m_layoutHeaderTitle.IsLoaded());
		}

		// RVA: 0x1BE6958 Offset: 0x1BE6958 VA: 0x1BE6958
		public void SetupFromResult(InitParam initParam, RaidResultBossFilterLayout bossFilter)
		{
			m_layoutOkayButton.SetupCallback(null, onClickOkayButton);
			m_finishLayout.Setup();
			m_bossFilter = bossFilter;
			startFinishAnim = () =>
			{
				//0x1BE7010
				if(m_bossFilter != null)
					m_bossFilter.SetFilter(RaidResultBossFilterLayout.FilterType.None);
			};
			endFinishAnim = () =>
			{
				//0x1BE70C4
				if(m_bossFilter != null)
					m_bossFilter.SetFilter(RaidResultBossFilterLayout.FilterType.Blue);
			};
			m_boxLayout.Setup(initParam.viewEventRaidRewardData);
			m_itemLayout.Setup(initParam.viewEventRaidRewardData);
			m_itemLayout.onClickButton = OnClickMemberListButton;
			m_finishLayout.gameObject.SetActive(false);
			m_boxLayout.gameObject.SetActive(false);
			m_itemLayout.gameObject.SetActive(false);
			m_raycastDisable = false;
			m_isStarted = false;
			m_isSkiped = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72090C Offset: 0x72090C VA: 0x72090C
		// // RVA: 0x1BE6BE0 Offset: 0x1BE6BE0 VA: 0x1BE6BE0
		public IEnumerator Co_SetupFromRaid(InitParam initParam, RaidResultBossFilterLayout bossFilter)
		{
			//0x1BE7310
			m_layoutOkayButton.SetupCallback(null, onClickOkayButton);
			m_finishLayout.Setup();
			m_bossFilter = bossFilter;
			startFinishAnim = () =>
			{
				//0x1BE7178
				if(m_bossFilter != null)
					m_bossFilter.SetFilter(RaidResultBossFilterLayout.FilterType.None);
			};
			endFinishAnim = () =>
			{
				//0x1BE722C
				if(m_bossFilter != null)
					m_bossFilter.SetFilter(RaidResultBossFilterLayout.FilterType.Blue);
			};
			m_boxLayout.Setup(initParam.viewEventRaidRewardData);
			m_itemLayout.Setup(initParam.viewEventRaidRewardData);
			m_itemLayout.onClickButton = OnClickMemberListButton;
			yield return null;
			m_finishLayout.gameObject.SetActive(false);
			m_boxLayout.gameObject.SetActive(false);
			m_itemLayout.gameObject.SetActive(false);
			m_raycastDisable = false;
			m_isStarted = false;
			m_isSkiped = false;
			m_layoutOkayButton.Hide();
			m_layoutOkayButton.HideHelpButton();
		}

		// // RVA: 0x1BE6CC0 Offset: 0x1BE6CC0 VA: 0x1BE6CC0
		public void StartAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720984 Offset: 0x720984 VA: 0x720984
		// // RVA: 0x1BE6CE8 Offset: 0x1BE6CE8 VA: 0x1BE6CE8
		private IEnumerator Co_StartAnim()
		{
			//0x1811D8C
			MenuScene.Instance.RaycastDisable();
			m_raycastDisable = true;
			m_isStarted = true;
			bool done = false;
			if(startFinishAnim != null)
				startFinishAnim();
			m_finishLayout.gameObject.SetActive(true);
			m_finishLayout.onFinished = () =>
			{
				//0x1BE72E8
				done = true;
			};
			m_finishLayout.StartBeginAnim();
			while(!done)
				yield return null;
			m_finishLayout.gameObject.SetActive(false);
			if(endFinishAnim != null)
				endFinishAnim();
			done = false;
			m_boxLayout.gameObject.SetActive(true);
			m_boxLayout.onFinished = () =>
			{
				//0x1BE72F4
				done = true;
			};
			m_boxLayout.StartBeginAnim();
			while(!done)
				yield return null;
			done = false;
			m_itemLayout.gameObject.SetActive(true);
			m_itemLayout.onFinished = () =>
			{
				//0x1BE7300
				done = true;
			};
			m_itemLayout.StartBeginAnim();
			while(!done)
				yield return null;
			m_boxLayout.HideBox();
			m_layoutOkayButton.StartBeginAnim(true);
			MenuScene.Instance.RaycastEnable();
			m_raycastDisable = false;
		}

		// // RVA: 0x1BE6D70 Offset: 0x1BE6D70 VA: 0x1BE6D70
		// public void SetActive(bool active) { }

		// // RVA: 0x1BE66D8 Offset: 0x1BE66D8 VA: 0x1BE66D8
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					m_finishLayout.gameObject.SetActive(false);
					m_boxLayout.gameObject.SetActive(false);
					m_itemLayout.gameObject.SetActive(true);
					m_boxLayout.SkipBeginAnim();
					m_itemLayout.SkipBeginAnim();
					m_layoutOkayButton.SkipAnim();
					if(endFinishAnim != null)
						endFinishAnim();
					this.StopCoroutineWatched(m_coroutine);
					if(m_raycastDisable)
						MenuScene.Instance.RaycastEnable();
					m_isSkiped = true;
				}
			}
		}

		// // RVA: 0x1BE6E50 Offset: 0x1BE6E50 VA: 0x1BE6E50
		// private void OnClickOkayButton() { }

		// // RVA: 0x1BE6EC0 Offset: 0x1BE6EC0 VA: 0x1BE6EC0
		private void OnClickMemberListButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(onClickMemberListButton != null)
				onClickMemberListButton();
		}

		// // RVA: 0x1BE6F30 Offset: 0x1BE6F30 VA: 0x1BE6F30
		public void ChangeViewForReward()
		{
			m_layoutHeaderTitle.gameObject.SetActive(true);
			m_layoutHeaderTitle.StartAlreadyAnim();
			m_layoutOkayButton.gameObject.SetActive(true);
			m_layoutOkayButton.InitAnim();
		}
	}
}
