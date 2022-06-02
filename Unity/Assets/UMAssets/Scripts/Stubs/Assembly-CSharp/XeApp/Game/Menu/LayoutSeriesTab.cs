using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutSeriesTab : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<ActionButton> m_SeriesButtons;
		[SerializeField]
		private List<RawImageEx> m_LogoImages;
	}
}
