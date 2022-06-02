using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidBottomButtonLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_requestHelpButton;
		[SerializeField]
		private ActionButton m_encounterBossButton;
		[SerializeField]
		private ActionButton m_itemButton;
		[SerializeField]
		private RawImageEx m_itemImage;
		[SerializeField]
		private NumberBase m_itemNum;
		[SerializeField]
		private NumberBase m_helpNum;
		[SerializeField]
		private Text m_remainCount;
	}
}
