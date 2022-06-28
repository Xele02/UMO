using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationRightEditButton : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_leftButton;
		[SerializeField]
		private ActionButton m_rightButton;
		[SerializeField]
		private RawImageEx m_leftButtonFontImage;
		[SerializeField]
		private RawImageEx m_rightButtonFontImage;
	}
}
