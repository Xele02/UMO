using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class InputContent : UIBehaviour
	{
		[SerializeField]
		private InputField m_input;
		[SerializeField]
		private Text m_descriptionText;
		[SerializeField]
		private Text m_notesText;
	}
}
