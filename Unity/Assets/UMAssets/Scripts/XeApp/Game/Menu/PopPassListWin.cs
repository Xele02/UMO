using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.Events;
using System.Collections;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopPassListWin : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		[SerializeField]
		private ActionButton m_btn_law_1; // 0x18
		[SerializeField]
		private ActionButton m_btn_law_2; // 0x1C
		[SerializeField]
		private ActionButton m_btn_cancel; // 0x20
		[SerializeField]
		private ActionButton m_btn_buy; // 0x24
		[SerializeField]
		private ActionButton m_btn_agre; // 0x28
		[SerializeField]
		private Text m_text_title; // 0x2C
		[SerializeField]
		private Text m_text_money; // 0x30
		//[CompilerGeneratedAttribute] // RVA: 0x67740C Offset: 0x67740C VA: 0x67740C
		public UnityAction m_cb_law_1; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x67741C Offset: 0x67741C VA: 0x67741C
		public UnityAction m_cb_law_2; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x67742C Offset: 0x67742C VA: 0x67742C
		public UnityAction m_cb_cancel; // 0x3C
		//[CompilerGeneratedAttribute] // RVA: 0x67743C Offset: 0x67743C VA: 0x67743C
		public UnityAction m_cb_buy; // 0x40
		//[CompilerGeneratedAttribute] // RVA: 0x67744C Offset: 0x67744C VA: 0x67744C
		public UnityAction m_cb_agre; // 0x44
		//[CompilerGeneratedAttribute] // RVA: 0x67745C Offset: 0x67745C VA: 0x67745C
		public UnityAction<bool> m_cb_bonus; // 0x48
		//[CompilerGeneratedAttribute] // RVA: 0x67746C Offset: 0x67746C VA: 0x67746C
		public UnityAction m_cb_detail; // 0x4C
		//[CompilerGeneratedAttribute] // RVA: 0x67747C Offset: 0x67747C VA: 0x67747C
		public UnityAction m_cb_contract; // 0x50
		//[CompilerGeneratedAttribute] // RVA: 0x67748C Offset: 0x67748C VA: 0x67748C
		public UnityAction m_cb_privacy; // 0x54
		private PopPassListElem m_layout_content; // 0x58
		private PopPassListAbout m_layout_about; // 0x5C
		private AbsoluteLayout m_anim_root; // 0x60
		private LayoutUGUIRuntime m_runtime; // 0x64

		// RVA: 0xDEDB40 Offset: 0xDEDB40 VA: 0xDEDB40 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_anim_root = layout.FindViewById("sw_pop_pass_inout_anim") as AbsoluteLayout;
			m_btn_law_1.AddOnClickCallback(CB_Law1);
			m_btn_law_2.AddOnClickCallback(CB_Law2);
			m_btn_cancel.AddOnClickCallback(CB_Cancel);
			m_btn_buy.AddOnClickCallback(CB_Buy);
			m_btn_agre.AddOnClickCallback(CB_Agre);
			m_runtime = GetComponent<LayoutUGUIRuntime>();
			m_scrollRect.horizontal = false;
			m_scrollRect.vertical = true;
			m_scrollRect.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			m_anim_root.StartChildrenAnimGoStop("st_wait");
			Loaded();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700054 Offset: 0x700054 VA: 0x700054
		// RVA: 0xDE9B38 Offset: 0xDE9B38 VA: 0xDE9B38
		public IEnumerator Co_LoadListContent()
		{
			XeSys.FontInfo font; // 0x18
			string bundleName; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20

			//0xDEE258
			font = GameManager.Instance.GetSystemFont();
			bundleName = "ly/150.xab";
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_pass_list_layout_root");
			yield return lytOp;
			GameObject t_source = null;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xDEE244
				t_source = instance;
			}));
			m_layout_content = t_source.GetComponent<PopPassListElem>();
			m_layout_content.m_cb_bonus += CB_Bonus;
			m_layout_content.transform.SetParent(m_scrollRect.content.transform, false);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while(!m_layout_content.IsReady())
				yield return null;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName, "root_pop_pass_txt_layout_root");
			t_source = null;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0xDEE24C
				t_source = instance;
			}));
			m_layout_about = t_source.GetComponent<PopPassListAbout>();
			m_layout_about.transform.SetParent(m_scrollRect.content.transform, false);
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (!m_layout_about.IsReady())
				yield return null;
		}

		// RVA: 0xDEB844 Offset: 0xDEB844 VA: 0xDEB844
		public void Initialize(bool a_is_first, NHPDPKHMFEP.GGNEBJEIFCP a_plan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(a_plan == NHPDPKHMFEP.GGNEBJEIFCP.AJAHGGBMOJE_1)
			{
				m_text_title.text = bk.GetMessageByLabel("pop_pass_sp_title");
			}
			else if(a_plan == NHPDPKHMFEP.GGNEBJEIFCP.CCAPCGPIIPF_0)
			{
				m_text_title.text = bk.GetMessageByLabel("pop_pass_title");
			}
			m_text_money.text = NHPDPKHMFEP.HHCJCDFCLOB.MNAMCPDKFGI_GetPassPriceString(a_plan);
			m_layout_content.Initialize(a_is_first, a_plan);
			m_layout_about.Initialize(a_plan, () =>
			{
				//0xDEE094
				VerticalLayoutGroup l = GetComponentInChildren<VerticalLayoutGroup>(true);
				l.spacing = 10;
				l.childControlWidth = true;
				l.childControlHeight = false;
				l.childForceExpandWidth = false;
				l.childForceExpandHeight = true;
				ContentSizeFitter c = GetComponentInChildren<ContentSizeFitter>(true);
				c.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				c.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
			});
			m_btn_agre.Hidden = true;
		}

		//// RVA: 0xDEDEF8 Offset: 0xDEDEF8 VA: 0xDEDEF8
		private void CB_Law1()
		{
			if (m_cb_law_1 != null)
				m_cb_law_1();
		}

		//// RVA: 0xDEDF0C Offset: 0xDEDF0C VA: 0xDEDF0C
		private void CB_Law2()
		{
			if (m_cb_law_2 != null)
				m_cb_law_2();
		}

		//// RVA: 0xDEDF20 Offset: 0xDEDF20 VA: 0xDEDF20
		private void CB_Cancel()
		{
			if (m_cb_cancel != null)
				m_cb_cancel();
		}

		//// RVA: 0xDEDF34 Offset: 0xDEDF34 VA: 0xDEDF34
		private void CB_Agre()
		{
			if (m_cb_agre != null)
				m_cb_agre();
		}

		//// RVA: 0xDEDF48 Offset: 0xDEDF48 VA: 0xDEDF48
		private void CB_Buy()
		{
			if (m_cb_buy != null)
				m_cb_buy();
		}

		//// RVA: 0xDEDF5C Offset: 0xDEDF5C VA: 0xDEDF5C
		private void CB_Bonus(bool forceAvailableTopplan)
		{
			if (m_cb_bonus != null)
				m_cb_bonus(forceAvailableTopplan);
		}

		//// RVA: 0xDEDFD0 Offset: 0xDEDFD0 VA: 0xDEDFD0
		private void CB_Detail()
		{
			if (m_cb_detail != null)
				m_cb_detail();
		}

		//// RVA: 0xDEDFE4 Offset: 0xDEDFE4 VA: 0xDEDFE4
		private void CB_Contract()
		{
			if (m_cb_contract != null)
				m_cb_contract();
		}

		//// RVA: 0xDEDFF8 Offset: 0xDEDFF8 VA: 0xDEDFF8
		private void CB_Privacy()
		{
			if (m_cb_privacy != null)
				m_cb_privacy();
		}

		// RVA: 0xDE9BC4 Offset: 0xDE9BC4 VA: 0xDE9BC4
		public bool IsReady()
		{
			return IsLoaded() && m_runtime.IsReady;
		}

		// RVA: 0xDECA38 Offset: 0xDECA38 VA: 0xDECA38
		public bool IsPlayingAnim()
		{
			return m_anim_root.IsPlayingChildren();
		}

		// RVA: 0xDEC91C Offset: 0xDEC91C VA: 0xDEC91C
		public void Enter()
		{
			m_anim_root.StartChildrenAnimGoStop("go_in", "st_in");
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
		}

		// RVA: 0xDECA64 Offset: 0xDECA64 VA: 0xDECA64
		public void Leave()
		{
			m_anim_root.StartChildrenAnimGoStop("go_out", "st_out");
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
		}

		//// RVA: 0xDEE00C Offset: 0xDEE00C VA: 0xDEE00C
		//public void Exit() { }

		//// RVA: 0xDEE010 Offset: 0xDEE010 VA: 0xDEE010
		private void OnBackButton()
		{
			if (m_btn_cancel.IsInputOff || m_btn_cancel.Disable)
				return;
			m_btn_cancel.PerformClick();
		}
	}
}
