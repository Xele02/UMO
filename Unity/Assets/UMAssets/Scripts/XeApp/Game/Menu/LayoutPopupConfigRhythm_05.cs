using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using System;
using System.Collections;
using XeSys;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_05 : LayoutPopupConfigBase
	{ 
		public enum eTextType
		{
			Plus50Max = 0,
			Minus50Max = 1,
			TimingDetail = 2,
			TimingTitle = 3,
			Num = 4,
		}

		private enum eButtonType
		{
			TimingDefault = 0,
			TimingScene = 1,
			TimingPlus = 2,
			TimingMinus = 3,
			Num = 4,
		}

		private enum eSlider
		{
			Timing = 0,
		}

		[SerializeField]
		private NumberBase m_notes; // 0x38
		[SerializeField]
		private GameObject m_timingPos; // 0x3C
		[SerializeField]
		private RawImageEx m_symbolNumber; // 0x40
		private TexUVList m_texUvList; // 0x44
		private TextSet[] m_textTbl = new TextSet[4] {
			new TextSet() { index = 0, label = "" },
			new TextSet() { index = 1, label = "" },
			new TextSet() { index = 2, label = "config_text_20" },
			new TextSet() { index = 3, label = "config_text_19" }
		}; // 0x4C

		public Action CallbackButtonTiming { get; set; } // 0x48

		// RVA: 0x1ED0AF0 Offset: 0x1ED0AF0 VA: 0x1ED0AF0 Slot: 6
		public override int GetContentsHeight()
		{
			return 315;
		}

		// RVA: 0x1ED0AF8 Offset: 0x1ED0AF8 VA: 0x1ED0AF8 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED0B00 Offset: 0x1ED0B00 VA: 0x1ED0B00 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetText(0, 75.ToString("+#;-#;0"));
			SetText(1, (-75).ToString("+#;-#;0"));
			int val = ConfigManager.Instance.Option.OJAJHIMOIEC_NoteOffset;
			if (val < 0)
				val = -val;
			m_notes.SetNumber(val, 0);
			SetTextureTiming(ConfigManager.Instance.Option.OJAJHIMOIEC_NoteOffset);
			m_changeSliderSePlay = false;
			SetValueSlider(0, ConfigManager.Instance.Option.OJAJHIMOIEC_NoteOffset);
			m_changeSliderSePlay = true;
		}

		//// RVA: 0x1ED0EB0 Offset: 0x1ED0EB0 VA: 0x1ED0EB0
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for (int i = 0; i < m_textTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		//// RVA: 0x1ED0CD0 Offset: 0x1ED0CD0 VA: 0x1ED0CD0
		private void SetTextureTiming(int num)
		{
			if(m_symbolNumber != null)
			{
				if(num == 0)
				{
					m_symbolNumber.uvRect = new Rect(0, 0, 0, 0);
				}
				else
				{
					if (num < 0)
						m_symbolNumber.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("cmn_con_num_11"));
					else
						m_symbolNumber.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData("cmn_con_num_10"));
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701EBC Offset: 0x701EBC VA: 0x701EBC
		//// RVA: 0x1ED10B8 Offset: 0x1ED10B8 VA: 0x1ED10B8
		private IEnumerator Setup()
		{
			//0x1ED1EB4
			SetText();
			bool isSliderTiming = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type001", (FileResultObject flo2) =>
			{
				//0x1ED1580
				GameObject inst = Instantiate(flo2.unityObject) as GameObject;
				Slider s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_timingPos.transform, false);
				m_sliders.Add(0, s);
				isSliderTiming = true;
				return true;
			});
			ResourcesManager.Instance.Load();
			while (!isSliderTiming)
				yield return null;
			SetCallbackSlider(0, (float value) =>
			{
				//0x1ED1770
				ConfigManager.Instance.SetNotesOffsetValue(value);
				int n = Mathf.RoundToInt(value);
				if (n < 0)
					n = -n;
				m_notes.SetNumber(n, 0);
				SetTextureTiming(n);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetLimitValueSlider(0, -75, 75);
			SetCallbackButton(2, () =>
			{
				//0x1ED18AC
				int val = ConfigManager.Instance.NotesPlus();
				SetValueSlider(0, val);
				if (val < 0)
					val = -val;
				m_notes.SetNumber(val, 0);
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(3, () =>
			{
				//0x1ED19C4
				int val = ConfigManager.Instance.NotesMinus();
				SetValueSlider(0, val);
				if (val < 0)
					val = -val;
				m_notes.SetNumber(val, 0);
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(1, () =>
			{
				//0x1ED1ADC
				ConfigManager.Instance.ApplyValue(true, () =>
				{
					//0x1ED1BAC
					if(CallbackButtonTiming != null)
					{
						CallbackButtonTiming();
					}
					PopupWindowManager.Close(null, null);
					ConfigUtility.PlaySeButton();
					MenuScene.Instance.ChangeRhythmAdjustScene();
				});
			});
			SetCallbackButton(0, () =>
			{
				//0x1ED1CF8
				ConfigUtility.TimingDefaultPopup((bool isDefault) =>
				{
					//0x1ED1DC0
					if (!isDefault)
						return;
					m_changeSliderSePlay = false;
					SetValueSlider(0, ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.Timing));
					m_changeSliderSePlay = true;
				});
				ConfigUtility.PlaySeButton();
			});
			Loaded();
		}

		// RVA: 0x1ED1164 Offset: 0x1ED1164 VA: 0x1ED1164 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_texUvList = uvMan.GetTexUVList("cmn_config_packtex");
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
