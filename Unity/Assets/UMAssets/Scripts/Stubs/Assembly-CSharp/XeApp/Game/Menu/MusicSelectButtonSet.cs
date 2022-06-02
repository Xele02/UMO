using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectButtonSet : LayoutLabelScriptBase
	{
		public enum OptionStyle
		{
			None = 0,
			Basic = 1,
			QuestEvent = 2,
			QuestEventInfo = 3,
			QuestEventSelect = 4,
			CollectEvent = 5,
			ScoreEvent = 6,
			BattleEvent = 7,
			SimulationLive = 8,
			EndEventHome = 9,
			GoDivaEvent = 10,
			GoDivaEventEnd = 11,
		}

		[SerializeField]
		private List<MusicSelectOptionButton> m_optionButtons;
	}
}
