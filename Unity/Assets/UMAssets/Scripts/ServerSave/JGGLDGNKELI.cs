
using System.Collections.Generic;

[System.Obsolete("Use JGGLDGNKELI_Emblem", true)]
public class JGGLDGNKELI { }
public class JGGLDGNKELI_Emblem : KLFDBFMNLBL_ServerSaveBlock
{
	public class AAHAAJEJNLJ
	{
		public int FBGGEFFJJHB = 0xa93169d; // 0x8

		public int HEJIMPBBFEP_IdCrypted { get; set; } // 0xC IBDDDEPKAKK KMPECCNMHAG CNNONBKOMNB
		public int GJOCKDBHEIM_CntCrypted { get; set; } // 0x10 EAOGMOMIMED GLEEHIGEGND FKNAHDCMFHE
		public int ABLOIBMGLFD_Id { get { return HEJIMPBBFEP_IdCrypted ^ FBGGEFFJJHB; } set { HEJIMPBBFEP_IdCrypted = value ^ FBGGEFFJJHB; } } //0xB16DEC PEFEEOLHFGE 0xB16744 LBMNIKJOIIF
		public int FHCAFLCLGAA_Cnt { get { return GJOCKDBHEIM_CntCrypted ^ FBGGEFFJJHB; } set { GJOCKDBHEIM_CntCrypted = value ^ FBGGEFFJJHB; } } //0xB16DF8 EMLMAIJNCKP 0xB16754 OKLACIGBMAM
		public long BEBJKJKBOGH_Date { get; set; } // 0x18 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		public bool FJODMPGPDDD { get { return BEBJKJKBOGH_Date != 0; } } //0xB173EC CGKAEMGLHNK

		//// RVA: 0xB175CC Offset: 0xB175CC VA: 0xB175CC
		public void ODDIHGPONFL(AAHAAJEJNLJ GPBJHKLFCEP)
		{
			ABLOIBMGLFD_Id = GPBJHKLFCEP.ABLOIBMGLFD_Id;
			FHCAFLCLGAA_Cnt = GPBJHKLFCEP.FHCAFLCLGAA_Cnt;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
		}

		//// RVA: 0xB178A0 Offset: 0xB178A0 VA: 0xB178A0
		//public bool AGBOGBEOFME(JGGLDGNKELI.AAHAAJEJNLJ OIKJFMGEICL) { }

		//// RVA: 0xB17D28 Offset: 0xB17D28 VA: 0xB17D28
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, JGGLDGNKELI.AAHAAJEJNLJ OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	 public List<AAHAAJEJNLJ> MDKOHOCONKE { get; private set; } // 0x24 JOMEBEGPPNI GIEDMHKMCEN DJKFGOKGNBF
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0xB16538 Offset: 0xB16538 VA: 0xB16538
	public JGGLDGNKELI_Emblem()
	{
		MDKOHOCONKE = new List<AAHAAJEJNLJ>(999);
		KMBPACJNEOF();
	}

	// // RVA: 0xB165DC Offset: 0xB165DC VA: 0xB165DC Slot: 4
	public override void KMBPACJNEOF()
	{
		MDKOHOCONKE.Clear();
		for(int i = 0; i < 999; i++)
		{
			AAHAAJEJNLJ data = new AAHAAJEJNLJ();
			data.ABLOIBMGLFD_Id = i + 1;
			data.FHCAFLCLGAA_Cnt = 0;
			data.BEBJKJKBOGH_Date = 0;
			MDKOHOCONKE.Add(data);
		}
	}

	// // RVA: 0xB16774 Offset: 0xB16774 VA: 0xB16774 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

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
				for(int i = 0; i < emblemDb.CDENCMNHNGA_EmblemList.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						AAHAAJEJNLJ data = MDKOHOCONKE[i];
						data.ABLOIBMGLFD_Id = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
						data.FHCAFLCLGAA_Cnt = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
					}
				}
				if(MDKOHOCONKE.Count > 0)
				{
					if(MDKOHOCONKE[0].BEBJKJKBOGH_Date == 0)
					{
						MDKOHOCONKE[0].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						MDKOHOCONKE[0].FHCAFLCLGAA_Cnt = 0;
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xB173FC Offset: 0xB173FC VA: 0xB173FC Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JGGLDGNKELI_Emblem e = GPBJHKLFCEP as JGGLDGNKELI_Emblem;
		for(int i = 0; i < MDKOHOCONKE.Count; i++)
		{
			MDKOHOCONKE[i].ODDIHGPONFL(e.MDKOHOCONKE[i]);
		}
	}

	// // RVA: 0xB17658 Offset: 0xB17658 VA: 0xB17658 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0xB1791C Offset: 0xB1791C VA: 0xB1791C Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0xB18A1C Offset: 0xB18A1C VA: 0xB18A1C Slot: 9
	// public override bool NFKFOODCJJB() { }
}
