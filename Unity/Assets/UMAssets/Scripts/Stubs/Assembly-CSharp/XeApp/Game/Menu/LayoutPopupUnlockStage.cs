using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockStage : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private RawImageEx m_musicJacket;
	}
}
