
using System.Collections.Generic;

[System.Obsolete("Use EAOHMJHHDKN_GachaLimit", true)]
public class EAOHMJHHDKN { }
public class EAOHMJHHDKN_GachaLimit : KLFDBFMNLBL_ServerSaveBlock
{
	public class EODJHACIKGM
	{
		public int FBGGEFFJJHB_xor = 0xcf74cd0; // 0x8

		public int EHOIENNDEDH_IdCrypted { get; set; } // 0xC DNLGCPAJPEK_bgs IFJPCFPIGEB_bgs CMJOJBHLPCJ_bgs
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14F3978 DEMEPMAEJOO_get_id 0x14F2D60 HIGKAIDMOKN_set_id
		public int FKFHJMJFBED { get; set; } // 0x10 APDMAEFIBMO_bgs CPPCJAACJHH_bgs KEBJBKIHELF_bgs
		public int LOLLNDMKPPH_flg { get { return FKFHJMJFBED ^ FBGGEFFJJHB_xor; } set { FKFHJMJFBED = value ^ FBGGEFFJJHB_xor; } } //0x14F2B28 PMCFCNLLPCO_bgs 0x14F2B38 CPBMIOKHCAB_bgs
		public int BAMCNPNLEEN { get; set; } // 0x14 HBEMCOGBNIB_bgs IAHKGFHLAFI_bgs IHALMMPKNJG_bgs
		public int FOILNHKHHDF_pt { get { return BAMCNPNLEEN ^ FBGGEFFJJHB_xor; } set { BAMCNPNLEEN = value ^ FBGGEFFJJHB_xor; } } //0x14F246C FOFBHPJDHFO_get_pt 0x14F2688 LHPMDDKPJDP_set_pt
		public int IFEHKNJONPL_CountCrypted { get; set; } // 0x18 IHGDKEALBJI_bgs FALJMODNNLC_bgs BAOGIFNIGFH_bgs
		public int BFINGCJHOHI_cnt { get { return IFEHKNJONPL_CountCrypted ^ FBGGEFFJJHB_xor; } set { IFEHKNJONPL_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14F28DC LFMCLIDAPHB_get_cnt 0x14F28EC EDAEPDGGFJJ_set_cnt

		//// RVA: 0x14F3940 Offset: 0x14F3940 VA: 0x14F3940
		//public bool DFIGPDCBAPB_IsInvalid() { }

		//// RVA: 0x14F42F8 Offset: 0x14F42F8 VA: 0x14F42F8
		public void ODDIHGPONFL_Copy(EODJHACIKGM GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			LOLLNDMKPPH_flg = GPBJHKLFCEP.LOLLNDMKPPH_flg;
			FOILNHKHHDF_pt = GPBJHKLFCEP.FOILNHKHHDF_pt;
			BFINGCJHOHI_cnt = GPBJHKLFCEP.BFINGCJHOHI_cnt;
		}

		//// RVA: 0x14F4608 Offset: 0x14F4608 VA: 0x14F4608
		public bool AGBOGBEOFME(EODJHACIKGM OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				LOLLNDMKPPH_flg != OIKJFMGEICL.LOLLNDMKPPH_flg ||
				FOILNHKHHDF_pt != OIKJFMGEICL.FOILNHKHHDF_pt ||
				BFINGCJHOHI_cnt != OIKJFMGEICL.BFINGCJHOHI_cnt)
				return false;
			return true;
		}

		//// RVA: 0x14F4A9C Offset: 0x14F4A9C VA: 0x14F4A9C
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, EAOHMJHHDKN_GachaLimit.EODJHACIKGM _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	private const int GACEJGPNHMP = 1000;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<EODJHACIKGM> OECAPENFOHH { get; private set; } // 0x24 AHJGDGAMCNJ_bgs MPEGCNGGNPP_bgs GLPLMEINNKJ_bgs
	public override bool DMICHEJIAJL { get { return true; } } // 0x14F5A58 NFKFOODCJJB_bgs

	// // RVA: 0x14F225C Offset: 0x14F225C VA: 0x14F225C
	public int CFLDNJANAPI_GetNum(int _HHGMPEEGFMA_GachaId)
	{
		BIHCALIAJII_GachaLimit.AICPHCIFEJL gacha = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
		{
			//0x14F5B5C
			return _HHGMPEEGFMA_GachaId == _GHPLINIACBB_x.FEFDGBPFKBJ_gid;
		});
		if(gacha != null && gacha.PLALNIIBLOF_en == 2)
		{
			return OECAPENFOHH[gacha.PPFNGGCBJKC_id].BAMCNPNLEEN;
		}
		return 0;
	}

