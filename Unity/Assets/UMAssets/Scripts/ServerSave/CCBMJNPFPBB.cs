
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use CCBMJNPFPBB_EventGoDiva", true)]
public class CCBMJNPFPBB { }
public class CCBMJNPFPBB_EventGoDiva : KLFDBFMNLBL_ServerSaveBlock
{
	public class CAJKNNAEIPI
	{
		private int FBGGEFFJJHB; // 0x8
		private int PLBBECDLENA_Crypted; // 0xC
		private int NODFMDPDNJB_Crypted; // 0x10
		private int AGFFNJFJEOG_Crypted; // 0x14
		private int NICJPKNAKKN_Crypted; // 0x18
		private int IBMBLPOFBBB_Crypted; // 0x1C
		private int FIJFCNKHBAK_Crypted; // 0x20
		private int LGHEIJGKFDB_Crypted; // 0x24
		private int JFJPENFHPNJ_Crypted; // 0x28
		private int LBAAEBGKHPE_Crypted; // 0x2C
		private int LHIHGKAPKDN_Crypted; // 0x30
		private int ENCPNANJGHD_Crypted; // 0x34
		private int CNIAECGOPMK_Crypted; // 0x38
		private int BBHEKIAJMBL_Crypted; // 0x3C
		private int DPGCPCMNJLB_Crypted; // 0x40
		private int DFEFCOBCMCB_Crypted; // 0x44
		private int IAIIMDFOPOL_Crypted; // 0x48
		private int NPGOJLNHBIG_Crypted; // 0x4C
		private int IGAADAHAFEP_Crypted; // 0x50

		public int KKGPPDLFDKA_SoLv { get { return PLBBECDLENA_Crypted ^ FBGGEFFJJHB; } set { PLBBECDLENA_Crypted = value ^ FBGGEFFJJHB; NODFMDPDNJB_Crypted = value; } } //0x1907204 IAAHLBMJIKE 0x19016C4 GKOMOPECNLC
		public int DMDLAIOJKPM_SoExp { get { return AGFFNJFJEOG_Crypted ^ FBGGEFFJJHB; } set { AGFFNJFJEOG_Crypted = value ^ FBGGEFFJJHB; NICJPKNAKKN_Crypted = value; } } //0x1907214 BHBPDMPBDNE 0x19016D8 HGNHINHJODJ
		public int JDHJEINPJLL_SoMExp { get { return IBMBLPOFBBB_Crypted ^ FBGGEFFJJHB; } set { IBMBLPOFBBB_Crypted = value ^ FBGGEFFJJHB; FIJFCNKHBAK_Crypted = value; } } //0x1907224 NHJHIMPFHKG 0x19016EC MPGJFJCNOJI
		public int IDIDIJGPPIO_VoLv { get { return LGHEIJGKFDB_Crypted ^ FBGGEFFJJHB; } set { LGHEIJGKFDB_Crypted = value ^ FBGGEFFJJHB; JFJPENFHPNJ_Crypted = value; } } //0x1907234 CJDKBLMLELB 0x1901700 LJLCMJLLOCA
		public int GNBEKAELDMM_VoExp { get { return LBAAEBGKHPE_Crypted ^ FBGGEFFJJHB; } set { LBAAEBGKHPE_Crypted = value ^ FBGGEFFJJHB; LHIHGKAPKDN_Crypted = value; } } //0x1907244 CFMCJHBBMFH 0x1901714 OCOHFADLOHF
		public int OIMLBHPAMGD_VoMExp { get { return ENCPNANJGHD_Crypted ^ FBGGEFFJJHB; } set { ENCPNANJGHD_Crypted = value ^ FBGGEFFJJHB; CNIAECGOPMK_Crypted = value; } } //0x1907254 JLGGALLPMID 0x1901728 GJMCHHMBACC
		public int OMOIGFMNFJB_ChLv { get { return BBHEKIAJMBL_Crypted ^ FBGGEFFJJHB; } set { BBHEKIAJMBL_Crypted = value ^ FBGGEFFJJHB; DPGCPCMNJLB_Crypted = value; } } //0x1907264 JKKNKLNMOCD 0x190173C NBNFPNCJDPN
		public int BCANABIAIIP_ChExp { get { return DFEFCOBCMCB_Crypted ^ FBGGEFFJJHB; } set { DFEFCOBCMCB_Crypted = value ^ FBGGEFFJJHB; IAIIMDFOPOL_Crypted = value; } } //0x1907274 DHMEJNEFEHO 0x1901750 KBPDDCGHIKD
		public int PFDDNKEOKBF_ChMExp { get { return NPGOJLNHBIG_Crypted ^ FBGGEFFJJHB; } set { NPGOJLNHBIG_Crypted = value ^ FBGGEFFJJHB; IGAADAHAFEP_Crypted = value; } } //0x1907284 KBNOJNALELL 0x1901764 GCFLNKDPFGL

