using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SpEventButton : ActionButton
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private RawImageEx m_imageButton;
		[SerializeField]
		private Text m_textLimit;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private NumberBase m_numberUnlock;
		[SerializeField]
		private RectTransform m_rectNewRoot;
		[SerializeField]
		private bool m_isLargeSize;
	}
}
