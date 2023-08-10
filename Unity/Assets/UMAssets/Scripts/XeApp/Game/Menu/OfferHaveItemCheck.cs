using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using mcrs;

namespace XeApp.Game.Menu
{
	public class OfferHaveItemCheck : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18

		// RVA: 0x18520A4 Offset: 0x18520A4 VA: 0x18520A4
		private void Start()
		{
			return;
		}

		// RVA: 0x18520A8 Offset: 0x18520A8 VA: 0x18520A8
		private void Update()
		{
			return;
		}

		//// RVA: 0x18520AC Offset: 0x18520AC VA: 0x18520AC
		//public void ButtonDisable() { }

		//// RVA: 0x18520DC Offset: 0x18520DC VA: 0x18520DC
		//public void ButtonEnable() { }

		// RVA: 0x185210C Offset: 0x185210C VA: 0x185210C
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1852198 Offset: 0x1852198 VA: 0x1852198
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1852224 Offset: 0x1852224 VA: 0x1852224
		//public void Hide() { }

		//// RVA: 0x18522A0 Offset: 0x18522A0 VA: 0x18522A0
		//public void Show() { }

		//// RVA: 0x185231C Offset: 0x185231C VA: 0x185231C
		//public bool IsPlaying() { }

		// RVA: 0x1852348 Offset: 0x1852348 VA: 0x1852348 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_item_sw_btn_shoji_anim") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x18525AC
				GameManager.Instance.CloseSnsNotice();
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				MenuScene.Instance.ShowItemListWindow(0, true);
			});
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
