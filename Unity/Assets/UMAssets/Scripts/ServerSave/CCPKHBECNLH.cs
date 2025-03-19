
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use CCPKHBECNLH_EventBattle", true)]
public class CCPKHBECNLH { }
public class CCPKHBECNLH_EventBattle : KLFDBFMNLBL_ServerSaveBlock
{
	public class AIFGBKMMJGL
	{
		private const int FBGGEFFJJHB = 1744406327; // 0x67f98737
		private List<int> NBOLDNMPJFG_ScoreByDiff = new List<int>(5); // 0x8
		public List<int> NLKEBAOBJCM_ComboByDiff = new List<int>(5); // 0xC
		public List<sbyte> LAMCCNAKIOJ_ComboRankByDiff = new List<sbyte>(5); // 0x10
		public List<int> JNLKJCDFFMM_ClearByDiff = new List<int>(5); // 0x14
		public List<int> EMHFDJEFIHG_PlayByDiff = new List<int>(5); // 0x18
		private List<int> OAAFPCECFMD_ScoreByDiffL6 = new List<int>(5); // 0x1C
		public List<int> DNIGPFPHJAK_ComboByDiffL6 = new List<int>(5); // 0x20
		public List<sbyte> EEECMKPLPNL_ComboRankByDiffL6 = new List<sbyte>(5); // 0x24
		public List<int> DPPCFFFNBGA_ClearByDiffL6 = new List<int>(5); // 0x28
		public List<int> FHFKOGIPAEH_PlayByDiffL6 = new List<int>(5); // 0x2C
		private int CJAOMKLHFJL_Crypted = FBGGEFFJJHB; // 0x30
		private int BNPKALPLIJH_Crypted = FBGGEFFJJHB; // 0x34

