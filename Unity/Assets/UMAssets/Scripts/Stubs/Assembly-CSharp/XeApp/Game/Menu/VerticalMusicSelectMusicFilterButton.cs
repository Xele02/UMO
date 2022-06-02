using UnityEngine;
using XeApp.Game.Common;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicFilterButton : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private GameObject[] m_filterObj;
		[SerializeField]
		private TextMeshProUGUI[] m_sortText;
	}
}
