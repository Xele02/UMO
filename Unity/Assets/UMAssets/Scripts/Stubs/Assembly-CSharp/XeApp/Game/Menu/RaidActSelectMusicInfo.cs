using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidActSelectMusicInfo : LayoutLabelScriptBase
	{
		[SerializeField]
		private List<MusicSelectDiffButton> m_diffButtons;
		[SerializeField]
		private Text m_musicTitle;
		[SerializeField]
		private Text m_singerName;
		[SerializeField]
		private Text m_musicLevel;
		[SerializeField]
		private Text m_reward;
		[SerializeField]
		private Text m_highscore;
		[SerializeField]
		private Text m_comboCount;
		[SerializeField]
		private Text m_noInfoText;
		[SerializeField]
		private Text m_eventTitle;
		[SerializeField]
		private Text m_eventDesc;
		[SerializeField]
		private Text m_eventPeriod;
		[SerializeField]
		private Text m_simMusicTitle;
		[SerializeField]
		private Text m_simSingerName;
		[SerializeField]
		private RawImageEx m_cdJacketImage;
		[SerializeField]
		private ActionButton m_unitButton;
		[SerializeField]
		private RawImageEx m_imageOnOff;
		[SerializeField]
		private RawImageEx m_imageDisable;
		[SerializeField]
		private ActionButton m_arrorwLeft;
		[SerializeField]
		private ActionButton m_arrorwRight;
		[SerializeField]
		private SwaipTouch m_swipeTouch;
		[SerializeField]
		private SwaipTouch m_swipeTouch6;
	}
}
