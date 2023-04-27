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
		private BPOJMOOIIFI_PlayerLevelData viewLevelupData; // 0x18
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
		public void Setup(BPOJMOOIIFI_PlayerLevelData viewPlayerLevelupData)
		{
			viewLevelupData = viewPlayerLevelupData;
			if(viewPlayerLevelupData.OJBGOOBBMFP > 0)
			{
				layoutExpBonus.StartChildrenAnimGoStop("01");
				numberExpBonus.SetNumber(viewPlayerLevelupData.OJBGOOBBMFP, 0);
			}
			else
			{
				layoutExpBonus.StartChildrenAnimGoStop("02");
			}
		}

		// // RVA: 0x18E62AC Offset: 0x18E62AC VA: 0x18E62AC
		public void SkipAnim()
		{
			m_isSkiped = true;
		}

		// // RVA: 0x18E62B8 Offset: 0x18E62B8 VA: 0x18E62B8
		public void StartAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_StartAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C79C Offset: 0x71C79C VA: 0x71C79C
		// // RVA: 0x18E62E0 Offset: 0x18E62E0 VA: 0x18E62E0
		private IEnumerator Co_StartAnim()
		{
			//0x18E8424
			if(IsLevelMax(viewLevelupData.APIIHFJGEAO_Level))
			{
				m_isSkiped = true;
				if (onFinished != null)
					onFinished();
			}
			else
			{
				int restAcquiredExp = viewLevelupData.FDNEEPFGPLH_GainExp;
				currentGaugePercentage = CalcExpPercentage(viewLevelupData.APIIHFJGEAO_Level, viewLevelupData.ALBCEALLGJG_PrevExp);
				ChangePlayerLevel(viewLevelupData.APIIHFJGEAO_Level);
				ChangeCurrentExp(viewLevelupData.APIIHFJGEAO_Level, currentGaugePercentage, viewLevelupData.ALBCEALLGJG_PrevExp);
				ChangeRequiredPlayerExp(viewLevelupData.APIIHFJGEAO_Level);
				layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
				yield return Co.R(Co_WaitAnim(layoutRoot, true));
				yield return Co.R(Co_ExpIncreaseAnim());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C814 Offset: 0x71C814 VA: 0x71C814
		// // RVA: 0x18E638C Offset: 0x18E638C VA: 0x18E638C
		private IEnumerator Co_ExpIncreaseAnim()
		{
			float startExp; // 0x14
			float endExp; // 0x18
			int currentFrameLevel; // 0x1C
			float currentTime; // 0x20
			float timeLength; // 0x24
			float sectionExp; // 0x28
			float gaugePercentage; // 0x2C

			//0x18E75E8
			PlayCountUpLoopSE();
			startExp = viewLevelupData.ALBCEALLGJG_PrevExp + expMaster.DGPJNADIFNE_GetExpUpToPlayerLevel(viewLevelupData.APIIHFJGEAO_Level);
			endExp = startExp + viewLevelupData.FDNEEPFGPLH_GainExp;
			currentFrameLevel = viewLevelupData.APIIHFJGEAO_Level;
			currentTime = 0;
			timeLength = 3;
			while(true)
			{
				int oldFrameLevel = currentFrameLevel;
				currentTime += TimeWrapper.deltaTime;
				float f = XeSys.Math.Tween.EasingInOutCubic(startExp, endExp, currentTime / timeLength);
				sectionExp = expMaster.ANADOECHNEO_GetLevelAndExp(f, out currentFrameLevel);
				gaugePercentage = CalcExpPercentage(currentFrameLevel, sectionExp);
				ChangeCurrentExp(currentFrameLevel, gaugePercentage, -1);
				if(oldFrameLevel < currentFrameLevel)
				{
					isLevelupFirst = true;
					if (IsLevelMax(currentFrameLevel))
					{
						yield return Co.R(Co_LevelMaxProcess(currentFrameLevel));
					}
					else
					{
						StartLevelupAnimation(currentFrameLevel);
						ChangeRequiredPlayerExp(currentFrameLevel);
					}
					//LAB_018e78b4
					layoutOldExpGauge.StartAnimGoStop(0, 0);
					layoutEffectOutGauge.StartAnimGoStop(0, 0);
				}
				if (IsLevelMax(currentFrameLevel) || timeLength < currentTime)
					break;
				if(!m_isSkiped)
				{
					yield return null;
				}
			}
			ChangeCurrentExp(currentFrameLevel, gaugePercentage, Mathf.RoundToInt(sectionExp));
			numberCurrentExp.SetNumber(viewLevelupData.GLAJCLEAKJJ_Exp, 0);
			countUpSEPlayback.Stop();
			if (onFinished != null)
				onFinished();
		}

		// // RVA: 0x18E6438 Offset: 0x18E6438 VA: 0x18E6438
		// private void LevelupProcess(int playerLevel) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71C88C Offset: 0x71C88C VA: 0x71C88C
		// // RVA: 0x18E6724 Offset: 0x18E6724 VA: 0x18E6724
		private IEnumerator Co_LevelMaxProcess(int playerLevel)
		{
			//0x18E7D5C
			countUpSEPlayback.Stop();
			ChangeCurrentExp(playerLevel - 1, 100, -1);
			StartLevelupAnimation(playerLevel);
			yield return null;
			yield return Co.R(Co_WaitAnim(layoutLevelUp, true));
			ChangeRequiredPlayerExp(playerLevel);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C904 Offset: 0x71C904 VA: 0x71C904
		// // RVA: 0x18E67EC Offset: 0x18E67EC VA: 0x18E67EC
		public IEnumerator Co_ShowRankupPopup()
		{
			//0x18E7F4C
			if(viewLevelupData.APIIHFJGEAO_Level < viewLevelupData.IANDPFDFAKP_Level2)
			{
				TodoLogger.Log(0, "Co_ShowRankupPopup() 1");
				yield break;
			}
		}

		// // RVA: 0x18E6898 Offset: 0x18E6898 VA: 0x18E6898
		public bool IsOpenRankupPopup()
		{
			return isOpenRankupPopup;
		}

		// // RVA: 0x18E645C Offset: 0x18E645C VA: 0x18E645C
		private void StartLevelupAnimation(int playerLevel)
		{
			PlaySound(5, true);
			ChangePlayerLevel(playerLevel);
			layoutLevelUp.StartChildrenAnimGoStop("go_in", "st_in");
			layoutLevelupLeftEffect.StartChildrenAnimGoStop("go_in", "st_in");
			layoutLevelupRightEffect.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18E69C4 Offset: 0x18E69C4 VA: 0x18E69C4
		// private void OnButtonClickedPlayerRankup(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// // RVA: 0x18E68AC Offset: 0x18E68AC VA: 0x18E68AC
		private void ChangePlayerLevel(int playerLevel)
		{
			layoutLevelupRightEffect = layoutLevelupRightEffects[playerLevel.ToString().Length - 1];
			numberPlayerLevel.SetNumber(playerLevel, 0);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C97C Offset: 0x71C97C VA: 0x71C97C
		// // RVA: 0x18E69C8 Offset: 0x18E69C8 VA: 0x18E69C8
		private IEnumerator Co_FinishGaugeAnim()
		{
			int frame;

			//0x18E7AD4
			frame = 0;
			while (frame < GAUGE_ANIM_FINISH_TIME * 30)
			{
				if (!PopupWindowManager.IsOpenPopupWindow())
					frame++;
				yield return null;
			}
			layoutAddAnimGauge.StartChildrenAnimGoStop("go_out", "st_out");
			layoutEffectOutGauge.StartChildrenAnimGoStop("go_out", "st_out");
			layoutEffectInGauge.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18E6A74 Offset: 0x18E6A74 VA: 0x18E6A74
		public void StartFinishGaugeAnim()
		{
			GaugeAnimFinishCoroutine = this.StartCoroutineWatched(Co_FinishGaugeAnim());
		}

		// // RVA: 0x18E6A9C Offset: 0x18E6A9C VA: 0x18E6A9C
		public void StopFinishGaugeAnim()
		{
			if(GaugeAnimFinishCoroutine != null)
			{
				this.StopCoroutineWatched(GaugeAnimFinishCoroutine);
				GaugeAnimFinishCoroutine = null;
			}
			ChangeOldExp(viewLevelupData.IANDPFDFAKP_Level2, CalcExpPercentage(viewLevelupData.IANDPFDFAKP_Level2, viewLevelupData.GLAJCLEAKJJ_Exp));
		}

		// // RVA: 0x18E6B84 Offset: 0x18E6B84 VA: 0x18E6B84
		private void ChangeOldExp(int playerLevel, float gaugePercentage)
		{
			int f = CalcGaugeFrame(playerLevel, gaugePercentage);
			layoutOldExpGauge.StartAnimGoStop(f, f);
			layoutEffectOutGauge.StartAnimGoStop(f, f);
		}

		// // RVA: 0x18E6D2C Offset: 0x18E6D2C VA: 0x18E6D2C
		private void ChangeCurrentExp(int playerLevel, float gaugePercentage, int sectionExp = -1)
		{
			int f = CalcGaugeFrame(playerLevel, gaugePercentage);
			layoutExpGauge.StartChildrenAnimGoStop(f, f);
			if(!IsLevelMax(playerLevel))
			{
				if(!isLevelupFirst)
				{
					ChangeOldExp(viewLevelupData.APIIHFJGEAO_Level, CalcExpPercentage(viewLevelupData.APIIHFJGEAO_Level, viewLevelupData.ALBCEALLGJG_PrevExp));
				}
				else
				{
					layoutOldExpGauge.StartAnimGoStop(0, 0);
					layoutEffectOutGauge.StartAnimGoStop(0, 0);
				}
			}
			if (IsLevelMax(playerLevel))
				return;
			if(sectionExp < 0)
			{
				sectionExp = Mathf.RoundToInt(gaugePercentage / 100.0f * expMaster.NDFGMMKGBAA_GetExpForPlayerLevel(playerLevel));
			}
			numberCurrentExp.SetNumber(sectionExp, 0);
		}

		// // RVA: 0x18E6588 Offset: 0x18E6588 VA: 0x18E6588
		private void ChangeRequiredPlayerExp(int playerLevel)
		{
			if(!IsLevelMax(playerLevel))
			{
				layoutExpType.StartChildrenAnimGoStop("st_normal");
				numberRequiredExp.SetNumber(expMaster.NDFGMMKGBAA_GetExpForPlayerLevel(playerLevel), 0);
			}
			else
			{
				layoutExpType.StartChildrenAnimGoStop("st_max");
				layoutExpGauge.StartChildrenAnimGoStop(layoutExpGauge.GetView(0).FrameAnimation.FrameNum + 1, layoutExpGauge.GetView(0).FrameAnimation.FrameNum + 1);
			}
		}

		// // RVA: 0x18E6B28 Offset: 0x18E6B28 VA: 0x18E6B28
		private float CalcExpPercentage(int playerLevel, float exp)
		{
			return exp / expMaster.NDFGMMKGBAA_GetExpForPlayerLevel(playerLevel) * 100.0f;
		}

		// // RVA: 0x18E701C Offset: 0x18E701C VA: 0x18E701C
		// private float CalcExpValue(int playerLevel, float percentage) { }

		// // RVA: 0x18E6BEC Offset: 0x18E6BEC VA: 0x18E6BEC
		private int CalcGaugeFrame(int playerLevel, float gaugePercentage)
		{
			if (IsLevelMax(playerLevel))
				gaugePercentage = 100;
			return Mathf.RoundToInt(Mathf.Clamp(gaugePercentage, 0, 100) * layoutExpGauge.GetView(0).FrameAnimation.FrameNum + 1 / 100);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71C9F4 Offset: 0x71C9F4 VA: 0x71C9F4
		// // RVA: 0x18E7078 Offset: 0x18E7078 VA: 0x18E7078
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip = true)
		{
			//0x18E8728
			while(true)
			{
				if (!layout.IsPlayingChildren())
					yield break;
				if(!m_isSkiped || (m_isSkiped && !enableSkip))
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// // RVA: 0x18E7158 Offset: 0x18E7158 VA: 0x18E7158
		private void PlaySound(int cueId, bool enableSkip = true)
		{
			if (m_isSkiped && enableSkip)
				return;
			SoundManager.Instance.sePlayerResult.Play(cueId);
		}

		// // RVA: 0x18E71C4 Offset: 0x18E71C4 VA: 0x18E71C4
		private void PlayCountUpLoopSE()
		{
			countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(4);
		}

		// // RVA: 0x18E7224 Offset: 0x18E7224 VA: 0x18E7224
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x18E68A0 Offset: 0x18E68A0 VA: 0x18E68A0
		// private void PlayLevelUpSE() { }

		// // RVA: 0x18E6F0C Offset: 0x18E6F0C VA: 0x18E6F0C
		private bool IsLevelMax(int level)
		{
			return level >= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.PIAMMJNADJH_PlayerMaxLevel;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x71CA6C Offset: 0x71CA6C VA: 0x71CA6C
		// // RVA: 0x18E7354 Offset: 0x18E7354 VA: 0x18E7354
		// private void <Co_ShowRankupPopup>b__40_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x71CA7C Offset: 0x71CA7C VA: 0x71CA7C
		// // RVA: 0x18E7360 Offset: 0x18E7360 VA: 0x18E7360
		// private bool <Co_ShowRankupPopup>b__40_1() { }
	}
}
