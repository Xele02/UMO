using XeSys;
using System.Collections.Generic;
using UnityEngine;
using System;
using CriWare;

public abstract class LBHFILLFAGA
{
	public enum PLINNKMECEF_State
	{
		NFFGMBBNNPH_0_None = 0,
		AMDJBGNGLDL_Start = 1,
		KEDMBDBJBKM_Success = 2,
		PNGOBECOOJM_Error = 3,
		JKONMHNBGLL_Cancel = 4,
	}

	public string BOPDLODALFD_withoutPlarformPath; // 0x18
	public string HHHEFALNMJO_mPath; // 0x1C
	private float JMHHKKFPPOL_time; // 0x48
	private static readonly byte[] ILINJKLDCJD = new byte[7] { 0x55, 0x6e, 0x69, 0x74, 0x79, 0x46, 0x53 }; // 0x0
	private static readonly byte[] MPNFIMBCMFK = new byte[4] { 0x40, 0x55, 0x54, 0x46 }; // 0x4
	private static readonly byte[] OBIKJLFDNJA = new byte[4] { 0x41, 0x46, 0x53, 0x32 }; // 0x8
	private static readonly byte[] NFIOLMJLGFM = new byte[4] { 0x43, 0x52, 0x49, 0x44 }; // 0xC
	private static readonly byte[] OPMNFNHOMJF = new byte[5] { 0x7b, 0x0a, 0x20, 0x20, 0x20 }; // 0x10
	private static readonly byte[] LLJJCPNHPFP = new byte[12] { 0x4d, 0x61, 0x6e, 0x69, 0x66, 0x65, 0x73, 0x74, 0x46, 0x69, 0x6c, 0x65 }; // 0x14
	private static readonly byte[] BGLBMKIKKKP = new byte[4] { 0x89, 0x50, 0x4e, 0x47 }; // 0x18
	private static readonly byte[] LEAAJEJAMMH = new byte[3] { 0xff, 0xd8, 0xff }; // 0x1C

	public FileLoadedPostProcess DAPCDNJBKBK_mSuccess { get; set; }  // 0x8 OGPIDJJJPDA_bgs ONKPBECIMIE_bgs JJHJMLAJLIL_bgs
	public FileLoadedPostProcess HAANPNDACPE_mFail { get; set; } // 0xC HEBMELACEOE_bgs OMFPAIIEMEF_bgs KKNOOFCBHGN_bgs
	protected FileResultObject IMGIFJHHEED_fro { get; set; } // 0x10 BJCPEOGAOCP_bgs LNDGEDHIEAF_bgs KDNEHECLIDH_bgs
	public int IIMBNNKHGOM { get; set; } // 0x14 HLAHGBEIIDC_bgs NBLBPKLLFHB_bgs JKGMAOLDLLM_bgs
	public bool FHHAFJMELMD_alreadyLoading { get; set; } // 0x20 KGPGOAPDCGM_bgs LGCBNNBFLLC_bgs HNKEGLMMFFH_bgs
	public int EAABKFGHKBG_TryCount { get; set; } // 0x24 PCCDLFDCFBG_bgs OACNBAPAKAA_bgs GMJKJICMLHI_bgs
	public byte NHJKENJIEME { get; set; } // 0x28 DIPNMHIKPKL_bgs ILBBLANOILG_bgs CEEPINBAEKO_bgs
	public float EBKOJBFMABH_elapsedTime { get; set; } // 0x2C NKIAIBHHPDL_bgs BMPPFIPBMBE_bgs BIILBBPMNBJ_bgs
	public CriFsBinder COIBJNACMFK { get; set; } // 0x30 NFIDNEPMMOK_bgs EBIJOIDBPIE_bgs GOKEIMCNGHB_bgs
	public BEEINMBNKNM_Encryption DMKAFCEJFDG_decryptor { get; set; } // 0x34 FKCKGBMNBPL_bgs LIMGNMMPKGF_bgs AKNAGKOHHCA_bgs
	public PLINNKMECEF_State LHMDABPNDDH_state { get; set; } // 0x38 JNOFANKGNGJ_bgs HMMFHMFLNAJ_bgs PBNPKEFIPKI_bgs
	public bool KCIDANFAFPP { get; set; } // 0x3C PJOGIHCDNCE_bgs KMEELELCBJJ_bgs HNDBDCPGMOM_bgs
	public float AJOAGOLGLAI { get; set; }  // 0x40 NEMPFIPLCMK_bgs IMNPGDHJKEN_bgs HODDHFFBNIL_bgs
	public bool PHOPDCNFFEI { get { return LHMDABPNDDH_state == PLINNKMECEF_State.PNGOBECOOJM_Error; } } // NPFACLDLOCJ_bgs 0xD98588
	public bool OJOLGGKILFL { get; set; } // 0x44 CLJDDDODKCD_bgs KKEOAGANMNA_bgs HHPCOOAPJJN_bgs

