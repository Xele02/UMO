
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use FNBIIGJJGKA_Counter", true)]
public class FNBIIGJJGKA {}
public class FNBIIGJJGKA_Counter : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private const int MKINOABMBGM = 20;
	private const int FOBFLHIIJOM = 100;
	private const int PNFLFNNAAPL = 5;
	private const long EBABKJBHKDF = 9999999999;
	private const long GKIALDDPKNF = 99999;
	private const int AFHHHFICNIN = 12;
	public OHDCBNFDHLA EJFAEKPGKNJ_daily; // 0x24
	public NAKMCMEPAGH BDLNMOIOMHK_Total; // 0x28
	public byte[] NONMPJBNBNN_m_clr = new byte[300]; // 0x2C
	public byte[] CFHOMPIKIGK_MFCb = new byte[300]; // 0x30
	public byte[] NDBEHBMEGGI_MClr16 = new byte[300]; // 0x34
	public byte[] DNKKDCHJJHF_MFCb16 = new byte[300]; // 0x38
	public long[] NJIDHLPGBFO_t_tap = new long[5]; // 0x3C
	public long PCBJHBCNNGD_t_clr; // 0x40

	public override bool DMICHEJIAJL { get { return true; } } // 0x11A3920 NFKFOODCJJB

	// // RVA: 0x119E81C Offset: 0x119E81C VA: 0x119E81C
	public void BEJONIOEGCI(int _DLAEJOBELBH_MusicId, int _AKNELONELJK_difficulty, bool _BCGLDMKODLC_IsClear, bool _NANEGCHBEDN_IsFullCombo, List<int> _PGPBALKFBNK_Notes, bool _PMCGHPOGLGM_IsSkip, bool _GIKLNODJKFK_IsLine6/* = false*/)
	{
		if(_AKNELONELJK_difficulty < 5)
		{
			if(_BCGLDMKODLC_IsClear)
			{
				byte[] mclr = _GIKLNODJKFK_IsLine6 ? NDBEHBMEGGI_MClr16 : NONMPJBNBNN_m_clr;
				mclr[_DLAEJOBELBH_MusicId] |= (byte)(1 << _AKNELONELJK_difficulty);
				if (PCBJHBCNNGD_t_clr < 99999)
					PCBJHBCNNGD_t_clr++;
			}
			if(_NANEGCHBEDN_IsFullCombo)
			{
				byte[] mfcb = _GIKLNODJKFK_IsLine6 ? DNKKDCHJJHF_MFCb16 : CFHOMPIKIGK_MFCb;
				mfcb[_DLAEJOBELBH_MusicId] |= (byte)(1 << _AKNELONELJK_difficulty);
			}
			if(_PGPBALKFBNK_Notes != null && !_PMCGHPOGLGM_IsSkip)
			{
				for(int i = 0; i < 5; i++)
				{
					NJIDHLPGBFO_t_tap[i] += _PGPBALKFBNK_Notes[i];
					if(NJIDHLPGBFO_t_tap[i] > 9999999999)
						NJIDHLPGBFO_t_tap[i] = 9999999999;
				}
			}
		}
	}

	// // RVA: 0x119EAD0 Offset: 0x119EAD0 VA: 0x119EAD0
	private int GMKMEENIJFK(byte[] _IDLHJIOMJBK_Data, int _AKNELONELJK_difficulty)
	{
		int res = 0;
		for (int i = 0; i < _IDLHJIOMJBK_Data.Length; i++)
		{
			if ((_IDLHJIOMJBK_Data[i] & (1 << _AKNELONELJK_difficulty)) != 0)
				res++;
		}
		return res;
	}

	// // RVA: 0x119EB44 Offset: 0x119EB44 VA: 0x119EB44
	public int MOEJDCPHJOH_GetTotalMClr(int _AKNELONELJK_difficulty)
	{
		return GMKMEENIJFK(NONMPJBNBNN_m_clr, _AKNELONELJK_difficulty);
	}

	// // RVA: 0x119EB50 Offset: 0x119EB50 VA: 0x119EB50
	public int DGKBOGGIAKD_GetTotalMClr16(int _AKNELONELJK_difficulty)
	{
		return GMKMEENIJFK(NDBEHBMEGGI_MClr16, _AKNELONELJK_difficulty);
	}

	// // RVA: 0x119EB5C Offset: 0x119EB5C VA: 0x119EB5C
	public int AMIPHDGAMLI_GetTotalFcb(int _AKNELONELJK_difficulty)
	{
		return GMKMEENIJFK(CFHOMPIKIGK_MFCb, _AKNELONELJK_difficulty);
	}

	// // RVA: 0x119EB68 Offset: 0x119EB68 VA: 0x119EB68
	public int CEPBENFKMFF_GetTotalMFcb16(int _AKNELONELJK_difficulty)
	{
		return GMKMEENIJFK(DNKKDCHJJHF_MFCb16, _AKNELONELJK_difficulty);
	}

	// // RVA: 0x119EB74 Offset: 0x119EB74 VA: 0x119EB74
	public FNBIIGJJGKA_Counter()
	{
		EJFAEKPGKNJ_daily = new OHDCBNFDHLA();
		BDLNMOIOMHK_Total = new NAKMCMEPAGH();
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x119EC90 Offset: 0x119EC90 VA: 0x119EC90 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		EJFAEKPGKNJ_daily.LHPDDGIJKNB_Reset();
		BDLNMOIOMHK_Total.LHPDDGIJKNB_Reset();
		for(int i = 0; i < 300; i++)
		{
			NONMPJBNBNN_m_clr[i] = 0;
			CFHOMPIKIGK_MFCb[i] = 0;
			NDBEHBMEGGI_MClr16[i] = 0;
			DNKKDCHJJHF_MFCb16[i] = 0;
		}
		for(int i = 0; i < 5; i++)
		{
			NJIDHLPGBFO_t_tap[i] = 0;
		}
		PCBJHBCNNGD_t_clr = 0;
	}

	// // RVA: 0x119EE28 Offset: 0x119EE28 VA: 0x119EE28 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = EJFAEKPGKNJ_daily.BEBJKJKBOGH_Date;
			data2[AFEHLCGHAEE_Strings.EJKHAFIALGK_MClr] = EJFAEKPGKNJ_daily.MILCBLJDADN_MusicClear;
			data2[AFEHLCGHAEE_Strings.LAALIAKBNIB_gach] = EJFAEKPGKNJ_daily.NDNHHGJKJGM_Gach;
			data2[AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv] = EJFAEKPGKNJ_daily.GACBDCLPOCD_Sdv;
			data2[AFEHLCGHAEE_Strings.ELBJIFCDJGO_a_s] = EJFAEKPGKNJ_daily.MPHFGEPJOGL_NumSkillActive;
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < EJFAEKPGKNJ_daily.GEIONHDKGEB_ScoreRank.Length; i++)
			{
				data3.Add(EJFAEKPGKNJ_daily.GEIONHDKGEB_ScoreRank[i]);
			}
			data2[AFEHLCGHAEE_Strings.GPNPBHLLHDI_ScoreRank] = data3;
			data[AFEHLCGHAEE_Strings.BAOFEFFADPD_Day] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.EJKHAFIALGK_MClr] = BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear;
			data2[AFEHLCGHAEE_Strings.NJDCEFLEPEG_perf] = BDLNMOIOMHK_Total.HLNOELCIBPH_Perf;
			data2[AFEHLCGHAEE_Strings.IBOHALOCJDL_fcb] = BDLNMOIOMHK_Total.FILFPNDEINH_Combo;
			data2[AFEHLCGHAEE_Strings.EJOECKJNGPD_Ss] = BDLNMOIOMHK_Total.KOONLNKCIJC_SS;
			data2[AFEHLCGHAEE_Strings.ACGLMKEBMDL_Uc] = BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc;
			data2["max"] = BDLNMOIOMHK_Total.EDLBLCGHECJ_MaxScore;
			data2[AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv] = BDLNMOIOMHK_Total.GACBDCLPOCD_Sdv;
			data2[AFEHLCGHAEE_Strings.GGGFIKIHJCM_vk] = BDLNMOIOMHK_Total.IMIEPNOECFD_ValkyrieMode;
			data2["mv"] = BDLNMOIOMHK_Total.BENEAPDMALA_Mk;
			data2["medl"] = BDLNMOIOMHK_Total.PDGJIJOMAKO_Medl;
			data2["shp"] = BDLNMOIOMHK_Total.PFOMECFACLL_Shop;
			data2["dcshp"] = BDLNMOIOMHK_Total.DHNOLFBEHKN_Dcshp;
			data2["dp"] = BDLNMOIOMHK_Total.NALPJPKDNGH_Dp;
			data2["cosu"] = BDLNMOIOMHK_Total.KNCLIEBAPJD_Cosu;
			data2["valu"] = BDLNMOIOMHK_Total.MJBCBJDMODC_Valu;
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for (int i = 0; i < BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC.Length; i++)
				{
					data3.Add(BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[i]);
				}
				data2["vopc"] = data3;
			}
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for (int i = 0; i < BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC.Length; i++)
				{
					data3.Add(BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[i]);
				}
				data2["dopc"] = data3;
			}
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for (int i = 0; i < BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear.Length; i++)
				{
					data3.Add(BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[i]);
				}
				data2[AFEHLCGHAEE_Strings.BGBKGFDLCME_sclr] = data3;
			}
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
				for (int i = 0; i < BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear.Length; i++)
				{
					data3.Add(BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[i]);
					data4.Add(BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[i]);
				}
				data2[AFEHLCGHAEE_Strings.HPGEGOONHGD_dclr] = data3;
				data2["dclr_l6"] = data4;
			}
			data2["lcnt"] = BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt;
			data2["ldt"] = BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt;
			data[AFEHLCGHAEE_Strings.BDLNMOIOMHK_Total] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < 300; i++)
			{
				data2.Add((int)NONMPJBNBNN_m_clr[i]);
				data3.Add((int)CFHOMPIKIGK_MFCb[i]);
				data4.Add((int)NDBEHBMEGGI_MClr16[i]);
				data5.Add((int)DNKKDCHJJHF_MFCb16[i]);
			}
			for(int i = 0; i < 5; i++)
			{
				data6.Add(NJIDHLPGBFO_t_tap[i]);
			}
			data[AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr] = PCBJHBCNNGD_t_clr;
			data[AFEHLCGHAEE_Strings.NONMPJBNBNN_m_clr] = data2;
			data[AFEHLCGHAEE_Strings.CFHOMPIKIGK_MFCb] = data3;
			data[AFEHLCGHAEE_Strings.NJIDHLPGBFO_t_tap] = data6;
			data["m_clr_l6"] = data4;
			data["m_fcb_l6"] = data5;
		}
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x11A05F4 Offset: 0x11A05F4 VA: 0x11A05F4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			OILEIIEIBHP = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		}
		bool isInvalid = true;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
		{
			if ((int)OILEIIEIBHP[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] == 2)
				isInvalid = false;
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BAOFEFFADPD_Day))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.BAOFEFFADPD_Day];
			EJFAEKPGKNJ_daily.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
			EJFAEKPGKNJ_daily.MILCBLJDADN_MusicClear = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJKHAFIALGK_MClr, 0, ref isInvalid);
			EJFAEKPGKNJ_daily.NDNHHGJKJGM_Gach = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.LAALIAKBNIB_gach, 0, ref isInvalid);
			EJFAEKPGKNJ_daily.GACBDCLPOCD_Sdv = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv, 0, ref isInvalid);
			EJFAEKPGKNJ_daily.MPHFGEPJOGL_NumSkillActive = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.ELBJIFCDJGO_a_s, 0, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.GPNPBHLLHDI_ScoreRank, 0, EJFAEKPGKNJ_daily.GEIONHDKGEB_ScoreRank.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A3928
				EJFAEKPGKNJ_daily.GEIONHDKGEB_ScoreRank[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BDLNMOIOMHK_Total))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.BDLNMOIOMHK_Total];
			BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJKHAFIALGK_MClr, 0, ref isInvalid);
			BDLNMOIOMHK_Total.HLNOELCIBPH_Perf = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.NJDCEFLEPEG_perf, 0, ref isInvalid);
			BDLNMOIOMHK_Total.FILFPNDEINH_Combo = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.IBOHALOCJDL_fcb, 0, ref isInvalid);
			BDLNMOIOMHK_Total.KOONLNKCIJC_SS = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJOECKJNGPD_Ss, 0, ref isInvalid);
			BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.ACGLMKEBMDL_Uc, 0, ref isInvalid);
			BDLNMOIOMHK_Total.EDLBLCGHECJ_MaxScore = CJAENOMGPDA_ReadInt(b, "max", 0, ref isInvalid);
			BDLNMOIOMHK_Total.GACBDCLPOCD_Sdv = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv, 0, ref isInvalid);
			BDLNMOIOMHK_Total.IMIEPNOECFD_ValkyrieMode = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.GGGFIKIHJCM_vk, 0, ref isInvalid);
			BDLNMOIOMHK_Total.BENEAPDMALA_Mk = CJAENOMGPDA_ReadInt(b, "mv", 0, ref isInvalid);
			BDLNMOIOMHK_Total.PDGJIJOMAKO_Medl = CJAENOMGPDA_ReadInt(b, "medl", 0, ref isInvalid);
			BDLNMOIOMHK_Total.PFOMECFACLL_Shop = CJAENOMGPDA_ReadInt(b, "shp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.DHNOLFBEHKN_Dcshp = CJAENOMGPDA_ReadInt(b, "dcshp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.NALPJPKDNGH_Dp = CJAENOMGPDA_ReadInt(b, "dp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.KNCLIEBAPJD_Cosu = CJAENOMGPDA_ReadInt(b, "cosu", 0, ref isInvalid);
			BDLNMOIOMHK_Total.MJBCBJDMODC_Valu = CJAENOMGPDA_ReadInt(b, "valu", 0, ref isInvalid);
			BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt = CJAENOMGPDA_ReadInt(b, "lcnt", 0, ref isInvalid);
			BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt = CJAENOMGPDA_ReadInt(b, "ldt", 0, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "vopc", 0, BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A3988
				BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "dopc", 0, BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A39E8
				BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.BGBKGFDLCME_sclr, 0, BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A3A48
				BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.HPGEGOONHGD_dclr, 0, BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A3AA8
				BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "dclr_l6", 0, BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
			{
				//0x11A3B08
				BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
			}, ref isInvalid);
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NONMPJBNBNN_m_clr))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.NONMPJBNBNN_m_clr];
			int cnt = 300;
			if(b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for(int i = 0; i < cnt; i++)
			{
				NONMPJBNBNN_m_clr[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CFHOMPIKIGK_MFCb))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.CFHOMPIKIGK_MFCb];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				CFHOMPIKIGK_MFCb[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains("m_clr_l6"))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP["m_clr_l6"];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				NDBEHBMEGGI_MClr16[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains("m_fcb_l6"))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP["m_fcb_l6"];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				DNKKDCHJJHF_MFCb16[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NJIDHLPGBFO_t_tap))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.NJIDHLPGBFO_t_tap];
			int cnt = 5;
			if (b.HNBFOAJIIAL_Count < 5)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				if(b[i].MDDJBLEDMBJ_IsInt)
				{
					NJIDHLPGBFO_t_tap[i] = (int)b[i];
				}
				else if (b[i].DCPEFFOMOOK_IsLong)
				{
					NJIDHLPGBFO_t_tap[i] = (long)b[i];
				}
			}
		}
		else
		{
			isInvalid = true;
		}
		PCBJHBCNNGD_t_clr = CJAENOMGPDA_ReadInt(OILEIIEIBHP, AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr, 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x11A1E0C Offset: 0x11A1E0C VA: 0x11A1E0C Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FNBIIGJJGKA_Counter c = GPBJHKLFCEP as FNBIIGJJGKA_Counter;
		EJFAEKPGKNJ_daily.ODDIHGPONFL_Copy(c.EJFAEKPGKNJ_daily);
		BDLNMOIOMHK_Total.ODDIHGPONFL_Copy(c.BDLNMOIOMHK_Total);
		for(int i = 0; i < 300; i++)
		{
			NONMPJBNBNN_m_clr[i] = c.NONMPJBNBNN_m_clr[i];
			CFHOMPIKIGK_MFCb[i] = c.CFHOMPIKIGK_MFCb[i];
			NDBEHBMEGGI_MClr16[i] = c.NDBEHBMEGGI_MClr16[i];
			DNKKDCHJJHF_MFCb16[i] = c.DNKKDCHJJHF_MFCb16[i];
		}
		for(int i = 0; i < NJIDHLPGBFO_t_tap.Length; i++)
		{
			NJIDHLPGBFO_t_tap[i] = c.NJIDHLPGBFO_t_tap[i];
		}
		PCBJHBCNNGD_t_clr = c.PCBJHBCNNGD_t_clr;
	}

	// // RVA: 0x11A21D0 Offset: 0x11A21D0 VA: 0x11A21D0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FNBIIGJJGKA_Counter other = GPBJHKLFCEP as FNBIIGJJGKA_Counter;
		if(PCBJHBCNNGD_t_clr != other.PCBJHBCNNGD_t_clr)
			return false;
		for(int i = 0; i < NJIDHLPGBFO_t_tap.Length; i++)
		{
			if(NJIDHLPGBFO_t_tap[i] != other.NJIDHLPGBFO_t_tap[i])
				return false;
		}
		if(!EJFAEKPGKNJ_daily.AGBOGBEOFME(other.EJFAEKPGKNJ_daily))
			return false;
		if(!BDLNMOIOMHK_Total.AGBOGBEOFME(other.BDLNMOIOMHK_Total))
			return false;
		for(int i = 0; i < 300; i++)
		{
			if(NONMPJBNBNN_m_clr[i] != other.NONMPJBNBNN_m_clr[i] ||
				CFHOMPIKIGK_MFCb[i] != other.CFHOMPIKIGK_MFCb[i] ||
				NDBEHBMEGGI_MClr16[i] != other.NDBEHBMEGGI_MClr16[i] ||
				DNKKDCHJJHF_MFCb16[i] != other.DNKKDCHJJHF_MFCb16[i])
				return false;
		}
		return true;
	}

	// // RVA: 0x11A25E8 Offset: 0x11A25E8 VA: 0x11A25E8 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}

