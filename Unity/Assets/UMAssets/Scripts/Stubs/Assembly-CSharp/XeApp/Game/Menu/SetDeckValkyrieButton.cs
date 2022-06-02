using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckValkyrieButton : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private Image m_abilityImage;
		[SerializeField]
		private Image m_emptyImage;
		[SerializeField]
		private RawImage m_valkyrieImage;
		[SerializeField]
		private UGUIStayButton m_valkyrieButton;
		[SerializeField]
		private GameObject m_tapGuardObject;
	}
}
