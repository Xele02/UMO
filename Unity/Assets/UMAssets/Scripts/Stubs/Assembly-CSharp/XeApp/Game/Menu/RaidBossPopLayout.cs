using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossPopLayout : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private RawImageEx m_bossImage;
		[SerializeField]
		private bool isSp;
	}
}
