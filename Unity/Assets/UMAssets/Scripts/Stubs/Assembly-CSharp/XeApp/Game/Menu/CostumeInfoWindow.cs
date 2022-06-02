using XeSys.Gfx;
using System;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CostumeInfoWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class CostumeInfo
		{
			public Text name;
			public Text total;
			public Text soul;
			public Text voice;
			public Text charm;
			public Text life;
			public Text support;
			public Text fold;
			public Text effect1;
			public Text effect2;
			public RawImageEx costume;
		}

		[SerializeField]
		private CostumeInfo[] m_panel_data;
		[SerializeField]
		private RawImageEx[] m_state_icon;
		[SerializeField]
		private CheckboxButton m_homeCostumeCheckBox;
		[SerializeField]
		private Text m_homeCostumeCheckText;
	}
}
