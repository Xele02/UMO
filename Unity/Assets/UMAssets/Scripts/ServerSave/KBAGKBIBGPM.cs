
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use KBAGKBIBGPM_EventRaidLobby", true)]
public class KBAGKBIBGPM { }
public class KBAGKBIBGPM_EventRaidLobby : KLFDBFMNLBL_ServerSaveBlock
{
	public class JAIFDODKMIA
	{
		private int ENOBDCFHELD; // 0x8
		private int FCEJCHGLFGN; // 0xC
		public int AFGHJEJKDHN_Crypted; // 0x10
		public int FBDJBMDEENG_Crypted; // 0x14
		private int HFIHMDILNFD_Crypted; // 0x18
		private int IGMFFIKLEHP_Crypted; // 0x1C
		private int GEIHLKKJNDG_Crypted; // 0x20
		private int BIOAGBAPPJA_Crypted; // 0x24
		private int BHFAGDDEOKC_Crypted; // 0x28
		private int EOODGLMGDLC_Crypted; // 0x2C
		private List<CEBFFLDKAEC_SecureInt> LJKMKCOAICL_ItemCnt = new List<CEBFFLDKAEC_SecureInt>(3); // 0x30
		public bool CJALBNNJOOB_IsFl; // 0x34
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(50); // 0x38
		public string MPCAGEPEJJJ_Key; // 0x3C
		public long EGBOHDFBAPB_End; // 0x40
		public string MDADLCOCEBN_SessionId = ""; // 0x48

		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_Crypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_Crypted = value ^ ENOBDCFHELD; FBDJBMDEENG_Crypted = value ^ FCEJCHGLFGN; } } //0x1014918 MAFBDLKFHGJ 0x10153DC EPEFBOIALDI
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } //0x1014928 PBEMPHPDDDB 0x10153F0 MCADMIEOCCF
		public int KMMJMDGLIFA_FrCns { get { return GEIHLKKJNDG_Crypted ^ ENOBDCFHELD; } set { GEIHLKKJNDG_Crypted = value ^ ENOBDCFHELD; BIOAGBAPPJA_Crypted = value ^ FCEJCHGLFGN; } } //0x1014938 ODELLHEMAAK 0x1015404 DNGGAOCFLAB
		public int GNICDMGKMEP_Qu { get { return BHFAGDDEOKC_Crypted ^ ENOBDCFHELD; } set { BHFAGDDEOKC_Crypted = value ^ ENOBDCFHELD; EOODGLMGDLC_Crypted = value ^ FCEJCHGLFGN; } } //0x1014948 CHJKNNCKKJP 0x1015418 FCPDMGEHNCK
		public bool BOKPBNGHOGM { get { return (((BHFAGDDEOKC_Crypted ^ ENOBDCFHELD) << 1) >> 31) != 0; } set { if(value) BHFAGDDEOKC_Crypted = ((BHFAGDDEOKC_Crypted ^ ENOBDCFHELD) | 0x40000000) ^ ENOBDCFHELD; else BHFAGDDEOKC_Crypted = (int)((BHFAGDDEOKC_Crypted ^ ENOBDCFHELD) & 0xbfffffff) ^ ENOBDCFHELD; EOODGLMGDLC_Crypted = BHFAGDDEOKC_Crypted ^ ENOBDCFHELD ^ FCEJCHGLFGN; } } //0x10183B4 MAMKCDMOCEG 0x10183C8 CHCMNLGGHBH
		public int LAGLPDDLMCK { get { return (BHFAGDDEOKC_Crypted ^ ENOBDCFHELD) & 0x3fffffff; } set { BHFAGDDEOKC_Crypted = ((int)((BHFAGDDEOKC_Crypted ^ ENOBDCFHELD) & 0xc0000000) | value) ^ ENOBDCFHELD; EOODGLMGDLC_Crypted = BHFAGDDEOKC_Crypted ^ ENOBDCFHELD ^ FCEJCHGLFGN; } } //0x10183FC CAJJKOMKCEI 0x1018410 CIOPEIBIKNP

		// // RVA: 0x101817C Offset: 0x101817C VA: 0x101817C
		// public bool MILHIALDDLG() { }

		// // RVA: 0x101819C Offset: 0x101819C VA: 0x101819C
		// public bool LHBMFPPPFBM() { }

		// // RVA: 0x1014878 Offset: 0x1014878 VA: 0x1014878
		public int KAINPNMMAEK_GetItemCount(RaidItemConstants.Type INDDJNMPONH)
		{
			return LJKMKCOAICL_ItemCnt[(int)INDDJNMPONH - 1].DNJEJEANJGL_Value;
		}

		// // RVA: 0x101830C Offset: 0x101830C VA: 0x101830C
		public void PPJAGFPBFHJ_SetItemCount(RaidItemConstants.Type INDDJNMPONH, int HMFFHLPNMPH)
		{
			LJKMKCOAICL_ItemCnt[(int)INDDJNMPONH - 1].DNJEJEANJGL_Value = HMFFHLPNMPH;
		}

		// // RVA: 0x10181BC Offset: 0x10181BC VA: 0x10181BC
		// public bool IINDHOJJOJO() { }

		// // RVA: 0x10182AC Offset: 0x10182AC VA: 0x10182AC
		// public bool MGFEHOKAFOC() { }

		// // RVA: 0x1013D08 Offset: 0x1013D08 VA: 0x1013D08
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x8730115;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_End = 0;
			CJALBNNJOOB_IsFl = false;
			LGADCGFMLLD_Step = 0;
			OMCAOJJGOGG_Lb = 0;
			KMMJMDGLIFA_FrCns = 0;
			GNICDMGKMEP_Qu = 0;
			LJKMKCOAICL_ItemCnt.Clear();
			for(int i = 0; i < 3; i++)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				v.LHPDDGIJKNB_Reset(ENOBDCFHELD, FCEJCHGLFGN);
				LJKMKCOAICL_ItemCnt.Add(v);
			}
			NNMPGOAGEOL_Quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			MDADLCOCEBN_SessionId = "";
		}

		// // RVA: 0x10155FC Offset: 0x10155FC VA: 0x10155FC
		public void ODDIHGPONFL(JAIFDODKMIA GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			KMMJMDGLIFA_FrCns = GPBJHKLFCEP.KMMJMDGLIFA_FrCns;
			GNICDMGKMEP_Qu = GPBJHKLFCEP.GNICDMGKMEP_Qu;
			for(int i = 0; i < 3; i++)
			{
				LJKMKCOAICL_ItemCnt[i].DNJEJEANJGL_Value = GPBJHKLFCEP.LJKMKCOAICL_ItemCnt[i].DNJEJEANJGL_Value;
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			MDADLCOCEBN_SessionId = GPBJHKLFCEP.MDADLCOCEBN_SessionId;
		}

		// // RVA: 0x1015ABC Offset: 0x1015ABC VA: 0x1015ABC
		public bool AGBOGBEOFME(JAIFDODKMIA OIKJFMGEICL)
		{
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(KMMJMDGLIFA_FrCns != OIKJFMGEICL.KMMJMDGLIFA_FrCns)
				return false;
			if(CJALBNNJOOB_IsFl != OIKJFMGEICL.CJALBNNJOOB_IsFl)
				return false;
			if(LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step)
				return false;
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(GNICDMGKMEP_Qu != OIKJFMGEICL.GNICDMGKMEP_Qu)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId)
				return false;
			for(int i = 0; i < 3; i++)
			{
				if(LJKMKCOAICL_ItemCnt[i].DNJEJEANJGL_Value != OIKJFMGEICL.LJKMKCOAICL_ItemCnt[i].DNJEJEANJGL_Value)
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0x10162C4 Offset: 0x10162C4 VA: 0x10162C4
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, KBAGKBIBGPM.JAIFDODKMIA OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 1;
	public const int ICHFGGBPCBJ = 4;
	public const int BJEPEBMLKOL = 50;
	public const int HNDHMLCHKFM = 1073741824;
	public const int NEJCHBPCHOP = 1073741823;
	public List<JAIFDODKMIA> FBCJICEPLED = new List<JAIFDODKMIA>(4); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0x10182CC NFKFOODCJJB

	// // RVA: 0x1013AA8 Offset: 0x1013AA8 VA: 0x1013AA8
	public KBAGKBIBGPM_EventRaidLobby()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x1013B44 Offset: 0x1013B44 VA: 0x1013B44 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 4; i++)
		{
			JAIFDODKMIA data = new JAIFDODKMIA();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x1013F84 Offset: 0x1013F84 VA: 0x1013F84 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 4; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data2.Add(FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 3; j++)
			{
				data3.Add(FBCJICEPLED[i].KAINPNMMAEK_GetItemCount((RaidItemConstants.Type)j + 1));
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data4[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data4[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_Step;
			data4[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data2;
			data4[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_SessionId;
			data4["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data4["fr_cns"] = FBCJICEPLED[i].KMMJMDGLIFA_FrCns;
			data4["is_fl"] = FBCJICEPLED[i].CJALBNNJOOB_IsFl ? 1 : 0;
			data4["item_cnt"] = data3;
			data4["qu"] = FBCJICEPLED[i].GNICDMGKMEP_Qu;
			data.Add(data4);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1014958 Offset: 0x1014958 VA: 0x1014958 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if(block.HNBFOAJIIAL_Count > 0)
				{
					int cnt = block.HNBFOAJIIAL_Count;
					if(cnt >= 5)
					{
						isInvalid = true;
						cnt = 4;
					}
					for(int i = 0; i < cnt; i++)
					{
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].LGADCGFMLLD_Step = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(block[i], "lb", 0, ref isInvalid);
						FBCJICEPLED[i].KMMJMDGLIFA_FrCns = CJAENOMGPDA_ReadInt(block[i], "fr_cns", 0, ref isInvalid);
						FBCJICEPLED[i].CJALBNNJOOB_IsFl = CJAENOMGPDA_ReadInt(block[i], "is_fl", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].GNICDMGKMEP_Qu = CJAENOMGPDA_ReadInt(block[i], "qu", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], "item_cnt", 0, 3, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x10182D4
							FBCJICEPLED[i].PPJAGFPBFHJ_SetItemCount((RaidItemConstants.Type)OIPCCBHIKIA + 1, JBGEEPFKIGG);
						}, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData d = block[i][AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt2 = d.HNBFOAJIIAL_Count;
							if(cnt2 > 50)
								cnt2 = 50;
							for(int j = 0; j < 50; j++)
							{
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(d[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(d[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x101542C Offset: 0x101542C VA: 0x101542C Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		KBAGKBIBGPM_EventRaidLobby other = GPBJHKLFCEP as KBAGKBIBGPM_EventRaidLobby;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x10158DC Offset: 0x10158DC VA: 0x10158DC Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		KBAGKBIBGPM_EventRaidLobby other = GPBJHKLFCEP as KBAGKBIBGPM_EventRaidLobby;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1015EB8 Offset: 0x1015EB8 VA: 0x1015EB8 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x1017F88 Offset: 0x1017F88 VA: 0x1017F88 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
