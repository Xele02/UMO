using System;
using CriWare;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultDivaMain : LayoutUGUIScriptBase
	{
		private class DivaLayout
		{
			public RawImageEx imageDiva; // 0x8
			public AbsoluteLayout layoutGaugeRoot; // 0xC
			public AbsoluteLayout layoutDivaEmblem; // 0x10
			public NumberBase numberMusicLevel; // 0x14
			public AbsoluteLayout layoutMuisicLevelEffectRoot; // 0x18
			public AbsoluteLayout layoutMuisicLevelEffect; // 0x1C
			public NumberBase numberMusicLevelNextExp; // 0x20
			public AbsoluteLayout layoutMusicLevelExpGauge; // 0x24
			public AbsoluteLayout layoutMusicLevelOldExpGauge; // 0x28
			public AbsoluteLayout layoutMusicLevelEffectIn; // 0x2C
			public AbsoluteLayout layoutMusicLevelEffectOut; // 0x30
			public AbsoluteLayout layoutMusicLevelBonus; // 0x34
			public AbsoluteLayout layoutDivaLevelEffect1; // 0x38
			public AbsoluteLayout layoutDivaLevelEffectRoot2; // 0x3C
			public AbsoluteLayout[] layoutDivaLevelEffect3 = new AbsoluteLayout[4]; // 0x40
			public AbsoluteLayout layoutDivaLevelEffectRoot4; // 0x44
			public AbsoluteLayout layoutDivaLevelEffect4; // 0x48
			public NumberBase numberMusicLevelUpDivaExp; // 0x4C
			public NumberBase numberMusicLevelUpDivaExpAdd; // 0x50
			public AbsoluteLayout layoutMusicLevelUpBackShadow; // 0x54
			public NumberBase[] numberDivaLevel = new NumberBase[4]; // 0x58
			public AbsoluteLayout layoutDivaExpGauge; // 0x5C
			public AbsoluteLayout layoutDivaOldExpGauge; // 0x60
			public AbsoluteLayout layoutDivaExpGaugeEffect; // 0x64
			public AbsoluteLayout layoutDivaExpGaugeEffectIn; // 0x68
			public AbsoluteLayout layoutDivaExpGaugeEffectOut; // 0x6C
			public NumberBase numberDivaExpCurrent; // 0x70
			public NumberBase numberDivaExpNecessary; // 0x74
			public AbsoluteLayout layoutDivaLevelUp; // 0x78
			public ActionButton lockButton; // 0x7C
			public bool isMusicLevelup; // 0x80
			public bool isDivaLevelup; // 0x81
			public NumberBase numberMusicLevelBonus; // 0x84
			public AbsoluteLayout layoutIntimacy; // 0x88
			public NumberBase[] numberIntimacy; // 0x8C
		}

		private class MusicLevelLayout
		{
			public AbsoluteLayout layoutRoot; // 0x8
			public AbsoluteLayout layoutEffectRoot; // 0xC
			public AbsoluteLayout layoutEffect; // 0x10
			public NumberBase numberExp1; // 0x14
			public NumberBase numberExp2; // 0x18
			public NumberBase numberExp3; // 0x1C
		}

		private JJOPEDJCCJK_Exp expMaster; // 0x14
		// private GNIFOHMFDMO viewResultDivaData; // 0x18
		private AbsoluteLayout layoutRoot; // 0x1C
		private AbsoluteLayout layoutExpBonus; // 0x20
		private NumberBase numberExpBonus; // 0x24
		private AbsoluteLayout[] layoutCenterBonus = new AbsoluteLayout[2]; // 0x28
		private AbsoluteLayout layoutCenterBonusTable; // 0x2C
		private NumberBase[] numberCenterBonusArray; // 0x30
		private MusicLevelLayout musicLevelLayout = new MusicLevelLayout(); // 0x34
		private DivaLayout[] divaLayouts = new DivaLayout[3]; // 0x38
		private float[] restAcquiredMusicLevelExp = new float[3]; // 0x3C
		private int[] currentDivaExp = new int[3]; // 0x40
		private CriAtomExPlayback countMusicExpUpSEPlayback; // 0x44
		private CriAtomExPlayback countDivaExpUpSEPlayback; // 0x48
		private bool isLevelupPopupProcess; // 0x4C
		private Coroutine ExpAnimCoroutine; // 0x50
		private bool isFinished; // 0x54
		public Action onFinished; // 0x58
		private bool isEnter; // 0x5C
		private bool isSkiped; // 0x5D
		private bool IsCenterIntimacyBonus; // 0x5F
		private bool isMusicBonuslook; // 0x60
		private Coroutine GaugeAnimFinishCoroutine; // 0x64
		private AbsoluteLayout goDivaDisableLayoutRoot; // 0x68

		public bool IsLevelup { get; private set; } // 0x5E
		// public bool IsLevelupPopupProcess { get; private set; } 0x1883F34 0x1883F3C

		// RVA: 0x1883F44 Offset: 0x1883F44 VA: 0x1883F44
		private void Awake()
		{
			expMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
		}

		// RVA: 0x1884008 Offset: 0x1884008 VA: 0x1884008
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x188405C Offset: 0x188405C VA: 0x188405C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_fr_anim (AbsoluteLayout)").Find("sw_fr_set (AbsoluteLayout)");
			layoutRoot = layout.FindViewById("sw_fr_anim") as AbsoluteLayout;
			layoutExpBonus = layout.FindViewById("sw_g_r_multi_exp_onoff") as AbsoluteLayout;
			layoutCenterBonus[0] = layoutRoot.FindViewById("g_r_multi_center") as AbsoluteLayout;
			layoutCenterBonus[1] = layoutRoot.FindViewById("g_r_multi_center_2") as AbsoluteLayout;
			Transform t2 = t.Find("sw_jukuicon_anim (AbsoluteLayout)");
			musicLevelLayout.layoutRoot = layoutRoot.FindViewById("sw_jukuicon_anim") as AbsoluteLayout;
			musicLevelLayout.layoutEffectRoot = layoutRoot.FindViewById("sw_juk1_inout") as AbsoluteLayout;
			musicLevelLayout.layoutEffect = musicLevelLayout.layoutEffectRoot.FindViewById("sw_juk1_anim") as AbsoluteLayout;
			musicLevelLayout.numberExp1 = t2.Find("swnum_juku (AbsoluteLayout)").GetComponent<NumberBase>();
			musicLevelLayout.numberExp2 = t2.Find("swnum_juku_2 (AbsoluteLayout)").GetComponent<NumberBase>();
			musicLevelLayout.numberExp3 = t2.Find("swnum_juku_3 (AbsoluteLayout)").GetComponent<NumberBase>();
			layoutCenterBonusTable = layoutRoot.FindViewById("swtbl_multi_center") as AbsoluteLayout;
			string[] strs = new string[3] { "sw_diva_set_c", "sw_diva_set_l", "sw_diva_set_r"};
			string[] strs2 = new string[3] { "sw_diva_set_c (AbsoluteLayout)", "sw_diva_set_l (AbsoluteLayout)", "sw_diva_set_r (AbsoluteLayout)"};
			string[] strs3 = new string[3] { "sw_c_multi_rapport_c", "sw_c_multi_rapport_l", "sw_c_multi_rapport_r"};
			for(int i = 0; i < 3; i++)
			{
				divaLayouts[i] = new DivaLayout();
				Transform t3 = t.Find(strs2[i]);
				Transform t4 = t3.Find("sw_diva_guage (AbsoluteLayout)");
				divaLayouts[i].imageDiva = t3.Find("swtexc_cmn_diva_m03 (ImageView)").GetComponent<RawImageEx>();
				divaLayouts[i].imageDiva.raycastTarget = false;
				divaLayouts[i].layoutGaugeRoot = (layoutRoot.FindViewById(strs[i]) as AbsoluteLayout).FindViewById("sw_diva_guage") as AbsoluteLayout;
				divaLayouts[i].layoutDivaEmblem = divaLayouts[i].layoutGaugeRoot.FindViewById("swtbl_emb") as AbsoluteLayout;
				divaLayouts[i].layoutMusicLevelExpGauge = divaLayouts[i].layoutGaugeRoot.FindViewById("swfrm_jlv") as AbsoluteLayout;
				divaLayouts[i].layoutMusicLevelOldExpGauge = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_jlv_sw_jlv_plus_out_anim") as AbsoluteLayout;
				divaLayouts[i].layoutMusicLevelEffectIn = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_jlv_sw_guage_ef_inout_anim_in") as AbsoluteLayout;
				divaLayouts[i].layoutMusicLevelEffectOut = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_jlv_sw_guage_ef_inout_anim_out") as AbsoluteLayout;
				divaLayouts[i].layoutMusicLevelBonus = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_inc_anim") as AbsoluteLayout;
				divaLayouts[i].layoutMuisicLevelEffectRoot = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_juk2_inout") as AbsoluteLayout;
				divaLayouts[i].layoutMuisicLevelEffect = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_juk2_anim") as AbsoluteLayout;
				divaLayouts[i].layoutDivaLevelEffect1 = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_exp1_anim") as AbsoluteLayout;
				divaLayouts[i].layoutDivaLevelEffectRoot2 = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_exp2_anim") as AbsoluteLayout;
				for(int j = 0; j < divaLayouts[i].layoutDivaLevelEffect3.Length; j++)
				{
					divaLayouts[i].layoutDivaLevelEffect3[j] = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_exp3_anim_"+(i + 1)) as AbsoluteLayout;
				}
				divaLayouts[i].layoutDivaLevelEffectRoot4 = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_exp4_anim_inout") as AbsoluteLayout;
				divaLayouts[i].layoutDivaLevelEffect4 = divaLayouts[i].layoutDivaLevelEffectRoot4.FindViewById("sw_exp4_anim") as AbsoluteLayout;
				divaLayouts[i].layoutDivaExpGauge = divaLayouts[i].layoutGaugeRoot.FindViewById("swfrm_dlv") as AbsoluteLayout;
				divaLayouts[i].layoutDivaOldExpGauge = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_dlv_sw_dlv_plus_out_anim") as AbsoluteLayout;
				divaLayouts[i].layoutDivaExpGaugeEffect = divaLayouts[i].layoutDivaExpGauge.FindViewById("sw_dlv_guage_ef") as AbsoluteLayout;
				divaLayouts[i].layoutDivaExpGaugeEffectIn = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_dlv_sw_guage_ef_inout_anim_in") as AbsoluteLayout;
				divaLayouts[i].layoutDivaExpGaugeEffectOut = divaLayouts[i].layoutGaugeRoot.FindViewByExId("swfrm_dlv_sw_guage_ef2_inout_anim_out") as AbsoluteLayout;
				divaLayouts[i].layoutDivaLevelUp = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_dlvup") as AbsoluteLayout;
				divaLayouts[i].numberMusicLevel = t4.Find("swnum_jlv (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].numberMusicLevelNextExp = t4.Find("swnum_jexp (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].numberMusicLevelUpDivaExp = t4.Find("sw_exp2_anim (AbsoluteLayout)/swnum_dexp_p (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].numberMusicLevelUpDivaExpAdd = t4.Find("sw_exp2_anim (AbsoluteLayout)/swnum_dexpl2_2 (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].layoutMusicLevelUpBackShadow = divaLayouts[i].layoutGaugeRoot.FindViewById("sw_gra_anim") as AbsoluteLayout;
				ActionButton[] bs = t3.GetComponentsInChildren<ActionButton>(true);
				divaLayouts[i].lockButton = bs[0];
				int divaIndex = i;
				divaLayouts[i].lockButton.AddOnClickCallback(() => {
					//0x188B3B0
					OnClickLockButton(divaIndex);
				});
				string[] strs4 = new string[4]
				{
					"swnum_dlv_num (AbsoluteLayout)", "swnum_dlv_num2 (AbsoluteLayout)",
					"swnum_dlv_num_boke (AbsoluteLayout)", "swnum_dlv_num_boke2 (AbsoluteLayout)"
				};
				for(int j = 0; j < divaLayouts[i].numberDivaLevel.Length; j++)
				{
					divaLayouts[i].numberDivaLevel[j] = t4.Find("sw_dlvup (AbsoluteLayout)/"+strs4[j]).GetComponent<NumberBase>();
				}
				divaLayouts[i].numberDivaExpCurrent = t4.Find("sw_dexp (AbsoluteLayout)/swnum_dexpl (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].numberDivaExpNecessary = t4.Find("sw_dexp (AbsoluteLayout)/swnum_dexp (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].isMusicLevelup = false;
				divaLayouts[i].isDivaLevelup = false;
				divaLayouts[i].numberMusicLevelBonus = t4.Find("sw_inc_anim (AbsoluteLayout)/swnum_juku (AbsoluteLayout)").GetComponent<NumberBase>();
				divaLayouts[i].layoutIntimacy = layout.FindViewById(strs3[i]) as AbsoluteLayout;
				divaLayouts[i].numberIntimacy = t.Find(strs3[i]+" (AbsoluteLayout)").GetComponentsInChildren<NumberBase>(true);
			}
			goDivaDisableLayoutRoot = layoutRoot.FindViewById(strs[1]) as AbsoluteLayout;
			numberCenterBonusArray = t.Find("swtbl_multi_center (AbsoluteLayout)").GetComponentsInChildren<NumberBase>(true);
			numberExpBonus = t.Find("sw_jukuicon_anim (AbsoluteLayout)").GetComponentInChildren<NumberBase>(true);
			Loaded();
			return true;
		}

		// // RVA: 0x1886720 Offset: 0x1886720 VA: 0x1886720
		// public void PreloadDivaIcon(GNIFOHMFDMO viewResultDivaData) { }

		// // RVA: 0x1886B10 Offset: 0x1886B10 VA: 0x1886B10
		// public bool IsPreloadedDivaIcon() { }

		// // RVA: 0x1886CC0 Offset: 0x1886CC0 VA: 0x1886CC0
		// public void Setup(GNIFOHMFDMO viewResultDivaData) { }

		// // RVA: 0x1887F10 Offset: 0x1887F10 VA: 0x1887F10
		// public void SetGoDivaLayout() { }

		// // RVA: 0x1887F8C Offset: 0x1887F8C VA: 0x1887F8C
		public void StartBeginAnim()
		{
			TodoLogger.Log(0, "StartBeginAnim");
			if(onFinished != null)
				onFinished();
		}

		// // RVA: 0x18880B8 Offset: 0x18880B8 VA: 0x18880B8
		// public void StartExpAnim() { }

		// // RVA: 0x1888178 Offset: 0x1888178 VA: 0x1888178
		// public void StopExpAnim() { }

		// // RVA: 0x188818C Offset: 0x188818C VA: 0x188818C
		// public void StartEndAnim(Action endAnimCallback) { }

		// // RVA: 0x18882E0 Offset: 0x18882E0 VA: 0x18882E0
		// public bool IsEnter() { }

		// // RVA: 0x18882E8 Offset: 0x18882E8 VA: 0x18882E8
		// public void SkipBeginAnim() { }

		// // RVA: 0x1888A70 Offset: 0x1888A70 VA: 0x1888A70
		public void StartGaugeFinishAnim()
		{
			TodoLogger.Log(0, "StartGaugeFinishAnim");
		}

		// // RVA: 0x1888B24 Offset: 0x1888B24 VA: 0x1888B24
		public void StopGaugeFinishAnim()
		{
			TodoLogger.Log(0, "StopGaugeFinishAnim");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717874 Offset: 0x717874 VA: 0x717874
		// // RVA: 0x1888030 Offset: 0x1888030 VA: 0x1888030
		// private IEnumerator Co_StartPlayingAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7178EC Offset: 0x7178EC VA: 0x7178EC
		// // RVA: 0x1888238 Offset: 0x1888238 VA: 0x1888238
		// private IEnumerator Co_EndPlayingAnim(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717964 Offset: 0x717964 VA: 0x717964
		// // RVA: 0x18880F0 Offset: 0x18880F0 VA: 0x18880F0
		// private IEnumerator Co_StartMusicLevelPlayingAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x7179DC Offset: 0x7179DC VA: 0x7179DC
		// // RVA: 0x1888DB0 Offset: 0x1888DB0 VA: 0x1888DB0
		// private IEnumerator Co_StartMusicLevelExpAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x717A54 Offset: 0x717A54 VA: 0x717A54
		// // RVA: 0x1888E5C Offset: 0x1888E5C VA: 0x1888E5C
		// private IEnumerator Co_StartMusicLevelBonusExpAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x717ACC Offset: 0x717ACC VA: 0x717ACC
		// // RVA: 0x18889C8 Offset: 0x18889C8 VA: 0x18889C8
		// private IEnumerator Co_StartLevelupPopupProcess(Action finishCb) { }

		// // RVA: 0x1888980 Offset: 0x1888980 VA: 0x1888980
		// private AbsoluteLayout GetCenterBonusLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x717B44 Offset: 0x717B44 VA: 0x717B44
		// // RVA: 0x1888F28 Offset: 0x1888F28 VA: 0x1888F28
		// private IEnumerator Co_EnterIntimacyAnim(int divaIndex) { }

		// // RVA: 0x1888FF0 Offset: 0x1888FF0 VA: 0x1888FF0
		// private void LeaveIntimacyAnim(int divaIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717BBC Offset: 0x717BBC VA: 0x717BBC
		// // RVA: 0x18891A0 Offset: 0x18891A0 VA: 0x18891A0
		// private IEnumerator Co_MusicLevelExpIncreaseAnim(int divaIndex, bool BonusExp = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717C34 Offset: 0x717C34 VA: 0x717C34
		// // RVA: 0x1889280 Offset: 0x1889280 VA: 0x1889280
		// private IEnumerator Co_WaitDivaExpAnim(int divaIndex, string start, string end) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717CAC Offset: 0x717CAC VA: 0x717CAC
		// // RVA: 0x1889354 Offset: 0x1889354 VA: 0x1889354
		// private IEnumerator Co_MusicLevelBonusEnterAnim(int divaIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717D24 Offset: 0x717D24 VA: 0x717D24
		// // RVA: 0x188941C Offset: 0x188941C VA: 0x188941C
		// private IEnumerator Co_MusicLevelBonusExpIncreaseAnim(int divaIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717D9C Offset: 0x717D9C VA: 0x717D9C
		// // RVA: 0x18894E4 Offset: 0x18894E4 VA: 0x18894E4
		// private IEnumerator Co_MusicLevelBonusLeaveAnim(int divaIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717E14 Offset: 0x717E14 VA: 0x717E14
		// // RVA: 0x1888A98 Offset: 0x1888A98 VA: 0x1888A98
		// private IEnumerator Co_GaugeFinishAnim() { }

		// // RVA: 0x18895CC Offset: 0x18895CC VA: 0x18895CC
		// private void StartMusicLevelup(int divaIndex, int nextMusicLevel, bool isShow) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717E8C Offset: 0x717E8C VA: 0x717E8C
		// // RVA: 0x1889894 Offset: 0x1889894 VA: 0x1889894
		// private IEnumerator Co_DivaLevelExpIncreaseAnim(int divaIndex) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717F04 Offset: 0x717F04 VA: 0x717F04
		// // RVA: 0x188995C Offset: 0x188995C VA: 0x188995C
		// private IEnumerator Co_PlayDivaIncreaseGuideAnim(int divaIndex) { }

		// // RVA: 0x1889A24 Offset: 0x1889A24 VA: 0x1889A24
		// private void StartDivaLevelup(int divaIndex, int nextDivaLevel) { }

		// [IteratorStateMachineAttribute] // RVA: 0x717F7C Offset: 0x717F7C VA: 0x717F7C
		// // RVA: 0x1889C10 Offset: 0x1889C10 VA: 0x1889C10
		// private IEnumerator Co_ShowLevelupPopup(int divaIndex) { }

		// // RVA: 0x1889CD8 Offset: 0x1889CD8 VA: 0x1889CD8
		// private void ShowLevelupPopup(int divaIndex) { }

		// // RVA: 0x188A068 Offset: 0x188A068 VA: 0x188A068
		// private bool IsGetBonus() { }

		// [IteratorStateMachineAttribute] // RVA: 0x717FF4 Offset: 0x717FF4 VA: 0x717FF4
		// // RVA: 0x188A134 Offset: 0x188A134 VA: 0x188A134
		// private IEnumerator Co_GaugeEffectAnimStartWait(AbsoluteLayout layoutGaugeEffect) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71806C Offset: 0x71806C VA: 0x71806C
		// // RVA: 0x188A1E0 Offset: 0x188A1E0 VA: 0x188A1E0
		// private IEnumerator Co_GaugeEffectAnimFinishLoopWait(AbsoluteLayout layoutGaugeEffect) { }

		// // RVA: 0x1886998 Offset: 0x1886998 VA: 0x1886998
		// private void StartLoadDivaIcon(int divaIndex, int divaId, int costumeId, int colorId) { }

		// // RVA: 0x1887418 Offset: 0x1887418 VA: 0x1887418
		// private void SetMusicLevel(int divaIndex, int musicLevel) { }

		// // RVA: 0x188A294 Offset: 0x188A294 VA: 0x188A294
		// private void SetMusicLevelNextExp(int divaIndex, int musicCurrentLevel, int musicCurrentTotalExp) { }

		// // RVA: 0x18879A4 Offset: 0x18879A4 VA: 0x18879A4
		// private void SetDivaLevelNumber(int divaIndex, int divaLevel) { }

		// // RVA: 0x188A354 Offset: 0x188A354 VA: 0x188A354
		// private void SetDivaLevelCurrentExp(int divaIndex, int divaCurrentLevel, int divaTotalExp) { }

		// // RVA: 0x1887ADC Offset: 0x1887ADC VA: 0x1887ADC
		// private void SetDivaLevelNecessaryExp(int divaIndex, int divaCurrentLevel) { }

		// // RVA: 0x188A414 Offset: 0x188A414 VA: 0x188A414
		// private void SetMusicLevelGaugeType(int divaIndex, int musicLevel) { }

		// // RVA: 0x188A578 Offset: 0x188A578 VA: 0x188A578
		// private void ChangeOldMusicLevelExp(int divaIndex, int musicLevel, float gaugePercentage) { }

		// // RVA: 0x18874A4 Offset: 0x18874A4 VA: 0x18874A4
		// private void ChangeCurrentMusicLevelExp(int divaIndex, int musicLevel, float gaugePercentage) { }

		// // RVA: 0x188A7A0 Offset: 0x188A7A0 VA: 0x188A7A0
		// private void ChangeOldDivaLevelExp(int divaIndex, int divaLevel, float gaugePercentage) { }

		// // RVA: 0x1887B94 Offset: 0x1887B94 VA: 0x1887B94
		// private void ChangeCurrentDivaLevelExp(int divaIndex, int divaLevel, float gaugePercentage) { }

		// // RVA: 0x18873BC Offset: 0x18873BC VA: 0x18873BC
		// private float CalcMusicLevelExpSectionPercentage(int musicLevel, float musicSectionExp) { }

		// // RVA: 0x1887938 Offset: 0x1887938 VA: 0x1887938
		// private float CalcDivaLevelExpSectionPercentage(int divaLevel, float divaSectionExp) { }

		// // RVA: 0x188736C Offset: 0x188736C VA: 0x188736C
		// private float ToSectionMusicLevelExp(int musicLevel, float musicTotalExp) { }

		// // RVA: 0x18878E8 Offset: 0x18878E8 VA: 0x18878E8
		// private float ToSectionDivaLevelExp(int divaLevel, float divaTotalExp) { }

		// // RVA: 0x188A968 Offset: 0x188A968 VA: 0x188A968
		// private void PlayMusicLastMusicEndSE() { }

		// // RVA: 0x188A9C0 Offset: 0x188A9C0 VA: 0x188A9C0
		// private void PlayMusicExpCountUpLoopSE() { }

		// // RVA: 0x1888968 Offset: 0x1888968 VA: 0x1888968
		// private void StopMusicExpCountUpLoopSE() { }

		// // RVA: 0x188983C Offset: 0x188983C VA: 0x188983C
		// private void PlayMusicExpLevelUpSE() { }

		// // RVA: 0x188AA20 Offset: 0x188AA20 VA: 0x188AA20
		// private void PlayDivaExpCountUpLoopSE() { }

		// // RVA: 0x1888974 Offset: 0x1888974 VA: 0x1888974
		// private void StopDivaExpCountUpLoopSE() { }

		// // RVA: 0x1889BB8 Offset: 0x1889BB8 VA: 0x1889BB8
		// private void PlayDivaExpLevelUpSE() { }

		// // RVA: 0x188AA80 Offset: 0x188AA80 VA: 0x188AA80
		private void OnClickLockButton(int divaIndex)
		{
			TodoLogger.LogNotImplemented("OnClickLockButton");
		}

		// [CompilerGeneratedAttribute] // RVA: 0x7180E4 Offset: 0x7180E4 VA: 0x7180E4
		// // RVA: 0x188B140 Offset: 0x188B140 VA: 0x188B140
		// private bool <Co_StartPlayingAnim>b__48_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7180F4 Offset: 0x7180F4 VA: 0x7180F4
		// // RVA: 0x188B16C Offset: 0x188B16C VA: 0x188B16C
		// private bool <Co_EndPlayingAnim>b__49_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x718104 Offset: 0x718104 VA: 0x718104
		// // RVA: 0x188B198 Offset: 0x188B198 VA: 0x188B198
		// private bool <Co_StartMusicLevelPlayingAnim>b__50_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x718114 Offset: 0x718114 VA: 0x718114
		// // RVA: 0x188B1D8 Offset: 0x188B1D8 VA: 0x188B1D8
		// private bool <Co_StartMusicLevelExpAnim>b__51_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x718124 Offset: 0x718124 VA: 0x718124
		// // RVA: 0x188B208 Offset: 0x188B208 VA: 0x188B208
		// private bool <Co_StartMusicLevelExpAnim>b__51_1() { }
	}
}
