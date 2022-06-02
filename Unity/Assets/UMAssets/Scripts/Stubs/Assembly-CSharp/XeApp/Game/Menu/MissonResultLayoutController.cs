using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MissonResultLayoutController : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_missionInfoText;
		[SerializeField]
		private Text m_missionPerText;
		[SerializeField]
		private Text m_noClearPerText;
		[SerializeField]
		private Text m_basePointText;
		[SerializeField]
		private Text m_missionBonusText;
		[SerializeField]
		private Text m_musicBonusText;
		[SerializeField]
		private Text m_episodeBonusText;
		[SerializeField]
		private Text m_episodeNumText;
		[SerializeField]
		private Text[] m_getPointText;
		[SerializeField]
		private Text m_totalPointText;
		[SerializeField]
		private Text m_medalNumText;
		[SerializeField]
		private RawImageEx m_levelNumImage;
		[SerializeField]
		private RawImageEx m_diffImage;
		[SerializeField]
		private RawImageEx m_medalImage;
		[SerializeField]
		private Text m_militaryMedalText;
		[SerializeField]
		private List<Text> m_textlist_dash;
	}
}
