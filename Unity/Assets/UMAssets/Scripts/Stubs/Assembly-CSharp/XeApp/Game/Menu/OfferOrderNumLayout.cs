using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferOrderNumLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase orderNum;
		[SerializeField]
		private NumberBase orderMaxNum;
		[SerializeField]
		private ActionButton m_allGetButton;
		[SerializeField]
		private ActionButton m_updownButton;
		[SerializeField]
		private RawImageEx m_updownText;
	}
}
