using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationItemCollection : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_itemNum;
		[SerializeField]
		private NumberBase m_pointNum;
		[SerializeField]
		private RawImageEx m_medalImage;
		[SerializeField]
		private RawImageEx m_pointImage;
		[SerializeField]
		private ActionButton m_button;
	}
}
