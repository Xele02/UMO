using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidResultEffectBaseLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected NumberBase damageNum1;
		[SerializeField]
		protected NumberBase damageNum2;
		[SerializeField]
		protected NumberBase damageNum3;
		[SerializeField]
		protected Text m_bossName;
	}
}
