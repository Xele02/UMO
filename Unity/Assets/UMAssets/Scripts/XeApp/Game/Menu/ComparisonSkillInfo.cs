using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;
using System.Text;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class ComparisonSkillInfo : LayoutUGUIScriptBase
	{
		public enum SkillMask
		{
			None = 0,
			NoCompatible = 1,
			MainSlot = 2,
			MisMatchMusic = 3,
			NoCenterDiva = 4,
			MisMatchSeries = 5,
			MisMatchAttr = 6,
		}

		private enum DescDetailsButtonType
		{
			Top = 0,
			First = 1,
			Second = 2,
		}

		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private Text[] m_levelTexts; // 0x18
		[SerializeField]
		private Text[] m_detailsTexts; // 0x1C
		[SerializeField]
		private RawImageEx[] m_rankImages; // 0x20
		[SerializeField]
		private RawImageEx[] m_descDetailsImage; // 0x24
		[SerializeField]
		private ActionButton[] m_descDetailsButton; // 0x28
		[SerializeField]
		private RegulationButton m_regulationButton; // 0x2C
		private TextAnchor m_nameTextAnchor; // 0x30
		private TextAnchor m_detailsTextAnchor; // 0x34
		private AbsoluteLayout m_maskLayout; // 0x38
		[SerializeField]
		private string m_maskLayoutExId; // 0x3C
		private AbsoluteLayout[] m_typeLayouts; // 0x40
		[SerializeField]
		private string m_typeLayoutExId; // 0x44
		private AbsoluteLayout m_skillCrossFade; // 0x48
		[SerializeField]
		private string m_skillCrossFadeExId; // 0x4C
		public Action<ComparisonSkillInfo, int> OnPushDetailsEvent; // 0x50
		public Action OnPushRegulationEvent; // 0x54

		//public RegulationButton RegulationButton { get; } 0x1B56550

		// RVA: 0x1B56558 Offset: 0x1B56558 VA: 0x1B56558 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_nameTextAnchor = m_levelTexts[0].alignment;
			m_detailsTextAnchor = m_detailsTexts[0].alignment;
			LayoutUGUIHitOnly h = m_descDetailsButton[0].GetComponent<LayoutUGUIHitOnly>();
			if (h != null)
				h.enabled = false;
			m_descDetailsButton[0].enabled = false;
			m_descDetailsButton[1].AddOnClickCallback(OnPushDetails);
			m_descDetailsButton[2].AddOnClickCallback(OnPushDetails2);
			m_regulationButton.AddOnClickCallback(OnPushRegulation);
			StringBuilder str = new StringBuilder();
			AbsoluteLayout root = m_runtime.FindViewBase(transform as RectTransform) as AbsoluteLayout;
			m_maskLayout = root.FindViewByExId(m_maskLayoutExId) as AbsoluteLayout;
			List<AbsoluteLayout> l = new List<AbsoluteLayout>();
			for(int i = 1; ; i++)
			{
				str.Clear();
				str.AppendFormat("sw_skill_cf_anim_sw_skill_{0:D2}", i);
				AbsoluteLayout s = root.FindViewByExId(str.ToString()) as AbsoluteLayout;
				if (s == null)
					break;
				l.Add(s);
			}
			if(l.Count < 1)
			{
				m_typeLayouts = new AbsoluteLayout[1];
				l[0] = root.FindViewByExId(m_typeLayoutExId) as AbsoluteLayout;
			}
			else
			{
				m_typeLayouts = new AbsoluteLayout[l.Count];
				for(int i = 0; i < m_typeLayouts.Length; i++)
				{
					m_typeLayouts[i] = l[i];
				}
			}
			m_skillCrossFade = root.FindViewByExId(m_skillCrossFadeExId) as AbsoluteLayout;
			Loaded();
			return true;
		}

		//// RVA: 0x1B56F20 Offset: 0x1B56F20 VA: 0x1B56F20
		public void SetSkillType(SkillType.Type type, int index = 0)
		{
			if (m_typeLayouts.Length <= index)
				return;
			if(type == SkillType.Type.ActiveSkill)
			{
				m_typeLayouts[index].StartChildrenAnimGoStop("02");
			}
			else if(type == SkillType.Type.LiveSkill)
			{
				m_typeLayouts[index].StartChildrenAnimGoStop("03");
			}
			else if (type == SkillType.Type.CenterSkill)
			{
				m_typeLayouts[index].StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x1B5164C Offset: 0x1B5164C VA: 0x1B5164C
		public void SetSkillTypeAll(SkillType.Type type)
		{
			for(int i = 0; i < m_typeLayouts.Length; i++)
			{
				SetSkillType(type, i);
			}
		}

		//// RVA: 0x1B5170C Offset: 0x1B5170C VA: 0x1B5170C
		//public void SetSkillRank(SkillRank.Type rank, int index = 0) { }

		//// RVA: 0x1B518A4 Offset: 0x1B518A4 VA: 0x1B518A4
		//public void SetSkillLevel(int level, int index = 0) { }

		//// RVA: 0x1B51AD8 Offset: 0x1B51AD8 VA: 0x1B51AD8
		//public void SetSkillDescription(string description, int index = 0) { }

		//// RVA: 0x1B51E9C Offset: 0x1B51E9C VA: 0x1B51E9C
		//public void SetSkillCrossFade(bool enable) { }

		//// RVA: 0x1B51F9C Offset: 0x1B51F9C VA: 0x1B51F9C
		//public void SetSkillMask(ComparisonSkillInfo.SkillMask mask) { }

		//// RVA: 0x1B570C4 Offset: 0x1B570C4 VA: 0x1B570C4
		private void OnPushDetails()
		{
			TodoLogger.LogNotImplemented("OnPushDetails");
		}

		//// RVA: 0x1B5719C Offset: 0x1B5719C VA: 0x1B5719C
		private void OnPushDetails2()
		{
			TodoLogger.LogNotImplemented("OnPushDetails2");
		}

		//// RVA: 0x1B57274 Offset: 0x1B57274 VA: 0x1B57274
		private void OnPushRegulation()
		{
			TodoLogger.LogNotImplemented("OnPushRegulation");
		}
	}
}
