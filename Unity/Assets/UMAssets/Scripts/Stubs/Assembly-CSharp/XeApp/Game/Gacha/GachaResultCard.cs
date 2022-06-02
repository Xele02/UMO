using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Gacha
{
	public class GachaResultCard : LayoutLabelScriptBase
	{
		[SerializeField]
		private int m_cardIndex;
		[SerializeField]
		private RawImageEx m_cardImage;
		[SerializeField]
		private RawImageEx m_frameImage;
		[SerializeField]
		private LayoutUGUIHitOnly m_hitOnly;
		[SerializeField]
		private StayButton m_stayButton;
		[SerializeField]
		private RectTransform m_newDecoRoot;
	}
}
