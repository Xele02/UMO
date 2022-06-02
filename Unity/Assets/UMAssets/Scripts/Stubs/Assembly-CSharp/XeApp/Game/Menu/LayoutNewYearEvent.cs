using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutNewYearEvent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<RawImageEx> m_imageTitle;
		[SerializeField]
		private Text m_textPeriod;
		[SerializeField]
		private List<SpEventButton> m_btnList;
		[SerializeField]
		private List<Text> m_textNext;
		[SerializeField]
		private List<RawImageEx> m_imageNext;
	}
}
