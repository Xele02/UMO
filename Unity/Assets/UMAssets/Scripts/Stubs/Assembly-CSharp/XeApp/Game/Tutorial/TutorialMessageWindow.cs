using UnityEngine;
using XeApp.Game;
using UnityEngine.UI;
using XeApp.Game.Adv;

namespace XeApp.Game.Tutorial
{
	public class TutorialMessageWindow : MonoBehaviour
	{
		[SerializeField]
		private AnchorPositionTween m_sendCursorTween;
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private AdvMessage m_messageText;
		[SerializeField]
		private RawImage m_charaIconImage;
		[SerializeField]
		private Image m_messageWindowImage;
		[SerializeField]
		private Sprite[] m_windowPartsSprite;
		[SerializeField]
		private ColorTween[] m_colorTweens;
		[SerializeField]
		private float m_messageSpeed;
	}
}
