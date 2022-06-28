using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidMvpLayout : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_notesText;
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private Text m_descText;
		[SerializeField]
		private RawImageEx m_bossImage;
		[SerializeField]
		private Text m_playerDamageText;
		[SerializeField]
		private Text m_infoText01;
		[SerializeField]
		private Text m_infoText02;
		[SerializeField]
		private SwapScrollList m_scrollList;
	}
}
