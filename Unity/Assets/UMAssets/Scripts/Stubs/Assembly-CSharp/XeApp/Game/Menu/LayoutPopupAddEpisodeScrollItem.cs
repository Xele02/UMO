using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisodeScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_episodeName;
		[SerializeField]
		private RawImageEx m_icon;
		[SerializeField]
		private ActionButton m_btnShowAddEpisode;
	}
}
