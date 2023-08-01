using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupOverlapSingle : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textPrev;
		[SerializeField]
		private Text m_textNext;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text m_textLimit;
		[SerializeField]
		private RawImageEx m_imagePlate;
		[SerializeField]
		private RawImageEx m_imagePoster;
		[SerializeField]
		private ButtonBase m_button;
	}
}
