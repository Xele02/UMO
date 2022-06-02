using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected Text[] m_texts;
		[SerializeField]
		protected ActionButton[] m_buttons;
		[SerializeField]
		protected ToggleButtonGroup[] m_toggleButtonGroups;
	}
}
