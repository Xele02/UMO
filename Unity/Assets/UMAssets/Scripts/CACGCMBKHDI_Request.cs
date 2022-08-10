using XeApp.Core.WorkerThread;
using UnityEngine;
using System.Collections;

public delegate bool MMACCEADALH(SakashoErrorId PPFNGGCBJKC_Id);


public class IDNNDIHDLGA
{
	public string KLMPFGOCBHC; // 0x8
}


public abstract class CACGCMBKHDI {}
public abstract class CACGCMBKHDI_Request
{
    public delegate void HDHIKGLMOGF(CACGCMBKHDI_Request ADKIDBJCAJA);

    public long CKOOCBJGHBI; // 0x8
    public int CFICLNJACCD = 3; // 0x10
    public float GJAEJFLLKGC = 3.0f; // 0x14
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
    private bool NAEDHHPPFCK; // 0x74
    public bool KAEMPHIPDFN; // 0x75

    public HDHIKGLMOGF BHFHGFKBOHH { get; set; } // 0x1C FJNKDKOKOMD MEOFOFHFBFD FAKPBHKKNOK
    public HDHIKGLMOGF MOBEEPPKFLG { get; set; } // 0x20 HELECPOBDIL LLHGEKKIFIJ AHNDFJKKLDJ
    public WorkerThreadQueue BNJPAKLNOPA_WorkerThreadQueue { get; set; } // 0x24 EGCCKJEDANG IMDNDFIKMHN ODBGIMFJOHN
    public SakashoError ANMFDAGDMDE { get; set; } // 0x2C GHCMEMELCJF ILGAFKNEAJI DPCCCKAKHDB
    public SakashoErrorId CJMFJOMECKI { get; set; } // 0x30 BCCAMPBOJHK LBJPGPOJOKP GPEILELFPCD
    public bool NPNNPNAIONN { get; set; } // 0x34 GMEODAHJILH IAGEPLEBOKJ DDHAFEDMPEH
    public bool JONHGMCILHM { get; set; } // 0x35 CEMOPAGHPJM JPIBKPPPIDG BMAPGPMEFKC
    public bool LEBKCAEHLPC { get; set; } // 0x36 DMGEAJAAHAO FHBJIBDPBLI ODMPKGGKPAN
    public bool PDAPLCPOCMA { get; set; } // 0x37 MIEDINFMHKL EBANJNNPMCM GNKHADMLLGA
    public bool EFGFPCBGDDK { get; set; } // 0x38 FMBCHNLOAHF  // EEEPONHOKCJ // EHJOEBHMHLB
    public string NGCAIEGPLKD_result { get; set; }  // 0x3C // JCIJAABGKKM; // ALHHGGDPGEH // GLHKPBHJAPP

    public OBOKMHHMOIL HOHOBEOJPBK { get; set; }  // 0x40 // POMCKJFOMGJ // PEMKJFHLBIA // FINMAPHMLHA
    public IDNNDIHDLGA HIBMKLEJEDP { get; set; } // 0x44 DFEGGDEPMMB PLKKKJIEJNE IPHOHNBDMOE
    public string GEKKKPIIOAF { get; set; } // 0x48 AOCPFCELECC EFJKDEPPKJL EOIEFLFHAFI
    public string JNDJDDBAIAJ { get; set; } // 0x4C APGMLBJEHPH NHPMIODGLEJ NJGFHKKAKEM
    // public virtual bool DCLHBCFKIJI { get; set; } IHGGDFHAGGM 0x18F2320 AHLIMCFMAHO 0x18F2328 
    public double KINJOEIAHFK_StartTime { get; set; } // 0x58 BLHFJCJNIGC CMNMHDELKND IOPPCLACPOF
    public double DMOBOIOFPCM { get; set; } // 0x60 GJKEKJMCFLB IBBPAJGOFFA FNIKLDHAPEG
    public double LHGPAJGIAME { get; set; }  // 0x68 FOFFKBHGEPC OJCLNCIEHLL BPAIAMDPKBJ
    // public double MOCNPGKAPKE { get; } // FLDLAOCPFCP 0x18F23E0
    // public virtual bool OIDCBBGLPHL { get; } // GINMIBJOABO 0x18F256C
    public virtual bool ICFMKEFJOIE { get { return false; } } // HOPDAAAEBBG 0x18F2574 
    // public virtual bool BNCFONNOHFO { get; } // NPLNAJFJPEE 0x18F257C
    public bool PLOOEECNHFB { get { return NAEDHHPPFCK; } set { NAEDHHPPFCK = value; } } // JFOKBBLFMLD 0x18F2584 EDBGNGILAKA 0x18F258C
    public SakashoAPICallContext EBGACDGNCAA { get; set; }  // 0x78 NKPCDAJOMEO EEMOCCMAONH IGIDINIFHDJ
    public virtual bool EBPLLJGPFDA { get { return true; } } // HGPAELCGELL 0x18F2BD8

