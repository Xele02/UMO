using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidMvpScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_playerIconImage;
		[SerializeField]
		private RawImageEx m_playerPlateImage;
		[SerializeField]
		private Text m_playerNameText;
		[SerializeField]
		private Text m_damageText;
		[SerializeField]
		private Text m_playerRankText;
		[SerializeField]
		private Text m_beText;
		[SerializeField]
		private RawImageEx m_beImage;
		[SerializeField]
		private Text m_eventRankText;
		[SerializeField]
		private ButtonBase m_profileButton;
	}
}
