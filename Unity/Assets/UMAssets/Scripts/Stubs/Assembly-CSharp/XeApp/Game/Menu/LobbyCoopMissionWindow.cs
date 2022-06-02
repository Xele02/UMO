using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LobbyCoopMissionWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_iconButtonList;
		[SerializeField]
		private ActionButton[] m_buttonChallenge;
		[SerializeField]
		private ActionButton[] m_buttonReceive;
		[SerializeField]
		private Text[] m_desc;
		[SerializeField]
		private Text[] m_timeCount;
		[SerializeField]
		private RawImageEx[] m_icon;
		[SerializeField]
		private NumberBase[] m_denominator;
		[SerializeField]
		private NumberBase[] m_molecule;
		[SerializeField]
		private NumberBase[] m_itemCountList;
		public int[] ItemIdList;
		public int[] ItemCountList;
	}
}
