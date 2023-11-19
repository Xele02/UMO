
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use FMFBNHLMHPL_EventAprilFool", true)]
public class FMFBNHLMHPL { }
public class FMFBNHLMHPL_EventAprilFool : KLFDBFMNLBL_ServerSaveBlock
{
	public class LCFOEDLCCON
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public int AFGHJEJKDHN_StepCrypted; // 0x10
		public int FBDJBMDEENG; // 0x14
		public sbyte JDNEMJLJJLC_PickupCrypted; // 0x18
		public string MDADLCOCEBN_SessionId = ""; // 0x1C
		public int HFIHMDILNFD_LbCrypted; // 0x20
		public int IGMFFIKLEHP_LbCrypted2; // 0x24
		public long BEBJKJKBOGH_Date; // 0x28
		public int IACIALIHPAJ_ActCrypted; // 0x30
		public int MJGLINBDCKG; // 0x34
		public int PPHCFBMEDND_IsMinigameClearCrypted; // 0x38
		public int MILIPFCLCNC_IsMinigameClearCrypted2; // 0x3C
		public List<IKCGAJKCPFN> NNMPGOAGEOL = new List<IKCGAJKCPFN>(50); // 0x40
		public string MPCAGEPEJJJ_Key; // 0x44
		public long EGBOHDFBAPB_End; // 0x48
		public bool IMFBCJOIJKJ_Entry; // 0x50
		public bool ABBJBPLHFHA_Spurt; // 0x51
		public int INLNJOGHLJE_Show; // 0x54
		public int MHKICPIMFEI_PlayCnt; // 0x58
		public List<CEBFFLDKAEC_SecureInt> AAJOOBMPOEP = new List<CEBFFLDKAEC_SecureInt>(1); // 0x5C

		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_StepCrypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_StepCrypted = ENOBDCFHELD ^ value; FBDJBMDEENG = FCEJCHGLFGN ^ value; } } //0x1199604 MAFBDLKFHGJ 0x119A410 EPEFBOIALDI
		public bool PPKAKKGCAOJ_IsPickup { get { return JDNEMJLJJLC_PickupCrypted == 87; } set { JDNEMJLJJLC_PickupCrypted = value ? (sbyte)87 : (sbyte)19; } } //0x11995F0 KBHPMOPAPBL 0x119A3E0 FJGACEGCMGM
		public int CFKFIODHFNC_Act { get { return ENOBDCFHELD ^ IACIALIHPAJ_ActCrypted; } set { IACIALIHPAJ_ActCrypted = ENOBDCFHELD ^ value; MJGLINBDCKG = FCEJCHGLFGN ^ value; } } //0x1199614 OHHANDMGKHM 0x119A424 PLHGJGHHEOP
		public bool KBAHNBKMFDL_IsMinigameClear { get { return (PPHCFBMEDND_IsMinigameClearCrypted ^ ENOBDCFHELD) == 87; } set { PPHCFBMEDND_IsMinigameClearCrypted = ENOBDCFHELD ^ (value ? 87 : 19); MILIPFCLCNC_IsMinigameClearCrypted2 = FCEJCHGLFGN ^ (value ? 87 : 19); } } //0x1199624 AJJDGCJIILD 0x119A438 KJJGGIBOMHP
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_LbCrypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_LbCrypted = ENOBDCFHELD ^ value; IGMFFIKLEHP_LbCrypted2 = FCEJCHGLFGN ^ value; } } //0x1199640 PBEMPHPDDDB 0x119A49C MCADMIEOCCF

		//// RVA: 0x1198788 Offset: 0x1198788 VA: 0x1198788
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime() ^ 0x1741147;
			FCEJCHGLFGN = (int)Utility.GetCurrentUnixTime() ^ 0x7411141;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_End = 0;
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			PPKAKKGCAOJ_IsPickup = true;
			INLNJOGHLJE_Show = 0;
			OMCAOJJGOGG_Lb = 0;
			LGADCGFMLLD_Step = 0;
			NNMPGOAGEOL.Clear();
			int k = ENOBDCFHELD + 5;
			for (int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN data = new IKCGAJKCPFN();
				data.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL.Add(data);
				k *= 13;
			}
			MHKICPIMFEI_PlayCnt = 0;
			BEBJKJKBOGH_Date = 0;
			CFKFIODHFNC_Act = 0;
			KBAHNBKMFDL_IsMinigameClear = false;
			AAJOOBMPOEP.Clear();
			AAJOOBMPOEP.Add(new CEBFFLDKAEC_SecureInt());
		}

		//// RVA: 0x119A680 Offset: 0x119A680 VA: 0x119A680
		public void ODDIHGPONFL(LCFOEDLCCON GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			PPKAKKGCAOJ_IsPickup = GPBJHKLFCEP.PPKAKKGCAOJ_IsPickup;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			CFKFIODHFNC_Act = GPBJHKLFCEP.CFKFIODHFNC_Act;
			KBAHNBKMFDL_IsMinigameClear = GPBJHKLFCEP.KBAHNBKMFDL_IsMinigameClear;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL[i]);
			}
			AAJOOBMPOEP[0].DNJEJEANJGL_Value = GPBJHKLFCEP.AAJOOBMPOEP[0].DNJEJEANJGL_Value;
			MDADLCOCEBN_SessionId = string.Copy(GPBJHKLFCEP.MDADLCOCEBN_SessionId);
			MHKICPIMFEI_PlayCnt = GPBJHKLFCEP.MHKICPIMFEI_PlayCnt;
		}

		//// RVA: 0x119ABE4 Offset: 0x119ABE4 VA: 0x119ABE4
		public bool AGBOGBEOFME(LCFOEDLCCON OIKJFMGEICL)
		{
			if (IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry ||
				ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt ||
				PPKAKKGCAOJ_IsPickup != OIKJFMGEICL.PPKAKKGCAOJ_IsPickup ||
				EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End ||
				LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step ||
				BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date ||
				CFKFIODHFNC_Act != OIKJFMGEICL.CFKFIODHFNC_Act ||
				KBAHNBKMFDL_IsMinigameClear != OIKJFMGEICL.KBAHNBKMFDL_IsMinigameClear ||
				INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show ||
				OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb ||
				MHKICPIMFEI_PlayCnt != OIKJFMGEICL.MHKICPIMFEI_PlayCnt ||
				MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key ||
				MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId
				)
				return false;
			for(int i = 0; i < 50; i++)
			{
				if (!NNMPGOAGEOL[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL[i]))
					return false;
			}
			if (AAJOOBMPOEP[0].DNJEJEANJGL_Value != OIKJFMGEICL.AAJOOBMPOEP[0].DNJEJEANJGL_Value)
				return false;
			return true;
		}

		//// RVA: 0x119B534 Offset: 0x119B534 VA: 0x119B534
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, FMFBNHLMHPL.LCFOEDLCCON OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int BJEPEBMLKOL = 50;
	public const int ICHFGGBPCBJ = 9;
	public const int CCLDBKDCJEH = 1;
	public List<LCFOEDLCCON> FBCJICEPLED = new List<LCFOEDLCCON>(9); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x119DF54 NFKFOODCJJB

	// // RVA: 0x1198528 Offset: 0x1198528 VA: 0x1198528
	public FMFBNHLMHPL_EventAprilFool()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x11985C4 Offset: 0x11985C4 VA: 0x11985C4 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 9; i++)
		{
			LCFOEDLCCON data = new LCFOEDLCCON();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x11989F0 Offset: 0x11989F0 VA: 0x11989F0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 9; i++)
		{
			EDOHBJAPLPF_JsonData quest = new EDOHBJAPLPF_JsonData();
			quest.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int j = 0; j < 50; j++)
			{
				quest.Add(FBCJICEPLED[i].NNMPGOAGEOL[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData nxsq = new EDOHBJAPLPF_JsonData();
			nxsq.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			nxsq.Add(FBCJICEPLED[i].AAJOOBMPOEP[0].DNJEJEANJGL_Value);

			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data2[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data2[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data2[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data2["pickup"] = FBCJICEPLED[i].PPKAKKGCAOJ_IsPickup ? 1 : 0;
			data2[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_Step;
			data2[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = quest;
			data2["nxsq"] = nxsq;
			data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = FBCJICEPLED[i].BEBJKJKBOGH_Date;
			data2["act"] = FBCJICEPLED[i].CFKFIODHFNC_Act;
			data2[AFEHLCGHAEE_Strings.KBAHNBKMFDL_is_minigame_clear] = FBCJICEPLED[i].KBAHNBKMFDL_IsMinigameClear ? 1 : 0;
			data2["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data2[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_SessionId;
			data2["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data2["play_cnt"] = FBCJICEPLED[i].MHKICPIMFEI_PlayCnt;
			data.Add(data2);
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

	// // RVA: 0x1199650 Offset: 0x1199650 VA: 0x1199650 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				int c = block.HNBFOAJIIAL_Count;
				if (c >= 10)
				{
					c = 9;
					isInvalid = true;
				}
				for(int i = 0; i < c; i++)
				{
					EDOHBJAPLPF_JsonData data = block[i];
					FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
					LCFOEDLCCON CCBEKGNDDBE = FBCJICEPLED[i];
					CCBEKGNDDBE.MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
					CCBEKGNDDBE.EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(data, AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
					CCBEKGNDDBE.IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
					CCBEKGNDDBE.ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
					CCBEKGNDDBE.PPKAKKGCAOJ_IsPickup = CJAENOMGPDA_ReadInt(data, "pickup", 1, ref isInvalid) != 0;
					CCBEKGNDDBE.LGADCGFMLLD_Step = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid);
					CCBEKGNDDBE.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
					CCBEKGNDDBE.CFKFIODHFNC_Act = CJAENOMGPDA_ReadInt(data, "act", 0, ref isInvalid);
					CCBEKGNDDBE.KBAHNBKMFDL_IsMinigameClear = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.KBAHNBKMFDL_is_minigame_clear, 0, ref isInvalid) != 0;
					CCBEKGNDDBE.INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(data, "show", 0, ref isInvalid);
					CCBEKGNDDBE.MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(data, AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
					CCBEKGNDDBE.OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(data, "lb", 0, ref isInvalid);
					CCBEKGNDDBE.MHKICPIMFEI_PlayCnt = CJAENOMGPDA_ReadInt(data, "play_cnt", 0, ref isInvalid);
					if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
					{
						EDOHBJAPLPF_JsonData quests = data[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
						int c2 = quests.HNBFOAJIIAL_Count;
						if (c2 > 49)
							c2 = 50;
						for(int j = 0; j < c2; j++)
						{
							EDOHBJAPLPF_JsonData quest2 = quests[j];
							IKCGAJKCPFN data2 = CCBEKGNDDBE.NNMPGOAGEOL[j];
							data2.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(quest2, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref isInvalid);
							data2.EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(quest2, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
							data2.HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(quest2, AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
							data2.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(quest2, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
							data2.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(quest2, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
						}
					}
					if(data.BBAJPINMOEP_Contains("nxsq"))
					{
						EDOHBJAPLPF_JsonData nxsq = data["nxsq"];
						int c2 = nxsq.HNBFOAJIIAL_Count;
						if (c2 > 0)
							c2 = 1;
						IBCGPBOGOGP_ReadIntArray(data, "nxsq", 0, c2, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x119DF5C
							CCBEKGNDDBE.AAJOOBMPOEP[OIPCCBHIKIA].DNJEJEANJGL_Value = JBGEEPFKIGG;
						}, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x119A4B0 Offset: 0x119A4B0 VA: 0x119A4B0 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FMFBNHLMHPL_EventAprilFool o = GPBJHKLFCEP as FMFBNHLMHPL_EventAprilFool;
		for (int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(o.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x119AA04 Offset: 0x119AA04 VA: 0x119AA04 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FMFBNHLMHPL_EventAprilFool o = GPBJHKLFCEP as FMFBNHLMHPL_EventAprilFool;
		for (int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if (!FBCJICEPLED[i].AGBOGBEOFME(o.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x119B128 Offset: 0x119B128 VA: 0x119B128 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}

	// // RVA: 0x119DD38 Offset: 0x119DD38 VA: 0x119DD38 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
