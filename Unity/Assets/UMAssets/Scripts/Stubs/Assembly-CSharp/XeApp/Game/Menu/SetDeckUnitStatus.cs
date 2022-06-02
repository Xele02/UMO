using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitStatus : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private Text m_unitNameText;
		[SerializeField]
		private UGUIButton m_nameEditButton;
		[SerializeField]
		private SetDeckStatusValueControl m_totalStatus;
		[SerializeField]
		private Text m_invalidTotalText;
		[SerializeField]
		private GameObject m_episodeBonusObject;
		[SerializeField]
		private Text m_episodeBonusText;
		[SerializeField]
		private UGUIButton m_episodeBonusButton;
		[SerializeField]
		private UGUIButton m_checkStatusButton;
		[SerializeField]
		private Image m_checkStatusButtonImage;
		[SerializeField]
		private Text m_checkStatusButtonTextNormal;
		[SerializeField]
		private Text m_checkStatusButtonTextDisplay;
		[SerializeField]
		private UGUIButton m_dispTypeButton;
		[SerializeField]
		private Sprite m_checkStatusButtonSpriteNormal;
		[SerializeField]
		private Sprite m_checkStatusButtonSpriteDisplay;
	}
}
