using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_02 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			VolumeTitle = 0,
			NotesCaution = 1,
			Num = 2,
		}

		private enum eButtonType
		{
			VolumeDefault = 0,
			NotesPlus = 1,
			NotesMinus = 2,
			VoicePlus = 3,
			VoiceMinus = 4,
			SePlus = 5,
			SeMinus = 6,
			VolumePlus = 7,
			VolumeMinus = 8,
			Num = 9,
		}

		private enum eSlider
		{
			Voice = 0,
			Se = 1,
			Bgm = 2,
			Notes = 3,
		}

		[SerializeField]
		private GameObject m_notesPos; // 0x38
		[SerializeField]
		private GameObject m_voicePos; // 0x3C
		[SerializeField]
		private GameObject m_sePos; // 0x40
		[SerializeField]
		private GameObject m_bgmPos; // 0x44
		private TextSet[] m_textTbl = new TextSet[2]
		{
			new TextSet() { index = 0, label = "config_text_00" },
			new TextSet() { index = 1, label = "config_text_78" },
		}; // 0x48

		// RVA: 0x1ECC7B0 Offset: 0x1ECC7B0 VA: 0x1ECC7B0 Slot: 6
		public override int GetContentsHeight()
		{
			return 505;
		}

		// RVA: 0x1ECC7B8 Offset: 0x1ECC7B8 VA: 0x1ECC7B8 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ECC7C0 Offset: 0x1ECC7C0 VA: 0x1ECC7C0 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			m_changeSliderSePlay = false;
			SetValueSlider(0, ConfigManager.Instance.Option.FCKEDCKCEFC_VolVoiceRhythm);
			SetValueSlider(1, ConfigManager.Instance.Option.LMDACNNJDOE_VolSeRhythm);
			SetValueSlider(2, ConfigManager.Instance.Option.ICGAOAFIHFD_VolBgmRhythm);
			SetValueSlider(3, ConfigManager.Instance.Option.IBEINHHMHAC_VolNotesRhythm);
			m_changeSliderSePlay = true;
		}

		//// RVA: 0x1ECC94C Offset: 0x1ECC94C VA: 0x1ECC94C
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_textTbl.Length; i++)
			{
				if(!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701B0C Offset: 0x701B0C VA: 0x701B0C
		//// RVA: 0x1ECCB54 Offset: 0x1ECCB54 VA: 0x1ECCB54
		private IEnumerator Setup()
		{
			//0x1ECE35C
			SetText();
			bool isSlider = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type002", (FileResultObject flo) =>
			{
				//0x1ECD120
				GameObject inst = Instantiate(flo.unityObject) as GameObject;
				Slider s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_voicePos.transform, false);
				m_sliders.Add(0, s);

				inst = Instantiate(flo.unityObject) as GameObject;
				s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_bgmPos.transform, false);
				m_sliders.Add(2, s);

				inst = Instantiate(flo.unityObject) as GameObject;
				s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_sePos.transform, false);
				m_sliders.Add(1, s);

				inst = Instantiate(flo.unityObject) as GameObject;
				s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_notesPos.transform, false);
				m_sliders.Add(3, s);
				isSlider = true;
				return true;
			});
			ResourcesManager.Instance.Load();
			while (!isSlider)
				yield return null;
			SetCallbackSlider(0, (float value) =>
			{
				//0x1ECD730
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_VOICE, value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(1, (float value) =>
			{
				//0x1ECD7FC
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_SE, value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(2, (float value) =>
			{
				//0x1ECD8C8
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_BGM, value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(3, (float value) =>
			{
				//0x1ECD994
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_NOTES, value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetLimitValueSlider(0, 0, 20);
			SetLimitValueSlider(1, 0, 20);
			SetLimitValueSlider(2, 0, 20);
			SetLimitValueSlider(3, 0, 20);
			SetCallbackButton(7, () =>
			{
				//0x1ECDA60
				SetValueSlider(2, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_BGM, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(8, () =>
			{
				//0x1ECDB2C
				SetValueSlider(2, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_BGM, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(3, () =>
			{
				//0x1ECDBF8
				SetValueSlider(0, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_VOICE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(4, () =>
			{
				//0x1ECDCC4
				SetValueSlider(0, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_VOICE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(5, () =>
			{
				//0x1ECDD90
				SetValueSlider(1, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_SE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(6, () =>
			{
				//0x1ECDE5C
				SetValueSlider(1, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_SE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(1, () =>
			{
				//0x1ECDF28
				SetValueSlider(3, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_NOTES, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(2, () =>
			{
				//0x1ECDFF4
				SetValueSlider(3, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_NOTES, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(0, () =>
			{
				//0x1ECE0C0
				ConfigUtility.VolumeDefaultPopup((bool isDefault) =>
				{
					//0x1ECE188
					if(!isDefault)
						return;
					ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.RhythmVolume);
					m_changeSliderSePlay = false;
					SetValueSlider(2, ConfigManager.Instance.Option.ICGAOAFIHFD_VolBgmRhythm);
					SetValueSlider(1, ConfigManager.Instance.Option.LMDACNNJDOE_VolSeRhythm);
					SetValueSlider(0, ConfigManager.Instance.Option.FCKEDCKCEFC_VolVoiceRhythm);
					SetValueSlider(3, ConfigManager.Instance.Option.IBEINHHMHAC_VolNotesRhythm);
					m_changeSliderSePlay = true;
				});
				ConfigUtility.PlaySeButton();
			});
			Loaded();
		}

		// RVA: 0x1ECCC00 Offset: 0x1ECCC00 VA: 0x1ECCC00 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			m_texts[1].enabled = false;
			transform.GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) =>
			{
				//0x1ECD098
				return _.name == "cmn_head_icon_new_02 (ImageView)";
			}).First().enabled = false;
			return true;
		}
	}
}
