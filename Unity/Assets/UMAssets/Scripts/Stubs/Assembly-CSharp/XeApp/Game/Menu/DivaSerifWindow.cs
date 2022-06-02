using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaSerifWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private RawImageEx m_imageItemIcon;
		[SerializeField]
		private RawImageEx m_imageMusicrateIcon;
		[SerializeField]
		private Text m_textMusicrateGrade;
		[SerializeField]
		private Text m_textMusicrateRate;
		[SerializeField]
		private Text m_textMusicrateRank;
		[SerializeField]
		private Text m_textMusicrateRankUnit;
		[SerializeField]
		private Text m_textNoItem;
		[SerializeField]
		private ActionButton m_btnMusicrateDetail;
		[SerializeField]
		private ActionButton m_btnChangeWindow;
	}
}
