
[System.Obsolete("Use FFMIPGABHHA_SaveHash", true)]
public class FFMIPGABHHA { }
public class FFMIPGABHHA_SaveHash : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	public const long BBEGLBMOBOF = 0x77ccefaa9;
	public static string POFDDFCGEGP = "_"; // 0x0
	public string IOIMHJAOKOO_Hash; // 0x24
	private long KLAPHOKNEDG_Time; // 0x28
	public long AFNJCFEKFDD_Dirty; // 0x30

	public long BEBJKJKBOGH_Time { get { return KLAPHOKNEDG_Time ^ BBEGLBMOBOF; } set { KLAPHOKNEDG_Time = value ^ BBEGLBMOBOF; } } //DIAPHCJBPFD 0x14E4B88 IHAIKPNEEJE 0x14E4BA0
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x14E4BBC Offset: 0x14E4BBC VA: 0x14E4BBC
	public static string CAOGDCBPBAN(string MDADLCOCEBN, int EHDDADDKMFI, int FEOKKEPAIBB)
	{
		TodoLogger.Log(0, "CAOGDCBPBAN");
		return "";
	}

	// // RVA: 0x14E4E1C Offset: 0x14E4E1C VA: 0x14E4E1C
	public FFMIPGABHHA_SaveHash()
	{
		KMBPACJNEOF();
	}

	// // RVA: 0x14E4E48 Offset: 0x14E4E48 VA: 0x14E4E48 Slot: 4
	public override void KMBPACJNEOF()
	{
		BEBJKJKBOGH_Time = 0;
		AFNJCFEKFDD_Dirty = 0;
		IOIMHJAOKOO_Hash = "";
	}

	// // RVA: 0x14E4EC8 Offset: 0x14E4EC8 VA: 0x14E4EC8 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x14E5148 Offset: 0x14E5148 VA: 0x14E5148 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			isInvalid = true;
		}
		else
		{
			EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
			if (!block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
				isInvalid = true;
			else
			{
				if ((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
					isInvalid = true;
			}
			IOIMHJAOKOO_Hash = FGCNMLBACGO_ReadString(block, "hash", "", ref isInvalid);
			BEBJKJKBOGH_Time = DKMPHAPBDLH_ReadLong(block, "date", 0, ref isInvalid);
			AFNJCFEKFDD_Dirty = DKMPHAPBDLH_ReadLong(block, "dirty", 0, ref isInvalid);
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x14E5400 Offset: 0x14E5400 VA: 0x14E5400 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FFMIPGABHHA_SaveHash s = GPBJHKLFCEP as FFMIPGABHHA_SaveHash;
		IOIMHJAOKOO_Hash = string.Copy(s.IOIMHJAOKOO_Hash);
		BEBJKJKBOGH_Time = s.BEBJKJKBOGH_Time;
		AFNJCFEKFDD_Dirty = s.AFNJCFEKFDD_Dirty;
	}

	// // RVA: 0x14E5558 Offset: 0x14E5558 VA: 0x14E5558 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x14E56AC Offset: 0x14E56AC VA: 0x14E56AC Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x14E5A68 Offset: 0x14E5A68 VA: 0x14E5A68 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
