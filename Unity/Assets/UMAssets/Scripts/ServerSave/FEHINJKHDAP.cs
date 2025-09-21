
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use FEHINJKHDAP_EventScore", true)]
public class FEHINJKHDAP { }
public class FEHINJKHDAP_EventScore : KLFDBFMNLBL_ServerSaveBlock
{
	public class ALGDNCMJHGN
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public long AADPAJOLEEF_PointCrypted; // 0x10
		public long IOJOBGHPLIE_PointCrypted; // 0x18
		public long DLEEMCAPOBP_Crypted; // 0x20
		public long JPNMMOEPAEM_Crypted; // 0x28
		public sbyte MLLPMIHMMFL_Crypted; // 0x30
		public List<CEBFFLDKAEC_SecureInt> KNIFCANOHOC_score = new List<CEBFFLDKAEC_SecureInt>(5); // 0x34
		public List<CEBFFLDKAEC_SecureInt> NLKEBAOBJCM_combo = new List<CEBFFLDKAEC_SecureInt>(5); // 0x38
		public List<CEBFFLDKAEC_SecureInt> JNLKJCDFFMM_clear = new List<CEBFFLDKAEC_SecureInt>(5); // 0x3C
		public List<CEBFFLDKAEC_SecureInt> EMHFDJEFIHG_Play = new List<CEBFFLDKAEC_SecureInt>(5); // 0x40
		public List<sbyte> LAMCCNAKIOJ_ComboRank = new List<sbyte>(5); // 0x44
		public List<byte> HNDPLCDMOJF_RewardClear = new List<byte>(5); // 0x48
		public List<byte> JDIDBMEMKBC_RewardScore = new List<byte>(5); // 0x4C
		public List<byte> AGGFHNMMGMN_RewardCombo = new List<byte>(5); // 0x50
		public List<CEBFFLDKAEC_SecureInt> HAFFCOKJHBN_ScoreL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x54
		public List<CEBFFLDKAEC_SecureInt> DNIGPFPHJAK_ComboL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x58
		public List<CEBFFLDKAEC_SecureInt> DPPCFFFNBGA_ClearL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x5C
		public List<CEBFFLDKAEC_SecureInt> FHFKOGIPAEH_PlayL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x60
		public List<sbyte> EEECMKPLPNL_ComboRankL6 = new List<sbyte>(5); // 0x64
		public List<byte> LGBKKDOLOFP_RewardClearL6 = new List<byte>(5); // 0x68
		public List<byte> DKIIINIEKHP_RewardScoreL6 = new List<byte>(5); // 0x6C
		public List<byte> JNNIOJIDNKM_RewardComboL6 = new List<byte>(5); // 0x70
		public int ODEHJGPDFCL_Score; // 0x74
		public int PDNJGJNGPNJ_MaxCombo; // 0x78
		public int ANDJNPEINGI_TeamLuck; // 0x7C
		public int ABFNAEKEGOB_ComboRank; // 0x80
		public List<int> BKJPGJJAODB; // 0x84
		private int JDFAEOFJLAD_ExcellentScoreCrypted; // 0x88
		public string MPCAGEPEJJJ_Key; // 0x8C
		public long EGBOHDFBAPB_CloseAt; // 0x90
		public bool IMFBCJOIJKJ_Entry; // 0x98
		public int INLNJOGHLJE_Show; // 0x9C
		public int EHDDADDKMFI_f_id; // 0xA0

