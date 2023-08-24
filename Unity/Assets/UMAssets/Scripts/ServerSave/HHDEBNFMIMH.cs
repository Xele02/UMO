
using System.Collections.Generic;

[System.Obsolete("Use HHDEBNFMIMH_Adventure", true)]
public class HHDEBNFMIMH { }
public class HHDEBNFMIMH_Adventure : KLFDBFMNLBL_ServerSaveBlock
{
	public class JLAPDGALDGC
	{
		public int DPMFCMCDBKL_Id { get; set; } // 0x8 PEGDAIOMDKH BDFDFHFLEKI MBOGFMBGAIG
		public bool CADENLBDAEB_New { get; set; } // 0xC HMFLCAALEKM KJGFPPLHLAB ILJHLPMDHPO
		public long BEBJKJKBOGH_Date { get; set; } // 0x10 MCIJNMKFMDB DIAPHCJBPFD IHAIKPNEEJE
		//public bool FJODMPGPDDD { get; }

		//// RVA: 0x17574A8 Offset: 0x17574A8 VA: 0x17574A8
		//public void GLHANCMGNDM(long JGNBPFCJLKI) { }

		//// RVA: 0x17574C0 Offset: 0x17574C0 VA: 0x17574C0
		//public bool CGKAEMGLHNK() { }

		//// RVA: 0x17560C0 Offset: 0x17560C0 VA: 0x17560C0
		public void ODDIHGPONFL(JLAPDGALDGC GPBJHKLFCEP)
		{
			DPMFCMCDBKL_Id = GPBJHKLFCEP.DPMFCMCDBKL_Id;
			CADENLBDAEB_New = GPBJHKLFCEP.CADENLBDAEB_New;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
		}

		//// RVA: 0x1756370 Offset: 0x1756370 VA: 0x1756370
		public bool AGBOGBEOFME(JLAPDGALDGC OIKJFMGEICL)
		{
			if(DPMFCMCDBKL_Id != OIKJFMGEICL.DPMFCMCDBKL_Id ||
				CADENLBDAEB_New != OIKJFMGEICL.CADENLBDAEB_New ||
				BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
				return false;
			return true;
		}

		//// RVA: 0x17567F4 Offset: 0x17567F4 VA: 0x17567F4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, HHDEBNFMIMH.JLAPDGALDGC OHMCIEMIKCE, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<JLAPDGALDGC> JBBHBNAJMJB { get; private set; } // 0x24 COIBHDMEMIP PHPKEFFEFLI OBEIGCKJIPF
	public override bool DMICHEJIAJL { get { return true; } } // 0x175742C NFKFOODCJJB

	// // RVA: 0x17550EC Offset: 0x17550EC VA: 0x17550EC
	public void GFANLIOMMNA(int BPNKGDGBBFG)
	{
		JBBHBNAJMJB[BPNKGDGBBFG - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
	}

	// // RVA: 0x175523C Offset: 0x175523C VA: 0x175523C
	public bool FABEJIHKFGN(int MDLFDNOJAJN)
	{
		return JBBHBNAJMJB[MDLFDNOJAJN - 1].BEBJKJKBOGH_Date != 0;
	}

	// // RVA: 0x17552F0 Offset: 0x17552F0 VA: 0x17552F0
	public HHDEBNFMIMH_Adventure()
	{
		JBBHBNAJMJB = new List<JLAPDGALDGC>(500);
		KMBPACJNEOF();
	}

	// // RVA: 0x1755394 Offset: 0x1755394 VA: 0x1755394 Slot: 4
	public override void KMBPACJNEOF()
	{
		JBBHBNAJMJB.Clear();
		for(int i = 0; i < 500; i++)
		{
			JLAPDGALDGC data = new JLAPDGALDGC();
			data.DPMFCMCDBKL_Id = i + 1;
			JBBHBNAJMJB.Add(data);
		}
	}

	// // RVA: 0x175549C Offset: 0x175549C VA: 0x175549C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP] = "";
		for(int i = 0; i < JBBHBNAJMJB.Count; i++)
		{
			if(JBBHBNAJMJB[i].BEBJKJKBOGH_Date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = JBBHBNAJMJB[i].DPMFCMCDBKL_Id;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = JBBHBNAJMJB[i].CADENLBDAEB_New ? 1 : 0;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = JBBHBNAJMJB[i].BEBJKJKBOGH_Date;
				data[POFDDFCGEGP + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
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

	// // RVA: 0x1755B78 Offset: 0x1755B78 VA: 0x1755B78 Slot: 6
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
				GPMHOAKFALE_Adventure advDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure;
				for(int i = 0; i < advDb.CDENCMNHNGA.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						JLAPDGALDGC data = JBBHBNAJMJB[i];
						data.DPMFCMCDBKL_Id = i + 1;
						data.CADENLBDAEB_New = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
						data.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1755EF0 Offset: 0x1755EF0 VA: 0x1755EF0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		HHDEBNFMIMH_Adventure a = GPBJHKLFCEP as HHDEBNFMIMH_Adventure;
		for(int i = 0; i < JBBHBNAJMJB.Count; i++)
		{
			JBBHBNAJMJB[i].ODDIHGPONFL(a.JBBHBNAJMJB[i]);
		}
	}

	// // RVA: 0x1756128 Offset: 0x1756128 VA: 0x1756128 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		HHDEBNFMIMH_Adventure other = GPBJHKLFCEP as HHDEBNFMIMH_Adventure;
		if(JBBHBNAJMJB.Count != other.JBBHBNAJMJB.Count)
			return false;
		for(int i = 0; i < JBBHBNAJMJB.Count; i++)
		{
			if(!JBBHBNAJMJB[i].AGBOGBEOFME(other.JBBHBNAJMJB[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x17563E8 Offset: 0x17563E8 VA: 0x17563E8 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}
}
