using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneGrowthUnlockButton : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_buttonSta;
		[SerializeField]
		private ActionButton m_buttonEpi;
		[SerializeField]
		private ActionButton m_buttonAll;
	}
}
