using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemDetail : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_itemIconImage;
		[SerializeField]
		private Text m_itemNameText;
		[SerializeField]
		private Text m_itemDescriptionText;
		[SerializeField]
		private Text m_decoSetCautionText;
	}
}
