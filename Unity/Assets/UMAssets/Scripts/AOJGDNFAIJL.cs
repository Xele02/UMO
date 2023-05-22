
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

[System.Obsolete("Use AOJGDNFAIJL_PrismData", true)]
public class AOJGDNFAIJL { }
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
	
	public class MHOGKDIKIHE_ValkyrieInfo
	{
		public int PPFNGGCBJKC_Id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
		public bool CBLHLEKLLDE_IsSet { get; set; }  // 0xC LPCLOHOCPIG DDNKFFEAFGB NIDGBLGJJJP
	}

    public class AMIECPBIALP
    {
        private readonly int DKNAIAKHHDC_Invalid = -1; // 0x8
        private readonly int OPICBODCKGG_None; // 0xC
        private List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo>[] CCEMEAAIKOL_DivasListBySlot = new List<AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo>[5]; // 0x24
        private List<AOJGDNFAIJL_PrismData.BGCLFIILKIG_SelectCostumeInfo>[] HJDEMKCNHJF_CostumeListBySlot = new List<AOJGDNFAIJL_PrismData.BGCLFIILKIG_SelectCostumeInfo>[5]; // 0x28
        private List<AOJGDNFAIJL_PrismData.MHOGKDIKIHE_ValkyrieInfo> MDNHCIKGEAE_ValkyrieList; // 0x2C
        private int[] ENCKALOAAMB_SelectedDivaIds; // 0x30
        private int[] LGPBDFHDMNA_SelectedCostumeIds; // 0x34
        private int[] DJCCKIAJFGH_SelectedCostumeColorIds; // 0x38
        private int AGBLOHKHHAB_SelectedValkyrieId; // 0x3C
        private int ICAJJLHPMDF_DefaultDivaId; // 0x40
        private int CLDDCHNMLLM_DefaultCostumeId; // 0x44
        private int CCEMMCJOPIO_DefaultColorId; // 0x48
        private int AOPLBEPHLID_DefaultValkyrieId; // 0x4C
        private BBHNACPENDM_ServerSaveData LDEGEHAEALK_Save; // 0x50
        private NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting OOEPMEDAJNJ_TeamSave; // 0x54
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
            LDEGEHAEALK_Save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
            if(LDEGEHAEALK_Save != null)
            {
                OOEPMEDAJNJ_TeamSave = LDEGEHAEALK_Save.GHDDPJBBEOC_Prism.GCINIJEMHFK_GetTeamForSong(DLAEJOBELBH_MusicId);
                EOPODFDEMGF = GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(Database.Instance.gameSetup.musicInfo.gameEventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva).DJPFJGKGOOF_ScoreTeam;
                int divaId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
                if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId < 1)
                {
                    divaId = EOPODFDEMGF.FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id;
                }
                ICAJJLHPMDF_DefaultDivaId = divaId;
                ADPFDMPMILA_FindCostume(divaId, ref CLDDCHNMLLM_DefaultCostumeId, ref CCEMMCJOPIO_DefaultColorId);
                AOPLBEPHLID_DefaultValkyrieId = EOPODFDEMGF.FODKKJIDDKN_VfId;
                OOEPMEDAJNJ_TeamSave.PPFNGGCBJKC_Id = DLAEJOBELBH_MusicId;
                FBGAKINEIPG = OOEPMEDAJNJ_TeamSave.PLALNIIBLOF_Enabled != 1 ? false : true;
                OHLCKPIMMFH_ValkyrieMode = OOEPMEDAJNJ_TeamSave.MKKGKKHABEK_ValkyrieMode != 1 ? false : true;
                HGEKDNNJAAC_DivaMode = OOEPMEDAJNJ_TeamSave.JPBJOGBGKGA_DivaMode != 1 ? false : true;
                DNLCLAOPFPF_ShowNotes = OOEPMEDAJNJ_TeamSave.NLFMKOJHAHJ_ShowNotes != 1 ? false : true;
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
                    ENCKALOAAMB_SelectedDivaIds[0] = OOEPMEDAJNJ_TeamSave.AIPJAKIFMPN_SelectedDiva0Id;
                    ENCKALOAAMB_SelectedDivaIds[1] = OOEPMEDAJNJ_TeamSave.JMAGFEENOED_SelectedDiva1Id;
                    ENCKALOAAMB_SelectedDivaIds[2] = OOEPMEDAJNJ_TeamSave.LFHILMNKGCB_SelectedDiva2Id;
                    ENCKALOAAMB_SelectedDivaIds[3] = OOEPMEDAJNJ_TeamSave.OLKOJOACIBD_SelectedDiva3Id;
                    ENCKALOAAMB_SelectedDivaIds[4] = OOEPMEDAJNJ_TeamSave.INBGAKAAJPB_SelectedDiva4Id;

                    LGPBDFHDMNA_SelectedCostumeIds[0] = OOEPMEDAJNJ_TeamSave.FHFONPEHLMN_SelectedCostume0Id;
                    LGPBDFHDMNA_SelectedCostumeIds[1] = OOEPMEDAJNJ_TeamSave.HPPOFOIJJMB_SelectedCostume1Id;
                    LGPBDFHDMNA_SelectedCostumeIds[2] = OOEPMEDAJNJ_TeamSave.NBPNNNBCGFG_SelectedCostume2Id;
                    LGPBDFHDMNA_SelectedCostumeIds[3] = OOEPMEDAJNJ_TeamSave.LLKEMHHHLEN_SelectedCostume3Id;
                    LGPBDFHDMNA_SelectedCostumeIds[4] = OOEPMEDAJNJ_TeamSave.DGDLPGFKCFA_SelectedCostume4Id;

                    DJCCKIAJFGH_SelectedCostumeColorIds[0] = OOEPMEDAJNJ_TeamSave.ADLOGNCDIFG_SelectedCostumeColor0Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[1] = OOEPMEDAJNJ_TeamSave.DFHNEEBKEIC_SelectedCostumeColor1Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[2] = OOEPMEDAJNJ_TeamSave.BFMDCDFAJKE_SelectedCostumeColor2Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[3] = OOEPMEDAJNJ_TeamSave.OHCNKIKIGHM_SelectedCostumeColor3Id;
                    DJCCKIAJFGH_SelectedCostumeColorIds[4] = OOEPMEDAJNJ_TeamSave.HDKHGAACNFG_SelectedCostumeColor4Id;

                    AGBLOHKHHAB_SelectedValkyrieId = OOEPMEDAJNJ_TeamSave.PIJEEAOMMGA_SelectedValkyrie;
                    DisplayDivaId = OPICBODCKGG_None;
                    SelectedDivaId = OPICBODCKGG_None;
                }
                else
                {
                    ENCKALOAAMB_SelectedDivaIds[0] = OOEPMEDAJNJ_TeamSave.OCAMDLMPBGA_SelectedDivaSoloId;
                    ENCKALOAAMB_SelectedDivaIds[1] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[2] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[3] = OPICBODCKGG_None;
                    ENCKALOAAMB_SelectedDivaIds[4] = OPICBODCKGG_None;

                    LGPBDFHDMNA_SelectedCostumeIds[0] = OOEPMEDAJNJ_TeamSave.PGCEGEJOOON_SelectedCostumeSoloId;
                    LGPBDFHDMNA_SelectedCostumeIds[1] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[2] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[3] = OPICBODCKGG_None;
                    LGPBDFHDMNA_SelectedCostumeIds[4] = OPICBODCKGG_None;

                    DJCCKIAJFGH_SelectedCostumeColorIds[0] = OOEPMEDAJNJ_TeamSave.IAFIKNONLJF_SelectedCostumeColorSoloId;
                    DJCCKIAJFGH_SelectedCostumeColorIds[1] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[2] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[3] = OPICBODCKGG_None;
                    DJCCKIAJFGH_SelectedCostumeColorIds[4] = OPICBODCKGG_None;

                    AGBLOHKHHAB_SelectedValkyrieId = OOEPMEDAJNJ_TeamSave.EPDPAHNLMKH_SelectedValkyrieSoloId;
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
                PFMHBFAKNNL_NumDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH_MusicId).NJAOOMHCIHL_DivaSolo;
            }
            else
            {
                PFMHBFAKNNL_NumDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(DLAEJOBELBH_MusicId).PECMGDOMLAF_DivaMulti;
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
        public bool OFHMEAJBIEL_IsPrismUnlocked()
		{
			return DPHIJENPBCJ_GetPrismLevelRequired() <= LDEGEHAEALK_Save.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		}

        // // RVA: 0xD5B494 Offset: 0xD5B494 VA: 0xD5B494
        public int DPHIJENPBCJ_GetPrismLevelRequired()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("prism_player_level", 9999);
		}

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
            foreach(DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo a in LDEGEHAEALK_Save.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList)
            {
                if(/*RuntimeSettings.CurrentSettings.ForceDivaUnlock || */a.CPGFPEDMDEH_Have == 1)
                {
                    AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo data2 = new AOJGDNFAIJL_PrismData.LLHDHKLACJA_SelectDivaInfo();
                    data2.PPFNGGCBJKC_Id = a.DIPKCALNIII_DivaId;
                    data2.CBLHLEKLLDE_IsSet = false;
                    if(!isSet)
                    {
                        if(OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIndex] == a.DIPKCALNIII_DivaId)
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

			for(int i = 0; i < LDEGEHAEALK_Save.BEKHNNCGIEL_Costume.FABAGMLEKIB_List.Count; i++)
			{
				int val = LDEGEHAEALK_Save.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId;
				if (val > 0)
					val--;
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[val];
				if(cosInfo.PPEGAKEIEGM_Enabled == 2)
				{
					if (OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP_SlotIndex] == cosInfo.AHHJLDLAPAN_PrismDivaId) //???
					{
						int val3 = 0;
						if(LDEGEHAEALK_Save.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].CGKAEMGLHNK_Possessed())
						{
							val3 = LDEGEHAEALK_Save.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].BEEAIAAJOHD_CostumeId;
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
							short[] colorList = cosInfo.KKLPLPGBOFD_GetAvaiableColor(LDEGEHAEALK_Save.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].ANAJIAENLNB_Level);
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
        public List<MHOGKDIKIHE_ValkyrieInfo> PDECHELDNCC()
		{
			MHOGKDIKIHE_ValkyrieInfo defaultInfo = new MHOGKDIKIHE_ValkyrieInfo();
			defaultInfo.PPFNGGCBJKC_Id = AOPLBEPHLID_DefaultValkyrieId;
			defaultInfo.CBLHLEKLLDE_IsSet = AGBLOHKHHAB_SelectedValkyrieId < 1;
			MDNHCIKGEAE_ValkyrieList = new List<MHOGKDIKIHE_ValkyrieInfo>(101);
			MDNHCIKGEAE_ValkyrieList.Clear();
			MDNHCIKGEAE_ValkyrieList.Add(defaultInfo);
			JPIANKEOOMB_Valkyrie valkDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie;
			foreach (OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo valk in LDEGEHAEALK_Save.JJFFBDLIOCF_Valkyrie.CNGNBKNBKGI_ValkList)
			{
				MHOGKDIKIHE_ValkyrieInfo data = new MHOGKDIKIHE_ValkyrieInfo();
				int val = valk.FODKKJIDDKN_Id;
				if (val < 1)
					val = 0;
				else
					val = val - 1;
				JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = valkDb.CDENCMNHNGA_ValkyrieList[val];
				if (dbValk.PPEGAKEIEGM_Enabled == 2 && valk.FJODMPGPDDD)
				{
					if(dbValk.GPPEFLKGGGJ_Id == valk.FODKKJIDDKN_Id)
					{
						data.PPFNGGCBJKC_Id = valk.FODKKJIDDKN_Id;
						if(AGBLOHKHHAB_SelectedValkyrieId < 1)
						{
							data.CBLHLEKLLDE_IsSet = false;
						}
						else
						{
							data.CBLHLEKLLDE_IsSet = valk.FODKKJIDDKN_Id == FBAGIDFLHHI_PrismValkyrieId;
						}
						MDNHCIKGEAE_ValkyrieList.Add(data);
					}
				}
			}
			return MDNHCIKGEAE_ValkyrieList;
		}

        // // RVA: 0xD5CAB0 Offset: 0xD5CAB0 VA: 0xD5CAB0
        private void ICANMPJECNA_SelectDiva(int AHHJLDLAPAN_divaId, int IOPHIHFOOEP_SlotIdx)
        {
			if(IOPHIHFOOEP_SlotIdx < 5)
			{
				int divaId = AHHJLDLAPAN_divaId;
				if (divaId < 1)
					divaId = ICAJJLHPMDF_DefaultDivaId;
                UnityEngine.Debug.Log("Select diva "+divaId);
				bool found = false;
				if(NAENFAFGMEP_IsMultiDiva)
				{
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

        // // RVA: 0xD5D1E8 Offset: 0xD5D1E8 VA: 0xD5D1E8
        private void IKABJMHIAKH_SelectCostume(int JPIDIENBGKH_CostumeId, int HEHKNMCDBJJ_ColorId, int IOPHIHFOOEP_SlotIndex)
		{
			if (IOPHIHFOOEP_SlotIndex > 4)
				return;
            UnityEngine.Debug.Log("Select costume "+JPIDIENBGKH_CostumeId+" "+HEHKNMCDBJJ_ColorId);
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
        public bool KEHGJNIGKBC_SelectValkyrie(int OIPCCBHIKIA)
		{
			if (MDNHCIKGEAE_ValkyrieList.Count <= OIPCCBHIKIA)
				return false;
			AGBLOHKHHAB_SelectedValkyrieId = DKNAIAKHHDC_Invalid;
			FBAGIDFLHHI_PrismValkyrieId = AOPLBEPHLID_DefaultValkyrieId;
            UnityEngine.Debug.Log("Select valk "+FBAGIDFLHHI_PrismValkyrieId);
			if (OIPCCBHIKIA > 0)
			{
				AGBLOHKHHAB_SelectedValkyrieId = MDNHCIKGEAE_ValkyrieList[OIPCCBHIKIA].PPFNGGCBJKC_Id;
			}
			if (AGBLOHKHHAB_SelectedValkyrieId > 0)
            {
				FBAGIDFLHHI_PrismValkyrieId = AGBLOHKHHAB_SelectedValkyrieId;
            }
			return true;
		}

        // // RVA: 0xD5D78C Offset: 0xD5D78C VA: 0xD5D78C
        public void NFMFFMDHBJO(bool PODBALIIGIK)
		{
			FBGAKINEIPG = PODBALIIGIK;
		}

        // // RVA: 0xD5D794 Offset: 0xD5D794 VA: 0xD5D794
        public void EOGMEFOFOBJ_SetValkyrieMode(bool PODBALIIGIK)
		{
			OHLCKPIMMFH_ValkyrieMode = PODBALIIGIK;
		}

        // // RVA: 0xD5D79C Offset: 0xD5D79C VA: 0xD5D79C
        public void FNMFBCGCPGP_SetDivaMode(bool PODBALIIGIK)
		{
			HGEKDNNJAAC_DivaMode = PODBALIIGIK;
		}

        // // RVA: 0xD5D7A4 Offset: 0xD5D7A4 VA: 0xD5D7A4
        public void NEJBBHHINLA_SetShowNotes(bool PODBALIIGIK)
		{
			DNLCLAOPFPF_ShowNotes = PODBALIIGIK;
		}

        // // RVA: 0xD5D7AC Offset: 0xD5D7AC VA: 0xD5D7AC
        public void LMAAILCIFLF_ApplyInSave()
        {
			if(!NAENFAFGMEP_IsMultiDiva)
			{
				OOEPMEDAJNJ_TeamSave.OCAMDLMPBGA_SelectedDivaSoloId = ENCKALOAAMB_SelectedDivaIds[0];
				OOEPMEDAJNJ_TeamSave.PGCEGEJOOON_SelectedCostumeSoloId = LGPBDFHDMNA_SelectedCostumeIds[0];
				OOEPMEDAJNJ_TeamSave.IAFIKNONLJF_SelectedCostumeColorSoloId = DJCCKIAJFGH_SelectedCostumeColorIds[0];
				OOEPMEDAJNJ_TeamSave.EPDPAHNLMKH_SelectedValkyrieSoloId = AGBLOHKHHAB_SelectedValkyrieId;
			}
			else
			{
				OOEPMEDAJNJ_TeamSave.AIPJAKIFMPN_SelectedDiva0Id = ENCKALOAAMB_SelectedDivaIds[0];
				OOEPMEDAJNJ_TeamSave.JMAGFEENOED_SelectedDiva1Id = ENCKALOAAMB_SelectedDivaIds[1];
				OOEPMEDAJNJ_TeamSave.LFHILMNKGCB_SelectedDiva2Id = ENCKALOAAMB_SelectedDivaIds[2];
				OOEPMEDAJNJ_TeamSave.OLKOJOACIBD_SelectedDiva3Id = ENCKALOAAMB_SelectedDivaIds[3];
				OOEPMEDAJNJ_TeamSave.INBGAKAAJPB_SelectedDiva4Id = ENCKALOAAMB_SelectedDivaIds[4];

				OOEPMEDAJNJ_TeamSave.FHFONPEHLMN_SelectedCostume0Id = LGPBDFHDMNA_SelectedCostumeIds[0];
				OOEPMEDAJNJ_TeamSave.HPPOFOIJJMB_SelectedCostume1Id = LGPBDFHDMNA_SelectedCostumeIds[1];
				OOEPMEDAJNJ_TeamSave.NBPNNNBCGFG_SelectedCostume2Id = LGPBDFHDMNA_SelectedCostumeIds[2];
				OOEPMEDAJNJ_TeamSave.LLKEMHHHLEN_SelectedCostume3Id = LGPBDFHDMNA_SelectedCostumeIds[3];
				OOEPMEDAJNJ_TeamSave.DGDLPGFKCFA_SelectedCostume4Id = LGPBDFHDMNA_SelectedCostumeIds[4];

				OOEPMEDAJNJ_TeamSave.ADLOGNCDIFG_SelectedCostumeColor0Id = DJCCKIAJFGH_SelectedCostumeColorIds[0];
				OOEPMEDAJNJ_TeamSave.DFHNEEBKEIC_SelectedCostumeColor1Id = DJCCKIAJFGH_SelectedCostumeColorIds[1];
				OOEPMEDAJNJ_TeamSave.BFMDCDFAJKE_SelectedCostumeColor2Id = DJCCKIAJFGH_SelectedCostumeColorIds[2];
				OOEPMEDAJNJ_TeamSave.OHCNKIKIGHM_SelectedCostumeColor3Id = DJCCKIAJFGH_SelectedCostumeColorIds[3];
				OOEPMEDAJNJ_TeamSave.HDKHGAACNFG_SelectedCostumeColor4Id = DJCCKIAJFGH_SelectedCostumeColorIds[4];

				OOEPMEDAJNJ_TeamSave.PIJEEAOMMGA_SelectedValkyrie = AGBLOHKHHAB_SelectedValkyrieId;
			}

			OOEPMEDAJNJ_TeamSave.PLALNIIBLOF_Enabled = FBGAKINEIPG ? 1 : 0;
			OOEPMEDAJNJ_TeamSave.MKKGKKHABEK_ValkyrieMode = OHLCKPIMMFH_ValkyrieMode ? 1 : 0;
			OOEPMEDAJNJ_TeamSave.JPBJOGBGKGA_DivaMode = HGEKDNNJAAC_DivaMode ? 1 : 0;
			OOEPMEDAJNJ_TeamSave.NLFMKOJHAHJ_ShowNotes = DNLCLAOPFPF_ShowNotes ? 1 : 0;
        }

        // // RVA: 0xD5AF08 Offset: 0xD5AF08 VA: 0xD5AF08
        private void ADPFDMPMILA_FindCostume(int AHHJLDLAPAN_DivaId, ref int PDEEMMEHDPK_CostumeId, ref int HEHKNMCDBJJ_ColorId)
        {
            PDEEMMEHDPK_CostumeId = 0;
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, LDEGEHAEALK_Save.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).BEEAIAAJOHD_CostumeId);
            if(a != null)
            {
                PDEEMMEHDPK_CostumeId = a.JPIDIENBGKH_CostumeId;
			}
			HEHKNMCDBJJ_ColorId = LDEGEHAEALK_Save.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).AFNIOJHODAG_CostumeColorId;
		}

        // // RVA: 0xD5B0A8 Offset: 0xD5B0A8 VA: 0xD5B0A8
        private bool HPHDLNEKPKP_IsCostumeValidForDiva(int JPIDIENBGKH_CostumeId, int AHHJLDLAPAN_DivaId)
        {
            if(JPIDIENBGKH_CostumeId > 0 && AHHJLDLAPAN_DivaId > 0)
            {
                foreach(var a in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes)
                {
                    if(a.PPEGAKEIEGM_Enabled == 2 && a.JPIDIENBGKH_CostumeId == JPIDIENBGKH_CostumeId && a.AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN_DivaId)
                        return true;
                }
            }
            return false;
        }

        // // RVA: 0xD5DE98 Offset: 0xD5DE98 VA: 0xD5DE98
        public int[] CEMKPBIBOCG(bool GIKLNODJKFK)
		{
			int[] res = new int[5];
			PEBFNABDJDI_System systemDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System;
			if(!GIKLNODJKFK)
			{
				res[0] = systemDb.LPJLEHAJADA("mv_sup_es", -1);
				res[1] = systemDb.LPJLEHAJADA("mv_sup_nm", -1);
				res[2] = systemDb.LPJLEHAJADA("mv_sup_hd", -1);
				res[3] = systemDb.LPJLEHAJADA("mv_sup_vh", -1);
				res[4] = systemDb.LPJLEHAJADA("mv_sup_ex", -1);
			}
			else
			{
				res[0] = systemDb.LPJLEHAJADA("mv_sup_es_l6", -1);
				res[1] = systemDb.LPJLEHAJADA("mv_sup_nm_l6", -1);
				res[2] = systemDb.LPJLEHAJADA("mv_sup_hd_l6", -1);
				res[3] = systemDb.LPJLEHAJADA("mv_sup_vh_l6", -1);
				res[4] = systemDb.LPJLEHAJADA("mv_sup_ex_l6", -1);
			}
			return res;
		}

        // // RVA: 0xD5E2A8 Offset: 0xD5E2A8 VA: 0xD5E2A8
        public int FGCCCMAFCNH_GetMvValkAtk()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mv_vk_atk", -1);
		}

        // // RVA: 0xD5E398 Offset: 0xD5E398 VA: 0xD5E398
        public int GPGPOBJCMFB_GetMvValkAccuracy()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("mv_vk_hit", -1);
		}

		// // RVA: 0xD5E488 Offset: 0xD5E488 VA: 0xD5E488
		public void EKACMEKEJLP(AMIECPBIALP CJODFDGPKIA, int AHHJLDLAPAN, int IOPHIHFOOEP)
		{
			if(IOPHIHFOOEP < 5)
			{
				for(int i = 0; i < CJODFDGPKIA.ENCKALOAAMB_SelectedDivaIds.Length; i++)
				{
					if(CJODFDGPKIA.ENCKALOAAMB_SelectedDivaIds[i] == AHHJLDLAPAN)
					{
						ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP] = CJODFDGPKIA.ENCKALOAAMB_SelectedDivaIds[i];
						LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP] = CJODFDGPKIA.LGPBDFHDMNA_SelectedCostumeIds[i];
						DJCCKIAJFGH_SelectedCostumeColorIds[IOPHIHFOOEP] = CJODFDGPKIA.DJCCKIAJFGH_SelectedCostumeColorIds[i];
						OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP] = CJODFDGPKIA.OMNDNNFANCK_PrismDivaIds[i];
						DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP] = CJODFDGPKIA.DLPIKHDNIIE_PrismCostumeIds[i];
						PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP] = CJODFDGPKIA.PBHPPCPKHDL_PrismCostumeColorIds[i];
						return;
					}
				}
				ENCKALOAAMB_SelectedDivaIds[IOPHIHFOOEP] = AHHJLDLAPAN;
				if(AHHJLDLAPAN == 0)
				{
					DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP] = OPICBODCKGG_None;
					PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP] = OPICBODCKGG_None;
				}
				else
				{
					LGPBDFHDMNA_SelectedCostumeIds[IOPHIHFOOEP] = DKNAIAKHHDC_Invalid;
					DJCCKIAJFGH_SelectedCostumeColorIds[IOPHIHFOOEP] = DKNAIAKHHDC_Invalid;
					ADPFDMPMILA_FindCostume(AHHJLDLAPAN, ref CLDDCHNMLLM_DefaultCostumeId, ref CCEMMCJOPIO_DefaultColorId);
					DLPIKHDNIIE_PrismCostumeIds[IOPHIHFOOEP] = CLDDCHNMLLM_DefaultCostumeId;
					PBHPPCPKHDL_PrismCostumeColorIds[IOPHIHFOOEP] = CCEMMCJOPIO_DefaultColorId;
				}
				OMNDNNFANCK_PrismDivaIds[IOPHIHFOOEP] = AHHJLDLAPAN;
			}
		}

        // // RVA: 0xD5E944 Offset: 0xD5E944 VA: 0xD5E944
        public AOJCMPIBFHD OOKAOFJBCFD()
        {
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.OOKAOFJBCFD(OOEPMEDAJNJ_TeamSave.PPFNGGCBJKC_Id, PFMHBFAKNNL_NumDiva);
        }

        // // RVA: 0xD5EA54 Offset: 0xD5EA54 VA: 0xD5EA54
        public bool CPGGFKAINHH()
        {
            AOJCMPIBFHD a = OOKAOFJBCFD();
            if(a != null)
            {
                return a.PLALNIIBLOF == 2;
            }
            return false;
        }
    }

	public const int ALHBMNBOBAE = 5;
}
