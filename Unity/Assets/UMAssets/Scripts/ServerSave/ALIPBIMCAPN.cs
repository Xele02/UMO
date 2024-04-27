
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ALIPBIMCAPN_EventBoxGacha", true)]
public class ALIPBIMCAPN { }
public class ALIPBIMCAPN_EventBoxGacha : KLFDBFMNLBL_ServerSaveBlock
{
	public class EHDCAEHLLKF
	{
		public int ENOBDCFHELD; // 0x8
		public int IILDKHILHGA_Crypted; // 0xC
		public int LIEACBPCMBC_Crypted; // 0x10

		public int JBDBPCMMBIH_Id { get { return IILDKHILHGA_Crypted ^ ENOBDCFHELD; } set { IILDKHILHGA_Crypted = value ^ ENOBDCFHELD; } } //0xCDDC40 OMNPGGNMPAJ 0xCDB324 GMJGOPKKIEC
		public int AGKANHNHECE_Remain { get { return LIEACBPCMBC_Crypted ^ ENOBDCFHELD; } set { LIEACBPCMBC_Crypted = value ^ ENOBDCFHELD; } } //0xCDDC50 MKKGOKMADFP 0xCDB334 BPGBPFPDJLF

		// // RVA: 0xCDDC60 Offset: 0xCDDC60 VA: 0xCDDC60
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{
			ENOBDCFHELD = KNEFBLHBDBG;
			JBDBPCMMBIH_Id = 0;
			AGKANHNHECE_Remain = 0;
		}

		// // RVA: 0xCDDC70 Offset: 0xCDDC70 VA: 0xCDDC70
		public void ODDIHGPONFL(EHDCAEHLLKF GPBJHKLFCEP)
		{
			JBDBPCMMBIH_Id = GPBJHKLFCEP.JBDBPCMMBIH_Id;
			AGKANHNHECE_Remain = GPBJHKLFCEP.AGKANHNHECE_Remain;
		}

		// // RVA: 0xCDDCD4 Offset: 0xCDDCD4 VA: 0xCDDCD4
		public bool AGBOGBEOFME(EHDCAEHLLKF OIKJFMGEICL)
		{
			return JBDBPCMMBIH_Id == OIKJFMGEICL.JBDBPCMMBIH_Id && 
				AGKANHNHECE_Remain == OIKJFMGEICL.AGKANHNHECE_Remain;
		}

		// // RVA: 0xCDAAD8 Offset: 0xCDAAD8 VA: 0xCDAAD8
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data["id"] = JBDBPCMMBIH_Id;
			data["remain"] = AGKANHNHECE_Remain;
			return data;
		}

