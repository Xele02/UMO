using XeApp.Core.WorkerThread;
using UnityEngine;
using System.Collections;
using XeApp.Game;

public delegate bool MMACCEADALH(SakashoErrorId _PPFNGGCBJKC_id);

// namespace XeApp_Game_Net_Actions

public class IDNNDIHDLGA
{
	public string KLMPFGOCBHC_description; // 0x8
}

[System.Obsolete("Use CACGCMBKHDI_NetBaseAction", true)]
public abstract class CACGCMBKHDI {}
public abstract class CACGCMBKHDI_NetBaseAction
{
    public delegate void HDHIKGLMOGF(CACGCMBKHDI_NetBaseAction _ADKIDBJCAJA_action);

    public long CKOOCBJGHBI_RequestId; // 0x8
    public int CFICLNJACCD_NumRetry = 3; // 0x10
    public float GJAEJFLLKGC_RetryTime = 3.0f; // 0x14
    public float ICDEFIIADDO_Timeout = 120.0f; // 0x18
    protected string ECGDADGLAMM; // 0x28
    public MMACCEADALH NBFDEFGFLPJ; // 0x50
    public bool DLKLLHPLANH; // 0x54
    private bool GIAJMLDDPKF; // 0x55
    public bool EOPCHGLLONF; // 0x70
    public bool AILPHBMCCGP; // 0x71
    public static bool NLKPHFGBJHM; // 0x0
    public bool CMMCGNLPHLE; // 0x72
    public bool ALJHFFCKBDP; // 0x73
    private bool NAEDHHPPFCK_IsDone; // 0x74
    public bool KAEMPHIPDFN; // 0x75

    public HDHIKGLMOGF BHFHGFKBOHH_OnSuccess { get; set; } // 0x1C FJNKDKOKOMD_bgs MEOFOFHFBFD_bgs FAKPBHKKNOK_bgs
    public HDHIKGLMOGF MOBEEPPKFLG_OnFail { get; set; } // 0x20 HELECPOBDIL_bgs LLHGEKKIFIJ_bgs AHNDFJKKLDJ_bgs
    public WorkerThreadQueue BNJPAKLNOPA_WorkerThreadQueue { get; set; } // 0x24 EGCCKJEDANG_bgs IMDNDFIKMHN_bgs ODBGIMFJOHN_bgs
    public SakashoError ANMFDAGDMDE_Error { get; set; } // 0x2C GHCMEMELCJF_bgs ILGAFKNEAJI_bgs DPCCCKAKHDB_bgs
    public SakashoErrorId CJMFJOMECKI_ErrorId { get; set; } // 0x30 BCCAMPBOJHK_bgs LBJPGPOJOKP_bgs GPEILELFPCD_bgs
    public bool NPNNPNAIONN_IsError { get; set; } // 0x34 GMEODAHJILH_bgs IAGEPLEBOKJ_bgs DDHAFEDMPEH_bgs
    public bool JONHGMCILHM { get; set; } // 0x35 CEMOPAGHPJM_bgs JPIBKPPPIDG_bgs BMAPGPMEFKC_bgs
    public bool LEBKCAEHLPC { get; set; } // 0x36 DMGEAJAAHAO_bgs FHBJIBDPBLI_bgs ODMPKGGKPAN_bgs
    public bool PDAPLCPOCMA { get; set; } // 0x37 MIEDINFMHKL_bgs EBANJNNPMCM_bgs GNKHADMLLGA_bgs
    public bool EFGFPCBGDDK { get; set; } // 0x38 FMBCHNLOAHF_bgs  // EEEPONHOKCJ_bgs // EHJOEBHMHLB_bgs
    public string NGCAIEGPLKD_result { get; set; }  // 0x3C // JCIJAABGKKM_bgs; // ALHHGGDPGEH_bgs // GLHKPBHJAPP_bgs

