using System.Collections.Generic;

public class DEKKMGAFJCG { }
public class DEKKMGAFJCG_Diva : KLFDBFMNLBL_ServerSaveBlock
{
	public class MNNLOBDPCCH_DivaInfo
	{
		private List<int> KJFGPMCKKOD = new List<int>(CIEBPOLGCBC); // 0x8
		private List<int> OJKHIMDICBI = new List<int>(CIEBPOLGCBC); // 0xC
		private List<int> OGKFEBONAAP = new List<int>(CIEBPOLGCBC); // 0x10
		private List<int> NBJLJHECGEF = new List<int>(NLKJKCPHOLP); // 0x14
		public int CPGFPEDMDEH; // 0x30
		public int FBGGEFFJJHB = 0x8e; // 0x34
		public int LFIEICOKCDE_IntimacyLevelCrypted; // 0x38
		public int MJJEODANLKB_IntimacyExpCrypted; // 0x3C
		public int BEMIPFOEHNL_IntimacySkillLevelCrypted; // 0x40
		public int CKPNEAELHGB_IntimacyTensionCrypted; // 0x44
		public int EFCFPHJBDLF_IntimacyPresentCountCrypted; // 0x48
		public int PDFBAFBABNB_IntimacyPresentTotalCrypted; // 0x4C
		public int NJMEPLMHKGM_IntimacyTouchCountCrypted; // 0x50
		public int BIGEOBIAMCC_IntimacyTouchTotalCrypted; // 0x54
		public int HMGACICFNNA_EvSoLevelCrypted; // 0x58
		public int EDHLMBBAFKM_EvVoLevelCrypted; // 0x5C
		public int DAAIECDPNBM_EvChLevelCrypted; // 0x60

