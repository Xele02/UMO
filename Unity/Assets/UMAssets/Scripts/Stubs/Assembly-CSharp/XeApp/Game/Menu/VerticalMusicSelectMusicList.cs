using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicList : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private MusicScrollView m_musicScroll;
		[SerializeField]
		private GameObject m_emptyTextObj;
		[SerializeField]
		private TextMeshProUGUI m_emptyText;
		[SerializeField]
		private Animator m_listUpdateAnim;
	}
}
