using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupSnsSetting : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private LayoutInhertingSnsButton[] m_buttons;
		[SerializeField]
		private ToggleButton m_toggleButton;
	}
}
