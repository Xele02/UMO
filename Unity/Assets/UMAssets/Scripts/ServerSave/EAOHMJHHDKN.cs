
using System.Collections.Generic;

[System.Obsolete("Use EAOHMJHHDKN_GachaLimit", true)]
public class EAOHMJHHDKN { }
public class EAOHMJHHDKN_GachaLimit : KLFDBFMNLBL_ServerSaveBlock
{
	public class EODJHACIKGM
	{
		public int FBGGEFFJJHB_xor = 0xcf74cd0; // 0x8

		public int EHOIENNDEDH_IdCrypted { get; set; } // 0xC DNLGCPAJPEK IFJPCFPIGEB CMJOJBHLPCJ
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14F3978 DEMEPMAEJOO 0x14F2D60 HIGKAIDMOKN
		public int FKFHJMJFBED { get; set; } // 0x10 APDMAEFIBMO CPPCJAACJHH KEBJBKIHELF
		public int LOLLNDMKPPH_flg { get { return FKFHJMJFBED ^ FBGGEFFJJHB_xor; } set { FKFHJMJFBED = value ^ FBGGEFFJJHB_xor; } } //0x14F2B28 PMCFCNLLPCO 0x14F2B38 CPBMIOKHCAB
		public int BAMCNPNLEEN { get; set; } // 0x14 HBEMCOGBNIB IAHKGFHLAFI IHALMMPKNJG
		public int FOILNHKHHDF_Pt { get { return BAMCNPNLEEN ^ FBGGEFFJJHB_xor; } set { BAMCNPNLEEN = value ^ FBGGEFFJJHB_xor; } } //0x14F246C FOFBHPJDHFO 0x14F2688 LHPMDDKPJDP
		public int IFEHKNJONPL_CountCrypted { get; set; } // 0x18 IHGDKEALBJI FALJMODNNLC BAOGIFNIGFH
		public int BFINGCJHOHI_Count { get { return IFEHKNJONPL_CountCrypted ^ FBGGEFFJJHB_xor; } set { IFEHKNJONPL_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x14F28DC LFMCLIDAPHB 0x14F28EC EDAEPDGGFJJ

		//// RVA: 0x14F3940 Offset: 0x14F3940 VA: 0x14F3940
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0x14F42F8 Offset: 0x14F42F8 VA: 0x14F42F8
		public void ODDIHGPONFL_Copy(EODJHACIKGM GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			LOLLNDMKPPH_flg = GPBJHKLFCEP.LOLLNDMKPPH_flg;
			FOILNHKHHDF_Pt = GPBJHKLFCEP.FOILNHKHHDF_Pt;
			BFINGCJHOHI_Count = GPBJHKLFCEP.BFINGCJHOHI_Count;
		}

		//// RVA: 0x14F4608 Offset: 0x14F4608 VA: 0x14F4608
		public bool AGBOGBEOFME(EODJHACIKGM OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				LOLLNDMKPPH_flg != OIKJFMGEICL.LOLLNDMKPPH_flg ||
				FOILNHKHHDF_Pt != OIKJFMGEICL.FOILNHKHHDF_Pt ||
				BFINGCJHOHI_Count != OIKJFMGEICL.BFINGCJHOHI_Count)
				return false;
			return true;
		}

		//// RVA: 0x14F4A9C Offset: 0x14F4A9C VA: 0x14F4A9C
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, EAOHMJHHDKN.EODJHACIKGM _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	private const int GACEJGPNHMP = 1000;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<EODJHACIKGM> OECAPENFOHH { get; private set; } // 0x24 AHJGDGAMCNJ MPEGCNGGNPP GLPLMEINNKJ
	public override bool DMICHEJIAJL { get { return true; } } // 0x14F5A58 NFKFOODCJJB

	// // RVA: 0x14F225C Offset: 0x14F225C VA: 0x14F225C
	public int CFLDNJANAPI(int _HHGMPEEGFMA_GachaId)
	{
		BIHCALIAJII_GachaLimit.AICPHCIFEJL gacha = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
		{
			//0x14F5B5C
			return _HHGMPEEGFMA_GachaId == _GHPLINIACBB_x.FEFDGBPFKBJ_GId;
		});
		if(gacha != null && gacha.PLALNIIBLOF_en == 2)
		{
			return OECAPENFOHH[gacha.PPFNGGCBJKC_id].BAMCNPNLEEN;
		}
		return 0;
	}

	// // RVA: 0x14F247C Offset: 0x14F247C VA: 0x14F247C
	public void KHBNLBNPGPK(int _HHGMPEEGFMA_GachaId, int _DNBFMLBNAEE_Point)
	{
		BIHCALIAJII_GachaLimit.AICPHCIFEJL a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OINLLHOMEAK_GachaLimit.CDENCMNHNGA_table.Find((BIHCALIAJII_GachaLimit.AICPHCIFEJL _GHPLINIACBB_x) =>
		{
			//0x14F5BA0
			return _HHGMPEEGFMA_GachaId == _GHPLINIACBB_x.FEFDGBPFKBJ_GId;
		});
		if(a != null && a.PLALNIIBLOF_en == 2)
		{
			OECAPENFOHH[a.PPFNGGCBJKC_id - 1].FOILNHKHHDF_Pt = _DNBFMLBNAEE_Point;
		}
	}

	// // RVA: 0x14F2698 Offset: 0x14F2698 VA: 0x14F2698
	// public bool JMFILPONAEC(int _HHGMPEEGFMA_GachaId, int _DNBFMLBNAEE_Point) { }

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
			data.FOILNHKHHDF_Pt = 0;
			data.BFINGCJHOHI_Count = 0;
			OECAPENFOHH.Add(data);
		}
	}

	// // RVA: 0x14F2D70 Offset: 0x14F2D70 VA: 0x14F2D70 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP] = "";
		for(int i = 0; i < OECAPENFOHH.Count; i++)
		{
			if(OECAPENFOHH[i].LOLLNDMKPPH_flg != 0 || OECAPENFOHH[i].FOILNHKHHDF_Pt != 0 || OECAPENFOHH[i].BFINGCJHOHI_Count != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = OECAPENFOHH[i].PPFNGGCBJKC_id;
				data2[AFEHLCGHAEE_Strings.LOLLNDMKPPH_flg] = OECAPENFOHH[i].LOLLNDMKPPH_flg;
				data2[AFEHLCGHAEE_Strings.FOILNHKHHDF_Pt] = OECAPENFOHH[i].FOILNHKHHDF_Pt;
				data2[AFEHLCGHAEE_Strings.BFINGCJHOHI_Count] = OECAPENFOHH[i].BFINGCJHOHI_Count;
				data[POFDDFCGEGP + OECAPENFOHH[i].PPFNGGCBJKC_id] = data2;
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
						string str = POFDDFCGEGP + gachaDb.CDENCMNHNGA_table[i].PPFNGGCBJKC_id.ToString();
						if(block.BBAJPINMOEP_Contains(str))
						{
							EDOHBJAPLPF_JsonData b = block[str];
							EODJHACIKGM data = OECAPENFOHH[i];
							data.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, gachaDb.CDENCMNHNGA_table[i].PPFNGGCBJKC_id, ref isInvalid);
							data.LOLLNDMKPPH_flg = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.LOLLNDMKPPH_flg, 0, ref isInvalid);
							data.FOILNHKHHDF_Pt = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.FOILNHKHHDF_Pt, 0, ref isInvalid);
							data.BFINGCJHOHI_Count = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_Count, 0, ref isInvalid);
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
