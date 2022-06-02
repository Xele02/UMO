using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDCursor : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_remainPrefix;
		[SerializeField]
		private Text m_remainPostfix;
		[SerializeField]
		private Text m_endMessage;
		[SerializeField]
		private Text m_bonusMessage;
		[SerializeField]
		private Text m_musicRatio;
		[SerializeField]
		private Text m_musicRankingText;
		[SerializeField]
		private Text m_stepCountText;
		[SerializeField]
		private Text m_eventGoDivaExpBonudText;
		[SerializeField]
		private Text m_eventGoDivaRankingText;
		[SerializeField]
		private Text[] m_eventGoDivaExpTypeText;
		[SerializeField]
		private Text[] m_eventGoDivaExpValueText;
		[SerializeField]
		private RawImageEx m_endPanelImage;
		[SerializeField]
		private RawImageEx m_bonusPanelImage;
		[SerializeField]
		private NumberBase m_playCount;
		[SerializeField]
		private NumberBase m_ticketCount;
		[SerializeField]
		private NumberBase m_rankValue;
		[SerializeField]
		private List<RawImageEx> m_itemImages;
		[SerializeField]
		private GameObject m_newIconParent;
		[SerializeField]
		private MusicSelectAttrFrame m_attrFrame;
		[SerializeField]
		private RawImageEx m_rewardMarkForScore;
		[SerializeField]
		private RawImageEx m_rewardMarkForCombo;
		[SerializeField]
		private RawImageEx m_rewardMarkForClearCount;
		[SerializeField]
		private RawImageEx m_coutingMarkImage;
		[SerializeField]
		private List<RawImageEx> m_eventTicketImage;
		[SerializeField]
		private RawImageEx m_frameImage;
		[SerializeField]
		private RawImageEx m_ratioImage;
	}
}
