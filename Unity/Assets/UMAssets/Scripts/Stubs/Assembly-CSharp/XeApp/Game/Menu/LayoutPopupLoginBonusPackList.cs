using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupLoginBonusPackList : LayoutPopupLoginBonusPackListBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private RawImageEx m_imageItem;
		[SerializeField]
		private RawImageEx m_imageFrameBtm;
		[SerializeField]
		private RawImageEx m_imageOmake;
		[SerializeField]
		private NumberBase m_numberCount;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text m_textOmake;
	}
}
