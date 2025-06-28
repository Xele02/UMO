
using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class HGFPAFPGIKG
{
    public enum FHOKKDKGGJI
    {
        HJNNKCMLGFL = 0,
        KENKGHLELHP_1 = 1,
        PDEGHEGBDBE_2 = 2,
    }

    public enum GDEJHABHLFH
    {
        HJNNKCMLGFL_0 = 0,
        HPFFBANMJOD_1 = 1,
        CPLKGJJFJKA_2 = 2,
        DAFJKGJDAND_3 = 3,
        BEJJEGKLGMP_4 = 4,
        EOAFEBEENLI_5 = 5,
    }

    public enum FBGKMBHEOBC
    {
        HJNNKCMLGFL_0 = 0,
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
        public int PPFNGGCBJKC; // 0x8
        public int GLCLFMGPMAN_ItemId; // 0xC
        public int LJKMKCOAICL; // 0x10
        public int LIDBKCIMCKE_Rarity; // 0x14
        public string OPFGFINHFCE_Name; // 0x18
        public bool JOPPFEHKNFO_IsPickup; // 0x1C
    }

    public class CMEDMHFOFAH : JAKMCKNADCE
    {
        public int OIPCCBHIKIA_Idx; // 0x20
        public int NNCCGILOOIE; // 0x24
        public int BFGKGMOLAFL_MaxPlate; // 0x28
    }
 
    public class LBEPCOMCHNE
    {
        public int PPFNGGCBJKC; // 0x8
        public FHOKKDKGGJI IIKIOIKEGMM; // 0xC
        public GDEJHABHLFH FKDOMKHHOCD; // 0x10
        public FBGKMBHEOBC INDDJNMPONH; // 0x14
        public int EILKGEADKGH; // 0x18
        public string EIGFHDMDECG_CharaText; // 0x1C
        public int BKCIPBIHKJG_CharaId; // 0x20

        // // RVA: 0x174D4EC Offset: 0x174D4EC VA: 0x174D4EC
        public void ODDIHGPONFL(LBEPCOMCHNE IJAOGPFKDBP)
        {
            PPFNGGCBJKC = IJAOGPFKDBP.PPFNGGCBJKC;
            IIKIOIKEGMM = IJAOGPFKDBP.IIKIOIKEGMM;
            FKDOMKHHOCD = IJAOGPFKDBP.FKDOMKHHOCD;
            INDDJNMPONH = IJAOGPFKDBP.INDDJNMPONH;
            EILKGEADKGH = IJAOGPFKDBP.EILKGEADKGH;
            EIGFHDMDECG_CharaText = IJAOGPFKDBP.EIGFHDMDECG_CharaText;
            BKCIPBIHKJG_CharaId = IJAOGPFKDBP.BKCIPBIHKJG_CharaId;
        }
    }

	private const int NMHGMNGLPFO = 10;
	public long JOFAGCFNKIO_Start; // 0x8
	public long EBCHFBIINDP_End; // 0x10
	public int DMPELKEMCCJ_BoxTotal; // 0x18
	public int JALHJAPAFLK_BoxCurrent; // 0x1C
	public float DHIPGHBJLIL; // 0x20
	public int IMMDGJAOPCD; // 0x24
	public int NNCCGILOOIE_ListIdx; // 0x28
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
	public HGFPAFPGIKG(int EKANGPODCEP)
    {
        DFFEFGHMEOK_EventId = EKANGPODCEP;
        if(EKANGPODCEP == 0)
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
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
            MLAECGLBCBM_OverStopCnt = dbEv.LPJLEHAJADA("over_stop_cnt", 1);
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
	public void BFDHGPNBNMP(CHHECNJBMLA_EventBoxGacha MOHDLLIJELH)
    {
        LOMNOJCONHP = new List<CMEDMHFOFAH>();
        HCIDHHLOPLK = new List<CMEDMHFOFAH>();
        JJAKKNHDABO = new List<CMEDMHFOFAH>();
        LHBBFEHAPGI = new List<LBEPCOMCHNE>();
        LOMNOJCONHP.Clear();
        HCIDHHLOPLK.Clear();
        JJAKKNHDABO.Clear();
        CHHECNJBMLA_EventBoxGacha.MDBEKHIHBJM m = MOHDLLIJELH.DGBCMNLEDEI();
        if(m != null)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_Idx = 0;
            LOMNOJCONHP.Add(d);
        }
        for(int i = 0; i < MOHDLLIJELH.JMLKAGOACAE.Count; i++)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_Idx = i;
            HCIDHHLOPLK.Add(d);
        }
        for(int i = 0; i < MOHDLLIJELH.CKFCGDIJKKC.Count; i++)
        {
            CMEDMHFOFAH d = new CMEDMHFOFAH();
            d.OIPCCBHIKIA_Idx = i;
            JJAKKNHDABO.Add(d);
        }
        FNJCONEDHDO();
    }

	// // RVA: 0x174AE20 Offset: 0x174AE20 VA: 0x174AE20
	public void HCDGELDHFHB(CHHECNJBMLA_EventBoxGacha MOHDLLIJELH)
    {
        IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ ev = MOHDLLIJELH.DIACKBHMKEH_GetCurrentBoxInfo();
        JOFAGCFNKIO_Start = ev.PDBPFJJCADD_OpenAt;
        EBCHFBIINDP_End = ev.FDBNFFNFOND_CloseAt;
        DMPELKEMCCJ_BoxTotal = MOHDLLIJELH.MPJNMBFIJMB();
        JALHJAPAFLK_BoxCurrent = MOHDLLIJELH.IPOENPPBFNK();
        IMMDGJAOPCD = ev.PPFNGGCBJKC_Id;
        NNCCGILOOIE_ListIdx = MOHDLLIJELH.GOIJBILEHPD_GetSaveBoxCnt();
        JHNEFBNEAAO = ev.GLCLFMGPMAN_ItemId;
        MFHLHIDLKGN_NumTicket = MOHDLLIJELH.BCMFJLFDLND_GetNumUseItemForCurrentBox();
        JAAOFLAIEOD = MFHLHIDLKGN_NumTicket;
        JAAOFLAIEOD = Mathf.Clamp(JAAOFLAIEOD, 0, 10);
        if(JALHJAPAFLK_BoxCurrent < JAAOFLAIEOD)
            JAAOFLAIEOD = JALHJAPAFLK_BoxCurrent;
        JAAOFLAIEOD = JALHJAPAFLK_BoxCurrent - DMPELKEMCCJ_BoxTotal;
        HCPAAGBDCAO_IsEmpty = JALHJAPAFLK_BoxCurrent == 0;
        AAIKGPGDHIB_Cost = ev.NDNHKMJPBCM_Cost;
        if(LOMNOJCONHP.Count > 0)
        {
            CHHECNJBMLA_EventBoxGacha.MDBEKHIHBJM m = MOHDLLIJELH.DGBCMNLEDEI();
            if(m != null)
            {
                LOMNOJCONHP[0].LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(m.GLCLFMGPMAN_ItemId);
                LOMNOJCONHP[0].OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(m.GLCLFMGPMAN_ItemId);
                LOMNOJCONHP[0].GLCLFMGPMAN_ItemId = m.GLCLFMGPMAN_ItemId;
                LOMNOJCONHP[0].NNCCGILOOIE = m.AGKANHNHECE;
                LOMNOJCONHP[0].BFGKGMOLAFL_MaxPlate = m.GCEANEOEGMD;
                LOMNOJCONHP[0].JOPPFEHKNFO_IsPickup = m.AEDMJLGNDHN;
            }
            for(int i = 0; i < HCIDHHLOPLK.Count; i++)
            {
                HCIDHHLOPLK[i].LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                HCIDHHLOPLK[i].OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                HCIDHHLOPLK[i].GLCLFMGPMAN_ItemId = MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId;
                HCIDHHLOPLK[i].LJKMKCOAICL = MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].HMFFHLPNMPH;
                HCIDHHLOPLK[i].NNCCGILOOIE = MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AGKANHNHECE;
                HCIDHHLOPLK[i].BFGKGMOLAFL_MaxPlate = MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GCEANEOEGMD;
                HCIDHHLOPLK[i].JOPPFEHKNFO_IsPickup = MOHDLLIJELH.JMLKAGOACAE[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AEDMJLGNDHN;
            }
            for(int i = 0; i < JJAKKNHDABO.Count; i++)
            {
                JJAKKNHDABO[i].LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                JJAKKNHDABO[i].OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                JJAKKNHDABO[i].GLCLFMGPMAN_ItemId = MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId;
                JJAKKNHDABO[i].LJKMKCOAICL = MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].HMFFHLPNMPH;
                JJAKKNHDABO[i].NNCCGILOOIE = MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AGKANHNHECE;
                JJAKKNHDABO[i].BFGKGMOLAFL_MaxPlate = MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GCEANEOEGMD;
                JJAKKNHDABO[i].JOPPFEHKNFO_IsPickup = MOHDLLIJELH.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AEDMJLGNDHN;
            }
            ENJLGHMEKEL_Type = KAFHMMOGLKO.FAFCPLEAFCP_0_Summer;
            DateTime t = Utility.GetLocalDateTime(JOFAGCFNKIO_Start);
            if(t.Month != 7 && t.Month != 8)
            {
                ENJLGHMEKEL_Type = KAFHMMOGLKO.DALFBOFBJJL_1_NewYear;
                if(t.Month != 12 && t.Month != 1)
                    ENJLGHMEKEL_Type = KAFHMMOGLKO.AIMPCCIHKAJ_2;
            }
        }
    }

	// // RVA: 0x174BB90 Offset: 0x174BB90 VA: 0x174BB90
	public void EAFPKOMBKGB(int JOGLNEBOIOD, Action<List<JAKMCKNADCE>> BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev.KOCPLGOAKKG(JOGLNEBOIOD))
        {
            List<JAKMCKNADCE> l = new List<JAKMCKNADCE>();
            for(int i = 0; i < ev.PNLJHCDHKCP_LotResult.Count; i++)
            {
                JAKMCKNADCE d = new JAKMCKNADCE();
                d.PPFNGGCBJKC = ev.PNLJHCDHKCP_LotResult[i].PPFNGGCBJKC;
                d.GLCLFMGPMAN_ItemId = ev.PNLJHCDHKCP_LotResult[i].KIJAPOFAGPN_ItemId;
                d.LJKMKCOAICL = ev.PNLJHCDHKCP_LotResult[i].HMFFHLPNMPH_Cnt;
                d.JOPPFEHKNFO_IsPickup = ev.PNLJHCDHKCP_LotResult[i].AEDMJLGNDHN;
                d.LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(d.GLCLFMGPMAN_ItemId);
                d.OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(d.GLCLFMGPMAN_ItemId);
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
                BHFHGFKBOHH(l);
            }, () =>
            {
                //0x174D82C
                AOCANKOMKFG();
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
	public int EPLMGDEGLKG(int IMMDGJAOPCD)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
            return dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD - 1].PLALNIIBLOF_Enabled != 2 ? 1 : dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD - 1].NDNHKMJPBCM_Cost;
        }
        return 1;
    }

	// // RVA: 0x174C258 Offset: 0x174C258 VA: 0x174C258
	public int FBJLOOFBHAP()
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
        return dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD - 1].PLALNIIBLOF_Enabled == 2 ? dbEv.KGDBEMPMAIJ_Boxes[IMMDGJAOPCD - 1].IHGDLBBPKFI_Next : 1;
    }

	// // RVA: 0x174C4B0 Offset: 0x174C4B0 VA: 0x174C4B0
	public int EDKNOJBCIJO(int IMMDGJAOPCD)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
            int res = 0;
            for(int i = 0; i < dbEv.PKPLOGBIDIG_Prizes.Count; i++)
            {
                if(dbEv.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId == IMMDGJAOPCD)
                {
                    if(dbEv.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_Enabled == 2)
                    {
                        res += dbEv.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_Num;
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
            if(NNCCGILOOIE_ListIdx == IOPHIHFOOEP)
                return IMMDGJAOPCD;
            else
            {
                CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
                if(ev != null)
                {
                    IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
                    if(IOPHIHFOOEP < dbEv.KGDBEMPMAIJ_Boxes.Count)
                    {
                        return IOPHIHFOOEP + 1;
                    }
                    else
                    {
                        int a = IOPHIHFOOEP - NNCCGILOOIE_ListIdx;
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
	public List<CMEDMHFOFAH> NHOBNJOLBPO(int IMMDGJAOPCD, bool DHLHLJOMGEL/* = True*/)
    {
        if(DHLHLJOMGEL && this.IMMDGJAOPCD == IMMDGJAOPCD)
            return HCIDHHLOPLK;
        else
        {
            CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
            if(ev != null)
            {
                ev.ELAGEGMIKKK(ref ev.CKFCGDIJKKC, IMMDGJAOPCD);
                JJAKKNHDABO.Clear();
                for(int i = 0; i < ev.CKFCGDIJKKC.Count; i++)
                {
                    CMEDMHFOFAH d = new CMEDMHFOFAH();
                    d.OIPCCBHIKIA_Idx = i;
                    JJAKKNHDABO.Add(d);
                }
                for(int i = 0; i < JJAKKNHDABO.Count; i++)
                {
                    JJAKKNHDABO[i].LIDBKCIMCKE_Rarity = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                    JJAKKNHDABO[i].OPFGFINHFCE_Name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId);
                    JJAKKNHDABO[i].GLCLFMGPMAN_ItemId = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GLCLFMGPMAN_ItemId;
                    JJAKKNHDABO[i].LJKMKCOAICL = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].HMFFHLPNMPH;
                    JJAKKNHDABO[i].NNCCGILOOIE = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AGKANHNHECE;
                    JJAKKNHDABO[i].BFGKGMOLAFL_MaxPlate = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].GCEANEOEGMD;
                    JJAKKNHDABO[i].JOPPFEHKNFO_IsPickup = ev.CKFCGDIJKKC[JJAKKNHDABO[i].OIPCCBHIKIA_Idx].AEDMJLGNDHN;
                }
            }
            return JJAKKNHDABO;
        }
    }

	// // RVA: 0x174CD64 Offset: 0x174CD64 VA: 0x174CD64
	public bool KMNNDEFMEKH()
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
        int a = 0;
        for(int i = 0; i < dbEv.KGDBEMPMAIJ_Boxes.Count; i++)
        {
            if(dbEv.KGDBEMPMAIJ_Boxes[i].PLALNIIBLOF_Enabled == 2)
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
	public string HODCEOAPAIA(int PPFNGGCBJKC)
    {
        CHHECNJBMLA_EventBoxGacha ev = OEGDCBLNNFF();
        if(ev != null)
        {
            if(ev.JOPOPMLFINI_QuestId == "event_box_gacha_a")
            {
                return MessageManager.Instance.GetMessage("master", "ebga_rtx_" + PPFNGGCBJKC.ToString("D4"));
            }
            else if(ev.JOPOPMLFINI_QuestId == "event_box_gacha_b")
            {
                return MessageManager.Instance.GetMessage("master", "ebgb_rtx_" + PPFNGGCBJKC.ToString("D4"));
            }
            else if(ev.JOPOPMLFINI_QuestId == "event_box_gacha_c")
            {
                return MessageManager.Instance.GetMessage("master", "ebgc_rtx_" + PPFNGGCBJKC.ToString("D4"));
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
            IMDBGDNPLJA_EventBoxGacha dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
            for(int i = 0; i < dbEv.FICLPLNOKOP.Count; i++)
            {
                if(dbEv.FICLPLNOKOP[i].PLALNIIBLOF_Enabled == 2)
                {
                    LBEPCOMCHNE d = new LBEPCOMCHNE();
                    d.PPFNGGCBJKC = dbEv.FICLPLNOKOP[i].PPFNGGCBJKC_Id;
                    d.IIKIOIKEGMM = (FHOKKDKGGJI)dbEv.FICLPLNOKOP[i].GPJKJCBPBIP_Tim;
                    d.FKDOMKHHOCD = (GDEJHABHLFH)dbEv.FICLPLNOKOP[i].OAFPGJLCNFM_Cond;
                    d.INDDJNMPONH = (FBGKMBHEOBC)dbEv.FICLPLNOKOP[i].GBJFNGCDKPM_Type;
                    d.EILKGEADKGH = dbEv.FICLPLNOKOP[i].FPOMEEJFBIG_Odr;
                    d.EIGFHDMDECG_CharaText = HODCEOAPAIA(dbEv.FICLPLNOKOP[i].PPFNGGCBJKC_Id);
                    d.BKCIPBIHKJG_CharaId = dbEv.FICLPLNOKOP[i].NKNAECHNACI_GroupId;
                    LHBBFEHAPGI.Add(d);
                }
            }
            LHBBFEHAPGI.Sort((LBEPCOMCHNE HKICMNAACDA, LBEPCOMCHNE BNKHBCBJBKI) =>
            {
                //0x174D640
                if(HKICMNAACDA.IIKIOIKEGMM == BNKHBCBJBKI.IIKIOIKEGMM)
                {
                    if(HKICMNAACDA.EILKGEADKGH == BNKHBCBJBKI.EILKGEADKGH)
                    {
                        if(HKICMNAACDA.INDDJNMPONH == BNKHBCBJBKI.INDDJNMPONH)
                        {
                            return HKICMNAACDA.PPFNGGCBJKC.CompareTo(BNKHBCBJBKI.PPFNGGCBJKC);
                        }
                        return HKICMNAACDA.INDDJNMPONH.CompareTo(BNKHBCBJBKI.INDDJNMPONH);
                    }
                    return BNKHBCBJBKI.EILKGEADKGH.CompareTo(HKICMNAACDA.EILKGEADKGH);
                }
                return HKICMNAACDA.IIKIOIKEGMM.CompareTo(BNKHBCBJBKI.IIKIOIKEGMM);
            });
        }
    }

	// // RVA: 0x174D1F4 Offset: 0x174D1F4 VA: 0x174D1F4
	// public List<HGFPAFPGIKG.LBEPCOMCHNE> MHCOADJDLLF() { }

	// // RVA: 0x174D1FC Offset: 0x174D1FC VA: 0x174D1FC
	public List<LBEPCOMCHNE> MHCOADJDLLF(FHOKKDKGGJI IIKIOIKEGMM, FBGKMBHEOBC INDDJNMPONH/* = 0*/, GDEJHABHLFH FKDOMKHHOCD/* = 0*/)
    {
        List<LBEPCOMCHNE> res = new List<LBEPCOMCHNE>();
        res.Clear();
        for(int i = 0; i < LHBBFEHAPGI.Count; i++)
        {
            if(LHBBFEHAPGI[i].IIKIOIKEGMM == IIKIOIKEGMM)
            {
                if(INDDJNMPONH != 0)
                {
                    if(LHBBFEHAPGI[i].INDDJNMPONH != INDDJNMPONH)
                        continue;
                }
                if(FKDOMKHHOCD != 0)
                {
                    if(LHBBFEHAPGI[i].FKDOMKHHOCD != FKDOMKHHOCD)
                        continue;
                }
                LBEPCOMCHNE d = new LBEPCOMCHNE();
                d.ODDIHGPONFL(LHBBFEHAPGI[i]);
                res.Add(d);
            }
        }
        return res;
    }
}
