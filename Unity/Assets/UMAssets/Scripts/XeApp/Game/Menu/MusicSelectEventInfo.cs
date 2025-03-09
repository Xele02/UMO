using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectEventInfo : LayoutLabelScriptBase
	{
		public enum Style
		{
			Ranking = 0,
			Basic = 1,
			Battle = 2,
			None = 3,
			Mission = 4,
		}

		[SerializeField]
		private NumberBase m_curTicketCount; // 0x18
		[SerializeField]
		private Text m_curTicketLabelText; // 0x1C
		[SerializeField]
		private Text m_curValueLabelText; // 0x20
		[SerializeField]
		private Text m_curValueText; // 0x24
		[SerializeField]
		private Text m_curValueUnitText; // 0x28
		[SerializeField]
		private Text m_bpValueLabelText; // 0x2C
		[SerializeField]
		private Text m_bpValueText; // 0x30
		[SerializeField]
		private Text m_bpValueUnitText; // 0x34
		[SerializeField]
		private Text[] m_rankLabelText; // 0x38
		[SerializeField]
		private Text[] m_rankOrderText; // 0x3C
		[SerializeField]
		private Text[] m_rankOrderUnitText; // 0x40
		[SerializeField]
		private Text m_nextLabelText; // 0x44
		[SerializeField]
		private Text m_nextValueText; // 0x48
		[SerializeField]
		private Text m_nextValueUnitText; // 0x4C
		[SerializeField]
		private Text m_rewardLabelText; // 0x50
		[SerializeField]
		private Text m_rewardEndText; // 0x54
		[SerializeField]
		private RawImageEx m_rewardIconImage; // 0x58
		[SerializeField]
		private RawImageEx m_eventTicketImage; // 0x5C
		private LayoutSymbolData m_symbolMain; // 0x60
		private LayoutSymbolData m_symbolStyle; // 0x64
		private LayoutSymbolData m_symbolReward; // 0x68
		private bool m_isShow; // 0x6C

		// RVA: 0x1676574 Offset: 0x1676574 VA: 0x1676574
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// RVA: 0x1676608 Offset: 0x1676608 VA: 0x1676608
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1676584 Offset: 0x1676584 VA: 0x1676584
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1676618 Offset: 0x1676618 VA: 0x1676618
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x167669C Offset: 0x167669C VA: 0x167669C
		// public void Show() { }

		// // RVA: 0x1676720 Offset: 0x1676720 VA: 0x1676720
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x16767A4 Offset: 0x16767A4 VA: 0x16767A4
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x16767D0 Offset: 0x16767D0 VA: 0x16767D0
		public void SetStyle(Style style)
		{
			switch(style)
			{
				case Style.Ranking:
					m_symbolStyle.StartAnim("rank");
					break;
				case Style.Basic:
					m_symbolStyle.StartAnim("basic");
					break;
				case Style.Battle:
					m_symbolStyle.StartAnim("battle");
					break;
				case Style.None:
					m_symbolStyle.StartAnim("none");
					break;
				case Style.Mission:
					m_symbolStyle.StartAnim("mission");
					break;
			}
		}

		// // RVA: 0x167690C Offset: 0x167690C VA: 0x167690C
		// public void SetRewardValid(bool isValid) { }

		// // RVA: 0x16769A4 Offset: 0x16769A4 VA: 0x16769A4
		// public void SetTicketImage(IiconTexture image) { }

		// // RVA: 0x1676A84 Offset: 0x1676A84 VA: 0x1676A84
		// public void SetTicketCountLabel(string label) { }

		// // RVA: 0x1676AC0 Offset: 0x1676AC0 VA: 0x1676AC0
		// public void SetTicketCount(int count) { }

		// // RVA: 0x1676B00 Offset: 0x1676B00 VA: 0x1676B00
		public void SetValueUnitLabel(string label)
		{
			m_curValueUnitText.text = label;
			m_nextValueUnitText.text = label;
		}

		// // RVA: 0x1676B6C Offset: 0x1676B6C VA: 0x1676B6C
		public void SetBpValueUnitLabel(string label)
		{
			m_bpValueUnitText.text = label;
		}

		// // RVA: 0x1676BA8 Offset: 0x1676BA8 VA: 0x1676BA8
		public void SetRankLabel(string label, int index/* = 0*/)
		{
			m_rankLabelText[index].text = label;
		}

		// // RVA: 0x1676C1C Offset: 0x1676C1C VA: 0x1676C1C
		// public void SetRankOrder(string order, int index = 0) { }

		// // RVA: 0x1676C90 Offset: 0x1676C90 VA: 0x1676C90
		public void SetRankUnitLabel(string label, int index/* = 0*/)
		{
			m_rankOrderUnitText[index].text = label;
		}

		// // RVA: 0x1676D04 Offset: 0x1676D04 VA: 0x1676D04
		// public void SetRankCouting(string text, int index = 0) { }

		// // RVA: 0x1676E24 Offset: 0x1676E24 VA: 0x1676E24
		public void SetCurrentValueLabel(string label)
		{
			m_curValueLabelText.text = label;
		}

		// // RVA: 0x1676E60 Offset: 0x1676E60 VA: 0x1676E60
		// public void SetCurrentValue(string value) { }

		// // RVA: 0x1676E9C Offset: 0x1676E9C VA: 0x1676E9C
		public void SetBpValueLabel(string label)
		{
			m_bpValueLabelText.text = label;
		}

		// // RVA: 0x1676ED8 Offset: 0x1676ED8 VA: 0x1676ED8
		// public void SetBpValue(string value) { }

		// // RVA: 0x1676F14 Offset: 0x1676F14 VA: 0x1676F14
		public void SetNextValueLabel(string label)
		{
			m_nextLabelText.text = label;
		}

		// // RVA: 0x1676F50 Offset: 0x1676F50 VA: 0x1676F50
		// public void SetNextValue(string value) { }

		// // RVA: 0x1676F8C Offset: 0x1676F8C VA: 0x1676F8C
		public void SetRewardLabel(string label)
		{
			m_rewardLabelText.text = label;
		}

		// // RVA: 0x1676FC8 Offset: 0x1676FC8 VA: 0x1676FC8
		// public void SetRewardIcon(IiconTexture image) { }

		// // RVA: 0x16770A8 Offset: 0x16770A8 VA: 0x16770A8
		// public void SetRewardEndLabel(string label) { }

		// RVA: 0x16770E4 Offset: 0x16770E4 VA: 0x16770E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStyle = CreateSymbol("style", layout);
			m_symbolReward = CreateSymbol("reward", layout);
			m_symbolStyle.StartAnim("basic");
			Loaded();
			return true;
		}
	}
}
