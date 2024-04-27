
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use OKLMJPBJHKL_EventMission", true)]
public class OKLMJPBJHKL { }
public class OKLMJPBJHKL_EventMission : KLFDBFMNLBL_ServerSaveBlock
{
	public class MKIGCLOBJBI
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public long AADPAJOLEEF_Crypted; // 0x10
		public long IOJOBGHPLIE_Crypted; // 0x18
		public long DLEEMCAPOBP_Crypted; // 0x20
		public long JPNMMOEPAEM_Crypted; // 0x28
		public int FOEHHBMNGNK; // 0x30
		public int DGFLFPAMNJO; // 0x34
		public int AFGHJEJKDHN_Crypted; // 0x38
		public int FBDJBMDEENG_Crypted; // 0x3C
		public sbyte MLLPMIHMMFL_Crypted; // 0x40
		public string MDADLCOCEBN_SessionId = ""; // 0x44
		public int HFIHMDILNFD_Crypted; // 0x48
		public int IGMFFIKLEHP_Crypted; // 0x4C
		public int NOOCBEMKDDG_Crypted; // 0x50
		public int HPMDPMFNAAO_Crypted; // 0x54
		public int AIONCABLDOC_Crypted; // 0x58
		public int OAACFDNGGDI_Crypted; // 0x5C
		public int HJDDHKOMADA_Crypted; // 0x60
		public int LPMDBMGPCFE_Crypted; // 0x64
		public int KEOIOOONAPE_Crypted; // 0x68
		public int MMNBJIJFOGI_Crypted; // 0x6C
		public int JEHBIJBEAMA_Crypted; // 0x70
		public int IHFLDDNELGL_Crypted; // 0x74
		public long BEBJKJKBOGH_Date; // 0x78
		public sbyte JBOCIADFMEA_Crypted; // 0x80
		public sbyte PICDFKNKFLG_Crypted; // 0x81
		public long LCBFDCAJHFG_LstBns; // 0x88
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(50); // 0x90
		public string MPCAGEPEJJJ_Key; // 0x94
		public long EGBOHDFBAPB_End; // 0x98
		public bool IMFBCJOIJKJ_Entry; // 0xA0
		public bool ABBJBPLHFHA_Spurt; // 0xA1
		public int INLNJOGHLJE_Show; // 0xA4
		public int MHKICPIMFEI_PlayCnt; // 0xA8
		public int CCABNCGIHNI_Rslt; // 0xAC
		public int PPHEALAJAKD_MiSet; // 0xB0
		public int LIEKIBHAPKC_FId; // 0xB4
		public bool KGGPBOEPKCE_PrevSel; // 0xB8
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0xBC

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } // 0x14A5914 DCHHABKOMFP 0x14A6CA8 EGGIBMLGCOJ
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } // 0x14A5998 CLGCKBAEJHF 0x14A6CD8 AHFMKDDCFAM
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } // 0x14A59AC AIBENAPCPJI 0x14A6D08 FKKHHKCJEII
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A58E4 JKHIIAEMMDE 0x14A6BC0 PFFKLBLEPKB
		public long NFIOKIBPJCJ_Uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A58FC NGIDBCKCAMO 0x14A6C44 AEHIIPBDNGE
		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_Crypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_Crypted = value ^ ENOBDCFHELD; FBDJBMDEENG_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5928 MAFBDLKFHGJ 0x14A6C6C EPEFBOIALDI
		public int NKCCNNNJGJF_SelCard { get { return NOOCBEMKDDG_Crypted ^ ENOBDCFHELD; } set { NOOCBEMKDDG_Crypted = value ^ ENOBDCFHELD; HPMDPMFNAAO_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5938 AOMJCKPMOAI 0x14A6C80 KLMJNGAGDHO
		public int PFKHDMGPGKL_SelDf { get { return AIONCABLDOC_Crypted ^ ENOBDCFHELD; } set { AIONCABLDOC_Crypted = value ^ ENOBDCFHELD; OAACFDNGGDI_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5948 BKNGCMPPAAI 0x14A6C94 CIGDNLKIFEM
		public int POENMEGPHCG_Reset { get { return HJDDHKOMADA_Crypted ^ ENOBDCFHELD; } set { HJDDHKOMADA_Crypted = value ^ ENOBDCFHELD; LPMDBMGPCFE_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5958 NBIINAFIJEN 0x14A6D38 FKNEOBLFDIM
		public int JNAHAJFKKCB_EpiCnt { get { return JEHBIJBEAMA_Crypted ^ ENOBDCFHELD; } set { JEHBIJBEAMA_Crypted = value ^ ENOBDCFHELD; IHFLDDNELGL_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5968 DHIOKCLDFIE 0x14A6D4C AMKBAJJLMGF
		public int NBNFHHLCMDH_EpiBo { get { return KEOIOOONAPE_Crypted ^ ENOBDCFHELD; } set { KEOIOOONAPE_Crypted = value ^ ENOBDCFHELD; MMNBJIJFOGI_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5978 LJGJCGBMGPN 0x14A6D60 CBEODBCPDOJ
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } // 0x14A5988 PBEMPHPDDDB 0x14A6D74 MCADMIEOCCF

		// // RVA: 0x14ACA70 Offset: 0x14ACA70 VA: 0x14ACA70
		public bool BHIAKGKHKGD(int BMBBDIAEOMP)
		{
			return LCDIGDMGPGO_TRcv[BMBBDIAEOMP] != 20;
		}

		// // RVA: 0x14AC9DC Offset: 0x14AC9DC VA: 0x14AC9DC
		public void IPNLHCLFIDB(int BMBBDIAEOMP, bool JKDJCFEBDHC)
		{
			LCDIGDMGPGO_TRcv[BMBBDIAEOMP] = (sbyte)(JKDJCFEBDHC ? 40 : 20);
		}

		// // RVA: 0x14A4560 Offset: 0x14A4560 VA: 0x14A4560
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_End = 0;
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			OKEJGGCMAAI_PlaRcv = false;
			HPLMECLKFID_RRcv = false;
			LCBFDCAJHFG_LstBns = 0;
			CGMMMJCIDFE_EpaRcv = false;
			INLNJOGHLJE_Show = 0;
			LGADCGFMLLD_Step = 0;
			OMCAOJJGOGG_Lb = 0;
			NKCCNNNJGJF_SelCard = 0;
			PFKHDMGPGKL_SelDf = 0;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_Uptime = 0;
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv.Add(20);
			}
			NNMPGOAGEOL_Quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			POENMEGPHCG_Reset = 0;
			NBNFHHLCMDH_EpiBo = 0;
			JNAHAJFKKCB_EpiCnt = 0;
			BEBJKJKBOGH_Date = 0;
			MHKICPIMFEI_PlayCnt = 0;
			CCABNCGIHNI_Rslt = 0;
			PPHEALAJAKD_MiSet = 0;
			LIEKIBHAPKC_FId = 0;
			MDADLCOCEBN_SessionId = "";
			KGGPBOEPKCE_PrevSel = false;
		}

		// // RVA: 0x14A6F58 Offset: 0x14A6F58 VA: 0x14A6F58
		public void ODDIHGPONFL(MKIGCLOBJBI GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			LCBFDCAJHFG_LstBns = GPBJHKLFCEP.LCBFDCAJHFG_LstBns;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			NKCCNNNJGJF_SelCard = GPBJHKLFCEP.NKCCNNNJGJF_SelCard;
			PFKHDMGPGKL_SelDf = GPBJHKLFCEP.PFKHDMGPGKL_SelDf;
			POENMEGPHCG_Reset = GPBJHKLFCEP.POENMEGPHCG_Reset;
			JNAHAJFKKCB_EpiCnt = GPBJHKLFCEP.JNAHAJFKKCB_EpiCnt;
			NBNFHHLCMDH_EpiBo = GPBJHKLFCEP.NBNFHHLCMDH_EpiBo;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			NFIOKIBPJCJ_Uptime = GPBJHKLFCEP.NFIOKIBPJCJ_Uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			MDADLCOCEBN_SessionId = GPBJHKLFCEP.MDADLCOCEBN_SessionId;
			CCABNCGIHNI_Rslt = GPBJHKLFCEP.CCABNCGIHNI_Rslt;
			PPHEALAJAKD_MiSet = GPBJHKLFCEP.PPHEALAJAKD_MiSet;
			LIEKIBHAPKC_FId = GPBJHKLFCEP.LIEKIBHAPKC_FId;
			KGGPBOEPKCE_PrevSel = GPBJHKLFCEP.KGGPBOEPKCE_PrevSel;
			MHKICPIMFEI_PlayCnt = GPBJHKLFCEP.MHKICPIMFEI_PlayCnt;
		}

		// // RVA: 0x14A7670 Offset: 0x14A7670 VA: 0x14A7670
		public bool AGBOGBEOFME(MKIGCLOBJBI OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(OKEJGGCMAAI_PlaRcv != OIKJFMGEICL.OKEJGGCMAAI_PlaRcv)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(CGMMMJCIDFE_EpaRcv != OIKJFMGEICL.CGMMMJCIDFE_EpaRcv)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(LCBFDCAJHFG_LstBns != OIKJFMGEICL.LCBFDCAJHFG_LstBns)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			if(KGGPBOEPKCE_PrevSel != OIKJFMGEICL.KGGPBOEPKCE_PrevSel)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step)
				return false;
			if(NKCCNNNJGJF_SelCard != OIKJFMGEICL.NKCCNNNJGJF_SelCard)
				return false;
			if(PFKHDMGPGKL_SelDf != OIKJFMGEICL.PFKHDMGPGKL_SelDf)
				return false;
			if(POENMEGPHCG_Reset != OIKJFMGEICL.POENMEGPHCG_Reset)
				return false;
			if(JNAHAJFKKCB_EpiCnt != OIKJFMGEICL.JNAHAJFKKCB_EpiCnt)
				return false;
			if(NBNFHHLCMDH_EpiBo != OIKJFMGEICL.NBNFHHLCMDH_EpiBo)
				return false;
			if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
				return false;
			if(NFIOKIBPJCJ_Uptime != OIKJFMGEICL.NFIOKIBPJCJ_Uptime)
				return false;
			if(CCABNCGIHNI_Rslt != OIKJFMGEICL.CCABNCGIHNI_Rslt)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(PPHEALAJAKD_MiSet != OIKJFMGEICL.PPHEALAJAKD_MiSet)
				return false;
			if(LIEKIBHAPKC_FId != OIKJFMGEICL.LIEKIBHAPKC_FId)
				return false;
			if(MHKICPIMFEI_PlayCnt != OIKJFMGEICL.MHKICPIMFEI_PlayCnt)
				return false;
			if(MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			for(int i = 0; i < 100; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0x14A80BC Offset: 0x14A80BC VA: 0x14A80BC
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OKLMJPBJHKL.MKIGCLOBJBI OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int BJEPEBMLKOL = 50;
	public const int AJCLDHGLJPD = 3;
	public const int DDCDBOAAOAE = 15;
	public const long EGHFCEBIGEE = 99999999;
	public const int KKBHHBGCNJO = 5;
	public const int DOONPLKIOGD = 10;
	public List<MKIGCLOBJBI> FBCJICEPLED = new List<MKIGCLOBJBI>(3); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0x14AC994 NFKFOODCJJB

	// // RVA: 0x14A4304 Offset: 0x14A4304 VA: 0x14A4304
	public OKLMJPBJHKL_EventMission()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x14A43A0 Offset: 0x14A43A0 VA: 0x14A43A0 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			MKIGCLOBJBI data = new MKIGCLOBJBI();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x14A485C Offset: 0x14A485C VA: 0x14A485C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
            MKIGCLOBJBI d = FBCJICEPLED[i];
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < d.LCDIGDMGPGO_TRcv.Count; j++)
			{
				data2.Add(d.BHIAKGKHKGD(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data3.Add(d.NNMPGOAGEOL_Quests[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = d.MPCAGEPEJJJ_Key;
			data4[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = d.EGBOHDFBAPB_End;
			data4[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = d.IMFBCJOIJKJ_Entry ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = d.ABBJBPLHFHA_Spurt ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = d.DNBFMLBNAEE_Point;
			data4[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = d.NFIOKIBPJCJ_Uptime;
			data4[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = d.HPLMECLKFID_RRcv ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data2;
			data4[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = d.LGADCGFMLLD_Step;
			data4[AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card] = d.NKCCNNNJGJF_SelCard;
			data4[AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df] = d.PFKHDMGPGKL_SelDf;
			data4[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data3;
			data4[AFEHLCGHAEE_Strings.POENMEGPHCG_reset] = d.POENMEGPHCG_Reset;
			data4["epi_cnt"] = d.JNAHAJFKKCB_EpiCnt;
			data4["epi_bo"] = d.NBNFHHLCMDH_EpiBo;
			data4[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = d.BEBJKJKBOGH_Date;
			data4["show"] = d.INLNJOGHLJE_Show;
			data4[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = d.MDADLCOCEBN_SessionId;
			data4["rslt"] = d.CCABNCGIHNI_Rslt;
			data4["lb"] = d.OMCAOJJGOGG_Lb;
			data4["f_id"] = d.LIEKIBHAPKC_FId;
			data4["mi_set"] = d.PPHEALAJAKD_MiSet;
			data4["prev_sel"] = d.KGGPBOEPKCE_PrevSel ? 1 : 0;
			data4["play_cnt"] = d.MHKICPIMFEI_PlayCnt;
			data4["pla_rcv"] = d.OKEJGGCMAAI_PlaRcv ? 1 : 0;
			data4["epa_rcv"] = d.CGMMMJCIDFE_EpaRcv ? 1 : 0;
			data4["lst_bns"] = d.LCBFDCAJHFG_LstBns;
			data.Add(data4);
        }
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x14A59C0 Offset: 0x14A59C0 VA: 0x14A59C0 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if(block.HNBFOAJIIAL_Count > 0)
				{
					int cnt = block.HNBFOAJIIAL_Count;
					if(cnt >= 4)
					{
						isInvalid = true;
						cnt = 3;
					}
					for(int i = 0; i < cnt; i++)
					{
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_Point = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_Uptime = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].LGADCGFMLLD_Step = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						FBCJICEPLED[i].NKCCNNNJGJF_SelCard = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card, 0, ref isInvalid);
						FBCJICEPLED[i].PFKHDMGPGKL_SelDf = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df, 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_ReadInt(block[i], "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_ReadInt(block[i], "epa_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].LCBFDCAJHFG_LstBns = DKMPHAPBDLH_ReadLong(block[i], "lst_bns", 0, ref isInvalid);
						FBCJICEPLED[i].POENMEGPHCG_Reset = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.POENMEGPHCG_reset, 0, ref isInvalid);
						FBCJICEPLED[i].JNAHAJFKKCB_EpiCnt = CJAENOMGPDA_ReadInt(block[i], "epi_cnt", 0, ref isInvalid);
						FBCJICEPLED[i].NBNFHHLCMDH_EpiBo = CJAENOMGPDA_ReadInt(block[i], "epi_bo", 0, ref isInvalid);
						FBCJICEPLED[i].BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].CCABNCGIHNI_Rslt = CJAENOMGPDA_ReadInt(block[i], "rslt", 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(block[i], "lb", 0, ref isInvalid);
						FBCJICEPLED[i].LIEKIBHAPKC_FId = CJAENOMGPDA_ReadInt(block[i], "f_id", 0, ref isInvalid);
						FBCJICEPLED[i].PPHEALAJAKD_MiSet = CJAENOMGPDA_ReadInt(block[i], "mi_set", 0, ref isInvalid);
						FBCJICEPLED[i].KGGPBOEPKCE_PrevSel = CJAENOMGPDA_ReadInt(block[i], "prev_sel", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].MHKICPIMFEI_PlayCnt = CJAENOMGPDA_ReadInt(block[i], "play_cnt", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14AC99C
							FBCJICEPLED[i].IPNLHCLFIDB(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData d = block[i][AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt2 = d.HNBFOAJIIAL_Count;
							if(cnt2 > 50)
								cnt2 = 50;
							for(int j = 0; j < cnt; j++)
							{
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(d[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x14A6D88 Offset: 0x14A6D88 VA: 0x14A6D88 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OKLMJPBJHKL_EventMission other = GPBJHKLFCEP as OKLMJPBJHKL_EventMission;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x14A7490 Offset: 0x14A7490 VA: 0x14A7490 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OKLMJPBJHKL_EventMission other = GPBJHKLFCEP as OKLMJPBJHKL_EventMission;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x14A7CB0 Offset: 0x14A7CB0 VA: 0x14A7CB0 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x14AC718 Offset: 0x14AC718 VA: 0x14AC718 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
