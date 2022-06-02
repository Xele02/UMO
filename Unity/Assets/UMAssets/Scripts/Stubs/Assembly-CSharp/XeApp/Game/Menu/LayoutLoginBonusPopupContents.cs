using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusPopupContents : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_itemName;
		[SerializeField]
		private RawImageEx m_icon;
		[SerializeField]
		private Text m_desc;
		[SerializeField]
		private NumberBase m_day;
	}
}
