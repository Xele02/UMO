using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class UnitDanceWarningWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_okButton; // 0x14
		[SerializeField]
		private ActionButton m_unitLiveButton; // 0x18
		[SerializeField]
		private ActionButton m_soloLiveButton; // 0x1C
		[SerializeField]
		private ToggleButton m_toggleButton; // 0x20
		[SerializeField]
		private RawImageEx m_unitDanceIconImage; // 0x24
		[SerializeField]
		private Text m_title; // 0x28
		[SerializeField]
		private Text m_content; // 0x2C
		[SerializeField]
		private Text m_checkLabel; // 0x30
		public UnityAction<bool> PositiveListener; // 0x34
		public UnityAction<bool> NegativeListener; // 0x38
		public UnityAction ToggleButtonListener; // 0x3C
		private AbsoluteLayout m_buttonChangeLayout; // 0x40
		private AbsoluteLayout m_rootLayout; // 0x44
		private TexUVListManager m_uvMan; // 0x48
		private readonly string[] IconUvNameTable = new string[5] {
			"pop_u_s_icon_solo",
			"pop_u_s_icon_unit2",
			"pop_u_s_icon_unit3",
			"pop_u_s_icon_unit4",
			"pop_u_s_icon_unit5"
		}; // 0x4C

		// RVA: 0x1243D4C Offset: 0x1243D4C VA: 0x1243D4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_okButton.AddOnClickCallback(OnPositive);
			m_unitLiveButton.AddOnClickCallback(OnPositive);
			m_soloLiveButton.AddOnClickCallback(OnNegative);
			m_toggleButton.AddOnClickCallback(OnToggleButton);
			m_rootLayout = layout.FindViewByExId("root_pop_unit_select_sw_pop_unit_select_inout_anim") as AbsoluteLayout;
			m_uvMan = uvMan;
			m_buttonChangeLayout = layout.FindViewByExId("sw_pop_unit_select_swtbl_btn") as AbsoluteLayout;
			m_rootLayout.StartChildrenAnimGoStop("st_out");
			return true;
		}

		//// RVA: 0x1244044 Offset: 0x1244044 VA: 0x1244044
		public void Initialize(int danceNum, bool isUnitOnly)
		{
			m_buttonChangeLayout.StartChildrenAnimGoStop(MessageManager.Instance.GetBank("menu").GetMessageByLabel(isUnitOnly ? "02" : "01"));
			m_title.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_warning_window_title");
			m_content.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(isUnitOnly ? "unit_warning_window_text_002" : "unit_warning_window_text_001");
			m_checkLabel.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_warning_window_check");
			m_unitDanceIconImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(IconUvNameTable[danceNum - 1]));
		}

		//// RVA: 0x1244324 Offset: 0x1244324 VA: 0x1244324
		public void Show()
		{
			m_rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x12443B0 Offset: 0x12443B0 VA: 0x12443B0
		public void Close()
		{
			m_rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x124443C Offset: 0x124443C VA: 0x124443C
		public bool IsPlaying()
		{
			return m_rootLayout.IsPlayingChildren();
		}

		//// RVA: 0x1244468 Offset: 0x1244468 VA: 0x1244468
		private void OnPositive()
		{
			if (PositiveListener != null)
				PositiveListener(m_toggleButton.IsOn);
		}

		//// RVA: 0x12444FC Offset: 0x12444FC VA: 0x12444FC
		private void OnNegative()
		{
			if (NegativeListener != null)
				NegativeListener(m_toggleButton.IsOn);
		}

		//// RVA: 0x1244590 Offset: 0x1244590 VA: 0x1244590
		private void OnToggleButton()
		{
			if (ToggleButtonListener != null)
				ToggleButtonListener();
		}

		//// RVA: 0x12445A4 Offset: 0x12445A4 VA: 0x12445A4
		public void PerformClickOk()
		{
			if (m_okButton != null)
				m_okButton.PerformClick();
		}
	}
}
