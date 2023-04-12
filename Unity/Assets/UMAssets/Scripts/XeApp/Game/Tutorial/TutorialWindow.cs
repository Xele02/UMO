using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using System.Collections;
using XeApp.Game.Menu;
using mcrs;
using XeSys;

namespace XeApp.Game.Tutorial
{
	public class TutorialWindow : LayoutUGUIScriptBase
	{
		private struct MessageData
		{
			public string messages; // 0x0
			public string title; // 0x4
			public int pictId; // 0x8
		}

		[SerializeField]
		private Text m_titleText; // 0x14
		[SerializeField]
		private Text[] m_messageText; // 0x18
		[SerializeField]
		private Text[] m_pageNumbers; // 0x1C
		[SerializeField]
		private ActionButton[] m_sendButton; // 0x20
		[SerializeField]
		private ActionButton[] m_okButton; // 0x24
		[SerializeField]
		private ActionButton[] m_arrowButtons; // 0x28
		[SerializeField]
		private RawImageEx[] m_image; // 0x2C
		[SerializeField]
		private float m_buttonWaitSec = 0.25f; // 0x30
		private TutorialImageCache m_imageCache = new TutorialImageCache(); // 0x34
		private RawImage m_blackPlane; // 0x38
		private PJANOOPJIDE_TutorialPict.HNHHGJCPMEA m_messageData; // 0x3C
		private List<MessageData> m_messageList = new List<MessageData>(); // 0x40
		private List<AbsoluteLayout> m_rootLayer = new List<AbsoluteLayout>(2); // 0x44
		private AbsoluteLayout m_layoutRootAnime; // 0x48
		private List<AbsoluteLayout> m_buttonRoot = new List<AbsoluteLayout>(); // 0x4C
		private List<AbsoluteLayout> m_windowAnime = new List<AbsoluteLayout>(); // 0x50
		private int m_showDataIndex; // 0x54
		private int m_maxPage; // 0x58
		private List<ButtonBase> m_buttonReferenceList = new List<ButtonBase>(); // 0x5C
		private Action m_closeAction; // 0x60
		private IEnumerator m_hideCoroutine; // 0x64
		private WaitForSeconds m_waitForSec = new WaitForSeconds(0.25f); // 0x68
		private const int MaxPage = 3;

