using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleExGauge : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_textWinPoint;
		[SerializeField]
		private Text m_textLosePoint;
		[SerializeField]
		private Text m_textValue;
		[SerializeField]
		private RawImageEx m_imageClass;
		[SerializeField]
		private LayoutBattleExGauge m_layoutGauge;
	}
}
