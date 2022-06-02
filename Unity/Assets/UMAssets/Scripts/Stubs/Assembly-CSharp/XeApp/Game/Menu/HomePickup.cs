using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class HomePickup : LayoutLabelScriptBase
	{
		[SerializeField]
		private ActionButton m_closeButton;
		[SerializeField]
		private ActionButton m_jumpButton;
		[SerializeField]
		private CheckboxButton m_rejectCheckbox;
		[SerializeField]
		private Text m_checkboxLabelText;
		[SerializeField]
		private RawImageEx m_pickupImage;
		[SerializeField]
		private RawImageEx m_jumpButtonImage;
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker;
		[SerializeField]
		private Text m_pickDayText;
	}
}