		// RVA: 0x1916FCC Offset: 0x1916FCC VA: 0x1916FCC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Array.ForEach(m_sendButton, (ActionButton x) =>
			{
				//0x1919830
				x.AddOnClickCallback(OnSendButton);
			});
			Array.ForEach(m_okButton, (ActionButton x) =>
			{
				//0x19198D8
				x.AddOnClickCallback(OnSendButton);
			});
			m_arrowButtons[1].AddOnClickCallback(OnSendButton);
			m_arrowButtons[3].AddOnClickCallback(OnSendButton);
			m_arrowButtons[0].AddOnClickCallback(OnPrevButton);
			m_arrowButtons[2].AddOnClickCallback(OnPrevButton);
			AbsoluteLayout a = layout.FindViewByExId("swtbl_cmn_tuto03_sw_cmn_tuto03_all_anim") as AbsoluteLayout;
			a.StartChildrenAnimGoStop("st_out");
			m_rootLayer.Add(a);
			a = layout.FindViewByExId("swtbl_cmn_tuto03_sw_cmn_tuto03_all_anim_new") as AbsoluteLayout;
			a.StartChildrenAnimGoStop("st_out");
			m_rootLayer.Add(a);
			m_layoutRootAnime = layout.FindViewByExId("root_cmn_tuto03_window_cmn_tuto_all") as AbsoluteLayout;
			m_buttonRoot.Add(layout.FindViewByExId("sw_cmn_tuto03_window_sw_cmn_btn_anim") as AbsoluteLayout);
			m_buttonRoot.Add(layout.FindViewByExId("sw_cmn_tuto03_window_new_sw_cmn_btn_anim") as AbsoluteLayout);
			m_windowAnime.Add(layout.FindViewByExId("sw_cmn_tuto03_pict_sw_cmn_tuto03_pict_anim") as AbsoluteLayout);
			m_windowAnime.Add(null);
			GameObject bp = new GameObject("BackPlane");
			bp.transform.SetParent(transform);
			bp.transform.SetAsFirstSibling();
			m_blackPlane = bp.AddComponent<RawImage>();
			m_blackPlane.color = new Color(0, 0, 0, 0.5f);
			m_blackPlane.rectTransform.sizeDelta = new Vector2(1184, 792);
			m_blackPlane.rectTransform.pivot = new Vector2(1, 0);
			m_buttonReferenceList.AddRange(m_arrowButtons);
			Array.ForEach(m_sendButton, (ActionButton x) =>
			{
				//0x1919980
				m_buttonReferenceList.Add(x);
			});
			Array.ForEach(m_okButton, (ActionButton x) =>
			{
				//0x1919A00
				m_buttonReferenceList.Add(x);
			});
			m_titleText.text = "";
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		//// RVA: 0x1917A80 Offset: 0x1917A80 VA: 0x1917A80
		public void SetMessageData(PJANOOPJIDE_TutorialPict.HNHHGJCPMEA messData)
		{
			m_messageData = messData;
			m_showDataIndex = 0;
			Array.ForEach(m_image, (RawImageEx x) =>
			{
				//0x1919C5C
				x.gameObject.SetActive(false);
			});
			m_messageList.Clear();
			string str = "";
			for (int i = 0; i < m_messageData.JONNCMDGMKA.Length; i++)
			{
				if(!string.IsNullOrEmpty(m_messageData.ADCMNODJBGJ[i]))
				{
					str = m_messageData.ADCMNODJBGJ[i];
				}
				if(m_messageData.KMDGMOMCDAD[i] < 1 || !GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(m_messageData.KMDGMOMCDAD[i]))
				{
					//LAB_01917df8
					m_messageList.Add(new MessageData() { messages = m_messageData.JONNCMDGMKA[i], title = str, pictId = m_messageData.MAPDMCPCLFA[i] });
				}
			}
			SetMaxPage(m_messageList.Count);
			SetCurrentData();
		}

		// RVA: 0x191856C Offset: 0x191856C VA: 0x191856C
		private void OnDestroy()
		{
			m_imageCache.Terminated();
		}

		//// RVA: 0x1918068 Offset: 0x1918068 VA: 0x1918068
		private void SetCurrentData()
		{
			SetCurrentPage(m_showDataIndex + 1);
			SetMessage(m_messageList[m_showDataIndex].messages);
			SetTitle(m_messageList[m_showDataIndex].title);
			if(m_messageList[m_showDataIndex].pictId > 0)
			{
				Array.ForEach(m_image, (RawImageEx x) =>
				{
					//0x1919CAC
					x.gameObject.SetActive(false);
				});
				m_imageCache.Load(m_messageList[m_showDataIndex].pictId, (IiconTexture texture) =>
				{
					//0x1919A80
					Array.ForEach(m_image, (RawImageEx x) =>
					{
						//0x1919CFC
						x.gameObject.SetActive(true);
					});
					SetImage(texture);
				});
			}
			m_arrowButtons[0].Hidden = m_showDataIndex == 0;
			m_arrowButtons[2].Hidden = m_showDataIndex == 0;
			m_arrowButtons[1].Hidden = m_showDataIndex == m_messageList.Count - 1;
			m_arrowButtons[3].Hidden = m_showDataIndex == m_messageList.Count - 1;
			m_buttonRoot[m_messageData.KNHABOOAAIP].StartChildrenAnimGoStop(m_showDataIndex == m_messageList.Count - 1 ? "02" : "01");
		}

