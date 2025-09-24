
using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class HGFPAFPGIKG
{
    public enum FHOKKDKGGJI
    {
        HJNNKCMLGFL_0_None = 0,
        KENKGHLELHP_1 = 1,
        PDEGHEGBDBE_2 = 2,
    }

    public enum GDEJHABHLFH
    {
        HJNNKCMLGFL_0_None = 0,
        HPFFBANMJOD_1 = 1,
        CPLKGJJFJKA_2 = 2,
        DAFJKGJDAND_3 = 3,
        BEJJEGKLGMP_4 = 4,
        EOAFEBEENLI_5 = 5,
    }

    public enum FBGKMBHEOBC
    {
        HJNNKCMLGFL_0_None = 0,
        JIFGIDIGBMA = 1,
        HCOLMJNKMEG = 2,
    }

    public enum KAFHMMOGLKO
    {
        FAFCPLEAFCP_0_Summer = 0,
        DALFBOFBJJL_1_NewYear = 1,
        AIMPCCIHKAJ_2 = 2,
    }

    public class JAKMCKNADCE
    {
        public int PPFNGGCBJKC_id; // 0x8
        public int GLCLFMGPMAN_ItemId; // 0xC
        public int LJKMKCOAICL_ItemCount; // 0x10
        public int LIDBKCIMCKE_rarity; // 0x14
        public string OPFGFINHFCE_name; // 0x18
        public bool JOPPFEHKNFO_Pickup; // 0x1C
    }

    public class CMEDMHFOFAH : JAKMCKNADCE
    {
        public int OIPCCBHIKIA_index; // 0x20
        public int NNCCGILOOIE_Num; // 0x24 Remain
        public int BFGKGMOLAFL_Max; // 0x28
    }
 
    public class LBEPCOMCHNE
    {
        public int PPFNGGCBJKC_id; // 0x8
        public FHOKKDKGGJI IIKIOIKEGMM; // 0xC
        public GDEJHABHLFH FKDOMKHHOCD_CenterSkillCondition; // 0x10
        public FBGKMBHEOBC INDDJNMPONH_type; // 0x14
        public int EILKGEADKGH_Order; // 0x18
        public string EIGFHDMDECG_CharaText; // 0x1C
        public int BKCIPBIHKJG_CharaId; // 0x20

        // // RVA: 0x174D4EC Offset: 0x174D4EC VA: 0x174D4EC
        public void ODDIHGPONFL_Copy(LBEPCOMCHNE IJAOGPFKDBP)
        {
            PPFNGGCBJKC_id = IJAOGPFKDBP.PPFNGGCBJKC_id;
            IIKIOIKEGMM = IJAOGPFKDBP.IIKIOIKEGMM;
            FKDOMKHHOCD_CenterSkillCondition = IJAOGPFKDBP.FKDOMKHHOCD_CenterSkillCondition;
            INDDJNMPONH_type = IJAOGPFKDBP.INDDJNMPONH_type;
            EILKGEADKGH_Order = IJAOGPFKDBP.EILKGEADKGH_Order;
            EIGFHDMDECG_CharaText = IJAOGPFKDBP.EIGFHDMDECG_CharaText;
            BKCIPBIHKJG_CharaId = IJAOGPFKDBP.BKCIPBIHKJG_CharaId;
        }
    }

	private const int NMHGMNGLPFO = 10;
	public long JOFAGCFNKIO_OpenTime; // 0x8
	public long EBCHFBIINDP_End; // 0x10
	public int DMPELKEMCCJ_BoxTotal; // 0x18
	public int JALHJAPAFLK_BoxCurrent; // 0x1C
	public float DHIPGHBJLIL_coef; // 0x20
	public int IMMDGJAOPCD_BoxId; // 0x24
	public int NNCCGILOOIE_Num; // 0x28 ListIdx
	public int JAAOFLAIEOD; // 0x2C
	public int JHNEFBNEAAO; // 0x30
	public int MFHLHIDLKGN_NumTicket; // 0x34
	public int AAIKGPGDHIB_Cost; // 0x38
	public int MLAECGLBCBM_OverStopCnt; // 0x3C
	public bool HCPAAGBDCAO_IsEmpty; // 0x40
	public List<CMEDMHFOFAH> LOMNOJCONHP; // 0x44
	private List<CMEDMHFOFAH> HCIDHHLOPLK; // 0x48
	private List<CMEDMHFOFAH> JJAKKNHDABO; // 0x4C
	private List<LBEPCOMCHNE> LHBBFEHAPGI; // 0x50
	private int DFFEFGHMEOK_EventId; // 0x54
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x58
	public KAFHMMOGLKO ENJLGHMEKEL_Type = KAFHMMOGLKO.AIMPCCIHKAJ_2; // 0x5C

	// RVA: 0x174A67C Offset: 0x174A67C VA: 0x174A67C
	public HGFPAFPGIKG(int _EKANGPODCEP_EventId)
    {
        DFFEFGHMEOK_EventId = _EKANGPODCEP_EventId;
        if(_EKANGPODCEP_EventId == 0)
        {
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived);
            if (ev != null)
            {
                DFFEFGHMEOK_EventId = ev.PGIIDPEGGPI_EventId;
            }
        }
        OBKGEDCKHHE();
    }

	// // RVA: 0x174A77C Offset: 0x174A77C VA: 0x174A77C
	public void OBKGEDCKHHE()
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
            MLAECGLBCBM_OverStopCnt = dbEv.LPJLEHAJADA_GetIntParam("over_stop_cnt", 1);
            ev.AAIAADGEDDN();
            BFDHGPNBNMP(ev);
            HCDGELDHFHB(ev);
        }
    }

	// // RVA: 0x174A948 Offset: 0x174A948 VA: 0x174A948
	public CHHECNJBMLA_EventBoxGacha OEGDCBLNNFF()
    {
        return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(DFFEFGHMEOK_EventId) as CHHECNJBMLA_EventBoxGacha;
    }

	// // RVA: 0x174AA98 Offset: 0x174AA98 VA: 0x174AA98
	public void BFDHGPNBNMP(CHHECNJBMLA_EventBoxGacha _MOHDLLIJELH_cont)
    {
        LOMNOJCONHP = new List<CMEDMHFOFAH>();
        HCIDHHLOPLK = new List<CMEDMHFOFAH>();
        JJAKKNHDABO = new List<CMEDMHFOFAH>();
        LHBBFEHAPGI = new List<LBEPCOMCHNE>();
        LOMNOJCONHP.Clear();
        HCIDHHLOPLK.Clear();
        JJAKKNHDABO.Clear();
        CHHECNJBMLA_EventBoxGacha.MDBEKHIHBJM m = _MOHDLLIJELH_cont.DGBCMNLEDEI();
        if(m != null)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_index = 0;
            LOMNOJCONHP.Add(d);
        }
        for(int i = 0; i < _MOHDLLIJELH_cont.JMLKAGOACAE.Count; i++)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_index = i;
            HCIDHHLOPLK.Add(d);
        }
        for(int i = 0; i < _MOHDLLIJELH_cont.CKFCGDIJKKC.Count; i++)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_index = i;
            JJAKKNHDABO.Add(d);
        }
        FNJCONEDHDO();
    }

	// // RVA: 0x174AE20 Offset: 0x174AE20 VA: 0x174AE20
	public void HCDGELDHFHB(CHHECNJBMLA_EventBoxGacha _MOHDLLIJELH_cont)
    {
        IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ ev = _MOHDLLIJELH_cont.DIACKBHMKEH_GetCurrentBoxInfo();
        JOFAGCFNKIO_OpenTime = ev.PDBPFJJCADD_open_at;
        EBCHFBIINDP_End = ev.FDBNFFNFOND_close_at;
        DMPELKEMCCJ_BoxTotal = _MOHDLLIJELH_cont.MPJNMBFIJMB();
        JALHJAPAFLK_BoxCurrent = _MOHDLLIJELH_cont.IPOENPPBFNK();
        IMMDGJAOPCD_BoxId = ev.PPFNGGCBJKC_id;
        NNCCGILOOIE_Num = _MOHDLLIJELH_cont.GOIJBILEHPD_GetSaveBoxCnt();
        JHNEFBNEAAO = ev.GLCLFMGPMAN_ItemId;
        MFHLHIDLKGN_NumTicket = _MOHDLLIJELH_cont.BCMFJLFDLND_GetNumUseItemForCurrentBox();
        JAAOFLAIEOD = MFHLHIDLKGN_NumTicket;
        JAAOFLAIEOD = Mathf.Clamp(JAAOFLAIEOD, 0, 10);
        if(JALHJAPAFLK_BoxCurrent < JAAOFLAIEOD)
            JAAOFLAIEOD = JALHJAPAFLK_BoxCurrent;
        JAAOFLAIEOD = JALHJAPAFLK_BoxCurrent - DMPELKEMCCJ_BoxTotal;
        HCPAAGBDCAO_IsEmpty = JALHJAPAFLK_BoxCurrent == 0;
        AAIKGPGDHIB_Cost = ev.NDNHKMJPBCM_Cost;
        if(LOMNOJCONHP.Count > 0)
        {
            CHHECNJBMLA_EventBoxGacha.MDBEKHIHBJM m = _MOHDLLIJELH_cont.DGBCMNLEDEI();
            if(m != null)
            {
                LOMNOJCONHP[0].LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(m.GLCLFMGPMAN_ItemId);
                LOMNOJCONHP[0].OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(m.GLCLFMGPMAN_ItemId);
                LOMNOJCONHP[0].GLCLFMGPMAN_ItemId = m.GLCLFMGPMAN_ItemId;
                LOMNOJCONHP[0].NNCCGILOOIE_Num = m.AGKANHNHECE_Remain;
                LOMNOJCONHP[0].BFGKGMOLAFL_Max = m.GCEANEOEGMD_Num;
                LOMNOJCONHP[0].JOPPFEHKNFO_Pickup = m.AEDMJLGNDHN_IsSp;
            }
            for(int i = 0; i < HCIDHHLOPLK.Count; i++)
            {
                HCIDHHLOPLK[i].LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                HCIDHHLOPLK[i].OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                HCIDHHLOPLK[i].GLCLFMGPMAN_ItemId = _MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId;
                HCIDHHLOPLK[i].LJKMKCOAICL_ItemCount = _MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].HMFFHLPNMPH_count;
                HCIDHHLOPLK[i].NNCCGILOOIE_Num = _MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].AGKANHNHECE_Remain;
                HCIDHHLOPLK[i].BFGKGMOLAFL_Max = _MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].GCEANEOEGMD_Num;
                HCIDHHLOPLK[i].JOPPFEHKNFO_Pickup = _MOHDLLIJELH_cont.JMLKAGOACAE[HCIDHHLOPLK[i].OIPCCBHIKIA_index].AEDMJLGNDHN_IsSp;
            }
            for(int i = 0; i < JJAKKNHDABO.Count; i++)
            {
                JJAKKNHDABO[i].LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                JJAKKNHDABO[i].OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                JJAKKNHDABO[i].GLCLFMGPMAN_ItemId = _MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId;
                JJAKKNHDABO[i].LJKMKCOAICL_ItemCount = _MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].HMFFHLPNMPH_count;
                JJAKKNHDABO[i].NNCCGILOOIE_Num = _MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].AGKANHNHECE_Remain;
                JJAKKNHDABO[i].BFGKGMOLAFL_Max = _MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GCEANEOEGMD_Num;
                JJAKKNHDABO[i].JOPPFEHKNFO_Pickup = _MOHDLLIJELH_cont.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].AEDMJLGNDHN_IsSp;
            }
            ENJLGHMEKEL_Type = KAFHMMOGLKO.FAFCPLEAFCP_0_Summer;
            DateTime t = Utility.GetLocalDateTime(JOFAGCFNKIO_OpenTime);
            if(t.Month != 7 && t.Month != 8)
            {
                ENJLGHMEKEL_Type = KAFHMMOGLKO.DALFBOFBJJL_1_NewYear;
                if(t.Month != 12 && t.Month != 1)
                    ENJLGHMEKEL_Type = KAFHMMOGLKO.AIMPCCIHKAJ_2;
            }
        }
    }

	// // RVA: 0x174BB90 Offset: 0x174BB90 VA: 0x174BB90
	public void EAFPKOMBKGB(int JOGLNEBOIOD, Action<List<JAKMCKNADCE>> _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev.KOCPLGOAKKG(JOGLNEBOIOD))
        {
            List<JAKMCKNADCE> l = new List<JAKMCKNADCE>();
            for(int i = 0; i < ev.PNLJHCDHKCP_LotResult.Count; i++)
            {
                JAKMCKNADCE d = new JAKMCKNADCE();
                d.PPFNGGCBJKC_id = ev.PNLJHCDHKCP_LotResult[i].PPFNGGCBJKC_id;
                d.GLCLFMGPMAN_ItemId = ev.PNLJHCDHKCP_LotResult[i].KIJAPOFAGPN_ItemId;
                d.LJKMKCOAICL_ItemCount = ev.PNLJHCDHKCP_LotResult[i].HMFFHLPNMPH_count;
                d.JOPPFEHKNFO_Pickup = ev.PNLJHCDHKCP_LotResult[i].AEDMJLGNDHN_IsSp;
                d.LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(d.GLCLFMGPMAN_ItemId);
                d.OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(d.GLCLFMGPMAN_ItemId);
                l.Add(d);
            }
            JANMJPOKLFL_InventoryUtil = ev.JANMJPOKLFL_InventoryUtil;
            if(ev.IPOENPPBFNK() == 0)
            {
                HCPAAGBDCAO_IsEmpty = true;
                ev.OGMDPOJNBHK();
            }
            CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
            {
                //0x174D7AC
                _BHFHGFKBOHH_OnSuccess(l);
            }, () =>
            {
                //0x174D82C
                _AOCANKOMKFG_OnError();
            }, null);
        }
        else
        {
            NIMPEHIECJH();
        }
    }

	// // RVA: 0x174BFFC Offset: 0x174BFFC VA: 0x174BFFC
	public List<CMEDMHFOFAH> GMENOMFADOH()
    {
        return HCIDHHLOPLK;
    }

	// // RVA: 0x174C004 Offset: 0x174C004 VA: 0x174C004
	public int EPLMGDEGLKG(int _IMMDGJAOPCD_BoxId)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
            return dbEv.KGDBEMPMAIJ_Boxes[_IMMDGJAOPCD_BoxId - 1].PLALNIIBLOF_en != 2 ? 1 : dbEv.KGDBEMPMAIJ_Boxes[_IMMDGJAOPCD_BoxId - 1].NDNHKMJPBCM_Cost;
        }
        return 1;
    }

	// // RVA: 0x174C258 Offset: 0x174C258 VA: 0x174C258
	public int FBJLOOFBHAP()
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
        return dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD_BoxId - 1].PLALNIIBLOF_en == 2 ? dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD_BoxId - 1].IHGDLBBPKFI_Next : 1;
    }

	// // RVA: 0x174C4B0 Offset: 0x174C4B0 VA: 0x174C4B0
	public int EDKNOJBCIJO(int _IMMDGJAOPCD_BoxId)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
            int res = 0;
            for(int i = 0; i < dbEv.PKPLOGBIDIG_Prizes.Count; i++)
            {
                if(dbEv.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId == _IMMDGJAOPCD_BoxId)
                {
                    if(dbEv.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_en == 2)
                    {
                        res += dbEv.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_num;
                    }
                }
            }
            return res;
        }
        return 0;
    }

	// // RVA: 0x174C7E8 Offset: 0x174C7E8 VA: 0x174C7E8
	public int EDILCJAICBE(int IOPHIHFOOEP)
    {
        if(IOPHIHFOOEP > -1)
        {
            if(NNCCGILOOIE_Num == IOPHIHFOOEP)
                return IMMDGJAOPCD_BoxId;
            else
            {
                CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
                if(ev != null)
                {
                    IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
                    if(IOPHIHFOOEP < dbEv.KGDBEMPMAIJ_Boxes.Count)
                    {
                        return IOPHIHFOOEP + 1;
                    }
                    else
                    {
                        int a = IOPHIHFOOEP - NNCCGILOOIE_Num;
                        if(a < 0)
                            a = -a;
                        if(a <= MLAECGLBCBM_OverStopCnt)
                        {
                            int v = dbEv.KGDBEMPMAIJ_Boxes.Count;
                            for(int i = dbEv.KGDBEMPMAIJ_Boxes.Count - 1; i < IOPHIHFOOEP; i++)
                            {
                                v = dbEv.KGDBEMPMAIJ_Boxes[dbEv.KGDBEMPMAIJ_Boxes.Count - 1].IHGDLBBPKFI_Next;
                                if(v == 0)
                                    return 0;
                            }
                        }
                    }
                }
            }
        }
        return 0;
    }

	// // RVA: 0x174CA8C Offset: 0x174CA8C VA: 0x174CA8C
	public List<CMEDMHFOFAH> NHOBNJOLBPO(int _IMMDGJAOPCD_BoxId, bool DHLHLJOMGEL/* = True*/)
    {
        if(DHLHLJOMGEL && this.IMMDGJAOPCD_BoxId == _IMMDGJAOPCD_BoxId)
            return HCIDHHLOPLK;
        else
        {
            CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
            if(ev != null)
            {
                ev.ELAGEGMIKKK(ref ev.CKFCGDIJKKC, _IMMDGJAOPCD_BoxId);
                JJAKKNHDABO.Clear();
                for(int i = 0; i < ev.CKFCGDIJKKC.Count; i++)
                {
                    CMEDMHFOFAH d = new CMEDMHFOFAH();
                    d.OIPCCBHIKIA_index = i;
                    JJAKKNHDABO.Add(d);
                }
                for(int i = 0; i < JJAKKNHDABO.Count; i++)
                {
                    JJAKKNHDABO[i].LIDBKCIMCKE_rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                    JJAKKNHDABO[i].OPFGFINHFCE_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId);
                    JJAKKNHDABO[i].GLCLFMGPMAN_ItemId = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GLCLFMGPMAN_ItemId;
                    JJAKKNHDABO[i].LJKMKCOAICL_ItemCount = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].HMFFHLPNMPH_count;
                    JJAKKNHDABO[i].NNCCGILOOIE_Num = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].AGKANHNHECE_Remain;
                    JJAKKNHDABO[i].BFGKGMOLAFL_Max = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].GCEANEOEGMD_Num;
                    JJAKKNHDABO[i].JOPPFEHKNFO_Pickup = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_index].AEDMJLGNDHN_IsSp;
                }
            }
            return JJAKKNHDABO;
        }
    }

	// // RVA: 0x174CD64 Offset: 0x174CD64 VA: 0x174CD64
	public bool KMNNDEFMEKH()
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
        int a = 0;
        for(int i = 0; i < dbEv.KGDBEMPMAIJ_Boxes.Count; i++)
        {
            if(dbEv.KGDBEMPMAIJ_Boxes[i].PLALNIIBLOF_en == 2)
            {
                if(a > 0)
                {
                    if(dbEv.KGDBEMPMAIJ_Boxes[i].NDNHKMJPBCM_Cost != a)
                        return true;
                }
                a = dbEv.KGDBEMPMAIJ_Boxes[i].NDNHKMJPBCM_Cost;
            }
        }
        return false;
    }

	// // RVA: 0x174D044 Offset: 0x174D044 VA: 0x174D044
	public string HODCEOAPAIA(int _PPFNGGCBJKC_id)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            if(ev.JOPOPMLFINI_QuestName == "event_box_gacha_a")
            {
                return MessageManager.Instance.GetMessage("master", "ebga_rtx_" + _PPFNGGCBJKC_id.ToString("D4"));
            }
            else if(ev.JOPOPMLFINI_QuestName == "event_box_gacha_b")
            {
                return MessageManager.Instance.GetMessage("master", "ebgb_rtx_" + _PPFNGGCBJKC_id.ToString("D4"));
            }
            else if(ev.JOPOPMLFINI_QuestName == "event_box_gacha_c")
            {
                return MessageManager.Instance.GetMessage("master", "ebgc_rtx_" + _PPFNGGCBJKC_id.ToString("D4"));
            }
        }
        return "";
    }

	// // RVA: 0x174B524 Offset: 0x174B524 VA: 0x174B524
	private void FNJCONEDHDO()
    {
        LHBBFEHAPGI.Clear();
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
            for(int i = 0; i < dbEv.FICLPLNOKOP.Count; i++)
            {
                if(dbEv.FICLPLNOKOP[i].PLALNIIBLOF_en == 2)
                {
                    LBEPCOMCHNE d = new LBEPCOMCHNE();
                    d.PPFNGGCBJKC_id = dbEv.FICLPLNOKOP[i].PPFNGGCBJKC_id;
                    d.IIKIOIKEGMM = (FHOKKDKGGJI)dbEv.FICLPLNOKOP[i].GPJKJCBPBIP_Tim;
                    d.FKDOMKHHOCD_CenterSkillCondition = (GDEJHABHLFH)dbEv.FICLPLNOKOP[i].OAFPGJLCNFM_cond;
                    d.INDDJNMPONH_type = (FBGKMBHEOBC)dbEv.FICLPLNOKOP[i].GBJFNGCDKPM_typ;
                    d.EILKGEADKGH_Order = dbEv.FICLPLNOKOP[i].FPOMEEJFBIG_odr;
                    d.EIGFHDMDECG_CharaText = HODCEOAPAIA(dbEv.FICLPLNOKOP[i].PPFNGGCBJKC_id);
                    d.BKCIPBIHKJG_CharaId = dbEv.FICLPLNOKOP[i].NKNAECHNACI_GroupId;
                    LHBBFEHAPGI.Add(d);
                }
            }
            LHBBFEHAPGI.Sort((LBEPCOMCHNE _HKICMNAACDA_a, LBEPCOMCHNE _BNKHBCBJBKI_b) =>
            {
                //0x174D640
                if(_HKICMNAACDA_a.IIKIOIKEGMM == _BNKHBCBJBKI_b.IIKIOIKEGMM)
                {
                    if(_HKICMNAACDA_a.EILKGEADKGH_Order == _BNKHBCBJBKI_b.EILKGEADKGH_Order)
                    {
                        if(_HKICMNAACDA_a.INDDJNMPONH_type == _BNKHBCBJBKI_b.INDDJNMPONH_type)
                        {
                            return _HKICMNAACDA_a.PPFNGGCBJKC_id.CompareTo(_BNKHBCBJBKI_b.PPFNGGCBJKC_id);
                        }
                        return _HKICMNAACDA_a.INDDJNMPONH_type.CompareTo(_BNKHBCBJBKI_b.INDDJNMPONH_type);
                    }
                    return _BNKHBCBJBKI_b.EILKGEADKGH_Order.CompareTo(_HKICMNAACDA_a.EILKGEADKGH_Order);
                }
                return _HKICMNAACDA_a.IIKIOIKEGMM.CompareTo(_BNKHBCBJBKI_b.IIKIOIKEGMM);
            });
        }
    }

	// // RVA: 0x174D1F4 Offset: 0x174D1F4 VA: 0x174D1F4
	// public List<HGFPAFPGIKG.LBEPCOMCHNE> MHCOADJDLLF() { }

	// // RVA: 0x174D1FC Offset: 0x174D1FC VA: 0x174D1FC
	public List<LBEPCOMCHNE> MHCOADJDLLF(FHOKKDKGGJI IIKIOIKEGMM, FBGKMBHEOBC _INDDJNMPONH_type/* = 0*/, GDEJHABHLFH _FKDOMKHHOCD_CenterSkillCondition/* = 0*/)
    {
        List<LBEPCOMCHNE> res = new List<LBEPCOMCHNE>();
        res.Clear();
        for(int i = 0; i < LHBBFEHAPGI.Count; i++)
        {
            if(LHBBFEHAPGI[i].IIKIOIKEGMM == IIKIOIKEGMM)
            {
                if(_INDDJNMPONH_type != 0)
                {
                    if(LHBBFEHAPGI[i].INDDJNMPONH_type != _INDDJNMPONH_type)
                        continue;
                }
                if(_FKDOMKHHOCD_CenterSkillCondition != 0)
                {
                    if(LHBBFEHAPGI[i].FKDOMKHHOCD_CenterSkillCondition != _FKDOMKHHOCD_CenterSkillCondition)
                        continue;
                }
                LBEPCOMCHNE d = new LBEPCOMCHNE();
                d.ODDIHGPONFL_Copy(LHBBFEHAPGI[i]);
                res.Add(d);
            }
        }
        return res;
    }
}
