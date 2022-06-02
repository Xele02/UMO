using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutShopListItem : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textLimit;
		[SerializeField]
		private Text m_textGetLimit;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textMedal;
		[SerializeField]
		private Text m_textClose;
		[SerializeField]
		private RawImageEx[] m_imageMedal;
		[SerializeField]
		private ActionButton m_button;
	}
}
