using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Gacha
{
	public class GachaResultButtonSet : LayoutLabelScriptBase
	{
		[SerializeField]
		private GachaResultRetryButton m_retryButton;
		[SerializeField]
		private ActionButton m_backButton;
		[SerializeField]
		private ActionButton m_legalDescButton;
		[SerializeField]
		private ActionButton m_confirmButton;
		[SerializeField]
		private RawImageEx m_imageKakuteiInfo;
		[SerializeField]
		private Font m_fontKakutei;
		[SerializeField]
		private Text m_textKakutei;
		[SerializeField]
		private Text m_textTelop;
	}
}
