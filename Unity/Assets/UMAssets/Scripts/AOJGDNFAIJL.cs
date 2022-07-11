
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

public class AOJGDNFAIJL
{
    public class LLHDHKLACJA
    {
        public int PPFNGGCBJKC_DivaId { get; set; }// 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
        public bool CBLHLEKLLDE_IsSet { get; set; } // 0xC LPCLOHOCPIG DDNKFFEAFGB NIDGBLGJJJP
    }
    public class AMIECPBIALP
    {
        private readonly int DKNAIAKHHDC = -1; // 0x8
        private readonly int OPICBODCKGG; // 0xC
        private List<AOJGDNFAIJL.LLHDHKLACJA>[] CCEMEAAIKOL = new List<AOJGDNFAIJL.LLHDHKLACJA>[5]; // 0x24
        // private List<AOJGDNFAIJL.BGCLFIILKIG>[] HJDEMKCNHJF = new List<AOJGDNFAIJL.BGCLFIILKIG>[5]; // 0x28
        // private List<AOJGDNFAIJL.MHOGKDIKIHE> MDNHCIKGEAE; // 0x2C
        private int[] ENCKALOAAMB_DivaIds; // 0x30
        private int[] LGPBDFHDMNA_CostumeIds; // 0x34
        private int[] DJCCKIAJFGH_CostumeColorIds; // 0x38
        private int AGBLOHKHHAB; // 0x3C
        private int ICAJJLHPMDF_DefaultDivaId; // 0x40
        private int CLDDCHNMLLM_CostumeId; // 0x44
        private int CCEMMCJOPIO_ColorId; // 0x48
        private int AOPLBEPHLID; // 0x4C
        private BBHNACPENDM LDEGEHAEALK; // 0x50
        private NPOOPJIOMHF.CLGGEONAHPL OOEPMEDAJNJ; // 0x54
        private CIFHILOJJFC EOPODFDEMGF; // 0x58
        private bool NAENFAFGMEP_IsMultiDiva; // 0x5C
        private int PFMHBFAKNNL; // 0x60

        public int[] OMNDNNFANCK_PrismDivaIds { get; private set; } // 0x10 ACAKFKBJCIE PGFAAJJJPNH OKBCIFPNKIL // prismdivaids
        public int[] DLPIKHDNIIE_PrismCostumeIds { get; private set; } // 0x14 NKHEFHPGPOO JMJHBEFHIBN LMEJNJIEDOE // prismcostumeid
        public int[] PBHPPCPKHDL_PrismCostumeColorIds { get; private set; } // 0x18 JCMGMDGJBMF CFEGNKFHGAM CGKCELFGHCK // costume color id
        public int FBAGIDFLHHI_ValkyrieId { get; private set; } // 0x1C ALNPAMMMLLO FGBBLAADIDG AFJIFKDFNDI // valkId
        public bool FBGAKINEIPG { get; private set; } // 0x20 BNIOOBDDMJB IKPHJPLOGLD KFFLMEHHNKJ
        public bool OHLCKPIMMFH_ValkyrieMode { get; private set; } // 0x21 NEKDPHBJJGO BLJNAHPNEPC GMFAOCGDIBP // ValkMode
        public bool HGEKDNNJAAC_DivaMode { get; private set; } // 0x22 DPIFLIMIDPI ABKLDEHPOJH IFAFHCOMMHJ // divamode
        public bool DNLCLAOPFPF_ShowNotes { get; private set; } // 0x23 JPEAMBLKJEF KINDNNEJNOL GOIIKFBHFLD // shownote

        // RVA: 0xD599FC Offset: 0xD599FC VA: 0xD599FC
	    public AMIECPBIALP()
        {
            return;
        }

        // // RVA: 0xD59A94 Offset: 0xD59A94 VA: 0xD59A94
        public AMIECPBIALP(int DLAEJOBELBH_Id, bool HJNAMIDGAJB)
		{
			OBKGEDCKHHE(DLAEJOBELBH_Id, HJNAMIDGAJB);
		}

