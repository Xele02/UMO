using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectEventBanner : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		[SerializeField]
		private UGUIButton m_uGUIButton;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private RawImage m_eventBunnerImage;
		[SerializeField]
		private GameObject m_countingObj;
		[SerializeField]
		private GameObject m_openObj;
		[SerializeField]
		private TextMeshProUGUI m_limitTime;
		[SerializeField]
		private InOutAnime m_pullDownInOut;
		[SerializeField]
		private UGUIButton m_pullDownButton;
	}
}
