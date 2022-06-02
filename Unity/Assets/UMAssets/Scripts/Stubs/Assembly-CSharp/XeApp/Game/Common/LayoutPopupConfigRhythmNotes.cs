using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class LayoutPopupConfigRhythmNotes : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_detailText;
		[SerializeField]
		private Text m_numberText;
		[SerializeField]
		private Text m_diffDescText;
		[SerializeField]
		private Text m_check01LabelText;
		[SerializeField]
		private Text m_check01CautionText;
		[SerializeField]
		private Text m_check02LabelText;
		[SerializeField]
		private Text m_check02CautionText;
		[SerializeField]
		private ActionButton m_defaultButton;
		[SerializeField]
		private ActionButton m_plus10Button;
		[SerializeField]
		private ActionButton m_plus01Button;
		[SerializeField]
		private ActionButton m_minus10Button;
		[SerializeField]
		private ActionButton m_minus01Button;
		[SerializeField]
		private ActionButton m_diffSelectLeft;
		[SerializeField]
		private ActionButton m_diffSelectRight;
		[SerializeField]
		private CheckboxButton m_check01Button;
		[SerializeField]
		private CheckboxButton m_check02Button;
	}
}
