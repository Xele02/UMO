using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomStampWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_decideButton;
		[SerializeField]
		private ActionButton m_cancelButton;
		[SerializeField]
		private RawImageEx m_cancelBtnImage;
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_registerNumberText;
		[SerializeField]
		private Text m_windowDescText;
		[SerializeField]
		private Text m_wintext;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Vector2 m_windowSize;
	}
}
