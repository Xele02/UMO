using System;
using System.Collections.Generic;
using XeApp.Game.Common;

[System.Obsolete("Use EBFLJMOCLNA_Costume", true)]
public class EBFLJMOCLNA { }
public class EBFLJMOCLNA_Costume : KLFDBFMNLBL_ServerSaveBlock
{
	public class ILFJDCICIKN // TypeDefIndex: 9373
	{ 
		public class PIHKHAKGNCN
		{
			public int DNLHENCICKD_UcCrypted; // 0x8
			public int MBCPMFPKNBA_LevelCrypted; // 0xC
			public int AADPAJOLEEF_PointCrypted; // 0x10
			public List<int> EHABLECCLLF; // 0x14

			public int ACGLMKEBMDL_uc { get { return DNLHENCICKD_UcCrypted ^ FCEJCHGLFGN; } set { DNLHENCICKD_UcCrypted = value ^ FCEJCHGLFGN; } } //0x14FDD90 ALOLFIJOOHG_get_uc 0x14FDA6C JDPCOMJIMHG_set_uc
			public int ANAJIAENLNB_lv { get { return MBCPMFPKNBA_LevelCrypted ^ FCEJCHGLFGN; } set { MBCPMFPKNBA_LevelCrypted = value ^ FCEJCHGLFGN; } } //0x14FDD0C MMOMNMBKHJF_get_lv 0x14FDA44 FEHNFGPFINK_set_lv
			public int DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ FCEJCHGLFGN; } set { AADPAJOLEEF_PointCrypted = value ^ FCEJCHGLFGN; } } //0x14FDCF8 JKHIIAEMMDE_bgs 0x14FDA58 PFFKLBLEPKB_bgs

