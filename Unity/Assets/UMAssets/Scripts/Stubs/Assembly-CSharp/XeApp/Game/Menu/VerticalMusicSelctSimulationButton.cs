using UnityEngine;
using XeApp.Game.Common;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelctSimulationButton : MonoBehaviour
	{
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private TextMeshProUGUI m_tokenText;
		[SerializeField]
		private GameObject m_lockObj;
	}
}
