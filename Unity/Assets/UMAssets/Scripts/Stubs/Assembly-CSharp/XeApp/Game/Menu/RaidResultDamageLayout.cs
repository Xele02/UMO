using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidResultDamageLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private Text m_pointText;
		[SerializeField]
		private Text m_damageText;
		[SerializeField]
		private NumberBase m_numDamage;
	}
}
