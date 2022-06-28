using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class LuckyLeafOpenAbility : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text[] prevLeafEffectTexts;
		[SerializeField]
		private Text[] addLeafEffectTexts;
		[SerializeField]
		private Text unlockCondition;
		[SerializeField]
		private Text skillCaution;
		[SerializeField]
		private Text kiraCaution;
		[SerializeField]
		private ActionButton helpButton;
	}
}
