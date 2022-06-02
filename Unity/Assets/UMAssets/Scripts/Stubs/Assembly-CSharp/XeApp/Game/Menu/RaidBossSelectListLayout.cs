using XeSys.Gfx;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectListLayout : LayoutUGUIScriptBase
	{
		[Serializable]
		public class BossPanel
		{
			public int panelIndex;
			public bool isSp;
			public Text nameText1;
			public Text nameText2;
			public Text timeText1;
			public Text timeText2;
			public Text joinMemberText;
			public RawImageEx playerIcon;
			public RawImageEx musicRateImage1;
			public RawImageEx musicRateImage2;
			public ActionButton attackButton;
			public NumberBase hpNum1;
			public NumberBase hpNum2;
			public ButtonBase iconButton;
			public List<RawImageEx> panelImageList;
		}

		[SerializeField]
		private List<RaidBossSelectListLayout.BossPanel> m_bossPanelList;
		[SerializeField]
		private RaidBossSelectReelScroller m_scroller;
		[SerializeField]
		private RawImageEx topArrow;
		[SerializeField]
		private RawImageEx bottonArrow;
	}
}