	// // RVA: 0xD985AC Offset: 0xD985AC VA: 0xD985AC
	public LBHFILLFAGA()
	{
		KCIDANFAFPP = false;
		OJOLGGKILFL = false;
		AJOAGOLGLAI = 1.0f;
		LHMDABPNDDH_state = PLINNKMECEF_State.NFFGMBBNNPH_0_None;
		FHHAFJMELMD_alreadyLoading = false;
		IIMBNNKHGOM = 0;
		JMHHKKFPPOL_time = 0.0f;
		EBKOJBFMABH_elapsedTime = 0.0f;
		NHJKENJIEME = 0;
		EAABKFGHKBG_TryCount = 0;
	}

	// // RVA: 0xD985F4 Offset: 0xD985F4 VA: 0xD985F4
	//path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi
	public LBHFILLFAGA(string _CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi)
	{
		KCIDANFAFPP = false;
		OJOLGGKILFL = false;
		AJOAGOLGLAI = 1.0f;
		LHMDABPNDDH_state = 0;
		EAABKFGHKBG_TryCount = 0;
		this.BOPDLODALFD_withoutPlarformPath = BOPDLODALFD_withoutPlarformPath;
		HHHEFALNMJO_mPath = _CJEKGLGBIHF_path;
		DAPCDNJBKBK_mSuccess = OGLMMENAJFL_onSuccess;
		HAANPNDACPE_mFail = GOIHDOPGPCE_onFail;
		if(LAMFBMFNOFP_fi == null)
		{
			IMGIFJHHEED_fro = new FileResultObject(_CJEKGLGBIHF_path,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue);
			FHHAFJMELMD_alreadyLoading = false;
		}
		else
		{
			IMGIFJHHEED_fro = LAMFBMFNOFP_fi.resultObject;
			FHHAFJMELMD_alreadyLoading = true;
		}
		IIMBNNKHGOM = _CJEKGLGBIHF_path.GetHashCode();
		EAABKFGHKBG_TryCount = 0;
		JMHHKKFPPOL_time = 0.0f;
		NHJKENJIEME = 0;
		EBKOJBFMABH_elapsedTime = 0.0f;
	}

	// // RVA: 0xD9872C Offset: 0xD9872C VA: 0xD9872C
	public void ODJCMJBNDOK_Start()
	{
		OJOLGGKILFL = false;
		LHMDABPNDDH_state = PLINNKMECEF_State.AMDJBGNGLDL_Start;
		if(FHHAFJMELMD_alreadyLoading)
			return;
		if(KCIDANFAFPP)
		{
			JMHHKKFPPOL_time = Time.realtimeSinceStartup;
			return;
		}
		BDALHEMDIDC_DoStart();
	}

	// // RVA: -1 Offset: -1 Slot: 4
	public abstract void BDALHEMDIDC_DoStart();

	// // RVA: -1 Offset: -1 Slot: 5
	public abstract bool GDEMPLAOGKK_IsDone();

	// // RVA: -1 Offset: -1 Slot: 6
	public abstract string LKPOPGJLPAJ_GetErrorStr();

	// // RVA: 0xD98788 Offset: 0xD98788 VA: 0xD98788 Slot: 7
	public virtual void GFCMEKDCCME_SetError()
	{
		IMGIFJHHEED_fro.error = LKPOPGJLPAJ_GetErrorStr();
	}

	// // RVA: 0xD987CC Offset: 0xD987CC VA: 0xD987CC Slot: 8
	public virtual void GMHKEJMLDDJ()
	{
		return;
	}

	// // RVA: 0xD987D0 Offset: 0xD987D0 VA: 0xD987D0
	public bool KIDJFNEGAHO_Ended()
	{
		if(!KCIDANFAFPP && !FHHAFJMELMD_alreadyLoading)
		{
			if(LKPOPGJLPAJ_GetErrorStr() != null)
			{
				OJOLGGKILFL = false;
				return false;
			}
		}
		if(MLMEOLAEJEL_DoLoadData())
		{
			OJOLGGKILFL = true;
			LHMDABPNDDH_state = PLINNKMECEF_State.KEDMBDBJBKM_Success;
			return true;
		}
		OJOLGGKILFL = false;
		return false;
	}

