
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use CCPKHBECNLH_EventBattle", true)]
public class CCPKHBECNLH { }
public class CCPKHBECNLH_EventBattle : KLFDBFMNLBL_ServerSaveBlock
{
	public class AIFGBKMMJGL
	{
		private const int FBGGEFFJJHB_xor = 1744406327; // 0x67f98737
		private List<int> NBOLDNMPJFG_scoreCrypted = new List<int>(5); // 0x8
		public List<int> NLKEBAOBJCM_combo = new List<int>(5); // 0xC
		public List<sbyte> LAMCCNAKIOJ_ComboRank = new List<sbyte>(5); // 0x10
		public List<int> JNLKJCDFFMM_clear = new List<int>(5); // 0x14
		public List<int> EMHFDJEFIHG_play = new List<int>(5); // 0x18
		private List<int> OAAFPCECFMD_ScoreByDiffL6 = new List<int>(5); // 0x1C
		public List<int> DNIGPFPHJAK_ComboL6 = new List<int>(5); // 0x20
		public List<sbyte> EEECMKPLPNL_ComboRankL6 = new List<sbyte>(5); // 0x24
		public List<int> DPPCFFFNBGA_ClearL6 = new List<int>(5); // 0x28
		public List<int> FHFKOGIPAEH_PlayL6 = new List<int>(5); // 0x2C
		private int CJAOMKLHFJL_Crypted = FBGGEFFJJHB_xor; // 0x30
		private int BNPKALPLIJH_Crypted = FBGGEFFJJHB_xor; // 0x34