			// RVA: 0x14FDA18 Offset: 0x14FDA18 VA: 0x14FDA18
			public PIHKHAKGNCN()
			{
				ACGLMKEBMDL_uc = 0;
				ANAJIAENLNB_lv = 0;
				DNBFMLBNAEE_point = 0;
			}
		}

		public int FBGGEFFJJHB_xor; // 0x8
		private const sbyte CNECJGKECHK_True = 31;
		private const sbyte JFOFMKBJBBE_False = 56;
		public int BJHHOBEMBJG_CostumeIdCrypted; // 0x10
		public long KLAPHOKNEDG_DateCrypted; // 0x18
		public int MBCPMFPKNBA_LevelCrypted; // 0x20
		public int JJBEDMKNPFF_Crypted; // 0x24
		public int AADPAJOLEEF_PointCrypted; // 0x28
		public int LPNLLCCFHEI_IsNewColorFlags_Crypted; // 0x2C
		public long JMFGGKLPKOM; // 0x30
		public int DKOGOBKOGBM; // 0x38
		public int BFLIINDAAAA; // 0x3C
		public int IOJOBGHPLIE_PointCrypted; // 0x40
		public int BHOGOHAILFM; // 0x44
		private int MDFMOFABGKL_Crypted; // 0x48
		public List<int> LDPGNKBFJOM_Levels; // 0x4C

		public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { BJHHOBEMBJG_CostumeIdCrypted = FBGGEFFJJHB_xor ^ value; } } //0x14F81D4 DIIBIOEMHAI_get_CostumeId 0x14F9084 JIHEDMEFKAF_set_CostumeId
		public bool CADENLBDAEB_IsNew { get; set; } // 0xC HMFLCAALEKM_bgs KJGFPPLHLAB_bgs ILJHLPMDHPO_bgs
		public long BEBJKJKBOGH_date { get { return KLAPHOKNEDG_DateCrypted ^ FBGGEFFJJHB_xor; } set { KLAPHOKNEDG_DateCrypted = value ^ FBGGEFFJJHB_xor; JMFGGKLPKOM = value ^ FCEJCHGLFGN; } } //0x14F98EC DIAPHCJBPFD_get_date 0x14F9EEC IHAIKPNEEJE_set_date
		public int ANAJIAENLNB_lv { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB_xor; } set { MBCPMFPKNBA_LevelCrypted = value ^ FBGGEFFJJHB_xor; DKOGOBKOGBM = value ^ FCEJCHGLFGN; } } //0x14F8710 MMOMNMBKHJF_get_lv 0x14F9F20 FEHNFGPFINK_set_lv
		public int KBOLNIBLIND_unlock { get { return JJBEDMKNPFF_Crypted ^ FBGGEFFJJHB_xor; } set { JJBEDMKNPFF_Crypted = value ^ FBGGEFFJJHB_xor; BFLIINDAAAA = value ^ FCEJCHGLFGN; } } //0x14F81E4 HEOJHPJAPJC_bgs 0x14F9F40 AGMKOELJHLC_bgs
		public int DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ FBGGEFFJJHB_xor; } set { AADPAJOLEEF_PointCrypted = value ^ FBGGEFFJJHB_xor; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } //0x14F991C JKHIIAEMMDE_bgs 0x14F9F60 PFFKLBLEPKB_bgs
		public int MKEHNGNEFMM_IsNewColorFlags { get { return LPNLLCCFHEI_IsNewColorFlags_Crypted ^ FBGGEFFJJHB_xor; } set { LPNLLCCFHEI_IsNewColorFlags_Crypted = value ^ FBGGEFFJJHB_xor; BHOGOHAILFM = value ^ FCEJCHGLFGN; } } //0x14F992C BLHDBHOBDIM_bgs 0x14F9F80 HLBGPACOLCD_bgs
		public int FOENNFDGCIC_TrsNew { get { return MDFMOFABGKL_Crypted ^ FBGGEFFJJHB_xor; } set { MDFMOFABGKL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x14F9904 KFANFPLGMAM_bgs 0x14F9FA0 OLIMMBABBFI_bgs
		public bool FJODMPGPDDD_Unlocked { get { return BEBJKJKBOGH_date != 0;} } //0x14F7038 CGKAEMGLHNK_get_Unlocked

		// RVA: 0x14FD494 Offset: 0x14FD494 VA: 0x14FD494
		public bool GPOJCDOEDFD(int _HEHKNMCDBJJ_ColorId)
		{
			return (FOENNFDGCIC_TrsNew & (1 << _HEHKNMCDBJJ_ColorId)) == 0;
		}

		// // RVA: 0x14FD4B8 Offset: 0x14FD4B8 VA: 0x14FD4B8
		public void HBNNIHCGEOG(int _HEHKNMCDBJJ_ColorId, bool _OAFPGJLCNFM_cond)
		{
			if(_OAFPGJLCNFM_cond)
				FOENNFDGCIC_TrsNew &= ~(1 << _HEHKNMCDBJJ_ColorId);
			else
				FOENNFDGCIC_TrsNew |= 1 << _HEHKNMCDBJJ_ColorId;
		}

		// RVA: 0x14F9064 Offset: 0x14F9064 VA: 0x14F9064
		public ILFJDCICIKN()
		{
			LHPDDGIJKNB_Reset();
		}

		// // RVA: 0x14FD4F0 Offset: 0x14FD4F0 VA: 0x14FD4F0
		public void LHPDDGIJKNB_Reset()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			BEEAIAAJOHD_CostumeId = 0;
			CADENLBDAEB_IsNew = false;
			FOENNFDGCIC_TrsNew = 0;
			BEBJKJKBOGH_date = 0;
			ANAJIAENLNB_lv = 0;
			KBOLNIBLIND_unlock = -1;
			DNBFMLBNAEE_point = 0;
			MKEHNGNEFMM_IsNewColorFlags = 0;
		}

		// // RVA: 0x14FA198 Offset: 0x14FA198 VA: 0x14FA198
		public void ODDIHGPONFL_Copy(ILFJDCICIKN GPBJHKLFCEP)
		{
			BEEAIAAJOHD_CostumeId = GPBJHKLFCEP.BEEAIAAJOHD_CostumeId;
			CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
			ANAJIAENLNB_lv = GPBJHKLFCEP.ANAJIAENLNB_lv;
			KBOLNIBLIND_unlock = GPBJHKLFCEP.KBOLNIBLIND_unlock;
			DNBFMLBNAEE_point = GPBJHKLFCEP.DNBFMLBNAEE_point;
			MKEHNGNEFMM_IsNewColorFlags = GPBJHKLFCEP.MKEHNGNEFMM_IsNewColorFlags;
			FOENNFDGCIC_TrsNew = GPBJHKLFCEP.FOENNFDGCIC_TrsNew;
		}

		// // RVA: 0x14FA540 Offset: 0x14FA540 VA: 0x14FA540
		public bool AGBOGBEOFME(ILFJDCICIKN OIKJFMGEICL)
		{
			if(BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId ||
				CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew ||
				BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date ||
				ANAJIAENLNB_lv != OIKJFMGEICL.ANAJIAENLNB_lv ||
				KBOLNIBLIND_unlock != OIKJFMGEICL.KBOLNIBLIND_unlock ||
				DNBFMLBNAEE_point != OIKJFMGEICL.DNBFMLBNAEE_point ||
				MKEHNGNEFMM_IsNewColorFlags != OIKJFMGEICL.MKEHNGNEFMM_IsNewColorFlags ||
				FOENNFDGCIC_TrsNew != OIKJFMGEICL.FOENNFDGCIC_TrsNew)
				return false;
			return true;
		}

		// // RVA: 0x14FAAD0 Offset: 0x14FAAD0 VA: 0x14FAAD0
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, EBFLJMOCLNA_Costume.ILFJDCICIKN _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }

		// // RVA: 0x14FC9EC Offset: 0x14FC9EC VA: 0x14FC9EC
		// public FENCAJJBLBH PFAKPFKJJKA() { }

		// // RVA: 0x14FD5D0 Offset: 0x14FD5D0 VA: 0x14FD5D0
		public bool EAMPKNCDCFM(LCLCCHLDNHJ_Costume DALAFJJBBFH, int GNDJCANPLDJ, out PIHKHAKGNCN _HBODCMLFDOB_result)
		{
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = DALAFJJBBFH.EEOADCECNOM_GetCostume(BEEAIAAJOHD_CostumeId);
			int[] ints = DALAFJJBBFH.MBLNIECELNK_UnlockPoints[cos.AGBPBDODKBK_UnlockPointIdx];
			int[] ints2 = DALAFJJBBFH.AKKDOIJNMBH_UcCostByPoint[cos.HMCOGDICFNB_UcCostByPointIdx];
			List<int> l = new List<int>(cos.BJGNGNPHCBA_LevelsInfo.Length);
			int level = ANAJIAENLNB_lv;
			int point = DNBFMLBNAEE_point;
			bool br = false;
			int a2 = 0;
			do
			{
				int a1 = GNDJCANPLDJ;
				GNDJCANPLDJ = point;
				int a4 = 0;
				int a5 = 0;
				while(true)
				{
					int a3 = a1;
					if(a1 < 1)
					{
						br = true;
						break;
					}
					a4 = ints[level];
					a5 = GNDJCANPLDJ + a3;
					if(a4 <= a5)
						break;
					a1 = 0;
					GNDJCANPLDJ = a5;
					if(a2 < 1)
					{
						a2 = ints2[level] * a3;
						a1 = 0;
					}
				}
				if(br)
					break;
				l.Add(level);
				if(a2 < 1)
				{
					a2 = ints2[level] * (a4 - GNDJCANPLDJ);
				}
				GNDJCANPLDJ = a5 - a4;
				level++;
				point = 0;
			} while(level < ints.Length && !br);
			_HBODCMLFDOB_result = new PIHKHAKGNCN();
			_HBODCMLFDOB_result.ANAJIAENLNB_lv = level;
			_HBODCMLFDOB_result.DNBFMLBNAEE_point = GNDJCANPLDJ;
			_HBODCMLFDOB_result.ACGLMKEBMDL_uc = a2;
			_HBODCMLFDOB_result.EHABLECCLLF = l;
			return l.Count > 0;
        }

		// // RVA: 0x14FDA80 Offset: 0x14FDA80 VA: 0x14FDA80
		public void MOACIBEKLEN(PIHKHAKGNCN _HBODCMLFDOB_result)
		{
			DNBFMLBNAEE_point = _HBODCMLFDOB_result.DNBFMLBNAEE_point;
			ANAJIAENLNB_lv = _HBODCMLFDOB_result.ANAJIAENLNB_lv;
			if(BEBJKJKBOGH_date == 0)
			{
				BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
			if(_HBODCMLFDOB_result.EHABLECCLLF.Count > 0)
			{
				if(LDPGNKBFJOM_Levels == null)
				{
					LDPGNKBFJOM_Levels = _HBODCMLFDOB_result.EHABLECCLLF;
				}
				else
				{
					for(int i = 0; i < _HBODCMLFDOB_result.EHABLECCLLF.Count; i++)
					{
						LDPGNKBFJOM_Levels.Add(_HBODCMLFDOB_result.EHABLECCLLF[i]);
					}
				}
			}
		}

		// // RVA: 0x14F83A0 Offset: 0x14F83A0 VA: 0x14F83A0
		public void GLHANCMGNDM_Unlock(int _ANAJIAENLNB_lv)
		{
			KBOLNIBLIND_unlock = _ANAJIAENLNB_lv;
			if (BEBJKJKBOGH_date != 0)
				return;
			BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}

		// // RVA: 0x14FDD20 Offset: 0x14FDD20 VA: 0x14FDD20
		public bool EJODLFBKFDK_IsNewColor(int _HEHKNMCDBJJ_ColorId)
		{
			return (MKEHNGNEFMM_IsNewColorFlags & (1 << (_HEHKNMCDBJJ_ColorId - 1))) != 0;
		}

		// // RVA: 0x14FDD48 Offset: 0x14FDD48 VA: 0x14FDD48
		public void PDADHMIODCA(int _HEHKNMCDBJJ_ColorId, bool _JKDJCFEBDHC_Enabled)
		{
			if(_JKDJCFEBDHC_Enabled)
				MKEHNGNEFMM_IsNewColorFlags |= 1 << (_HEHKNMCDBJJ_ColorId - 1);
			else
				MKEHNGNEFMM_IsNewColorFlags &= ~(1 << (_HEHKNMCDBJJ_ColorId - 1));
		}
	}

	
	public enum NDOPBOCEPJO_TutoUpgradeType
	{
		NHIOLMNADIO_0_Home = 0,
		CAPLNONHNCO_1_SettingMenu = 1,
		LEHHJINPFHA_2_CostumeUpgrade = 2,
	}

	private class NMAPBJMLMPM
	{
		public LCLCCHLDNHJ_Costume.JMEHNBGDEBD KBOLNIBLIND_unlock; // 0x8
		public int AHHJLDLAPAN_DivaId; // 0xC

		//// RVA: 0x14F81F4 Offset: 0x14F81F4 VA: 0x14F81F4
		public bool OHIADCDNJPB(NMAPBJMLMPM _GJLFANGDGCL_Target)
		{
			for(int i = 0; i < _GJLFANGDGCL_Target.KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions.Length; i++)
			{
				if(_GJLFANGDGCL_Target.KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_type != 0)
				{
					if(_GJLFANGDGCL_Target.KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_type == 2)
					{
						return false;
					}
					if (_GJLFANGDGCL_Target.KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions[i].INDDJNMPONH_type == 3 && AHHJLDLAPAN_DivaId != _GJLFANGDGCL_Target.AHHJLDLAPAN_DivaId)
						return false;
					for(int j = 0; j < KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions.Length; j++)
					{
						if (KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions[j].OHIADCDNJPB(_GJLFANGDGCL_Target.KBOLNIBLIND_unlock.NKNBKLHCAFD_UnlocksConditions[i]))
							break;
					}
					return false;
				}
			}
			return true;
		}

		//// RVA: 0x14FDDA4 Offset: 0x14FDDA4 VA: 0x14FDDA4 Slot: 0
		public override bool Equals(object _LMNBBOIJBBL_obj)
		{
			NMAPBJMLMPM b = _LMNBBOIJBBL_obj as NMAPBJMLMPM;
			return KBOLNIBLIND_unlock.PPFNGGCBJKC_id == b.KBOLNIBLIND_unlock.PPFNGGCBJKC_id && AHHJLDLAPAN_DivaId == b.AHHJLDLAPAN_DivaId;
		}
	}

	public class AEGPJOENNML
	{
		public int JPIDIENBGKH_CostumeId; // 0x8
		public int ANAJIAENLNB_lv; // 0xC
		public LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo.FBKPFMKPMAF_LevelInfo HGNBPGDIFGH_LevelInfo; // 0x10
	}

	public const int ECFEMKGFDCE_CurrentVersion = 2;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	public const int FCEJCHGLFGN = 0x6871471; //109515889;
	public const int PADPOGKDNDP = 500;
	private int JLFONLABECA_ShowTuto; // 0x28

	public List<ILFJDCICIKN> FABAGMLEKIB_CostumeList { get; private set; } = new List<ILFJDCICIKN>(500); // 0x24 PICMGGDAMCD_bgs NGJACJFHBKM_bgs NEHGIPDDKNG_bgs
	public override bool DMICHEJIAJL { get { return true; } } // 0x14FCB14 NFKFOODCJJB_bgs

	// // RVA: 0x14F6B90 Offset: 0x14F6B90 VA: 0x14F6B90
	public ILFJDCICIKN EEOADCECNOM_GetCostume(int _PPFNGGCBJKC_id)
	{
		return FABAGMLEKIB_CostumeList[_PPFNGGCBJKC_id - 1];
	}

	// // RVA: 0x14F6C10 Offset: 0x14F6C10 VA: 0x14F6C10
	public bool MLBBKNLPBBD_IsTutoDone(int _OIPCCBHIKIA_index)
	{
		return (JLFONLABECA_ShowTuto & (1 << (_OIPCCBHIKIA_index & 0x1f))) != 0;
	}

	// // RVA: 0x14F6C2C Offset: 0x14F6C2C VA: 0x14F6C2C
	public void ILMPHFPFLJE_SetTutoStatus(int _OIPCCBHIKIA_index, bool _OAFPGJLCNFM_cond)
	{
		if (_OAFPGJLCNFM_cond)
			JLFONLABECA_ShowTuto |= (1 << (_OIPCCBHIKIA_index & 0x1f));
		else
			JLFONLABECA_ShowTuto &= ~(1 << (_OIPCCBHIKIA_index & 0x1f));
	}

	// // RVA: 0x14F6C54 Offset: 0x14F6C54 VA: 0x14F6C54
	private void JEDBIGLCMBC_ForEachUnlockedCostume(LCLCCHLDNHJ_Costume _MFPNGNMFEAL_Costume, DEKKMGAFJCG_Diva _DGCJCAHIAPP_Diva, bool NHMPDLNPBJD, Action<ILFJDCICIKN> KBCBGIGOLHP)
	{
		for (int i = 0; i < _MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = _MFPNGNMFEAL_Costume.CDENCMNHNGA_table[i];
			if(c.PPEGAKEIEGM_Enabled == 2)
			{
				if(NHMPDLNPBJD)
				{
					if (c.EODICFLJAKO)
						continue;
				}
				if(c.DAJGPBLEEOB_ModelId == 1)
				{
					if(_DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(c.AHHJLDLAPAN_DivaId).CPGFPEDMDEH_have != 0)
					{
						KBCBGIGOLHP(FABAGMLEKIB_CostumeList[i]);
					}
				}
				else
				{
					ILFJDCICIKN sc = FABAGMLEKIB_CostumeList[i];
					if(sc.BEBJKJKBOGH_date != 0)
					{
						KBCBGIGOLHP(sc);
					}
				}
			}
		}
	}

	// // RVA: 0x14F1D78 Offset: 0x14F1D78 VA: 0x14F1D78
	public int EFFKJGEDONM_GetNumUnlockedCostume(LCLCCHLDNHJ_Costume _MFPNGNMFEAL_Costume, DEKKMGAFJCG_Diva _DGCJCAHIAPP_Diva, bool NHMPDLNPBJD)
	{
		int CPGFPEDMDEH_have = 0;
		JEDBIGLCMBC_ForEachUnlockedCostume(_MFPNGNMFEAL_Costume, _DGCJCAHIAPP_Diva, NHMPDLNPBJD, (EBFLJMOCLNA_Costume.ILFJDCICIKN JPAEDJJFFOI) =>
		{
			//0x14FCFAC
			CPGFPEDMDEH_have++;
		});
		return CPGFPEDMDEH_have;
	}

	// // RVA: 0x14F7060 Offset: 0x14F7060 VA: 0x14F7060
	public void BEEJCDHCONE(int _JPIDIENBGKH_CostumeId, int _ANAJIAENLNB_lv)
	{
        LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(_JPIDIENBGKH_CostumeId);
		LCLCCHLDNHJ_Costume.JMEHNBGDEBD j = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[cos.BJGNGNPHCBA_LevelsInfo[_ANAJIAENLNB_lv].KBOLNIBLIND_unlock];
		if(j.IJPCKNNNFHI() != LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
		{
			NMAPBJMLMPM d = new NMAPBJMLMPM();
			d.KBOLNIBLIND_unlock = j;
			d.AHHJLDLAPAN_DivaId = cos.AHHJLDLAPAN_DivaId;
			List<NMAPBJMLMPM> GJFECKHFKLK = new List<NMAPBJMLMPM>(1);
			GJFECKHFKLK.Add(d);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.JEDBIGLCMBC_ForEachUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN _LDEGEHAEALK_ServerData) =>
			{
				//0x14FCFBC
				if(_LDEGEHAEALK_ServerData.BEEAIAAJOHD_CostumeId == _JPIDIENBGKH_CostumeId)
					return;
				HNLMNKFJHLK(_LDEGEHAEALK_ServerData, GJFECKHFKLK);
			});
		}
    }

	// // RVA: 0x14F7440 Offset: 0x14F7440 VA: 0x14F7440
	public void BJGLMIDBKKB(int _JPIDIENBGKH_CostumeId)
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if(l.Count > 0)
		{
			HNLMNKFJHLK(EEOADCECNOM_GetCostume(_JPIDIENBGKH_CostumeId), l);
		}
	}

	// // RVA: 0x14F7E20 Offset: 0x14F7E20 VA: 0x14F7E20
	public void AGEAPKNODHO()
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if(l.Count > 0)
		{
			JEDBIGLCMBC_ForEachUnlockedCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN _LDEGEHAEALK_ServerData) =>
			{
				//0x14FD01C
				HNLMNKFJHLK(_LDEGEHAEALK_ServerData, l);
			});
		}
	}

	// // RVA: 0x14F8070 Offset: 0x14F8070 VA: 0x14F8070
	public void CGBCFBGJHKC(int _AHHJLDLAPAN_DivaId)
	{
		List<NMAPBJMLMPM> l = PHMAHDDGICC();
		if (l.Count < 1)
			return;
		HNLMNKFJHLK(EEOADCECNOM_GetCostume(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.MGENBBDAONJ(_AHHJLDLAPAN_DivaId).JPIDIENBGKH_CostumeId), l);
	}

	// // RVA: 0x14F74E4 Offset: 0x14F74E4 VA: 0x14F74E4
	private List<NMAPBJMLMPM> PHMAHDDGICC()
	{
		LCLCCHLDNHJ_Costume NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
		Dictionary<int, LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition> KMECJBPCDDD = new Dictionary<int, LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition>(NDFIEMPPMLF_master.FDNBEPCEHBH_UnlocksConditions.Count);
		foreach(var k in NDFIEMPPMLF_master.FDNBEPCEHBH_UnlocksConditions)
		{
			LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition d = k.Value.IJPCKNNNFHI();
			KMECJBPCDDD.Add(k.Key, d);
		}
		List<NMAPBJMLMPM> GJFECKHFKLK = new List<NMAPBJMLMPM>(FABAGMLEKIB_CostumeList.Count * 6);
		JEDBIGLCMBC_ForEachUnlockedCostume(NDFIEMPPMLF_master, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva, true, (ILFJDCICIKN _LDEGEHAEALK_ServerData) =>
		{
			//0x14FD050
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = NDFIEMPPMLF_master.EEOADCECNOM_GetCostume(_LDEGEHAEALK_ServerData.BEEAIAAJOHD_CostumeId);
			for (int i = 0; i < _LDEGEHAEALK_ServerData.KBOLNIBLIND_unlock + 1; i++)
			{
				if (c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_unlock != 0)
				{
					if (KMECJBPCDDD[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_unlock] != LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
					{
						NMAPBJMLMPM ACGLMKEBMDL_uc = new NMAPBJMLMPM();
						ACGLMKEBMDL_uc.KBOLNIBLIND_unlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_unlock];
						if(KMECJBPCDDD[c.BJGNGNPHCBA_LevelsInfo[i].KBOLNIBLIND_unlock] == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.CALCHKAMIDB_3_DivaIntimacy)
						{
							ACGLMKEBMDL_uc.AHHJLDLAPAN_DivaId = c.AHHJLDLAPAN_DivaId;
						}
						else
						{
							ACGLMKEBMDL_uc.AHHJLDLAPAN_DivaId = 0;
						}
						NMAPBJMLMPM m = GJFECKHFKLK.Find((NMAPBJMLMPM JPAEDJJFFOI) =>
						{
							//0x14FD458
							return JPAEDJJFFOI.Equals(ACGLMKEBMDL_uc);
						});
						if(m == null)
						{
							GJFECKHFKLK.Add(ACGLMKEBMDL_uc);
						}
					}
				}
			}
		});
		return GJFECKHFKLK;
	}

	// // RVA: 0x14F7A78 Offset: 0x14F7A78 VA: 0x14F7A78
	private void HNLMNKFJHLK(ILFJDCICIKN _LDEGEHAEALK_ServerData, List<NMAPBJMLMPM> GJFECKHFKLK)
	{
		LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(_LDEGEHAEALK_ServerData.BEEAIAAJOHD_CostumeId);
		int level = -1;
		for(int i = _LDEGEHAEALK_ServerData.KBOLNIBLIND_unlock; i < c.LLLCMHENKKN_LevelMax; i++)
		{
			if (c.BJGNGNPHCBA_LevelsInfo[i + 1].KBOLNIBLIND_unlock != 0)
			{
				NMAPBJMLMPM data = new NMAPBJMLMPM();
				data.KBOLNIBLIND_unlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[c.BJGNGNPHCBA_LevelsInfo[i + 1].KBOLNIBLIND_unlock];
				data.AHHJLDLAPAN_DivaId = c.AHHJLDLAPAN_DivaId;
				for(int j = 0; j < GJFECKHFKLK.Count; j++)
				{
					level = i + 1;
					if (GJFECKHFKLK[j].OHIADCDNJPB(data))
						break;
				}
			}
		}
		if (level < 0)
			return;
		_LDEGEHAEALK_ServerData.GLHANCMGNDM_Unlock(level);
	}

	// // RVA: 0x14F84D4 Offset: 0x14F84D4 VA: 0x14F84D4
	public StatusData NNIKNCGNDHK_GetStatForDiva(int _MCDINKAKFGG_DivaId)
	{
		StatusData res = new StatusData();
		for (int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCostume = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(FABAGMLEKIB_CostumeList[i].BEEAIAAJOHD_CostumeId);
			if(FABAGMLEKIB_CostumeList[i].BEBJKJKBOGH_date != 0 && dbCostume.AHHJLDLAPAN_DivaId == _MCDINKAKFGG_DivaId)
			{
				dbCostume.NNIKNCGNDHK_GetStatForDiva(FABAGMLEKIB_CostumeList[i].ANAJIAENLNB_lv, res);
			}
		}
		return res;
	}

	// // RVA: 0x14F8720 Offset: 0x14F8720 VA: 0x14F8720
	public int[,] GODGHFDMAHF_GetRateBySupportPlate()
	{
		int[,] res = new int[LCLCCHLDNHJ_Costume.GFIKOEEBIJP, 3];
		for (int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(FABAGMLEKIB_CostumeList[i].BEEAIAAJOHD_CostumeId);
			if(FABAGMLEKIB_CostumeList[i].BEBJKJKBOGH_date != 0)
			{
				dbCos.LEFFFKJFCFH_AddNumSupportPlate(FABAGMLEKIB_CostumeList[i].ANAJIAENLNB_lv, res);
			}
		}
		bool found = false;
		for (int i = 0; i < res.GetLength(0); i++)
		{
			for(int j = 0; j < res.GetLength(1); j++)
			{
				if(res[i, j] > 0)
				{
					res[i, j] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OLNFADCCMIG_RateBySupportPlate[res[i, j] - 1];
					found = true;
				}
			}
		}
		return found ? res : null;
	}

	// // RVA: 0x14F8ADC Offset: 0x14F8ADC VA: 0x14F8ADC
	public int AAKEPLHPLPL(LCLCCHLDNHJ_Costume _MFPNGNMFEAL_Costume, int _NDKJCDGHPLD_MasterVersion, int IIELLEPEEFH_TrsVersion)
	{
		int res = 0;
		for(int i = 0; i < _MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count; i++)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCostume = _MFPNGNMFEAL_Costume.CDENCMNHNGA_table[i];
			if(dbCostume.PPEGAKEIEGM_Enabled == 2)
			{
				if(LMLGEDEJCJO(dbCostume.JPIDIENBGKH_CostumeId, _MFPNGNMFEAL_Costume, false) > 0)
				{
					if (IIELLEPEEFH_TrsVersion < dbCostume.IIELLEPEEFH_TrsVersion && _NDKJCDGHPLD_MasterVersion >= dbCostume.IIELLEPEEFH_TrsVersion && res < dbCostume.IIELLEPEEFH_TrsVersion)
						res = dbCostume.IIELLEPEEFH_TrsVersion;
				}
			}
		}
		return res;
	}

	// // RVA: 0x14F8C6C Offset: 0x14F8C6C VA: 0x14F8C6C
	public int LMLGEDEJCJO(int _PPFNGGCBJKC_id, LCLCCHLDNHJ_Costume _MFPNGNMFEAL_Costume, bool HGIKOKNMMDH/* = true*/)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			if (_PPFNGGCBJKC_id < FABAGMLEKIB_CostumeList.Count)
			{
				if(HGIKOKNMMDH)
				{
					if (!_MFPNGNMFEAL_Costume.JAHFLLONDCN(_PPFNGGCBJKC_id, 0))
						return 0;
				}
				if(_MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(_PPFNGGCBJKC_id).DAJGPBLEEOB_ModelId == 1)
				{
					DEKKMGAFJCG_Diva sDivas = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva;
					if (sDivas != null)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sDiva = sDivas.LGKFMLIOPKL_GetDivaInfo(_MFPNGNMFEAL_Costume.EEOADCECNOM_GetCostume(_PPFNGGCBJKC_id).AHHJLDLAPAN_DivaId);
						if (sDiva != null)
						{
							return sDiva.CPGFPEDMDEH_have == 1 ? 1 : 0;
						}
					}
				}
				else
				{
					return FABAGMLEKIB_CostumeList[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date != 0 ? 1 : 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x14F8EB0 Offset: 0x14F8EB0 VA: 0x14F8EB0
	public EBFLJMOCLNA_Costume()
	{
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x14F8F54 Offset: 0x14F8F54 VA: 0x14F8F54 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FABAGMLEKIB_CostumeList.Clear();
		for(int i = 1; i < 501; i++)
		{
			ILFJDCICIKN data = new ILFJDCICIKN();
			data.BEEAIAAJOHD_CostumeId = i;
			FABAGMLEKIB_CostumeList.Add(data);
		}
		JLFONLABECA_ShowTuto = 0;
	}

	// // RVA: 0x14F9094 Offset: 0x14F9094 VA: 0x14F9094 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			if(FABAGMLEKIB_CostumeList[i].BEBJKJKBOGH_date != 0 || FABAGMLEKIB_CostumeList[i].FOENNFDGCIC_TrsNew != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = FABAGMLEKIB_CostumeList[i].BEEAIAAJOHD_CostumeId;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = FABAGMLEKIB_CostumeList[i].CADENLBDAEB_IsNew;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = FABAGMLEKIB_CostumeList[i].BEBJKJKBOGH_date;
				data2["lv"] = FABAGMLEKIB_CostumeList[i].ANAJIAENLNB_lv;
				data2["unlock"] = FABAGMLEKIB_CostumeList[i].KBOLNIBLIND_unlock;
				data2["point"] = FABAGMLEKIB_CostumeList[i].DNBFMLBNAEE_point;
				data2["col_new"] = FABAGMLEKIB_CostumeList[i].MKEHNGNEFMM_IsNewColorFlags;
				data2[AFEHLCGHAEE_Strings.DLMDINBHGBG_trs_new] = FABAGMLEKIB_CostumeList[i].FOENNFDGCIC_TrsNew;
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.FFKMJNHFFFL_costume] = data;
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data2["show_tuto"] = JLFONLABECA_ShowTuto;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x14F993C Offset: 0x14F993C VA: 0x14F993C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				LCLCCHLDNHJ_Costume costumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
				for (int i = 0; i < costumeDb.CDENCMNHNGA_table.Count; i++)
				{
					LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo item = costumeDb.CDENCMNHNGA_table[i];
					if(item.PPEGAKEIEGM_Enabled == 2)
					{
						string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
						if(block.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b = block[str];
							ILFJDCICIKN data = FABAGMLEKIB_CostumeList[i];
							data.BEEAIAAJOHD_CostumeId = i + 1;
							data.CADENLBDAEB_IsNew = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
							data.BEBJKJKBOGH_date = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
							data.ANAJIAENLNB_lv = CJAENOMGPDA_GetInt(b, "lv", 0, ref isInvalid);
							data.KBOLNIBLIND_unlock = CJAENOMGPDA_GetInt(b, "unlock", -1, ref isInvalid);
							data.DNBFMLBNAEE_point = CJAENOMGPDA_GetInt(b, "point", 0, ref isInvalid);
							data.MKEHNGNEFMM_IsNewColorFlags = CJAENOMGPDA_GetInt(b, "col_new", 0, ref isInvalid);
							data.FOENNFDGCIC_TrsNew = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.DLMDINBHGBG_trs_new, 0, ref isInvalid);
						}
					}
				}
				EDOHBJAPLPF_JsonData b2 = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
				JLFONLABECA_ShowTuto = CJAENOMGPDA_GetInt(b2, "show_tuto", 0, ref isInvalid);
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x14F9FB0 Offset: 0x14F9FB0 VA: 0x14F9FB0 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EBFLJMOCLNA_Costume c = GPBJHKLFCEP as EBFLJMOCLNA_Costume;
		for(int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			FABAGMLEKIB_CostumeList[i].ODDIHGPONFL_Copy(c.FABAGMLEKIB_CostumeList[i]);
		}
		JLFONLABECA_ShowTuto = c.JLFONLABECA_ShowTuto;
	}

	// // RVA: 0x14FA2E8 Offset: 0x14FA2E8 VA: 0x14FA2E8 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EBFLJMOCLNA_Costume other = GPBJHKLFCEP as EBFLJMOCLNA_Costume;
		if(FABAGMLEKIB_CostumeList.Count != other.FABAGMLEKIB_CostumeList.Count)
			return false;
		for(int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			if(!FABAGMLEKIB_CostumeList[i].AGBOGBEOFME(other.FABAGMLEKIB_CostumeList[i]))
				return false;
		}
		return JLFONLABECA_ShowTuto == other.JLFONLABECA_ShowTuto;
	}

	// // RVA: 0x14FA654 Offset: 0x14FA654 VA: 0x14FA654 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x14FC8B4 Offset: 0x14FC8B4 VA: 0x14FC8B4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x14FCB1C Offset: 0x14FCB1C VA: 0x14FCB1C
	public List<AEGPJOENNML> POEDIMMMLME(LCLCCHLDNHJ_Costume DALAFJJBBFH, ref bool AJFHCEEKPPA)
	{
		List<AEGPJOENNML> res = new List<AEGPJOENNML>();
		for(int i = 0; i < FABAGMLEKIB_CostumeList.Count; i++)
		{
			if(FABAGMLEKIB_CostumeList[i].LDPGNKBFJOM_Levels != null)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = DALAFJJBBFH.EEOADCECNOM_GetCostume(FABAGMLEKIB_CostumeList[i].BEEAIAAJOHD_CostumeId);
				if(cos.PPEGAKEIEGM_Enabled != 0)
				{
					for(int j = 0; j < FABAGMLEKIB_CostumeList[i].LDPGNKBFJOM_Levels.Count; j++)
					{
						AEGPJOENNML data = new AEGPJOENNML();
						data.JPIDIENBGKH_CostumeId = FABAGMLEKIB_CostumeList[i].BEEAIAAJOHD_CostumeId;
						data.ANAJIAENLNB_lv = FABAGMLEKIB_CostumeList[i].LDPGNKBFJOM_Levels[j];
						data.HGNBPGDIFGH_LevelInfo = cos.BJGNGNPHCBA_LevelsInfo[data.ANAJIAENLNB_lv];
						AJFHCEEKPPA = true;
						res.Add(data);
					}
				}
			}
		}
		if(res.Count == 0)
			res = null;
		return res;
	}

	// // RVA: 0x14FCE60 Offset: 0x14FCE60 VA: 0x14FCE60
	// public void CLADPCMBMMO() { }
}
