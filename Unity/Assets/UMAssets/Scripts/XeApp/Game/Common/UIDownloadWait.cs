using XeSys.Gfx;
using System;
using UnityEngine;

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
		// public bool IsReady { get; } 0x1CDD520

		// // RVA: 0x1CDD528 Offset: 0x1CDD528 VA: 0x1CDD528
		private void Update()
		{
			if(m_updater != null)
				m_updater();
		}

		// // RVA: 0x1CDD53C Offset: 0x1CDD53C VA: 0x1CDD53C
		// public void Begin() { }

		// // RVA: 0x1CDD738 Offset: 0x1CDD738 VA: 0x1CDD738
		// public void End() { }

		// // RVA: 0x1CDD770 Offset: 0x1CDD770 VA: 0x1CDD770
		// public void SetPer(float per) { }

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
			UnityEngine.Debug.LogWarning("TODO ChangeProgress");
		}

		// // RVA: 0x1CDD888 Offset: 0x1CDD888 VA: 0x1CDD888
		private void ChangeProgressForHighResolutionMode(float per)
		{
			UnityEngine.Debug.LogWarning("TODO ChangeProgressForHighResolutionMode");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7397E4 Offset: 0x7397E4 VA: 0x7397E4
		// // RVA: 0x1CDD6AC Offset: 0x1CDD6AC VA: 0x1CDD6AC
		// private IEnumerator WaitOneFrameCoroutine() { }

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