		public int GOIKCKHMBDL_FreeMusicId { get { return CJAOMKLHFJL_Crypted ^ FBGGEFFJJHB_xor; } set { CJAOMKLHFJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x190F12C BPGCGEDHBEH_get_FreeMusicId 0x190F140 ICPMFBIDFFO_set_FreeMusicId
		public int OFJHABJNGOD_ExcellentScore { get { return BNPKALPLIJH_Crypted ^ FBGGEFFJJHB_xor; } set { BNPKALPLIJH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x190F154 NDBFELIIICL_bgs 0x190F168 BIJLJDDDMLL_bgs

		// // RVA: 0x190F17C Offset: 0x190F17C VA: 0x190F17C
		public int BDCAICINCKK_GetScore(int _AKNELONELJK_difficulty)
		{
			return NBOLDNMPJFG_scoreCrypted[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x190F208 Offset: 0x190F208 VA: 0x190F208
		public void ECKFCIHPHGJ_SetScore(int _AKNELONELJK_difficulty, int _KNIFCANOHOC_score)
		{
			NBOLDNMPJFG_scoreCrypted[_AKNELONELJK_difficulty] = _KNIFCANOHOC_score ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x190F298 Offset: 0x190F298 VA: 0x190F298
		public int AHDKMPFDKPE_GetScoreForDiffL6(int _AKNELONELJK_difficulty)
		{
			return OAAFPCECFMD_ScoreByDiffL6[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x190F324 Offset: 0x190F324 VA: 0x190F324
		public void AAELOPLDBPF_SetScoreForDiffL6(int _AKNELONELJK_difficulty, int _KNIFCANOHOC_score)
		{
			OAAFPCECFMD_ScoreByDiffL6[_AKNELONELJK_difficulty] = _KNIFCANOHOC_score ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x190F3B4 Offset: 0x190F3B4 VA: 0x190F3B4
		public void LHPDDGIJKNB_Reset()
		{
			NBOLDNMPJFG_scoreCrypted.Clear();
			NLKEBAOBJCM_combo.Clear();
			LAMCCNAKIOJ_ComboRank.Clear();
			JNLKJCDFFMM_clear.Clear();
			EMHFDJEFIHG_play.Clear();
			OAAFPCECFMD_ScoreByDiffL6.Clear();
			DNIGPFPHJAK_ComboL6.Clear();
			EEECMKPLPNL_ComboRankL6.Clear();
			DPPCFFFNBGA_ClearL6.Clear();
			FHFKOGIPAEH_PlayL6.Clear();
			for(int i = 0; i < 5; i++)
			{
				NBOLDNMPJFG_scoreCrypted.Add(0);
				ECKFCIHPHGJ_SetScore(i, 0);
				NLKEBAOBJCM_combo.Add(0);
				LAMCCNAKIOJ_ComboRank.Add(0);
				JNLKJCDFFMM_clear.Add(0);
				EMHFDJEFIHG_play.Add(0);
				OAAFPCECFMD_ScoreByDiffL6.Add(0);
				AAELOPLDBPF_SetScoreForDiffL6(i, 0);
				DNIGPFPHJAK_ComboL6.Add(0);
				EEECMKPLPNL_ComboRankL6.Add(0);
				DPPCFFFNBGA_ClearL6.Add(0);
				FHFKOGIPAEH_PlayL6.Add(0);
			}
			GOIKCKHMBDL_FreeMusicId = 0;
			OFJHABJNGOD_ExcellentScore = 0;
		}

		// // RVA: 0x190F810 Offset: 0x190F810 VA: 0x190F810
		public void ODDIHGPONFL_Copy(AIFGBKMMJGL GPBJHKLFCEP)
		{
			for(int i = 0; i < 5; i++)
			{
				ECKFCIHPHGJ_SetScore(i, GPBJHKLFCEP.BDCAICINCKK_GetScore(i));
				NLKEBAOBJCM_combo[i] = GPBJHKLFCEP.NLKEBAOBJCM_combo[i];
				LAMCCNAKIOJ_ComboRank[i] = GPBJHKLFCEP.LAMCCNAKIOJ_ComboRank[i];
				JNLKJCDFFMM_clear[i] = GPBJHKLFCEP.JNLKJCDFFMM_clear[i];
				EMHFDJEFIHG_play[i] = GPBJHKLFCEP.EMHFDJEFIHG_play[i];
				AAELOPLDBPF_SetScoreForDiffL6(i, GPBJHKLFCEP.AHDKMPFDKPE_GetScoreForDiffL6(i));
				DNIGPFPHJAK_ComboL6[i] = GPBJHKLFCEP.DNIGPFPHJAK_ComboL6[i];
				EEECMKPLPNL_ComboRankL6[i] = GPBJHKLFCEP.EEECMKPLPNL_ComboRankL6[i];
				DPPCFFFNBGA_ClearL6[i] = GPBJHKLFCEP.DPPCFFFNBGA_ClearL6[i];
				FHFKOGIPAEH_PlayL6[i] = GPBJHKLFCEP.FHFKOGIPAEH_PlayL6[i];
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
				if(BDCAICINCKK_GetScore(i) != OIKJFMGEICL.BDCAICINCKK_GetScore(i))
					return false;
				if(NLKEBAOBJCM_combo[i] != OIKJFMGEICL.NLKEBAOBJCM_combo[i])
					return false;
				if(LAMCCNAKIOJ_ComboRank[i] != OIKJFMGEICL.LAMCCNAKIOJ_ComboRank[i])
					return false;
				if(JNLKJCDFFMM_clear[i] != OIKJFMGEICL.JNLKJCDFFMM_clear[i])
					return false;
				if(EMHFDJEFIHG_play[i] != OIKJFMGEICL.EMHFDJEFIHG_play[i])
					return false;
				if(AHDKMPFDKPE_GetScoreForDiffL6(i) != OIKJFMGEICL.AHDKMPFDKPE_GetScoreForDiffL6(i))
					return false;
				if(DNIGPFPHJAK_ComboL6[i] != OIKJFMGEICL.DNIGPFPHJAK_ComboL6[i])
					return false;
				if(EEECMKPLPNL_ComboRankL6[i] != OIKJFMGEICL.EEECMKPLPNL_ComboRankL6[i])
					return false;
				if(DPPCFFFNBGA_ClearL6[i] != OIKJFMGEICL.DPPCFFFNBGA_ClearL6[i])
					return false;
				if(FHFKOGIPAEH_PlayL6[i] != OIKJFMGEICL.FHFKOGIPAEH_PlayL6[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1910144 Offset: 0x1910144 VA: 0x1910144
		// public JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo KJAFPNIFPGP() { }

		// // RVA: 0x19106E4 Offset: 0x19106E4 VA: 0x19106E4
		// public void IOONPJENLOJ(JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo GPBJHKLFCEP) { }

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
				data1.Add(BDCAICINCKK_GetScore(i));
				data2.Add(NLKEBAOBJCM_combo[i]);
				data3.Add((int)LAMCCNAKIOJ_ComboRank[i]);
				data4.Add(JNLKJCDFFMM_clear[i]);
				data5.Add(EMHFDJEFIHG_play[i]);
				data6.Add(AHDKMPFDKPE_GetScoreForDiffL6(i));
				data7.Add(DNIGPFPHJAK_ComboL6[i]);
				data8.Add((int)EEECMKPLPNL_ComboRankL6[i]);
				data9.Add(DPPCFFFNBGA_ClearL6[i]);
				data10.Add(FHFKOGIPAEH_PlayL6[i]);
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
		public void IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, ref bool _NGJDHLGMHMH_IsInvalid)
		{
			List<int> l = new List<int>();
			List<int> l2 = new List<int>();
			for(int i = 0; i < 5; i++)
			{
				l.Add(0);
				l2.Add(0);
			}
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.KNIFCANOHOC_score, l);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo, NLKEBAOBJCM_combo);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk, l2);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, JNLKJCDFFMM_clear);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.EMHFDJEFIHG_play, EMHFDJEFIHG_play);
			for(int i = 0; i < 5; i++)
			{
				ECKFCIHPHGJ_SetScore(i, l[i]);
				LAMCCNAKIOJ_ComboRank[i] = (sbyte)l2[i];
				l[i] = 0;
				l2[i] = 0;
			}
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, "score_l6", l);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, "combo_l6", DNIGPFPHJAK_ComboL6);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, "cbrnk_l6", l2);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, "clear_l6", DPPCFFFNBGA_ClearL6);
			_NGJDHLGMHMH_IsInvalid |= HIELDCAFGOC(_IDLHJIOMJBK_data, "play_l6", FHFKOGIPAEH_PlayL6);
			for(int i = 0; i < 5; i++)
			{
				AAELOPLDBPF_SetScoreForDiffL6(i, l[i]);
				EEECMKPLPNL_ComboRankL6[i] = (sbyte)l2[i];
			}
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("f_id"))
			{
				GOIKCKHMBDL_FreeMusicId = (int)_IDLHJIOMJBK_data["f_id"];
			}
			else
			{
				GOIKCKHMBDL_FreeMusicId = 0;
				_NGJDHLGMHMH_IsInvalid = true;
			}
		}

		// // RVA: 0x1910C3C Offset: 0x1910C3C VA: 0x1910C3C
		private static bool HIELDCAFGOC(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, string _PPFNGGCBJKC_id, List<int> NNDGIAEFMOG)
		{
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(_PPFNGGCBJKC_id))
			{
				EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data[_PPFNGGCBJKC_id];
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
		public long AADPAJOLEEF_PointCrypted; // 0x10
		public long IOJOBGHPLIE_PointCrypted; // 0x18
		public long DLEEMCAPOBP_Crypted; // 0x20
		public long JPNMMOEPAEM_Crypted; // 0x28
		public int FOEHHBMNGNK_TicketCrypted; // 0x30
		public int DGFLFPAMNJO_TicketCrypted; // 0x34
		public int AFGHJEJKDHN_StepCrypted; // 0x38
		public int FBDJBMDEENG_StepCrypted2; // 0x3C
		public sbyte MLLPMIHMMFL_Crypted; // 0x40
		public sbyte PCHFOEIJJMM_Crypted; // 0x41
		public string MDADLCOCEBN_session_id; // 0x44
		public int LFCCCLPFJMB_LastFId; // 0x48
		public int HFIHMDILNFD_LbCrypted; // 0x4C
		public int IGMFFIKLEHP_LbCrypted2; // 0x50
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
		public List<IKCGAJKCPFN> NNMPGOAGEOL_quests = new List<IKCGAJKCPFN>(50); // 0x88
		public List<AIFGBKMMJGL> FFMHJIJBKEN_music = new List<AIFGBKMMJGL>(10); // 0x8C
		public string MPCAGEPEJJJ_Key; // 0x90
		public long EGBOHDFBAPB_closed_at; // 0x98
		public bool IMFBCJOIJKJ_Entry; // 0xA0
		public bool ABBJBPLHFHA_Spurt; // 0xA1
		public int INLNJOGHLJE_Show; // 0xA4
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0xA8

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } //0x12A82A0 DCHHABKOMFP_bgs 0x12A82B4 EGGIBMLGCOJ_bgs
		public bool CIIBINABMPE_RRcv2 { get { return PCHFOEIJJMM_Crypted == 65; } set { PCHFOEIJJMM_Crypted = (sbyte)(value ? 65 : 126); } } //0x12A82E4 GOIFOCEJNAB_bgs 0x12A82F8 PHOFJDEOLAF_bgs
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } //0x12A8328 CLGCKBAEJHF_bgs 0x12A833C AHFMKDDCFAM_bgs
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } //0x12A836C AIBENAPCPJI_bgs 0x12A8380 FKKHHKCJEII_bgs
		public long DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_PointCrypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } //0x12A8450 JKHIIAEMMDE_bgs 0x12A8468 PFFKLBLEPKB_bgs
		public long NFIOKIBPJCJ_uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x12A84EC NGIDBCKCAMO_bgs 0x12A8504 AEHIIPBDNGE_bgs
		public int LGADCGFMLLD_step { get { return AFGHJEJKDHN_StepCrypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_StepCrypted = value ^ ENOBDCFHELD; FBDJBMDEENG_StepCrypted2 = value ^ FCEJCHGLFGN; } } //0x12A852C MAFBDLKFHGJ_get_step 0x12A853C EPEFBOIALDI_set_step
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_LbCrypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_LbCrypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_LbCrypted2 = value ^ FCEJCHGLFGN; } } //0x12A8550 PBEMPHPDDDB_get_Lb 0x12A8560 MCADMIEOCCF_set_Lb
		public int BINKCNFPHIP_Cls { get { return INDNOJCKAOD_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; INDNOJCKAOD_Crypted = value ^ ENOBDCFHELD; MIMCCOCDMJK_Crypted = value ^ FCEJCHGLFGN; } } //0x12A8578 MBNKNJFEDJH_bgs 0x12A8588 EBNGKIMILNB_bgs
		public int LCPFENLEALH_Clsu0 { get { return HIPJJHBLLNA_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; HIPJJHBLLNA_Crypted = value ^ ENOBDCFHELD; JIPEIJLHPCC_Crypted = value ^ FCEJCHGLFGN; } } //0x12A85A8 IILMAGDPGBO_bgs 0x12A85B8 DILPDKDJBFA_bgs
		public int JMGCEEAJNFE_ExPoint { get { return PCFNAIECMHM_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; PCFNAIECMHM_Crypted = value ^ ENOBDCFHELD; FGKIIKDGDNF_Crypted = value ^ FCEJCHGLFGN; } } //0x12A85D8 EIHDMDDLPNE_bgs 0x12A85E8 FENLFALHKPI_bgs
		public bool NMPBIBEPLDO_ExRival { get { return GGGEOJAOLKN_Crypted != 56; } set { GGGEOJAOLKN_Crypted = (sbyte)(value ? 19 : 56); } } //0x12A8608 GGKHHJOMIPD_bgs 0x12A861C BNNJDABPBIC_bgs
		public int GBFAOCFOIIM_RvMc { get { return EIGHJEHEOCH_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; EIGHJEHEOCH_Crypted = value ^ ENOBDCFHELD; OICKANODJBO_Crypted = value ^ FCEJCHGLFGN; } } //0x12A864C LMNPOPPNLKL_bgs 0x12A865C IBFECOHDEDM_bgs
		public int MNLJJDJHJPM_RvSt { get { return MEAHAGDHJEK_Crypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; MEAHAGDHJEK_Crypted = value ^ ENOBDCFHELD; MAAOPMFJCLP_Crypted = value ^ FCEJCHGLFGN; } } //0x12A867C OPHIPEIMEOC_bgs 0x12A868C MCNAEENHMHO_bgs

		// // RVA: 0x12A83B0 Offset: 0x12A83B0 VA: 0x12A83B0
		// public bool AAIKMLIKIEB(int LHJCOPMMIGO) { }

		// // RVA: 0x12A83EC Offset: 0x12A83EC VA: 0x12A83EC
		public void LHAEPPFACOB_SetRewardReceived(bool _OAFPGJLCNFM_cond, int LHJCOPMMIGO)
		{
			if(LHJCOPMMIGO == 1)
			{
				CIIBINABMPE_RRcv2 = _OAFPGJLCNFM_cond;
			}
			else if(LHJCOPMMIGO == 0)
			{
				HPLMECLKFID_RRcv = _OAFPGJLCNFM_cond;
			}
		}

		// // RVA: 0x12A86AC Offset: 0x12A86AC VA: 0x12A86AC
		public bool BHIAKGKHKGD_IsReceived(int _BMBBDIAEOMP_i)
		{
			return LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] != 20;
		}

		// // RVA: 0x12A873C Offset: 0x12A873C VA: 0x12A873C
		public void IPNLHCLFIDB_SetRewardReceived(int _BMBBDIAEOMP_i, bool _JKDJCFEBDHC_Enabled)
		{
			LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] = (sbyte)(_JKDJCFEBDHC_Enabled ? 40 : 20);
		}

		// // RVA: 0x12A87D0 Offset: 0x12A87D0 VA: 0x12A87D0
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_closed_at = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			OKEJGGCMAAI_PlaRcv = false;
			HPLMECLKFID_RRcv = false;
			CIIBINABMPE_RRcv2 = false;
			CGMMMJCIDFE_EpaRcv = false;
			LGADCGFMLLD_step = 0;
			INLNJOGHLJE_Show = 0;
			MDADLCOCEBN_session_id = "";
			LFCCCLPFJMB_LastFId = 0;
			OMCAOJJGOGG_Lb = 0;
			DNBFMLBNAEE_point = 0;
			NFIOKIBPJCJ_uptime = 0;
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
				LCDIGDMGPGO_TRcv.Add(20);
			NNMPGOAGEOL_quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB_Reset(i + 1, k);
				NNMPGOAGEOL_quests.Add(ik);
				k *= 13;
			}
			CCKMLNLMLFC_Rivals = new List<KJGBJBLMBJN>(6);
			for(int i = 0; i < 6; i++)
			{
				KJGBJBLMBJN data = new KJGBJBLMBJN();
				data.LHPDDGIJKNB_Reset();
				CCKMLNLMLFC_Rivals.Add(data);
				k *= 14;
			}
			FFMHJIJBKEN_music.Clear();
			for(int i = 0; i < 10; i++)
			{
				AIFGBKMMJGL data = new AIFGBKMMJGL();
				data.LHPDDGIJKNB_Reset();
				FFMHJIJBKEN_music.Add(data);
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
				data.LHPDDGIJKNB_Reset(k);
				PCNOCBANFOO_ExResult.Add(data);
				k *= 15;
			}
		}

		// // RVA: 0x12A8CE4 Offset: 0x12A8CE4 VA: 0x12A8CE4
		public void ODDIHGPONFL_Copy(BHIDLKBIJFK GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_closed_at = GPBJHKLFCEP.EGBOHDFBAPB_closed_at;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			CIIBINABMPE_RRcv2 = GPBJHKLFCEP.CIIBINABMPE_RRcv2;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			DNBFMLBNAEE_point = GPBJHKLFCEP.DNBFMLBNAEE_point;
			LGADCGFMLLD_step = GPBJHKLFCEP.LGADCGFMLLD_step;
			NFIOKIBPJCJ_uptime = GPBJHKLFCEP.NFIOKIBPJCJ_uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			MDADLCOCEBN_session_id = GPBJHKLFCEP.MDADLCOCEBN_session_id;
			LFCCCLPFJMB_LastFId = GPBJHKLFCEP.LFCCCLPFJMB_LastFId;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_quests[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.NNMPGOAGEOL_quests[i]);
			}
			for(int i = 0; i < 6; i++)
			{
				CCKMLNLMLFC_Rivals[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.CCKMLNLMLFC_Rivals[i]);
			}
			for(int i = 0; i < 10; i++)
			{
				FFMHJIJBKEN_music[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.FFMHJIJBKEN_music[i]);
			}
			BINKCNFPHIP_Cls = GPBJHKLFCEP.BINKCNFPHIP_Cls;
			LCPFENLEALH_Clsu0 = GPBJHKLFCEP.LCPFENLEALH_Clsu0;
			JMGCEEAJNFE_ExPoint = GPBJHKLFCEP.JMGCEEAJNFE_ExPoint;
			NMPBIBEPLDO_ExRival = GPBJHKLFCEP.NMPBIBEPLDO_ExRival;
			GBFAOCFOIIM_RvMc = GPBJHKLFCEP.GBFAOCFOIIM_RvMc;
			MNLJJDJHJPM_RvSt = GPBJHKLFCEP.MNLJJDJHJPM_RvSt;
			for(int i = 0; i < 3; i++)
			{
				PCNOCBANFOO_ExResult[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.PCNOCBANFOO_ExResult[i]);
			}
		}

		// // RVA: 0x12A93B8 Offset: 0x12A93B8 VA: 0x12A93B8
		public bool AGBOGBEOFME(BHIDLKBIJFK OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_closed_at != OIKJFMGEICL.EGBOHDFBAPB_closed_at)
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
			if(DNBFMLBNAEE_point != OIKJFMGEICL.DNBFMLBNAEE_point)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			if(LGADCGFMLLD_step != OIKJFMGEICL.LGADCGFMLLD_step)
				return false;
			if(NFIOKIBPJCJ_uptime != OIKJFMGEICL.NFIOKIBPJCJ_uptime)
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
			if(MDADLCOCEBN_session_id != OIKJFMGEICL.MDADLCOCEBN_session_id)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_quests[i]))
					return false;
			}
			for(int i = 0; i < 6; i++)
			{
				if(!CCKMLNLMLFC_Rivals[i].AGBOGBEOFME(OIKJFMGEICL.CCKMLNLMLFC_Rivals[i]))
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(!FFMHJIJBKEN_music[i].AGBOGBEOFME(OIKJFMGEICL.FFMHJIJBKEN_music[i]))
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
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, CCPKHBECNLH_EventBattle.BHIDLKBIJFK _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int BJEPEBMLKOL = 50;
	public const long EGHFCEBIGEE = 99999999;
	public const int MBPDCHNOEIM = 6;
	public const int BHCKAPNMBNE = 3;
	public const int EGOLNNPNJCA = 10;
	public const int KKBHHBGCNJO = 5;
	public List<BHIDLKBIJFK> FBCJICEPLED = new List<BHIDLKBIJFK>(); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x190F0E0 NFKFOODCJJB_bgs

	// // RVA: 0x190A2E4 Offset: 0x190A2E4 VA: 0x190A2E4
	public CCPKHBECNLH_EventBattle()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x190A380 Offset: 0x190A380 VA: 0x190A380 Slot: 4
	public override void KMBPACJNEOF_Reset()
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
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].LCDIGDMGPGO_TRcv.Count; j++)
			{
				data2.Add(FBCJICEPLED[i].BHIAKGKHKGD_IsReceived(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].NNMPGOAGEOL_quests.Count; j++)
			{
				data3.Add(FBCJICEPLED[i].NNMPGOAGEOL_quests[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data4[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_closed_at;
			data4[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_point;
			data4[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_uptime;
			data4[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv ? 1 : 0;
			data4["r_rcv2"] = FBCJICEPLED[i].CIIBINABMPE_RRcv2 ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data2;
			data4[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_step;
			data4[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data3;
			data4["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data4["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data4[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_session_id;
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
				data6.Add(FBCJICEPLED[i].FFMHJIJBKEN_music[j].OKJPIBHMKMJ());
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
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
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
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_GetString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_closed_at = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_point = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_uptime = DKMPHAPBDLH_GetLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].LGADCGFMLLD_step = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_GetInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CIIBINABMPE_RRcv2 = CJAENOMGPDA_GetInt(block[i], "r_rcv2", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_GetInt(block[i], "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_GetInt(block[i], "epa_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_GetInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_session_id = FGCNMLBACGO_GetString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].LFCCCLPFJMB_LastFId = CJAENOMGPDA_GetInt(block[i], "last_f_id", 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_GetInt(block[i], "lb", 0, ref isInvalid);
						FBCJICEPLED[i].BINKCNFPHIP_Cls = CJAENOMGPDA_GetInt(block[i], "cls", 0, ref isInvalid);
						FBCJICEPLED[i].LCPFENLEALH_Clsu0 = CJAENOMGPDA_GetInt(block[i], "clsu0", 0, ref isInvalid);
						FBCJICEPLED[i].JMGCEEAJNFE_ExPoint = CJAENOMGPDA_GetInt(block[i], "ex_pt", 0, ref isInvalid);
						FBCJICEPLED[i].NMPBIBEPLDO_ExRival = CJAENOMGPDA_GetInt(block[i], "ex_rv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].GBFAOCFOIIM_RvMc = CJAENOMGPDA_GetInt(block[i], "rv_mc", 0, ref isInvalid);
						FBCJICEPLED[i].MNLJJDJHJPM_RvSt = CJAENOMGPDA_GetInt(block[i], "rv_st", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x190F0E8
							FBCJICEPLED[i].IPNLHCLFIDB_SetRewardReceived(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val != 0);
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
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].EALOBDHOCHP_stat = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].HMFFHLPNMPH_count = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(data[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_GetInt(data[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
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
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].HBODCMLFDOB_result.IIEMACPEEBJ_Deserialize(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, data[j], ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].OPFGFINHFCE_name = FGCNMLBACGO_GetString(data[j], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, "", ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].PBJLLAOJMAK_PId = CJAENOMGPDA_GetInt(data[j], "pid", 0, ref isInvalid);
								FBCJICEPLED[i].CCKMLNLMLFC_Rivals[j].BHCIFFILAKJ_Strength = CJAENOMGPDA_GetInt(data[j], "strg", 0, ref isInvalid);
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
								FBCJICEPLED[i].FFMHJIJBKEN_music[j].IIEMACPEEBJ_Deserialize(data[j], ref isInvalid);
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
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].GOIKCKHMBDL_FreeMusicId = CJAENOMGPDA_GetInt(data[j], "f", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].KNIFCANOHOC_score = CJAENOMGPDA_GetInt(data[j], "sc", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].JKAMFMNGEBB_high_score = CJAENOMGPDA_GetInt(data[j], "hs", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].EPKDHJLMKLF_C = CJAENOMGPDA_GetInt(data[j], "c", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].LJLCKFLJNPC_Bn = CJAENOMGPDA_GetInt(data[j], "bn", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].CEAEKLNDENC_Ec = CJAENOMGPDA_GetInt(data[j], "ec", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].FAKIHAPMADE_Ep = CJAENOMGPDA_GetInt(data[j], "ep", 0, ref isInvalid);
								FBCJICEPLED[i].PCNOCBANFOO_ExResult[j].PFGLKPNGKLN_Wl = CJAENOMGPDA_GetInt(data[j], "wl", 0, ref isInvalid) == 1;
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
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CCPKHBECNLH_EventBattle other = GPBJHKLFCEP as CCPKHBECNLH_EventBattle;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL_Copy(other.FBCJICEPLED[i]);
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
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x190ED98 Offset: 0x190ED98 VA: 0x190ED98 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
