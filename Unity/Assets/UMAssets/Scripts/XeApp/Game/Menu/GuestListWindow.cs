using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GuestListWindow : LayoutLabelScriptBase
	{
		public enum CounterStyle
		{
			Count = 0,
			Fraction = 1,
			None = 2,
		}

		private const float s_elemOffsetY = -128;
		[SerializeField]
		private Text m_windowMessage; // 0x18
		[SerializeField]
		private List<Text> m_countValues; // 0x1C
		[SerializeField]
		private List<Text> m_maxValues; // 0x20
		[SerializeField]
		private Text m_cautionMessage; // 0x24
		private LayoutSymbolData m_symbolMain; // 0x28
		private LayoutSymbolData m_symbolMessage; // 0x2C
		private LayoutSymbolData m_symbolCounter; // 0x30
		private LayoutSymbolData m_symbolCaution; // 0x34
		private int m_elemCount; // 0x38

		//// RVA: 0xE29FA0 Offset: 0xE29FA0 VA: 0xE29FA0
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		//// RVA: 0xE2A7C0 Offset: 0xE2A7C0 VA: 0xE2A7C0
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		//// RVA: 0xE2FDA8 Offset: 0xE2FDA8 VA: 0xE2FDA8
		//public void Show() { }

		//// RVA: 0xE29E1C Offset: 0xE29E1C VA: 0xE29E1C
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		//// RVA: 0xE2A078 Offset: 0xE2A078 VA: 0xE2A078
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		//// RVA: 0xE2C420 Offset: 0xE2C420 VA: 0xE2C420
		public void SetMessage(string message)
		{
			m_windowMessage.text = message;
		}

		//// RVA: 0xE2AD5C Offset: 0xE2AD5C VA: 0xE2AD5C
		public void SetMessageVisible(bool isVisible)
		{
			m_symbolMessage.StartAnim(isVisible ? "on" : "off");
		}

		//// RVA: 0xE2AE8C Offset: 0xE2AE8C VA: 0xE2AE8C
		public void SetCounterStyle(CounterStyle style)
		{
			m_symbolCounter.StartAnim(new string[3] { "count", "fraction", "none" }[(int)style]);
		}

		//// RVA: 0xE2FE24 Offset: 0xE2FE24 VA: 0xE2FE24
		//public void SetCount(string count) { }

		//// RVA: 0xE2FF10 Offset: 0xE2FF10 VA: 0xE2FF10
		//public void SetMax(string max) { }

		//// RVA: 0xE2FFFC Offset: 0xE2FFFC VA: 0xE2FFFC
		//public void SetCaution(string message) { }

		//// RVA: 0xE2ADF4 Offset: 0xE2ADF4 VA: 0xE2ADF4
		public void SetCautionVisible(bool isVisible)
		{
			m_symbolCaution.StartAnim(isVisible ? "on" : "off");
		}

		// RVA: 0xE30038 Offset: 0xE30038 VA: 0xE30038 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolMessage = CreateSymbol("message", layout);
			m_symbolCounter = CreateSymbol("counter", layout);
			m_symbolCaution = CreateSymbol("caution", layout);
			m_windowMessage.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("pop_lobby_group_not_searchplayer");
			SetMessageVisible(false);
			Loaded();
			return true;
		}
	}
}
