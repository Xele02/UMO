using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMissionRewardContents : SwapScrollListContent
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private RawImageEx ItemIcon;
		[SerializeField]
		private Text MissionText;
		[SerializeField]
		private Text ItemName;
	}
}
