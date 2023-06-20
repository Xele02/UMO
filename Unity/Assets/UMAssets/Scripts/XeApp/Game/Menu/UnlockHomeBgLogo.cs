using System;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockHomeBgLogo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_abs; // 0x14
		private Transform m_content; // 0x18
		private Transform m_mask; // 0x1C
		private Action mUpdater; // 0x20

		// RVA: 0x16492EC Offset: 0x16492EC VA: 0x16492EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.Root[0] as AbsoluteLayout;
			m_mask = transform.GetComponentInChildren<Mask>(true).transform;
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0x1649468 Offset: 0x1649468 VA: 0x1649468
		private void Start()
		{
			return;
		}

		// RVA: 0x164946C Offset: 0x164946C VA: 0x164946C
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0x1649480 Offset: 0x1649480 VA: 0x1649480
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		//// RVA: 0x1649508 Offset: 0x1649508 VA: 0x1649508
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x164950C Offset: 0x164950C VA: 0x164950C
		private void EnterWait()
		{
			if (IsPlaying())
				return;
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimLoop("logo_up", "loen_up");
			mUpdater = UpdateIdle;
		}

		//// RVA: 0x1649654 Offset: 0x1649654 VA: 0x1649654
		public void Enter()
		{
			m_mask.gameObject.SetActive(true);
			m_abs.StartAllAnimGoStop("go_in", "st_in");
			mUpdater = EnterWait;
		}

		//// RVA: 0x1649760 Offset: 0x1649760 VA: 0x1649760
		//public void Wait() { }

		//// RVA: 0x1649628 Offset: 0x1649628 VA: 0x1649628
		public bool IsPlaying()
		{
			return m_abs.IsPlayingAll();
		}
	}
}
