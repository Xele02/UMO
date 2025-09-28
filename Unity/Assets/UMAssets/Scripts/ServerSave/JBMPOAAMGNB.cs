
[System.Obsolete("Use JBMPOAAMGNB_Base", true)]
public class JBMPOAAMGNB { }
public class JBMPOAAMGNB_Base : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public const int JDNKJIFMONK_CurrentVersion = 2;
	private static string IMHFIDMLLNI = JpStringLiterals.StringLiteral_9806; // 0x0
	private static string NBPICMBNPPB = JpStringLiterals.StringLiteral_9807; // 0x4
	public static bool NICIAENCMEG = false; // 0x8

	public int LLNDMKBBNIJ_ver { get; set; } // 0x24 BGOALFDCFBL OHMCGADLNCA KJNHDFEGEGE
	public string OPFGFINHFCE_name { get; set; } // 0x28 LGIIAPHCLPN DKJOHDGOIJE MJAMIGECMMF
	public string CMKKFCGBILD_prof { get; set; } // 0x2C JLHLBNNHPKA NCCACAFLMOO MNOEKLIDBJP
	public int IJHBIMNKOMC_tutorial_end { get; set; } // 0x30 DALCLLEGHAC DHDGMEEPOPC IDOPFHIMIDI
	public long AFPONJEJKCO_rename_date { get; set; } // 0x38 CIHJOFPCAFP LIOJMOEDFAN JJGOCLFAPMD
	public bool FNLNIKFNHAM_force_rename { get; set; } // 0x40 GAJKNOHAOMB KDLCLJKPMOF JLBBKAMOCNK
	public int PBEKKMOPENN_agree_tos_ver { get; set; } // 0x44 NJIKBJEECJP CBEOCBNKLFO OKJEOMMBCKA
	public override bool DMICHEJIAJL { get { return true; } } // 0x1422C30 NFKFOODCJJB

	// // RVA: 0x142163C Offset: 0x142163C VA: 0x142163C
	public JBMPOAAMGNB_Base()
	{
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1421668 Offset: 0x1421668 VA: 0x1421668 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		LLNDMKBBNIJ_ver = JDNKJIFMONK_CurrentVersion;
		OPFGFINHFCE_name = IMHFIDMLLNI;
		AFPONJEJKCO_rename_date = 0;
		CMKKFCGBILD_prof = NBPICMBNPPB;
		IJHBIMNKOMC_tutorial_end = 0;
		FNLNIKFNHAM_force_rename = false;
		PBEKKMOPENN_agree_tos_ver = 0;
	}

	// // RVA: 0x1421728 Offset: 0x1421728 VA: 0x1421728 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = OPFGFINHFCE_name;
		data[AFEHLCGHAEE_Strings.LLNDMKBBNIJ_ver] = LLNDMKBBNIJ_ver;
		data[AFEHLCGHAEE_Strings.CMKKFCGBILD_prof] = CMKKFCGBILD_prof;
		data[AFEHLCGHAEE_Strings.IJHBIMNKOMC_tutorial_end] = IJHBIMNKOMC_tutorial_end;
		data[AFEHLCGHAEE_Strings.AFPONJEJKCO_rename_date] = AFPONJEJKCO_rename_date;
		data[AFEHLCGHAEE_Strings.FNLNIKFNHAM_force_rename] = FNLNIKFNHAM_force_rename ? 1 : 0;
		data[AFEHLCGHAEE_Strings.PBEKKMOPENN_agree_tos_ver] = PBEKKMOPENN_agree_tos_ver;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1421B40 Offset: 0x1421B40 VA: 0x1421B40 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if (!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
			return false;
		EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		bool isInvalid = false;
		if(!block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev) || (int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
		{
			isInvalid = true;
		}
		OPFGFINHFCE_name = CEDHHAGBIBA.KJFAGPBALNO(FGCNMLBACGO_GetString(block, AFEHLCGHAEE_Strings.OPFGFINHFCE_name, IMHFIDMLLNI, ref isInvalid));
		LLNDMKBBNIJ_ver = CJAENOMGPDA_GetInt(block, AFEHLCGHAEE_Strings.LLNDMKBBNIJ_ver, 1, ref isInvalid);
		CMKKFCGBILD_prof = FGCNMLBACGO_GetString(block, AFEHLCGHAEE_Strings.CMKKFCGBILD_prof, NBPICMBNPPB, ref isInvalid);
		IJHBIMNKOMC_tutorial_end = CJAENOMGPDA_GetInt(block, AFEHLCGHAEE_Strings.IJHBIMNKOMC_tutorial_end, 0, ref isInvalid);
		FNLNIKFNHAM_force_rename = CJAENOMGPDA_GetInt(block, AFEHLCGHAEE_Strings.FNLNIKFNHAM_force_rename, 0, ref isInvalid) != 0;
		PBEKKMOPENN_agree_tos_ver = CJAENOMGPDA_GetInt(block, AFEHLCGHAEE_Strings.PBEKKMOPENN_agree_tos_ver, 0, ref isInvalid);
		AFPONJEJKCO_rename_date = FNLNIKFNHAM_force_rename ? 0 : DKMPHAPBDLH_GetLong(block, AFEHLCGHAEE_Strings.AFPONJEJKCO_rename_date, 0, ref isInvalid);
		if(OPFGFINHFCE_name.Length > 10)
			OPFGFINHFCE_name = OPFGFINHFCE_name.Substring(0, 10);
		if (CMKKFCGBILD_prof.Length > 25)
			CMKKFCGBILD_prof = CMKKFCGBILD_prof.Substring(0, 25);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x1422000 Offset: 0x1422000 VA: 0x1422000 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JBMPOAAMGNB_Base b = GPBJHKLFCEP as JBMPOAAMGNB_Base;
		OPFGFINHFCE_name = string.Copy(b.OPFGFINHFCE_name);
		LLNDMKBBNIJ_ver = b.LLNDMKBBNIJ_ver;
		CMKKFCGBILD_prof = string.Copy(b.CMKKFCGBILD_prof);
		IJHBIMNKOMC_tutorial_end = b.IJHBIMNKOMC_tutorial_end;
		FNLNIKFNHAM_force_rename = b.FNLNIKFNHAM_force_rename;
		AFPONJEJKCO_rename_date = b.AFPONJEJKCO_rename_date;
		PBEKKMOPENN_agree_tos_ver = b.PBEKKMOPENN_agree_tos_ver;
	}

	// // RVA: 0x14221CC Offset: 0x14221CC VA: 0x14221CC Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JBMPOAAMGNB_Base other = GPBJHKLFCEP as JBMPOAAMGNB_Base;
		if(OPFGFINHFCE_name != other.OPFGFINHFCE_name ||
			LLNDMKBBNIJ_ver != other.LLNDMKBBNIJ_ver ||
			CMKKFCGBILD_prof != other.CMKKFCGBILD_prof || 
			FNLNIKFNHAM_force_rename != other.FNLNIKFNHAM_force_rename ||
			PBEKKMOPENN_agree_tos_ver != other.PBEKKMOPENN_agree_tos_ver ||
			AFPONJEJKCO_rename_date != other.AFPONJEJKCO_rename_date ||
			IJHBIMNKOMC_tutorial_end != other.IJHBIMNKOMC_tutorial_end)
			return false;
		return true;
	}

	// // RVA: 0x142245C Offset: 0x142245C VA: 0x142245C Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
