using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopPassListElem : SwapScrollListContent
	{
		public ActionButton m_btn_bonus; // 0x20
		public RawImageEx m_image_frm_01; // 0x24
		public RawImageEx m_image_frm_03; // 0x28
		//[CompilerGeneratedAttribute] // RVA: 0x67737C Offset: 0x67737C VA: 0x67737C
		public UnityAction<bool> m_cb_bonus; // 0x2C
		private AbsoluteLayout m_anim_first; // 0x30
		private AbsoluteLayout m_anim_privacy_contract_btn; // 0x34
		private LayoutUGUIRuntime m_runtime; // 0x38
		private NHPDPKHMFEP.GGNEBJEIFCP m_plan; // 0x3C

		// RVA: 0xDECE30 Offset: 0xDECE30 VA: 0xDECE30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim_first = layout.FindViewById("sw_pop_pass_list") as AbsoluteLayout;
			m_anim_privacy_contract_btn = layout.FindViewById("swtbl_btn") as AbsoluteLayout;
			m_btn_bonus.AddOnClickCallback(OnPushBtnBonus);
			m_runtime = GetComponent<LayoutUGUIRuntime>();
			Loaded();
			return true;
		}

		// RVA: 0xDED010 Offset: 0xDED010 VA: 0xDED010
		public void Initialize(bool a_is_first, NHPDPKHMFEP.GGNEBJEIFCP a_plan)
		{
			m_plan = a_plan;
			if(a_plan == NHPDPKHMFEP.GGNEBJEIFCP.AJAHGGBMOJE_1)
			{
				m_anim_first.StartChildrenAnimGoStop(a_is_first ? "03" : "04");
			}
			else if (a_plan == NHPDPKHMFEP.GGNEBJEIFCP.CCAPCGPIIPF_0)
			{
				m_anim_first.StartChildrenAnimGoStop(a_is_first ? "01" : "02");
			}
		}

		// RVA: 0xDED0FC Offset: 0xDED0FC VA: 0xDED0FC
		public bool IsReady()
		{
			return IsLoaded() && m_runtime.IsReady;
		}

		//// RVA: 0xDED154 Offset: 0xDED154 VA: 0xDED154
		private void OnPushBtnBonus()
		{
			if (m_cb_bonus != null)
				m_cb_bonus(m_plan == NHPDPKHMFEP.GGNEBJEIFCP.AJAHGGBMOJE_1);
		}
	}
}
