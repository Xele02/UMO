using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using System.Collections;
using XeSys;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_01 : LayoutPopupConfigBase
	{
		[SerializeField]
		private LayoutPopupConfigRhythmNotes m_notesUi; // 0x38

		// RVA: 0x1ECB2E0 Offset: 0x1ECB2E0 VA: 0x1ECB2E0 Slot: 6
		public override int GetContentsHeight()
		{
			return 353;
		}

		// RVA: 0x1ECB2E8 Offset: 0x1ECB2E8 VA: 0x1ECB2E8 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ECB2F0 Offset: 0x1ECB2F0 VA: 0x1ECB2F0 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			if(ConfigType == ConfigMenu.eType.Menu)
			{
				m_notesUi.SetStyle(LayoutPopupConfigRhythmNotes.Style.Option);
				m_notesUi.SetDiffDesc(MessageManager.Instance.GetMessage("menu", "config_text_37_option"));
				ConfigManager.Instance.SetNotesSpeedDiffSelection(true);
			}
			else if(ConfigType == ConfigMenu.eType.Rhythm)
			{
				m_notesUi.SetStyle(LayoutPopupConfigRhythmNotes.Style.Rhythm);
				m_notesUi.SetDiffDesc(MessageManager.Instance.GetMessage("menu", "config_text_37_rhythm"));
				ConfigManager.Instance.SetNotesSpeedDiffSelection(false);
			}
			SetDifficulty();
			m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.GetNotesSpeed()));
			m_notesUi.SetCheckbox01Status(ConfigManager.Instance.GetNotesSpeedAllApply());
		}

		//// RVA: 0x1ECB72C Offset: 0x1ECB72C VA: 0x1ECB72C
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_notesUi.SetTitle(bk.GetMessageByLabel("config_text_40"));
			m_notesUi.SetDetail(bk.GetMessageByLabel("config_text_39"));
			m_notesUi.SetNumber("");
			m_notesUi.SetCheckbox01Text(bk.GetMessageByLabel("config_text_63"), bk.GetMessageByLabel("config_text_64"));
			m_notesUi.SetCheckbox02Text(bk.GetMessageByLabel("config_text_65"), bk.GetMessageByLabel("config_text_66"));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7019B4 Offset: 0x7019B4 VA: 0x7019B4
		//// RVA: 0x1ECB9E0 Offset: 0x1ECB9E0 VA: 0x1ECB9E0
		private IEnumerator Setup()
		{
			//0x1ECC398
			SetText();
			m_notesUi.SetOnClickMinus10(() =>
			{
				//0x1ECBAB8
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.NotesSpeedMinus1()));
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickMinus01(() =>
			{
				//0x1ECBBAC
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.NotesSpeedMinus()));
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickPlus10(() =>
			{
				//0x1ECBCA0
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.NotesSpeedPlus1()));
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickPlus01(() =>
			{
				//0x1ECBD94
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.NotesSpeedPlus()));
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickDefault(() =>
			{
				//0x1ECBE88
				ConfigUtility.NotesSpeedDefaultPopup((bool isOk) =>
				{
					//0x1ECBF2C
					if(isOk)
					{
						m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.NotesSpeed)));
						m_notesUi.SetCheckbox01Status(ConfigManager.Instance.GetNotesSpeedAllApply());
					}
				});
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickDiffLeft(() =>
			{
				//0x1ECC084
				ConfigManager.Instance.NotesSpeedDiffToLeft();
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.GetNotesSpeed()));
				SetDifficulty();
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickDiffRight(() =>
			{
				//0x1ECC1B4
				ConfigManager.Instance.NotesSpeedDiffToRight();
				m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.GetNotesSpeed()));
				SetDifficulty();
				ConfigUtility.PlaySeButton();
			});
			m_notesUi.SetOnClickCheckbox01(() =>
			{
				//0x1ECC2E4
				ConfigManager.Instance.SetNotesSpeedAllApply(m_notesUi.IsChecked01);
				ConfigUtility.PlaySeButton();
			});
			Loaded();
			yield break;
		}

		//// RVA: 0x1ECB654 Offset: 0x1ECB654 VA: 0x1ECB654
		private void SetDifficulty()
		{
			m_notesUi.SetDifficulty(ConfigManager.Instance.GetNotesSpeedCurrentDiff(), ConfigManager.Instance.IsNotesSpeedCurrentLine6Mode());
		}

		// RVA: 0x1ECBA8C Offset: 0x1ECBA8C VA: 0x1ECBA8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
