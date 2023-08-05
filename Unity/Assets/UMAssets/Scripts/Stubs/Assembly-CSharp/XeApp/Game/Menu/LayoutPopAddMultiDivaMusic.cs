using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopAddMultiDivaMusic : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_divaNumText;
		[SerializeField]
		private RawImageEx m_musicJacket;
		[SerializeField]
		private RawImageEx m_Serieslogo;
	}
}
