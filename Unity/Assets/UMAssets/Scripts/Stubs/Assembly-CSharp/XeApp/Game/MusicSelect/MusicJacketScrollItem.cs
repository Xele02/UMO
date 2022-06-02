using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.MusicSelect
{
	public class MusicJacketScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private CanvasGroup m_canvasGroup;
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_scrollTextTitle;
		[SerializeField]
		private RawImageEx m_imageJacket;
		[SerializeField]
		private Image m_imageSelect;
		[SerializeField]
		private SpriteAnime m_animeSelect;
		[SerializeField]
		private Image m_imageAttr;
		[SerializeField]
		private Sprite[] m_tableAttr;
		[SerializeField]
		private Image m_imageLock;
		[SerializeField]
		private UGUIButton m_buttonJacket;
		[SerializeField]
		private Image m_imageBookMark;
	}
}