public class OHDCBNFDHLA
{
	private const int MNHALNODIPI = 99999999;
	public long BEBJKJKBOGH_Date; // 0x8
	public int MILCBLJDADN_MusicClear; // 0x10
	public int[] GEIONHDKGEB_ScoreRank = new int[5]; // 0x14
	public int NDNHHGJKJGM_Gach; // 0x18
	public int GACBDCLPOCD_Sdv; // 0x1C
	public int MPHFGEPJOGL_NumSkillActive; // 0x20

	public long AAFMGJHLLCD_EndOfDay { get
		{
			DateTime date = Utility.GetLocalDateTime(BEBJKJKBOGH_Date);
			return Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
		} } //0x1DE0750 KMKOHJDPKGL

	//// RVA: 0x1DE0894 Offset: 0x1DE0894 VA: 0x1DE0894
	public void FHPENOLOPKI_CheckEndOfDay(long _JHNMKKNEENE_Time, bool _FBBNPFFEJBN_Force)
	{
		if (AAFMGJHLLCD_EndOfDay >= _JHNMKKNEENE_Time)
			return;
		NDNHHGJKJGM_Gach = 0;
		GACBDCLPOCD_Sdv = 0;
		MPHFGEPJOGL_NumSkillActive = 0;
		BEBJKJKBOGH_Date = _JHNMKKNEENE_Time;
		MILCBLJDADN_MusicClear = 0;
		for(int i = 0; i < GEIONHDKGEB_ScoreRank.Length; i++)
		{
			GEIONHDKGEB_ScoreRank[i] = 0;
		}
	}

