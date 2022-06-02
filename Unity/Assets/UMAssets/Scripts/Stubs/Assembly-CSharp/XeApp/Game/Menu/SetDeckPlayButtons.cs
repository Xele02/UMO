using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckPlayButtons : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIPositionTable m_posTable;
		[SerializeField]
		private UGUIButton m_skipButton;
		[SerializeField]
		private ColorGroup m_skipButtonColorGroup;
		[SerializeField]
		private Text m_skipRestCountText;
		[SerializeField]
		private Image m_skipButtonLockImage;
		[SerializeField]
		private UGUIButton m_playButton;
		[SerializeField]
		private GameObject m_playObject;
		[SerializeField]
		private GameObject m_supportObject;
		[SerializeField]
		private GameObject m_energyObject;
		[SerializeField]
		private Text m_energyNameText;
		[SerializeField]
		private Text m_energyText;
	}
}
