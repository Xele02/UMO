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
	public class LayoutViewModeViewOff_Vertical_02 : LayoutModelViewModeBase
	{
		// Fields
		private RectTransform m_HitArea; // 0x24
		private Action m_Updater; // 0x28
		private GameObject m_ViewValkyrieModeObj; // 0x2C
		private bool m_IsWaitTransformation; // 0x30
		private bool m_IsTouchBegin; // 0x31
		private Vector3 m_TouchBeginPos = Vector3.zero; // 0x34
		private bool m_IsValkyrieTouch; // 0x40
		private List<LayoutUGUIHitOnly> m_list_hit = new List<LayoutUGUIHitOnly>(); // 0x44
		private List<Button> m_list_btn = new List<Button>(); // 0x48

		// RVA: 0x153C47C Offset: 0x153C47C VA: 0x153C47C Slot: 6
		protected override void OnInitializeFromLayout(Layout layout, TexUVListManager uvMan) 
		{
			m_list_hit.Clear();
			m_list_hit.AddRange(GetComponentsInChildren<LayoutUGUIHitOnly>(true));
			m_list_btn.Clear();
			m_list_btn.AddRange(GetComponentsInChildren<Button>(true));
		}

		// RVA: 0x153C5C0 Offset: 0x153C5C0 VA: 0x153C5C0
		public void Start()
		{
			m_Updater = UpdateInit;
		}

		// // RVA: 0x153C648 Offset: 0x153C648 VA: 0x153C648
		// public void Setup() { }

		// // RVA: 0x153C730 Offset: 0x153C730 VA: 0x153C730
		// public void Exit() { }

		// RVA: 0x153C740 Offset: 0x153C740 VA: 0x153C740
		public void Update()
		{
			if(m_Updater != null)
				m_Updater();
		}

		// // RVA: 0x153C754 Offset: 0x153C754 VA: 0x153C754
		private void UpdateInit()
		{
			if(!IsReady())
				return;
			m_HitArea = GetComponentsInChildren<Button>(true).Where((Button _) =>
			{
				//0x153D40C
				return _.name == "hit_check (AbsoluteLayout)";
			}).First().GetComponent<RectTransform>();
			base.Initialize("root_sel_val_btn_viewoff_vertical_02_sw_sel_val_btn_vertical_02_anim");
			m_Updater = UpdateIdle;
		}

		// // RVA: 0x153C970 Offset: 0x153C970 VA: 0x153C970
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

		// [IteratorStateMachineAttribute] // RVA: 0x733974 Offset: 0x733974 VA: 0x733974
		// // RVA: 0x153CB90 Offset: 0x153CB90 VA: 0x153CB90
		private IEnumerator Co_WaitTransformation()
		{
			//0x153D490
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

		// // RVA: 0x153CC3C Offset: 0x153CC3C VA: 0x153CC3C
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

		// RVA: 0x153CFB8 Offset: 0x153CFB8 VA: 0x153CFB8 Slot: 9
		public override void Enter()
		{
			base.Enter();
			SetEnableHit(true);
		}

		// RVA: 0x153CFE8 Offset: 0x153CFE8 VA: 0x153CFE8 Slot: 10
		public override void Leave()
		{
			base.Leave();
			SetEnableHit(false);
		}

		// RVA: 0x153D018 Offset: 0x153D018 VA: 0x153D018 Slot: 11
		public override void SetEnableHit(bool a_enable)
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
