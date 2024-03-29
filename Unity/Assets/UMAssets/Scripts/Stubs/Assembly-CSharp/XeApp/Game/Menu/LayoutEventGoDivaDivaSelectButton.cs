using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaDivaSelectButton : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx[] m_imageDivaIconTbl;
		[SerializeField]
		private Text[] m_textDivaLockTbl;
		[SerializeField]
		private ActionButton[] m_buttonDivaTbl;
		[SerializeField]
		private Text m_textExplain;
	}
}
