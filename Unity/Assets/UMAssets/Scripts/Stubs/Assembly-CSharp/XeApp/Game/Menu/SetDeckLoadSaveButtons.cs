using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckLoadSaveButtons : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIButton m_saveButton;
		[SerializeField]
		private UGUIButton m_loadButton;
		[SerializeField]
		private Image m_SaveTextSprite;
		[SerializeField]
		private UnitSetSaveTextScriptableObject m_SaveTextSpriteList;
	}
}