    public OBOKMHHMOIL_ServerInfo HOHOBEOJPBK_ServerInfo { get; set; }  // 0x40 // POMCKJFOMGJ_bgs // PEMKJFHLBIA_bgs // FINMAPHMLHA_bgs
    public IDNNDIHDLGA HIBMKLEJEDP { get; set; } // 0x44 DFEGGDEPMMB_bgs PLKKKJIEJNE_bgs IPHOHNBDMOE_bgs
    public string GEKKKPIIOAF_Extra { get; set; } // 0x48 AOCPFCELECC_bgs EFJKDEPPKJL_bgs EOIEFLFHAFI_bgs
    public string JNDJDDBAIAJ_Message { get; set; } // 0x4C APGMLBJEHPH_bgs NHPMIODGLEJ_bgs NJGFHKKAKEM_bgs
    // public virtual bool DCLHBCFKIJI { get; set; } IHGGDFHAGGM 0x18F2320_bgs AHLIMCFMAHO_bgs 0x18F2328_bgs 
    public double KINJOEIAHFK_StartTime { get; set; } // 0x58 BLHFJCJNIGC_bgs CMNMHDELKND_bgs IOPPCLACPOF_bgs
    public double DMOBOIOFPCM_EndTime { get; set; } // 0x60 GJKEKJMCFLB_bgs IBBPAJGOFFA_bgs FNIKLDHAPEG_bgs
    public double LHGPAJGIAME_ResultTime { get; set; }  // 0x68 FOFFKBHGEPC_bgs OJCLNCIEHLL_bgs BPAIAMDPKBJ_bgs
    // public double MOCNPGKAPKE { get; } // FLDLAOCPFCP_bgs 0x18F23E0
    public virtual bool OIDCBBGLPHL { get { return false; } } // GINMIBJOABO_bgs 0x18F256C
    public virtual bool ICFMKEFJOIE { get { return false; } } // HOPDAAAEBBG_bgs 0x18F2574 
    public virtual bool BNCFONNOHFO { get { return false; } } // NPLNAJFJPEE_bgs 0x18F257C
    public bool PLOOEECNHFB_IsDone { get { return NAEDHHPPFCK_IsDone; } set { NAEDHHPPFCK_IsDone = value; } } // JFOKBBLFMLD_bgs 0x18F2584 EDBGNGILAKA_bgs 0x18F258C
    public SakashoAPICallContext EBGACDGNCAA_CallContext { get; set; }  // 0x78 NKPCDAJOMEO_bgs EEMOCCMAONH_bgs IGIDINIFHDJ_bgs
    public virtual bool EBPLLJGPFDA_HasResult { get { return true; } } // HGPAELCGELL_bgs 0x18F2BD8

    // // RVA: 0x18F2330 Offset: 0x18F2330 VA: 0x18F2330 Slot: 6
    // public virtual string NFODPNFPDGD() { }

    // // RVA: 0x18F240C Offset: 0x18F240C VA: 0x18F240C
    public void BOPHNJFGJBN()
    {
        if(!ALJHFFCKBDP)
            return;
        GameManager.Instance.InputEnabled = true;
    }

    // // RVA: 0x18F24BC Offset: 0x18F24BC VA: 0x18F24BC
    public void EHLFONGENNK()
    {
        if(!ALJHFFCKBDP)
            return;
        GameManager.Instance.InputEnabled = false;
    }

    // // RVA: 0x18F25A4 Offset: 0x18F25A4 VA: 0x18F25A4
    public void OGPFKGAKOFD()
    {
        EFGFPCBGDDK = false;
        ANMFDAGDMDE_Error = null;
        NGCAIEGPLKD_result = null;
        HOHOBEOJPBK_ServerInfo = null;
        HIBMKLEJEDP = null;
        EBGACDGNCAA_CallContext = null;
        DHLDNIEELHO();
    }

    // [ConditionalAttribute] // RVA: 0x6C3D70 Offset: 0x6C3D70 VA: 0x6C3D70
    // // RVA: 0x18F25D0 Offset: 0x18F25D0 VA: 0x18F25D0
    // public void FGNOINLMJLN(string _INDDJNMPONH_type, string HEKJBOPBDIA) { }

