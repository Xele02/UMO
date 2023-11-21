using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferMessageLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text MessageText; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18
		private AbsoluteLayout m_loopAnim; // 0x1C
		private bool IsNonInfomation; // 0x20

		// RVA: 0x1853D54 Offset: 0x1853D54 VA: 0x1853D54
		private void Start()
		{
			return;
		}

		// RVA: 0x1853D58 Offset: 0x1853D58 VA: 0x1853D58
		private void Update()
		{
			return;
		}

		// RVA: 0x1853D5C Offset: 0x1853D5C VA: 0x1853D5C
		public void SettingText(string text)
		{
			if (text == "")
			{
				IsNonInfomation = true;
				Hide();
			}
			else
				IsNonInfomation = false;
			MessageText.text = text;
		}

		// RVA: 0x1853E94 Offset: 0x1853E94 VA: 0x1853E94
		public void Enter()
		{
			if (IsNonInfomation)
				return;
			m_layoutRoot.StartAllAnimGoStop("go_in", "st_in");
			m_loopAnim.StartChildrenAnimLoop("lo_");
		}

		// RVA: 0x1853F5C Offset: 0x1853F5C VA: 0x1853F5C
		public void Leave()
		{
			if (IsNonInfomation)
				return;
			m_layoutRoot.StartAllAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1853E18 Offset: 0x1853E18 VA: 0x1853E18
		public void Hide()
		{
			m_layoutRoot.StartAllAnimGoStop("st_out");
		}

		//// RVA: 0x1853FF4 Offset: 0x1853FF4 VA: 0x1853FF4
		//public void Show() { }

		//// RVA: 0x1854070 Offset: 0x1854070 VA: 0x1854070
		//public bool IsPlaying() { }

		// RVA: 0x185409C Offset: 0x185409C VA: 0x185409C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_mes_layout_root") as AbsoluteLayout;
			m_loopAnim = layout.FindViewByExId("sw_s_v_mes_sw_s_v_win_fnt_01_lo") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
