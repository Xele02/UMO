using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkContentLayout : MonoBehaviour
	{
		[SerializeField]
		private UGUIToggleButton[] m_bookMarkCheckBox;
		[SerializeField]
		private Text[] m_bookMarkName;
		[SerializeField]
		private UGUIButton[] m_changeNameButton;
		[SerializeField]
		private UGUIButton[] m_bookMarakButton;
		public int m_nameMaxLength;
	}
}