	//// RVA: 0x1DE0948 Offset: 0x1DE0948 VA: 0x1DE0948
	public void FBKAPLHEACL_AddMClr()
	{
		if (MILCBLJDADN_MusicClear < 99999999)
			MILCBLJDADN_MusicClear++;
	}

	//// RVA: 0x1DE0964 Offset: 0x1DE0964 VA: 0x1DE0964
	public void DPKJNIPGGMJ_AddSRnk(int _FJOLNJLLJEJ_Rank)
	{
		if (GEIONHDKGEB_ScoreRank[_FJOLNJLLJEJ_Rank] > 99999998)
			return;
		GEIONHDKGEB_ScoreRank[_FJOLNJLLJEJ_Rank]++;
	}

	//// RVA: 0x1DE0A00 Offset: 0x1DE0A00 VA: 0x1DE0A00
	public void BFAJMALBALG_AddGacha(int _HMFFHLPNMPH_Count)
	{
		NDNHHGJKJGM_Gach += _HMFFHLPNMPH_Count;
		if (NDNHHGJKJGM_Gach > 99999999)
			NDNHHGJKJGM_Gach = 99999999;
	}

	//// RVA: 0x1DE0A20 Offset: 0x1DE0A20 VA: 0x1DE0A20
	public void MAFAKCMFHEE_AddSdv()
	{
		if (GACBDCLPOCD_Sdv < 99999999)
			GACBDCLPOCD_Sdv++;
	}