	// // RVA: 0xD9884C Offset: 0xD9884C VA: 0xD9884C
	public bool INODGGFPKOE_IsSuccess()
	{
		if(!KCIDANFAFPP && !FHHAFJMELMD_alreadyLoading)
		{
			return LKPOPGJLPAJ_GetErrorStr() == null;
		}
		return true;
	}

	// // RVA: 0xD98894 Offset: 0xD98894 VA: 0xD98894 Slot: 9
	public virtual bool MLMEOLAEJEL_DoLoadData() 
    { 
        if(DAPCDNJBKBK_mSuccess != null)
		{
			return DAPCDNJBKBK_mSuccess(IMGIFJHHEED_fro);
		}
		return true;
    }

	// // RVA: 0xD988B4 Offset: 0xD988B4 VA: 0xD988B4 Slot: 10
	public virtual bool HICEMOLOKKF()
	{
		if(HAANPNDACPE_mFail != null)
		{
			return HAANPNDACPE_mFail(IMGIFJHHEED_fro);
		}
		return true;
	}

	// // RVA: 0xD988D4 Offset: 0xD988D4 VA: 0xD988D4
	public void PEFNBFCMIBL()
	{
		DKNGPHJKGAP();
	}

	// // RVA: 0xD988E4 Offset: 0xD988E4 VA: 0xD988E4
	public void IPGGCCPIMMI_Cancel()
	{
		PAHHAMPDBFP();
	}

	// // RVA: 0xD988F4 Offset: 0xD988F4 VA: 0xD988F4 Slot: 11
	public virtual void PAHHAMPDBFP()
	{
		LHMDABPNDDH_state = PLINNKMECEF_State.NFFGMBBNNPH_0_None; // 0
	}

	// // RVA: 0xD988F8 Offset: 0xD988F8 VA: 0xD988F8 Slot: 12
	public virtual void DKNGPHJKGAP()
	{
		return;
	}

	// // RVA: -1 Offset: -1 Slot: 13
	public abstract void JNDNHPEIMEI();

	// // RVA: 0xD988FC Offset: 0xD988FC VA: 0xD988FC
	public void JKONMHNBGLL_Cancel()
	{
		LHMDABPNDDH_state = PLINNKMECEF_State.JKONMHNBGLL_Cancel; // 4
	}

	// // RVA: 0xD98908 Offset: 0xD98908 VA: 0xD98908
	public void JOCCKKMCPAC_Error()
	{
		LHMDABPNDDH_state = PLINNKMECEF_State.PNGOBECOOJM_Error; // 3
	}

	// // RVA: 0xD98914 Offset: 0xD98914 VA: 0xD98914
	public bool GCPOIANJEOC_IsCanceled()
	{
		return LHMDABPNDDH_state == PLINNKMECEF_State.JKONMHNBGLL_Cancel; // 4
	}

	// // RVA: 0xD98928 Offset: 0xD98928 VA: 0xD98928
	private bool GOGBNFLIJAB(byte[] _DBBGALAPFGC_bytes, byte[] PJCEJFENECH)
	{
		if(PJCEJFENECH.Length <= _DBBGALAPFGC_bytes.Length)
		{
			for(int i = 0; i < ILINJKLDCJD.Length; i++)
			{
				if(_DBBGALAPFGC_bytes[i] != ILINJKLDCJD[i])
					return false;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0xD98AE0 Offset: 0xD98AE0 VA: 0xD98AE0
	protected bool BBGDFKAPJHN(byte[] _DBBGALAPFGC_bytes) 
    {
		if(_DBBGALAPFGC_bytes.Length > 15)
		{
			if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, ILINJKLDCJD))
			{
				if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, MPNFIMBCMFK))
				{
					if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, OBIKJLFDNJA))
					{
						if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, NFIOLMJLGFM))
						{
							if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, OPMNFNHOMJF))
							{
								if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, LLJJCPNHPFP))
								{
									if(BitConverter.ToUInt32(_DBBGALAPFGC_bytes, 0) != 0x46464952)
									{
										if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, BGLBMKIKKKP))
										{
											if(!GOGBNFLIJAB(_DBBGALAPFGC_bytes, LEAAJEJAMMH))
											{
												bool val = false;
												for(int i = 0; i < 12; i++)
												{
													val |= (_DBBGALAPFGC_bytes[i + 4] != 0xff);
												}
												return !val;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		
        return true;
    }
}
