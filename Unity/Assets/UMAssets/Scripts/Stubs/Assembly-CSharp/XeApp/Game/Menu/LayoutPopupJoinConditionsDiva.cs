using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupJoinConditionsDiva : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private Text m_joinDesc;
		[SerializeField]
		private RawImageEx m_divaIcon;
	}
}
