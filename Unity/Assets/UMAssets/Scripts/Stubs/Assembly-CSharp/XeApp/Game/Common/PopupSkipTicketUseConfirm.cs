using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupSkipTicketUseConfirm : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageIcon;
		[SerializeField]
		private StayButton m_itemButton;
		[SerializeField]
		private ActionButton m_minusButton;
		[SerializeField]
		private ActionButton m_plusButton;
		[SerializeField]
		private Text m_itemNameText;
		[SerializeField]
		private Text m_itemValueText;
		[SerializeField]
		private Text[] m_skipTicketTexts;
		[SerializeField]
		private Text[] m_consumeItemTexts;
		[SerializeField]
		private Text m_cautionText;
	}
}
