using UnityEngine;
using XeApp.Game;
using UnityEngine.UI;
using XeApp.Game.Adv;
using System.Collections.Generic;

namespace XeApp.Game.Tutorial
{
	public class TutorialMessageWindow : MonoBehaviour
	{
		public enum Position
		{
			Top = 0,
			Bottom = 1,
		}

		[SerializeField]
		private AnchorPositionTween m_sendCursorTween; // 0xC
		[SerializeField]
		private Text m_nameText; // 0x10
		[SerializeField]
		private AdvMessage m_messageText; // 0x14
		[SerializeField]
		private RawImage m_charaIconImage; // 0x18
		[SerializeField]
		private Image m_messageWindowImage; // 0x1C
		[SerializeField]
		private Sprite[] m_windowPartsSprite; // 0x20
		[SerializeField]
		private ColorTween[] m_colorTweens; // 0x24
		[SerializeField]
		private float m_messageSpeed = 0.025f; // 0x28
		private Coroutine m_sendCursorCoroutine; // 0x2C
		private const float m_windowPositionX = 0;
		private bool m_isShow; // 0x30
		private RectTransform m_rectTransform; // 0x34
		private Dictionary<int, int> m_charaSpriteMap = new Dictionary<int, int>()
		{
			{ 3, 0 }, { 1, 1 }, { 12, 2 }
		}; // 0x38
		private bool m_isRunning; // 0x3C

		//public bool IsRunning { get; } 0xE4842C

		// RVA: 0xE48434 Offset: 0xE48434 VA: 0xE48434
		private void Awake()
		{
			m_rectTransform = transform.GetChild(0).GetComponent<RectTransform>();
			HideSendCursor();
		}

		// RVA: 0xE4855C Offset: 0xE4855C VA: 0xE4855C
		private void Start()
		{
			m_nameText.font = GameManager.Instance.GetSystemFont();
			m_messageText.Text.font = GameManager.Instance.GetSystemFont();
		}

		//// RVA: 0xE48694 Offset: 0xE48694 VA: 0xE48694
		//public void Show(TutorialMessageWindow.Position pos) { }

		//// RVA: 0xE4454C Offset: 0xE4454C VA: 0xE4454C
		//public void ResetWindow() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEB50 Offset: 0x6AEB50 VA: 0x6AEB50
		//// RVA: 0xE4881C Offset: 0xE4881C VA: 0xE4881C
		//private IEnumerator ShowCoroutine() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6AEBC8 Offset: 0x6AEBC8 VA: 0x6AEBC8
		//// RVA: 0xE445A8 Offset: 0xE445A8 VA: 0xE445A8
		//public IEnumerator ProcMessageCoroutine(int charaNo, TutorialMessageWindow.Position pos, string message, AdvMessageBase.TagConvertFunc func) { }

		//// RVA: 0xE488E8 Offset: 0xE488E8 VA: 0xE488E8
		//private bool IsTouchScreen() { }

		//// RVA: 0xE48B10 Offset: 0xE48B10 VA: 0xE48B10
		//private bool IsTouchPoisitionInScreen(Vector2 screenPos) { }

		//// RVA: 0xE48C54 Offset: 0xE48C54 VA: 0xE48C54
		//private void ShowSendCursor() { }

		//// RVA: 0xE484E8 Offset: 0xE484E8 VA: 0xE484E8
		private void HideSendCursor()
		{
			if (m_sendCursorCoroutine != null)
			{
				this.StopCoroutineWatched(m_sendCursorCoroutine);
				m_sendCursorCoroutine = null;
			}
			m_sendCursorTween.gameObject.SetActive(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEC40 Offset: 0x6AEC40 VA: 0x6AEC40
		//// RVA: 0xE48CE4 Offset: 0xE48CE4 VA: 0xE48CE4
		//private IEnumerator SendCursorAnimationCoroutine() { }
	}
}
