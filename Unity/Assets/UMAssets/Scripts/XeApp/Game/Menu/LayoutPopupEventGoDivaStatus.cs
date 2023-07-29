using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;
using System.Text;

namespace XeApp.Game.Menu
{
	public class LayoutPopupEventGoDivaStatus : LayoutUGUIScriptBase
	{
		public class StatusParam
		{
			public int totalLevel; // 0x8
			public int totalStatus; // 0xC
			public int upStatus; // 0x10
		}

		public class StatusParamSet
		{
			public StatusParam soul = new StatusParam(); // 0x8
			public StatusParam voice = new StatusParam(); // 0xC
			public StatusParam charm = new StatusParam(); // 0x10
		}

		private enum StatusType
		{
			Soul = 0,
			Voice = 1,
			Charm = 2,
			Num = 3,
		}

		private static readonly string[] StatusNameMsgLabels = new string[3]
		{
			"popup_godiva_status_name_soul",
			"popup_godiva_status_name_voice",
			"popup_godiva_status_name_charm"
		}; // 0x0
		[SerializeField]
		private Text[] m_textStatusNameTbl; // 0x14
		[SerializeField]
		private Text[] m_textLevelTbl; // 0x18
		[SerializeField]
		private Text[] m_textTotalStatusTbl; // 0x1C
		[SerializeField]
		private Text[] m_textUpStatusTbl; // 0x20

		// RVA: 0x172278C Offset: 0x172278C VA: 0x172278C
		public void Setup(StatusParamSet statusParamSet)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			StatusParam[] p = new StatusParam[3]
			{
				statusParamSet.soul,
				statusParamSet.voice,
				statusParamSet.charm
			};
			for(int i = 0; i < 3; i++)
			{
				m_textStatusNameTbl[i].text = bk.GetMessageByLabel(StatusNameMsgLabels[i]);
				str.SetFormat(bk.GetMessageByLabel("popup_godiva_status_level"), p[i].totalLevel);
				m_textLevelTbl[i].text = str.ToString();
				str.SetFormat(bk.GetMessageByLabel("popup_godiva_status_status"), p[i].totalStatus);
				m_textTotalStatusTbl[i].text = str.ToString();
				str.SetFormat(bk.GetMessageByLabel("popup_godiva_status_up_status"), p[i].upStatus);
				m_textUpStatusTbl[i].text = str.ToString();
			}
		}

		// RVA: 0x1722DD0 Offset: 0x1722DD0 VA: 0x1722DD0
		public void Reset()
		{
			return;
		}

		// RVA: 0x1722DD4 Offset: 0x1722DD4 VA: 0x1722DD4
		public void Show()
		{
			return;
		}

		// RVA: 0x1722DD8 Offset: 0x1722DD8 VA: 0x1722DD8
		public void Hide()
		{
			return;
		}

		// RVA: 0x1722DDC Offset: 0x1722DDC VA: 0x1722DDC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
