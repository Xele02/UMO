
[System.Obsolete("Use MKNIBACMCDO_AssistPlate", true)]
public class MKNIBACMCDO { }
public class MKNIBACMCDO_AssistPlate : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE_CurrentVersion = 2;
	public const int FBBENLHJFKO = 5;
	private int FBGGEFFJJHB_xor; // 0x24
	public JNMFKOHFAFB_PublicStatus.ONCMONJIPCD[] LDIINNKMLLO = new JNMFKOHFAFB_PublicStatus.ONCMONJIPCD[5]; // 0x28
	public int NBIIKNFOLLK; // 0x2C

	public int HODDNKENKHD_Page { get { return NBIIKNFOLLK ^ FBGGEFFJJHB_xor; } set { NBIIKNFOLLK = value ^ FBGGEFFJJHB_xor; } } //EMLKHGADCIE_bgs 0x195AB08 LAGDPCMEBOD_bgs 0x195AB18

	// // RVA: 0x195AA5C Offset: 0x195AA5C VA: 0x195AA5C
	public MKNIBACMCDO_AssistPlate()
	{
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
	}

	// // RVA: 0x195AB28 Offset: 0x195AB28 VA: 0x195AB28 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		for(int i = 0; i < 5; i++)
		{
			LDIINNKMLLO[i] = new JNMFKOHFAFB_PublicStatus.ONCMONJIPCD();
			LDIINNKMLLO[i].KMBPACJNEOF_Reset(i);
		}
		HODDNKENKHD_Page = 0;
	}

	// // RVA: 0x195AC68 Offset: 0x195AC68 VA: 0x195AC68 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MKNIBACMCDO_AssistPlate a = GPBJHKLFCEP as MKNIBACMCDO_AssistPlate;
		for(int i = 0; i < 5; i++)
		{
			LDIINNKMLLO[i].ODDIHGPONFL_Copy(a.LDIINNKMLLO[i]);
		}
		HODDNKENKHD_Page = a.HODDNKENKHD_Page;
	}

	// // RVA: 0x195AE1C Offset: 0x195AE1C VA: 0x195AE1C Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x195B1D0 Offset: 0x195B1D0 VA: 0x195B1D0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MKNIBACMCDO_AssistPlate other = GPBJHKLFCEP as MKNIBACMCDO_AssistPlate;
		for(int i = 0; i < LDIINNKMLLO.Length; i++)
		{
			if (!LDIINNKMLLO[i].AGBOGBEOFME(other.LDIINNKMLLO[i]))
				return false;
		}
		return HODDNKENKHD_Page == other.HODDNKENKHD_Page;
	}

	// // RVA: 0x195B3C8 Offset: 0x195B3C8 VA: 0x195B3C8 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x195B3D0 Offset: 0x195B3D0 VA: 0x195B3D0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.EOKMNCPJMCO_assist_list] = EOLCFDGNIJI();
		data["page"] = HODDNKENKHD_Page;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x195B098 Offset: 0x195B098 VA: 0x195B098
	private EDOHBJAPLPF_JsonData EOLCFDGNIJI()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		OAILDDLJFEE o = new OAILDDLJFEE();
		for(int i = 0; i < LDIINNKMLLO.Length; i++)
		{
			data.Add(o.LPGBJBHFINB(LDIINNKMLLO[i]));
		}
		return data;
	}

	// // RVA: 0x195B560 Offset: 0x195B560 VA: 0x195B560 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			HODDNKENKHD_Page = CJAENOMGPDA_GetInt(OILEIIEIBHP[JIKKNHIAEKG_BlockName], "page", 0, ref isInvalid);
			FIFBCMMEPOE(OILEIIEIBHP[JIKKNHIAEKG_BlockName], ref isInvalid);
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		KFKDMBPNLJK_BlockInvalid = true;
		return false;
	}

	// // RVA: 0x195B680 Offset: 0x195B680 VA: 0x195B680
	private void FIFBCMMEPOE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(OBHAFLMHAKG.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EOKMNCPJMCO_assist_list))
		{
			for(int i = 0; i < 5; i++)
			{
				LFNFJHGDKAA(LDIINNKMLLO[i], OBHAFLMHAKG[AFEHLCGHAEE_Strings.EOKMNCPJMCO_assist_list][i], ref _NGJDHLGMHMH_IsInvalid);
			}
		}
	}

	// // RVA: 0x195B834 Offset: 0x195B834 VA: 0x195B834
	private void LFNFJHGDKAA(JNMFKOHFAFB_PublicStatus.ONCMONJIPCD _IDLHJIOMJBK_data, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		for(int i = 0; i < 4; i++)
		{
			EHEMJOHCJOG(_IDLHJIOMJBK_data.JOHLGBDOLNO_AssistScenes[i], OBHAFLMHAKG[AFEHLCGHAEE_Strings.GGLICPAANFE_assist_data_list][i], ref _NGJDHLGMHMH_IsInvalid);
		}
		_IDLHJIOMJBK_data.JCJNKBKMJFK_Name = FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.COEBIDJMMCH_assist_name, "", ref _NGJDHLGMHMH_IsInvalid);
	}

	// // RVA: 0x195BA04 Offset: 0x195BA04 VA: 0x195BA04
	private void EHEMJOHCJOG(JNMFKOHFAFB_PublicStatus.KNHIPBADANI KDIFMECGNIC, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		KDIFMECGNIC.KMBPACJNEOF_Reset();
		KDIFMECGNIC.PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref _NGJDHLGMHMH_IsInvalid);
		bool isReset = false;
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(KDIFMECGNIC.PPFNGGCBJKC_id))
				{
					isReset = true;
					KDIFMECGNIC.PPFNGGCBJKC_id = 0;
				}
			}
		}
		KDIFMECGNIC.ANAJIAENLNB_lv = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.GKOAEJDMLED_reward_opened_at, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.MJBODMOLOBC_luck = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.MJBODMOLOBC_luck, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.JPIPENJGGDD_NumBoard = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.DMNIMMGGJJJ_Leaf = CJAENOMGPDA_GetInt(OBHAFLMHAKG, "leaf", 0, ref _NGJDHLGMHMH_IsInvalid);
		if(isReset)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.AJHBAOCLNDF_MasterSw != 2)
			{
				KDIFMECGNIC.DMNIMMGGJJJ_Leaf = 0;
			}
		}
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.PDNIFBEGMHC_Mb, FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.DANMJLOBLIE_mb, "", ref _NGJDHLGMHMH_IsInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.EMOJHJGHJLN_Sb, FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.KOHNLDKIKPC_sb, "", ref _NGJDHLGMHMH_IsInvalid));
		KDIFMECGNIC.ANAJIAENLNB_lv = CEDHHAGBIBA.OGPFNHOKONH_GetNumBitActive(KDIFMECGNIC.PDNIFBEGMHC_Mb) + 1;
		if (KDIFMECGNIC.MJBODMOLOBC_luck < 0)
			KDIFMECGNIC.MJBODMOLOBC_luck = 0;
		if(KDIFMECGNIC.MJBODMOLOBC_luck > 25)
			KDIFMECGNIC.MJBODMOLOBC_luck = 25;
	}
}
