using UnityEngine;
using System;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class HomeFesBanner : MonoBehaviour
	{
		[Serializable]
		public class ReplaceInfo
		{
			public string name;
			public Sprite sprite;
		}

		[SerializeField]
		private ReplaceInfo[] m_tableReplace;
		[SerializeField]
		private Image m_imageBannerIcon;
		[SerializeField]
		private ButtonBase m_buttonBanner;
		[SerializeField]
		private GameObject m_textPeriodSwitch;
		[SerializeField]
		private Text m_textPeriod;
		[SerializeField]
		private GameObject m_textStatusSwitch;
		[SerializeField]
		private Text m_textStatus;
		[SerializeField]
		private RawImageEx m_imageTicketIcon;
		[SerializeField]
		private Text m_textTicketNum;
		[SerializeField]
		private InOutAnime m_inOutAnime;
		[SerializeField]
		private CanvasGroup m_canvasGroup;
	}
}
