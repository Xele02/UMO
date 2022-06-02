using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GeneralListWindow : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_windowMessage;
		[SerializeField]
		private Text m_warningMessage;
		[SerializeField]
		private List<Text> m_musicTitle;
		[SerializeField]
		private Text m_rankingMessage;
		[SerializeField]
		private Text m_rankButtonLabel;
		[SerializeField]
		private List<RawImageEx> m_musicAttrImage;
		[SerializeField]
		private RawImageEx m_musicDiffImage;
		[SerializeField]
		private List<RawImageEx> m_musicJacketImage;
		[SerializeField]
		private RawImageEx m_eventBannerImage;
		[SerializeField]
		private List<RawImageEx> m_rankingMessageImage;
		[SerializeField]
		private ActionButton m_innerButton1;
		[SerializeField]
		private ActionButton m_innerButton2;
		[SerializeField]
		private ActionButton m_frameButton;
		[SerializeField]
		private ButtonBase m_totalRankTab;
		[SerializeField]
		private ButtonBase m_friendRankTab;
		[SerializeField]
		private NumberBase m_itemCount;
		[SerializeField]
		private NumberBase m_itemMax;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private List<RawImageEx> m_eventRankingMusicJacketImage;
		[SerializeField]
		private ActionButton m_eventRankingChangeButton;
		[SerializeField]
		private RawImageEx m_eventRankingChangeButtonImage;
		[SerializeField]
		private Text m_txtDivaName;
	}
}
