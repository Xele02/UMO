
using System.Collections.Generic;

[System.Obsolete("Use JGGLDGNKELI_Emblem", true)]
public class JGGLDGNKELI { }
public class JGGLDGNKELI_Emblem : KLFDBFMNLBL_ServerSaveBlock
{
	public class AAHAAJEJNLJ
	{
		public int FBGGEFFJJHB_xor = 0xa93169d; // 0x8

		public int HEJIMPBBFEP_EmIdCrypted { get; set; } // 0xC IBDDDEPKAKK KMPECCNMHAG CNNONBKOMNB
		public int GJOCKDBHEIM_EmCntCrypted { get; set; } // 0x10 EAOGMOMIMED GLEEHIGEGND FKNAHDCMFHE
		public int ABLOIBMGLFD_em_id { get { return HEJIMPBBFEP_EmIdCrypted ^ FBGGEFFJJHB_xor; } set { HEJIMPBBFEP_EmIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB16DEC PEFEEOLHFGE 0xB16744 LBMNIKJOIIF
		public int FHCAFLCLGAA_em_cnt { get { return GJOCKDBHEIM_EmCntCrypted ^ FBGGEFFJJHB_xor; } set { GJOCKDBHEIM_EmCntCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB16DF8 EMLMAIJNCKP 0xB16754 OKLACIGBMAM
		public long BEBJKJKBOGH_date { get; set; } // 0x18 MCIJNMKFMDB DIAPHCJBPFD_get_date IHAIKPNEEJE
		public bool FJODMPGPDDD_Unlocked { get { return BEBJKJKBOGH_date != 0; } } //0xB173EC CGKAEMGLHNK_get_Unlocked

		//// RVA: 0xB175CC Offset: 0xB175CC VA: 0xB175CC
		public void ODDIHGPONFL_Copy(AAHAAJEJNLJ GPBJHKLFCEP)
		{
			ABLOIBMGLFD_em_id = GPBJHKLFCEP.ABLOIBMGLFD_em_id;
			FHCAFLCLGAA_em_cnt = GPBJHKLFCEP.FHCAFLCLGAA_em_cnt;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
		}

		//// RVA: 0xB178A0 Offset: 0xB178A0 VA: 0xB178A0
		public bool AGBOGBEOFME(AAHAAJEJNLJ OIKJFMGEICL)
		{
			if(ABLOIBMGLFD_em_id != OIKJFMGEICL.ABLOIBMGLFD_em_id ||
				FHCAFLCLGAA_em_cnt != OIKJFMGEICL.FHCAFLCLGAA_em_cnt ||
				BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date)
				return false;
			return true;
		}

		//// RVA: 0xB17D28 Offset: 0xB17D28 VA: 0xB17D28
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, JGGLDGNKELI_Emblem.AAHAAJEJNLJ _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<AAHAAJEJNLJ> MDKOHOCONKE { get; private set; } // 0x24 JOMEBEGPPNI GIEDMHKMCEN DJKFGOKGNBF
	public override bool DMICHEJIAJL { get { return true; } } // 0xB18A1C NFKFOODCJJB

	// // RVA: 0xB16538 Offset: 0xB16538 VA: 0xB16538
	public JGGLDGNKELI_Emblem()
	{
		MDKOHOCONKE = new List<AAHAAJEJNLJ>(999);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0xB165DC Offset: 0xB165DC VA: 0xB165DC Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		MDKOHOCONKE.Clear();
		for(int i = 0; i < 999; i++)
		{
			AAHAAJEJNLJ data = new AAHAAJEJNLJ();
			data.ABLOIBMGLFD_em_id = i + 1;
			data.FHCAFLCLGAA_em_cnt = 0;
			data.BEBJKJKBOGH_date = 0;
			MDKOHOCONKE.Add(data);
		}
	}

	// // RVA: 0xB16774 Offset: 0xB16774 VA: 0xB16774 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < MDKOHOCONKE.Count; i++)
		{
			if(MDKOHOCONKE[i].BEBJKJKBOGH_date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MDKOHOCONKE[i].ABLOIBMGLFD_em_id;
				data2[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = MDKOHOCONKE[i].FHCAFLCLGAA_em_cnt;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = MDKOHOCONKE[i].BEBJKJKBOGH_date;
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

	// // RVA: 0xB16E08 Offset: 0xB16E08 VA: 0xB16E08 Slot: 6
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
				IHGBPAJMJFK_Emblem emblemDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem;
				for(int i = 0; i < emblemDb.CDENCMNHNGA_table.Count; i++)
				{
					string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						AAHAAJEJNLJ data = MDKOHOCONKE[i];
						data.ABLOIBMGLFD_em_id = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, i + 1, ref isInvalid);
						data.FHCAFLCLGAA_em_cnt = CJAENOMGPDA_GetInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					}
				}
				if(MDKOHOCONKE.Count > 0)
				{
					if(MDKOHOCONKE[0].BEBJKJKBOGH_date == 0)
					{
						MDKOHOCONKE[0].BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						MDKOHOCONKE[0].FHCAFLCLGAA_em_cnt = 0;
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xB173FC Offset: 0xB173FC VA: 0xB173FC Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JGGLDGNKELI_Emblem e = GPBJHKLFCEP as JGGLDGNKELI_Emblem;
		for(int i = 0; i < MDKOHOCONKE.Count; i++)
		{
			MDKOHOCONKE[i].ODDIHGPONFL_Copy(e.MDKOHOCONKE[i]);
		}
	}

	// // RVA: 0xB17658 Offset: 0xB17658 VA: 0xB17658 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JGGLDGNKELI_Emblem other = GPBJHKLFCEP as JGGLDGNKELI_Emblem;
		if(MDKOHOCONKE.Count != other.MDKOHOCONKE.Count)
			return false;
		for(int i = 0; i < MDKOHOCONKE.Count; i++)
		{
			if(!MDKOHOCONKE[i].AGBOGBEOFME(other.MDKOHOCONKE[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xB1791C Offset: 0xB1791C VA: 0xB1791C Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
