using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomStampItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_charactorImage;
		[SerializeField]
		private RawImageEx m_serifImage;
		[SerializeField]
		private Text m_numText;
		[SerializeField]
		private StayButton m_editCharaButton;
		[SerializeField]
		private ActionButton m_createButton;
		[SerializeField]
		private Text[] m_serifText;
	}
}
