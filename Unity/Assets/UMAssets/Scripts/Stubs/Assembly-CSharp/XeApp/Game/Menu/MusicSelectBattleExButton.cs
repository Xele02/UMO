using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleExButton : LayoutLabelScriptBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private ActionButton m_buttonReSelect;
		[SerializeField]
		private ActionButton m_buttonHiScore;
	}
}
