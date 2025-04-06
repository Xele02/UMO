using System;
using XeSys;
using System.IO;
using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using System.Collections.Generic;
using XeApp.Game.Menu;
using XeApp.Game;

public class ILDKBCLAFPB
{
	public enum CDIPJNPICCO_RecoveryPoint
	{
		HJNNKCMLGFL = 0,
		ENKHFKLKCPO = 1,
		ICPCONCBPLH = 2,
		DOEHLCLBCNN_3_Gacha = 3,
		FBFBGLONIME_4_AfterGacha = 4,
		DJPFJGKGOOF_5_Setting = 5,
		BNLDNJNMFMC_6 = 6,
		KIDJFNEGAHO_7_ToMusicResult = 7,
		GBECNPANBEA_8_TutoMusicResult = 8,
		AKPFBBEGGEF = 9,
		CIJOMBLJANG = 10,
		AEFCOHJBLPO = 11,
	}

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
        public int DDHCLNFPNGK_RenderQuality = 1; // 0x34
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
        public int BBIOMNCILMC_HomeDivaId; // 0xAC
        public bool GDLAPBKCBFP_IsHomeDivaWindow = true; // 0xB0
        public int BAGJHPGGCCI_PlayLogGraphType; // 0xB4
        public bool EDDMJEMOAGM_IsNotExcellentDisplaySetting = true; // 0xB8
        public bool CJKKALFPMLA_IsNotDivaModeDivaVisible = true; // 0xB9
        public bool KPFAFLBICLA_IsNotBattleEventInfo = true; // 0xBA
        public bool MJHEPGIEDDL_IsSlideNoteEffect = true; // 0xBB
        public int HLABNEIEJPM_SafeAreaDesign; // 0xBC
        public int HJPDHDHMOPF_IsNotForceWideScreen; // 0xC0
        public bool BIEOIPOLFLN_IsNotPlayRecordFirstLaunch = true; // 0xC4

        // public bool PBANLLOLBKK { get; }
        // public bool GBCGNDJANFJ { get; }
        // public bool ENJFHBNCHEB { get; }
        // public bool PPDJAPPLOPA { get; }
        // public bool AHIBBPFIAMJ { get; }
        // public bool FFKLPNPJLMB { get; }
        // public bool FGJBDPOGMDI { get; }
        public bool CIGAPPFDFKL_Is3D { get { return DDHCLNFPNGK_RenderQuality != 2; } private set {} } //MNJOLLGPMPI 0x2035E64 JCCDFGOGFFA 0x2035E8C
        public bool OOCKIFIHJJN_Is2DMode { get { return DDHCLNFPNGK_RenderQuality == 2; } private set {} } //CKJIGBCJGMI 0x2035E78 IBPIBMKAMPE 0x2035E90

        // // RVA: 0x2035BF0 Offset: 0x2035BF0 VA: 0x2035BF0
        public void PBCBJAPONBF()
        {
			ICGAOAFIHFD_VolBgmRhythm = 15;
			FCKEDCKCEFC_VolVoiceRhythm = 15;
			IBEINHHMHAC_VolNotesRhythm = 11;
			DDHCLNFPNGK_RenderQuality = 1;
			HHMCIGLCBNG_QualityCustomDiva3D = 0;
			AHLFOHJMGAI_QualityCustomOther3D = 0;
			IHEPCAHBECA_VideoMode = 0;
			MHACPBAPBFE_BgMode = 0;
			DCHMOFLEFMI_NotesSpeedEasy = 30;
			MBOEPFLNDOD_NotesSpeedNormal = 40;
			JDJBFBPBLDC_NotesSpeedVeryHardPlus = 70;
			FJKNAHGFAPP_NotesSpeedExtremePlus = 80;
			LHJHOFNIJJF_NotesSpeedSelectDiff = 1;
			BGLLCLEDHKK_VolSe = 15;
			HOMPENLIHCK_VolBgm = 15;
			CNCIMBGLKOB_VolVoice = 15;
			LMDACNNJDOE_VolSeRhythm = 15;
			CJFAJNMADBA_ScreenRotation = 0;
			NFMEIILKACN_NotesRoute = 0;
			NAGJLEIPAAC_Cutin = 0;
			DADIPGPHLDD_EffectCutin = 0;
			FPJHOLMLDGC_QualityCustom2D = 1;
			CDGKHMEOEMP_ValkyrieMode = 0;
			OLALFDCEHKJ_Dimmer3d = 10;
			FPFAMFOPJDJ_Dimmer2d = 4;
			MGOOLKHAPAF_NotesSpeedHard = 60;
			AIKDLBAANLG_NotesSpeedVeryHard = 70;
			KOKDGGOFPPI_NotesSpeedExtreme = 70;
			LIPAPGABJOA_NotesSpeedHardPlus = 70;
			LBIKGDHCICB_NotesSpeedAllApply = 0;
			JJDENMHGOIH_NotesSpeedAutoRejected = 0;
			KDNKCOAJGCM_NotesType = 1;
			BBIOMNCILMC_HomeDivaId = 0;
			ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = false;
			GEPLOFLHAOL_NeedInitRenderQuality = 0;
			OJAJHIMOIEC_NoteOffset = 0;
			OAKOJGPBAJF_BackKey = 0;
			PMGMMMGCEEI_Video = 0;
			GDLAPBKCBFP_IsHomeDivaWindow = true;
			BAGJHPGGCCI_PlayLogGraphType = 0;
			EDDMJEMOAGM_IsNotExcellentDisplaySetting = true;
			CJKKALFPMLA_IsNotDivaModeDivaVisible = true;
			KPFAFLBICLA_IsNotBattleEventInfo = true;
			MJHEPGIEDDL_IsSlideNoteEffect = true;
			HLABNEIEJPM_SafeAreaDesign = 0;
			HJPDHDHMOPF_IsNotForceWideScreen = SystemManager.IsForceWideScreen ? 0 : 1;
			BIEOIPOLFLN_IsNotPlayRecordFirstLaunch = true;
		}

        // // RVA: 0x2035D68 Offset: 0x2035D68 VA: 0x2035D68
        public bool KKBJCJNAGDB_CutInEnabled()
		{
			return NAGJLEIPAAC_Cutin == 0;
		}

