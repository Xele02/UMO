using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossButtonsLayout : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RaidActSelectOptionButton m_rankingButton;
		[SerializeField]
		private RaidActSelectOptionButton m_rewardListButton;
		[SerializeField]
		private RaidActSelectOptionButton m_missionButton;
	}
}
