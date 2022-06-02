using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDataOption : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_buttons;
		[SerializeField]
		private RawImageEx[] m_buttonImages;
		[SerializeField]
		private Text[] m_titleTexts;
		[SerializeField]
		private Text[] m_desc1Texts;
		[SerializeField]
		private Text[] m_desc2Texts;
	}
}
