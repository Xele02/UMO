using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidApHealWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		private class Content
		{
			public RawImageEx Image;
			public NumberBase Num;
			public Text Text1;
			public Text Text2;
			public Text Text3;
			public ActionButton Button;
			public ActionButton ItemIcon;
		}

		[SerializeField]
		private Text m_infoText;
		[SerializeField]
		private Content[] m_contents;
	}
}
