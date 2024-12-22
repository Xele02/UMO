using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine.Events;
using XeApp.Game.Common;
using mcrs;
using System.Collections;
using System.Collections.Generic;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionary : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_windowPrefab; // 0xC
		[SerializeField]
		private GameObject m_messWindowPrefab; // 0x10
		[SerializeField]
		private LayoutUGUIHitOnly m_inputBlocker; // 0x14
		[SerializeField]
		private Button m_messageTouchArea; // 0x18
		private LayoutQuestionaryWindow m_window; // 0x1C
		private LayoutQuestionaryMessWindow m_messWindow; // 0x20
		private bool m_isPushOk; // 0x24
		private int m_executeIndex; // 0x28
		private const int QuestionaryEndAdvId = 54;
		public UnityAction<LayoutQuestionaryButton[], int> PushOkHander; // 0x2C 0x97F23C 0x97F348

		// RVA: 0x97F454 Offset: 0x97F454 VA: 0x97F454
		public void LoadResource()
		{
			m_window = Instantiate(m_windowPrefab, transform, false).GetComponent<LayoutQuestionaryWindow>();
			m_messWindow = Instantiate(m_messWindowPrefab, transform, false).GetComponent<LayoutQuestionaryMessWindow>();
			m_messWindow.transform.SetAsFirstSibling();
			m_window.transform.SetAsFirstSibling();
			m_window.PushOkHandler = OnPushOk;
			m_messageTouchArea.onClick.AddListener(() =>
			{
				//0x97FC78
				m_messWindow.OnSendMessage();
			});
			m_messageTouchArea.gameObject.SetActive(false);
		}

		// RVA: 0x97F840 Offset: 0x97F840 VA: 0x97F840
		public bool IsLoading()
		{
			return !m_window.IsLoaded() || !m_messWindow.IsLoaded();
		}

		//// RVA: 0x97F8A0 Offset: 0x97F8A0 VA: 0x97F8A0
		public void SetProgressValue(int value)
		{
			m_window.SetProgressValue(value);
		}

		//// RVA: 0x97F908 Offset: 0x97F908 VA: 0x97F908
		public void SetFinishDownLoad()
		{
			m_window.SetFinishProgress();
		}

		//// RVA: 0x97F9AC Offset: 0x97F9AC VA: 0x97F9AC
		//public void SetWindowHide() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B5AD8 Offset: 0x6B5AD8 VA: 0x6B5AD8
		//// RVA: 0x97F9FC Offset: 0x97F9FC VA: 0x97F9FC
		public IEnumerator Co_Proc(List<MBLFHJJEHLH_AnketoMgr.CGBKENNCMMC> qData, int totalCount)
		{
			WaitWhile waiter; // 0x1C
			int page; // 0x20

			//0x97FEF0
			waiter = new WaitWhile(() =>
			{
				//0x97FD38
				return GameManager.IsFading();
			});
			while (IsLoading())
				yield return null;
			GameManager.FadeIn(0.4f);
			m_window.gameObject.SetActive(true);
			m_window.CloseAllButton();
			page = totalCount - qData.Count;
			m_executeIndex = 0;
			m_window.SetMaxPage(totalCount);
			do
			{
				//LAB_0098042c
				m_inputBlocker.enabled = true;
				m_window.SetCurrentPage(page + m_executeIndex + 1);
				m_isPushOk = false;
				yield return this.StartCoroutineWatched(m_window.Setup(qData[m_executeIndex]));
				yield return waiter;
				yield return this.StartCoroutineWatched(Co_ShowMessage(qData[m_executeIndex].CIMPIIJBFPE));
				m_inputBlocker.enabled = false;
				while (!m_isPushOk)
				{
					yield return null;
				}
				m_inputBlocker.enabled = true;
				yield return this.StartCoroutineWatched(Co_ShowMessage(qData[m_executeIndex].DHEIGBMNBNK));
				m_executeIndex++;
				if (m_executeIndex < qData.Count)
				{
					yield return null;
				}
			} while (m_executeIndex < qData.Count);
			yield return this.StartCoroutineWatched(Co_ShowMessage(54));
			GameManager.FadeOut(0.4f);
			yield return waiter;
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6B5B50 Offset: 0x6B5B50 VA: 0x6B5B50
		//// RVA: 0x97FADC Offset: 0x97FADC VA: 0x97FADC
		private IEnumerator Co_ShowMessage(int miniAdvId)
		{
			ILLPGHGGKLL_TutorialMiniAdv.AFBMNDPOALE adv; // 0x18
			int i; // 0x1C

			//0x980BD0
			adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LINHIDCNAMG_TutorialMiniAdv.LBDOLHGDIEB(miniAdvId);
			if (adv == null)
				yield break;
			m_messageTouchArea.gameObject.SetActive(true);
			m_messWindow.Show();
			while (m_messWindow.IsPlaying())
				yield return null;
			for(i = 0; i < adv.JONNCMDGMKA_Messages.Length; i++)
			{
				yield return Co.R(m_messWindow.Co_ProcMessage(adv.JONNCMDGMKA_Messages[i]));
				yield return null;
			}
			m_messWindow.Hide();
			//LAB_00980ee8
			while (m_messWindow.IsPlaying())
				yield return null;
			m_messWindow.MessageClear();
			m_messageTouchArea.gameObject.SetActive(false);
		}

		//// RVA: 0x97FBA4 Offset: 0x97FBA4 VA: 0x97FBA4
		private void OnPushOk(LayoutQuestionaryButton[] buttons)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_isPushOk = true;
			PushOkHander(buttons, m_executeIndex);
		}
	}
}
