using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GakuyaPresentListContent : SwapScrollListContent
	{
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private RawImage m_imagePresent;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textCount;
		[SerializeField]
		private ColorGroup m_contentColorGroup;
		[SerializeField]
		private Color m_colorNormal;
		[SerializeField]
		private Color m_colorImp;
	}
}
