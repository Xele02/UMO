using System;
using System.Collections;
using System.Linq;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutViewModeViewOff : LayoutModelViewModeBase
	{
		private RectTransform m_HitArea; // 0x24
		private Action m_Updater; // 0x28
		private GameObject m_ViewValkyrieModeObj; // 0x2C
		private bool m_IsWaitTransformation; // 0x30
		private bool m_IsTouchBegin; // 0x31
		private Vector3 m_TouchBeginPos = Vector3.zero; // 0x34
		private bool m_IsValkyrieTouch; // 0x40

		// RVA: 0x153A344 Offset: 0x153A344 VA: 0x153A344
		public void Start()
		{
			m_Updater = UpdateInit;
		}

		// // RVA: 0x153A3CC Offset: 0x153A3CC VA: 0x153A3CC
		public void Setup()
		{
			m_ViewValkyrieModeObj = GameObject.Find("View Mode Valkyrie");
			m_IsWaitTransformation = false;
			m_IsTouchBegin = false;
			m_TouchBeginPos = Vector3.zero;
			m_Button.enabled = true;
			m_IsValkyrieTouch = true;
		}

		// // RVA: 0x153A4B4 Offset: 0x153A4B4 VA: 0x153A4B4
		public void Exit()
		{
			m_IsValkyrieTouch = false;
			this.StopAllCoroutinesWatched();
		}

		// RVA: 0x153A4C4 Offset: 0x153A4C4 VA: 0x153A4C4
		public void Update()
		{
			if(m_Updater != null)
				m_Updater();
		}

		// // RVA: 0x153A4D8 Offset: 0x153A4D8 VA: 0x153A4D8
		private void UpdateInit()
		{
			if(!IsReady())
				return;
			Button[] btns = GetComponentsInChildren<Button>(true);
			m_HitArea = btns.Where((Button _) =>
			{
				//0x153AE5C
				return _.name == "hit_check (AbsoluteLayout)";
			}).First().GetComponent<RectTransform>();
			base.Initialize("root_sel_val_btn_viewoff_sw_sel_val_btn_03");
			m_Updater = UpdateIdle;
		}

		// // RVA: 0x153A6F4 Offset: 0x153A6F4 VA: 0x153A6F4
		private void Transformation()
		{
			if(m_ViewValkyrieModeObj != null && !m_IsWaitTransformation)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					ViewScreenValkyrie v = m_ViewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
					if(v != null)
					{
						int form = v.GetFormType();
						form++;
						if(form > 2)
							form -= 3;
						v.ChangeFormType(form, true);
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
						this.StartCoroutineWatched(Co_WaitTransformation());
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7337E4 Offset: 0x7337E4 VA: 0x7337E4
		// // RVA: 0x153A914 Offset: 0x153A914 VA: 0x153A914
		private IEnumerator Co_WaitTransformation()
		{
			//0x153AEE0
			m_IsWaitTransformation = true;
			m_Button.enabled = false;
			float time = 0;
			if(m_ViewValkyrieModeObj != null)
			{
				ViewScreenValkyrie v = m_ViewValkyrieModeObj.GetComponent<ViewScreenValkyrie>();
				if(v != null)
				{
					time = v.GetChangeWaitTime();
				}
			}
			yield return new WaitForSeconds(time);
			m_Button.enabled = true;
			m_IsWaitTransformation = false;
		}

		// // RVA: 0x153A9C0 Offset: 0x153A9C0 VA: 0x153A9C0
		private void UpdateIdle()
		{
			if(m_IsValkyrieTouch)
			{
                TouchInfoRecord record = InputManager.Instance.GetFirstInScreenTouchRecord();
				if(record != null)
				{
					if (!record.currentInfo.isIllegal)
					{
						Canvas c = GetComponentInParent<Canvas>();
						if(c != null)
						{
							if(c.worldCamera != null)
							{
								if(RectTransformUtility.RectangleContainsScreenPoint(m_HitArea, record.currentInfo.nativePosition, c.worldCamera))
								{
									if(record.currentInfo.isBegan)
									{
										m_IsTouchBegin = true;
										m_TouchBeginPos = record.currentInfo.nativePosition;
									}
									else
									{
										if(record.currentInfo.isEnded && m_IsTouchBegin)
										{
											if(Vector3.Distance(m_TouchBeginPos, record.currentInfo.nativePosition) <= 10)
												Transformation();
											m_IsTouchBegin = false;
										}
									}
								}
								else
								{
									m_IsTouchBegin = false;
								}
							}
						}
					}
				}
			}
		}
	}
}
