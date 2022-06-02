using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class DivaChangePopup : UIBehaviour
	{
		[SerializeField]
		private List<Text> m_divaNameTexts;
		[SerializeField]
		private List<RawImage> m_divaImages;
		[SerializeField]
		private Text m_messageText;
	}
}
