using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutOfferFormationLock : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_conditionsTitleText; // 0x14
		[SerializeField]
		private Text m_conditionsText; // 0x18
		private bool IsEnable; // 0x1C
		private AbsoluteLayout m_layoutRoot; // 0x20

		// RVA: 0x15D45EC Offset: 0x15D45EC VA: 0x15D45EC
		private void Start()
		{
			return;
		}

		// RVA: 0x15D45F0 Offset: 0x15D45F0 VA: 0x15D45F0
		private void Update()
		{
			return;
		}

		// RVA: 0x15D45F4 Offset: 0x15D45F4 VA: 0x15D45F4
		public void SetText(string condition)
		{
			m_conditionsTitleText.text = condition;
		}

		// RVA: 0x15D4630 Offset: 0x15D4630 VA: 0x15D4630
		public void Enter()
		{
			IsEnable = true;
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x15D46C4 Offset: 0x15D46C4 VA: 0x15D46C4
		public void Leave()
		{
			if (!IsEnable)
				return;
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			IsEnable = false;
		}

		// RVA: 0x15D4764 Offset: 0x15D4764 VA: 0x15D4764
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_out");
		}

		//// RVA: 0x15D47E0 Offset: 0x15D47E0 VA: 0x15D47E0
		//public void Show() { }

		//// RVA: 0x15D485C Offset: 0x15D485C VA: 0x15D485C
		//public bool IsPlaying() { }

		// RVA: 0x15D4888 Offset: 0x15D4888 VA: 0x15D4888 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("sw_sel_vfo_terms_pop_sw_s_v_terms_window_anim") as AbsoluteLayout;
			m_conditionsText.text = MessageManager.Instance.GetMessage("menu", "offer_platoon_release_condition_title_text");
			return true;
		}
	}
}