		// // RVA: 0x1907294 Offset: 0x1907294 VA: 0x1907294
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			KKGPPDLFDKA_SoLv = 0;
			DMDLAIOJKPM_SoExp = 0;
			JDHJEINPJLL_SoMExp = 0;
			IDIDIJGPPIO_VoLv = 0;
			GNBEKAELDMM_VoExp = 0;
			OIMLBHPAMGD_VoMExp = 0;
			OMOIGFMNFJB_ChLv = 0;
			BCANABIAIIP_ChExp = 0;
			PFDDNKEOKBF_ChMExp = 0;
		}

		// // RVA: 0x19072E8 Offset: 0x19072E8 VA: 0x19072E8
		public bool AGBOGBEOFME(CAJKNNAEIPI OIKJFMGEICL)
		{
			if(KKGPPDLFDKA_SoLv != OIKJFMGEICL.KKGPPDLFDKA_SoLv)
				return false;
			if(DMDLAIOJKPM_SoExp != OIKJFMGEICL.DMDLAIOJKPM_SoExp)
				return false;
			if(JDHJEINPJLL_SoMExp != OIKJFMGEICL.JDHJEINPJLL_SoMExp)
				return false;
			if(IDIDIJGPPIO_VoLv != OIKJFMGEICL.IDIDIJGPPIO_VoLv)
				return false;
			if(GNBEKAELDMM_VoExp != OIKJFMGEICL.GNBEKAELDMM_VoExp)
				return false;
			if(OIMLBHPAMGD_VoMExp != OIKJFMGEICL.OIMLBHPAMGD_VoMExp)
				return false;
			if(OMOIGFMNFJB_ChLv != OIKJFMGEICL.OMOIGFMNFJB_ChLv)
				return false;
			if(BCANABIAIIP_ChExp != OIKJFMGEICL.BCANABIAIIP_ChExp)
				return false;
			if(PFDDNKEOKBF_ChMExp != OIKJFMGEICL.PFDDNKEOKBF_ChMExp)
				return false;
			return true;
		}

		// // RVA: 0x190760C Offset: 0x190760C VA: 0x190760C
		public void ODDIHGPONFL(CAJKNNAEIPI OIKJFMGEICL)
		{
			KKGPPDLFDKA_SoLv = OIKJFMGEICL.KKGPPDLFDKA_SoLv;
			DMDLAIOJKPM_SoExp = OIKJFMGEICL.DMDLAIOJKPM_SoExp;
			JDHJEINPJLL_SoMExp = OIKJFMGEICL.JDHJEINPJLL_SoMExp;
			IDIDIJGPPIO_VoLv = OIKJFMGEICL.IDIDIJGPPIO_VoLv;
			GNBEKAELDMM_VoExp = OIKJFMGEICL.GNBEKAELDMM_VoExp;
			OIMLBHPAMGD_VoMExp = OIKJFMGEICL.OIMLBHPAMGD_VoMExp;
			OMOIGFMNFJB_ChLv = OIKJFMGEICL.OMOIGFMNFJB_ChLv;
			BCANABIAIIP_ChExp = OIKJFMGEICL.BCANABIAIIP_ChExp;
			PFDDNKEOKBF_ChMExp = OIKJFMGEICL.PFDDNKEOKBF_ChMExp;
		}