    // // RVA: 0x18F272C Offset: 0x18F272C VA: 0x18F272C Slot: 10
    // public virtual bool CPIIKMBBKAI() { }

    // // RVA: 0x18F2734 Offset: 0x18F2734 VA: 0x18F2734 Slot: 11
    // public virtual void CBEPCFJOJOI() { }

    // // RVA: 0x18F2738 Offset: 0x18F2738 VA: 0x18F2738 Slot: 12
    public virtual void DHLDNIEELHO()
    {
        return;
    }

    // // RVA: 0x18F273C Offset: 0x18F273C VA: 0x18F273C
    public void MEOCKCJBDAD(SakashoError _DOGDHKIEBJA_error)
    {
		EFGFPCBGDDK = true;
		ANMFDAGDMDE_Error = _DOGDHKIEBJA_error;
		if(_DOGDHKIEBJA_error.ErrorDetailJSON != null)
		{
			if(_DOGDHKIEBJA_error.getErrorId() == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(_DOGDHKIEBJA_error.ErrorDetailJSON);
                if(!data.BBAJPINMOEP_Contains("extra"))
                {
                    GEKKKPIIOAF_Extra = null;
                    return;
                }
                GEKKKPIIOAF_Extra = (string)data["extra"];
			}
			else if(_DOGDHKIEBJA_error.getErrorId() == SakashoErrorId.SIGN_IN_WITH_APPLE_UNAVAILABLE)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(_DOGDHKIEBJA_error.ErrorDetailJSON);
                if(!data.BBAJPINMOEP_Contains("message"))
                {
                    return;
                }
                JNDJDDBAIAJ_Message = (string)data["message"];
			}
			else if (_DOGDHKIEBJA_error.getErrorId() == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(_DOGDHKIEBJA_error.ErrorDetailJSON);
                HIBMKLEJEDP = new IDNNDIHDLGA();
                HIBMKLEJEDP.KLMPFGOCBHC_description = CEDHHAGBIBA.KJFAGPBALNO((string)data["description"]);
			}
		}
	}

    // // RVA: 0x18F2B34 Offset: 0x18F2B34 VA: 0x18F2B34
    public void DCKLDDCAJAP(string _IDLHJIOMJBK_data)
    {
        HOHOBEOJPBK_ServerInfo = new OBOKMHHMOIL_ServerInfo();
        HOHOBEOJPBK_ServerInfo.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data);
        EFGFPCBGDDK = true;
        NGCAIEGPLKD_result = _IDLHJIOMJBK_data;
    }

    // // RVA: 0x18F2BD4 Offset: 0x18F2BD4 VA: 0x18F2BD4 Slot: 13
    public virtual void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        return;
    }

    // // RVA: 0x18F2BE0 Offset: 0x18F2BE0 VA: 0x18F2BE0 Slot: 15
    public virtual void NLDKLFODOJJ()
    {
        return;
    }

    // // RVA: 0x18F2BE4 Offset: 0x18F2BE4 VA: 0x18F2BE4
    public YieldInstruction GDPDELLNOBO_WaitDone(MonoBehaviour _DANMJLOBLIE_mb)
    {
        return _DANMJLOBLIE_mb.StartCoroutineWatched(HOHLIBIOPOM_CheckDone());
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3DB0 Offset: 0x6C3DB0 VA: 0x6C3DB0
    // // RVA: 0x18F2C1C Offset: 0x18F2C1C VA: 0x18F2C1C
    private IEnumerator HOHLIBIOPOM_CheckDone()
    {
        //0x18F2D34
        while(!NAEDHHPPFCK_IsDone)
        {
            yield return null;
        }
    }

    // // RVA: 0x18F2CC8 Offset: 0x18F2CC8 VA: 0x18F2CC8 Slot: 16
    // public virtual string GHAIKECGKKO() { }

}

