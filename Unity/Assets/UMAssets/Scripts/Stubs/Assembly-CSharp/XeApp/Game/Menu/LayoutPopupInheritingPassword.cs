using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupInheritingPassword : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private GameObject m_inputPosition;
		[SerializeField]
		private GameObject m_inputIdPosition;
		[SerializeField]
		private Text[] m_texts;
	}
}
