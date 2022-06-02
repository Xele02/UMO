using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicRateListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_textTotalNum;
		[SerializeField]
		private Text m_textGrade;
		[SerializeField]
		private Text m_textScroll;
		[SerializeField]
		private Text m_textNextRate_01;
		[SerializeField]
		private Text m_textNextRate_02;
		[SerializeField]
		private Text m_textNextRate_03;
		[SerializeField]
		private Text m_textNextRate_04;
		[SerializeField]
		private Text m_textHyphen;
		[SerializeField]
		private RawImageEx m_imageGrade;
		[SerializeField]
		private RawImageEx m_imageNextGrade;
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private ActionButton m_btnHelp;
	}
}
