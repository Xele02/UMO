using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigSimulation_01 : LayoutPopupConfigBase
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

		// RVA: 0x1ED804C Offset: 0x1ED804C VA: 0x1ED804C Slot: 6
		public override int GetContentsHeight()
		{
			return 505;
		}

		// RVA: 0x1ED8054 Offset: 0x1ED8054 VA: 0x1ED8054 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1ED805C Offset: 0x1ED805C VA: 0x1ED805C Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			m_changeSliderSePlay = false;
			SetValueSlider(0, ConfigManager.Instance.OptionSLive.FCKEDCKCEFC_VolVoiceRhythm);
			SetValueSlider(1, ConfigManager.Instance.OptionSLive.LMDACNNJDOE_VolSeRhythm);
			SetValueSlider(2, ConfigManager.Instance.OptionSLive.ICGAOAFIHFD_VolBgmRhythm);
			SetValueSlider(3, ConfigManager.Instance.OptionSLive.IBEINHHMHAC_VolNotesRhythm);
			m_changeSliderSePlay = true;
		}

		//// RVA: 0x1ED81E8 Offset: 0x1ED81E8 VA: 0x1ED81E8
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_textTbl.Length; i++)
			{
				string s = "";
				int index = i;
				if(!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					index = m_textTbl[i].index;
					s = bk.GetMessageByLabel(m_textTbl[i].label);
				}
				SetText(index, s);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70258C Offset: 0x70258C VA: 0x70258C
		//// RVA: 0x1ED83F0 Offset: 0x1ED83F0 VA: 0x1ED83F0
		private IEnumerator Setup()
		{
			//0x1ED98F8
			SetText();
			bool isSlider = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type002", (FileResultObject flo) =>
			{
				//0x1ED86BC
				GameObject g = Instantiate(flo.unityObject) as GameObject;
				g.GetComponent<Slider>().transform.SetParent(m_voicePos.transform, false);
				m_sliders.Add(0, g.GetComponent<Slider>());
				g = Instantiate(flo.unityObject) as GameObject;
				g.GetComponent<Slider>().transform.SetParent(m_bgmPos.transform, false);
				m_sliders.Add(2, g.GetComponent<Slider>());
				g = Instantiate(flo.unityObject) as GameObject;
				g.GetComponent<Slider>().transform.SetParent(m_sePos.transform, false);
				m_sliders.Add(1, g.GetComponent<Slider>());
				g = Instantiate(flo.unityObject) as GameObject;
				g.GetComponent<Slider>().transform.SetParent(m_notesPos.transform, false);
				m_sliders.Add(3, g.GetComponent<Slider>());
				isSlider = true;
				return true;
			});
			ResourcesManager.Instance.Load();
			while(!isSlider)
				yield return null;
			SetCallbackSlider(0, (float value) =>
			{
				//0x1ED8CCC
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_VOICE, value, true);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(1, (float value) =>
			{
				//0x1ED8D98
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_SE, value, true);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(2, (float value) =>
			{
				//0x1ED8E64
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_BGM, value, true);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(3, (float value) =>
			{
				//0x1ED8F30
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.GAME_NOTES, value, true);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetLimitValueSlider(0, 0, 20);
			SetLimitValueSlider(1, 0, 20);
			SetLimitValueSlider(2, 0, 20);
			SetLimitValueSlider(3, 0, 20);
			SetCallbackButton(7, () =>
			{
				//0x1ED8FFC
				SetValueSlider(2, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_BGM, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(8, () =>
			{
				//0x1ED90C8
				SetValueSlider(2, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_BGM, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(3, () =>
			{
				//0x1ED9194
				SetValueSlider(0, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_VOICE, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(4, () =>
			{
				//0x1ED9260
				SetValueSlider(0, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_VOICE, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(5, () =>
			{
				//0x1ED932C
				SetValueSlider(1, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_SE, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(6, () =>
			{
				//0x1ED93F8
				SetValueSlider(1, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_SE, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(1, () =>
			{
				//0x1ED94C4
				SetValueSlider(3, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.GAME_NOTES, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(2, () =>
			{
				//0x1ED9590
				SetValueSlider(3, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.GAME_NOTES, true));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(0, () =>
			{
				//0x1ED965C
				ConfigUtility.VolumeDefaultPopup((bool isDefault) =>
				{
					//0x1ED9724
					if (!isDefault)
						return;
					ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.SLiveVolume);
					m_changeSliderSePlay = false;
					SetValueSlider(2, ConfigManager.Instance.OptionSLive.ICGAOAFIHFD_VolBgmRhythm);
					SetValueSlider(1, ConfigManager.Instance.OptionSLive.LMDACNNJDOE_VolSeRhythm);
					SetValueSlider(0, ConfigManager.Instance.OptionSLive.FCKEDCKCEFC_VolVoiceRhythm);
					SetValueSlider(3, ConfigManager.Instance.OptionSLive.IBEINHHMHAC_VolNotesRhythm);
					m_changeSliderSePlay = true;
				});
				ConfigUtility.PlaySeButton();
			});
			Loaded();
		}

		// RVA: 0x1ED849C Offset: 0x1ED849C VA: 0x1ED849C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
