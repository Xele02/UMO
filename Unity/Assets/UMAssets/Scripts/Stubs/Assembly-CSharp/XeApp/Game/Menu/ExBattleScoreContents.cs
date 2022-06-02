using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class ExBattleScoreContents : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_jacket;
		[SerializeField]
		private ActionButton m_searchBtn;
		[SerializeField]
		private Text m_scoreText;
		[SerializeField]
		private string EXID;
	}
}
