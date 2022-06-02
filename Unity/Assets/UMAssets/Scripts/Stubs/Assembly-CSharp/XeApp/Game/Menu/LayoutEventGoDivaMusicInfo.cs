using XeSys.Gfx;
using XeApp.Game;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaMusicInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private TextureListSupport m_textureListSupport;
		[SerializeField]
		private RawImageEx m_imageLineIcon;
		[SerializeField]
		private ActionButton m_buttonChangeDiva;
		[SerializeField]
		private ActionButton m_buttonChangeMusic;
		[SerializeField]
		private ActionButton m_buttonRandomMusic;
		[SerializeField]
		private RawImageEx m_imageDifficulty;
		[SerializeField]
		private Text[] m_textExpTbl;
		[SerializeField]
		private LayoutEventGoDivaAttrFrame m_attrFrame;
		[SerializeField]
		private RawImageEx m_imageJacket;
		[SerializeField]
		private ActionButton m_buttonUseBonusItem;
		[SerializeField]
		private Text m_textBonusRate;
		[SerializeField]
		private Text[] m_textBonusRemainCountTbl;
		[SerializeField]
		private Text m_textBonus;
		[SerializeField]
		private MusicSelectPlayButton m_playButton;
		[SerializeField]
		private Text m_textLevel;
		[SerializeField]
		private Text m_textHighScore;
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private Text m_textSinger;
	}
}
