using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomePlayRecordBanner : MonoBehaviour
	{
		[SerializeField]
		private ButtonBase m_button;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
