using System.Collections.Generic;
using XeApp.Core.WorkerThread;
using UnityEngine;
using System.Collections;
using XeSys;
using System;

public delegate void OEEHODIFBIG(bool JKDJCFEBDHC);
public delegate void DLMJDDACNLA(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, bool PANAGHJOMPO);
public delegate void EHLCCMEDIOH();
public delegate void DMADPGMDPHC(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request ADKIDBJCAJA, int MJACIGCPNDA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP);
public delegate void MFKJNKIKBOP(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request ADKIDBJCAJA, int MJACIGCPNDA, IMCBBOAFION KLMFJJCNBIP);
public delegate void DIDEKBFMOBM(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request ADKIDBJCAJA, string LJGOOOMOMMA, IMCBBOAFION KLMFJJCNBIP);
public delegate void IHABJNEGMEA(CACGCMBKHDI_Request ADKIDBJCAJA, int CMCKNKKCNDK, IMCBBOAFION KLMFJJCNBIP);

public class PJKLMCGEJMK
{
    public enum AHADNLCOPOL
    {
        NFFGMBBNNPH_None = 0,
        HIHKPNBDNJC_Running = 1,
        OGBMKAILHMF = 2,
    }

    public delegate void FPHHIOBKMFD_Updater();

    private int NLGJBBGAOLH = 3; // 0x8
    private float BLKIMNAILKK = 3.0f; // 0xC
    private const double IACPOAJPMNO = 1;
    private int MFNENCLNGKF; // 0x10
    private int OANLLFOHEPJ; // 0x14
    private long NNODMPKKCJH = 1; // 0x18
    private long JDIBBDGNFKH = 1; // 0x20
    public static long DALFMJFKCGJ; // 0x0
    public static bool KCEDAACIBFG; // 0x8
    private KPKEOIJHIMN OPFEFKOOMED = new KPKEOIJHIMN(); // 0x2C
    private OBOKMHHMOIL_ServerInfo IEBFCJACLPN = new OBOKMHHMOIL_ServerInfo(); // 0x30
    public bool IEFOIIAEBBJ; // 0x34
    public bool NFECEPJEMHG; // 0x35
    public bool LMBLIFCNKCJ; // 0x36
    private bool NAJENHKNJLN; // 0x37
    private IIDJLAEDMPI HFMOEKIBNKA = new IIDJLAEDMPI(); // 0x38
    private LGNBLDHKLJK DNMDKBFINPG = new LGNBLDHKLJK(); // 0x3C
    public bool BEBMDHKKNDA; // 0x40
    public bool KAEMPHIPDFN; // 0x41
	public bool BLFILNOBHMM; // 0x42
	public DMADPGMDPHC LJPJJHGIEAO; // 0x44
	public MFKJNKIKBOP IGAMFDCEGFC; // 0x48
	public DIDEKBFMOBM LLFDDHIIPBK; // 0x4C
	public DIDEKBFMOBM CCBAMLACFCF; // 0x50
	public DIDEKBFMOBM NIJMLFNDAJP; // 0x54
	public IHABJNEGMEA EGAOFAHEPME; // 0x58
	public DLMJDDACNLA OMAGHCDMBBI; // 0x5C
    public OEEHODIFBIG DMPHNPAFHEG; // 0x60
    public bool OLBAIKLLIFE; // 0x64
    private List<CACGCMBKHDI_Request> FCICFIAOLAM_RequestList = new List<CACGCMBKHDI_Request>(); // 0x68
    private bool DMGPJMPINFJ; // 0x6C
    private PJKLMCGEJMK.FPHHIOBKMFD_Updater LCIGLIDJILJ_updater; // 0x74

