using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBannerItem : SelectScrollViewContent
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx m_imageBanner;
		[SerializeField]
		private RawImageEx[] m_imageBadge;
		[SerializeField]
		private RawImageEx m_imageEvTicket;
		[SerializeField]
		private ButtonBase m_button;
	}
}
