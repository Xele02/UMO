using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine.Events;
using mcrs;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryWindow : LayoutUGUIScriptBase
	{
		[SerializeField] // RVA: 0x666434 Offset: 0x666434 VA: 0x666434
		private LayoutQuestionaryButton[] m_radioButtons; // 0x14
		[SerializeField] // RVA: 0x666444 Offset: 0x666444 VA: 0x666444
		private LayoutQuestionaryButton[] m_checkButtons; // 0x18
		[SerializeField] // RVA: 0x666454 Offset: 0x666454 VA: 0x666454
		private ActionButton m_okButton; // 0x1C
		[SerializeField] // RVA: 0x666464 Offset: 0x666464 VA: 0x666464
		private Text m_questionText; // 0x20
		[SerializeField] // RVA: 0x666474 Offset: 0x666474 VA: 0x666474
		private Text[] m_notification1Text; // 0x24
		[SerializeField] // RVA: 0x666484 Offset: 0x666484 VA: 0x666484
		private Text m_notification2Text; // 0x28
		[SerializeField] // RVA: 0x666494 Offset: 0x666494 VA: 0x666494
		private Text m_denText; // 0x2C
		[SerializeField] // RVA: 0x6664A4 Offset: 0x6664A4 VA: 0x6664A4
		private Text m_numText; // 0x30
		public UnityAction<LayoutQuestionaryButton[]> PushOkHandler; // 0x34 0x97F734 0x981F78
		private int m_currentQuestionaryType = -1; // 0x38
		private int m_minAnswerCount = 1; // 0x3C
		private int m_maxAnswerCount = 1; // 0x40
		private AbsoluteLayout m_rootAnim; // 0x44
		private AbsoluteLayout m_buttonChangeAnim; // 0x48
		private AbsoluteLayout _m_progressAnim; // 0x4C
		private AbsoluteLayout m_radioButtonRoot; // 0x50
		private AbsoluteLayout m_checkButtonRoot; // 0x54
		private AbsoluteLayout m_notificationTextChangeAnim; // 0x58
		private const string TitleFormat = "Q{0}.{1}";
		private const int MultiAnswerTypeId = 2;
		private const int NotificationChangeStrLen = 17;

		//private AbsoluteLayout m_progressAnim { get; set; } 0x982084 0x98208C

		// RVA: 0x982094 Offset: 0x982094 VA: 0x982094 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootAnim = layout.FindViewByExId("root_cmn_euq_window_sw_cmn_euq_window_all_anim") as AbsoluteLayout;
			_m_progressAnim = layout.FindViewByExId("sw_cmn_euq_window_sw_cmn_enq_bar_anim") as AbsoluteLayout;
			m_radioButtonRoot = layout.FindViewByExId("sw_cmn_euq_window_sw_cmn_euq_btn_radio") as AbsoluteLayout;
			m_checkButtonRoot = layout.FindViewByExId("sw_cmn_euq_window_sw_cmn_euq_btn_check") as AbsoluteLayout;
			m_notificationTextChangeAnim = layout.FindViewByExId("sw_cmn_euq_window_swtbl_caution_txt") as AbsoluteLayout;
			for(int i = 0;  i < m_radioButtons.Length; i++)
			{
				m_radioButtons[i].PushButtonHandler += OnSelectedRadioButton;
			}
			for(int i = 0; i < m_checkButtons.Length; i++)
			{
				m_checkButtons[i].PushButtonHandler += OnSelectedCheckButton;
			}
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		//// RVA: 0x9824C4 Offset: 0x9824C4 VA: 0x9824C4
		//public void Show() { }

		//// RVA: 0x982550 Offset: 0x982550 VA: 0x982550
		//public void Hide() { }

		//// RVA: 0x9825DC Offset: 0x9825DC VA: 0x9825DC
		//public bool IsPlaying() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6B5D80 Offset: 0x6B5D80 VA: 0x6B5D80
		//// RVA: 0x980924 Offset: 0x980924 VA: 0x980924
		//public IEnumerator Setup(MBLFHJJEHLH.CGBKENNCMMC data) { }

		//// RVA: 0x98087C Offset: 0x98087C VA: 0x98087C
		//public void SetMaxPage(int max) { }

		//// RVA: 0x9808D0 Offset: 0x9808D0 VA: 0x9808D0
		//public void SetCurrentPage(int num) { }

		//// RVA: 0x97F8D0 Offset: 0x97F8D0 VA: 0x97F8D0
		//public void SetProgressValue(int value) { }

		//// RVA: 0x97F930 Offset: 0x97F930 VA: 0x97F930
		public void SetFinishProgress()
		{
			_m_progressAnim.StartChildrenAnimGoStop("st_in");
		}

		//// RVA: 0x980774 Offset: 0x980774 VA: 0x980774
		//public void CloseAllButton() { }

		//// RVA: 0x982628 Offset: 0x982628 VA: 0x982628
		//private bool IsPlayingButtonAnime() { }

		//// RVA: 0x982748 Offset: 0x982748 VA: 0x982748
		private void OnSelectedCheckButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			int numChecked = 0;
			for(int i = 0; i < m_checkButtons.Length; i++)
			{
				if (m_checkButtons[i].IsOn())
					numChecked++;
			}
			if (numChecked < m_maxAnswerCount)
			{
				for(int i = 0; i < m_checkButtons.Length; i++)
				{
					if(m_checkButtons[i].IsDisable())
					{
						m_checkButtons[i].SetEnable();
					}
				}
			}
			else
			{
				for (int i = 0; i < m_checkButtons.Length; i++)
				{
					if (!m_checkButtons[i].IsOn())
					{
						m_checkButtons[i].SetDisable();
					}
				}
			}
			m_okButton.Disable = numChecked < m_minAnswerCount;
		}

		//// RVA: 0x982A00 Offset: 0x982A00 VA: 0x982A00
		private void OnSelectedRadioButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_okButton.Disable = false;
		}

		//// RVA: 0x982A80 Offset: 0x982A80 VA: 0x982A80
		//private void OnPushOk(LayoutQuestionaryButton[] buttons) { }

		//// RVA: 0x982AF4 Offset: 0x982AF4 VA: 0x982AF4
		//private string GetNotificationMessage(MBLFHJJEHLH.CGBKENNCMMC data) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B5DF8 Offset: 0x6B5DF8 VA: 0x6B5DF8
		//// RVA: 0x982C64 Offset: 0x982C64 VA: 0x982C64
		//private void <Setup>b__30_0() { }

		//[CompilerGeneratedAttribute] // RVA: 0x6B5E08 Offset: 0x6B5E08 VA: 0x6B5E08
		//// RVA: 0x982C6C Offset: 0x982C6C VA: 0x982C6C
		//private void <Setup>b__30_1() { }
	}
}
