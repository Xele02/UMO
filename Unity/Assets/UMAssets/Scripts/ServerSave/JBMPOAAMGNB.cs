
[System.Obsolete("Use JBMPOAAMGNB_Base", true)]
public class JBMPOAAMGNB { }
public class JBMPOAAMGNB_Base : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	public const int JDNKJIFMONK_CurrentVersion = 2;
	private static string IMHFIDMLLNI = JpStringLiterals.StringLiteral_9806; // 0x0
	private static string NBPICMBNPPB = JpStringLiterals.StringLiteral_9807; // 0x4
	public static bool NICIAENCMEG = false; // 0x8

	public int LLNDMKBBNIJ_Version { get; set; } // 0x24 BGOALFDCFBL OHMCGADLNCA KJNHDFEGEGE
	public string OPFGFINHFCE_PlayerName { get; set; } // 0x28 LGIIAPHCLPN DKJOHDGOIJE MJAMIGECMMF
	public string CMKKFCGBILD_Prof { get; set; } // 0x2C JLHLBNNHPKA NCCACAFLMOO MNOEKLIDBJP
	public int IJHBIMNKOMC_TutorialEnd { get; set; } // 0x30 DALCLLEGHAC DHDGMEEPOPC IDOPFHIMIDI
	public long AFPONJEJKCO_RenameDate { get; set; } // 0x38 CIHJOFPCAFP LIOJMOEDFAN JJGOCLFAPMD
	public bool FNLNIKFNHAM_ForceRename { get; set; } // 0x40 GAJKNOHAOMB KDLCLJKPMOF JLBBKAMOCNK
	public int PBEKKMOPENN_AgreeTosVer { get; set; } // 0x44 NJIKBJEECJP CBEOCBNKLFO OKJEOMMBCKA
	public override bool DMICHEJIAJL { get { return true; } } // 0x1422C30 NFKFOODCJJB

	// // RVA: 0x142163C Offset: 0x142163C VA: 0x142163C
	public JBMPOAAMGNB_Base()
	{
		KMBPACJNEOF();
	}

	// // RVA: 0x1421668 Offset: 0x1421668 VA: 0x1421668 Slot: 4
	public override void KMBPACJNEOF()
	{
		LLNDMKBBNIJ_Version = JDNKJIFMONK_CurrentVersion;
		OPFGFINHFCE_PlayerName = IMHFIDMLLNI;
		AFPONJEJKCO_RenameDate = 0;
		CMKKFCGBILD_Prof = NBPICMBNPPB;
		IJHBIMNKOMC_TutorialEnd = 0;
		FNLNIKFNHAM_ForceRename = false;
		PBEKKMOPENN_AgreeTosVer = 0;

		if (RuntimeSettings.CurrentSettings.ForceTutoSkip)
			IJHBIMNKOMC_TutorialEnd = 2;
	}

	// // RVA: 0x1421728 Offset: 0x1421728 VA: 0x1421728 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = OPFGFINHFCE_PlayerName;
		data[AFEHLCGHAEE_Strings.LLNDMKBBNIJ_ver] = LLNDMKBBNIJ_Version;
		data[AFEHLCGHAEE_Strings.CMKKFCGBILD_prof] = CMKKFCGBILD_Prof;
		data[AFEHLCGHAEE_Strings.IJHBIMNKOMC_tutorial_end] = IJHBIMNKOMC_TutorialEnd;
		data[AFEHLCGHAEE_Strings.AFPONJEJKCO_rename_date] = AFPONJEJKCO_RenameDate;
		data[AFEHLCGHAEE_Strings.FNLNIKFNHAM_force_rename] = FNLNIKFNHAM_ForceRename ? 1 : 0;
		data[AFEHLCGHAEE_Strings.PBEKKMOPENN_agree_tos_ver] = PBEKKMOPENN_AgreeTosVer;
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
		OPFGFINHFCE_PlayerName = CEDHHAGBIBA.KJFAGPBALNO(FGCNMLBACGO_ReadString(block, AFEHLCGHAEE_Strings.OPFGFINHFCE_name, IMHFIDMLLNI, ref isInvalid));
		LLNDMKBBNIJ_Version = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.LLNDMKBBNIJ_ver, 1, ref isInvalid);
		CMKKFCGBILD_Prof = FGCNMLBACGO_ReadString(block, AFEHLCGHAEE_Strings.CMKKFCGBILD_prof, NBPICMBNPPB, ref isInvalid);
		IJHBIMNKOMC_TutorialEnd = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.IJHBIMNKOMC_tutorial_end, 0, ref isInvalid);
		FNLNIKFNHAM_ForceRename = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.FNLNIKFNHAM_force_rename, 0, ref isInvalid) != 0;
		PBEKKMOPENN_AgreeTosVer = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.PBEKKMOPENN_agree_tos_ver, 0, ref isInvalid);
		AFPONJEJKCO_RenameDate = FNLNIKFNHAM_ForceRename ? 0 : DKMPHAPBDLH_ReadLong(block, AFEHLCGHAEE_Strings.AFPONJEJKCO_rename_date, 0, ref isInvalid);
		if(OPFGFINHFCE_PlayerName.Length > 10)
			OPFGFINHFCE_PlayerName = OPFGFINHFCE_PlayerName.Substring(0, 10);
		if (CMKKFCGBILD_Prof.Length > 25)
			CMKKFCGBILD_Prof = CMKKFCGBILD_Prof.Substring(0, 25);
		KFKDMBPNLJK_BlockInvalid = isInvalid;

		if(RuntimeSettings.CurrentSettings.ForceTutoSkip)
			IJHBIMNKOMC_TutorialEnd = 2;
		return true;
	}

	// // RVA: 0x1422000 Offset: 0x1422000 VA: 0x1422000 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JBMPOAAMGNB_Base b = GPBJHKLFCEP as JBMPOAAMGNB_Base;
		OPFGFINHFCE_PlayerName = string.Copy(b.OPFGFINHFCE_PlayerName);
		LLNDMKBBNIJ_Version = b.LLNDMKBBNIJ_Version;
		CMKKFCGBILD_Prof = string.Copy(b.CMKKFCGBILD_Prof);
		IJHBIMNKOMC_TutorialEnd = b.IJHBIMNKOMC_TutorialEnd;
		FNLNIKFNHAM_ForceRename = b.FNLNIKFNHAM_ForceRename;
		AFPONJEJKCO_RenameDate = b.AFPONJEJKCO_RenameDate;
		PBEKKMOPENN_AgreeTosVer = b.PBEKKMOPENN_AgreeTosVer;
	}

	// // RVA: 0x14221CC Offset: 0x14221CC VA: 0x14221CC Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JBMPOAAMGNB_Base other = GPBJHKLFCEP as JBMPOAAMGNB_Base;
		if(OPFGFINHFCE_PlayerName != other.OPFGFINHFCE_PlayerName ||
			LLNDMKBBNIJ_Version != other.LLNDMKBBNIJ_Version ||
			CMKKFCGBILD_Prof != other.CMKKFCGBILD_Prof || 
			FNLNIKFNHAM_ForceRename != other.FNLNIKFNHAM_ForceRename ||
			PBEKKMOPENN_AgreeTosVer != other.PBEKKMOPENN_AgreeTosVer ||
			AFPONJEJKCO_RenameDate != other.AFPONJEJKCO_RenameDate ||
			IJHBIMNKOMC_TutorialEnd != other.IJHBIMNKOMC_TutorialEnd)
			return false;
		return true;
	}

	// // RVA: 0x142245C Offset: 0x142245C VA: 0x142245C Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}
}
