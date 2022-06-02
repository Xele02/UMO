using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SnsNotificationLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_faceIcon;
		[SerializeField]
		private RawImageEx m_offerFaceIcon;
		[SerializeField]
		private Text m_roomText;
		[SerializeField]
		private Text m_messageText;
		[SerializeField]
		private SnsNotificationButton m_button;
		[SerializeField]
		private SnsNotificationButton m_offerButton;
		[SerializeField]
		private Text m_OfferText;
	}
}
