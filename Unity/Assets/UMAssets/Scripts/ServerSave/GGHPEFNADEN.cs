
using System.Collections.Generic;

[System.Obsolete("Use GGHPEFNADEN_Ticket", true)]
public class GGHPEFNADEN { }
public class GGHPEFNADEN_Ticket : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	public const int ECDKBNNCHJB = 7;
	public string LJNAKDMILMC_key = ""; // 0x24
	public int INLNJOGHLJE_Show; // 0x28
	public int CDMGDFLPPHN_Entry; // 0x2C
	public int LNACKEBEMOB_Received; // 0x30
	public string AJFDNKLNKDP_EntryDate_; // 0x34
	public string OGMOHJIEDEA_Result_; // 0x38
	public string KKJKOGHFGLB_Pending_; // 0x3C
	public int CBPJHNHBLNN; // 0x40
	public int BKIIKBEACDN; // 0x44
	public int OKKAFCJGCJL; // 0x48

	public string EBAMGNMELPO_EntryDate { get { return AJFDNKLNKDP_EntryDate_; } set { AJFDNKLNKDP_EntryDate_ = value; OKKAFCJGCJL = value.GetHashCode(); } } //NLLPAPKGDJM 0xAA1300 GDOPHGNBAGO 0xAA1308
	public string HBODCMLFDOB_Result { get { return OGMOHJIEDEA_Result_; } set { OGMOHJIEDEA_Result_ = value; BKIIKBEACDN = value.GetHashCode(); } } //MDOIHMLLDEC 0xAA1348 DNGOCLOHDPE 0xAA1350
	public string OEDIICBDNKG_Pending { get { return KKJKOGHFGLB_Pending_; } set { KKJKOGHFGLB_Pending_ = value; CBPJHNHBLNN = value.GetHashCode(); } } //GNOMCGBDNDA 0xAA1390 MFIEGCGDLFH 0xAA1398
	public override bool DMICHEJIAJL { get { return false; } } // 0xAA2A6C NFKFOODCJJB

	// // RVA: 0xAA13D8 Offset: 0xAA13D8 VA: 0xAA13D8
	public List<string> HOFACDIBDLM()
	{
		string[] strs = AJFDNKLNKDP_EntryDate_.Split(new char[]{','});
		List<string> res = new List<string>();
		for(int i = 0; i < strs.Length; i++)
		{
			res.Add(strs[i]);
		}
		return res;
	}

	// // RVA: 0xAA1544 Offset: 0xAA1544 VA: 0xAA1544
	public GGHPEFNADEN_Ticket()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0xAA15BC Offset: 0xAA15BC VA: 0xAA15BC Slot: 4
	public override void KMBPACJNEOF()
	{
		EBAMGNMELPO_EntryDate = "";
		LJNAKDMILMC_key = "";
		INLNJOGHLJE_Show = 0;
		CDMGDFLPPHN_Entry = 0;
		LNACKEBEMOB_Received = 0;
		HBODCMLFDOB_Result = "";
		OEDIICBDNKG_Pending = "";
	}

	// // RVA: 0xAA16D0 Offset: 0xAA16D0 VA: 0xAA16D0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		data["entry_date"] = EBAMGNMELPO_EntryDate;
		data[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = LJNAKDMILMC_key;
		data["show"] = INLNJOGHLJE_Show;
		data["entry"] = CDMGDFLPPHN_Entry;
		data["received"] = LNACKEBEMOB_Received;
		data["result"] = HBODCMLFDOB_Result;
		data["pending"] = OEDIICBDNKG_Pending;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xAA1A4C Offset: 0xAA1A4C VA: 0xAA1A4C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = true;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			isInvalid = false;
			EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
			if(!block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
				isInvalid = true;
			else
			{
				if((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
					isInvalid = true;
			}
			LJNAKDMILMC_key = FGCNMLBACGO_ReadString(block, "key", "", ref isInvalid);
			AJFDNKLNKDP_EntryDate_ = FGCNMLBACGO_ReadString(block, "entry_date", "", ref isInvalid);
			OKKAFCJGCJL = AJFDNKLNKDP_EntryDate_.GetHashCode();
			INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block, "show", 0, ref isInvalid);
			CDMGDFLPPHN_Entry = CJAENOMGPDA_ReadInt(block, "entry", 0, ref isInvalid);
			LNACKEBEMOB_Received = CJAENOMGPDA_ReadInt(block, "received", 0, ref isInvalid);
			OGMOHJIEDEA_Result_ = FGCNMLBACGO_ReadString(block, "result", "", ref isInvalid);
			BKIIKBEACDN = OGMOHJIEDEA_Result_.GetHashCode();
			KKJKOGHFGLB_Pending_ = FGCNMLBACGO_ReadString(block, "pending", "", ref isInvalid);
			CBPJHNHBLNN = KKJKOGHFGLB_Pending_.GetHashCode();
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return false;
	}

	// // RVA: 0xAA1E44 Offset: 0xAA1E44 VA: 0xAA1E44 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GGHPEFNADEN_Ticket other = GPBJHKLFCEP as GGHPEFNADEN_Ticket;
		LJNAKDMILMC_key = other.LJNAKDMILMC_key;
		EBAMGNMELPO_EntryDate = other.EBAMGNMELPO_EntryDate;
		OKKAFCJGCJL = EBAMGNMELPO_EntryDate.GetHashCode();
		INLNJOGHLJE_Show = other.INLNJOGHLJE_Show;
		CDMGDFLPPHN_Entry = other.CDMGDFLPPHN_Entry;
		LNACKEBEMOB_Received = other.LNACKEBEMOB_Received;
		HBODCMLFDOB_Result = other.HBODCMLFDOB_Result;
		BKIIKBEACDN = OGMOHJIEDEA_Result_.GetHashCode();
		OEDIICBDNKG_Pending = other.OEDIICBDNKG_Pending;
		CBPJHNHBLNN = OEDIICBDNKG_Pending.GetHashCode();
	}

	// // RVA: 0xAA2020 Offset: 0xAA2020 VA: 0xAA2020 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GGHPEFNADEN_Ticket other = GPBJHKLFCEP as GGHPEFNADEN_Ticket;
		if(INLNJOGHLJE_Show != other.INLNJOGHLJE_Show)
			return false;
		if(CDMGDFLPPHN_Entry != other.CDMGDFLPPHN_Entry)
			return false;
		if(LNACKEBEMOB_Received != other.LNACKEBEMOB_Received)
			return false;
		if(LJNAKDMILMC_key != other.LJNAKDMILMC_key)
			return false;
		if(AJFDNKLNKDP_EntryDate_ != other.AJFDNKLNKDP_EntryDate_)
			return false;
		if(OGMOHJIEDEA_Result_ != other.OGMOHJIEDEA_Result_)
			return false;
		if(KKJKOGHFGLB_Pending_ != other.KKJKOGHFGLB_Pending_)
			return false;
		return true;
	}

	// // RVA: 0xAA21DC Offset: 0xAA21DC VA: 0xAA21DC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0xAA2900 Offset: 0xAA2900 VA: 0xAA2900 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
