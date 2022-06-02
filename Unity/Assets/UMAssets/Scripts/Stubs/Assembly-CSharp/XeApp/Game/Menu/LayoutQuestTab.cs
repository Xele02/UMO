using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutQuestTab : LayoutUGUIScriptBase
	{
		public enum eTabType
		{
			Event = 0,
			Normal = 1,
			Daily = 2,
			Diva = 3,
			Beginner = 4,
			Bingo = 5,
		}

		[SerializeField]
		private ActionButton[] m_buttons;
		[SerializeField]
		private Text[] m_times;
	}
}
