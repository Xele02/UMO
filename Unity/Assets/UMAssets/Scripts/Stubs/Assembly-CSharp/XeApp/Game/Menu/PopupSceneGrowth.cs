using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupSceneGrowth : UIBehaviour
	{
		[SerializeField]
		private RectTransform m_rectTransform;
		[SerializeField]
		private Text[] m_needItemTexts;
		[SerializeField]
		private Text m_needMoneyText;
	}
}
