using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System;

namespace XeApp.Game.Menu
{
	public class CommonMenuTop : LayoutUGUIScriptBase
	{
		private Layout m_layout; // 0x14
		private AbsoluteLayout m_root; // 0x18
		private AbsoluteLayout m_main; // 0x1C
		private AbsoluteLayout m_energyNum; // 0x20
		private AbsoluteLayout m_energyMax; // 0x24
		private AbsoluteLayout m_coin_layout; // 0x28
		private int m_utaRateRanking = -100; // 0x2C
		private HighScoreRatingRank.Type m_utaGrade; // 0x30
		[SerializeField]
		private CommonMenuTopButton[] m_menu_top_button; // 0x34
		[SerializeField]
		private CommonMenuExpGauge m_exp_gauge; // 0x38
		[SerializeField]
		private NumberBase m_numberRank; // 0x3C
		[SerializeField]
		private RawImageEx m_imageUtaGrade; // 0x40
		[SerializeField]
		private Text m_textUtaRate; // 0x44
		[SerializeField]
		private RawImageEx m_imageMedal; // 0x48
		[SerializeField]
		private Text m_textMedal; // 0x4C
		[SerializeField]
		private Text m_textEnergyNum; // 0x50
		[SerializeField]
		private Text m_textEnergyTime; // 0x54
		[SerializeField]
		private Text m_textUC; // 0x58
		[SerializeField]
		private Text m_textStone; // 0x5C
		[SerializeField]
		private ButtonBase m_buttonRank; // 0x60
		[SerializeField]
		private ButtonBase m_buttonUtaRate; // 0x64
		[SerializeField]
		private CommonMenuTopMiniWindow m_miniWindowPrefab; // 0x68
		private CommonMenuTopMiniWindow m_miniWindow; // 0x6C
		private StringBuilder table_id = new StringBuilder(); // 0x70
		private bool is_show; // 0x74
		private bool is_energy_max; // 0x75
		private bool is_level_limit; // 0x76
		private bool is_play_energy_max; // 0x77
		private Action mUpdater; // 0x78
		private Action m_on_recov_ene; // 0x7C
		private Action m_on_charge_mny; // 0x80
		private Rect[] m_monthly_coin_rect; // 0x84

		public Action OnRecovEne { set { m_on_recov_ene = value; } } //0x1B4CCC4
		 public Action OnChargeMoney { set { m_on_charge_mny = value; } } //0x1B4CCCC

		// RVA: 0x1B4CCD4 Offset: 0x1B4CCD4 VA: 0x1B4CCD4
		private void Update()
		{
			if(mUpdater != null)
				mUpdater();
		}

		// RVA: 0x1B4CCE8 Offset: 0x1B4CCE8 VA: 0x1B4CCE8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout;
			m_root = layout.FindViewByExId("root_cmn_head_sw_title_anim") as AbsoluteLayout;
			m_main = layout.FindViewByExId("sw_head_anim_swtbl_cmn_head_p") as AbsoluteLayout;
			m_coin_layout = layout.FindViewById("swtbl_cmn_head_p") as AbsoluteLayout;
			m_energyNum = layout.FindViewById("swfrm_cmn_head_en_bar") as AbsoluteLayout;
			m_energyMax = layout.FindViewById("sw_cmn_head_en_eff_anim") as AbsoluteLayout;
			m_menu_top_button[0].AddOnClickCallback(() =>
			{
				//0x1B4F1E4
				if (m_on_recov_ene != null)
					m_on_recov_ene();
			});
			m_menu_top_button[1].AddOnClickCallback(() =>
			{
				//0x1B4F1F8
				if (m_on_charge_mny != null)
					m_on_charge_mny();
			});
			m_buttonRank.AddOnClickCallback(OnClickRankInfo);
			m_buttonUtaRate.AddOnClickCallback(OnClickUtaRateInfo);
			m_monthly_coin_rect = new Rect[12];
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < 12; i++)
			{
				str.Clear();
				str.AppendFormat("cmn_evecoin_icon_{0:D2}", i + 1);
				m_monthly_coin_rect[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
			}
			mUpdater = UpdateLoad;
			SetActiveMonthlyCoin(true);
			m_imageMedal.uvRect = m_monthly_coin_rect[0];
			SetEnergyMaxAnim(false, true);
			return true;
		}

