using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateRankingListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textRank;
		[SerializeField]
		private Text m_textGradeName;
		[SerializeField]
		private Text m_textRateNum;
		[SerializeField]
		private Text m_textRanking;
		[SerializeField]
		private RawImageEx m_imageDiva;
		[SerializeField]
		private RawImageEx m_imageScene;
		[SerializeField]
		private RawImageEx m_imageGrade;
		[SerializeField]
		private ButtonBase m_buttonProf;
	}
}