    // private bool IGIIAEPHNCC { get; set; } // BLJMGAEEDAC 0x930B9C NNFLLPLMHBG 0x930C78
    // private int JMEKPMDNKEO { get; set; }  // MMACOJFDCJC 0x930D48 MLFFBGAHKJI 0x930E1C 
    // private KPKEOIJHIMN.GIDACIOHFNN DLDIKFJIGBE { get; set; } //  BEPAHJLMMOG 0x930EEC PFABEFOBEMC 0x930FC0
    public WorkerThreadQueue BNJPAKLNOPA_WorkerThreadQueue { get; set; } // 0x28 // EGCCKJEDANG IMDNDFIKMHN ODBGIMFJOHN
    public KPKEOIJHIMN DAOHAKABAFG { get { return OPFEFKOOMED; } } // JACGBOGNFKM 0x9310A0
    // public OBOKMHHMOIL OAKOMPBPGLD { get; } // MFLBDBHHKMP 0x9310A8
    public bool MBOIDKCMCDL { get { return NAJENHKNJLN; } set { NAJENHKNJLN = value; } } // NPCNCBJAJNO 0x9310B0 GOFGBIANJGF 0x9310B8
    public IIDJLAEDMPI FJDBNGEPKHL { get { return HFMOEKIBNKA; } } // FIIMIGEKDCM 0x925074
    public LGNBLDHKLJK LOMEEJGIAHO { get { return DNMDKBFINPG; } } // LEFKJNJCAPO 0x9310C0
    public AHADNLCOPOL CMCKNKKCNDK_Status { get; set; } // 0x70 CLCJNFNMNBH CNKGOPKANGF 0x9310C8 CHJGGLFGALP 0x9310D0 

    // // RVA: 0x9310D8 Offset: 0x9310D8 VA: 0x9310D8
    public void IJBGPAENLJA_Start(MonoBehaviour DANMJLOBLIE)
    {
        CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.NFFGMBBNNPH_None;
        LCIGLIDJILJ_updater = this.LFKLIOKFGLP_TryStartRequest;
        HFMOEKIBNKA.EAJMLOKKOOK_SetServerTime(Utility.GetCurrentUnixTime());
        DNMDKBFINPG.JOJFKIIHMOJ(HFMOEKIBNKA.KMEFBNBFJHI_GetServerTime());
        BNJPAKLNOPA_WorkerThreadQueue = new XeApp.Core.WorkerThread.WorkerThreadQueue();
        BNJPAKLNOPA_WorkerThreadQueue.Start();
    }

    // // RVA: 0x931278 Offset: 0x931278 VA: 0x931278
    public void BAGMHFKPFIF_Update()
    {
        LCIGLIDJILJ_updater();
        DDBHLHBJEGP(CMCKNKKCNDK_Status);
    }

    // // RVA: 0x931734 Offset: 0x931734 VA: 0x931734
    public void FFBCKMFKFME()
    {
        if(BNJPAKLNOPA_WorkerThreadQueue == null)
            return;
        BNJPAKLNOPA_WorkerThreadQueue.Abort();
        BNJPAKLNOPA_WorkerThreadQueue = null;
    }

