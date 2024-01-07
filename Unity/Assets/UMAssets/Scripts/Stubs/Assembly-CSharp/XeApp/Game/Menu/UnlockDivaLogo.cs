using System;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockDivaLogo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private Transform m_content; // 0x18
		private Transform m_mask; // 0x1C
		private Action mUpdater; // 0x20

		// RVA: 0x125F9A4 Offset: 0x125F9A4 VA: 0x125F9A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.Root[0] as AbsoluteLayout;
			m_mask = transform.GetComponentInChildren<Mask>(true).transform;
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x125FB20 Offset: 0x125FB20 VA: 0x125FB20
		private void Start()
		{
			return;
		}

		// RVA: 0x125FB24 Offset: 0x125FB24 VA: 0x125FB24
		private void Update()
		{
			if(mUpdater != null)
				mUpdater();
		}

		// // RVA: 0x125FB38 Offset: 0x125FB38 VA: 0x125FB38
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x125FBC0 Offset: 0x125FBC0 VA: 0x125FBC0
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x125FBC4 Offset: 0x125FBC4 VA: 0x125FBC4
		private void EnterWait()
		{
			if(IsPlaying())
				return;
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimLoop("logo_up", "loen_up");
			mUpdater = UpdateIdle;
		}

		// RVA: 0x125FD0C Offset: 0x125FD0C VA: 0x125FD0C
		public void Enter()
		{
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimGoStop("go_in", "st_in");
			mUpdater = EnterWait;
		}

		// RVA: 0x125FE18 Offset: 0x125FE18 VA: 0x125FE18
		public void Wait()
		{
			m_mask.gameObject.SetActive(false);
			m_abs.StartAllAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x125FCE0 Offset: 0x125FCE0 VA: 0x125FCE0
		public bool IsPlaying()
		{
			return m_abs.IsPlayingAll();
		}
	}
}
