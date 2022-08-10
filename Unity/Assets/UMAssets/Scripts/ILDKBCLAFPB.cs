using System;
using XeSys;
using System.IO;
using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using System.Collections.Generic;
using XeApp.Game.Menu;

public class ILDKBCLAFPB
{
    public enum EJFLCPHPMCA
    {
        MKOILBFAONG = 0,
        DKBFPPODLDF = 1,
        JIMDHEJOPBK = 2,
    }

    public class MPHNGGECENI_Option
    {
        public const int LPACNHPFCPE = 3650;
        public const int AFGDPNLDDHD = 25;
        public const int EAIDAGDMCJN = 15;
        public const int KMKPHAGFCBC = 15;
        public const int CDFANKJIPJL = 11;
        public const int OHCKGBCBOCH = 10;
        public const int GGGDLHINIIH = 4;
        public const int CIEJBCJHLOB = 10;
        public const int IJHGBPOCDIN = 1;
        public const int FPHFGEJIBLK = 6;
        public const int POBJCCIDNNF = -75;
        public const int BMHABNAFHNA = 75;
        private const int JJPGNNDKFOH = 0;
        public const int LMFBPFAAFAJ = 30;
        public const int KHKCGBEHOCF = 40;
        public const int MPADBDCHIBN = 60;
        public const int KAGAEHCIAFJ = 70;
        public const int OCIIJNGCKFM = 80;
        public const int BBIDMJJNLKP = 70;
        public const int PHHFFLHPEEG = 70;
        public const int MMJPNPDOJJI = 80;
        public int BGLLCLEDHKK_VolSe = 15; // 0x8
        public int HOMPENLIHCK_VolBgm = 15; // 0xC
        public int CNCIMBGLKOB_VolVoice = 15; // 0x10
        public int LMDACNNJDOE_VolSeRhythm = 15; // 0x14
        public int ICGAOAFIHFD_VolBgmRhythm = 15; // 0x18
        public int FCKEDCKCEFC_VolVoiceRhythm = 15; // 0x1C
        public int IBEINHHMHAC_VolNotesRhythm = 11; // 0x20
        public int CJFAJNMADBA_ScreenRotation; // 0x24
        public int NFMEIILKACN_NotesRoute; // 0x28
        public int NAGJLEIPAAC_Cutin; // 0x2C
        public int DADIPGPHLDD_EffectCutin; // 0x30
        public int DDHCLNFPNGK_RenderQuality = 0;// Tmp to init in full quality 1; // 0x34
        public int GEPLOFLHAOL_NeedInitRenderQuality; // 0x38
        public int OJAJHIMOIEC_NoteOffset; // 0x3C
        public int OAKOJGPBAJF_BackKey; // 0x40
        public int PMGMMMGCEEI_Video; // 0x44
        public int IHEPCAHBECA_VideoMode; // 0x48
        public int MHACPBAPBFE_BgMode; // 0x4C
        public int GACNKPOMOFA_IsDrawKira; // 0x50
        public int LENJLNLNPEO_IsPlateAnimationHome; // 0x54
        public int DFLJOKOKLIL_IsPlateAnimationOther; // 0x58
        public int MDMDEAFFIMB_IsDivaEffect; // 0x5C
        public int HHMCIGLCBNG_QualityCustomDiva3D; // 0x60
        public int AHLFOHJMGAI_QualityCustomOther3D; // 0x64
        public int FPJHOLMLDGC_QualityCustom2D = 1; // 0x68
        public int CDGKHMEOEMP_ValkyrieMode; // 0x6C
        public int OLALFDCEHKJ_Dimmer3d = 10; // 0x70
        public int FPFAMFOPJDJ_Dimmer2d = 4; // 0x74
        public int DCHMOFLEFMI_NotesSpeedEasy = 30; // 0x78
        public int MBOEPFLNDOD_NotesSpeedNormal = 40; // 0x7C
        public int MGOOLKHAPAF_NotesSpeedHard = 60; // 0x80
        public int AIKDLBAANLG_NotesSpeedVeryHard = 70; // 0x84
        public int KOKDGGOFPPI_NotesSpeedExtreme = 80; // 0x88
        public int LIPAPGABJOA_NotesSpeedHardPlus = 70; // 0x8C
        public int JDJBFBPBLDC_NotesSpeedVeryHardPlus = 70; // 0x90
        public int FJKNAHGFAPP_NotesSpeedExtremePlus = 80; // 0x94
        public int LHJHOFNIJJF_NotesSpeedSelectDiff = 1; // 0x98
        public bool ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode; // 0x9C
        public int LBIKGDHCICB_NotesSpeedAllApply; // 0xA0
        public int JJDENMHGOIH_NotesSpeedAutoRejected; // 0xA4
        public int KDNKCOAJGCM_NotesType = 1; // 0xA8
        public int BBIOMNCILMC_HomeDivaId = 1; // 0xAC // Hack default init diva id for new save
        public bool GDLAPBKCBFP_IsHomeDivaWindow = true; // 0xB0
        public int BAGJHPGGCCI_PlayLogGraphType; // 0xB4
        public bool EDDMJEMOAGM_IsExcellentDisplaySetting = true; // 0xB8
        public bool CJKKALFPMLA_IsDivaModeDivaVisible = true; // 0xB9
        public bool KPFAFLBICLA_IsBattleEventInfo = true; // 0xBA
        public bool MJHEPGIEDDL_IsSlideNoteEffect = true; // 0xBB
        public int HLABNEIEJPM_SafeAreaDesign; // 0xBC
        public int HJPDHDHMOPF; // 0xC0
        public bool BIEOIPOLFLN_IsPlayRecordFirstLaunch = true; // 0xC4

        // public bool PBANLLOLBKK { get; }
        // public bool GBCGNDJANFJ { get; }
        // public bool ENJFHBNCHEB { get; }
        // public bool PPDJAPPLOPA { get; }
        // public bool AHIBBPFIAMJ { get; }
        // public bool FFKLPNPJLMB { get; }
        // public bool FGJBDPOGMDI { get; }
        public bool CIGAPPFDFKL_Is3D { get { return DDHCLNFPNGK_RenderQuality != 2; } private set {} } //MNJOLLGPMPI 0x2035E64 JCCDFGOGFFA 0x2035E8C
        // public bool OOCKIFIHJJN { get; private set; } CKJIGBCJGMI 0x2035E78 IBPIBMKAMPE 0x2035E90

        // // RVA: 0x2035BF0 Offset: 0x2035BF0 VA: 0x2035BF0
        public void PBCBJAPONBF()
        {
            TodoLogger.Log(0, "TODO");
		}

        // // RVA: 0x2035D68 Offset: 0x2035D68 VA: 0x2035D68
        // public bool KKBJCJNAGDB() { }

        // // RVA: 0x2035D7C Offset: 0x2035D7C VA: 0x2035D7C
        public bool GLKGAOFHLPN()
        {
            return DADIPGPHLDD_EffectCutin == 0;
        }

        // // RVA: 0x2035D90 Offset: 0x2035D90 VA: 0x2035D90
        public bool GPKILPOLNKO()
		{
			if (DDHCLNFPNGK_RenderQuality == 2)
				return false;
			return PMGMMMGCEEI_Video == 0;
		}

        // // RVA: 0x2035DB8 Offset: 0x2035DB8 VA: 0x2035DB8
        public bool PKEMELMMEKM_GetDivaQuality()
		{
			if (DDHCLNFPNGK_RenderQuality == 3)
				return HHMCIGLCBNG_QualityCustomDiva3D == 0;
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035DD4 Offset: 0x2035DD4 VA: 0x2035DD4
        // public bool DKECHCHOMEL() { }

        // // RVA: 0x2035DF0 Offset: 0x2035DF0 VA: 0x2035DF0
        // public bool MIHFCOBBIPJ() { }

        // // RVA: 0x2035E0C Offset: 0x2035E0C VA: 0x2035E0C
        public bool JLEJPKOMKEJ()
		{
			if(DDHCLNFPNGK_RenderQuality == 3)
			{
				if (FPJHOLMLDGC_QualityCustom2D == 1 && HHMCIGLCBNG_QualityCustomDiva3D == 1)
					return AHLFOHJMGAI_QualityCustomOther3D == 1;
			}
			return false;
		}

        // // RVA: 0x2035E48 Offset: 0x2035E48 VA: 0x2035E48
        public bool INPHNKJPJFN()
		{
			if(DDHCLNFPNGK_RenderQuality == 3)
			{
				return HHMCIGLCBNG_QualityCustomDiva3D == 0;
			}
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035E94 Offset: 0x2035E94 VA: 0x2035E94
        public int CBLEFELBNDN_GetQuality()
		{
			return IHEPCAHBECA_VideoMode != 0 ? 1 : 2;
		}

        // // RVA: 0x2035EA8 Offset: 0x2035EA8 VA: 0x2035EA8
        // public int DGCDPGPAAII(Difficulty.Type FEOKKEPAIBB, bool JCOJKAHFADL) { }

        // // RVA: 0x2035F1C Offset: 0x2035F1C VA: 0x2035F1C
        // public Difficulty.Type OEJCANLJKPI() { }

        // // RVA: 0x2035F24 Offset: 0x2035F24 VA: 0x2035F24
        // public bool IFLFCLIHCOA() { }

        // // RVA: 0x2035F2C Offset: 0x2035F2C VA: 0x2035F2C
        // public bool DCJKPJFIJKH() { }

        // // RVA: 0x2035F3C Offset: 0x2035F3C VA: 0x2035F3C
        public int HBCHGGNOOCD_GetNotesDisplayTiming(Difficulty.Type FEOKKEPAIBB, bool JCOJKAHFADL)
        {
            TodoLogger.Log(0, "HBCHGGNOOCD_GetNotesDisplayTiming");
            return 0;
        }

        // // RVA: 0x203607C Offset: 0x203607C VA: 0x203607C
        // public void GMHKLEMBLOF(int INDDJNMPONH, int DOKKMMFKLJI) { }

        // // RVA: 0x2036088 Offset: 0x2036088 VA: 0x2036088
        // public void FFLGCAJBPDE(out int INDDJNMPONH, out int DOKKMMFKLJI) { }

        // // RVA: 0x20360B0 Offset: 0x20360B0 VA: 0x20360B0
        // public static float MOMJFKFNJIA(int DHMNFEPOLOK) { }

        // // RVA: 0x20360D4 Offset: 0x20360D4 VA: 0x20360D4
        // public float MIFIAMNHKOF() { }

        // // RVA: 0x20360F8 Offset: 0x20360F8 VA: 0x20360F8
        // public float EBBAAPCHNKL() { }

        // // RVA: 0x20361A4 Offset: 0x20361A4 VA: 0x20361A4
        // public bool AOOKLMAPPLG() { }

        // // RVA: 0x20361B8 Offset: 0x20361B8 VA: 0x20361B8
        public void AFMDGKBANPH(bool IPJMPBANBPP)
        {
            TodoLogger.Log(0, "TODO");
        }

        // // RVA: 0x20361E0 Offset: 0x20361E0 VA: 0x20361E0
        // public static bool CHDGLBBFEKH(ILDKBCLAFPB.MPHNGGECENI_Option ILEKEPJBFDP, ILDKBCLAFPB.MPHNGGECENI_Option GEPALDIIDPC) { }

        // // RVA: 0x20326B8 Offset: 0x20326B8 VA: 0x20326B8
        // public static bool HMMFJOEBEKJ(ILDKBCLAFPB.MPHNGGECENI_Option ILEKEPJBFDP, ILDKBCLAFPB.MPHNGGECENI_Option GEPALDIIDPC) { }

        // // RVA: 0x20326F4 Offset: 0x20326F4 VA: 0x20326F4
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.MPHNGGECENI_Option FMKAONAMGCN)
        {
            TodoLogger.Log(0, "SaveCopy");
        }

        // // RVA: 0x20346A4 Offset: 0x20346A4 VA: 0x20346A4
        // public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }

        // // RVA: 0x20335FC Offset: 0x20335FC VA: 0x20335FC
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			BGLLCLEDHKK_VolSe = JsonUtil.GetInt(OBHAFLMHAKG, "volSe", 0xf);
			HOMPENLIHCK_VolBgm = JsonUtil.GetInt(OBHAFLMHAKG, "volBgm", 0xf);
			CNCIMBGLKOB_VolVoice = JsonUtil.GetInt(OBHAFLMHAKG, "volVoice", 0xf);
			CJFAJNMADBA_ScreenRotation = JsonUtil.GetInt(OBHAFLMHAKG, "screenRotation", 0);
			NFMEIILKACN_NotesRoute = JsonUtil.GetInt(OBHAFLMHAKG, "notesRoute", 0);
			OJAJHIMOIEC_NoteOffset = JsonUtil.GetInt(OBHAFLMHAKG, "noteOffset", 0);
			NAGJLEIPAAC_Cutin = JsonUtil.GetInt(OBHAFLMHAKG, "cutin", 0);
			DADIPGPHLDD_EffectCutin = JsonUtil.GetInt(OBHAFLMHAKG, "effectCutin", 0);
			DDHCLNFPNGK_RenderQuality = JsonUtil.GetInt(OBHAFLMHAKG, "renderQuality", 1);
			GEPLOFLHAOL_NeedInitRenderQuality = JsonUtil.GetInt(OBHAFLMHAKG, "needInitRenderQuality", 0);
			LMDACNNJDOE_VolSeRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volSeRhythm", 0xf);
			ICGAOAFIHFD_VolBgmRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volBgmRhythm", 0xf);
			FCKEDCKCEFC_VolVoiceRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volVoiceRhythm", 0xf);
			IBEINHHMHAC_VolNotesRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volNotesRhythm", 0xb);
			PMGMMMGCEEI_Video = JsonUtil.GetInt(OBHAFLMHAKG, "video", 0);
			IHEPCAHBECA_VideoMode = JsonUtil.GetInt(OBHAFLMHAKG, "videoMode", 0);
			OAKOJGPBAJF_BackKey = JsonUtil.GetInt(OBHAFLMHAKG, "backKey", 0);
			MHACPBAPBFE_BgMode = JsonUtil.GetInt(OBHAFLMHAKG, "bgMode", 0);
			GACNKPOMOFA_IsDrawKira = JsonUtil.GetInt(OBHAFLMHAKG, "isDrawKira", 0);
			LENJLNLNPEO_IsPlateAnimationHome = JsonUtil.GetInt(OBHAFLMHAKG, "isPlateAnimationHome", 0);
			DFLJOKOKLIL_IsPlateAnimationOther = JsonUtil.GetInt(OBHAFLMHAKG, "isPlateAnimationOther", 0);
			MDMDEAFFIMB_IsDivaEffect = JsonUtil.GetInt(OBHAFLMHAKG, "isDivaEffect", 0);
			HHMCIGLCBNG_QualityCustomDiva3D = JsonUtil.GetInt(OBHAFLMHAKG, "qualityCustomDiva3D", 0);
			AHLFOHJMGAI_QualityCustomOther3D = JsonUtil.GetInt(OBHAFLMHAKG, "qualityCustomOther3D", 0);
			FPJHOLMLDGC_QualityCustom2D = JsonUtil.GetInt(OBHAFLMHAKG, "qualityCustom2D", 1);
			OLALFDCEHKJ_Dimmer3d = JsonUtil.GetInt(OBHAFLMHAKG, "dimmer3d", 10);
			FPFAMFOPJDJ_Dimmer2d = JsonUtil.GetInt(OBHAFLMHAKG, "dimmer2d", 4);
			CDGKHMEOEMP_ValkyrieMode = JsonUtil.GetInt(OBHAFLMHAKG, "valkyrieMode", 0);
			DCHMOFLEFMI_NotesSpeedEasy = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedEasy", 30);
			MBOEPFLNDOD_NotesSpeedNormal = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedNormal", 40);
			MGOOLKHAPAF_NotesSpeedHard = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedHard", 60);
			AIKDLBAANLG_NotesSpeedVeryHard = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedVeryHard", 70);
			KOKDGGOFPPI_NotesSpeedExtreme = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedExtreme", 80);
			LIPAPGABJOA_NotesSpeedHardPlus = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedHardPlus", 70);
			JDJBFBPBLDC_NotesSpeedVeryHardPlus = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedVeryHardPlus", 70);
			FJKNAHGFAPP_NotesSpeedExtremePlus= JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedExtremePlus", 80);
			LHJHOFNIJJF_NotesSpeedSelectDiff = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedSelectDiff", 1);
			ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedSelectDiffLine6Mode", 0) != 0;
			LBIKGDHCICB_NotesSpeedAllApply = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedAllApply", 0);
			JJDENMHGOIH_NotesSpeedAutoRejected = JsonUtil.GetInt(OBHAFLMHAKG, "notesSpeedAutoRejected", 0);
			KDNKCOAJGCM_NotesType = JsonUtil.GetInt(OBHAFLMHAKG, "notesType", 1);
			BBIOMNCILMC_HomeDivaId = JsonUtil.GetInt(OBHAFLMHAKG, "homeDivaId", 0);
			GDLAPBKCBFP_IsHomeDivaWindow = JsonUtil.GetInt(OBHAFLMHAKG, "isHomeDivaWindow", 0) != 0;
			BAGJHPGGCCI_PlayLogGraphType = JsonUtil.GetInt(OBHAFLMHAKG, "playLogGraphType", 0);
			EDDMJEMOAGM_IsExcellentDisplaySetting = JsonUtil.GetInt(OBHAFLMHAKG, "isExcellentDisplaySetting", 0) != 0;
			CJKKALFPMLA_IsDivaModeDivaVisible = JsonUtil.GetInt(OBHAFLMHAKG, "isDivaModeDivaVisible", 0) != 0;
			KPFAFLBICLA_IsBattleEventInfo = JsonUtil.GetInt(OBHAFLMHAKG, "isBattleEventInfo", 0) != 0;
			MJHEPGIEDDL_IsSlideNoteEffect = JsonUtil.GetInt(OBHAFLMHAKG, "isSlideNoteEffect", 0) != 0;
			HLABNEIEJPM_SafeAreaDesign = JsonUtil.GetInt(OBHAFLMHAKG, "safeAreaDesign", 0);
			BIEOIPOLFLN_IsPlayRecordFirstLaunch = JsonUtil.GetInt(OBHAFLMHAKG, "isPlayRecordFirstLaunch", 0) != 0;
			HJPDHDHMOPF = SystemManager.IsForceWideScreen ? 0 : 1;
		}
		
	}

