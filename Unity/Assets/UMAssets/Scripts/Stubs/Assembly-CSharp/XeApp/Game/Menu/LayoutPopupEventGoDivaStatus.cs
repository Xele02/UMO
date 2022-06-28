using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupEventGoDivaStatus : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text[] m_textStatusNameTbl;
		[SerializeField]
		private Text[] m_textLevelTbl;
		[SerializeField]
		private Text[] m_textTotalStatusTbl;
		[SerializeField]
		private Text[] m_textUpStatusTbl;
	}
}