        // // RVA: 0xD59B44 Offset: 0xD59B44 VA: 0xD59B44
        public void OBKGEDCKHHE(int DLAEJOBELBH_MusicId, bool HJNAMIDGAJB_IsMultiDiva)
        {
            NAENFAFGMEP_IsMultiDiva = HJNAMIDGAJB_IsMultiDiva;
            LDEGEHAEALK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI;
            if(LDEGEHAEALK != null)
            {
                OOEPMEDAJNJ = LDEGEHAEALK.GHDDPJBBEOC.GCINIJEMHFK(DLAEJOBELBH_MusicId);
                EOPODFDEMGF = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP.BNECMLPHAGJ).DJPFJGKGOOF;
                int divaId = GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.BBIOMNCILMC_HomeDivaId;
                if(GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB.BBIOMNCILMC_HomeDivaId < 1)
                {
                    divaId = EOPODFDEMGF.FDBOPFEOENF[0].DIPKCALNIII;
                }
                ICAJJLHPMDF_DefaultDivaId = divaId;
                ADPFDMPMILA(divaId, ref CLDDCHNMLLM_CostumeId, ref CCEMMCJOPIO_ColorId);
                AOPLBEPHLID = EOPODFDEMGF.FODKKJIDDKN;
                OOEPMEDAJNJ.PPFNGGCBJKC = DLAEJOBELBH_MusicId;
                FBGAKINEIPG = OOEPMEDAJNJ.PLALNIIBLOF != 1 ? false : true;
                OHLCKPIMMFH_ValkyrieMode = OOEPMEDAJNJ.MKKGKKHABEK != 1 ? false : true;
                HGEKDNNJAAC_DivaMode = OOEPMEDAJNJ.JPBJOGBGKGA != 1 ? false : true;
                DNLCLAOPFPF_ShowNotes = OOEPMEDAJNJ.NLFMKOJHAHJ != 1 ? false : true;
                ENCKALOAAMB_DivaIds = new int[5];
                LGPBDFHDMNA_CostumeIds = new int[5];
                DJCCKIAJFGH_CostumeColorIds = new int[5];
                OMNDNNFANCK_PrismDivaIds = new int[5];
                DLPIKHDNIIE_PrismCostumeIds = new int[5];
                PBHPPCPKHDL_PrismCostumeColorIds = new int[5];
                int numDiva = 1;
                if(HJNAMIDGAJB_IsMultiDiva)
                    numDiva = 5;
                int val = 0;
                int val2 = 0;
                if(HJNAMIDGAJB_IsMultiDiva)
                {
                    ENCKALOAAMB_DivaIds[0] = OOEPMEDAJNJ.AIPJAKIFMPN;
                    ENCKALOAAMB_DivaIds[1] = OOEPMEDAJNJ.JMAGFEENOED;
                    ENCKALOAAMB_DivaIds[2] = OOEPMEDAJNJ.LFHILMNKGCB;
                    ENCKALOAAMB_DivaIds[3] = OOEPMEDAJNJ.OLKOJOACIBD;
                    ENCKALOAAMB_DivaIds[4] = OOEPMEDAJNJ.INBGAKAAJPB;

                    LGPBDFHDMNA_CostumeIds[0] = OOEPMEDAJNJ.FHFONPEHLMN;
                    LGPBDFHDMNA_CostumeIds[1] = OOEPMEDAJNJ.HPPOFOIJJMB;
                    LGPBDFHDMNA_CostumeIds[2] = OOEPMEDAJNJ.NBPNNNBCGFG;
                    LGPBDFHDMNA_CostumeIds[3] = OOEPMEDAJNJ.LLKEMHHHLEN;
                    LGPBDFHDMNA_CostumeIds[4] = OOEPMEDAJNJ.DGDLPGFKCFA;

                    DJCCKIAJFGH_CostumeColorIds[0] = OOEPMEDAJNJ.ADLOGNCDIFG;
                    DJCCKIAJFGH_CostumeColorIds[1] = OOEPMEDAJNJ.DFHNEEBKEIC;
                    DJCCKIAJFGH_CostumeColorIds[2] = OOEPMEDAJNJ.BFMDCDFAJKE;
                    DJCCKIAJFGH_CostumeColorIds[3] = OOEPMEDAJNJ.OHCNKIKIGHM;
                    DJCCKIAJFGH_CostumeColorIds[4] = OOEPMEDAJNJ.HDKHGAACNFG;

                    AGBLOHKHHAB = OOEPMEDAJNJ.PIJEEAOMMGA;
                    val = OPICBODCKGG;
                    val2 = OPICBODCKGG;
                }
                else
                {
                    ENCKALOAAMB_DivaIds[0] = OOEPMEDAJNJ.OCAMDLMPBGA;
                    ENCKALOAAMB_DivaIds[1] = OPICBODCKGG;
                    ENCKALOAAMB_DivaIds[2] = OPICBODCKGG;
                    ENCKALOAAMB_DivaIds[3] = OPICBODCKGG;
                    ENCKALOAAMB_DivaIds[4] = OPICBODCKGG;

                    LGPBDFHDMNA_CostumeIds[0] = OOEPMEDAJNJ.PGCEGEJOOON;
                    LGPBDFHDMNA_CostumeIds[1] = OPICBODCKGG;
                    LGPBDFHDMNA_CostumeIds[2] = OPICBODCKGG;
                    LGPBDFHDMNA_CostumeIds[3] = OPICBODCKGG;
                    LGPBDFHDMNA_CostumeIds[4] = OPICBODCKGG;

                    DJCCKIAJFGH_CostumeColorIds[0] = OOEPMEDAJNJ.IAFIKNONLJF;
                    DJCCKIAJFGH_CostumeColorIds[1] = OPICBODCKGG;
                    DJCCKIAJFGH_CostumeColorIds[2] = OPICBODCKGG;
                    DJCCKIAJFGH_CostumeColorIds[3] = OPICBODCKGG;
                    DJCCKIAJFGH_CostumeColorIds[4] = OPICBODCKGG;

                    AGBLOHKHHAB = OOEPMEDAJNJ.EPDPAHNLMKH;
                    val = ICAJJLHPMDF_DefaultDivaId;
                    val2 = DKNAIAKHHDC;
                }
                for(int i = 0; i < numDiva; i++)
                {
                    if(OPICBODCKGG < ENCKALOAAMB_DivaIds[i])
                    {
                        OMNDNNFANCK_PrismDivaIds[i] = ENCKALOAAMB_DivaIds[i];
                    }
                    else
                    {
                        OMNDNNFANCK_PrismDivaIds[i] = val;
                        ENCKALOAAMB_DivaIds[i] = val2;
                    }
                    if(OPICBODCKGG < OMNDNNFANCK_PrismDivaIds[i])
                    {
                        if(OPICBODCKGG < LGPBDFHDMNA_CostumeIds[i])
                        {
                            if(HPHDLNEKPKP(OMNDNNFANCK_PrismDivaIds[i], LGPBDFHDMNA_CostumeIds[i]))
                            {
                                DLPIKHDNIIE_PrismCostumeIds[i] = LGPBDFHDMNA_CostumeIds[i];
                                PBHPPCPKHDL_PrismCostumeColorIds[i] = DJCCKIAJFGH_CostumeColorIds[i];
                            }
                            else
                            {
                                LGPBDFHDMNA_CostumeIds[i] = DKNAIAKHHDC;
                                DJCCKIAJFGH_CostumeColorIds[i] = DKNAIAKHHDC;
                            }
                        }
                        else if(!HJNAMIDGAJB_IsMultiDiva)
                        {
                            LGPBDFHDMNA_CostumeIds[i] = DKNAIAKHHDC;
                            DJCCKIAJFGH_CostumeColorIds[i] = DKNAIAKHHDC;
                        }
                        if(LGPBDFHDMNA_CostumeIds[i] == DKNAIAKHHDC)
                        {
                            ADPFDMPMILA(OMNDNNFANCK_PrismDivaIds[i], ref CLDDCHNMLLM_CostumeId, ref CCEMMCJOPIO_ColorId);
                            DLPIKHDNIIE_PrismCostumeIds[i] = CLDDCHNMLLM_CostumeId;
                            PBHPPCPKHDL_PrismCostumeColorIds[i] = CCEMMCJOPIO_ColorId;
                        }
                    }
                    else
                    {
                        DLPIKHDNIIE_PrismCostumeIds[i] = OPICBODCKGG;
                        PBHPPCPKHDL_PrismCostumeColorIds[i] = OPICBODCKGG;
                        LGPBDFHDMNA_CostumeIds[i] = OPICBODCKGG;
                        DJCCKIAJFGH_CostumeColorIds[i] = OPICBODCKGG;
                    }
                }
                if(AGBLOHKHHAB < 1)
                {
                    FBAGIDFLHHI_ValkyrieId = AOPLBEPHLID;
                    AGBLOHKHHAB = DKNAIAKHHDC;
                }
                else
                {
                    FBAGIDFLHHI_ValkyrieId = AGBLOHKHHAB;
                }
            }
            if(!NAENFAFGMEP_IsMultiDiva)
            {
                PFMHBFAKNNL = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC(DLAEJOBELBH_MusicId).NJAOOMHCIHL_Dvs;
            }
            else
            {
                PFMHBFAKNNL = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC(DLAEJOBELBH_MusicId).PECMGDOMLAF_Dvm;
            }
        }

