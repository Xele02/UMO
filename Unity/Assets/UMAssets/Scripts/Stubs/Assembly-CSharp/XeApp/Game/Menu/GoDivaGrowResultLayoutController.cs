using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GoDivaGrowResultLayoutController : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textPoint;
		[SerializeField]
		private Text m_textPointEf;
		[SerializeField]
		private Text[] m_textBonusExp;
		[SerializeField]
		private Text[] m_textGauge;
		[SerializeField]
		private NumberBase[] m_levelCapNum;
		[SerializeField]
		private NumberBase[] m_levelNum;
		[SerializeField]
		private NumberBase[] m_totalExpNum;
	}
}
