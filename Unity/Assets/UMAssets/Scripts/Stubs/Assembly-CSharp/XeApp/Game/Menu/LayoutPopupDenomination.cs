using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDenomination : LayoutUGUIScriptBase
	{
		private ScrollRect m_ScrollRect; // 0x14
		private Transform m_ScrollContent; // 0x18
		private Action m_OnClickSCTL; // 0x1C
		private Action m_OnClickPSA; // 0x20

		public ScrollRect GetScrollRect { get { return m_ScrollRect; } } //0x171E19C
		public Transform GetScrollContent { get { return m_ScrollContent; } } //0x171E1A4
		public Action OnClickSCTL { set { m_OnClickSCTL = value; } } //0x171E1AC
		public Action OnClickPSA { set { m_OnClickPSA = value; } } //0x171E1B4

		// RVA: 0x171E1BC Offset: 0x171E1BC VA: 0x171E1BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_ScrollRect = GetComponentInChildren<ScrollRect>(true);
			m_ScrollContent = m_ScrollRect.transform.Find("Content");
			ScrollRect sr = GetComponentInChildren<ScrollRect>(true);
			sr.horizontal = false;
			sr.vertical = true;
			sr.horizontalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			sr.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
			sr.gameObject.GetComponentInChildren<VerticalLayoutGroup>().enabled = false;
			sr.gameObject.GetComponentInChildren<ContentSizeFitter>().enabled = false;
			sr.gameObject.GetComponentInChildren<LayoutElement>().enabled = false;
			sr.content.anchoredPosition = Vector2.zero;
			sr.content.sizeDelta = Vector2.zero;
			RectTransform rt = sr.content.Find("Range").GetComponent<RectTransform>();
			rt.anchoredPosition = Vector2.zero;
			rt.sizeDelta = Vector2.zero;
			ActionButton[] acts = GetComponentsInChildren<ActionButton>(true);
			acts.Where((ActionButton _) =>
			{
				//0x171EA78
				return _.name == "sw_den_btn_law_1 (AbsoluteLayout)";
			}).First().AddOnClickCallback(() =>
			{
				//0x171E9D4
				if(m_OnClickSCTL != null)
					m_OnClickSCTL();
			});
			acts.Where((ActionButton _) =>
			{
				//0x171EAF8
				return _.name == "sw_den_btn_law_2 (AbsoluteLayout)";
			}).First().AddOnClickCallback(() =>
			{
				//0x171E9E8
				if(m_OnClickPSA != null)
					m_OnClickPSA();
			});
			Loaded();
			return true;
		}

		// RVA: 0x171E8CC Offset: 0x171E8CC VA: 0x171E8CC
		public void SetUp(int have_paid_vc)
		{
			GetComponentInChildren<NumberBase>(true).SetNumber(have_paid_vc, 0);
		}

		// RVA: 0x171E968 Offset: 0x171E968 VA: 0x171E968
		public void Update()
		{
			return;
		}

		// // RVA: 0x171E96C Offset: 0x171E96C VA: 0x171E96C
		public void ScrollEnable()
		{
			m_ScrollRect.enabled = true;
		}

		// // RVA: 0x171E99C Offset: 0x171E99C VA: 0x171E99C
		public void ScrollDisable()
		{
			m_ScrollRect.enabled = false;
		}
	}
}