		// // RVA: 0x1B4D554 Offset: 0x1B4D554 VA: 0x1B4D554
		private void UpdateLoad()
		{
			for(int i = 0; i < m_menu_top_button.Length; i++)
			{
				if (!m_menu_top_button[i].IsLoaded())
					return;
			}
			if (!m_numberRank.IsLoaded())
				return;
			Loaded();
			mUpdater = UpdateIdle;
		}

		// // RVA: 0x1B4D698 Offset: 0x1B4D698 VA: 0x1B4D698
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x1B4D69C Offset: 0x1B4D69C VA: 0x1B4D69C
		public void Enter(bool isEnd = false)
		{
			if(!is_show)
			{
				m_main.StartSiblingAnimGoStop(isEnd ? "st_in" : "go_in", "st_in");
			}
			is_show = true;
		}

		// // RVA: 0x1B49E30 Offset: 0x1B49E30 VA: 0x1B49E30
		public void Leave(bool isEnd = false)
		{
			if(is_show)
			{
				m_main.StartSiblingAnimGoStop(isEnd ? "st_out" : "go_out", "st_out");
			}
			is_show = false;
		}

		// // RVA: 0x1B4D764 Offset: 0x1B4D764 VA: 0x1B4D764
		public bool IsPlaying()
		{
			return m_main.IsPlayingSibling();
		}

		// // RVA: 0x1B49F50 Offset: 0x1B49F50 VA: 0x1B49F50
		// public bool LeaveEnd() { }

		// // RVA: 0x1B4D790 Offset: 0x1B4D790 VA: 0x1B4D790
		public void SetLevelLimit(bool isLimit)
		{
			is_level_limit = isLimit;
		}

		// // RVA: 0x1B4D798 Offset: 0x1B4D798 VA: 0x1B4D798
		public void ChangeEnergyValue(int num, int den)
		{
			if (den == 0)
				return;
			if (num < 1)
				num = 0;
			SetEnergyNum(num, den);
			is_energy_max = den <= num;
			SetEnergyMaxAnim(den <= num, false);
		}

		// // RVA: 0x1B4D908 Offset: 0x1B4D908 VA: 0x1B4D908
		public void ChangeLevelValue(int level)
		{
			m_numberRank.SetNumber(level, 0);
		}

		// // RVA: 0x1B4D948 Offset: 0x1B4D948 VA: 0x1B4D948
		public void ChangeEXPValue(int current, int max)
		{
			if(is_level_limit)
			{
				m_exp_gauge.gaugeMax = 1;
				m_exp_gauge.gaugeValue = 1;
			}
			else
			{
				m_exp_gauge.gaugeMax = max;
				m_exp_gauge.gaugeValue = current;
			}
		}

		// // RVA: 0x1B4D9E0 Offset: 0x1B4D9E0 VA: 0x1B4D9E0
		// private static int ConvertTimeBasedValue(int seconds) { }

		// // RVA: 0x1B4DA08 Offset: 0x1B4DA08 VA: 0x1B4DA08
		// private static int ConvertTimeBasedValue(int minutes, int seconds) { }

		// // RVA: 0x1B4DA14 Offset: 0x1B4DA14 VA: 0x1B4DA14
		public void ChangeRemainTime(int seconds)
		{
			if(!is_energy_max)
			{
				m_textEnergyTime.text = JpStringLiterals.StringLiteral_11083 + (seconds / 60) + ":" + (seconds % 60).ToString("00");
			}
			else
			{
				m_textEnergyTime.text = "MAX";
			}
		}

		// // RVA: 0x1B4D7F0 Offset: 0x1B4D7F0 VA: 0x1B4D7F0
		private void SetEnergyNum(int num, int den)
		{
			m_textEnergyNum.text = string.Format("<color=#ff2992>{0}</color>/{1}", num, den);
			int start = num * 100 / den;
			m_energyNum.StartChildrenAnimGoStop(start, start);
		}

