using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LobbyLayoutItemR : FlexibleListItemLayout
	{
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx m_divaStampIconImage;
		[SerializeField]
		private RawImageEx m_stampBallonImage;
		[SerializeField]
		private Text[] m_textMessge;
		[SerializeField]
		private Text[] m_textUserName;
		[SerializeField]
		private Text[] m_textTime;
		[SerializeField]
		private ActionButton m_chatButton;
		[SerializeField]
		private ActionButton m_movieThumButton;
		[SerializeField]
		private ActionButton m_playerIconButton;
		[SerializeField]
		private NumberBase m_emblemNum;
		[SerializeField]
		private RawImageEx m_musicrate_image;
		[SerializeField]
		private Text m_musicrate_rank_text;
	}
}
