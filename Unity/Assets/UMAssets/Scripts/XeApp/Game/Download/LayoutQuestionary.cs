using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine.Events;
using XeApp.Game.Common;
using mcrs;

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
		//public void SetProgressValue(int value) { }

		//// RVA: 0x97F908 Offset: 0x97F908 VA: 0x97F908
		public void SetFinishDownLoad()
		{
			m_window.SetFinishProgress();
		}

		//// RVA: 0x97F9AC Offset: 0x97F9AC VA: 0x97F9AC
		//public void SetWindowHide() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B5AD8 Offset: 0x6B5AD8 VA: 0x6B5AD8
		//// RVA: 0x97F9FC Offset: 0x97F9FC VA: 0x97F9FC
		//public IEnumerator Co_Proc(List<MBLFHJJEHLH.CGBKENNCMMC> qData, int totalCount) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B5B50 Offset: 0x6B5B50 VA: 0x6B5B50
		//// RVA: 0x97FADC Offset: 0x97FADC VA: 0x97FADC
		//private IEnumerator Co_ShowMessage(int miniAdvId) { }

		//// RVA: 0x97FBA4 Offset: 0x97FBA4 VA: 0x97FBA4
		private void OnPushOk(LayoutQuestionaryButton[] buttons)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			m_isPushOk = true;
			PushOkHander(buttons, m_executeIndex);
		}
	}
}