		// // RVA: 0xCDDD50 Offset: 0xCDDD50 VA: 0xCDDD50
		// public int ALHOCKONAIH() { }
	}

	public class GLNFOMDKJJH
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public int KGAHLMDIFIE_Crypted; // 0x10
		public int JHPJAPKMCML_Crypted; // 0x14
		public int KEMHBBFKOPG_Crypted; // 0x18
		public int MGFKOBJNOMH_Crypted; // 0x1C
		public int CNOKFGJGEJI_Crypted; // 0x20
		public int FJEOGBHLFLN_Crypted; // 0x24
		public int EHBPLFINKDK_Crypted; // 0x28
		public int HLOOHJBOGKI_Crypted; // 0x2C
		public int BBLGDHOFIAI_Crypted; // 0x30
		public int GPIJJMHOJNE_Crypted; // 0x34
		public int NNAOOLFLCAE_Crypted; // 0x38
		public int OGBIPMPCBEF_Crypted; // 0x3C
		public List<EHDCAEHLLKF> PKPLOGBIDIG_Prizes = new List<EHDCAEHLLKF>(100); // 0x40
		public long EGBOHDFBAPB_End; // 0x48
		public bool IMFBCJOIJKJ_Entry; // 0x50

		public int DNJLJMKKDNA_EventId { get { return KGAHLMDIFIE_Crypted ^ ENOBDCFHELD; } set { KGAHLMDIFIE_Crypted = value ^ ENOBDCFHELD; JHPJAPKMCML_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAA78 DONEINFNFCP 0xCDB2AC EPEBGHFNMKP
		public int FEFCFGNGPGC_Pickup { get { return KEMHBBFKOPG_Crypted ^ ENOBDCFHELD; } set { KEMHBBFKOPG_Crypted = value ^ ENOBDCFHELD; MGFKOBJNOMH_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAA88 PPDMEDMOJIM 0xCDB2C0 COPALOPLHOC
		public int IMMDGJAOPCD_BoxId { get { return CNOKFGJGEJI_Crypted ^ ENOBDCFHELD; } set { CNOKFGJGEJI_Crypted = value ^ ENOBDCFHELD; FJEOGBHLFLN_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAA98 KADOBOBABJG 0xCDB2D4 BLLCKEDEKHH
		public int NNCCGILOOIE_BoxCnt { get { return EHBPLFINKDK_Crypted ^ ENOBDCFHELD; } set { EHBPLFINKDK_Crypted = value ^ ENOBDCFHELD; HLOOHJBOGKI_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAAA8 IEPNLGLLFBN 0xCDB2E8 JKBPEBDAPDF
		public int IGHIADKHGHG_DrawCnt { get { return BBLGDHOFIAI_Crypted ^ ENOBDCFHELD; } set { BBLGDHOFIAI_Crypted = value ^ ENOBDCFHELD; GPIJJMHOJNE_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAAB8 DPDEKAMDOFF 0xCDB2FC KPBIELPFDEP
		public int BGCOKABBHNC_GachaTicketCnt { get { return NNAOOLFLCAE_Crypted ^ ENOBDCFHELD; } set { NNAOOLFLCAE_Crypted = value ^ ENOBDCFHELD; OGBIPMPCBEF_Crypted = value ^ FCEJCHGLFGN; } } // 0xCDAAC8 MNAHDPJGFOP 0xCDB310 DFEOLBNOMJE

		// // RVA: 0xCDA114 Offset: 0xCDA114 VA: 0xCDA114
		public void LHPDDGIJKNB(bool IJKLOFCMKCK = false)
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			if(!IJKLOFCMKCK)
			{
				EGBOHDFBAPB_End = 0;
				DNJLJMKKDNA_EventId = 0;
				IMFBCJOIJKJ_Entry = false;
				BGCOKABBHNC_GachaTicketCnt = 0;
			}
			FEFCFGNGPGC_Pickup = 0;
			IMMDGJAOPCD_BoxId = 0;
			NNCCGILOOIE_BoxCnt = 0;
			IGHIADKHGHG_DrawCnt = 0;
			PKPLOGBIDIG_Prizes.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 100; i++)
			{
				EHDCAEHLLKF data = new EHDCAEHLLKF();
				data.LHPDDGIJKNB(k);
				PKPLOGBIDIG_Prizes.Add(data);
				k *= 13;
			}
		}

		// // RVA: 0xCDB514 Offset: 0xCDB514 VA: 0xCDB514
		public void ODDIHGPONFL(GLNFOMDKJJH GPBJHKLFCEP)
		{
			DNJLJMKKDNA_EventId = GPBJHKLFCEP.DNJLJMKKDNA_EventId;
			FEFCFGNGPGC_Pickup = GPBJHKLFCEP.FEFCFGNGPGC_Pickup;
			IMMDGJAOPCD_BoxId = GPBJHKLFCEP.IMMDGJAOPCD_BoxId;
			NNCCGILOOIE_BoxCnt = GPBJHKLFCEP.NNCCGILOOIE_BoxCnt;
			IGHIADKHGHG_DrawCnt = GPBJHKLFCEP.IGHIADKHGHG_DrawCnt;
			BGCOKABBHNC_GachaTicketCnt = GPBJHKLFCEP.BGCOKABBHNC_GachaTicketCnt;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			for(int i = 0; i < 100; i++)
			{
				PKPLOGBIDIG_Prizes[i].ODDIHGPONFL(GPBJHKLFCEP.PKPLOGBIDIG_Prizes[i]);
			}
		}

		// // RVA: 0xCDB928 Offset: 0xCDB928 VA: 0xCDB928
		public bool AGBOGBEOFME(GLNFOMDKJJH OIKJFMGEICL)
		{
			if(DNJLJMKKDNA_EventId != OIKJFMGEICL.DNJLJMKKDNA_EventId) return false;
			if(FEFCFGNGPGC_Pickup != OIKJFMGEICL.FEFCFGNGPGC_Pickup) return false;
			if(IMMDGJAOPCD_BoxId != OIKJFMGEICL.IMMDGJAOPCD_BoxId) return false;
			if(NNCCGILOOIE_BoxCnt != OIKJFMGEICL.NNCCGILOOIE_BoxCnt) return false;
			if(IGHIADKHGHG_DrawCnt != OIKJFMGEICL.IGHIADKHGHG_DrawCnt) return false;
			if(BGCOKABBHNC_GachaTicketCnt != OIKJFMGEICL.BGCOKABBHNC_GachaTicketCnt) return false;
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End) return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry) return false;
			for(int i = 0; i < 100; i++)
			{
				if(!PKPLOGBIDIG_Prizes[i].AGBOGBEOFME(OIKJFMGEICL.PKPLOGBIDIG_Prizes[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0xCDC130 Offset: 0xCDC130 VA: 0xCDC130
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, ALIPBIMCAPN.GLNFOMDKJJH OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int MJFKKHOFMBO = 100;
	public const int ICHFGGBPCBJ = 6;
	public List<GLNFOMDKJJH> FBCJICEPLED = new List<GLNFOMDKJJH>(); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0xCDDC38 NFKFOODCJJB

	// // RVA: 0xCD9EFC Offset: 0xCD9EFC VA: 0xCD9EFC
	public ALIPBIMCAPN_EventBoxGacha()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0xCD9F98 Offset: 0xCD9F98 VA: 0xCD9F98 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 6; i++)
		{
			GLNFOMDKJJH data = new GLNFOMDKJJH();
			data.LHPDDGIJKNB(false);
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0xCDA2C4 Offset: 0xCDA2C4 VA: 0xCDA2C4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 6; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data2[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data2["event_id"] = FBCJICEPLED[i].DNJLJMKKDNA_EventId;
			data2["pickup"] = FBCJICEPLED[i].FEFCFGNGPGC_Pickup;
			data2["box_id"] = FBCJICEPLED[i].IMMDGJAOPCD_BoxId;
			data2["box_cnt"] = FBCJICEPLED[i].NNCCGILOOIE_BoxCnt;
			data2["draw_cnt"] = FBCJICEPLED[i].IGHIADKHGHG_DrawCnt;
			data2["gacha_ticket_cnt"] = FBCJICEPLED[i].BGCOKABBHNC_GachaTicketCnt;
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 100; j++)
			{
				data3.Add(FBCJICEPLED[i].PKPLOGBIDIG_Prizes[j].NOJCMGAFAAC());
			}
			data2["prize"] = data3;
			data.Add(data2);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xCDABFC Offset: 0xCDABFC VA: 0xCDABFC Slot: 6
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
				if(block.HNBFOAJIIAL_Count > 0)
				{
					int cnt = block.HNBFOAJIIAL_Count;
					if(cnt >= 7)
					{
						isInvalid = true;
						cnt = 6;
					}
					for(int i = 0; i < cnt; i++)
					{
						FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNJLJMKKDNA_EventId = CJAENOMGPDA_ReadInt(block[i], "event_id", 0, ref isInvalid);
						FBCJICEPLED[i].FEFCFGNGPGC_Pickup = CJAENOMGPDA_ReadInt(block[i], "pickup", 0, ref isInvalid);
						FBCJICEPLED[i].IMMDGJAOPCD_BoxId = CJAENOMGPDA_ReadInt(block[i], "box_id", 0, ref isInvalid);
						FBCJICEPLED[i].NNCCGILOOIE_BoxCnt = CJAENOMGPDA_ReadInt(block[i], "box_cnt", 0, ref isInvalid);
						FBCJICEPLED[i].IGHIADKHGHG_DrawCnt = CJAENOMGPDA_ReadInt(block[i], "draw_cnt", 0, ref isInvalid);
						FBCJICEPLED[i].BGCOKABBHNC_GachaTicketCnt = CJAENOMGPDA_ReadInt(block[i], "gacha_ticket_cnt", 0, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains("prize"))
						{
							EDOHBJAPLPF_JsonData data =  block[i]["prize"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 100)
								cnt2 = 100;
							for(int j = 0; j < 100; j++)
							{
								FBCJICEPLED[i].PKPLOGBIDIG_Prizes[j].JBDBPCMMBIH_Id = CJAENOMGPDA_ReadInt(data[j], "id", 0, ref isInvalid);
								FBCJICEPLED[i].PKPLOGBIDIG_Prizes[j].AGKANHNHECE_Remain = CJAENOMGPDA_ReadInt(data[j], "remain", 0, ref isInvalid);
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

	// // RVA: 0xCDB344 Offset: 0xCDB344 VA: 0xCDB344 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ALIPBIMCAPN_EventBoxGacha other = GPBJHKLFCEP as ALIPBIMCAPN_EventBoxGacha;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0xCDB748 Offset: 0xCDB748 VA: 0xCDB748 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		ALIPBIMCAPN_EventBoxGacha other = GPBJHKLFCEP as ALIPBIMCAPN_EventBoxGacha;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xCDBD24 Offset: 0xCDBD24 VA: 0xCDBD24 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0xCDD9A4 Offset: 0xCDD9A4 VA: 0xCDD9A4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
