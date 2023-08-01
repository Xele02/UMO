using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockDiva : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private RawImageEx m_diva;
		[SerializeField]
		private Text m_comment;
		[SerializeField]
		private Text m_birthday;
		[SerializeField]
		private Text m_age;
		[SerializeField]
		private Text m_birthplace;
		[SerializeField]
		private Text m_like;
	}
}