		//// RVA: 0x19187CC Offset: 0x19187CC VA: 0x19187CC
		public void Show(Action finishCb, bool isBlackPlane = true)
		{
			if (m_hideCoroutine != null)
				this.StopCoroutineWatched(m_hideCoroutine);
			SetButtonInputState(true);
			GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
			m_closeAction = finishCb;
			m_blackPlane.gameObject.SetActive(false);
			this.StartCoroutineWatched(ShowCoroutine(isBlackPlane));
		}

		//// RVA: 0x1918B58 Offset: 0x1918B58 VA: 0x1918B58
		private void Hide(Action finishCb)
		{
			SetButtonInputState(true);
			m_rootLayer[m_messageData.KNHABOOAAIP].StartChildrenAnimGoStop("go_out", "st_out");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			m_hideCoroutine = AnimeWaitCorutine(() =>
			{
				//0x1919D4C
				if (finishCb != null)
					finishCb();
			});
			this.StartCoroutineWatched(m_hideCoroutine);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AFF38 Offset: 0x6AFF38 VA: 0x6AFF38
		//// RVA: 0x1918AB0 Offset: 0x1918AB0 VA: 0x1918AB0
		private IEnumerator ShowCoroutine(bool isBlackPlane)
		{
			//0x191A7F0
			while(m_imageCache.IsLoading())
				yield return null;
			m_blackPlane.gameObject.SetActive(isBlackPlane);
			if (m_messageData.KNHABOOAAIP == 1)
			{
				m_layoutRootAnime.StartChildrenAnimGoStop("02");
			}
			else if(m_messageData.KNHABOOAAIP == 0)
			{
				m_layoutRootAnime.StartChildrenAnimGoStop("01");
			}
			m_rootLayer[m_messageData.KNHABOOAAIP].StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_004);
			yield return this.StartCoroutineWatched(AnimeWaitCorutine(() =>
			{
				//0x1919BD8
				SetButtonInputState(false);
			}));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AFFB0 Offset: 0x6AFFB0 VA: 0x6AFFB0
		//// RVA: 0x1918D1C Offset: 0x1918D1C VA: 0x1918D1C
		private IEnumerator AnimeWaitCorutine(Action fnishCb)
		{
			//0x1919ED0
			while (m_rootLayer[m_messageData.KNHABOOAAIP].IsPlayingChildren())
				yield return null;
			if (fnishCb != null)
				fnishCb();
		}

		//// RVA: 0x1918938 Offset: 0x1918938 VA: 0x1918938
		private void SetButtonInputState(bool isInputOff)
		{
			Array.ForEach(m_sendButton, (ActionButton x) =>
			{
				//0x1919D60
				x.IsInputOff = isInputOff;
			});
			for(int i = 0; i < m_arrowButtons.Length; i++)
			{
				m_arrowButtons[i].IsInputOff = isInputOff;
			}
		}

		//// RVA: 0x1918E0C Offset: 0x1918E0C VA: 0x1918E0C
		//private bool IsPlaying() { }

		//// RVA: 0x1918778 Offset: 0x1918778 VA: 0x1918778
		private void SetTitle(string title)
		{
			if (string.IsNullOrEmpty(title))
				return;
			m_titleText.text = title;
		}

		//// RVA: 0x1918EC0 Offset: 0x1918EC0 VA: 0x1918EC0
		private void SetImage(IiconTexture texture)
		{
			Array.ForEach(m_image, (RawImageEx x) =>
			{
				//0x1919D9C
				texture.Set(x);
			});
		}

		//// RVA: 0x1918690 Offset: 0x1918690 VA: 0x1918690
		public void SetMessage(string maessage)
		{
			Array.ForEach(m_messageText, (Text x) =>
			{
				//0x1919E7C
				x.text = maessage;
			});
		}

		//// RVA: 0x1917F7C Offset: 0x1917F7C VA: 0x1917F7C
		private void SetMaxPage(int page)
		{
			m_pageNumbers[3].text = page.ToString();
			m_pageNumbers[1].text = page.ToString();
			m_maxPage = page;
		}

		//// RVA: 0x1918FB8 Offset: 0x1918FB8 VA: 0x1918FB8
		private void ChangePageAnime(int page)
		{
			int a = m_maxPage - page + 1;
			if (a > 2)
				a = 3;
			m_windowAnime[m_messageData.KNHABOOAAIP].StartChildrenAnimGoStop(string.Format("{0:D2}", a));
		}

		//// RVA: 0x19185A0 Offset: 0x19185A0 VA: 0x19185A0
		private void SetCurrentPage(int page)
		{
			m_pageNumbers[2].text = page.ToString();
			m_pageNumbers[0].text = page.ToString();
			ChangePageAnime(page);
		}

		//// RVA: 0x19190C0 Offset: 0x19190C0 VA: 0x19190C0
		private void OnSendButton()
		{
			m_showDataIndex++;
			if(IsLastPage())
			{
				this.StartCoroutineWatched(SendCoroutine());
				this.StartCoroutineWatched(Co_ButtonWait());
			}
			else
			{
				this.StartCoroutineWatched(Co_Close());
			}
			OnPlayButtonSe();
		}

		//// RVA: 0x191912C Offset: 0x191912C VA: 0x191912C
		private bool IsLastPage()
		{
			return m_showDataIndex < m_messageList.Count;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0028 Offset: 0x6B0028 VA: 0x6B0028
		//// RVA: 0x19191B8 Offset: 0x19191B8 VA: 0x19191B8
		private IEnumerator SendCoroutine()
		{
			//0x191A678
			SetButtonInputState(true);
			SetCurrentData();
			while (m_imageCache.IsLoading())
				yield return null;
			SetButtonInputState(false);
		}

		//// RVA: 0x19193D4 Offset: 0x19193D4 VA: 0x19193D4
		private void OnPrevButton()
		{
			TodoLogger.LogNotImplemented("OnPrevButton");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B00A0 Offset: 0x6B00A0 VA: 0x6B00A0
		//// RVA: 0x1919244 Offset: 0x1919244 VA: 0x1919244
		private IEnumerator Co_ButtonWait()
		{
			float sec;

			//0x191A09C
			sec = 0;
			for(int i = 0; i < m_buttonReferenceList.Count; i++)
			{
				m_buttonReferenceList[i].enabled = false;
			}
			while(sec < m_buttonWaitSec)
			{
				sec += TimeWrapper.deltaTime;
				yield return null;
			}
			for (int i = 0; i < m_buttonReferenceList.Count; i++)
			{
				m_buttonReferenceList[i].enabled = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B0118 Offset: 0x6B0118 VA: 0x6B0118
		//// RVA: 0x19192D0 Offset: 0x19192D0 VA: 0x19192D0
		private IEnumerator Co_Close()
		{
			//0x191A360
			GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
			bool isWait = true;
			Hide(() =>
			{
				//0x1919EC0
				isWait = false;
			});
			while (isWait)
				yield return null;
			yield return m_waitForSec;
			if(m_closeAction != null)
			{
				m_closeAction();
				m_closeAction = null;
			}
			gameObject.SetActive(false);
		}

		//// RVA: 0x1919458 Offset: 0x1919458 VA: 0x1919458
		//private void OnClose() { }

		//// RVA: 0x191935C Offset: 0x191935C VA: 0x191935C
		private void OnPlayButtonSe()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		// RVA: 0x1919484 Offset: 0x1919484 VA: 0x1919484
		private void Update()
		{
			m_imageCache.Update();
		}

		//// RVA: 0x19194B0 Offset: 0x19194B0 VA: 0x19194B0
		private void OnBackButton()
		{
			TodoLogger.LogNotImplemented("OnBackButton");
		}
	}
}
