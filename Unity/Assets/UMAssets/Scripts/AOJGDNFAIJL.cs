
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

public class AOJGDNFAIJL_PrismData
{
    public class LLHDHKLACJA_SelectDivaInfo
    {
        public int PPFNGGCBJKC_Id { get; set; }// 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
        public bool CBLHLEKLLDE_IsSet { get; set; } // 0xC LPCLOHOCPIG DDNKFFEAFGB NIDGBLGJJJP
    }
	
	public class BGCLFIILKIG_SelectCostumeInfo
	{
		public int PPFNGGCBJKC_Id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
		public int DOKKMMFKLJI_ColorId { get; set; } // 0xC HHLLKENPACJ FGEACNKHOEB KNMBKMIELEO
		public bool CBLHLEKLLDE_IsSet { get; set; } // 0x10 LPCLOHOCPIG DDNKFFEAFGB NIDGBLGJJJP
	}
    public class AMIECPBIALP
    {
        private readonly int DKNAIAKHHDC_Invalid = -1; // 0x8
        private readonly int OPICBODCKGG_None; // 0xC
        private List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo>[] CCEMEAAIKOL_DivasListBySlot = new List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo>[5]; // 0x24
        private List<AOJGDNFAIJL_PrismData.BGCLFIILKIG_SelectCostumeInfo>[] HJDEMKCNHJF_CostumeListBySlot = new List<AOJGDNFAIJL_PrismData.BGCLFIILKIG_SelectCostumeInfo>[5]; // 0x28
        // private List<AOJGDNFAIJL.MHOGKDIKIHE> MDNHCIKGEAE; // 0x2C
        private int[] ENCKALOAAMB_SelectedDivaIds; // 0x30
        private int[] LGPBDFHDMNA_SelectedCostumeIds; // 0x34
        private int[] DJCCKIAJFGH_SelectedCostumeColorIds; // 0x38
        private int AGBLOHKHHAB_SelectedValkyrieId; // 0x3C
        private int ICAJJLHPMDF_DefaultDivaId; // 0x40
        private int CLDDCHNMLLM_DefaultCostumeId; // 0x44
        private int CCEMMCJOPIO_DefaultColorId; // 0x48
        private int AOPLBEPHLID_DefaultValkyrieId; // 0x4C
        private BBHNACPENDM LDEGEHAEALK; // 0x50
        private NPOOPJIOMHF.CLGGEONAHPL_TeamSelectionSetting OOEPMEDAJNJ_Save; // 0x54
        private CIFHILOJJFC EOPODFDEMGF; // 0x58
        private bool NAENFAFGMEP_IsMultiDiva; // 0x5C
        private int PFMHBFAKNNL_NumDiva; // 0x60

