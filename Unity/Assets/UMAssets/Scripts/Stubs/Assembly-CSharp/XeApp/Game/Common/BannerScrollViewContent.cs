using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class BannerScrollViewContent : SelectScrollViewContent
	{
		[SerializeField]
		protected RawImageEx m_imageBanner;
		[SerializeField]
		protected ButtonBase m_buttonBanner;
		[SerializeField]
		protected GameObject m_textPeriodSwitch;
		[SerializeField]
		protected Text m_textPeriod;
	}
}