		// // RVA: 0x1B4D478 Offset: 0x1B4D478 VA: 0x1B4D478
		private void SetEnergyMaxAnim(bool enable, bool force = false)
		{
			if (!force && is_play_energy_max == enable)
				return;
			is_play_energy_max = enable;
			if (enable)
				m_energyMax.StartChildrenAnimLoop("logo_01", "loen_01");
			else
				m_energyMax.StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0x1B4DB68 Offset: 0x1B4DB68 VA: 0x1B4DB68
		private void OnClickRankInfo()
		{
			TodoLogger.LogNotImplemented("CommonMenuTop.OnClickRankInfo");
		}

		// // RVA: 0x1B4E59C Offset: 0x1B4E59C VA: 0x1B4E59C
		private void OnClickUtaRateInfo()
		{
			if(m_miniWindow == null)
			{
				m_miniWindow = Instantiate(m_miniWindowPrefab);
#if UNITY_EDITOR || UNITY_STANDALONE
				BundleShaderInfo.Instance.FixMaterialShader(m_miniWindow.gameObject);
#endif
				m_miniWindow.transform.SetParent(transform.parent, false);
				m_miniWindow.transform.SetAsLastSibling();
				m_miniWindow.SetFont(m_layout.fontInfo.font);
			}
			IFBCGCCJBHI d = new IFBCGCCJBHI();
			d.KHEKNNFCAOI();
			string s = string.Format("{0}", "----");
			if(d.JHKAEJBNGKE_RateLeftToNext > 0)
			{
				s = string.Format("{0}", d.JHKAEJBNGKE_RateLeftToNext);
			}
			m_miniWindow.Setup(0, s, d.JHKAEJBNGKE_RateLeftToNext);
			m_miniWindow.Enter();
		}

		// // RVA: 0x1B4E8E4 Offset: 0x1B4E8E4 VA: 0x1B4E8E4
		public void LeaveMiniWindow()
		{
			if (m_miniWindow != null)
			{
				m_miniWindow.Leave();
			}
		}

		// // RVA: 0x1B4EC20 Offset: 0x1B4EC20 VA: 0x1B4EC20
		public bool IsPlayingMiniWindow()
		{
			if(m_miniWindow != null)
			{
				return m_miniWindow.IsPlaying();
			}
			return false;
		}

		// // RVA: 0x1B4ED00 Offset: 0x1B4ED00 VA: 0x1B4ED00
		public void ChangeCurrencyValue(int nonPaid, int paid)
		{
			m_textUC.text = string.Format("{0:#,0}", nonPaid);
			m_textStone.text = string.Format("{0:#,0}", paid);
		}

		// // RVA: 0x1B4EE2C Offset: 0x1B4EE2C VA: 0x1B4EE2C
		public void ChangeUtaRateValue(HighScoreRatingRank.Type grade, int ranking)
		{
			int a = OEGIPPCADNA.BFKAHKBKBJE(ranking, 0);
			if (m_utaRateRanking != a)
			{
				m_utaRateRanking = a;
				m_textUtaRate.text = OEGIPPCADNA.GEEFFAEGHAH(a, true);
			}
			if (m_utaGrade == grade)
				return;
			m_utaGrade = grade;
			m_imageUtaGrade.enabled = false;
			GameManager.Instance.MusicRatioTextureCache.Load(m_utaGrade, (IiconTexture texture) =>
			{
				//0x1B4F20C
				if(texture != null)
				{
					MusicRatioTextureCache.MusicRatioTexture tex = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(tex != null)
					{
						m_imageUtaGrade.enabled = true;
						tex.Set(m_imageUtaGrade, m_utaGrade);
					}
				}
			});
		}

		// // RVA: 0x1B4EFE8 Offset: 0x1B4EFE8 VA: 0x1B4EFE8
		public void ChangeMedalValue(int medalMonth, int value)
		{
			m_textMedal.text = string.Format("{0:#,0}", value).ToString();
			if (medalMonth < 2)
				medalMonth = 1;
			if (medalMonth > 11)
				medalMonth = 12;
			m_imageMedal.uvRect = m_monthly_coin_rect[medalMonth - 1];
		}

		// // RVA: 0x1B4D42C Offset: 0x1B4D42C VA: 0x1B4D42C
		public void SetActiveMonthlyCoin(bool active)
		{
			m_coin_layout.StartChildrenAnimGoStop(active ? 1 : 0, active ? 1 : 0);
		}
	}
}