    // // RVA: 0x931760 Offset: 0x931760 VA: 0x931760
    private void LFKLIOKFGLP_TryStartRequest()
    {
        if(FCICFIAOLAM_RequestList.Count < 1)
            return;

        CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running;
        N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM_RequestList[0]));
        LCIGLIDJILJ_updater = this.JADLLIFCGLG_CheckRequest;
    }

    // // RVA: 0x931934 Offset: 0x931934 VA: 0x931934
    private void JADLLIFCGLG_CheckRequest()
    {
        if(FCICFIAOLAM_RequestList.Count == 0)
        {
            CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.NFFGMBBNNPH_None;
            LCIGLIDJILJ_updater = this.LFKLIOKFGLP_TryStartRequest;
            DMGPJMPINFJ = false;
            return;
        }
        CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running;
        if(DMGPJMPINFJ)
        {
            CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.OGBMKAILHMF;
        }
        CACGCMBKHDI_Request request = FCICFIAOLAM_RequestList[0];
        if(!request.PLOOEECNHFB_IsDone)
            return;
        if(FCICFIAOLAM_RequestList.Count > 0)
        {
            FCICFIAOLAM_RequestList.RemoveAt(0);
        }
        if(FCICFIAOLAM_RequestList.Count < 1)
        {
            CMCKNKKCNDK_Status = PJKLMCGEJMK.AHADNLCOPOL.NFFGMBBNNPH_None;
            LCIGLIDJILJ_updater = this.LFKLIOKFGLP_TryStartRequest;
        }
        else
        {
            N.a.StartCoroutineWatched(NBCKHIAINIM_Coroutine_Execute(FCICFIAOLAM_RequestList[0]));
            LCIGLIDJILJ_updater = this.JADLLIFCGLG_CheckRequest;
        }
    }

    // // RVA: 0x931BD0 Offset: 0x931BD0 VA: 0x931BD0
    public CACGCMBKHDI_Request IFFNCAFNEAG_AddRequest(CACGCMBKHDI_Request ADKIDBJCAJA_Request)
    {
        ADKIDBJCAJA_Request.BNJPAKLNOPA_WorkerThreadQueue = BNJPAKLNOPA_WorkerThreadQueue;
        ADKIDBJCAJA_Request.PLOOEECNHFB_IsDone = false;

        double time = Time.realtimeSinceStartup;
        ADKIDBJCAJA_Request.KINJOEIAHFK_StartTime = time;
        ADKIDBJCAJA_Request.DMOBOIOFPCM = time;
        ADKIDBJCAJA_Request.LHGPAJGIAME = time;
        ADKIDBJCAJA_Request.CFICLNJACCD = NLGJBBGAOLH;
        ADKIDBJCAJA_Request.GJAEJFLLKGC = BLKIMNAILKK;
        ADKIDBJCAJA_Request.KAEMPHIPDFN = KAEMPHIPDFN;
        ADKIDBJCAJA_Request.CKOOCBJGHBI = NNODMPKKCJH;
        NNODMPKKCJH++;

        FCICFIAOLAM_RequestList.Add(ADKIDBJCAJA_Request);

        return ADKIDBJCAJA_Request;
    }

    // // RVA: -1 Offset: -1
    // RVA: 0x1AB65FC Offset: 0x1AB65FC VA: 0x1AB65FC
    public T IFFNCAFNEAG_AddRequest<T>(T ADKIDBJCAJA_Request)  where T : CACGCMBKHDI_Request
    { 
        ADKIDBJCAJA_Request.BNJPAKLNOPA_WorkerThreadQueue = BNJPAKLNOPA_WorkerThreadQueue;
        ADKIDBJCAJA_Request.PLOOEECNHFB_IsDone = false;

        double time = Time.realtimeSinceStartup;
        ADKIDBJCAJA_Request.KINJOEIAHFK_StartTime = time;
        ADKIDBJCAJA_Request.DMOBOIOFPCM = time;
        ADKIDBJCAJA_Request.LHGPAJGIAME = time;
        ADKIDBJCAJA_Request.CFICLNJACCD = NLGJBBGAOLH;
        ADKIDBJCAJA_Request.GJAEJFLLKGC = BLKIMNAILKK;
        ADKIDBJCAJA_Request.CKOOCBJGHBI = NNODMPKKCJH;
        NNODMPKKCJH++;

        FCICFIAOLAM_RequestList.Add(ADKIDBJCAJA_Request);
        return ADKIDBJCAJA_Request;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3578 Offset: 0x6C3578 VA: 0x6C3578
    // // RVA: 0x93188C Offset: 0x93188C VA: 0x93188C
    private IEnumerator NBCKHIAINIM_Coroutine_Execute(CACGCMBKHDI_Request ADKIDBJCAJA)
    {
    	//UnityEngine.Debug.Log("Enter NBCKHIAINIM_Coroutine_Execute");
        // private PJKLMCGEJMK.<>c__DisplayClass69_0 OPLBFCEPDCH; // 0x18
            // public bool FFEFFPIHPFF; // 0x8
            // public bool APLAAAMOBCF; // 0x9
            // public bool GLPPGJMLNKM; // 0xA
            // RVA: 0x933200 Offset: 0x933200 VA: 0x933200
            // internal void NBKNLFPENDK() { }
            // RVA: 0x93320C Offset: 0x93320C VA: 0x93320C
            // internal void MJPBDADELKI() { }
            // RVA: 0x933218 Offset: 0x933218 VA: 0x933218
            // internal void EHOJJEKBLBC() { }

        // private PJKLMCGEJMK.<>c__DisplayClass69_1 LBLMCMHMNGC; // 0x1C
            // public bool NEFPJAHDAJJ; // 0x8
            // public bool EEBKLFOBGPM; // 0x9
            // RVA: 0x933230 Offset: 0x933230 VA: 0x933230
            // internal void FFJDKJAAPIB() { }
            // RVA: 0x93323C Offset: 0x93323C VA: 0x93323C
            // internal void IHFHHBALPDJ() { }

        // private PJKLMCGEJMK.<>c__DisplayClass69_2 PHPPCOBECCA; // 0x20
	        // public bool APGOAMNGFFF; // 0x8
            // RVA: 0x933250 Offset: 0x933250 VA: 0x933250
            // internal void NNGKMNIFILI() { }

        // private bool KADMOOOMMJF; // 0x24
        // private bool JBPEHAHCBLK; // 0x25
        // private float MEMLLCDHAIF; // 0x28
        // private SakashoAPICallContext GPBPFELFMFL; // 0x2C
        //0x933B50

        // 0
        yield return null;
        // 1
        MFNENCLNGKF = 0;
        OANLLFOHEPJ = 0;
        LMBLIFCNKCJ = false;
        bool KADMOOOMMJF = false;
        while(true)
        {
            //goto LAB_00933f38;
            //6
            //LAB_00933f38:
            DMGPJMPINFJ = false;
            bool JBPEHAHCBLK = false;
            if(OANLLFOHEPJ > 0)
            {
                bool FFEFFPIHPFF = false;
                bool APLAAAMOBCF = false;
                bool GLPPGJMLNKM = false;

                if(BKGNCCKFMPF(ADKIDBJCAJA, () => {
                    //0x933200
                    FFEFFPIHPFF = true;
                }, () => {
                    //0x93320C
                    FFEFFPIHPFF = true;
                    APLAAAMOBCF = true;
                }, () => {
                    //0x933218
                    GLPPGJMLNKM = true;
                    FFEFFPIHPFF = true;
                }))
                {
                    //LAB_009340ac:
                    while(!FFEFFPIHPFF)
                    {
                        yield return null;
                    }
                    if(APLAAAMOBCF || GLPPGJMLNKM)
                    {
                        if(APLAAAMOBCF)
                        {
                            ADKIDBJCAJA.NPNNPNAIONN_IsError = false;
                            KADMOOOMMJF = false;
                        }
                        else
                        {
                            KADMOOOMMJF = true;
                            ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
                        }
                        break;
                    }
                }
            }

            bool enterIf = ADKIDBJCAJA.CKOOCBJGHBI >= JDIBBDGNFKH;
            if(!enterIf)
            {
                OHFKAECPJPO(ADKIDBJCAJA);
                enterIf = !BLFILNOBHMM;
            }
            if(enterIf)
            {
                ADKIDBJCAJA.OGPFKGAKOFD();
                ADKIDBJCAJA.CKOOCBJGHBI = JDIBBDGNFKH;
                float MEMLLCDHAIF = 0.0f;
                SakashoAPICallContext GPBPFELFMFL = ADKIDBJCAJA.EBGACDGNCAA_CallContext;
                //LAB_00934228
                while(!ADKIDBJCAJA.EFGFPCBGDDK)
                {
                    MEMLLCDHAIF = MEMLLCDHAIF + Time.deltaTime;
                    if(MEMLLCDHAIF > ADKIDBJCAJA.ICDEFIIADDO_Timeout && GPBPFELFMFL != null)
                    {
                        if(GPBPFELFMFL.CancelAPICall())
                        {
                            JBPEHAHCBLK = true;
                            break;
                        }
                    }
                    // to 4 LAB_00934228
                    yield return null;
                }
                GPBPFELFMFL = null;
                ADKIDBJCAJA.CJMFJOMECKI_ErrorId = 0;
                KADMOOOMMJF = false;
                IEBFCJACLPN.LHPDDGIJKNB_Reset();
                SakashoError error = ADKIDBJCAJA.ANMFDAGDMDE;
                string errorJSon = null;
                int errorResponse = 0;
                if(error == null)
                {
                    OBOKMHHMOIL_ServerInfo b = ADKIDBJCAJA.HOHOBEOJPBK_ServerInfo;
                    if(b != null)
                    {
                        if(b.LCAINKFINEI_ServerCurrentDateTime != 0)
                        {
                            HFMOEKIBNKA.EAJMLOKKOOK_SetServerTime(b.LCAINKFINEI_ServerCurrentDateTime);
                            NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK = false;
                        }
                        if(!string.IsNullOrEmpty(b.ABFADMDAAKJ_ServerRecommendedClientVersion))
                        {
                            IEFOIIAEBBJ = true;
                        }
                        IEBFCJACLPN.ODDIHGPONFL_Copy(b);
                        OPFEFKOOMED.EHMKHLIGFEJ(b);
                    }
                }
                else
                {
                    ADKIDBJCAJA.CJMFJOMECKI_ErrorId = error.getErrorId();
                    errorJSon = error.ErrorDetailJSON;
                    errorResponse = error.ResponseCode;
                    KADMOOOMMJF = true;
                }
                ADKIDBJCAJA.NPNNPNAIONN_IsError = KADMOOOMMJF;
                if(JBPEHAHCBLK)
                {
                    if(!ADKIDBJCAJA.AILPHBMCCGP || OMAGHCDMBBI == null)
                    {
                        //LAB_009346e8:
                        ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
                        ADKIDBJCAJA.PDAPLCPOCMA = true;
                        KADMOOOMMJF = true;
                        break;
                    }
                    DMGPJMPINFJ = true;
                    bool NEFPJAHDAJJ = false;
                    bool EEBKLFOBGPM = false;
                    ADKIDBJCAJA.BOPHNJFGJBN();
                    OMAGHCDMBBI(() => {
                        //0x933230
                        NEFPJAHDAJJ = true;
                        EEBKLFOBGPM = true;
                    }, () => {
                        //0x93323C
                        NEFPJAHDAJJ = true;
                    }, !ADKIDBJCAJA.ICFMKEFJOIE);
                    //LAB_00933cac:
                    while(!NEFPJAHDAJJ)
                    {
                        yield return null;
                    }
                    ADKIDBJCAJA.EHLFONGENNK();
                    if(!EEBKLFOBGPM)
                    {
                        //goto LAB_009346e8;
                        ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
                        ADKIDBJCAJA.PDAPLCPOCMA = true;
                        KADMOOOMMJF = true;
                        break;
                    }
                    //L527
                    OANLLFOHEPJ = OANLLFOHEPJ + 1;
                    DMGPJMPINFJ = false;
                    //goto LAB_00933f38;
                    continue;
                }
                if(!KADMOOOMMJF)
                {
                    KPKEOIJHIMN.GIDACIOHFNN val = OPFEFKOOMED.PGBOFGNOBLD();
                    if(val != KPKEOIJHIMN.GIDACIOHFNN.NHHHCIINJKO && (val == KPKEOIJHIMN.GIDACIOHFNN.DNKAABNOOBF || NAJENHKNJLN))
                    {
                        CMCKNKKCNDK_Status = /*2*/PJKLMCGEJMK.AHADNLCOPOL.OGBMKAILHMF;
                        yield return N.a.StartCoroutineWatched(AOMMJNJGFEL(ADKIDBJCAJA, val));
                        // To 8
                        KADMOOOMMJF = true;
                        ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
                        ADKIDBJCAJA.JONHGMCILHM = true;
                        break;
                    }
                    // L 556
                    ADKIDBJCAJA.DMOBOIOFPCM = Time.realtimeSinceStartup;
                    ADKIDBJCAJA.MGFNKDPHFGI(N.a);
                    //goto LAB_00933de0;
                    // To 9
                    while(!ADKIDBJCAJA.EBPLLJGPFDA_HasResult)
                    {
                        yield return null;
                    }
                    ADKIDBJCAJA.NLDKLFODOJJ();
                    ADKIDBJCAJA.LHGPAJGIAME = Time.realtimeSinceStartup;
                    break;
                }
                // L 573
                if(ADKIDBJCAJA.CJMFJOMECKI_ErrorId == /*1*/SakashoErrorId.INTERNAL_SERVER_ERROR)
                {
                    NELKBIEGFIF(ADKIDBJCAJA);
                }
                if(ADKIDBJCAJA.CJMFJOMECKI_ErrorId == /*170*/SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
                {
                    LMBLIFCNKCJ = true;
                }
                if(EHLBPCGHLCL(ADKIDBJCAJA, ADKIDBJCAJA.CJMFJOMECKI_ErrorId, true))
                {
                    MFNENCLNGKF = MFNENCLNGKF + 1;
                    OANLLFOHEPJ = OANLLFOHEPJ + 1;
                    if(ADKIDBJCAJA.CFICLNJACCD > MFNENCLNGKF)
                    {
                        yield return new WaitForSeconds(0);
                        //To6
                        continue;
                    }
                }
                // L625
                if(ADKIDBJCAJA.NBFDEFGFLPJ != null)
                {
                    if(ADKIDBJCAJA.NBFDEFGFLPJ(ADKIDBJCAJA.CJMFJOMECKI_ErrorId))
                    {
                        break;
                    }
                }
                bool APGOAMNGFFF = false;
                yield return N.a.StartCoroutineWatched(MELKAFEGNMD(ADKIDBJCAJA, ADKIDBJCAJA.CJMFJOMECKI_ErrorId, errorResponse, errorJSon, () => {
                    //0x933250
                    APGOAMNGFFF = true;
                }));
                // L 663
                // To7
                if(!APGOAMNGFFF)
                {
                    break;
                }
                OANLLFOHEPJ = OANLLFOHEPJ + 1;
                MFNENCLNGKF = 0;
                //goto LAB_00933f38; // To6
            }
            else
            {
                yield return N.a.StartCoroutineWatched(GGOECCJJPFN(ADKIDBJCAJA));
                // To3
                KADMOOOMMJF = true;
                ADKIDBJCAJA.NPNNPNAIONN_IsError = true;
                ADKIDBJCAJA.CJMFJOMECKI_ErrorId = 0;
                break;
            }
        }
        ADKIDBJCAJA.PLOOEECNHFB_IsDone = true;
        CACGCMBKHDI_Request.HDHIKGLMOGF a = null;
        if(!KADMOOOMMJF)
        {
            a = ADKIDBJCAJA.BHFHGFKBOHH_OnSuccess;
            if(a == null)
            {
    	        //UnityEngine.Debug.Log("Exit NBCKHIAINIM_Coroutine_Execute");
                yield break;
            }
        }
        else
        {
            UnityEngine.Debug.LogError("NBCKHIAINIM_Coroutine_Execute Error");
            a = ADKIDBJCAJA.MOBEEPPKFLG_OnFail;
            if(a == null)
            {
    	        UnityEngine.Debug.LogError("Exit  Error NBCKHIAINIM_Coroutine_Execute");
                yield break;
            }
        }
        a(ADKIDBJCAJA);
		if(KADMOOOMMJF)
			UnityEngine.Debug.LogError("Exit Error NBCKHIAINIM_Coroutine_Execute");
		//UnityEngine.Debug.Log("Exit "+(KADMOOOMMJF?" Error":"")+" NBCKHIAINIM_Coroutine_Execute");
	}

    // // RVA: 0x931E18 Offset: 0x931E18 VA: 0x931E18
    private bool EHLBPCGHLCL(CACGCMBKHDI_Request ADKIDBJCAJA, SakashoErrorId KLCMLLLIANB, bool OHPAOJNLDJO) 
    {
        TodoLogger.LogError(0, "TODO");
        return false;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C35F0 Offset: 0x6C35F0 VA: 0x6C35F0
    // // RVA: 0x931F34 Offset: 0x931F34 VA: 0x931F34
    private IEnumerator MELKAFEGNMD(CACGCMBKHDI_Request ADKIDBJCAJA, SakashoErrorId KLCMLLLIANB, int MJACIGCPNDA, string IIGAKOKGKIB, EHLCCMEDIOH IICBBDEPBAM)
    {
    	//UnityEngine.Debug.Log("Enter MELKAFEGNMD");
        TodoLogger.LogError(0, "TODO");
    	//UnityEngine.Debug.Log("Exit MELKAFEGNMD");
        yield break;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3668 Offset: 0x6C3668 VA: 0x6C3668
    // // RVA: 0x932064 Offset: 0x932064 VA: 0x932064
    private IEnumerator AOMMJNJGFEL(CACGCMBKHDI_Request ADKIDBJCAJA, KPKEOIJHIMN.GIDACIOHFNN CMCKNKKCNDK_Status)
    {
    	//UnityEngine.Debug.Log("Enter AOMMJNJGFEL");
        TodoLogger.LogError(0, "TODO");
    	//UnityEngine.Debug.Log("Exit AOMMJNJGFEL");
        yield break;
    }

    // // RVA: 0x9316EC Offset: 0x9316EC VA: 0x9316EC
    private void DDBHLHBJEGP(PJKLMCGEJMK.AHADNLCOPOL HOENAFAJMGI)
    {
        if(DMPHNPAFHEG == null || CMCKNKKCNDK_Status == HOENAFAJMGI)
            return;
        if(HOENAFAJMGI != PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running)
        {
            DMPHNPAFHEG(false);
            return;
        }
        if(!OLBAIKLLIFE)
            DMPHNPAFHEG(true);
    }

    // // RVA: 0x932144 Offset: 0x932144 VA: 0x932144
    public void CEEAFKHANJB(int EAABKFGHKBG, int ABFKANCAMPN)
	{
        int val = 0;
        float fVal = 0;
        if(EAABKFGHKBG < 0)
            val = 0;
        else if(EAABKFGHKBG < 10)
            val = EAABKFGHKBG + 2;
        else
            val = 10;
        NLGJBBGAOLH = val;
        if(ABFKANCAMPN < 1000)
            fVal = 1.0f;
        else if(ABFKANCAMPN < 30001)
            fVal = ABFKANCAMPN / 1000.0f;
        else
            fVal = 30.0f;
        BLKIMNAILKK = fVal / 10.0f;
	}

    // // RVA: 0x9321AC Offset: 0x9321AC VA: 0x9321AC
    private void NELKBIEGFIF(CACGCMBKHDI_Request ADKIDBJCAJA)
    {
        TodoLogger.LogError(0, "TODO");
    }

    // // RVA: 0x9324C8 Offset: 0x9324C8 VA: 0x9324C8
    private void OHFKAECPJPO(CACGCMBKHDI_Request ADKIDBJCAJA)
    {
        object[] objs = new object[6];
        objs[0] = "class=";
        objs[1] = ADKIDBJCAJA.GetType().FullName;
        objs[2] = ",";
        objs[3] = JDIBBDGNFKH;
        objs[4] = "->";
        objs[5] = ADKIDBJCAJA.CKOOCBJGHBI;

        throw new Exception(string.Concat(objs));
    }

    // // RVA: 0x93299C Offset: 0x93299C VA: 0x93299C
    // private static int OMNAPCHLBHF(CACGCMBKHDI ADKIDBJCAJA) { }

    // // RVA: 0x932A64 Offset: 0x932A64 VA: 0x932A64
    // private static int GJNFKJOCKKA(CACGCMBKHDI ADKIDBJCAJA) { }

    // // RVA: 0x932B64 Offset: 0x932B64 VA: 0x932B64
    // private static int CBILGOPCOIG(CACGCMBKHDI ADKIDBJCAJA) { }

    // // RVA: 0x932C38 Offset: 0x932C38 VA: 0x932C38
    // private static bool EDAAKPJIKLE(CACGCMBKHDI ADKIDBJCAJA) { }

    // // RVA: 0x932CD4 Offset: 0x932CD4 VA: 0x932CD4
    private bool BKGNCCKFMPF(CACGCMBKHDI_Request ADKIDBJCAJA, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG)
    {
        TodoLogger.LogError(0, "TODO");
        return false;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C36E0 Offset: 0x6C36E0 VA: 0x6C36E0
    // // RVA: 0x932EDC Offset: 0x932EDC VA: 0x932EDC
    // private IEnumerator NFMEJDJCOOK(CACGCMBKHDI ADKIDBJCAJA, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG) { }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3758 Offset: 0x6C3758 VA: 0x6C3758
    // // RVA: 0x932E1C Offset: 0x932E1C VA: 0x932E1C
    // private IEnumerator EPGFMHDOBAA(CACGCMBKHDI KEABHGFLDJF, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG) { }

    // [IteratorStateMachineAttribute] // RVA: 0x6C37D0 Offset: 0x6C37D0 VA: 0x6C37D0
    // // RVA: 0x932FF4 Offset: 0x932FF4 VA: 0x932FF4
    private IEnumerator GGOECCJJPFN(CACGCMBKHDI_Request ADKIDBJCAJA)
    {
    	//UnityEngine.Debug.Log("Enter GGOECCJJPFN");
        TodoLogger.LogError(0, "TODO");
    	//UnityEngine.Debug.Log("Exit GGOECCJJPFN");
        yield break;
    }

}
