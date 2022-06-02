using UnityEngine;
using TMPro;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectUtaRate : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_textUtaRate;
		[SerializeField]
		private RawImageEx m_utaRateIcon;
		[SerializeField]
		private UGUIButton m_utaRateButton;
		[SerializeField]
		private InOutAnime m_inOut;
	}
}