		public int ECLDABOLHLM_ExcellentScore { get { return JDFAEOFJLAD_ExcellentScoreCrypted ^ ENOBDCFHELD; } set {  JDFAEOFJLAD_ExcellentScoreCrypted = value ^ ENOBDCFHELD; } } //0x14CCB58 HPPGLGDLIMM 0x14CCB68 ELFABLKMCMK
		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113: 50); } } //0x14CCB78 DCHHABKOMFP 0x14CCB8C EGGIBMLGCOJ
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_PointCrypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999: value; AADPAJOLEEF_PointCrypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } //0x14CCBBC JKHIIAEMMDE 0x14CCBD4 PFFKLBLEPKB
		public long NFIOKIBPJCJ_uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x14CCC58 NGIDBCKCAMO 0x14CCC70 AEHIIPBDNGE

		//// RVA: 0x14CCC98 Offset: 0x14CCC98 VA: 0x14CCC98
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_CloseAt = 0;
			IMFBCJOIJKJ_Entry = false;
			HPLMECLKFID_RRcv = false;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_uptime = 0;
			KNIFCANOHOC_score.Clear();
			NLKEBAOBJCM_combo.Clear();
			JNLKJCDFFMM_clear.Clear();
			EMHFDJEFIHG_Play.Clear();
			LAMCCNAKIOJ_ComboRank.Clear();
			HNDPLCDMOJF_RewardClear.Clear();
			JDIDBMEMKBC_RewardScore.Clear();
			AGGFHNMMGMN_RewardCombo.Clear();
			HAFFCOKJHBN_ScoreL6.Clear();
			DNIGPFPHJAK_ComboL6.Clear();
			DPPCFFFNBGA_ClearL6.Clear();
			FHFKOGIPAEH_PlayL6.Clear();
			EEECMKPLPNL_ComboRankL6.Clear();
			LGBKKDOLOFP_RewardClearL6.Clear();
			DKIIINIEKHP_RewardScoreL6.Clear();
			JNNIOJIDNKM_RewardComboL6.Clear();
			INLNJOGHLJE_Show = 0;
			int k = FCEJCHGLFGN * 18;
			BKJPGJJAODB = null;
			ECLDABOLHLM_ExcellentScore = 0;
			for(int i = 0; i < 5; i++)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				KNIFCANOHOC_score.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				NLKEBAOBJCM_combo.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				JNLKJCDFFMM_clear.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				EMHFDJEFIHG_Play.Add(v);
				JDIDBMEMKBC_RewardScore.Add(0);
				AGGFHNMMGMN_RewardCombo.Add(0);
				HNDPLCDMOJF_RewardClear.Add(0);
				LAMCCNAKIOJ_ComboRank.Add(0);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				HAFFCOKJHBN_ScoreL6.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				DNIGPFPHJAK_ComboL6.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				DPPCFFFNBGA_ClearL6.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				FHFKOGIPAEH_PlayL6.Add(v);
				DKIIINIEKHP_RewardScoreL6.Add(0);
				JNNIOJIDNKM_RewardComboL6.Add(0);
				LGBKKDOLOFP_RewardClearL6.Add(0);
				EEECMKPLPNL_ComboRankL6.Add(0);
			}
		}

		//// RVA: 0x14CD67C Offset: 0x14CD67C VA: 0x14CD67C
		public void ODDIHGPONFL_Copy(ALGDNCMJHGN GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_CloseAt = GPBJHKLFCEP.EGBOHDFBAPB_CloseAt;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			NFIOKIBPJCJ_uptime = GPBJHKLFCEP.NFIOKIBPJCJ_uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			for(int i = 0; i < 5; i++)
			{
				KNIFCANOHOC_score[i].DNJEJEANJGL_Value = GPBJHKLFCEP.KNIFCANOHOC_score[i].DNJEJEANJGL_Value;
				NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value = GPBJHKLFCEP.NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value;
				JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value = GPBJHKLFCEP.JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value;
				EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value = GPBJHKLFCEP.EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value;
				JDIDBMEMKBC_RewardScore[i] = GPBJHKLFCEP.JDIDBMEMKBC_RewardScore[i];
				AGGFHNMMGMN_RewardCombo[i] = GPBJHKLFCEP.AGGFHNMMGMN_RewardCombo[i];
				HNDPLCDMOJF_RewardClear[i] = GPBJHKLFCEP.HNDPLCDMOJF_RewardClear[i];
				LAMCCNAKIOJ_ComboRank[i] = GPBJHKLFCEP.LAMCCNAKIOJ_ComboRank[i];
				HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value;
				DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value;
				DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value;
				FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value;
				DKIIINIEKHP_RewardScoreL6[i] = GPBJHKLFCEP.DKIIINIEKHP_RewardScoreL6[i];
				JNNIOJIDNKM_RewardComboL6[i] = GPBJHKLFCEP.JNNIOJIDNKM_RewardComboL6[i];
				LGBKKDOLOFP_RewardClearL6[i] = GPBJHKLFCEP.LGBKKDOLOFP_RewardClearL6[i];
				EEECMKPLPNL_ComboRankL6[i] = GPBJHKLFCEP.EEECMKPLPNL_ComboRankL6[i];
			}
		}

		//// RVA: 0x14CE1E4 Offset: 0x14CE1E4 VA: 0x14CE1E4
		public bool AGBOGBEOFME(ALGDNCMJHGN OIKJFMGEICL)
		{
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(EGBOHDFBAPB_CloseAt != OIKJFMGEICL.EGBOHDFBAPB_CloseAt)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(NFIOKIBPJCJ_uptime != OIKJFMGEICL.NFIOKIBPJCJ_uptime)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(KNIFCANOHOC_score[i].DNJEJEANJGL_Value != OIKJFMGEICL.KNIFCANOHOC_score[i].DNJEJEANJGL_Value)
					return false;
				if(NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value != OIKJFMGEICL.NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value)
					return false;
				if(JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value != OIKJFMGEICL.JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value)
					return false;
				if(EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value != OIKJFMGEICL.EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value)
					return false;
				if(JDIDBMEMKBC_RewardScore[i] != OIKJFMGEICL.JDIDBMEMKBC_RewardScore[i])
					return false;
				if(AGGFHNMMGMN_RewardCombo[i] != OIKJFMGEICL.AGGFHNMMGMN_RewardCombo[i])
					return false;
				if(HNDPLCDMOJF_RewardClear[i] != OIKJFMGEICL.HNDPLCDMOJF_RewardClear[i])
					return false;
				if(LAMCCNAKIOJ_ComboRank[i] != OIKJFMGEICL.LAMCCNAKIOJ_ComboRank[i])
					return false;
				if(HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value)
					return false;
				if(DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value)
					return false;
				if(DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value)
					return false;
				if(FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value)
					return false;
				if(DKIIINIEKHP_RewardScoreL6[i] != OIKJFMGEICL.DKIIINIEKHP_RewardScoreL6[i])
					return false;
				if(JNNIOJIDNKM_RewardComboL6[i] != OIKJFMGEICL.JNNIOJIDNKM_RewardComboL6[i])
					return false;
				if(LGBKKDOLOFP_RewardClearL6[i] != OIKJFMGEICL.LGBKKDOLOFP_RewardClearL6[i])
					return false;
				if(EEECMKPLPNL_ComboRankL6[i] != OIKJFMGEICL.EEECMKPLPNL_ComboRankL6[i])
					return false;
			}
			return true;
		}

		//// RVA: 0x14CEE58 Offset: 0x14CEE58 VA: 0x14CEE58
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, FEHINJKHDAP.ALGDNCMJHGN _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }

		//// RVA: 0x14D43F4 Offset: 0x14D43F4 VA: 0x14D43F4
		public void IOONPJENLOJ(JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo GPBJHKLFCEP)
		{
			for(int i = 0; i < 5; i++)
			{
				KNIFCANOHOC_score[i].DNJEJEANJGL_Value = GPBJHKLFCEP.BDCAICINCKK_GetScoreForDiff(i);
				NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value = GPBJHKLFCEP.NLKEBAOBJCM_combo[i];
				JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value = GPBJHKLFCEP.JNLKJCDFFMM_clear[i];
				EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value = GPBJHKLFCEP.EMHFDJEFIHG_Play[i];
				LAMCCNAKIOJ_ComboRank[i] = GPBJHKLFCEP.LAMCCNAKIOJ_ComboRank[i];
				HNDPLCDMOJF_RewardClear[i] = GPBJHKLFCEP.HNDPLCDMOJF_RewardClear[i];
				JDIDBMEMKBC_RewardScore[i] = GPBJHKLFCEP.JDIDBMEMKBC_RewardScore[i];
				AGGFHNMMGMN_RewardCombo[i] = GPBJHKLFCEP.AGGFHNMMGMN_RewardCombo[i];
				HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
				DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DNIGPFPHJAK_ComboL6[i];
				DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DPPCFFFNBGA_ClearL6[i];
				FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.FHFKOGIPAEH_PlayL6[i];
				EEECMKPLPNL_ComboRankL6[i] = GPBJHKLFCEP.EEECMKPLPNL_ComboRankL6[i];
				LGBKKDOLOFP_RewardClearL6[i] = GPBJHKLFCEP.LGBKKDOLOFP_RewardClearL6[i];
				DKIIINIEKHP_RewardScoreL6[i] = GPBJHKLFCEP.DKIIINIEKHP_RewardScoreL6[i];
				JNNIOJIDNKM_RewardComboL6[i] = GPBJHKLFCEP.JNNIOJIDNKM_RewardComboL6[i];
			}
			ODEHJGPDFCL_Score = GPBJHKLFCEP.ODEHJGPDFCL_Score;
			PDNJGJNGPNJ_MaxCombo = GPBJHKLFCEP.PDNJGJNGPNJ_MaxCombo;
			ANDJNPEINGI_TeamLuck = GPBJHKLFCEP.ANDJNPEINGI_TeamLuck;
			ABFNAEKEGOB_ComboRank = GPBJHKLFCEP.ABFNAEKEGOB_ComboRank;
			ECLDABOLHLM_ExcellentScore = GPBJHKLFCEP.ECLDABOLHLM_ExcellentScore;
			BKJPGJJAODB = GPBJHKLFCEP.BKJPGJJAODB;
		}

		//// RVA: 0x14D4F08 Offset: 0x14D4F08 VA: 0x14D4F08
		public JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo KJAFPNIFPGP()
		{
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo res = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
			for(int i = 0; i < 5; i++)
			{
				res.ECKFCIHPHGJ_SetScore_ForDiff(i, KNIFCANOHOC_score[i].DNJEJEANJGL_Value);
				res.NLKEBAOBJCM_combo[i] = NLKEBAOBJCM_combo[i].DNJEJEANJGL_Value;
				res.JNLKJCDFFMM_clear[i] = JNLKJCDFFMM_clear[i].DNJEJEANJGL_Value;
				res.EMHFDJEFIHG_Play[i] = EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value;
				res.LAMCCNAKIOJ_ComboRank[i] = LAMCCNAKIOJ_ComboRank[i];
				res.HNDPLCDMOJF_RewardClear[i] = HNDPLCDMOJF_RewardClear[i];
				res.JDIDBMEMKBC_RewardScore[i] = JDIDBMEMKBC_RewardScore[i];
				res.AGGFHNMMGMN_RewardCombo[i] = AGGFHNMMGMN_RewardCombo[i];
				res.AAELOPLDBPF_SetScoreL6_ForDiff(i, HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value);
				res.DNIGPFPHJAK_ComboL6[i] = DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value;
				res.DPPCFFFNBGA_ClearL6[i] = DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value;
				res.FHFKOGIPAEH_PlayL6[i] = FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value;
				res.EEECMKPLPNL_ComboRankL6[i] = EEECMKPLPNL_ComboRankL6[i];
				res.LGBKKDOLOFP_RewardClearL6[i] = LGBKKDOLOFP_RewardClearL6[i];
				res.DKIIINIEKHP_RewardScoreL6[i] = DKIIINIEKHP_RewardScoreL6[i];
				res.JNNIOJIDNKM_RewardComboL6[i] = JNNIOJIDNKM_RewardComboL6[i];
			}
			res.ODEHJGPDFCL_Score = ODEHJGPDFCL_Score;
			res.PDNJGJNGPNJ_MaxCombo = PDNJGJNGPNJ_MaxCombo;
			res.ANDJNPEINGI_TeamLuck = ANDJNPEINGI_TeamLuck;
			res.ABFNAEKEGOB_ComboRank = ABFNAEKEGOB_ComboRank;
			res.ECLDABOLHLM_ExcellentScore = ECLDABOLHLM_ExcellentScore;
			return res;
		}
	}
	private const int ECFEMKGFDCE = 2;
	public const int ICHFGGBPCBJ = 6;
	public const int KKBHHBGCNJO = 5;
	public const long EGHFCEBIGEE = 99999999;
	public List<ALGDNCMJHGN> FBCJICEPLED = new List<ALGDNCMJHGN>(6); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0xFD6278 NFKFOODCJJB

	// // RVA: 0xFD2E00 Offset: 0xFD2E00 VA: 0xFD2E00
	public FEHINJKHDAP_EventScore()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0xFD2E9C Offset: 0xFD2E9C VA: 0xFD2E9C Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 6; i++)
		{
			ALGDNCMJHGN data = new ALGDNCMJHGN();
			data.LHPDDGIJKNB_Reset();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0xFD2F8C Offset: 0xFD2F8C VA: 0xFD2F8C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 6; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data2[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_CloseAt;
			data2[AFEHLCGHAEE_Strings.CDMGDFLPPHN_Entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data2[AFEHLCGHAEE_Strings.DNBFMLBNAEE_Point] = FBCJICEPLED[i].DNBFMLBNAEE_Point;
			data2[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_uptime;
			data2["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data2[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv;
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data7 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data8 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data9 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data10 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data11 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data7.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data8.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data9.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data10.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data11.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 5; j++)
			{
				data3.Add(FBCJICEPLED[i].KNIFCANOHOC_score[j].DNJEJEANJGL_Value);
				data4.Add(FBCJICEPLED[i].JNLKJCDFFMM_clear[j].DNJEJEANJGL_Value);
				data5.Add(FBCJICEPLED[i].EMHFDJEFIHG_Play[j].DNJEJEANJGL_Value);
				data6.Add(FBCJICEPLED[i].NLKEBAOBJCM_combo[j].DNJEJEANJGL_Value);
				data7.Add((int)FBCJICEPLED[i].HNDPLCDMOJF_RewardClear[j]);
				data8.Add((int)FBCJICEPLED[i].JDIDBMEMKBC_RewardScore[j]);
				data9.Add((int)FBCJICEPLED[i].AGGFHNMMGMN_RewardCombo[j]);
				data10.Add((int)FBCJICEPLED[i].LAMCCNAKIOJ_ComboRank[j]);
			}
			data2[AFEHLCGHAEE_Strings.KNIFCANOHOC_score] = data3;
			data2[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear] = data4;
			data2[AFEHLCGHAEE_Strings.EMHFDJEFIHG_Play] = data5;
			data2[AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo] = data6;
			data2[AFEHLCGHAEE_Strings.ACBIPLOOEKI_rwd_clr] = data7;
			data2[AFEHLCGHAEE_Strings.LKCHLHEOHFF_rwd_sc] = data8;
			data2[AFEHLCGHAEE_Strings.GNHMCCLFBLB_rwd_cb] = data9;
			data2[AFEHLCGHAEE_Strings.IMEPEOAFIIB_ComboRank] = data10;

			data3 = new EDOHBJAPLPF_JsonData();
			data4 = new EDOHBJAPLPF_JsonData();
			data5 = new EDOHBJAPLPF_JsonData();
			data6 = new EDOHBJAPLPF_JsonData();
			data7 = new EDOHBJAPLPF_JsonData();
			data8 = new EDOHBJAPLPF_JsonData();
			data9 = new EDOHBJAPLPF_JsonData();
			data10 = new EDOHBJAPLPF_JsonData();
			data11 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data7.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data8.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data9.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data10.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data11.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 5; j++)
			{
				data3.Add(FBCJICEPLED[i].HAFFCOKJHBN_ScoreL6[j].DNJEJEANJGL_Value);
				data4.Add(FBCJICEPLED[i].DPPCFFFNBGA_ClearL6[j].DNJEJEANJGL_Value);
				data5.Add(FBCJICEPLED[i].FHFKOGIPAEH_PlayL6[j].DNJEJEANJGL_Value);
				data6.Add(FBCJICEPLED[i].DNIGPFPHJAK_ComboL6[j].DNJEJEANJGL_Value);
				data7.Add((int)FBCJICEPLED[i].LGBKKDOLOFP_RewardClearL6[j]);
				data8.Add((int)FBCJICEPLED[i].DKIIINIEKHP_RewardScoreL6[j]);
				data9.Add((int)FBCJICEPLED[i].JNNIOJIDNKM_RewardComboL6[j]);
				data10.Add((int)FBCJICEPLED[i].EEECMKPLPNL_ComboRankL6[j]);
			}
			data2["score_l6"] = data3;
			data2["clear_l6"] = data4;
			data2["play_l6"] = data5;
			data2["combo_l6"] = data6;
			data2["rwd_clr_l6"] = data7;
			data2["rwd_sc_l6"] = data8;
			data2["rwd_cb_l6"] = data9;
			data2["cbrnk_l6"] = data10;
			data.Add(data2);
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

	// // RVA: 0xFD48FC Offset: 0xFD48FC VA: 0xFD48FC Slot: 6
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
					if(cnt >= 7)
					{
						isInvalid = true;
						cnt = 6;
					}
					for(int i = 0; i < cnt; i++)
					{
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_CloseAt = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_Entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_Point = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_Point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_uptime = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.KNIFCANOHOC_score, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC098
							FBCJICEPLED[i].KNIFCANOHOC_score[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC154
							FBCJICEPLED[i].JNLKJCDFFMM_clear[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.EMHFDJEFIHG_Play, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC210
							FBCJICEPLED[i].EMHFDJEFIHG_Play[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC2CC
							FBCJICEPLED[i].NLKEBAOBJCM_combo[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.ACBIPLOOEKI_rwd_clr, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC388
							FBCJICEPLED[i].HNDPLCDMOJF_RewardClear[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.LKCHLHEOHFF_rwd_sc, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC424
							FBCJICEPLED[i].JDIDBMEMKBC_RewardScore[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.GNHMCCLFBLB_rwd_cb, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC4C0
							FBCJICEPLED[i].AGGFHNMMGMN_RewardCombo[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.IMEPEOAFIIB_ComboRank, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC55C
							FBCJICEPLED[i].LAMCCNAKIOJ_ComboRank[_OIPCCBHIKIA_index] = (sbyte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "score_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC5F8
							FBCJICEPLED[i].HAFFCOKJHBN_ScoreL6[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "clear_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC6B4
							FBCJICEPLED[i].DPPCFFFNBGA_ClearL6[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "play_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC770
							FBCJICEPLED[i].FHFKOGIPAEH_PlayL6[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "combo_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC82C
							FBCJICEPLED[i].DNIGPFPHJAK_ComboL6[_OIPCCBHIKIA_index].DNJEJEANJGL_Value = _JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_clr_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC8E8
							FBCJICEPLED[i].LGBKKDOLOFP_RewardClearL6[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_sc_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CC984
							FBCJICEPLED[i].DKIIINIEKHP_RewardScoreL6[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_cb_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CCA20
							FBCJICEPLED[i].JNNIOJIDNKM_RewardComboL6[_OIPCCBHIKIA_index] = (byte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "cbrnk_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14CCABC
							FBCJICEPLED[i].EEECMKPLPNL_ComboRankL6[_OIPCCBHIKIA_index] = (sbyte)_JBGEEPFKIGG_val;
						}, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xFD55BC Offset: 0xFD55BC VA: 0xFD55BC Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FEHINJKHDAP_EventScore other = GPBJHKLFCEP as FEHINJKHDAP_EventScore;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL_Copy(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0xFD5790 Offset: 0xFD5790 VA: 0xFD5790 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FEHINJKHDAP_EventScore other = GPBJHKLFCEP as FEHINJKHDAP_EventScore;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xFD5980 Offset: 0xFD5980 VA: 0xFD5980 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0xFD5D94 Offset: 0xFD5D94 VA: 0xFD5D94 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