	// // RVA: 0x14F247C Offset: 0x14F247C VA: 0x14F247C
	public void KHBNLBNPGPK(int _HHGMPEEGFMA_GachaId, int _DNBFMLBNAEE_point)
	{
		BIHCALIAJII_GachaLimit.AICPHCIFEJL a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
		{
			//0x14F5BA0
			return _HHGMPEEGFMA_GachaId == _GHPLINIACBB_x.FEFDGBPFKBJ_gid;
		});
		if(a != null && a.PLALNIIBLOF_en == 2)
		{
			OECAPENFOHH[a.PPFNGGCBJKC_id - 1].FOILNHKHHDF_pt = _DNBFMLBNAEE_point;
		}
	}

	// // RVA: 0x14F2698 Offset: 0x14F2698 VA: 0x14F2698
	// public bool JMFILPONAEC(int _HHGMPEEGFMA_GachaId, int _DNBFMLBNAEE_point) { }

	// // RVA: 0x14F28FC Offset: 0x14F28FC VA: 0x14F28FC
	// public int LGJEOHCDCPF(int _HHGMPEEGFMA_GachaId) { }

	// // RVA: 0x14F2B48 Offset: 0x14F2B48 VA: 0x14F2B48
	public EAOHMJHHDKN_GachaLimit()
	{
		OECAPENFOHH = new List<EODJHACIKGM>();
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x14F2BEC Offset: 0x14F2BEC VA: 0x14F2BEC Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		OECAPENFOHH.Clear();
		for(int i = 0; i < 1000; i++)
		{
			EODJHACIKGM data = new EODJHACIKGM();
			data.PPFNGGCBJKC_id = i + 1;
			data.LOLLNDMKPPH_flg = 0;
			data.FOILNHKHHDF_pt = 0;
			data.BFINGCJHOHI_cnt = 0;
			OECAPENFOHH.Add(data);
		}
	}

	// // RVA: 0x14F2D70 Offset: 0x14F2D70 VA: 0x14F2D70 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < OECAPENFOHH.Count; i++)
		{
			if(OECAPENFOHH[i].LOLLNDMKPPH_flg != 0 || OECAPENFOHH[i].FOILNHKHHDF_pt != 0 || OECAPENFOHH[i].BFINGCJHOHI_cnt != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = OECAPENFOHH[i].PPFNGGCBJKC_id;
				data2[AFEHLCGHAEE_Strings.LOLLNDMKPPH_flg] = OECAPENFOHH[i].LOLLNDMKPPH_flg;
				data2[AFEHLCGHAEE_Strings.FOILNHKHHDF_pt] = OECAPENFOHH[i].FOILNHKHHDF_pt;
				data2[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = OECAPENFOHH[i].BFINGCJHOHI_cnt;
				data[POFDDFCGEGP_Underscore + OECAPENFOHH[i].PPFNGGCBJKC_id] = data2;
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

	// // RVA: 0x14F3B70 Offset: 0x14F3B70 VA: 0x14F3B70 Slot: 6
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
				BIHCALIAJII_GachaLimit gachaDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit;
				for(int i = 0; i < gachaDb.CDENCMNHNGA_table.Count; i++)
				{
					if(gachaDb.CDENCMNHNGA_table[i].PLALNIIBLOF_en == 2)
					{
						string str = POFDDFCGEGP_Underscore + gachaDb.CDENCMNHNGA_table[i].PPFNGGCBJKC_id.ToString();
						if(block.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b = block[str];
							EODJHACIKGM data = OECAPENFOHH[i];
							data.PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, gachaDb.CDENCMNHNGA_table[i].PPFNGGCBJKC_id, ref isInvalid);
							data.LOLLNDMKPPH_flg = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.LOLLNDMKPPH_flg, 0, ref isInvalid);
							data.FOILNHKHHDF_pt = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.FOILNHKHHDF_pt, 0, ref isInvalid);
							data.BFINGCJHOHI_cnt = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x14F4128 Offset: 0x14F4128 VA: 0x14F4128 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EAOHMJHHDKN_GachaLimit g = GPBJHKLFCEP as EAOHMJHHDKN_GachaLimit;
		for(int i = 0; i < OECAPENFOHH.Count; i++)
		{
			OECAPENFOHH[i].ODDIHGPONFL_Copy(g.OECAPENFOHH[i]);
		}
	}

	// // RVA: 0x14F43C0 Offset: 0x14F43C0 VA: 0x14F43C0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		EAOHMJHHDKN_GachaLimit other = GPBJHKLFCEP as EAOHMJHHDKN_GachaLimit;
		if(OECAPENFOHH.Count != other.OECAPENFOHH.Count)
			return false;
		for(int i = 0; i < OECAPENFOHH.Count; i++)
		{
			if(!OECAPENFOHH[i].AGBOGBEOFME(other.OECAPENFOHH[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x14F46A4 Offset: 0x14F46A4 VA: 0x14F46A4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
