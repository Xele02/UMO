
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use CCBMJNPFPBB_EventGoDiva", true)]
public class CCBMJNPFPBB { }
public class CCBMJNPFPBB_EventGoDiva : KLFDBFMNLBL_ServerSaveBlock
{
	public class CAJKNNAEIPI
	{
		private int FBGGEFFJJHB_xor; // 0x8
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

		public int KKGPPDLFDKA_so_lv { get { return PLBBECDLENA_Crypted ^ FBGGEFFJJHB_xor; } set { PLBBECDLENA_Crypted = value ^ FBGGEFFJJHB_xor; NODFMDPDNJB_Crypted = value; } } //0x1907204 IAAHLBMJIKE 0x19016C4 GKOMOPECNLC
		public int DMDLAIOJKPM_so_exp { get { return AGFFNJFJEOG_Crypted ^ FBGGEFFJJHB_xor; } set { AGFFNJFJEOG_Crypted = value ^ FBGGEFFJJHB_xor; NICJPKNAKKN_Crypted = value; } } //0x1907214 BHBPDMPBDNE 0x19016D8 HGNHINHJODJ
		public int JDHJEINPJLL_so_mexp { get { return IBMBLPOFBBB_Crypted ^ FBGGEFFJJHB_xor; } set { IBMBLPOFBBB_Crypted = value ^ FBGGEFFJJHB_xor; FIJFCNKHBAK_Crypted = value; } } //0x1907224 NHJHIMPFHKG 0x19016EC MPGJFJCNOJI
		public int IDIDIJGPPIO_vo_lv { get { return LGHEIJGKFDB_Crypted ^ FBGGEFFJJHB_xor; } set { LGHEIJGKFDB_Crypted = value ^ FBGGEFFJJHB_xor; JFJPENFHPNJ_Crypted = value; } } //0x1907234 CJDKBLMLELB 0x1901700 LJLCMJLLOCA
		public int GNBEKAELDMM_vo_exp { get { return LBAAEBGKHPE_Crypted ^ FBGGEFFJJHB_xor; } set { LBAAEBGKHPE_Crypted = value ^ FBGGEFFJJHB_xor; LHIHGKAPKDN_Crypted = value; } } //0x1907244 CFMCJHBBMFH 0x1901714 OCOHFADLOHF
		public int OIMLBHPAMGD_vo_mexp { get { return ENCPNANJGHD_Crypted ^ FBGGEFFJJHB_xor; } set { ENCPNANJGHD_Crypted = value ^ FBGGEFFJJHB_xor; CNIAECGOPMK_Crypted = value; } } //0x1907254 JLGGALLPMID 0x1901728 GJMCHHMBACC
		public int OMOIGFMNFJB_ch_lv { get { return BBHEKIAJMBL_Crypted ^ FBGGEFFJJHB_xor; } set { BBHEKIAJMBL_Crypted = value ^ FBGGEFFJJHB_xor; DPGCPCMNJLB_Crypted = value; } } //0x1907264 JKKNKLNMOCD 0x190173C NBNFPNCJDPN
		public int BCANABIAIIP_ch_exp { get { return DFEFCOBCMCB_Crypted ^ FBGGEFFJJHB_xor; } set { DFEFCOBCMCB_Crypted = value ^ FBGGEFFJJHB_xor; IAIIMDFOPOL_Crypted = value; } } //0x1907274 DHMEJNEFEHO 0x1901750 KBPDDCGHIKD
		public int PFDDNKEOKBF_ch_mexp { get { return NPGOJLNHBIG_Crypted ^ FBGGEFFJJHB_xor; } set { NPGOJLNHBIG_Crypted = value ^ FBGGEFFJJHB_xor; IGAADAHAFEP_Crypted = value; } } //0x1907284 KBNOJNALELL 0x1901764 GCFLNKDPFGL

