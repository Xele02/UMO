using System;
using System.Collections;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultDamageLayoutController : MonoBehaviour
	{
		public class InitParam
		{
			public GJMCHHCPFDL viewEventRaidDamageData; // 0x8
			public FLCAECNBMML viewEventRaidPointData; // 0xC
		}

		private LayoutResultRaidOkayButton m_layoutOkayButton; // 0xC
		private LayoutResultRaidHeaderTitle m_layoutHeaderTitle; // 0x10
		private RaidResultDamageLayout m_damageLayout; // 0x14
		private RaidResultCannonLayout m_cannonLayout; // 0x18
		public Action onClickOkayButton; // 0x1C
		private JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH m_attackType; // 0x20
		private bool m_isStarted; // 0x24
		private bool m_isSkiped; // 0x25

		// RVA: 0x1BDE820 Offset: 0x1BDE820 VA: 0x1BDE820
		private void Awake()
		{
			m_damageLayout = transform.GetComponentInChildren<RaidResultDamageLayout>(true);
			m_cannonLayout = transform.GetComponentInChildren<RaidResultCannonLayout>(true);
			m_layoutOkayButton = transform.GetComponentInChildren<LayoutResultRaidOkayButton>(true);
			m_layoutHeaderTitle = transform.GetComponentInChildren<LayoutResultRaidHeaderTitle>(true);
		}

		// RVA: 0x1BDE96C Offset: 0x1BDE96C VA: 0x1BDE96C
		private void Update()
		{
			if(IsReady())
			{
				CheckSkipStep();
			}
		}

		// // RVA: 0x1BDE990 Offset: 0x1BDE990 VA: 0x1BDE990
		public bool IsReady()
		{
			return (m_damageLayout == null || m_damageLayout.IsLoaded()) && 
				(m_cannonLayout == null || m_cannonLayout.IsLoaded()) && 
				(m_layoutOkayButton == null || m_layoutOkayButton.IsLoaded()) && 
				(m_layoutHeaderTitle == null || m_layoutHeaderTitle.IsLoaded());
		}

		// // RVA: 0x1BDECC8 Offset: 0x1BDECC8 VA: 0x1BDECC8
		public void Setup(InitParam initParam)
		{
			m_layoutOkayButton.SetupCallback(null, onClickOkayButton);
			m_layoutHeaderTitle.StartBeginAnim();
			m_damageLayout.Setup(false, initParam.viewEventRaidDamageData);
			m_cannonLayout.Setup(initParam.viewEventRaidPointData);
		}

		// // RVA: 0x1BDED98 Offset: 0x1BDED98 VA: 0x1BDED98
		public void StartAnim()
		{
			this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F894 Offset: 0x71F894 VA: 0x71F894
		// // RVA: 0x1BDEDBC Offset: 0x1BDEDBC VA: 0x1BDEDBC
		private IEnumerator Co_StartAnim()
		{
			//0x1BDF078
			MenuScene.Instance.RaycastDisable();
			m_isStarted = true;
			m_damageLayout.StartBeginAnim();
			bool done = false;
			m_damageLayout.onFinished = () =>
			{
				//0x1BDF05C
				done = true;
			};
			while(!done)
				yield return null;
			m_cannonLayout.StartBeginAnim();
			done = false;
			m_cannonLayout.onFinished = () =>
			{
				//0x1BDF068
				done = true;
			};
			while(!done)
				yield return null;
			m_layoutOkayButton.StartBeginAnim(true);
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0x1BDEE68 Offset: 0x1BDEE68 VA: 0x1BDEE68
		// public void SetActive(bool active) { }

		// // RVA: 0x1BDEBB8 Offset: 0x1BDEBB8 VA: 0x1BDEBB8
		private void CheckSkipStep()
		{
			if(m_isStarted && !m_isSkiped)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				{
					m_damageLayout.SkipBeginAnim();
					m_cannonLayout.SkipBeginAnim();
					m_isSkiped = true;
				}
			}
		}

		// // RVA: 0x1BDEF04 Offset: 0x1BDEF04 VA: 0x1BDEF04
		// private void OnClickOkayButton() { }

		// // RVA: 0x1BDEF74 Offset: 0x1BDEF74 VA: 0x1BDEF74
		public void ChangeViewForResultDamage()
		{
			m_layoutHeaderTitle.gameObject.SetActive(true);
			m_layoutHeaderTitle.StartAlreadyAnim();
			m_layoutOkayButton.gameObject.SetActive(true);
			m_layoutOkayButton.InitAnim();
		}
	}
}
