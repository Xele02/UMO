using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class LayoutPopupConfigRhythmNotes : LayoutUGUIScriptBase
	{
		public enum Style
		{
			Option = 0,
			Rhythm = 1,
			Passive = 2,
		}

		[SerializeField]
		private Text m_titleText; // 0x14
		[SerializeField]
		private Text m_detailText; // 0x18
		[SerializeField]
		private Text m_numberText; // 0x1C
		[SerializeField]
		private Text m_diffDescText; // 0x20
		[SerializeField]
		private Text m_check01LabelText; // 0x24
		[SerializeField]
		private Text m_check01CautionText; // 0x28
		[SerializeField]
		private Text m_check02LabelText; // 0x2C
		[SerializeField]
		private Text m_check02CautionText; // 0x30
		[SerializeField]
		private ActionButton m_defaultButton; // 0x34
		[SerializeField]
		private ActionButton m_plus10Button; // 0x38
		[SerializeField]
		private ActionButton m_plus01Button; // 0x3C
		[SerializeField]
		private ActionButton m_minus10Button; // 0x40
		[SerializeField]
		private ActionButton m_minus01Button; // 0x44
		[SerializeField]
		private ActionButton m_diffSelectLeft; // 0x48
		[SerializeField]
		private ActionButton m_diffSelectRight; // 0x4C
		[SerializeField]
		private CheckboxButton m_check01Button; // 0x50
		[SerializeField]
		private CheckboxButton m_check02Button; // 0x54
		private AbsoluteLayout m_diffTable; // 0x58
		private AbsoluteLayout m_diffSelectTable; // 0x5C
		private AbsoluteLayout m_checkBoxTable; // 0x60

		//public bool IsChecked01 { get; } 0x11073DC
		//public bool IsChecked02 { get; } 0x1107408

		//// RVA: 0x1107434 Offset: 0x1107434 VA: 0x1107434
		public void SetStyle(Style style)
		{
			m_diffSelectTable.StartChildrenAnimGoStop(style == Style.Option ? "01" : "02");
			m_checkBoxTable.StartChildrenAnimGoStop(style == Style.Passive ? "02" : "01");
		}

		//// RVA: 0x1107520 Offset: 0x1107520 VA: 0x1107520
		public void SetTitle(string title)
		{
			m_titleText.text = title;
		}

		//// RVA: 0x110755C Offset: 0x110755C VA: 0x110755C
		public void SetDetail(string detail)
		{
			m_detailText.text = detail;
		}

		//// RVA: 0x1107598 Offset: 0x1107598 VA: 0x1107598
		public void SetNumber(string num)
		{
			m_numberText.text = num;
		}

		//// RVA: 0x11075D4 Offset: 0x11075D4 VA: 0x11075D4
		public void SetDiffDesc(string desc)
		{
			m_diffDescText.text = desc;
		}

		//// RVA: 0x1107610 Offset: 0x1107610 VA: 0x1107610
		public void SetDifficulty(Difficulty.Type diffType, bool isLine6Mode)
		{
			m_diffTable.StartChildrenAnimGoStop(((isLine6Mode ? 4 : 1) + (int)diffType).ToString("d2"));
		}

		//// RVA: 0x11076C4 Offset: 0x11076C4 VA: 0x11076C4
		public void SetCheckbox01Text(string label, string caution)
		{
			m_check01LabelText.text = label;
			m_check01CautionText.text = caution;
		}

		//// RVA: 0x1107734 Offset: 0x1107734 VA: 0x1107734
		public void SetCheckbox02Text(string label, string caution)
		{
			m_check02LabelText.text = label;
			m_check02CautionText.text = caution;
		}

		//// RVA: 0x11077A4 Offset: 0x11077A4 VA: 0x11077A4
		public void SetCheckbox01Status(bool isChecked)
		{
			if (isChecked)
				m_check01Button.SetOn();
			else
				m_check01Button.SetOff();
		}

		//// RVA: 0x11077F0 Offset: 0x11077F0 VA: 0x11077F0
		public void SetCheckbox02Status(bool isChecked)
		{
			if (isChecked)
				m_check02Button.SetOn();
			else
				m_check02Button.SetOff();
		}

		//// RVA: 0x110783C Offset: 0x110783C VA: 0x110783C
		public void SetOnClickDefault(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_defaultButton, callback);
		}

		//// RVA: 0x11078A4 Offset: 0x11078A4 VA: 0x11078A4
		public void SetOnClickPlus10(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_plus10Button, callback);
		}

		//// RVA: 0x11078B0 Offset: 0x11078B0 VA: 0x11078B0
		public void SetOnClickPlus01(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_plus01Button, callback);
		}

		//// RVA: 0x11078BC Offset: 0x11078BC VA: 0x11078BC
		public void SetOnClickMinus10(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_minus10Button, callback);
		}

		//// RVA: 0x11078C8 Offset: 0x11078C8 VA: 0x11078C8
		public void SetOnClickMinus01(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_minus01Button, callback);
		}

		//// RVA: 0x11078D4 Offset: 0x11078D4 VA: 0x11078D4
		public void SetOnClickDiffLeft(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_diffSelectLeft, callback);
		}

		//// RVA: 0x11078E0 Offset: 0x11078E0 VA: 0x11078E0
		public void SetOnClickDiffRight(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_diffSelectRight, callback);
		}

		//// RVA: 0x11078EC Offset: 0x11078EC VA: 0x11078EC
		public void SetOnClickCheckbox01(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_check01Button, callback);
		}

		//// RVA: 0x11078F8 Offset: 0x11078F8 VA: 0x11078F8
		public void SetOnClickCheckbox02(ButtonBase.OnClickCallback callback)
		{
			SetOnClick(m_check02Button, callback);
		}

		//// RVA: 0x1107848 Offset: 0x1107848 VA: 0x1107848
		private void SetOnClick(ActionButton button, ButtonBase.OnClickCallback callback)
		{
			button.ClearOnClickCallback();
			button.AddOnClickCallback(callback);
		}

		// RVA: 0x1107904 Offset: 0x1107904 VA: 0x1107904 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_diffTable = layout.FindViewByExId("sw_rhythm_set_01_swtbl_con_diff") as AbsoluteLayout;
			m_diffSelectTable = layout.FindViewByExId("sw_rhythm_set_01_swtbl_con_page_btn") as AbsoluteLayout;
			m_checkBoxTable = layout.FindViewByExId("sw_rhythm_set_01_swtbl_set_reflect") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
