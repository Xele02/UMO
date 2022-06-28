using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class TipsWindow : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private TipsContent m_conten;
		[SerializeField]
		private ActionButton[] m_arrowButtons;
		[SerializeField]
		private RawImageEx[] m_charaImages;
		[SerializeField]
		private RawImageEx[] m_graffitiImages;
	}
}
