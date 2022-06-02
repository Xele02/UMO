using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGakuyaPresentUse2Contents : UIBehaviour
	{
		[SerializeField]
		private RawImage m_imagePresent;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private Text m_useItemValText;
		[SerializeField]
		private Text m_cautionText;
		[SerializeField]
		private UGUIButton m_subButton;
		[SerializeField]
		private UGUIButton m_addButton;
	}
}
