using System.Collections.Generic;
using XeApp.Core.WorkerThread;
using UnityEngine;
using System.Collections;
using XeSys;
using System;
using XeApp;

public delegate void OEEHODIFBIG(bool JKDJCFEBDHC);
public delegate void DLMJDDACNLA(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, bool PANAGHJOMPO);
public delegate void EHLCCMEDIOH();
public delegate void DMADPGMDPHC(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request _ADKIDBJCAJA_action, int MJACIGCPNDA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP);
public delegate void MFKJNKIKBOP(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request _ADKIDBJCAJA_action, int MJACIGCPNDA, IMCBBOAFION KLMFJJCNBIP);
public delegate void DIDEKBFMOBM(SakashoErrorId KLCMLLLIANB, CACGCMBKHDI_Request _ADKIDBJCAJA_action, string LJGOOOMOMMA, IMCBBOAFION KLMFJJCNBIP);
public delegate void IHABJNEGMEA(CACGCMBKHDI_Request _ADKIDBJCAJA_action, int CMCKNKKCNDK, IMCBBOAFION KLMFJJCNBIP);

public class INTERNAL_SEVER_ERROR_EXCEPTION : Exception
{
	public INTERNAL_SEVER_ERROR_EXCEPTION() : base() { }

	// RVA: 0xA0267C Offset: 0xA0267C VA: 0xA0267C
	public INTERNAL_SEVER_ERROR_EXCEPTION(string message) : base(message) { }

