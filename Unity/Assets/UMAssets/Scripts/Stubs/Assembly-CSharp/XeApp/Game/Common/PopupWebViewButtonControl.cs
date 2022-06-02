using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupWebViewButtonControl : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_returnButton;
		[SerializeField]
		private ActionButton m_closeButton;
		[SerializeField]
		private List<RawImageEx> m_labels;
		[SerializeField]
		private CheckboxButton m_rejectCheckbox;
		[SerializeField]
		private Text m_rejectText;
	}
}
