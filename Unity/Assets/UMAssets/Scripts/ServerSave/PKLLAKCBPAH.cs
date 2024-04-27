
using XeSys;

[System.Obsolete("Use PKLLAKCBPAH_DecoPublicInfo", true)]
public class PKLLAKCBPAH { }
public class PKLLAKCBPAH_DecoPublicInfo : KLFDBFMNLBL_ServerSaveBlock
{
	 private const int ECFEMKGFDCE = 1;
	 private int ENOBDCFHELD; // 0x24
	 private int FCEJCHGLFGN; // 0x28
	 private sbyte MLLAPPOGDJO; // 0x2C
	 private string LAJDGNJCMEH_SetName; // 0x30

	 public bool DGNMOIBJBBJ_HasEnabled { get { return MLLAPPOGDJO == 0x41; } set { MLLAPPOGDJO = (sbyte)(value ? 0x41 : 0x53); } } //GOOBCPPNKNF 0x93EF3C NBBIKPFKHME 0x93EF50
	 public string PCBDMADAIEO_SetName { get { return LAJDGNJCMEH_SetName; } set { LAJDGNJCMEH_SetName = value; } } //KBGEHDFKHJC 0x93EF80 KNBPHPFBGMI 0x93EF88
	public override bool DMICHEJIAJL { get { return true; } } // 0x93F2CC NFKFOODCJJB

	// // RVA: 0x93EF90 Offset: 0x93EF90 VA: 0x93EF90
	public PKLLAKCBPAH_DecoPublicInfo()
	{
		KMBPACJNEOF();
	}

	// // RVA: 0x93EFBC Offset: 0x93EFBC VA: 0x93EFBC Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x93EFC4 Offset: 0x93EFC4 VA: 0x93EFC4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				DGNMOIBJBBJ_HasEnabled = CJAENOMGPDA_ReadInt(block, "has_enabled", 0, ref isInvalid) != 0;
				LAJDGNJCMEH_SetName = FGCNMLBACGO_ReadString(block, "set_name", "", ref isInvalid);
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x93F1B4 Offset: 0x93F1B4 VA: 0x93F1B4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		PKLLAKCBPAH_DecoPublicInfo other = GPBJHKLFCEP as PKLLAKCBPAH_DecoPublicInfo;
		DGNMOIBJBBJ_HasEnabled = other.DGNMOIBJBBJ_HasEnabled;
		LAJDGNJCMEH_SetName = other.LAJDGNJCMEH_SetName;
	}

	// // RVA: 0x93F2D4 Offset: 0x93F2D4 VA: 0x93F2D4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x93F6E0 Offset: 0x93F6E0 VA: 0x93F6E0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		PKLLAKCBPAH_DecoPublicInfo other = GPBJHKLFCEP as PKLLAKCBPAH_DecoPublicInfo;
		return DGNMOIBJBBJ_HasEnabled == other.DGNMOIBJBBJ_HasEnabled && 
			LAJDGNJCMEH_SetName == other.LAJDGNJCMEH_SetName;
	}

	// // RVA: 0x93F820 Offset: 0x93F820 VA: 0x93F820 Slot: 4
	public override void KMBPACJNEOF()
	{
		ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0xf214);
		FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0xb7772e);
		DGNMOIBJBBJ_HasEnabled = false;
		LAJDGNJCMEH_SetName = "";
	}

	// // RVA: 0x93F8E8 Offset: 0x93F8E8 VA: 0x93F8E8 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data["has_enabled"] = DGNMOIBJBBJ_HasEnabled ? 1 : 0;
		data["set_name"] = LAJDGNJCMEH_SetName;
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = ECFEMKGFDCE;
			data2[JIKKNHIAEKG_BlockName] = data;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}
}
