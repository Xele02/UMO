using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeSys;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupConfigPreGameContent : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField]
		private LayoutPopupConfigRhythmNotes m_notesUi; // 0xC
		private bool m_isLayoutLoaded; // 0x10

		public Transform Parent { get { return null; } } //0xAF9C74

		//// RVA: 0xAF92C4 Offset: 0xAF92C4 VA: 0xAF92C4
		private void InitializeLayout()
		{
			SetText();
			m_notesUi.SetOnClickMinus10(() =>
			{
				//0xAF9DA8
				TodoLogger.LogNotImplemented("SetOnClickMinus");
			});
			m_notesUi.SetOnClickMinus01(() =>
			{
				//0xAF9E9C
				TodoLogger.LogNotImplemented("SetOnClickMinus01");
			});
			m_notesUi.SetOnClickPlus10(() =>
			{
				//0xAF9F90
				TodoLogger.LogNotImplemented("SetOnClickPlus10");
			});
			m_notesUi.SetOnClickPlus01(() =>
			{
				//0xAFA084
				TodoLogger.LogNotImplemented("SetOnClickPlus01");
			});
			m_notesUi.SetOnClickDefault(() =>
			{
				//0xAFA178
				TodoLogger.LogNotImplemented("SetOnClickDefault");
			});
			m_notesUi.SetOnClickDiffLeft(() =>
			{
				//0xAFA374
				TodoLogger.LogNotImplemented("SetOnClickDiffLeft");
			});
			m_notesUi.SetOnClickDiffRight(() =>
			{
				//0xAFA4A4
				TodoLogger.LogNotImplemented("SetOnClickDiffRight");
			});
			m_notesUi.SetOnClickCheckbox01(() =>
			{
				//0xAFA5D4
				TodoLogger.LogNotImplemented("SetOnClickCheckbox01");
			});
			m_notesUi.SetOnClickCheckbox02(() =>
			{
				//0xAFA684
				TodoLogger.LogNotImplemented("SetOnClickCheckbox02");
			});
		}

		//// RVA: 0xAF9908 Offset: 0xAF9908 VA: 0xAF9908
		private void Setup()
		{
			m_notesUi.SetStyle(LayoutPopupConfigRhythmNotes.Style.Passive);
			m_notesUi.SetDiffDesc(MessageManager.Instance.GetMessage("menu", "config_text_37_rhythm"));
			ConfigManager.Instance.SetNotesSpeedDiffSelection(false);
			SetDifficulty();
			m_notesUi.SetNumber(string.Format("{0:f1}", ConfigManager.Instance.GetNotesSpeed()));
			m_notesUi.SetCheckbox01Status(ConfigManager.Instance.GetNotesSpeedAllApply());
			m_notesUi.SetCheckbox02Status(ConfigManager.Instance.GetNotesSpeedAutoRejected());
		}

		//// RVA: 0xAF9654 Offset: 0xAF9654 VA: 0xAF9654
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_notesUi.SetTitle(bk.GetMessageByLabel("config_text_40"));
			m_notesUi.SetDetail(bk.GetMessageByLabel("config_text_39"));
			m_notesUi.SetNumber("");
			m_notesUi.SetCheckbox01Text(bk.GetMessageByLabel("config_text_63"), bk.GetMessageByLabel("config_text_64"));
			m_notesUi.SetCheckbox02Text(bk.GetMessageByLabel("config_text_65"), bk.GetMessageByLabel("config_text_66"));
		}

		//// RVA: 0xAF9B8C Offset: 0xAF9B8C VA: 0xAF9B8C
		private void SetDifficulty()
		{
			m_notesUi.SetDifficulty(ConfigManager.Instance.GetNotesSpeedCurrentDiff(), ConfigManager.Instance.IsNotesSpeedCurrentLine6Mode());
		}

		//// RVA: 0xAF9C64 Offset: 0xAF9C64 VA: 0xAF9C64
		//private void PlaySeButton() { }

		//// RVA: 0xAF9C6C Offset: 0xAF9C6C VA: 0xAF9C6C
		//private void PlaySeToggleButton() { }

		//// RVA: 0xAF9C7C Offset: 0xAF9C7C VA: 0xAF9C7C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			InitializeLayout();
			Setup();
			gameObject.SetActive(true);
		}

		//// RVA: 0xAF9CC8 Offset: 0xAF9CC8 VA: 0xAF9CC8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		//// RVA: 0xAF9CD0 Offset: 0xAF9CD0 VA: 0xAF9CD0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0xAF9D08 Offset: 0xAF9D08 VA: 0xAF9D08 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		//// RVA: 0xAF9D40 Offset: 0xAF9D40 VA: 0xAF9D40 Slot: 21
		public bool IsReady()
		{
			return m_notesUi.IsLoaded() && m_isLayoutLoaded;
		}

		//// RVA: 0xAF9D8C Offset: 0xAF9D8C VA: 0xAF9D8C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xAF9D90 Offset: 0xAF9D90 VA: 0xAF9D90 Slot: 24
		bool ILayoutUGUIPaste.InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isLayoutLoaded = true;
			return true;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x73DB7C Offset: 0x73DB7C VA: 0x73DB7C
		//// RVA: 0xAFA21C Offset: 0xAFA21C VA: 0xAFA21C
		//private void <InitializeLayout>b__2_9(bool isOk) { }
	}
}
