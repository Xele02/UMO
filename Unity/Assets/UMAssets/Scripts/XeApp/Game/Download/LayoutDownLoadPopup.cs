using System;
using System.Linq;
using mcrs;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.DownLoad
{
	public class LayoutDownLoadPopup : LayoutUGUIScriptBase
	{
		private Action m_OnClickCancel; // 0x14
		private Action m_OnClickDecide; // 0x18
		private AbsoluteLayout m_Anim; // 0x1C
		private Text m_DivaNameText; // 0x20
		private bool m_IsShow; // 0x24
		private ActionButton m_cancelButton; // 0x28

		public Action OnClickCancel { set { m_OnClickCancel = value; } } //0x97E284
		public Action OnClickDecide { set { m_OnClickDecide = value; } } //0x97E28C

		// RVA: 0x97E294 Offset: 0x97E294 VA: 0x97E294 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewByExId("root_sel_chara_pop_sw_sel_chara_pop_anim") as AbsoluteLayout;
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_cancelButton = btns.Where((ActionButton _) =>
			{
				//0x97EFBC
				return _.name == "sw_adjust_btn_01_anim (AbsoluteLayout)";
			}).First();
			m_cancelButton.AddOnClickCallback(() =>
			{
				//0x97EF30
				OnClickButton(m_OnClickCancel);
			});
			btns.Where((ActionButton _) =>
			{
				//0x97F03C
				return _.name == "sw_adjust_btn_02_anim (AbsoluteLayout)";
			}).First().AddOnClickCallback(() =>
			{
				//0x97EF38
				OnClickButton(m_OnClickDecide);
			});
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_DivaNameText = txts.Where((Text _) =>
			{
				//0x97F0BC
				return _.name == "diva_name (TextView)";
			}).First();
			m_DivaNameText.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
			Text txt = txts.Where((Text _) =>
			{
				//0x97F13C
				return _.name == "strat_txt (TextView)";
			}).First();
			txt.text = MessageManager.Instance.GetMessage("menu", "tuto_divaselect_popup_002");
			txt.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
			txt = txts.Where((Text _) =>
			{
				//0x97F1BC
				return _.name == "caution_detail_01 (TextView)";
			}).First();
			txt.text = MessageManager.Instance.GetMessage("menu", "tuto_divaselect_popup_003");
			txt.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
			Loaded();
			return true;
		}

		// RVA: 0x97EAE8 Offset: 0x97EAE8 VA: 0x97EAE8
		public bool IsReady()
		{
			if(IsLoaded())
			{
				return GetComponent<LayoutUGUIRuntime>().IsReady;
			}
			return false;
		}

		// RVA: 0x97EB84 Offset: 0x97EB84 VA: 0x97EB84
		public void Show(string diva_name)
		{
			if(m_IsShow)
				return;
			m_DivaNameText.text = string.Format(MessageManager.Instance.GetMessage("menu", "tuto_divaselect_popup_001"), diva_name);
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
			m_IsShow = true;
		}

		// // RVA: 0x97ED04 Offset: 0x97ED04 VA: 0x97ED04
		private void Hide()
		{
			if(!m_IsShow)
				return;
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
			m_IsShow = false;
		}

		// // RVA: 0x97EDF0 Offset: 0x97EDF0 VA: 0x97EDF0
		private void OnClickButton(Action callback)
		{
			if(!m_IsShow)
				return;
			if(callback != null)
				callback();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			Hide();
		}

		// RVA: 0x97EE74 Offset: 0x97EE74 VA: 0x97EE74
		public void PerformClickCancel()
		{
			if(m_cancelButton != null)
				m_cancelButton.PerformClick();
		}
	}
}
