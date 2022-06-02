using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectMusicFilterButton : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private Image m_buttonImage;
		[SerializeField]
		private Sprite m_spriteFilterOff;
		[SerializeField]
		private Sprite m_spriteFilterOn;
	}
}
