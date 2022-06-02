using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectEventItem : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		[SerializeField]
		private RawImageEx m_itemIcon;
		[SerializeField]
		private TextMeshProUGUI m_itemNumText;
	}
}
