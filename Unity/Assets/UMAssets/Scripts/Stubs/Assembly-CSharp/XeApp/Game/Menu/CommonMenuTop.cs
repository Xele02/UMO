using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CommonMenuTop : LayoutUGUIScriptBase
	{
		[SerializeField]
		private CommonMenuTopButton[] m_menu_top_button;
		[SerializeField]
		private CommonMenuExpGauge m_exp_gauge;
		[SerializeField]
		private NumberBase m_numberRank;
		[SerializeField]
		private RawImageEx m_imageUtaGrade;
		[SerializeField]
		private Text m_textUtaRate;
		[SerializeField]
		private RawImageEx m_imageMedal;
		[SerializeField]
		private Text m_textMedal;
		[SerializeField]
		private Text m_textEnergyNum;
		[SerializeField]
		private Text m_textEnergyTime;
		[SerializeField]
		private Text m_textUC;
		[SerializeField]
		private Text m_textStone;
		[SerializeField]
		private ButtonBase m_buttonRank;
		[SerializeField]
		private ButtonBase m_buttonUtaRate;
		[SerializeField]
		private CommonMenuTopMiniWindow m_miniWindowPrefab;
	}
}
