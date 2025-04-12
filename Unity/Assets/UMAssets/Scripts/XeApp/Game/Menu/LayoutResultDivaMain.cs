using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CriWare;
using mcrs;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
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
		private GNIFOHMFDMO_DivaResultData viewResultDivaData; // 0x18
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
		public bool IsLevelupPopupProcess { get { return isLevelupPopupProcess; } private set { isLevelupPopupProcess = value; } } //0x1883F34 0x1883F3C

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
		public void PreloadDivaIcon(GNIFOHMFDMO_DivaResultData viewResultDivaData)
		{
			for(int i = 0; i < 3; i++)
			{
				int divaId = 0;
				int colorId = 0;
				int costumeId = 0;
				if(viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId >= 1)
				{
					FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId - 1];
					costumeId = diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
					colorId = diva.EKFONBFDAAP_ColorId;
					divaId = diva.AHHJLDLAPAN_DivaId;
				}
				StartLoadDivaIcon(i, divaId, costumeId, colorId);
			}
		}

		// // RVA: 0x1886B10 Offset: 0x1886B10 VA: 0x1886B10
		public bool IsPreloadedDivaIcon()
		{
			for(int i = 0; i < 3; i++)
			{
				if (divaLayouts[i].imageDiva == null)
					return false;
				if (divaLayouts[i].imageDiva.texture == null)
					return false;
			}
			return true;
		}

		// // RVA: 0x1886CC0 Offset: 0x1886CC0 VA: 0x1886CC0
		public void Setup(GNIFOHMFDMO_DivaResultData viewResultDivaData)
		{
			for(int i = 0; i < numberCenterBonusArray.Length; i++)
			{
				numberCenterBonusArray[i].SetNumber(viewResultDivaData.HMHJOEMJOKE_GetCenterDivaBonus(), 0);
			}
			layoutExpBonus.StartChildrenAnimGoStop(viewResultDivaData.HGHMMDOEGEF_ExpBonus < 1 ? "02" : "01");
			numberExpBonus.SetNumber(viewResultDivaData.HGHMMDOEGEF_ExpBonus, 0);
			this.viewResultDivaData = viewResultDivaData;
			musicLevelLayout.numberExp1.SetNumber(viewResultDivaData.CBCIFACJGHI_Exp, 0);
			musicLevelLayout.numberExp2.SetNumber(viewResultDivaData.CBCIFACJGHI_Exp, 0);
			musicLevelLayout.numberExp3.SetNumber(viewResultDivaData.CBCIFACJGHI_Exp, 0);
			for(int i = 0; i < 3; i++)
			{
				if(viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId < 1)
				{
					divaLayouts[i].layoutGaugeRoot.StartChildrenAnimGoStop("st_non");
				}
				else
				{
					restAcquiredMusicLevelExp[i] = (float)viewResultDivaData.NAIHIJAJPNK_Divas[i].BKJJLJKGDJB_MusicExpDiff;
					currentDivaExp[i] = (int)viewResultDivaData.NAIHIJAJPNK_Divas[i].MECHKMMEIPP_PrevExp;
					divaLayouts[i].layoutDivaEmblem.StartChildrenAnimGoStop(viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId - 1, viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId - 1);
					SetMusicLevel(i, viewResultDivaData.NAIHIJAJPNK_Divas[i].IIHHAFPPFCP_PrevMusicLevel);
					ChangeCurrentMusicLevelExp(i, viewResultDivaData.NAIHIJAJPNK_Divas[i].IIHHAFPPFCP_PrevMusicLevel, CalcMusicLevelExpSectionPercentage(viewResultDivaData.NAIHIJAJPNK_Divas[i].IIHHAFPPFCP_PrevMusicLevel, ToSectionMusicLevelExp(viewResultDivaData.NAIHIJAJPNK_Divas[i].IIHHAFPPFCP_PrevMusicLevel, (float)viewResultDivaData.NAIHIJAJPNK_Divas[i].NMHNDLHJENB_PrevMusicExp)));
					SetDivaLevelNumber(i, viewResultDivaData.NAIHIJAJPNK_Divas[i].AJCEIPJDMEC_PrevDivaLevel);
					SetDivaLevelNecessaryExp(i, viewResultDivaData.NAIHIJAJPNK_Divas[i].AJCEIPJDMEC_PrevDivaLevel);
					ChangeCurrentDivaLevelExp(i, viewResultDivaData.NAIHIJAJPNK_Divas[i].AJCEIPJDMEC_PrevDivaLevel, CalcDivaLevelExpSectionPercentage(viewResultDivaData.NAIHIJAJPNK_Divas[i].AJCEIPJDMEC_PrevDivaLevel, ToSectionDivaLevelExp(viewResultDivaData.NAIHIJAJPNK_Divas[i].AJCEIPJDMEC_PrevDivaLevel, (float)viewResultDivaData.NAIHIJAJPNK_Divas[i].NFJFBOBJONF_PrevExpFrag)));
					divaLayouts[i].numberMusicLevelBonus.SetNumber(viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp, 0);
					JJOELIOGMKK_DivaIntimacyInfo intimacy = new JJOELIOGMKK_DivaIntimacyInfo();
					intimacy.KHEKNNFCAOI(viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId);
					for(int j = 0; j < divaLayouts[i].numberIntimacy.Length; j++)
					{
						divaLayouts[i].numberIntimacy[j].SetNumber(intimacy.HBODCMLFDOB.IGNABALECPK);
					}
					if (i == 0 && intimacy.HBODCMLFDOB.IGNABALECPK > 0)
						IsCenterIntimacyBonus = true;
				}
			}
			musicLevelLayout.layoutRoot.StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0x1887F10 Offset: 0x1887F10 VA: 0x1887F10
		public void SetGoDivaLayout()
		{
			goDivaDisableLayoutRoot.StartSiblingAnimGoStop("02");
		}

		// // RVA: 0x1887F8C Offset: 0x1887F8C VA: 0x1887F8C
		public void StartBeginAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_StartPlayingAnim());
		}

		// // RVA: 0x18880B8 Offset: 0x18880B8 VA: 0x18880B8
		public void StartExpAnim()
		{
			if (isSkiped)
				return;
			ExpAnimCoroutine = this.StartCoroutineWatched(Co_StartMusicLevelPlayingAnim());
		}

		// // RVA: 0x1888178 Offset: 0x1888178 VA: 0x1888178
		// public void StopExpAnim() { }

		// // RVA: 0x188818C Offset: 0x188818C VA: 0x188818C
		public void StartEndAnim(Action endAnimCallback)
		{
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			this.StartCoroutineWatched(Co_EndPlayingAnim(endAnimCallback));
		}

		// // RVA: 0x18882E0 Offset: 0x18882E0 VA: 0x18882E0
		public bool IsEnter()
		{
			return isEnter;
		}

		// // RVA: 0x18882E8 Offset: 0x18882E8 VA: 0x18882E8
		public void SkipBeginAnim()
		{
			if(!isFinished && !isLevelupPopupProcess)
			{
				isSkiped = true;
				StopAllCoroutines();
				countMusicExpUpSEPlayback.Stop();
				countDivaExpUpSEPlayback.Stop();
				layoutRoot.StartChildrenAnimGoStop("st_in");
				GetCenterBonusLayout().StartChildrenAnimGoStop("st_out");
				musicLevelLayout.layoutRoot.StartChildrenAnimGoStop("st_in");
				musicLevelLayout.layoutEffectRoot.StartChildrenAnimGoStop("st_out");
				for(int i = 0; i < 3; i++)
				{
					GNIFOHMFDMO_DivaResultData.IKODHMDOMMP info = viewResultDivaData.NAIHIJAJPNK_Divas[i];
					if(info.AHHJLDLAPAN_DivaId > 0)
					{
						DivaLayout dl = divaLayouts[i];
						float f = CalcMusicLevelExpSectionPercentage(info.AIMAJDEJDLM_MusicLevel, ToSectionMusicLevelExp(info.AIMAJDEJDLM_MusicLevel, (float)info.CFDGFLNIMCL_MusicExp));
						if(info.IIHHAFPPFCP_PrevMusicLevel < info.AIMAJDEJDLM_MusicLevel)
						{
							dl.isMusicLevelup = true;
						}
						SetMusicLevel(i, info.AIMAJDEJDLM_MusicLevel);
						ChangeCurrentMusicLevelExp(i, info.AIMAJDEJDLM_MusicLevel, f);
						f = CalcDivaLevelExpSectionPercentage(info.JPGEAFPDHDE_DivaLevel, ToSectionDivaLevelExp(info.JPGEAFPDHDE_DivaLevel, (int)info.DKLBOOEIKKL_ExpFrag));
						if(info.AJCEIPJDMEC_PrevDivaLevel < info.JPGEAFPDHDE_DivaLevel)
						{
							dl.isDivaLevelup = true;
						}
						SetDivaLevelNumber(i, info.JPGEAFPDHDE_DivaLevel);
						SetDivaLevelNecessaryExp(i, info.JPGEAFPDHDE_DivaLevel);
						ChangeCurrentDivaLevelExp(i, info.JPGEAFPDHDE_DivaLevel, f);
						int nextXp = expMaster.IECLHMBPEIJ_GetMusicExp(info.AIMAJDEJDLM_MusicLevel + 1);
						dl.numberMusicLevelNextExp.SetNumber(nextXp - (int)info.CFDGFLNIMCL_MusicExp, 0);
						dl.layoutMuisicLevelEffectRoot.StartChildrenAnimGoStop("st_out");
						dl.layoutDivaLevelEffect1.StartChildrenAnimGoStop("st_in");
						dl.layoutDivaLevelEffectRoot2.StartChildrenAnimGoStop("st_out");
						for(int j = 0; j < dl.layoutDivaLevelEffect3.Length; j++)
						{
							dl.layoutDivaLevelEffect3[j].StartChildrenAnimGoStop("st_in");
						}
						dl.layoutDivaLevelEffectRoot4.StartChildrenAnimGoStop("st_out");
						dl.layoutDivaExpGaugeEffect.StartChildrenAnimGoStop("st_out");
						dl.layoutMusicLevelUpBackShadow.StartChildrenAnimGoStop("st_out", "st_out");
						if(info.DACHHLHPAAB_BonusExp > 0)
						{
							dl.layoutMusicLevelBonus.StartChildrenAnimGoStop(isMusicBonuslook ? "st_out" : "st_in");
						}
						dl.layoutIntimacy.StartChildrenAnimGoStop("st_out");
					}
				}
				this.StartCoroutineWatched(Co_StartLevelupPopupProcess(onFinished));
				isFinished = true;
			}
		}

		// // RVA: 0x1888A70 Offset: 0x1888A70 VA: 0x1888A70
		public void StartGaugeFinishAnim()
		{
			GaugeAnimFinishCoroutine = this.StartCoroutineWatched(Co_GaugeFinishAnim());
		}

		// // RVA: 0x1888B24 Offset: 0x1888B24 VA: 0x1888B24
		public void StopGaugeFinishAnim()
		{
			if(GaugeAnimFinishCoroutine != null)
			{
				this.StopCoroutineWatched(GaugeAnimFinishCoroutine);
				GaugeAnimFinishCoroutine = null;
			}
			for(int i = 0; i < 3; i++)
			{
				divaLayouts[i].layoutMusicLevelOldExpGauge.StartAllAnimGoStop("st_out", "st_out");
				divaLayouts[i].layoutMusicLevelEffectIn.StartAllAnimGoStop("st_in", "st_in");
				divaLayouts[i].layoutMusicLevelEffectOut.StartAllAnimGoStop("st_out", "st_out");
				divaLayouts[i].layoutDivaOldExpGauge.StartAllAnimGoStop("st_out", "st_out");
				divaLayouts[i].layoutDivaExpGaugeEffectIn.StartAllAnimGoStop("st_in", "st_in");
				divaLayouts[i].layoutDivaExpGaugeEffectOut.StartAllAnimGoStop("st_out", "st_out");
				divaLayouts[i].layoutMusicLevelBonus.StartAllAnimGoStop("st_out", "st_out");
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717874 Offset: 0x717874 VA: 0x717874
		// // RVA: 0x1888030 Offset: 0x1888030 VA: 0x1888030
		private IEnumerator Co_StartPlayingAnim()
		{
			//0x1D8ABB0
			yield return new WaitWhile(() =>
			{
				//0x188B140
				return layoutRoot.IsPlayingChildren();
			});
			isEnter = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7178EC Offset: 0x7178EC VA: 0x7178EC
		// // RVA: 0x1888238 Offset: 0x1888238 VA: 0x1888238
		private IEnumerator Co_EndPlayingAnim(Action endCallback)
		{
			//0x188BDB8
			yield return new WaitWhile(() =>
			{
				//0x188B16C
				return layoutRoot.IsPlayingChildren();
			});
			endCallback();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717964 Offset: 0x717964 VA: 0x717964
		// // RVA: 0x18880F0 Offset: 0x18880F0 VA: 0x18880F0
		private IEnumerator Co_StartMusicLevelPlayingAnim()
		{
			//0x1D8A940
			musicLevelLayout.layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			PlayMusicLastMusicEndSE();
			yield return new WaitWhile(() =>
			{
				//0x188B198
				return musicLevelLayout.layoutRoot.IsPlayingChildren();
			});
			this.StartCoroutineWatched(Co_StartMusicLevelExpAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7179DC Offset: 0x7179DC VA: 0x7179DC
		// // RVA: 0x1888DB0 Offset: 0x1888DB0 VA: 0x1888DB0
		private IEnumerator Co_StartMusicLevelExpAnim()
		{
			//0x188EBDC
			GetCenterBonusLayout().StartChildrenAnimGoStop("go_in", "st_in");
			for (int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0)
				{
					this.StartCoroutineWatched(Co_EnterIntimacyAnim(i));
				}
			}
			yield return new WaitWhile(() =>
			{
				//0x188B1D8
				return GetCenterBonusLayout().IsPlayingChildren();
			});
			GetCenterBonusLayout().StartChildrenAnimLoop("logo_m", "loen_m");
			Stopwatch sw = new Stopwatch();
			sw.Start();
			PlayMusicExpCountUpLoopSE();
			musicLevelLayout.layoutRoot.StartChildrenAnimLoop("logo_juk1", "loen_juk1");
			musicLevelLayout.layoutEffectRoot.StartChildrenAnimGoStop("go_in", "st_in");
			musicLevelLayout.layoutEffect.StartChildrenAnimLoop("anim", "lo_anim");
			List<Coroutine> coMusicExpIncreaseList = new List<Coroutine>();
			for (int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_MusicLevelExpIncreaseAnim(i, false)));
				}
			}
			for (int i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
			coMusicExpIncreaseList.Clear();
			countMusicExpUpSEPlayback.Stop();
			coMusicExpIncreaseList = null;
			sw.Stop();
			if (sw.Elapsed.Milliseconds <= 1500)
			{
				yield return new WaitForSeconds((1500 - sw.Elapsed.Milliseconds) * 1.0f / 1000);
			}

			GetCenterBonusLayout().StartChildrenAnimGoStop("go_out", "st_out");
			for (int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0)
				{
					LeaveIntimacyAnim(i);
				}
			}
			yield return new WaitWhile(() =>
			{
				//0x188B208
				return GetCenterBonusLayout().IsPlayingChildren();
			});
			if (IsGetBonus())
			{
				yield return Co.R(Co_StartMusicLevelBonusExpAnim());
			}
			musicLevelLayout.layoutRoot.FinishAnimLoop();
			musicLevelLayout.layoutEffectRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return new WaitForSeconds(0.5f);
			PlayDivaExpCountUpLoopSE();
			List<Coroutine> coDivaExpIncreaseList = new List<Coroutine>();
			for (int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0)
				{
					coDivaExpIncreaseList.Add(this.StartCoroutineWatched(Co_DivaLevelExpIncreaseAnim(i)));
				}
			}
			for (int i = 0; i < coDivaExpIncreaseList.Count; i++)
			{
				yield return coDivaExpIncreaseList[i];
			}
			countDivaExpUpSEPlayback.Stop();
			coDivaExpIncreaseList.Clear();

			for (int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0)
				{
					//? not sure this one
					coDivaExpIncreaseList.Add(this.StartCoroutineWatched(Co_GaugeEffectAnimFinishLoopWait(divaLayouts[i].layoutDivaExpGaugeEffectIn)));
				}
			}
			for (int i = 0; i < coDivaExpIncreaseList.Count; i++)
			{
				yield return coDivaExpIncreaseList[i];
			}
			yield return new WaitForSeconds(0.5f);
			yield return this.StartCoroutineWatched(Co_StartLevelupPopupProcess(null));
			if (onFinished != null)
				onFinished();
			isFinished = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717A54 Offset: 0x717A54 VA: 0x717A54
		// // RVA: 0x1888E5C Offset: 0x1888E5C VA: 0x1888E5C
		private IEnumerator Co_StartMusicLevelBonusExpAnim()
		{
			List<Coroutine> coMusicExpIncreaseList; // 0x14
			int i; // 0x18

			//0x188E190
			coMusicExpIncreaseList = new List<Coroutine>();
			for(i = 0; i < 3; i++)
			{
				if(viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0 &&
					viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_WaitDivaExpAnim(i, "go_out", "st_out")));
				}
			}
			for(i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
			coMusicExpIncreaseList.Clear();

			for (i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0 &&
					viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_MusicLevelBonusEnterAnim(i)));
				}
			}
			for (i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
			coMusicExpIncreaseList.Clear();
			PlayMusicExpCountUpLoopSE();

			for (i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0 &&
					viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_MusicLevelBonusExpIncreaseAnim(i)));
				}
			}
			for (i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
			coMusicExpIncreaseList.Clear();

			for (i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0 &&
					viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_MusicLevelBonusLeaveAnim(i)));
				}
			}
			for (i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
			countMusicExpUpSEPlayback.Stop();
			coMusicExpIncreaseList.Clear();
			for (i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].AHHJLDLAPAN_DivaId > 0 &&
					viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
				{
					coMusicExpIncreaseList.Add(this.StartCoroutineWatched(Co_WaitDivaExpAnim(i, "go_in", "st_in")));
				}
			}
			for (i = 0; i < coMusicExpIncreaseList.Count; i++)
			{
				yield return coMusicExpIncreaseList[i];
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717ACC Offset: 0x717ACC VA: 0x717ACC
		// // RVA: 0x18889C8 Offset: 0x18889C8 VA: 0x18889C8
		private IEnumerator Co_StartLevelupPopupProcess(Action finishCb)
		{
			int divaIndex;

			//0x188DF48
			if(!isLevelupPopupProcess)
			{
				isLevelupPopupProcess = true;
				divaIndex = 0;
				for(; divaIndex < 3; divaIndex++)
				{
					if(viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].AJCEIPJDMEC_PrevDivaLevel < viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].JPGEAFPDHDE_DivaLevel)
					{
						IsLevelup = true;
						yield return this.StartCoroutineWatched(Co_ShowLevelupPopup(divaIndex));
					}
				}
				isLevelupPopupProcess = false;
				if (finishCb != null)
					finishCb();
			}
		}

		// // RVA: 0x1888980 Offset: 0x1888980 VA: 0x1888980
		private AbsoluteLayout GetCenterBonusLayout()
		{
			return layoutCenterBonus[IsCenterIntimacyBonus ? 1 : 0];
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717B44 Offset: 0x717B44 VA: 0x717B44
		// // RVA: 0x1888F28 Offset: 0x1888F28 VA: 0x1888F28
		private IEnumerator Co_EnterIntimacyAnim(int divaIndex)
		{
			//0x188BF6C
			DivaLayout dl = divaLayouts[divaIndex];
			GNIFOHMFDMO_DivaResultData.IKODHMDOMMP info = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
			JJOELIOGMKK_DivaIntimacyInfo intimacy = new JJOELIOGMKK_DivaIntimacyInfo();
			intimacy.KHEKNNFCAOI(info.AHHJLDLAPAN_DivaId);
			bool b = false;
			if(intimacy.HBODCMLFDOB.IGNABALECPK >= 1)
			{
				if (divaIndex == 0)
					layoutCenterBonusTable.StartChildrenAnimLoop(1, 1);
				dl.layoutIntimacy.StartChildrenAnimGoStop("go_in", "st_in");
				yield return new WaitWhile(() =>
				{
					//0x188B3E8
					return dl.layoutIntimacy.IsPlayingChildren();
				});
				dl.layoutIntimacy.StartChildrenAnimLoop("logo_m", "loen_m");
			}
		}

		// // RVA: 0x1888FF0 Offset: 0x1888FF0 VA: 0x1888FF0
		private void LeaveIntimacyAnim(int divaIndex)
		{
			JJOELIOGMKK_DivaIntimacyInfo intimacy = new JJOELIOGMKK_DivaIntimacyInfo();
			intimacy.KHEKNNFCAOI(viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].AHHJLDLAPAN_DivaId);
			if (intimacy.HBODCMLFDOB.IGNABALECPK < 1)
				return;
			divaLayouts[divaIndex].layoutIntimacy.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717BBC Offset: 0x717BBC VA: 0x717BBC
		// // RVA: 0x18891A0 Offset: 0x18891A0 VA: 0x18891A0
		private IEnumerator Co_MusicLevelExpIncreaseAnim(int divaIndex, bool BonusExp = false)
		{
			DivaLayout dl; // 0x1C
			float startExp; // 0x20
			float endExp; // 0x24
			int currentFrameLevel; // 0x28
			float currentTime; // 0x2C
			float timeLength; // 0x30

			//0x188D39C
			dl = divaLayouts[divaIndex];
			startExp = (float)viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].NMHNDLHJENB_PrevMusicExp;
			endExp = (float)viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].CFDGFLNIMCL_MusicExp;
			if(startExp != endExp)
			{
				if (!BonusExp)
					endExp = endExp - viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].DACHHLHPAAB_BonusExp;
				else
					startExp = endExp - viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].DACHHLHPAAB_BonusExp;
			}
			currentFrameLevel = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].IIHHAFPPFCP_PrevMusicLevel;
			timeLength = divaIndex == 0 ? 3 : 2;
			currentTime = 0;
			while (true)
			{
				currentTime += TimeWrapper.deltaTime;
				float r = XeSys.Math.Tween.EasingInOutCubic(startExp, endExp, currentTime / timeLength);
				int lvl = currentFrameLevel;
				float f = expMaster.BOLBEBNHJHG_GetMusicLevelAndExp(r, out currentFrameLevel);
				if (currentFrameLevel < lvl)
				{
					currentFrameLevel = lvl;
				}
				ChangeCurrentMusicLevelExp(divaIndex, currentFrameLevel, CalcMusicLevelExpSectionPercentage(currentFrameLevel, f));
				if (lvl < currentFrameLevel)
				{
					dl.isMusicLevelup = true;
					StartMusicLevelup(divaIndex, currentFrameLevel, !BonusExp);
				}
				KDOMGMCGHDC.HJNMIKNAMFH h = viewResultDivaData.LNHIFELKOJF_GetPrevInfo(divaIndex, currentFrameLevel);
				bool end = true;
				if (!h.HHBJAEOIGIH_IsLocked)
					end = h.NBHEBLNHOJO_IsMax;
				if (timeLength <= currentTime)
					end = true;
				if(!end)
				{
					yield return null;
				}
				else
				{
					dl.numberMusicLevelNextExp.SetNumber(expMaster.IECLHMBPEIJ_GetMusicExp(currentFrameLevel + 1) - (int)(endExp), 0);
					yield break;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717C34 Offset: 0x717C34 VA: 0x717C34
		// // RVA: 0x1889280 Offset: 0x1889280 VA: 0x1889280
		private IEnumerator Co_WaitDivaExpAnim(int divaIndex, string start, string end)
		{
			//0x1D8AD78
			DivaLayout dl = divaLayouts[divaIndex];
			if (!dl.isMusicLevelup)
				yield break;
			dl.layoutDivaLevelEffectRoot2.StartChildrenAnimGoStop(start, end);
			dl.layoutMusicLevelUpBackShadow.StartChildrenAnimGoStop(start, end);
			yield return new WaitWhile(() =>
			{
				//0x188B430
				return dl.layoutDivaLevelEffectRoot2.IsPlayingChildren() || dl.layoutMusicLevelUpBackShadow.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717CAC Offset: 0x717CAC VA: 0x717CAC
		// // RVA: 0x1889354 Offset: 0x1889354 VA: 0x1889354
		private IEnumerator Co_MusicLevelBonusEnterAnim(int divaIndex)
		{
			//0x188CC8C
			DivaLayout dl = divaLayouts[divaIndex];
			dl.layoutMusicLevelBonus.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play(28);
			isMusicBonuslook = true;
			yield return new WaitWhile(() =>
			{
				//0x188B4BC
				return dl.layoutMusicLevelBonus.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717D24 Offset: 0x717D24 VA: 0x717D24
		// // RVA: 0x188941C Offset: 0x188941C VA: 0x188941C
		private IEnumerator Co_MusicLevelBonusExpIncreaseAnim(int divaIndex)
		{
			//0x188CF54
			yield return this.StartCoroutineWatched(Co_MusicLevelExpIncreaseAnim(divaIndex, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717D9C Offset: 0x717D9C VA: 0x717D9C
		// // RVA: 0x18894E4 Offset: 0x18894E4 VA: 0x18894E4
		private IEnumerator Co_MusicLevelBonusLeaveAnim(int divaIndex)
		{
			//0x188D124
			DivaLayout dl = divaLayouts[divaIndex];
			dl.layoutMusicLevelBonus.StartChildrenAnimGoStop("go_out", "st_out");
			yield return new WaitWhile(() =>
			{
				//0x188B504
				return dl.layoutMusicLevelBonus.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717E14 Offset: 0x717E14 VA: 0x717E14
		// // RVA: 0x1888A98 Offset: 0x1888A98 VA: 0x1888A98
		private IEnumerator Co_GaugeFinishAnim()
		{
			int frame;

			//0x188C7B8
			frame = 0;
			while(true)
			{
				if (!PopupWindowManager.IsOpenPopupWindow())
				{
					frame++;
				}
				if (frame < 45)
					yield return null;
				else
					break;
			}
			for(int i = 0; i < 3; i++)
			{
				divaLayouts[i].layoutMusicLevelOldExpGauge.StartAllAnimGoStop("go_out", "st_out");
				divaLayouts[i].layoutMusicLevelEffectIn.StartAllAnimGoStop("go_in", "st_in");
				divaLayouts[i].layoutMusicLevelEffectOut.StartAllAnimGoStop("go_out", "st_out");
				if(divaLayouts[i].isMusicLevelup)
				{
					divaLayouts[i].layoutDivaOldExpGauge.StartAllAnimGoStop("go_out", "st_out");
					divaLayouts[i].layoutDivaExpGaugeEffectIn.StartAllAnimGoStop("go_in", "st_in");
					divaLayouts[i].layoutDivaExpGaugeEffectOut.StartAllAnimGoStop("go_out", "st_out");
				}
				if(viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0 && !isMusicBonuslook)
				{
					divaLayouts[i].layoutMusicLevelBonus.StartChildrenAnimGoStop("go_out", "st_out");
				}
			}
		}

		// // RVA: 0x18895CC Offset: 0x18895CC VA: 0x18895CC
		private void StartMusicLevelup(int divaIndex, int nextMusicLevel, bool isShow)
		{
			SetMusicLevel(divaIndex, nextMusicLevel);
			divaLayouts[divaIndex].numberMusicLevelUpDivaExp.SetNumber(expMaster.DAFDPHFHANB(nextMusicLevel), 0);
			divaLayouts[divaIndex].layoutMusicLevelOldExpGauge.StartAnimGoStop(0, 0);
			divaLayouts[divaIndex].layoutMusicLevelEffectOut.StartAnimGoStop(0, 0);
			if(isShow)
			{
				divaLayouts[divaIndex].layoutDivaLevelEffect1.StartChildrenAnimGoStop("go_in", "st_in");
				divaLayouts[divaIndex].layoutDivaLevelEffectRoot2.StartChildrenAnimGoStop("go_in", "st_in");
				divaLayouts[divaIndex].layoutMusicLevelUpBackShadow.StartChildrenAnimGoStop("go_in", "st_in");
			}
			PlayMusicExpLevelUpSE();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717E8C Offset: 0x717E8C VA: 0x717E8C
		// // RVA: 0x1889894 Offset: 0x1889894 VA: 0x1889894
		private IEnumerator Co_DivaLevelExpIncreaseAnim(int divaIndex)
		{
			DivaLayout dl; // 0x18
			float startExp; // 0x1C
			float endExp; // 0x20
			int currentFrameLevel; // 0x24
			Coroutine coGuideAnim; // 0x28
			float currentTime; // 0x2C
			float timeLength; // 0x30

			//0x188B6F0
			dl = divaLayouts[divaIndex];
			if (viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].KNCMFPIODKJ_ExpFragDiff == 0)
				yield break;
			startExp = (float)viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].NFJFBOBJONF_PrevExpFrag;
			endExp = (float)viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].DKLBOOEIKKL_ExpFrag;
			currentFrameLevel = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex].AJCEIPJDMEC_PrevDivaLevel;

			dl.layoutDivaLevelEffectRoot2.StartChildrenAnimGoStop("go_fix", "st_fix");
			dl.layoutMusicLevelUpBackShadow.StartChildrenAnimGoStop("go_out", "st_out");
			dl.layoutDivaLevelEffectRoot4.StartChildrenAnimGoStop("go_in", "st_in");
			dl.layoutDivaLevelEffect4.StartChildrenAnimLoop("anim", "lo_anim");
			coGuideAnim = this.StartCoroutineWatched(Co_PlayDivaIncreaseGuideAnim(divaIndex));
			dl.layoutDivaExpGaugeEffect.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_GaugeEffectAnimStartWait(dl.layoutDivaExpGaugeEffect));

			currentTime = 0;
			timeLength = 2;

			while(true)
			{
				currentTime += TimeWrapper.deltaTime;
				int level = currentFrameLevel;
				float r = XeSys.Math.Tween.EasingInOutCubic(startExp, endExp, currentTime / timeLength);
				float v = expMaster.OLJFPKPHCJD_GetDivaExpAndLevel(r, out currentFrameLevel);
				ChangeCurrentDivaLevelExp(divaIndex, currentFrameLevel, CalcDivaLevelExpSectionPercentage(currentFrameLevel, v));
				if(level < currentFrameLevel)
				{
					dl.isDivaLevelup = true;
					StartDivaLevelup(divaIndex, currentFrameLevel);
				}
				if(coGuideAnim != null && timeLength - 1 <= currentTime)
				{
					dl.layoutDivaLevelEffectRoot2.StartChildrenAnimGoStop("go_out", "st_out");
					this.StopCoroutineWatched(coGuideAnim);
				}
				if(timeLength <= currentTime)
				{
					break;
				}
				else
				{
					yield return null;
				}
			}
			dl.layoutDivaLevelEffectRoot4.StartChildrenAnimGoStop("go_out", "st_out");
			dl.layoutDivaExpGaugeEffect.FinishAnimLoop();
			this.StartCoroutineWatched(Co_GaugeEffectAnimFinishLoopWait(dl.layoutDivaExpGaugeEffect));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717F04 Offset: 0x717F04 VA: 0x717F04
		// // RVA: 0x188995C Offset: 0x188995C VA: 0x188995C
		private IEnumerator Co_PlayDivaIncreaseGuideAnim(int divaIndex)
		{
			DivaLayout dl; // 0x18
			int currentIndex; // 0x1C

			//0x188D854
			dl = divaLayouts[divaIndex];
			currentIndex = 0;
			dl.layoutDivaLevelEffect3[0].StartChildrenAnimGoStop("go_in", "st_in");
			while(true)
			{
				if(dl.layoutDivaLevelEffect3[currentIndex].GetView(0).FrameAnimation.FrameCount >= 15 && dl.layoutDivaLevelEffect3[currentIndex].GetView(0).FrameAnimation.FrameCount < 21)
				{
					currentIndex = (currentIndex + 1) % dl.layoutDivaLevelEffect3.Length;
					dl.layoutDivaLevelEffect3[currentIndex].StartChildrenAnimGoStop("go_in", "st_in");
				}
				yield return null;
			}
		}

		// // RVA: 0x1889A24 Offset: 0x1889A24 VA: 0x1889A24
		private void StartDivaLevelup(int divaIndex, int nextDivaLevel)
		{
			DivaLayout dl = divaLayouts[divaIndex];
			GNIFOHMFDMO_DivaResultData.IKODHMDOMMP info = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
			SetDivaLevelNumber(divaIndex, nextDivaLevel);
			SetDivaLevelNecessaryExp(divaIndex, nextDivaLevel);
			dl.layoutDivaLevelUp.StartChildrenAnimGoStop("go_in", "st_in");
			dl.layoutDivaOldExpGauge.StartAnimGoStop(0, 0);
			dl.layoutDivaExpGaugeEffectOut.StartAnimGoStop(0, 0);
			PlayDivaExpLevelUpSE();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717F7C Offset: 0x717F7C VA: 0x717F7C
		// // RVA: 0x1889C10 Offset: 0x1889C10 VA: 0x1889C10
		private IEnumerator Co_ShowLevelupPopup(int divaIndex)
		{
			//0x188DBEC
			ShowLevelupPopup(divaIndex);
			yield return new WaitUntil(() =>
			{
				//0x188B2B4
				return PopupWindowManager.IsActivePopupWindow();
			});
			yield return new WaitWhile(() =>
			{
				//0x188B330
				return PopupWindowManager.IsActivePopupWindow();
			});
		}

		// // RVA: 0x1889CD8 Offset: 0x1889CD8 VA: 0x1889CD8
		private void ShowLevelupPopup(int divaIndex)
		{
			GNIFOHMFDMO_DivaResultData.IKODHMDOMMP info = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
			FFHPBEPOMAK_DivaInfo prev = new FFHPBEPOMAK_DivaInfo();
			FFHPBEPOMAK_DivaInfo next = new FFHPBEPOMAK_DivaInfo();
			prev.KHEKNNFCAOI(info.AHHJLDLAPAN_DivaId, info.AJCEIPJDMEC_PrevDivaLevel, 0, 0, null, null, true);
			next.KHEKNNFCAOI(info.AHHJLDLAPAN_DivaId, info.JPGEAFPDHDE_DivaLevel, 0, 0, null, null, true);
			PopupDivaLevelupSetting setting = new PopupDivaLevelupSetting();
			setting.TitleText = "";
			setting.IsCaption = false;
			setting.WindowSize = SizeType.Middle;
			setting.beforeDivaData = prev;
			setting.afterDivaData = next;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Type = PopupButton.ButtonType.Positive, Label = PopupButton.ButtonLabel.Ok }
			};
			PopupWindowManager.Show(setting, null, null, null, null);
		}

		// // RVA: 0x188A068 Offset: 0x188A068 VA: 0x188A068
		private bool IsGetBonus()
		{
			for(int i = 0; i < 3; i++)
			{
				if (viewResultDivaData.NAIHIJAJPNK_Divas[i].DACHHLHPAAB_BonusExp > 0)
					return true;
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717FF4 Offset: 0x717FF4 VA: 0x717FF4
		// // RVA: 0x188A134 Offset: 0x188A134 VA: 0x188A134
		private IEnumerator Co_GaugeEffectAnimStartWait(AbsoluteLayout layoutGaugeEffect)
		{
			//0x188C594
			yield return new WaitWhile(() =>
			{
				//0x188B54C
				return layoutGaugeEffect.IsPlayingChildren();
			});
			layoutGaugeEffect.StartChildrenAnimLoop("logo_addition", "loen_addition");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71806C Offset: 0x71806C VA: 0x71806C
		// // RVA: 0x188A1E0 Offset: 0x188A1E0 VA: 0x188A1E0
		private IEnumerator Co_GaugeEffectAnimFinishLoopWait(AbsoluteLayout layoutGaugeEffect)
		{
			//0x188C370
			yield return new WaitWhile(() =>
			{
				//0x188B580
				return layoutGaugeEffect.IsPlayingChildren();
			});
			layoutGaugeEffect.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1886998 Offset: 0x1886998 VA: 0x1886998
		private void StartLoadDivaIcon(int divaIndex, int divaId, int costumeId, int colorId)
		{
			MenuScene.Instance.DivaIconCache.LoadPortraitIcon(divaId, costumeId, colorId, (IiconTexture iconTexture) =>
			{
				//0x188B5AC
				iconTexture.Set(divaLayouts[divaIndex].imageDiva);
			});
		}

		// // RVA: 0x1887418 Offset: 0x1887418 VA: 0x1887418
		private void SetMusicLevel(int divaIndex, int musicLevel)
		{
			divaLayouts[divaIndex].numberMusicLevel.SetNumber(musicLevel, 0);
		}

		// // RVA: 0x188A294 Offset: 0x188A294 VA: 0x188A294
		private void SetMusicLevelNextExp(int divaIndex, int musicCurrentLevel, int musicCurrentTotalExp)
		{
			divaLayouts[divaIndex].numberMusicLevelNextExp.SetNumber(expMaster.IECLHMBPEIJ_GetMusicExp(musicCurrentLevel + 1) - musicCurrentTotalExp, 0);
		}

		// // RVA: 0x18879A4 Offset: 0x18879A4 VA: 0x18879A4
		private void SetDivaLevelNumber(int divaIndex, int divaLevel)
		{
			for(int i = 0; i < divaLayouts[divaIndex].numberDivaLevel.Length; i++)
			{
				divaLayouts[divaIndex].numberDivaLevel[i].SetNumber(divaLevel, 0);
			}
		}

		// // RVA: 0x188A354 Offset: 0x188A354 VA: 0x188A354
		private void SetDivaLevelCurrentExp(int divaIndex, int divaCurrentLevel, int divaTotalExp)
		{
			divaLayouts[divaIndex].numberDivaExpCurrent.SetNumber(divaTotalExp - expMaster.NHEBLEFJNDO_GetDivaExp(divaCurrentLevel), 0);
		}

		// // RVA: 0x1887ADC Offset: 0x1887ADC VA: 0x1887ADC
		private void SetDivaLevelNecessaryExp(int divaIndex, int divaCurrentLevel)
		{
			divaLayouts[divaIndex].numberDivaExpNecessary.SetNumber(expMaster.PHGMKDILOGE_GetDivaLevelExp(divaCurrentLevel + 1), 0);
		}

		// // RVA: 0x188A414 Offset: 0x188A414 VA: 0x188A414
		private void SetMusicLevelGaugeType(int divaIndex, int musicLevel)
		{
			KDOMGMCGHDC.HJNMIKNAMFH prevInfo = viewResultDivaData.LNHIFELKOJF_GetPrevInfo(divaIndex, musicLevel);
			if(!prevInfo.HHBJAEOIGIH_IsLocked)
			{
				divaLayouts[divaIndex].layoutGaugeRoot.StartChildrenAnimGoStop(!prevInfo.NBHEBLNHOJO_IsMax ? "st_wait" : "st_max");
			}
			else
			{
				divaLayouts[divaIndex].layoutGaugeRoot.StartChildrenAnimGoStop("st_lock");
			}
		}

		// // RVA: 0x188A578 Offset: 0x188A578 VA: 0x188A578
		private void ChangeOldMusicLevelExp(int divaIndex, int musicLevel, float gaugePercentage)
		{
			KDOMGMCGHDC.HJNMIKNAMFH prevInfo = viewResultDivaData.LNHIFELKOJF_GetPrevInfo(divaIndex, musicLevel);
			if (prevInfo.HHBJAEOIGIH_IsLocked || prevInfo.NBHEBLNHOJO_IsMax)
				gaugePercentage = 100;
			float f = Mathf.Clamp(gaugePercentage, 0, 100);
			int frameNum = divaLayouts[divaIndex].layoutMusicLevelExpGauge.GetView(0).FrameAnimation.FrameNum;
			int frame = (int)(f * (frameNum + 1) / 100);
			divaLayouts[divaIndex].layoutMusicLevelOldExpGauge.StartAnimGoStop(frame, frame);
			divaLayouts[divaIndex].layoutMusicLevelEffectOut.StartAnimGoStop(frame, frame);
		}

		// // RVA: 0x18874A4 Offset: 0x18874A4 VA: 0x18874A4
		private void ChangeCurrentMusicLevelExp(int divaIndex, int musicLevel, float gaugePercentage)
		{
			KDOMGMCGHDC.HJNMIKNAMFH prevInfo = viewResultDivaData.LNHIFELKOJF_GetPrevInfo(divaIndex, musicLevel);
			if (prevInfo.HHBJAEOIGIH_IsLocked || prevInfo.NBHEBLNHOJO_IsMax)
				gaugePercentage = 100;
			float f = Mathf.Clamp(gaugePercentage, 0, 100);
			int frameNum = divaLayouts[divaIndex].layoutMusicLevelExpGauge.GetView(0).FrameAnimation.FrameNum;
			int frame = (int)(f * (frameNum + 1) / 100);
			divaLayouts[divaIndex].layoutMusicLevelExpGauge.StartChildrenAnimGoStop(frame, frame);
			if(!prevInfo.HHBJAEOIGIH_IsLocked)
			{
				if(!prevInfo.NBHEBLNHOJO_IsMax)
				{
					if (!divaLayouts[divaIndex].isMusicLevelup)
					{
						GNIFOHMFDMO_DivaResultData.IKODHMDOMMP resInfo = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
						restAcquiredMusicLevelExp[divaIndex] = (float)resInfo.BKJJLJKGDJB_MusicExpDiff;
						currentDivaExp[divaIndex] = (int)resInfo.MECHKMMEIPP_PrevExp;
						ChangeOldMusicLevelExp(divaIndex, resInfo.IIHHAFPPFCP_PrevMusicLevel, CalcMusicLevelExpSectionPercentage(resInfo.IIHHAFPPFCP_PrevMusicLevel, ToSectionMusicLevelExp(resInfo.IIHHAFPPFCP_PrevMusicLevel, (float)resInfo.NMHNDLHJENB_PrevMusicExp)));
					}
					else
					{
						divaLayouts[divaIndex].layoutMusicLevelOldExpGauge.StartAnimGoStop(0, 0);
						divaLayouts[divaIndex].layoutMusicLevelEffectOut.StartAnimGoStop(0, 0);
					}
				}
				if(!prevInfo.HHBJAEOIGIH_IsLocked && !prevInfo.NBHEBLNHOJO_IsMax)
				{
					SetMusicLevelNextExp(divaIndex, musicLevel, (int)(f * expMaster.CMENIBIIKPJ_GetMusicLevelExp(musicLevel + 1) / 100 + expMaster.IECLHMBPEIJ_GetMusicExp(musicLevel)));
				}
			}
			SetMusicLevelGaugeType(divaIndex, musicLevel);
		}

		// // RVA: 0x188A7A0 Offset: 0x188A7A0 VA: 0x188A7A0
		private void ChangeOldDivaLevelExp(int divaIndex, int divaLevel, float gaugePercentage)
		{
			float f = Mathf.Clamp(gaugePercentage, 0, 100);
			int frame = divaLayouts[divaIndex].layoutDivaExpGauge.GetView(0).FrameAnimation.FrameNum;
			int idx = (int)(f * (frame + 1) / 100);
			divaLayouts[divaIndex].layoutDivaOldExpGauge.StartAnimGoStop(idx, idx);
			divaLayouts[divaIndex].layoutDivaExpGaugeEffectOut.StartAnimGoStop(idx, idx);
		}

		// // RVA: 0x1887B94 Offset: 0x1887B94 VA: 0x1887B94
		private void ChangeCurrentDivaLevelExp(int divaIndex, int divaLevel, float gaugePercentage)
		{
			float f = Mathf.Clamp(gaugePercentage, 0, 100);
			int frame = divaLayouts[divaIndex].layoutDivaExpGauge.GetView(0).FrameAnimation.FrameNum;
			int idx = (int)(f * (frame + 1) / 100.0f);
			divaLayouts[divaIndex].layoutDivaExpGauge.StartChildrenAnimGoStop(idx, idx);
			if(!divaLayouts[divaIndex].isDivaLevelup)
			{
				GNIFOHMFDMO_DivaResultData.IKODHMDOMMP d = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
				ChangeOldDivaLevelExp(divaIndex, d.AJCEIPJDMEC_PrevDivaLevel, CalcDivaLevelExpSectionPercentage(d.AJCEIPJDMEC_PrevDivaLevel, ToSectionDivaLevelExp(d.AJCEIPJDMEC_PrevDivaLevel, (float)d.NFJFBOBJONF_PrevExpFrag)));
			}
			else
			{
				divaLayouts[divaIndex].layoutDivaOldExpGauge.StartAnimGoStop(0, 0);
				divaLayouts[divaIndex].layoutDivaExpGaugeEffectOut.StartAnimGoStop(0, 0);
			}
			SetDivaLevelCurrentExp(divaIndex, divaLevel, (int)(f * expMaster.PHGMKDILOGE_GetDivaLevelExp(divaLevel + 1) / 100 + expMaster.NHEBLEFJNDO_GetDivaExp(divaLevel)));
			SetDivaLevelNecessaryExp(divaIndex, divaLevel);
		}

		// // RVA: 0x18873BC Offset: 0x18873BC VA: 0x18873BC
		private float CalcMusicLevelExpSectionPercentage(int musicLevel, float musicSectionExp)
		{
			return musicSectionExp / expMaster.CMENIBIIKPJ_GetMusicLevelExp(musicLevel + 1) * 100;
		}

		// // RVA: 0x1887938 Offset: 0x1887938 VA: 0x1887938
		private float CalcDivaLevelExpSectionPercentage(int divaLevel, float divaSectionExp)
		{
			int a = expMaster.PHGMKDILOGE_GetDivaLevelExp(divaLevel + 1);
			return a == 0 ? 0 : divaSectionExp / a * 100;
		}

		// // RVA: 0x188736C Offset: 0x188736C VA: 0x188736C
		private float ToSectionMusicLevelExp(int musicLevel, float musicTotalExp)
		{
			return musicTotalExp - expMaster.IECLHMBPEIJ_GetMusicExp(musicLevel);
		}

		// // RVA: 0x18878E8 Offset: 0x18878E8 VA: 0x18878E8
		private float ToSectionDivaLevelExp(int divaLevel, float divaTotalExp)
		{
			return divaTotalExp - expMaster.NHEBLEFJNDO_GetDivaExp(divaLevel);
		}

		// // RVA: 0x188A968 Offset: 0x188A968 VA: 0x188A968
		private void PlayMusicLastMusicEndSE()
		{
			SoundManager.Instance.sePlayerResult.Play(28);
		}

		// // RVA: 0x188A9C0 Offset: 0x188A9C0 VA: 0x188A9C0
		private void PlayMusicExpCountUpLoopSE()
		{
			countMusicExpUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(6);
		}

		// // RVA: 0x1888968 Offset: 0x1888968 VA: 0x1888968
		// private void StopMusicExpCountUpLoopSE() { }

		// // RVA: 0x188983C Offset: 0x188983C VA: 0x188983C
		private void PlayMusicExpLevelUpSE()
		{
			SoundManager.Instance.sePlayerResult.Play(13);
		}

		// // RVA: 0x188AA20 Offset: 0x188AA20 VA: 0x188AA20
		private void PlayDivaExpCountUpLoopSE()
		{
			countDivaExpUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(14);
		}

		// // RVA: 0x1888974 Offset: 0x1888974 VA: 0x1888974
		// private void StopDivaExpCountUpLoopSE() { }

		// // RVA: 0x1889BB8 Offset: 0x1889BB8 VA: 0x1889BB8
		private void PlayDivaExpLevelUpSE()
		{
			SoundManager.Instance.sePlayerResult.Play(15);
		}

		// // RVA: 0x188AA80 Offset: 0x188AA80 VA: 0x188AA80
		private void OnClickLockButton(int divaIndex)
		{
			if(isFinished)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				GNIFOHMFDMO_DivaResultData.IKODHMDOMMP d = viewResultDivaData.NAIHIJAJPNK_Divas[divaIndex];
				DFKGGBMFFGB_PlayerInfo p = new DFKGGBMFFGB_PlayerInfo();
				p.KHEKNNFCAOI_Init(null, false);
				FFHPBEPOMAK_DivaInfo f = p.NBIGLBMHEDC_Divas[d.AHHJLDLAPAN_DivaId - 1];
				f.KHEKNNFCAOI(d.AHHJLDLAPAN_DivaId, d.JPGEAFPDHDE_DivaLevel, 0, 0, null, null, false);
				List<int> l = f.PKLPGBKKFOL_DivaLevels;
				KDOMGMCGHDC.HJNMIKNAMFH k = KDOMGMCGHDC.ODIAFJCPIFO(viewResultDivaData.DLAEJOBELBH_MusicId, f.AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l[viewResultDivaData.DLAEJOBELBH_MusicId - 1]);
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("growth_popup_title_01"), SizeType.Small, k.ONIAMNAJLKI_LockMessage, new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x188B3AC
					return;
				}, null, null, null);
			}
		}
	}
}
