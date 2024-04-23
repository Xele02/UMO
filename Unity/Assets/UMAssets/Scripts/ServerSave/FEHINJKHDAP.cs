
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
		public long AADPAJOLEEF_Crypted; // 0x10
		public long IOJOBGHPLIE_Crypted; // 0x18
		public long DLEEMCAPOBP_Crypted; // 0x20
		public long JPNMMOEPAEM_Crypted; // 0x28
		public sbyte MLLPMIHMMFL_Crypted; // 0x30
		public List<CEBFFLDKAEC_SecureInt> KNIFCANOHOC_Score = new List<CEBFFLDKAEC_SecureInt>(5); // 0x34
		public List<CEBFFLDKAEC_SecureInt> NLKEBAOBJCM_Combo = new List<CEBFFLDKAEC_SecureInt>(5); // 0x38
		public List<CEBFFLDKAEC_SecureInt> JNLKJCDFFMM_Clear = new List<CEBFFLDKAEC_SecureInt>(5); // 0x3C
		public List<CEBFFLDKAEC_SecureInt> EMHFDJEFIHG_Play = new List<CEBFFLDKAEC_SecureInt>(5); // 0x40
		public List<sbyte> LAMCCNAKIOJ_CbRnk = new List<sbyte>(5); // 0x44
		public List<byte> HNDPLCDMOJF_RwdClr = new List<byte>(5); // 0x48
		public List<byte> JDIDBMEMKBC_RwdSc = new List<byte>(5); // 0x4C
		public List<byte> AGGFHNMMGMN_RwdCb = new List<byte>(5); // 0x50
		public List<CEBFFLDKAEC_SecureInt> HAFFCOKJHBN_ScoreL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x54
		public List<CEBFFLDKAEC_SecureInt> DNIGPFPHJAK_ComboL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x58
		public List<CEBFFLDKAEC_SecureInt> DPPCFFFNBGA_ClearL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x5C
		public List<CEBFFLDKAEC_SecureInt> FHFKOGIPAEH_PlayL6 = new List<CEBFFLDKAEC_SecureInt>(5); // 0x60
		public List<sbyte> EEECMKPLPNL_CbRnkL6 = new List<sbyte>(5); // 0x64
		public List<byte> LGBKKDOLOFP_RwdClrL6 = new List<byte>(5); // 0x68
		public List<byte> DKIIINIEKHP_RwdScL6 = new List<byte>(5); // 0x6C
		public List<byte> JNNIOJIDNKM_RwdCbL6 = new List<byte>(5); // 0x70
		public int ODEHJGPDFCL; // 0x74
		public int PDNJGJNGPNJ; // 0x78
		public int ANDJNPEINGI; // 0x7C
		public int ABFNAEKEGOB; // 0x80
		public List<int> BKJPGJJAODB; // 0x84
		private int JDFAEOFJLAD_Crypted; // 0x88
		public string MPCAGEPEJJJ_Key; // 0x8C
		public long EGBOHDFBAPB_End; // 0x90
		public bool IMFBCJOIJKJ_Entry; // 0x98
		public int INLNJOGHLJE_Show; // 0x9C
		public int EHDDADDKMFI; // 0xA0

		public int ECLDABOLHLM { get { return JDFAEOFJLAD_Crypted ^ ENOBDCFHELD; } set {  JDFAEOFJLAD_Crypted = value ^ ENOBDCFHELD; } } //0x14CCB58 HPPGLGDLIMM 0x14CCB68 ELFABLKMCMK
		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113: 50); } } //0x14CCB78 DCHHABKOMFP 0x14CCB8C EGGIBMLGCOJ
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999: value; AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } //0x14CCBBC JKHIIAEMMDE 0x14CCBD4 PFFKLBLEPKB
		public long NFIOKIBPJCJ_Update { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x14CCC58 NGIDBCKCAMO 0x14CCC70 AEHIIPBDNGE

		//// RVA: 0x14CCC98 Offset: 0x14CCC98 VA: 0x14CCC98
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_End = 0;
			IMFBCJOIJKJ_Entry = false;
			HPLMECLKFID_RRcv = false;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_Update = 0;
			KNIFCANOHOC_Score.Clear();
			NLKEBAOBJCM_Combo.Clear();
			JNLKJCDFFMM_Clear.Clear();
			EMHFDJEFIHG_Play.Clear();
			LAMCCNAKIOJ_CbRnk.Clear();
			HNDPLCDMOJF_RwdClr.Clear();
			JDIDBMEMKBC_RwdSc.Clear();
			AGGFHNMMGMN_RwdCb.Clear();
			HAFFCOKJHBN_ScoreL6.Clear();
			DNIGPFPHJAK_ComboL6.Clear();
			DPPCFFFNBGA_ClearL6.Clear();
			FHFKOGIPAEH_PlayL6.Clear();
			EEECMKPLPNL_CbRnkL6.Clear();
			LGBKKDOLOFP_RwdClrL6.Clear();
			DKIIINIEKHP_RwdScL6.Clear();
			JNNIOJIDNKM_RwdCbL6.Clear();
			INLNJOGHLJE_Show = 0;
			int k = FCEJCHGLFGN * 18;
			BKJPGJJAODB = null;
			ECLDABOLHLM = 0;
			for(int i = 0; i < 5; i++)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				KNIFCANOHOC_Score.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				NLKEBAOBJCM_Combo.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				JNLKJCDFFMM_Clear.Add(v);
				v = new CEBFFLDKAEC_SecureInt();
				v.DNJEJEANJGL_Value = k;
				EMHFDJEFIHG_Play.Add(v);
				JDIDBMEMKBC_RwdSc.Add(0);
				AGGFHNMMGMN_RwdCb.Add(0);
				HNDPLCDMOJF_RwdClr.Add(0);
				LAMCCNAKIOJ_CbRnk.Add(0);
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
				DKIIINIEKHP_RwdScL6.Add(0);
				JNNIOJIDNKM_RwdCbL6.Add(0);
				LGBKKDOLOFP_RwdClrL6.Add(0);
				EEECMKPLPNL_CbRnkL6.Add(0);
			}
		}

		//// RVA: 0x14CD67C Offset: 0x14CD67C VA: 0x14CD67C
		public void ODDIHGPONFL(ALGDNCMJHGN GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			NFIOKIBPJCJ_Update = GPBJHKLFCEP.NFIOKIBPJCJ_Update;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			for(int i = 0; i < 5; i++)
			{
				KNIFCANOHOC_Score[i].DNJEJEANJGL_Value = GPBJHKLFCEP.KNIFCANOHOC_Score[i].DNJEJEANJGL_Value;
				NLKEBAOBJCM_Combo[i].DNJEJEANJGL_Value = GPBJHKLFCEP.NLKEBAOBJCM_Combo[i].DNJEJEANJGL_Value;
				JNLKJCDFFMM_Clear[i].DNJEJEANJGL_Value = GPBJHKLFCEP.JNLKJCDFFMM_Clear[i].DNJEJEANJGL_Value;
				EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value = GPBJHKLFCEP.EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value;
				JDIDBMEMKBC_RwdSc[i] = GPBJHKLFCEP.JDIDBMEMKBC_RwdSc[i];
				AGGFHNMMGMN_RwdCb[i] = GPBJHKLFCEP.AGGFHNMMGMN_RwdCb[i];
				HNDPLCDMOJF_RwdClr[i] = GPBJHKLFCEP.HNDPLCDMOJF_RwdClr[i];
				LAMCCNAKIOJ_CbRnk[i] = GPBJHKLFCEP.LAMCCNAKIOJ_CbRnk[i];
				HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value;
				DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value;
				DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value;
				FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value = GPBJHKLFCEP.FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value;
				DKIIINIEKHP_RwdScL6[i] = GPBJHKLFCEP.DKIIINIEKHP_RwdScL6[i];
				JNNIOJIDNKM_RwdCbL6[i] = GPBJHKLFCEP.JNNIOJIDNKM_RwdCbL6[i];
				LGBKKDOLOFP_RwdClrL6[i] = GPBJHKLFCEP.LGBKKDOLOFP_RwdClrL6[i];
				EEECMKPLPNL_CbRnkL6[i] = GPBJHKLFCEP.EEECMKPLPNL_CbRnkL6[i];
			}
		}

		//// RVA: 0x14CE1E4 Offset: 0x14CE1E4 VA: 0x14CE1E4
		public bool AGBOGBEOFME(ALGDNCMJHGN OIKJFMGEICL)
		{
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(NFIOKIBPJCJ_Update != OIKJFMGEICL.NFIOKIBPJCJ_Update)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(KNIFCANOHOC_Score[i].DNJEJEANJGL_Value != OIKJFMGEICL.KNIFCANOHOC_Score[i].DNJEJEANJGL_Value)
					return false;
				if(NLKEBAOBJCM_Combo[i].DNJEJEANJGL_Value != OIKJFMGEICL.NLKEBAOBJCM_Combo[i].DNJEJEANJGL_Value)
					return false;
				if(JNLKJCDFFMM_Clear[i].DNJEJEANJGL_Value != OIKJFMGEICL.JNLKJCDFFMM_Clear[i].DNJEJEANJGL_Value)
					return false;
				if(EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value != OIKJFMGEICL.EMHFDJEFIHG_Play[i].DNJEJEANJGL_Value)
					return false;
				if(JDIDBMEMKBC_RwdSc[i] != OIKJFMGEICL.JDIDBMEMKBC_RwdSc[i])
					return false;
				if(AGGFHNMMGMN_RwdCb[i] != OIKJFMGEICL.AGGFHNMMGMN_RwdCb[i])
					return false;
				if(HNDPLCDMOJF_RwdClr[i] != OIKJFMGEICL.HNDPLCDMOJF_RwdClr[i])
					return false;
				if(LAMCCNAKIOJ_CbRnk[i] != OIKJFMGEICL.LAMCCNAKIOJ_CbRnk[i])
					return false;
				if(HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.HAFFCOKJHBN_ScoreL6[i].DNJEJEANJGL_Value)
					return false;
				if(DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.DNIGPFPHJAK_ComboL6[i].DNJEJEANJGL_Value)
					return false;
				if(DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.DPPCFFFNBGA_ClearL6[i].DNJEJEANJGL_Value)
					return false;
				if(FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value != OIKJFMGEICL.FHFKOGIPAEH_PlayL6[i].DNJEJEANJGL_Value)
					return false;
				if(DKIIINIEKHP_RwdScL6[i] != OIKJFMGEICL.DKIIINIEKHP_RwdScL6[i])
					return false;
				if(JNNIOJIDNKM_RwdCbL6[i] != OIKJFMGEICL.JNNIOJIDNKM_RwdCbL6[i])
					return false;
				if(LGBKKDOLOFP_RwdClrL6[i] != OIKJFMGEICL.LGBKKDOLOFP_RwdClrL6[i])
					return false;
				if(EEECMKPLPNL_CbRnkL6[i] != OIKJFMGEICL.EEECMKPLPNL_CbRnkL6[i])
					return false;
			}
			return true;
		}

		//// RVA: 0x14CEE58 Offset: 0x14CEE58 VA: 0x14CEE58
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, FEHINJKHDAP.ALGDNCMJHGN OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0x14D43F4 Offset: 0x14D43F4 VA: 0x14D43F4
		//public void IOONPJENLOJ(JDDGGJCGOPA.EHFMCGGNPIJ GPBJHKLFCEP) { }

		//// RVA: 0x14D4F08 Offset: 0x14D4F08 VA: 0x14D4F08
		public JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo KJAFPNIFPGP()
		{
			TodoLogger.LogError(TodoLogger.EventScore_4, "KJAFPNIFPGP");
			return new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
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
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 6; i++)
		{
			ALGDNCMJHGN data = new ALGDNCMJHGN();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0xFD2F8C Offset: 0xFD2F8C VA: 0xFD2F8C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 6; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data2[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data2[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data2[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_Point;
			data2[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_Update;
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
				data3.Add(FBCJICEPLED[i].KNIFCANOHOC_Score[j].DNJEJEANJGL_Value);
				data4.Add(FBCJICEPLED[i].JNLKJCDFFMM_Clear[j].DNJEJEANJGL_Value);
				data5.Add(FBCJICEPLED[i].EMHFDJEFIHG_Play[j].DNJEJEANJGL_Value);
				data6.Add(FBCJICEPLED[i].NLKEBAOBJCM_Combo[j].DNJEJEANJGL_Value);
				data7.Add((int)FBCJICEPLED[i].HNDPLCDMOJF_RwdClr[j]);
				data8.Add((int)FBCJICEPLED[i].JDIDBMEMKBC_RwdSc[j]);
				data9.Add((int)FBCJICEPLED[i].AGGFHNMMGMN_RwdCb[j]);
				data10.Add((int)FBCJICEPLED[i].LAMCCNAKIOJ_CbRnk[j]);
			}
			data2[AFEHLCGHAEE_Strings.KNIFCANOHOC_score] = data3;
			data2[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear] = data4;
			data2[AFEHLCGHAEE_Strings.EMHFDJEFIHG_play] = data5;
			data2[AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo] = data6;
			data2[AFEHLCGHAEE_Strings.ACBIPLOOEKI_rwd_clr] = data7;
			data2[AFEHLCGHAEE_Strings.LKCHLHEOHFF_rwd_sc] = data8;
			data2[AFEHLCGHAEE_Strings.GNHMCCLFBLB_rwd_cb] = data9;
			data2[AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk] = data10;

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
				data7.Add((int)FBCJICEPLED[i].LGBKKDOLOFP_RwdClrL6[j]);
				data8.Add((int)FBCJICEPLED[i].DKIIINIEKHP_RwdScL6[j]);
				data9.Add((int)FBCJICEPLED[i].JNNIOJIDNKM_RwdCbL6[j]);
				data10.Add((int)FBCJICEPLED[i].EEECMKPLPNL_CbRnkL6[j]);
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
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_Point = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_Update = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.KNIFCANOHOC_score, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC098
							FBCJICEPLED[i].KNIFCANOHOC_Score[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC154
							FBCJICEPLED[i].JNLKJCDFFMM_Clear[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.EMHFDJEFIHG_play, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC210
							FBCJICEPLED[i].EMHFDJEFIHG_Play[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC2CC
							FBCJICEPLED[i].NLKEBAOBJCM_Combo[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.ACBIPLOOEKI_rwd_clr, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC388
							FBCJICEPLED[i].HNDPLCDMOJF_RwdClr[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.LKCHLHEOHFF_rwd_sc, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC424
							FBCJICEPLED[i].JDIDBMEMKBC_RwdSc[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.GNHMCCLFBLB_rwd_cb, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC4C0
							FBCJICEPLED[i].AGGFHNMMGMN_RwdCb[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC55C
							FBCJICEPLED[i].LAMCCNAKIOJ_CbRnk[OIPCCBHIKIA] = (sbyte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "score_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC5F8
							FBCJICEPLED[i].HAFFCOKJHBN_ScoreL6[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "clear_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC6B4
							FBCJICEPLED[i].DPPCFFFNBGA_ClearL6[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "play_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC770
							FBCJICEPLED[i].FHFKOGIPAEH_PlayL6[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "combo_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC82C
							FBCJICEPLED[i].DNIGPFPHJAK_ComboL6[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_clr_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC8E8
							FBCJICEPLED[i].LGBKKDOLOFP_RwdClrL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_sc_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CC984
							FBCJICEPLED[i].DKIIINIEKHP_RwdScL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "rwd_cb_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CCA20
							FBCJICEPLED[i].JNNIOJIDNKM_RwdCbL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "cbrnk_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x14CCABC
							FBCJICEPLED[i].EEECMKPLPNL_CbRnkL6[OIPCCBHIKIA] = (sbyte)JBGEEPFKIGG;
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
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FEHINJKHDAP_EventScore other = GPBJHKLFCEP as FEHINJKHDAP_EventScore;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
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
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0xFD5D94 Offset: 0xFD5D94 VA: 0xFD5D94 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
