using XeSys.Gfx;
using System;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Common
{
	public class UIDownloadWait : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_download_frame_layout; // 0x18
		private NumberBase m_per_number; // 0x20
		private Action m_updater; // 0x24
		private const float DELAY_VALUE = 0.7f;
		private float m_ratio; // 0x28
		private float m_per; // 0x2C
		private bool m_isReady; // 0x30
		private Transform m_parent; // 0x34
		private WaitForEndOfFrame m_frameYilder = new WaitForEndOfFrame(); // 0x38

		public bool HighResolutionModeFlag { get; set; } // 0x1C
		public bool IsReady { get { return m_isReady; } } //0x1CDD520

		// // RVA: 0x1CDD528 Offset: 0x1CDD528 VA: 0x1CDD528
		private void Update()
		{
			if(m_updater != null)
				m_updater();
		}

		// // RVA: 0x1CDD53C Offset: 0x1CDD53C VA: 0x1CDD53C
		public void Begin()
		{
			if(!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			m_ratio = 0;
			m_per = 0;
			ChangeProgress(0);
			m_isReady = false;
			this.StartCoroutineWatched(WaitOneFrameCoroutine());
		}

		// // RVA: 0x1CDD738 Offset: 0x1CDD738 VA: 0x1CDD738
		public void End()
		{
			gameObject.SetActive(false);
		}

		// // RVA: 0x1CDD770 Offset: 0x1CDD770 VA: 0x1CDD770
		public void SetPer(float per)
		{
			m_per = per;
		}

		// // RVA: 0x1CDD778 Offset: 0x1CDD778 VA: 0x1CDD778
		private void UpdateLoad()
		{
			if(!m_per_number.IsLoaded())
				return;
			Loaded();
			gameObject.SetActive(false);
			m_updater = this.UpdateIdle;
		}

		// // RVA: 0x1CDD864 Offset: 0x1CDD864 VA: 0x1CDD864
		private void UpdateIdle()
		{ 
			if(HighResolutionModeFlag)
			{
				ChangeProgressForHighResolutionMode(m_per);
				return;
			}
			ChangeProgress((int)m_per);
		}

		// // RVA: 0x1CDD5E0 Offset: 0x1CDD5E0 VA: 0x1CDD5E0
		private void ChangeProgress(int per)
		{
			if(per < 100)
			{
				m_ratio += (per - m_ratio) * 0.7f;
			}
			else
			{
				m_ratio = 100;
			}
			int v = Mathf.RoundToInt(m_ratio);
			m_per_number.SetNumber(v * 100, 3);
			m_download_frame_layout.StartChildrenAnimGoStop(v, v);
		}

		// // RVA: 0x1CDD888 Offset: 0x1CDD888 VA: 0x1CDD888
		private void ChangeProgressForHighResolutionMode(float per)
		{
			TodoLogger.Log(5, "ChangeProgressForHighResolutionMode");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7397E4 Offset: 0x7397E4 VA: 0x7397E4
		// // RVA: 0x1CDD6AC Offset: 0x1CDD6AC VA: 0x1CDD6AC
		private IEnumerator WaitOneFrameCoroutine()
		{
			//0x1CDDC64
			if(m_parent == null)
				m_parent = transform.parent;
			transform.SetParent(null, false);
			yield return m_frameYilder;
			transform.SetParent(m_parent, false);
			m_isReady = true;
		}

		// // RVA: 0x1CDD9C8 Offset: 0x1CDD9C8 VA: 0x1CDD9C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewByExId("root_cmn_load_down_layout_root") as AbsoluteLayout;
			m_download_frame_layout = layout.FindViewByExId("sw_cmn_load_down_swfrm_mask_bar_01_anim") as AbsoluteLayout;
			m_per_number = transform.Find("cmn_load_down (AbsoluteLayout)/cmn_load_down (AbsoluteLayout)/swnum_load_down_num (AbsoluteLayout)").GetComponent<NumberBase>();
			m_root.StartAllAnimLoop("logo_");
			m_updater = this.UpdateLoad;
			return true;
		}
	}
}
