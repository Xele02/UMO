using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckDivaCardControl : MonoBehaviour
	{
		[SerializeField]
		private UGUIStayButton m_divaButton;
		[SerializeField]
		private Image m_emptyBackImage;
		[SerializeField]
		private Image m_divaBackImage;
		[SerializeField]
		private Image m_emptyImage;
		[SerializeField]
		private RawImage m_divaImage;
		[SerializeField]
		private RawImage m_divaIconImage;
		[SerializeField]
		private Image m_divaFrameImage;
		[SerializeField]
		private Image m_divaFrontImage;
		[SerializeField]
		private Image m_unitIconImage;
		[SerializeField]
		private SetDeckDivaStatusControl m_divaStatus;
		[SerializeField]
		private UGUIButton m_costumeButton;
		[SerializeField]
		private RawImage m_costumeImage;
		[SerializeField]
		private GameObject m_costumeImpObject;
		[SerializeField]
		private GameObject m_divaImpObject;
		[SerializeField]
		private Image m_prismImpImage;
		[SerializeField]
		private Text m_messageText;
		[SerializeField]
		private DivaColorSetScriptableObject m_divaColors;
	}
}
