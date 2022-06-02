using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectEventBanner : LayoutLabelScriptBase
	{
		[SerializeField]
		private RawImageEx m_eventBannerImage;
		[SerializeField]
		private RawImageEx m_eventTicketImage;
		[SerializeField]
		private RawImageEx m_timeImage;
		[SerializeField]
		private ButtonBase m_bannerButton;
		[SerializeField]
		private Text m_disabledText;
		[SerializeField]
		private Text m_limitTimeText;
		[SerializeField]
		private NumberBase m_curTicketCount;
	}
}