    // // RVA: 0x18F2330 Offset: 0x18F2330 VA: 0x18F2330 Slot: 6
    // public virtual string NFODPNFPDGD() { }

    // // RVA: 0x18F240C Offset: 0x18F240C VA: 0x18F240C
    public void BOPHNJFGJBN()
    {
        TodoLogger.Log(0, "TODO");
    }

    // // RVA: 0x18F24BC Offset: 0x18F24BC VA: 0x18F24BC
    public void EHLFONGENNK()
    {
        TodoLogger.Log(0, "TODO");
    }

    // // RVA: 0x18F25A4 Offset: 0x18F25A4 VA: 0x18F25A4
    public void OGPFKGAKOFD()
    {
        EFGFPCBGDDK = false;
        ANMFDAGDMDE = null;
        NGCAIEGPLKD_result = null;
        HOHOBEOJPBK = null;
        HIBMKLEJEDP = null;
        EBGACDGNCAA = null;
        DHLDNIEELHO();
    }

    // [ConditionalAttribute] // RVA: 0x6C3D70 Offset: 0x6C3D70 VA: 0x6C3D70
    // // RVA: 0x18F25D0 Offset: 0x18F25D0 VA: 0x18F25D0
    // public void FGNOINLMJLN(string INDDJNMPONH, string HEKJBOPBDIA) { }

    // // RVA: 0x18F272C Offset: 0x18F272C VA: 0x18F272C Slot: 10
    // public virtual bool CPIIKMBBKAI() { }

    // // RVA: 0x18F2734 Offset: 0x18F2734 VA: 0x18F2734 Slot: 11
    // public virtual void CBEPCFJOJOI() { }

    // // RVA: 0x18F2738 Offset: 0x18F2738 VA: 0x18F2738 Slot: 12
    public virtual void DHLDNIEELHO()
    {
        TodoLogger.Log(0, "TODO");
    }

    // // RVA: 0x18F273C Offset: 0x18F273C VA: 0x18F273C
    public void MEOCKCJBDAD(SakashoError DOGDHKIEBJA)
    {
        TodoLogger.Log(0, "TODO");
    }

    // // RVA: 0x18F2B34 Offset: 0x18F2B34 VA: 0x18F2B34
    public void DCKLDDCAJAP(string IDLHJIOMJBK_result)
    {
        HOHOBEOJPBK = new OBOKMHHMOIL();
        HOHOBEOJPBK.KHEKNNFCAOI_Init(IDLHJIOMJBK_result);
        EFGFPCBGDDK = true;
        NGCAIEGPLKD_result = IDLHJIOMJBK_result;
    }

    // // RVA: 0x18F2BD4 Offset: 0x18F2BD4 VA: 0x18F2BD4 Slot: 13
    public virtual void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        return;
    }

    // // RVA: 0x18F2BE0 Offset: 0x18F2BE0 VA: 0x18F2BE0 Slot: 15
    public virtual void NLDKLFODOJJ()
    {
        return;
    }

    // // RVA: 0x18F2BE4 Offset: 0x18F2BE4 VA: 0x18F2BE4
    public YieldInstruction GDPDELLNOBO(MonoBehaviour DANMJLOBLIE)
    {
        return DANMJLOBLIE.StartCoroutine(HOHLIBIOPOM_CheckDone());
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3DB0 Offset: 0x6C3DB0 VA: 0x6C3DB0
    // // RVA: 0x18F2C1C Offset: 0x18F2C1C VA: 0x18F2C1C
    private IEnumerator HOHLIBIOPOM_CheckDone()
    {
        UnityEngine.Debug.Log("Enter HOHLIBIOPOM_CheckDone");
        //0x18F2D34
        while(!NAEDHHPPFCK)
        {
            yield return null;
        }
        UnityEngine.Debug.Log("Exit HOHLIBIOPOM_CheckDone");
    }

    // // RVA: 0x18F2CC8 Offset: 0x18F2CC8 VA: 0x18F2CC8 Slot: 16
    // public virtual string GHAIKECGKKO() { }

}

