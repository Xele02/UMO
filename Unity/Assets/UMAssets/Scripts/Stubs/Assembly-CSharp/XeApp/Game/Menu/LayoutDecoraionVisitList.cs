using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	internal class LayoutDecoraionVisitList : SwapScrollListContent
	{
		[SerializeField]
		private ButtonBase m_divaIcon;
		[SerializeField]
		private ActionButton m_visitButton;
		[SerializeField]
		private ActionButton m_giftButton;
		[SerializeField]
		private RawImageEx m_giftButtonFont;
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx m_scoreRatingImage;
		[SerializeField]
		private NumberBase m_numberFan;
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private Text m_rankText;
		[SerializeField]
		private Text m_lastLoginTimeText;
		[SerializeField]
		private Text m_mapNameText;
		[SerializeField]
		private Text m_MusicRateRankText;
	}
}
