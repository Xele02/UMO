using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class UnitSetSettingButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_unitSetButton;
		[SerializeField]
		private ActionButton m_autoSettingButton;
		[SerializeField]
		private ActionButton m_showChangeStatusButton;
		[SerializeField]
		private ActionButton m_assistSelectButton;
		[SerializeField]
		private RawImageEx m_displayStatusNameImage;
		[SerializeField]
		private UnityEvent m_onPushUnitSetButton;
		[SerializeField]
		private UnityEvent m_onPushAutoSettingButton;
		[SerializeField]
		private UnityEvent m_onPushShowChangeStatusButton;
		[SerializeField]
		private UnityEvent m_onPushChangeStatusButton;
		[SerializeField]
		private UnityEvent m_onPushAssistSelectButton;
	}
}
