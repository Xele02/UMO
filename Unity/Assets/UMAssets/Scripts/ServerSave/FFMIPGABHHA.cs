
using System.Text;

[System.Obsolete("Use FFMIPGABHHA_SaveHash", true)]
public class FFMIPGABHHA { }
public class FFMIPGABHHA_SaveHash : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public const long BBEGLBMOBOF_xorl = 0x77ccefaa9;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	public string IOIMHJAOKOO_Hash; // 0x24
	private long KLAPHOKNEDG_DateCrypted; // 0x28
	public long AFNJCFEKFDD_Dirty; // 0x30

	public long BEBJKJKBOGH_date { get { return KLAPHOKNEDG_DateCrypted ^ BBEGLBMOBOF_xorl; } set { KLAPHOKNEDG_DateCrypted = value ^ BBEGLBMOBOF_xorl; } } //DIAPHCJBPFD_get_date 0x14E4B88 IHAIKPNEEJE 0x14E4BA0
	public override bool DMICHEJIAJL { get { return true; } } // 0x14E5A68 NFKFOODCJJB

	// // RVA: 0x14E4BBC Offset: 0x14E4BBC VA: 0x14E4BBC
	public static string CAOGDCBPBAN(string _MDADLCOCEBN_session_id, int _EHDDADDKMFI_f_id, int _FEOKKEPAIBB_diff)
	{
		StringBuilder str = new StringBuilder();
		str.Append(_MDADLCOCEBN_session_id);
		str.Append('-');
		str.Append(_EHDDADDKMFI_f_id);
		str.Append('-');
		str.Append(_FEOKKEPAIBB_diff);
		str.Append('-');
		str.Append(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
		return str.ToString();
	}

	// // RVA: 0x14E4E1C Offset: 0x14E4E1C VA: 0x14E4E1C
	public FFMIPGABHHA_SaveHash()
	{
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x14E4E48 Offset: 0x14E4E48 VA: 0x14E4E48 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		BEBJKJKBOGH_date = 0;
		AFNJCFEKFDD_Dirty = 0;
		IOIMHJAOKOO_Hash = "";
	}

	// // RVA: 0x14E4EC8 Offset: 0x14E4EC8 VA: 0x14E4EC8 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		data["hash"] = IOIMHJAOKOO_Hash;
		data["date"] = BEBJKJKBOGH_date;
		data["dirty"] = AFNJCFEKFDD_Dirty;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

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
			IOIMHJAOKOO_Hash = FGCNMLBACGO_GetString(block, "hash", "", ref isInvalid);
			BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(block, "date", 0, ref isInvalid);
			AFNJCFEKFDD_Dirty = DKMPHAPBDLH_GetLong(block, "dirty", 0, ref isInvalid);
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x14E5400 Offset: 0x14E5400 VA: 0x14E5400 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FFMIPGABHHA_SaveHash s = GPBJHKLFCEP as FFMIPGABHHA_SaveHash;
		IOIMHJAOKOO_Hash = string.Copy(s.IOIMHJAOKOO_Hash);
		BEBJKJKBOGH_date = s.BEBJKJKBOGH_date;
		AFNJCFEKFDD_Dirty = s.AFNJCFEKFDD_Dirty;
	}

	// // RVA: 0x14E5558 Offset: 0x14E5558 VA: 0x14E5558 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FFMIPGABHHA_SaveHash other = GPBJHKLFCEP as FFMIPGABHHA_SaveHash;
		if(BEBJKJKBOGH_date != other.BEBJKJKBOGH_date ||
			IOIMHJAOKOO_Hash != other.IOIMHJAOKOO_Hash ||
			AFNJCFEKFDD_Dirty != other.AFNJCFEKFDD_Dirty)
			return false;
		return true;
	}

	// // RVA: 0x14E56AC Offset: 0x14E56AC VA: 0x14E56AC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
