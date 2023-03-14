using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockMusic : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_vocalName;
		[SerializeField]
		private RawImageEx m_musicJacket;
		[SerializeField]
		private RawImageEx m_logo;
	}
}
