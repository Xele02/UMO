using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferResultOkayLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_Button; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18

		// RVA: 0x1855DD8 Offset: 0x1855DD8 VA: 0x1855DD8
		private void Start()
		{
			return;
		}

		// RVA: 0x1855DDC Offset: 0x1855DDC VA: 0x1855DDC
		private void Update()
		{
			return;
		}

		// RVA: 0x1855DE0 Offset: 0x1855DE0 VA: 0x1855DE0
		public void SetOKButtonAction(Action act)
		{
			m_Button.AddOnClickCallback(() =>
			{
				//0x18561F8
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				act();
			});
		}

		// RVA: 0x1855EC8 Offset: 0x1855EC8 VA: 0x1855EC8
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1855F54 Offset: 0x1855F54 VA: 0x1855F54
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1855FE0 Offset: 0x1855FE0 VA: 0x1855FE0
		//public void Hide() { }

		//// RVA: 0x185605C Offset: 0x185605C VA: 0x185605C
		//public void Show() { }

		// RVA: 0x18560D8 Offset: 0x18560D8 VA: 0x18560D8
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlaying();
		}

		// RVA: 0x1856104 Offset: 0x1856104 VA: 0x1856104 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_layoutRoot = layout.FindViewByExId("root_btn_ok_sw_btn_in") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
