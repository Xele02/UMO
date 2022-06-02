using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeApp.Game;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListDecoWindow : LayoutShopListBase
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
		private RawImageEx[] m_imageMedal;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private Text m_noProductText;
		[SerializeField]
		private TextureListSupport m_texListSupport;
		[SerializeField]
		private RawImageEx m_filterButtonLabel;
		[SerializeField]
		private List<ActionButton> m_DecoTypeButtons;
		[SerializeField]
		private ActionButton m_extraTabButton;
	}
}
