using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotFewRuntime : PopupGachaLotRuntime
	{
		[SerializeField]
		private RawImageEx m_needLabelImage;
		[SerializeField]
		private Text[] m_messageCautionTexts;
		[SerializeField]
		private Text m_needCurrencyText;
	}
}