        // // RVA: 0x2035D7C Offset: 0x2035D7C VA: 0x2035D7C
        public bool GLKGAOFHLPN_IsCutinEnabled()
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
        public bool PKEMELMMEKM_IsDivaHighQuality()
		{
			if (DDHCLNFPNGK_RenderQuality == 3)
				return HHMCIGLCBNG_QualityCustomDiva3D == 0;
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035DD4 Offset: 0x2035DD4 VA: 0x2035DD4
        public bool DKECHCHOMEL_IsValkyrieHighQuality()
		{
			if (DDHCLNFPNGK_RenderQuality == 3)
				return AHLFOHJMGAI_QualityCustomOther3D == 0;
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035DF0 Offset: 0x2035DF0 VA: 0x2035DF0
        public bool MIHFCOBBIPJ_Is2DHighQuality()
		{
			if(DDHCLNFPNGK_RenderQuality == 3)
				return FPJHOLMLDGC_QualityCustom2D == 0;
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035E0C Offset: 0x2035E0C VA: 0x2035E0C
        public bool JLEJPKOMKEJ_IsAnimatorLowQuality()
		{
			if(DDHCLNFPNGK_RenderQuality == 3)
			{
				if (FPJHOLMLDGC_QualityCustom2D == 1 && HHMCIGLCBNG_QualityCustomDiva3D == 1)
					return AHLFOHJMGAI_QualityCustomOther3D == 1;
			}
			return false;
		}

        // // RVA: 0x2035E48 Offset: 0x2035E48 VA: 0x2035E48
        public bool INPHNKJPJFN_IsBoneHighQuality()
		{
			if(DDHCLNFPNGK_RenderQuality == 3)
			{
				return HHMCIGLCBNG_QualityCustomDiva3D == 0;
			}
			return DDHCLNFPNGK_RenderQuality == 0;
		}

        // // RVA: 0x2035E94 Offset: 0x2035E94 VA: 0x2035E94
        public int CBLEFELBNDN_GetVideoQuality()
		{
			return IHEPCAHBECA_VideoMode != 0 ? 1 : 2;
		}

        // // RVA: 0x2035EA8 Offset: 0x2035EA8 VA: 0x2035EA8
        public int DGCDPGPAAII_GetNotesSpeed(Difficulty.Type FEOKKEPAIBB, bool JCOJKAHFADL)
		{
			switch(FEOKKEPAIBB)
			{
				case Difficulty.Type.Easy:
					return DCHMOFLEFMI_NotesSpeedEasy;
				case Difficulty.Type.Normal:
					return MBOEPFLNDOD_NotesSpeedNormal;
				case Difficulty.Type.Hard:
					if(JCOJKAHFADL)
						return LIPAPGABJOA_NotesSpeedHardPlus;
					else
						return MGOOLKHAPAF_NotesSpeedHard;
				case Difficulty.Type.VeryHard:
					if(JCOJKAHFADL)
						return JDJBFBPBLDC_NotesSpeedVeryHardPlus;
					else
						return AIKDLBAANLG_NotesSpeedVeryHard;
				case Difficulty.Type.Extreme:
					if(JCOJKAHFADL)
						return FJKNAHGFAPP_NotesSpeedExtremePlus;
					else
						return KOKDGGOFPPI_NotesSpeedExtreme;
				default:
					return -1;
			}
		}

        // // RVA: 0x2035F1C Offset: 0x2035F1C VA: 0x2035F1C
        // public Difficulty.Type OEJCANLJKPI() { }

        // // RVA: 0x2035F24 Offset: 0x2035F24 VA: 0x2035F24
        // public bool IFLFCLIHCOA() { }

        // // RVA: 0x2035F2C Offset: 0x2035F2C VA: 0x2035F2C
        public bool DCJKPJFIJKH_IsNotesSpeedAutoRejected()
		{
			return JJDENMHGOIH_NotesSpeedAutoRejected == 1;
		}

        // // RVA: 0x2035F3C Offset: 0x2035F3C VA: 0x2035F3C
        public int HBCHGGNOOCD_GetNotesDisplayTiming(Difficulty.Type FEOKKEPAIBB, bool JCOJKAHFADL_IsLine6)
        {
            switch(FEOKKEPAIBB)
			{
				case Difficulty.Type.Easy: return GameManager.Instance.rhythmNotesSpeedSetting.CalcNoteDispTime(DCHMOFLEFMI_NotesSpeedEasy);
				case Difficulty.Type.Normal: return GameManager.Instance.rhythmNotesSpeedSetting.CalcNoteDispTime(MBOEPFLNDOD_NotesSpeedNormal);
				case Difficulty.Type.Hard: return GameManager.Instance.rhythmNotesSpeedSetting.CalcNoteDispTime(JCOJKAHFADL_IsLine6 ? LIPAPGABJOA_NotesSpeedHardPlus : MGOOLKHAPAF_NotesSpeedHard);
				case Difficulty.Type.VeryHard: return GameManager.Instance.rhythmNotesSpeedSetting.CalcNoteDispTime(JCOJKAHFADL_IsLine6 ? JDJBFBPBLDC_NotesSpeedVeryHardPlus : AIKDLBAANLG_NotesSpeedVeryHard);
				case Difficulty.Type.Extreme: return GameManager.Instance.rhythmNotesSpeedSetting.CalcNoteDispTime(JCOJKAHFADL_IsLine6 ? FJKNAHGFAPP_NotesSpeedExtremePlus : KOKDGGOFPPI_NotesSpeedExtreme);
			}
			return -1;
        }

        // // RVA: 0x203607C Offset: 0x203607C VA: 0x203607C
        public void GMHKLEMBLOF(int INDDJNMPONH, int DOKKMMFKLJI)
		{
			KDNKCOAJGCM_NotesType = DOKKMMFKLJI + INDDJNMPONH * 2;
		}

        // // RVA: 0x2036088 Offset: 0x2036088 VA: 0x2036088
        public void FFLGCAJBPDE(out int INDDJNMPONH, out int DOKKMMFKLJI)
		{
			INDDJNMPONH = KDNKCOAJGCM_NotesType / 2;
			DOKKMMFKLJI = KDNKCOAJGCM_NotesType % 2;
		}

        // // RVA: 0x20360B0 Offset: 0x20360B0 VA: 0x20360B0
        // public static float MOMJFKFNJIA(int DHMNFEPOLOK) { }

        // // RVA: 0x20360D4 Offset: 0x20360D4 VA: 0x20360D4
        // public float MIFIAMNHKOF() { }

        // // RVA: 0x20360F8 Offset: 0x20360F8 VA: 0x20360F8
        // public float EBBAAPCHNKL() { }

        // // RVA: 0x20361A4 Offset: 0x20361A4 VA: 0x20361A4
        public bool AOOKLMAPPLG_IsValkyrieModeEnabled()
		{
			return CDGKHMEOEMP_ValkyrieMode == 0;
		}

        // // RVA: 0x20361B8 Offset: 0x20361B8 VA: 0x20361B8
        public void AFMDGKBANPH_SetValkyrieMode(bool IPJMPBANBPP)
        {
			CDGKHMEOEMP_ValkyrieMode = IPJMPBANBPP ? 0 : 1;
		}

        // // RVA: 0x20361E0 Offset: 0x20361E0 VA: 0x20361E0
        public static bool CHDGLBBFEKH_IsEqual(MPHNGGECENI_Option ILEKEPJBFDP, MPHNGGECENI_Option GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.BGLLCLEDHKK_VolSe == GEPALDIIDPC.BGLLCLEDHKK_VolSe &&
				ILEKEPJBFDP.HOMPENLIHCK_VolBgm == GEPALDIIDPC.HOMPENLIHCK_VolBgm &&
				ILEKEPJBFDP.CNCIMBGLKOB_VolVoice == GEPALDIIDPC.CNCIMBGLKOB_VolVoice &&
				ILEKEPJBFDP.CJFAJNMADBA_ScreenRotation == GEPALDIIDPC.CJFAJNMADBA_ScreenRotation &&
				ILEKEPJBFDP.NFMEIILKACN_NotesRoute == GEPALDIIDPC.NFMEIILKACN_NotesRoute &&
				ILEKEPJBFDP.OJAJHIMOIEC_NoteOffset == GEPALDIIDPC.OJAJHIMOIEC_NoteOffset &&
				ILEKEPJBFDP.NAGJLEIPAAC_Cutin == GEPALDIIDPC.NAGJLEIPAAC_Cutin &&
				ILEKEPJBFDP.DADIPGPHLDD_EffectCutin == GEPALDIIDPC.DADIPGPHLDD_EffectCutin &&
				ILEKEPJBFDP.DDHCLNFPNGK_RenderQuality == GEPALDIIDPC.DDHCLNFPNGK_RenderQuality &&
				ILEKEPJBFDP.GEPLOFLHAOL_NeedInitRenderQuality == GEPALDIIDPC.GEPLOFLHAOL_NeedInitRenderQuality &&
				ILEKEPJBFDP.LMDACNNJDOE_VolSeRhythm == GEPALDIIDPC.LMDACNNJDOE_VolSeRhythm &&
				ILEKEPJBFDP.ICGAOAFIHFD_VolBgmRhythm == GEPALDIIDPC.ICGAOAFIHFD_VolBgmRhythm &&
				ILEKEPJBFDP.FCKEDCKCEFC_VolVoiceRhythm == GEPALDIIDPC.FCKEDCKCEFC_VolVoiceRhythm &&
				ILEKEPJBFDP.IBEINHHMHAC_VolNotesRhythm == GEPALDIIDPC.IBEINHHMHAC_VolNotesRhythm &&
				ILEKEPJBFDP.PMGMMMGCEEI_Video == GEPALDIIDPC.PMGMMMGCEEI_Video &&
				ILEKEPJBFDP.IHEPCAHBECA_VideoMode == GEPALDIIDPC.IHEPCAHBECA_VideoMode &&
				ILEKEPJBFDP.OAKOJGPBAJF_BackKey == GEPALDIIDPC.OAKOJGPBAJF_BackKey &&
				ILEKEPJBFDP.MHACPBAPBFE_BgMode == GEPALDIIDPC.MHACPBAPBFE_BgMode &&
				ILEKEPJBFDP.GACNKPOMOFA_IsDrawKira == GEPALDIIDPC.GACNKPOMOFA_IsDrawKira &&
				ILEKEPJBFDP.LENJLNLNPEO_IsPlateAnimationHome == GEPALDIIDPC.LENJLNLNPEO_IsPlateAnimationHome &&
				ILEKEPJBFDP.DFLJOKOKLIL_IsPlateAnimationOther == GEPALDIIDPC.DFLJOKOKLIL_IsPlateAnimationOther &&
				ILEKEPJBFDP.MDMDEAFFIMB_IsDivaEffect == GEPALDIIDPC.MDMDEAFFIMB_IsDivaEffect &&
				ILEKEPJBFDP.HHMCIGLCBNG_QualityCustomDiva3D == GEPALDIIDPC.HHMCIGLCBNG_QualityCustomDiva3D &&
				ILEKEPJBFDP.AHLFOHJMGAI_QualityCustomOther3D == GEPALDIIDPC.AHLFOHJMGAI_QualityCustomOther3D &&
				ILEKEPJBFDP.FPJHOLMLDGC_QualityCustom2D == GEPALDIIDPC.FPJHOLMLDGC_QualityCustom2D &&
				ILEKEPJBFDP.OLALFDCEHKJ_Dimmer3d == GEPALDIIDPC.OLALFDCEHKJ_Dimmer3d &&
				ILEKEPJBFDP.FPFAMFOPJDJ_Dimmer2d == GEPALDIIDPC.FPFAMFOPJDJ_Dimmer2d &&
				ILEKEPJBFDP.CDGKHMEOEMP_ValkyrieMode == GEPALDIIDPC.CDGKHMEOEMP_ValkyrieMode &&
				ILEKEPJBFDP.DCHMOFLEFMI_NotesSpeedEasy == GEPALDIIDPC.DCHMOFLEFMI_NotesSpeedEasy &&
				ILEKEPJBFDP.MBOEPFLNDOD_NotesSpeedNormal == GEPALDIIDPC.MBOEPFLNDOD_NotesSpeedNormal &&
				ILEKEPJBFDP.MGOOLKHAPAF_NotesSpeedHard == GEPALDIIDPC.MGOOLKHAPAF_NotesSpeedHard &&
				ILEKEPJBFDP.AIKDLBAANLG_NotesSpeedVeryHard == GEPALDIIDPC.AIKDLBAANLG_NotesSpeedVeryHard &&
				ILEKEPJBFDP.KOKDGGOFPPI_NotesSpeedExtreme == GEPALDIIDPC.KOKDGGOFPPI_NotesSpeedExtreme &&
				ILEKEPJBFDP.LIPAPGABJOA_NotesSpeedHardPlus == GEPALDIIDPC.LIPAPGABJOA_NotesSpeedHardPlus &&
				ILEKEPJBFDP.JDJBFBPBLDC_NotesSpeedVeryHardPlus == GEPALDIIDPC.JDJBFBPBLDC_NotesSpeedVeryHardPlus &&
				ILEKEPJBFDP.FJKNAHGFAPP_NotesSpeedExtremePlus == GEPALDIIDPC.FJKNAHGFAPP_NotesSpeedExtremePlus &&
				ILEKEPJBFDP.LHJHOFNIJJF_NotesSpeedSelectDiff == GEPALDIIDPC.LHJHOFNIJJF_NotesSpeedSelectDiff &&
				ILEKEPJBFDP.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode == GEPALDIIDPC.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode &&
				ILEKEPJBFDP.LBIKGDHCICB_NotesSpeedAllApply == GEPALDIIDPC.LBIKGDHCICB_NotesSpeedAllApply &&
				ILEKEPJBFDP.JJDENMHGOIH_NotesSpeedAutoRejected == GEPALDIIDPC.JJDENMHGOIH_NotesSpeedAutoRejected &&
				ILEKEPJBFDP.KDNKCOAJGCM_NotesType == GEPALDIIDPC.KDNKCOAJGCM_NotesType &&
				ILEKEPJBFDP.BBIOMNCILMC_HomeDivaId == GEPALDIIDPC.BBIOMNCILMC_HomeDivaId &&
				ILEKEPJBFDP.GDLAPBKCBFP_IsHomeDivaWindow == GEPALDIIDPC.GDLAPBKCBFP_IsHomeDivaWindow &&
				ILEKEPJBFDP.BAGJHPGGCCI_PlayLogGraphType == GEPALDIIDPC.BAGJHPGGCCI_PlayLogGraphType &&
				ILEKEPJBFDP.EDDMJEMOAGM_IsNotExcellentDisplaySetting == GEPALDIIDPC.EDDMJEMOAGM_IsNotExcellentDisplaySetting &&
				ILEKEPJBFDP.CJKKALFPMLA_IsNotDivaModeDivaVisible == GEPALDIIDPC.CJKKALFPMLA_IsNotDivaModeDivaVisible &&
				ILEKEPJBFDP.KPFAFLBICLA_IsNotBattleEventInfo == GEPALDIIDPC.KPFAFLBICLA_IsNotBattleEventInfo &&
				ILEKEPJBFDP.MJHEPGIEDDL_IsSlideNoteEffect == GEPALDIIDPC.MJHEPGIEDDL_IsSlideNoteEffect &&
				ILEKEPJBFDP.HLABNEIEJPM_SafeAreaDesign == GEPALDIIDPC.HLABNEIEJPM_SafeAreaDesign &&
				ILEKEPJBFDP.HJPDHDHMOPF_IsNotForceWideScreen == GEPALDIIDPC.HJPDHDHMOPF_IsNotForceWideScreen &&
				ILEKEPJBFDP.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch == GEPALDIIDPC.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch)
				return true;
			return false;
		}

        // // RVA: 0x20326B8 Offset: 0x20326B8 VA: 0x20326B8
        public static bool HMMFJOEBEKJ(MPHNGGECENI_Option ILEKEPJBFDP, MPHNGGECENI_Option GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

        // // RVA: 0x20326F4 Offset: 0x20326F4 VA: 0x20326F4
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.MPHNGGECENI_Option FMKAONAMGCN)
        {
			FMKAONAMGCN.BGLLCLEDHKK_VolSe = BGLLCLEDHKK_VolSe;
			FMKAONAMGCN.HOMPENLIHCK_VolBgm = HOMPENLIHCK_VolBgm;
			FMKAONAMGCN.CNCIMBGLKOB_VolVoice = CNCIMBGLKOB_VolVoice;
			FMKAONAMGCN.CJFAJNMADBA_ScreenRotation = CJFAJNMADBA_ScreenRotation;
			FMKAONAMGCN.NFMEIILKACN_NotesRoute = NFMEIILKACN_NotesRoute;
			FMKAONAMGCN.OJAJHIMOIEC_NoteOffset = OJAJHIMOIEC_NoteOffset;
			FMKAONAMGCN.NAGJLEIPAAC_Cutin = NAGJLEIPAAC_Cutin;
			FMKAONAMGCN.DADIPGPHLDD_EffectCutin = DADIPGPHLDD_EffectCutin;
			FMKAONAMGCN.DDHCLNFPNGK_RenderQuality = DDHCLNFPNGK_RenderQuality;
			FMKAONAMGCN.GEPLOFLHAOL_NeedInitRenderQuality = GEPLOFLHAOL_NeedInitRenderQuality;
			FMKAONAMGCN.LMDACNNJDOE_VolSeRhythm = LMDACNNJDOE_VolSeRhythm;
			FMKAONAMGCN.ICGAOAFIHFD_VolBgmRhythm = ICGAOAFIHFD_VolBgmRhythm;
			FMKAONAMGCN.FCKEDCKCEFC_VolVoiceRhythm = FCKEDCKCEFC_VolVoiceRhythm;
			FMKAONAMGCN.IBEINHHMHAC_VolNotesRhythm = IBEINHHMHAC_VolNotesRhythm;
			FMKAONAMGCN.PMGMMMGCEEI_Video = PMGMMMGCEEI_Video;
			FMKAONAMGCN.IHEPCAHBECA_VideoMode = IHEPCAHBECA_VideoMode;
			FMKAONAMGCN.OAKOJGPBAJF_BackKey = OAKOJGPBAJF_BackKey;
			FMKAONAMGCN.MHACPBAPBFE_BgMode = MHACPBAPBFE_BgMode;
			FMKAONAMGCN.GACNKPOMOFA_IsDrawKira = GACNKPOMOFA_IsDrawKira;
			FMKAONAMGCN.LENJLNLNPEO_IsPlateAnimationHome = LENJLNLNPEO_IsPlateAnimationHome;
			FMKAONAMGCN.DFLJOKOKLIL_IsPlateAnimationOther = DFLJOKOKLIL_IsPlateAnimationOther;
			FMKAONAMGCN.MDMDEAFFIMB_IsDivaEffect = MDMDEAFFIMB_IsDivaEffect;
			FMKAONAMGCN.HHMCIGLCBNG_QualityCustomDiva3D = HHMCIGLCBNG_QualityCustomDiva3D;
			FMKAONAMGCN.AHLFOHJMGAI_QualityCustomOther3D = AHLFOHJMGAI_QualityCustomOther3D;
			FMKAONAMGCN.FPJHOLMLDGC_QualityCustom2D = FPJHOLMLDGC_QualityCustom2D;
			FMKAONAMGCN.OLALFDCEHKJ_Dimmer3d = OLALFDCEHKJ_Dimmer3d;
			FMKAONAMGCN.FPFAMFOPJDJ_Dimmer2d = FPFAMFOPJDJ_Dimmer2d;
			FMKAONAMGCN.CDGKHMEOEMP_ValkyrieMode = CDGKHMEOEMP_ValkyrieMode;
			FMKAONAMGCN.DCHMOFLEFMI_NotesSpeedEasy = DCHMOFLEFMI_NotesSpeedEasy;
			FMKAONAMGCN.MBOEPFLNDOD_NotesSpeedNormal = MBOEPFLNDOD_NotesSpeedNormal;
			FMKAONAMGCN.MGOOLKHAPAF_NotesSpeedHard = MGOOLKHAPAF_NotesSpeedHard;
			FMKAONAMGCN.AIKDLBAANLG_NotesSpeedVeryHard = AIKDLBAANLG_NotesSpeedVeryHard;
			FMKAONAMGCN.KOKDGGOFPPI_NotesSpeedExtreme = KOKDGGOFPPI_NotesSpeedExtreme;
			FMKAONAMGCN.LIPAPGABJOA_NotesSpeedHardPlus = LIPAPGABJOA_NotesSpeedHardPlus;
			FMKAONAMGCN.JDJBFBPBLDC_NotesSpeedVeryHardPlus = JDJBFBPBLDC_NotesSpeedVeryHardPlus;
			FMKAONAMGCN.FJKNAHGFAPP_NotesSpeedExtremePlus  = FJKNAHGFAPP_NotesSpeedExtremePlus;
			FMKAONAMGCN.LHJHOFNIJJF_NotesSpeedSelectDiff = LHJHOFNIJJF_NotesSpeedSelectDiff;
			FMKAONAMGCN.ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode = ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode;
			FMKAONAMGCN.LBIKGDHCICB_NotesSpeedAllApply = LBIKGDHCICB_NotesSpeedAllApply;
			FMKAONAMGCN.JJDENMHGOIH_NotesSpeedAutoRejected = JJDENMHGOIH_NotesSpeedAutoRejected;
			FMKAONAMGCN.KDNKCOAJGCM_NotesType = KDNKCOAJGCM_NotesType;
			FMKAONAMGCN.BBIOMNCILMC_HomeDivaId = BBIOMNCILMC_HomeDivaId;
			FMKAONAMGCN.GDLAPBKCBFP_IsHomeDivaWindow = GDLAPBKCBFP_IsHomeDivaWindow;
			FMKAONAMGCN.BAGJHPGGCCI_PlayLogGraphType = BAGJHPGGCCI_PlayLogGraphType;
			FMKAONAMGCN.EDDMJEMOAGM_IsNotExcellentDisplaySetting = EDDMJEMOAGM_IsNotExcellentDisplaySetting;
			FMKAONAMGCN.CJKKALFPMLA_IsNotDivaModeDivaVisible = CJKKALFPMLA_IsNotDivaModeDivaVisible;
			FMKAONAMGCN.KPFAFLBICLA_IsNotBattleEventInfo = KPFAFLBICLA_IsNotBattleEventInfo;
			FMKAONAMGCN.MJHEPGIEDDL_IsSlideNoteEffect = MJHEPGIEDDL_IsSlideNoteEffect;
			FMKAONAMGCN.HLABNEIEJPM_SafeAreaDesign = HLABNEIEJPM_SafeAreaDesign;
			FMKAONAMGCN.HJPDHDHMOPF_IsNotForceWideScreen = HJPDHDHMOPF_IsNotForceWideScreen;
			FMKAONAMGCN.BIEOIPOLFLN_IsNotPlayRecordFirstLaunch = BIEOIPOLFLN_IsNotPlayRecordFirstLaunch;
        }

        // // RVA: 0x20346A4 Offset: 0x20346A4 VA: 0x20346A4
        public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["volSe"] = BGLLCLEDHKK_VolSe;
			res["volBgm"] = HOMPENLIHCK_VolBgm;
			res["volVoice"] = CNCIMBGLKOB_VolVoice;
			res["screenRotation"] = CJFAJNMADBA_ScreenRotation;
			res["notesRoute"] = NFMEIILKACN_NotesRoute;
			res["noteOffset"] = OJAJHIMOIEC_NoteOffset;
			res["cutin"] = NAGJLEIPAAC_Cutin;
			res["effectCutin"] = DADIPGPHLDD_EffectCutin;
			res["renderQuality"] = DDHCLNFPNGK_RenderQuality;
			res["needInitRenderQuality"] = GEPLOFLHAOL_NeedInitRenderQuality;
			res["volSeRhythm"] = LMDACNNJDOE_VolSeRhythm;
			res["volBgmRhythm"] = ICGAOAFIHFD_VolBgmRhythm;
			res["volVoiceRhythm"] = FCKEDCKCEFC_VolVoiceRhythm;
			res["volNotesRhythm"] = IBEINHHMHAC_VolNotesRhythm;
			res["video"] = PMGMMMGCEEI_Video;
			res["videoMode"] = IHEPCAHBECA_VideoMode;
			res["backKey"] = OAKOJGPBAJF_BackKey;
			res["bgMode"] = MHACPBAPBFE_BgMode;
			res["isDrawKira"] = GACNKPOMOFA_IsDrawKira;
			res["isPlateAnimationHome"] = LENJLNLNPEO_IsPlateAnimationHome;
			res["isPlateAnimationOther"] = DFLJOKOKLIL_IsPlateAnimationOther;
			res["isDivaEffect"] = MDMDEAFFIMB_IsDivaEffect;
			res["qualityCustomDiva3D"] = HHMCIGLCBNG_QualityCustomDiva3D;
			res["qualityCustomOther3D"] = AHLFOHJMGAI_QualityCustomOther3D;
			res["qualityCustom2D"] = FPJHOLMLDGC_QualityCustom2D;
			res["dimmer3d"] = OLALFDCEHKJ_Dimmer3d;
			res["dimmer2d"] = FPFAMFOPJDJ_Dimmer2d;
			res["valkyrieMode"] = CDGKHMEOEMP_ValkyrieMode;
			res["notesSpeedEasy"] = DCHMOFLEFMI_NotesSpeedEasy;
			res["notesSpeedNormal"] = MBOEPFLNDOD_NotesSpeedNormal;
			res["notesSpeedHard"] = MGOOLKHAPAF_NotesSpeedHard;
			res["notesSpeedVeryHard"] = AIKDLBAANLG_NotesSpeedVeryHard;
			res["notesSpeedExtreme"] = KOKDGGOFPPI_NotesSpeedExtreme;
			res["notesSpeedHardPlus"] = LIPAPGABJOA_NotesSpeedHardPlus;
			res["notesSpeedVeryHardPlus"] = JDJBFBPBLDC_NotesSpeedVeryHardPlus;
			res["notesSpeedExtremePlus"] = FJKNAHGFAPP_NotesSpeedExtremePlus;
			res["notesSpeedSelectDiff"] = LHJHOFNIJJF_NotesSpeedSelectDiff;
			res["notesSpeedSelectDiffLine6Mode"] = ODOEJMPJHME_NotesSpeedSelectDiffLine6Mode ? 1 : 0;
			res["notesSpeedAllApply"] = LBIKGDHCICB_NotesSpeedAllApply;
			res["notesSpeedAutoRejected"] = JJDENMHGOIH_NotesSpeedAutoRejected;
			res["notesType"] = KDNKCOAJGCM_NotesType;
			res["homeDivaId"] = BBIOMNCILMC_HomeDivaId;
			res["isHomeDivaWindow"] = GDLAPBKCBFP_IsHomeDivaWindow ? 1 : 0;
			res["playLogGraphType"] = BAGJHPGGCCI_PlayLogGraphType;
			res["isExcellentDisplaySetting"] = EDDMJEMOAGM_IsNotExcellentDisplaySetting ? 0 : 1;
			res["isDivaModeDivaVisible"] = CJKKALFPMLA_IsNotDivaModeDivaVisible ? 0 : 1;
			res["isBattleEventInfo"] = KPFAFLBICLA_IsNotBattleEventInfo ? 0 : 1;
			res["isSlideNoteEffect"] = MJHEPGIEDDL_IsSlideNoteEffect ? 0 : 1;
			res["safeAreaDesign"] = HLABNEIEJPM_SafeAreaDesign;
			res["isPlayRecordFirstLaunch"] = BIEOIPOLFLN_IsNotPlayRecordFirstLaunch ? 0 : 1;
			SystemManager.SetForceWideScreen(HJPDHDHMOPF_IsNotForceWideScreen == 0);
			return res;
		}

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
			EDDMJEMOAGM_IsNotExcellentDisplaySetting = JsonUtil.GetInt(OBHAFLMHAKG, "isExcellentDisplaySetting", 0) == 0;
			CJKKALFPMLA_IsNotDivaModeDivaVisible = JsonUtil.GetInt(OBHAFLMHAKG, "isDivaModeDivaVisible", 0) == 0;
			KPFAFLBICLA_IsNotBattleEventInfo = JsonUtil.GetInt(OBHAFLMHAKG, "isBattleEventInfo", 0) == 0;
			MJHEPGIEDDL_IsSlideNoteEffect = JsonUtil.GetInt(OBHAFLMHAKG, "isSlideNoteEffect", 0) == 0;
			HLABNEIEJPM_SafeAreaDesign = JsonUtil.GetInt(OBHAFLMHAKG, "safeAreaDesign", 0);
			BIEOIPOLFLN_IsNotPlayRecordFirstLaunch = JsonUtil.GetInt(OBHAFLMHAKG, "isPlayRecordFirstLaunch", 0) == 0;
			HJPDHDHMOPF_IsNotForceWideScreen = SystemManager.IsForceWideScreen ? 0 : 1;
		}
		
	}

	public class APLMBKKCNKC_Select
	{
		public class EJBBPMBEKLP_Live
		{
			private static readonly int LNHIHOKKPFF = FreeCategoryId.ArrayNum; // 0x0
			private int OMKLPMBJLIO_CategoryId; // 0x8 // FreeCategoryId
			private int HNKJDJFFACC_Diff; // 0xC // difficulty
			private List<int> LGMDOEIPLAK_FreeMusicIds; // 0x10
			private List<int> AADOPBAMLJK_GameEventTypes; // 0x14
			private int PFHPKAGBMOK_PlayDashEventId; // 0x18
			private int LPPHJLBNAEO_PlayDashSelect; // 0x1C
			private bool PMDNOPLFCNH_IsLine6; // 0x20
			private StringBuilder KKELPILEDDD; // 0x24

			// // RVA: 0x2022BB8 Offset: 0x2022BB8 VA: 0x2022BB8
			public EJBBPMBEKLP_Live()
			{
				HNKJDJFFACC_Diff = 0;
				OMKLPMBJLIO_CategoryId = 0;
				PMDNOPLFCNH_IsLine6 = false;
				LGMDOEIPLAK_FreeMusicIds = new List<int>(LNHIHOKKPFF);
				AADOPBAMLJK_GameEventTypes = new List<int>(LNHIHOKKPFF);
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(0);
					AADOPBAMLJK_GameEventTypes.Add(0);
				}
				KKELPILEDDD = new StringBuilder(32);
			}

			// // RVA: 0x2023BBC Offset: 0x2023BBC VA: 0x2023BBC
			public static bool CHDGLBBFEKH_IsEqual(EJBBPMBEKLP_Live LFGLBIAODLE, EJBBPMBEKLP_Live CJDJGHIIBHP)
			{
				if (!(LFGLBIAODLE.OMKLPMBJLIO_CategoryId == CJDJGHIIBHP.OMKLPMBJLIO_CategoryId &&
					LFGLBIAODLE.HNKJDJFFACC_Diff == CJDJGHIIBHP.HNKJDJFFACC_Diff &&
					LFGLBIAODLE.PMDNOPLFCNH_IsLine6 == CJDJGHIIBHP.PMDNOPLFCNH_IsLine6 && 
					LFGLBIAODLE.PFHPKAGBMOK_PlayDashEventId == CJDJGHIIBHP.PFHPKAGBMOK_PlayDashEventId &&
					LFGLBIAODLE.LPPHJLBNAEO_PlayDashSelect == CJDJGHIIBHP.LPPHJLBNAEO_PlayDashSelect))
					return false;
				for (int i = 0; i < LNHIHOKKPFF; i++)
				{
					if (LFGLBIAODLE.LGMDOEIPLAK_FreeMusicIds[i] != CJDJGHIIBHP.LGMDOEIPLAK_FreeMusicIds[i])
						return false;
					if (LFGLBIAODLE.AADOPBAMLJK_GameEventTypes[i] != CJDJGHIIBHP.AADOPBAMLJK_GameEventTypes[i])
						return false;
				}
				return true;
			}

			// // RVA: 0x201EA24 Offset: 0x201EA24 VA: 0x201EA24
			public static bool HMMFJOEBEKJ(EJBBPMBEKLP_Live LFGLBIAODLE, EJBBPMBEKLP_Live CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
			}

			// // RVA: 0x201EEF4 Offset: 0x201EEF4 VA: 0x201EEF4
			public void ODDIHGPONFL_Copy(ILDKBCLAFPB.APLMBKKCNKC_Select.EJBBPMBEKLP_Live PJFKNNNDMIA)
			{
				PJFKNNNDMIA.OMKLPMBJLIO_CategoryId = OMKLPMBJLIO_CategoryId;
				PJFKNNNDMIA.HNKJDJFFACC_Diff = HNKJDJFFACC_Diff;
				PJFKNNNDMIA.PMDNOPLFCNH_IsLine6 = PMDNOPLFCNH_IsLine6;
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.AddRange(LGMDOEIPLAK_FreeMusicIds);
				PJFKNNNDMIA.AADOPBAMLJK_GameEventTypes.Clear();
				PJFKNNNDMIA.AADOPBAMLJK_GameEventTypes.AddRange(AADOPBAMLJK_GameEventTypes);
				PJFKNNNDMIA.PFHPKAGBMOK_PlayDashEventId = PFHPKAGBMOK_PlayDashEventId;
				PJFKNNNDMIA.LPPHJLBNAEO_PlayDashSelect = LPPHJLBNAEO_PlayDashSelect;
			}

			// // RVA: 0x201FC3C Offset: 0x201FC3C VA: 0x201FC3C
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["categoryId"] = OMKLPMBJLIO_CategoryId;
				res["difficulty"] = HNKJDJFFACC_Diff;
				res["isLine6"] = PMDNOPLFCNH_IsLine6 ? 1 : 0;
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					res[IAMECBIFIKA("freeMusicId_{0:D2}", i)] = LGMDOEIPLAK_FreeMusicIds[i];
					res[IAMECBIFIKA("gameEventType_{0:D2}", i)] = AADOPBAMLJK_GameEventTypes[i];
				}
				res["playDashEventId"] = PFHPKAGBMOK_PlayDashEventId;
				res["playDashSelect"] = LPPHJLBNAEO_PlayDashSelect;
				return res;
			}

			// // RVA: 0x20219D4 Offset: 0x20219D4 VA: 0x20219D4
			public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				OMKLPMBJLIO_CategoryId = JsonUtil.GetInt(OBHAFLMHAKG, "categoryId", 4);
				HNKJDJFFACC_Diff = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				PMDNOPLFCNH_IsLine6 = JsonUtil.GetFlag(OBHAFLMHAKG, "isLine6", false);
				LGMDOEIPLAK_FreeMusicIds.Clear();
				AADOPBAMLJK_GameEventTypes.Clear();
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicId_{0:D2}", i), 0));
					AADOPBAMLJK_GameEventTypes.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("gameEventType_{0:D2}", i), 0));
				}
				PFHPKAGBMOK_PlayDashEventId = JsonUtil.GetInt(OBHAFLMHAKG, "playDashEventId", 0);
				LPPHJLBNAEO_PlayDashSelect = JsonUtil.GetInt(OBHAFLMHAKG, "playDashSelect", 0);
			}

			// // RVA: 0x2023DF4 Offset: 0x2023DF4 VA: 0x2023DF4
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}

			// // RVA: 0x2023EAC Offset: 0x2023EAC VA: 0x2023EAC
			public FreeCategoryId.Type OGJDBPMKJKE_GetCategoryId()
			{
				return (FreeCategoryId.Type)OMKLPMBJLIO_CategoryId;
			}

			// // RVA: 0x2023EB4 Offset: 0x2023EB4 VA: 0x2023EB4
			public Difficulty.Type FFACBDAJJJP_GetDifficulty()
			{
				return (Difficulty.Type)HNKJDJFFACC_Diff;
			}

			// // RVA: 0x2023EBC Offset: 0x2023EBC VA: 0x2023EBC
			public bool LMPCJJKHHPA_IsLine6() 
			{
				return PMDNOPLFCNH_IsLine6;
			}

			// // RVA: 0x2023EC4 Offset: 0x2023EC4 VA: 0x2023EC4
			// public int BKCOOGKFJJF() { }

			// // RVA: 0x2023ECC Offset: 0x2023ECC VA: 0x2023ECC
			// public int GHEFLJANGIC() { }

			// // RVA: 0x2023ED4 Offset: 0x2023ED4 VA: 0x2023ED4
			public void FKJBADIPKHK_GetSelectionForCategory(FreeCategoryId.Type DEPGBBJMFED_CategoryId, out int GHBPLHBNMBK_MusicId, out OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType)
			{
				GHBPLHBNMBK_MusicId = LGMDOEIPLAK_FreeMusicIds[(int)DEPGBBJMFED_CategoryId - 1];
				HIDHLFCBIDE_EventType = (OHCAABOMEOF.KGOGMKMBCPP_EventType)AADOPBAMLJK_GameEventTypes[(int)DEPGBBJMFED_CategoryId - 1];
			}

			// // RVA: 0x2023F98 Offset: 0x2023F98 VA: 0x2023F98
			public void NGNECOFAMKP(FreeCategoryId.Type DEPGBBJMFED)
			{
				OMKLPMBJLIO_CategoryId = (int)DEPGBBJMFED;
			}

			// // RVA: 0x2023FA0 Offset: 0x2023FA0 VA: 0x2023FA0
			// public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK) { }

			// // RVA: 0x2023FA8 Offset: 0x2023FA8 VA: 0x2023FA8
			public void HPDBEKAGKOD_SetIsLine6(bool GIKLNODJKFK)
			{
				PMDNOPLFCNH_IsLine6 = GIKLNODJKFK;
			}

			// // RVA: 0x2023FB0 Offset: 0x2023FB0 VA: 0x2023FB0
			// public void KJGPOAEGFHK(int EKANGPODCEP, int MCNEIJAOLNO) { }

			// // RVA: 0x2023FBC Offset: 0x2023FBC VA: 0x2023FBC
			public void ACGKEJKPFIA(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK, OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE)
			{
				LGMDOEIPLAK_FreeMusicIds[(int)DEPGBBJMFED - 1] = GHBPLHBNMBK;
				AADOPBAMLJK_GameEventTypes[(int)DEPGBBJMFED - 1] = (int)HIDHLFCBIDE;
			}
		}


		public class GADJIIFFPFI_NewLive
		{
			private int FFAKPFEGCOG_Series = 0; // 0x8
			private int HNKJDJFFACC_Diff = 0; // 0xC
			private List<int> LGMDOEIPLAK_SongIds = new List<int>(2) { 0, 0 }; // 0x10
			private List<int> AADOPBAMLJK_EventType = new List<int>(2) { 0, 0 }; // 0x14
			private int PFHPKAGBMOK_PlayDashEventId; // 0x18
			private int LPPHJLBNAEO_PlayDashSelect; // 0x1C
			private bool PMDNOPLFCNH_Is6LineMode = false; // 0x20 IS 6 line
			private bool KLABKJNFCPD_IsEventTab = false; // 0x21
			private bool PGNNDICEIBG_IsSmallOrder = true; // 0x22
			private StringBuilder KKELPILEDDD = new StringBuilder(32); // 0x24

			// // RVA: 0x202417C Offset: 0x202417C VA: 0x202417C
			public static bool CHDGLBBFEKH(GADJIIFFPFI_NewLive LFGLBIAODLE, GADJIIFFPFI_NewLive CJDJGHIIBHP)
			{
				if (!(LFGLBIAODLE.FFAKPFEGCOG_Series == CJDJGHIIBHP.FFAKPFEGCOG_Series &&
					LFGLBIAODLE.HNKJDJFFACC_Diff == CJDJGHIIBHP.HNKJDJFFACC_Diff &&
					LFGLBIAODLE.PMDNOPLFCNH_Is6LineMode == CJDJGHIIBHP.PMDNOPLFCNH_Is6LineMode &&
					LFGLBIAODLE.KLABKJNFCPD_IsEventTab == CJDJGHIIBHP.KLABKJNFCPD_IsEventTab &&
					LFGLBIAODLE.PGNNDICEIBG_IsSmallOrder == CJDJGHIIBHP.PGNNDICEIBG_IsSmallOrder &&
					LFGLBIAODLE.PFHPKAGBMOK_PlayDashEventId == CJDJGHIIBHP.PFHPKAGBMOK_PlayDashEventId &&
					LFGLBIAODLE.LPPHJLBNAEO_PlayDashSelect == CJDJGHIIBHP.LPPHJLBNAEO_PlayDashSelect))
					return false;
				for(int i = 0; i < 2; i++)
				{
					if (LFGLBIAODLE.LGMDOEIPLAK_SongIds[i] != CJDJGHIIBHP.LGMDOEIPLAK_SongIds[i])
						return false;
					if (LFGLBIAODLE.AADOPBAMLJK_EventType[i] != CJDJGHIIBHP.AADOPBAMLJK_EventType[i])
						return false;
				}
				return true;
			}

			// // RVA: 0x201EAB0 Offset: 0x201EAB0 VA: 0x201EAB0
			public static bool HMMFJOEBEKJ(GADJIIFFPFI_NewLive LFGLBIAODLE, GADJIIFFPFI_NewLive CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			// // RVA: 0x201F084 Offset: 0x201F084 VA: 0x201F084
			public void ODDIHGPONFL_Copy(GADJIIFFPFI_NewLive PJFKNNNDMIA)
			{
				PJFKNNNDMIA.FFAKPFEGCOG_Series = FFAKPFEGCOG_Series;
				PJFKNNNDMIA.HNKJDJFFACC_Diff = HNKJDJFFACC_Diff;
				PJFKNNNDMIA.PMDNOPLFCNH_Is6LineMode = PMDNOPLFCNH_Is6LineMode;
				PJFKNNNDMIA.KLABKJNFCPD_IsEventTab = KLABKJNFCPD_IsEventTab;
				PJFKNNNDMIA.PGNNDICEIBG_IsSmallOrder = PGNNDICEIBG_IsSmallOrder;
				PJFKNNNDMIA.LGMDOEIPLAK_SongIds.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK_SongIds.AddRange(LGMDOEIPLAK_SongIds);
				PJFKNNNDMIA.AADOPBAMLJK_EventType.Clear();
				PJFKNNNDMIA.AADOPBAMLJK_EventType.AddRange(AADOPBAMLJK_EventType);
				PJFKNNNDMIA.PFHPKAGBMOK_PlayDashEventId = PFHPKAGBMOK_PlayDashEventId;
				PJFKNNNDMIA.LPPHJLBNAEO_PlayDashSelect = LPPHJLBNAEO_PlayDashSelect;
			}

			// // RVA: 0x2020030 Offset: 0x2020030 VA: 0x2020030
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["selectSeriesId"] = FFAKPFEGCOG_Series;
				res["difficulty"] = HNKJDJFFACC_Diff;
				res["isLine6"] = PMDNOPLFCNH_Is6LineMode ? 1 : 0;
				res["isEvent"] = KLABKJNFCPD_IsEventTab ? 1 : 0;
				res["isSmallOrder"] = PGNNDICEIBG_IsSmallOrder ? 1 : 0;
				for(int i = 0; i < 2; i++)
				{
					res[IAMECBIFIKA("freeMusicId_{0:D2}", i)] = LGMDOEIPLAK_SongIds[i];
					res[IAMECBIFIKA("gameEventType_{0:D2}", i)] = AADOPBAMLJK_EventType[i];
				}
				res["playDashEventId"] = PFHPKAGBMOK_PlayDashEventId;
				res["playDashSelect"] = LPPHJLBNAEO_PlayDashSelect;
				return res;
			}

			// // RVA: 0x2021C78 Offset: 0x2021C78 VA: 0x2021C78
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				FFAKPFEGCOG_Series = JsonUtil.GetInt(OBHAFLMHAKG, "selectSeriesId", 0);
				HNKJDJFFACC_Diff = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				PMDNOPLFCNH_Is6LineMode = JsonUtil.GetFlag(OBHAFLMHAKG, "isLine6", false);
				KLABKJNFCPD_IsEventTab = JsonUtil.GetFlag(OBHAFLMHAKG, "isEvent", false);
				PGNNDICEIBG_IsSmallOrder = JsonUtil.GetFlag(OBHAFLMHAKG, "isSmallOrder", true);
				LGMDOEIPLAK_SongIds.Clear();
				AADOPBAMLJK_EventType.Clear();
				for(int i = 0; i < 2; i++)
				{
					LGMDOEIPLAK_SongIds.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicId_{0:D2}", i), 0));
					AADOPBAMLJK_EventType.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("gameEventType_{0:D2}", i), 0));
				}
				PFHPKAGBMOK_PlayDashEventId = JsonUtil.GetInt(OBHAFLMHAKG, "playDashEventId", 0);
				LPPHJLBNAEO_PlayDashSelect = JsonUtil.GetInt(OBHAFLMHAKG, "playDashSelect", 0);
			}

			// // RVA: 0x202439C Offset: 0x202439C VA: 0x202439C
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}

			// // RVA: 0x2024454 Offset: 0x2024454 VA: 0x2024454
			public MusicSelectConsts.SeriesType GPAJHMLOPNP_GetSeries()
			{
				return (MusicSelectConsts.SeriesType)FFAKPFEGCOG_Series;
			}

			// // RVA: 0x202445C Offset: 0x202445C VA: 0x202445C
			public Difficulty.Type FFACBDAJJJP_GetDifficulty()
			{
				return (Difficulty.Type)HNKJDJFFACC_Diff;
			}

			// // RVA: 0x2024464 Offset: 0x2024464 VA: 0x2024464
			public bool LMPCJJKHHPA_Is6LineMode()
			{
				return PMDNOPLFCNH_Is6LineMode;
			} // is 6 line

			// // RVA: 0x202446C Offset: 0x202446C VA: 0x202446C
			public bool OAALFANHEHL_IsEventTab()
			{
				return KLABKJNFCPD_IsEventTab;
			}

			// // RVA: 0x2024474 Offset: 0x2024474 VA: 0x2024474
			public bool CFNMCFDDOJO()
			{
				return PGNNDICEIBG_IsSmallOrder;
			}

			// // RVA: 0x202447C Offset: 0x202447C VA: 0x202447C
			// public int BKCOOGKFJJF() { }

			// // RVA: 0x2024484 Offset: 0x2024484 VA: 0x2024484
			// public int GHEFLJANGIC() { }

			// // RVA: 0x202448C Offset: 0x202448C VA: 0x202448C
			public void FKJBADIPKHK_GetSelectedSong(bool FAGEBAKNAOB_IsEvent, out int GHBPLHBNMBK_SongId, out OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType)
			{
				GHBPLHBNMBK_SongId = LGMDOEIPLAK_SongIds[FAGEBAKNAOB_IsEvent ? 1 : 0];
				HIDHLFCBIDE_EventType = (OHCAABOMEOF.KGOGMKMBCPP_EventType)AADOPBAMLJK_EventType[FAGEBAKNAOB_IsEvent ? 1 : 0];
				Debug.Log("Get Song : IsEvent="+FAGEBAKNAOB_IsEvent+" songId="+GHBPLHBNMBK_SongId+" EventType="+HIDHLFCBIDE_EventType);
			}

			// // RVA: 0x202454C Offset: 0x202454C VA: 0x202454C
			public void GJDEHJBAMNH_SetSeries(MusicSelectConsts.SeriesType MGBDCFIKBPM)
			{
				FFAKPFEGCOG_Series = (int)MGBDCFIKBPM;
			}

			// // RVA: 0x2024554 Offset: 0x2024554 VA: 0x2024554
			public void HJHBGHMNGKL_SetDifficulty(Difficulty.Type AKNELONELJK)
			{
				HNKJDJFFACC_Diff = (int)AKNELONELJK;
			}

			// // RVA: 0x202455C Offset: 0x202455C VA: 0x202455C
			public void HPDBEKAGKOD_SetIsLine6Mode(bool GIKLNODJKFK)
			{
				PMDNOPLFCNH_Is6LineMode = GIKLNODJKFK;
			}

			// // RVA: 0x2024564 Offset: 0x2024564 VA: 0x2024564
			public void ABGEMNAHALF_SetIsEventTab(bool FAGEBAKNAOB)
			{
				KLABKJNFCPD_IsEventTab = FAGEBAKNAOB;
			}

			// // RVA: 0x202456C Offset: 0x202456C VA: 0x202456C
			public void BKFOJBAGDHN_SetIsSmallOrder(bool GNLIFHBDDIL)
			{
				PGNNDICEIBG_IsSmallOrder = GNLIFHBDDIL;
			}

			// // RVA: 0x2024574 Offset: 0x2024574 VA: 0x2024574
			// public void KJGPOAEGFHK(int EKANGPODCEP, int MCNEIJAOLNO) { }

			// // RVA: 0x2024580 Offset: 0x2024580 VA: 0x2024580
			public void ACGKEJKPFIA_SetSelectedSong(bool FAGEBAKNAOB_IsEvent, int GHBPLHBNMBK_SongId, OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType)
			{
				Debug.Log("Save Song : IsEvent="+FAGEBAKNAOB_IsEvent+" songId="+GHBPLHBNMBK_SongId+" EventType="+HIDHLFCBIDE_EventType);
				LGMDOEIPLAK_SongIds[FAGEBAKNAOB_IsEvent ? 1 : 0] = GHBPLHBNMBK_SongId;
				AADOPBAMLJK_EventType[FAGEBAKNAOB_IsEvent ? 1 : 0] = (int)HIDHLFCBIDE_EventType;
			}
		}
		
		public class IEFBBNFNKIJ_CollectEvent
		{
			private int NFFKLFEOPMO_EventId = 0; // 0x8
			private int HNKJDJFFACC_Difficulty = 0; // 0xC
			private int MPKGEHBJOJM_FreeMusicId = 0; // 0x10

			//// RVA: 0x2024640 Offset: 0x2024640 VA: 0x2024640
			public static bool CHDGLBBFEKH(IEFBBNFNKIJ_CollectEvent LFGLBIAODLE, IEFBBNFNKIJ_CollectEvent CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
						LFGLBIAODLE.HNKJDJFFACC_Difficulty == CJDJGHIIBHP.HNKJDJFFACC_Difficulty &&
						LFGLBIAODLE.MPKGEHBJOJM_FreeMusicId == CJDJGHIIBHP.MPKGEHBJOJM_FreeMusicId)
					return true;
				return false;
			}

			//// RVA: 0x201EAC4 Offset: 0x201EAC4 VA: 0x201EAC4
			public static bool HMMFJOEBEKJ(IEFBBNFNKIJ_CollectEvent LFGLBIAODLE, IEFBBNFNKIJ_CollectEvent CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F240 Offset: 0x201F240 VA: 0x201F240
			public void ODDIHGPONFL_Copy(IEFBBNFNKIJ_CollectEvent PJFKNNNDMIA)
			{
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.HNKJDJFFACC_Difficulty = HNKJDJFFACC_Difficulty;
				PJFKNNNDMIA.MPKGEHBJOJM_FreeMusicId = MPKGEHBJOJM_FreeMusicId;
			}

			//// RVA: 0x20204B4 Offset: 0x20204B4 VA: 0x20204B4
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["difficulty"] = HNKJDJFFACC_Difficulty;
				res["freeMusicId"] = MPKGEHBJOJM_FreeMusicId;
				return res;
			}

			//// RVA: 0x2021F1C Offset: 0x2021F1C VA: 0x2021F1C
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				HNKJDJFFACC_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				MPKGEHBJOJM_FreeMusicId = JsonUtil.GetInt(OBHAFLMHAKG, "freeMusicId", 0);
			}

			//// RVA: 0x20246B0 Offset: 0x20246B0 VA: 0x20246B0
			//public bool FKEJBAHCMGC(int LHMJFCCBPPN) { }

			//// RVA: 0x20246DC Offset: 0x20246DC VA: 0x20246DC
			//public Difficulty.Type FFACBDAJJJP() { }

			//// RVA: 0x20246E4 Offset: 0x20246E4 VA: 0x20246E4
			//public int BMBELGEDKEG() { }

			//// RVA: 0x20246EC Offset: 0x20246EC VA: 0x20246EC
			//public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK) { }

			//// RVA: 0x20246F4 Offset: 0x20246F4 VA: 0x20246F4
			//public void PDOLFONNGHB(int GHBPLHBNMBK) { }
		}
		
		public class FLOIJPMBBIL_BattleEvent
		{
			private int NFFKLFEOPMO_EventId = 0; // 0x8
			private int HNKJDJFFACC_Difficulty = 0; // 0xC

			//// RVA: 0x20240E8 Offset: 0x20240E8 VA: 0x20240E8
			public static bool CHDGLBBFEKH(FLOIJPMBBIL_BattleEvent LFGLBIAODLE, FLOIJPMBBIL_BattleEvent CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
					LFGLBIAODLE.HNKJDJFFACC_Difficulty == CJDJGHIIBHP.HNKJDJFFACC_Difficulty)
					return true;
				return false;
			}

			//// RVA: 0x201EAD8 Offset: 0x201EAD8 VA: 0x201EAD8
			public static bool HMMFJOEBEKJ(FLOIJPMBBIL_BattleEvent LFGLBIAODLE, FLOIJPMBBIL_BattleEvent CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F2A8 Offset: 0x201F2A8 VA: 0x201F2A8
			public void ODDIHGPONFL_Copy(FLOIJPMBBIL_BattleEvent PJFKNNNDMIA)
			{
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.HNKJDJFFACC_Difficulty = HNKJDJFFACC_Difficulty;
			}

			//// RVA: 0x2020608 Offset: 0x2020608 VA: 0x2020608
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["difficulty"] = HNKJDJFFACC_Difficulty;
				return res;
			}

			//// RVA: 0x2021FD8 Offset: 0x2021FD8 VA: 0x2021FD8
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				HNKJDJFFACC_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
			}

			//// RVA: 0x2024148 Offset: 0x2024148 VA: 0x2024148
			//public bool FKEJBAHCMGC(int LHMJFCCBPPN) { }

			//// RVA: 0x202416C Offset: 0x202416C VA: 0x202416C
			public Difficulty.Type FFACBDAJJJP_GetDifficulty()
			{
				return (Difficulty.Type)HNKJDJFFACC_Difficulty;
			}

			//// RVA: 0x2024174 Offset: 0x2024174 VA: 0x2024174
			public void HJHBGHMNGKL_SetDifficulty(Difficulty.Type AKNELONELJK)
			{
				HNKJDJFFACC_Difficulty = (int)AKNELONELJK;
			}
		}
		
		public class PLHMBFFLEPB_MissionEvent
		{
			private static readonly int LNHIHOKKPFF = FreeCategoryId.ArrayNum; // 0x0
			private int NFFKLFEOPMO_EventId = 0; // 0x8
			private int HNKJDJFFACC_Difficulty = 0; // 0xC
			private int OMKLPMBJLIO_CategoryId; // 0x10
			private List<int> LGMDOEIPLAK_FreeMusicIds = new List<int>(LNHIHOKKPFF); // 0x14
			private StringBuilder KKELPILEDDD = new StringBuilder(64); // 0x18

			// RVA: 0x2022F5C Offset: 0x2022F5C VA: 0x2022F5C
			public PLHMBFFLEPB_MissionEvent()
			{
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(0);
				}
			}

			//// RVA: 0x2024CDC Offset: 0x2024CDC VA: 0x2024CDC
			public static bool CHDGLBBFEKH(PLHMBFFLEPB_MissionEvent LFGLBIAODLE, PLHMBFFLEPB_MissionEvent CJDJGHIIBHP)
			{
				if (!(LFGLBIAODLE.OMKLPMBJLIO_CategoryId == CJDJGHIIBHP.OMKLPMBJLIO_CategoryId &&
					LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
					LFGLBIAODLE.HNKJDJFFACC_Difficulty == CJDJGHIIBHP.HNKJDJFFACC_Difficulty))
					return false;
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					if (LFGLBIAODLE.LGMDOEIPLAK_FreeMusicIds[i] != CJDJGHIIBHP.LGMDOEIPLAK_FreeMusicIds[i])
						return false;
				}
				return true;
			}

			//// RVA: 0x201EAEC Offset: 0x201EAEC VA: 0x201EAEC
			public static bool HMMFJOEBEKJ(PLHMBFFLEPB_MissionEvent LFGLBIAODLE, PLHMBFFLEPB_MissionEvent CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F2F4 Offset: 0x201F2F4 VA: 0x201F2F4
			public void ODDIHGPONFL(PLHMBFFLEPB_MissionEvent PJFKNNNDMIA)
			{
				PJFKNNNDMIA.OMKLPMBJLIO_CategoryId = OMKLPMBJLIO_CategoryId;
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.HNKJDJFFACC_Difficulty = HNKJDJFFACC_Difficulty;
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.AddRange(LGMDOEIPLAK_FreeMusicIds);
			}

			//// RVA: 0x202071C Offset: 0x202071C VA: 0x202071C
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["difficulty"] = HNKJDJFFACC_Difficulty;
				res["categoryId"] = OMKLPMBJLIO_CategoryId;
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					res["freeMusicId_{0:D2}"] = LGMDOEIPLAK_FreeMusicIds[i];
				}
				return res;
			}

			//// RVA: 0x2022070 Offset: 0x2022070 VA: 0x2022070
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				HNKJDJFFACC_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				OMKLPMBJLIO_CategoryId = JsonUtil.GetInt(OBHAFLMHAKG, "categoryId", 0);
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicid_{0:D2}", i), 0));
				}
			}

			//// RVA: 0x2024F1C Offset: 0x2024F1C VA: 0x2024F1C
			//public bool FKEJBAHCMGC(int LHMJFCCBPPN) { }

			//// RVA: 0x2024F40 Offset: 0x2024F40 VA: 0x2024F40
			//public Difficulty.Type FFACBDAJJJP() { }

			//// RVA: 0x2024F48 Offset: 0x2024F48 VA: 0x2024F48
			//public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK) { }

			//// RVA: 0x2024F50 Offset: 0x2024F50 VA: 0x2024F50
			//public void NGNECOFAMKP(FreeCategoryId.Type DEPGBBJMFED) { }

			//// RVA: 0x2024F58 Offset: 0x2024F58 VA: 0x2024F58
			//public void ACGKEJKPFIA(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK) { }

			//// RVA: 0x2024FE4 Offset: 0x2024FE4 VA: 0x2024FE4
			//public void FKJBADIPKHK(FreeCategoryId.Type DEPGBBJMFED, out int GHBPLHBNMBK) { }

			//// RVA: 0x2024E64 Offset: 0x2024E64 VA: 0x2024E64
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}
		}
		
		public class CGAJFHFIGJG_GoDivaEvent
		{
			private static readonly int LNHIHOKKPFF = FreeCategoryId.ArrayNum; // 0x0
			private int NFFKLFEOPMO_EventId = 0; // 0x8
			private bool CPDGABHJCLO_HideBonusClosePopupFlag = false; // 0xC
			private int HNKJDJFFACC_Difficulty = 0; // 0x10
			private List<int> LGMDOEIPLAK_FreeMusicIds = new List<int>(LNHIHOKKPFF); // 0x14
			private StringBuilder KKELPILEDDD = new StringBuilder(); // 0x18

			// RVA: 0x20230E8 Offset: 0x20230E8 VA: 0x20230E8
			public CGAJFHFIGJG_GoDivaEvent()
			{
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(0);
				}
			}

			//// RVA: 0x2023578 Offset: 0x2023578 VA: 0x2023578
			public static bool CHDGLBBFEKH(CGAJFHFIGJG_GoDivaEvent LFGLBIAODLE, CGAJFHFIGJG_GoDivaEvent CJDJGHIIBHP)
			{
				if (!(LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
					LFGLBIAODLE.CPDGABHJCLO_HideBonusClosePopupFlag == CJDJGHIIBHP.CPDGABHJCLO_HideBonusClosePopupFlag &&
					LFGLBIAODLE.HNKJDJFFACC_Difficulty == CJDJGHIIBHP.HNKJDJFFACC_Difficulty))
					return false;
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					if (LFGLBIAODLE.LGMDOEIPLAK_FreeMusicIds[i] != CJDJGHIIBHP.LGMDOEIPLAK_FreeMusicIds[i])
						return false;
				}
				return true;
			}

			//// RVA: 0x201EB78 Offset: 0x201EB78 VA: 0x201EB78
			public static bool HMMFJOEBEKJ(CGAJFHFIGJG_GoDivaEvent LFGLBIAODLE, CGAJFHFIGJG_GoDivaEvent CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F408 Offset: 0x201F408 VA: 0x201F408
			public void ODDIHGPONFL_Copy(CGAJFHFIGJG_GoDivaEvent PJFKNNNDMIA)
			{
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.CPDGABHJCLO_HideBonusClosePopupFlag = CPDGABHJCLO_HideBonusClosePopupFlag;
				PJFKNNNDMIA.HNKJDJFFACC_Difficulty = HNKJDJFFACC_Difficulty;
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.AddRange(LGMDOEIPLAK_FreeMusicIds);
			}

			//// RVA: 0x202099C Offset: 0x202099C VA: 0x202099C
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["hideBonusClosePopupFlag"] = CPDGABHJCLO_HideBonusClosePopupFlag ? 1 : 0;
				res["difficulty"] = HNKJDJFFACC_Difficulty;
				for (int i = 0; i < LNHIHOKKPFF; i++)
				{
					res[IAMECBIFIKA("freeMusicId_{0:D2}", i)] = LGMDOEIPLAK_FreeMusicIds[i];
				}
				return res;
			}

			//// RVA: 0x20221FC Offset: 0x20221FC VA: 0x20221FC
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				CPDGABHJCLO_HideBonusClosePopupFlag = JsonUtil.GetInt(OBHAFLMHAKG, "hideBonusClosePopupFlag", 0) != 0;
				HNKJDJFFACC_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				LGMDOEIPLAK_FreeMusicIds.Clear();
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicId_{0:D2}", i), 0));
				}
			}

			//// RVA: 0x20237C8 Offset: 0x20237C8 VA: 0x20237C8
			public bool FKEJBAHCMGC_SetEventId(int LHMJFCCBPPN)
			{
				if(NFFKLFEOPMO_EventId != LHMJFCCBPPN)
				{
					NFFKLFEOPMO_EventId = LHMJFCCBPPN;
					HNKJDJFFACC_Difficulty = 0;
					return true;
				}
				return false;
			}

			//// RVA: 0x20237EC Offset: 0x20237EC VA: 0x20237EC
			public bool KOGLAOFGHEN_GetHideBonusClosePopupFlag()
			{
				return CPDGABHJCLO_HideBonusClosePopupFlag;
			}

			//// RVA: 0x20237F4 Offset: 0x20237F4 VA: 0x20237F4
			public void LMENKAFNADG_SetHideBonusClosePopupFlag(bool LPJJLOIFCID)
			{
				CPDGABHJCLO_HideBonusClosePopupFlag = LPJJLOIFCID;
			}

			//// RVA: 0x20237FC Offset: 0x20237FC VA: 0x20237FC
			public Difficulty.Type FFACBDAJJJP_GetDifficulty()
			{
				return (Difficulty.Type) HNKJDJFFACC_Difficulty;
			}

			//// RVA: 0x2023804 Offset: 0x2023804 VA: 0x2023804
			public void HJHBGHMNGKL_SetDifficulty(Difficulty.Type AKNELONELJK)
			{
				HNKJDJFFACC_Difficulty = (int)AKNELONELJK;
			}

			//// RVA: 0x202380C Offset: 0x202380C VA: 0x202380C
			public void ACGKEJKPFIA_SetFreeMusicId(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK)
			{
				LGMDOEIPLAK_FreeMusicIds[(int)DEPGBBJMFED - 1] = GHBPLHBNMBK;
			}

			//// RVA: 0x2023898 Offset: 0x2023898 VA: 0x2023898
			public void FKJBADIPKHK_GetFreeMusicId(FreeCategoryId.Type DEPGBBJMFED, out int GHBPLHBNMBK)
			{
				GHBPLHBNMBK = LGMDOEIPLAK_FreeMusicIds[(int)DEPGBBJMFED - 1];
			}

			//// RVA: 0x2023710 Offset: 0x2023710 VA: 0x2023710
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}
		}
		
		public class MBNCBCJKCEA_Raid
		{
			private static readonly int LNHIHOKKPFF = FreeCategoryId.ArrayNum; // 0x0
			private int NFFKLFEOPMO_EventId = 0; // 0x8
			private int HNKJDJFFACC_Difficulty = 0; // 0xC
			private int OMKLPMBJLIO_CategoryId; // 0x10
			private List<int> LGMDOEIPLAK_FreeMusicIds = new List<int>(LNHIHOKKPFF); // 0x14
			private StringBuilder KKELPILEDDD = new StringBuilder(); // 0x18

			// RVA: 0x2023278 Offset: 0x2023278 VA: 0x2023278
			public MBNCBCJKCEA_Raid()
			{
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(0);
				}
			}

			//// RVA: 0x202481C Offset: 0x202481C VA: 0x202481C
			public static bool CHDGLBBFEKH(MBNCBCJKCEA_Raid LFGLBIAODLE, MBNCBCJKCEA_Raid CJDJGHIIBHP)
			{
				if (!(LFGLBIAODLE.OMKLPMBJLIO_CategoryId == CJDJGHIIBHP.OMKLPMBJLIO_CategoryId &&
					LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
					LFGLBIAODLE.HNKJDJFFACC_Difficulty == CJDJGHIIBHP.HNKJDJFFACC_Difficulty))
					return false;
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					if (LFGLBIAODLE.LGMDOEIPLAK_FreeMusicIds[i] != CJDJGHIIBHP.LGMDOEIPLAK_FreeMusicIds[i])
						return false;
				}
				return true;
			}

			//// RVA: 0x201EC04 Offset: 0x201EC04 VA: 0x201EC04
			public static bool HMMFJOEBEKJ(MBNCBCJKCEA_Raid LFGLBIAODLE, MBNCBCJKCEA_Raid CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F51C Offset: 0x201F51C VA: 0x201F51C
			public void ODDIHGPONFL_Copy(MBNCBCJKCEA_Raid PJFKNNNDMIA)
			{
				PJFKNNNDMIA.OMKLPMBJLIO_CategoryId = OMKLPMBJLIO_CategoryId;
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.HNKJDJFFACC_Difficulty = HNKJDJFFACC_Difficulty;
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.Clear();
				PJFKNNNDMIA.LGMDOEIPLAK_FreeMusicIds.AddRange(LGMDOEIPLAK_FreeMusicIds);
			}

			//// RVA: 0x2020C58 Offset: 0x2020C58 VA: 0x2020C58
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["difficulty"] = HNKJDJFFACC_Difficulty;
				res["categoryId"] = OMKLPMBJLIO_CategoryId;
				for (int i = 0; i < LNHIHOKKPFF; i++)
				{
					res[IAMECBIFIKA("freeMusicId_{0:D2}", i)] = LGMDOEIPLAK_FreeMusicIds[i];
				}
				return res;
			}

			//// RVA: 0x20223C8 Offset: 0x20223C8 VA: 0x20223C8
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				HNKJDJFFACC_Difficulty = JsonUtil.GetInt(OBHAFLMHAKG, "difficulty", 0);
				OMKLPMBJLIO_CategoryId = JsonUtil.GetInt(OBHAFLMHAKG, "categoryId", 0);
				for(int i = 0; i < LNHIHOKKPFF; i++)
				{
					LGMDOEIPLAK_FreeMusicIds.Add(JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("freeMusicid_{0:D2}", i), 0));
				}
			}

			//// RVA: 0x2024A5C Offset: 0x2024A5C VA: 0x2024A5C
			//public bool FKEJBAHCMGC(int LHMJFCCBPPN) { }

			//// RVA: 0x2024A80 Offset: 0x2024A80 VA: 0x2024A80
			//public Difficulty.Type FFACBDAJJJP() { }

			//// RVA: 0x2024A88 Offset: 0x2024A88 VA: 0x2024A88
			//public void HJHBGHMNGKL(Difficulty.Type AKNELONELJK) { }

			//// RVA: 0x2024A90 Offset: 0x2024A90 VA: 0x2024A90
			//public void NGNECOFAMKP(FreeCategoryId.Type DEPGBBJMFED) { }

			//// RVA: 0x2024A98 Offset: 0x2024A98 VA: 0x2024A98
			//public void ACGKEJKPFIA(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK) { }

			//// RVA: 0x2024B24 Offset: 0x2024B24 VA: 0x2024B24
			//public void FKJBADIPKHK(FreeCategoryId.Type DEPGBBJMFED, out int GHBPLHBNMBK) { }

			//// RVA: 0x20249A4 Offset: 0x20249A4 VA: 0x20249A4
			private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
			{
				KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
				return KKELPILEDDD.ToString();
			}
		}
		
		public class JPAIABGDMCK_RaidLobbyEvent
		{
			private long KNMEGCIAIAO_NewsletterUpdateAt = 0; // 0x8
			private long JPNJGPKMGFA_CoopQuestUpdateAt = 0; // 0x10
			private bool CDEEHJDGMDC_IsDisplayViewingText = true; // 0x18

			//// RVA: 0x20246FC Offset: 0x20246FC VA: 0x20246FC
			public static bool CHDGLBBFEKH(JPAIABGDMCK_RaidLobbyEvent LFGLBIAODLE, JPAIABGDMCK_RaidLobbyEvent CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.KNMEGCIAIAO_NewsletterUpdateAt == CJDJGHIIBHP.KNMEGCIAIAO_NewsletterUpdateAt &&
					LFGLBIAODLE.JPNJGPKMGFA_CoopQuestUpdateAt == CJDJGHIIBHP.JPNJGPKMGFA_CoopQuestUpdateAt &&
					LFGLBIAODLE.CDEEHJDGMDC_IsDisplayViewingText == CJDJGHIIBHP.CDEEHJDGMDC_IsDisplayViewingText)
					return true;
				return false;
			}

			//// RVA: 0x201EC90 Offset: 0x201EC90 VA: 0x201EC90
			public static bool HMMFJOEBEKJ(JPAIABGDMCK_RaidLobbyEvent LFGLBIAODLE, JPAIABGDMCK_RaidLobbyEvent CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F630 Offset: 0x201F630 VA: 0x201F630
			public void ODDIHGPONFL_Copy(JPAIABGDMCK_RaidLobbyEvent PJFKNNNDMIA)
			{
				PJFKNNNDMIA.KNMEGCIAIAO_NewsletterUpdateAt = KNMEGCIAIAO_NewsletterUpdateAt;
				PJFKNNNDMIA.JPNJGPKMGFA_CoopQuestUpdateAt = JPNJGPKMGFA_CoopQuestUpdateAt;
				PJFKNNNDMIA.CDEEHJDGMDC_IsDisplayViewingText = CDEEHJDGMDC_IsDisplayViewingText;
			}

			//// RVA: 0x2020ED8 Offset: 0x2020ED8 VA: 0x2020ED8
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["newsletterUpdateAt"] = KNMEGCIAIAO_NewsletterUpdateAt;
				res["coopQuestUpdateAt"] = JPNJGPKMGFA_CoopQuestUpdateAt;
				res["isDisplayViewingText"] = CDEEHJDGMDC_IsDisplayViewingText ? 1 : 0;
				return res;
			}

			//// RVA: 0x2022554 Offset: 0x2022554 VA: 0x2022554
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				KNMEGCIAIAO_NewsletterUpdateAt = JsonUtil.GetLong(OBHAFLMHAKG, "newsletterUpdateAt", 0);
				JPNJGPKMGFA_CoopQuestUpdateAt = JsonUtil.GetLong(OBHAFLMHAKG, "coopQuestUpdateAt", 0);
				CDEEHJDGMDC_IsDisplayViewingText = JsonUtil.GetInt(OBHAFLMHAKG, "isDisplayViewingText", 1) != 0;
			}

			//// RVA: 0x2024788 Offset: 0x2024788 VA: 0x2024788
			//public void AGCAONIMNAL(long EKEGHNPNCEH) { }

			//// RVA: 0x2024798 Offset: 0x2024798 VA: 0x2024798
			//public long HJEMMCMEKED() { }

			//// RVA: 0x20247A0 Offset: 0x20247A0 VA: 0x20247A0
			//public void IDIHHKNAIJG(long EKEGHNPNCEH) { }

			//// RVA: 0x20247B0 Offset: 0x20247B0 VA: 0x20247B0
			//public long IKGFALONFNL() { }

			//// RVA: 0x20247B8 Offset: 0x20247B8 VA: 0x20247B8
			//public void JJDBLFAGGGK(bool JKDJCFEBDHC) { }

			//// RVA: 0x20247C0 Offset: 0x20247C0 VA: 0x20247C0
			//public bool LALECMJIGPH() { }
		}
		 
		public class DBALFEBAHDH_Bbs
		{
			private List<long> CNIPILFLJDD_UpdateAt = new List<long>(4) { 0, 0, 0, 0 }; // 0x8

			//// RVA: 0x202398C Offset: 0x202398C VA: 0x202398C
			public static bool CHDGLBBFEKH(DBALFEBAHDH_Bbs LFGLBIAODLE, DBALFEBAHDH_Bbs CJDJGHIIBHP)
			{
				for(int i = 0; i < 4; i++)
				{
					if (LFGLBIAODLE.CNIPILFLJDD_UpdateAt[i] != CJDJGHIIBHP.CNIPILFLJDD_UpdateAt[i])
						return false;
				}
				return true;
			}

			//// RVA: 0x201ECA4 Offset: 0x201ECA4 VA: 0x201ECA4
			public static bool HMMFJOEBEKJ(DBALFEBAHDH_Bbs LFGLBIAODLE, DBALFEBAHDH_Bbs CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F6B0 Offset: 0x201F6B0 VA: 0x201F6B0
			public void ODDIHGPONFL(DBALFEBAHDH_Bbs PJFKNNNDMIA)
			{
				PJFKNNNDMIA.CNIPILFLJDD_UpdateAt.Clear();
				PJFKNNNDMIA.CNIPILFLJDD_UpdateAt.AddRange(CNIPILFLJDD_UpdateAt);
			}

			//// RVA: 0x2021064 Offset: 0x2021064 VA: 0x2021064
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				EDOHBJAPLPF_JsonData array = new EDOHBJAPLPF_JsonData();
				array.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < 4; i++)
				{
					array.Add(CNIPILFLJDD_UpdateAt[i]);
				}
				res["updateAt"] = array;
				return res;
			}

			//// RVA: 0x202262C Offset: 0x202262C VA: 0x202262C
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				if(OBHAFLMHAKG.BBAJPINMOEP_Contains("updateAt"))
				{
					CNIPILFLJDD_UpdateAt.Clear();
					for(int i = 0; i < OBHAFLMHAKG["updateAt"].HNBFOAJIIAL_Count; i++)
					{
						CNIPILFLJDD_UpdateAt.Add(JsonUtil.GetLong(OBHAFLMHAKG["updateAt"][i]));
					}
				}
			}

			//// RVA: 0x2023AA0 Offset: 0x2023AA0 VA: 0x2023AA0
			public void ICKOFGNMPDE_SetUpdateAt(AHAENNIFOAF.IAOPMEAIHLH INDDJNMPONH, long EKEGHNPNCEH)
			{
				CNIPILFLJDD_UpdateAt[(int)INDDJNMPONH] = EKEGHNPNCEH;
			}

			//// RVA: 0x2023B3C Offset: 0x2023B3C VA: 0x2023B3C
			public long DPKGNBIAFDO_GetUpdateAt(AHAENNIFOAF.IAOPMEAIHLH INDDJNMPONH)
			{
				return CNIPILFLJDD_UpdateAt[(int)INDDJNMPONH];
			}
		}
		
		public class OAMMINGBAPE_Skip
		{
			public bool MDDGHHALFKF_Skip = false; // 0x8
			public bool OBMEMOOLLEI_SkipTicketPopup = true; // 0x9

			//// RVA: 0x2024C60 Offset: 0x2024C60 VA: 0x2024C60
			public static bool CHDGLBBFEKH(OAMMINGBAPE_Skip LFGLBIAODLE, OAMMINGBAPE_Skip CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.MDDGHHALFKF_Skip == CJDJGHIIBHP.MDDGHHALFKF_Skip &&
					LFGLBIAODLE.OBMEMOOLLEI_SkipTicketPopup == CJDJGHIIBHP.OBMEMOOLLEI_SkipTicketPopup)
					return true;
				return false;
			}

			//// RVA: 0x201ECB8 Offset: 0x201ECB8 VA: 0x201ECB8
			public static bool HMMFJOEBEKJ(OAMMINGBAPE_Skip LFGLBIAODLE, OAMMINGBAPE_Skip CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F770 Offset: 0x201F770 VA: 0x201F770
			public void ODDIHGPONFL_Copy(OAMMINGBAPE_Skip PJFKNNNDMIA)
			{
				PJFKNNNDMIA.MDDGHHALFKF_Skip = MDDGHHALFKF_Skip;
				PJFKNNNDMIA.OBMEMOOLLEI_SkipTicketPopup = OBMEMOOLLEI_SkipTicketPopup;
			}

			//// RVA: 0x20211D0 Offset: 0x20211D0 VA: 0x20211D0
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["skip"] = MDDGHHALFKF_Skip ? 1 : 0;
				res["skip_ticket_popup"] = OBMEMOOLLEI_SkipTicketPopup ? 1 : 0;
				return res;
			}

			// RVA: 0x20227B8 Offset: 0x20227B8 VA: 0x20227B8
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				MDDGHHALFKF_Skip = JsonUtil.GetInt(OBHAFLMHAKG, "skip", 0) != 0;
				OBMEMOOLLEI_SkipTicketPopup = JsonUtil.GetInt(OBHAFLMHAKG, "skip_ticket_popup", 1) != 0;
			}
		}
		
		public class MEMAEGKMBJM_UnitMenu
		{
			public int BLABFAMKLIN_UnitInfoDispType = 0; // 0x8

			//// RVA: 0x2024C18 Offset: 0x2024C18 VA: 0x2024C18
			public static bool CHDGLBBFEKH(MEMAEGKMBJM_UnitMenu LFGLBIAODLE, MEMAEGKMBJM_UnitMenu CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.BLABFAMKLIN_UnitInfoDispType == CJDJGHIIBHP.BLABFAMKLIN_UnitInfoDispType)
					return true;
				return false;
			}

			//// RVA: 0x201ECCC Offset: 0x201ECCC VA: 0x201ECCC
			public static bool HMMFJOEBEKJ(MEMAEGKMBJM_UnitMenu LFGLBIAODLE, MEMAEGKMBJM_UnitMenu CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F7BC Offset: 0x201F7BC VA: 0x201F7BC
			public void ODDIHGPONFL_Copy(MEMAEGKMBJM_UnitMenu PJFKNNNDMIA)
			{
				PJFKNNNDMIA.BLABFAMKLIN_UnitInfoDispType = BLABFAMKLIN_UnitInfoDispType;
			}

			//// RVA: 0x202131C Offset: 0x202131C VA: 0x202131C
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["unit_info_disp_type"] = BLABFAMKLIN_UnitInfoDispType;
				return res;
			}

			// RVA: 0x2022888 Offset: 0x2022888 VA: 0x2022888
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				BLABFAMKLIN_UnitInfoDispType = JsonUtil.GetInt(OBHAFLMHAKG, "unit_info_disp_type", 0);
			}
		}
		
		public class KOOHLCAIIGJ_StepUpQuest
		{
			public bool IAPNOPFIPAG_IsShowNextInfo = false; // 0x8

			//// RVA: 0x20247C8 Offset: 0x20247C8 VA: 0x20247C8
			public static bool CHDGLBBFEKH(KOOHLCAIIGJ_StepUpQuest LFGLBIAODLE, KOOHLCAIIGJ_StepUpQuest CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.IAPNOPFIPAG_IsShowNextInfo == CJDJGHIIBHP.IAPNOPFIPAG_IsShowNextInfo)
					return true;
				return false;
			}

			//// RVA: 0x201ECE0 Offset: 0x201ECE0 VA: 0x201ECE0
			public static bool HMMFJOEBEKJ(KOOHLCAIIGJ_StepUpQuest LFGLBIAODLE, KOOHLCAIIGJ_StepUpQuest CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201F7E4 Offset: 0x201F7E4 VA: 0x201F7E4
			public void ODDIHGPONFL_Copy(KOOHLCAIIGJ_StepUpQuest PJFKNNNDMIA)
			{
				PJFKNNNDMIA.IAPNOPFIPAG_IsShowNextInfo = IAPNOPFIPAG_IsShowNextInfo;
			}

			//// RVA: 0x20213F0 Offset: 0x20213F0 VA: 0x20213F0
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["isShowNextInfo"] = IAPNOPFIPAG_IsShowNextInfo ? 1 : 0;
				return res;
			}

			// RVA: 0x20228FC Offset: 0x20228FC VA: 0x20228FC
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				IAPNOPFIPAG_IsShowNextInfo = JsonUtil.GetInt(OBHAFLMHAKG, "isShowNextInfo", 0) != 0;
			}
		}

		public EJBBPMBEKLP_Live BCOIACHCMLA_Live = new EJBBPMBEKLP_Live(); // 0x8
		public GADJIIFFPFI_NewLive ADHMDONLHLJ_NewLive = new GADJIIFFPFI_NewLive(); // 0xC
		public IEFBBNFNKIJ_CollectEvent OCBIOMPAJFF_CollectEvent = new IEFBBNFNKIJ_CollectEvent(); // 0x10
		public FLOIJPMBBIL_BattleEvent MFFAIIDJPBL_BattleEvent = new FLOIJPMBBIL_BattleEvent(); // 0x14
		public PLHMBFFLEPB_MissionEvent KIKCCBMOLDM_MissionEvent = new PLHMBFFLEPB_MissionEvent(); // 0x18
		public CGAJFHFIGJG_GoDivaEvent CECJBBEGOPG_GoDivaEvent = new CGAJFHFIGJG_GoDivaEvent(); // 0x1C
		public MBNCBCJKCEA_Raid JGAFBCMOGLP_Raid = new MBNCBCJKCEA_Raid(); // 0x20
		public JPAIABGDMCK_RaidLobbyEvent KHBHOGEEHBA_RaidLobbyEvent = new JPAIABGDMCK_RaidLobbyEvent(); // 0x24
		public DBALFEBAHDH_Bbs FPOJOFFFLFK_Bbs = new DBALFEBAHDH_Bbs(); // 0x28
		public OAMMINGBAPE_Skip KMCLFGMAKPA_Skip = new OAMMINGBAPE_Skip(); // 0x2C
		public MEMAEGKMBJM_UnitMenu ECNAIALHHBO_UnitMenu = new MEMAEGKMBJM_UnitMenu(); // 0x30
		public KOOHLCAIIGJ_StepUpQuest AAFEFCNONGL_StepUpQuest = new KOOHLCAIIGJ_StepUpQuest(); // 0x34

		// // RVA: 0x201E7F4 Offset: 0x201E7F4 VA: 0x201E7F4
		public static bool CHDGLBBFEKH_IsEqual(APLMBKKCNKC_Select LFGLBIAODLE, APLMBKKCNKC_Select CJDJGHIIBHP)
		{
			if (EJBBPMBEKLP_Live.CHDGLBBFEKH_IsEqual(LFGLBIAODLE.BCOIACHCMLA_Live, CJDJGHIIBHP.BCOIACHCMLA_Live) &&
					GADJIIFFPFI_NewLive.CHDGLBBFEKH(LFGLBIAODLE.ADHMDONLHLJ_NewLive, CJDJGHIIBHP.ADHMDONLHLJ_NewLive) &&
					IEFBBNFNKIJ_CollectEvent.CHDGLBBFEKH(LFGLBIAODLE.OCBIOMPAJFF_CollectEvent, CJDJGHIIBHP.OCBIOMPAJFF_CollectEvent) &&
					FLOIJPMBBIL_BattleEvent.CHDGLBBFEKH(LFGLBIAODLE.MFFAIIDJPBL_BattleEvent, CJDJGHIIBHP.MFFAIIDJPBL_BattleEvent) &&
					PLHMBFFLEPB_MissionEvent.CHDGLBBFEKH(LFGLBIAODLE.KIKCCBMOLDM_MissionEvent, CJDJGHIIBHP.KIKCCBMOLDM_MissionEvent) &&
					CGAJFHFIGJG_GoDivaEvent.CHDGLBBFEKH(LFGLBIAODLE.CECJBBEGOPG_GoDivaEvent, CJDJGHIIBHP.CECJBBEGOPG_GoDivaEvent) &&
					MBNCBCJKCEA_Raid.CHDGLBBFEKH(LFGLBIAODLE.JGAFBCMOGLP_Raid, CJDJGHIIBHP.JGAFBCMOGLP_Raid) &&
					JPAIABGDMCK_RaidLobbyEvent.CHDGLBBFEKH(LFGLBIAODLE.KHBHOGEEHBA_RaidLobbyEvent, CJDJGHIIBHP.KHBHOGEEHBA_RaidLobbyEvent) &&
					DBALFEBAHDH_Bbs.CHDGLBBFEKH(LFGLBIAODLE.FPOJOFFFLFK_Bbs, CJDJGHIIBHP.FPOJOFFFLFK_Bbs) &&
					OAMMINGBAPE_Skip.CHDGLBBFEKH(LFGLBIAODLE.KMCLFGMAKPA_Skip, CJDJGHIIBHP.KMCLFGMAKPA_Skip) &&
					MEMAEGKMBJM_UnitMenu.CHDGLBBFEKH(LFGLBIAODLE.ECNAIALHHBO_UnitMenu, CJDJGHIIBHP.ECNAIALHHBO_UnitMenu) &&
					KOOHLCAIIGJ_StepUpQuest.CHDGLBBFEKH(LFGLBIAODLE.AAFEFCNONGL_StepUpQuest, CJDJGHIIBHP.AAFEFCNONGL_StepUpQuest))
				return true;
			return false;
		}

		// // RVA: 0x201ECF4 Offset: 0x201ECF4 VA: 0x201ECF4
		public static bool HMMFJOEBEKJ(APLMBKKCNKC_Select LFGLBIAODLE, APLMBKKCNKC_Select CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		// // RVA: 0x201ED08 Offset: 0x201ED08 VA: 0x201ED08
		public void ODDIHGPONFL_Copy(ILDKBCLAFPB.APLMBKKCNKC_Select PJFKNNNDMIA)
		{
			BCOIACHCMLA_Live.ODDIHGPONFL_Copy(PJFKNNNDMIA.BCOIACHCMLA_Live);
			ADHMDONLHLJ_NewLive.ODDIHGPONFL_Copy(PJFKNNNDMIA.ADHMDONLHLJ_NewLive);
			OCBIOMPAJFF_CollectEvent.ODDIHGPONFL_Copy(PJFKNNNDMIA.OCBIOMPAJFF_CollectEvent);
			MFFAIIDJPBL_BattleEvent.ODDIHGPONFL_Copy(PJFKNNNDMIA.MFFAIIDJPBL_BattleEvent);
			KIKCCBMOLDM_MissionEvent.ODDIHGPONFL(PJFKNNNDMIA.KIKCCBMOLDM_MissionEvent);
			CECJBBEGOPG_GoDivaEvent.ODDIHGPONFL_Copy(PJFKNNNDMIA.CECJBBEGOPG_GoDivaEvent);
			JGAFBCMOGLP_Raid.ODDIHGPONFL_Copy(PJFKNNNDMIA.JGAFBCMOGLP_Raid);
			KHBHOGEEHBA_RaidLobbyEvent.ODDIHGPONFL_Copy(PJFKNNNDMIA.KHBHOGEEHBA_RaidLobbyEvent);
			FPOJOFFFLFK_Bbs.ODDIHGPONFL(PJFKNNNDMIA.FPOJOFFFLFK_Bbs);
			KMCLFGMAKPA_Skip.ODDIHGPONFL_Copy(PJFKNNNDMIA.KMCLFGMAKPA_Skip);
			ECNAIALHHBO_UnitMenu.ODDIHGPONFL_Copy(PJFKNNNDMIA.ECNAIALHHBO_UnitMenu);
			AAFEFCNONGL_StepUpQuest.ODDIHGPONFL_Copy(PJFKNNNDMIA.AAFEFCNONGL_StepUpQuest);
		}

		// // RVA: 0x201F80C Offset: 0x201F80C VA: 0x201F80C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["live"] = BCOIACHCMLA_Live.NOJCMGAFAAC();
			res["newLive"] = ADHMDONLHLJ_NewLive.NOJCMGAFAAC();
			res["collectEvent"] = OCBIOMPAJFF_CollectEvent.NOJCMGAFAAC();
			res["battleEvent"] = MFFAIIDJPBL_BattleEvent.NOJCMGAFAAC();
			res["missionEvent"] = KIKCCBMOLDM_MissionEvent.NOJCMGAFAAC();
			res["godivaEvent"] = CECJBBEGOPG_GoDivaEvent.NOJCMGAFAAC();
			res["raid"] = JGAFBCMOGLP_Raid.NOJCMGAFAAC();
			res["raidLobbyEvent"] = KHBHOGEEHBA_RaidLobbyEvent.NOJCMGAFAAC();
			res["bbs"] = FPOJOFFFLFK_Bbs.NOJCMGAFAAC();
			res["skip"] = KMCLFGMAKPA_Skip.NOJCMGAFAAC();
			res["unitMenu"] = ECNAIALHHBO_UnitMenu.NOJCMGAFAAC();
			res["stepUpQuest"] = AAFEFCNONGL_StepUpQuest.NOJCMGAFAAC();
			return res;
		}

		// // RVA: 0x20214C8 Offset: 0x20214C8 VA: 0x20214C8
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			if (OBHAFLMHAKG == null)
				return;
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("live"))
			{
				BCOIACHCMLA_Live.KHEKNNFCAOI_Init(OBHAFLMHAKG["live"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("newLive"))
			{
				ADHMDONLHLJ_NewLive.KHEKNNFCAOI(OBHAFLMHAKG["newLive"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("collectEvent"))
			{
				OCBIOMPAJFF_CollectEvent.KHEKNNFCAOI(OBHAFLMHAKG["collectEvent"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("battleEvent"))
			{
				MFFAIIDJPBL_BattleEvent.KHEKNNFCAOI(OBHAFLMHAKG["battleEvent"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("missionEvent"))
			{
				KIKCCBMOLDM_MissionEvent.KHEKNNFCAOI(OBHAFLMHAKG["missionEvent"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("godivaEvent"))
			{
				CECJBBEGOPG_GoDivaEvent.KHEKNNFCAOI(OBHAFLMHAKG["godivaEvent"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("raid"))
			{
				JGAFBCMOGLP_Raid.KHEKNNFCAOI(OBHAFLMHAKG["raid"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("raidLobbyEvent"))
			{
				KHBHOGEEHBA_RaidLobbyEvent.KHEKNNFCAOI(OBHAFLMHAKG["raidLobbyEvent"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("bbs"))
			{
				FPOJOFFFLFK_Bbs.KHEKNNFCAOI(OBHAFLMHAKG["bbs"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("skip"))
			{
				KMCLFGMAKPA_Skip.KHEKNNFCAOI(OBHAFLMHAKG["skip"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("unitMenu"))
			{
				ECNAIALHHBO_UnitMenu.KHEKNNFCAOI(OBHAFLMHAKG["unitMenu"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("stepUpQuest"))
			{
				AAFEFCNONGL_StepUpQuest.KHEKNNFCAOI(OBHAFLMHAKG["stepUpQuest"]);
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
        public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["version"] = CEMEIPNMAAD_Version;
			return res;
		}

        // // RVA: 0x202A6A0 Offset: 0x202A6A0 VA: 0x202A6A0
        public static bool CHDGLBBFEKH_IsEqual(FOLMONPGGPP_Header ILEKEPJBFDP, FOLMONPGGPP_Header GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.CEMEIPNMAAD_Version == GEPALDIIDPC.CEMEIPNMAAD_Version)
				return true;
			return false;
		}

        // // RVA: 0x202A6E8 Offset: 0x202A6E8 VA: 0x202A6E8
        public static bool HMMFJOEBEKJ(FOLMONPGGPP_Header ILEKEPJBFDP, FOLMONPGGPP_Header GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

        // // RVA: 0x202A6FC Offset: 0x202A6FC VA: 0x202A6FC
        public void ODDIHGPONFL_Copy(FOLMONPGGPP_Header FMKAONAMGCN)
		{
			FMKAONAMGCN.CEMEIPNMAAD_Version = CEMEIPNMAAD_Version;
		}

        // // RVA: 0x201B130 Offset: 0x201B130 VA: 0x201B130
        public void BOGMEEOOADP()
        {
            CEMEIPNMAAD_Version = JLLFHBIJNPC_GetVersion();
        }
    }
	
	
	public class KKNFJMEBONI_SceneData
	{
		public CEBFFLDKAEC_SecureInt PPFNGGCBJKC_Id = new CEBFFLDKAEC_SecureInt(); // 0x8
		public long BEBJKJKBOGH_Date; // 0x10
		public int CADENLBDAEB_IsNew = 1; // 0x18

		// // RVA: 0x202B4F8 Offset: 0x202B4F8 VA: 0x202B4F8
		public void EDEDFDDIOKO(MMPBPOIFDAF_Scene.PMKOFEIONEG KDIFMECGNIC)
		{
			PPFNGGCBJKC_Id.DNJEJEANJGL_Value = KDIFMECGNIC.PPFNGGCBJKC_Id;
			BEBJKJKBOGH_Date = KDIFMECGNIC.BEBJKJKBOGH_Date;
			CADENLBDAEB_IsNew = KDIFMECGNIC.LHMOAJAIJCO_New ? 1 : 0;
		}

		// // RVA: 0x202A72C Offset: 0x202A72C VA: 0x202A72C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["id"] = PPFNGGCBJKC_Id.DNJEJEANJGL_Value;
			res["date"] = BEBJKJKBOGH_Date;
			res["isNew"] = CADENLBDAEB_IsNew;
			return res;
		}

		// // RVA: 0x202A8AC Offset: 0x202A8AC VA: 0x202A8AC
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			PPFNGGCBJKC_Id.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "id", 0);
			BEBJKJKBOGH_Date = JsonUtil.GetLong(OBHAFLMHAKG, "date", 0);
			CADENLBDAEB_IsNew = JsonUtil.GetInt(OBHAFLMHAKG, "isNew", 1);
		}

		// // RVA: 0x2035B3C Offset: 0x2035B3C VA: 0x2035B3C
		public static bool CHDGLBBFEKH(KKNFJMEBONI_SceneData ILEKEPJBFDP, KKNFJMEBONI_SceneData GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.PPFNGGCBJKC_Id.DNJEJEANJGL_Value == GEPALDIIDPC.PPFNGGCBJKC_Id.DNJEJEANJGL_Value &&
				ILEKEPJBFDP.BEBJKJKBOGH_Date == GEPALDIIDPC.BEBJKJKBOGH_Date &&
				ILEKEPJBFDP.CADENLBDAEB_IsNew == GEPALDIIDPC.CADENLBDAEB_IsNew)
				return true;
			return false;
		}

		// // RVA: 0x202AD64 Offset: 0x202AD64 VA: 0x202AD64
		public static bool HMMFJOEBEKJ(KKNFJMEBONI_SceneData ILEKEPJBFDP, KKNFJMEBONI_SceneData GEPALDIIDPC)
		{
			return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
		}

		// // RVA: 0x202BBB4 Offset: 0x202BBB4 VA: 0x202BBB4
		public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
		{
			return PPFNGGCBJKC_Id.KPOCKNCJBPN_CheckSecure();
		}

		// // RVA: 0x202AD78 Offset: 0x202AD78 VA: 0x202AD78
		public void ODDIHGPONFL_Copy(KKNFJMEBONI_SceneData FMKAONAMGCN)
		{
			FMKAONAMGCN.BEBJKJKBOGH_Date = BEBJKJKBOGH_Date;
			FMKAONAMGCN.PPFNGGCBJKC_Id.DNJEJEANJGL_Value = PPFNGGCBJKC_Id.DNJEJEANJGL_Value;
			FMKAONAMGCN.CADENLBDAEB_IsNew = CADENLBDAEB_IsNew;
		}
	}
	
	public class BEBBCJLDOFF_DivaData
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public CEBFFLDKAEC_SecureInt AFBMEMCHJCL_MainScene = new CEBFFLDKAEC_SecureInt(); // 0xC

		// // RVA: 0x20250D8 Offset: 0x20250D8 VA: 0x20250D8
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["id"] = PPFNGGCBJKC_Id;
			res["mainScene"] = AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value;
			return res;
		}

		// // RVA: 0x2025208 Offset: 0x2025208 VA: 0x2025208
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			PPFNGGCBJKC_Id = JsonUtil.GetInt(OBHAFLMHAKG, "id", 0);
			AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "mainScene", 0);
		}

		// // RVA: 0x20252C4 Offset: 0x20252C4 VA: 0x20252C4
		public static bool CHDGLBBFEKH(BEBBCJLDOFF_DivaData ILEKEPJBFDP, BEBBCJLDOFF_DivaData GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.PPFNGGCBJKC_Id == GEPALDIIDPC.PPFNGGCBJKC_Id &&
				ILEKEPJBFDP.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value == GEPALDIIDPC.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value)
				return true;
			return false;
		}

		// // RVA: 0x2025364 Offset: 0x2025364 VA: 0x2025364
		public static bool HMMFJOEBEKJ(BEBBCJLDOFF_DivaData ILEKEPJBFDP, BEBBCJLDOFF_DivaData GEPALDIIDPC)
		{
			return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
		}

		// // RVA: 0x2025378 Offset: 0x2025378 VA: 0x2025378
		public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
		{
			return AFBMEMCHJCL_MainScene.KPOCKNCJBPN_CheckSecure();
		}

		// // RVA: 0x20253A4 Offset: 0x20253A4 VA: 0x20253A4
		public void ODDIHGPONFL_Copy(BEBBCJLDOFF_DivaData FMKAONAMGCN)
		{
			FMKAONAMGCN.PPFNGGCBJKC_Id = PPFNGGCBJKC_Id;
			FMKAONAMGCN.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value = AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value;
		}
	}
	
	public class ABBBCBIHMFE_DropItem
	{
		public CEBFFLDKAEC_SecureInt KIJAPOFAGPN_ItemId = new CEBFFLDKAEC_SecureInt(); // 0x8
		public int OIPCCBHIKIA_Index; // 0xC
		public int OMAJOEOOAJJ_Count0; // 0x10
		public int HMFFHLPNMPH_Count; // 0x14
		public int JPIPENJGGDD_Multi; // 0x18
		public int PLKAGPBEHMB_LuckPlus; // 0x1C
		public CEBFFLDKAEC_SecureInt ONDODHPHOOF_ConvertItemId = new CEBFFLDKAEC_SecureInt(); // 0x20
		public int ABIFFLDIAMM_ConvertItemCount; // 0x24
		public bool LHEDLDEMPPG_IsNewScene; // 0x28
		public bool PHJHJGDLPED_IsRareDrop; // 0x29

		// // RVA: 0x201BD08 Offset: 0x201BD08 VA: 0x201BD08
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["itemId"] = KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value;
			res["index"] = OIPCCBHIKIA_Index;
			res["count0"] = OMAJOEOOAJJ_Count0;
			res["count"] = HMFFHLPNMPH_Count;
			res["multi"] = JPIPENJGGDD_Multi;
			res["luckPlus"] = PLKAGPBEHMB_LuckPlus;
			res["convertItemId"] = ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value;
			res["convertItemCount"] = ABIFFLDIAMM_ConvertItemCount;
			res["isNewScene"] = LHEDLDEMPPG_IsNewScene ? 1 : 0;
			res["isRareDrop"] = PHJHJGDLPED_IsRareDrop ? 1 : 0;
			return res;
		}

		// // RVA: 0x201C10C Offset: 0x201C10C VA: 0x201C10C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "itemId", 0);
			OIPCCBHIKIA_Index = JsonUtil.GetInt(OBHAFLMHAKG, "index", 0);
			OMAJOEOOAJJ_Count0 = JsonUtil.GetInt(OBHAFLMHAKG, "count0", 0);
			HMFFHLPNMPH_Count = JsonUtil.GetInt(OBHAFLMHAKG, "count", 0);
			JPIPENJGGDD_Multi = JsonUtil.GetInt(OBHAFLMHAKG, "multi", 0);
			PLKAGPBEHMB_LuckPlus = JsonUtil.GetInt(OBHAFLMHAKG, "luckPlus", 0);
			ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "convertItemId", 0);
			ABIFFLDIAMM_ConvertItemCount = JsonUtil.GetInt(OBHAFLMHAKG, "convertItemCount", 0);
			LHEDLDEMPPG_IsNewScene = JsonUtil.GetInt(OBHAFLMHAKG, "isNewScene", 0) != 0;
			PHJHJGDLPED_IsRareDrop = JsonUtil.GetInt(OBHAFLMHAKG, "isRareDrop", 0) != 0;
		}

		// // RVA: 0x201C31C Offset: 0x201C31C VA: 0x201C31C
		public static bool CHDGLBBFEKH(ILDKBCLAFPB.ABBBCBIHMFE_DropItem ILEKEPJBFDP, ILDKBCLAFPB.ABBBCBIHMFE_DropItem GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.KIJAPOFAGPN_ItemId == GEPALDIIDPC.KIJAPOFAGPN_ItemId &&
				ILEKEPJBFDP.OIPCCBHIKIA_Index == GEPALDIIDPC.OIPCCBHIKIA_Index &&
				ILEKEPJBFDP.OMAJOEOOAJJ_Count0 == GEPALDIIDPC.OMAJOEOOAJJ_Count0 &&
				ILEKEPJBFDP.HMFFHLPNMPH_Count == GEPALDIIDPC.HMFFHLPNMPH_Count &&
				ILEKEPJBFDP.JPIPENJGGDD_Multi == GEPALDIIDPC.JPIPENJGGDD_Multi &&
				ILEKEPJBFDP.PLKAGPBEHMB_LuckPlus == GEPALDIIDPC.PLKAGPBEHMB_LuckPlus &&
				ILEKEPJBFDP.ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value == GEPALDIIDPC.ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value &&
				ILEKEPJBFDP.ABIFFLDIAMM_ConvertItemCount == GEPALDIIDPC.ABIFFLDIAMM_ConvertItemCount &&
				ILEKEPJBFDP.LHEDLDEMPPG_IsNewScene == GEPALDIIDPC.LHEDLDEMPPG_IsNewScene &&
				ILEKEPJBFDP.PHJHJGDLPED_IsRareDrop == GEPALDIIDPC.PHJHJGDLPED_IsRareDrop)
				return true;
			return false;
		}

		// // RVA: 0x201C490 Offset: 0x201C490 VA: 0x201C490
		public static bool HMMFJOEBEKJ(ILDKBCLAFPB.ABBBCBIHMFE_DropItem ILEKEPJBFDP, ILDKBCLAFPB.ABBBCBIHMFE_DropItem GEPALDIIDPC)
		{
			return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
		}

		// // RVA: 0x201C4A4 Offset: 0x201C4A4 VA: 0x201C4A4
		public void ODDIHGPONFL_Copy(ABBBCBIHMFE_DropItem FMKAONAMGCN)
		{
			FMKAONAMGCN.KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value = KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value;
			FMKAONAMGCN.OIPCCBHIKIA_Index = OIPCCBHIKIA_Index;
			FMKAONAMGCN.OMAJOEOOAJJ_Count0 = OMAJOEOOAJJ_Count0;
			FMKAONAMGCN.HMFFHLPNMPH_Count = HMFFHLPNMPH_Count;
			FMKAONAMGCN.JPIPENJGGDD_Multi = JPIPENJGGDD_Multi;
			FMKAONAMGCN.PLKAGPBEHMB_LuckPlus = PLKAGPBEHMB_LuckPlus;
			FMKAONAMGCN.ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value = ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value;
			FMKAONAMGCN.ABIFFLDIAMM_ConvertItemCount = ABIFFLDIAMM_ConvertItemCount;
			FMKAONAMGCN.LHEDLDEMPPG_IsNewScene = LHEDLDEMPPG_IsNewScene;
			FMKAONAMGCN.PHJHJGDLPED_IsRareDrop = PHJHJGDLPED_IsRareDrop;
		}
	}

	public class GCLIKCLDDKG_PlayerData
	{
		public KKNFJMEBONI_SceneData PNLOINMCCKH_SceneData = new KKNFJMEBONI_SceneData(); // 0x8
		public BEBBCJLDOFF_DivaData DGCJCAHIAPP_DivaData = new BEBBCJLDOFF_DivaData(); // 0xC
		public CEBFFLDKAEC_SecureInt NMDKKAAOIOI_LastBaseUnionCredit = new CEBFFLDKAEC_SecureInt(); // 0x10
		public CEBFFLDKAEC_SecureInt MJKFDDKLLFP_LastDropUnionCredit = new CEBFFLDKAEC_SecureInt(); // 0x14
		public int GCAPLLEIAAI_LastScore; // 0x18
		public int GPMILOPNBPA_LastScoreExcellent; // 0x1C
		public int PBGLMBMEKAA_LastCombo; // 0x20
		public int CODDMAKLBDO_LastComboRank; // 0x24
		public int IKBLCEFCGDE_LastLuck; // 0x28
		public List<ILDKBCLAFPB.ABBBCBIHMFE_DropItem> KKAOCDKGJHJ_DropItems = new List<ILDKBCLAFPB.ABBBCBIHMFE_DropItem>(); // 0x2C
		public int[] ODIGNDEKCGA_NoteResultCount = new int[5]; // 0x30
		public CEBFFLDKAEC_SecureInt KELFCMEOPPM_EpisodeId = new CEBFFLDKAEC_SecureInt(); // 0x34
		public long BENGJHEDCAK_EpisodeDate; // 0x38

		// RVA: 0x2026D28 Offset: 0x2026D28 VA: 0x2026D28
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["lastBaseUnionCredit"] = NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value;
			res["lastDropUnionCredit"] = MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value;
			res["lastScore"] = GCAPLLEIAAI_LastScore;
			res["lastScoreExcellent"] = GPMILOPNBPA_LastScoreExcellent;
			res["lastCombo"] = PBGLMBMEKAA_LastCombo;
			res["lastComboRank"] = CODDMAKLBDO_LastComboRank;
			res["lastLuck"] = IKBLCEFCGDE_LastLuck;
			res["sceneData"] = PNLOINMCCKH_SceneData.NOJCMGAFAAC();
			res["divaData"] = DGCJCAHIAPP_DivaData.NOJCMGAFAAC();
			EDOHBJAPLPF_JsonData array = new EDOHBJAPLPF_JsonData();
			array.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < KKAOCDKGJHJ_DropItems.Count; i++)
			{
				array.Add(KKAOCDKGJHJ_DropItems[i].NOJCMGAFAAC());
			}
			res["dropItem"] = array;
			array = new EDOHBJAPLPF_JsonData();
			array.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ODIGNDEKCGA_NoteResultCount.Length; i++)
			{
				array.Add(ODIGNDEKCGA_NoteResultCount[i]);
			}
			res["notesResultCount"] = array;
			res["episodeId"] = KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value;
			res["episodeDate"] = BENGJHEDCAK_EpisodeDate;
			return res;
		}

		// // RVA: 0x2027660 Offset: 0x2027660 VA: 0x2027660
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "lastBaseUnionCredit", 0);
			MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "lastDropUnionCredit", 0);
			GCAPLLEIAAI_LastScore = JsonUtil.GetInt(OBHAFLMHAKG, "lastScore", 0);
			GPMILOPNBPA_LastScoreExcellent = JsonUtil.GetInt(OBHAFLMHAKG, "lastScoreExcellent", 0);
			PBGLMBMEKAA_LastCombo = JsonUtil.GetInt(OBHAFLMHAKG, "lastCombo", 0);
			CODDMAKLBDO_LastComboRank = JsonUtil.GetInt(OBHAFLMHAKG, "lastComboRank", 0);
			IKBLCEFCGDE_LastLuck = JsonUtil.GetInt(OBHAFLMHAKG, "lastLuck", 0);
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("sceneData"))
			{
				PNLOINMCCKH_SceneData.KHEKNNFCAOI_Init(OBHAFLMHAKG["sceneData"]);
			}
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("divaData"))
			{
				DGCJCAHIAPP_DivaData.KHEKNNFCAOI_Init(OBHAFLMHAKG["divaData"]);
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
			KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value = JsonUtil.GetInt(OBHAFLMHAKG, "episodeId", 0);
			BENGJHEDCAK_EpisodeDate = JsonUtil.GetLong(OBHAFLMHAKG, "episodeDate", 0);
		}

		// // RVA: 0x202A99C Offset: 0x202A99C VA: 0x202A99C
		public static bool CHDGLBBFEKH_IsEqual(GCLIKCLDDKG_PlayerData ILEKEPJBFDP, GCLIKCLDDKG_PlayerData GEPALDIIDPC)
		{
			if (!(KKNFJMEBONI_SceneData.CHDGLBBFEKH(ILEKEPJBFDP.PNLOINMCCKH_SceneData, GEPALDIIDPC.PNLOINMCCKH_SceneData) &&
				BEBBCJLDOFF_DivaData.CHDGLBBFEKH(ILEKEPJBFDP.DGCJCAHIAPP_DivaData, GEPALDIIDPC.DGCJCAHIAPP_DivaData) &&
				ILEKEPJBFDP.KKAOCDKGJHJ_DropItems.Count == GEPALDIIDPC.KKAOCDKGJHJ_DropItems.Count &&
				ILEKEPJBFDP.NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value == GEPALDIIDPC.NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value &&
				ILEKEPJBFDP.MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value == GEPALDIIDPC.MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value &&
				ILEKEPJBFDP.GCAPLLEIAAI_LastScore == GEPALDIIDPC.GCAPLLEIAAI_LastScore &&
				ILEKEPJBFDP.GPMILOPNBPA_LastScoreExcellent == GEPALDIIDPC.GPMILOPNBPA_LastScoreExcellent &&
				ILEKEPJBFDP.PBGLMBMEKAA_LastCombo == GEPALDIIDPC.PBGLMBMEKAA_LastCombo &&
				ILEKEPJBFDP.CODDMAKLBDO_LastComboRank == GEPALDIIDPC.CODDMAKLBDO_LastComboRank &&
				ILEKEPJBFDP.IKBLCEFCGDE_LastLuck == GEPALDIIDPC.IKBLCEFCGDE_LastLuck))
				return false;
			for(int i = 0; i < ILEKEPJBFDP.KKAOCDKGJHJ_DropItems.Count; i++)
			{
				if (!ABBBCBIHMFE_DropItem.CHDGLBBFEKH(ILEKEPJBFDP.KKAOCDKGJHJ_DropItems[i], GEPALDIIDPC.KKAOCDKGJHJ_DropItems[i]))
					return false;
			}
			for(int i = 0; i < ILEKEPJBFDP.ODIGNDEKCGA_NoteResultCount.Length; i++)
			{
				if (ILEKEPJBFDP.ODIGNDEKCGA_NoteResultCount[i] != GEPALDIIDPC.ODIGNDEKCGA_NoteResultCount[i])
					return false;
			}
			if (ILEKEPJBFDP.KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value == GEPALDIIDPC.KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value &&
				ILEKEPJBFDP.BENGJHEDCAK_EpisodeDate == GEPALDIIDPC.BENGJHEDCAK_EpisodeDate)
				return true;
			return false;
		}

		// // RVA: 0x202651C Offset: 0x202651C VA: 0x202651C
		public static bool HMMFJOEBEKJ(GCLIKCLDDKG_PlayerData ILEKEPJBFDP, GCLIKCLDDKG_PlayerData GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

		// // RVA: 0x20266A8 Offset: 0x20266A8 VA: 0x20266A8
		public void ODDIHGPONFL_Copy(GCLIKCLDDKG_PlayerData CHOFCBBPDCH)
		{
			CHOFCBBPDCH.PNLOINMCCKH_SceneData.ODDIHGPONFL_Copy(PNLOINMCCKH_SceneData);
			CHOFCBBPDCH.DGCJCAHIAPP_DivaData.ODDIHGPONFL_Copy(DGCJCAHIAPP_DivaData);
			NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value = CHOFCBBPDCH.NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value;
			MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value = CHOFCBBPDCH.MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value;
			GCAPLLEIAAI_LastScore = CHOFCBBPDCH.GCAPLLEIAAI_LastScore;
			GPMILOPNBPA_LastScoreExcellent = CHOFCBBPDCH.GPMILOPNBPA_LastScoreExcellent;
			PBGLMBMEKAA_LastCombo = CHOFCBBPDCH.PBGLMBMEKAA_LastCombo;
			CODDMAKLBDO_LastComboRank = CHOFCBBPDCH.CODDMAKLBDO_LastComboRank;
			IKBLCEFCGDE_LastLuck = CHOFCBBPDCH.IKBLCEFCGDE_LastLuck;
			for(int i = 0; i < CHOFCBBPDCH.KKAOCDKGJHJ_DropItems.Count; i++)
			{
				ABBBCBIHMFE_DropItem item = new ABBBCBIHMFE_DropItem();
				CHOFCBBPDCH.KKAOCDKGJHJ_DropItems[i].ODDIHGPONFL_Copy(item);
				KKAOCDKGJHJ_DropItems.Add(item);
			}
			for(int i = 0; i < CHOFCBBPDCH.ODIGNDEKCGA_NoteResultCount.Length; i++)
			{
				ODIGNDEKCGA_NoteResultCount[i] = CHOFCBBPDCH.ODIGNDEKCGA_NoteResultCount[i];
			}
			KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value = CHOFCBBPDCH.KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value;
			BENGJHEDCAK_EpisodeDate = CHOFCBBPDCH.BENGJHEDCAK_EpisodeDate;
		}

		// // RVA: 0x2027C00 Offset: 0x2027C00 VA: 0x2027C00
		public void INBCGKAFHDO(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
		{
			AHEFHIMGIBI.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_VfId = 1;
			if(PNLOINMCCKH_SceneData.PPFNGGCBJKC_Id.DNJEJEANJGL_Value > 0)
			{
				MMPBPOIFDAF_Scene.PMKOFEIONEG scene = AHEFHIMGIBI.PNLOINMCCKH_Scene.OPIBAPEGCLA[PNLOINMCCKH_SceneData.PPFNGGCBJKC_Id.DNJEJEANJGL_Value - 1];
				scene.JPIPENJGGDD_Mlt = 0;
				scene.LHMOAJAIJCO_New = PNLOINMCCKH_SceneData.CADENLBDAEB_IsNew != 0;
				scene.BEBJKJKBOGH_Date = PNLOINMCCKH_SceneData.BEBJKJKBOGH_Date;
			}
			if(DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id > 0)
			{
				AHEFHIMGIBI.MLAFAACKKBG_Unit.GCINIJEMHFK(0).FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id = DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id;
				AHEFHIMGIBI.MLAFAACKKBG_Unit.GCINIJEMHFK(0).FDBOPFEOENF_MainDivas[0].EBDNICPAFLB_SSlot[0] = DGCJCAHIAPP_DivaData.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value;
				AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id - 1].CPGFPEDMDEH_Have = 1;
				AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id - 1].BEEAIAAJOHD_CostumeId = 0;
				AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id - 1].AFNIOJHODAG_CostumeColorId = 0;
				AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id - 1].PIGLAEFPNEK_MSlot = DGCJCAHIAPP_DivaData.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value;
				AHEFHIMGIBI.KCCLEHLLOFG_Common.NIKCFOALFJC_DivaFirst = DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id;
			}
			if(KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value > 0)
			{
				OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo ep = AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value - 1];
				ep.BEBJKJKBOGH_Date = BENGJHEDCAK_EpisodeDate;
			}
			if(NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value > 0)
			{
				AHEFHIMGIBI.KCCLEHLLOFG_Common.ENEMPFLFEHP_AddUc(NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value);
				AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EJJAPFPJLHP_AddUc(NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value);
			}
			for(int i = 0; i < KKAOCDKGJHJ_DropItems.Count; i++)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KKAOCDKGJHJ_DropItems[i].KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value);
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KKAOCDKGJHJ_DropItems[i].KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
				{
					AHEFHIMGIBI.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[itemId - 1].BFINGCJHOHI_Cnt += KKAOCDKGJHJ_DropItems[i].HMFFHLPNMPH_Count;
				}
				else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
				{
					DGDIEDDPNNG_UcItem.FCPCMPLGJNP ucItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NMJEDFNPIPL_UcItem.CDENCMNHNGA[itemId - 1];
					AHEFHIMGIBI.KCCLEHLLOFG_Common.ENEMPFLFEHP_AddUc(ucItem.JBGEEPFKIGG_Val * KKAOCDKGJHJ_DropItems[i].HMFFHLPNMPH_Count);
					AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EJJAPFPJLHP_AddUc(ucItem.JBGEEPFKIGG_Val * KKAOCDKGJHJ_DropItems[i].HMFFHLPNMPH_Count);
				}
			}
		}

		// // RVA: 0x202AE10 Offset: 0x202AE10 VA: 0x202AE10
		public void MFNPKIACGLM(JGEOBNENMAH FDOODGBBKEE, BBHNACPENDM_ServerSaveData AHEFHIMGIBI, GameSetupData KCMGEINBEFO, GameResultData HHPEADPLPKG)
		{
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo music = AHEFHIMGIBI.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[KCMGEINBEFO.musicInfo.freeMusicId - 1];
			music.ODEHJGPDFCL_Score = GCAPLLEIAAI_LastScore;
			music.ECLDABOLHLM_ExcellentScore = GPMILOPNBPA_LastScoreExcellent;
			music.PDNJGJNGPNJ_MaxCombo = PBGLMBMEKAA_LastCombo;
			music.ABFNAEKEGOB_ComboRank = CODDMAKLBDO_LastComboRank;
			music.ANDJNPEINGI_TeamLuck = IKBLCEFCGDE_LastLuck;
			int[] notes = new int[5];
			for(int i = 0; i < ODIGNDEKCGA_NoteResultCount.Length; i++)
			{
				notes[i] = ODIGNDEKCGA_NoteResultCount[i];
			}
			HHPEADPLPKG.Setup(true, false, notes, null, 0);
			FDOODGBBKEE.DCELMKFJHPG.Clear();
			for(int i = 0; i < KKAOCDKGJHJ_DropItems.Count; i++)
			{
				IELJJAAJAOE d = new IELJJAAJAOE();
				d.KIJAPOFAGPN_ItemId = KKAOCDKGJHJ_DropItems[i].KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value;
				d.OIPCCBHIKIA_ItemCode = KKAOCDKGJHJ_DropItems[i].OIPCCBHIKIA_Index;
				d.OMAJOEOOAJJ_Cnt = KKAOCDKGJHJ_DropItems[i].OMAJOEOOAJJ_Count0;
				d.HMFFHLPNMPH = KKAOCDKGJHJ_DropItems[i].HMFFHLPNMPH_Count;
				d.JPIPENJGGDD = KKAOCDKGJHJ_DropItems[i].JPIPENJGGDD_Multi;
				d.PLKAGPBEHMB = KKAOCDKGJHJ_DropItems[i].PLKAGPBEHMB_LuckPlus;
				d.ONDODHPHOOF = KKAOCDKGJHJ_DropItems[i].ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value;
				d.ABIFFLDIAMM = KKAOCDKGJHJ_DropItems[i].ABIFFLDIAMM_ConvertItemCount;
				d.LHEDLDEMPPG = KKAOCDKGJHJ_DropItems[i].LHEDLDEMPPG_IsNewScene;
				d.PHJHJGDLPED = KKAOCDKGJHJ_DropItems[i].PHJHJGDLPED_IsRareDrop;
				FDOODGBBKEE.DCELMKFJHPG.Add(d);
			}
			FDOODGBBKEE.NMDKKAAOIOI_LastBaseUnionCredit = NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value;
			FDOODGBBKEE.MJKFDDKLLFP_LastDropUnionCredit = MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value;
		}

		// // RVA: 0x20289CC Offset: 0x20289CC VA: 0x20289CC
		public void MNGKOHKKAHI(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
		{
			for(int i = 0; i < AHEFHIMGIBI.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count; i++)
			{
				if(AHEFHIMGIBI.PNLOINMCCKH_Scene.OPIBAPEGCLA[i].IHIAFIHAAPO_Unlocked)
				{
					PNLOINMCCKH_SceneData.EDEDFDDIOKO(AHEFHIMGIBI.PNLOINMCCKH_Scene.OPIBAPEGCLA[i]);
					break;
				}
			}
			for(int i = 0; i < AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList.Count; i++)
			{
				if (AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date != 0)
				{
					KELFCMEOPPM_EpisodeId.DNJEJEANJGL_Value = AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i].HPLMMKHBKIG_Id;
					BENGJHEDCAK_EpisodeDate = AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i].BEBJKJKBOGH_Date;
					break;
				}
			}
			//LAB_02028d80
			for(int i = 0; i < AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				if(AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have > 0)
				{
					DGCJCAHIAPP_DivaData.PPFNGGCBJKC_Id = AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].DIPKCALNIII_DivaId;
					DGCJCAHIAPP_DivaData.AFBMEMCHJCL_MainScene.DNJEJEANJGL_Value = AHEFHIMGIBI.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].PIGLAEFPNEK_MSlot;
					break;
				}
			}
		}

		// // RVA: 0x202B594 Offset: 0x202B594 VA: 0x202B594
		public void EJFNMIFOFME(JGEOBNENMAH FDOODGBBKEE, BBHNACPENDM_ServerSaveData AHEFHIMGIBI, GameSetupData KCMGEINBEFO, GameResultData HHPEADPLPKG)
		{
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo rmusic = AHEFHIMGIBI.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[KCMGEINBEFO.musicInfo.freeMusicId - 1];
			GCAPLLEIAAI_LastScore = rmusic.ODEHJGPDFCL_Score;
			GPMILOPNBPA_LastScoreExcellent = rmusic.ECLDABOLHLM_ExcellentScore;
			PBGLMBMEKAA_LastCombo = rmusic.PDNJGJNGPNJ_MaxCombo;
			CODDMAKLBDO_LastComboRank = rmusic.ABFNAEKEGOB_ComboRank;
			IKBLCEFCGDE_LastLuck = rmusic.ANDJNPEINGI_TeamLuck;
			for(int i = 0; i < ODIGNDEKCGA_NoteResultCount.Length; i++)
			{
				ODIGNDEKCGA_NoteResultCount[i] = HHPEADPLPKG.GetNoteTypeCount((RhythmGameConsts.NoteResult)i);
			}
			KKAOCDKGJHJ_DropItems.Clear();
			for(int i = 0; i < FDOODGBBKEE.DCELMKFJHPG.Count; i++)
			{
				ABBBCBIHMFE_DropItem d = new ABBBCBIHMFE_DropItem();
				IELJJAAJAOE it = FDOODGBBKEE.DCELMKFJHPG[i];
				d.KIJAPOFAGPN_ItemId.DNJEJEANJGL_Value = it.KIJAPOFAGPN_ItemId;
				d.OIPCCBHIKIA_Index = it.OIPCCBHIKIA_ItemCode;
				d.OMAJOEOOAJJ_Count0 = it.OMAJOEOOAJJ_Cnt;
				d.HMFFHLPNMPH_Count = it.HMFFHLPNMPH;
				d.JPIPENJGGDD_Multi = it.JPIPENJGGDD;
				d.PLKAGPBEHMB_LuckPlus = it.PLKAGPBEHMB;
				d.ONDODHPHOOF_ConvertItemId.DNJEJEANJGL_Value = it.ONDODHPHOOF;
				d.ABIFFLDIAMM_ConvertItemCount = it.ABIFFLDIAMM;
				d.LHEDLDEMPPG_IsNewScene = it.LHEDLDEMPPG;
				d.PHJHJGDLPED_IsRareDrop = it.PHJHJGDLPED;
				KKAOCDKGJHJ_DropItems.Add(d);
			}
			NMDKKAAOIOI_LastBaseUnionCredit.DNJEJEANJGL_Value = FDOODGBBKEE.NMDKKAAOIOI_LastBaseUnionCredit;
			MJKFDDKLLFP_LastDropUnionCredit.DNJEJEANJGL_Value = FDOODGBBKEE.MJKFDDKLLFP_LastDropUnionCredit;
		}

		// // RVA: 0x2028F7C Offset: 0x2028F7C VA: 0x2028F7C
		public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
		{
			if (PNLOINMCCKH_SceneData.KPOCKNCJBPN_CheckSecure() != null)
				return PNLOINMCCKH_SceneData.KPOCKNCJBPN_CheckSecure();
			if (DGCJCAHIAPP_DivaData.KPOCKNCJBPN_CheckSecure() != null)
				return DGCJCAHIAPP_DivaData.KPOCKNCJBPN_CheckSecure();
			if (NMDKKAAOIOI_LastBaseUnionCredit.KPOCKNCJBPN_CheckSecure() != null)
				return NMDKKAAOIOI_LastBaseUnionCredit.KPOCKNCJBPN_CheckSecure();
			if (MJKFDDKLLFP_LastDropUnionCredit.KPOCKNCJBPN_CheckSecure() != null)
				return MJKFDDKLLFP_LastDropUnionCredit.KPOCKNCJBPN_CheckSecure();
			if (KELFCMEOPPM_EpisodeId.KPOCKNCJBPN_CheckSecure() != null)
				return KELFCMEOPPM_EpisodeId.KPOCKNCJBPN_CheckSecure();
			for(int i = 0; i < KKAOCDKGJHJ_DropItems.Count; i++)
			{
				//??
			}
			return null;
		}
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
		public bool ODKIHPBEOEC_IsTrue(int PPFNGGCBJKC)
		{
			return (KGMLFAFPOKP[PPFNGGCBJKC >> 5] & (1 << (PPFNGGCBJKC & 0x1f))) != 0;
		}

		// // RVA: 0x2025540 Offset: 0x2025540 VA: 0x2025540
		// public bool LANDKPMJEFB(int PPFNGGCBJKC) { }

		// // RVA: 0x201BAF8 Offset: 0x201BAF8 VA: 0x201BAF8
		public void EDEDFDDIOKO_SetTrue(int PPFNGGCBJKC)
		{
			KGMLFAFPOKP[PPFNGGCBJKC >> 5] |= 1 << (PPFNGGCBJKC & 0x1f);
		}

		// // RVA: 0x2025554 Offset: 0x2025554 VA: 0x2025554
		// public void GIBNLEBILNO(int PPFNGGCBJKC) { }

		// // RVA: 0x20255B0 Offset: 0x20255B0 VA: 0x20255B0
		public void JCHLONCMPAJ_Clear()
		{
			for (int i = 0; i < KGMLFAFPOKP.Length; i++)
			{
				KGMLFAFPOKP[i] = 0;
			}
		}

		// // RVA: 0x2025628 Offset: 0x2025628 VA: 0x2025628
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			for(int i = 0; i < KGMLFAFPOKP.Length; i++)
			{
				KGMLFAFPOKP[i] = JsonUtil.GetInt(OBHAFLMHAKG[i]);
			}
		}

		// // RVA: 0x20256F0 Offset: 0x20256F0 VA: 0x20256F0
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			for(int i = 0; i < KGMLFAFPOKP.Length; i++)
			{
				res.Add(KGMLFAFPOKP[i]);
			}
			return res;
		}

		// // RVA: 0x2025810 Offset: 0x2025810 VA: 0x2025810
		public static bool CHDGLBBFEKH_IsEqual(BKLCILHFCGB_Flags ILEKEPJBFDP, BKLCILHFCGB_Flags GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.KGMLFAFPOKP.Length != GEPALDIIDPC.KGMLFAFPOKP.Length)
				return false;
			for(int i = 0; i < ILEKEPJBFDP.KGMLFAFPOKP.Length; i++)
			{
				if (ILEKEPJBFDP.KGMLFAFPOKP[i] != GEPALDIIDPC.KGMLFAFPOKP[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x2025928 Offset: 0x2025928 VA: 0x2025928
		public static bool HMMFJOEBEKJ(BKLCILHFCGB_Flags ILEKEPJBFDP, BKLCILHFCGB_Flags GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

		// // RVA: 0x202593C Offset: 0x202593C VA: 0x202593C
		public void ODDIHGPONFL_Copy(BKLCILHFCGB_Flags CHOFCBBPDCH)
		{
			if(KGMLFAFPOKP.Length != CHOFCBBPDCH.KGMLFAFPOKP.Length)
			{
				KGMLFAFPOKP = new int[CHOFCBBPDCH.KGMLFAFPOKP.Length];
			}
			Array.Copy(CHOFCBBPDCH.KGMLFAFPOKP, KGMLFAFPOKP, CHOFCBBPDCH.KGMLFAFPOKP.Length);
		}

		// // RVA: 0x201BA70 Offset: 0x201BA70 VA: 0x201BA70
		public int BCGHBIMJOFP_Count()
		{
			return KGMLFAFPOKP.Length << 5;
		}
	}

    public class DNLECGEBDOI_Tutorial
    {
        public int OLDAGCNLJOI_Progress; // 0x8
        public int CEMEIPNMAAD_Version; // 0xC
        public long KINJOEIAHFK_StartTime; // 0x10
        public int PPOJCDCCFNI_TutorialEnd; // 0x18
        public int NJFNCNCJMOO_FirstLogin; // 0x1C
        public GCLIKCLDDKG_PlayerData AHEFHIMGIBI_PlayerData = new GCLIKCLDDKG_PlayerData(); // 0x20
        public BKLCILHFCGB_Flags INEAGJMJLFG_TutorialAlreadyFlags = new BKLCILHFCGB_Flags(128); // 0x24
        public BKLCILHFCGB_Flags PNNHEOOJBFI_TutorialGeneralFlags = new BKLCILHFCGB_Flags(32); // 0x28
        public int JKHNILLPKBO_LCnt; // 0x2C
        public int HLKKGIKPLOM_LDay; // 0x30

        // // RVA: 0x2026434 Offset: 0x2026434 VA: 0x2026434
        public static bool CHDGLBBFEKH_IsEqual(DNLECGEBDOI_Tutorial ILEKEPJBFDP, DNLECGEBDOI_Tutorial GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.CEMEIPNMAAD_Version == GEPALDIIDPC.CEMEIPNMAAD_Version &&
				ILEKEPJBFDP.OLDAGCNLJOI_Progress == GEPALDIIDPC.OLDAGCNLJOI_Progress &&
				ILEKEPJBFDP.KINJOEIAHFK_StartTime == GEPALDIIDPC.KINJOEIAHFK_StartTime &&
				ILEKEPJBFDP.PPOJCDCCFNI_TutorialEnd == GEPALDIIDPC.PPOJCDCCFNI_TutorialEnd &&
				ILEKEPJBFDP.NJFNCNCJMOO_FirstLogin == GEPALDIIDPC.NJFNCNCJMOO_FirstLogin &&
				ILEKEPJBFDP.JKHNILLPKBO_LCnt == GEPALDIIDPC.JKHNILLPKBO_LCnt &&
				ILEKEPJBFDP.HLKKGIKPLOM_LDay == GEPALDIIDPC.HLKKGIKPLOM_LDay &&
				GCLIKCLDDKG_PlayerData.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.AHEFHIMGIBI_PlayerData, GEPALDIIDPC.AHEFHIMGIBI_PlayerData) &&
				BKLCILHFCGB_Flags.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.INEAGJMJLFG_TutorialAlreadyFlags, GEPALDIIDPC.INEAGJMJLFG_TutorialAlreadyFlags) &&
				BKLCILHFCGB_Flags.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.PNNHEOOJBFI_TutorialGeneralFlags, GEPALDIIDPC.PNNHEOOJBFI_TutorialGeneralFlags))
				return true;
			return false;
		}

        // // RVA: 0x2026530 Offset: 0x2026530 VA: 0x2026530
        public static bool HMMFJOEBEKJ(ILDKBCLAFPB.DNLECGEBDOI_Tutorial ILEKEPJBFDP, ILDKBCLAFPB.DNLECGEBDOI_Tutorial GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

        // // RVA: 0x2026544 Offset: 0x2026544 VA: 0x2026544
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.DNLECGEBDOI_Tutorial FMKAONAMGCN)
		{
			FMKAONAMGCN.OLDAGCNLJOI_Progress = OLDAGCNLJOI_Progress;
			FMKAONAMGCN.CEMEIPNMAAD_Version = CEMEIPNMAAD_Version;
			FMKAONAMGCN.KINJOEIAHFK_StartTime = KINJOEIAHFK_StartTime;
			FMKAONAMGCN.PPOJCDCCFNI_TutorialEnd = PPOJCDCCFNI_TutorialEnd;
			FMKAONAMGCN.NJFNCNCJMOO_FirstLogin = NJFNCNCJMOO_FirstLogin;
			FMKAONAMGCN.JKHNILLPKBO_LCnt = JKHNILLPKBO_LCnt;
			FMKAONAMGCN.HLKKGIKPLOM_LDay = HLKKGIKPLOM_LDay;
			FMKAONAMGCN.AHEFHIMGIBI_PlayerData.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
			FMKAONAMGCN.INEAGJMJLFG_TutorialAlreadyFlags.ODDIHGPONFL_Copy(INEAGJMJLFG_TutorialAlreadyFlags);
			FMKAONAMGCN.PNNHEOOJBFI_TutorialGeneralFlags.ODDIHGPONFL_Copy(PNNHEOOJBFI_TutorialGeneralFlags);
		}

        // // RVA: 0x20269E4 Offset: 0x20269E4 VA: 0x20269E4
        public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["progress"] = OLDAGCNLJOI_Progress;
			res["version"] = CEMEIPNMAAD_Version;
			res["startTime"] = KINJOEIAHFK_StartTime;
			res["tutorialEnd"] = PPOJCDCCFNI_TutorialEnd;
			res["firstLogin"] = NJFNCNCJMOO_FirstLogin;
			res["playerData"] = AHEFHIMGIBI_PlayerData.NOJCMGAFAAC();
			res["tutorialAlreadyFlags"] = INEAGJMJLFG_TutorialAlreadyFlags.NOJCMGAFAAC();
			res["tutorialGeneralFlags"] = PNNHEOOJBFI_TutorialGeneralFlags.NOJCMGAFAAC();
			res["lcnt"] = JKHNILLPKBO_LCnt;
			res["lday"] = HLKKGIKPLOM_LDay;
			return res;
		}

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
				AHEFHIMGIBI_PlayerData.KHEKNNFCAOI_Init(OBHAFLMHAKG["playerData"]);
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
        public void INBCGKAFHDO(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
		{
			AHEFHIMGIBI_PlayerData.INBCGKAFHDO(AHEFHIMGIBI);
		}

        // // RVA: 0x202899C Offset: 0x202899C VA: 0x202899C
        public void LFNEPDFBINM(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
		{
			AHEFHIMGIBI_PlayerData.MNGKOHKKAHI(AHEFHIMGIBI);
		}

        // // RVA: 0x2028F6C Offset: 0x2028F6C VA: 0x2028F6C
        public void DGMFOHADMHN(CDIPJNPICCO_RecoveryPoint FOFFPCGACMF)
		{
			OLDAGCNLJOI_Progress = (int)FOFFPCGACMF;
		}

        // // RVA: 0x2028F74 Offset: 0x2028F74 VA: 0x2028F74
        public CDIPJNPICCO_RecoveryPoint KMKIGHHCAGE()
		{
			return (CDIPJNPICCO_RecoveryPoint)OLDAGCNLJOI_Progress;
		}

        // // RVA: 0x201B2EC Offset: 0x201B2EC VA: 0x201B2EC
        public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
		{
			return AHEFHIMGIBI_PlayerData.KPOCKNCJBPN_CheckSecure();
		}
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
			public void LHPDDGIJKNB()
			{
				LHPDCGNKPHD_sortItem = 40;
				DPDBMECAIIO_NumUnitsFilterBits = 0;
				GONLKIDILLH_BookmarkIndex = 0;
				AONOGHPAENH_filterMusicUnLock = 0;
				ALGFGPCPGFK_filterRange = 0;
				EOCPIGDIFNB_MusicAttrFilterBits = 0;
				JJNLEPEKNDO_ComboFilterBits = 0;
				PGMJCBIHNHK_RewardFilterBits = 0;
			}

			//// RVA: 0x202D040 Offset: 0x202D040 VA: 0x202D040
			public void ODDIHGPONFL(CLBMCCEEDGE_VerticalMusicSelect DNNHDJPNIAK)
			{
				DNNHDJPNIAK.EOCPIGDIFNB_MusicAttrFilterBits = EOCPIGDIFNB_MusicAttrFilterBits;
				DNNHDJPNIAK.JJNLEPEKNDO_ComboFilterBits = JJNLEPEKNDO_ComboFilterBits;
				DNNHDJPNIAK.PGMJCBIHNHK_RewardFilterBits = PGMJCBIHNHK_RewardFilterBits;
				DNNHDJPNIAK.DPDBMECAIIO_NumUnitsFilterBits = DPDBMECAIIO_NumUnitsFilterBits;
				DNNHDJPNIAK.GONLKIDILLH_BookmarkIndex = GONLKIDILLH_BookmarkIndex;
				DNNHDJPNIAK.AONOGHPAENH_filterMusicUnLock = AONOGHPAENH_filterMusicUnLock;
				DNNHDJPNIAK.ALGFGPCPGFK_filterRange = ALGFGPCPGFK_filterRange;
				DNNHDJPNIAK.LHPDCGNKPHD_sortItem = LHPDCGNKPHD_sortItem;
			}

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
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["filterMusicAttr"] = EOCPIGDIFNB_MusicAttrFilterBits;
				res["filterCombo"] = JJNLEPEKNDO_ComboFilterBits;
				res["filterReward"] = PGMJCBIHNHK_RewardFilterBits;
				res["filterUnit"] = DPDBMECAIIO_NumUnitsFilterBits;
				res["filterMusicBookMark"] = GONLKIDILLH_BookmarkIndex;
				res["filterMusicUnLock"] = AONOGHPAENH_filterMusicUnLock;
				res["filterRange"] = ALGFGPCPGFK_filterRange;
				res["sortItem"] = LHPDCGNKPHD_sortItem;
				return res;
			}

			//// RVA: 0x2031A08 Offset: 0x2031A08 VA: 0x2031A08
			public static bool CHDGLBBFEKH_IsEqual(CLBMCCEEDGE_VerticalMusicSelect ILEKEPJBFDP, CLBMCCEEDGE_VerticalMusicSelect GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.EOCPIGDIFNB_MusicAttrFilterBits == GEPALDIIDPC.EOCPIGDIFNB_MusicAttrFilterBits &&
					ILEKEPJBFDP.JJNLEPEKNDO_ComboFilterBits == GEPALDIIDPC.JJNLEPEKNDO_ComboFilterBits &&
					ILEKEPJBFDP.PGMJCBIHNHK_RewardFilterBits == GEPALDIIDPC.PGMJCBIHNHK_RewardFilterBits &&
					ILEKEPJBFDP.DPDBMECAIIO_NumUnitsFilterBits == GEPALDIIDPC.DPDBMECAIIO_NumUnitsFilterBits &&
					ILEKEPJBFDP.GONLKIDILLH_BookmarkIndex == GEPALDIIDPC.GONLKIDILLH_BookmarkIndex &&
					ILEKEPJBFDP.AONOGHPAENH_filterMusicUnLock == GEPALDIIDPC.AONOGHPAENH_filterMusicUnLock &&
					ILEKEPJBFDP.ALGFGPCPGFK_filterRange == GEPALDIIDPC.ALGFGPCPGFK_filterRange &&
					ILEKEPJBFDP.LHPDCGNKPHD_sortItem == GEPALDIIDPC.LHPDCGNKPHD_sortItem)
					return true;
				return false;
			}

			//// RVA: 0x202C5FC Offset: 0x202C5FC VA: 0x202C5FC
			public static bool HMMFJOEBEKJ(CLBMCCEEDGE_VerticalMusicSelect ILEKEPJBFDP, CLBMCCEEDGE_VerticalMusicSelect GEPALDIIDPC)
			{
				return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
			}
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
			public void ODDIHGPONFL(MMALELPFEBH_UserList DNNHDJPNIAK)
			{
				DNNHDJPNIAK.LHPDCGNKPHD_sortItem = LHPDCGNKPHD_sortItem;
				DNNHDJPNIAK.NPEEPPCPEPE_assistItem = NPEEPPCPEPE_assistItem;
				DNNHDJPNIAK.ACCHOFLOOEC_filter = ACCHOFLOOEC_filter;
				DNNHDJPNIAK.BOFFOHHLLFG_attributeFilter = BOFFOHHLLFG_attributeFilter;
				DNNHDJPNIAK.BBIIHLNBHDE_seriaseFilter = BBIIHLNBHDE_seriaseFilter;
				DNNHDJPNIAK.LKPCKPJGJKN_centerSkillFilter = LKPCKPJGJKN_centerSkillFilter;
				DNNHDJPNIAK.EILKGEADKGH_order = EILKGEADKGH_order;
			}

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
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["sortItem"] = LHPDCGNKPHD_sortItem;
				res["assistItem"] = NPEEPPCPEPE_assistItem;
				res["filter"] = ACCHOFLOOEC_filter;
				res["attributeFilter"] = BOFFOHHLLFG_attributeFilter;
				res["seriaseFilter"] = BBIIHLNBHDE_seriaseFilter;
				res["centerSkillFilter"] = LKPCKPJGJKN_centerSkillFilter;
				res["order"] = EILKGEADKGH_order;
				return res;
			}

			//// RVA: 0x2032054 Offset: 0x2032054 VA: 0x2032054
			public static bool CHDGLBBFEKH(MMALELPFEBH_UserList ILEKEPJBFDP, MMALELPFEBH_UserList GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.LHPDCGNKPHD_sortItem == GEPALDIIDPC.LHPDCGNKPHD_sortItem &&
					ILEKEPJBFDP.NPEEPPCPEPE_assistItem == GEPALDIIDPC.NPEEPPCPEPE_assistItem &&
					ILEKEPJBFDP.ACCHOFLOOEC_filter == GEPALDIIDPC.ACCHOFLOOEC_filter &&
					ILEKEPJBFDP.BOFFOHHLLFG_attributeFilter == GEPALDIIDPC.BOFFOHHLLFG_attributeFilter &&
					ILEKEPJBFDP.BBIIHLNBHDE_seriaseFilter == GEPALDIIDPC.BBIIHLNBHDE_seriaseFilter &&
					ILEKEPJBFDP.LKPCKPJGJKN_centerSkillFilter == GEPALDIIDPC.LKPCKPJGJKN_centerSkillFilter &&
					ILEKEPJBFDP.EILKGEADKGH_order == GEPALDIIDPC.EILKGEADKGH_order)
					return true;
				return false;
			}

			//// RVA: 0x202C598 Offset: 0x202C598 VA: 0x202C598
			public static bool HMMFJOEBEKJ(MMALELPFEBH_UserList ILEKEPJBFDP, MMALELPFEBH_UserList GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
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
			public void ODDIHGPONFL(BNIKLNDKMEO_EpisodeSelect DNNHDJPNIAK)
			{
				DNNHDJPNIAK.LHPDCGNKPHD_sortItem = LHPDCGNKPHD_sortItem;
				DNNHDJPNIAK.EILKGEADKGH_order = EILKGEADKGH_order;
				DNNHDJPNIAK.CNGFLNMNIMJ_filterMainEp = CNGFLNMNIMJ_filterMainEp;
				DNNHDJPNIAK.IKEMMEAEPLM_filterDivaAndVal = IKEMMEAEPLM_filterDivaAndVal;
				DNNHDJPNIAK.JFOPNJOOGNI_filterSeriese = JFOPNJOOGNI_filterSeriese;
			}

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
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["sortItem"] = LHPDCGNKPHD_sortItem;
				res["order"] = EILKGEADKGH_order;
				res["filterMainEp"] = CNGFLNMNIMJ_filterMainEp;
				res["filterDivaAndVal"] = IKEMMEAEPLM_filterDivaAndVal;
				res["filterSeriese"] = JFOPNJOOGNI_filterSeriese;
				return res;
			}

			//// RVA: 0x2031900 Offset: 0x2031900 VA: 0x2031900
			public static bool CHDGLBBFEKH(BNIKLNDKMEO_EpisodeSelect ILEKEPJBFDP, BNIKLNDKMEO_EpisodeSelect GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.LHPDCGNKPHD_sortItem == GEPALDIIDPC.LHPDCGNKPHD_sortItem &&
					ILEKEPJBFDP.EILKGEADKGH_order == GEPALDIIDPC.EILKGEADKGH_order &&
					ILEKEPJBFDP.CNGFLNMNIMJ_filterMainEp == GEPALDIIDPC.CNGFLNMNIMJ_filterMainEp &&
					ILEKEPJBFDP.IKEMMEAEPLM_filterDivaAndVal == GEPALDIIDPC.IKEMMEAEPLM_filterDivaAndVal &&
					ILEKEPJBFDP.JFOPNJOOGNI_filterSeriese == GEPALDIIDPC.JFOPNJOOGNI_filterSeriese)
					return true;
				return false;
			}

			//// RVA: 0x202C5AC Offset: 0x202C5AC VA: 0x202C5AC
			public static bool HMMFJOEBEKJ(BNIKLNDKMEO_EpisodeSelect ILEKEPJBFDP, BNIKLNDKMEO_EpisodeSelect GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
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
			public void ODDIHGPONFL(PFONKAHHKJK_Raid DNNHDJPNIAK)
			{
				DNNHDJPNIAK.LHPDCGNKPHD_sortItem = LHPDCGNKPHD_sortItem;
				DNNHDJPNIAK.AOKFAJOMCKK_bossFilter = AOKFAJOMCKK_bossFilter;
				DNNHDJPNIAK.MOAJJHLGILP_rankFilter = MOAJJHLGILP_rankFilter;
				DNNHDJPNIAK.COIKKDHMGID_joinFilter = COIKKDHMGID_joinFilter;
				DNNHDJPNIAK.EILKGEADKGH_order = EILKGEADKGH_order;
			}

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
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["sortItem"] = LHPDCGNKPHD_sortItem;
				res["bossFilter"] = AOKFAJOMCKK_bossFilter;
				res["rankFilter"] = MOAJJHLGILP_rankFilter;
				res["joinFilter"] = COIKKDHMGID_joinFilter;
				res["order"] = EILKGEADKGH_order;
				return res;
			}

			//// RVA: 0x2032150 Offset: 0x2032150 VA: 0x2032150
			public static bool CHDGLBBFEKH(PFONKAHHKJK_Raid ILEKEPJBFDP, PFONKAHHKJK_Raid GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.LHPDCGNKPHD_sortItem == GEPALDIIDPC.LHPDCGNKPHD_sortItem &&
					ILEKEPJBFDP.AOKFAJOMCKK_bossFilter == GEPALDIIDPC.AOKFAJOMCKK_bossFilter &&
					ILEKEPJBFDP.MOAJJHLGILP_rankFilter == GEPALDIIDPC.MOAJJHLGILP_rankFilter &&
					ILEKEPJBFDP.COIKKDHMGID_joinFilter == GEPALDIIDPC.COIKKDHMGID_joinFilter &&
					ILEKEPJBFDP.EILKGEADKGH_order == GEPALDIIDPC.EILKGEADKGH_order)
					return true;
				return false;
			}

			//// RVA: 0x202C5C0 Offset: 0x202C5C0 VA: 0x202C5C0
			public static bool HMMFJOEBEKJ(PFONKAHHKJK_Raid ILEKEPJBFDP, PFONKAHHKJK_Raid GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
		}
		public class LPNOICEBNEL_MusicSelect
		{
			private int FBGGEFFJJHB = 0x2511a53e; // 0x8
			public int EOCPIGDIFNB_FilterMusicAttr = 0; // 0xC
			public int JJNLEPEKNDO_FilterCombo = 0; // 0x10
			public int JGOJDHFAHHE_FilterScoreRank = 0; // 0x14
			public int PGMJCBIHNHK_FilterReward = 0; // 0x18
			public int DPDBMECAIIO_FilterUnit = 0; // 0x1C
			private int OOJKCGDIPIH_FilterMusicLevelMin_Crypted = 0x2511a53e; // 0x20
			private int CPBHIHNOIHB_FilterMusicLevelMax_Crypted = 0x2511a53e; // 0x24

			public int KHAJGNDEPMG_FilterMusicLevelMin { get { return OOJKCGDIPIH_FilterMusicLevelMin_Crypted ^ FBGGEFFJJHB; } set { OOJKCGDIPIH_FilterMusicLevelMin_Crypted = value ^ FBGGEFFJJHB; } } //0x2031E08 MLGBACGCCEA 0x2031E18 OHHKCBNKFHD
			public int IKFKKJLBBBN_FilterMusicLevelMax { get { return CPBHIHNOIHB_FilterMusicLevelMax_Crypted ^ FBGGEFFJJHB; } set { CPBHIHNOIHB_FilterMusicLevelMax_Crypted = value ^ FBGGEFFJJHB; } } //0x2031E28 FCGLOBJNLLH 0x2031E38 CPIMGEMMJJE

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
			public void ODDIHGPONFL(LPNOICEBNEL_MusicSelect DNNHDJPNIAK)
			{
				DNNHDJPNIAK.EOCPIGDIFNB_FilterMusicAttr = EOCPIGDIFNB_FilterMusicAttr;
				DNNHDJPNIAK.JJNLEPEKNDO_FilterCombo = JJNLEPEKNDO_FilterCombo;
				DNNHDJPNIAK.JGOJDHFAHHE_FilterScoreRank = JGOJDHFAHHE_FilterScoreRank;
				DNNHDJPNIAK.PGMJCBIHNHK_FilterReward = PGMJCBIHNHK_FilterReward;
				DNNHDJPNIAK.DPDBMECAIIO_FilterUnit = DPDBMECAIIO_FilterUnit;
				DNNHDJPNIAK.KHAJGNDEPMG_FilterMusicLevelMin = KHAJGNDEPMG_FilterMusicLevelMin;
				DNNHDJPNIAK.IKFKKJLBBBN_FilterMusicLevelMax = IKFKKJLBBBN_FilterMusicLevelMax;
			}

			// RVA: 0x2030AB4 Offset: 0x2030AB4 VA: 0x2030AB4
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				EOCPIGDIFNB_FilterMusicAttr = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicAttr", CIDINFCADGB);
				JJNLEPEKNDO_FilterCombo = JsonUtil.GetInt(OBHAFLMHAKG, "filterCombo", CIDINFCADGB);
				JGOJDHFAHHE_FilterScoreRank = JsonUtil.GetInt(OBHAFLMHAKG, "filterScoreRank", CIDINFCADGB);
				PGMJCBIHNHK_FilterReward = JsonUtil.GetInt(OBHAFLMHAKG, "filterReward", CIDINFCADGB);
				DPDBMECAIIO_FilterUnit = JsonUtil.GetInt(OBHAFLMHAKG, "filterUnit", CIDINFCADGB);
				KHAJGNDEPMG_FilterMusicLevelMin = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMin", CIDINFCADGB);
				IKFKKJLBBBN_FilterMusicLevelMax = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMax", CIDINFCADGB);
			}

			//// RVA: 0x202EA64 Offset: 0x202EA64 VA: 0x202EA64
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["filterMusicAttr"] = EOCPIGDIFNB_FilterMusicAttr;
				res["filterCombo"] = JJNLEPEKNDO_FilterCombo;
				res["filterScoreRank"] = JGOJDHFAHHE_FilterScoreRank;
				res["filterReward"] = PGMJCBIHNHK_FilterReward;
				res["filterUnit"] = DPDBMECAIIO_FilterUnit;
				res["filterMusicLevelMin"] = KHAJGNDEPMG_FilterMusicLevelMin;
				res["filterMusicLevelMax"] = IKFKKJLBBBN_FilterMusicLevelMax;
				return res;
			}

			//// RVA: 0x2031ED8 Offset: 0x2031ED8 VA: 0x2031ED8
			public static bool CHDGLBBFEKH(LPNOICEBNEL_MusicSelect ILEKEPJBFDP, LPNOICEBNEL_MusicSelect GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.EOCPIGDIFNB_FilterMusicAttr == GEPALDIIDPC.EOCPIGDIFNB_FilterMusicAttr &&
					ILEKEPJBFDP.JJNLEPEKNDO_FilterCombo == GEPALDIIDPC.JJNLEPEKNDO_FilterCombo &&
					ILEKEPJBFDP.JGOJDHFAHHE_FilterScoreRank == GEPALDIIDPC.JGOJDHFAHHE_FilterScoreRank &&
					ILEKEPJBFDP.PGMJCBIHNHK_FilterReward == GEPALDIIDPC.PGMJCBIHNHK_FilterReward &&
					ILEKEPJBFDP.DPDBMECAIIO_FilterUnit == GEPALDIIDPC.DPDBMECAIIO_FilterUnit &&
					ILEKEPJBFDP.KHAJGNDEPMG_FilterMusicLevelMin == GEPALDIIDPC.KHAJGNDEPMG_FilterMusicLevelMin &&
					ILEKEPJBFDP.IKFKKJLBBBN_FilterMusicLevelMax == GEPALDIIDPC.IKFKKJLBBBN_FilterMusicLevelMax)
					return true;
				return false;
			}

			//// RVA: 0x202C5E8 Offset: 0x202C5E8 VA: 0x202C5E8
			public static bool HMMFJOEBEKJ(LPNOICEBNEL_MusicSelect ILEKEPJBFDP, LPNOICEBNEL_MusicSelect GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
		}
		public class KLIBOIEIMBA_EventMission
		{
			private int FBGGEFFJJHB = 0x2151a53e; // 0x8
			public int EOCPIGDIFNB_FilterMusicAttr = 0; // 0xC
			public int JJNLEPEKNDO_FilterCombo = 0; // 0x10
			public int JGOJDHFAHHE_FilterScoreRank = 0; // 0x14
			public int PGMJCBIHNHK_FilterReward = 0; // 0x18
			public int DPDBMECAIIO_FilterUnit = 0; // 0x1C
			private int OOJKCGDIPIH_FilterMusicLevelMin = 0x2151a53e; // 0x20
			private int CPBHIHNOIHB_FilterMusicLevelMax = 0x2151a53e; // 0x24
			public int GMMPGHKIDEK_FilterBonus = 0; // 0x28

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
			public void ODDIHGPONFL(KLIBOIEIMBA_EventMission DNNHDJPNIAK)
			{
				DNNHDJPNIAK.EOCPIGDIFNB_FilterMusicAttr = EOCPIGDIFNB_FilterMusicAttr;
				DNNHDJPNIAK.JJNLEPEKNDO_FilterCombo = JJNLEPEKNDO_FilterCombo;
				DNNHDJPNIAK.JGOJDHFAHHE_FilterScoreRank = JGOJDHFAHHE_FilterScoreRank;
				DNNHDJPNIAK.PGMJCBIHNHK_FilterReward = PGMJCBIHNHK_FilterReward;
				DNNHDJPNIAK.DPDBMECAIIO_FilterUnit = DPDBMECAIIO_FilterUnit;
				DNNHDJPNIAK.OOJKCGDIPIH_FilterMusicLevelMin = OOJKCGDIPIH_FilterMusicLevelMin ^ FBGGEFFJJHB ^ DNNHDJPNIAK.FBGGEFFJJHB;
				DNNHDJPNIAK.CPBHIHNOIHB_FilterMusicLevelMax = CPBHIHNOIHB_FilterMusicLevelMax ^ FBGGEFFJJHB ^ DNNHDJPNIAK.FBGGEFFJJHB;
				DNNHDJPNIAK.GMMPGHKIDEK_FilterBonus = GMMPGHKIDEK_FilterBonus;
			}

			// RVA: 0x2030EEC Offset: 0x2030EEC VA: 0x2030EEC
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				EOCPIGDIFNB_FilterMusicAttr = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicAttr", CIDINFCADGB);
				JJNLEPEKNDO_FilterCombo = JsonUtil.GetInt(OBHAFLMHAKG, "filterCombo", CIDINFCADGB);
				JGOJDHFAHHE_FilterScoreRank = JsonUtil.GetInt(OBHAFLMHAKG, "filterScoreRank", CIDINFCADGB);
				PGMJCBIHNHK_FilterReward = JsonUtil.GetInt(OBHAFLMHAKG, "filterReward", CIDINFCADGB);
				DPDBMECAIIO_FilterUnit = JsonUtil.GetInt(OBHAFLMHAKG, "filterUnit", CIDINFCADGB);
				OOJKCGDIPIH_FilterMusicLevelMin = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMin", CIDINFCADGB) ^ FBGGEFFJJHB;
				CPBHIHNOIHB_FilterMusicLevelMax = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMax", CIDINFCADGB) ^ FBGGEFFJJHB;
				GMMPGHKIDEK_FilterBonus = JsonUtil.GetInt(OBHAFLMHAKG, "filterBonus", CIDINFCADGB);
			}

			//// RVA: 0x202F1C0 Offset: 0x202F1C0 VA: 0x202F1C0
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["filterMusicAttr"] = EOCPIGDIFNB_FilterMusicAttr;
				res["filterCombo"] = JJNLEPEKNDO_FilterCombo;
				res["filterScoreRank"] = JGOJDHFAHHE_FilterScoreRank;
				res["filterReward"] = PGMJCBIHNHK_FilterReward;
				res["filterUnit"] = DPDBMECAIIO_FilterUnit;
				res["filterMusicLevelMin"] = OOJKCGDIPIH_FilterMusicLevelMin ^ FBGGEFFJJHB;
				res["filterMusicLevelMax"] = CPBHIHNOIHB_FilterMusicLevelMax ^ FBGGEFFJJHB;
				res["filterBonus"] = GMMPGHKIDEK_FilterBonus;
				return res;
			}

			//// RVA: 0x2031D30 Offset: 0x2031D30 VA: 0x2031D30
			public static bool CHDGLBBFEKH(KLIBOIEIMBA_EventMission ILEKEPJBFDP, KLIBOIEIMBA_EventMission GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.EOCPIGDIFNB_FilterMusicAttr == GEPALDIIDPC.EOCPIGDIFNB_FilterMusicAttr &&
					ILEKEPJBFDP.JJNLEPEKNDO_FilterCombo == GEPALDIIDPC.JJNLEPEKNDO_FilterCombo &&
					ILEKEPJBFDP.JGOJDHFAHHE_FilterScoreRank == GEPALDIIDPC.JGOJDHFAHHE_FilterScoreRank &&
					ILEKEPJBFDP.PGMJCBIHNHK_FilterReward == GEPALDIIDPC.PGMJCBIHNHK_FilterReward &&
					ILEKEPJBFDP.DPDBMECAIIO_FilterUnit == GEPALDIIDPC.DPDBMECAIIO_FilterUnit &&
					(ILEKEPJBFDP.OOJKCGDIPIH_FilterMusicLevelMin ^ ILEKEPJBFDP.FBGGEFFJJHB) == (GEPALDIIDPC.OOJKCGDIPIH_FilterMusicLevelMin ^ GEPALDIIDPC.FBGGEFFJJHB) &&
					(ILEKEPJBFDP.CPBHIHNOIHB_FilterMusicLevelMax ^ ILEKEPJBFDP.FBGGEFFJJHB) == (GEPALDIIDPC.CPBHIHNOIHB_FilterMusicLevelMax ^ GEPALDIIDPC.FBGGEFFJJHB) &&
					ILEKEPJBFDP.GMMPGHKIDEK_FilterBonus == GEPALDIIDPC.GMMPGHKIDEK_FilterBonus)
					return true;
				return false;
			}

			//// RVA: 0x202C610 Offset: 0x202C610 VA: 0x202C610
			public static bool HMMFJOEBEKJ(KLIBOIEIMBA_EventMission ILEKEPJBFDP, KLIBOIEIMBA_EventMission GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
		}
		
		public class FPMABHADHBB_EventGoDiva
		{
			private int FBGGEFFJJHB = 0x1215a53e; // 0x8
			public int EOCPIGDIFNB_FilterMusicAttr = 0; // 0xC
			public int JJNLEPEKNDO_FilterCombo = 0; // 0x10
			public int JGOJDHFAHHE_FilterScoreRank = 0; // 0x14
			public int PGMJCBIHNHK_FilterReward = 0; // 0x18
			private int OOJKCGDIPIH_FilterMusicLevelMin_Crypted = 0x1215a53e; // 0x1C
			private int CPBHIHNOIHB_FilterMusicLevelMax_Crypted = 0x1215a53e; // 0x20
			public int MENIBLFBNLC_FilterMusicExp = 0; // 0x24

			public int KHAJGNDEPMG_FilterMusicLevelMin { get { return OOJKCGDIPIH_FilterMusicLevelMin_Crypted ^ FBGGEFFJJHB; } set { OOJKCGDIPIH_FilterMusicLevelMin_Crypted = value ^ FBGGEFFJJHB; } } //0x2031AC8 MLGBACGCCEA 0x2031AD8 OHHKCBNKFHD
			public int IKFKKJLBBBN_FilterMusicLevelMax { get { return CPBHIHNOIHB_FilterMusicLevelMax_Crypted ^ FBGGEFFJJHB; } set { CPBHIHNOIHB_FilterMusicLevelMax_Crypted = value ^ FBGGEFFJJHB; } } //0x2031AE8 FCGLOBJNLLH 0x2031AF8 CPIMGEMMJJE

			// RVA: 0x2031844 Offset: 0x2031844 VA: 0x2031844
			public FPMABHADHBB_EventGoDiva()
			{
				return;
			}

			//// RVA: 0x2031B2C Offset: 0x2031B2C VA: 0x2031B2C
			//public void .ctor(int EOCPIGDIFNB, int JJNLEPEKNDO, int JGOJDHFAHHE, int PGMJCBIHNHK, int DPDBMECAIIO, int KHAJGNDEPMG, int IKFKKJLBBBN, int MENIBLFBNLC) { }

			//// RVA: 0x2031B08 Offset: 0x2031B08 VA: 0x2031B08
			public void LHPDDGIJKNB()
			{
				KHAJGNDEPMG_FilterMusicLevelMin = 0;
				IKFKKJLBBBN_FilterMusicLevelMax = 0;
				MENIBLFBNLC_FilterMusicExp = 0;
				EOCPIGDIFNB_FilterMusicAttr = 0;
				JJNLEPEKNDO_FilterCombo = 0;
				JGOJDHFAHHE_FilterScoreRank = 0;
				PGMJCBIHNHK_FilterReward = 0;
			}

			//// RVA: 0x202D134 Offset: 0x202D134 VA: 0x202D134
			public void ODDIHGPONFL(FPMABHADHBB_EventGoDiva DNNHDJPNIAK)
			{
				DNNHDJPNIAK.EOCPIGDIFNB_FilterMusicAttr = EOCPIGDIFNB_FilterMusicAttr;
				DNNHDJPNIAK.JJNLEPEKNDO_FilterCombo = JJNLEPEKNDO_FilterCombo;
				DNNHDJPNIAK.JGOJDHFAHHE_FilterScoreRank = JGOJDHFAHHE_FilterScoreRank;
				DNNHDJPNIAK.PGMJCBIHNHK_FilterReward = PGMJCBIHNHK_FilterReward;
				DNNHDJPNIAK.KHAJGNDEPMG_FilterMusicLevelMin = KHAJGNDEPMG_FilterMusicLevelMin;
				DNNHDJPNIAK.IKFKKJLBBBN_FilterMusicLevelMax = IKFKKJLBBBN_FilterMusicLevelMax;
				DNNHDJPNIAK.MENIBLFBNLC_FilterMusicExp = MENIBLFBNLC_FilterMusicExp;
			}

			// RVA: 0x2030D8C Offset: 0x2030D8C VA: 0x2030D8C
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int CIDINFCADGB = 0)
			{
				EOCPIGDIFNB_FilterMusicAttr = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicAttr", CIDINFCADGB);
				JJNLEPEKNDO_FilterCombo = JsonUtil.GetInt(OBHAFLMHAKG, "filterCombo", CIDINFCADGB);
				JGOJDHFAHHE_FilterScoreRank = JsonUtil.GetInt(OBHAFLMHAKG, "filterScoreRank", CIDINFCADGB);
				PGMJCBIHNHK_FilterReward = JsonUtil.GetInt(OBHAFLMHAKG, "filterReward", CIDINFCADGB);
				KHAJGNDEPMG_FilterMusicLevelMin = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMin", CIDINFCADGB);
				IKFKKJLBBBN_FilterMusicLevelMax = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicLevelMax", CIDINFCADGB);
				MENIBLFBNLC_FilterMusicExp = JsonUtil.GetInt(OBHAFLMHAKG, "filterMusicExp", CIDINFCADGB);
			}

			//// RVA: 0x202EF5C Offset: 0x202EF5C VA: 0x202EF5C
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["filterMusicAttr"] = EOCPIGDIFNB_FilterMusicAttr;
				res["filterCombo"] = JJNLEPEKNDO_FilterCombo;
				res["filterScoreRank"] = JGOJDHFAHHE_FilterScoreRank;
				res["filterReward"] = PGMJCBIHNHK_FilterReward;
				res["filterMusicLevelMin"] = KHAJGNDEPMG_FilterMusicLevelMin;
				res["filterMusicLevelMax"] = IKFKKJLBBBN_FilterMusicLevelMax;
				res["filterMusicExp"] = MENIBLFBNLC_FilterMusicExp;
				return res;
			}

			//// RVA: 0x2031B90 Offset: 0x2031B90 VA: 0x2031B90
			public static bool CHDGLBBFEKH(FPMABHADHBB_EventGoDiva ILEKEPJBFDP, FPMABHADHBB_EventGoDiva GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.EOCPIGDIFNB_FilterMusicAttr == GEPALDIIDPC.EOCPIGDIFNB_FilterMusicAttr &&
					ILEKEPJBFDP.JJNLEPEKNDO_FilterCombo == GEPALDIIDPC.JJNLEPEKNDO_FilterCombo &&
					ILEKEPJBFDP.JGOJDHFAHHE_FilterScoreRank == GEPALDIIDPC.JGOJDHFAHHE_FilterScoreRank &&
					ILEKEPJBFDP.PGMJCBIHNHK_FilterReward == GEPALDIIDPC.PGMJCBIHNHK_FilterReward &&
					ILEKEPJBFDP.KHAJGNDEPMG_FilterMusicLevelMin == GEPALDIIDPC.KHAJGNDEPMG_FilterMusicLevelMin &&
					ILEKEPJBFDP.IKFKKJLBBBN_FilterMusicLevelMax == GEPALDIIDPC.IKFKKJLBBBN_FilterMusicLevelMax &&
					ILEKEPJBFDP.MENIBLFBNLC_FilterMusicExp == GEPALDIIDPC.MENIBLFBNLC_FilterMusicExp)
					return true;
				return false;
			}

			//// RVA: 0x202C5D4 Offset: 0x202C5D4 VA: 0x202C5D4
			public static bool HMMFJOEBEKJ(FPMABHADHBB_EventGoDiva ILEKEPJBFDP, FPMABHADHBB_EventGoDiva GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
		}
		
		public class MCINLGMJPDM_SelectHomeBG
		{
			public int EILKGEADKGH_Order = 1; // 0x8
			public int PLNMMHPILLO_FilterRarity; // 0xC
			public int HBEFGKLLMEC_FilterSeries; // 0x10

			// RVA: 0x203188C Offset: 0x203188C VA: 0x203188C
			public MCINLGMJPDM_SelectHomeBG()
			{
				return;
			}

			// RVA: 0x2031FA0 Offset: 0x2031FA0 VA: 0x2031FA0
			//public void .ctor(int EILKGEADKGH, int PLNMMHPILLO, int HBEFGKLLMEC) { }

			//// RVA: 0x202D340 Offset: 0x202D340 VA: 0x202D340
			public void ODDIHGPONFL(MCINLGMJPDM_SelectHomeBG PKBAJMCNIHP)
			{
				PKBAJMCNIHP.EILKGEADKGH_Order = EILKGEADKGH_Order;
				PKBAJMCNIHP.PLNMMHPILLO_FilterRarity = PLNMMHPILLO_FilterRarity;
				PKBAJMCNIHP.HBEFGKLLMEC_FilterSeries = HBEFGKLLMEC_FilterSeries;
			}

			// RVA: 0x2031070 Offset: 0x2031070 VA: 0x2031070
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				EILKGEADKGH_Order = JsonUtil.GetInt(OBHAFLMHAKG, "order");
				PLNMMHPILLO_FilterRarity = JsonUtil.GetInt(OBHAFLMHAKG, "fileterRarity", 0);
				HBEFGKLLMEC_FilterSeries = JsonUtil.GetInt(OBHAFLMHAKG, "fileterSeriese", 0);
			}

			//// RVA: 0x202F464 Offset: 0x202F464 VA: 0x202F464
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["order"] = EILKGEADKGH_Order;
				res["fileterRarity"] = PLNMMHPILLO_FilterRarity;
				res["fileterSeriese"] = HBEFGKLLMEC_FilterSeries;
				return res;
			}

			//// RVA: 0x2031FDC Offset: 0x2031FDC VA: 0x2031FDC
			public static bool CHDGLBBFEKH(MCINLGMJPDM_SelectHomeBG ILEKEPJBFDP, MCINLGMJPDM_SelectHomeBG GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.EILKGEADKGH_Order == GEPALDIIDPC.EILKGEADKGH_Order &&
					ILEKEPJBFDP.PLNMMHPILLO_FilterRarity == GEPALDIIDPC.PLNMMHPILLO_FilterRarity &&
					ILEKEPJBFDP.HBEFGKLLMEC_FilterSeries == GEPALDIIDPC.HBEFGKLLMEC_FilterSeries)
					return true;
				return false;
			}

			//// RVA: 0x202C624 Offset: 0x202C624 VA: 0x202C624
			public static bool HMMFJOEBEKJ(MCINLGMJPDM_SelectHomeBG ILEKEPJBFDP, MCINLGMJPDM_SelectHomeBG GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}
		}
		public class POCEANNLGLP_ShopProduct
		{
			public int LHPDCGNKPHD_SortItem = 5; // 0x8
			public int MLMHPBOKJCL_SortOrder = 1; // 0xC
			public int EGBPCFOGOCK_HaveFilter; // 0x10
			public int ACCHOFLOOEC_RarityFilter; // 0x14
			public int BOFFOHHLLFG_AttrFilter; // 0x18
			public int BBIIHLNBHDE_SerieFilter; // 0x1C
			public int ABLBLOEKBKA_CompatibleFilter; // 0x20
			public int OAJNACDACDF_LiveSkillRangeFilter; // 0x24
			public int PFNPLBNHDJK_CenterSkillRankFilter; // 0x28
			public int DNLJMMBEKAA_ActiveSkillRankFilter; // 0x2C
			public int EAPCPNGAPBB_LiveSkillRankFilter; // 0x30
			public int NLLEDCOAPIG_NoteExpectedFilter; // 0x34
			public long LKPCKPJGJKN_CenterSkillFilter; // 0x38
			public long LACACEBKHCM_ActiveSkillFilter; // 0x40
			public long PPEFJBBGGHI_LiveSkillFilter; // 0x48

			//// RVA: 0x20321E0 Offset: 0x20321E0 VA: 0x20321E0
			public static bool CHDGLBBFEKH(POCEANNLGLP_ShopProduct ILEKEPJBFDP, POCEANNLGLP_ShopProduct GEPALDIIDPC)
			{
				if (ILEKEPJBFDP.LHPDCGNKPHD_SortItem == GEPALDIIDPC.LHPDCGNKPHD_SortItem &&
					ILEKEPJBFDP.MLMHPBOKJCL_SortOrder == GEPALDIIDPC.MLMHPBOKJCL_SortOrder &&
					ILEKEPJBFDP.EGBPCFOGOCK_HaveFilter == GEPALDIIDPC.EGBPCFOGOCK_HaveFilter &&
					ILEKEPJBFDP.ACCHOFLOOEC_RarityFilter == GEPALDIIDPC.ACCHOFLOOEC_RarityFilter &&
					ILEKEPJBFDP.BOFFOHHLLFG_AttrFilter == GEPALDIIDPC.BOFFOHHLLFG_AttrFilter &&
					ILEKEPJBFDP.BBIIHLNBHDE_SerieFilter == GEPALDIIDPC.BBIIHLNBHDE_SerieFilter &&
					ILEKEPJBFDP.ABLBLOEKBKA_CompatibleFilter == GEPALDIIDPC.ABLBLOEKBKA_CompatibleFilter &&
					ILEKEPJBFDP.OAJNACDACDF_LiveSkillRangeFilter == GEPALDIIDPC.OAJNACDACDF_LiveSkillRangeFilter &&
					ILEKEPJBFDP.PFNPLBNHDJK_CenterSkillRankFilter == GEPALDIIDPC.PFNPLBNHDJK_CenterSkillRankFilter &&
					ILEKEPJBFDP.DNLJMMBEKAA_ActiveSkillRankFilter == GEPALDIIDPC.DNLJMMBEKAA_ActiveSkillRankFilter &&
					ILEKEPJBFDP.EAPCPNGAPBB_LiveSkillRankFilter == GEPALDIIDPC.EAPCPNGAPBB_LiveSkillRankFilter &&
					ILEKEPJBFDP.NLLEDCOAPIG_NoteExpectedFilter == GEPALDIIDPC.NLLEDCOAPIG_NoteExpectedFilter &&
					ILEKEPJBFDP.LKPCKPJGJKN_CenterSkillFilter == GEPALDIIDPC.LKPCKPJGJKN_CenterSkillFilter &&
					ILEKEPJBFDP.LACACEBKHCM_ActiveSkillFilter == GEPALDIIDPC.LACACEBKHCM_ActiveSkillFilter &&
					ILEKEPJBFDP.PPEFJBBGGHI_LiveSkillFilter == GEPALDIIDPC.PPEFJBBGGHI_LiveSkillFilter)
					return true;
				return false;
			}

			//// RVA: 0x202C638 Offset: 0x202C638 VA: 0x202C638
			public static bool HMMFJOEBEKJ(POCEANNLGLP_ShopProduct ILEKEPJBFDP, POCEANNLGLP_ShopProduct GEPALDIIDPC)
			{
				return !CHDGLBBFEKH(ILEKEPJBFDP, GEPALDIIDPC);
			}

			//// RVA: 0x202D3A8 Offset: 0x202D3A8 VA: 0x202D3A8
			public void ODDIHGPONFL(POCEANNLGLP_ShopProduct FMKAONAMGCN)
			{
				FMKAONAMGCN.LHPDCGNKPHD_SortItem = LHPDCGNKPHD_SortItem;
				FMKAONAMGCN.MLMHPBOKJCL_SortOrder = MLMHPBOKJCL_SortOrder;
				FMKAONAMGCN.EGBPCFOGOCK_HaveFilter = EGBPCFOGOCK_HaveFilter;
				FMKAONAMGCN.ACCHOFLOOEC_RarityFilter = ACCHOFLOOEC_RarityFilter;
				FMKAONAMGCN.BOFFOHHLLFG_AttrFilter = BOFFOHHLLFG_AttrFilter;
				FMKAONAMGCN.BBIIHLNBHDE_SerieFilter = BBIIHLNBHDE_SerieFilter;
				FMKAONAMGCN.ABLBLOEKBKA_CompatibleFilter = ABLBLOEKBKA_CompatibleFilter;
				FMKAONAMGCN.OAJNACDACDF_LiveSkillRangeFilter = OAJNACDACDF_LiveSkillRangeFilter;
				FMKAONAMGCN.PFNPLBNHDJK_CenterSkillRankFilter = PFNPLBNHDJK_CenterSkillRankFilter;
				FMKAONAMGCN.DNLJMMBEKAA_ActiveSkillRankFilter = DNLJMMBEKAA_ActiveSkillRankFilter;
				FMKAONAMGCN.EAPCPNGAPBB_LiveSkillRankFilter = EAPCPNGAPBB_LiveSkillRankFilter;
				FMKAONAMGCN.NLLEDCOAPIG_NoteExpectedFilter = NLLEDCOAPIG_NoteExpectedFilter;
				FMKAONAMGCN.LKPCKPJGJKN_CenterSkillFilter = LKPCKPJGJKN_CenterSkillFilter;
				FMKAONAMGCN.LACACEBKHCM_ActiveSkillFilter = LACACEBKHCM_ActiveSkillFilter;
				FMKAONAMGCN.PPEFJBBGGHI_LiveSkillFilter = PPEFJBBGGHI_LiveSkillFilter;
			}

			//// RVA: 0x202F5B8 Offset: 0x202F5B8 VA: 0x202F5B8
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["sortItem"] = LHPDCGNKPHD_SortItem;
				res["sortOrder"] = MLMHPBOKJCL_SortOrder;
				res["haveFilter"] = EGBPCFOGOCK_HaveFilter;
				res["rarityFilter"] = ACCHOFLOOEC_RarityFilter;
				res["attributeFilter"] = BOFFOHHLLFG_AttrFilter;
				res["seriaseFilter"] = BBIIHLNBHDE_SerieFilter;
				res["compatibleFilter"] = ABLBLOEKBKA_CompatibleFilter;
				res["liveSkillRangeFilter"] = OAJNACDACDF_LiveSkillRangeFilter;
				res["centerSkillRankFilter"] = PFNPLBNHDJK_CenterSkillRankFilter;
				res["activeSkillRankFilter"] = DNLJMMBEKAA_ActiveSkillRankFilter;
				res["liveSkillRankFilter"] = EAPCPNGAPBB_LiveSkillRankFilter;
				res["notesExpectedFilter"] = NLLEDCOAPIG_NoteExpectedFilter;
				res["centerSkillFilter"] = LKPCKPJGJKN_CenterSkillFilter;
				res["activeSkillFilter"] = LACACEBKHCM_ActiveSkillFilter;
				res["liveSkillFilter"] = PPEFJBBGGHI_LiveSkillFilter;
				return res;
			}

			// RVA: 0x2031128 Offset: 0x2031128 VA: 0x2031128
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				LHPDCGNKPHD_SortItem = JsonUtil.GetInt(OBHAFLMHAKG, "sortItem", 5);
				MLMHPBOKJCL_SortOrder = JsonUtil.GetInt(OBHAFLMHAKG, "sortOrder", 1);
				EGBPCFOGOCK_HaveFilter = JsonUtil.GetInt(OBHAFLMHAKG, "haveFilter", 0);
				ACCHOFLOOEC_RarityFilter = JsonUtil.GetInt(OBHAFLMHAKG, "rarityFilter", 0);
				BOFFOHHLLFG_AttrFilter = JsonUtil.GetInt(OBHAFLMHAKG, "attributeFilter", 0);
				BBIIHLNBHDE_SerieFilter = JsonUtil.GetInt(OBHAFLMHAKG, "seriaseFilter", 0);
				ABLBLOEKBKA_CompatibleFilter = JsonUtil.GetInt(OBHAFLMHAKG, "compatibleFilter", 0);
				OAJNACDACDF_LiveSkillRangeFilter = JsonUtil.GetInt(OBHAFLMHAKG, "liveSkillRangeFilter", 0);
				PFNPLBNHDJK_CenterSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "centerSkillRankFilter", 0);
				DNLJMMBEKAA_ActiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "activeSkillRankFilter", 0);
				EAPCPNGAPBB_LiveSkillRankFilter = JsonUtil.GetInt(OBHAFLMHAKG, "liveSkillRankFilter", 0);
				NLLEDCOAPIG_NoteExpectedFilter = JsonUtil.GetInt(OBHAFLMHAKG, "notesExpectedFilter", 0);
				LKPCKPJGJKN_CenterSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "centerSkillFilter", 0);
				LACACEBKHCM_ActiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "activeSkillFilter", 0);
				PPEFJBBGGHI_LiveSkillFilter = JsonUtil.GetLong(OBHAFLMHAKG, "liveSkillFilter", 0);
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
		public MMALELPFEBH_UserList ACCNCHJBDHM_UserList = new MMALELPFEBH_UserList(); // 0xDC
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
		public static bool CHDGLBBFEKH_IsEqual(IJDOCJCLAIL_SortProprty ILEKEPJBFDP, IJDOCJCLAIL_SortProprty GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.LNFFKCDNCPN_sceneSelectSortItem == GEPALDIIDPC.LNFFKCDNCPN_sceneSelectSortItem &&
				ILEKEPJBFDP.GEAECNMDMHH_sceneListSortItem == GEPALDIIDPC.GEAECNMDMHH_sceneListSortItem &&
				ILEKEPJBFDP.NCDOLBOHGFN_sceneAssistSortItem == GEPALDIIDPC.NCDOLBOHGFN_sceneAssistSortItem &&
				ILEKEPJBFDP.ONPAMDMIEKM_divaSortItem == GEPALDIIDPC.ONPAMDMIEKM_divaSortItem &&
				ILEKEPJBFDP.CIDJJBFGHIE_sceneSelectSortOrder == GEPALDIIDPC.CIDJJBFGHIE_sceneSelectSortOrder &&
				ILEKEPJBFDP.CLKCCJJJPLB_sceneListSortOrder == GEPALDIIDPC.CLKCCJJJPLB_sceneListSortOrder &&
				ILEKEPJBFDP.OGFJPNKICGI_sceneAssistSortOrder == GEPALDIIDPC.OGFJPNKICGI_sceneAssistSortOrder &&
				ILEKEPJBFDP.HNGHNBNPCHO_divaSortOrder == GEPALDIIDPC.HNGHNBNPCHO_divaSortOrder &&
				ILEKEPJBFDP.MDJMAEEONKK_costumeSortItem == GEPALDIIDPC.MDJMAEEONKK_costumeSortItem &&
				ILEKEPJBFDP.LEAPMNHODPJ_unitWindowDispItem == GEPALDIIDPC.LEAPMNHODPJ_unitWindowDispItem &&
				ILEKEPJBFDP.BICLOMKLAOF_unitWindowDivaDispItem == GEPALDIIDPC.BICLOMKLAOF_unitWindowDivaDispItem &&
				ILEKEPJBFDP.FFAKMECDMFC_sceneSelectRarityFilter == GEPALDIIDPC.FFAKMECDMFC_sceneSelectRarityFilter &&
				ILEKEPJBFDP.LMPKAPBCIFD_sceneSelectAttributeFilter == GEPALDIIDPC.LMPKAPBCIFD_sceneSelectAttributeFilter &&
				ILEKEPJBFDP.MNNCLIFBAOA_sceneSelectSeriaseFilter == GEPALDIIDPC.MNNCLIFBAOA_sceneSelectSeriaseFilter &&
				ILEKEPJBFDP.NPFGKBKKCFL_sceneSelectCompatibleFilter == GEPALDIIDPC.NPFGKBKKCFL_sceneSelectCompatibleFilter &&
				ILEKEPJBFDP.JACFDEKLDCK_isCompatibleDivaCheck == GEPALDIIDPC.JACFDEKLDCK_isCompatibleDivaCheck &&
				ILEKEPJBFDP.HMJNAGNIEJB_sceneListRarityFilter == GEPALDIIDPC.HMJNAGNIEJB_sceneListRarityFilter &&
				ILEKEPJBFDP.HFGAILIOFAN_sceneListAttributeFilter == GEPALDIIDPC.HFGAILIOFAN_sceneListAttributeFilter &&
				ILEKEPJBFDP.AKFPHKLCHAA_sceneListSeriaseFilter == GEPALDIIDPC.AKFPHKLCHAA_sceneListSeriaseFilter &&
				ILEKEPJBFDP.PHCEMKLNJLH_sceneListCompatibleFilter == GEPALDIIDPC.PHCEMKLNJLH_sceneListCompatibleFilter &&
				ILEKEPJBFDP.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter == GEPALDIIDPC.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter &&
				ILEKEPJBFDP.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter == GEPALDIIDPC.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter &&
				ILEKEPJBFDP.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter == GEPALDIIDPC.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter &&
				ILEKEPJBFDP.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter == GEPALDIIDPC.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter &&
				ILEKEPJBFDP.IHECEFMGKHO_sceneSelectCenterSkillFilter == GEPALDIIDPC.IHECEFMGKHO_sceneSelectCenterSkillFilter &&
				ILEKEPJBFDP.POJHGOJDOND_sceneSelectActiveSkillFilter == GEPALDIIDPC.POJHGOJDOND_sceneSelectActiveSkillFilter &&
				ILEKEPJBFDP.OCKOEPFNGJG_sceneSelectLiveSkillFilter == GEPALDIIDPC.OCKOEPFNGJG_sceneSelectLiveSkillFilter &&
				ILEKEPJBFDP.LALFKJDFPOD_sceneListLiveSkillRangeFilter == GEPALDIIDPC.LALFKJDFPOD_sceneListLiveSkillRangeFilter &&
				ILEKEPJBFDP.MECEGIJIGBN_sceneListCenterSkillRankFilter == GEPALDIIDPC.MECEGIJIGBN_sceneListCenterSkillRankFilter &&
				ILEKEPJBFDP.ALFGELGDIGC_sceneListActiveSkillRankFilter == GEPALDIIDPC.ALFGELGDIGC_sceneListActiveSkillRankFilter &&
				ILEKEPJBFDP.HKFPBAFALHO_sceneListLiveSkillRankFilter == GEPALDIIDPC.HKFPBAFALHO_sceneListLiveSkillRankFilter &&
				ILEKEPJBFDP.IOBABMJPAAE_sceneListCenterSkillFilter == GEPALDIIDPC.IOBABMJPAAE_sceneListCenterSkillFilter &&
				ILEKEPJBFDP.GIPNFAFFNLF_sceneListActiveSkillFilter == GEPALDIIDPC.GIPNFAFFNLF_sceneListActiveSkillFilter &&
				ILEKEPJBFDP.BOMCDAIEFLN_sceneListLiveSkillFilter == GEPALDIIDPC.BOMCDAIEFLN_sceneListLiveSkillFilter &&
				ILEKEPJBFDP.DMKHBHDGABG_sceneSelectNotesExpectedFilter == GEPALDIIDPC.DMKHBHDGABG_sceneSelectNotesExpectedFilter &&
				ILEKEPJBFDP.MCJBFHMJECO_sceneListNotesExpectedFilter == GEPALDIIDPC.MCJBFHMJECO_sceneListNotesExpectedFilter &&
				ILEKEPJBFDP.OFFBGLDDBHC_sceneAssistAttributeFilter == GEPALDIIDPC.OFFBGLDDBHC_sceneAssistAttributeFilter &&
				ILEKEPJBFDP.POPIEDDJGBA_sceneAssistSeriaseFilter == GEPALDIIDPC.POPIEDDJGBA_sceneAssistSeriaseFilter &&
				ILEKEPJBFDP.GJFPKDOBIPH_sceneAssistCenterSkillFilter == GEPALDIIDPC.GJFPKDOBIPH_sceneAssistCenterSkillFilter &&
				ILEKEPJBFDP.MOOHKFCHJPO_shopListSeriaseFilter == GEPALDIIDPC.MOOHKFCHJPO_shopListSeriaseFilter &&
				ILEKEPJBFDP.PJDCJKHMNNM_interiorListFilter == GEPALDIIDPC.PJDCJKHMNNM_interiorListFilter &&
				MMALELPFEBH_UserList.CHDGLBBFEKH(ILEKEPJBFDP.IDFGCPNELIA_FriendList, GEPALDIIDPC.IDFGCPNELIA_FriendList) &&
				MMALELPFEBH_UserList.CHDGLBBFEKH(ILEKEPJBFDP.GDMIGCCMEEF_GuestSelect, GEPALDIIDPC.GDMIGCCMEEF_GuestSelect) &&
				MMALELPFEBH_UserList.CHDGLBBFEKH(ILEKEPJBFDP.EJAJGGKHALM_SentRequestList, GEPALDIIDPC.EJAJGGKHALM_SentRequestList) &&
				MMALELPFEBH_UserList.CHDGLBBFEKH(ILEKEPJBFDP.DOKBEPGKNJK_PendingList, GEPALDIIDPC.DOKBEPGKNJK_PendingList) &&
				BNIKLNDKMEO_EpisodeSelect.CHDGLBBFEKH(ILEKEPJBFDP.CEJNPBFIIMJ_EpisodeSelect, GEPALDIIDPC.CEJNPBFIIMJ_EpisodeSelect) &&
				PFONKAHHKJK_Raid.CHDGLBBFEKH(ILEKEPJBFDP.JGAFBCMOGLP_Raid, GEPALDIIDPC.JGAFBCMOGLP_Raid) &&
				FPMABHADHBB_EventGoDiva.CHDGLBBFEKH(ILEKEPJBFDP.IMEBBACHPAN_EventGoDiva, GEPALDIIDPC.IMEBBACHPAN_EventGoDiva) &&
				LPNOICEBNEL_MusicSelect.CHDGLBBFEKH(ILEKEPJBFDP.KGDILGLNKFM_MusicSelect, GEPALDIIDPC.KGDILGLNKFM_MusicSelect) &&
				CLBMCCEEDGE_VerticalMusicSelect.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.JHCKHAMFHMG_VerticalMusicSelect, GEPALDIIDPC.JHCKHAMFHMG_VerticalMusicSelect) &&
				KLIBOIEIMBA_EventMission.CHDGLBBFEKH(ILEKEPJBFDP.BPFEOJEAEGK_EventMission, GEPALDIIDPC.BPFEOJEAEGK_EventMission) &&
				MCINLGMJPDM_SelectHomeBG.CHDGLBBFEKH(ILEKEPJBFDP.GIDCHFBCBML_SelectHomeBG, GEPALDIIDPC.GIDCHFBCBML_SelectHomeBG) &&
				POCEANNLGLP_ShopProduct.CHDGLBBFEKH(ILEKEPJBFDP.CCJMAIPBELA_ShopProduct1_4, GEPALDIIDPC.CCJMAIPBELA_ShopProduct1_4) &&
				POCEANNLGLP_ShopProduct.CHDGLBBFEKH(ILEKEPJBFDP.HDKDFCCJEEP_ShopProduct5_6, GEPALDIIDPC.HDKDFCCJEEP_ShopProduct5_6))
				return true;
			return false;
		}

		//// RVA: 0x202C64C Offset: 0x202C64C VA: 0x202C64C
		//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.IJDOCJCLAIL ILEKEPJBFDP, ILDKBCLAFPB.IJDOCJCLAIL GEPALDIIDPC) { }

		//// RVA: 0x202C660 Offset: 0x202C660 VA: 0x202C660
		public void ODDIHGPONFL_Copy(IJDOCJCLAIL_SortProprty FMKAONAMGCN)
		{
			FMKAONAMGCN.LNFFKCDNCPN_sceneSelectSortItem = LNFFKCDNCPN_sceneSelectSortItem;
			FMKAONAMGCN.GEAECNMDMHH_sceneListSortItem = GEAECNMDMHH_sceneListSortItem;
			FMKAONAMGCN.NCDOLBOHGFN_sceneAssistSortItem = NCDOLBOHGFN_sceneAssistSortItem;
			FMKAONAMGCN.ONPAMDMIEKM_divaSortItem = ONPAMDMIEKM_divaSortItem;
			FMKAONAMGCN.CIDJJBFGHIE_sceneSelectSortOrder = CIDJJBFGHIE_sceneSelectSortOrder;
			FMKAONAMGCN.CLKCCJJJPLB_sceneListSortOrder = CLKCCJJJPLB_sceneListSortOrder;
			FMKAONAMGCN.OGFJPNKICGI_sceneAssistSortOrder = OGFJPNKICGI_sceneAssistSortOrder;
			FMKAONAMGCN.HNGHNBNPCHO_divaSortOrder = HNGHNBNPCHO_divaSortOrder;
			FMKAONAMGCN.MDJMAEEONKK_costumeSortItem = MDJMAEEONKK_costumeSortItem;
			FMKAONAMGCN.LEAPMNHODPJ_unitWindowDispItem = LEAPMNHODPJ_unitWindowDispItem;
			FMKAONAMGCN.BICLOMKLAOF_unitWindowDivaDispItem = BICLOMKLAOF_unitWindowDivaDispItem;
			FMKAONAMGCN.FFAKMECDMFC_sceneSelectRarityFilter = FFAKMECDMFC_sceneSelectRarityFilter;
			FMKAONAMGCN.LMPKAPBCIFD_sceneSelectAttributeFilter = LMPKAPBCIFD_sceneSelectAttributeFilter;
			FMKAONAMGCN.MNNCLIFBAOA_sceneSelectSeriaseFilter = MNNCLIFBAOA_sceneSelectSeriaseFilter;
			FMKAONAMGCN.NPFGKBKKCFL_sceneSelectCompatibleFilter = NPFGKBKKCFL_sceneSelectCompatibleFilter;
			FMKAONAMGCN.JACFDEKLDCK_isCompatibleDivaCheck = JACFDEKLDCK_isCompatibleDivaCheck;
			FMKAONAMGCN.HMJNAGNIEJB_sceneListRarityFilter = HMJNAGNIEJB_sceneListRarityFilter;
			FMKAONAMGCN.HFGAILIOFAN_sceneListAttributeFilter = HFGAILIOFAN_sceneListAttributeFilter;
			FMKAONAMGCN.AKFPHKLCHAA_sceneListSeriaseFilter = AKFPHKLCHAA_sceneListSeriaseFilter;
			FMKAONAMGCN.PHCEMKLNJLH_sceneListCompatibleFilter = PHCEMKLNJLH_sceneListCompatibleFilter;
			FMKAONAMGCN.OFFBGLDDBHC_sceneAssistAttributeFilter = OFFBGLDDBHC_sceneAssistAttributeFilter;
			FMKAONAMGCN.POPIEDDJGBA_sceneAssistSeriaseFilter = POPIEDDJGBA_sceneAssistSeriaseFilter;
			FMKAONAMGCN.GJFPKDOBIPH_sceneAssistCenterSkillFilter = GJFPKDOBIPH_sceneAssistCenterSkillFilter;
			FMKAONAMGCN.MOOHKFCHJPO_shopListSeriaseFilter = MOOHKFCHJPO_shopListSeriaseFilter;
			FMKAONAMGCN.PJDCJKHMNNM_interiorListFilter = PJDCJKHMNNM_interiorListFilter;
			FMKAONAMGCN.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter = IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter;
			FMKAONAMGCN.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter = BPFPFOJNFLC_sceneSelectCenterSkillRankFilter;
			FMKAONAMGCN.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter = BIBBAIFCGLD_sceneSelectActiveSkillRankFilter;
			FMKAONAMGCN.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter = AIPJDIPBDEA_sceneSelectLiveSkillRankFilter;
			FMKAONAMGCN.IHECEFMGKHO_sceneSelectCenterSkillFilter = IHECEFMGKHO_sceneSelectCenterSkillFilter;
			FMKAONAMGCN.POJHGOJDOND_sceneSelectActiveSkillFilter = POJHGOJDOND_sceneSelectActiveSkillFilter;
			FMKAONAMGCN.OCKOEPFNGJG_sceneSelectLiveSkillFilter = OCKOEPFNGJG_sceneSelectLiveSkillFilter;
			FMKAONAMGCN.LALFKJDFPOD_sceneListLiveSkillRangeFilter = LALFKJDFPOD_sceneListLiveSkillRangeFilter;
			FMKAONAMGCN.MECEGIJIGBN_sceneListCenterSkillRankFilter = MECEGIJIGBN_sceneListCenterSkillRankFilter;
			FMKAONAMGCN.ALFGELGDIGC_sceneListActiveSkillRankFilter = ALFGELGDIGC_sceneListActiveSkillRankFilter;
			FMKAONAMGCN.HKFPBAFALHO_sceneListLiveSkillRankFilter = HKFPBAFALHO_sceneListLiveSkillRankFilter;
			FMKAONAMGCN.IOBABMJPAAE_sceneListCenterSkillFilter = IOBABMJPAAE_sceneListCenterSkillFilter;
			FMKAONAMGCN.GIPNFAFFNLF_sceneListActiveSkillFilter = GIPNFAFFNLF_sceneListActiveSkillFilter;
			FMKAONAMGCN.BOMCDAIEFLN_sceneListLiveSkillFilter = BOMCDAIEFLN_sceneListLiveSkillFilter;
			FMKAONAMGCN.DMKHBHDGABG_sceneSelectNotesExpectedFilter = DMKHBHDGABG_sceneSelectNotesExpectedFilter;
			FMKAONAMGCN.MCJBFHMJECO_sceneListNotesExpectedFilter = MCJBFHMJECO_sceneListNotesExpectedFilter;
			IDFGCPNELIA_FriendList.ODDIHGPONFL(FMKAONAMGCN.IDFGCPNELIA_FriendList);
			GDMIGCCMEEF_GuestSelect.ODDIHGPONFL(FMKAONAMGCN.GDMIGCCMEEF_GuestSelect);
			EJAJGGKHALM_SentRequestList.ODDIHGPONFL(FMKAONAMGCN.EJAJGGKHALM_SentRequestList);
			DOKBEPGKNJK_PendingList.ODDIHGPONFL(FMKAONAMGCN.DOKBEPGKNJK_PendingList);
			CEJNPBFIIMJ_EpisodeSelect.ODDIHGPONFL(FMKAONAMGCN.CEJNPBFIIMJ_EpisodeSelect);
			JGAFBCMOGLP_Raid.ODDIHGPONFL(FMKAONAMGCN.JGAFBCMOGLP_Raid);
			KGDILGLNKFM_MusicSelect.ODDIHGPONFL(FMKAONAMGCN.KGDILGLNKFM_MusicSelect);
			JHCKHAMFHMG_VerticalMusicSelect.ODDIHGPONFL(FMKAONAMGCN.JHCKHAMFHMG_VerticalMusicSelect);
			IMEBBACHPAN_EventGoDiva.ODDIHGPONFL(FMKAONAMGCN.IMEBBACHPAN_EventGoDiva);
			BPFEOJEAEGK_EventMission.ODDIHGPONFL(FMKAONAMGCN.BPFEOJEAEGK_EventMission);
			GIDCHFBCBML_SelectHomeBG.ODDIHGPONFL(FMKAONAMGCN.GIDCHFBCBML_SelectHomeBG);
			CCJMAIPBELA_ShopProduct1_4.ODDIHGPONFL(FMKAONAMGCN.CCJMAIPBELA_ShopProduct1_4);
			HDKDFCCJEEP_ShopProduct5_6.ODDIHGPONFL(FMKAONAMGCN.HDKDFCCJEEP_ShopProduct5_6);
		}

		//// RVA: 0x202D584 Offset: 0x202D584 VA: 0x202D584
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["sceneSelectSortItem"] = LNFFKCDNCPN_sceneSelectSortItem;
			res["sceneListSortItem"] = GEAECNMDMHH_sceneListSortItem;
			res["sceneAssistSortItem"] = NCDOLBOHGFN_sceneAssistSortItem;
			res["divaSortItem"] = ONPAMDMIEKM_divaSortItem;
			res["sceneSelectSortOrder"] = CIDJJBFGHIE_sceneSelectSortOrder;
			res["sceneListSortOrder"] = CLKCCJJJPLB_sceneListSortOrder;
			res["sceneAssistSortOrder"] = OGFJPNKICGI_sceneAssistSortOrder;
			res["divaSortOrder"] = HNGHNBNPCHO_divaSortOrder;
			res["costumeSortItem"] = MDJMAEEONKK_costumeSortItem;
			res["unitWindowDispItem"] = LEAPMNHODPJ_unitWindowDispItem;
			res["unitWindowDivaDispItem"] = BICLOMKLAOF_unitWindowDivaDispItem;
			res["sceneSelectRarityFilter"] = FFAKMECDMFC_sceneSelectRarityFilter;
			res["sceneSelectAttributeFilter"] = LMPKAPBCIFD_sceneSelectAttributeFilter;
			res["sceneSelectSeriaseFilter"] = MNNCLIFBAOA_sceneSelectSeriaseFilter;
			res["sceneSelectCompatibleFilter"] = NPFGKBKKCFL_sceneSelectCompatibleFilter;
			res["isCompatibleDivaCheck"] = JACFDEKLDCK_isCompatibleDivaCheck;
			res["sceneListRarityFilter"] = HMJNAGNIEJB_sceneListRarityFilter;
			res["sceneListAttributeFilter"] = HFGAILIOFAN_sceneListAttributeFilter;
			res["sceneListSeriaseFilter"] = AKFPHKLCHAA_sceneListSeriaseFilter;
			res["sceneListCompatibleFilter"] = PHCEMKLNJLH_sceneListCompatibleFilter;
			res["sceneAssistAttributeFilter"] = OFFBGLDDBHC_sceneAssistAttributeFilter;
			res["sceneAssistSeriaseFilter"] = POPIEDDJGBA_sceneAssistSeriaseFilter;
			res["sceneAssistCenterSkillFilter"] = GJFPKDOBIPH_sceneAssistCenterSkillFilter;
			res["shopListSeriaseFilter"] = MOOHKFCHJPO_shopListSeriaseFilter;
			res["interiorListFilter"] = PJDCJKHMNNM_interiorListFilter;
			res["sceneSelectLiveSkillRangeFilter"] = IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter;
			res["sceneSelectCenterSkillRankFilter"] = BPFPFOJNFLC_sceneSelectCenterSkillRankFilter;
			res["sceneSelectActiveSkillRankFilter"] = BIBBAIFCGLD_sceneSelectActiveSkillRankFilter;
			res["sceneSelectLiveSkillRankFilter"] = AIPJDIPBDEA_sceneSelectLiveSkillRankFilter;
			res["sceneSelectCenterSkillFilter"] = IHECEFMGKHO_sceneSelectCenterSkillFilter;
			res["sceneSelectActiveSkillFilter"] = POJHGOJDOND_sceneSelectActiveSkillFilter;
			res["sceneSelectLiveSkillFilter"] = OCKOEPFNGJG_sceneSelectLiveSkillFilter;
			res["sceneListLiveSkillRangeFilter"] = LALFKJDFPOD_sceneListLiveSkillRangeFilter;
			res["sceneListCenterSkillRankFilter"] = MECEGIJIGBN_sceneListCenterSkillRankFilter;
			res["sceneListActiveSkillRankFilter"] = ALFGELGDIGC_sceneListActiveSkillRankFilter;
			res["sceneListLiveSkillRankFilter"] = HKFPBAFALHO_sceneListLiveSkillRankFilter;
			res["sceneListCenterSkillFilter"] = IOBABMJPAAE_sceneListCenterSkillFilter;
			res["sceneListActiveSkillFilter"] = GIPNFAFFNLF_sceneListActiveSkillFilter;
			res["sceneListLiveSkillFilter"] = BOMCDAIEFLN_sceneListLiveSkillFilter;
			res["sceneSelectNotesExpectedFilter"] = DMKHBHDGABG_sceneSelectNotesExpectedFilter;
			res["sceneListNotesExpectedFilter"] = MCJBFHMJECO_sceneListNotesExpectedFilter;
			res["friendList"] = IDFGCPNELIA_FriendList.NOJCMGAFAAC();
			res["guestSelect"] = GDMIGCCMEEF_GuestSelect.NOJCMGAFAAC();
			res["sentRequestList"] = EJAJGGKHALM_SentRequestList.NOJCMGAFAAC();
			res["pendingList"] = DOKBEPGKNJK_PendingList.NOJCMGAFAAC();
			res["episodeSelect"] = CEJNPBFIIMJ_EpisodeSelect.NOJCMGAFAAC();
			res["raid"] = JGAFBCMOGLP_Raid.NOJCMGAFAAC();
			res["musicSelect"] = KGDILGLNKFM_MusicSelect.NOJCMGAFAAC();
			res["verticalMusicSelect"] = JHCKHAMFHMG_VerticalMusicSelect.NOJCMGAFAAC();
			res["eventGoDiva"] = IMEBBACHPAN_EventGoDiva.NOJCMGAFAAC();
			res["eventMission"] = BPFEOJEAEGK_EventMission.NOJCMGAFAAC();
			res["selectHomeBg"] = GIDCHFBCBML_SelectHomeBG.NOJCMGAFAAC();
			res["shopProduct_1_4"] = CCJMAIPBELA_ShopProduct1_4.NOJCMGAFAAC();
			res["shopProduct_5_6"] = HDKDFCCJEEP_ShopProduct5_6.NOJCMGAFAAC();
			return res;
		}

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
        public FOLMONPGGPP_Header HKGPAMEKGKG_Header = new FOLMONPGGPP_Header(); // 0x8
        public DNLECGEBDOI_Tutorial IAHLNPMFJMH_Tutorial = new DNLECGEBDOI_Tutorial(); // 0xC
        public MPHNGGECENI_Option CNLJNGLMMHB_Options = new MPHNGGECENI_Option(); // 0x10
        public BEJIKEOAJHN_OptionSLive MHHPDGJLJGE_OptionsSLive = new BEJIKEOAJHN_OptionSLive(); // 0x14
        public APLMBKKCNKC_Select MCNEIJAOLNO_Select = new APLMBKKCNKC_Select(); // 0x18
        public IJDOCJCLAIL_SortProprty PPCGEFGJJIC_SortProprty = new IJDOCJCLAIL_SortProprty(); // 0x1C
        public JDBOPCADICO_Notification BOJCCICAHJK_Notification = new JDBOPCADICO_Notification(); // 0x20
		public EHNBPANMAKA_Popup OFMECFHNCHA_Popup = new EHNBPANMAKA_Popup(); // 0x24
		public FNDHMLLDACE_Login NDOKECOAPML_Login = new FNDHMLLDACE_Login(); // 0x28
		public HEJDCGGIADL_StatusPopup LDNJHLLKEIG_StatusPopup = new HEJDCGGIADL_StatusPopup(); // 0x2C
		public NKHHJGFNAKI_Anketo LPBFPCGDOGC_Anketo = new NKHHJGFNAKI_Anketo(); // 0x30
		public DBAJCPLEMDP_Shop PFOMECFACLL_Shop = new DBAJCPLEMDP_Shop(); // 0x34
		public DJJGOGFPCEA_Home GBCEALJIKFN_Home = new DJJGOGFPCEA_Home(); // 0x38
		public JCFNHPMBPLJ_UnitDance EGNEDJLCMAI_UnitDance = new JCFNHPMBPLJ_UnitDance(); // 0x3C
		public CMKCDNCHNKH_CostumeUpgrade MOBOMOEHGAO_CostumeUpgrade = new CMKCDNCHNKH_CostumeUpgrade(); // 0x40
		public ABEMIFANBMF_Offer DKFCBKNPPOO_Offer = new ABEMIFANBMF_Offer(); // 0x44
		public ICEOHGGIBBE_ChatCommon NNKKOLHBGEL_ChatCommon = new ICEOHGGIBBE_ChatCommon(); // 0x48
		public EIHCEKNKHJB_ValkyrieTuneUp IOAFPGDJCDH_ValkyrieTuneUp = new EIHCEKNKHJB_ValkyrieTuneUp(); // 0x4C
		public FIDNFICGLEE_LimitedItemWarning KPHPNFBBLPA_LimitedItemWarning = new FIDNFICGLEE_LimitedItemWarning(); // 0x50
		public AKKDKBOBKGH_AprilFool ICFDECCGKIL_AprilFool = new AKKDKBOBKGH_AprilFool(); // 0x54

		// // RVA: 0x2032328 Offset: 0x2032328 VA: 0x2032328
		private void ICJOCNLOOIP()
		{
			if(HKGPAMEKGKG_Header.CEMEIPNMAAD_Version < ILDKBCLAFPB.JLLFHBIJNPC_GetVersion())
			{
				for(int i = HKGPAMEKGKG_Header.CEMEIPNMAAD_Version; i < ILDKBCLAFPB.BKDGANJBPPG.Length; i++)
				{
					ILDKBCLAFPB.BKDGANJBPPG[i](this);
				}
			}
			HKGPAMEKGKG_Header.BOGMEEOOADP();
		}

        // // RVA: 0x203249C Offset: 0x203249C VA: 0x203249C
        public static bool CHDGLBBFEKH_IsEqual(IPHAEFKCNMN ILEKEPJBFDP, IPHAEFKCNMN GEPALDIIDPC)
		{
			if (FOLMONPGGPP_Header.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.HKGPAMEKGKG_Header, GEPALDIIDPC.HKGPAMEKGKG_Header) &&
					DNLECGEBDOI_Tutorial.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.IAHLNPMFJMH_Tutorial, GEPALDIIDPC.IAHLNPMFJMH_Tutorial) &&
					MPHNGGECENI_Option.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.CNLJNGLMMHB_Options, GEPALDIIDPC.CNLJNGLMMHB_Options) &&
					BEJIKEOAJHN_OptionSLive.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.MHHPDGJLJGE_OptionsSLive, GEPALDIIDPC.MHHPDGJLJGE_OptionsSLive) &&
					APLMBKKCNKC_Select.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.MCNEIJAOLNO_Select, GEPALDIIDPC.MCNEIJAOLNO_Select) &&
					IJDOCJCLAIL_SortProprty.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.PPCGEFGJJIC_SortProprty, GEPALDIIDPC.PPCGEFGJJIC_SortProprty) &&
					JDBOPCADICO_Notification.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.BOJCCICAHJK_Notification, GEPALDIIDPC.BOJCCICAHJK_Notification) &&
					EHNBPANMAKA_Popup.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.OFMECFHNCHA_Popup, GEPALDIIDPC.OFMECFHNCHA_Popup) &&
					FNDHMLLDACE_Login.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.NDOKECOAPML_Login, GEPALDIIDPC.NDOKECOAPML_Login) &&
					HEJDCGGIADL_StatusPopup.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.LDNJHLLKEIG_StatusPopup, GEPALDIIDPC.LDNJHLLKEIG_StatusPopup) &&
					NKHHJGFNAKI_Anketo.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.LPBFPCGDOGC_Anketo, GEPALDIIDPC.LPBFPCGDOGC_Anketo) &&
					DBAJCPLEMDP_Shop.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.PFOMECFACLL_Shop, GEPALDIIDPC.PFOMECFACLL_Shop) &&
					DJJGOGFPCEA_Home.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.GBCEALJIKFN_Home, GEPALDIIDPC.GBCEALJIKFN_Home) &&
					JCFNHPMBPLJ_UnitDance.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.EGNEDJLCMAI_UnitDance, GEPALDIIDPC.EGNEDJLCMAI_UnitDance) &&
					CMKCDNCHNKH_CostumeUpgrade.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.MOBOMOEHGAO_CostumeUpgrade, GEPALDIIDPC.MOBOMOEHGAO_CostumeUpgrade) &&
					ABEMIFANBMF_Offer.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.DKFCBKNPPOO_Offer, GEPALDIIDPC.DKFCBKNPPOO_Offer) &&
					ICEOHGGIBBE_ChatCommon.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.NNKKOLHBGEL_ChatCommon, GEPALDIIDPC.NNKKOLHBGEL_ChatCommon) &&
					EIHCEKNKHJB_ValkyrieTuneUp.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.IOAFPGDJCDH_ValkyrieTuneUp, GEPALDIIDPC.IOAFPGDJCDH_ValkyrieTuneUp) &&
					FIDNFICGLEE_LimitedItemWarning.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.KPHPNFBBLPA_LimitedItemWarning, GEPALDIIDPC.KPHPNFBBLPA_LimitedItemWarning) &&
					AKKDKBOBKGH_AprilFool.CHDGLBBFEKH_IsEqual(ILEKEPJBFDP.ICFDECCGKIL_AprilFool, GEPALDIIDPC.ICFDECCGKIL_AprilFool))
				return true;
			return false;
		}

        // // RVA: 0x201B270 Offset: 0x201B270 VA: 0x201B270
        public static bool HMMFJOEBEKJ_IsNotEqual(IPHAEFKCNMN ILEKEPJBFDP, IPHAEFKCNMN GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

        // // RVA: 0x201A834 Offset: 0x201A834 VA: 0x201A834
        public void ODDIHGPONFL_Copy(ILDKBCLAFPB.IPHAEFKCNMN FMKAONAMGCN)
        {
			HKGPAMEKGKG_Header.ODDIHGPONFL_Copy(FMKAONAMGCN.HKGPAMEKGKG_Header);
			IAHLNPMFJMH_Tutorial.ODDIHGPONFL_Copy(FMKAONAMGCN.IAHLNPMFJMH_Tutorial);
			CNLJNGLMMHB_Options.ODDIHGPONFL_Copy(FMKAONAMGCN.CNLJNGLMMHB_Options);
			MHHPDGJLJGE_OptionsSLive.ODDIHGPONFL_Copy(FMKAONAMGCN.MHHPDGJLJGE_OptionsSLive);
			MCNEIJAOLNO_Select.ODDIHGPONFL_Copy(FMKAONAMGCN.MCNEIJAOLNO_Select);
			PPCGEFGJJIC_SortProprty.ODDIHGPONFL_Copy(FMKAONAMGCN.PPCGEFGJJIC_SortProprty);
			BOJCCICAHJK_Notification.ODDIHGPONFL_Copy(FMKAONAMGCN.BOJCCICAHJK_Notification);
			OFMECFHNCHA_Popup.ODDIHGPONFL(FMKAONAMGCN.OFMECFHNCHA_Popup);
			NDOKECOAPML_Login.ODDIHGPONFL(FMKAONAMGCN.NDOKECOAPML_Login);
			LDNJHLLKEIG_StatusPopup.ODDIHGPONFL(FMKAONAMGCN.LDNJHLLKEIG_StatusPopup);
			LPBFPCGDOGC_Anketo.ODDIHGPONFL(FMKAONAMGCN.LPBFPCGDOGC_Anketo);
			PFOMECFACLL_Shop.ODDIHGPONFL(FMKAONAMGCN.PFOMECFACLL_Shop);
			GBCEALJIKFN_Home.ODDIHGPONFL(FMKAONAMGCN.GBCEALJIKFN_Home);
			EGNEDJLCMAI_UnitDance.ODDIHGPONFL(FMKAONAMGCN.EGNEDJLCMAI_UnitDance);
			MOBOMOEHGAO_CostumeUpgrade.ODDIHGPONFL(FMKAONAMGCN.MOBOMOEHGAO_CostumeUpgrade);
			DKFCBKNPPOO_Offer.ODDIHGPONFL(FMKAONAMGCN.DKFCBKNPPOO_Offer);
			NNKKOLHBGEL_ChatCommon.ODDIHGPONFL(FMKAONAMGCN.NNKKOLHBGEL_ChatCommon);
			IOAFPGDJCDH_ValkyrieTuneUp.ODDIHGPONFL(FMKAONAMGCN.IOAFPGDJCDH_ValkyrieTuneUp);
			KPHPNFBBLPA_LimitedItemWarning.ODDIHGPONFL(FMKAONAMGCN.KPHPNFBBLPA_LimitedItemWarning);
			ICFDECCGKIL_AprilFool.ODDIHGPONFL(FMKAONAMGCN.ICFDECCGKIL_AprilFool);
		}

        // // RVA: 0x2032DB8 Offset: 0x2032DB8 VA: 0x2032DB8
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
        {
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("header"))
			{
				HKGPAMEKGKG_Header.KHEKNNFCAOI_Init(OBHAFLMHAKG["header"]);
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
			if(OBHAFLMHAKG.BBAJPINMOEP_Contains("notification"))
			{
				BOJCCICAHJK_Notification.KHEKNNFCAOI_Init(OBHAFLMHAKG["notification"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("popup"))
			{
				OFMECFHNCHA_Popup.KHEKNNFCAOI_Init(OBHAFLMHAKG["popup"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("login"))
			{
				NDOKECOAPML_Login.KHEKNNFCAOI_Init(OBHAFLMHAKG["login"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("statusPopup"))
			{
				LDNJHLLKEIG_StatusPopup.KHEKNNFCAOI_Init(OBHAFLMHAKG["statusPopup"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("anketo"))
			{
				LPBFPCGDOGC_Anketo.KHEKNNFCAOI_Init(OBHAFLMHAKG["anketo"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("shop"))
			{
				PFOMECFACLL_Shop.KHEKNNFCAOI_Init(OBHAFLMHAKG["shop"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("home"))
			{
				GBCEALJIKFN_Home.KHEKNNFCAOI_Init(OBHAFLMHAKG["home"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("unitDance"))
			{
				EGNEDJLCMAI_UnitDance.KHEKNNFCAOI_Init(OBHAFLMHAKG["unitDance"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("costumeUpgrade"))
			{
				MOBOMOEHGAO_CostumeUpgrade.KHEKNNFCAOI_Init(OBHAFLMHAKG["costumeUpgrade"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("offer"))
			{
				DKFCBKNPPOO_Offer.KHEKNNFCAOI_Init(OBHAFLMHAKG["offer"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("ChatCommon"))
			{
				NNKKOLHBGEL_ChatCommon.KHEKNNFCAOI_Init(OBHAFLMHAKG["ChatCommon"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("valkyrieTuneUp"))
			{
				IOAFPGDJCDH_ValkyrieTuneUp.KHEKNNFCAOI_Init(OBHAFLMHAKG["valkyrieTuneUp"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("limitedItemWarning"))
			{
				KPHPNFBBLPA_LimitedItemWarning.KHEKNNFCAOI_Init(OBHAFLMHAKG["limitedItemWarning"]);
			}
			if (OBHAFLMHAKG.BBAJPINMOEP_Contains("aprilFool"))
			{
				ICFDECCGKIL_AprilFool.KHEKNNFCAOI_Init(OBHAFLMHAKG["aprilFool"]);
			}
			ICJOCNLOOIP();
        }

        // // RVA: 0x2033FE0 Offset: 0x2033FE0 VA: 0x2033FE0
        public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["header"] = HKGPAMEKGKG_Header.NOJCMGAFAAC();
			res["tutorial"] = IAHLNPMFJMH_Tutorial.NOJCMGAFAAC();
			res["option"] = CNLJNGLMMHB_Options.NOJCMGAFAAC();
			res["option_slive"] = MHHPDGJLJGE_OptionsSLive.NOJCMGAFAAC();
			res["select"] = MCNEIJAOLNO_Select.NOJCMGAFAAC();
			res["sortProprty"] = PPCGEFGJJIC_SortProprty.NOJCMGAFAAC();
			res["notification"] = BOJCCICAHJK_Notification.NOJCMGAFAAC();
			res["popup"] = OFMECFHNCHA_Popup.NOJCMGAFAAC();
			res["login"] = NDOKECOAPML_Login.NOJCMGAFAAC();
			res["statusPopup"] = LDNJHLLKEIG_StatusPopup.NOJCMGAFAAC();
			res["anketo"] = LPBFPCGDOGC_Anketo.NOJCMGAFAAC();
			res["shop"] = PFOMECFACLL_Shop.NOJCMGAFAAC();
			res["home"] = GBCEALJIKFN_Home.NOJCMGAFAAC();
			res["unitDance"] = EGNEDJLCMAI_UnitDance.NOJCMGAFAAC();
			res["costumeUpgrade"] = MOBOMOEHGAO_CostumeUpgrade.NOJCMGAFAAC();
			res["offer"] = DKFCBKNPPOO_Offer.NOJCMGAFAAC();
			res["ChatCommon"] = NNKKOLHBGEL_ChatCommon.NOJCMGAFAAC();
			res["valkyrieTuneUp"] = IOAFPGDJCDH_ValkyrieTuneUp.NOJCMGAFAAC();
			res["limitedItemWarning"] = KPHPNFBBLPA_LimitedItemWarning.NOJCMGAFAAC();
			res["aprilFool"] = ICFDECCGKIL_AprilFool.NOJCMGAFAAC();
			return res;
		}

        // // RVA: 0x201B1B0 Offset: 0x201B1B0 VA: 0x201B1B0
        public void NFDEBEJFNGD(string DLENPPIJNPA)
        {
            KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DLENPPIJNPA));
        }

        // // RVA: 0x201A460 Offset: 0x201A460 VA: 0x201A460
        public string EJCOJCGIBNG()
		{
			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			NOJCMGAFAAC().EJCOJCGIBNG_ToJson(writer);
			return writer.ToString();
		}
    }

    public class JDBOPCADICO_Notification
    {
        public sbyte KNOLBNCEHFB_StaminaReceive = 1; // 0x8
        public sbyte ILNIHDCCOEO_EventReceive = 1; // 0x9
        public sbyte NDOEPNGHGPF_SnsReceive = 1; // 0xA
        public sbyte JAFLKPEEGIM_OfferReceive = 1; // 0xB
        public sbyte PIPOIELPKBP_DecoReceive = 1; // 0xC
        public sbyte HILOMEJEJAM_ApReceive = 1; // 0xD
        public sbyte OKGKFFLMFKH_LimitedReceive = 1; // 0xE
        public int OLBKCGKDBBL_TimeSlotAndBoss; // 0x10

        public sbyte EJGJPICOCBI { get { return (sbyte)(~((OLBKCGKDBBL_TimeSlotAndBoss >> 8) & 1)); } set {
				if (value == 0)
					OLBKCGKDBBL_TimeSlotAndBoss |= 0x100;
				else
					OLBKCGKDBBL_TimeSlotAndBoss &= ~0x100;
			} } //ILKOBMOJIPG 0x2035A10 IONHLLLJLAI 0x2035A20

		// // RVA: 0x2035A38 Offset: 0x2035A38 VA: 0x2035A38
		public void AAHGFMHAJFG(int ICDJHNPILBC, bool JKDJCFEBDHC)
		{
			if (JKDJCFEBDHC)
				OLBKCGKDBBL_TimeSlotAndBoss &= ~(1 << ICDJHNPILBC);
			else
				OLBKCGKDBBL_TimeSlotAndBoss |= 1 << ICDJHNPILBC;
		}

		// // RVA: 0x2035A60 Offset: 0x2035A60 VA: 0x2035A60
		public bool OCKFGNLLBFA(int ICDJHNPILBC)
		{
			return (OLBKCGKDBBL_TimeSlotAndBoss & (1 << ICDJHNPILBC)) == 0;
		}

        // // RVA: 0x2035A7C Offset: 0x2035A7C VA: 0x2035A7C
        public static bool CHDGLBBFEKH_IsEqual(JDBOPCADICO_Notification ILEKEPJBFDP, JDBOPCADICO_Notification GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.KNOLBNCEHFB_StaminaReceive == GEPALDIIDPC.KNOLBNCEHFB_StaminaReceive &&
				ILEKEPJBFDP.ILNIHDCCOEO_EventReceive == GEPALDIIDPC.ILNIHDCCOEO_EventReceive &&
				ILEKEPJBFDP.NDOEPNGHGPF_SnsReceive == GEPALDIIDPC.NDOEPNGHGPF_SnsReceive &&
				ILEKEPJBFDP.JAFLKPEEGIM_OfferReceive == GEPALDIIDPC.JAFLKPEEGIM_OfferReceive &&
				ILEKEPJBFDP.OLBKCGKDBBL_TimeSlotAndBoss == GEPALDIIDPC.OLBKCGKDBBL_TimeSlotAndBoss &&
				ILEKEPJBFDP.PIPOIELPKBP_DecoReceive == GEPALDIIDPC.PIPOIELPKBP_DecoReceive &&
				ILEKEPJBFDP.HILOMEJEJAM_ApReceive == GEPALDIIDPC.HILOMEJEJAM_ApReceive &&
				ILEKEPJBFDP.OKGKFFLMFKH_LimitedReceive == GEPALDIIDPC.OKGKFFLMFKH_LimitedReceive)
				return true;
			return false;
		}

        // // RVA: 0x20326CC Offset: 0x20326CC VA: 0x20326CC
        public static bool HMMFJOEBEKJ(JDBOPCADICO_Notification ILEKEPJBFDP, JDBOPCADICO_Notification GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}

        // // RVA: 0x2032C9C Offset: 0x2032C9C VA: 0x2032C9C
        public void ODDIHGPONFL_Copy(JDBOPCADICO_Notification FMKAONAMGCN)
		{
			FMKAONAMGCN.KNOLBNCEHFB_StaminaReceive = KNOLBNCEHFB_StaminaReceive;
			FMKAONAMGCN.ILNIHDCCOEO_EventReceive = ILNIHDCCOEO_EventReceive;
			FMKAONAMGCN.NDOEPNGHGPF_SnsReceive = NDOEPNGHGPF_SnsReceive;
			FMKAONAMGCN.JAFLKPEEGIM_OfferReceive = JAFLKPEEGIM_OfferReceive;
			FMKAONAMGCN.OLBKCGKDBBL_TimeSlotAndBoss = OLBKCGKDBBL_TimeSlotAndBoss;
			FMKAONAMGCN.PIPOIELPKBP_DecoReceive = PIPOIELPKBP_DecoReceive;
			FMKAONAMGCN.HILOMEJEJAM_ApReceive = HILOMEJEJAM_ApReceive;
			FMKAONAMGCN.OKGKFFLMFKH_LimitedReceive = OKGKFFLMFKH_LimitedReceive;
		}

        // // RVA: 0x203557C Offset: 0x203557C VA: 0x203557C
        public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["staminaReceive"] = KNOLBNCEHFB_StaminaReceive;
			res["eventReceive"] = ILNIHDCCOEO_EventReceive;
			res["snsReceive"] = NDOEPNGHGPF_SnsReceive;
			res["offerReceive"] = JAFLKPEEGIM_OfferReceive;
			res["timeSlotAndBoss"] = OLBKCGKDBBL_TimeSlotAndBoss;
			res["decoReceve"] = PIPOIELPKBP_DecoReceive;
			res["apReceive"] = HILOMEJEJAM_ApReceive;
			res["limitedReceive"] = OKGKFFLMFKH_LimitedReceive;
			return res;
		}

        // // RVA: 0x2033DDC Offset: 0x2033DDC VA: 0x2033DDC
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			KNOLBNCEHFB_StaminaReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "staminaReceive", 1);
			ILNIHDCCOEO_EventReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "eventReceive", 1);
			NDOEPNGHGPF_SnsReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "snsReceive", 1);
			JAFLKPEEGIM_OfferReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "offerReceive", 1);
			OLBKCGKDBBL_TimeSlotAndBoss = JsonUtil.GetInt(OBHAFLMHAKG, "timeSlotAndBoss", 0);
			PIPOIELPKBP_DecoReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "decoReceve", 1);
			HILOMEJEJAM_ApReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "apReceive", 1);
			OKGKFFLMFKH_LimitedReceive = (sbyte)JsonUtil.GetInt(OBHAFLMHAKG, "limitedReceive", 1);
		}
    }
	
	public class EHNBPANMAKA_Popup
	{
		public enum FEGJEHDIEMM
		{
			FOJBCKOADNF = 0,
			HLFFEADNEHB_AccountBindPopup = 1,
			ONLKHHHLGPK = 2,
			CAMKIILHPDE = 3,
		}

		public const int HFLFBFBGEOM = 3;
		private List<long> KBMJNKENLAC_PopupNt = new List<long>(HFLFBFBGEOM) { 0, 0, 0 }; // 0x8
		private StringBuilder GMHABOPJDLN = new StringBuilder(); // 0xC

		//// RVA: 0x20292BC Offset: 0x20292BC VA: 0x20292BC
		public static bool CHDGLBBFEKH_IsEqual(EHNBPANMAKA_Popup LFGLBIAODLE, EHNBPANMAKA_Popup CJDJGHIIBHP)
		{
			if (System.Linq.Enumerable.SequenceEqual<long>(LFGLBIAODLE.KBMJNKENLAC_PopupNt, CJDJGHIIBHP.KBMJNKENLAC_PopupNt))
				return true;
			return false;
		}

		//// RVA: 0x202934C Offset: 0x202934C VA: 0x202934C
		public static bool HMMFJOEBEKJ(EHNBPANMAKA_Popup LFGLBIAODLE, EHNBPANMAKA_Popup CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x202946C Offset: 0x202946C VA: 0x202946C
		public void ODDIHGPONFL(EHNBPANMAKA_Popup PJFKNNNDMIA)
		{
			PJFKNNNDMIA.KBMJNKENLAC_PopupNt.Clear();
			PJFKNNNDMIA.KBMJNKENLAC_PopupNt.AddRange(KBMJNKENLAC_PopupNt);
		}

		//// RVA: 0x202952C Offset: 0x202952C VA: 0x202952C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			for (int i = 0; i < HFLFBFBGEOM; i++)
			{
				res[LAPEABGEEKP((FEGJEHDIEMM)i)] = KBMJNKENLAC_PopupNt[i];
			}
			return res;
		}

		//// RVA: 0x2029728 Offset: 0x2029728 VA: 0x2029728
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			for(int i = 0; i < HFLFBFBGEOM; i++)
			{
				KBMJNKENLAC_PopupNt[i] = JsonUtil.GetLong(OBHAFLMHAKG, LAPEABGEEKP((FEGJEHDIEMM)i));
			}
		}

		//// RVA: 0x20297F0 Offset: 0x20297F0 VA: 0x20297F0
		//public void PFCBKBFONJA(ILDKBCLAFPB.EHNBPANMAKA.FEGJEHDIEMM PPFNGGCBJKC) { }

		//// RVA: 0x2029884 Offset: 0x2029884 VA: 0x2029884
		public void PFCBKBFONJA_SetPopupNextShowTime(FEGJEHDIEMM PPFNGGCBJKC, long GJNPGCCKICA)
		{
			KBMJNKENLAC_PopupNt[(int)PPFNGGCBJKC] = GJNPGCCKICA;
		}

		//// RVA: 0x2029920 Offset: 0x2029920 VA: 0x2029920
		public bool MDBINDIACKP_CanShowPopup(FEGJEHDIEMM PPFNGGCBJKC)
		{
			return MDBINDIACKP_CanShowPopup(PPFNGGCBJKC, Utility.GetCurrentUnixTime());
		}

		//// RVA: 0x20299C0 Offset: 0x20299C0 VA: 0x20299C0
		public bool MDBINDIACKP_CanShowPopup(FEGJEHDIEMM PPFNGGCBJKC, long AIOOALJCFOG)
		{
			if(KBMJNKENLAC_PopupNt[(int)PPFNGGCBJKC] != 0)
			{
				return KBMJNKENLAC_PopupNt[(int)PPFNGGCBJKC] > -1 && KBMJNKENLAC_PopupNt[(int)PPFNGGCBJKC] <= AIOOALJCFOG;
			}
			return true;
		}

		//// RVA: 0x2029668 Offset: 0x2029668 VA: 0x2029668
		private string LAPEABGEEKP(FEGJEHDIEMM PPFNGGCBJKC)
		{
			GMHABOPJDLN.SetFormat("popup_NT_{0:D4}", (int)PPFNGGCBJKC);
			return GMHABOPJDLN.ToString();
		}
	}
	
	public class FNDHMLLDACE_Login
	{
		public enum JNBNAOBNLMM
		{
			DHGCJEOPEIE = 0,
			DDAFHPDFFPI = 1,
			CCDOBDNDPIL = 2,
			HNOJIKHAPHA = 3,
			HCBFMFONIOE = 4,
			OCCOKOMIGEE = 5,
			KHLPAOENONH = 6,
			MCLMCFMIAEN = 7,
			HMCELLADLDI = 8,
			CAMKIILHPDE = 9,
		}

		public BKLCILHFCGB_Flags LDCMANMNAHC_HomeTalkFlags = new BKLCILHFCGB_Flags(9); // 0x8
		public long CCIMAHFKOGO_LastLoginDate; // 0x10

		//// RVA: 0x202A1EC Offset: 0x202A1EC VA: 0x202A1EC
		public static bool CHDGLBBFEKH_IsEqual(FNDHMLLDACE_Login LFGLBIAODLE, FNDHMLLDACE_Login CJDJGHIIBHP)
		{
			if (BKLCILHFCGB_Flags.CHDGLBBFEKH_IsEqual(LFGLBIAODLE.LDCMANMNAHC_HomeTalkFlags, CJDJGHIIBHP.LDCMANMNAHC_HomeTalkFlags) &&
				LFGLBIAODLE.CCIMAHFKOGO_LastLoginDate == CJDJGHIIBHP.CCIMAHFKOGO_LastLoginDate)
				return true;
			return false;
		}

		//// RVA: 0x202A25C Offset: 0x202A25C VA: 0x202A25C
		public static bool HMMFJOEBEKJ(FNDHMLLDACE_Login LFGLBIAODLE, FNDHMLLDACE_Login CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x202A270 Offset: 0x202A270 VA: 0x202A270
		public void ODDIHGPONFL(FNDHMLLDACE_Login PJFKNNNDMIA)
		{
			PJFKNNNDMIA.LDCMANMNAHC_HomeTalkFlags.ODDIHGPONFL_Copy(LDCMANMNAHC_HomeTalkFlags);
			PJFKNNNDMIA.CCIMAHFKOGO_LastLoginDate = CCIMAHFKOGO_LastLoginDate;
		}

		//// RVA: 0x202A2C0 Offset: 0x202A2C0 VA: 0x202A2C0
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["homeTalkFlags"] = LDCMANMNAHC_HomeTalkFlags.NOJCMGAFAAC();
			res["lastLoginDate"] = CCIMAHFKOGO_LastLoginDate;
			return res;
		}

		// RVA: 0x202A3F8 Offset: 0x202A3F8 VA: 0x202A3F8
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			LDCMANMNAHC_HomeTalkFlags.KHEKNNFCAOI_Init(OBHAFLMHAKG["homeTalkFlags"]);
			CCIMAHFKOGO_LastLoginDate = JsonUtil.GetLong(OBHAFLMHAKG, "lastLoginDate");
		}
	}
	
	public class HEJDCGGIADL_StatusPopup
	{
		public int EPJPNFIMODP_DivaStatusPage; // 0x8
		public int ICBNEOCAGKF_SceneStatusPage; // 0xC
		public int ILEFFJCOGOG_GachaStatusPage; // 0x10

		//// RVA: 0x202BC64 Offset: 0x202BC64 VA: 0x202BC64
		public static bool CHDGLBBFEKH_IsEqual(HEJDCGGIADL_StatusPopup LFGLBIAODLE, HEJDCGGIADL_StatusPopup CJDJGHIIBHP)
		{
			if (LFGLBIAODLE.EPJPNFIMODP_DivaStatusPage == CJDJGHIIBHP.EPJPNFIMODP_DivaStatusPage &&
				LFGLBIAODLE.ICBNEOCAGKF_SceneStatusPage == CJDJGHIIBHP.ICBNEOCAGKF_SceneStatusPage &&
				LFGLBIAODLE.ILEFFJCOGOG_GachaStatusPage == CJDJGHIIBHP.ILEFFJCOGOG_GachaStatusPage)
				return true;
			return false;
		}

		//// RVA: 0x202BCD4 Offset: 0x202BCD4 VA: 0x202BCD4
		public static bool HMMFJOEBEKJ(HEJDCGGIADL_StatusPopup LFGLBIAODLE, HEJDCGGIADL_StatusPopup CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x202BCE8 Offset: 0x202BCE8 VA: 0x202BCE8
		public void ODDIHGPONFL(HEJDCGGIADL_StatusPopup PJFKNNNDMIA)
		{
			PJFKNNNDMIA.EPJPNFIMODP_DivaStatusPage = EPJPNFIMODP_DivaStatusPage;
			PJFKNNNDMIA.ICBNEOCAGKF_SceneStatusPage = ICBNEOCAGKF_SceneStatusPage;
			PJFKNNNDMIA.ILEFFJCOGOG_GachaStatusPage = ILEFFJCOGOG_GachaStatusPage;
		}

		//// RVA: 0x202BD50 Offset: 0x202BD50 VA: 0x202BD50
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["divaStatusPage"] = EPJPNFIMODP_DivaStatusPage;
			res["sceneStatusPage"] = ICBNEOCAGKF_SceneStatusPage;
			res["gachaStatusPage"] = ILEFFJCOGOG_GachaStatusPage;
			return res;
		}

		// RVA: 0x202BEA4 Offset: 0x202BEA4 VA: 0x202BEA4
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			EPJPNFIMODP_DivaStatusPage = JsonUtil.GetInt(OBHAFLMHAKG, "divaStatusPage", 0);
			ICBNEOCAGKF_SceneStatusPage = JsonUtil.GetInt(OBHAFLMHAKG, "sceneStatusPage", 0);
			ILEFFJCOGOG_GachaStatusPage = JsonUtil.GetInt(OBHAFLMHAKG, "gachaStatusPage", 0);
		}
	}
	
	public class NKHHJGFNAKI_Anketo
	{
		private const int LDFLPHDIMLB = 64;
		public BKLCILHFCGB_Flags FHEJNGDFMAI_AnswerFlags = new BKLCILHFCGB_Flags(64); // 0x8

		//// RVA: 0x9F1788 Offset: 0x9F1788 VA: 0x9F1788
		public static bool CHDGLBBFEKH_IsEqual(NKHHJGFNAKI_Anketo LFGLBIAODLE, NKHHJGFNAKI_Anketo CJDJGHIIBHP)
		{
			if (BKLCILHFCGB_Flags.CHDGLBBFEKH_IsEqual(LFGLBIAODLE.FHEJNGDFMAI_AnswerFlags, CJDJGHIIBHP.FHEJNGDFMAI_AnswerFlags))
				return true;
			return false;
		}

		//// RVA: 0x9F17D4 Offset: 0x9F17D4 VA: 0x9F17D4
		public static bool HMMFJOEBEKJ(NKHHJGFNAKI_Anketo LFGLBIAODLE, NKHHJGFNAKI_Anketo CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x9F17E8 Offset: 0x9F17E8 VA: 0x9F17E8
		public void ODDIHGPONFL(NKHHJGFNAKI_Anketo PJFKNNNDMIA)
		{
			PJFKNNNDMIA.FHEJNGDFMAI_AnswerFlags.ODDIHGPONFL_Copy(FHEJNGDFMAI_AnswerFlags);
		}

		//// RVA: 0x9F1834 Offset: 0x9F1834 VA: 0x9F1834
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["answerFlags"] = FHEJNGDFMAI_AnswerFlags.NOJCMGAFAAC();
			return res;
		}

		// RVA: 0x9F18F8 Offset: 0x9F18F8 VA: 0x9F18F8
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			FHEJNGDFMAI_AnswerFlags.KHEKNNFCAOI_Init(OBHAFLMHAKG["answerFlags"]);
		}
	}
	
	public class DBAJCPLEMDP_Shop
	{
		private const int NBLINPODEID = 64;
		public List<long> MHKCPJDNJKI = new List<long>(NBLINPODEID); // 0x8
		private StringBuilder GMHABOPJDLN = new StringBuilder(16); // 0xC

		//// RVA: 0x2025D7C Offset: 0x2025D7C VA: 0x2025D7C
		public static bool CHDGLBBFEKH_IsEqual(DBAJCPLEMDP_Shop LFGLBIAODLE, DBAJCPLEMDP_Shop CJDJGHIIBHP)
		{
			if (System.Linq.Enumerable.SequenceEqual<long>(LFGLBIAODLE.MHKCPJDNJKI, CJDJGHIIBHP.MHKCPJDNJKI))
				return true;
			return false;
		}

		//// RVA: 0x2025E0C Offset: 0x2025E0C VA: 0x2025E0C
		public static bool HMMFJOEBEKJ(DBAJCPLEMDP_Shop LFGLBIAODLE, DBAJCPLEMDP_Shop CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x2025E20 Offset: 0x2025E20 VA: 0x2025E20
		public DBAJCPLEMDP_Shop()
		{
			for(int i = 0; i < NBLINPODEID; i++)
			{
				MHKCPJDNJKI.Add(0);
			}
		}

		//// RVA: 0x2025F2C Offset: 0x2025F2C VA: 0x2025F2C
		public void ODDIHGPONFL(DBAJCPLEMDP_Shop PJFKNNNDMIA)
		{
			PJFKNNNDMIA.MHKCPJDNJKI.Clear();
			PJFKNNNDMIA.MHKCPJDNJKI.AddRange(MHKCPJDNJKI);
		}

		//// RVA: 0x2025FEC Offset: 0x2025FEC VA: 0x2025FEC
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			for (int i = 0; i < MHKCPJDNJKI.Count; i++)
			{
				res[LAPEABGEEKP(i)] = MHKCPJDNJKI[i];
			}
			return res;
		}

		//// RVA: 0x2026220 Offset: 0x2026220 VA: 0x2026220
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			for(int i = 0; i < MHKCPJDNJKI.Count; i++)
			{
				MHKCPJDNJKI[i] = JsonUtil.GetLong(OBHAFLMHAKG, LAPEABGEEKP(i));
			}
		}

		//// RVA: 0x2026318 Offset: 0x2026318 VA: 0x2026318
		public void POAFHAHACEL(int PPFNGGCBJKC, long IOIMHJAOKOO)
		{
			MHKCPJDNJKI[PPFNGGCBJKC - 1] = IOIMHJAOKOO;
		}

		//// RVA: 0x20263B4 Offset: 0x20263B4 VA: 0x20263B4
		public long BGDCMGOPCGE(int PPFNGGCBJKC)
		{
			return MHKCPJDNJKI[PPFNGGCBJKC - 1];
		}

		//// RVA: 0x2026160 Offset: 0x2026160 VA: 0x2026160
		private string LAPEABGEEKP(int PPFNGGCBJKC)
		{
			GMHABOPJDLN.SetFormat("{0:D3}", PPFNGGCBJKC);
			return GMHABOPJDLN.ToString();
		}
	}
	
	public class JCFNHPMBPLJ_UnitDance
	{
		public bool KBAMKMDJMJC_DisableWarning; // 0x8

		//// RVA: 0x20359BC Offset: 0x20359BC VA: 0x20359BC
		public static bool CHDGLBBFEKH_IsEqual(JCFNHPMBPLJ_UnitDance LFGLBIAODLE, JCFNHPMBPLJ_UnitDance CJDJGHIIBHP)
		{
			if (LFGLBIAODLE.KBAMKMDJMJC_DisableWarning == CJDJGHIIBHP.KBAMKMDJMJC_DisableWarning)
				return true;
			return false;
		}

		//// RVA: 0x20326E0 Offset: 0x20326E0 VA: 0x20326E0
		public static bool HMMFJOEBEKJ(JCFNHPMBPLJ_UnitDance LFGLBIAODLE, JCFNHPMBPLJ_UnitDance CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x2032D90 Offset: 0x2032D90 VA: 0x2032D90
		public void ODDIHGPONFL(JCFNHPMBPLJ_UnitDance PJFKNNNDMIA)
		{
			PJFKNNNDMIA.KBAMKMDJMJC_DisableWarning = KBAMKMDJMJC_DisableWarning;
		}

		//// RVA: 0x2035810 Offset: 0x2035810 VA: 0x2035810
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["disableWarning"] = KBAMKMDJMJC_DisableWarning ? 1 : 0;
			return res;
		}

		// RVA: 0x2033F4C Offset: 0x2033F4C VA: 0x2033F4C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			KBAMKMDJMJC_DisableWarning = JsonUtil.GetInt(OBHAFLMHAKG, "disableWarning", 0) > 0;
		}
	}
	
	public class CMKCDNCHNKH_CostumeUpgrade
	{
		private const string ELGLBFFBHOC = "divaFilterBit";
		private const string CBAGNKPDHLI = "selectDivaId";
		private const string PKJDGFKGOLE = "selectCostumeId";
		public int AEKKEKBMOCF_DivaFilterBit; // 0x8
		public int BDIOOMFHPJA_SelectDivaId = 1; // 0xC
		public int HEEJCAOKDPE_SelectCostumeId = 1; // 0x10

		// RVA: 0x2025A38 Offset: 0x2025A38 VA: 0x2025A38
		public CMKCDNCHNKH_CostumeUpgrade()
		{
			return;
		}

		// RVA: 0x2025A4C Offset: 0x2025A4C VA: 0x2025A4C
		public CMKCDNCHNKH_CostumeUpgrade(int EPCHEDJFAON, int BDIOOMFHPJA, int HEEJCAOKDPE)
		{
			AEKKEKBMOCF_DivaFilterBit = EPCHEDJFAON;
			this.BDIOOMFHPJA_SelectDivaId = BDIOOMFHPJA;
			this.HEEJCAOKDPE_SelectCostumeId = HEEJCAOKDPE;
		}

		//// RVA: 0x2025A8C Offset: 0x2025A8C VA: 0x2025A8C
		public void ODDIHGPONFL(CMKCDNCHNKH_CostumeUpgrade DNNHDJPNIAK)
		{
			DNNHDJPNIAK.AEKKEKBMOCF_DivaFilterBit = AEKKEKBMOCF_DivaFilterBit;
			DNNHDJPNIAK.BDIOOMFHPJA_SelectDivaId = BDIOOMFHPJA_SelectDivaId;
			DNNHDJPNIAK.HEEJCAOKDPE_SelectCostumeId = HEEJCAOKDPE_SelectCostumeId;
		}

		//// RVA: 0x2025AF4 Offset: 0x2025AF4 VA: 0x2025AF4
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			AEKKEKBMOCF_DivaFilterBit = JsonUtil.GetInt(OBHAFLMHAKG, ELGLBFFBHOC);
			BDIOOMFHPJA_SelectDivaId = JsonUtil.GetInt(OBHAFLMHAKG, CBAGNKPDHLI);
			HEEJCAOKDPE_SelectCostumeId = JsonUtil.GetInt(OBHAFLMHAKG, PKJDGFKGOLE);
		}

		//// RVA: 0x2025BA4 Offset: 0x2025BA4 VA: 0x2025BA4
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["divaFilterBit"] = AEKKEKBMOCF_DivaFilterBit;
			res["selectDivaId"] = BDIOOMFHPJA_SelectDivaId;
			res["selectCostumeId"] = HEEJCAOKDPE_SelectCostumeId;
			return res;
		}

		//// RVA: 0x2025CF8 Offset: 0x2025CF8 VA: 0x2025CF8
		public static bool CHDGLBBFEKH_IsEqual(CMKCDNCHNKH_CostumeUpgrade ILEKEPJBFDP, CMKCDNCHNKH_CostumeUpgrade GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.AEKKEKBMOCF_DivaFilterBit == GEPALDIIDPC.AEKKEKBMOCF_DivaFilterBit &&
				ILEKEPJBFDP.BDIOOMFHPJA_SelectDivaId == GEPALDIIDPC.BDIOOMFHPJA_SelectDivaId &&
				ILEKEPJBFDP.HEEJCAOKDPE_SelectCostumeId == GEPALDIIDPC.HEEJCAOKDPE_SelectCostumeId)
				return true;
			return false;
		}

		//// RVA: 0x2025D68 Offset: 0x2025D68 VA: 0x2025D68
		public static bool HMMFJOEBEKJ(CMKCDNCHNKH_CostumeUpgrade ILEKEPJBFDP, CMKCDNCHNKH_CostumeUpgrade GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}
	}
	
	public class ABEMIFANBMF_Offer
	{
		public bool GJAFIADJFHH_IsSortDesc; // 0x8
		public bool JALHDJGHMDN_IsLimited; // 0x9
		public int CPKMLLNADLJ_Series = 1; // 0xC
		public int AHMOGDDPIFL_LastVfId = 1; // 0x10
		private int NOHNDOIKIJK_ShowInfoBits; // 0x14
		public int GHKKEFGDIBC_LastVFP_Unlock = 1; // 0x18
		public int CHFMCFNEFEO_LastVOP_DailyLv = 1; // 0x1C
		private int[] IDCCFDHKJNP_LastVOP_DivaLv; // 0x20
		public KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo PCLGJLABHKG_DivaOfferInfo; // 0x24
		private StringBuilder KKELPILEDDD; // 0x28

		// RVA: 0x201C630 Offset: 0x201C630 VA: 0x201C630
		public ABEMIFANBMF_Offer()
		{
			CPKMLLNADLJ_Series = 1;
			AHMOGDDPIFL_LastVfId = 1;
			NOHNDOIKIJK_ShowInfoBits = 0;
			GHKKEFGDIBC_LastVFP_Unlock = 1;
			GJAFIADJFHH_IsSortDesc = false;
			JALHDJGHMDN_IsLimited = false;
			CHFMCFNEFEO_LastVOP_DailyLv = 1;
			IDCCFDHKJNP_LastVOP_DivaLv = new int[10];
			for(int i = 0; i < IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
			{
				IDCCFDHKJNP_LastVOP_DivaLv[i] = 2;
			}
			PCLGJLABHKG_DivaOfferInfo = new KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo();
			PCLGJLABHKG_DivaOfferInfo.LHPDDGIJKNB();
			KKELPILEDDD = new StringBuilder(32);
		}

		//// RVA: 0x201C7B8 Offset: 0x201C7B8 VA: 0x201C7B8
		public bool MGMIIAMOMGH(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ)
		{
			return (NOHNDOIKIJK_ShowInfoBits & (int)FIKCHOLCKNJ) != 0;
		}

		//// RVA: 0x201C7C8 Offset: 0x201C7C8 VA: 0x201C7C8
		public void LPGIDDKBJFJ(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ)
		{
			NOHNDOIKIJK_ShowInfoBits |= (int)FIKCHOLCKNJ;
		}

		//// RVA: 0x201C7D8 Offset: 0x201C7D8 VA: 0x201C7D8
		public void BFJFAIIAMMO(BOPFPIHGJMD.FDDGIANLNAD FIKCHOLCKNJ)
		{
			NOHNDOIKIJK_ShowInfoBits &= ~(int)FIKCHOLCKNJ;
		}

		//// RVA: 0x201C7E8 Offset: 0x201C7E8 VA: 0x201C7E8
		public int LDIBGNOLFAB_GetDivaLv(int AHHJLDLAPAN)
		{
			if (AHHJLDLAPAN < 1 || AHHJLDLAPAN > 10)
				return 0;
			return IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1];
		}

		//// RVA: 0x201C840 Offset: 0x201C840 VA: 0x201C840
		public void AHOBDLOOLHD(int AHHJLDLAPAN, int ANAJIAENLNB)
		{
			if(AHHJLDLAPAN > 0 && AHHJLDLAPAN - 1 < 10)
			{
				IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1] = ANAJIAENLNB;
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
				{
					if (IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1] == CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(AHHJLDLAPAN - 1))
						return;
					if (IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1] >= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(AHHJLDLAPAN - 1))
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.ALANKFMEIPK(AHHJLDLAPAN - 1, IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1]);
						return;
					}
					IDCCFDHKJNP_LastVOP_DivaLv[AHHJLDLAPAN - 1] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(AHHJLDLAPAN - 1);
				}
			}
		}

		//// RVA: 0x201CA94 Offset: 0x201CA94 VA: 0x201CA94
		public void OEIIDFEIFBE(KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo CNHEPCPELGK)
		{
			if (PCLGJLABHKG_DivaOfferInfo == null)
				return;
			CNHEPCPELGK.ODDIHGPONFL(PCLGJLABHKG_DivaOfferInfo);
		}

		//// RVA: 0x201CAD0 Offset: 0x201CAD0 VA: 0x201CAD0
		public void LMAHFGBPGKF(KDHGBOOECKC.GBAGPIKOGAN_DivaOfferInfo GPBJHKLFCEP)
		{
			if(PCLGJLABHKG_DivaOfferInfo != null)
				PCLGJLABHKG_DivaOfferInfo.ODDIHGPONFL(GPBJHKLFCEP);
		}

		//// RVA: 0x201CAE4 Offset: 0x201CAE4 VA: 0x201CAE4
		public void CPDBAIILNPL()
		{
			if (PCLGJLABHKG_DivaOfferInfo == null)
				return;
			PCLGJLABHKG_DivaOfferInfo.LHPDDGIJKNB();
		}

		//// RVA: 0x201CAF8 Offset: 0x201CAF8 VA: 0x201CAF8
		public void MKFNKOLCBOP_UpdateVFpUnlock(int ADPPAIPFHML)
		{
			GHKKEFGDIBC_LastVFP_Unlock = ADPPAIPFHML;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if (GHKKEFGDIBC_LastVFP_Unlock == CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock)
					return;
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock <= GHKKEFGDIBC_LastVFP_Unlock)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock = GHKKEFGDIBC_LastVFP_Unlock;
					return;
				}
				GHKKEFGDIBC_LastVFP_Unlock = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock;
			}
		}

		//// RVA: 0x201CC78 Offset: 0x201CC78 VA: 0x201CC78
		public void AHAECLAKMIB_UpdateDailyLv(int ANAJIAENLNB)
		{
			CHFMCFNEFEO_LastVOP_DailyLv = ANAJIAENLNB;
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if (CHFMCFNEFEO_LastVOP_DailyLv == CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv)
					return;
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv <= CHFMCFNEFEO_LastVOP_DailyLv)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv = CHFMCFNEFEO_LastVOP_DailyLv;
					return;
				}
				CHFMCFNEFEO_LastVOP_DailyLv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv;
			}
		}

		//// RVA: 0x201CDF8 Offset: 0x201CDF8 VA: 0x201CDF8
		public bool FBCDKFENOEM()
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				bool b = false;
				if (GHKKEFGDIBC_LastVFP_Unlock != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock)
				{
					if(GHKKEFGDIBC_LastVFP_Unlock < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock)
					{
						GHKKEFGDIBC_LastVFP_Unlock = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock;
						b = true;
					}
					else
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.GHKKEFGDIBC_LastVfpUnlock = GHKKEFGDIBC_LastVFP_Unlock;
						b = false;
					}
				}
				if (CHFMCFNEFEO_LastVOP_DailyLv != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv)
				{
					if(CHFMCFNEFEO_LastVOP_DailyLv < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv)
					{
						CHFMCFNEFEO_LastVOP_DailyLv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv;
						b = true;
					}
					else
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.CHFMCFNEFEO_LastVopDailyLv = CHFMCFNEFEO_LastVOP_DailyLv;
					}
				}
				for(int i = 0; i < IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
				{
					if(IDCCFDHKJNP_LastVOP_DivaLv[i] != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(i))
					{
						if (IDCCFDHKJNP_LastVOP_DivaLv[i] < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(i))
						{
							IDCCFDHKJNP_LastVOP_DivaLv[i] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MIPAIEGENEA(i);
							b = true;
						}
						else
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.ALANKFMEIPK(i, IDCCFDHKJNP_LastVOP_DivaLv[i]);
						}
					}
				}
				return b;
			}
			return false;
		}

		//// RVA: 0x201D1E0 Offset: 0x201D1E0 VA: 0x201D1E0
		public static bool CHDGLBBFEKH_IsEqual(ABEMIFANBMF_Offer LFGLBIAODLE, ABEMIFANBMF_Offer CJDJGHIIBHP)
		{
			if (!(LFGLBIAODLE.GJAFIADJFHH_IsSortDesc == CJDJGHIIBHP.GJAFIADJFHH_IsSortDesc &&
				LFGLBIAODLE.JALHDJGHMDN_IsLimited == CJDJGHIIBHP.JALHDJGHMDN_IsLimited &&
				LFGLBIAODLE.CPKMLLNADLJ_Series == CJDJGHIIBHP.CPKMLLNADLJ_Series &&
				LFGLBIAODLE.AHMOGDDPIFL_LastVfId == CJDJGHIIBHP.AHMOGDDPIFL_LastVfId &&
				LFGLBIAODLE.NOHNDOIKIJK_ShowInfoBits == CJDJGHIIBHP.NOHNDOIKIJK_ShowInfoBits &&
				LFGLBIAODLE.GHKKEFGDIBC_LastVFP_Unlock == CJDJGHIIBHP.GHKKEFGDIBC_LastVFP_Unlock &&
				LFGLBIAODLE.CHFMCFNEFEO_LastVOP_DailyLv == CJDJGHIIBHP.CHFMCFNEFEO_LastVOP_DailyLv &&
				LFGLBIAODLE.PCLGJLABHKG_DivaOfferInfo.AGBOGBEOFME(CJDJGHIIBHP.PCLGJLABHKG_DivaOfferInfo)))
				return false;
			for(int i = 0; i < LFGLBIAODLE.IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
			{
				if (LFGLBIAODLE.IDCCFDHKJNP_LastVOP_DivaLv[i] != CJDJGHIIBHP.IDCCFDHKJNP_LastVOP_DivaLv[i])
					return false;
			}
			return true;
		}

		//// RVA: 0x201D370 Offset: 0x201D370 VA: 0x201D370
		public static bool HMMFJOEBEKJ(ABEMIFANBMF_Offer LFGLBIAODLE, ABEMIFANBMF_Offer CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x201D384 Offset: 0x201D384 VA: 0x201D384
		public void ODDIHGPONFL(ABEMIFANBMF_Offer PJFKNNNDMIA)
		{
			PJFKNNNDMIA.GJAFIADJFHH_IsSortDesc = GJAFIADJFHH_IsSortDesc;
			PJFKNNNDMIA.JALHDJGHMDN_IsLimited = JALHDJGHMDN_IsLimited;
			PJFKNNNDMIA.CPKMLLNADLJ_Series = CPKMLLNADLJ_Series;
			PJFKNNNDMIA.AHMOGDDPIFL_LastVfId = AHMOGDDPIFL_LastVfId;
			PJFKNNNDMIA.NOHNDOIKIJK_ShowInfoBits = NOHNDOIKIJK_ShowInfoBits;
			PJFKNNNDMIA.GHKKEFGDIBC_LastVFP_Unlock = GHKKEFGDIBC_LastVFP_Unlock;
			PJFKNNNDMIA.CHFMCFNEFEO_LastVOP_DailyLv = CHFMCFNEFEO_LastVOP_DailyLv;
			for(int i = 0; i < IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
			{
				PJFKNNNDMIA.IDCCFDHKJNP_LastVOP_DivaLv[i] = IDCCFDHKJNP_LastVOP_DivaLv[i];
			}
			PJFKNNNDMIA.PCLGJLABHKG_DivaOfferInfo.ODDIHGPONFL(PCLGJLABHKG_DivaOfferInfo);
		}

		//// RVA: 0x201D51C Offset: 0x201D51C VA: 0x201D51C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["isSortDesc"] = GJAFIADJFHH_IsSortDesc ? 1 : 0;
			res["isLimited"] = JALHDJGHMDN_IsLimited ? 1 : 0;
			res["series"] = CPKMLLNADLJ_Series;
			res["lastVfId"] = AHMOGDDPIFL_LastVfId;
			res["showInfoBits"] = NOHNDOIKIJK_ShowInfoBits;
			res["lastVFP_Unlock"] = GHKKEFGDIBC_LastVFP_Unlock;
			res["lastVOP_DailyLv"] = CHFMCFNEFEO_LastVOP_DailyLv;
			for (int i = 0; i < IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
			{
				res[IAMECBIFIKA("lastVOP_DivaLv_{0:D2}", i)] = IDCCFDHKJNP_LastVOP_DivaLv[i];
			}
			res["divaOfferInfo_divaId"] = PCLGJLABHKG_DivaOfferInfo.AHHJLDLAPAN_DivaId;
			res["divaOfferInfo_offerId"] = PCLGJLABHKG_DivaOfferInfo.MLDPDLPHJPM_OfferId;
			res["divaOfferInfo_divaName"] = PCLGJLABHKG_DivaOfferInfo.MBALOBPODGA_DivaName;
			res["divaOfferInfo_offerName"] = PCLGJLABHKG_DivaOfferInfo.PGOGHFDBIBA_OfferName;
			res["divaOfferInfo_offerText"] = PCLGJLABHKG_DivaOfferInfo.PNOBKANLFHA_OfferText;
			res["divaOfferInfo_cond"] = (int)PCLGJLABHKG_DivaOfferInfo.OAFPGJLCNFM_Cond;
			res["divaOfferInfo_level0"] = PCLGJLABHKG_DivaOfferInfo.KFEMFDFPCGO_Level0;
			res["divaOfferInfo_level"] = PCLGJLABHKG_DivaOfferInfo.CIEOBFIIPLD_Level;
			res["divaOfferInfo_isMaxLevel"] = PCLGJLABHKG_DivaOfferInfo.NBHEBLNHOJO_IsMaxLevel ? 1 : 0;
			return res;
		}

		//// RVA: 0x201DCA4 Offset: 0x201DCA4 VA: 0x201DCA4
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			GJAFIADJFHH_IsSortDesc = JsonUtil.GetInt(OBHAFLMHAKG, "isSortDesc", 0) > 0;
			JALHDJGHMDN_IsLimited = JsonUtil.GetInt(OBHAFLMHAKG, "isLimited", 0) > 0;
			CPKMLLNADLJ_Series = JsonUtil.GetInt(OBHAFLMHAKG, "series", 1);
			AHMOGDDPIFL_LastVfId = JsonUtil.GetInt(OBHAFLMHAKG, "lastVfId", 1);
			NOHNDOIKIJK_ShowInfoBits = JsonUtil.GetInt(OBHAFLMHAKG, "showInfoBits", 0);
			GHKKEFGDIBC_LastVFP_Unlock = JsonUtil.GetInt(OBHAFLMHAKG, "lastVFP_Unlock", 1);
			CHFMCFNEFEO_LastVOP_DailyLv = JsonUtil.GetInt(OBHAFLMHAKG, "lastVOP_DailyLv", 1);
			for(int i = 0; i < IDCCFDHKJNP_LastVOP_DivaLv.Length; i++)
			{
				IDCCFDHKJNP_LastVOP_DivaLv[i] = JsonUtil.GetInt(OBHAFLMHAKG, IAMECBIFIKA("lastVOP_DivaLv_{0:D2}", i), 2);
			}
			PCLGJLABHKG_DivaOfferInfo.AHHJLDLAPAN_DivaId = JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_divaId", 0);
			PCLGJLABHKG_DivaOfferInfo.MLDPDLPHJPM_OfferId = JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_offerId", 0);
			PCLGJLABHKG_DivaOfferInfo.MBALOBPODGA_DivaName = JsonUtil.GetString(OBHAFLMHAKG, "divaOfferInfo_divaName", "");
			PCLGJLABHKG_DivaOfferInfo.PGOGHFDBIBA_OfferName = JsonUtil.GetString(OBHAFLMHAKG, "divaOfferInfo_offerName", "");
			PCLGJLABHKG_DivaOfferInfo.PNOBKANLFHA_OfferText = JsonUtil.GetString(OBHAFLMHAKG, "divaOfferInfo_offerText", "");
			PCLGJLABHKG_DivaOfferInfo.OAFPGJLCNFM_Cond = (BOPFPIHGJMD.LEIPFJHOFPC)JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_cond", 0);
			PCLGJLABHKG_DivaOfferInfo.KFEMFDFPCGO_Level0 = JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_level0", 0);
			PCLGJLABHKG_DivaOfferInfo.CIEOBFIIPLD_Level = JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_level", 0);
			PCLGJLABHKG_DivaOfferInfo.NBHEBLNHOJO_IsMaxLevel = JsonUtil.GetInt(OBHAFLMHAKG, "divaOfferInfo_isMaxLevel", 0) > 0;
		}

		//// RVA: 0x201DBEC Offset: 0x201DBEC VA: 0x201DBEC
		private string IAMECBIFIKA(string IPHJGHDONAN, int OIPCCBHIKIA)
		{
			KKELPILEDDD.SetFormat(IPHJGHDONAN, OIPCCBHIKIA);
			return KKELPILEDDD.ToString();
		}
	}
	
	public class ICEOHGGIBBE_ChatCommon
	{
		private const string DMJOEJOJOBI = "Chat_iconState";
		public bool OCFJGGFPIBK_ChatIconState = true; // 0x8

		// RVA: 0x202BF68 Offset: 0x202BF68 VA: 0x202BF68
		public ICEOHGGIBBE_ChatCommon()
		{
			return;
		}

		// RVA: 0x202BF78 Offset: 0x202BF78 VA: 0x202BF78
		public ICEOHGGIBBE_ChatCommon(bool OCFJGGFPIBK)
		{
			this.OCFJGGFPIBK_ChatIconState = OCFJGGFPIBK;
		}

		//// RVA: 0x202BFA4 Offset: 0x202BFA4 VA: 0x202BFA4
		public void ODDIHGPONFL(ICEOHGGIBBE_ChatCommon DNNHDJPNIAK)
		{
			DNNHDJPNIAK.OCFJGGFPIBK_ChatIconState = OCFJGGFPIBK_ChatIconState;
		}

		//// RVA: 0x202BFCC Offset: 0x202BFCC VA: 0x202BFCC
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			OCFJGGFPIBK_ChatIconState = JsonUtil.GetInt(OBHAFLMHAKG, DMJOEJOJOBI, 0) > 0;
		}

		//// RVA: 0x202C060 Offset: 0x202C060 VA: 0x202C060
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["Chat_iconState"] = OCFJGGFPIBK_ChatIconState ? 1 : 0;
			return res;
		}

		//// RVA: 0x202C138 Offset: 0x202C138 VA: 0x202C138
		public static bool CHDGLBBFEKH_IsEqual(ICEOHGGIBBE_ChatCommon ILEKEPJBFDP, ICEOHGGIBBE_ChatCommon GEPALDIIDPC)
		{
			if (ILEKEPJBFDP.OCFJGGFPIBK_ChatIconState == GEPALDIIDPC.OCFJGGFPIBK_ChatIconState)
				return true;
			return false;
		}

		//// RVA: 0x202C18C Offset: 0x202C18C VA: 0x202C18C
		public static bool HMMFJOEBEKJ(ICEOHGGIBBE_ChatCommon ILEKEPJBFDP, ICEOHGGIBBE_ChatCommon GEPALDIIDPC)
		{
			return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
		}
	}
	
	public class EIHCEKNKHJB_ValkyrieTuneUp
	{
		public int IHAHBHEDIAK_SelectVfId = 1; // 0x8

		//// RVA: 0x2029A98 Offset: 0x2029A98 VA: 0x2029A98
		public static bool CHDGLBBFEKH_IsEqual(EIHCEKNKHJB_ValkyrieTuneUp LFGLBIAODLE, EIHCEKNKHJB_ValkyrieTuneUp CJDJGHIIBHP)
		{
			if (LFGLBIAODLE.IHAHBHEDIAK_SelectVfId == CJDJGHIIBHP.IHAHBHEDIAK_SelectVfId)
				return true;
			return false;
		}

		//// RVA: 0x2029AE0 Offset: 0x2029AE0 VA: 0x2029AE0
		public static bool HMMFJOEBEKJ(EIHCEKNKHJB_ValkyrieTuneUp LFGLBIAODLE, EIHCEKNKHJB_ValkyrieTuneUp CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x2029AF4 Offset: 0x2029AF4 VA: 0x2029AF4
		public void ODDIHGPONFL(EIHCEKNKHJB_ValkyrieTuneUp PJFKNNNDMIA)
		{
			PJFKNNNDMIA.IHAHBHEDIAK_SelectVfId = IHAHBHEDIAK_SelectVfId;
		}

		//// RVA: 0x2029B1C Offset: 0x2029B1C VA: 0x2029B1C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["selectVfId"] = IHAHBHEDIAK_SelectVfId;
			return res;
		}

		// RVA: 0x2029BF0 Offset: 0x2029BF0 VA: 0x2029BF0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			IHAHBHEDIAK_SelectVfId = JsonUtil.GetInt(OBHAFLMHAKG, "selectVfId", 1);
		}
	}
	
	public class FIDNFICGLEE_LimitedItemWarning
	{
		public long DIKBJMJBOIL_RateUpDate = 0; // 0x8
		public long HCKHMGNIKMB_GachaTicketDate = 0; // 0x10
		public long LANFKFKIADL_LogboGachaTicketDate = 0; // 0x18
		public long NKJODNGKFPB_LimitedItemGachaTicketDate = 0; // 0x20
		public long LDKICHJMLOH_PassGachaTicketDate = 0; // 0x28
		public long KFPALNAJJBP_EventGachaTicketDate = 0; // 0x30

		//// RVA: 0x2029C98 Offset: 0x2029C98 VA: 0x2029C98
		public static bool CHDGLBBFEKH_IsEqual(FIDNFICGLEE_LimitedItemWarning LFGLBIAODLE, FIDNFICGLEE_LimitedItemWarning CJDJGHIIBHP)
		{
			if (LFGLBIAODLE.DIKBJMJBOIL_RateUpDate == CJDJGHIIBHP.DIKBJMJBOIL_RateUpDate &&
				LFGLBIAODLE.HCKHMGNIKMB_GachaTicketDate == CJDJGHIIBHP.HCKHMGNIKMB_GachaTicketDate &&
				LFGLBIAODLE.LANFKFKIADL_LogboGachaTicketDate == CJDJGHIIBHP.LANFKFKIADL_LogboGachaTicketDate &&
				LFGLBIAODLE.NKJODNGKFPB_LimitedItemGachaTicketDate == CJDJGHIIBHP.NKJODNGKFPB_LimitedItemGachaTicketDate &&
				LFGLBIAODLE.LDKICHJMLOH_PassGachaTicketDate == CJDJGHIIBHP.LDKICHJMLOH_PassGachaTicketDate &&
				LFGLBIAODLE.KFPALNAJJBP_EventGachaTicketDate == CJDJGHIIBHP.KFPALNAJJBP_EventGachaTicketDate)
				return true;
			return false;
		}

		//// RVA: 0x2029D68 Offset: 0x2029D68 VA: 0x2029D68
		public static bool HMMFJOEBEKJ(FIDNFICGLEE_LimitedItemWarning LFGLBIAODLE, FIDNFICGLEE_LimitedItemWarning CJDJGHIIBHP)
		{
			return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
		}

		//// RVA: 0x2029D7C Offset: 0x2029D7C VA: 0x2029D7C
		public void ODDIHGPONFL(FIDNFICGLEE_LimitedItemWarning PJFKNNNDMIA)
		{
			PJFKNNNDMIA.DIKBJMJBOIL_RateUpDate = DIKBJMJBOIL_RateUpDate;
			PJFKNNNDMIA.HCKHMGNIKMB_GachaTicketDate = HCKHMGNIKMB_GachaTicketDate;
			PJFKNNNDMIA.LANFKFKIADL_LogboGachaTicketDate = LANFKFKIADL_LogboGachaTicketDate;
			PJFKNNNDMIA.NKJODNGKFPB_LimitedItemGachaTicketDate = NKJODNGKFPB_LimitedItemGachaTicketDate;
			PJFKNNNDMIA.LDKICHJMLOH_PassGachaTicketDate = LDKICHJMLOH_PassGachaTicketDate;
			PJFKNNNDMIA.KFPALNAJJBP_EventGachaTicketDate = KFPALNAJJBP_EventGachaTicketDate;
		}

		//// RVA: 0x2029E80 Offset: 0x2029E80 VA: 0x2029E80
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["rare_up_date"] = DIKBJMJBOIL_RateUpDate;
			res["gacha_ticket_date"] = HCKHMGNIKMB_GachaTicketDate;
			res["logbo_gacha_ticket_date"] = LANFKFKIADL_LogboGachaTicketDate;
			res["limited_item_gacha_ticket_date"] = NKJODNGKFPB_LimitedItemGachaTicketDate;
			res["pass_gacha_ticket_date"] = LDKICHJMLOH_PassGachaTicketDate;
			res["event_gacha_ticket_date"] = KFPALNAJJBP_EventGachaTicketDate;
			return res;
		}

		// RVA: 0x202A098 Offset: 0x202A098 VA: 0x202A098
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			DIKBJMJBOIL_RateUpDate = JsonUtil.GetInt(OBHAFLMHAKG, "rare_up_date", 0);
			HCKHMGNIKMB_GachaTicketDate = JsonUtil.GetInt(OBHAFLMHAKG, "gacha_ticket_date", 0);
			LANFKFKIADL_LogboGachaTicketDate = JsonUtil.GetInt(OBHAFLMHAKG, "logbo_gacha_ticket_date", 0);
			NKJODNGKFPB_LimitedItemGachaTicketDate = JsonUtil.GetInt(OBHAFLMHAKG, "limited_item_gacha_ticket_date", 0);
			LDKICHJMLOH_PassGachaTicketDate = JsonUtil.GetInt(OBHAFLMHAKG, "pass_gacha_ticket_date", 0);
			KFPALNAJJBP_EventGachaTicketDate = JsonUtil.GetInt(OBHAFLMHAKG, "event_gacha_ticket_date", 0);
		}
	}
	
	public class AKKDKBOBKGH_AprilFool
	{
		public class OEAIOIHGMIH
		{
			private int FBGGEFFJJHB = 0x4a73b2f1; // 0x8
			private int NFFKLFEOPMO_EventId = 0; // 0xC
			private int NPIKKEHOKOG_HighScoreCrypted = 0x4a73b2f1; // 0x10
			private bool BLGHBBEDGML_IsUseCommand = false; // 0x14

			private int LGDLEHHOIEL_HighScore { get { return NPIKKEHOKOG_HighScoreCrypted ^ FBGGEFFJJHB; } set { NPIKKEHOKOG_HighScoreCrypted = value ^ FBGGEFFJJHB; } } //0x201E6E8 OMFCCEBAODD 0x201E6F8 JGIJCMFGKEP

			//// RVA: 0x201E708 Offset: 0x201E708 VA: 0x201E708
			public static bool CHDGLBBFEKH(OEAIOIHGMIH LFGLBIAODLE, OEAIOIHGMIH CJDJGHIIBHP)
			{
				if (LFGLBIAODLE.NFFKLFEOPMO_EventId == CJDJGHIIBHP.NFFKLFEOPMO_EventId &&
					LFGLBIAODLE.LGDLEHHOIEL_HighScore == CJDJGHIIBHP.LGDLEHHOIEL_HighScore &&
					LFGLBIAODLE.BLGHBBEDGML_IsUseCommand == CJDJGHIIBHP.BLGHBBEDGML_IsUseCommand)
					return true;
				return false;
			}

			//// RVA: 0x201E158 Offset: 0x201E158 VA: 0x201E158
			public static bool HMMFJOEBEKJ(OEAIOIHGMIH LFGLBIAODLE, OEAIOIHGMIH CJDJGHIIBHP)
			{
				return !CHDGLBBFEKH(LFGLBIAODLE, CJDJGHIIBHP);
			}

			//// RVA: 0x201E1C4 Offset: 0x201E1C4 VA: 0x201E1C4
			public void ODDIHGPONFL(OEAIOIHGMIH PJFKNNNDMIA)
			{
				PJFKNNNDMIA.NFFKLFEOPMO_EventId = NFFKLFEOPMO_EventId;
				PJFKNNNDMIA.LGDLEHHOIEL_HighScore = LGDLEHHOIEL_HighScore;
				PJFKNNNDMIA.BLGHBBEDGML_IsUseCommand = BLGHBBEDGML_IsUseCommand;
			}

			//// RVA: 0x201E2F0 Offset: 0x201E2F0 VA: 0x201E2F0
			public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["eventId"] = NFFKLFEOPMO_EventId;
				res["highScore"] = LGDLEHHOIEL_HighScore;
				res["isUseCommand"] = BLGHBBEDGML_IsUseCommand ? 1 : 0;
				return res;
			}

			//// RVA: 0x201E540 Offset: 0x201E540 VA: 0x201E540
			public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
			{
				NFFKLFEOPMO_EventId = JsonUtil.GetInt(OBHAFLMHAKG, "eventId", 0);
				LGDLEHHOIEL_HighScore = JsonUtil.GetInt(OBHAFLMHAKG, "highScore", 0);
				BLGHBBEDGML_IsUseCommand = JsonUtil.GetInt(OBHAFLMHAKG, "isUseCommand", 0) > 0;
			}

			//// RVA: 0x201E794 Offset: 0x201E794 VA: 0x201E794
			public bool FKEJBAHCMGC(int LHMJFCCBPPN)
			{
				if(NFFKLFEOPMO_EventId != LHMJFCCBPPN)
				{
					BLGHBBEDGML_IsUseCommand = false;
					NFFKLFEOPMO_EventId = LHMJFCCBPPN;
					LGDLEHHOIEL_HighScore = 0;
					return true;
				}
				return false;
			}

			//// RVA: 0x201E7C4 Offset: 0x201E7C4 VA: 0x201E7C4
			public int LJKLECGFIEN_GetHighScore()
			{
				return LGDLEHHOIEL_HighScore;
			}

			//// RVA: 0x201E7D4 Offset: 0x201E7D4 VA: 0x201E7D4
			public void BIEBAEDGDIA_SetHighScore(int LGDLEHHOIEL)
			{
				LGDLEHHOIEL_HighScore = LGDLEHHOIEL;
			}

			//// RVA: 0x201E7E4 Offset: 0x201E7E4 VA: 0x201E7E4
			public bool PFBGBGLGBLA_GetIsUseCommand()
			{
				return BLGHBBEDGML_IsUseCommand;
			}

			//// RVA: 0x201E7EC Offset: 0x201E7EC VA: 0x201E7EC
			public void JBCCMOKKCPA_SetIsUseCommand(bool CHPIFIEEEEC)
			{
				BLGHBBEDGML_IsUseCommand = CHPIFIEEEEC;
			}
		}

		public OEAIOIHGMIH MNKOCOODFKH_MiniGameShooting = new OEAIOIHGMIH(); // 0x8

		//// RVA: 0x201E114 Offset: 0x201E114 VA: 0x201E114
		public static bool CHDGLBBFEKH_IsEqual(AKKDKBOBKGH_AprilFool LFGLBIAODLE, AKKDKBOBKGH_AprilFool CJDJGHIIBHP)
		{
			if (OEAIOIHGMIH.CHDGLBBFEKH(LFGLBIAODLE.MNKOCOODFKH_MiniGameShooting, CJDJGHIIBHP.MNKOCOODFKH_MiniGameShooting))
				return true;
			return false;
		}

		//// RVA: 0x201E16C Offset: 0x201E16C VA: 0x201E16C
		//public static bool HMMFJOEBEKJ(ILDKBCLAFPB.AKKDKBOBKGH LFGLBIAODLE, ILDKBCLAFPB.AKKDKBOBKGH CJDJGHIIBHP) { }

		//// RVA: 0x201E180 Offset: 0x201E180 VA: 0x201E180
		public void ODDIHGPONFL(AKKDKBOBKGH_AprilFool PJFKNNNDMIA)
		{
			MNKOCOODFKH_MiniGameShooting.ODDIHGPONFL(PJFKNNNDMIA.MNKOCOODFKH_MiniGameShooting);
		}

		//// RVA: 0x201E230 Offset: 0x201E230 VA: 0x201E230
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["miniGameShooting"] = MNKOCOODFKH_MiniGameShooting.NOJCMGAFAAC();
			return res;
		}

		//// RVA: 0x201E480 Offset: 0x201E480 VA: 0x201E480
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			if (!OBHAFLMHAKG.BBAJPINMOEP_Contains("miniGameShooting"))
				return;
			MNKOCOODFKH_MiniGameShooting.KHEKNNFCAOI(OBHAFLMHAKG["miniGameShooting"]);
		}
	}


	private static Action<IPHAEFKCNMN>[] BKDGANJBPPG; // 0x0
	private CipherRijndael MIDAHPPDINB; // 0x8
	private const string AGLECLBEGCE = "SaveData";
	private const string EDAOODPKLLI = "save.bin";
	private IPHAEFKCNMN GLANNFOPMDO_Save; // 0xC
	private IPHAEFKCNMN CGFIFBHIBCF_SavedCache; // 0x10

	// public ILDKBCLAFPB.IPHAEFKCNMN NDILDEKOCOP { get; } // ??
	// private ILDKBCLAFPB.IPHAEFKCNMN KBFFAEDDLKA { get; } // ??

	// // RVA: 0x20199AC Offset: 0x20199AC VA: 0x20199AC
	public static int JLLFHBIJNPC_GetVersion()
    {
        return BKDGANJBPPG.Length;
    }

	// // RVA: 0x2019A4C Offset: 0x2019A4C VA: 0x2019A4C
	private static void AAPCFCKIFND_PatchV1(IPHAEFKCNMN NHLBKJCPLBL)
    {
		NHLBKJCPLBL.CNLJNGLMMHB_Options.IBEINHHMHAC_VolNotesRhythm = Mathf.Clamp(NHLBKJCPLBL.CNLJNGLMMHB_Options.IBEINHHMHAC_VolNotesRhythm - 7, 0, 20);
	}

	// // RVA: 0x2019B34 Offset: 0x2019B34 VA: 0x2019B34
	private static void IBMGEHJHHPK_PatchV2(ILDKBCLAFPB.IPHAEFKCNMN NHLBKJCPLBL)
    {
        NHLBKJCPLBL.CNLJNGLMMHB_Options.IBEINHHMHAC_VolNotesRhythm = Mathf.Clamp(Mathf.RoundToInt((NHLBKJCPLBL.CNLJNGLMMHB_Options.IBEINHHMHAC_VolNotesRhythm * 5.0f + 35.0f) / 6.75f), 0, 20);
	}

	// // RVA: 0x2019C30 Offset: 0x2019C30 VA: 0x2019C30
	public ILDKBCLAFPB(string GMEFFNIMFIF, string CDPAMAOOHNF)
    {
        GLANNFOPMDO_Save = new IPHAEFKCNMN();
        CGFIFBHIBCF_SavedCache = new IPHAEFKCNMN();
        MIDAHPPDINB = new CipherRijndael(GMEFFNIMFIF, CDPAMAOOHNF);
    }

	// // RVA: 0x201A168 Offset: 0x201A168 VA: 0x201A168
	public ILDKBCLAFPB.IPHAEFKCNMN EPJOACOONAC_GetSave()
    {
        return GLANNFOPMDO_Save;
    }

	// // RVA: 0x201A170 Offset: 0x201A170 VA: 0x201A170
	// private ILDKBCLAFPB.IPHAEFKCNMN BDHDGOOLBDE() { }

	// // RVA: 0x201A178 Offset: 0x201A178 VA: 0x201A178
	// public void OEGPHLDDFDF() { }

	// // RVA: 0x201A184 Offset: 0x201A184 VA: 0x201A184
	public void LHPDDGIJKNB_Reset()
	{
		GLANNFOPMDO_Save = new IPHAEFKCNMN();
		CGFIFBHIBCF_SavedCache = new IPHAEFKCNMN();
	}

	// // RVA: 0x201A204 Offset: 0x201A204 VA: 0x201A204
	public bool HJMKBCFJOOH_TrySave()
    {
		if(!IPHAEFKCNMN.CHDGLBBFEKH_IsEqual(GLANNFOPMDO_Save, CGFIFBHIBCF_SavedCache) && KPOCKNCJBPN_CheckSecure() == null)
		{
			JCHBCPEPFKE_CreateSaveDirectory();
			JCOILDLEPDP_SaveToPath(DMCLJKABBCJ_GetSavePath(), MIDAHPPDINB.EncryptToBase64(GLANNFOPMDO_Save.EJCOJCGIBNG()));
			GLANNFOPMDO_Save.ODDIHGPONFL_Copy(CGFIFBHIBCF_SavedCache);
			if (RuntimeSettings.CurrentSettings.EnableLocalSaveCheck)
			{
				if(!IPHAEFKCNMN.CHDGLBBFEKH_IsEqual(GLANNFOPMDO_Save, CGFIFBHIBCF_SavedCache))
				{
					UnityEngine.Debug.LogError("Local save was not copied correctly");
					File.WriteAllText(Application.persistentDataPath + "/Local1.txt", GLANNFOPMDO_Save.EJCOJCGIBNG());
					File.WriteAllText(Application.persistentDataPath + "/Local2.txt", CGFIFBHIBCF_SavedCache.EJCOJCGIBNG());
				}
				IPHAEFKCNMN t = new IPHAEFKCNMN();
				GLANNFOPMDO_Save.ODDIHGPONFL_Copy(t);
				PCODDPDFLHK_Load();
				if(!IPHAEFKCNMN.CHDGLBBFEKH_IsEqual(GLANNFOPMDO_Save, t))
				{
					UnityEngine.Debug.LogError("Local save was not save correctly");
					File.WriteAllText(Application.persistentDataPath + "/Local1.txt", GLANNFOPMDO_Save.EJCOJCGIBNG());
					File.WriteAllText(Application.persistentDataPath + "/Local2.txt", t.EJCOJCGIBNG());
				}
			}
			return true;
		}
        return false;
    }

	// // RVA: 0x201ABAC Offset: 0x201ABAC VA: 0x201ABAC
	public EJFLCPHPMCA PCODDPDFLHK_Load()
    {
        string s = DNHFPLJMIPI_ReadFromPath(DMCLJKABBCJ_GetSavePath());
        if(s == null)
        {
            GLANNFOPMDO_Save.HKGPAMEKGKG_Header.BOGMEEOOADP();
            return ILDKBCLAFPB.EJFLCPHPMCA.MKOILBFAONG;
        }
        else
        {
            GLANNFOPMDO_Save = new IPHAEFKCNMN();
            GLANNFOPMDO_Save.NFDEBEJFNGD(MIDAHPPDINB.DecryptFromBase64(s));
            GLANNFOPMDO_Save.ODDIHGPONFL_Copy(CGFIFBHIBCF_SavedCache);
			return ILDKBCLAFPB.EJFLCPHPMCA.JIMDHEJOPBK;
        }
    }

	// // RVA: 0x201B244 Offset: 0x201B244 VA: 0x201B244
	// public void BLICHJOLKAO() { }

	// // RVA: 0x201A3D8 Offset: 0x201A3D8 VA: 0x201A3D8
	// private bool JMCDHAGAPIP() { }

	// // RVA: 0x201A434 Offset: 0x201A434 VA: 0x201A434
	private void JCHBCPEPFKE_CreateSaveDirectory()
	{
		if (Directory.Exists(KJEOLHCEDJI_GetSaveDirectory()))
			return;
		Directory.CreateDirectory(KJEOLHCEDJI_GetSaveDirectory());
	}

	// // RVA: 0x201A3F8 Offset: 0x201A3F8 VA: 0x201A3F8
	public FENCAJJBLBH KPOCKNCJBPN_CheckSecure()
	{
		return GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.KPOCKNCJBPN_CheckSecure();
	}

	// // RVA: 0x201B284 Offset: 0x201B284 VA: 0x201B284
	private string KJEOLHCEDJI_GetSaveDirectory()
	{
		return Application.persistentDataPath + "/SaveData";
	}

	// // RVA: 0x201A538 Offset: 0x201A538 VA: 0x201A538
	private string DMCLJKABBCJ_GetSavePath()
    {
		int playerId = UMO_PlayerPrefs.GetInt("cpid", 0);
        return Application.persistentDataPath + "/SaveData/"+playerId+"_save.bin";
    }
	
	// // RVA: 0x201AE10 Offset: 0x201AE10 VA: 0x201AE10
	private string DNHFPLJMIPI_ReadFromPath(string HDMOIHHPJEA)
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
	private void JCOILDLEPDP_SaveToPath(string HDMOIHHPJEA_Path, string GPBPBJFBOHL_Data)
	{
		StreamWriter writer = new StreamWriter(HDMOIHHPJEA_Path, false);
		writer.WriteLine(GPBPBJFBOHL_Data);
		writer.Close();
		writer.Dispose();
	}

	// // RVA: 0x201B314 Offset: 0x201B314 VA: 0x201B314
	public void FBCDKFENOEM_SyncFlagsFromServer()
	{
		EGOLBAPFHHD_Common saveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
		int f = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.BCGHBIMJOFP_Count();
		for(int i = 0; i < f; i++)
		{
			bool b = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(i);
			bool b2 = saveCommon.KPPMKBEHKLK_IsShowTipsFlag(i);
			if (!(!b2 && !b))
			{
				saveCommon.KFFFMJDEJOP_SetShowTipsFlag(i, true);
			}
			else if(b2 && !b)
			{
				GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.EDEDFDDIOKO_SetTrue(i);
			}
		}
		f = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.PNNHEOOJBFI_TutorialGeneralFlags.BCGHBIMJOFP_Count();
		for (int i = 0; i < f; i++)
		{
			bool b = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(i);
			bool b2 = saveCommon.PBKPEGCIPME_IsShowTipsSubFlag(i);
			if (!(!b2 && !b))
			{
				saveCommon.DMNGICGDFAO_SetShowTipsSubFlag(i, true);
			}
			else if (b2 && !b)
			{
				GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.EDEDFDDIOKO_SetTrue(i);
			}
		}
		f = GLANNFOPMDO_Save.LPBFPCGDOGC_Anketo.FHEJNGDFMAI_AnswerFlags.BCGHBIMJOFP_Count();
		for (int i = 0; i < f; i++)
		{
			bool b = GLANNFOPMDO_Save.LPBFPCGDOGC_Anketo.FHEJNGDFMAI_AnswerFlags.ODKIHPBEOEC_IsTrue(i);
			bool b2 = saveCommon.JPIDBKDPFLM_IsShowAnketoFlag(i);
			if (!(!b2 && !b))
			{
				saveCommon.BDMJHCCGIED_SetShowAnketoFlag(i, true);
			}
			else if (b2 && !b)
			{
				GLANNFOPMDO_Save.LPBFPCGDOGC_Anketo.FHEJNGDFMAI_AnswerFlags.EDEDFDDIOKO_SetTrue(i);
			}
		}
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt < GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.JKHNILLPKBO_LCnt)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.JKHNILLPKBO_LCnt;
		}
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt < GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.HLKKGIKPLOM_LDay)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt = GLANNFOPMDO_Save.IAHLNPMFJMH_Tutorial.HLKKGIKPLOM_LDay;
		}
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.IPJPAAFNAOF_Psh = GLANNFOPMDO_Save.BOJCCICAHJK_Notification.OLBKCGKDBBL_TimeSlotAndBoss;
	}

	// // RVA: 0x201BB54 Offset: 0x201BB54 VA: 0x201BB54
	static ILDKBCLAFPB()
    {
        BKDGANJBPPG = new Action<IPHAEFKCNMN>[2];
        BKDGANJBPPG[0] = AAPCFCKIFND_PatchV1;
        BKDGANJBPPG[1] = IBMGEHJHHPK_PatchV2;
    }
}

