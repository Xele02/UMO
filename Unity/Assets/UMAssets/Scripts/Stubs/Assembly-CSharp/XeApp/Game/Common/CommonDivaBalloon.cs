using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class CommonDivaBalloon : MonoBehaviour
	{
		[SerializeField]
		private Image m_imageFrame;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		[SerializeField]
		private float m_intervalCloseWindowMax;
		[SerializeField]
		private Color[] m_colorTable;
	}
}
