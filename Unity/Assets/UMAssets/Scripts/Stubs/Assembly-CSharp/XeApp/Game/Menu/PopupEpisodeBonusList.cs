using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusList : UIBehaviour
	{
		[SerializeField]
		private EpisodeLayoutParts[] m_episodeLayoutParts;
		[SerializeField]
		private Text m_episodePointText;
		[SerializeField]
		private Text m_episodePointNoteText;
		[SerializeField]
		private ActionButton[] m_episodeButtons;
	}
}
