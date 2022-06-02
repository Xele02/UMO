using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class HomeEventBanner : MonoBehaviour
	{
		[SerializeField]
		private float m_autoScrollWait;
		[SerializeField]
		private GridLayoutGroup m_gridLayoutGroup;
		[SerializeField]
		private BannerScrollView m_scrollView;
		[SerializeField]
		private HomeEventBannerContent m_objBanner;
		[SerializeField]
		private Transform m_rootPageIcon;
		[SerializeField]
		private Toggle m_basePageIcon;
		[SerializeField]
		private ButtonBase m_buttonLeft;
		[SerializeField]
		private ButtonBase m_buttonRight;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
	}
}
