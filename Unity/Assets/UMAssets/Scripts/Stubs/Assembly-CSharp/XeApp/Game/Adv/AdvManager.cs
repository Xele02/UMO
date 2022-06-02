using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;
using XeApp.Game.Common;

namespace XeApp.Game.Adv
{
	public class AdvManager : MonoBehaviour
	{
		[SerializeField]
		private AdvCharacter m_advCharacterPrefab;
		[SerializeField]
		private RawImage m_bg;
		[SerializeField]
		private Button m_skipButton;
		[SerializeField]
		private TweenBase[] m_sendIconTween;
		[SerializeField]
		private MessageWindowInfo[] m_windowInfo;
		[SerializeField]
		private RectTransform m_charaRoot;
		[SerializeField]
		private Button m_touchArea;
		[SerializeField]
		private RectTransform m_animeRoot;
		[SerializeField]
		private float[] m_messageSpeed;
		[SerializeField]
		private float FADE_TIME;
		[SerializeField]
		private AdvVoicePlayer m_advVoicePlayer;
	}
}