		public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB; } } //0x190F12C BPGCGEDHBEH 0x190F140 ICPMFBIDFFO
		public int OFJHABJNGOD_ExcellentScore { get { return BNPKALPLIJH_Crypted ^ FBGGEFFJJHB; } set { BNPKALPLIJH_Crypted = value ^ FBGGEFFJJHB; } } //0x190F154 NDBFELIIICL 0x190F168 BIJLJDDDMLL

		// // RVA: 0x190F17C Offset: 0x190F17C VA: 0x190F17C
		public int BDCAICINCKK_GetScoreForDiff(int AKNELONELJK)
		{
			return NBOLDNMPJFG_ScoreByDiff[AKNELONELJK] ^ FBGGEFFJJHB;
		}

		// // RVA: 0x190F208 Offset: 0x190F208 VA: 0x190F208
		public void ECKFCIHPHGJ_SetScoreForDiff(int AKNELONELJK, int KNIFCANOHOC)
		{
			NBOLDNMPJFG_ScoreByDiff[AKNELONELJK] = KNIFCANOHOC ^ FBGGEFFJJHB;
		}

		// // RVA: 0x190F298 Offset: 0x190F298 VA: 0x190F298
		public int AHDKMPFDKPE_GetScoreForDiffL6(int AKNELONELJK)
		{
			return OAAFPCECFMD_ScoreByDiffL6[AKNELONELJK] ^ FBGGEFFJJHB;
		}

		// // RVA: 0x190F324 Offset: 0x190F324 VA: 0x190F324
		public void AAELOPLDBPF_SetScoreForDiffL6(int AKNELONELJK, int KNIFCANOHOC)
		{
			OAAFPCECFMD_ScoreByDiffL6[AKNELONELJK] = KNIFCANOHOC ^ FBGGEFFJJHB;
		}

		// // RVA: 0x190F3B4 Offset: 0x190F3B4 VA: 0x190F3B4
		public void LHPDDGIJKNB_Reset()
		{
			NBOLDNMPJFG_ScoreByDiff.Clear();
			NLKEBAOBJCM_ComboByDiff.Clear();
			LAMCCNAKIOJ_ComboRankByDiff.Clear();
			JNLKJCDFFMM_ClearByDiff.Clear();
			EMHFDJEFIHG_PlayByDiff.Clear();
			OAAFPCECFMD_ScoreByDiffL6.Clear();
			DNIGPFPHJAK_ComboByDiffL6.Clear();
			EEECMKPLPNL_ComboRankByDiffL6.Clear();
			DPPCFFFNBGA_ClearByDiffL6.Clear();
			FHFKOGIPAEH_PlayByDiffL6.Clear();
			for(int i = 0; i < 5; i++)
			{
				NBOLDNMPJFG_ScoreByDiff.Add(0);
				ECKFCIHPHGJ_SetScoreForDiff(i, 0);
				NLKEBAOBJCM_ComboByDiff.Add(0);
				LAMCCNAKIOJ_ComboRankByDiff.Add(0);
				JNLKJCDFFMM_ClearByDiff.Add(0);
				EMHFDJEFIHG_PlayByDiff.Add(0);
				OAAFPCECFMD_ScoreByDiffL6.Add(0);
				AAELOPLDBPF_SetScoreForDiffL6(i, 0);
				DNIGPFPHJAK_ComboByDiffL6.Add(0);
				EEECMKPLPNL_ComboRankByDiffL6.Add(0);
				DPPCFFFNBGA_ClearByDiffL6.Add(0);
				FHFKOGIPAEH_PlayByDiffL6.Add(0);
			}
			GOIKCKHMBDL_FreeMusicId = 0;
			OFJHABJNGOD_ExcellentScore = 0;
		}

		// // RVA: 0x190F810 Offset: 0x190F810 VA: 0x190F810
		public void ODDIHGPONFL(AIFGBKMMJGL GPBJHKLFCEP)
		{
			for(int i = 0; i < 5; i++)
			{
				ECKFCIHPHGJ_SetScoreForDiff(i, GPBJHKLFCEP.BDCAICINCKK_GetScoreForDiff(i));
				NLKEBAOBJCM_ComboByDiff[i] = GPBJHKLFCEP.NLKEBAOBJCM_ComboByDiff[i];
				LAMCCNAKIOJ_ComboRankByDiff[i] = GPBJHKLFCEP.LAMCCNAKIOJ_ComboRankByDiff[i];
				JNLKJCDFFMM_ClearByDiff[i] = GPBJHKLFCEP.JNLKJCDFFMM_ClearByDiff[i];
				EMHFDJEFIHG_PlayByDiff[i] = GPBJHKLFCEP.EMHFDJEFIHG_PlayByDiff[i];
				AAELOPLDBPF_SetScoreForDiffL6(i, GPBJHKLFCEP.AHDKMPFDKPE_GetScoreForDiffL6(i));
				DNIGPFPHJAK_ComboByDiffL6[i] = GPBJHKLFCEP.DNIGPFPHJAK_ComboByDiffL6[i];
				EEECMKPLPNL_ComboRankByDiffL6[i] = GPBJHKLFCEP.EEECMKPLPNL_ComboRankByDiffL6[i];
				DPPCFFFNBGA_ClearByDiffL6[i] = GPBJHKLFCEP.DPPCFFFNBGA_ClearByDiffL6[i];
				FHFKOGIPAEH_PlayByDiffL6[i] = GPBJHKLFCEP.FHFKOGIPAEH_PlayByDiffL6[i];
			}
			GOIKCKHMBDL_FreeMusicId = GPBJHKLFCEP.GOIKCKHMBDL_FreeMusicId;
		}

		// // RVA: 0x190FC8C Offset: 0x190FC8C VA: 0x190FC8C
		public bool AGBOGBEOFME(AIFGBKMMJGL OIKJFMGEICL)
		{
			if(GOIKCKHMBDL_FreeMusicId != OIKJFMGEICL.GOIKCKHMBDL_FreeMusicId)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(BDCAICINCKK_GetScoreForDiff(i) != OIKJFMGEICL.BDCAICINCKK_GetScoreForDiff(i))
					return false;
				if(NLKEBAOBJCM_ComboByDiff[i] != OIKJFMGEICL.NLKEBAOBJCM_ComboByDiff[i])
					return false;
				if(LAMCCNAKIOJ_ComboRankByDiff[i] != OIKJFMGEICL.LAMCCNAKIOJ_ComboRankByDiff[i])
					return false;
				if(JNLKJCDFFMM_ClearByDiff[i] != OIKJFMGEICL.JNLKJCDFFMM_ClearByDiff[i])
					return false;
				if(EMHFDJEFIHG_PlayByDiff[i] != OIKJFMGEICL.EMHFDJEFIHG_PlayByDiff[i])
					return false;
				if(AHDKMPFDKPE_GetScoreForDiffL6(i) != OIKJFMGEICL.AHDKMPFDKPE_GetScoreForDiffL6(i))
					return false;
				if(DNIGPFPHJAK_ComboByDiffL6[i] != OIKJFMGEICL.DNIGPFPHJAK_ComboByDiffL6[i])
					return false;
				if(EEECMKPLPNL_ComboRankByDiffL6[i] != OIKJFMGEICL.EEECMKPLPNL_ComboRankByDiffL6[i])
					return false;
				if(DPPCFFFNBGA_ClearByDiffL6[i] != OIKJFMGEICL.DPPCFFFNBGA_ClearByDiffL6[i])
					return false;
				if(FHFKOGIPAEH_PlayByDiffL6[i] != OIKJFMGEICL.FHFKOGIPAEH_PlayByDiffL6[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1910144 Offset: 0x1910144 VA: 0x1910144
		// public JDDGGJCGOPA.EHFMCGGNPIJ KJAFPNIFPGP() { }

		// // RVA: 0x19106E4 Offset: 0x19106E4 VA: 0x19106E4
		// public void IOONPJENLOJ(JDDGGJCGOPA.EHFMCGGNPIJ GPBJHKLFCEP) { }

		// // RVA: 0x190B714 Offset: 0x190B714 VA: 0x190B714
		public EDOHBJAPLPF_JsonData OKJPIBHMKMJ()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data1 = new EDOHBJAPLPF_JsonData();
			data1.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data7 = new EDOHBJAPLPF_JsonData();
			data7.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data8 = new EDOHBJAPLPF_JsonData();
			data8.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data9 = new EDOHBJAPLPF_JsonData();
			data9.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data10 = new EDOHBJAPLPF_JsonData();
			data10.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < 5; i++)
			{
				data1.Add(BDCAICINCKK_GetScoreForDiff(i));
				data2.Add(NLKEBAOBJCM_ComboByDiff[i]);
				data3.Add((int)LAMCCNAKIOJ_ComboRankByDiff[i]);
				data4.Add(JNLKJCDFFMM_ClearByDiff[i]);
				data5.Add(EMHFDJEFIHG_PlayByDiff[i]);
				data6.Add(AHDKMPFDKPE_GetScoreForDiffL6(i));
				data7.Add(DNIGPFPHJAK_ComboByDiffL6[i]);
				data8.Add((int)EEECMKPLPNL_ComboRankByDiffL6[i]);
				data9.Add(DPPCFFFNBGA_ClearByDiffL6[i]);
				data10.Add(FHFKOGIPAEH_PlayByDiffL6[i]);
			}
			res[AFEHLCGHAEE_Strings.KNIFCANOHOC_score] = data1;
			res[AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo] = data2;
			res[AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk] = data3;
			res[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear] = data4;
			res[AFEHLCGHAEE_Strings.EMHFDJEFIHG_play] = data5;
			res["score_l6"] = data6;
			res["combo_l6"] = data7;
			res["cbrnk_l6"] = data8;
			res["clear_l6"] = data9;
			res["play_l6"] = data10;
			res["f_id"] = GOIKCKHMBDL_FreeMusicId;
			return res;
		}

		// // RVA: 0x190E048 Offset: 0x190E048 VA: 0x190E048
		public void IIEMACPEEBJ(EDOHBJAPLPF_JsonData IDLHJIOMJBK, ref bool NGJDHLGMHMH)
		{
			List<int> l = new List<int>();
			List<int> l2 = new List<int>();
			for(int i = 0; i < 5; i++)
			{
				l.Add(0);
				l2.Add(0);
			}
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, AFEHLCGHAEE_Strings.KNIFCANOHOC_score, l);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo, NLKEBAOBJCM_ComboByDiff);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk, l2);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, JNLKJCDFFMM_ClearByDiff);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, AFEHLCGHAEE_Strings.EMHFDJEFIHG_play, EMHFDJEFIHG_PlayByDiff);
			for(int i = 0; i < 5; i++)
			{
				ECKFCIHPHGJ_SetScoreForDiff(i, l[i]);
				LAMCCNAKIOJ_ComboRankByDiff[i] = (sbyte)l2[i];
				l[i] = 0;
				l2[i] = 0;
			}
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, "score_l6", l);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, "combo_l6", DNIGPFPHJAK_ComboByDiffL6);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, "cbrnk_l6", l2);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, "clear_l6", DPPCFFFNBGA_ClearByDiffL6);
			NGJDHLGMHMH |= HIELDCAFGOC(IDLHJIOMJBK, "play_l6", FHFKOGIPAEH_PlayByDiffL6);
			for(int i = 0; i < 5; i++)
			{
				AAELOPLDBPF_SetScoreForDiffL6(i, l[i]);
				EEECMKPLPNL_ComboRankByDiffL6[i] = (sbyte)l2[i];
			}
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("f_id"))
			{
				GOIKCKHMBDL_FreeMusicId = (int)IDLHJIOMJBK["f_id"];
			}
			else
			{
				GOIKCKHMBDL_FreeMusicId = 0;
				NGJDHLGMHMH = true;
			}
		}

		// // RVA: 0x1910C3C Offset: 0x1910C3C VA: 0x1910C3C
		private static bool HIELDCAFGOC(EDOHBJAPLPF_JsonData IDLHJIOMJBK, string PPFNGGCBJKC, List<int> NNDGIAEFMOG)
		{
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(PPFNGGCBJKC))
			{
				EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[PPFNGGCBJKC];
				int cnt = data.HNBFOAJIIAL_Count;
				bool res = false;
				if(cnt > 5)
				{
					res = true;
					cnt = 5;
				}
				for(int i = 0; i < cnt; i++)
				{
					NNDGIAEFMOG[i] = (int)data[i];
				}
				return res;
			}
			return true;
		}
	}

	public class BHIDLKBIJFK
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
		public sbyte PCHFOEIJJMM_Crypted; // 0x41
		public string MDADLCOCEBN_SessionId; // 0x44
		public int LFCCCLPFJMB_LastFId; // 0x48
		public int HFIHMDILNFD_Crypted; // 0x4C
		public int IGMFFIKLEHP_Crypted; // 0x50
		public int INDNOJCKAOD_Crypted; // 0x54
		public int MIMCCOCDMJK_Crypted; // 0x58
		public int HIPJJHBLLNA_Crypted; // 0x5C
		public int JIPEIJLHPCC_Crypted; // 0x60
		public int PCFNAIECMHM_Crypted; // 0x64
		public int FGKIIKDGDNF_Crypted; // 0x68
		public int EIGHJEHEOCH_Crypted; // 0x6C
		public int OICKANODJBO_Crypted; // 0x70
		public int MEAHAGDHJEK_Crypted; // 0x74
		public int MAAOPMFJCLP_Crypted; // 0x78
		public sbyte GGGEOJAOLKN_Crypted; // 0x7C
		public sbyte JBOCIADFMEA_Crypted; // 0x7D
		public sbyte PICDFKNKFLG_Crypted; // 0x7E
		public List<BAJFMCIDGOK> PCNOCBANFOO_ExResult = new List<BAJFMCIDGOK>(3); // 0x80
		public List<KJGBJBLMBJN> CCKMLNLMLFC_Rivals = new List<KJGBJBLMBJN>(6); // 0x84
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(50); // 0x88
		public List<AIFGBKMMJGL> FFMHJIJBKEN_Musics = new List<AIFGBKMMJGL>(10); // 0x8C
		public string MPCAGEPEJJJ_Key; // 0x90
		public long EGBOHDFBAPB_End; // 0x98
		public bool IMFBCJOIJKJ_Entry; // 0xA0
		public bool ABBJBPLHFHA_Spurt; // 0xA1
		public int INLNJOGHLJE_Show; // 0xA4
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0xA8

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } //0x12A82A0 DCHHABKOMFP 0x12A82B4 EGGIBMLGCOJ
		public bool CIIBINABMPE_RRcv2 { get { return PCHFOEIJJMM_Crypted == 65; } set { PCHFOEIJJMM_Crypted = (sbyte)(value ? 65 : 126); } } //0x12A82E4 GOIFOCEJNAB 0x12A82F8 PHOFJDEOLAF
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } //0x12A8328 CLGCKBAEJHF 0x12A833C AHFMKDDCFAM
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } //0x12A836C AIBENAPCPJI 0x12A8380 FKKHHKCJEII
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } //0x12A8450 JKHIIAEMMDE 0x12A8468 PFFKLBLEPKB
		public long NFIOKIBPJCJ_Uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x12A84EC NGIDBCKCAMO 0x12A8504 AEHIIPBDNGE
		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_Crypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_Crypted = value ^ ENOBDCFHELD; FBDJBMDEENG_Crypted = value ^ FCEJCHGLFGN; } } //0x12A852C MAFBDLKFHGJ 0x12A853C EPEFBOIALDI
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } //0x12A8550 PBEMPHPDDDB 0x12A8560 MCADMIEOCCF
		public int BINKCNFPHIP_Cls { get { return INDNOJCKAOD_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; INDNOJCKAOD_Crypted = value ^ ENOBDCFHELD; MIMCCOCDMJK_Crypted = value ^ FCEJCHGLFGN; } } //0x12A8578 MBNKNJFEDJH 0x12A8588 EBNGKIMILNB
		public int LCPFENLEALH_Clsu0 { get { return HIPJJHBLLNA_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; HIPJJHBLLNA_Crypted = value ^ ENOBDCFHELD; JIPEIJLHPCC_Crypted = value ^ FCEJCHGLFGN; } } //0x12A85A8 IILMAGDPGBO 0x12A85B8 DILPDKDJBFA
		public int JMGCEEAJNFE_ExPoint { get { return PCFNAIECMHM_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; PCFNAIECMHM_Crypted = value ^ ENOBDCFHELD; FGKIIKDGDNF_Crypted = value ^ FCEJCHGLFGN; } } //0x12A85D8 EIHDMDDLPNE 0x12A85E8 FENLFALHKPI
		public bool NMPBIBEPLDO_ExRival { get { return GGGEOJAOLKN_Crypted != 56; } set { GGGEOJAOLKN_Crypted = (sbyte)(value ? 19 : 56); } } //0x12A8608 GGKHHJOMIPD 0x12A861C BNNJDABPBIC
		public int GBFAOCFOIIM_RvMc { get { return EIGHJEHEOCH_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; EIGHJEHEOCH_Crypted = value ^ ENOBDCFHELD; OICKANODJBO_Crypted = value ^ FCEJCHGLFGN; } } //0x12A864C LMNPOPPNLKL 0x12A865C IBFECOHDEDM
		public int MNLJJDJHJPM_RvSt { get { return MEAHAGDHJEK_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; MEAHAGDHJEK_Crypted = value ^ ENOBDCFHELD; MAAOPMFJCLP_Crypted = value ^ FCEJCHGLFGN; } } //0x12A867C OPHIPEIMEOC 0x12A868C MCNAEENHMHO

		// // RVA: 0x12A83B0 Offset: 0x12A83B0 VA: 0x12A83B0
		// public bool AAIKMLIKIEB(int LHJCOPMMIGO) { }

		// // RVA: 0x12A83EC Offset: 0x12A83EC VA: 0x12A83EC
		public void LHAEPPFACOB(bool OAFPGJLCNFM, int LHJCOPMMIGO)
		{
			if(LHJCOPMMIGO == 1)
			{
				CIIBINABMPE_RRcv2 = OAFPGJLCNFM;
			}
			else if(LHJCOPMMIGO == 0)
			{
				HPLMECLKFID_RRcv = OAFPGJLCNFM;
			}
		}

		// // RVA: 0x12A86AC Offset: 0x12A86AC VA: 0x12A86AC
		public bool BHIAKGKHKGD_GetReceived(int BMBBDIAEOMP)
		{
			return LCDIGDMGPGO_TRcv[BMBBDIAEOMP] != 20;
		}

		// // RVA: 0x12A873C Offset: 0x12A873C VA: 0x12A873C
		public void IPNLHCLFIDB(int BMBBDIAEOMP, bool JKDJCFEBDHC)
		{
			LCDIGDMGPGO_TRcv[BMBBDIAEOMP] = (sbyte)(JKDJCFEBDHC ? 40 : 20);
		}

		// // RVA: 0x12A87D0 Offset: 0x12A87D0 VA: 0x12A87D0
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_End = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			OKEJGGCMAAI_PlaRcv = false;
			HPLMECLKFID_RRcv = false;
			CIIBINABMPE_RRcv2 = false;
			CGMMMJCIDFE_EpaRcv = false;
			LGADCGFMLLD_Step = 0;
			INLNJOGHLJE_Show = 0;
			MDADLCOCEBN_SessionId = "";
			LFCCCLPFJMB_LastFId = 0;
			OMCAOJJGOGG_Lb = 0;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_Uptime = 0;
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
				LCDIGDMGPGO_TRcv.Add(20);
			NNMPGOAGEOL_Quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			CCKMLNLMLFC_Rivals = new List<KJGBJBLMBJN>(6);
			for(int i = 0; i < 6; i++)
			{
				KJGBJBLMBJN data = new KJGBJBLMBJN();
				data.LHPDDGIJKNB();
				CCKMLNLMLFC_Rivals.Add(data);
				k *= 14;
			}
			FFMHJIJBKEN_Musics.Clear();
			for(int i = 0; i < 10; i++)
			{
				AIFGBKMMJGL data = new AIFGBKMMJGL();
				data.LHPDDGIJKNB_Reset();
				FFMHJIJBKEN_Musics.Add(data);
			}
			NMPBIBEPLDO_ExRival = false;
			BINKCNFPHIP_Cls = 0;
			LCPFENLEALH_Clsu0 = 0;
			JMGCEEAJNFE_ExPoint = 0;
			MNLJJDJHJPM_RvSt = 0;
			GBFAOCFOIIM_RvMc = 4;
			PCNOCBANFOO_ExResult = new List<BAJFMCIDGOK>(3);
			for(int i = 0; i < 3; i++)
			{
				BAJFMCIDGOK data = new BAJFMCIDGOK();
				data.LHPDDGIJKNB(k);
				PCNOCBANFOO_ExResult.Add(data);
				k *= 15;
			}
		}

		// // RVA: 0x12A8CE4 Offset: 0x12A8CE4 VA: 0x12A8CE4
		public void ODDIHGPONFL(BHIDLKBIJFK GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			CIIBINABMPE_RRcv2 = GPBJHKLFCEP.CIIBINABMPE_RRcv2;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			NFIOKIBPJCJ_Uptime = GPBJHKLFCEP.NFIOKIBPJCJ_Uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			MDADLCOCEBN_SessionId = GPBJHKLFCEP.MDADLCOCEBN_SessionId;
			LFCCCLPFJMB_LastFId = GPBJHKLFCEP.LFCCCLPFJMB_LastFId;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			for(int i = 0; i < 6; i++)
			{
				CCKMLNLMLFC_Rivals[i].ODDIHGPONFL(GPBJHKLFCEP.CCKMLNLMLFC_Rivals[i]);
			}
			for(int i = 0; i < 10; i++)
			{
				FFMHJIJBKEN_Musics[i].ODDIHGPONFL(GPBJHKLFCEP.FFMHJIJBKEN_Musics[i]);
			}
			BINKCNFPHIP_Cls = GPBJHKLFCEP.BINKCNFPHIP_Cls;
			LCPFENLEALH_Clsu0 = GPBJHKLFCEP.LCPFENLEALH_Clsu0;
			JMGCEEAJNFE_ExPoint = GPBJHKLFCEP.JMGCEEAJNFE_ExPoint;
			NMPBIBEPLDO_ExRival = GPBJHKLFCEP.NMPBIBEPLDO_ExRival;
			GBFAOCFOIIM_RvMc = GPBJHKLFCEP.GBFAOCFOIIM_RvMc;
			MNLJJDJHJPM_RvSt = GPBJHKLFCEP.MNLJJDJHJPM_RvSt;
			for(int i = 0; i < 3; i++)
			{
				PCNOCBANFOO_ExResult[i].ODDIHGPONFL(GPBJHKLFCEP.PCNOCBANFOO_ExResult[i]);
			}
		}

		// // RVA: 0x12A93B8 Offset: 0x12A93B8 VA: 0x12A93B8
		public bool AGBOGBEOFME(BHIDLKBIJFK OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(OKEJGGCMAAI_PlaRcv != OIKJFMGEICL.OKEJGGCMAAI_PlaRcv)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(CIIBINABMPE_RRcv2 != OIKJFMGEICL.CIIBINABMPE_RRcv2)
				return false;
			if(CGMMMJCIDFE_EpaRcv != OIKJFMGEICL.CGMMMJCIDFE_EpaRcv)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			if(LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step)
				return false;
			if(NFIOKIBPJCJ_Uptime != OIKJFMGEICL.NFIOKIBPJCJ_Uptime)
				return false;
			if(LFCCCLPFJMB_LastFId != OIKJFMGEICL.LFCCCLPFJMB_LastFId)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(BINKCNFPHIP_Cls != OIKJFMGEICL.BINKCNFPHIP_Cls)
				return false;
			if(LCPFENLEALH_Clsu0 != OIKJFMGEICL.LCPFENLEALH_Clsu0)
				return false;
			if(JMGCEEAJNFE_ExPoint != OIKJFMGEICL.JMGCEEAJNFE_ExPoint)
				return false;
			if(NMPBIBEPLDO_ExRival != OIKJFMGEICL.NMPBIBEPLDO_ExRival)
				return false;
			if(GBFAOCFOIIM_RvMc != OIKJFMGEICL.GBFAOCFOIIM_RvMc)
				return false;
			if(MNLJJDJHJPM_RvSt != OIKJFMGEICL.MNLJJDJHJPM_RvSt)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			for(int i = 0; i < 6; i++)
			{
				if(!CCKMLNLMLFC_Rivals[i].AGBOGBEOFME(OIKJFMGEICL.CCKMLNLMLFC_Rivals[i]))
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(!FFMHJIJBKEN_Musics[i].AGBOGBEOFME(OIKJFMGEICL.FFMHJIJBKEN_Musics[i]))
					return false;
			}
			for(int i = 0; i < 3; i++)
			{
				if(!PCNOCBANFOO_ExResult[i].AGBOGBEOFME(OIKJFMGEICL.PCNOCBANFOO_ExResult[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0x12A9BD4 Offset: 0x12A9BD4 VA: 0x12A9BD4
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, CCPKHBECNLH.BHIDLKBIJFK OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int BJEPEBMLKOL = 50;
	public const long EGHFCEBIGEE = 99999999;
	public const int MBPDCHNOEIM = 6;
	public const int BHCKAPNMBNE = 3;
	public const int EGOLNNPNJCA = 10;
	public const int KKBHHBGCNJO = 5;
	public List<BHIDLKBIJFK> FBCJICEPLED = new List<BHIDLKBIJFK>(); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x190F0E0 NFKFOODCJJB

	// // RVA: 0x190A2E4 Offset: 0x190A2E4 VA: 0x190A2E4
	public CCPKHBECNLH_EventBattle()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x190A380 Offset: 0x190A380 VA: 0x190A380 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			BHIDLKBIJFK data = new BHIDLKBIJFK();
			data.LHPDDGIJKNB_Reset();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x190A470 Offset: 0x190A470 VA: 0x190A470 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].LCDIGDMGPGO_TRcv.Count; j++)
			{
				data2.Add(FBCJICEPLED[i].BHIAKGKHKGD_GetReceived(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].NNMPGOAGEOL_Quests.Count; j++)
			{
				data3.Add(FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data4[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data4[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_Point;
			data4[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_Uptime;
			data4[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv ? 1 : 0;
			data4["r_rcv2"] = FBCJICEPLED[i].CIIBINABMPE_RRcv2 ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data2;
			data4[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_Step;
			data4[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data3;
			data4["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data4["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data4[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_SessionId;
			data4["last_f_id"] = FBCJICEPLED[i].LFCCCLPFJMB_LastFId;
			data4["cls"] = FBCJICEPLED[i].BINKCNFPHIP_Cls;
			data4["clsu0"] = FBCJICEPLED[i].LCPFENLEALH_Clsu0;
			data4["ex_pt"] = FBCJICEPLED[i].JMGCEEAJNFE_ExPoint;
			data4["ex_rv"] = FBCJICEPLED[i].NMPBIBEPLDO_ExRival ? 1 : 0;
			data4["rv_mc"] = FBCJICEPLED[i].GBFAOCFOIIM_RvMc;
			data4["rv_st"] = FBCJICEPLED[i].MNLJJDJHJPM_RvSt;
			data4["pla_rcv"] = FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv ? 1 : 0;
			data4["epa_rcv"] = FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv ? 1 : 0;
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 6; j++)
			{
				data5.Add(FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].OKJPIBHMKMJ());
			}
			data4["rivals"] = data5;
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data6.Add(FBCJICEPLED[i].FFMHJIJBKEN_Musics[j].OKJPIBHMKMJ());
			}
			data4["music"] = data6;
			data.Add(data4);
			EDOHBJAPLPF_JsonData data7 = new EDOHBJAPLPF_JsonData();
			data7.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 3; j++)
			{
				data7.Add(FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].OKJPIBHMKMJ());
			}
			data4["ex_result"] = data7;
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

	// // RVA: 0x190C288 Offset: 0x190C288 VA: 0x190C288 Slot: 6
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
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CIIBINABMPE_RRcv2 = CJAENOMGPDA_ReadInt(block[i], "r_rcv2", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_ReadInt(block[i], "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_ReadInt(block[i], "epa_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].LFCCCLPFJMB_LastFId = CJAENOMGPDA_ReadInt(block[i], "last_f_id", 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(block[i], "lb", 0, ref isInvalid);
						FBCJICEPLED[i].BINKCNFPHIP_Cls = CJAENOMGPDA_ReadInt(block[i], "cls", 0, ref isInvalid);
						FBCJICEPLED[i].LCPFENLEALH_Clsu0 = CJAENOMGPDA_ReadInt(block[i], "clsu0", 0, ref isInvalid);
						FBCJICEPLED[i].JMGCEEAJNFE_ExPoint = CJAENOMGPDA_ReadInt(block[i], "ex_pt", 0, ref isInvalid);
						FBCJICEPLED[i].NMPBIBEPLDO_ExRival = CJAENOMGPDA_ReadInt(block[i], "ex_rv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].GBFAOCFOIIM_RvMc = CJAENOMGPDA_ReadInt(block[i], "rv_mc", 0, ref isInvalid);
						FBCJICEPLED[i].MNLJJDJHJPM_RvSt = CJAENOMGPDA_ReadInt(block[i], "rv_st", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x190F0E8
							FBCJICEPLED[i].IPNLHCLFIDB(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData data = block[i][AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 50)
							{
								cnt2 = 50;
							}
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(data[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
							}
						}
						if(block[i].BBAJPINMOEP_Contains("rivals"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["rivals"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 6)
							{
								cnt2 = 6;
							}
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].HBODCMLFDOB.IIEMACPEEBJ(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data[j], ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].OPFGFINHFCE_Name = FGCNMLBACGO_ReadString(data[j], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, "", ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].PBJLLAOJMAK_PId = CJAENOMGPDA_ReadInt(data[j], "pid", 0, ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].BHCIFFILAKJ_Strg = CJAENOMGPDA_ReadInt(data[j], "strg", 0, ref isInvalid);
							}
						}
						if(block[i].BBAJPINMOEP_Contains("music"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["music"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 10)
							{
								cnt2 = 10;
							}
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].FFMHJIJBKEN_Musics[j].IIEMACPEEBJ(data[j], ref isInvalid);
							}
						}
						if(block[i].BBAJPINMOEP_Contains("ex_result"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["ex_result"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 3)
							{
								cnt2 = 3;
							}
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].GOIKCKHMBDL_F = CJAENOMGPDA_ReadInt(data[j], "f", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].KNIFCANOHOC_Sc = CJAENOMGPDA_ReadInt(data[j], "sc", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].JKAMFMNGEBB_Hs = CJAENOMGPDA_ReadInt(data[j], "hs", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].EPKDHJLMKLF_C = CJAENOMGPDA_ReadInt(data[j], "c", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].LJLCKFLJNPC_Bn = CJAENOMGPDA_ReadInt(data[j], "bn", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].CEAEKLNDENC_Ec = CJAENOMGPDA_ReadInt(data[j], "ec", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].FAKIHAPMADE_Ep = CJAENOMGPDA_ReadInt(data[j], "ep", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].PFGLKPNGKLN_Wl = CJAENOMGPDA_ReadInt(data[j], "wl", 0, ref isInvalid) == 1;
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

	// // RVA: 0x190E5C0 Offset: 0x190E5C0 VA: 0x190E5C0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCPKHBECNLH_EventBattle other = GPBJHKLFCEP as CCPKHBECNLH_EventBattle;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x190E794 Offset: 0x190E794 VA: 0x190E794 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCPKHBECNLH_EventBattle other = GPBJHKLFCEP as CCPKHBECNLH_EventBattle;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x190E984 Offset: 0x190E984 VA: 0x190E984 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x190ED98 Offset: 0x190ED98 VA: 0x190ED98 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