		// // RVA: 0x1907294 Offset: 0x1907294 VA: 0x1907294
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			KKGPPDLFDKA_so_lv = 0;
			DMDLAIOJKPM_so_exp = 0;
			JDHJEINPJLL_so_mexp = 0;
			IDIDIJGPPIO_vo_lv = 0;
			GNBEKAELDMM_vo_exp = 0;
			OIMLBHPAMGD_vo_mexp = 0;
			OMOIGFMNFJB_ch_lv = 0;
			BCANABIAIIP_ch_exp = 0;
			PFDDNKEOKBF_ch_mexp = 0;
		}

		// // RVA: 0x19072E8 Offset: 0x19072E8 VA: 0x19072E8
		public bool AGBOGBEOFME(CAJKNNAEIPI OIKJFMGEICL)
		{
			if(KKGPPDLFDKA_so_lv != OIKJFMGEICL.KKGPPDLFDKA_so_lv)
				return false;
			if(DMDLAIOJKPM_so_exp != OIKJFMGEICL.DMDLAIOJKPM_so_exp)
				return false;
			if(JDHJEINPJLL_so_mexp != OIKJFMGEICL.JDHJEINPJLL_so_mexp)
				return false;
			if(IDIDIJGPPIO_vo_lv != OIKJFMGEICL.IDIDIJGPPIO_vo_lv)
				return false;
			if(GNBEKAELDMM_vo_exp != OIKJFMGEICL.GNBEKAELDMM_vo_exp)
				return false;
			if(OIMLBHPAMGD_vo_mexp != OIKJFMGEICL.OIMLBHPAMGD_vo_mexp)
				return false;
			if(OMOIGFMNFJB_ch_lv != OIKJFMGEICL.OMOIGFMNFJB_ch_lv)
				return false;
			if(BCANABIAIIP_ch_exp != OIKJFMGEICL.BCANABIAIIP_ch_exp)
				return false;
			if(PFDDNKEOKBF_ch_mexp != OIKJFMGEICL.PFDDNKEOKBF_ch_mexp)
				return false;
			return true;
		}

		// // RVA: 0x190760C Offset: 0x190760C VA: 0x190760C
		public void ODDIHGPONFL_Copy(CAJKNNAEIPI OIKJFMGEICL)
		{
			KKGPPDLFDKA_so_lv = OIKJFMGEICL.KKGPPDLFDKA_so_lv;
			DMDLAIOJKPM_so_exp = OIKJFMGEICL.DMDLAIOJKPM_so_exp;
			JDHJEINPJLL_so_mexp = OIKJFMGEICL.JDHJEINPJLL_so_mexp;
			IDIDIJGPPIO_vo_lv = OIKJFMGEICL.IDIDIJGPPIO_vo_lv;
			GNBEKAELDMM_vo_exp = OIKJFMGEICL.GNBEKAELDMM_vo_exp;
			OIMLBHPAMGD_vo_mexp = OIKJFMGEICL.OIMLBHPAMGD_vo_mexp;
			OMOIGFMNFJB_ch_lv = OIKJFMGEICL.OMOIGFMNFJB_ch_lv;
			BCANABIAIIP_ch_exp = OIKJFMGEICL.BCANABIAIIP_ch_exp;
			PFDDNKEOKBF_ch_mexp = OIKJFMGEICL.PFDDNKEOKBF_ch_mexp;
		}

		// // RVA: 0x190780C Offset: 0x190780C VA: 0x190780C
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, CCBMJNPFPBB_EventGoDiva.CAJKNNAEIPI _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

