using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LobbyStampItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_charaStampIcon;
		[SerializeField]
		private RawImageEx m_messgeBalloon;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private Text[] m_stampMesList;
	}
}
