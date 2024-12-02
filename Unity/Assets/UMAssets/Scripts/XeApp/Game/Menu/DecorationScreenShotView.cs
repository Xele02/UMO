using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DecorationScreenShotView : MonoBehaviour
	{
		[SerializeField]
		private Button closeButton; // 0xC
		[SerializeField]
		private Button returnButton; // 0x10
		[SerializeField]
		private Button shareButton; // 0x14
		[SerializeField]
		private Button takeButton; // 0x18
		[SerializeField]
		private Button messagePanelButton; // 0x1C
		[SerializeField]
		private RawImage captureImage; // 0x20
		[SerializeField]
		private RectTransform captureResultPanel; // 0x24
		[SerializeField]
		private Image infomationSprite; // 0x28
		private CanvasGroup canvasGroup; // 0x2C
		private Coroutine loopAnimationCoroutine; // 0x30
		private RectTransform rectTransform; // 0x34
		private float imageHeight; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x66B9A8 Offset: 0x66B9A8 VA: 0x66B9A8
		public UnityAction PushCloseButtonListener; // 0x3C
		//[CompilerGeneratedAttribute] // RVA: 0x66B9B8 Offset: 0x66B9B8 VA: 0x66B9B8
		public UnityAction PushReturnButtonListner; // 0x40
		//[CompilerGeneratedAttribute] // RVA: 0x66B9C8 Offset: 0x66B9C8 VA: 0x66B9C8
		public UnityAction PushShareButtonListner; // 0x44
		//[CompilerGeneratedAttribute] // RVA: 0x66B9D8 Offset: 0x66B9D8 VA: 0x66B9D8
		public UnityAction PushTakeButtonListner; // 0x48
		//[CompilerGeneratedAttribute] // RVA: 0x66B9E8 Offset: 0x66B9E8 VA: 0x66B9E8
		public UnityAction PushMessagePanelButtonListner; // 0x4C

		// // RVA: 0x11E1C64 Offset: 0x11E1C64 VA: 0x11E1C64
		private void Start()
		{
			gameObject.SetActive(false);
			rectTransform = GetComponent<RectTransform>();
			imageHeight = captureImage.rectTransform.sizeDelta.y;
			closeButton.gameObject.SetActive(false);
			returnButton.gameObject.SetActive(false);
			captureResultPanel.gameObject.SetActive(false);
			messagePanelButton.gameObject.SetActive(false);
			canvasGroup = GetComponent<CanvasGroup>();
			closeButton.onClick.AddListener(() =>
			{
				//0x11E2B6C
				if(PushCloseButtonListener != null)
					PushCloseButtonListener();
			});
			returnButton.onClick.AddListener(() =>
			{
				//0x11E2B80
				if(PushReturnButtonListner != null)
					PushReturnButtonListner();
			});
			shareButton.onClick.AddListener(() =>
			{
				//0x11E2B94
				if(PushShareButtonListner != null)
					PushShareButtonListner();
			});
			takeButton.onClick.AddListener(() =>
			{
				//0x11E2BA8
				if(PushTakeButtonListner != null)
					PushTakeButtonListner();
			});
			messagePanelButton.onClick.AddListener(() =>
			{
				//0x11E2BBC
				if(PushMessagePanelButtonListner != null)
					PushMessagePanelButtonListner();
			});
			Text[] txts = GetComponentsInChildren<Text>(true);
			for(int i = 0; i < txts.Length; i++)
			{
				GameManager.Instance.GetSystemFont().Apply(txts[i]);
				if(txts[i].transform.parent.name == "MessageWindow")
				{
					txts[i].text = MessageManager.Instance.GetMessage("menu", "deco_screenshot_success");
				}
			}
		}

		// RVA: 0x11E231C Offset: 0x11E231C VA: 0x11E231C
		public void Show()
		{
			gameObject.SetActive(true);
			RectTransform rt = transform.parent.GetComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			rectTransform.sizeDelta = rt.rect.size;
			captureImage.rectTransform.sizeDelta = new Vector2(captureImage.rectTransform.sizeDelta.x, imageHeight * (1.777778f / (rt.rect.size.x / rt.rect.size.y)));
			CloseCloseButton();
			CloseReturnButton();
			ShowReturnButton();
			if(loopAnimationCoroutine != null)
			{
				this.StopCoroutineWatched(loopAnimationCoroutine);
			}
			loopAnimationCoroutine = this.StartCoroutineWatched(Co_LoopAnimation());
		}

		// RVA: 0x11E27F8 Offset: 0x11E27F8 VA: 0x11E27F8
		public void Close()
		{
			gameObject.SetActive(false);
		}

		// // RVA: 0x11E271C Offset: 0x11E271C VA: 0x11E271C
		public void ShowReturnButton()
		{
			returnButton.gameObject.SetActive(true);
		}

		// // RVA: 0x11E26CC Offset: 0x11E26CC VA: 0x11E26CC
		public void CloseReturnButton()
		{
			returnButton.gameObject.SetActive(false);
		}

		// // RVA: 0x11E2830 Offset: 0x11E2830 VA: 0x11E2830
		public void ShowCloseButton()
		{
			closeButton.gameObject.SetActive(true);
		}

		// // RVA: 0x11E267C Offset: 0x11E267C VA: 0x11E267C
		public void CloseCloseButton()
		{
			closeButton.gameObject.SetActive(false);
		}

		// // RVA: 0x11E2880 Offset: 0x11E2880 VA: 0x11E2880
		public void ShowResult(Texture2D texture)
		{
			captureResultPanel.gameObject.SetActive(true);
			captureImage.texture = texture;
			CloseReturnButton();
			ShowCloseButton();
		}

		// // RVA: 0x11E290C Offset: 0x11E290C VA: 0x11E290C
		public void CloseResult()
		{
			captureResultPanel.gameObject.SetActive(false);
		}

		// // RVA: 0x11E295C Offset: 0x11E295C VA: 0x11E295C
		public void ShowSuccessMessage()
		{
			messagePanelButton.gameObject.SetActive(true);
		}

		// // RVA: 0x11E29AC Offset: 0x11E29AC VA: 0x11E29AC
		public void CloseSuccessMessage()
		{
			messagePanelButton.gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D163C Offset: 0x6D163C VA: 0x6D163C
		// // RVA: 0x11E276C Offset: 0x11E276C VA: 0x11E276C
		private IEnumerator Co_LoopAnimation()
		{
			float time;

			//0x11E2BD4
			if(infomationSprite == null)
				yield break;
			time = 0;
			while(true)
			{
				float r = Math.Tween.Evaluate(Math.Tween.EasingFunc.InOutExpo, 1, 0, time);
				time += TimeWrapper.deltaTime;
				if(time >= 1)
					time -= 1;
				Color col = infomationSprite.color;
				col.a = r;
				infomationSprite.color = col;
				yield return null;
			}
		}

		// // RVA: 0x11E2A1C Offset: 0x11E2A1C VA: 0x11E2A1C
		public void PreformReturnButton()
		{
			if(returnButton != null && returnButton.gameObject.activeInHierarchy && returnButton.interactable)
				returnButton.onClick.Invoke();
		}
	}
}
