using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkMusicListContentLayout : MonoBehaviour
	{
		[SerializeField]
		private UGUISwapScrollList m_scrollList;
		[SerializeField]
		private GameObject m_scrollObjet;
		[SerializeField]
		private Text m_musicNoneText;
	}
}