public class FLGABCAPFEC<T> // TypeDefIndex: 7782
{
	protected List<T> DOBDFAGOIJK_List; // 0x0

	// RVA: -1 Offset: -1
	public static bool CHDGLBBFEKH_IsEqual(FLGABCAPFEC<T> LFGLBIAODLE, FLGABCAPFEC<T> CJDJGHIIBHP)
	{
		//if (LFGLBIAODLE.DOBDFAGOIJK_List.Equals(CJDJGHIIBHP.DOBDFAGOIJK_List))
		if (System.Linq.Enumerable.SequenceEqual<T>(LFGLBIAODLE.DOBDFAGOIJK_List, CJDJGHIIBHP.DOBDFAGOIJK_List))
			return true;
		return false;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC6CC Offset: 0x26BC6CC VA: 0x26BC6CC
	//|-FLGABCAPFEC<long>.CHDGLBBFEKH
	//|
	//|-RVA: 0x26BC968 Offset: 0x26BC968 VA: 0x26BC968
	//|-FLGABCAPFEC<object>.CHDGLBBFEKH
	//*/

	//// RVA: -1 Offset: -1
	public static bool HMMFJOEBEKJ(FLGABCAPFEC<T> LFGLBIAODLE, FLGABCAPFEC<T> CJDJGHIIBHP)
	{
		return !CHDGLBBFEKH_IsEqual(LFGLBIAODLE, CJDJGHIIBHP);
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC730 Offset: 0x26BC730 VA: 0x26BC730
	//|-FLGABCAPFEC<long>.HMMFJOEBEKJ
	//|
	//|-RVA: 0x26BC9CC Offset: 0x26BC9CC VA: 0x26BC9CC
	//|-FLGABCAPFEC<object>.HMMFJOEBEKJ
	//*/

	//// RVA: -1 Offset: -1
	public void ODDIHGPONFL(FLGABCAPFEC<T> PJFKNNNDMIA)
	{
		PJFKNNNDMIA.DOBDFAGOIJK_List.Clear();
		PJFKNNNDMIA.DOBDFAGOIJK_List.AddRange(DOBDFAGOIJK_List);
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC7A0 Offset: 0x26BC7A0 VA: 0x26BC7A0
	//|-FLGABCAPFEC<long>.ODDIHGPONFL
	//|
	//|-RVA: 0x26BCA3C Offset: 0x26BCA3C VA: 0x26BCA3C
	//|-FLGABCAPFEC<object>.ODDIHGPONFL
	//*/

	//// RVA: -1 Offset: -1
	//public T DEACAHNLMNI(int AOGDKBPNGCI) { }
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC828 Offset: 0x26BC828 VA: 0x26BC828
	//|-FLGABCAPFEC<long>.DEACAHNLMNI
	//|
	//|-RVA: 0x26BCAC4 Offset: 0x26BCAC4 VA: 0x26BCAC4
	//|-FLGABCAPFEC<object>.DEACAHNLMNI
	//*/

	//// RVA: -1 Offset: -1
	//public void DDALGNEFENM(int AOGDKBPNGCI, T CAEKKKJLIHP) { }
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC86C Offset: 0x26BC86C VA: 0x26BC86C
	//|-FLGABCAPFEC<long>.DDALGNEFENM
	//|
	//|-RVA: 0x26BCB08 Offset: 0x26BCB08 VA: 0x26BCB08
	//|-FLGABCAPFEC<object>.DDALGNEFENM
	//*/

	//// RVA: -1 Offset: -1 Slot: 4
	public virtual EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		return new EDOHBJAPLPF_JsonData();
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC8CC Offset: 0x26BC8CC VA: 0x26BC8CC
	//|-FLGABCAPFEC<long>.NOJCMGAFAAC
	//|
	//|-RVA: 0x26BCB54 Offset: 0x26BCB54 VA: 0x26BCB54
	//|-FLGABCAPFEC<object>.NOJCMGAFAAC
	//*/

	//// RVA: -1 Offset: -1 Slot: 5
	public virtual void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
	{
		return;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26BC938 Offset: 0x26BC938 VA: 0x26BC938
	//|-FLGABCAPFEC<long>.KHEKNNFCAOI
	//|
	//|-RVA: 0x26BCBC0 Offset: 0x26BCBC0 VA: 0x26BCBC0
	//|-FLGABCAPFEC<object>.KHEKNNFCAOI
	//*/
}

[System.Obsolete("Use DJJGOGFPCEA_Home", true)]
public class DJJGOGFPCEA { }
public class DJJGOGFPCEA_Home : FLGABCAPFEC<long>
{
	public enum MBLAHPBHIIA
	{
		MEIJJDFEFLJ = 0,
		CKPGGPDJCAL = 1,
	}

	public const long FFPCMGNMHOF = -1;
	protected StringBuilder AEBKEEBPNIJ = new StringBuilder(16); // 0xC

	// RVA: 0x198CFE8 Offset: 0x198CFE8 VA: 0x198CFE8
	public DJJGOGFPCEA_Home()
	{
		DOBDFAGOIJK_List = new List<long>(1);
		DOBDFAGOIJK_List.Add(-1);
	}

	//// RVA: 0x198D0E8 Offset: 0x198D0E8 VA: 0x198D0E8 Slot: 4
	public override EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res[LAPEABGEEKP(0)] = DOBDFAGOIJK_List[0];
		return res;
	}

	//// RVA: 0x198D2C4 Offset: 0x198D2C4 VA: 0x198D2C4 Slot: 5
	public override void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData IOMPKKGKCLF)
	{
		DOBDFAGOIJK_List[0] = JsonUtil.GetLong(IOMPKKGKCLF, LAPEABGEEKP(0), -1);
	}

	//// RVA: 0x198D204 Offset: 0x198D204 VA: 0x198D204
	private string LAPEABGEEKP(int OFGAFPOFKOG)
	{
		AEBKEEBPNIJ.SetFormat("home_scene_id_{0:D4}", OFGAFPOFKOG);
		return AEBKEEBPNIJ.ToString();
	}

	//// RVA: 0x198D388 Offset: 0x198D388 VA: 0x198D388
	public bool MBHHHMCCOLI(long OFCBCEKFAMJ)
	{
		if(DOBDFAGOIJK_List[0] != -1)
		{
			if (OFCBCEKFAMJ < DOBDFAGOIJK_List[0])
				return false;
			HBGKPLDGGLF(-1);
		}
		return true;
	}

	//// RVA: 0x198D448 Offset: 0x198D448 VA: 0x198D448
	public void HBGKPLDGGLF(long BBFAAIDPIJM)
	{
		DOBDFAGOIJK_List[0] = BBFAAIDPIJM;
	}
}

