using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2PlateSmall : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text info;
		[SerializeField]
		private Text plateName;
		[SerializeField]
		private RawImageEx plateImage;
		[SerializeField]
		private StayButton btn;
	}
}