	public class APLMBKKCNKC_Select
	{
		public class EJBBPMBEKLP
		{
			private static readonly int LNHIHOKKPFF = FreeCategoryId.ArrayNum; // 0x0
			private int OMKLPMBJLIO; // 0x8 // FreeCategoryId
			private int HNKJDJFFACC_Diff; // 0xC // difficulty
			private List<int> LGMDOEIPLAK; // 0x10
			private List<int> AADOPBAMLJK; // 0x14
			private int PFHPKAGBMOK; // 0x18
			private int LPPHJLBNAEO; // 0x1C
			private bool PMDNOPLFCNH; // 0x20
			private StringBuilder KKELPILEDDD; // 0x24

			// // RVA: 0x2022BB8 Offset: 0x2022BB8 VA: 0x2022BB8
			public EJBBPMBEKLP()
			{
				HNKJDJFFACC_Diff = 0;
				OMKLPMBJLIO = 0;
				PMDNOPLFCNH = false;
				LGMDOEIPLAK = new List<int>(LNHIHOKKPFF);
				AADOPBAMLJK = new List<int>(LNHIHOKKPFF);
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK.Add(0);
					AADOPBAMLJK.Add(0);
				}
				KKELPILEDDD = new StringBuilder(32);
			}

			// // RVA: 0x2023BBC Offset: 0x2023BBC VA: 0x2023BBC
			// public static bool CHDGLBBFEKH(ILDKBCLAFPB.APLMBKKCNKC.EJBBPMBEKLP LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC.EJBBPMBEKLP CJDJGHIIBHP) { }

			// // RVA: 0x201EA24 Offset: 0x201EA24 VA: 0x201EA24
			// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.APLMBKKCNKC.EJBBPMBEKLP LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC.EJBBPMBEKLP CJDJGHIIBHP) { }

			// // RVA: 0x201EEF4 Offset: 0x201EEF4 VA: 0x201EEF4
			public void ODDIHGPONFL_Copy(ILDKBCLAFPB.APLMBKKCNKC_Select.EJBBPMBEKLP PJFKNNNDMIA)
			{
				PJFKNNNDMIA.OMKLPMBJLIO = OMKLPMBJLIO;
				PJFKNNNDMIA.HNKJDJFFACC_Diff = HNKJDJFFACC_Diff;
				PJFKNNNDMIA.PMDNOPLFCNH = PMDNOPLFCNH;
				PJFKNNNDMIA.LGMDOEIPLAK.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK.AddRange(LGMDOEIPLAK);
				PJFKNNNDMIA.AADOPBAMLJK.Clear();
				PJFKNNNDMIA.AADOPBAMLJK.AddRange(AADOPBAMLJK);
				PJFKNNNDMIA.PFHPKAGBMOK = PFHPKAGBMOK;
				PJFKNNNDMIA.LPPHJLBNAEO = LPPHJLBNAEO;
			}

			// // RVA: 0x201FC3C Offset: 0x201FC3C VA: 0x201FC3C
			// public EDOHBJAPLPF NOJCMGAFAAC() { }

