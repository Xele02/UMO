
using System.Collections.Generic;

[System.Obsolete("Use OIGEIIGKMNH_Valkyrie", true)]
public class OIGEIIGKMNH { }
public class OIGEIIGKMNH_Valkyrie : KLFDBFMNLBL_ServerSaveBlock
{
	public class HLNPGNNPCGO_ValkyrieInfo
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private const sbyte CNECJGKECHK_True = 31;
		private const sbyte JFOFMKBJBBE_False = 56;
		private int BBOLHCKJFCA_VfIdCrypted; // 0x18
		private sbyte ACKPOCNHOOP_IsNewCrypted; // 0x1C
		private long KLAPHOKNEDG_DateCrypted; // 0x20
		private int NFCALENBIBL_LevelCrypted; // 0x28
		private sbyte DLFOHMJLHHP_DvfNewCrypted; // 0x2C

		public int FODKKJIDDKN_vf_Id { get { return BBOLHCKJFCA_VfIdCrypted ^ FBGGEFFJJHB_xor; } set { BBOLHCKJFCA_VfIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE4548 LCHMMCPCFDD_get_vf_Id 0x1DE3D34 DHMLIEPNLCG_set_vf_Id
		public bool CADENLBDAEB_IsNew { get { return ACKPOCNHOOP_IsNewCrypted == CNECJGKECHK_True; } set { ACKPOCNHOOP_IsNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1DE4558 KJGFPPLHLAB_bgs 0x1DE4964 ILJHLPMDHPO_bgs
		public long BEBJKJKBOGH_date { get { return KLAPHOKNEDG_DateCrypted ^ BBEGLBMOBOF_xorl; } set { KLAPHOKNEDG_DateCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1DE4534 DIAPHCJBPFD_get_date 0x1DE4994 IHAIKPNEEJE_set_date
		public int CIEOBFIIPLD_Level { get { return NFCALENBIBL_LevelCrypted ^ FBGGEFFJJHB_xor; } set { NFCALENBIBL_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1DE3724 OGKGFGMKPKB_bgs 0x1DE377C JOOMBHHPHBD_bgs
		public bool FJKIELICMAH_DvfNew { get { return DLFOHMJLHHP_DvfNewCrypted == CNECJGKECHK_True; } set { DLFOHMJLHHP_DvfNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; }  } //0x1DE456C BIHLHDNGPJP_bgs 0x1DE49B4 BCKLGGPBOIK_bgs
		public bool FJODMPGPDDD_Unlocked { get { return BEBJKJKBOGH_date != 0; } } //0x1DE363C CGKAEMGLHNK_get_Unlocked

		// RVA: 0x1DE3C2C Offset: 0x1DE3C2C VA: 0x1DE3C2C
		public HLNPGNNPCGO_ValkyrieInfo()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
			FODKKJIDDKN_vf_Id = 0;
			CADENLBDAEB_IsNew = false;
			BEBJKJKBOGH_date = 0;
			CIEOBFIIPLD_Level = 0;
			FJKIELICMAH_DvfNew = true;
		}

		//// RVA: 0x1DE4BB4 Offset: 0x1DE4BB4 VA: 0x1DE4BB4
		public void ODDIHGPONFL_Copy(HLNPGNNPCGO_ValkyrieInfo GPBJHKLFCEP)
		{
			FODKKJIDDKN_vf_Id = GPBJHKLFCEP.FODKKJIDDKN_vf_Id;
			CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
			CIEOBFIIPLD_Level = GPBJHKLFCEP.CIEOBFIIPLD_Level;
			FJKIELICMAH_DvfNew = GPBJHKLFCEP.FJKIELICMAH_DvfNew;
		}

		//// RVA: 0x1DE4EF8 Offset: 0x1DE4EF8 VA: 0x1DE4EF8
		public bool AGBOGBEOFME(HLNPGNNPCGO_ValkyrieInfo OIKJFMGEICL)
		{
			if(FODKKJIDDKN_vf_Id != OIKJFMGEICL.FODKKJIDDKN_vf_Id ||
				CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew ||
				BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date ||
				CIEOBFIIPLD_Level != OIKJFMGEICL.CIEOBFIIPLD_Level ||
				FJKIELICMAH_DvfNew != OIKJFMGEICL.FJKIELICMAH_DvfNew)
				return false;
			return true;
		}

		//// RVA: 0x1DE53F4 Offset: 0x1DE53F4 VA: 0x1DE53F4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, OIGEIIGKMNH_Valkyrie.HLNPGNNPCGO_ValkyrieInfo _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<HLNPGNNPCGO_ValkyrieInfo> CNGNBKNBKGI_ValkList { get; private set; } // 0x24 HPMHJMMCOKA_bgs PGNBHFIAMPP_bgs BDMGCKFBDMI_bgs
	public override bool DMICHEJIAJL { get { return true; } } // 0x1DE68D0 NFKFOODCJJB_bgs

	// // RVA: 0x1DE34C8 Offset: 0x1DE34C8 VA: 0x1DE34C8
	public int IJHGOONDKLI_GetNumUnlocked(JPIANKEOOMB_Valkyrie _PEOALFEGNDH_Valkyrie)
	{
		int res = 0;
		for(int i = 0; i < _PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table.Count; i++)
		{
			if(_PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_date != 0)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0x1DE3658 Offset: 0x1DE3658 VA: 0x1DE3658
	public HLNPGNNPCGO_ValkyrieInfo JMJOPCDNHKK(int _FODKKJIDDKN_vf_Id)
	{
		if (_FODKKJIDDKN_vf_Id > 100)
			return null;
		return CNGNBKNBKGI_ValkList[_FODKKJIDDKN_vf_Id - 1];
	}

	// // RVA: 0x1DE36E4 Offset: 0x1DE36E4 VA: 0x1DE36E4
	public int OEMMJCLJMGB_GetLevel(int _FODKKJIDDKN_vf_Id)
	{
		if(JMJOPCDNHKK(_FODKKJIDDKN_vf_Id) != null)
		{
			if(JMJOPCDNHKK(_FODKKJIDDKN_vf_Id).BEBJKJKBOGH_date != 0)
				return JMJOPCDNHKK(_FODKKJIDDKN_vf_Id).CIEOBFIIPLD_Level;
		}
		return 0;
	}

	// // RVA: 0x1DE3734 Offset: 0x1DE3734 VA: 0x1DE3734
	public bool KBBNHBBGDEC(int _FODKKJIDDKN_vf_Id, int _CIEOBFIIPLD_Level)
	{
		HLNPGNNPCGO_ValkyrieInfo d = JMJOPCDNHKK(_FODKKJIDDKN_vf_Id);
		if(d != null && d.BEBJKJKBOGH_date != 0)
		{
			d.CIEOBFIIPLD_Level = _CIEOBFIIPLD_Level;
			return true;
		}
		return false;
	}

	// // RVA: 0x1DE378C Offset: 0x1DE378C VA: 0x1DE378C
	public int HEGDAMANPMF(JPIANKEOOMB_Valkyrie _PEOALFEGNDH_Valkyrie, int _NDKJCDGHPLD_MasterVersion, int MIHAHCEANII)
	{
		int res = 0;
		for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
		{
			JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo dbValk = _PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[i];
			if(dbValk.PPEGAKEIEGM_Enabled == 2)
			{
				HLNPGNNPCGO_ValkyrieInfo saveValk = CNGNBKNBKGI_ValkList[i];
				if(saveValk.BEBJKJKBOGH_date != 0)
				{
					if (dbValk.MIHAHCEANII > MIHAHCEANII && _NDKJCDGHPLD_MasterVersion >= dbValk.MIHAHCEANII && res < dbValk.MIHAHCEANII)
						res = dbValk.MIHAHCEANII;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1DE397C Offset: 0x1DE397C VA: 0x1DE397C
	public int NBFPEPBFEHI(int _PPFNGGCBJKC_id, JPIANKEOOMB_Valkyrie _PEOALFEGNDH_Valkyrie)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			if(_PPFNGGCBJKC_id <= CNGNBKNBKGI_ValkList.Count)
			{
				if(_PEOALFEGNDH_Valkyrie.AAACOMKNJJJ(_PPFNGGCBJKC_id))
				{
					return CNGNBKNBKGI_ValkList[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date != 0 ? 1 : 0;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1DE3A98 Offset: 0x1DE3A98 VA: 0x1DE3A98
	public OIGEIIGKMNH_Valkyrie()
	{
		CNGNBKNBKGI_ValkList = new List<HLNPGNNPCGO_ValkyrieInfo>(100);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1DE3B3C Offset: 0x1DE3B3C VA: 0x1DE3B3C Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		CNGNBKNBKGI_ValkList.Clear();
		for(int i = 0; i < 100; i++)
		{
			HLNPGNNPCGO_ValkyrieInfo data = new HLNPGNNPCGO_ValkyrieInfo();
			data.FODKKJIDDKN_vf_Id = i + 1;
			CNGNBKNBKGI_ValkList.Add(data);
		}
	}

	// // RVA: 0x1DE3D44 Offset: 0x1DE3D44 VA: 0x1DE3D44 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
		{
			if(CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = CNGNBKNBKGI_ValkList[i].FODKKJIDDKN_vf_Id;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = CNGNBKNBKGI_ValkList[i].CADENLBDAEB_IsNew ? 1 : 0;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_date;
				data2[AFEHLCGHAEE_Strings.ANAJIAENLNB_lv] = CNGNBKNBKGI_ValkList[i].CIEOBFIIPLD_Level;
				data2[AFEHLCGHAEE_Strings.HMJPPJNLBCM_dvf_new] = CNGNBKNBKGI_ValkList[i].FJKIELICMAH_DvfNew ? 1 : 0;
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1DE4580 Offset: 0x1DE4580 VA: 0x1DE4580 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData data = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(data == null)
			{
				isInvalid = true;
			}
			else
			{
				List<JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo> valkList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table;
				for(int i = 0; i < valkList.Count; i++)
				{
					string key = POFDDFCGEGP_Underscore + (i + 1);
					if (data.BBAJPINMOEP_Contains(key))
					{
						EDOHBJAPLPF_JsonData info = data[key];
						CNGNBKNBKGI_ValkList[i].FODKKJIDDKN_vf_Id = i + 1;
						CNGNBKNBKGI_ValkList[i].CADENLBDAEB_IsNew = CJAENOMGPDA_GetInt(info, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new/*new*/, 0, ref isInvalid) != 0;
						CNGNBKNBKGI_ValkList[i].BEBJKJKBOGH_date = CJAENOMGPDA_GetInt(info, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date/*date*/, 0, ref isInvalid);
						CNGNBKNBKGI_ValkList[i].CIEOBFIIPLD_Level = CJAENOMGPDA_GetInt(info, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv/*lv*/, 0, ref isInvalid);
						CNGNBKNBKGI_ValkList[i].FJKIELICMAH_DvfNew = CJAENOMGPDA_GetInt(info, AFEHLCGHAEE_Strings.HMJPPJNLBCM_dvf_new/*dvf_new*/, 1, ref isInvalid) != 0;
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1DE49E4 Offset: 0x1DE49E4 VA: 0x1DE49E4 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OIGEIIGKMNH_Valkyrie v = GPBJHKLFCEP as OIGEIIGKMNH_Valkyrie;
		for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
		{
			CNGNBKNBKGI_ValkList[i].ODDIHGPONFL_Copy(v.CNGNBKNBKGI_ValkList[i]);
		}
	}

	// // RVA: 0x1DE4CB0 Offset: 0x1DE4CB0 VA: 0x1DE4CB0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OIGEIIGKMNH_Valkyrie other = GPBJHKLFCEP as OIGEIIGKMNH_Valkyrie;
		if(CNGNBKNBKGI_ValkList.Count != other.CNGNBKNBKGI_ValkList.Count)
			return false;
		for(int i = 0; i < CNGNBKNBKGI_ValkList.Count; i++)
		{
			if(!CNGNBKNBKGI_ValkList[i].AGBOGBEOFME(other.CNGNBKNBKGI_ValkList[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1DE4FE8 Offset: 0x1DE4FE8 VA: 0x1DE4FE8 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
