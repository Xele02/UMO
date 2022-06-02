using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	internal class UnitBonusDetailWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_descText;
		[SerializeField]
		private List<Text> m_nameTextList;
		[SerializeField]
		private List<Text> m_bonusTextList;
		[SerializeField]
		private List<RawImageEx> m_iconImageList;
		[SerializeField]
		private List<RawImageEx> m_mainImageList;
	}
}
