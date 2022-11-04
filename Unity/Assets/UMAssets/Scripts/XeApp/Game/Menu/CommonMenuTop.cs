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
			TodoLogger.Log(0, "Init layout common top menu");
			return true;
		}

		// // RVA: 0x1B4D554 Offset: 0x1B4D554 VA: 0x1B4D554
		// private void UpdateLoad() { }

		// // RVA: 0x1B4D698 Offset: 0x1B4D698 VA: 0x1B4D698
		// private void UpdateIdle() { }

		// // RVA: 0x1B4D69C Offset: 0x1B4D69C VA: 0x1B4D69C
		public void Enter(bool isEnd = false)
		{
			TodoLogger.Log(0, "Enter common top menu");
		}

		// // RVA: 0x1B49E30 Offset: 0x1B49E30 VA: 0x1B49E30
		public void Leave(bool isEnd = false)
		{
			TodoLogger.Log(0, "Leave common top menu");
		}

		// // RVA: 0x1B4D764 Offset: 0x1B4D764 VA: 0x1B4D764
		// public bool IsPlaying() { }

		// // RVA: 0x1B49F50 Offset: 0x1B49F50 VA: 0x1B49F50
		// public bool LeaveEnd() { }

		// // RVA: 0x1B4D790 Offset: 0x1B4D790 VA: 0x1B4D790
		// public void SetLevelLimit(bool isLimit) { }

		// // RVA: 0x1B4D798 Offset: 0x1B4D798 VA: 0x1B4D798
		// public void ChangeEnergyValue(int num, int den) { }

		// // RVA: 0x1B4D908 Offset: 0x1B4D908 VA: 0x1B4D908
		// public void ChangeLevelValue(int level) { }

		// // RVA: 0x1B4D948 Offset: 0x1B4D948 VA: 0x1B4D948
		// public void ChangeEXPValue(int current, int max) { }

		// // RVA: 0x1B4D9E0 Offset: 0x1B4D9E0 VA: 0x1B4D9E0
		// private static int ConvertTimeBasedValue(int seconds) { }

		// // RVA: 0x1B4DA08 Offset: 0x1B4DA08 VA: 0x1B4DA08
		// private static int ConvertTimeBasedValue(int minutes, int seconds) { }

		// // RVA: 0x1B4DA14 Offset: 0x1B4DA14 VA: 0x1B4DA14
		// public void ChangeRemainTime(int seconds) { }

		// // RVA: 0x1B4D7F0 Offset: 0x1B4D7F0 VA: 0x1B4D7F0
		// private void SetEnergyNum(int num, int den) { }

		// // RVA: 0x1B4D478 Offset: 0x1B4D478 VA: 0x1B4D478
		// private void SetEnergyMaxAnim(bool enable, bool force = False) { }

		// // RVA: 0x1B4DB68 Offset: 0x1B4DB68 VA: 0x1B4DB68
		// private void OnClickRankInfo() { }

		// // RVA: 0x1B4E59C Offset: 0x1B4E59C VA: 0x1B4E59C
		// private void OnClickUtaRateInfo() { }

		// // RVA: 0x1B4E8E4 Offset: 0x1B4E8E4 VA: 0x1B4E8E4
		public void LeaveMiniWindow()
		{
			TodoLogger.Log(0, "LeaveMiniWindow");
		}

		// // RVA: 0x1B4EC20 Offset: 0x1B4EC20 VA: 0x1B4EC20
		public bool IsPlayingMiniWindow()
		{
			TodoLogger.Log(0, "IsPlayingMiniWindow");
			return false;
		}

		// // RVA: 0x1B4ED00 Offset: 0x1B4ED00 VA: 0x1B4ED00
		// public void ChangeCurrencyValue(int nonPaid, int paid) { }

		// // RVA: 0x1B4EE2C Offset: 0x1B4EE2C VA: 0x1B4EE2C
		// public void ChangeUtaRateValue(HighScoreRatingRank.Type grade, int ranking) { }

		// // RVA: 0x1B4EFE8 Offset: 0x1B4EFE8 VA: 0x1B4EFE8
		// public void ChangeMedalValue(int medalMonth, int value) { }

		// // RVA: 0x1B4D42C Offset: 0x1B4D42C VA: 0x1B4D42C
		// public void SetActiveMonthlyCoin(bool active) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CC484 Offset: 0x6CC484 VA: 0x6CC484
		// // RVA: 0x1B4F1E4 Offset: 0x1B4F1E4 VA: 0x1B4F1E4
		// private void <InitializeFromLayout>b__40_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CC494 Offset: 0x6CC494 VA: 0x6CC494
		// // RVA: 0x1B4F1F8 Offset: 0x1B4F1F8 VA: 0x1B4F1F8
		// private void <InitializeFromLayout>b__40_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6CC4A4 Offset: 0x6CC4A4 VA: 0x6CC4A4
		// // RVA: 0x1B4F20C Offset: 0x1B4F20C VA: 0x1B4F20C
		// private void <ChangeUtaRateValue>b__61_0(IiconTexture texture) { }
	}
}
