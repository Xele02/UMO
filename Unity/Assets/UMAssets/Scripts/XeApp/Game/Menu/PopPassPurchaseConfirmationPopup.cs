using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopPassPurchaseConfirmationPopup : LayoutUGUIScriptBase
	{
		public enum Result
		{
			None = 0,
			Cancel = 1,
			Error = 2,
			Buy = 3,
			Close = 4,
		}

		[SerializeField]
		public ActionButton m_btn_agre; // 0x14
		[SerializeField]
		public ActionButton m_btn_buy; // 0x18
		[SerializeField]
		public ActionButton m_btn_cancel; // 0x1C
		[SerializeField]
		public ToggleButton m_btn_check; // 0x20
		[SerializeField]
		public Text m_text_title; // 0x24
		[SerializeField]
		public Text m_text_01; // 0x28
		[SerializeField]
		public Text m_text_02; // 0x2C
		[SerializeField]
		public Text m_text_03; // 0x30
		[SerializeField]
		public RawImageEx m_image_button; // 0x34
		private Rect[] m_uv_button; // 0x38
		private AbsoluteLayout m_anim_root; // 0x3C
		//[CompilerGeneratedAttribute] // RVA: 0x67752C Offset: 0x67752C VA: 0x67752C
		public UnityAction m_cb_agre; // 0x40
		//[CompilerGeneratedAttribute] // RVA: 0x67753C Offset: 0x67753C VA: 0x67753C
		public UnityAction m_cb_buy; // 0x44
		//[CompilerGeneratedAttribute] // RVA: 0x67754C Offset: 0x67754C VA: 0x67754C
		public UnityAction m_cb_cancel; // 0x48
		public Result m_result; // 0x50
		public NHPDPKHMFEP.GGNEBJEIFCP m_plan; // 0x54
		private LayoutUGUIRuntime m_runtime; // 0x58

		public Transform Parent { get; private set; } // 0x4C

		// RVA: 0xDEF040 Offset: 0xDEF040 VA: 0xDEF040 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim_root = layout.FindViewById("sw_pop_pass_agre_inout_anim") as AbsoluteLayout;
			m_btn_agre.AddOnClickCallback(OnPushBtnAgre);
			m_btn_buy.AddOnClickCallback(OnPushBtnBuy);
			m_btn_cancel.AddOnClickCallback(OnPushBtnCancel);
			m_btn_check.AddOnClickCallback(OnPushBtnCheck);
			m_anim_root.StartChildrenAnimGoStop("st_wait");
			m_runtime = GetComponent<LayoutUGUIRuntime>();
			m_uv_button = new Rect[2]
			{
				LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("pop_pass_btn_fnt_02")),
				LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("pop_pass_btn_fnt_10"))
			};
			Loaded();
			return true;
		}

		// RVA: 0xDEC40C Offset: 0xDEC40C VA: 0xDEC40C
		public void Initialize(NHPDPKHMFEP.GGNEBJEIFCP plan)
		{
			m_btn_check.SetOff();
			m_btn_buy.Disable = true;
			m_plan = plan;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false))
			{
				m_text_01.text = bk.GetMessageByLabel("pop_pass_popup_text03");
				m_text_02.text = bk.GetMessageByLabel("pop_pass_popup_text04");
				m_image_button.uvRect = m_uv_button[1];
				m_text_title.text = bk.GetMessageByLabel("pop_pass_update_popup_title");
			}
			else
			{
				if(plan == NHPDPKHMFEP.GGNEBJEIFCP.AJAHGGBMOJE_1)
				{
					m_text_01.text = bk.GetMessageByLabel("pop_pass_popup_text03");
					m_text_02.text = bk.GetMessageByLabel("pop_pass_popup_text02");
				}
				else if(plan == NHPDPKHMFEP.GGNEBJEIFCP.CCAPCGPIIPF_0)
				{
					m_text_01.text = bk.GetMessageByLabel("pop_pass_popup_text01");
					m_text_02.text = bk.GetMessageByLabel("pop_pass_popup_text02");
				}
				m_image_button.uvRect = m_uv_button[0];
				m_text_title.text = bk.GetMessageByLabel("pop_pass_popup_title");
			}
			m_text_03.text = bk.GetMessageByLabel("pop_pass_popup_check");
		}

		// RVA: 0xDE9C1C Offset: 0xDE9C1C VA: 0xDE9C1C
		public bool IsReady()
		{
			return IsLoaded() && m_runtime.IsReady;
		}

		//// RVA: 0xDE90A4 Offset: 0xDE90A4 VA: 0xDE90A4
		//public bool IsPlayingAnim() { }

		//// RVA: 0xDEF430 Offset: 0xDEF430 VA: 0xDEF430
		public void EnableButton(bool a_enable)
		{
			m_btn_buy.IsInputOff = !a_enable;
			m_btn_cancel.IsInputOff = !a_enable;
			m_btn_check.IsInputOff = !a_enable;
			m_btn_agre.IsInputOff = !a_enable;
		}

		//// RVA: 0xDE8F28 Offset: 0xDE8F28 VA: 0xDE8F28
		//public void Enter() { }

		//// RVA: 0xDE90D0 Offset: 0xDE90D0 VA: 0xDE90D0
		//public void Leave() { }

		//// RVA: 0xDEF4D8 Offset: 0xDEF4D8 VA: 0xDEF4D8
		private void OnPushBtnAgre()
		{
			TodoLogger.LogNotImplemented("OnPushBtnAgre");
		}

		//// RVA: 0xDEF8CC Offset: 0xDEF8CC VA: 0xDEF8CC
		private void OnPushBtnBuy()
		{
			TodoLogger.LogNotImplemented("OnPushBtnBuy");
		}

		//// RVA: 0xDEFAA4 Offset: 0xDEFAA4 VA: 0xDEFAA4
		private void OnPushBtnCancel()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
			EnableButton(false);
			m_result = Result.Cancel;
			if (m_cb_cancel != null)
				m_cb_cancel();
		}

		//// RVA: 0xDEFB28 Offset: 0xDEFB28 VA: 0xDEFB28
		private void OnPushBtnCheck()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_btn_buy.Disable = !m_btn_check.IsOn;
		}

		//// RVA: 0xDEFBD4 Offset: 0xDEFBD4 VA: 0xDEFBD4
		//private void OnBackButton() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7001AC Offset: 0x7001AC VA: 0x7001AC
		//// RVA: 0xDEFC58 Offset: 0xDEFC58 VA: 0xDEFC58
		//private void <OnPushBtnAgre>b__35_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7001BC Offset: 0x7001BC VA: 0x7001BC
		//// RVA: 0xDEFC84 Offset: 0xDEFC84 VA: 0xDEFC84
		//private void <OnPushBtnBuy>b__36_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7001CC Offset: 0x7001CC VA: 0x7001CC
		//// RVA: 0xDEFC90 Offset: 0xDEFC90 VA: 0xDEFC90
		//private void <OnPushBtnBuy>b__36_1() { }

		//[CompilerGeneratedAttribute] // RVA: 0x7001DC Offset: 0x7001DC VA: 0x7001DC
		//// RVA: 0xDEFC9C Offset: 0xDEFC9C VA: 0xDEFC9C
		//private void <OnPushBtnBuy>b__36_2() { }
	}
}
