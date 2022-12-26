using XeSys.Gfx;
using UnityEngine;
using System;
using CriWare;
using XeApp.Game.Common;
using System.Text;
using XeSys;
using System.Collections.Generic;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlayerRank : LayoutUGUIScriptBase
	{
		private static readonly int LevelDigitNum = 3; // 0x0
		private JJOPEDJCCJK_Exp expMaster; // 0x14
		// private BPOJMOOIIFI viewLevelupData; // 0x18
		public Action onFinished; // 0x1C
		private AbsoluteLayout layoutRoot; // 0x20
		private AbsoluteLayout layoutExpType; // 0x24
		private AbsoluteLayout layoutExpBonus; // 0x28
		private AbsoluteLayout layoutLevelupLeftEffect; // 0x2C
		private AbsoluteLayout[] layoutLevelupRightEffects = new AbsoluteLayout[LevelDigitNum]; // 0x30
		private AbsoluteLayout layoutLevelupRightEffect; // 0x34
		private AbsoluteLayout layoutLevelUp; // 0x38
		private AbsoluteLayout layoutExpGauge; // 0x3C
		private AbsoluteLayout layoutOldExpGauge; // 0x40
		private AbsoluteLayout layoutEffectInGauge; // 0x44
		private AbsoluteLayout layoutEffectOutGauge; // 0x48
		private AbsoluteLayout layoutAddAnimGauge; // 0x4C
		private NumberBase numberPlayerLevel; // 0x50
		private NumberBase numberCurrentExp; // 0x54
		private NumberBase numberRequiredExp; // 0x58
		private NumberBase numberExpBonus; // 0x5C
		private float restAcquiredExp; // 0x60
		private float currentGaugePercentage; // 0x64
		private CriAtomExPlayback countUpSEPlayback; // 0x68
		private bool m_isSkiped; // 0x6C
		private bool isOpenRankupPopup; // 0x6D
		private bool isLevelupFirst; // 0x6E
		private Matrix23 m_identity; // 0x70
		private Coroutine m_coroutine; // 0x88
		private Coroutine GaugeAnimFinishCoroutine; // 0x8C
		[SerializeField]
		private float GAUGE_ANIM_FINISH_TIME = 1.5f; // 0x90

		// RVA: 0x18E543C Offset: 0x18E543C VA: 0x18E543C
		private void Awake()
		{
			expMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
		}

		// RVA: 0x18E5500 Offset: 0x18E5500 VA: 0x18E5500
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.player == null)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x18E55A4 Offset: 0x18E55A4 VA: 0x18E55A4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			StringBuilder str = new StringBuilder();
			layoutRoot = layout.FindViewById("sw_plv_guage_anim") as AbsoluteLayout;
			layoutExpType = layoutRoot.FindViewById("swtbl_plv_guage") as AbsoluteLayout;
			layoutExpBonus = layoutRoot.FindViewById("sw_num_multi_onoff") as AbsoluteLayout;
			layoutLevelupLeftEffect = layoutExpType.FindViewById("sw_lv_kira") as AbsoluteLayout;
			for(int i = 0; i < LevelDigitNum; i++)
			{
				str.SetFormat("sw_lv_kira_{0}d", i + 1);
				layoutLevelupRightEffects[i] = layoutExpType.FindViewById(str.ToString()) as AbsoluteLayout;
			}
			layoutLevelUp = layoutExpType.FindViewById("sw_plvup") as AbsoluteLayout;
			layoutExpGauge = layoutExpType.FindViewById("swfrm_plv") as AbsoluteLayout;
			layoutOldExpGauge = layoutExpType.FindViewByExId("swfrm_plv_sw_plv_plus_anim") as AbsoluteLayout;
			layoutEffectInGauge = layoutExpType.FindViewByExId("swfrm_plv_sw_plv_guage_ef_inout_anim_in") as AbsoluteLayout;
			layoutEffectOutGauge = layoutExpType.FindViewByExId("swfrm_plv_sw_plv_guage_ef_inout_anim_out") as AbsoluteLayout;
			layoutAddAnimGauge = layoutExpType.FindViewById("sw_plv_plus_anim") as AbsoluteLayout;
			layoutEffectInGauge.StartAnimGoStop("st_stop");
			List<NumberBase> nbs = new List<NumberBase>(GetComponentsInChildren<NumberBase>(true));
			numberPlayerLevel = nbs.Find((NumberBase _) => {
				//0x18E73E4
				return _.name == "swnum_plv (AbsoluteLayout)";
			});
			numberCurrentExp = nbs.Find((NumberBase _) => {
				//0x18E7464
				return _.name == "swnum_plvexp_bunshi (AbsoluteLayout)";
			});
			numberRequiredExp = nbs.Find((NumberBase _) => {
				//0x18E74E4
				return _.name == "swnum_plvexp_bunbo (AbsoluteLayout)";
			});
			numberExpBonus = nbs.Find((NumberBase _) => {
				//0x18E7564
				return _.name == "swnum_multi (AbsoluteLayout)";
			});
			Loaded();
			return true;
		}

		// // RVA: 0x18E61BC Offset: 0x18E61BC VA: 0x18E61BC
		// public void Setup(BPOJMOOIIFI viewPlayerLevelupData) { }

		// // RVA: 0x18E62AC Offset: 0x18E62AC VA: 0x18E62AC
		public void SkipAnim()
		{
			m_isSkiped = true;
		}

		// // RVA: 0x18E62B8 Offset: 0x18E62B8 VA: 0x18E62B8
		public void StartAnim()
		{
			m_coroutine = StartCoroutine(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C79C Offset: 0x71C79C VA: 0x71C79C
		// // RVA: 0x18E62E0 Offset: 0x18E62E0 VA: 0x18E62E0
		private IEnumerator Co_StartAnim()
		{
			//0x18E8424
			TodoLogger.Log(0, "Co_StartAnim");
			yield return null;
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C814 Offset: 0x71C814 VA: 0x71C814
		// // RVA: 0x18E638C Offset: 0x18E638C VA: 0x18E638C
		// private IEnumerator Co_ExpIncreaseAnim() { }

		// // RVA: 0x18E6438 Offset: 0x18E6438 VA: 0x18E6438
		// private void LevelupProcess(int playerLevel) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C88C Offset: 0x71C88C VA: 0x71C88C
		// // RVA: 0x18E6724 Offset: 0x18E6724 VA: 0x18E6724
		// private IEnumerator Co_LevelMaxProcess(int playerLevel) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C904 Offset: 0x71C904 VA: 0x71C904
		// // RVA: 0x18E67EC Offset: 0x18E67EC VA: 0x18E67EC
		public IEnumerator Co_ShowRankupPopup()
		{
			TodoLogger.Log(0, "Co_ShowRankupPopup");
			yield return null;
		}

		// // RVA: 0x18E6898 Offset: 0x18E6898 VA: 0x18E6898
		public bool IsOpenRankupPopup()
		{
			TodoLogger.Log(0, "IsOpenRankupPopup");
			return false;
		}

		// // RVA: 0x18E645C Offset: 0x18E645C VA: 0x18E645C
		// private void StartLevelupAnimation(int playerLevel) { }

		// // RVA: 0x18E69C4 Offset: 0x18E69C4 VA: 0x18E69C4
		// private void OnButtonClickedPlayerRankup(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x18E68AC Offset: 0x18E68AC VA: 0x18E68AC
		// private void ChangePlayerLevel(int playerLevel) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C97C Offset: 0x71C97C VA: 0x71C97C
		// // RVA: 0x18E69C8 Offset: 0x18E69C8 VA: 0x18E69C8
		// private IEnumerator Co_FinishGaugeAnim() { }

		// // RVA: 0x18E6A74 Offset: 0x18E6A74 VA: 0x18E6A74
		// public void StartFinishGaugeAnim() { }

		// // RVA: 0x18E6A9C Offset: 0x18E6A9C VA: 0x18E6A9C
		public void StopFinishGaugeAnim()
		{
			TodoLogger.Log(0, "StopFinishGaugeAnim");
		}

		// // RVA: 0x18E6B84 Offset: 0x18E6B84 VA: 0x18E6B84
		// private void ChangeOldExp(int playerLevel, float gaugePercentage) { }

		// // RVA: 0x18E6D2C Offset: 0x18E6D2C VA: 0x18E6D2C
		// private void ChangeCurrentExp(int playerLevel, float gaugePercentage, int sectionExp = -1) { }

		// // RVA: 0x18E6588 Offset: 0x18E6588 VA: 0x18E6588
		// private void ChangeRequiredPlayerExp(int playerLevel) { }

		// // RVA: 0x18E6B28 Offset: 0x18E6B28 VA: 0x18E6B28
		// private float CalcExpPercentage(int playerLevel, float exp) { }

		// // RVA: 0x18E701C Offset: 0x18E701C VA: 0x18E701C
		// private float CalcExpValue(int playerLevel, float percentage) { }

		// // RVA: 0x18E6BEC Offset: 0x18E6BEC VA: 0x18E6BEC
		// private int CalcGaugeFrame(int playerLevel, float gaugePercentage) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C9F4 Offset: 0x71C9F4 VA: 0x71C9F4
		// // RVA: 0x18E7078 Offset: 0x18E7078 VA: 0x18E7078
		// private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip = True) { }

		// // RVA: 0x18E7158 Offset: 0x18E7158 VA: 0x18E7158
		// private void PlaySound(int cueId, bool enableSkip = True) { }

		// // RVA: 0x18E71C4 Offset: 0x18E71C4 VA: 0x18E71C4
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x18E7224 Offset: 0x18E7224 VA: 0x18E7224
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x18E68A0 Offset: 0x18E68A0 VA: 0x18E68A0
		// private void PlayLevelUpSE() { }

		// // RVA: 0x18E6F0C Offset: 0x18E6F0C VA: 0x18E6F0C
		// private bool IsLevelMax(int level) { }

		// [CompilerGeneratedAttribute] // RVA: 0x71CA6C Offset: 0x71CA6C VA: 0x71CA6C
		// // RVA: 0x18E7354 Offset: 0x18E7354 VA: 0x18E7354
		// private void <Co_ShowRankupPopup>b__40_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71CA7C Offset: 0x71CA7C VA: 0x71CA7C
		// // RVA: 0x18E7360 Offset: 0x18E7360 VA: 0x18E7360
		// private bool <Co_ShowRankupPopup>b__40_1() { }
	}
}
