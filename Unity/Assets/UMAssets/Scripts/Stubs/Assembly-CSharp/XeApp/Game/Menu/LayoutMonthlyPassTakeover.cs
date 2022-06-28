using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutMonthlyPassTakeover : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton ContractedButton;
		[SerializeField]
		private ActionButton NotContractButton;
		[SerializeField]
		private Text ConfirmationText;
	}
}