		public int DIPKCALNIII_DivaId { get; set; } // 0x18 HLEPHANBMGN EOGPBFIDAPF JDNCGPBAFMB
		public int HEBKEJBDCBH_DivaLevel { get; set; } // 0x1C GHHNOPMHDJE OMOHEDILHMF FCGDHINFKHC
		public int BEEAIAAJOHD_CostumeId { get; set; } // 0x20 JPEMECNHGLE DIIBIOEMHAI JIHEDMEFKAF
		public int AFNIOJHODAG_CostumeColorId { get; set; } // 0x24 JMNBFBLHJMC OCABHAPHAMH DIAIECJEGDG
		public int HPJMPINPKEP_HomeCostumeId { get; set; } // 0x28 FFHDAPEBIOM JKALKLILMPH HALNDNAKBIE
		public int KKEPMONFGEI_HomeCostumeColorId { get; set; } // 0x2C HGHGFBHGAKL EDJNFDAPBAP MJDLBJPPPOL
		public List<int> ANAJIAENLNB_Levels { get { return KJFGPMCKKOD; } } //0x1973BD8 MMOMNMBKHJF
		public List<int> LKIFDCEKDCK_Exps { get { return OJKHIMDICBI; } } //0x1973BE0 GOKMANFHFPC
		public List<int> KBOLNIBLIND_Unlocks { get { return OGKFEBONAAP; } } //0x1973BE8 HEOJHPJAPJC
		public List<int> EBDNICPAFLB_SSlot { get { return NBJLJHECGEF; } } //0x1972894 GHDADHFINPE
		public int KCCONFODCPN_IntimacyLevel { get { int val = LFIEICOKCDE_IntimacyLevelCrypted ^ (FBGGEFFJJHB + 3); return val < 1 ? 0 : val; } set { LFIEICOKCDE_IntimacyLevelCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 3); } } //0x1973C20 GMOJMNAFGFF 0x1975018 AFJNLICPHEM
		public int BNDNNCHJGBB_IntimacyExp { get { int val = MJJEODANLKB_IntimacyExpCrypted ^ (FBGGEFFJJHB + 99); return val < 1 ? 0 : val; } set { MJJEODANLKB_IntimacyExpCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 99); } } //0x1973C3C ACFHGNKOBHK 0x1975030 JLCPBIOLJON
		public int JLEPLIHFPKD_IntimacySkillLevel { get { int val = BEMIPFOEHNL_IntimacySkillLevelCrypted ^ (FBGGEFFJJHB + 37); return val < 1 ? 0 : val; } set { BEMIPFOEHNL_IntimacySkillLevelCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 37); } } //0x1973C58 IMCFHELDLLB 0x1975048 BIGDLBNDOEJ
		public int GCGCFGJCLEL_IntimacyTension { get { int val = CKPNEAELHGB_IntimacyTensionCrypted ^ (FBGGEFFJJHB + 1111); return val < 1 ? 0 : val; } set { CKPNEAELHGB_IntimacyTensionCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 1111); } } //0x1973C74 NJEMIKDCDDO 0x1975060 AOEKFBICAJE
		public int APKBMBKMPAB_IntimacyPresentCount { get { int val = EFCFPHJBDLF_IntimacyPresentCountCrypted ^ (FBGGEFFJJHB + 137); return val < 1 ? 0 : val; } set { EFCFPHJBDLF_IntimacyPresentCountCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 137); } } //0x1973C94 CPIAANDJCBL 0x197507C ENAGDPKCBJD
		public int DDODJCCIENF_IntimacyPresentTotal { get { int val = PDFBAFBABNB_IntimacyPresentTotalCrypted ^ (FBGGEFFJJHB + 53); return val < -1 ? 0 : val; } set { PDFBAFBABNB_IntimacyPresentTotalCrypted = (value > -2 ? value : 0) ^ (FBGGEFFJJHB + 53); } } //0x1973CB0 MJBJAFNIMNK 0x1975094 PECPGGACCMJ
		public int NFDPLBOIDAB_IntimacyTouchCount { get { int val = NJMEPLMHKGM_IntimacyTouchCountCrypted ^ (FBGGEFFJJHB + 107); return val < 1 ? 0 : val; } set { NJMEPLMHKGM_IntimacyTouchCountCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 107); } }// 0x1973CCC PHHGPFOGJPD 0x19750AC KEIPFIPCDMA
		public int NEAADNDKGLG_IntimacyTouchTotal { get { int val = BIGEOBIAMCC_IntimacyTouchTotalCrypted ^ (FBGGEFFJJHB + 23); return val < 1 ? 0 : val; } set { BIGEOBIAMCC_IntimacyTouchTotalCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 23); } } //0x1973CE8 NNJOIONEHNA 0x19750C4 AOPELFDEENK
		public int MMCEMJILMJI_EvSoLevel { get { int val = HMGACICFNNA_EvSoLevelCrypted ^ (FBGGEFFJJHB + 17); return val < 1 ? 0 : val; } set { HMGACICFNNA_EvSoLevelCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 17); } } //0x1973D04 LCACIAMABII 0x19750DC NOKGCDDMCLA
		public int HDPANGMKKCP_EvVoLevel { get { int val = EDHLMBBAFKM_EvVoLevelCrypted ^ (FBGGEFFJJHB + 33); return val < 1 ? 0 : val; } set { EDHLMBBAFKM_EvVoLevelCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 33); } } //0x1973D20 BPLDHGOMIHE 0x19750F4 KDLHBMNGHOI
		public int FFMLBEEBHDD_EvChLevel { get { int val = DAAIECDPNBM_EvChLevelCrypted ^ (FBGGEFFJJHB + 94); return val < 1 ? 0 : val; } set { DAAIECDPNBM_EvChLevelCrypted = (value > 0 ? value : 0) ^ (FBGGEFFJJHB + 94); } } //0x1973D3C JJOCEKDMNCN 0x197510C BBAHDADNMIM
		public int PIGLAEFPNEK_MSlot { get; set; } // 0x64 NIFCANFEMPB CIPINKBCEDB NCGOKHEDOLB
		public int JCHHIPOPNIN { get { return 2; } set { return; } } //0x197289C KJGAMDBEKEM 0x1974FF4 KMEDIPKMMBN
		public int ACABEFKBBEN_ExpFrag { get; set; } // 0x68 AJBEODMJGDN OFECNFINKEH NLFNBNNJJJC

		// // RVA: 0x197B9A8 Offset: 0x197B9A8 VA: 0x197B9A8
		public int OKMELNIIMMO()
		{
			return HEBKEJBDCBH_DivaLevel;
		}

		// // RVA: 0x1972A30 Offset: 0x1972A30 VA: 0x1972A30
		public MNNLOBDPCCH_DivaInfo()
		{
			LHPDDGIJKNB();
		}

		// // RVA: 0x197B9B0 Offset: 0x197B9B0 VA: 0x197B9B0
		public void LHPDDGIJKNB()
		{
			KJFGPMCKKOD.Clear();
			OJKHIMDICBI.Clear();
			OGKFEBONAAP.Clear();
			for(int i = 0; i < CIEBPOLGCBC; i++)
			{
				KJFGPMCKKOD.Add(0);
				OJKHIMDICBI.Add(0);
				OGKFEBONAAP.Add(0);
			}
			for(int i = 0; i < NLKJKCPHOLP; i++)
			{
				NBJLJHECGEF.Add(0);
			}
			BEEAIAAJOHD_CostumeId = 0;
			AFNIOJHODAG_CostumeColorId = 0;
			HPJMPINPKEP_HomeCostumeId = 0;
			KKEPMONFGEI_HomeCostumeColorId = 0;
			CPGFPEDMDEH = 0;
			FFMLBEEBHDD_EvChLevel = 0;
			KCCONFODCPN_IntimacyLevel = 1;
			BNDNNCHJGBB_IntimacyExp = 0;
			JLEPLIHFPKD_IntimacySkillLevel = 0;
			GCGCFGJCLEL_IntimacyTension = 0;
			APKBMBKMPAB_IntimacyPresentCount = 1;
			DDODJCCIENF_IntimacyPresentTotal = -1;
			NFDPLBOIDAB_IntimacyTouchCount = 0;
			NEAADNDKGLG_IntimacyTouchTotal = 0;
			MMCEMJILMJI_EvSoLevel = 0;
			HDPANGMKKCP_EvVoLevel = 0;
		}

		// // RVA: 0x1975AC4 Offset: 0x1975AC4 VA: 0x1975AC4
		// public bool AGBOGBEOFME(DEKKMGAFJCG.MNNLOBDPCCH OIKJFMGEICL) { }

		// // RVA: 0x19752F4 Offset: 0x19752F4 VA: 0x19752F4
		// public void ODDIHGPONFL(DEKKMGAFJCG.MNNLOBDPCCH GPBJHKLFCEP) { }

		// // RVA: 0x19765E4 Offset: 0x19765E4 VA: 0x19765E4
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, DEKKMGAFJCG.MNNLOBDPCCH OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	public class IFHCNLAODKG
	{
		public int AHHJLDLAPAN; // 0x8
		public int LGBDBBFEPGL = -1; // 0xC
		public int BCCHOBPJJKE; // 0x10
		public int NGEADPGADLI = -1; // 0x14
	}

	public const int ECFEMKGFDCE = 2;
	public const int LBBLNLCFIOH = 10;
	private const int CIEBPOLGCBC = 300;
	public const int NLKJKCPHOLP = 2;

	public List<MNNLOBDPCCH_DivaInfo> NBIGLBMHEDC_DivaList { get; private set; } // 0x24 ELHJMCKHBBO DGMMMDMLCJF PICPPMMJAEH
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x19724F0 Offset: 0x19724F0 VA: 0x19724F0
	public MNNLOBDPCCH_DivaInfo LGKFMLIOPKL_GetDivaInfo(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC != 0)
		{
			return NBIGLBMHEDC_DivaList[PPFNGGCBJKC - 1];
		}
		return null;
	}

	// // RVA: 0x1972580 Offset: 0x1972580 VA: 0x1972580
	public IFHCNLAODKG JOGOEIEKIHP(int BCCHOBPJJKE)
	{
		if(BCCHOBPJJKE == 0)
			return null;
		for(int i = 0; i < NBIGLBMHEDC_DivaList.Count; i++)
		{
			if(NBIGLBMHEDC_DivaList[i].PIGLAEFPNEK_MSlot == BCCHOBPJJKE)
			{
				IFHCNLAODKG res = new IFHCNLAODKG();
				res.LGBDBBFEPGL = 0;
				res.BCCHOBPJJKE = BCCHOBPJJKE;
				res.AHHJLDLAPAN = NBIGLBMHEDC_DivaList[i].DIPKCALNIII_DivaId;
				return res;
			}
			for(int j = 0; j < 2; j++)
			{
				if(NBIGLBMHEDC_DivaList[i].EBDNICPAFLB_SSlot[j] == BCCHOBPJJKE)
				{
					IFHCNLAODKG res = new IFHCNLAODKG();
					res.LGBDBBFEPGL = j + 1;
					res.BCCHOBPJJKE = BCCHOBPJJKE;
					res.AHHJLDLAPAN = NBIGLBMHEDC_DivaList[i].DIPKCALNIII_DivaId;
					return res;
				}
			}
		}
		return null;
	}

	// // RVA: 0x19728A4 Offset: 0x19728A4 VA: 0x19728A4
	public DEKKMGAFJCG_Diva()
	{
		NBIGLBMHEDC_DivaList = new List<MNNLOBDPCCH_DivaInfo>();
		KMBPACJNEOF();
	}

	// // RVA: 0x1972948 Offset: 0x1972948 VA: 0x1972948 Slot: 4
	public override void KMBPACJNEOF()
	{
		NBIGLBMHEDC_DivaList.Clear();
		for(int i = 1; i < 11; i++)
		{
			MNNLOBDPCCH_DivaInfo data = new MNNLOBDPCCH_DivaInfo();
			data.DIPKCALNIII_DivaId = i;
			NBIGLBMHEDC_DivaList.Add(data);
		}
	}

	// // RVA: 0x1972B2C Offset: 0x1972B2C VA: 0x1972B2C Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1973D58 Offset: 0x1973D58 VA: 0x1973D58 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		bool blockMissing = false;
		EDOHBJAPLPF_JsonData data = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(data == null || !data.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if(data.HNBFOAJIIAL_Count != 10)
				{
					isInvalid = true;
				}
				for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
				{
					EDOHBJAPLPF_JsonData subData = data[i];
					MNNLOBDPCCH_DivaInfo info = NBIGLBMHEDC_DivaList[i];
					int val = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id, i + 1, ref isInvalid);
					if (info.DIPKCALNIII_DivaId != val)
						val = i + 1;
					info.DIPKCALNIII_DivaId = val;
					info.HEBKEJBDCBH_DivaLevel = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.HEBKEJBDCBH_diva_lv, 1, ref isInvalid);
					info.ACABEFKBBEN_ExpFrag = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.ACABEFKBBEN_exp_frag, 0, ref isInvalid);
					info.PIGLAEFPNEK_MSlot = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.PIGLAEFPNEK_m_slot, 0, ref isInvalid);
					info.BEEAIAAJOHD_CostumeId = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref isInvalid);
					info.AFNIOJHODAG_CostumeColorId = CJAENOMGPDA_ReadInt(subData, "c_col", 0, ref isInvalid);
					info.HPJMPINPKEP_HomeCostumeId = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.JJLLJCEJENB_h_c_id, 0, ref isInvalid);
					info.KKEPMONFGEI_HomeCostumeColorId = CJAENOMGPDA_ReadInt(subData, AFEHLCGHAEE_Strings.FEDBLJNOCIH_h_c_col, 0, ref isInvalid);
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
					{
						if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(info.DIPKCALNIII_DivaId))
						{
							info.DIPKCALNIII_DivaId = 1;
						}
						if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(info.BEEAIAAJOHD_CostumeId, info.DIPKCALNIII_DivaId))
						{
							info.BEEAIAAJOHD_CostumeId = 0;
						}
						if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(info.AFNIOJHODAG_CostumeColorId, info.BEEAIAAJOHD_CostumeId, info.DIPKCALNIII_DivaId))
						{
							info.AFNIOJHODAG_CostumeColorId = 0;
						}
						if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(info.HPJMPINPKEP_HomeCostumeId, info.DIPKCALNIII_DivaId))
						{
							info.HPJMPINPKEP_HomeCostumeId = 0;
						}
						if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(info.KKEPMONFGEI_HomeCostumeColorId, info.HPJMPINPKEP_HomeCostumeId, info.DIPKCALNIII_DivaId))
						{
							info.KKEPMONFGEI_HomeCostumeColorId = 0;
						}
					}
					IBCGPBOGOGP_ReadIntArray(subData, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 0, 300, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
					{
						//0x197B738
						info.ANAJIAENLNB_Levels[OIPCCBHIKIA] = JBGEEPFKIGG;
					}, ref isInvalid);
					IBCGPBOGOGP_ReadIntArray(subData, AFEHLCGHAEE_Strings.LKIFDCEKDCK_exp, 0, 300, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
					{
						//0x197B7D4
						info.LKIFDCEKDCK_Exps[OIPCCBHIKIA] = JBGEEPFKIGG;
					}, ref isInvalid);
					IBCGPBOGOGP_ReadIntArray(subData, AFEHLCGHAEE_Strings.KBOLNIBLIND_unlock, 0, 300, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
					{
						//0x197B870
						info.KBOLNIBLIND_Unlocks[OIPCCBHIKIA] = JBGEEPFKIGG;
					}, ref isInvalid);
					IBCGPBOGOGP_ReadIntArray(subData, AFEHLCGHAEE_Strings.EBDNICPAFLB_s_slot, 0, 2, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
					{
						//0x197B90C
						info.EBDNICPAFLB_SSlot[OIPCCBHIKIA] = JBGEEPFKIGG;
					}, ref isInvalid);
					info.KCCONFODCPN_IntimacyLevel = CJAENOMGPDA_ReadInt(subData, "intm_lv", 1, ref isInvalid);
					info.BNDNNCHJGBB_IntimacyExp = CJAENOMGPDA_ReadInt(subData, "intm_exp", 0, ref isInvalid);
					info.JLEPLIHFPKD_IntimacySkillLevel = CJAENOMGPDA_ReadInt(subData, "intm_skill_lv", 0, ref isInvalid);
					info.GCGCFGJCLEL_IntimacyTension = CJAENOMGPDA_ReadInt(subData, "intm_tension", 0, ref isInvalid);
					info.APKBMBKMPAB_IntimacyPresentCount = CJAENOMGPDA_ReadInt(subData, "intm_present_cnt", 1, ref isInvalid);
					info.DDODJCCIENF_IntimacyPresentTotal = CJAENOMGPDA_ReadInt(subData, "intm_present_total", -1, ref isInvalid);
					info.NFDPLBOIDAB_IntimacyTouchCount = CJAENOMGPDA_ReadInt(subData, "intm_touch_cnt", 0, ref isInvalid);
					info.NEAADNDKGLG_IntimacyTouchTotal = CJAENOMGPDA_ReadInt(subData, "intm_touch_total", 0, ref isInvalid);
					info.MMCEMJILMJI_EvSoLevel = CJAENOMGPDA_ReadInt(subData, "ev_so_lv", 0, ref isInvalid);
					info.HDPANGMKKCP_EvVoLevel = CJAENOMGPDA_ReadInt(subData, "ev_vo_lv", 0, ref isInvalid);
					info.FFMLBEEBHDD_EvChLevel = CJAENOMGPDA_ReadInt(subData, "ev_ch_lv", 0, ref isInvalid);
					if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(info.PIGLAEFPNEK_MSlot))
					{
						info.PIGLAEFPNEK_MSlot = 0;
					}
					for (int j = 0; j < 2; j++)
					{
						if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(info.EBDNICPAFLB_SSlot[j]))
						{
							info.EBDNICPAFLB_SSlot[j] = 0;
						}
					}
					int v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.IECLHMBPEIJ(1);
					for (int j = 0; j < 300; j++)
					{
						if(info.ANAJIAENLNB_Levels[j] == 1)
						{
							if(info.LKIFDCEKDCK_Exps[j] < v)
							{
								info.ANAJIAENLNB_Levels[j] = 0;
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
		}
		else
		{
			return false;
		}
		return true;
	}

	// // RVA: 0x1975124 Offset: 0x1975124 VA: 0x1975124 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x197587C Offset: 0x197587C VA: 0x197587C Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x19761D8 Offset: 0x19761D8 VA: 0x19761D8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x197A9C8 Offset: 0x197A9C8 VA: 0x197A9C8 Slot: 9
	// public override bool NFKFOODCJJB() { }

	// // RVA: 0x197A9D0 Offset: 0x197A9D0 VA: 0x197A9D0
	// public void OBDIJIHNKLE(List<int> HNHCIGMKPDC, ref List<int> ONOICEHIHPJ) { }

	// // RVA: 0x197AFF8 Offset: 0x197AFF8 VA: 0x197AFF8
	// public int BJBKCMPCPME(int AHHJLDLAPAN, int DNBFMLBNAEE, GJALOMELEHD NDFIEMPPMLF) { }

	// // RVA: 0x197B1C8 Offset: 0x197B1C8 VA: 0x197B1C8
	// public int BOOKOGDDJGM(int AHHJLDLAPAN) { }

	// // RVA: 0x197B290 Offset: 0x197B290 VA: 0x197B290
	// public bool EGDJODNNKDE(int AHHJLDLAPAN, int NHCCINMHEAB) { }

	// // RVA: 0x197B35C Offset: 0x197B35C VA: 0x197B35C
	// public int OFFBPFBODLJ(int AHHJLDLAPAN) { }

	// // RVA: 0x197B418 Offset: 0x197B418 VA: 0x197B418
	// public bool BNLJGNBGMFM(int AHHJLDLAPAN, int HMFFHLPNMPH) { }

	// // RVA: 0x197B4D8 Offset: 0x197B4D8 VA: 0x197B4D8
	// public int MCIPCILAJIN(int AHHJLDLAPAN) { }

	// // RVA: 0x197B59C Offset: 0x197B59C VA: 0x197B59C
	// public bool IGFOFCEKIAM(int AHHJLDLAPAN, int HMFFHLPNMPH) { }

	// // RVA: 0x197B67C Offset: 0x197B67C VA: 0x197B67C
	// public int KPJIMHGMAGN(int AHHJLDLAPAN) { }
}
