using UnityEngine.UI;
using UnityEngine;
using XeSys;
using XeSys.Gfx;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigMenu_01 : LayoutPopupConfigBase
	{
		public enum eToggleButtonType
		{
			HomeDiva = 0,
			DrawKira = 1,
			DivaEffect = 2,
			PlateAnimationHome = 3,
			PlateAnimationOther = 4,
		}

		public enum eButtonType
		{
			Default = 0,
			VoicePlus = 1,
			VoiceMinus = 2,
			SePlus = 3,
			SeMinus = 4,
			BgmPlus = 5,
			BgmMinus = 6,
		}

		private enum eSlider
		{
			Voice = 0,
			Se = 1,
			Bgm = 2,
		}

		[SerializeField]
		private Text m_titleVolume; // 0x38
		[SerializeField]
		private Text m_titleDiva; // 0x3C
		[SerializeField]
		private Text m_descDiva; // 0x40
		[SerializeField]
		private Text m_descCenterDiva; // 0x44
		[SerializeField]
		private Text m_descSelectDiva; // 0x48
		[SerializeField]
		private Text m_titleKira; // 0x4C
		[SerializeField]
		private Text m_descKira; // 0x50
		[SerializeField]
		private Text m_descOnKira; // 0x54
		[SerializeField]
		private Text m_descOffKira; // 0x58
		[SerializeField]
		private Text m_costumeEffectTitle; // 0x5C
		[SerializeField]
		private Text m_costumeEffectCaution01; // 0x60
		[SerializeField]
		private Text m_costumeEffectCaution02; // 0x64
		[SerializeField]
		private Text m_plateAnimeTitle; // 0x68
		[SerializeField]
		private Text m_plateAnimeCaution01; // 0x6C
		[SerializeField]
		private GameObject m_voicePos; // 0x70
		[SerializeField]
		private GameObject m_sePos; // 0x74
		[SerializeField]
		private GameObject m_bgmPos; // 0x78
		private bool m_changeSliderSePlay = true; // 0x80

		public Transform Parent { get; set; } // 0x7C

		// RVA: 0x1EC4160 Offset: 0x1EC4160 VA: 0x1EC4160 Slot: 6
		public override int GetContentsHeight()
		{
			return 1185;
		}

		// RVA: 0x1EC4168 Offset: 0x1EC4168 VA: 0x1EC4168 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EC4170 Offset: 0x1EC4170 VA: 0x1EC4170 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextTitleVolume(bk.GetMessageByLabel("config_text_00"));
			SetTextDivaTitle(bk.GetMessageByLabel("config_text_47"));
			SetTextDivaDesc(bk.GetMessageByLabel("config_text_48"));
			SetTextDivaCenerDesc(bk.GetMessageByLabel("config_text_49"));
			SetTextDivaSelectDesc(bk.GetMessageByLabel("config_text_50"));
			SetTextKiraTitle(bk.GetMessageByLabel("config_text_93"));
			SetTextKiraDesc(bk.GetMessageByLabel("config_text_94"));
			SetTextKiraOnDesc(bk.GetMessageByLabel("config_text_95"));
			SetTextKiraOffDesc(bk.GetMessageByLabel("config_text_96"));
			SeCostumeEffectTitle(bk.GetMessageByLabel("config_text_98"));
			SeCostumeEffectCaution01(bk.GetMessageByLabel("config_text_99"));
			SeCostumeEffectCaution02(bk.GetMessageByLabel("config_text_100"));
			SetPlateAnimeTitle(bk.GetMessageByLabel("config_text_101"));
			SetPlateAnimeCaution01(bk.GetMessageByLabel("config_text_102"));
			SetSelectToggleButton(0, ConfigManager.Instance.HomeDiva);
			SetSelectToggleButton(1, ConfigManager.Instance.Option.GACNKPOMOFA_IsDrawKira);
			SetSelectToggleButton(3, ConfigManager.Instance.Option.LENJLNLNPEO_IsPlateAnimationHome);
			SetSelectToggleButton(4, ConfigManager.Instance.Option.DFLJOKOKLIL_IsPlateAnimationOther);
			SetSelectToggleButton(2, ConfigManager.Instance.Option.MDMDEAFFIMB_IsDivaEffect);
			m_changeSliderSePlay = false;
			SetValueSlider(2, ConfigManager.Instance.Option.HOMPENLIHCK_VolBgm);
			SetValueSlider(0, ConfigManager.Instance.Option.CNCIMBGLKOB_VolVoice);
			SetValueSlider(1, ConfigManager.Instance.Option.BGLLCLEDHKK_VolSe);
			m_changeSliderSePlay = true;
		}

		//// RVA: 0x1EC48AC Offset: 0x1EC48AC VA: 0x1EC48AC
		public void SetTextTitleVolume(string text)
		{
			if (m_titleVolume != null)
				m_titleVolume.text = text;
		}

		//// RVA: 0x1EC4970 Offset: 0x1EC4970 VA: 0x1EC4970
		public void SetTextDivaTitle(string text)
		{
			if (m_titleDiva != null)
				m_titleDiva.text = text;
		}

		//// RVA: 0x1EC4A34 Offset: 0x1EC4A34 VA: 0x1EC4A34
		public void SetTextDivaDesc(string text)
		{
			if (m_descDiva != null)
				m_descDiva.text = text;
		}

		//// RVA: 0x1EC4AF8 Offset: 0x1EC4AF8 VA: 0x1EC4AF8
		public void SetTextDivaCenerDesc(string text)
		{
			if (m_descCenterDiva != null)
				m_descCenterDiva.text = text;
		}

		//// RVA: 0x1EC4BBC Offset: 0x1EC4BBC VA: 0x1EC4BBC
		public void SetTextDivaSelectDesc(string text)
		{
			if (m_descSelectDiva != null)
				m_descSelectDiva.text = text;
		}

		//// RVA: 0x1EC4C80 Offset: 0x1EC4C80 VA: 0x1EC4C80
		public void SetTextKiraTitle(string text)
		{
			if (m_titleKira != null)
				m_titleKira.text = text;
		}

		//// RVA: 0x1EC4D44 Offset: 0x1EC4D44 VA: 0x1EC4D44
		public void SetTextKiraDesc(string text)
		{
			if (m_descKira != null)
				m_descKira.text = text;
		}

		//// RVA: 0x1EC4E08 Offset: 0x1EC4E08 VA: 0x1EC4E08
		public void SetTextKiraOnDesc(string text)
		{
			if (m_descOnKira != null)
				m_descOnKira.text = text;
		}

		//// RVA: 0x1EC4ECC Offset: 0x1EC4ECC VA: 0x1EC4ECC
		public void SetTextKiraOffDesc(string text)
		{
			if (m_descOffKira != null)
				m_descOffKira.text = text;
		}

		//// RVA: 0x1EC4F90 Offset: 0x1EC4F90 VA: 0x1EC4F90
		public void SeCostumeEffectTitle(string text)
		{
			if (m_costumeEffectTitle != null)
				m_costumeEffectTitle.text = text;
		}

		//// RVA: 0x1EC5054 Offset: 0x1EC5054 VA: 0x1EC5054
		public void SeCostumeEffectCaution01(string text)
		{
			if (m_costumeEffectCaution01 != null)
				m_costumeEffectCaution01.text = text;
		}

		//// RVA: 0x1EC5118 Offset: 0x1EC5118 VA: 0x1EC5118
		public void SeCostumeEffectCaution02(string text)
		{
			if (m_costumeEffectCaution02 != null)
				m_costumeEffectCaution02.text = text;
		}

		//// RVA: 0x1EC51DC Offset: 0x1EC51DC VA: 0x1EC51DC
		public void SetPlateAnimeTitle(string text)
		{
			if (m_plateAnimeTitle != null)
				m_plateAnimeTitle.text = text;
		}

		//// RVA: 0x1EC52A0 Offset: 0x1EC52A0 VA: 0x1EC52A0
		public void SetPlateAnimeCaution01(string text)
		{
			if (m_plateAnimeCaution01 != null)
				m_plateAnimeCaution01.text = text;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70164C Offset: 0x70164C VA: 0x70164C
		//// RVA: 0x1EC5364 Offset: 0x1EC5364 VA: 0x1EC5364
		private IEnumerator SetupLayout()
		{
			//0x1EC64FC
			bool isSlider = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type002", (FileResultObject flo) =>
			{
				//0x1EC544C
				GameObject g = Instantiate(flo.unityObject) as GameObject;
				Slider s = g.GetComponent<Slider>();
				s.transform.SetParent(m_bgmPos.transform, false);
				m_sliders.Add(2, s);

				g = Instantiate(flo.unityObject) as GameObject;
				s = g.GetComponent<Slider>();
				s.transform.SetParent(m_sePos.transform, false);
				m_sliders.Add(1, s);

				g = Instantiate(flo.unityObject) as GameObject;
				s = g.GetComponent<Slider>();
				s.transform.SetParent(m_voicePos.transform, false);
				m_sliders.Add(0, s);

				isSlider = true;
				return true;
			});
			ResourcesManager.Instance.Load();
			while(!isSlider)
				yield return null;
			SetLimitValueSlider(0, 0, 20);
			SetLimitValueSlider(2, 0, 20);
			SetLimitValueSlider(1, 0, 20);
			SetCallbackSlider(0, (float value) =>
			{
				//0x1EC58FC
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.MENU_VOICE, value);
				if (m_changeSliderSePlay && m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(2, (float value) =>
			{
				//0x1EC59E8
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.MENU_BGM, value);
				if (m_changeSliderSePlay && m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(1, (float value) =>
			{
				//0x1EC5AD4
				ConfigManager.Instance.SetVolume(Common.SoundManager.CategoryId.MENU_SE, value);
				if (m_changeSliderSePlay && m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackButton(0, () =>
			{
				//0x1EC5BC0
				ConfigUtility.VolumeDefaultPopup((bool isDefault) =>
				{
					//0x1EC5C74

				});
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(5, () =>
			{
				//0x1EC5D74
				SetValueSlider(2, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.MENU_BGM, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(6, () =>
			{
				//0x1EC5E2C
				SetValueSlider(2, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.MENU_BGM, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(1, () =>
			{
				//0x1EC5EE4
				SetValueSlider(0, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.MENU_VOICE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(2, () =>
			{
				//0x1EC5F9C
				SetValueSlider(0, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.MENU_VOICE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(3, () =>
			{
				//0x1EC6054
				SetValueSlider(1, ConfigManager.Instance.VolumePlus(Common.SoundManager.CategoryId.MENU_SE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(4, () =>
			{
				//0x1EC610C
				SetValueSlider(1, ConfigManager.Instance.VolumeMinus(Common.SoundManager.CategoryId.MENU_SE, false));
				ConfigUtility.PlaySeButton();
			});
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EC61C4
				ConfigManager.Instance.SetHomeDiva(value);
				ConfigUtility.PlaySeToggleButton();
			});
			SetCallbackToggleButton(1, (int value) =>
			{
				//0x1EC6268
				ConfigManager.Instance.SetDrawKira(value);
				ConfigUtility.PlaySeToggleButton();
			});
			SetCallbackToggleButton(2, (int value) =>
			{
				//0x1EC630C
				ConfigManager.Instance.SetDivaEffect(value);
				ConfigUtility.PlaySeToggleButton();
			});
			SetCallbackToggleButton(3, (int value) =>
			{
				//0x1EC63B0
				ConfigManager.Instance.SetPlateAnimationHome(value);
				ConfigUtility.PlaySeToggleButton();
			});
			SetCallbackToggleButton(4, (int value) =>
			{
				//0x1EC6454
				ConfigManager.Instance.SetPlateAnimationOther(value);
				ConfigUtility.PlaySeToggleButton();
			});
			Loaded();
		}

		// RVA: 0x1EC5410 Offset: 0x1EC5410 VA: 0x1EC5410 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(SetupLayout());
			return true;
		}
	}
}
