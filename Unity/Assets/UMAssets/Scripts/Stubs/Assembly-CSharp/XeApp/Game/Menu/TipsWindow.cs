using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class TipsWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private TipsContent m_conten;
		[SerializeField]
		private ActionButton[] m_arrowButtons;
		[SerializeField]
		private RawImageEx[] m_charaImages;
		[SerializeField]
		private RawImageEx[] m_graffitiImages;
	}
}
