using XeSys.Gfx;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidActionSelectLayout : LayoutUGUIScriptBase
	{
		[Serializable]
		public class ActionSelectButton
		{
			public Text buffText;
			public ActionButton decideButton;
			public ActionButton mcrsCannonButton;
		}

		[SerializeField]
		private List<RaidActionSelectLayout.ActionSelectButton> m_actionSelectBtnList;
		[SerializeField]
		private ActionButton m_arrowRButton;
		[SerializeField]
		private ActionButton m_arrowLButton;
		[SerializeField]
		private MusicSelectCDScroller m_scroller;
		[SerializeField]
		private Text attackPlayerText;
		[SerializeField]
		private Button mvpCandidatesButton;
		public Button button1;
		public Button button2;
	}
}
