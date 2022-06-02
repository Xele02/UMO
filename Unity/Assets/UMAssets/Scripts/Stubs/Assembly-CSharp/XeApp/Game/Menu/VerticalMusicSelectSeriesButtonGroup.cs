using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSeriesButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_pullDownButton;
		[SerializeField]
		private InOutAnime m_pullDownInOut;
		[SerializeField]
		private Sprite[] m_seriesSprites;
		[SerializeField]
		private Image[] m_btnImage;
		[SerializeField]
		private TextMeshProUGUI[] m_btnText;
		[SerializeField]
		private Image m_pullDownBtnImage;
		[SerializeField]
		private TextMeshProUGUI m_pullDownBtnText;
	}
}