			// // RVA: 0x20219D4 Offset: 0x20219D4 VA: 0x20219D4
			public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				OMKLPMBJLIO = JsonUtil.GetInt(OBHAFLMHAKG, "categoryId", 4);
				HNKJDJFFACC_Diff = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				PMDNOPLFCNH = JsonUtil.GetFlag(OBHAFLMHAKG, "isLine6", false);
				LGMDOEIPLAK.Clear();
				AADOPBAMLJK.Clear();
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicid_{0:D2}", i), 0));
					AADOPBAMLJK.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("gameEventType_{0:D2}{0:D2}", i), 0));
				}
				PFHPKAGBMOK = JsonUtil.GetInt(OBHAFLMHAKG, "playDashEventId", 0);
				LPPHJLBNAEO = JsonUtil.GetInt(OBHAFLMHAKG, "playDashSelect", 0);
			}

			// // RVA: 0x2023DF4 Offset: 0x2023DF4 VA: 0x2023DF4
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}

			// // RVA: 0x2023EAC Offset: 0x2023EAC VA: 0x2023EAC
			public FreeCategoryId.Type OGJDBPMKJKE()
			{
				return (FreeCategoryId.Type)OMKLPMBJLIO;
			}

			// // RVA: 0x2023EB4 Offset: 0x2023EB4 VA: 0x2023EB4
			public Difficulty.Type FFACBDAJJJP()
			{
				return (Difficulty.Type)HNKJDJFFACC_Diff;
			}

			// // RVA: 0x2023EBC Offset: 0x2023EBC VA: 0x2023EBC
			public bool LMPCJJKHHPA() 
			{
				return PMDNOPLFCNH;
			}

			// // RVA: 0x2023EC4 Offset: 0x2023EC4 VA: 0x2023EC4
			// public int BKCOOGKFJJF() { }

			// // RVA: 0x2023ECC Offset: 0x2023ECC VA: 0x2023ECC
			// public int GHEFLJANGIC() { }

			// // RVA: 0x2023ED4 Offset: 0x2023ED4 VA: 0x2023ED4
			public void FKJBADIPKHK(FreeCategoryId.Type DEPGBBJMFED, out int GHBPLHBNMBK, out OHCAABOMEOF.KGOGMKMBCPP HIDHLFCBIDE)
			{
				GHBPLHBNMBK = LGMDOEIPLAK[(int)DEPGBBJMFED - 1];
				HIDHLFCBIDE = (OHCAABOMEOF.KGOGMKMBCPP)AADOPBAMLJK[(int)DEPGBBJMFED - 1];
			}

			// // RVA: 0x2023F98 Offset: 0x2023F98 VA: 0x2023F98
			// public void NGNECOFAMKP(FreeCategoryId.Type DEPGBBJMFED) { }

			// // RVA: 0x2023FA0 Offset: 0x2023FA0 VA: 0x2023FA0
			// public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK) { }

			// // RVA: 0x2023FA8 Offset: 0x2023FA8 VA: 0x2023FA8
			// public void HPDBEKAGKOD(bool GIKLNODJKFK) { }

			// // RVA: 0x2023FB0 Offset: 0x2023FB0 VA: 0x2023FB0
			// public void KJGPOAEGFHK(int EKANGPODCEP, int MCNEIJAOLNO) { }

			// // RVA: 0x2023FBC Offset: 0x2023FBC VA: 0x2023FBC
			// public void ACGKEJKPFIA(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK, OHCAABOMEOF.KGOGMKMBCPP HIDHLFCBIDE) { }
		}


		public class GADJIIFFPFI
		{
			private int FFAKPFEGCOG_Series = 0; // 0x8
			private int HNKJDJFFACC_Diff = 0; // 0xC
			private List<int> LGMDOEIPLAK = new List<int>(2) { 0, 0 }; // 0x10
			private List<int> AADOPBAMLJK = new List<int>(2) { 0, 0 }; // 0x14
			private int PFHPKAGBMOK; // 0x18
			private int LPPHJLBNAEO; // 0x1C
			private bool PMDNOPLFCNH = false; // 0x20 IS 6 line
			private bool KLABKJNFCPD = false; // 0x21
			private bool PGNNDICEIBG = true; // 0x22
			private StringBuilder KKELPILEDDD = new StringBuilder(32); // 0x24

			// // RVA: 0x202417C Offset: 0x202417C VA: 0x202417C
			// public static bool CHDGLBBFEKH(ILDKBCLAFPB.APLMBKKCNKC.GADJIIFFPFI LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC.GADJIIFFPFI CJDJGHIIBHP) { }

			// // RVA: 0x201EAB0 Offset: 0x201EAB0 VA: 0x201EAB0
			// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.APLMBKKCNKC.GADJIIFFPFI LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC.GADJIIFFPFI CJDJGHIIBHP) { }

			// // RVA: 0x201F084 Offset: 0x201F084 VA: 0x201F084
			// public void ODDIHGPONFL(ILDKBCLAFPB.APLMBKKCNKC.GADJIIFFPFI PJFKNNNDMIA) { }

			// // RVA: 0x2020030 Offset: 0x2020030 VA: 0x2020030
			// public EDOHBJAPLPF NOJCMGAFAAC() { }

			// // RVA: 0x2021C78 Offset: 0x2021C78 VA: 0x2021C78
			// public void KHEKNNFCAOI(EDOHBJAPLPF OBHAFLMHAKG) { }

			// // RVA: 0x202439C Offset: 0x202439C VA: 0x202439C
			// private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA) { }

			// // RVA: 0x2024454 Offset: 0x2024454 VA: 0x2024454
			// public MusicSelectConsts.SeriesType GPAJHMLOPNP() { }

			// // RVA: 0x202445C Offset: 0x202445C VA: 0x202445C
			public Difficulty.Type FFACBDAJJJP()
			{
				return (Difficulty.Type)HNKJDJFFACC_Diff;
			}

			// // RVA: 0x2024464 Offset: 0x2024464 VA: 0x2024464
			public bool LMPCJJKHHPA()
			{
				return PMDNOPLFCNH;
			} // is 6 line

			// // RVA: 0x202446C Offset: 0x202446C VA: 0x202446C
			public bool OAALFANHEHL()
			{
				return KLABKJNFCPD;
			}

			// // RVA: 0x2024474 Offset: 0x2024474 VA: 0x2024474
			public bool CFNMCFDDOJO()
			{
				return PGNNDICEIBG;
			}

			// // RVA: 0x202447C Offset: 0x202447C VA: 0x202447C
			// public int BKCOOGKFJJF() { }

			// // RVA: 0x2024484 Offset: 0x2024484 VA: 0x2024484
			// public int GHEFLJANGIC() { }

			// // RVA: 0x202448C Offset: 0x202448C VA: 0x202448C
			public void FKJBADIPKHK(bool FAGEBAKNAOB, out int GHBPLHBNMBK, out OHCAABOMEOF.KGOGMKMBCPP HIDHLFCBIDE)
			{
				TodoLogger.Log(0, "FKJBADIPKHK");
				GHBPLHBNMBK = 0;
				HIDHLFCBIDE = OHCAABOMEOF.KGOGMKMBCPP.AOPKACCDKPA;
			}

			// // RVA: 0x202454C Offset: 0x202454C VA: 0x202454C
			public void GJDEHJBAMNH(MusicSelectConsts.SeriesType MGBDCFIKBPM)
			{
				FFAKPFEGCOG_Series = (int)MGBDCFIKBPM;
			}

			// // RVA: 0x2024554 Offset: 0x2024554 VA: 0x2024554
			public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK)
			{
				HNKJDJFFACC_Diff = (int)AKNELONELJK;
			}

			// // RVA: 0x202455C Offset: 0x202455C VA: 0x202455C
			// public void HPDBEKAGKOD(bool GIKLNODJKFK) { }

			// // RVA: 0x2024564 Offset: 0x2024564 VA: 0x2024564
			// public void ABGEMNAHALF(bool FAGEBAKNAOB) { }

			// // RVA: 0x202456C Offset: 0x202456C VA: 0x202456C
			public void BKFOJBAGDHN(bool GNLIFHBDDIL)
			{
				PGNNDICEIBG = GNLIFHBDDIL;
			}

			// // RVA: 0x2024574 Offset: 0x2024574 VA: 0x2024574
			// public void KJGPOAEGFHK(int EKANGPODCEP, int MCNEIJAOLNO) { }

			// // RVA: 0x2024580 Offset: 0x2024580 VA: 0x2024580
			public void ACGKEJKPFIA(bool FAGEBAKNAOB, int GHBPLHBNMBK, OHCAABOMEOF.KGOGMKMBCPP HIDHLFCBIDE)
			{
				LGMDOEIPLAK[FAGEBAKNAOB ? 1 : 0] = GHBPLHBNMBK;
				AADOPBAMLJK[FAGEBAKNAOB ? 1 : 0] = (int)HIDHLFCBIDE;
			}
		}

		public ILDKBCLAFPB.APLMBKKCNKC_Select.EJBBPMBEKLP BCOIACHCMLA = new ILDKBCLAFPB.APLMBKKCNKC_Select.EJBBPMBEKLP(); // 0x8
		public ILDKBCLAFPB.APLMBKKCNKC_Select.GADJIIFFPFI ADHMDONLHLJ = new ILDKBCLAFPB.APLMBKKCNKC_Select.GADJIIFFPFI(); // 0xC
		// public ILDKBCLAFPB.APLMBKKCNKC.IEFBBNFNKIJ OCBIOMPAJFF = new ILDKBCLAFPB.APLMBKKCNKC.IEFBBNFNKIJ(); // 0x10
		// public ILDKBCLAFPB.APLMBKKCNKC.FLOIJPMBBIL MFFAIIDJPBL = new ILDKBCLAFPB.APLMBKKCNKC.FLOIJPMBBIL(); // 0x14
		// public ILDKBCLAFPB.APLMBKKCNKC.PLHMBFFLEPB KIKCCBMOLDM = new ILDKBCLAFPB.APLMBKKCNKC.PLHMBFFLEPB(); // 0x18
		// public ILDKBCLAFPB.APLMBKKCNKC.CGAJFHFIGJG CECJBBEGOPG = new ILDKBCLAFPB.APLMBKKCNKC.CGAJFHFIGJG(); // 0x1C
		// public ILDKBCLAFPB.APLMBKKCNKC.MBNCBCJKCEA JGAFBCMOGLP = new ILDKBCLAFPB.APLMBKKCNKC.MBNCBCJKCEA(); // 0x20
		// public ILDKBCLAFPB.APLMBKKCNKC.JPAIABGDMCK KHBHOGEEHBA = new ILDKBCLAFPB.APLMBKKCNKC.JPAIABGDMCK(); // 0x24
		// public ILDKBCLAFPB.APLMBKKCNKC.DBALFEBAHDH FPOJOFFFLFK = new ILDKBCLAFPB.APLMBKKCNKC.DBALFEBAHDH(); // 0x28
		// public ILDKBCLAFPB.APLMBKKCNKC.OAMMINGBAPE KMCLFGMAKPA = new ILDKBCLAFPB.APLMBKKCNKC.OAMMINGBAPE(); // 0x2C
		// public ILDKBCLAFPB.APLMBKKCNKC.MEMAEGKMBJM ECNAIALHHBO = new ILDKBCLAFPB.APLMBKKCNKC.MEMAEGKMBJM(); // 0x30
		// public ILDKBCLAFPB.APLMBKKCNKC.KOOHLCAIIGJ AAFEFCNONGL = new ILDKBCLAFPB.APLMBKKCNKC.KOOHLCAIIGJ(); // 0x34

		// // RVA: 0x201E7F4 Offset: 0x201E7F4 VA: 0x201E7F4
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.APLMBKKCNKC LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC CJDJGHIIBHP) { }

		// // RVA: 0x201ECF4 Offset: 0x201ECF4 VA: 0x201ECF4
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.APLMBKKCNKC LFGLBIAODLE, ILDKBCLAFPB.APLMBKKCNKC CJDJGHIIBHP) { }

		// // RVA: 0x201ED08 Offset: 0x201ED08 VA: 0x201ED08
		public void ODDIHGPONFL_Copy(ILDKBCLAFPB.APLMBKKCNKC_Select PJFKNNNDMIA)
		{
			TodoLogger.Log(0, "finish ODDIHGPONFL_Copy");
			BCOIACHCMLA.ODDIHGPONFL_Copy(PJFKNNNDMIA.BCOIACHCMLA);
		}

		// // RVA: 0x201F80C Offset: 0x201F80C VA: 0x201F80C
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x20214C8 Offset: 0x20214C8 VA: 0x20214C8
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			TodoLogger.Log(0, "finish KHEKNNFCAOI_Init");
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("live"))
			{
				BCOIACHCMLA.KHEKNNFCAOI_Init(OBHAFLMHAKG["live"]);
			}
		}
	}

    public class FOLMONPGGPP_Header
    {
        public int CEMEIPNMAAD_Version { get; protected set; } // 0x8 FDEEJLEOLGC MPHJDGEDFOC FNCCGEAMNAC

        // // RVA: 0x202A558 Offset: 0x202A558 VA: 0x202A558
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			CEMEIPNMAAD_Version = JsonUtil.GetInt(OBHAFLMHAKG, "version", 0);
		}

        // // RVA: 0x202A5CC Offset: 0x202A5CC VA: 0x202A5CC
        // public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }

        // // RVA: 0x202A6A0 Offset: 0x202A6A0 VA: 0x202A6A0
        // public static bool CHDGLBBFEKH(ILDKBCLAFPB.FOLMONPGGPP_Header ILEKEPJBFDP, ILDKBCLAFPB.FOLMONPGGPP_Header GEPALDIIDPC) { }

        // // RVA: 0x202A6E8 Offset: 0x202A6E8 VA: 0x202A6E8
        // public static bool HMMFJOEBEKJ(ILDKBCLAFPB.FOLMONPGGPP_Header ILEKEPJBFDP, ILDKBCLAFPB.FOLMONPGGPP_Header GEPALDIIDPC) { }

        // // RVA: 0x202A6FC Offset: 0x202A6FC VA: 0x202A6FC
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.FOLMONPGGPP_Header FMKAONAMGCN)
		{
			TodoLogger.Log(0, "SaveCopy");
		}

        // // RVA: 0x201B130 Offset: 0x201B130 VA: 0x201B130
        public void BOGMEEOOADP()
        {
            CEMEIPNMAAD_Version = ILDKBCLAFPB.JLLFHBIJNPC();
        }
    }
	
	
	public class KKNFJMEBONI_SceneData
	{
		public CEBFFLDKAEC PPFNGGCBJKC_Id = new CEBFFLDKAEC(); // 0x8
		public long BEBJKJKBOGH_Date; // 0x10
		public int CADENLBDAEB_IsNew = 1; // 0x18

		// // RVA: 0x202B4F8 Offset: 0x202B4F8 VA: 0x202B4F8
		// public void EDEDFDDIOKO(MMPBPOIFDAF.PMKOFEIONEG KDIFMECGNIC) { }

		// // RVA: 0x202A72C Offset: 0x202A72C VA: 0x202A72C
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x202A8AC Offset: 0x202A8AC VA: 0x202A8AC
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			PPFNGGCBJKC_Id.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "id", 0);
			BEBJKJKBOGH_Date = JsonUtil.GetLong(OBHAFLMHAKG, "date", 0);
			CADENLBDAEB_IsNew = JsonUtil.GetInt(OBHAFLMHAKG, "isNew", 1);
		}

		// // RVA: 0x2035B3C Offset: 0x2035B3C VA: 0x2035B3C
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.KKNFJMEBONI_SceneData ILEKEPJBFDP, ILDKBCLAFPB.KKNFJMEBONI_SceneData GEPALDIIDPC) { }

		// // RVA: 0x202AD64 Offset: 0x202AD64 VA: 0x202AD64
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.KKNFJMEBONI_SceneData ILEKEPJBFDP, ILDKBCLAFPB.KKNFJMEBONI_SceneData GEPALDIIDPC) { }

		// // RVA: 0x202BBB4 Offset: 0x202BBB4 VA: 0x202BBB4
		// public FENCAJJBLBH KPOCKNCJBPN() { }

		// // RVA: 0x202AD78 Offset: 0x202AD78 VA: 0x202AD78
		// public void ODDIHGPONFL_Copy(ILDKBCLAFPB.KKNFJMEBONI_SceneData FMKAONAMGCN) { }
	}
	
	public class BEBBCJLDOFF_DivaData
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public CEBFFLDKAEC AFBMEMCHJCL_MainScene = new CEBFFLDKAEC(); // 0xC

		// // RVA: 0x20250D8 Offset: 0x20250D8 VA: 0x20250D8
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x2025208 Offset: 0x2025208 VA: 0x2025208
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			PPFNGGCBJKC_Id = JsonUtil.GetInt(OBHAFLMHAKG, "lastBaseUnionCredit", 0);
			AFBMEMCHJCL_MainScene.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "mainScene", 0);
		}

		// // RVA: 0x20252C4 Offset: 0x20252C4 VA: 0x20252C4
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.BEBBCJLDOFF_DivaData ILEKEPJBFDP, ILDKBCLAFPB.BEBBCJLDOFF_DivaData GEPALDIIDPC) { }

		// // RVA: 0x2025364 Offset: 0x2025364 VA: 0x2025364
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.BEBBCJLDOFF_DivaData ILEKEPJBFDP, ILDKBCLAFPB.BEBBCJLDOFF_DivaData GEPALDIIDPC) { }

		// // RVA: 0x2025378 Offset: 0x2025378 VA: 0x2025378
		// public FENCAJJBLBH KPOCKNCJBPN() { }

		// // RVA: 0x20253A4 Offset: 0x20253A4 VA: 0x20253A4
		// public void ODDIHGPONFL_Copy(ILDKBCLAFPB.BEBBCJLDOFF_DivaData FMKAONAMGCN) { }
	}
	
	public class ABBBCBIHMFE_DropItem
	{
		public CEBFFLDKAEC KIJAPOFAGPN_ItemId = new CEBFFLDKAEC(); // 0x8
		public int OIPCCBHIKIA_Index; // 0xC
		public int OMAJOEOOAJJ_Count0; // 0x10
		public int HMFFHLPNMPH_Count; // 0x14
		public int JPIPENJGGDD_Multi; // 0x18
		public int PLKAGPBEHMB_LuckPlus; // 0x1C
		public CEBFFLDKAEC ONDODHPHOOF_ConvertItemId = new CEBFFLDKAEC(); // 0x20
		public int ABIFFLDIAMM_ConvertItemCount; // 0x24
		public bool LHEDLDEMPPG_IsNewScene; // 0x28
		public bool PHJHJGDLPED_IsRareDrop; // 0x29

		// // RVA: 0x201BD08 Offset: 0x201BD08 VA: 0x201BD08
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x201C10C Offset: 0x201C10C VA: 0x201C10C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			KIJAPOFAGPN_ItemId.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "itemId", 0);
			OIPCCBHIKIA_Index = JsonUtil.GetInt(OBHAFLMHAKG, "index", 0);
			OMAJOEOOAJJ_Count0 = JsonUtil.GetInt(OBHAFLMHAKG, "count0", 0);
			HMFFHLPNMPH_Count = JsonUtil.GetInt(OBHAFLMHAKG, "count", 0);
			JPIPENJGGDD_Multi = JsonUtil.GetInt(OBHAFLMHAKG, "multi", 0);
			PLKAGPBEHMB_LuckPlus = JsonUtil.GetInt(OBHAFLMHAKG, "luckPlus", 0);
			ONDODHPHOOF_ConvertItemId.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "convertItemId", 0);
			ABIFFLDIAMM_ConvertItemCount = JsonUtil.GetInt(OBHAFLMHAKG, "convertItemCount", 0);
			LHEDLDEMPPG_IsNewScene = JsonUtil.GetInt(OBHAFLMHAKG, "isNewScene", 0) != 0;
			PHJHJGDLPED_IsRareDrop = JsonUtil.GetInt(OBHAFLMHAKG, "isRareDrop", 0) != 0;
		}

		// // RVA: 0x201C31C Offset: 0x201C31C VA: 0x201C31C
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.ABBBCBIHMFE_DropItem ILEKEPJBFDP, ILDKBCLAFPB.ABBBCBIHMFE_DropItem GEPALDIIDPC) { }

		// // RVA: 0x201C490 Offset: 0x201C490 VA: 0x201C490
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.ABBBCBIHMFE_DropItem ILEKEPJBFDP, ILDKBCLAFPB.ABBBCBIHMFE_DropItem GEPALDIIDPC) { }

		// // RVA: 0x201C4A4 Offset: 0x201C4A4 VA: 0x201C4A4
		// public void ODDIHGPONFL_Copy(ILDKBCLAFPB.ABBBCBIHMFE_DropItem FMKAONAMGCN) { }
	}

	public class GCLIKCLDDKG_PlayerData
	{
		public ILDKBCLAFPB.KKNFJMEBONI_SceneData PNLOINMCCKH = new ILDKBCLAFPB.KKNFJMEBONI_SceneData(); // 0x8
		public ILDKBCLAFPB.BEBBCJLDOFF_DivaData DGCJCAHIAPP = new ILDKBCLAFPB.BEBBCJLDOFF_DivaData(); // 0xC
		public CEBFFLDKAEC NMDKKAAOIOI_LastBaseUnionCredit = new CEBFFLDKAEC(); // 0x10
		public CEBFFLDKAEC MJKFDDKLLFP_LastDropUnionCredit = new CEBFFLDKAEC(); // 0x14
		public int GCAPLLEIAAI_LastScore; // 0x18
		public int GPMILOPNBPA_LastScoreExcellent; // 0x1C
		public int PBGLMBMEKAA_LastCombo; // 0x20
		public int CODDMAKLBDO_LastComboRank; // 0x24
		public int IKBLCEFCGDE_LastLuck; // 0x28
		public List<ILDKBCLAFPB.ABBBCBIHMFE_DropItem> KKAOCDKGJHJ_DropItems = new List<ILDKBCLAFPB.ABBBCBIHMFE_DropItem>(); // 0x2C
		public int[] ODIGNDEKCGA_NoteResultCount = new int[5]; // 0x30
		public CEBFFLDKAEC KELFCMEOPPM_EpisodeId = new CEBFFLDKAEC(); // 0x34
		public long BENGJHEDCAK_EpisodeDate; // 0x38

		// RVA: 0x2026D28 Offset: 0x2026D28 VA: 0x2026D28
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x2027660 Offset: 0x2027660 VA: 0x2027660
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "lastBaseUnionCredit", 0);
			MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "lastDropUnionCredit", 0);
			GCAPLLEIAAI_LastScore = JsonUtil.GetInt(OBHAFLMHAKG, "lastScore", 0);
			GPMILOPNBPA_LastScoreExcellent = JsonUtil.GetInt(OBHAFLMHAKG, "lastScoreExcellent", 0);
			PBGLMBMEKAA_LastCombo = JsonUtil.GetInt(OBHAFLMHAKG, "lastCombo", 0);
			CODDMAKLBDO_LastComboRank = JsonUtil.GetInt(OBHAFLMHAKG, "lastComboRank", 0);
			IKBLCEFCGDE_LastLuck = JsonUtil.GetInt(OBHAFLMHAKG, "lastLuck", 0);
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("sceneData"))
			{
				PNLOINMCCKH.KHEKNNFCAOI_Init(OBHAFLMHAKG["sceneData"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("divaData"))
			{
				DGCJCAHIAPP.KHEKNNFCAOI_Init(OBHAFLMHAKG["divaData"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("dropItem"))
			{
				KKAOCDKGJHJ_DropItems = new List<ILDKBCLAFPB.ABBBCBIHMFE_DropItem>();
				for(int i = 0; i < OBHAFLMHAKG["dropItem"].HNBFOAJIIAL_Count; i++)
				{
					ILDKBCLAFPB.ABBBCBIHMFE_DropItem dropItem = new ILDKBCLAFPB.ABBBCBIHMFE_DropItem();
					dropItem.KHEKNNFCAOI_Init(OBHAFLMHAKG["dropItem"][i]);
					KKAOCDKGJHJ_DropItems.Add(dropItem);
				}
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("notesResultCount"))
			{
				for(int i = 0; i < OBHAFLMHAKG["notesResultCount"].HNBFOAJIIAL_Count; i++)
				{
					ODIGNDEKCGA_NoteResultCount[i] = JsonUtil.GetInt(OBHAFLMHAKG["notesResultCount"][i]);
				}
			}
			KELFCMEOPPM_EpisodeId.DNJEJEANJGL = JsonUtil.GetInt(OBHAFLMHAKG, "episodeId", 0);
			BENGJHEDCAK_EpisodeDate = JsonUtil.GetLong(OBHAFLMHAKG, "episodeDate", 0);
		}

		// // RVA: 0x202A99C Offset: 0x202A99C VA: 0x202A99C
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.GCLIKCLDDKG ILEKEPJBFDP, ILDKBCLAFPB.GCLIKCLDDKG GEPALDIIDPC) { }

		// // RVA: 0x202651C Offset: 0x202651C VA: 0x202651C
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.GCLIKCLDDKG ILEKEPJBFDP, ILDKBCLAFPB.GCLIKCLDDKG GEPALDIIDPC) { }

		// // RVA: 0x20266A8 Offset: 0x20266A8 VA: 0x20266A8
		// public void ODDIHGPONFL_Copy(ILDKBCLAFPB.GCLIKCLDDKG CHOFCBBPDCH) { }

		// // RVA: 0x2027C00 Offset: 0x2027C00 VA: 0x2027C00
		// public void INBCGKAFHDO(BBHNACPENDM AHEFHIMGIBI) { }

		// // RVA: 0x202AE10 Offset: 0x202AE10 VA: 0x202AE10
		// public void MFNPKIACGLM(JGEOBNENMAH FDOODGBBKEE, BBHNACPENDM AHEFHIMGIBI, GameSetupData KCMGEINBEFO, GameResultData HHPEADPLPKG) { }

		// // RVA: 0x20289CC Offset: 0x20289CC VA: 0x20289CC
		// public void MNGKOHKKAHI(BBHNACPENDM AHEFHIMGIBI) { }

		// // RVA: 0x202B594 Offset: 0x202B594 VA: 0x202B594
		// public void EJFNMIFOFME(JGEOBNENMAH FDOODGBBKEE, BBHNACPENDM AHEFHIMGIBI, GameSetupData KCMGEINBEFO, GameResultData HHPEADPLPKG) { }

		// // RVA: 0x2028F7C Offset: 0x2028F7C VA: 0x2028F7C
		// public FENCAJJBLBH KPOCKNCJBPN() { }
	}
	
	public class BKLCILHFCGB_Flags
	{
		private int[] KGMLFAFPOKP = new int[0]; // 0x8

		// RVA: 0x20254B4 Offset: 0x20254B4 VA: 0x20254B4
		public BKLCILHFCGB_Flags(int KOFKCJOHHOC)
		{
			KGMLFAFPOKP = new int[(KOFKCJOHHOC + 0x1f) >> 5];
		}

		// // RVA: 0x201BA98 Offset: 0x201BA98 VA: 0x201BA98
		// public bool ODKIHPBEOEC(int PPFNGGCBJKC) { }

		// // RVA: 0x2025540 Offset: 0x2025540 VA: 0x2025540
		// public bool LANDKPMJEFB(int PPFNGGCBJKC) { }

		// // RVA: 0x201BAF8 Offset: 0x201BAF8 VA: 0x201BAF8
		// public void EDEDFDDIOKO(int PPFNGGCBJKC) { }

		// // RVA: 0x2025554 Offset: 0x2025554 VA: 0x2025554
		// public void GIBNLEBILNO(int PPFNGGCBJKC) { }

		// // RVA: 0x20255B0 Offset: 0x20255B0 VA: 0x20255B0
		// public void JCHLONCMPAJ() { }

		// // RVA: 0x2025628 Offset: 0x2025628 VA: 0x2025628
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			for(int i = 0; i < KGMLFAFPOKP.Length; i++)
			{
				KGMLFAFPOKP[i] = JsonUtil.GetInt(OBHAFLMHAKG[i]);
			}
		}

		// // RVA: 0x20256F0 Offset: 0x20256F0 VA: 0x20256F0
		// public EDOHBJAPLPF NOJCMGAFAAC() { }

		// // RVA: 0x2025810 Offset: 0x2025810 VA: 0x2025810
		// public static bool CHDGLBBFEKH(ILDKBCLAFPB.BKLCILHFCGB_Flags ILEKEPJBFDP, ILDKBCLAFPB.BKLCILHFCGB_Flags GEPALDIIDPC) { }

		// // RVA: 0x2025928 Offset: 0x2025928 VA: 0x2025928
		// public static bool HMMFJOEBEKJ(ILDKBCLAFPB.BKLCILHFCGB_Flags ILEKEPJBFDP, ILDKBCLAFPB.BKLCILHFCGB_Flags GEPALDIIDPC) { }

		// // RVA: 0x202593C Offset: 0x202593C VA: 0x202593C
		// public void ODDIHGPONFL_Copy(ILDKBCLAFPB.BKLCILHFCGB_Flags CHOFCBBPDCH) { }

		// // RVA: 0x201BA70 Offset: 0x201BA70 VA: 0x201BA70
		// public int BCGHBIMJOFP() { }
	}

    public class DNLECGEBDOI_Tutorial
    {
        public int OLDAGCNLJOI_Progress; // 0x8
        public int CEMEIPNMAAD_Version; // 0xC
        public long KINJOEIAHFK_StartTime; // 0x10
        public int PPOJCDCCFNI_TutorialEnd; // 0x18
        public int NJFNCNCJMOO_FirstLogin; // 0x1C
        public ILDKBCLAFPB.GCLIKCLDDKG_PlayerData AHEFHIMGIBI = new ILDKBCLAFPB.GCLIKCLDDKG_PlayerData(); // 0x20
        public ILDKBCLAFPB.BKLCILHFCGB_Flags INEAGJMJLFG_TutorialAlreadyFlags = new ILDKBCLAFPB.BKLCILHFCGB_Flags(128); // 0x24
        public ILDKBCLAFPB.BKLCILHFCGB_Flags PNNHEOOJBFI_TutorialGeneralFlags = new ILDKBCLAFPB.BKLCILHFCGB_Flags(32); // 0x28
        public int JKHNILLPKBO_LCnt; // 0x2C
        public int HLKKGIKPLOM_LDay; // 0x30

        // // RVA: 0x2026434 Offset: 0x2026434 VA: 0x2026434
        // public static bool CHDGLBBFEKH(ILDKBCLAFPB.DNLECGEBDOI_Tutorial ILEKEPJBFDP, ILDKBCLAFPB.DNLECGEBDOI_Tutorial GEPALDIIDPC) { }

        // // RVA: 0x2026530 Offset: 0x2026530 VA: 0x2026530
        // public static bool HMMFJOEBEKJ(ILDKBCLAFPB.DNLECGEBDOI_Tutorial ILEKEPJBFDP, ILDKBCLAFPB.DNLECGEBDOI_Tutorial GEPALDIIDPC) { }

        // // RVA: 0x2026544 Offset: 0x2026544 VA: 0x2026544
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.DNLECGEBDOI_Tutorial FMKAONAMGCN)
		{
			TodoLogger.Log(0, "SaveCopy");
		}

        // // RVA: 0x20269E4 Offset: 0x20269E4 VA: 0x20269E4
        // public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }

        // // RVA: 0x2027374 Offset: 0x2027374 VA: 0x2027374
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			OLDAGCNLJOI_Progress = JsonUtil.GetInt(OBHAFLMHAKG, "progress", 0);
			CEMEIPNMAAD_Version = JsonUtil.GetInt(OBHAFLMHAKG, "veriosn", 0);
			KINJOEIAHFK_StartTime = JsonUtil.GetInt(OBHAFLMHAKG, "startTime", 0);
			PPOJCDCCFNI_TutorialEnd = JsonUtil.GetInt(OBHAFLMHAKG, "tutorialEnd", 0);
			NJFNCNCJMOO_FirstLogin = JsonUtil.GetInt(OBHAFLMHAKG, "firstLogin", 0);
			JKHNILLPKBO_LCnt = JsonUtil.GetInt(OBHAFLMHAKG, "lcnt", 0);
			HLKKGIKPLOM_LDay = JsonUtil.GetInt(OBHAFLMHAKG, "lday", 0);
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("playerData"))
			{
				AHEFHIMGIBI.KHEKNNFCAOI_Init(OBHAFLMHAKG["playerData"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("tutorialAlreadyFlags"))
			{
				INEAGJMJLFG_TutorialAlreadyFlags.KHEKNNFCAOI_Init(OBHAFLMHAKG["tutorialAlreadyFlags"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("tutorialGeneralFlags"))
			{
				PNNHEOOJBFI_TutorialGeneralFlags.KHEKNNFCAOI_Init(OBHAFLMHAKG["tutorialGeneralFlags"]);
			}
		}

        // // RVA: 0x2027BD0 Offset: 0x2027BD0 VA: 0x2027BD0
        // public void INBCGKAFHDO(BBHNACPENDM AHEFHIMGIBI) { }

        // // RVA: 0x202899C Offset: 0x202899C VA: 0x202899C
        // public void LFNEPDFBINM(BBHNACPENDM AHEFHIMGIBI) { }

        // // RVA: 0x2028F6C Offset: 0x2028F6C VA: 0x2028F6C
        // public void DGMFOHADMHN(ILDKBCLAFPB.CDIPJNPICCO FOFFPCGACMF) { }

        // // RVA: 0x2028F74 Offset: 0x2028F74 VA: 0x2028F74
        // public ILDKBCLAFPB.CDIPJNPICCO KMKIGHHCAGE() { }

        // // RVA: 0x201B2EC Offset: 0x201B2EC VA: 0x201B2EC
        // public FENCAJJBLBH KPOCKNCJBPN() { }
    }

	public class IJDOCJCLAIL_SortProprty
	{
		public class CLBMCCEEDGE_VerticalMusicSelect
		{
			public int EOCPIGDIFNB_MusicAttrFilterBits = 0; // 0x8
			public int JJNLEPEKNDO_ComboFilterBits = 0; // 0xC
			public int PGMJCBIHNHK_RewardFilterBits = 0; // 0x10
			public int DPDBMECAIIO_NumUnitsFilterBits = 0; // 0x14
			public int GONLKIDILLH_BookmarkIndex = 0; // 0x18
			public int AONOGHPAENH_filterMusicUnLock = 0; // 0x1C
			public int ALGFGPCPGFK_filterRange = 0; // 0x20
			public int LHPDCGNKPHD_sortItem = 40; // 0x24

			// RVA: 0x20317C0 Offset: 0x20317C0 VA: 0x20317C0
			public CLBMCCEEDGE_VerticalMusicSelect()
			{
				return;
			}

			//// RVA: 0x20319B0 Offset: 0x20319B0 VA: 0x20319B0
			//public void .ctor(int EOCPIGDIFNB, int JJNLEPEKNDO, int PGMJCBIHNHK, int DPDBMECAIIO, int AONOGHPAENH, int ALGFGPCPGFK, int GONLKIDILLH, int LHPDCGNKPHD) { }

			//// RVA: 0x2031990 Offset: 0x2031990 VA: 0x2031990
			//public void LHPDDGIJKNB() { }

			//// RVA: 0x202D040 Offset: 0x202D040 VA: 0x202D040
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.CLBMCCEEDGE DNNHDJPNIAK) { }

			//// RVA: 0x2030C14 Offset: 0x2030C14 VA: 0x2030C14
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0, int JNGOCAGJGDN = 0, int MKICPACJHGE = 40)
			{
				EOCPIGDIFNB_MusicAttrFilterBits = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicAttr", CIDINFCADGB);
				JJNLEPEKNDO_ComboFilterBits = JsonUtil.GetInt(OBHAFLMHAKG, "filterCombo", CIDINFCADGB);
				PGMJCBIHNHK_RewardFilterBits = JsonUtil.GetInt(OBHAFLMHAKG, "filterReward", CIDINFCADGB);
				DPDBMECAIIO_NumUnitsFilterBits = JsonUtil.GetInt(OBHAFLMHAKG, "filterUnit", CIDINFCADGB);
				GONLKIDILLH_BookmarkIndex = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicBookMark", CIDINFCADGB);
				AONOGHPAENH_filterMusicUnLock = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicUnLock", CIDINFCADGB);
				ALGFGPCPGFK_filterRange = JsonUtil.GetInt(OBHAFLMHAKG, "filterRange", CIDINFCADGB);
				LHPDCGNKPHD_sortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sortItem", JNGOCAGJGDN);
			}

			//// RVA: 0x202ECC8 Offset: 0x202ECC8 VA: 0x202ECC8
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031A08 Offset: 0x2031A08 VA: 0x2031A08
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.CLBMCCEEDGE ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.CLBMCCEEDGE GEPALDIIDPC) { }

			//// RVA: 0x202C5FC Offset: 0x202C5FC VA: 0x202C5FC
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.CLBMCCEEDGE ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.CLBMCCEEDGE GEPALDIIDPC) { }
		}

		public class MMALELPFEBH_UserList
		{
			public int LHPDCGNKPHD_sortItem; // 0x8
			public int NPEEPPCPEPE_assistItem; // 0xC
			public int ACCHOFLOOEC_filter; // 0x10
			public int BOFFOHHLLFG_attributeFilter; // 0x14
			public int BBIIHLNBHDE_seriaseFilter; // 0x18
			public int LKPCKPJGJKN_centerSkillFilter; // 0x1C
			public int EILKGEADKGH_order; // 0x20

			// RVA: 0x203204C Offset: 0x203204C VA: 0x203204C
			public MMALELPFEBH_UserList()
			{
				return;
			}

			//// RVA: 0x2031710 Offset: 0x2031710 VA: 0x2031710
			//public void .ctor(int LHPDCGNKPHD, int NPEEPPCPEPE, int ACCHOFLOOEC, int BOFFOHHLLFG, int BBIIHLNBHDE, int LKPCKPJGJKN, int EILKGEADKGH) { }

			//// RVA: 0x202CD38 Offset: 0x202CD38 VA: 0x202CD38
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH DNNHDJPNIAK) { }

			// RVA: 0x203076C Offset: 0x203076C VA: 0x203076C
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0, int DOOPCGHMICD = 0)
			{
				LHPDCGNKPHD_sortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sortItem", CIDINFCADGB);
				NPEEPPCPEPE_assistItem = JsonUtil.GetInt(OBHAFLMHAKG, "assistItem", DOOPCGHMICD);
				ACCHOFLOOEC_filter = JsonUtil.GetInt(OBHAFLMHAKG, "filter");
				BOFFOHHLLFG_attributeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "attributeFilter");
				BBIIHLNBHDE_seriaseFilter = JsonUtil.GetInt(OBHAFLMHAKG, "seriaseFilter");
				LKPCKPJGJKN_centerSkillFilter = JsonUtil.GetInt(OBHAFLMHAKG, "centerSkillFilter");
				EILKGEADKGH_order = JsonUtil.GetInt(OBHAFLMHAKG, "order");
			}

			// RVA: 0x202E468 Offset: 0x202E468 VA: 0x202E468
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2032054 Offset: 0x2032054 VA: 0x2032054
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH GEPALDIIDPC) { }

			//// RVA: 0x202C598 Offset: 0x202C598 VA: 0x202C598
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH GEPALDIIDPC) { }
		}
		
		public class BNIKLNDKMEO_EpisodeSelect
		{
			public int LHPDCGNKPHD_sortItem = 26; // 0x8
			public int EILKGEADKGH_order; // 0xC
			public int CNGFLNMNIMJ_filterMainEp; // 0x10
			public int JFOPNJOOGNI_filterSeriese; // 0x14
			public int IKEMMEAEPLM_filterDivaAndVal; // 0x18

			// RVA: 0x2031758 Offset: 0x2031758 VA: 0x2031758
			public BNIKLNDKMEO_EpisodeSelect()
			{
				return;
			}

			//// RVA: 0x20318B4 Offset: 0x20318B4 VA: 0x20318B4
			//public void .ctor(int LHPDCGNKPHD, int EILKGEADKGH, int CNGFLNMNIMJ, int IKEMMEAEPLM, int JFOPNJOOGNI) { }

			//// RVA: 0x202CE10 Offset: 0x202CE10 VA: 0x202CE10
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.BNIKLNDKMEO DNNHDJPNIAK) { }

			// RVA: 0x20308AC Offset: 0x20308AC VA: 0x20308AC
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 26)
			{
				LHPDCGNKPHD_sortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sortItem", CIDINFCADGB);
				EILKGEADKGH_order = JsonUtil.GetInt(OBHAFLMHAKG, "order");
				CNGFLNMNIMJ_filterMainEp = JsonUtil.GetInt(OBHAFLMHAKG, "filterMainEp", 0);
				IKEMMEAEPLM_filterDivaAndVal = JsonUtil.GetInt(OBHAFLMHAKG, "filterDivaAndVal", 0);
				JFOPNJOOGNI_filterSeriese = JsonUtil.GetInt(OBHAFLMHAKG, "filterSeriese", 0);
			}

			//// RVA: 0x202E6BC Offset: 0x202E6BC VA: 0x202E6BC
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031900 Offset: 0x2031900 VA: 0x2031900
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.BNIKLNDKMEO ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.BNIKLNDKMEO GEPALDIIDPC) { }

			//// RVA: 0x202C5AC Offset: 0x202C5AC VA: 0x202C5AC
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.BNIKLNDKMEO ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.BNIKLNDKMEO GEPALDIIDPC) { }
		}
		
		public class PFONKAHHKJK_Raid
		{
			public int LHPDCGNKPHD_sortItem; // 0x8
			public int AOKFAJOMCKK_bossFilter; // 0xC
			public int MOAJJHLGILP_rankFilter; // 0x10
			public int COIKKDHMGID_joinFilter; // 0x14
			public int EILKGEADKGH_order = 1; // 0x18

			// RVA: 0x2031768 Offset: 0x2031768 VA: 0x2031768
			public PFONKAHHKJK_Raid()
			{
				return;
			}

			//// RVA: 0x2032104 Offset: 0x2032104 VA: 0x2032104
			//public void .ctor(int LHPDCGNKPHD, int AOKFAJOMCKK, int MOAJJHLGILP, int COIKKDHMGID, int EILKGEADKGH) { }

			//// RVA: 0x202CEB0 Offset: 0x202CEB0 VA: 0x202CEB0
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.PFONKAHHKJK DNNHDJPNIAK) { }

			// RVA: 0x20309B0 Offset: 0x20309B0 VA: 0x20309B0
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				LHPDCGNKPHD_sortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sortItem", CIDINFCADGB);
				AOKFAJOMCKK_bossFilter = JsonUtil.GetInt(OBHAFLMHAKG, "bossFilter", CIDINFCADGB);
				MOAJJHLGILP_rankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "rankFilter", CIDINFCADGB);
				COIKKDHMGID_joinFilter = JsonUtil.GetInt(OBHAFLMHAKG, "joinFilter", CIDINFCADGB);
				EILKGEADKGH_order = JsonUtil.GetInt(OBHAFLMHAKG, "order");
			}

			//// RVA: 0x202E890 Offset: 0x202E890 VA: 0x202E890
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2032150 Offset: 0x2032150 VA: 0x2032150
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.PFONKAHHKJK ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.PFONKAHHKJK GEPALDIIDPC) { }

			//// RVA: 0x202C5C0 Offset: 0x202C5C0 VA: 0x202C5C0
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.PFONKAHHKJK ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.PFONKAHHKJK GEPALDIIDPC) { }
		}
		public class LPNOICEBNEL_MusicSelect
		{
			private int FBGGEFFJJHB = 0x2511a53e; // 0x8
			public int EOCPIGDIFNB = 0; // 0xC
			public int JJNLEPEKNDO = 0; // 0x10
			public int JGOJDHFAHHE = 0; // 0x14
			public int PGMJCBIHNHK = 0; // 0x18
			public int DPDBMECAIIO = 0; // 0x1C
			private int OOJKCGDIPIH = 0x2511a53e; // 0x20
			private int CPBHIHNOIHB = 0x2511a53e; // 0x24

			//public int KHAJGNDEPMG { get; set; } 0x2031E08 MLGBACGCCEA 0x2031E18 OHHKCBNKFHD
			//public int IKFKKJLBBBN { get; set; } 0x2031E28 FCGLOBJNLLH 0x2031E38 CPIMGEMMJJE

			// RVA: 0x2031778 Offset: 0x2031778 VA: 0x2031778
			public LPNOICEBNEL_MusicSelect()
			{
				return;
			}

			//// RVA: 0x2031E6C Offset: 0x2031E6C VA: 0x2031E6C
			//public void .ctor(int EOCPIGDIFNB, int JJNLEPEKNDO, int JGOJDHFAHHE, int PGMJCBIHNHK, int DPDBMECAIIO, int KHAJGNDEPMG, int IKFKKJLBBBN) { }

			//// RVA: 0x2031E48 Offset: 0x2031E48 VA: 0x2031E48
			//public void LHPDDGIJKNB() { }

			//// RVA: 0x202CF50 Offset: 0x202CF50 VA: 0x202CF50
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.LPNOICEBNEL DNNHDJPNIAK) { }

			// RVA: 0x2030AB4 Offset: 0x2030AB4 VA: 0x2030AB4
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				TodoLogger.Log(0, "LPNOICEBNEL_MusicSelect KHEKNNFCAOI");
			}

			//// RVA: 0x202EA64 Offset: 0x202EA64 VA: 0x202EA64
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031ED8 Offset: 0x2031ED8 VA: 0x2031ED8
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.LPNOICEBNEL ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.LPNOICEBNEL GEPALDIIDPC) { }

			//// RVA: 0x202C5E8 Offset: 0x202C5E8 VA: 0x202C5E8
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.LPNOICEBNEL ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.LPNOICEBNEL GEPALDIIDPC) { }
		}
		public class KLIBOIEIMBA_EventMission
		{
			private int FBGGEFFJJHB = 0x2151a53e; // 0x8
			public int EOCPIGDIFNB = 0; // 0xC
			public int JJNLEPEKNDO = 0; // 0x10
			public int JGOJDHFAHHE = 0; // 0x14
			public int PGMJCBIHNHK = 0; // 0x18
			public int DPDBMECAIIO = 0; // 0x1C
			private int OOJKCGDIPIH = 0x2151a53e; // 0x20
			private int CPBHIHNOIHB = 0x2151a53e; // 0x24
			public int GMMPGHKIDEK = 0; // 0x28

			//public int KHAJGNDEPMG { get; set; } 0x2031C58 MLGBACGCCEA 0x2031C68 OHHKCBNKFHD
			//public int IKFKKJLBBBN { get; set; } 0x2031C78 FCGLOBJNLLH 0x2031C88 CPIMGEMMJJE

			// RVA: 0x20317F8 Offset: 0x20317F8 VA: 0x20317F8
			public KLIBOIEIMBA_EventMission()
			{
				return;
			}

			//// RVA: 0x2031CC0 Offset: 0x2031CC0 VA: 0x2031CC0
			//public void .ctor(int EOCPIGDIFNB, int JJNLEPEKNDO, int JGOJDHFAHHE, int PGMJCBIHNHK, int DPDBMECAIIO, int KHAJGNDEPMG, int IKFKKJLBBBN, int LKCFBAIOPIK) { }

			//// RVA: 0x2031C98 Offset: 0x2031C98 VA: 0x2031C98
			//public void LHPDDGIJKNB() { }

			//// RVA: 0x202D22C Offset: 0x202D22C VA: 0x202D22C
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.KLIBOIEIMBA DNNHDJPNIAK) { }

			// RVA: 0x2030EEC Offset: 0x2030EEC VA: 0x2030EEC
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				TodoLogger.Log(0, "KLIBOIEIMBA_EventMission KHEKNNFCAOI");
			}

			//// RVA: 0x202F1C0 Offset: 0x202F1C0 VA: 0x202F1C0
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031D30 Offset: 0x2031D30 VA: 0x2031D30
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.KLIBOIEIMBA ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.KLIBOIEIMBA GEPALDIIDPC) { }

			//// RVA: 0x202C610 Offset: 0x202C610 VA: 0x202C610
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.KLIBOIEIMBA ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.KLIBOIEIMBA GEPALDIIDPC) { }
		}
		
		public class FPMABHADHBB_EventGoDiva
		{
			private int FBGGEFFJJHB = 0x1215a53e; // 0x8
			public int EOCPIGDIFNB = 0; // 0xC
			public int JJNLEPEKNDO = 0; // 0x10
			public int JGOJDHFAHHE = 0; // 0x14
			public int PGMJCBIHNHK = 0; // 0x18
			private int OOJKCGDIPIH = 0x1215a53e; // 0x1C
			private int CPBHIHNOIHB = 0x1215a53e; // 0x20
			public int MENIBLFBNLC = 0; // 0x24

			//public int KHAJGNDEPMG { get; set; } 0x2031AC8 MLGBACGCCEA 0x2031AD8 OHHKCBNKFHD
			//public int IKFKKJLBBBN { get; set; } 0x2031AE8 FCGLOBJNLLH 0x2031AF8 CPIMGEMMJJE

			// RVA: 0x2031844 Offset: 0x2031844 VA: 0x2031844
			public FPMABHADHBB_EventGoDiva()
			{
				return;
			}

			//// RVA: 0x2031B2C Offset: 0x2031B2C VA: 0x2031B2C
			//public void .ctor(int EOCPIGDIFNB, int JJNLEPEKNDO, int JGOJDHFAHHE, int PGMJCBIHNHK, int DPDBMECAIIO, int KHAJGNDEPMG, int IKFKKJLBBBN, int MENIBLFBNLC) { }

			//// RVA: 0x2031B08 Offset: 0x2031B08 VA: 0x2031B08
			//public void LHPDDGIJKNB() { }

			//// RVA: 0x202D134 Offset: 0x202D134 VA: 0x202D134
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.FPMABHADHBB DNNHDJPNIAK) { }

			// RVA: 0x2030D8C Offset: 0x2030D8C VA: 0x2030D8C
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				TodoLogger.Log(0, "FPMABHADHBB_EventGoDiva KHEKNNFCAOI");
			}

			//// RVA: 0x202EF5C Offset: 0x202EF5C VA: 0x202EF5C
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031B90 Offset: 0x2031B90 VA: 0x2031B90
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.FPMABHADHBB ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.FPMABHADHBB GEPALDIIDPC) { }

			//// RVA: 0x202C5D4 Offset: 0x202C5D4 VA: 0x202C5D4
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.FPMABHADHBB ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.FPMABHADHBB GEPALDIIDPC) { }
		}
		
		public class MCINLGMJPDM_SelectHomeBG
		{
			public int EILKGEADKGH = 1; // 0x8
			public int PLNMMHPILLO; // 0xC
			public int HBEFGKLLMEC; // 0x10

			// RVA: 0x203188C Offset: 0x203188C VA: 0x203188C
			public MCINLGMJPDM_SelectHomeBG()
			{
				return;
			}

			// RVA: 0x2031FA0 Offset: 0x2031FA0 VA: 0x2031FA0
			//public void .ctor(int EILKGEADKGH, int PLNMMHPILLO, int HBEFGKLLMEC) { }

			//// RVA: 0x202D340 Offset: 0x202D340 VA: 0x202D340
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.MCINLGMJPDM PKBAJMCNIHP) { }

			// RVA: 0x2031070 Offset: 0x2031070 VA: 0x2031070
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				TodoLogger.Log(0, "MCINLGMJPDM_SelectHomeBG KHEKNNFCAOI");
			}

			//// RVA: 0x202F464 Offset: 0x202F464 VA: 0x202F464
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			//// RVA: 0x2031FDC Offset: 0x2031FDC VA: 0x2031FDC
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.MCINLGMJPDM ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.MCINLGMJPDM GEPALDIIDPC) { }

			//// RVA: 0x202C624 Offset: 0x202C624 VA: 0x202C624
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.MCINLGMJPDM ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.MCINLGMJPDM GEPALDIIDPC) { }
		}
		public class POCEANNLGLP_ShopProduct
		{
			public int LHPDCGNKPHD = 5; // 0x8
			public int MLMHPBOKJCL = 1; // 0xC
			public int EGBPCFOGOCK; // 0x10
			public int ACCHOFLOOEC; // 0x14
			public int BOFFOHHLLFG; // 0x18
			public int BBIIHLNBHDE; // 0x1C
			public int ABLBLOEKBKA; // 0x20
			public int OAJNACDACDF; // 0x24
			public int PFNPLBNHDJK; // 0x28
			public int DNLJMMBEKAA; // 0x2C
			public int EAPCPNGAPBB; // 0x30
			public int NLLEDCOAPIG; // 0x34
			public long LKPCKPJGJKN; // 0x38
			public long LACACEBKHCM; // 0x40
			public long PPEFJBBGGHI; // 0x48

			//// RVA: 0x20321E0 Offset: 0x20321E0 VA: 0x20321E0
			//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL.POCEANNLGLP ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.POCEANNLGLP GEPALDIIDPC) { }

			//// RVA: 0x202C638 Offset: 0x202C638 VA: 0x202C638
			//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL.POCEANNLGLP ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL.POCEANNLGLP GEPALDIIDPC) { }

			//// RVA: 0x202D3A8 Offset: 0x202D3A8 VA: 0x202D3A8
			//public void ODDIHGPONFL(ILDKBCLAFPB.IJDOCJCLAIL.POCEANNLGLP FMKAONAMGCN) { }

			//// RVA: 0x202F5B8 Offset: 0x202F5B8 VA: 0x202F5B8
			//public EDOHBJAPLPF NOJCMGAFAAC() { }

			// RVA: 0x2031128 Offset: 0x2031128 VA: 0x2031128
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				TodoLogger.Log(0, "POCEANNLGLP_ShopProduct KHEKNNFCAOI");
			}
		}

		public const int FOKMKPFDGGN = 6;
		public const int LKDNPPDPNND = 6;
		public const int HKEFMGOABPN = 6;
		public const int GDEKKBEPDHH = 6;
		public const int ILBBADJFMCB = 5;
		public const int HKIDNFCKDMH = 6;
		public const int JLPCBCLGLJL = 6;
		public const int CLACPOPLEBI = 6;
		public const int EGMCCBNBEND = 6;
		public const int MFNHHEFOBBE = 6;
		public const int PIDNFAFBJFB = 6;
		public const int NPANJCIHJOB = 6;
		public int LNFFKCDNCPN_sceneSelectSortItem = 6; // 0x8
		public int GEAECNMDMHH_sceneListSortItem = 6; // 0xC
		public int NCDOLBOHGFN_sceneAssistSortItem = 6; // 0x10
		public int ONPAMDMIEKM_divaSortItem = 6; // 0x14
		public int CIDJJBFGHIE_sceneSelectSortOrder = 1; // 0x18
		public int CLKCCJJJPLB_sceneListSortOrder = 1; // 0x1C
		public int OGFJPNKICGI_sceneAssistSortOrder = 1; // 0x20
		public int HNGHNBNPCHO_divaSortOrder = 1; // 0x24
		public int MDJMAEEONKK_costumeSortItem = 6; // 0x28
		public int LEAPMNHODPJ_unitWindowDispItem = 6; // 0x2C
		public int BICLOMKLAOF_unitWindowDivaDispItem = 6; // 0x30
		public int FFAKMECDMFC_sceneSelectRarityFilter; // 0x34
		public int LMPKAPBCIFD_sceneSelectAttributeFilter; // 0x38
		public int MNNCLIFBAOA_sceneSelectSeriaseFilter; // 0x3C
		public int NPFGKBKKCFL_sceneSelectCompatibleFilter; // 0x40
		public int JACFDEKLDCK_isCompatibleDivaCheck; // 0x44
		public int HMJNAGNIEJB_sceneListRarityFilter; // 0x48
		public int HFGAILIOFAN_sceneListAttributeFilter; // 0x4C
		public int AKFPHKLCHAA_sceneListSeriaseFilter; // 0x50
		public int PHCEMKLNJLH_sceneListCompatibleFilter; // 0x54
		public int OFFBGLDDBHC_sceneAssistAttributeFilter; // 0x58
		public int POPIEDDJGBA_sceneAssistSeriaseFilter; // 0x5C
		public int GJFPKDOBIPH_sceneAssistCenterSkillFilter; // 0x60
		public int MOOHKFCHJPO_shopListSeriaseFilter; // 0x64
		public int PJDCJKHMNNM_interiorListFilter; // 0x68
		public int IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter; // 0x6C
		public int BPFPFOJNFLC_sceneSelectCenterSkillRankFilter; // 0x70
		public int BIBBAIFCGLD_sceneSelectActiveSkillRankFilter; // 0x74
		public int AIPJDIPBDEA_sceneSelectLiveSkillRankFilter; // 0x78
		public long IHECEFMGKHO_sceneSelectCenterSkillFilter; // 0x80
		public long POJHGOJDOND_sceneSelectActiveSkillFilter; // 0x88
		public long OCKOEPFNGJG_sceneSelectLiveSkillFilter; // 0x90
		public int LALFKJDFPOD_sceneListLiveSkillRangeFilter; // 0x98
		public int MECEGIJIGBN_sceneListCenterSkillRankFilter; // 0x9C
		public int ALFGELGDIGC_sceneListActiveSkillRankFilter; // 0xA0
		public int HKFPBAFALHO_sceneListLiveSkillRankFilter; // 0xA4
		public long IOBABMJPAAE_sceneListCenterSkillFilter; // 0xA8
		public long GIPNFAFFNLF_sceneListActiveSkillFilter; // 0xB0
		public long BOMCDAIEFLN_sceneListLiveSkillFilter; // 0xB8
		public int DPFFNBOKKAO; // 0xC0
		public int DMKHBHDGABG_sceneSelectNotesExpectedFilter; // 0xC4
		public int MCJBFHMJECO_sceneListNotesExpectedFilter; // 0xC8
		public const int NLEANNODJBG = 0;
		public const int PJMPHFNDLJI = 0;
		public const int LGKAAIINKPJ = 0;
		public const int OKELEINFMKG = 0;
		public const int BOIHPEFBLDK = 0;
		public const int CALABBMDEHI = 0;
		public const int FDGMELIHCLK = 0;
		public MMALELPFEBH_UserList IDFGCPNELIA_FriendList = new MMALELPFEBH_UserList(); // 0xCC
		public MMALELPFEBH_UserList GDMIGCCMEEF_GuestSelect = new MMALELPFEBH_UserList(); // 0xD0
		public MMALELPFEBH_UserList EJAJGGKHALM_SentRequestList = new MMALELPFEBH_UserList(); // 0xD4
		public MMALELPFEBH_UserList DOKBEPGKNJK_PendingList = new MMALELPFEBH_UserList(); // 0xD8
		//public ILDKBCLAFPB.IJDOCJCLAIL.MMALELPFEBH ACCNCHJBDHM = new MMALELPFEBH(); // 0xDC
		public BNIKLNDKMEO_EpisodeSelect CEJNPBFIIMJ_EpisodeSelect = new BNIKLNDKMEO_EpisodeSelect(); // 0xE0
		public PFONKAHHKJK_Raid JGAFBCMOGLP_Raid = new PFONKAHHKJK_Raid(); // 0xE4
		public LPNOICEBNEL_MusicSelect KGDILGLNKFM_MusicSelect = new LPNOICEBNEL_MusicSelect(); // 0xE8
		public CLBMCCEEDGE_VerticalMusicSelect JHCKHAMFHMG_VerticalMusicSelect = new CLBMCCEEDGE_VerticalMusicSelect(); // 0xEC
		public KLIBOIEIMBA_EventMission BPFEOJEAEGK_EventMission = new KLIBOIEIMBA_EventMission(); // 0xF0
		public FPMABHADHBB_EventGoDiva IMEBBACHPAN_EventGoDiva = new FPMABHADHBB_EventGoDiva(); // 0xF4
		public MCINLGMJPDM_SelectHomeBG GIDCHFBCBML_SelectHomeBG = new MCINLGMJPDM_SelectHomeBG(); // 0xF8
		public POCEANNLGLP_ShopProduct CCJMAIPBELA_ShopProduct1_4 = new POCEANNLGLP_ShopProduct(); // 0xFC
		public POCEANNLGLP_ShopProduct HDKDFCCJEEP_ShopProduct5_6 = new POCEANNLGLP_ShopProduct(); // 0x100

		//// RVA: 0x202C1A0 Offset: 0x202C1A0 VA: 0x202C1A0
		//public static bool CHDGLBBFEKH(ILDKBCLAFPB.IJDOCJCLAIL ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL GEPALDIIDPC) { }

		//// RVA: 0x202C64C Offset: 0x202C64C VA: 0x202C64C
		//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL GEPALDIIDPC) { }

		//// RVA: 0x202C660 Offset: 0x202C660 VA: 0x202C660
		public void ODDIHGPONFL_Copy(ILDKBCLAFPB.IJDOCJCLAIL_SortProprty FMKAONAMGCN)
		{
			TodoLogger.Log(0, "ODDIHGPONFL_Copy");
		}

		//// RVA: 0x202D584 Offset: 0x202D584 VA: 0x202D584
		//public EDOHBJAPLPF NOJCMGAFAAC() { }

		//// RVA: 0x202FA0C Offset: 0x202FA0C VA: 0x202FA0C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			LNFFKCDNCPN_sceneSelectSortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectSortItem", 6);
			GEAECNMDMHH_sceneListSortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListSortItem", 6);
			NCDOLBOHGFN_sceneAssistSortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sceneAssistSortItem", 6);
			ONPAMDMIEKM_divaSortItem = JsonUtil.GetInt(OBHAFLMHAKG, "divaSortItem", 6);

			CIDJJBFGHIE_sceneSelectSortOrder = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectSortOrder", 1);
			CLKCCJJJPLB_sceneListSortOrder = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListSortOrder", 1);
			OGFJPNKICGI_sceneAssistSortOrder = JsonUtil.GetInt(OBHAFLMHAKG, "sceneAssistSortOrder", 1);
			HNGHNBNPCHO_divaSortOrder = JsonUtil.GetInt(OBHAFLMHAKG, "divaSortOrder", 1);

			MDJMAEEONKK_costumeSortItem = JsonUtil.GetInt(OBHAFLMHAKG, "costumeSortItem", 6);
			LEAPMNHODPJ_unitWindowDispItem = JsonUtil.GetInt(OBHAFLMHAKG, "unitWindowDispItem", 6);
			BICLOMKLAOF_unitWindowDivaDispItem = JsonUtil.GetInt(OBHAFLMHAKG, "unitWindowDivaDispItem", 6);

			FFAKMECDMFC_sceneSelectRarityFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectRarityFilter", 0);
			LMPKAPBCIFD_sceneSelectAttributeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectAttributeFilter", 0);
			MNNCLIFBAOA_sceneSelectSeriaseFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectSeriaseFilter", 0);
			NPFGKBKKCFL_sceneSelectCompatibleFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectCompatibleFilter", 0);
			JACFDEKLDCK_isCompatibleDivaCheck = JsonUtil.GetInt(OBHAFLMHAKG, "isCompatibleDivaCheck", 0);
			HMJNAGNIEJB_sceneListRarityFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListRarityFilter", 0);
			HFGAILIOFAN_sceneListAttributeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListAttributeFilter", 0);
			AKFPHKLCHAA_sceneListSeriaseFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListSeriaseFilter", 0);
			PHCEMKLNJLH_sceneListCompatibleFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListCompatibleFilter", 0);
			OFFBGLDDBHC_sceneAssistAttributeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneAssistAttributeFilter", 0);
			POPIEDDJGBA_sceneAssistSeriaseFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneAssistSeriaseFilter", 0);
			GJFPKDOBIPH_sceneAssistCenterSkillFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneAssistCenterSkillFilter", 0);
			MOOHKFCHJPO_shopListSeriaseFilter = JsonUtil.GetInt(OBHAFLMHAKG, "shopListSeriaseFilter", 0);
			PJDCJKHMNNM_interiorListFilter = JsonUtil.GetInt(OBHAFLMHAKG, "interiorListFilter", 0);
			IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectLiveSkillRangeFilter", 0);
			BPFPFOJNFLC_sceneSelectCenterSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectCenterSkillRankFilter", 0);
			BIBBAIFCGLD_sceneSelectActiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectActiveSkillRankFilter", 0);
			AIPJDIPBDEA_sceneSelectLiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectLiveSkillRankFilter", 0);
			IHECEFMGKHO_sceneSelectCenterSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneSelectCenterSkillFilter", 0);
			POJHGOJDOND_sceneSelectActiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneSelectActiveSkillFilter", 0);
			OCKOEPFNGJG_sceneSelectLiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneSelectLiveSkillFilter", 0);
			LALFKJDFPOD_sceneListLiveSkillRangeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListLiveSkillRangeFilter", 0);
			MECEGIJIGBN_sceneListCenterSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListCenterSkillRankFilter", 0);
			ALFGELGDIGC_sceneListActiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListActiveSkillRankFilter", 0);
			HKFPBAFALHO_sceneListLiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListLiveSkillRankFilter", 0);
			IOBABMJPAAE_sceneListCenterSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneListCenterSkillFilter", 0);
			GIPNFAFFNLF_sceneListActiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneListActiveSkillFilter", 0);
			BOMCDAIEFLN_sceneListLiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "sceneListLiveSkillFilter", 0);
			DMKHBHDGABG_sceneSelectNotesExpectedFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneSelectNotesExpectedFilter", 0);
			MCJBFHMJECO_sceneListNotesExpectedFilter = JsonUtil.GetInt(OBHAFLMHAKG, "sceneListNotesExpectedFilter", 0);
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("friendList"))
			{
				IDFGCPNELIA_FriendList.KHEKNNFCAOI(OBHAFLMHAKG["friendList"], 6, 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("guestSelect"))
			{
				GDMIGCCMEEF_GuestSelect.KHEKNNFCAOI(OBHAFLMHAKG["guestSelect"], 6, 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("sentRequestList"))
			{
				EJAJGGKHALM_SentRequestList.KHEKNNFCAOI(OBHAFLMHAKG["sentRequestList"], 6, 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("pendingList"))
			{
				DOKBEPGKNJK_PendingList.KHEKNNFCAOI(OBHAFLMHAKG["pendingList"], 6, 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("episodeSelect"))
			{
				CEJNPBFIIMJ_EpisodeSelect.KHEKNNFCAOI(OBHAFLMHAKG["episodeSelect"], 26);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("raid"))
			{
				JGAFBCMOGLP_Raid.KHEKNNFCAOI(OBHAFLMHAKG["raid"], 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("musicSelect"))
			{
				KGDILGLNKFM_MusicSelect.KHEKNNFCAOI(OBHAFLMHAKG["musicSelect"], 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("verticalMusicSelect"))
			{
				JHCKHAMFHMG_VerticalMusicSelect.KHEKNNFCAOI(OBHAFLMHAKG["verticalMusicSelect"], 0, 0, 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("eventGoDiva"))
			{
				IMEBBACHPAN_EventGoDiva.KHEKNNFCAOI(OBHAFLMHAKG["eventGoDiva"], 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("eventMission"))
			{
				BPFEOJEAEGK_EventMission.KHEKNNFCAOI(OBHAFLMHAKG["eventMission"], 0);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("selectHomeBg"))
			{
				GIDCHFBCBML_SelectHomeBG.KHEKNNFCAOI(OBHAFLMHAKG["selectHomeBg"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("shopProduct_1_4"))
			{
				CCJMAIPBELA_ShopProduct1_4.KHEKNNFCAOI(OBHAFLMHAKG["shopProduct_1_4"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("shopProduct_5_6"))
			{
				HDKDFCCJEEP_ShopProduct5_6.KHEKNNFCAOI(OBHAFLMHAKG["shopProduct_5_6"]);
			}
			UnitWindowConstant.Validate(this);
		}
	}

	public class IPHAEFKCNMN
    {
        public FOLMONPGGPP_Header HKGPAMEKGKG = new FOLMONPGGPP_Header(); // 0x8
        public DNLECGEBDOI_Tutorial IAHLNPMFJMH_Tutorial = new DNLECGEBDOI_Tutorial(); // 0xC
        public MPHNGGECENI_Option CNLJNGLMMHB_Options = new MPHNGGECENI_Option(); // 0x10
        public BEJIKEOAJHN_OptionSLive MHHPDGJLJGE_OptionsSLive = new BEJIKEOAJHN_OptionSLive(); // 0x14
        public APLMBKKCNKC_Select MCNEIJAOLNO_Select = new APLMBKKCNKC_Select(); // 0x18
        public IJDOCJCLAIL_SortProprty PPCGEFGJJIC_SortProprty = new IJDOCJCLAIL_SortProprty(); // 0x1C
        // public JDBOPCADICO BOJCCICAHJK = new JDBOPCADICO(); // 0x20
        // public EHNBPANMAKA OFMECFHNCHA = new EHNBPANMAKA(); // 0x24
        // public FNDHMLLDACE NDOKECOAPML = new FNDHMLLDACE(); // 0x28
        // public HEJDCGGIADL LDNJHLLKEIG = new HEJDCGGIADL(); // 0x2C
        // public NKHHJGFNAKI LPBFPCGDOGC = new NKHHJGFNAKI(); // 0x30
        // public DBAJCPLEMDP PFOMECFACLL = new DBAJCPLEMDP(); // 0x34
        // public DJJGOGFPCEA GBCEALJIKFN = new DJJGOGFPCEA(); // 0x38
        // public JCFNHPMBPLJ EGNEDJLCMAI = new JCFNHPMBPLJ(); // 0x3C
        // public CMKCDNCHNKH MOBOMOEHGAO = new CMKCDNCHNKH(); // 0x40
        // public ABEMIFANBMF DKFCBKNPPOO = new ABEMIFANBMF(); // 0x44
        // public ICEOHGGIBBE NNKKOLHBGEL = new ICEOHGGIBBE(); // 0x48
        // public EIHCEKNKHJB IOAFPGDJCDH = new EIHCEKNKHJB(); // 0x4C
        // public FIDNFICGLEE KPHPNFBBLPA = new FIDNFICGLEE(); // 0x50
        // public AKKDKBOBKGH ICFDECCGKIL = new AKKDKBOBKGH(); // 0x54

        // // RVA: 0x2032328 Offset: 0x2032328 VA: 0x2032328
        private void ICJOCNLOOIP()
		{
			if(HKGPAMEKGKG.CEMEIPNMAAD_Version < ILDKBCLAFPB.JLLFHBIJNPC())
			{
				for(int i = HKGPAMEKGKG.CEMEIPNMAAD_Version; i < ILDKBCLAFPB.BKDGANJBPPG.Length; i++)
				{
					ILDKBCLAFPB.BKDGANJBPPG[i](this);
				}
			}
			HKGPAMEKGKG.BOGMEEOOADP();
		}

        // // RVA: 0x203249C Offset: 0x203249C VA: 0x203249C
        // public static bool CHDGLBBFEKH(ILDKBCLAFPB.IPHAEFKCNMN ILEKEPJBFDP, ILDKBCLAFPB.IPHAEFKCNMN GEPALDIIDPC) { }

        // // RVA: 0x201B270 Offset: 0x201B270 VA: 0x201B270
        // public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IPHAEFKCNMN ILEKEPJBFDP, ILDKBCLAFPB.IPHAEFKCNMN GEPALDIIDPC) { }

        // // RVA: 0x201A834 Offset: 0x201A834 VA: 0x201A834
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.IPHAEFKCNMN FMKAONAMGCN)
        {
			HKGPAMEKGKG.ODDIHGPONFL_Copy(FMKAONAMGCN.HKGPAMEKGKG);
			IAHLNPMFJMH_Tutorial.ODDIHGPONFL_Copy(FMKAONAMGCN.IAHLNPMFJMH_Tutorial);
			CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(FMKAONAMGCN.CNLJNGLMMHB_Options);
			MHHPDGJLJGE_OptionsSLive.ODDIHGPONFL_Copy(FMKAONAMGCN.MHHPDGJLJGE_OptionsSLive);
			MCNEIJAOLNO_Select.ODDIHGPONFL_Copy(FMKAONAMGCN.MCNEIJAOLNO_Select);
			PPCGEFGJJIC_SortProprty.ODDIHGPONFL_Copy(FMKAONAMGCN.PPCGEFGJJIC_SortProprty);
			// BOJCCICAHJK.ODDIHGPONFL_Copy(FMKAONAMGCN.BOJCCICAHJK);
			// OFMECFHNCHA.ODDIHGPONFL_Copy(FMKAONAMGCN.OFMECFHNCHA);
			// NDOKECOAPML.ODDIHGPONFL_Copy(FMKAONAMGCN.NDOKECOAPML);
			// LDNJHLLKEIG.ODDIHGPONFL_Copy(FMKAONAMGCN.LDNJHLLKEIG);
			// LPBFPCGDOGC.ODDIHGPONFL_Copy(FMKAONAMGCN.LPBFPCGDOGC);
			// PFOMECFACLL.ODDIHGPONFL_Copy(FMKAONAMGCN.PFOMECFACLL);
			// GBCEALJIKFN.ODDIHGPONFL_Copy(FMKAONAMGCN.GBCEALJIKFN);
			// EGNEDJLCMAI.ODDIHGPONFL_Copy(FMKAONAMGCN.EGNEDJLCMAI);
			// MOBOMOEHGAO.ODDIHGPONFL_Copy(FMKAONAMGCN.MOBOMOEHGAO);
			// DKFCBKNPPOO.ODDIHGPONFL_Copy(FMKAONAMGCN.DKFCBKNPPOO);
			// NNKKOLHBGEL.ODDIHGPONFL_Copy(FMKAONAMGCN.NNKKOLHBGEL);
			// IOAFPGDJCDH.ODDIHGPONFL_Copy(FMKAONAMGCN.IOAFPGDJCDH);
			// KPHPNFBBLPA.ODDIHGPONFL_Copy(FMKAONAMGCN.KPHPNFBBLPA);
			// ICFDECCGKIL.ODDIHGPONFL_Copy(FMKAONAMGCN.ICFDECCGKIL);
        }

        // // RVA: 0x2032DB8 Offset: 0x2032DB8 VA: 0x2032DB8
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
        {
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("header"))
			{
				HKGPAMEKGKG.KHEKNNFCAOI_Init(OBHAFLMHAKG["header"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("tutorial"))
			{
				IAHLNPMFJMH_Tutorial.KHEKNNFCAOI_Init(OBHAFLMHAKG["tutorial"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("option"))
			{
				CNLJNGLMMHB_Options.KHEKNNFCAOI_Init(OBHAFLMHAKG["option"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("option_slive"))
			{
				MHHPDGJLJGE_OptionsSLive.KHEKNNFCAOI_Init(OBHAFLMHAKG["option_slive"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("select"))
			{
				MCNEIJAOLNO_Select.KHEKNNFCAOI_Init(OBHAFLMHAKG["select"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("sortProprty"))
			{
				PPCGEFGJJIC_SortProprty.KHEKNNFCAOI_Init(OBHAFLMHAKG["sortProprty"]);
			}
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("notification"))
			// {
			// 	BOJCCICAHJK.KHEKNNFCAOI_Init(OBHAFLMHAKG["notification"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("popup"))
			// {
			// 	OFMECFHNCHA.KHEKNNFCAOI_Init(OBHAFLMHAKG["popup"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("login"))
			// {
			// 	NDOKECOAPML.KHEKNNFCAOI_Init(OBHAFLMHAKG["login"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("statusPopup"))
			// {
			// 	LDNJHLLKEIG.KHEKNNFCAOI_Init(OBHAFLMHAKG["statusPopup"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("anketo"))
			// {
			// 	LPBFPCGDOGC.KHEKNNFCAOI_Init(OBHAFLMHAKG["anketo"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("shop"))
			// {
			// 	PFOMECFACLL.KHEKNNFCAOI_Init(OBHAFLMHAKG["shop"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("home"))
			// {
			// 	GBCEALJIKFN.KHEKNNFCAOI_Init(OBHAFLMHAKG["home"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("unitDance"))
			// {
			// 	EGNEDJLCMAI.KHEKNNFCAOI_Init(OBHAFLMHAKG["unitDance"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("costumeUpgrade"))
			// {
			// 	MOBOMOEHGAO.KHEKNNFCAOI_Init(OBHAFLMHAKG["costumeUpgrade"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("offer"))
			// {
			// 	DKFCBKNPPOO.KHEKNNFCAOI_Init(OBHAFLMHAKG["offer"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("ChatCommon"))
			// {
			// 	NNKKOLHBGEL.KHEKNNFCAOI_Init(OBHAFLMHAKG["ChatCommon"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("valkyrieTuneUp"))
			// {
			// 	IOAFPGDJCDH.KHEKNNFCAOI_Init(OBHAFLMHAKG["valkyrieTuneUp"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("limitedItemWarning"))
			// {
			// 	KPHPNFBBLPA.KHEKNNFCAOI_Init(OBHAFLMHAKG["limitedItemWarning"]);
			// }
			// if(OBHAFLMHAKG.BBAJPINMOEP_Contains("aprilFool"))
			// {
			// 	ICFDECCGKIL.KHEKNNFCAOI_Init(OBHAFLMHAKG["aprilFool"]);
			// }
			ICJOCNLOOIP();
        }

        // // RVA: 0x2033FE0 Offset: 0x2033FE0 VA: 0x2033FE0
        // public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }

        // // RVA: 0x201B1B0 Offset: 0x201B1B0 VA: 0x201B1B0
        public void NFDEBEJFNGD(string DLENPPIJNPA)
        {
            UnityEngine.Debug.LogError(DLENPPIJNPA);
            KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DLENPPIJNPA));
        }

        // // RVA: 0x201A460 Offset: 0x201A460 VA: 0x201A460
        // public string EJCOJCGIBNG() { }
    }

    public class JDBOPCADICO
    {
        public sbyte KNOLBNCEHFB = 1; // 0x8
        public sbyte ILNIHDCCOEO = 1; // 0x9
        public sbyte NDOEPNGHGPF = 1; // 0xA
        public sbyte JAFLKPEEGIM = 1; // 0xB
        public sbyte PIPOIELPKBP = 1; // 0xC
        public sbyte HILOMEJEJAM = 1; // 0xD
        public sbyte OKGKFFLMFKH = 1; // 0xE
        public int OLBKCGKDBBL; // 0x10

        // public sbyte EJGJPICOCBI { get; set; } ILKOBMOJIPG 0x2035A10 IONHLLLJLAI 0x2035A20

        // // RVA: 0x2035A38 Offset: 0x2035A38 VA: 0x2035A38
        // public void AAHGFMHAJFG(int ICDJHNPILBC, bool JKDJCFEBDHC) { }

        // // RVA: 0x2035A60 Offset: 0x2035A60 VA: 0x2035A60
        // public bool OCKFGNLLBFA(int ICDJHNPILBC) { }

        // // RVA: 0x2035A7C Offset: 0x2035A7C VA: 0x2035A7C
        // public static bool CHDGLBBFEKH(ILDKBCLAFPB.JDBOPCADICO ILEKEPJBFDP, ILDKBCLAFPB.JDBOPCADICO GEPALDIIDPC) { }

        // // RVA: 0x20326CC Offset: 0x20326CC VA: 0x20326CC
        // public static bool HMMFJOEBEKJ(ILDKBCLAFPB.JDBOPCADICO ILEKEPJBFDP, ILDKBCLAFPB.JDBOPCADICO GEPALDIIDPC) { }

        // // RVA: 0x2032C9C Offset: 0x2032C9C VA: 0x2032C9C
        // public void ODDIHGPONFL_Copy(ILDKBCLAFPB.JDBOPCADICO FMKAONAMGCN) { }

        // // RVA: 0x203557C Offset: 0x203557C VA: 0x203557C
        // public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }

        // // RVA: 0x2033DDC Offset: 0x2033DDC VA: 0x2033DDC
        // public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG) { }
    }

	private static Action<IPHAEFKCNMN>[] BKDGANJBPPG; // 0x0
	private CipherRijndael MIDAHPPDINB; // 0x8
	private const string AGLECLBEGCE = "SaveData";
	private const string EDAOODPKLLI = "save.bin";
	private IPHAEFKCNMN GLANNFOPMDO; // 0xC
	private IPHAEFKCNMN CGFIFBHIBCF; // 0x10

	// public ILDKBCLAFPB.IPHAEFKCNMN NDILDEKOCOP { get; } // ??
	// private ILDKBCLAFPB.IPHAEFKCNMN KBFFAEDDLKA { get; } // ??

	// // RVA: 0x20199AC Offset: 0x20199AC VA: 0x20199AC
	public static int JLLFHBIJNPC()
    {
        return BKDGANJBPPG.Length;
    }

	// // RVA: 0x2019A4C Offset: 0x2019A4C VA: 0x2019A4C
	private static void AAPCFCKIFND(ILDKBCLAFPB.IPHAEFKCNMN NHLBKJCPLBL)
    {
        TodoLogger.Log(0, "TODO");
    }

	// // RVA: 0x2019B34 Offset: 0x2019B34 VA: 0x2019B34
	private static void IBMGEHJHHPK(ILDKBCLAFPB.IPHAEFKCNMN NHLBKJCPLBL)
    {
        TodoLogger.Log(0, "TODO");
    }

	// // RVA: 0x2019C30 Offset: 0x2019C30 VA: 0x2019C30
	public ILDKBCLAFPB(string GMEFFNIMFIF, string CDPAMAOOHNF)
    {
        GLANNFOPMDO = new IPHAEFKCNMN();
        CGFIFBHIBCF = new IPHAEFKCNMN();
        MIDAHPPDINB = new CipherRijndael(GMEFFNIMFIF, CDPAMAOOHNF);
    }

	// // RVA: 0x201A168 Offset: 0x201A168 VA: 0x201A168
	public ILDKBCLAFPB.IPHAEFKCNMN EPJOACOONAC()
    {
        return GLANNFOPMDO;
    }

	// // RVA: 0x201A170 Offset: 0x201A170 VA: 0x201A170
	// private ILDKBCLAFPB.IPHAEFKCNMN BDHDGOOLBDE() { }

	// // RVA: 0x201A178 Offset: 0x201A178 VA: 0x201A178
	// public void OEGPHLDDFDF() { }

	// // RVA: 0x201A184 Offset: 0x201A184 VA: 0x201A184
	// public void LHPDDGIJKNB_Reset() { }

	// // RVA: 0x201A204 Offset: 0x201A204 VA: 0x201A204
	public bool HJMKBCFJOOH()
    {
        TodoLogger.Log(0, "TODO");
        return false;
    }

	// // RVA: 0x201ABAC Offset: 0x201ABAC VA: 0x201ABAC
	public EJFLCPHPMCA PCODDPDFLHK()
    {
        string s = DNHFPLJMIPI(DMCLJKABBCJ());
        if(s == null)
        {
            GLANNFOPMDO.HKGPAMEKGKG.BOGMEEOOADP();
            return ILDKBCLAFPB.EJFLCPHPMCA.MKOILBFAONG;
        }
        else
        {
            GLANNFOPMDO = new IPHAEFKCNMN();
            GLANNFOPMDO.NFDEBEJFNGD(MIDAHPPDINB.DecryptFromBase64(s));
            GLANNFOPMDO.ODDIHGPONFL_Copy(CGFIFBHIBCF);
            return ILDKBCLAFPB.EJFLCPHPMCA.JIMDHEJOPBK;
        }
    }

	// // RVA: 0x201B244 Offset: 0x201B244 VA: 0x201B244
	// public void BLICHJOLKAO() { }

	// // RVA: 0x201A3D8 Offset: 0x201A3D8 VA: 0x201A3D8
	// private bool JMCDHAGAPIP() { }

	// // RVA: 0x201A434 Offset: 0x201A434 VA: 0x201A434
	// private void JCHBCPEPFKE() { }

	// // RVA: 0x201A3F8 Offset: 0x201A3F8 VA: 0x201A3F8
	// public FENCAJJBLBH KPOCKNCJBPN() { }

	// // RVA: 0x201B284 Offset: 0x201B284 VA: 0x201B284
	// private string KJEOLHCEDJI() { }

	// // RVA: 0x201A538 Offset: 0x201A538 VA: 0x201A538
	private string DMCLJKABBCJ()
    {
        return Application.persistentDataPath + "/SaveData/save.bin";
    }

	// // RVA: 0x201AE10 Offset: 0x201AE10 VA: 0x201AE10
	private string DNHFPLJMIPI(string HDMOIHHPJEA)
    {
        if(File.Exists(HDMOIHHPJEA))
        {
            FileInfo info = new FileInfo(HDMOIHHPJEA);
            FileStream fs = info.OpenRead();
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Dispose();
            return data;
        }
        return null;
    }

	// // RVA: 0x201A5A0 Offset: 0x201A5A0 VA: 0x201A5A0
	// private void JCOILDLEPDP(string HDMOIHHPJEA, string GPBPBJFBOHL) { }

	// // RVA: 0x201B314 Offset: 0x201B314 VA: 0x201B314
	public void FBCDKFENOEM()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0x201BB54 Offset: 0x201BB54 VA: 0x201BB54
	static ILDKBCLAFPB()
    {
        BKDGANJBPPG = new Action<IPHAEFKCNMN>[2];
        BKDGANJBPPG[0] = AAPCFCKIFND;
        BKDGANJBPPG[1] = IBMGEHJHHPK;
    }
}
