
using XeSys;

[System.Obsolete("Use BEJIKEOAJHN_OptionSLive", true)]
public class BEJIKEOAJHN {}
public class BEJIKEOAJHN_OptionSLive
{
	public const int CDFANKJIPJL = 8;
	public int LMDACNNJDOE_VolSeRhythm = 15; // 0x8
	public int ICGAOAFIHFD_VolBgmRhythm = 15; // 0xC
	public int FCKEDCKCEFC_VolVoiceRhythm = 15; // 0x10 // init 0x80000000f; inversed?
	public int IBEINHHMHAC_VolNotesRhythm = 8; // 0x14
	public int DDHCLNFPNGK_RenderQuality = 1; // 0x18
	public int HHMCIGLCBNG_QualityCustomDiva3D; // 0x1C
	public int AHLFOHJMGAI_QualityCustomOther3D; // 0x20
	public int DADIPGPHLDD_EffectCutin = 1; // 0x24

	// // RVA: 0xC756D8 Offset: 0xC756D8 VA: 0xC756D8
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
	{
		LMDACNNJDOE_VolSeRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volSeRhythm", 15);
		ICGAOAFIHFD_VolBgmRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volBgmRhythm", 15);
		FCKEDCKCEFC_VolVoiceRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volVoiceRhythm", 15);
		IBEINHHMHAC_VolNotesRhythm = JsonUtil.GetInt(OBHAFLMHAKG, "volNotesRhythm", 11);
		DDHCLNFPNGK_RenderQuality = JsonUtil.GetInt(OBHAFLMHAKG, "renderQuality", 1);
		HHMCIGLCBNG_QualityCustomDiva3D = JsonUtil.GetInt(OBHAFLMHAKG, "qualityCustomDiva3D", 0);
		AHLFOHJMGAI_QualityCustomOther3D = JsonUtil.GetInt(OBHAFLMHAKG, "qualityCustomOther3D", 0);
		DADIPGPHLDD_EffectCutin = JsonUtil.GetInt(OBHAFLMHAKG, "effectCutin", 1);
		if(RuntimeSettings.CurrentSettings.ForceCutin)
			DADIPGPHLDD_EffectCutin = 0;
	}

	// // RVA: 0xC75848 Offset: 0xC75848 VA: 0xC75848
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res["volSeRhythm"] = LMDACNNJDOE_VolSeRhythm;
		res["volBgmRhythm"] = ICGAOAFIHFD_VolBgmRhythm;
		res["volVoiceRhythm"] = FCKEDCKCEFC_VolVoiceRhythm;
		res["volNotesRhythm"] = IBEINHHMHAC_VolNotesRhythm;
		res["renderQuality"] = DDHCLNFPNGK_RenderQuality;
		res["qualityCustomDiva3D"] = HHMCIGLCBNG_QualityCustomDiva3D;
		res["qualityCustomOther3D"] = AHLFOHJMGAI_QualityCustomOther3D;
		res["effectCutin"] = DADIPGPHLDD_EffectCutin;
		return res;
	}

	// // RVA: 0xC75ADC Offset: 0xC75ADC VA: 0xC75ADC
	public static bool CHDGLBBFEKH_IsEqual(BEJIKEOAJHN_OptionSLive ILEKEPJBFDP, BEJIKEOAJHN_OptionSLive GEPALDIIDPC)
	{
		return ILEKEPJBFDP.LMDACNNJDOE_VolSeRhythm == GEPALDIIDPC.LMDACNNJDOE_VolSeRhythm &&
				ILEKEPJBFDP.ICGAOAFIHFD_VolBgmRhythm == GEPALDIIDPC.ICGAOAFIHFD_VolBgmRhythm &&
				ILEKEPJBFDP.FCKEDCKCEFC_VolVoiceRhythm == GEPALDIIDPC.FCKEDCKCEFC_VolVoiceRhythm &&
				ILEKEPJBFDP.IBEINHHMHAC_VolNotesRhythm == GEPALDIIDPC.IBEINHHMHAC_VolNotesRhythm &&
				ILEKEPJBFDP.DDHCLNFPNGK_RenderQuality == GEPALDIIDPC.DDHCLNFPNGK_RenderQuality &&
				ILEKEPJBFDP.HHMCIGLCBNG_QualityCustomDiva3D == GEPALDIIDPC.HHMCIGLCBNG_QualityCustomDiva3D &&
				ILEKEPJBFDP.AHLFOHJMGAI_QualityCustomOther3D == GEPALDIIDPC.AHLFOHJMGAI_QualityCustomOther3D &&
				ILEKEPJBFDP.DADIPGPHLDD_EffectCutin == GEPALDIIDPC.DADIPGPHLDD_EffectCutin;
	}

	// // RVA: 0xC75B9C Offset: 0xC75B9C VA: 0xC75B9C
	public static bool HMMFJOEBEKJ(BEJIKEOAJHN_OptionSLive ILEKEPJBFDP, BEJIKEOAJHN_OptionSLive GEPALDIIDPC)
	{
		return !CHDGLBBFEKH_IsEqual(ILEKEPJBFDP, GEPALDIIDPC);
	}

	// // RVA: 0xC75BB0 Offset: 0xC75BB0 VA: 0xC75BB0
	public void ODDIHGPONFL_Copy(BEJIKEOAJHN_OptionSLive FMKAONAMGCN)
	{
		FMKAONAMGCN.LMDACNNJDOE_VolSeRhythm = LMDACNNJDOE_VolSeRhythm;
		FMKAONAMGCN.ICGAOAFIHFD_VolBgmRhythm = ICGAOAFIHFD_VolBgmRhythm;
		FMKAONAMGCN.FCKEDCKCEFC_VolVoiceRhythm = FCKEDCKCEFC_VolVoiceRhythm;
		FMKAONAMGCN.IBEINHHMHAC_VolNotesRhythm = IBEINHHMHAC_VolNotesRhythm;
		FMKAONAMGCN.DDHCLNFPNGK_RenderQuality = DDHCLNFPNGK_RenderQuality;
		FMKAONAMGCN.HHMCIGLCBNG_QualityCustomDiva3D = HHMCIGLCBNG_QualityCustomDiva3D;
		FMKAONAMGCN.AHLFOHJMGAI_QualityCustomOther3D = AHLFOHJMGAI_QualityCustomOther3D;
		FMKAONAMGCN.DADIPGPHLDD_EffectCutin = DADIPGPHLDD_EffectCutin;
	}

}
