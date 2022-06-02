using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeApp.Game;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListWindow : LayoutShopListBase
	{
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private Text m_textWarning;
		[SerializeField]
		private Text m_textMedal;
		[SerializeField]
		private Text m_textMedalNum;
		[SerializeField]
		private Text m_textInvalid;
		[SerializeField]
		private RawImageEx[] m_imageMedal;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private Text m_textFilter;
		[SerializeField]
		private Text m_textOrder;
		[SerializeField]
		private ActionButton m_buttonFilter;
		[SerializeField]
		private ActionButton m_buttonOrder;
		[SerializeField]
		private TextureListSupport m_texListSupport;
	}
}
