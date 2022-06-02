using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMissionRewardContents : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx ItemIcon;
		[SerializeField]
		private Text MissionText;
		[SerializeField]
		private Text ItemName;
	}
}