		// // RVA: 0x190780C Offset: 0x190780C VA: 0x190780C
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, CCBMJNPFPBB.CAJKNNAEIPI OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		// // RVA: 0x18FF69C Offset: 0x18FF69C VA: 0x18FF69C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.KKGPPDLFDKA_so_lv] = KKGPPDLFDKA_SoLv;
			res[AFEHLCGHAEE_Strings.DMDLAIOJKPM_so_exp] = DMDLAIOJKPM_SoExp;
			res[AFEHLCGHAEE_Strings.JDHJEINPJLL_so_mexp] = JDHJEINPJLL_SoMExp;
			res[AFEHLCGHAEE_Strings.IDIDIJGPPIO_vo_lv] = IDIDIJGPPIO_VoLv;
			res[AFEHLCGHAEE_Strings.GNBEKAELDMM_vo_exp] = GNBEKAELDMM_VoExp;
			res[AFEHLCGHAEE_Strings.OIMLBHPAMGD_vo_mexp] = OIMLBHPAMGD_VoMExp;
			res[AFEHLCGHAEE_Strings.OMOIGFMNFJB_ch_lv] = OMOIGFMNFJB_ChLv;
			res[AFEHLCGHAEE_Strings.BCANABIAIIP_ch_exp] = BCANABIAIIP_ChExp;
			res[AFEHLCGHAEE_Strings.PFDDNKEOKBF_ch_mexp] = PFDDNKEOKBF_ChMExp;
			return res;
		}
	}

	public class KIJJHJHLBAK
	{
		private int ENOBDCFHELD; // 0x8
		private int FCEJCHGLFGN; // 0xC
		public string MPCAGEPEJJJ_Key; // 0x10
		public long EGBOHDFBAPB_End; // 0x18
		public bool IMFBCJOIJKJ_Entry; // 0x20
		public bool ABBJBPLHFHA_Spurt; // 0x21
		public int INLNJOGHLJE_Show; // 0x24
		public int AFKMGCLEPGA_SelDiva; // 0x28
		public int LEPHEGEHHOD_SelFId; // 0x2C
		public List<CAJKNNAEIPI> FDBOPFEOENF_Divas = new List<CAJKNNAEIPI>(10); // 0x30
		public List<MIDMMFMJFPJ> LGFFMGDBIAH_Rankings = new List<MIDMMFMJFPJ>(10); // 0x34
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(10); // 0x38
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0x3C
		private int AADPAJOLEEF_Crypted; // 0x40
		private int IOJOBGHPLIE_Crypted; // 0x44
		private int CHGFBPOFICJ_Crypted; // 0x48
		private int BGNIPKEKKMK_Crypted; // 0x4C
		private int MEPLFFACONB_Crypted; // 0x50
		private int AEMACOJDCGK_Crypted; // 0x54
		private int PGDECJMHKGH_Crypted; // 0x58
		private int OFNEPGGPEPI_Crypted; // 0x5C
		private long DMBIIFIONCH_Crypted; // 0x60
		private long GOFAELEBNJD_Crypted; // 0x68
		private long DLEEMCAPOBP_Crypted; // 0x70
		private long JPNMMOEPAEM_Crypted; // 0x78
		private int HFIHMDILNFD_Crypted; // 0x80
		private int IGMFFIKLEHP_Crypted; // 0x84
		private int GPCKFEPLFFB_Crypted; // 0x88
		private int CNDLHDIJLIP_Crypted; // 0x8C
		private int BEJKFPEOPBJ_Crypted; // 0x90
		private int CHKEHHAKBFH_Crypted; // 0x94
		private int JGOPFCJEGMM_Crypted; // 0x98
		private int COKIDJLMPON_Crypted; // 0x9C
		private sbyte JBOCIADFMEA_Crypted; // 0xA0
		private sbyte PICDFKNKFLG_Crypted; // 0xA1

		public int DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = Mathf.Clamp(value, 0, 100000000); AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA7C JKHIIAEMMDE 0x1901480 PFFKLBLEPKB
		public int ADKDHKMPMHP_Rate { get { return CHGFBPOFICJ_Crypted ^ ENOBDCFHELD; } set { CHGFBPOFICJ_Crypted = value ^ ENOBDCFHELD; BGNIPKEKKMK_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA8C KCLKBHDMAFH 0x1901524 GOLECEILPOI
		public int GJPHOIBCEFL_ItemTicketCnt { get { return MEPLFFACONB_Crypted ^ ENOBDCFHELD; } set { value = Mathf.Clamp(value, 0, 10000); MEPLFFACONB_Crypted = value ^ ENOBDCFHELD; AEMACOJDCGK_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA9C NHPHHCAJHJM 0x1901538 DDCBIBDONGA
		public int NNCFCPEOODE_UseCnt { get { return PGDECJMHKGH_Crypted ^ ENOBDCFHELD; } set { PGDECJMHKGH_Crypted = value ^ ENOBDCFHELD; OFNEPGGPEPI_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAAC MJLFJHMJJHF 0x19015D8 GLGKFAHAHEG
		public long CNJCFCNLAMO_UseTime { get { return DMBIIFIONCH_Crypted ^ ENOBDCFHELD; } set { DMBIIFIONCH_Crypted = value ^ ENOBDCFHELD; GOFAELEBNJD_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFABC CLNBPMIBAIF 0x19015EC KMBEPOGBMLJ
		public long NFIOKIBPJCJ_Uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAD4 NGIDBCKCAMO 0x1901614 AEHIIPBDNGE
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAEC PBEMPHPDDDB 0x190163C MCADMIEOCCF
		public int KAPGPAMOKDD_Bns1 { get { return GPCKFEPLFFB_Crypted ^ ENOBDCFHELD; } set { GPCKFEPLFFB_Crypted = value ^ ENOBDCFHELD; CNDLHDIJLIP_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA5C GFLGNPEDCNM 0x1907108 BLFINOKAGDB
		public int JHKKAKJCJOF_Bns2 { get { return BEJKFPEOPBJ_Crypted ^ ENOBDCFHELD; } set { BEJKFPEOPBJ_Crypted = value ^ ENOBDCFHELD; CHKEHHAKBFH_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA6C MOLMAHDDPBI 0x190711C MLKEHKPBBNJ
		public int PFPGHILKGIG_BnsCnt { get { return JGOPFCJEGMM_Crypted ^ ENOBDCFHELD; } set { JGOPFCJEGMM_Crypted = value ^ ENOBDCFHELD; COKIDJLMPON_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAFC IJOGKMOAOOB 0x1901650 EBGNDBHKFHF
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } //0x18FFB0C CLGCKBAEJHF 0x1901664 AHFMKDDCFAM
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } //0x18FFB20 AIBENAPCPJI 0x1901694 FKKHHKCJEII

		// // RVA: 0x1908E18 Offset: 0x1908E18 VA: 0x1908E18
		public bool DGOAGKOKCIJ_IsRewardReceived(int LHJCOPMMIGO)
		{
			return LGFFMGDBIAH_Rankings[LHJCOPMMIGO].CKFKFHKHOHA_RRcv;
		}

		// // RVA: 0x1908EB8 Offset: 0x1908EB8 VA: 0x1908EB8
		public void LHAEPPFACOB_SetRawardReceived(int LHJCOPMMIGO, bool OAFPGJLCNFM)
		{
			LGFFMGDBIAH_Rankings[LHJCOPMMIGO].CKFKFHKHOHA_RRcv = OAFPGJLCNFM;
		}

		// // RVA: 0x1908F60 Offset: 0x1908F60 VA: 0x1908F60
		public bool BHIAKGKHKGD_IsRewardReceived(int BMBBDIAEOMP)
		{
			return LCDIGDMGPGO_TRcv[BMBBDIAEOMP] != 20;
		}

		// // RVA: 0x1907170 Offset: 0x1907170 VA: 0x1907170
		public void IPNLHCLFIDB_SetRewardReceived(int BMBBDIAEOMP, bool JKDJCFEBDHC)
		{
			LCDIGDMGPGO_TRcv[BMBBDIAEOMP] = (sbyte)(JKDJCFEBDHC ? 40 : 20);
		}

		// // RVA: 0x1908FF0 Offset: 0x1908FF0 VA: 0x1908FF0
		public bool HHAGNMOIENH(int JDPGHNKKGNE, long EOLFJGMAJAB)
		{
			if(JDPGHNKKGNE <= GJPHOIBCEFL_ItemTicketCnt && NNCFCPEOODE_UseCnt - JDPGHNKKGNE > -1)
			{
				GJPHOIBCEFL_ItemTicketCnt -= JDPGHNKKGNE;
				CNJCFCNLAMO_UseTime = EOLFJGMAJAB;
				NNCFCPEOODE_UseCnt -= JDPGHNKKGNE;
				return true;
			}
			return false;
		}

		// // RVA: 0x18FE0D8 Offset: 0x18FE0D8 VA: 0x18FE0D8
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_End = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			DNBFMLBNAEE_Point = 0;
			ADKDHKMPMHP_Rate = 0;
			GJPHOIBCEFL_ItemTicketCnt = 0;
			INLNJOGHLJE_Show = 0;
			AFKMGCLEPGA_SelDiva = 0;
			LEPHEGEHHOD_SelFId = 0;
			PFPGHILKGIG_BnsCnt = 0;
			NNCFCPEOODE_UseCnt = 0;
			CNJCFCNLAMO_UseTime = 0;
			NFIOKIBPJCJ_Uptime = 0;
			OMCAOJJGOGG_Lb = 0;
			KAPGPAMOKDD_Bns1 = 0;
			JHKKAKJCJOF_Bns2 = 0;
			OKEJGGCMAAI_PlaRcv = false;
			CGMMMJCIDFE_EpaRcv = false;
			FDBOPFEOENF_Divas.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 10; i++)
			{
				CAJKNNAEIPI data = new CAJKNNAEIPI();
				data.LHPDDGIJKNB(k);
				FDBOPFEOENF_Divas.Add(data);
				k *= 13;
			}
			LGFFMGDBIAH_Rankings.Clear();
			k = ENOBDCFHELD + 5;
			for(int i = 0; i < 10; i++)
			{
				MIDMMFMJFPJ data = new MIDMMFMJFPJ();
				data.LHPDDGIJKNB(k);
				LGFFMGDBIAH_Rankings.Add(data);
				k *= 13;
			}
			NNMPGOAGEOL_Quests.Clear();
			k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv.Add(20);
			}
		}

		// // RVA: 0x1901960 Offset: 0x1901960 VA: 0x1901960
		public void ODDIHGPONFL(KIJJHJHLBAK GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			ADKDHKMPMHP_Rate = GPBJHKLFCEP.ADKDHKMPMHP_Rate;
			GJPHOIBCEFL_ItemTicketCnt = GPBJHKLFCEP.GJPHOIBCEFL_ItemTicketCnt;
			NNCFCPEOODE_UseCnt = GPBJHKLFCEP.NNCFCPEOODE_UseCnt;
			CNJCFCNLAMO_UseTime = GPBJHKLFCEP.CNJCFCNLAMO_UseTime;
			NFIOKIBPJCJ_Uptime = GPBJHKLFCEP.NFIOKIBPJCJ_Uptime;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			KAPGPAMOKDD_Bns1 = GPBJHKLFCEP.KAPGPAMOKDD_Bns1;
			JHKKAKJCJOF_Bns2 = GPBJHKLFCEP.JHKKAKJCJOF_Bns2;
			PFPGHILKGIG_BnsCnt = GPBJHKLFCEP.PFPGHILKGIG_BnsCnt;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			AFKMGCLEPGA_SelDiva = GPBJHKLFCEP.AFKMGCLEPGA_SelDiva;
			LEPHEGEHHOD_SelFId = GPBJHKLFCEP.LEPHEGEHHOD_SelFId;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			for(int i = 0; i < 10; i++)
			{
				FDBOPFEOENF_Divas[i].ODDIHGPONFL(GPBJHKLFCEP.FDBOPFEOENF_Divas[i]);
			}
			for(int i = 0; i < 10; i++)
			{
				LGFFMGDBIAH_Rankings[i].ODDIHGPONFL(GPBJHKLFCEP.LGFFMGDBIAH_Rankings[i]);
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
		}

		// // RVA: 0x190211C Offset: 0x190211C VA: 0x190211C
		public bool AGBOGBEOFME(KIJJHJHLBAK OIKJFMGEICL)
		{
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(ADKDHKMPMHP_Rate != OIKJFMGEICL.ADKDHKMPMHP_Rate)
				return false;
			if(GJPHOIBCEFL_ItemTicketCnt != OIKJFMGEICL.GJPHOIBCEFL_ItemTicketCnt)
				return false;
			if(NFIOKIBPJCJ_Uptime != OIKJFMGEICL.NFIOKIBPJCJ_Uptime)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(PFPGHILKGIG_BnsCnt != OIKJFMGEICL.PFPGHILKGIG_BnsCnt)
				return false;
			if(JHKKAKJCJOF_Bns2 != OIKJFMGEICL.JHKKAKJCJOF_Bns2)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(AFKMGCLEPGA_SelDiva != OIKJFMGEICL.AFKMGCLEPGA_SelDiva)
				return false;
			if(LEPHEGEHHOD_SelFId != OIKJFMGEICL.LEPHEGEHHOD_SelFId)
				return false;
			if(KAPGPAMOKDD_Bns1 != OIKJFMGEICL.KAPGPAMOKDD_Bns1)
				return false;
			if(OKEJGGCMAAI_PlaRcv != OIKJFMGEICL.OKEJGGCMAAI_PlaRcv)
				return false;
			if(CGMMMJCIDFE_EpaRcv != OIKJFMGEICL.CGMMMJCIDFE_EpaRcv)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			for(int i = 0; i < 10; i++)
			{
				if(!FDBOPFEOENF_Divas[i].AGBOGBEOFME(OIKJFMGEICL.FDBOPFEOENF_Divas[i]))
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(!LGFFMGDBIAH_Rankings[i].AGBOGBEOFME(OIKJFMGEICL.LGFFMGDBIAH_Rankings[i]))
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1902E54 Offset: 0x1902E54 VA: 0x1902E54
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, CCBMJNPFPBB.KIJJHJHLBAK OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		// // RVA: 0x1906D84 Offset: 0x1906D84 VA: 0x1906D84
		// public FENCAJJBLBH PFAKPFKJJKA() { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int GKFIGBGDALK = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int LBBLNLCFIOH = 10;
	public const int NGIMNMPLBGA = 10;
	public const int BJEPEBMLKOL = 50;
	public const int EGHFCEBIGEE = 99999999;
	public const int NLFBJHLNKGJ = 9999;
	public long AFNJCFEKFDD_Dirty; // 0x28
	public List<KIJJHJHLBAK> FBCJICEPLED = new List<KIJJHJHLBAK>(); // 0x30

	public override bool DMICHEJIAJL { get { return true; } } // 0x1907094 NFKFOODCJJB

	// // RVA: 0x18FDE14 Offset: 0x18FDE14 VA: 0x18FDE14
	public CCBMJNPFPBB_EventGoDiva()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x18FDEB0 Offset: 0x18FDEB0 VA: 0x18FDEB0 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			KIJJHJHLBAK data = new KIJJHJHLBAK();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
		AFNJCFEKFDD_Dirty = 0;
	}

	// // RVA: 0x18FE540 Offset: 0x18FE540 VA: 0x18FE540 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data2.Add(FBCJICEPLED[i].FDBOPFEOENF_Divas[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data3.Add(FBCJICEPLED[i].LGFFMGDBIAH_Rankings[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data4.Add(FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data5.Add(FBCJICEPLED[i].BHIAKGKHKGD_IsRewardReceived(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data6.Add(FBCJICEPLED[i].KAPGPAMOKDD_Bns1);
			data6.Add(FBCJICEPLED[i].JHKKAKJCJOF_Bns2);
			EDOHBJAPLPF_JsonData data7 = new EDOHBJAPLPF_JsonData();
			data7[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data7[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data7[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data7[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data7[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_Point;
			data7[AFEHLCGHAEE_Strings.ADKDHKMPMHP_rate] = FBCJICEPLED[i].ADKDHKMPMHP_Rate;
			data7[AFEHLCGHAEE_Strings.COCEIPAKJKF_item] = FBCJICEPLED[i].GJPHOIBCEFL_ItemTicketCnt;
			data7[AFEHLCGHAEE_Strings.NNCFCPEOODE_usecnt] = FBCJICEPLED[i].NNCFCPEOODE_UseCnt;
			data7[AFEHLCGHAEE_Strings.CNJCFCNLAMO_usetime] = FBCJICEPLED[i].CNJCFCNLAMO_UseTime;
			data7[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_Uptime;
			data7["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data7[AFEHLCGHAEE_Strings.AEOEJNODHLC_bns_cnt] = FBCJICEPLED[i].PFPGHILKGIG_BnsCnt;
			data7["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data7[AFEHLCGHAEE_Strings.IIMOOLKIOHC_sel_diva] = FBCJICEPLED[i].AFKMGCLEPGA_SelDiva;
			data7[AFEHLCGHAEE_Strings.KMIPKHFODIK_sel_f_id] = FBCJICEPLED[i].LEPHEGEHHOD_SelFId;
			data7[AFEHLCGHAEE_Strings.FDBOPFEOENF_diva] = data2;
			data7[AFEHLCGHAEE_Strings.LGFFMGDBIAH_ranking] = data3;
			data7[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data4;
			data7[AFEHLCGHAEE_Strings.DKHIHHMOIKM_bns] = data6;
			data7[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data5;
			data7["pla_rcv"] = FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv;
			data7["epa_rcv"] = FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv;
			data.Add(data7);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			tmp["dirty"] = AFNJCFEKFDD_Dirty;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x18FFB34 Offset: 0x18FFB34 VA: 0x18FFB34 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			AFNJCFEKFDD_Dirty = DKMPHAPBDLH_ReadLong(OILEIIEIBHP, "dirty", 0, ref isInvalid);

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
						EDOHBJAPLPF_JsonData d = block[i];
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(d, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_Point = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].ADKDHKMPMHP_Rate = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.ADKDHKMPMHP_rate, 0, ref isInvalid);
						FBCJICEPLED[i].GJPHOIBCEFL_ItemTicketCnt = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.COCEIPAKJKF_item, 0, ref isInvalid);
						FBCJICEPLED[i].NNCFCPEOODE_UseCnt = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.NNCFCPEOODE_usecnt, 0, ref isInvalid);
						FBCJICEPLED[i].CNJCFCNLAMO_UseTime = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.CNJCFCNLAMO_usetime, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_Uptime = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(d, "lb", 0, ref isInvalid);
						FBCJICEPLED[i].PFPGHILKGIG_BnsCnt = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.AEOEJNODHLC_bns_cnt, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(d, "show", 0, ref isInvalid);
						FBCJICEPLED[i].AFKMGCLEPGA_SelDiva = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.IIMOOLKIOHC_sel_diva, 0, ref isInvalid);
						FBCJICEPLED[i].LEPHEGEHHOD_SelFId = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.KMIPKHFODIK_sel_f_id, 0, ref isInvalid);
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_ReadInt(d, "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_ReadInt(d, "epa_rcv", 0, ref isInvalid) != 0;
						if(d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FDBOPFEOENF_diva))
						{
							EDOHBJAPLPF_JsonData data2 = d[AFEHLCGHAEE_Strings.FDBOPFEOENF_diva];
							int cnt2 = data2.HNBFOAJIIAL_Count;
							if(cnt2 > 0)
							{
								if(cnt2 >= 11)
								{
									cnt2 = 10;
									isInvalid = true;
								}
								for(int j = 0; j < cnt2; j++)
								{
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].KKGPPDLFDKA_SoLv = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.KKGPPDLFDKA_so_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].DMDLAIOJKPM_SoExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.DMDLAIOJKPM_so_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].JDHJEINPJLL_SoMExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.JDHJEINPJLL_so_mexp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].IDIDIJGPPIO_VoLv = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.IDIDIJGPPIO_vo_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].GNBEKAELDMM_VoExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.GNBEKAELDMM_vo_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].OIMLBHPAMGD_VoMExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.OIMLBHPAMGD_vo_mexp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].OMOIGFMNFJB_ChLv = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.OMOIGFMNFJB_ch_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].BCANABIAIIP_ChExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.BCANABIAIIP_ch_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_Divas[j].PFDDNKEOKBF_ChMExp = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.PFDDNKEOKBF_ch_mexp, 0, ref isInvalid);
								}
							}
						}
						if(d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.LGFFMGDBIAH_ranking))
						{
							EDOHBJAPLPF_JsonData data2 = d[AFEHLCGHAEE_Strings.LGFFMGDBIAH_ranking];
							int cnt2 = data2.HNBFOAJIIAL_Count;
							if(cnt2 > 0)
							{
								if(cnt2 >= 11)
								{
									cnt2 = 10;
									isInvalid = true;
								}
								for(int j = 0; j < cnt2; j++)
								{
									FBCJICEPLED[i].LGFFMGDBIAH_Rankings[j].OCGFKMHNEOF_Key = FGCNMLBACGO_ReadString(data2[j], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_Rankings[j].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(data2[j], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_Rankings[j].NANNGLGOFKH_Val = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.JBGEEPFKIGG_val, 0, ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_Rankings[j].CKFKFHKHOHA_RRcv = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
								}
							}
						}
						if(d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData data2 = d[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt2 = data2.HNBFOAJIIAL_Count;
							if(cnt2 > 0)
							{
								if(cnt2 >= 51)
								{
									cnt2 = 50;
									isInvalid = true;
								}
								for(int j = 0; j < cnt2; j++)
								{
									FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(data2[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(data2[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
								}
							}
						}
						IBCGPBOGOGP_ReadIntArray(d, AFEHLCGHAEE_Strings.DKHIHHMOIKM_bns, 0, 2, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x190709C
							if(OIPCCBHIKIA == 1)
								FBCJICEPLED[i].JHKKAKJCJOF_Bns2 = JBGEEPFKIGG;
							else if(OIPCCBHIKIA == 0)
								FBCJICEPLED[i].KAPGPAMOKDD_Bns1 = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(d, AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x1907130
							FBCJICEPLED[i].IPNLHCLFIDB_SetRewardReceived(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1901778 Offset: 0x1901778 VA: 0x1901778 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCBMJNPFPBB_EventGoDiva other = GPBJHKLFCEP as CCBMJNPFPBB_EventGoDiva;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
		AFNJCFEKFDD_Dirty = other.AFNJCFEKFDD_Dirty;
	}

	// // RVA: 0x1901F10 Offset: 0x1901F10 VA: 0x1901F10 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCBMJNPFPBB_EventGoDiva other = GPBJHKLFCEP as CCBMJNPFPBB_EventGoDiva;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		if(AFNJCFEKFDD_Dirty != other.AFNJCFEKFDD_Dirty)
			return false;
		return true;
	}

	// // RVA: 0x19029CC Offset: 0x19029CC VA: 0x19029CC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x1906CA0 Offset: 0x1906CA0 VA: 0x1906CA0 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
