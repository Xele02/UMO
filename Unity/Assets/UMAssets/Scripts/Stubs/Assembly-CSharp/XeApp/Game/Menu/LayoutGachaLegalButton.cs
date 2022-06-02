using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaLegalButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textDesc1;
		[SerializeField]
		private Text m_textDesc2;
		[SerializeField]
		private Text m_textNormal;
		[SerializeField]
		private ActionButton m_buttonPickup;
		[SerializeField]
		private ActionButton m_buttonDetail;
		[SerializeField]
		private ActionButton m_buttonEpisode;
		[SerializeField]
		private ActionButton m_buttonMovie;
		[SerializeField]
		private ActionButton m_buttonRarity;
		[SerializeField]
		private ActionButton m_buttonPassPurchase;
	}
}
