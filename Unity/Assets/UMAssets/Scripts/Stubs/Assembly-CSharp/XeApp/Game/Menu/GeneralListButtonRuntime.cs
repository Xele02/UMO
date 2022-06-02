using XeSys.Gfx;
using XeApp.Game;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GeneralListButtonRuntime : LayoutLabelScriptBase
	{
		[SerializeField]
		private TextureListSupport m_texListSupport;
		[SerializeField]
		private ActionButton m_friendButtonLeft;
		[SerializeField]
		private ActionButton m_friendButtonRight;
		[SerializeField]
		private ActionButton m_reloadButton;
		[SerializeField]
		private RawImageEx m_sortTypeImage;
		[SerializeField]
		private RawImageEx m_sortOrderImage;
	}
}