	// RVA: 0xA02708 Offset: 0xA02708 VA: 0xA02708
	public INTERNAL_SEVER_ERROR_EXCEPTION(string message, Exception inner) : base(message, inner) { }
}

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
    private long NNODMPKKCJH_RequestId = 1; // 0x18
    private long JDIBBDGNFKH_PrevRequestId = 1; // 0x20
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
    public CACGCMBKHDI_Request IFFNCAFNEAG_AddRequest(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        TodoLogger.Log(TodoLogger.Job, "AddRequest "+_ADKIDBJCAJA_action);
        _ADKIDBJCAJA_action.BNJPAKLNOPA_WorkerThreadQueue = BNJPAKLNOPA_WorkerThreadQueue;
        _ADKIDBJCAJA_action.PLOOEECNHFB_IsDone = false;

        double time = Time.realtimeSinceStartup;
        _ADKIDBJCAJA_action.KINJOEIAHFK_StartTime = time;
        _ADKIDBJCAJA_action.DMOBOIOFPCM_EndTime = time;
        _ADKIDBJCAJA_action.LHGPAJGIAME_ResultTime = time;
        _ADKIDBJCAJA_action.CFICLNJACCD_NumRetry = NLGJBBGAOLH;
        _ADKIDBJCAJA_action.GJAEJFLLKGC_RetryTime = BLKIMNAILKK;
        _ADKIDBJCAJA_action.KAEMPHIPDFN = KAEMPHIPDFN;
        _ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId = NNODMPKKCJH_RequestId;
        NNODMPKKCJH_RequestId++;

        FCICFIAOLAM_RequestList.Add(_ADKIDBJCAJA_action);

        return _ADKIDBJCAJA_action;
    }

    // // RVA: -1 Offset: -1
    // RVA: 0x1AB65FC Offset: 0x1AB65FC VA: 0x1AB65FC
    public T IFFNCAFNEAG_AddRequest<T>(T _ADKIDBJCAJA_action)  where T : CACGCMBKHDI_Request
    { 
        TodoLogger.Log(TodoLogger.Job, "AddRequest "+_ADKIDBJCAJA_action);
        _ADKIDBJCAJA_action.BNJPAKLNOPA_WorkerThreadQueue = BNJPAKLNOPA_WorkerThreadQueue;
        _ADKIDBJCAJA_action.PLOOEECNHFB_IsDone = false;

        double time = Time.realtimeSinceStartup;
        _ADKIDBJCAJA_action.KINJOEIAHFK_StartTime = time;
        _ADKIDBJCAJA_action.DMOBOIOFPCM_EndTime = time;
        _ADKIDBJCAJA_action.LHGPAJGIAME_ResultTime = time;
        _ADKIDBJCAJA_action.CFICLNJACCD_NumRetry = NLGJBBGAOLH;
        _ADKIDBJCAJA_action.GJAEJFLLKGC_RetryTime = BLKIMNAILKK;
        _ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId = NNODMPKKCJH_RequestId;
        NNODMPKKCJH_RequestId++;

        FCICFIAOLAM_RequestList.Add(_ADKIDBJCAJA_action);
        return _ADKIDBJCAJA_action;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3578 Offset: 0x6C3578 VA: 0x6C3578
    // // RVA: 0x93188C Offset: 0x93188C VA: 0x93188C
    private IEnumerator NBCKHIAINIM_Coroutine_Execute(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
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

                if(BKGNCCKFMPF(_ADKIDBJCAJA_action, () => {
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
                            _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = false;
                            KADMOOOMMJF = false;
                        }
                        else
                        {
                            KADMOOOMMJF = true;
                            _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
                        }
                        break;
                    }
                }
            }

            bool enterIf = _ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId >= JDIBBDGNFKH_PrevRequestId;
            if(!enterIf)
            {
                OHFKAECPJPO(_ADKIDBJCAJA_action);
                enterIf = !BLFILNOBHMM;
            }
            if(enterIf)
            {
                _ADKIDBJCAJA_action.OGPFKGAKOFD();
                JDIBBDGNFKH_PrevRequestId = _ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId;
                float MEMLLCDHAIF = 0.0f;
                SakashoAPICallContext GPBPFELFMFL = _ADKIDBJCAJA_action.EBGACDGNCAA_CallContext;
                //LAB_00934228
                while(!_ADKIDBJCAJA_action.EFGFPCBGDDK)
                {
                    MEMLLCDHAIF = MEMLLCDHAIF + Time.deltaTime;
                    if(MEMLLCDHAIF >= _ADKIDBJCAJA_action.ICDEFIIADDO_Timeout && GPBPFELFMFL != null)
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
                _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId = 0;
                KADMOOOMMJF = false;
                IEBFCJACLPN.LHPDDGIJKNB_Reset();
                SakashoError error = _ADKIDBJCAJA_action.ANMFDAGDMDE_Error;
                string errorJSon = null;
                int errorResponse = 0;
                if(error == null)
                {
                    OBOKMHHMOIL_ServerInfo b = _ADKIDBJCAJA_action.HOHOBEOJPBK_ServerInfo;
                    if(b != null)
                    {
                        if(b.LCAINKFINEI_ServerCurrentDateTime != 0)
                        {
                            HFMOEKIBNKA.EAJMLOKKOOK_SetServerTime(b.LCAINKFINEI_ServerCurrentDateTime);
                            NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK = false;
                        }
                        if(!string.IsNullOrEmpty(b.ABFADMDAAKJ_SakashoRecommendedClientVersion))
                        {
                            IEFOIIAEBBJ = true;
                        }
                        IEBFCJACLPN.ODDIHGPONFL_Copy(b);
                        OPFEFKOOMED.EHMKHLIGFEJ(b);
                    }
                }
                else
                {
                    _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId = error.getErrorId();
                    errorJSon = error.ErrorDetailJSON;
                    errorResponse = error.ResponseCode;
                    KADMOOOMMJF = true;
                }
                _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = KADMOOOMMJF;
                if(JBPEHAHCBLK)
                {
                    if(!_ADKIDBJCAJA_action.AILPHBMCCGP || OMAGHCDMBBI == null)
                    {
                        //LAB_009346e8:
                        _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
                        _ADKIDBJCAJA_action.PDAPLCPOCMA = true;
                        KADMOOOMMJF = true;
                        break;
                    }
                    DMGPJMPINFJ = true;
                    bool NEFPJAHDAJJ = false;
                    bool EEBKLFOBGPM = false;
                    _ADKIDBJCAJA_action.BOPHNJFGJBN();
                    OMAGHCDMBBI(() => {
                        //0x933230
                        NEFPJAHDAJJ = true;
                        EEBKLFOBGPM = true;
                    }, () => {
                        //0x93323C
                        NEFPJAHDAJJ = true;
                    }, !_ADKIDBJCAJA_action.ICFMKEFJOIE);
                    //LAB_00933cac:
                    while(!NEFPJAHDAJJ)
                    {
                        yield return null;
                    }
                    _ADKIDBJCAJA_action.EHLFONGENNK();
                    if(!EEBKLFOBGPM)
                    {
                        //goto LAB_009346e8;
                        _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
                        _ADKIDBJCAJA_action.PDAPLCPOCMA = true;
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
                        yield return N.a.StartCoroutineWatched(AOMMJNJGFEL_Coroutine_VersionError(_ADKIDBJCAJA_action, val));
                        // To 8
                        KADMOOOMMJF = true;
                        _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
                        _ADKIDBJCAJA_action.JONHGMCILHM = true;
                        break;
                    }
                    // L 556
                    _ADKIDBJCAJA_action.DMOBOIOFPCM_EndTime = Time.realtimeSinceStartup;
                    _ADKIDBJCAJA_action.MGFNKDPHFGI(N.a);
                    //goto LAB_00933de0;
                    // To 9
                    while(!_ADKIDBJCAJA_action.EBPLLJGPFDA_HasResult)
                    {
                        yield return null;
                    }
                    _ADKIDBJCAJA_action.NLDKLFODOJJ();
                    _ADKIDBJCAJA_action.LHGPAJGIAME_ResultTime = Time.realtimeSinceStartup;
                    break;
                }
                // L 573
                if(_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId == /*1*/SakashoErrorId.INTERNAL_SERVER_ERROR)
                {
                    NELKBIEGFIF(_ADKIDBJCAJA_action);
                }
                if(_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId == /*170*/SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
                {
                    LMBLIFCNKCJ = true;
                }
                if(EHLBPCGHLCL(_ADKIDBJCAJA_action, _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId, true))
                {
                    MFNENCLNGKF = MFNENCLNGKF + 1;
                    OANLLFOHEPJ = OANLLFOHEPJ + 1;
                    if(_ADKIDBJCAJA_action.CFICLNJACCD_NumRetry > MFNENCLNGKF)
                    {
                        yield return new WaitForSeconds(0);
                        //To6
                        continue;
                    }
                }
                // L625
                if(_ADKIDBJCAJA_action.NBFDEFGFLPJ != null)
                {
                    if(_ADKIDBJCAJA_action.NBFDEFGFLPJ(_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId))
                    {
                        break;
                    }
                }
                bool APGOAMNGFFF = false;
                yield return N.a.StartCoroutineWatched(MELKAFEGNMD_Coroutine_SakashoError(_ADKIDBJCAJA_action, _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId, errorResponse, errorJSon, () => {
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
                yield return N.a.StartCoroutineWatched(GGOECCJJPFN_Coroutine_ShowRevertFatalError(_ADKIDBJCAJA_action));
                // To3
                KADMOOOMMJF = true;
                _ADKIDBJCAJA_action.NPNNPNAIONN_IsError = true;
                _ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId = 0;
                break;
            }
        }
        _ADKIDBJCAJA_action.PLOOEECNHFB_IsDone = true;
        CACGCMBKHDI_Request.HDHIKGLMOGF a = null;
        if(!KADMOOOMMJF)
        {
            a = _ADKIDBJCAJA_action.BHFHGFKBOHH_OnSuccess;
            if(a == null)
            {
                yield break;
            }
        }
        else
        {
            a = _ADKIDBJCAJA_action.MOBEEPPKFLG_OnFail;
            if(a == null)
            {
                yield break;
            }
        }
        a(_ADKIDBJCAJA_action);
	}

    // // RVA: 0x931E18 Offset: 0x931E18 VA: 0x931E18
    private bool EHLBPCGHLCL(CACGCMBKHDI_Request _ADKIDBJCAJA_action, SakashoErrorId KLCMLLLIANB, bool OHPAOJNLDJO) 
    {
		if(!_ADKIDBJCAJA_action.BNCFONNOHFO)
		{
			if(JGJFFKPFMDB.BDPBNKPKAJJ(KLCMLLLIANB) != GOBDOEHKLHN.KLPAIDGGGCN_5/*5*/)
			{
				if(JGJFFKPFMDB.BDPBNKPKAJJ(KLCMLLLIANB) == GOBDOEHKLHN.FJGMPDJFELN_4/*4*/)
				{
					if(KLCMLLLIANB != SakashoErrorId.INTERNAL_SERVER_ERROR && !_ADKIDBJCAJA_action.OIDCBBGLPHL)
					{
						return KLCMLLLIANB == SakashoErrorId.NETWORK_ERROR && !OHPAOJNLDJO;
					}
				}
				else if(KLCMLLLIANB != SakashoErrorId.INTERNAL_SERVER_ERROR)
					return KLCMLLLIANB == SakashoErrorId.NETWORK_ERROR && !OHPAOJNLDJO;
			}
			return true;
		}
        return false;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C35F0 Offset: 0x6C35F0 VA: 0x6C35F0
    // // RVA: 0x931F34 Offset: 0x931F34 VA: 0x931F34
    private IEnumerator MELKAFEGNMD_Coroutine_SakashoError(CACGCMBKHDI_Request _ADKIDBJCAJA_action, SakashoErrorId KLCMLLLIANB, int MJACIGCPNDA, string IIGAKOKGKIB, EHLCCMEDIOH IICBBDEPBAM)
    {
        string AIEEDMCGNAE; // 0x30
        string NPOFLDNNKAO; // 0x34

        //0x934E88
        yield return null;
        bool KOMKKBDABJP = false;
        GOBDOEHKLHN p = JGJFFKPFMDB.BDPBNKPKAJJ(KLCMLLLIANB);
        if(KLCMLLLIANB == SakashoErrorId.MONTHLY_TOTAL_AMOUNT_OVER)
        {
            TodoLogger.LogError(TodoLogger.MonthlyPass, "SakashoError " + KLCMLLLIANB);
        }
        if(p != GOBDOEHKLHN.EJHJJEBEHMG_8)
        {
            if(!EHLBPCGHLCL(_ADKIDBJCAJA_action, KLCMLLLIANB, false))
            {
                if(IGAMFDCEGFC == null)
                    yield break;
                _ADKIDBJCAJA_action.BOPHNJFGJBN();
                IGAMFDCEGFC(KLCMLLLIANB, _ADKIDBJCAJA_action, MJACIGCPNDA, () =>
                {
                    //0x9332C4
                    KOMKKBDABJP = true;
                });
                while(!KOMKKBDABJP)
                    yield return null;
                _ADKIDBJCAJA_action.EHLFONGENNK();
                yield break;
            }
            if(LJPJJHGIEAO == null)
                yield break;
            bool AAIOCNJGNEN = false;
            DMGPJMPINFJ = true;
            _ADKIDBJCAJA_action.BOPHNJFGJBN();
            LJPJJHGIEAO(KLCMLLLIANB, _ADKIDBJCAJA_action, MJACIGCPNDA, () =>
            {
                //0x9332D8
                KOMKKBDABJP = true;
                AAIOCNJGNEN = true;
            }, () =>
            {
                //0x9332B8
                KOMKKBDABJP = true;
            });
            while(!KOMKKBDABJP)
                yield return null;
            _ADKIDBJCAJA_action.EHLFONGENNK();
            if(AAIOCNJGNEN)
            {
                DMGPJMPINFJ = false;
                IICBBDEPBAM();
            }
            yield break;
        }
        if(KLCMLLLIANB < SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
        {
            if(KLCMLLLIANB != SakashoErrorId.PURCHASING_FAILED)
            {
                if(KLCMLLLIANB != SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
                    yield break;
                if(NIJMLFNDAJP == null)
                    yield break;
                DMGPJMPINFJ = true;
                while(true)
                {
                    KOMKKBDABJP = false;
                    _ADKIDBJCAJA_action.BOPHNJFGJBN();
                    NIJMLFNDAJP(KLCMLLLIANB, _ADKIDBJCAJA_action, "", () =>
                    {
                        //0x933270
                        KOMKKBDABJP = true;
                    });
                    while(!KOMKKBDABJP)
                        yield return null;
                    _ADKIDBJCAJA_action.EHLFONGENNK();
                    if(_ADKIDBJCAJA_action.GEKKKPIIOAF != null)
                    {
                        NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(_ADKIDBJCAJA_action.GEKKKPIIOAF);
                    }
                    yield return null;
                }
            }
        }
        else 
        {
            if(KLCMLLLIANB == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
            {
                if(LLFDDHIIPBK == null)
                    yield break;
                if(_ADKIDBJCAJA_action.EOPCHGLLONF)
                    yield break;
                AIEEDMCGNAE = null;
                if(_ADKIDBJCAJA_action.HIBMKLEJEDP != null)
                {
                    AIEEDMCGNAE = _ADKIDBJCAJA_action.HIBMKLEJEDP.KLMPFGOCBHC;
                }
                DMGPJMPINFJ = true;
                if(AppEnv.IsCBT() && !string.IsNullOrEmpty(AIEEDMCGNAE))
                {
                    if(AIEEDMCGNAE.Contains("CBT_END_URL="))
                    {
                        NPOFLDNNKAO = "";
                        string[] strs = AIEEDMCGNAE.Split('\n');
                        for(int i = 0; i < strs.Length; i++)
                        {
                            if(strs[i].Contains("CBT_END_URL="))
                            {
                                NPOFLDNNKAO = strs[i].Substring("CBT_END_URL=".Length);
                                break;
                            }
                        }
                        if(!string.IsNullOrEmpty(NPOFLDNNKAO))
                        {
                            while(true)
                            {
                                KOMKKBDABJP = false;
                                JHHBAFKMBDL.HHCJCDFCLOB.LHHMCNLONCI(() =>
                                {
                                    //0x93327C
                                    KOMKKBDABJP = true;
                                }, NPOFLDNNKAO);
                                while(!KOMKKBDABJP)
                                    yield return null;
                            }
                        }
                        NPOFLDNNKAO = null;
                    }
                }
                if(UMO_PlayerPrefs.GetInt("cpid", 0) == 0)
                {
                    while(true)
                    {
                        KOMKKBDABJP = false;
                        _ADKIDBJCAJA_action.BOPHNJFGJBN();
                        LLFDDHIIPBK(KLCMLLLIANB, _ADKIDBJCAJA_action, AIEEDMCGNAE, () =>
                        {
                            //0x933288
                            KOMKKBDABJP = true;
                        });
                        while(!KOMKKBDABJP)
                            yield return null;
                        _ADKIDBJCAJA_action.EHLFONGENNK();
                        yield return null;
                    }
                }
                _ADKIDBJCAJA_action.BOPHNJFGJBN();
                LLFDDHIIPBK(KLCMLLLIANB, _ADKIDBJCAJA_action, AIEEDMCGNAE, () =>
                {
                    //0x933294
                    KOMKKBDABJP = true;
                });
                while(!KOMKKBDABJP)
                    yield return null;
                _ADKIDBJCAJA_action.EHLFONGENNK();
                AIEEDMCGNAE = null;
                yield break;
            }
            if(KLCMLLLIANB == SakashoErrorId.PLAYER_ACCOUNT_STATUS_IS_SERVER_ACCESS_DENY)
            {
                if(CCBAMLACFCF == null)
                    yield break;
                DMGPJMPINFJ = true;
                CCBAMLACFCF(KLCMLLLIANB, _ADKIDBJCAJA_action, JGJFFKPFMDB.NCDHNMILIOJ(KLCMLLLIANB, false), () =>
                {
                    //0x9332A0
                    KOMKKBDABJP = true;
                });
                while(!KOMKKBDABJP)
                    yield return null;
                _ADKIDBJCAJA_action.EHLFONGENNK();
                yield break;
            }
            if(KLCMLLLIANB != SakashoErrorId.PURCHASING_DEFERRED)
                yield break;
        }
        _ADKIDBJCAJA_action.BOPHNJFGJBN();
        IGAMFDCEGFC(KLCMLLLIANB, _ADKIDBJCAJA_action, MJACIGCPNDA, () =>
        {
            //0x9332AC
            KOMKKBDABJP = true;
        });
        while(!KOMKKBDABJP)
            yield return null;
        _ADKIDBJCAJA_action.EHLFONGENNK();
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3668 Offset: 0x6C3668 VA: 0x6C3668
    // // RVA: 0x932064 Offset: 0x932064 VA: 0x932064
    private IEnumerator AOMMJNJGFEL_Coroutine_VersionError(CACGCMBKHDI_Request _ADKIDBJCAJA_action, KPKEOIJHIMN.GIDACIOHFNN CMCKNKKCNDK_Status)
    {
        //0x937760
        yield return null;
        if(EGAOFAHEPME == null)
            yield break;
        bool KOMKKBDABJP = false;
        DMGPJMPINFJ = false;
        _ADKIDBJCAJA_action.BOPHNJFGJBN();
        EGAOFAHEPME(_ADKIDBJCAJA_action, (int)CMCKNKKCNDK_Status, () =>
        {
            //0x933310
            KOMKKBDABJP = true;
        });
        while(!KOMKKBDABJP)
            yield return null;
        _ADKIDBJCAJA_action.EHLFONGENNK();
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
    private void NELKBIEGFIF(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        if(_ADKIDBJCAJA_action.ANMFDAGDMDE_Error == null)
            return;
        string str = "class=" + _ADKIDBJCAJA_action.GetType().FullName;
        if(_ADKIDBJCAJA_action.ANMFDAGDMDE_Error.ErrorDetailJSON == null)
        {
            str += "," + _ADKIDBJCAJA_action.ANMFDAGDMDE_Error.ErrorDetailJSON;
        }
        throw new INTERNAL_SEVER_ERROR_EXCEPTION(str);
    }

    // // RVA: 0x9324C8 Offset: 0x9324C8 VA: 0x9324C8
    private void OHFKAECPJPO(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        object[] objs = new object[6];
        objs[0] = "class=";
        objs[1] = _ADKIDBJCAJA_action.GetType().FullName;
        objs[2] = ",";
        objs[3] = JDIBBDGNFKH_PrevRequestId;
        objs[4] = "->";
        objs[5] = _ADKIDBJCAJA_action.CKOOCBJGHBI_RequestId;

        throw new Exception(string.Concat(objs));
    }

    // // RVA: 0x93299C Offset: 0x93299C VA: 0x93299C
    private static int OMNAPCHLBHF_GetPurchaseCurrencyId(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        if(_ADKIDBJCAJA_action != null)
        {
            CBMFOOHOAOE_Purchase p = _ADKIDBJCAJA_action as CBMFOOHOAOE_Purchase;
            if(p != null)
                return p.APHNELOFGAK_CurrencyId;
            IHJEDAFEJHH_StepUpLotPurchase p2 = _ADKIDBJCAJA_action as IHJEDAFEJHH_StepUpLotPurchase;
            if(p2 != null)
                return p2.APHNELOFGAK_CurrencyId;
        }
        return 0;
    }

    // // RVA: 0x932A64 Offset: 0x932A64 VA: 0x932A64
    private static int GJNFKJOCKKA_GetTotalCurrency(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        CBMFOOHOAOE_Purchase p = _ADKIDBJCAJA_action as CBMFOOHOAOE_Purchase;
        if(p != null)
        {
            return p.LGEKLPJFJEI_TotalCurrency;
        }
        FNPBAENIEPG_PurchaseAndSave p2 = _ADKIDBJCAJA_action as FNPBAENIEPG_PurchaseAndSave;
        if(p2 != null)
        {
            return p2.LGEKLPJFJEI_TotalCurrency;
        }
        return 0;
    }

    // // RVA: 0x932B64 Offset: 0x932B64 VA: 0x932B64
    private static int CBILGOPCOIG(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        CBMFOOHOAOE_Purchase p = _ADKIDBJCAJA_action as CBMFOOHOAOE_Purchase;
        if(p != null)
        {
            return p.LGEKLPJFJEI_TotalCurrency != 0 ? 1 : 0;
        }
        return 0;
    }

    // // RVA: 0x932C38 Offset: 0x932C38 VA: 0x932C38
    private static bool EDAAKPJIKLE(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        if(_ADKIDBJCAJA_action != null)
        {
            CBMFOOHOAOE_Purchase p = _ADKIDBJCAJA_action as CBMFOOHOAOE_Purchase;
            return p.JJHCNJKPAOK;
        }
        return false;
    }

    // // RVA: 0x932CD4 Offset: 0x932CD4 VA: 0x932CD4
    private bool BKGNCCKFMPF(CACGCMBKHDI_Request _ADKIDBJCAJA_action, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG)
    {
        int a1 = OMNAPCHLBHF_GetPurchaseCurrencyId(_ADKIDBJCAJA_action);
        if(a1 != 2 && a1 > 0)
        {
            if(EDAAKPJIKLE(_ADKIDBJCAJA_action))
            {
                N.a.StartCoroutineWatched(EPGFMHDOBAA_Coroutine_ValidateFreeProductStatus(_ADKIDBJCAJA_action, BHFHGFKBOHH, LNGMPEGMLBN, AOCANKOMKFG));
            }
            else
            {
                N.a.StartCoroutineWatched(NFMEJDJCOOK_Coroutine_ValidateCurrencyBalance(_ADKIDBJCAJA_action, BHFHGFKBOHH, LNGMPEGMLBN, AOCANKOMKFG));
            }
            return true;
        }
        return false;
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C36E0 Offset: 0x6C36E0 VA: 0x6C36E0
    // // RVA: 0x932EDC Offset: 0x932EDC VA: 0x932EDC
    private IEnumerator NFMEJDJCOOK_Coroutine_ValidateCurrencyBalance(CACGCMBKHDI_Request _ADKIDBJCAJA_action, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG)
    {
        int ALFDBMDGJOH_TotalCurrency; // 0x2C
        int GHKLCJHAFME; // 0x30
        int[] JIELFJKDNKM; // 0x34
        int BFALAMHCKGF; // 0x38

        //0x9363A0
        int CPGFOBNKKBF_CurrencyId = OMNAPCHLBHF_GetPurchaseCurrencyId(_ADKIDBJCAJA_action);
        ALFDBMDGJOH_TotalCurrency = GJNFKJOCKKA_GetTotalCurrency(_ADKIDBJCAJA_action);
        GHKLCJHAFME = CBILGOPCOIG(_ADKIDBJCAJA_action);
        JIELFJKDNKM = new int[1] { CPGFOBNKKBF_CurrencyId };
        BFALAMHCKGF = 2;
        List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ = new List<MCKCJMLOAFP_CurrencyInfo>();
        bool BEKAMBBOLBO = false;
        bool CNAIDEAFAAM = false;
        for(int BMBBDIAEOMP = 0; BMBBDIAEOMP < BFALAMHCKGF; BMBBDIAEOMP++)
        {
            BEKAMBBOLBO = false;
            CNAIDEAFAAM = false;
            SakashoErrorId CPILGOCFBNM = 0;
            int ACNDNOEBONM_CurrencyTotal = -1;
            BBEPLKNMICJ.Clear();
            SakashoPayment.GetRemainingForCurrencyIds(JIELFJKDNKM, (string IDLHJIOMJBK) =>
            {
                //0x933384
                EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(IDLHJIOMJBK);
                if(json.BBAJPINMOEP_Contains("balances"))
                {
                    for(int i = 0; i < json["balances"].HNBFOAJIIAL_Count; i++)
                    {
                        MCKCJMLOAFP_CurrencyInfo m = new MCKCJMLOAFP_CurrencyInfo();
                        m.DPKCOKLMFMK(json["balances"][i]);
                        if(m.PPFNGGCBJKC_Id == CPGFOBNKKBF_CurrencyId)
                        {
                            ACNDNOEBONM_CurrencyTotal = m.BDLNMOIOMHK_Total;
                        }
                        BBEPLKNMICJ.Add(m);
                    }
                }
                BEKAMBBOLBO = true;
            }, (SakashoError PPGMIGODOJH) =>
            {
                //0x933630
                CPILGOCFBNM = PPGMIGODOJH.getErrorId();
                BEKAMBBOLBO = true;
                CNAIDEAFAAM = true;
            });
            while(!BEKAMBBOLBO)
                yield return null;
            if(CNAIDEAFAAM)
            {
                if(((int)JGJFFKPFMDB.BDPBNKPKAJJ(CPILGOCFBNM) & 0xfffffffe) == 4)
                {
                    yield return new WaitForSeconds(3);
                    continue;
                }
                break;
            }
            if(GHKLCJHAFME == 0)
            {
                if(ACNDNOEBONM_CurrencyTotal != ALFDBMDGJOH_TotalCurrency)
                    break;
                //LAB_00936a18
                BHFHGFKBOHH();
                yield break;
            }
            if(ACNDNOEBONM_CurrencyTotal == ALFDBMDGJOH_TotalCurrency)
            {
                BHFHGFKBOHH();
                yield break;
            }
            if(ACNDNOEBONM_CurrencyTotal != ALFDBMDGJOH_TotalCurrency)
            {
                FNPBAENIEPG_PurchaseAndSave p2 = _ADKIDBJCAJA_action as FNPBAENIEPG_PurchaseAndSave;
                if(p2 != null)
                {
                    p2.MJMAHKAKPCG(BBEPLKNMICJ);
                }
                LNGMPEGMLBN();
                yield break;
            }
            //LAB_00936638
        }
        //LAB_00936a20
        _ADKIDBJCAJA_action.BOPHNJFGJBN();
        JHHBAFKMBDL.HHCJCDFCLOB.LOMNLGIDLKO(() =>
        {
            //0x933324
            _ADKIDBJCAJA_action.EHLFONGENNK();
            AOCANKOMKFG();
        });
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C3758 Offset: 0x6C3758 VA: 0x6C3758
    // // RVA: 0x932E1C Offset: 0x932E1C VA: 0x932E1C
    private IEnumerator EPGFMHDOBAA_Coroutine_ValidateFreeProductStatus(CACGCMBKHDI_Request KEABHGFLDJF, IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION LNGMPEGMLBN, DJBHIFLHJLK AOCANKOMKFG)
    {
        SakashoProductCriteria GHDBABPAHKN; // 0x28
        int OANJJGMJEKH; // 0x2C

        //0x936E48
        CBMFOOHOAOE_Purchase _ADKIDBJCAJA_action = KEABHGFLDJF as CBMFOOHOAOE_Purchase;
        int AFKAGFOFAHM_ProductId = _ADKIDBJCAJA_action.AFKAGFOFAHM_ProductId;
        GHDBABPAHKN = new SakashoProductCriteria();
        GHDBABPAHKN.CurrencyId = _ADKIDBJCAJA_action.APHNELOFGAK_CurrencyId;
        GHDBABPAHKN.Label = _ADKIDBJCAJA_action.ICKAMKNDAEB_Label;
        GHDBABPAHKN.ProductType = _ADKIDBJCAJA_action.LHMIIJEALCA_Type;
        OANJJGMJEKH = 2;
        bool BEKAMBBOLBO = false;
        bool CNAIDEAFAAM = false;
        bool OGBNBEKLCKC_ProductFound = false;
        bool GGEPAAJJPGI_NextFree = false;
        for(int BMBBDIAEOMP = 0; BMBBDIAEOMP < OANJJGMJEKH; BMBBDIAEOMP++)
        {
            BEKAMBBOLBO = false;
            CNAIDEAFAAM = false;
            SakashoErrorId CPILGOCFBNM_ErrorId = 0;
            SakashoPayment.GetProducts(GHDBABPAHKN, 1, 30, (string IDLHJIOMJBK) =>
            {
                //0x933724
                EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(IDLHJIOMJBK);
                if(json.BBAJPINMOEP_Contains("products"))
                {
                    for(int i = 0; i < json["products"].HNBFOAJIIAL_Count; i++)
                    {
                        if((int)json["products"][i]["id"] == AFKAGFOFAHM_ProductId)
                        {
                            OGBNBEKLCKC_ProductFound = true;
                            if(json["product"][i].BBAJPINMOEP_Contains("player_normal_lot_free_state"))
                            {
                                if((bool)json["product"][i]["player_normal_lot_free_state"]["is_next_free"])
                                {
                                    GGEPAAJJPGI_NextFree = true;
                                }
                            }
                            break;
                        }
                    }
                    BEKAMBBOLBO = true;
                }
            }, (SakashoError PPGMIGODOJH) =>
            {
                //0x933AA4
                CPILGOCFBNM_ErrorId = PPGMIGODOJH.getErrorId();
                BEKAMBBOLBO = true;
                CNAIDEAFAAM = true;
            });
            while(!BEKAMBBOLBO)
                yield return null;
            if(CNAIDEAFAAM)
            {
                if(((int)JGJFFKPFMDB.BDPBNKPKAJJ(CPILGOCFBNM_ErrorId) & 0xfffffffe) == 4)
                {
                    yield return new WaitForSeconds(3);
                    continue;
                }
                break;
            }
            if(!GGEPAAJJPGI_NextFree)
                break;
            if(GGEPAAJJPGI_NextFree)
            {
                BHFHGFKBOHH();
                yield break;
            }
            if(!OGBNBEKLCKC_ProductFound)
                break;
            //LAB_00937184
        }
        _ADKIDBJCAJA_action.BOPHNJFGJBN();
        JHHBAFKMBDL.HHCJCDFCLOB.LOMNLGIDLKO(() =>
        {
            //0x9336CC
            _ADKIDBJCAJA_action.EHLFONGENNK();
            AOCANKOMKFG();
        });
    }

    // [IteratorStateMachineAttribute] // RVA: 0x6C37D0 Offset: 0x6C37D0 VA: 0x6C37D0
    // // RVA: 0x932FF4 Offset: 0x932FF4 VA: 0x932FF4
    private IEnumerator GGOECCJJPFN_Coroutine_ShowRevertFatalError(CACGCMBKHDI_Request _ADKIDBJCAJA_action)
    {
        //0x93612C
        bool BEKAMBBOLBO = false;
        _ADKIDBJCAJA_action.BOPHNJFGJBN();
        JHHBAFKMBDL.HHCJCDFCLOB.OODNEKINHLO_ShowError(() =>
        {
            //0x933B40
            BEKAMBBOLBO = true;
        });
        while(!BEKAMBBOLBO)
            yield return null;
        _ADKIDBJCAJA_action.EHLFONGENNK();
    }

}
