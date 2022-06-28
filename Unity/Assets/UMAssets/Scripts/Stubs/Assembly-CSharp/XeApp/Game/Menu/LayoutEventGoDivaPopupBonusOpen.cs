using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaPopupBonusOpen : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_imageJacket;
		[SerializeField]
		private Text m_textBonusTargetTitle;
		[SerializeField]
		private Text m_textExpBonus;
		[SerializeField]
		private Text m_textExplain;
	}
}