        public int[] OMNDNNFANCK_PrismDivaIds { get; private set; } // 0x10 ACAKFKBJCIE PGFAAJJJPNH OKBCIFPNKIL // prismdivaids
        public int[] DLPIKHDNIIE_PrismCostumeIds { get; private set; } // 0x14 NKHEFHPGPOO JMJHBEFHIBN LMEJNJIEDOE // prismcostumeid
        public int[] PBHPPCPKHDL_PrismCostumeColorIds { get; private set; } // 0x18 JCMGMDGJBMF CFEGNKFHGAM CGKCELFGHCK // costume color id
        public int FBAGIDFLHHI_PrismValkyrieId { get; private set; } // 0x1C ALNPAMMMLLO FGBBLAADIDG AFJIFKDFNDI // valkId
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
            LDEGEHAEALK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save;
            if(LDEGEHAEALK != null)
            {
                OOEPMEDAJNJ_Save = LDEGEHAEALK.GHDDPJBBEOC.GCINIJEMHFK(DLAEJOBELBH_MusicId);
                EOPODFDEMGF = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP.BNECMLPHAGJ).DJPFJGKGOOF;
                int divaId = GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
                if(GameManager.Instance.localSave.EPJOACOONAC().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId < 1)
                {
                    divaId = EOPODFDEMGF.FDBOPFEOENF[0].DIPKCALNIII;
                }
                ICAJJLHPMDF_DefaultDivaId = divaId;
                ADPFDMPMILA_FindCostume(divaId, ref CLDDCHNMLLM_DefaultCostumeId, ref CCEMMCJOPIO_DefaultColorId);
                AOPLBEPHLID_DefaultValkyrieId = EOPODFDEMGF.FODKKJIDDKN;
                OOEPMEDAJNJ_Save.PPFNGGCBJKC = DLAEJOBELBH_MusicId;
                FBGAKINEIPG = OOEPMEDAJNJ_Save.PLALNIIBLOF != 1 ? false : true;
                OHLCKPIMMFH_ValkyrieMode = OOEPMEDAJNJ_Save.MKKGKKHABEK_ValkyrieMode != 1 ? false : true;
                HGEKDNNJAAC_DivaMode = OOEPMEDAJNJ_Save.JPBJOGBGKGA_DivaMode != 1 ? false : true;
                DNLCLAOPFPF_ShowNotes = OOEPMEDAJNJ_Save.NLFMKOJHAHJ_ShowNotes != 1 ? false : true;
                ENCKALOAAMB_SelectedDivaIds = new int[5];
                LGPBDFHDMNA_SelectedCostumeIds = new int[5];
                DJCCKIAJFGH_SelectedCostumeColorIds = new int[5];
                OMNDNNFANCK_PrismDivaIds = new int[5];
                DLPIKHDNIIE_PrismCostumeIds = new int[5];
                PBHPPCPKHDL_PrismCostumeColorIds = new int[5];
                int numDiva = 1;
                if(HJNAMIDGAJB_IsMultiDiva)
                    numDiva = 5;
                int DisplayDivaId = 0;
                int SelectedDivaId = 0;
                if(HJNAMIDGAJB_IsMultiDiva)
                {
                    ENCKALOAAMB_SelectedDivaIds[0] = OOEPMEDAJNJ_Save.AIPJAKIFMPN_SelectedDiva0Id;
                    ENCKALOAAMB_SelectedDivaIds[1] = OOEPMEDAJNJ_Save.JMAGFEENOED_SelectedDiva1Id;
                    ENCKALOAAMB_SelectedDivaIds[2] = OOEPMEDAJNJ_Save.LFHILMNKGCB_SelectedDiva2Id;
                    ENCKALOAAMB_SelectedDivaIds[3] = OOEPMEDAJNJ_Save.OLKOJOACIBD_SelectedDiva3Id;
                    ENCKALOAAMB_SelectedDivaIds[4] = OOEPMEDAJNJ_Save.INBGAKAAJPB_SelectedDiva4Id;

                    LGPBDFHDMNA_SelectedCostumeIds[0] = OOEPMEDAJNJ_Save.FHFONPEHLMN_SelectedCostume0Id;
                    LGPBDFHDMNA_SelectedCostumeIds[1] = OOEPMEDAJNJ_Save.HPPOFOIJJMB_SelectedCostume1Id;
                    LGPBDFHDMNA_SelectedCostumeIds[2] = OOEPMEDAJNJ_Save.NBPNNNBCGFG_SelectedCostume2Id;
                    LGPBDFHDMNA_SelectedCostumeIds[3] = OOEPMEDAJNJ_Save.LLKEMHHHLEN_SelectedCostume3Id;
                    LGPBDFHDMNA_SelectedCostumeIds[4] = OOEPMEDAJNJ_Save.DGDLPGFKCFA_SelectedCostume4Id;

                    DJCCKIAJFGH_SelectedCostumeColorIds[0] = OOEPMEDAJNJ_Save.ADLOGNCDIFG_SelectedCostumeColor0Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[1] = OOEPMEDAJNJ_Save.DFHNEEBKEIC_SelectedCostumeColor1Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[2] = OOEPMEDAJNJ_Save.BFMDCDFAJKE_SelectedCostumeColor2Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[3] = OOEPMEDAJNJ_Save.OHCNKIKIGHM_SelectedCostumeColor3Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[4] = OOEPMEDAJNJ_Save.HDKHGAACNFG_SelectedCostumecolor4Id;

                    AGBLOHKHHAB_SelectedValkyrieId = OOEPMEDAJNJ_Save.PIJEEAOMMGA_SelectedValkyrie;
                    DisplayDivaId = OPICBODCKGG_None;
                    SelectedDivaId = OPICBODCKGG_None;
                }
                else
                {
                    ENCKALOAAMB_SelectedDivaIds[0] = OOEPMEDAJNJ_Save.OCAMDLMPBGA_SelectedDivaSoloId;
                    ENCKALOAAMB_SelectedDivaIds[1] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[2] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[3] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[4] = OPICBODCKGG_None;

                    LGPBDFHDMNA_SelectedCostumeIds[0] = OOEPMEDAJNJ_Save.PGCEGEJOOON_SelectedCostumeSoloId;
                    LGPBDFHDMNA_SelectedCostumeIds[1] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[2] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[3] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[4] = OPICBODCKGG_None;

                    DJCCKIAJFGH_SelectedCostumeColorIds[0] = OOEPMEDAJNJ_Save.IAFIKNONLJF_SelectedCostumeColorSoloId;
                    DJCCKIAJFGH_SelectedCostumeColorIds[1] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[2] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[3] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[4] = OPICBODCKGG_None;

                    AGBLOHKHHAB_SelectedValkyrieId = OOEPMEDAJNJ_Save.EPDPAHNLMKH_SelectedValkyrieSoloId;
                    DisplayDivaId = ICAJJLHPMDF_DefaultDivaId;
                    SelectedDivaId = DKNAIAKHHDC_Invalid;
                }
                for(int i = 0; i < numDiva; i++)
                {
                    if(OPICBODCKGG_None < ENCKALOAAMB_SelectedDivaIds[i])
                    {
                        OMNDNNFANCK_PrismDivaIds[i] = ENCKALOAAMB_SelectedDivaIds[i];
                    }
                    else
                    {
                        OMNDNNFANCK_PrismDivaIds[i] = DisplayDivaId;
                        ENCKALOAAMB_SelectedDivaIds[i] = SelectedDivaId;
                    }
                    if(OPICBODCKGG_None < OMNDNNFANCK_PrismDivaIds[i])
                    {
                        if(OPICBODCKGG_None < LGPBDFHDMNA_SelectedCostumeIds[i])
                        {
                            if(HPHDLNEKPKP_IsCostumeValidForDiva(LGPBDFHDMNA_SelectedCostumeIds[i], OMNDNNFANCK_PrismDivaIds[i]))
                            {
                                DLPIKHDNIIE_PrismCostumeIds[i] = LGPBDFHDMNA_SelectedCostumeIds[i];
                                PBHPPCPKHDL_PrismCostumeColorIds[i] = DJCCKIAJFGH_SelectedCostumeColorIds[i];
                            }
                            else
                            {
                                LGPBDFHDMNA_SelectedCostumeIds[i] = DKNAIAKHHDC_Invalid;
                                DJCCKIAJFGH_SelectedCostumeColorIds[i] = DKNAIAKHHDC_Invalid;
                            }
                        }
                        else if(!HJNAMIDGAJB_IsMultiDiva)
                        {
                            LGPBDFHDMNA_SelectedCostumeIds[i] = DKNAIAKHHDC_Invalid;
                            DJCCKIAJFGH_SelectedCostumeColorIds[i] = DKNAIAKHHDC_Invalid;
                        }
                        if(LGPBDFHDMNA_SelectedCostumeIds[i] == DKNAIAKHHDC_Invalid)
                        {
                            ADPFDMPMILA_FindCostume(OMNDNNFANCK_PrismDivaIds[i], ref CLDDCHNMLLM_DefaultCostumeId, ref CCEMMCJOPIO_DefaultColorId);
                            DLPIKHDNIIE_PrismCostumeIds[i] = CLDDCHNMLLM_DefaultCostumeId;
                            PBHPPCPKHDL_PrismCostumeColorIds[i] = CCEMMCJOPIO_DefaultColorId;
                        }
                    }
                    else
                    {
                        DLPIKHDNIIE_PrismCostumeIds[i] = OPICBODCKGG_None;
                        PBHPPCPKHDL_PrismCostumeColorIds[i] = OPICBODCKGG_None;
                        LGPBDFHDMNA_SelectedCostumeIds[i] = OPICBODCKGG_None;
                        DJCCKIAJFGH_SelectedCostumeColorIds[i] = OPICBODCKGG_None;
                    }
                }
                if(AGBLOHKHHAB_SelectedValkyrieId < 1)
                {
                    FBAGIDFLHHI_PrismValkyrieId = AOPLBEPHLID_DefaultValkyrieId;
                    AGBLOHKHHAB_SelectedValkyrieId = DKNAIAKHHDC_Invalid;
                }
                else
                {
                    FBAGIDFLHHI_PrismValkyrieId = AGBLOHKHHAB_SelectedValkyrieId;
                }
            }
            if(!NAENFAFGMEP_IsMultiDiva)
            {
                PFMHBFAKNNL_NumDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH_MusicId).NJAOOMHCIHL_Dvs;
            }
            else
            {
                PFMHBFAKNNL_NumDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH_MusicId).PECMGDOMLAF_Dvm;
            }
        }

        // // RVA: 0xD5B314 Offset: 0xD5B314 VA: 0xD5B314
        public int PNBKLGKCKGO_GetPrismDivaIdForSlot(int IOPHIHFOOEP_SlotIdx)
		{
			if(IOPHIHFOOEP_SlotIdx < 5)
			{
				return OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIdx];
			}
			return OPICBODCKGG_None;
		}

        // // RVA: 0xD5B370 Offset: 0xD5B370 VA: 0xD5B370
        public int OCNHIHMAGMJ_GetPrismCostumeIdForSlot(int IOPHIHFOOEP_SlotIdx)
		{
			if (IOPHIHFOOEP_SlotIdx < 5)
			{
				return DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIdx];
			}
			return OPICBODCKGG_None;
		}

        // // RVA: 0xD5B3CC Offset: 0xD5B3CC VA: 0xD5B3CC
        public int DOIGAGAAAOP_GetPrismCostumeColorIdForSlot(int IOPHIHFOOEP_SlotIdx)
		{
			if (IOPHIHFOOEP_SlotIdx < 5)
			{
				return PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIdx];
			}
			return OPICBODCKGG_None;
		}

        // // RVA: 0xD5B428 Offset: 0xD5B428 VA: 0xD5B428
        public int PNDKNFBLKDP_GetPrismValkyrieId()
		{
			return FBAGIDFLHHI_PrismValkyrieId;
		}

        // // RVA: 0xD5B430 Offset: 0xD5B430 VA: 0xD5B430
        // public bool OFHMEAJBIEL() { }

        // // RVA: 0xD5B494 Offset: 0xD5B494 VA: 0xD5B494
        // public int DPHIJENPBCJ() { }

        // // RVA: 0xD5B584 Offset: 0xD5B584 VA: 0xD5B584
        public List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo> IANKDOFJLGB_GetDivasForSlot(int IOPHIHFOOEP_SlotIndex)
        {
            AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo data = new AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo();
            List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo> res = new List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo>(10);
            CCEMEAAIKOL_DivasListBySlot[IOPHIHFOOEP_SlotIndex] = res;
            CCEMEAAIKOL_DivasListBySlot[IOPHIHFOOEP_SlotIndex].Clear();
            bool isSet = false;
            if(!NAENFAFGMEP_IsMultiDiva)
            {
                data.PPFNGGCBJKC_Id = ICAJJLHPMDF_DefaultDivaId;
                data.CBLHLEKLLDE_IsSet = ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP_SlotIndex] == DKNAIAKHHDC_Invalid;
                isSet = data.CBLHLEKLLDE_IsSet;
                CCEMEAAIKOL_DivasListBySlot[IOPHIHFOOEP_SlotIndex].Add(data);
            }
            foreach(DEKKMGAFJCG.MNNLOBDPCCH a in LDEGEHAEALK.DGCJCAHIAPP.NBIGLBMHEDC)
            {
                if(RuntimeSettings.ForceDivaUnlock || a.CPGFPEDMDEH == 1)
                {
                    AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo data2 = new AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo();
                    data2.PPFNGGCBJKC_Id = a.DIPKCALNIII;
                    data2.CBLHLEKLLDE_IsSet = false;
                    if(!isSet)
                    {
                        if(OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIndex] == a.DIPKCALNIII)
                        {
                            data2.CBLHLEKLLDE_IsSet = true;
                        }
                    }
                    CCEMEAAIKOL_DivasListBySlot[IOPHIHFOOEP_SlotIndex].Add(data2);
                }
            }
            return CCEMEAAIKOL_DivasListBySlot[IOPHIHFOOEP_SlotIndex];
        }

        // // RVA: 0xD5BAF4 Offset: 0xD5BAF4 VA: 0xD5BAF4
        public List<BGCLFIILKIG_SelectCostumeInfo> ANNOBPMEDKK_GetCostumesForSlot(int IOPHIHFOOEP_SlotIndex)
		{
			BGCLFIILKIG_SelectCostumeInfo info = new BGCLFIILKIG_SelectCostumeInfo();
			int costumeId = 0, colorId = 0;
			ADPFDMPMILA_FindCostume(OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIndex], ref costumeId, ref colorId);
			info.PPFNGGCBJKC_Id = costumeId;
			info.DOKKMMFKLJI_ColorId = colorId;
			info.CBLHLEKLLDE_IsSet = LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIndex] < 1;
			HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex] = new List<BGCLFIILKIG_SelectCostumeInfo>(501);
			HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex].Clear();
			HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex].Add(info);

			for(int i = 0; i < LDEGEHAEALK.BEKHNNCGIEL.FABAGMLEKIB.Count; i++)
			{
				int val = LDEGEHAEALK.BEKHNNCGIEL.FABAGMLEKIB[i].BEEAIAAJOHD_CostumeId;
				if (val > 0)
					val--;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA[val];
				if(cosInfo.PPEGAKEIEGM == 2)
				{
					if (OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIndex] == cosInfo.AHHJLDLAPAN_PrismDivaId) //???
					{
						int val3 = 0;
						if(RuntimeSettings.ForceCostumeUnlock || LDEGEHAEALK.BEKHNNCGIEL.FABAGMLEKIB[i].CGKAEMGLHNK())
						{
							val3 = LDEGEHAEALK.BEKHNNCGIEL.FABAGMLEKIB[i].BEEAIAAJOHD_CostumeId;
						}
						else
						{
							if (cosInfo.DAJGPBLEEOB_PrismCostumeModelId != 1)
								continue;
							val3 = cosInfo.JPIDIENBGKH_CostumeId;
						}
						if(val3 > 0)
						{
							BGCLFIILKIG_SelectCostumeInfo info2 = new BGCLFIILKIG_SelectCostumeInfo();
							info2.PPFNGGCBJKC_Id = val3;
							info2.CBLHLEKLLDE_IsSet = false;
							if(LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIndex] > 0)
							{
								if(val3 == DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIndex])
								{
									if(PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIndex] == 0)
										info2.CBLHLEKLLDE_IsSet = true;
								}
							}
							HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex].Add(info2);
							short[] colorList = cosInfo.KKLPLPGBOFD(LDEGEHAEALK.BEKHNNCGIEL.FABAGMLEKIB[i].ANAJIAENLNB);
							for (int j = 0; j < colorList.Length; j++)
							{
								BGCLFIILKIG_SelectCostumeInfo info3 = new BGCLFIILKIG_SelectCostumeInfo();
								info3.PPFNGGCBJKC_Id = val3;
								info3.DOKKMMFKLJI_ColorId = colorList[j];
								info3.CBLHLEKLLDE_IsSet = false;
								if (LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIndex] > 0)
								{
									if (val3 == DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIndex])
									{
										info2.CBLHLEKLLDE_IsSet = PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIndex] == colorList[j];
									}
								}
								HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex].Add(info3);
							}
						}
					}
				}
			}

			return HJDEMKCNHJF_CostumeListBySlot[IOPHIHFOOEP_SlotIndex];
		}

        // // RVA: 0xD5C4E8 Offset: 0xD5C4E8 VA: 0xD5C4E8
        // public List<AOJGDNFAIJL.MHOGKDIKIHE> PDECHELDNCC() { }

        // // RVA: 0xD5CAB0 Offset: 0xD5CAB0 VA: 0xD5CAB0
        private void ICANMPJECNA_SelectDiva(int AHHJLDLAPAN_divaId, int IOPHIHFOOEP_SlotIdx)
        {
			if(IOPHIHFOOEP_SlotIdx < 5)
			{
				int divaId = AHHJLDLAPAN_divaId;
				if (divaId < 1)
					divaId = ICAJJLHPMDF_DefaultDivaId;
				if(!NAENFAFGMEP_IsMultiDiva)
				{
					bool found = false;
					for(int i = 0; i < OMNDNNFANCK_PrismDivaIds.Length; i++)
					{
						if(IOPHIHFOOEP_SlotIdx != i)
						{
							if(OMNDNNFANCK_PrismDivaIds[i] == divaId)
							{
								OMNDNNFANCK_PrismDivaIds[i] = OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIdx];

								int tmp = DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIdx];
								DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIdx] = DLPIKHDNIIE_PrismCostumeIds[i];
								DLPIKHDNIIE_PrismCostumeIds[i] = tmp;

								tmp = PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIdx];
								PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIdx] = PBHPPCPKHDL_PrismCostumeColorIds[i];
								PBHPPCPKHDL_PrismCostumeColorIds[i] = tmp;

								tmp = ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP_SlotIdx];
								ENCKALOAAMB_SelectedDivaIds[i] = tmp;

								tmp = LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIdx];
								LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIdx] = LGPBDFHDMNA_SelectedCostumeIds[i];
								LGPBDFHDMNA_SelectedCostumeIds[i] = tmp;

								tmp = DJCCKIAJFGH_SelectedCostumeColorIds[IOPHIHFOOEP_SlotIdx];
								DJCCKIAJFGH_SelectedCostumeColorIds[IOPHIHFOOEP_SlotIdx] = DJCCKIAJFGH_SelectedCostumeColorIds[i];
								DJCCKIAJFGH_SelectedCostumeColorIds[i] = tmp;

								ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP_SlotIdx] = AHHJLDLAPAN_divaId;
								found = true;
								break;
							}
						}
					}
					if(!found)
					{
						ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP_SlotIdx] = AHHJLDLAPAN_divaId;
					}
					if(OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIdx] != divaId || LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIdx] == OPICBODCKGG_None)
					{
						LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIdx] = DKNAIAKHHDC_Invalid;
						ADPFDMPMILA_FindCostume(divaId, ref CLDDCHNMLLM_DefaultCostumeId, ref CCEMMCJOPIO_DefaultColorId);
						DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIdx] = CLDDCHNMLLM_DefaultCostumeId;
						PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIdx] = CCEMMCJOPIO_DefaultColorId;
					}
					OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIdx] = divaId;
				}
			}
        }

        // // RVA: 0xD5D1E8 Offset: 0xD5D1E8 VA: 0xD5D1E8
        private void IKABJMHIAKH_SelectCostume(int JPIDIENBGKH_CostumeId, int HEHKNMCDBJJ_ColorId, int IOPHIHFOOEP_SlotIndex)
		{
			if (IOPHIHFOOEP_SlotIndex > 4)
				return;
			LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP_SlotIndex] = JPIDIENBGKH_CostumeId;
			DJCCKIAJFGH_SelectedCostumeColorIds[IOPHIHFOOEP_SlotIndex] = HEHKNMCDBJJ_ColorId;
			DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIndex] = JPIDIENBGKH_CostumeId;
			if (JPIDIENBGKH_CostumeId < 1)
				DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP_SlotIndex] = CLDDCHNMLLM_DefaultCostumeId;
			PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIndex] = HEHKNMCDBJJ_ColorId;
			if (JPIDIENBGKH_CostumeId < 1)
				PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP_SlotIndex] = CCEMMCJOPIO_DefaultColorId;
		}

        // // RVA: 0xD5D300 Offset: 0xD5D300 VA: 0xD5D300
        // private void DEINBFLAOIH(int LLOBHDMHJIG) { }

        // // RVA: 0xD5D314 Offset: 0xD5D314 VA: 0xD5D314
        public bool FLEMGCNKLIH_SelectDiva(int IKPIDCFOFEA_SlotIdx, int OIPCCBHIKIA_Index)
        {
            if(CCEMEAAIKOL_DivasListBySlot[IKPIDCFOFEA_SlotIdx].Count <= OIPCCBHIKIA_Index)
                return false;
            int val = CCEMEAAIKOL_DivasListBySlot[IKPIDCFOFEA_SlotIdx][OIPCCBHIKIA_Index].PPFNGGCBJKC_Id;
            if(!NAENFAFGMEP_IsMultiDiva)
                val = DKNAIAKHHDC_Invalid;
            if(OIPCCBHIKIA_Index != 0)
                val = CCEMEAAIKOL_DivasListBySlot[IKPIDCFOFEA_SlotIdx][OIPCCBHIKIA_Index].PPFNGGCBJKC_Id;
            ICANMPJECNA_SelectDiva(val, IKPIDCFOFEA_SlotIdx);
            return true;
        }

        // // RVA: 0xD5D488 Offset: 0xD5D488 VA: 0xD5D488
        public bool HHIDNFEILFA_SelectCostume(int IKPIDCFOFEA_SlotIdx, int OIPCCBHIKIA_Index)
		{
			if (HJDEMKCNHJF_CostumeListBySlot[IKPIDCFOFEA_SlotIdx].Count <= OIPCCBHIKIA_Index)
				return false;
			IKABJMHIAKH_SelectCostume(HJDEMKCNHJF_CostumeListBySlot[IKPIDCFOFEA_SlotIdx][OIPCCBHIKIA_Index].PPFNGGCBJKC_Id, HJDEMKCNHJF_CostumeListBySlot[IKPIDCFOFEA_SlotIdx][OIPCCBHIKIA_Index].DOKKMMFKLJI_ColorId, IKPIDCFOFEA_SlotIdx);
			return true;
		}

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
        public void LMAAILCIFLF_ApplyInSave()
        {
			if(!NAENFAFGMEP_IsMultiDiva)
			{
				OOEPMEDAJNJ_Save.OCAMDLMPBGA_SelectedDivaSoloId = ENCKALOAAMB_SelectedDivaIds[0];
				OOEPMEDAJNJ_Save.PGCEGEJOOON_SelectedCostumeSoloId = LGPBDFHDMNA_SelectedCostumeIds[0];
				OOEPMEDAJNJ_Save.IAFIKNONLJF_SelectedCostumeColorSoloId = DJCCKIAJFGH_SelectedCostumeColorIds[0];
				OOEPMEDAJNJ_Save.EPDPAHNLMKH_SelectedValkyrieSoloId = AGBLOHKHHAB_SelectedValkyrieId;
			}
			else
			{
				OOEPMEDAJNJ_Save.AIPJAKIFMPN_SelectedDiva0Id = ENCKALOAAMB_SelectedDivaIds[0];
				OOEPMEDAJNJ_Save.JMAGFEENOED_SelectedDiva1Id = ENCKALOAAMB_SelectedDivaIds[1];
				OOEPMEDAJNJ_Save.LFHILMNKGCB_SelectedDiva2Id = ENCKALOAAMB_SelectedDivaIds[2];
				OOEPMEDAJNJ_Save.OLKOJOACIBD_SelectedDiva3Id = ENCKALOAAMB_SelectedDivaIds[3];
				OOEPMEDAJNJ_Save.INBGAKAAJPB_SelectedDiva4Id = ENCKALOAAMB_SelectedDivaIds[4];

				OOEPMEDAJNJ_Save.FHFONPEHLMN_SelectedCostume0Id = LGPBDFHDMNA_SelectedCostumeIds[0];
				OOEPMEDAJNJ_Save.HPPOFOIJJMB_SelectedCostume1Id = LGPBDFHDMNA_SelectedCostumeIds[1];
				OOEPMEDAJNJ_Save.NBPNNNBCGFG_SelectedCostume2Id = LGPBDFHDMNA_SelectedCostumeIds[2];
				OOEPMEDAJNJ_Save.LLKEMHHHLEN_SelectedCostume3Id = LGPBDFHDMNA_SelectedCostumeIds[3];
				OOEPMEDAJNJ_Save.DGDLPGFKCFA_SelectedCostume4Id = LGPBDFHDMNA_SelectedCostumeIds[4];

				OOEPMEDAJNJ_Save.ADLOGNCDIFG_SelectedCostumeColor0Id = DJCCKIAJFGH_SelectedCostumeColorIds[0];
				OOEPMEDAJNJ_Save.DFHNEEBKEIC_SelectedCostumeColor1Id = DJCCKIAJFGH_SelectedCostumeColorIds[1];
				OOEPMEDAJNJ_Save.BFMDCDFAJKE_SelectedCostumeColor2Id = DJCCKIAJFGH_SelectedCostumeColorIds[2];
				OOEPMEDAJNJ_Save.OHCNKIKIGHM_SelectedCostumeColor3Id = DJCCKIAJFGH_SelectedCostumeColorIds[3];
				OOEPMEDAJNJ_Save.HDKHGAACNFG_SelectedCostumecolor4Id = DJCCKIAJFGH_SelectedCostumeColorIds[4];

				OOEPMEDAJNJ_Save.PIJEEAOMMGA_SelectedValkyrie = AGBLOHKHHAB_SelectedValkyrieId;
			}

			OOEPMEDAJNJ_Save.PLALNIIBLOF = FBGAKINEIPG ? 1 : 0;
			OOEPMEDAJNJ_Save.MKKGKKHABEK_ValkyrieMode = OHLCKPIMMFH_ValkyrieMode ? 1 : 0;
			OOEPMEDAJNJ_Save.JPBJOGBGKGA_DivaMode = HGEKDNNJAAC_DivaMode ? 1 : 0;
			OOEPMEDAJNJ_Save.NLFMKOJHAHJ_ShowNotes = DNLCLAOPFPF_ShowNotes ? 1 : 0;
        }

        // // RVA: 0xD5AF08 Offset: 0xD5AF08 VA: 0xD5AF08
        private void ADPFDMPMILA_FindCostume(int AHHJLDLAPAN_DivaId, ref int PDEEMMEHDPK_CostumeId, ref int HEHKNMCDBJJ_ColorId)
        {
            PDEEMMEHDPK_CostumeId = 0;
            LCLCCHLDNHJ_Costume.ILODJKFJJDO a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB(AHHJLDLAPAN_DivaId, LDEGEHAEALK.DGCJCAHIAPP.LGKFMLIOPKL(AHHJLDLAPAN_DivaId).BEEAIAAJOHD);
            if(a != null)
            {
                PDEEMMEHDPK_CostumeId = a.JPIDIENBGKH_CostumeId;
			}
			HEHKNMCDBJJ_ColorId = LDEGEHAEALK.DGCJCAHIAPP.LGKFMLIOPKL(AHHJLDLAPAN_DivaId).AFNIOJHODAG;
		}

        // // RVA: 0xD5B0A8 Offset: 0xD5B0A8 VA: 0xD5B0A8
        private bool HPHDLNEKPKP_IsCostumeValidForDiva(int JPIDIENBGKH_CostumeId, int AHHJLDLAPAN_DivaId)
        {
            if(JPIDIENBGKH_CostumeId > 1 && AHHJLDLAPAN_DivaId > 1) //??
            {
                foreach(var a in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA)
                {
                    if(a.PPEGAKEIEGM == 2 && a.JPIDIENBGKH_CostumeId == JPIDIENBGKH_CostumeId && a.AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN_DivaId)
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
