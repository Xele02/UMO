using System;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockCostumeLogo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private Transform m_content; // 0x18
		private Transform m_mask; // 0x1C
		private Action mUpdater; // 0x20

		// RVA: 0x125641C Offset: 0x125641C VA: 0x125641C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_ul_logo_anim") as AbsoluteLayout;
			m_mask = transform.Find("sw_ul_logo_anim (AbsoluteLayout)/mask (MaskView)");
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x1256564 Offset: 0x1256564 VA: 0x1256564
		private void Start()
		{ 
			return;
		}

		// RVA: 0x1256568 Offset: 0x1256568 VA: 0x1256568
		private void Update()
		{
			if(mUpdater != null)
				mUpdater();
		}

		// // RVA: 0x125657C Offset: 0x125657C VA: 0x125657C
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x1256604 Offset: 0x1256604 VA: 0x1256604
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x1256608 Offset: 0x1256608 VA: 0x1256608
		private void EnterWait()
		{
			if(IsPlaying())
				return;
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimLoop("logo_up", "loen_up");
			mUpdater = UpdateIdle;
		}

		// RVA: 0x1256750 Offset: 0x1256750 VA: 0x1256750
		public void Enter()
		{
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimGoStop("go_in", "st_in");
			mUpdater = EnterWait;
		}

		// RVA: 0x125685C Offset: 0x125685C VA: 0x125685C
		public void Wait()
		{
			m_mask.gameObject.SetActive(false);
			m_abs.StartAllAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x1256724 Offset: 0x1256724 VA: 0x1256724
		public bool IsPlaying()
		{
			return m_abs.IsPlayingAll();
		}

		// // RVA: 0x1256920 Offset: 0x1256920 VA: 0x1256920
		public void SetVisible(bool visible)
		{
			m_abs.enabled = visible;
		}
	}
}
