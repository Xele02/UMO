using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBox2ListWindow : LayoutGachaBoxListWindow
	{
		[SerializeField]
		private Text m_textContent;
		[SerializeField]
		private RawImageEx[] m_imageButton;
		[SerializeField]
		private ActionButton m_buttonPrev;
		[SerializeField]
		private ActionButton m_buttonNext;
	}
}