		// // RVA: 0x18FF69C Offset: 0x18FF69C VA: 0x18FF69C
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.KKGPPDLFDKA_so_lv] = KKGPPDLFDKA_so_lv;
			res[AFEHLCGHAEE_Strings.DMDLAIOJKPM_so_exp] = DMDLAIOJKPM_so_exp;
			res[AFEHLCGHAEE_Strings.JDHJEINPJLL_so_mexp] = JDHJEINPJLL_so_mexp;
			res[AFEHLCGHAEE_Strings.IDIDIJGPPIO_vo_lv] = IDIDIJGPPIO_vo_lv;
			res[AFEHLCGHAEE_Strings.GNBEKAELDMM_vo_exp] = GNBEKAELDMM_vo_exp;
			res[AFEHLCGHAEE_Strings.OIMLBHPAMGD_vo_mexp] = OIMLBHPAMGD_vo_mexp;
			res[AFEHLCGHAEE_Strings.OMOIGFMNFJB_ch_lv] = OMOIGFMNFJB_ch_lv;
			res[AFEHLCGHAEE_Strings.BCANABIAIIP_ch_exp] = BCANABIAIIP_ch_exp;
			res[AFEHLCGHAEE_Strings.PFDDNKEOKBF_ch_mexp] = PFDDNKEOKBF_ch_mexp;
			return res;
		}
	}

	public class KIJJHJHLBAK
	{
		private int ENOBDCFHELD; // 0x8
		private int FCEJCHGLFGN; // 0xC
		public string MPCAGEPEJJJ_Key; // 0x10
		public long EGBOHDFBAPB_closed_at; // 0x18
		public bool IMFBCJOIJKJ_Entry; // 0x20
		public bool ABBJBPLHFHA_Spurt; // 0x21
		public int INLNJOGHLJE_Show; // 0x24
		public int AFKMGCLEPGA_SelDiva; // 0x28
		public int LEPHEGEHHOD_SelFId; // 0x2C
		public List<CAJKNNAEIPI> FDBOPFEOENF_diva = new List<CAJKNNAEIPI>(10); // 0x30
		public List<MIDMMFMJFPJ> LGFFMGDBIAH_ranking = new List<MIDMMFMJFPJ>(10); // 0x34
		public List<IKCGAJKCPFN> NNMPGOAGEOL_quests = new List<IKCGAJKCPFN>(10); // 0x38
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0x3C
		private int AADPAJOLEEF_PointCrypted; // 0x40
		private int IOJOBGHPLIE_PointCrypted; // 0x44
		private int CHGFBPOFICJ_RateCrypted; // 0x48
		private int BGNIPKEKKMK_Crypted; // 0x4C
		private int MEPLFFACONB_Crypted; // 0x50
		private int AEMACOJDCGK_ItemTicketCntCrypted; // 0x54
		private int PGDECJMHKGH_Crypted; // 0x58
		private int OFNEPGGPEPI_Crypted; // 0x5C
		private long DMBIIFIONCH_Crypted; // 0x60
		private long GOFAELEBNJD_Crypted; // 0x68
		private long DLEEMCAPOBP_Crypted; // 0x70
		private long JPNMMOEPAEM_Crypted; // 0x78
		private int HFIHMDILNFD_LbCrypted; // 0x80
		private int IGMFFIKLEHP_LbCrypted2; // 0x84
		private int GPCKFEPLFFB_Crypted; // 0x88
		private int CNDLHDIJLIP_Crypted; // 0x8C
		private int BEJKFPEOPBJ_Crypted; // 0x90
		private int CHKEHHAKBFH_Crypted; // 0x94
		private int JGOPFCJEGMM_Crypted; // 0x98
		private int COKIDJLMPON_Crypted; // 0x9C
		private sbyte JBOCIADFMEA_Crypted; // 0xA0
		private sbyte PICDFKNKFLG_Crypted; // 0xA1

		public int DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ ENOBDCFHELD; } set { value = Mathf.Clamp(value, 0, 100000000); AADPAJOLEEF_PointCrypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } //0x18FFA7C JKHIIAEMMDE 0x1901480 PFFKLBLEPKB
		public int ADKDHKMPMHP_rate { get { return CHGFBPOFICJ_RateCrypted ^ ENOBDCFHELD; } set { CHGFBPOFICJ_RateCrypted = value ^ ENOBDCFHELD; BGNIPKEKKMK_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA8C KCLKBHDMAFH 0x1901524 GOLECEILPOI
		public int GJPHOIBCEFL_ItemTicketCnt { get { return MEPLFFACONB_Crypted ^ ENOBDCFHELD; } set { value = Mathf.Clamp(value, 0, 10000); MEPLFFACONB_Crypted = value ^ ENOBDCFHELD; AEMACOJDCGK_ItemTicketCntCrypted = value ^ FCEJCHGLFGN; } } //0x18FFA9C NHPHHCAJHJM 0x1901538 DDCBIBDONGA
		public int NNCFCPEOODE_usecnt { get { return PGDECJMHKGH_Crypted ^ ENOBDCFHELD; } set { PGDECJMHKGH_Crypted = value ^ ENOBDCFHELD; OFNEPGGPEPI_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAAC MJLFJHMJJHF 0x19015D8 GLGKFAHAHEG
		public long CNJCFCNLAMO_usetime { get { return DMBIIFIONCH_Crypted ^ ENOBDCFHELD; } set { DMBIIFIONCH_Crypted = value ^ ENOBDCFHELD; GOFAELEBNJD_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFABC CLNBPMIBAIF 0x19015EC KMBEPOGBMLJ
		public long NFIOKIBPJCJ_uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAD4 NGIDBCKCAMO 0x1901614 AEHIIPBDNGE
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_LbCrypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_LbCrypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_LbCrypted2 = value ^ FCEJCHGLFGN; } } //0x18FFAEC PBEMPHPDDDB 0x190163C MCADMIEOCCF
		public int KAPGPAMOKDD_Bns1 { get { return GPCKFEPLFFB_Crypted ^ ENOBDCFHELD; } set { GPCKFEPLFFB_Crypted = value ^ ENOBDCFHELD; CNDLHDIJLIP_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA5C GFLGNPEDCNM 0x1907108 BLFINOKAGDB
		public int JHKKAKJCJOF_Bns2 { get { return BEJKFPEOPBJ_Crypted ^ ENOBDCFHELD; } set { BEJKFPEOPBJ_Crypted = value ^ ENOBDCFHELD; CHKEHHAKBFH_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFA6C MOLMAHDDPBI 0x190711C MLKEHKPBBNJ
		public int PFPGHILKGIG_BnsCnt { get { return JGOPFCJEGMM_Crypted ^ ENOBDCFHELD; } set { JGOPFCJEGMM_Crypted = value ^ ENOBDCFHELD; COKIDJLMPON_Crypted = value ^ FCEJCHGLFGN; } } //0x18FFAFC IJOGKMOAOOB 0x1901650 EBGNDBHKFHF
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } //0x18FFB0C CLGCKBAEJHF 0x1901664 AHFMKDDCFAM
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } //0x18FFB20 AIBENAPCPJI 0x1901694 FKKHHKCJEII

		// // RVA: 0x1908E18 Offset: 0x1908E18 VA: 0x1908E18
		public bool DGOAGKOKCIJ_IsRewardReceived(int LHJCOPMMIGO)
		{
			return LGFFMGDBIAH_ranking[LHJCOPMMIGO].CKFKFHKHOHA_RRcv;
		}

		// // RVA: 0x1908EB8 Offset: 0x1908EB8 VA: 0x1908EB8
		public void LHAEPPFACOB_SetRewardReceived(int LHJCOPMMIGO, bool _OAFPGJLCNFM_cond)
		{
			LGFFMGDBIAH_ranking[LHJCOPMMIGO].CKFKFHKHOHA_RRcv = _OAFPGJLCNFM_cond;
		}

		// // RVA: 0x1908F60 Offset: 0x1908F60 VA: 0x1908F60
		public bool BHIAKGKHKGD_IsReceived(int _BMBBDIAEOMP_i)
		{
			return LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] != 20;
		}

		// // RVA: 0x1907170 Offset: 0x1907170 VA: 0x1907170
		public void IPNLHCLFIDB_SetRewardReceived(int _BMBBDIAEOMP_i, bool _JKDJCFEBDHC_Enabled)
		{
			LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] = (sbyte)(_JKDJCFEBDHC_Enabled ? 40 : 20);
		}

		// // RVA: 0x1908FF0 Offset: 0x1908FF0 VA: 0x1908FF0
		public bool HHAGNMOIENH_UseFeverTicket(int JDPGHNKKGNE, long _EOLFJGMAJAB_CurrentTime)
		{
			if(JDPGHNKKGNE <= GJPHOIBCEFL_ItemTicketCnt && NNCFCPEOODE_usecnt - JDPGHNKKGNE > -1)
			{
				GJPHOIBCEFL_ItemTicketCnt -= JDPGHNKKGNE;
				CNJCFCNLAMO_usetime = _EOLFJGMAJAB_CurrentTime;
				NNCFCPEOODE_usecnt -= JDPGHNKKGNE;
				return true;
			}
			return false;
		}

		// // RVA: 0x18FE0D8 Offset: 0x18FE0D8 VA: 0x18FE0D8
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_closed_at = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			DNBFMLBNAEE_point = 0;
			ADKDHKMPMHP_rate = 0;
			GJPHOIBCEFL_ItemTicketCnt = 0;
			INLNJOGHLJE_Show = 0;
			AFKMGCLEPGA_SelDiva = 0;
			LEPHEGEHHOD_SelFId = 0;
			PFPGHILKGIG_BnsCnt = 0;
			NNCFCPEOODE_usecnt = 0;
			CNJCFCNLAMO_usetime = 0;
			NFIOKIBPJCJ_uptime = 0;
			OMCAOJJGOGG_Lb = 0;
			KAPGPAMOKDD_Bns1 = 0;
			JHKKAKJCJOF_Bns2 = 0;
			OKEJGGCMAAI_PlaRcv = false;
			CGMMMJCIDFE_EpaRcv = false;
			FDBOPFEOENF_diva.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 10; i++)
			{
				CAJKNNAEIPI data = new CAJKNNAEIPI();
				data.LHPDDGIJKNB_Reset(k);
				FDBOPFEOENF_diva.Add(data);
				k *= 13;
			}
			LGFFMGDBIAH_ranking.Clear();
			k = ENOBDCFHELD + 5;
			for(int i = 0; i < 10; i++)
			{
				MIDMMFMJFPJ data = new MIDMMFMJFPJ();
				data.LHPDDGIJKNB_Reset(k);
				LGFFMGDBIAH_ranking.Add(data);
				k *= 13;
			}
			NNMPGOAGEOL_quests.Clear();
			k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB_Reset(i + 1, k);
				NNMPGOAGEOL_quests.Add(ik);
				k *= 13;
			}
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv.Add(20);
			}
		}

		// // RVA: 0x1901960 Offset: 0x1901960 VA: 0x1901960
		public void ODDIHGPONFL_Copy(KIJJHJHLBAK GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_closed_at = GPBJHKLFCEP.EGBOHDFBAPB_closed_at;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			DNBFMLBNAEE_point = GPBJHKLFCEP.DNBFMLBNAEE_point;
			ADKDHKMPMHP_rate = GPBJHKLFCEP.ADKDHKMPMHP_rate;
			GJPHOIBCEFL_ItemTicketCnt = GPBJHKLFCEP.GJPHOIBCEFL_ItemTicketCnt;
			NNCFCPEOODE_usecnt = GPBJHKLFCEP.NNCFCPEOODE_usecnt;
			CNJCFCNLAMO_usetime = GPBJHKLFCEP.CNJCFCNLAMO_usetime;
			NFIOKIBPJCJ_uptime = GPBJHKLFCEP.NFIOKIBPJCJ_uptime;
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
				FDBOPFEOENF_diva[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.FDBOPFEOENF_diva[i]);
			}
			for(int i = 0; i < 10; i++)
			{
				LGFFMGDBIAH_ranking[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.LGFFMGDBIAH_ranking[i]);
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_quests[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.NNMPGOAGEOL_quests[i]);
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
			if(EGBOHDFBAPB_closed_at != OIKJFMGEICL.EGBOHDFBAPB_closed_at)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(DNBFMLBNAEE_point != OIKJFMGEICL.DNBFMLBNAEE_point)
				return false;
			if(ADKDHKMPMHP_rate != OIKJFMGEICL.ADKDHKMPMHP_rate)
				return false;
			if(GJPHOIBCEFL_ItemTicketCnt != OIKJFMGEICL.GJPHOIBCEFL_ItemTicketCnt)
				return false;
			if(NFIOKIBPJCJ_uptime != OIKJFMGEICL.NFIOKIBPJCJ_uptime)
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
				if(!FDBOPFEOENF_diva[i].AGBOGBEOFME(OIKJFMGEICL.FDBOPFEOENF_diva[i]))
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(!LGFFMGDBIAH_ranking[i].AGBOGBEOFME(OIKJFMGEICL.LGFFMGDBIAH_ranking[i]))
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_quests[i]))
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
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

		// // RVA: 0x1906D84 Offset: 0x1906D84 VA: 0x1906D84
		// public FENCAJJBLBH PFAKPFKJJKA() { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
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
	public override void KMBPACJNEOF_Reset()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			KIJJHJHLBAK data = new KIJJHJHLBAK();
			data.LHPDDGIJKNB_Reset();
			FBCJICEPLED.Add(data);
		}
		AFNJCFEKFDD_Dirty = 0;
	}

	// // RVA: 0x18FE540 Offset: 0x18FE540 VA: 0x18FE540 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data2.Add(FBCJICEPLED[i].FDBOPFEOENF_diva[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data3.Add(FBCJICEPLED[i].LGFFMGDBIAH_ranking[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data4.Add(FBCJICEPLED[i].NNMPGOAGEOL_quests[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data5.Add(FBCJICEPLED[i].BHIAKGKHKGD_IsReceived(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data6.Add(FBCJICEPLED[i].KAPGPAMOKDD_Bns1);
			data6.Add(FBCJICEPLED[i].JHKKAKJCJOF_Bns2);
			EDOHBJAPLPF_JsonData data7 = new EDOHBJAPLPF_JsonData();
			data7[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data7[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_closed_at;
			data7[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data7[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data7[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_point;
			data7[AFEHLCGHAEE_Strings.ADKDHKMPMHP_rate] = FBCJICEPLED[i].ADKDHKMPMHP_rate;
			data7[AFEHLCGHAEE_Strings.COCEIPAKJKF_item] = FBCJICEPLED[i].GJPHOIBCEFL_ItemTicketCnt;
			data7[AFEHLCGHAEE_Strings.NNCFCPEOODE_usecnt] = FBCJICEPLED[i].NNCFCPEOODE_usecnt;
			data7[AFEHLCGHAEE_Strings.CNJCFCNLAMO_usetime] = FBCJICEPLED[i].CNJCFCNLAMO_usetime;
			data7[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_uptime;
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
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
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
			AFNJCFEKFDD_Dirty = DKMPHAPBDLH_GetLong(OILEIIEIBHP, "dirty", 0, ref isInvalid);

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
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_GetString(d, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_closed_at = DKMPHAPBDLH_GetLong(d, AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_point = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].ADKDHKMPMHP_rate = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.ADKDHKMPMHP_rate, 0, ref isInvalid);
						FBCJICEPLED[i].GJPHOIBCEFL_ItemTicketCnt = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.COCEIPAKJKF_item, 0, ref isInvalid);
						FBCJICEPLED[i].NNCFCPEOODE_usecnt = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.NNCFCPEOODE_usecnt, 0, ref isInvalid);
						FBCJICEPLED[i].CNJCFCNLAMO_usetime = DKMPHAPBDLH_GetLong(d, AFEHLCGHAEE_Strings.CNJCFCNLAMO_usetime, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_uptime = DKMPHAPBDLH_GetLong(d, AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_GetInt(d, "lb", 0, ref isInvalid);
						FBCJICEPLED[i].PFPGHILKGIG_BnsCnt = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.AEOEJNODHLC_bns_cnt, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_GetInt(d, "show", 0, ref isInvalid);
						FBCJICEPLED[i].AFKMGCLEPGA_SelDiva = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.IIMOOLKIOHC_sel_diva, 0, ref isInvalid);
						FBCJICEPLED[i].LEPHEGEHHOD_SelFId = CJAENOMGPDA_GetInt(d, AFEHLCGHAEE_Strings.KMIPKHFODIK_sel_f_id, 0, ref isInvalid);
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_GetInt(d, "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_GetInt(d, "epa_rcv", 0, ref isInvalid) != 0;
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
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].KKGPPDLFDKA_so_lv = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.KKGPPDLFDKA_so_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].DMDLAIOJKPM_so_exp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.DMDLAIOJKPM_so_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].JDHJEINPJLL_so_mexp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.JDHJEINPJLL_so_mexp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].IDIDIJGPPIO_vo_lv = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.IDIDIJGPPIO_vo_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].GNBEKAELDMM_vo_exp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.GNBEKAELDMM_vo_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].OIMLBHPAMGD_vo_mexp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.OIMLBHPAMGD_vo_mexp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].OMOIGFMNFJB_ch_lv = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.OMOIGFMNFJB_ch_lv, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].BCANABIAIIP_ch_exp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.BCANABIAIIP_ch_exp, 0, ref isInvalid);
									FBCJICEPLED[i].FDBOPFEOENF_diva[j].PFDDNKEOKBF_ch_mexp = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.PFDDNKEOKBF_ch_mexp, 0, ref isInvalid);
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
									FBCJICEPLED[i].LGFFMGDBIAH_ranking[j].OCGFKMHNEOF_name_for_api = FGCNMLBACGO_GetString(data2[j], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_ranking[j].EGBOHDFBAPB_closed_at = DKMPHAPBDLH_GetLong(data2[j], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_ranking[j].NANNGLGOFKH_value = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.JBGEEPFKIGG_val, 0, ref isInvalid);
									FBCJICEPLED[i].LGFFMGDBIAH_ranking[j].CKFKFHKHOHA_RRcv = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
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
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, j + 1, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].EALOBDHOCHP_stat = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].HMFFHLPNMPH_count = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(data2[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_GetInt(data2[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
								}
							}
						}
						IBCGPBOGOGP_ReadIntArray(d, AFEHLCGHAEE_Strings.DKHIHHMOIKM_bns, 0, 2, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x190709C
							if(_OIPCCBHIKIA_index == 1)
								FBCJICEPLED[i].JHKKAKJCJOF_Bns2 = _JBGEEPFKIGG_val;
							else if(_OIPCCBHIKIA_index == 0)
								FBCJICEPLED[i].KAPGPAMOKDD_Bns1 = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(d, AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x1907130
							FBCJICEPLED[i].IPNLHCLFIDB_SetRewardReceived(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val != 0);
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
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCBMJNPFPBB_EventGoDiva other = GPBJHKLFCEP as CCBMJNPFPBB_EventGoDiva;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL_Copy(other.FBCJICEPLED[i]);
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
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x1906CA0 Offset: 0x1906CA0 VA: 0x1906CA0 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
