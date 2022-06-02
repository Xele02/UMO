using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectMusicInfo : LayoutLabelScriptBase
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
	}
}