	//// RVA: 0x1DE0A40 Offset: 0x1DE0A40 VA: 0x1DE0A40
	public void CIGILPOKMAN_AddAS(int _HMFFHLPNMPH_Count)
	{
		MPHFGEPJOGL_NumSkillActive += _HMFFHLPNMPH_Count;
		if (MPHFGEPJOGL_NumSkillActive > 99999999)
			MPHFGEPJOGL_NumSkillActive = 99999999;
	}

	//// RVA: 0x1DE0A60 Offset: 0x1DE0A60 VA: 0x1DE0A60
	public void LHPDDGIJKNB_Reset()
	{
		BEBJKJKBOGH_Date = 0;
		MILCBLJDADN_MusicClear = 0;
		for(int i = 0; i < GEIONHDKGEB_ScoreRank.Length; i++)
		{
			GEIONHDKGEB_ScoreRank[i] = 0;
		}
		NDNHHGJKJGM_Gach = 0;
		GACBDCLPOCD_Sdv = 0;
		MPHFGEPJOGL_NumSkillActive = 0;
	}

	//// RVA: 0x1DE0AF4 Offset: 0x1DE0AF4 VA: 0x1DE0AF4
	public bool AGBOGBEOFME(OHDCBNFDHLA OIKJFMGEICL)
	{
		if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date ||
			MILCBLJDADN_MusicClear != OIKJFMGEICL.MILCBLJDADN_MusicClear ||
			NDNHHGJKJGM_Gach != OIKJFMGEICL.NDNHHGJKJGM_Gach ||
			GACBDCLPOCD_Sdv != OIKJFMGEICL.GACBDCLPOCD_Sdv ||
			MPHFGEPJOGL_NumSkillActive != OIKJFMGEICL.MPHFGEPJOGL_NumSkillActive)
			return false;
		for(int i = 0; i < GEIONHDKGEB_ScoreRank.Length; i++)
		{
			if(GEIONHDKGEB_ScoreRank[i] != OIKJFMGEICL.GEIONHDKGEB_ScoreRank[i])
				return false;
		}
		return true;
	}

	//// RVA: 0x1DE0CD4 Offset: 0x1DE0CD4 VA: 0x1DE0CD4
	public void ODDIHGPONFL_Copy(OHDCBNFDHLA GPBJHKLFCEP)
	{
		BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
		MILCBLJDADN_MusicClear = GPBJHKLFCEP.MILCBLJDADN_MusicClear;
		NDNHHGJKJGM_Gach = GPBJHKLFCEP.NDNHHGJKJGM_Gach;
		GACBDCLPOCD_Sdv = GPBJHKLFCEP.GACBDCLPOCD_Sdv;
		MPHFGEPJOGL_NumSkillActive = GPBJHKLFCEP.MPHFGEPJOGL_NumSkillActive;
		for(int i = 0; i < GEIONHDKGEB_ScoreRank.Length; i++)
		{
			GEIONHDKGEB_ScoreRank[i] = GPBJHKLFCEP.GEIONHDKGEB_ScoreRank[i];
		}
	}

	//// RVA: 0x1DE0E1C Offset: 0x1DE0E1C VA: 0x1DE0E1C
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, OHDCBNFDHLA _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
}