        // // RVA: 0xD5B314 Offset: 0xD5B314 VA: 0xD5B314
        public int PNBKLGKCKGO(int IOPHIHFOOEP)
		{
			if(IOPHIHFOOEP < 5)
			{
				return OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP];
			}
			return OPICBODCKGG;
		}

        // // RVA: 0xD5B370 Offset: 0xD5B370 VA: 0xD5B370
        public int OCNHIHMAGMJ(int IOPHIHFOOEP)
		{
			if (IOPHIHFOOEP < 5)
			{
				return DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP];
			}
			return OPICBODCKGG;
		}

        // // RVA: 0xD5B3CC Offset: 0xD5B3CC VA: 0xD5B3CC
        public int DOIGAGAAAOP(int IOPHIHFOOEP)
		{
			if (IOPHIHFOOEP < 5)
			{
				return PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP];
			}
			return OPICBODCKGG;
		}

        // // RVA: 0xD5B428 Offset: 0xD5B428 VA: 0xD5B428
        public int PNDKNFBLKDP()
		{
			return FBAGIDFLHHI_ValkyrieId;
		}

        // // RVA: 0xD5B430 Offset: 0xD5B430 VA: 0xD5B430
        // public bool OFHMEAJBIEL() { }

        // // RVA: 0xD5B494 Offset: 0xD5B494 VA: 0xD5B494
        // public int DPHIJENPBCJ() { }

        // // RVA: 0xD5B584 Offset: 0xD5B584 VA: 0xD5B584
        public List<AOJGDNFAIJL.LLHDHKLACJA> IANKDOFJLGB(int IOPHIHFOOEP)
        {
            AOJGDNFAIJL.LLHDHKLACJA data = new AOJGDNFAIJL.LLHDHKLACJA();
            List<AOJGDNFAIJL.LLHDHKLACJA> res = new List<AOJGDNFAIJL.LLHDHKLACJA>(10);
            CCEMEAAIKOL[IOPHIHFOOEP] = res;
            CCEMEAAIKOL[IOPHIHFOOEP].Clear();
            bool isSet = false;
            if(!NAENFAFGMEP_IsMultiDiva)
            {
                data.PPFNGGCBJKC_DivaId = ICAJJLHPMDF_DefaultDivaId;
                data.CBLHLEKLLDE_IsSet = ENCKALOAAMB_DivaIds[IOPHIHFOOEP] == DKNAIAKHHDC;
                isSet = data.CBLHLEKLLDE_IsSet;
                CCEMEAAIKOL[IOPHIHFOOEP].Add(data);
            }
            foreach(DEKKMGAFJCG.MNNLOBDPCCH a in LDEGEHAEALK.DGCJCAHIAPP.NBIGLBMHEDC)
            {
                if(RuntimeSettings.ForceDivaUnlock || a.CPGFPEDMDEH == 1)
                {
                    AOJGDNFAIJL.LLHDHKLACJA data2 = new AOJGDNFAIJL.LLHDHKLACJA();
                    data2.PPFNGGCBJKC_DivaId = a.DIPKCALNIII;
                    data2.CBLHLEKLLDE_IsSet = false;
                    if(!isSet)
                    {
                        if(OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP] == a.DIPKCALNIII)
                        {
                            data2.CBLHLEKLLDE_IsSet = true;
                        }
                    }
                    CCEMEAAIKOL[IOPHIHFOOEP].Add(data2);
                }
            }
            return CCEMEAAIKOL[IOPHIHFOOEP];
        }

        // // RVA: 0xD5BAF4 Offset: 0xD5BAF4 VA: 0xD5BAF4
        // public List<AOJGDNFAIJL.BGCLFIILKIG> ANNOBPMEDKK(int IOPHIHFOOEP) { }

        // // RVA: 0xD5C4E8 Offset: 0xD5C4E8 VA: 0xD5C4E8
        // public List<AOJGDNFAIJL.MHOGKDIKIHE> PDECHELDNCC() { }

        // // RVA: 0xD5CAB0 Offset: 0xD5CAB0 VA: 0xD5CAB0
        private void ICANMPJECNA(int AHHJLDLAPAN, int IOPHIHFOOEP)
        {
            UnityEngine.Debug.LogError("TODO ICANMPJECNA");
        }

        // // RVA: 0xD5D1E8 Offset: 0xD5D1E8 VA: 0xD5D1E8
        // private void IKABJMHIAKH(int JPIDIENBGKH, int HEHKNMCDBJJ, int IOPHIHFOOEP) { }

        // // RVA: 0xD5D300 Offset: 0xD5D300 VA: 0xD5D300
        // private void DEINBFLAOIH(int LLOBHDMHJIG) { }

        // // RVA: 0xD5D314 Offset: 0xD5D314 VA: 0xD5D314
        public bool FLEMGCNKLIH(int IKPIDCFOFEA, int OIPCCBHIKIA)
        {
            if(CCEMEAAIKOL[IKPIDCFOFEA].Count <= OIPCCBHIKIA)
                return false;
            int val = CCEMEAAIKOL[IKPIDCFOFEA][OIPCCBHIKIA].PPFNGGCBJKC_DivaId;
            if(!NAENFAFGMEP_IsMultiDiva)
                val = DKNAIAKHHDC;
            if(OIPCCBHIKIA != 0)
                val = CCEMEAAIKOL[IKPIDCFOFEA][OIPCCBHIKIA].PPFNGGCBJKC_DivaId;
            ICANMPJECNA(val, IKPIDCFOFEA);
            return true;
        }

        // // RVA: 0xD5D488 Offset: 0xD5D488 VA: 0xD5D488
        // public bool HHIDNFEILFA(int IKPIDCFOFEA, int OIPCCBHIKIA) { }

        // // RVA: 0xD5D688 Offset: 0xD5D688 VA: 0xD5D688
        // public bool KEHGJNIGKBC(int OIPCCBHIKIA) { }

        // // RVA: 0xD5D78C Offset: 0xD5D78C VA: 0xD5D78C
        // public void NFMFFMDHBJO(bool PODBALIIGIK) { }

        // // RVA: 0xD5D794 Offset: 0xD5D794 VA: 0xD5D794
        // public void EOGMEFOFOBJ(bool PODBALIIGIK) { }

        // // RVA: 0xD5D79C Offset: 0xD5D79C VA: 0xD5D79C
        // public void FNMFBCGCPGP(bool PODBALIIGIK) { }

        // // RVA: 0xD5D7A4 Offset: 0xD5D7A4 VA: 0xD5D7A4
        // public void NEJBBHHINLA(bool PODBALIIGIK) { }

        // // RVA: 0xD5D7AC Offset: 0xD5D7AC VA: 0xD5D7AC
        public void LMAAILCIFLF()
        {
            UnityEngine.Debug.LogError("TODO LMAAILCIFLF");
        }

        // // RVA: 0xD5AF08 Offset: 0xD5AF08 VA: 0xD5AF08
        private void ADPFDMPMILA(int AHHJLDLAPAN_DivaId, ref int PDEEMMEHDPK_CostumeId, ref int HEHKNMCDBJJ_ColorId)
        {
            HEHKNMCDBJJ_ColorId = LDEGEHAEALK.DGCJCAHIAPP.LGKFMLIOPKL(AHHJLDLAPAN_DivaId).BEEAIAAJOHD;
            PDEEMMEHDPK_CostumeId = 0;
            LCLCCHLDNHJ_Costume.ILODJKFJJDO a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB(AHHJLDLAPAN_DivaId, HEHKNMCDBJJ_ColorId);
            if(a != null)
            {
                PDEEMMEHDPK_CostumeId = a.JPIDIENBGKH_PrismDivaID;
            }
        }

        // // RVA: 0xD5B0A8 Offset: 0xD5B0A8 VA: 0xD5B0A8
        private bool HPHDLNEKPKP(int JPIDIENBGKH_PrismDivaId, int AHHJLDLAPAN_CostumeId)
        {
            if(JPIDIENBGKH_PrismDivaId > 1 && AHHJLDLAPAN_CostumeId > 1) //??
            {
                foreach(var a in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA)
                {
                    if(a.PPEGAKEIEGM == 2 && a.JPIDIENBGKH_PrismDivaID == JPIDIENBGKH_PrismDivaId && a.AHHJLDLAPAN_PrismCostumeId == AHHJLDLAPAN_CostumeId)
                        return true;
                }
            }
            return false;
        }

        // // RVA: 0xD5DE98 Offset: 0xD5DE98 VA: 0xD5DE98
        // public int[] CEMKPBIBOCG(bool GIKLNODJKFK) { }

        // // RVA: 0xD5E2A8 Offset: 0xD5E2A8 VA: 0xD5E2A8
        // public int FGCCCMAFCNH() { }

        // // RVA: 0xD5E398 Offset: 0xD5E398 VA: 0xD5E398
        // public int GPGPOBJCMFB() { }

        // // RVA: 0xD5E488 Offset: 0xD5E488 VA: 0xD5E488
        // public void EKACMEKEJLP(AOJGDNFAIJL.AMIECPBIALP CJODFDGPKIA, int AHHJLDLAPAN, int IOPHIHFOOEP) { }

        // // RVA: 0xD5E944 Offset: 0xD5E944 VA: 0xD5E944
        // public AOJCMPIBFHD OOKAOFJBCFD() { }

        // // RVA: 0xD5EA54 Offset: 0xD5EA54 VA: 0xD5EA54
        // public bool CPGGFKAINHH() { }
    }

	public const int ALHBMNBOBAE = 5;
}
