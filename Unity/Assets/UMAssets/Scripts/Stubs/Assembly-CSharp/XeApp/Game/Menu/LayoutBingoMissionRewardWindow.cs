using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMissionRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		public List<string> missionTextList;
	}
}
