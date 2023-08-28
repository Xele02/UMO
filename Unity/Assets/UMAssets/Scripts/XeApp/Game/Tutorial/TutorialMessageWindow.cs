using UnityEngine;
using XeApp.Game;
using UnityEngine.UI;
using XeApp.Game.Adv;
using System.Collections.Generic;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using XeApp.Game.Menu;
using XeSys;

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
		public void Show(Position pos)
		{
			if(pos == Position.Top)
			{
				m_rectTransform.anchorMax = new Vector2(0.5f, 1);
				m_rectTransform.anchorMin = new Vector2(0.5f, 1);
				m_rectTransform.anchoredPosition = new Vector2(0, -190);
			}
			else
			{
				m_rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
				m_rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
				m_rectTransform.anchoredPosition = new Vector2(0, -266);
			}
			m_isShow = true;
			this.StartCoroutineWatched(ShowCoroutine());
		}

		//// RVA: 0xE4454C Offset: 0xE4454C VA: 0xE4454C
		public void ResetWindow()
		{
			m_rectTransform.gameObject.SetActive(false);
			m_isShow = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEB50 Offset: 0x6AEB50 VA: 0x6AEB50
		//// RVA: 0xE4881C Offset: 0xE4881C VA: 0xE4881C
		private IEnumerator ShowCoroutine()
		{
			//0xE4970C
			m_rectTransform.gameObject.SetActive(true);
			for(int i = 0; i < m_colorTweens.Length; i++)
			{
				m_colorTweens[i].ResetTime();
			}
			while (!m_colorTweens[0].IsEnd())
			{
				for (int i = 0; i < m_colorTweens.Length; i++)
				{
					m_colorTweens[i].UpdateCurve();
				}
				yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AEBC8 Offset: 0x6AEBC8 VA: 0x6AEBC8
		//// RVA: 0xE445A8 Offset: 0xE445A8 VA: 0xE445A8
		public IEnumerator ProcMessageCoroutine(int charaNo, Position pos, string message, AdvMessageBase.TagConvertFunc func)
		{
			//0xE48FDC
			m_isRunning = true;
			bool isLoding = true;
			GameManager.Instance.DivaIconCache.LoadTutorialIcon(charaNo, (IiconTexture tex) =>
			{
				//0xE48EDC
				tex.Set(m_charaIconImage);
				isLoding = false;
			});
			while (isLoding)
				yield return null;
			m_messageWindowImage.sprite = m_windowPartsSprite[m_charaSpriteMap[charaNo]];
			m_nameText.text = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[charaNo - 1].OPFGFINHFCE_Name;
			if (!m_isShow)
				Show(pos);
			m_messageText.StartMessage(message, m_messageSpeed, func);
			while (m_messageText.IsPlay())
			{
				if(IsTouchScreen())
				{
					m_messageText.Skip();
				}
				yield return null;
			}
			ShowSendCursor();
			while (!IsTouchScreen())
				yield return null;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_ADV_TOUCH);
			HideSendCursor();
			m_isRunning = false;
			yield return null;
		}

		//// RVA: 0xE488E8 Offset: 0xE488E8 VA: 0xE488E8
		private bool IsTouchScreen()
		{
			for(int i = 0; i < InputManager.Instance.touchCount; i++)
			{
				if(InputManager.Instance.GetTouchInfoRecord(i).beganInfo.isBegan)
				{
					if(IsTouchPoisitionInScreen(InputManager.Instance.GetTouchInfoRecord(i).beganInfo.GetSceneInnerPosition()))
					{
						if(InputManager.Instance.GetTouchInfoRecord(i).endedInfo.isEnded)
						{
							if (IsTouchPoisitionInScreen(InputManager.Instance.GetTouchInfoRecord(i).endedInfo.GetSceneInnerPosition()))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xE48B10 Offset: 0xE48B10 VA: 0xE48B10
		private bool IsTouchPoisitionInScreen(Vector2 screenPos)
		{
			Rect r = SystemManager.rawAppScreenRect;
			if(r.x < screenPos.x)
			{
				if(screenPos.x <= r.xMax)
				{
					if(r.y < screenPos.y)
					{
						if (screenPos.y <= r.yMax)
							return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xE48C54 Offset: 0xE48C54 VA: 0xE48C54
		private void ShowSendCursor()
		{
			if(m_sendCursorCoroutine != null)
			{
				this.StopCoroutineWatched(m_sendCursorCoroutine);
				m_sendCursorCoroutine = null;
			}
			m_sendCursorTween.gameObject.SetActive(true);
			m_sendCursorCoroutine = this.StartCoroutineWatched(SendCursorAnimationCoroutine());
		}

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
		private IEnumerator SendCursorAnimationCoroutine()
		{
			//0xE495FC
			while (true)
			{
				m_sendCursorTween.UpdateCurve();
				yield return null;
			}
		}
	}
}
