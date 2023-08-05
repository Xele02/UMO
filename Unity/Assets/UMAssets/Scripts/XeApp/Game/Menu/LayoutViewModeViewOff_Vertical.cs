using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutViewModeViewOff_Vertical : LayoutModelViewModeBase
	{
		private RectTransform m_HitArea; // 0x24
		private Action m_Updater; // 0x28
		private GameObject m_ViewValkyrieModeObj; // 0x2C
		private bool m_IsWaitTransformation; // 0x30
		private bool m_IsTouchBegin; // 0x31
		private Vector3 m_TouchBeginPos = Vector3.zero; // 0x34
		private bool m_IsValkyrieTouch; // 0x40
		private List<LayoutUGUIHitOnly> m_list_hit = new List<LayoutUGUIHitOnly>(); // 0x44
		private List<Button> m_list_btn = new List<Button>(); // 0x48

		// RVA: 0x153B1A4 Offset: 0x153B1A4 VA: 0x153B1A4 Slot: 6
		protected override void OnInitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_list_hit.Clear();
			m_list_hit.AddRange(GetComponentsInChildren<LayoutUGUIHitOnly>(true));
			m_list_btn.Clear();
			m_list_btn.AddRange(GetComponentsInChildren<Button>(true));
		}

		// RVA: 0x153B2E8 Offset: 0x153B2E8 VA: 0x153B2E8
		public void Start()
		{
			m_Updater = UpdateInit;
		}

		// // RVA: 0x153B370 Offset: 0x153B370 VA: 0x153B370
		// public void Setup() { }

		// // RVA: 0x153B458 Offset: 0x153B458 VA: 0x153B458
		// public void Exit() { }

		// RVA: 0x153B468 Offset: 0x153B468 VA: 0x153B468
		public void Update()
		{
			if(m_Updater != null)
				m_Updater();
		}

		// // RVA: 0x153B47C Offset: 0x153B47C VA: 0x153B47C
		private void UpdateInit()
		{
			if(!IsReady())
				return;
			m_HitArea = GetComponentsInChildren<Button>(true).Where((Button _) =>
			{
				//0x153C134
				return _.name == "hit_check (AbsoluteLayout)";
			}).First().GetComponent<RectTransform>();
			base.Initialize("root_sel_val_btn_viewoff_vertical_sw_sel_val_btn_vertical_anim");
			m_Updater = UpdateIdle;
		}

		// // RVA: 0x153B698 Offset: 0x153B698 VA: 0x153B698
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

		// [IteratorStateMachineAttribute] // RVA: 0x7338AC Offset: 0x7338AC VA: 0x7338AC
		// // RVA: 0x153B8B8 Offset: 0x153B8B8 VA: 0x153B8B8
		private IEnumerator Co_WaitTransformation()
		{
			//0x153C1B8
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

		// // RVA: 0x153B964 Offset: 0x153B964 VA: 0x153B964
		private void UpdateIdle()
		{
			if(m_IsValkyrieTouch)
			{
                TouchInfoRecord record = InputManager.Instance.GetFirstInScreenTouchRecord();
				if(record != null)
				{
					if(!record.currentInfo.isIllegal)
					{
						Canvas c  = GetComponentInParent<Canvas>();
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
										}
										m_IsTouchBegin = false;
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

		// RVA: 0x153BCE0 Offset: 0x153BCE0 VA: 0x153BCE0 Slot: 9
		public override void Enter()
		{
			base.Enter();
			SetEnableHit(true);
		}

		// RVA: 0x153BD10 Offset: 0x153BD10 VA: 0x153BD10 Slot: 10
		public override void Leave()
		{
			base.Leave();
			SetEnableHit(false);
		}

		// // RVA: 0x153BD40 Offset: 0x153BD40 VA: 0x153BD40 Slot: 12
		public virtual void SetEnableHit(bool a_enable)
		{
			foreach(var l in m_list_hit)
			{
				l.enabled = a_enable;
			}
			foreach(var b in m_list_btn)
			{
				b.enabled = a_enable;
			}
		}
	}
}
