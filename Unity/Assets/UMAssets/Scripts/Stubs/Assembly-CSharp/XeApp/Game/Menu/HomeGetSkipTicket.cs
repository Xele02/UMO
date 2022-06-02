using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class HomeGetSkipTicket : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonClose;
		[SerializeField]
		private CheckboxButton m_checkboxReject;
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private Text m_textDesc1;
		[SerializeField]
		private Text m_textDesc2;
		[SerializeField]
		private Text m_textNumLabel;
		[SerializeField]
		private Text m_textNumCount;
		[SerializeField]
		private Text m_textReject;
		[SerializeField]
		private RawImageEx m_imageIcon;
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker;
	}
}
